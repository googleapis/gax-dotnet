/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
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
        var reader = new ReplayingStreamReader(ArrayOfObjectsJson.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
        var decodingReader = reader.CreateResponseReader();

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
        var reader = new ReplayingStreamReader(ArrayOfObjectsJson.Select(c => c.ToString()));
        var decodingReader = reader.CreateResponseReader();

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
        var reader = new ReplayingStreamReader(data);
        var decodingReader = reader.CreateResponseReader();

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["foo"], 1);

        var ex = await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(CancellationToken.None));
        Assert.Equal(StatusCode.DataLoss, ex.StatusCode);
    }

    /// <summary>
    /// Validates how we detect and throw errors. Each call to the TextReader
    /// is processed completely - resulting in an immediate exception if broken JSON
    /// is detected. This means we can fail with an exception even if we've queued up
    /// some valid responses. Arguably this isn't ideal, but it makes the code significantly
    /// simpler - and we're in the context of "the server has returned garbage" anyway.
    /// </summary>
    [Fact]
    public async Task ExceptionThrownOnErrorDetection()
    {
        string[] data =
        {
            // The first read call will yield the first result
            "[{ \"foo\": 1 }",
            // The second read call will result in an exception, even though a second result is available
            // before the broken JSON.
            ", { \"foo\": 2 }, BADJSON ]"
        };
        var reader = new ReplayingStreamReader(data);
        var decodingReader = reader.CreateResponseReader();

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.True(result);
        Assert.NotNull(decodingReader.Current);
        Assert.Equal(decodingReader.Current["foo"], 1);

        var ex = await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(CancellationToken.None));
        Assert.Equal(StatusCode.DataLoss, ex.StatusCode);
    }

    /// <summary>
    /// Test when data is empty array.
    /// </summary>
    [Fact]
    public async Task EmptyValidData()
    {
        var reader = new ReplayingStreamReader(new[] { "[]" });
        var decodingReader = reader.CreateResponseReader();

        var result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);

        result = await decodingReader.MoveNext(CancellationToken.None);
        Assert.False(result);
    }

    [Fact]
    public async Task NonWhitespaceAfterClosingArray()
    {
        var reader = new ReplayingStreamReader(new[] { "[] ," });
        var decodingReader = reader.CreateResponseReader();

        var ex = await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(CancellationToken.None));
        Assert.Equal(StatusCode.DataLoss, ex.StatusCode);
    }

    /// <summary>
    /// This doesn't test aspects like "cancellation during a read" but that's harder to do.
    /// </summary>
    [Fact]
    public async Task PerCallCancellationObserved()
    {
        var reader = new ReplayingStreamReader(new[] { "[]" });
        var decodingReader = reader.CreateResponseReader();
        var token = new CancellationToken(canceled: true);
        var exception = await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(token));
        Assert.Equal(StatusCode.Cancelled, exception.StatusCode);
    }

    [Fact]
    public async Task OverallCallCancellationObserved()
    {
        var reader = new ReplayingStreamReader(new[] { "[]" });
        var token = new CancellationToken(canceled: true);
        var decodingReader = reader.CreateResponseReader(callCancellationToken: token, deadlineCancellationToken: default);
        var exception = await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(token));
        Assert.Equal(StatusCode.Cancelled, exception.StatusCode);
    }

    [Fact]
    public async Task DeadlineCancellationObserved()
    {
        var reader = new ReplayingStreamReader(new[] { "[]" });
        var token = new CancellationToken(canceled: true);
        // Note: the deadline cancellation token is expected to be part of the call cancellation token.
        var decodingReader = reader.CreateResponseReader(callCancellationToken: token, deadlineCancellationToken: token);
        var exception = await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(token));
        Assert.Equal(StatusCode.DeadlineExceeded, exception.StatusCode);
    }

    /// <summary>
    /// A second call to MoveNext fails if the first one did, even if the first failure
    /// was only due to a cancellation token which was cancelled.
    /// </summary>
    [Fact]
    public async Task FailureIsSticky()
    {
        var reader = new ReplayingStreamReader(new[] { "[]" });
        var decodingReader = reader.CreateResponseReader();
        var token1 = new CancellationToken(canceled: true);
        await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(token1));

        var token2 = new CancellationToken(canceled: false);
        await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(token2));
    }

    [Fact]
    public async Task DisposedAfterCompletion()
    {
        var reader = new ReplayingStreamReader(new[] { "[{}]" });
        var decodingReader = reader.CreateResponseReader();
        Assert.True(await decodingReader.MoveNext(default));
        Assert.False(reader.Disposed);

        Assert.False(await decodingReader.MoveNext(default));
        await AssertDisposedSoon(reader);
    }

    [Fact]
    public async Task DisposedAfterCancellation()
    {
        var reader = new ReplayingStreamReader(new[] { "[{}]" });
        var decodingReader = reader.CreateResponseReader();
        var token = new CancellationToken(canceled: true);
        await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(token));
        await AssertDisposedSoon(reader);
    }

    [Fact]
    public async Task DisposedAfterError()
    {
        var reader = new ReplayingStreamReader(new[] { "[{}", ", broken]" });
        var decodingReader = reader.CreateResponseReader();
        var token = new CancellationToken(canceled: true);

        Assert.True(await decodingReader.MoveNext(default));
        Assert.False(reader.Disposed);

        await Assert.ThrowsAsync<RpcException>(() => decodingReader.MoveNext(default));
        await AssertDisposedSoon(reader);
    }

    private async Task AssertDisposedSoon(ReplayingStreamReader reader)
    {
        for (int check = 0; check < 5; check++)
        {
            if (reader.Disposed)
            {
                return;
            }
            await Task.Delay(500);
        }
        Assert.Fail("Reader was not disposed, even after a short delay.");
    }

    /// <summary>
    /// A TextReader which response to Read requests by copying data from the given strings.
    /// </summary>
    private class ReplayingStreamReader : TextReader
    {
        private readonly Queue<string> _queue;
        public bool Disposed { get; private set; }

        public ReplayingStreamReader(IEnumerable<string> strings)
        {
            _queue = new Queue<string>(strings);
        }

        internal PartialDecodingStreamReader<JObject> CreateResponseReader() =>
            CreateResponseReader(default, default);

        internal PartialDecodingStreamReader<JObject> CreateResponseReader(
            CancellationToken callCancellationToken, CancellationToken deadlineCancellationToken) =>
            new PartialDecodingStreamReader<JObject>(Task.FromResult<TextReader>(this), JObject.Parse, callCancellationToken, deadlineCancellationToken, "rpc");

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Disposed = true;
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
