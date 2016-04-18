/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var options = helper.BuildCallOptions(null);
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
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings { Expiration = Expiration.FromTimeout(timeout) },
                Clock = mockClock.Object
            });
            var options = helper.BuildCallOptions(null);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, now + timeout);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Once);
        }
        
        [Fact]
        public void BuildCallOptions_TimeoutAndImplicitSystemClock()
        {
            var now = DateTime.UtcNow;
            var timeout = TimeSpan.FromSeconds(1);
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings { Expiration = Expiration.FromTimeout(timeout) }
            });
            var options = helper.BuildCallOptions(null);
            // Allow for 100ms for the above code to execute... more than enough time.
            Assert.InRange(options.Deadline.Value, now + timeout, now + TimeSpan.FromMilliseconds(100) + timeout);
        }
        
        [Fact]
        public void BuildCallOptions_GlobalCallSettings()
        {
            var cts = new CancellationTokenSource();
            CallSettings callSettings = new CallSettings
            {
                Headers = new Metadata { new Metadata.Entry("1", "one") },
                Expiration = Expiration.FromDeadline(new DateTime(78L)),
                CancellationToken = cts.Token,
                WriteOptions = new WriteOptions(WriteFlags.BufferHint),
                PropagationToken = null, // Un-creatable, un-mockable
                Credentials = null, // Un-creatable, un-mockable
            };
            var helper = new ClientHelper(new DummySettings { CallSettings = callSettings });
            CallOptions callOptions = helper.BuildCallOptions(null);
            var userAgent = RemoveUserAgent(callOptions.Headers);
            Assert.Contains("gax/", userAgent);
            Assert.Contains("grpc/", userAgent);
            Assert.Contains("Google.Api.Gax.Tests/", userAgent);
            Assert.Equal(callSettings.Headers, callOptions.Headers);
            Assert.Equal(callSettings.Expiration.Deadline.Value, callOptions.Deadline);
            Assert.Equal(callSettings.CancellationToken, callOptions.CancellationToken);
            Assert.Equal(callSettings.WriteOptions, callOptions.WriteOptions);
            Assert.Null(callOptions.PropagationToken);
            Assert.Null(callOptions.Credentials);
        }

        [Fact]
        public void BuildCallOptions_AppliesOverride()
        {
            var helper = new ClientHelper(new DummySettings());
            var cts = new CancellationTokenSource();
            CallSettings callSettings = new CallSettings
            {
                Headers = new Metadata { new Metadata.Entry("1", "one") },
                Expiration = Expiration.FromDeadline(new DateTime(78L)),
                CancellationToken = cts.Token,
                WriteOptions = new WriteOptions(WriteFlags.BufferHint),
                PropagationToken = null, // Un-creatable, un-mockable
                Credentials = null, // Un-creatable, un-mockable
            };
            CallOptions callOptions = helper.BuildCallOptions(callSettings);
            var userAgent = RemoveUserAgent(callOptions.Headers);
            Assert.Contains("gax/", userAgent);
            Assert.Contains("grpc/", userAgent);
            Assert.Contains("Google.Api.Gax.Tests/", userAgent);
            Assert.Equal(callSettings.Headers, callOptions.Headers);
            Assert.Equal(callSettings.Expiration.Deadline.Value, callOptions.Deadline);
            Assert.Equal(callSettings.CancellationToken, callOptions.CancellationToken);
            Assert.Equal(callSettings.WriteOptions, callOptions.WriteOptions);
            Assert.Null(callOptions.PropagationToken);
            Assert.Null(callOptions.Credentials);
        }

        private string RemoveUserAgent(Metadata metadata)
        {
            var userAgentEntries = metadata
                .Where(entry => entry.Key.Equals(UserAgentBuilder.HeaderName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();           
            foreach (var entry in userAgentEntries)
            {
                metadata.Remove(entry);
            }
            return string.Join(" ", userAgentEntries.Select(entry => entry.Value));
        }

        private class DummySettings : ServiceSettingsBase
        {
            public DummySettings Clone() => CloneInto(new DummySettings());
        }
    }
}
