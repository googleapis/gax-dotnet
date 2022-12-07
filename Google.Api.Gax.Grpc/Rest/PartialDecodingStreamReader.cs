/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest;

using static Google.Api.Gax.Grpc.Rest.JsonStateTracker.NextAction;

/// <summary>
/// An IAsyncStreamReader implementation that reads an array of messages
/// from HTTP stream as they arrive in (partial) JSON chunks. 
/// </summary>
/// <typeparam name="TResponse">Type of proto messages in the stream</typeparam>
internal class PartialDecodingStreamReader<TResponse> : IAsyncStreamReader<TResponse>, IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Task which will return a reader containing the data.
    /// </summary>
    private readonly Task<TextReader> _textReaderTask;

    /// <summary>
    /// Converter to parse each individual JSON object in the response stream.
    /// </summary>
    private readonly Func<string, TResponse> _responseConverter;

    /// <summary>
    /// Cancellation context used to observe deadlines, original cancellation tokens from call options,
    /// and gRPC-method-based cancellation.
    /// </summary>
    private readonly RpcCancellationContext _cancellationContext;

    /// <summary>
    /// Responses which have already been parsed, and are ready to return to the caller.
    /// </summary>
    private readonly Queue<TResponse> _queuedResponses;

    /// <summary>
    /// The current response that we're building up.
    /// </summary>
    private readonly StringBuilder _currentResponseBuffer;
    
    /// <summary>
    /// The buffer we use when reading from the text reader.
    /// We don't need to actually preserve state between calls,
    /// as we process the whole read buffer on each call, but
    /// this avoids allocating multiple times.
    /// (As an alternative, we could allocate a smaller amount on the stack
    /// each time.)
    /// </summary>
    private readonly char[] _readBuffer = new char[1024 * 4];

    /// <summary>
    /// Keeps track of our state within the stream of JSON responses.
    /// This is not a full JSON tokenizer, but has just enough logic to
    /// recognize "we've reached the end of one response," or "we've reached
    /// the end of all responses," or "something's gone wrong". (It doesn't
    /// try to perform complete validation, but spots unexpected data between
    /// elements etc.)
    /// </summary>
    private JsonStateTracker _jsonState;

    /// <summary>
    /// Will be set to true when all responses have been read from the stream.
    /// (Any responses queued in <see cref="_queuedResponses"/> should still be returned.)
    /// This does *not* mean we've reached the end of the data, however.
    /// </summary>
    private bool _completed;

    /// <summary>
    /// Set to true when we've reached the end of the data. If this happens without
    /// <see cref="_completed"/> being true, that causes an error.
    /// </summary>
    private bool _endOfData;

    /// <summary>
    /// Set to non-null on any failure.
    /// </summary>
    private ExceptionDispatchInfo _exceptionInfo;

    private bool _disposed;

    /// <inheritdoc />
    public TResponse Current { get; private set; }

    /// <summary>
    /// Creates a new instance which will read data from the TextReader provided by
    /// <paramref name="textReaderTask"/>, and convert each object within a top-level JSON array
    /// into a response using <paramref name="responseConverter"/>.
    /// </summary>
    /// <param name="textReaderTask">A task to provide text reader returning partial JSON chunks</param>
    /// <param name="responseConverter">A function to transform a well-formed JSON object into the proto message.</param>
    /// <param name="cancellationContext">The cancellation context for the RPC.</param>
    public PartialDecodingStreamReader(Task<TextReader> textReaderTask, Func<string, TResponse> responseConverter,
        RpcCancellationContext cancellationContext)
    {
        _textReaderTask = textReaderTask;
        _responseConverter = responseConverter;
        _cancellationContext = cancellationContext;

        _queuedResponses = new Queue<TResponse>();
        _currentResponseBuffer = new StringBuilder();

        _jsonState = new JsonStateTracker();
    }

    /// <inheritdoc />
    public async Task<bool> MoveNext(CancellationToken cancellationToken)
    {
        // There are three layers, effectively:
        // - This "outer" method handles disposal and exception replay
        // - The RpcCancellationContext provides a "middle" method which handles cancellation
        // - The "inner" implementation which can just work in a way that doesn't
        //   really need to worry about this being part of an RPC.

        // If we've ever thrown, throw the same exception again.
        _exceptionInfo?.Throw();
        // If we've previously reached the end of the data, indicate that again.
        // (This avoids trying to use a disposed RpcCancellationContext to run a task.)
        if (_endOfData)
        {
            return false;
        }

        bool disposeOnExit = true;
        try
        {
            var result = await _cancellationContext.RunAsync(MoveNextImpl, cancellationToken).ConfigureAwait(false);
            disposeOnExit = !result; // Dispose if we're returning false
            return result;
        }
        catch (Exception e)
        {
            // Remember the exception on its way out, to replay it on any future calls.
            _exceptionInfo = ExceptionDispatchInfo.Capture(e);
            throw;
        }
        finally
        {
            if (disposeOnExit)
            {
                Dispose();
            }
        }
    }

    private async Task<bool> MoveNextImpl(CancellationToken cancellationToken)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (_queuedResponses.Count > 0)
            {
                Current = _queuedResponses.Dequeue();
                return true;
            }

            if (_endOfData)
            {
                return false;
            }

            // We don't currently know what to do, so read more data and see whether that
            // satisfies one of the above conditions. (We may need to loop multiple times.)
            await ReadAndProcessData(cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Called when we don't have a queued response and haven't reached a terminal state (error or completed).
    /// </summary>
    /// <returns></returns>
    private async Task ReadAndProcessData(CancellationToken cancellationToken)
    {
        var textReader = await AwaitWithCancellation(_textReaderTask, cancellationToken).ConfigureAwait(false);

        var readTask = textReader.ReadAsync(_readBuffer, 0, _readBuffer.Length);
        int charsRead = await AwaitWithCancellation(readTask, cancellationToken).ConfigureAwait(false);

        if (charsRead == 0)
        {
            _endOfData = true;
            if (!_completed)
            {
                throw new RpcException(new Status(StatusCode.DataLoss, "Response stream ended abruptly."));
            }
            return;
        }

        // Note: we process the whole of the buffer, even if we see end-of-response or end-of-stream.
        for (int i = 0; i < charsRead; i++)
        {
            char c = _readBuffer[i];
            var nextAction = _jsonState.Push(c);
            switch (nextAction)
            {
                case ParseResponse:
                    _currentResponseBuffer.Append(c);
                    _queuedResponses.Enqueue(_responseConverter(_currentResponseBuffer.ToString()));
                    _currentResponseBuffer.Clear();
                    break;
                case SignalEndOfResponses:
                    // We remember that we've seen the "end of responses" but continue to read
                    // until the end of the data, to spot badly-behaved responses that include
                    // data after the closing array. The state tracker will just return
                    // IgnoreAndContinue or SignalError from here onwards.
                    _completed = true;
                    break;
                case SignalError:
                    // Note: we don't have any more information about the way in which the JSON
                    // was invalid, but we really don't expect to see this anyway.
                    throw new RpcException(new Status(StatusCode.DataLoss, "Invalid JSON returned."));
                case IgnoreAndContinue:
                    break;
                case BufferAndContinue:
                    _currentResponseBuffer.Append(c);
                    break;
                default:
                    throw new InvalidOperationException($"Bug in GAX support library: unhandled state: {nextAction}");
            }
        }
    }

    /// <summary>
    /// Returns the value from the original task provided in <paramref name="task"/>, or throws
    /// if <paramref name="cancellationToken"/> was cancelled before the task completed.
    /// </summary>
    private static async Task<T> AwaitWithCancellation<T>(Task<T> task, CancellationToken cancellationToken)
    {
        var cancellationTask = Task.Delay(-1, cancellationToken);
        await Task.WhenAny(task, cancellationTask).ConfigureAwait(false);
        cancellationToken.ThrowIfCancellationRequested();
        // If we've got this far, then our real task must have completed:
        // the only way for cancellationTask to complete is if cancellationToken
        // has been cancelled. However, we still need to await it instead
        // of using .Result so that exceptions are propagated appropriately.
        return await task.ConfigureAwait(false);
    }

    /// <summary>
    /// Disposes of the underlying reader, in a fire-and-forget manner.
    /// The reader may not yet be available, so a task is attached to the reader-providing
    /// task to dispose of the reader when it becomes available.
    /// The <see cref="ValueTask"/> returned by this implementation will already be completed.
    /// </summary>
    public ValueTask DisposeAsync()
    {
        Dispose();
        return default;
    }

    /// <summary>
    /// Disposes of the underlying reader, in a fire-and-forget manner, as well as the
    /// cancellation context.
    /// The reader may not yet be available, so a task is attached to the reader-providing
    /// task to dispose of the reader when it becomes available.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        _disposed = true;

        _cancellationContext.Dispose();

        // Note: the returned task is deliberately ignored. It's fire-and-forget.
        _textReaderTask.ContinueWith(DisposeReader, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.HideScheduler);

        void DisposeReader(Task<TextReader> task)
        {
            try
            {
                // We're only scheduling this to execute if the task completed normally,
                // so it's fine to access .Result.
                task.Result?.Dispose();
            }
            catch
            {
                // Just swallow; this is best effort.
            }
        }
    }
}
