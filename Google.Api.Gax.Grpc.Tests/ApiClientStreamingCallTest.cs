﻿/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiClientStreamingCallTest
    {
        [Fact]
        public void FailWithRetry()
        {
            var apiCall = ApiClientStreamingCall.Create<int, int>(
                "Method",
                callOptions => null,
                CallSettings.FromRetry(new RetrySettings(5, TimeSpan.Zero, TimeSpan.Zero, 1.0, e => false, RetrySettings.RandomJitter)),
                new ClientStreamingSettings(100),
                new FakeClock());
            Assert.Throws<InvalidOperationException>(() => apiCall.Call(null));
        }

        [Fact]
        public void SucceedWithExpiration()
        {
            var apiCall = ApiClientStreamingCall.Create<int, int>(
                "Method",
                callOptions => null,
                CallSettings.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(100))),
                new ClientStreamingSettings(100),
                new FakeClock());
            Assert.Null(apiCall.Call(null));
        }

        [Fact]
        public void WithLogging()
        {
            var logger = new MemoryLogger("category");
            var apiCall = ApiClientStreamingCall.Create<int, int>(
                "ClientStreamingMethod",
                callOptions => null,
                null,
                new ClientStreamingSettings(100),
                new FakeClock()).WithLogging(logger);
            apiCall.Call(null);
            var logs = logger.ListLogEntries();
            var entry = Assert.Single(logger.ListLogEntries());
            Assert.Contains("ClientStreamingMethod", entry.Message);
        }
    }
}
