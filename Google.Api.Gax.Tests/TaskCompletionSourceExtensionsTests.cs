/*
 * Copyright 2018 Google LLC. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class TaskCompletionSourceExtensionsTests
    {
        [Fact]
        public async Task WithCancellationToken_None()
        {
            var tcs = new TaskCompletionSource<int>();
            var task = tcs.WithCancellationToken(CancellationToken.None);

            tcs.SetResult(5);
            Assert.Equal(5, await task);
        }

        [Fact]
        public async Task WithCancellationToken_Uncancelled()
        {
            var tcs = new TaskCompletionSource<int>();
            var source = new CancellationTokenSource();
            var task = tcs.WithCancellationToken(source.Token);

            tcs.SetResult(5);
            Assert.Equal(5, await task);
        }

        [Fact]
        public async Task WithCancellationToken_CancelledBeforeCreation()
        {
            var source = new CancellationTokenSource();
            source.Cancel();
            var tcs = new TaskCompletionSource<int>();
            var task = tcs.WithCancellationToken(source.Token);

            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
        }

        [Fact]
        public async Task WithCancellationToken_CancelledAfterCreation()
        {
            var tcs = new TaskCompletionSource<int>();
            var source = new CancellationTokenSource();
            var task = tcs.WithCancellationToken(source.Token);
            source.Cancel();

            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
        }
    }
}
