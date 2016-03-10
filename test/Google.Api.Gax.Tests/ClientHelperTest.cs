/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class ClientHelperTest
    {
        [Fact]
        public void BuildCallOptions_NoTimeout()
        {
            var mockClock = new Mock<IClock>();
            var helper = new ClientHelper(new DummySettings { Clock = mockClock.Object });
            var options = helper.BuildCallOptions(CancellationToken.None, null);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void BuildCallOptions_TimeoutAndClock()
        {
            var now = new DateTime(2015, 6, 19, 5, 2, 3, DateTimeKind.Utc);
            var timeout = TimeSpan.FromSeconds(1);
            var mockClock = new Mock<IClock>();
            mockClock.Setup(c => c.GetCurrentDateTimeUtc()).Returns(now);            
            var helper = new ClientHelper(new DummySettings { Timeout = timeout, Clock = mockClock.Object });
            var options = helper.BuildCallOptions(CancellationToken.None, null);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, now + timeout);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Once);
        }

        [Fact]
        public void BuildCallOptions_TimeoutAndImplicitSystemClock()
        {
            var now = DateTime.UtcNow;
            var timeout = TimeSpan.FromSeconds(1);
            var helper = new ClientHelper(new DummySettings { Timeout = timeout });
            var options = helper.BuildCallOptions(CancellationToken.None, null);
            // Allow for 100ms for the above code to execute... more than enough time.
            Assert.InRange(options.Deadline.Value, now + timeout, now + TimeSpan.FromMilliseconds(100) + timeout);
        }

        [Fact]
        public void BuildCallOptions_PopulatesCancellationToken()
        {
            var cts = new CancellationTokenSource();
            var helper = new ClientHelper(new DummySettings());
            var options = helper.BuildCallOptions(cts.Token, null);
            Assert.Equal(cts.Token, options.CancellationToken);
        }

        [Fact]
        public void BuildCallOptions_AppliesOverride()
        {
            var helper = new ClientHelper(new DummySettings());
            var modified = new CallOptions(
                new Metadata { { "foo", "bar" } },
                DateTime.UtcNow + TimeSpan.FromHours(1), // Just an arbitrary deadline
                writeOptions: new WriteOptions(WriteFlags.BufferHint)
            );
            Func<CallOptions, CallOptions> optionsOverride = _ => modified;
            var actual = helper.BuildCallOptions(CancellationToken.None, optionsOverride);
            Assert.Equal(modified, actual);
        }

        private class DummySettings : ServiceSettingsBase<DummySettings>
        {
            public override DummySettings Clone()
            {
                return CloneInto(new DummySettings());
            }
        }
    }
}
