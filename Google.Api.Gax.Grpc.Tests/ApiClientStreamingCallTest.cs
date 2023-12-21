/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using System.Diagnostics;
using System.Linq;
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

        [Fact]
        public void WithTracing()
        {
            var sourceName = "source";
            Activity capturedActivity = null;

            // We need a listener attached to an ActivitySource, otherwise activity won't be created.
            using var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == sourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllDataAndRecorded,
                ActivityStarted = activity => capturedActivity = activity
            };
            ActivitySource.AddActivityListener(listener);
            using var source = new ActivitySource(sourceName);
            var apiCall = ApiClientStreamingCall.Create<int, int>(
                "ClientStreamingMethod",
                callOptions => null,
                null,
                new ClientStreamingSettings(100),
                new FakeClock()).WithTracing(source);
            apiCall.Call(null);
            Assert.NotNull(capturedActivity);
            Assert.Equal(ApiCallTracingExtensions.ClientStreamingCallType, capturedActivity.Tags.First(j => j.Key == ApiCallTracingExtensions.GrpcCallTypeTag).Value);
            Assert.Contains("ClientStreamingMethod", capturedActivity.OperationName);
            Assert.Equal(sourceName, capturedActivity.Source.Name);
        }
    }
}
