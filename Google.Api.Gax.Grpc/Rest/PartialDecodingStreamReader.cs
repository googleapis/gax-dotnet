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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest;

using static Google.Api.Gax.Grpc.Rest.JsonStateTracker.NextAction;

// TODO: Disposal of the TextReader
// TODO: Evaluate what exception should be thrown, in different cases:
//       - Errors encountered that haven't naturally caused an exception
//       - Regular exceptions (e.g. IOException, InvalidProtobufException)
//       - Cancellation
//       We should retain an ExceptionDispatchInfo so we can throw the
//       right exception consistently (on follow-up calls) rather than
//       just a message.

/// <summary>
/// An IAsyncStreamReader implementation that reads an array of messages
/// from HTTP stream as they arrive in (partial) JSON chunks. 
/// </summary>
/// <typeparam name="TResponse">Type of proto messages in the stream</typeparam>
internal class PartialDecodingStreamReader<TResponse> : IAsyncStreamReader<TResponse>
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
    private string _errorMessage;

    /// <inheritdoc />
    public TResponse Current { get; private set; }

    /// <summary>
    /// Creates a new instance which will read data from the TextReader provided by
    /// <paramref name="textReaderTask"/>, and convert each object within a top-level JSON array
    /// into a response using <paramref name="responseConverter"/>.
    /// </summary>
    /// <param name="textReaderTask">A task to provide text reader returning partial JSON chunks</param>
    /// <param name="responseConverter">A function to transform a well-formed JSON object into the proto message.</param>
    public PartialDecodingStreamReader(Task<TextReader> textReaderTask, Func<string, TResponse> responseConverter)
    {
        _textReaderTask = textReaderTask;
        _responseConverter = responseConverter;

        _queuedResponses = new Queue<TResponse>();
        _currentResponseBuffer = new StringBuilder();

        _jsonState = new JsonStateTracker();
    }

    /// <inheritdoc />
    public async Task<bool> MoveNext(CancellationToken cancellationToken)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (_queuedResponses.Count > 0)
            {
                Current = _queuedResponses.Dequeue();
                return true;
            }

            // Throwing an exception takes priority over marking the sequence as completed.
            // But if there were valid responses *before* we detected an error, we'll return those first.
            if (_errorMessage is string)
            {
                // TODO: Should this actually be an RpcException?
                throw new InvalidOperationException(_errorMessage);
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
        try
        {
            var textReader = await AwaitWithCancellation(_textReaderTask, cancellationToken).ConfigureAwait(false);

            var readTask = textReader.ReadAsync(_readBuffer, 0, _readBuffer.Length);
            int charsRead = await AwaitWithCancellation(readTask, cancellationToken).ConfigureAwait(false);

            if (charsRead == 0)
            {
                _endOfData = true;
                if (!_completed)
                {
                    _errorMessage = "Response stream completed without a closing array";
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
                        _errorMessage = "Invalid JSON response.";
                        // No need to read any more: we're in a failure mode now, other than
                        // returning any already-parsed responses.
                        return;
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
        // If *anything* fails, this signals an overall failure.
        // Let the calling code effectively rethrow. (We lose the stack trace, which isn't ideal, admittedly.)
        catch (Exception e) when (e is not OperationCanceledException)
        {
            _errorMessage = e.Message;
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
        // has been cancelled.
        return task.Result;
    }
}
