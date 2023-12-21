/*
 * Copyright 2017 Google Inc. All Rights Reserved.
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
    public class ApiBidirectionalStreamingCallTest
    {
        [Fact]
        public void FailWithRetry()
        {
            var apiCall = ApiBidirectionalStreamingCall.Create<int, int>(
                "Method",
                callOptions => null,
                CallSettings.FromRetry(new RetrySettings(5, TimeSpan.Zero, TimeSpan.Zero, 1.0, e => false, RetrySettings.RandomJitter)),
                new BidirectionalStreamingSettings(100),
                new FakeClock());
            Assert.Throws<InvalidOperationException>(() => apiCall.Call(null));
        }

        [Fact]
        public void SucceedWithExpiration()
        {
            var apiCall = ApiBidirectionalStreamingCall.Create<int, int>(
                "Method",
                callOptions => null,
                CallSettings.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(100))),
                new BidirectionalStreamingSettings(100),
                new FakeClock());
            Assert.Null(apiCall.Call(null));
        }

        [Fact]
        public void WithLogging()
        {
            var logger = new MemoryLogger("category");
            var apiCall = ApiBidirectionalStreamingCall.Create<int, int>(
                "BidiStreamingMethod",
                callOptions => null,
                null,
                new BidirectionalStreamingSettings(100),
                new FakeClock()).WithLogging(logger);
            apiCall.Call(null);
            var logs = logger.ListLogEntries();
            var entry = Assert.Single(logger.ListLogEntries());
            Assert.Contains("BidiStreamingMethod", entry.Message);
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
            var apiCall = ApiBidirectionalStreamingCall.Create<int, int>(
                "BidiStreamingMethod",
                callOptions => null,
                null,
                new BidirectionalStreamingSettings(100),
                new FakeClock()).WithTracing(source);
            apiCall.Call(null);
            Assert.NotNull(capturedActivity);
            Assert.Equal(ApiCallTracingExtensions.BidiStreamingCallType, capturedActivity.Tags.First(j => j.Key == ApiCallTracingExtensions.GrpcCallTypeTag).Value);
            Assert.Equal(sourceName, capturedActivity.Source.Name);
            Assert.Contains("BidiStreamingMethod", capturedActivity.OperationName);
        }
    }
}
