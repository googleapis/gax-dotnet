/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json.Linq;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// An IAsyncStreamReader implementation that reads an array of messages
/// from HTTP stream as they arrive in (partial) JSON chunks. 
/// </summary>
/// <typeparam name="TResponse">Type of proto messages in the stream</typeparam>
internal class PartialDecodingStreamReader<TResponse> : IAsyncStreamReader<TResponse>
{
    private readonly Task<TextReader> _textReaderTask;
    private readonly Func<string, TResponse> _responseConverter;

    private readonly Queue<TResponse> _readyResults;
    private readonly StringBuilder _currentBuffer;
    
    private TextReader _textReader;
    private bool _arrayClosed;

    /// <summary>
    /// Creates the StreamReader
    /// </summary>
    /// <param name="textReaderTask">A stream reader returning partial JSON chunks</param>
    /// <param name="responseConverter">A function to transform a well-formed JSON object into the proto message.</param>
    public PartialDecodingStreamReader(Task<TextReader> textReaderTask, Func<string, TResponse> responseConverter)
    {
        _textReaderTask = textReaderTask;
        _responseConverter = responseConverter;

        _readyResults = new Queue<TResponse>();
        _currentBuffer = new StringBuilder();

        _textReader = null;
        _arrayClosed = false;
    }

    /// <inheritdoc />
    public async Task<bool> MoveNext(CancellationToken cancellationToken)
    {
        _textReader ??= await _textReaderTask.ConfigureAwait(false);

        if (_readyResults.Count > 0)
        {
            Current = _readyResults.Dequeue();
            return true;
        }

        if (_arrayClosed)
        {
            return false;
        }

        var buffer = new char[8000];
        while (_readyResults.Count == 0)
        {
            var taskRead = _textReader.ReadAsync(buffer, 0, buffer.Length);
            var cancellationTask = Task.Delay(-1, cancellationToken);
            var resultTask = await Task.WhenAny(taskRead, cancellationTask).ConfigureAwait(false);

            if (resultTask == cancellationTask)
            {
                // If the cancellationTask "wins" `Task.WhenAny` by being cancelled, the following await will throw TaskCancelledException.
                await cancellationTask.ConfigureAwait(false);
            }

            var readLen = await taskRead.ConfigureAwait(false);
            if (readLen == 0)
            {
                if (!_arrayClosed)
                {
                    var errorText = "Closing `]` bracket not received after iterating through the stream. " +
                                    "This means that streaming ended without all objects transmitted. " +
                                    "It is likely a result of server or network error.";
                    throw new InvalidOperationException(errorText);
                }

                return false;
            }

            var readChars = buffer.Take(readLen);
            foreach (var c in readChars)
            {
                // Closing bracket for the top-level array
                if (_currentBuffer.Length == 0 && c == ']')
                {
                    // TODO[virost, jskeet, 11/2022] Fix with tokenizer:
                    // it's possible to receive more data after the closing `]`
                    _arrayClosed = true;
                    continue;
                }

                // Between-objects commas and spaces, as well as an opening bracket
                // for the top-level array.
                if (_currentBuffer.Length == 0 && c != '{')
                {
                    continue;
                }
                
                _currentBuffer.Append(c);
                if (c != '}')
                {
                    continue;
                }

                var currentStr = _currentBuffer.ToString();
                try
                {
                    // This will throw unless the characters in the _currentBuffer
                    // add up to a correct JSON and since the _currentBuffer always
                    // starts with an opening `{` bracket from one of the
                    // top-level array's element's,
                    // this will throw unless _currentBuffer contains one message.
                    // TODO[virost, jskeet, 11/2022] Use a JSON tokenizer instead
                    JObject.Parse(currentStr);
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    // Tried to parse a partial json because the `}` was a part of
                    // a string or a child inner object.
                    continue;
                }

                TResponse responseElement = _responseConverter(currentStr);
                _readyResults.Enqueue(responseElement);
                _currentBuffer.Clear();
            }
        }

        Current = _readyResults.Dequeue();
        return true;
    }

    /// <inheritdoc />
    public TResponse Current { get; private set; }
}
