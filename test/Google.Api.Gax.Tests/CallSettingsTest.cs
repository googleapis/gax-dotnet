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

namespace Google.Api.Gax.Tests
{
    public class CallSettingsTest
    {
        [Fact]
        public void DefaultsToNull()
        {
            var callSettings = new CallSettings();
            Assert.Null(callSettings.Headers);
            Assert.Null(callSettings.Expiration);
            Assert.Null(callSettings.CancellationToken);
            Assert.Null(callSettings.WriteOptions);
            Assert.Null(callSettings.PropagationToken);
            Assert.Null(callSettings.Credentials);
        }

        [Fact]
        public void Clone()
        {
            var callSettings = new CallSettings
            {
                Headers = new Metadata { new Metadata.Entry("1", "one") },
                Expiration = Expiration.None,
                CancellationToken = CancellationToken.None,
                WriteOptions = new WriteOptions(WriteFlags.NoCompress),
                PropagationToken = null, // Not possible to create/mock
                Credentials = null, // Not possible to create/mock
            };
            var clone = callSettings.Clone();
            Assert.NotSame(callSettings, clone);
            Assert.NotSame(callSettings.Headers, clone.Headers);
            Assert.Equal(callSettings.Headers, clone.Headers);
            Assert.NotNull(clone.Headers);
            Assert.Same(callSettings.Expiration, clone.Expiration);
            Assert.Equal(callSettings.CancellationToken, clone.CancellationToken);
            Assert.Same(callSettings.WriteOptions, clone.WriteOptions);
            Assert.Same(callSettings.PropagationToken, clone.PropagationToken);
            Assert.Same(callSettings.Credentials, clone.Credentials);
        }

        [Fact]
        public void CloneNullHeaders()
        {
            var callSettings = new CallSettings { Headers = null };
            var clone = callSettings.Clone();
            Assert.Null(clone.Headers);
        }

        [Fact]
        public void ToCallOptions_ExpirationNull()
        {
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = new CallSettings();
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_ExpirationTimeout()
        {
            var clock = new FakeClock();
            var timeout = TimeSpan.FromSeconds(1);
            var callSettings = new CallSettings { Expiration = Expiration.FromTimeout(timeout) };
            var options = callSettings.ToCallOptions(clock);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, clock.GetCurrentDateTimeUtc() + timeout);
        }

        [Fact]
        public void ToCallOptions_ExpirationDeadline()
        {
            var deadline = new DateTime(2015, 6, 19, 5, 2, 3, DateTimeKind.Utc);
            var mockClock = new Mock<IClock>();
            var callSettings = new CallSettings { Expiration = Expiration.FromDeadline(deadline) };
            var options = callSettings.ToCallOptions(mockClock.Object);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_All()
        {
            var callSettings = new CallSettings
            {
                Headers = new Metadata { new Metadata.Entry("1", "one") },
                Expiration = Expiration.None,
                CancellationToken = new CancellationTokenSource().Token,
                WriteOptions = new WriteOptions(WriteFlags.NoCompress),
                PropagationToken = null, // Not possible to create/mock
                Credentials = null, // Not possible to create/mock
            };
            var options = callSettings.ToCallOptions(null);
            Assert.Same(callSettings.Headers, options.Headers);
            Assert.Null(options.Deadline);
            Assert.Equal(callSettings.CancellationToken, options.CancellationToken);
            Assert.Same(callSettings.WriteOptions, options.WriteOptions);
        }
    }
}
