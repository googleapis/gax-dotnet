using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public class PartialDecodingStreamReader<TResponse> : IAsyncStreamReader<TResponse>
{
    private readonly Func<string, TResponse> _parsing;

    private readonly Queue<TResponse> _readyResults;
    private readonly StringBuilder _currentBuffer;

    private bool _arrayClosed;
    private readonly Stream _stream;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpResponseTask"></param>
    /// <param name="parsing"></param>
    public PartialDecodingStreamReader(Task<HttpResponseMessage> httpResponseTask, Func<string, TResponse> parsing)
    {
        _parsing = parsing;

        var httpResponse = httpResponseTask.ConfigureAwait(false).GetAwaiter().GetResult();
        // TODO [virost, 11/5]: should I wrap this exception?
        httpResponse.EnsureSuccessStatusCode();
        _stream = httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        
        _readyResults = new Queue<TResponse>();
        _currentBuffer = new StringBuilder();
        _arrayClosed = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> MoveNext(CancellationToken cancellationToken)
    {
        if (_readyResults.Count > 0)
        {
            Current = _readyResults.Dequeue();
            return true;
        }

        while (_readyResults.Count == 0)
        {
            // StreamReader.ReadAsync does not have an overload with CancellationToken in 4.6.2, but Stream.ReadAsync does.
            // TODO [virost, 11/5]: 1000 is completely arbitrary, is there a better number?
            var buffer = new byte[1000];

            // TODO [virost, 11/5]: should I wrap whatever this throws?
            var readLen = await _stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);

            if (readLen == 0)
            {
                if (!_arrayClosed)
                {
                    var errorText = "Closing bracket not received after iterating through the stream. " +
                                    "This means that streaming ended without all objects transmitted. " +
                                    "It is likely a result of server or network error.";
                    throw new InvalidOperationException(errorText);
                }

                break;
            }

            var memStream = new MemoryStream(buffer, 0, readLen);
            var streamReader = new StreamReader(memStream);
            var readChars = streamReader.ReadToEnd();

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
                    TResponse obj = _parsing(_currentBuffer.ToString());
                    _readyResults.Enqueue(obj);
                    _currentBuffer.Clear();
                }
                catch (InvalidJsonException)
                {
                }
            }
        }

        if (!_readyResults.Any())
        {
            return false;
        }

        Current = _readyResults.Dequeue();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    public TResponse Current { get; private set; }
}
