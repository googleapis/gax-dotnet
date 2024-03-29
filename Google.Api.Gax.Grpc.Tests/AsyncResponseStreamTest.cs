﻿/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Testing;
using Grpc.Core;
using NSubstitute;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class AsyncResponseStreamTest
    {
        [Fact]
        public void GetAsyncEnumerator_ReturnsSelf()
        {
            var stream = CreateStream(1, 2, 3);
            Assert.Same(stream, stream.GetAsyncEnumerator());
        }

        [Fact]
        public void GetAsyncEnumerator_FailsSecondCall()
        {
            var stream = CreateStream(1, 2, 3);
            stream.GetAsyncEnumerator();
            Assert.Throws<InvalidOperationException>(() => stream.GetAsyncEnumerator());
        }

        // Tests for the data

        [Fact]
        public async Task MoveNextAsync_Parameterless()
        {
            var stream = CreateStream(1, 2);
            Assert.True(await stream.MoveNextAsync());
            Assert.Equal(1, stream.Current);
            Assert.True(await stream.MoveNextAsync());
            Assert.Equal(2, stream.Current);
            Assert.False(await stream.MoveNextAsync());
        }

        [Fact]
        public async Task MoveNextAsync_WithCancellationToken()
        {
            var stream = CreateStream(1, 2);
            Assert.True(await stream.MoveNextAsync(default));
            Assert.Equal(1, stream.Current);
            Assert.True(await stream.MoveNextAsync(default));
            Assert.Equal(2, stream.Current);
            Assert.False(await stream.MoveNextAsync(default));
        }

        // Tests for cancellation tokens being propagated

        [Fact]
        public async Task MoveNextAsync_Parameterless_WithoutGetAsyncEnumerator_UsesCancellationTokenNone()
        {
            var mock = Substitute.For<IAsyncStreamReader<int>>();
            mock.MoveNext(CancellationToken.None).Returns(Task.FromResult(true));

            var stream = new AsyncResponseStream<int>(mock);
            Assert.True(await stream.MoveNextAsync());

            _ = mock.Received(1).MoveNext(default);
        }

        [Fact]
        public async Task MoveNextAsync_Parameterless_AfterGetAsyncEnumerator_PropagatesToken()
        {
            var token = new CancellationTokenSource().Token;
            var mock = Substitute.For<IAsyncStreamReader<int>>();
            mock.MoveNext(token).Returns(Task.FromResult(true));

            var stream = new AsyncResponseStream<int>(mock);
            stream.GetAsyncEnumerator(token);
            Assert.True(await stream.MoveNextAsync());

            _ = mock.Received(1).MoveNext(token);
        }

        [Fact]
        public async Task MoveNextAsync_WithCancellationToken_PropagatesToken()
        {
            var token = new CancellationTokenSource().Token;
            var mock = Substitute.For<IAsyncStreamReader<int>>();
            mock.MoveNext(token).Returns(Task.FromResult(true));

            var stream = new AsyncResponseStream<int>(mock);
            Assert.True(await stream.MoveNextAsync(token));

            _ = mock.Received(1).MoveNext(token);
        }

        private AsyncResponseStream<int> CreateStream(params int[] array)
        {
            var adapter = new AsyncStreamAdapter<int>(array.ToAsyncEnumerable().GetAsyncEnumerator());
            return new AsyncResponseStream<int>(adapter);
        }

    }
}
