/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Grpc.Core;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class CallSettingsTest
    {
        [Fact]
        public void ToCallOptions_CallTimingNull()
        {
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.FromCallTiming(null);
            var options = CallSettings.ToCallOptions(callSettings, null, mockClock.Object);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_CallTimingExpirationTimeout()
        {
            var clock = new FakeClock();
            var timeout = TimeSpan.FromSeconds(1);
            CallSettings callSettings = CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(timeout)));
            var options = CallSettings.ToCallOptions(callSettings, null, clock);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, clock.GetCurrentDateTimeUtc() + timeout);
        }

        [Fact]
        public void ToCallOptions_CallTimingExpirationDeadline()
        {
            var deadline = new DateTime(2015, 6, 19, 5, 2, 3, DateTimeKind.Utc);
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromDeadline(deadline)));
            var options = CallSettings.ToCallOptions(callSettings, null, mockClock.Object);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_All()
        {
            var mockClock = new Mock<IClock>();
            var callSettings = new CallSettings
            (
                headers: new Metadata { new Metadata.Entry("1", "one") },
                timing: CallTiming.FromExpiration(Expiration.None),
                cancellationToken: new CancellationTokenSource().Token,
                writeOptions: new WriteOptions(WriteFlags.NoCompress),
                propagationToken: null, // Not possible to create/mock
                credentials: null // Not possible to create/mock
            );
            var options = CallSettings.ToCallOptions(callSettings, null, mockClock.Object);
            Assert.Same(callSettings.Headers, options.Headers);
            Assert.Null(options.Deadline);
            Assert.Equal(callSettings.CancellationToken, options.CancellationToken);
            Assert.Same(callSettings.WriteOptions, options.WriteOptions);
        }
    }
}
