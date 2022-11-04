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
    private readonly StreamReader _sr;

    private readonly Queue<TResponse> _readyResults;
    private readonly StringBuilder _currentBuffer;

    private bool _arrayClosed;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpResponseTask"></param>
    /// <param name="parsing"></param>
    public PartialDecodingStreamReader(Task<HttpResponseMessage> httpResponseTask, Func<string, TResponse> parsing)
    {
        _parsing = parsing;

        var httpResponse = httpResponseTask.ConfigureAwait(false).GetAwaiter().GetResult();
        var stream = httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        _sr = new StreamReader(stream);
        
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
        if (_sr.EndOfStream)
        {
            return false;
        }

        if (_readyResults.Count > 0)
        {
            Current = _readyResults.Dequeue();
            return true;
        }

        while (_readyResults.Count == 0 && !_sr.EndOfStream)
        {
            var buffer = new char[1000];
            var s = await _sr.ReadAsync(buffer, 0, 100).ConfigureAwait(false);
            if (s == 0) continue;

            foreach (var c in buffer.Take(s))
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

        if (_sr.EndOfStream && !_arrayClosed)
        {
            var errorText = "Closing bracket not received after iterating through the stream. " +
                            "This means that streaming ended without all objects transmitted. " +
                            "It is likely a result of server or network error.";
            throw new InvalidOperationException(errorText);
        }

        if (!_readyResults.Any())
        {
            return false;
        }

        Current = _readyResults.Dequeue();
        CurrentStr = _currentBuffer.ToString();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    public TResponse Current { get; private set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string CurrentStr { get; private set; }
}
