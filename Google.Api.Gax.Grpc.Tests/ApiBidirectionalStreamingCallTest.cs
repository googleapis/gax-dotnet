/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiBidirectionalStreamingCallTest
    {
        [Fact]
        public void FailWithRetry()
        {
            var apiCall = ApiBidirectionalStreamingCall.Create<int, int>(
                callOptions => null,
                CallSettings.FromCallTiming(CallTiming.FromRetry(new RetrySettings(
                    new BackoffSettings(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(100), 2.0),
                    new BackoffSettings(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(100), 2.0),
                    Expiration.FromTimeout(TimeSpan.FromSeconds(100))))),
                new BidirectionalStreamingSettings(100),
                new FakeClock());
            Assert.Throws<InvalidOperationException>(() => apiCall.Call(null));
        }

        [Fact]
        public void SucceedWithExpiration()
        {
            var apiCall = ApiBidirectionalStreamingCall.Create<int, int>(
                callOptions => null,
                CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(100)))),
                new BidirectionalStreamingSettings(100),
                new FakeClock());
            Assert.Null(apiCall.Call(null));
        }
    }
}
