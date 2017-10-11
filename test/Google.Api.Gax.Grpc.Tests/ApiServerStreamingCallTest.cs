/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiServerStreamingCallTest
    {
        [Fact]
        public async Task FailWithRetry()
        {
            var apiCall = ApiServerStreamingCall.Create<int, int>(
                (request, callOptions) => null,
                CallSettings.FromCallTiming(CallTiming.FromRetry(new RetrySettings(
                    new BackoffSettings(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(100), 2.0),
                    new BackoffSettings(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(100), 2.0),
                    Expiration.FromTimeout(TimeSpan.FromSeconds(100))))),
                new FakeClock());
            await Assert.ThrowsAsync<InvalidOperationException>(() => apiCall.CallAsync(0, null));
            Assert.Throws<InvalidOperationException>(() => apiCall.Call(0, null));
        }

        [Fact]
        public async Task SucceedWithExpiration()
        {
            var apiCall = ApiServerStreamingCall.Create<int, int>(
                (request, callOptions) => null,
                CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(100)))),
                new FakeClock());
            Assert.Null(await apiCall.CallAsync(0, null));
            Assert.Null(apiCall.Call(0, null));
        }
    }
}
