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
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings { Expiration = Expiration.FromTimeout(timeout) },
                Clock = mockClock.Object
            });
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
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings { Expiration = Expiration.FromTimeout(timeout) }
            });
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
            CallOptions callOptions = helper.BuildCallOptions(null, null);
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
            CallOptions callOptions = helper.BuildCallOptions(null, callSettings);
            Assert.Equal(callSettings.Headers, callOptions.Headers);
            Assert.Equal(callSettings.Expiration.Deadline.Value, callOptions.Deadline);
            Assert.Equal(callSettings.CancellationToken, callOptions.CancellationToken);
            Assert.Equal(callSettings.WriteOptions, callOptions.WriteOptions);
            Assert.Null(callOptions.PropagationToken);
            Assert.Null(callOptions.Credentials);
        }

        [Fact]
        public void BuildCallOptions_CancellationToken_NoOverride()
        {
            var globalCancellationToken = new CancellationTokenSource().Token;
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings
                {
                    CancellationToken = globalCancellationToken
                }
            });
            CallOptions callOptions = helper.BuildCallOptions(null, null);
            Assert.Equal(globalCancellationToken, callOptions.CancellationToken);
        }

        [Fact]
        public void BuildCallOptions_CancellationToken_SettingsOverride()
        {
            var globalCancellationToken = new CancellationTokenSource().Token;
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings
                {
                    CancellationToken = globalCancellationToken
                }
            });
            var overrideCancellationToken = new CancellationTokenSource().Token;
            var callSettingsOverride = new CallSettings
            {
                CancellationToken = overrideCancellationToken
            };
            CallOptions callOptions = helper.BuildCallOptions(null, callSettingsOverride);
            Assert.Equal(overrideCancellationToken, callOptions.CancellationToken);
        }

        [Fact]
        public void BuildCallOptions_CancellationToken_ArgOverride()
        {
            var globalCancellationToken = new CancellationTokenSource().Token;
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = new CallSettings
                {
                    CancellationToken = globalCancellationToken
                }
            });
            var overrideCancellationToken = new CancellationTokenSource().Token;
            var callSettingsOverride = new CallSettings
            {
                CancellationToken = overrideCancellationToken
            };
            var argCancellationToken = new CancellationTokenSource().Token;
            CallOptions callOptions = helper.BuildCallOptions(argCancellationToken, callSettingsOverride);
            Assert.Equal(argCancellationToken, callOptions.CancellationToken);
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
