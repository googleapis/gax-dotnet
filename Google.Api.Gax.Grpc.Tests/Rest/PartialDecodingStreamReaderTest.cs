/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class PartialDecodingStreamReaderTest
{
    private static readonly string ArrayOfObjectsJson = @"
[
  {
    ""foo"": 1
  },
  {
    ""bar"": 2
  }
]
";

    /// <summary>
    /// Test coarse split data.
    /// </summary>
    [Fact]
    public async Task ValidData_LineByLine()
    {
        TextReader reader = new ReplayingStreamReader(ArrayOfObjectsJson.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
        var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["foo"], 1);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["bar"], 2);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);
    }

    /// <summary>
    /// Test data split by characters.
    /// </summary>
    [Fact]
    public async Task ValidData_CharByChar()
    {
        TextReader reader = new ReplayingStreamReader(ArrayOfObjectsJson.Select(c => c.ToString()));
        var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["foo"], 1);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["bar"], 2);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);
    }

    /// <summary>
    /// Test when data breaks off unexpectedly.
    /// </summary>
    [Fact]
    public async Task IncompleteData()
    {
        string[] data = { "[", "{ \"foo\": 1 }", "," /* end of stream - we want more results... */};
        TextReader reader = new ReplayingStreamReader(data);
        var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["foo"], 1);

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => decodingReader.MoveNext(CancellationToken.None));
        Assert.Contains("array", ex.Message);
    }

    /// <summary>
    /// Test when data is empty array.
    /// </summary>
    [Fact]
    public async Task EmptyValidData()
    {
        TextReader reader = new ReplayingStreamReader(new[] { "[]" });
        var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);
    }

    [Fact]
    public async Task NonWhitespaceAfterClosingArray()
    {
        TextReader reader = new ReplayingStreamReader(new[] { "[] ," });
        var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

        await Assert.ThrowsAsync<InvalidOperationException>(() => decodingReader.MoveNext(CancellationToken.None));
    }

    /// <summary>
    /// This doesn't test aspects like "cancellation during a read" but that's harder to do.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task CancellationObserved()
    {
        TextReader reader = new ReplayingStreamReader(new[] { "[] ," });
        var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);
        var token = new CancellationToken(canceled: true);
        await Assert.ThrowsAsync<OperationCanceledException>(() => decodingReader.MoveNext(token));
    }

    /// <summary>
    /// A TextReader which response to Read requests by copying data from the given strings.
    /// </summary>
    private class ReplayingStreamReader : TextReader
    {
        private readonly Queue<string> _queue;

        public ReplayingStreamReader(IEnumerable<string> strings)
        {
            _queue = new Queue<string>(strings);
        }

        public override Task<int> ReadAsync(char[] buffer, int index, int count)
        {
            if (_queue.Count == 0)
            {
                return Task.FromResult(0);
            }

            var nextString = _queue.Dequeue();

            Assert.True(count > nextString.Length);

            for (int i = 0; i < nextString.Length; i++)
            {
                buffer[index + i] = nextString[i];
            }

            return Task.FromResult(nextString.Length);
        }
    }
}
