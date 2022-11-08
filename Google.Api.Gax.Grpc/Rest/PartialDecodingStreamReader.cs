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
public class PartialDecodingStreamReader<TResponse> : IAsyncStreamReader<TResponse>
{
    private readonly Func<string, TResponse> _parsing;

    private readonly Queue<TResponse> _readyResults;
    private readonly StringBuilder _currentBuffer;
    
    private readonly StreamReader _streamReader;
    private bool _arrayClosed;

    /// <summary>
    /// Creates the StreamReader
    /// </summary>
    /// <param name="stream">A stream with partial JSON</param>
    /// <param name="parsing">A function to transform a well-formed JSON object into the proto message.</param>
    public PartialDecodingStreamReader(Stream stream, Func<string, TResponse> parsing)
    {
        _streamReader = new StreamReader(stream);
        _parsing = parsing;
        
        _readyResults = new Queue<TResponse>();
        _currentBuffer = new StringBuilder();
        _arrayClosed = false;
    }

    /// <inheritdoc />
    public async Task<bool> MoveNext(CancellationToken cancellationToken)
    {
        if (_readyResults.Count > 0)
        {
            Current = _readyResults.Dequeue();
            return true;
        }

        while (_readyResults.Count == 0)
        {
            var buffer = new char[1000];
            var taskRead = _streamReader.ReadAsync(buffer, 0, buffer.Length);
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

                break;
            }

            var readChars = buffer.Take(readLen);
            foreach (var c in readChars)
            {
                // Closing bracket for the top-level array
                if (_currentBuffer.Length == 0 && c == ']')
                {
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

                try
                {
                    // This will throw unless the characters in the _currentBuffer
                    // add up to a correct JSON and since the _currentBuffer always
                    // starts with an opening `{` bracket from one of the
                    // top-level array's element's,
                    // this will throw unless _currentBuffer contains one message.
                    JObject.Parse(_currentBuffer.ToString());
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    // Tried to parse a partial json because the `}` was a part of
                    // a string or a child inner object.
                    continue;
                }

                TResponse obj = _parsing(_currentBuffer.ToString());
                _readyResults.Enqueue(obj);
                _currentBuffer.Clear();
            }
        }

        if (!_readyResults.Any())
        {
            return false;
        }

        Current = _readyResults.Dequeue();
        return true;
    }

    /// <inheritdoc />
    public TResponse Current { get; private set; }
}
