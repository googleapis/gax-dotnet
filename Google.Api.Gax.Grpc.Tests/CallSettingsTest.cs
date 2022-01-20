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
        public void ToCallOptions_NullSettings()
        {
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = null;
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_NoExpiration()
        {
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.CancellationTokenNone;
            Assert.Null(callSettings.Expiration);
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_ExpirationTimeout()
        {
            var clock = new FakeClock();
            var timeout = TimeSpan.FromSeconds(1);
            CallSettings callSettings = CallSettings.FromExpiration(Expiration.FromTimeout(timeout));
            var options = callSettings.ToCallOptions(clock);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, clock.GetCurrentDateTimeUtc() + timeout);
        }

        [Fact]
        public void ToCallOptions_ExpirationDeadline()
        {
            var deadline = new DateTime(2015, 6, 19, 5, 2, 3, DateTimeKind.Utc);
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.FromExpiration(Expiration.FromDeadline(deadline));
            var options = callSettings.ToCallOptions(mockClock.Object);
            // Value should be exact, as we control time precisely.
            Assert.Equal(options.Deadline.Value, deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_ExpirationNone()
        {
            var deadline = new DateTime(2015, 6, 19, 5, 2, 3, DateTimeKind.Utc);
            var mockClock = new Mock<IClock>();
            CallSettings callSettings = CallSettings.FromExpiration(Expiration.None);
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Null(options.Deadline);
            mockClock.Verify(c => c.GetCurrentDateTimeUtc(), Times.Never);
        }

        [Fact]
        public void ToCallOptions_All()
        {
            var mockClock = new Mock<IClock>();
            var callSettings = new CallSettings
            (
                headerMutation: metadata => metadata.Add(new Metadata.Entry("1", "one")),
                expiration: Expiration.None,
                // The retry settings aren't used in the call options, but we'll include them anyway.
                retry: new RetrySettings(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), 2.0, RetrySettings.FilterForStatusCodes(), RetrySettings.RandomJitter),
                cancellationToken: new CancellationTokenSource().Token,
                writeOptions: new WriteOptions(WriteFlags.NoCompress),
                propagationToken: null // Not possible to create/mock
            );
            var options = callSettings.ToCallOptions(mockClock.Object);
            Assert.Equal(1, options.Headers.Count);
            Assert.Equal("[Entry: key=1, value=one]", options.Headers[0].ToString());
            Assert.Null(options.Deadline);
            Assert.Equal(callSettings.CancellationToken, options.CancellationToken);
            Assert.Same(callSettings.WriteOptions, options.WriteOptions);
        }

        [Theory]
        [InlineData("x-goog-user-project", "my-project")]
        public void ToCallOptions_InvalidHeaderMutations(string header, string value) =>
            Assert.Throws<InvalidOperationException>(
                () => CallSettings
                .FromHeaderMutation(metadata => metadata.Add(new Metadata.Entry(header, value)))
                .ToCallOptions(new Mock<IClock>().Object));

        [Fact]
        public void CancellationTokenNone()
        {
            var none = CallSettings.FromCancellationToken(default(CancellationToken));
            Assert.Same(CallSettings.CancellationTokenNone, none);
            var notNone = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            Assert.NotSame(CallSettings.CancellationTokenNone, notNone);
        }

        [Fact]
        public void FromCancellationToken()
        {
            var token = new CancellationTokenSource().Token;
            var settings = CallSettings.FromCancellationToken(token);
            Assert.Equal(token, settings.CancellationToken);
        }

        [Fact]
        public void FromExpiration()
        {
            Assert.Null(CallSettings.FromExpiration(null));
            var expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var settings = CallSettings.FromExpiration(expiration);
            Assert.Same(expiration, settings.Expiration);
        }

        [Fact]
        public void FromRetry()
        {
            Assert.Null(CallSettings.FromRetry(null));
            var retry = new RetrySettings(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), 2.0, RetrySettings.FilterForStatusCodes(), RetrySettings.RandomJitter);
            var settings = CallSettings.FromRetry(retry);
            Assert.Same(retry, settings.Retry);
        }

        [Fact]
        public void FromCredential()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.Null(CallSettings.FromCallCredentials(null));
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credential = CallCredentials.FromInterceptor(interceptor);
            var settings = CallSettings.FromCallCredentials(credential);
            Assert.Same(credential, settings.Credentials);
#pragma warning restore CS0618 // Type or member is obsolete
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

        [Theory]
        [InlineData("x-goog-user-project", "my-project")]
        public void FromHeader_Invalid(string header, string value) =>
            Assert.Throws<InvalidOperationException>(() => CallSettings.FromHeader(header, value));

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

        [Fact]
        public void FromResponseMetadataHandler()
        {
            Action<Metadata> handler = metadata => { };
            var settings = CallSettings.FromResponseMetadataHandler(handler);
            Assert.Same(handler, settings.ResponseMetadataHandler);
        }

        [Fact]
        public void FromTrailingMetadataHandler()
        {
            Action<Metadata> handler = metadata => { };
            var settings = CallSettings.FromTrailingMetadataHandler(handler);
            Assert.Same(handler, settings.TrailingMetadataHandler);
        }

        [Fact]
        public void MergeResponseMetadataHandlers()
        {
            Action<Metadata> handler1 = metadata => { };
            Action<Metadata> handler2 = metadata => { };
            var settings = CallSettings.Merge(
                CallSettings.FromResponseMetadataHandler(handler1),
                CallSettings.FromResponseMetadataHandler(handler2));
            Assert.Equal(handler1 + handler2, settings.ResponseMetadataHandler);
        }

        [Fact]
        public void MergeTrailingMetadataHandlers()
        {
            Action<Metadata> handler1 = metadata => { };
            Action<Metadata> handler2 = metadata => { };
            var settings = CallSettings.Merge(
                CallSettings.FromTrailingMetadataHandler(handler1),
                CallSettings.FromTrailingMetadataHandler(handler2));
            Assert.Equal(handler1 + handler2, settings.TrailingMetadataHandler);
        }

        [Theory]
        [InlineData("parent", "foo", "parent=foo")]
        [InlineData("parent", "a,b", "parent=a%2Cb")]
        [InlineData("transaction", "xy==", "transaction=xy%3D%3D")]
        [InlineData("parent", null, "parent=")]
        public void FromGoogleRequestParamsHeader(string parameterName, string parameterValue, string expectedHeaderValue)
        {
            var callSettings = CallSettings.FromGoogleRequestParamsHeader(parameterName, parameterValue);
            AssertSingleHeader(callSettings, CallSettings.RequestParamsHeader, expectedHeaderValue);
        }

        [Fact]
        public void FromRequestReasonHeader()
        {
            var callSettings = CallSettings.FromRequestReasonHeader("diagnostics");
            AssertSingleHeader(callSettings, CallSettings.RequestReasonHeader, "diagnostics");
        }

        internal static void AssertSingleHeader(CallSettings callSettings, string expectedHeaderName, string expectedHeaderValue)
        {
            var metadata = new Metadata();
            callSettings.HeaderMutation(metadata);
            Assert.Equal(1, metadata.Count);
            Assert.Equal(expectedHeaderName, metadata[0].Key);
            Assert.Equal(expectedHeaderValue, metadata[0].Value);
        }

        internal static void AssertRoutingHeader(CallSettings callSettings, string expectedHeaderValue)
        {
            if (string.IsNullOrEmpty(expectedHeaderValue))
            {
                Assert.Null(callSettings);
            }
            else
            {
                var metadata = new Metadata();
                callSettings.HeaderMutation(metadata);
                Assert.Equal(1, metadata.Count);
                Assert.Equal(CallSettings.RequestParamsHeader, metadata[0].Key);
                Assert.Equal(expectedHeaderValue, metadata[0].Value);
            }
        }
    }
}
