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
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class CallSettingsTest
    {
        [Fact]
        public void Merge_HeaderMutationOrdering()
        {
            Action<Metadata> clearAndAddFoo = m => { m.Clear(); m.Add("foo", "bar"); };
            Action<Metadata> addSample = m => m.Add("sample", "value");

            CallSettings clearAndAddFooSettings = new CallSettings(null, null, null, clearAndAddFoo, null, null);
            CallSettings addSampleSettings = new CallSettings(null, null, null, addSample, null, null);

            var merged1 = CallSettings.Merge(clearAndAddFooSettings, addSampleSettings);
            var merged2 = CallSettings.Merge(addSampleSettings, clearAndAddFooSettings);

            // Original should be called first, so merged1 should end up with foo and sample;
            // merged2 should end up with just foo.
            var metadata = new Metadata();
            merged1.HeaderMutation(metadata);
            Assert.Equal(2, metadata.Count);

            metadata = new Metadata();
            merged2.HeaderMutation(metadata);
            Assert.Equal(1, metadata.Count);
        }

        [Fact]
        public void ToCallOptions_CallTimingNull()
        {
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.FromCallTiming(null);
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_CallTimingExpirationTimeout()
        {
            var clock = new FakeClock();
            var timeout = TimeSpan.FromSeconds(1);
            CallSettings callSettings = CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(timeout)));
            var options = callSettings.ToCallOptions(clock);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, clock.GetCurrentDateTimeUtc() + timeout);
        }

        [Fact]
        public void ToCallOptions_CallTimingExpirationDeadline()
        {
            var deadline = new DateTime(2015, 6, 19, 5, 2, 3, DateTimeKind.Utc);
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromDeadline(deadline)));
            var options = callSettings.ToCallOptions(mockClock.Object);
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
                headerMutation: metadata => metadata.Add(new Metadata.Entry("1", "one")),
                timing: CallTiming.FromExpiration(Expiration.None),
                cancellationToken: new CancellationTokenSource().Token,
                writeOptions: new WriteOptions(WriteFlags.NoCompress),
                propagationToken: null, // Not possible to create/mock
                credentials: null // Not possible to create/mock
            );
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Equal(1, options.Headers.Count);
            Assert.Equal("[Entry: key=1, value=one]", options.Headers[0].ToString());
            Assert.Null(options.Deadline);
            Assert.Equal(callSettings.CancellationToken, options.CancellationToken);
            Assert.Same(callSettings.WriteOptions, options.WriteOptions);
        }

        [Fact]
        public void FromCancellationToken()
        {
            var token = new CancellationTokenSource().Token;
            var settings = CallSettings.FromCancellationToken(token);
            Assert.Equal(token, settings.CancellationToken);
        }

        [Fact]
        public void FromCallTiming()
        {
            Assert.Null(CallSettings.FromCallTiming(null));
            var timing = CallTiming.FromExpiration(Expiration.None);
            var settings = CallSettings.FromCallTiming(timing);
            Assert.Same(timing, settings.Timing);
        }

        [Fact]
        public void FromCredential()
        {
            Assert.Null(CallSettings.FromCallCredentials(null));
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credential = CallCredentials.FromInterceptor(interceptor);
            var settings = CallSettings.FromCallCredentials(credential);
            Assert.Same(credential, settings.Credentials);
        }

        [Fact]
        public void FromHeaderMutation()
        {
            Assert.Null(CallSettings.FromHeaderMutation(null));
            Action<Metadata> action = metadata => { }; // No-op, but still an action...
            var settings = CallSettings.FromHeaderMutation(action);
            Assert.Same(action, settings.HeaderMutation);
        }

        [Fact]
        public void FromHeader()
        {
            var settings = CallSettings.FromHeader("name", "value");
            var metadata = new Metadata();
            settings.HeaderMutation(metadata);
            Assert.Equal("name", metadata[0].Key);
            Assert.Equal("value", metadata[0].Value);
        }

        // Note: this test may well need to change, e.g. if we start to use a side channel.
        [Fact]
        public void FromFieldMask()
        {
            var settings = CallSettings.FromFieldMask("foo");
            var metadata = new Metadata();
            settings.HeaderMutation(metadata);
            Assert.Equal(CallSettings.FieldMaskHeader, metadata[0].Key);
            Assert.Equal("foo", metadata[0].Value);
        }
    }
}
