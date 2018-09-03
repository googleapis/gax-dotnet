/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class CallSettingsExtensionsTest
    {
        [Fact]
        public void MergedWith_BothNull()
        {
            CallSettings settings = null;
            Assert.Null(settings.MergedWith(null));
        }

        [Fact]
        public void MergedWith_OneNull()
        {
            CallSettings settings1 = new CallSettings(null, null, null, null, null, null);
            CallSettings settings2 = null;
            Assert.Same(settings1, settings1.MergedWith(settings2));
            Assert.Same(settings1, settings2.MergedWith(settings1));
        }

        [Fact]
        public void MergedWith_BothNonNull()
        {
            CallTiming timing1 = CallTiming.FromExpiration(Expiration.None);
            CallTiming timing2 = CallTiming.FromDeadline(DateTime.UtcNow);

            CancellationToken token = new CancellationTokenSource().Token;

            var settings1 = new CallSettings(token, null, timing1, null, null, null);
            var settings2 = new CallSettings(null, null, timing2, null, null, null);
            var merged = settings1.MergedWith(settings2);
            Assert.Equal(token, merged.CancellationToken);
            Assert.Same(timing2, merged.Timing);
        }

        [Fact]
        public void WithCancellationToken()
        {
            CancellationToken token1 = new CancellationTokenSource().Token;
            CallTiming timing = CallTiming.FromExpiration(Expiration.None);
            var original = new CallSettings(token1, null, timing, null, null, null);

            CancellationToken token2 = new CancellationTokenSource().Token;
            var result = original.WithCancellationToken(token2);
            Assert.Same(timing, result.Timing);
            Assert.Equal(token2, result.CancellationToken);
        }

        [Fact]
        public void WithCallTiming_NonNull()
        {
            CallTiming timing1 = CallTiming.FromExpiration(Expiration.None);
            CallTiming timing2 = CallTiming.FromDeadline(DateTime.UtcNow);

            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, null, timing1, null, null, null);
            var result = original.WithCallTiming(timing2);
            Assert.Same(timing2, result.Timing);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithCallTiming_NullSettings()
        {
            CallSettings noSettings = null;
            Assert.Null(noSettings.WithCallTiming(null));
            CallTiming timing = CallTiming.FromExpiration(Expiration.None);
            var result = noSettings.WithCallTiming(timing);
            Assert.Same(timing, result.Timing);
        }

        [Fact]
        public void WithCallTiming_NullTiming()
        {
            CallTiming timing = CallTiming.FromExpiration(Expiration.None);
            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, null, timing, null, null, null);
            var result = original.WithCallTiming(null);
            Assert.Null(result.Timing);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithCallCredentials_NonNull()
        {
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credentials1 = CallCredentials.FromInterceptor(interceptor);
            var credentials2 = CallCredentials.FromInterceptor(interceptor);
            Assert.NotSame(credentials1, credentials2);

            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, credentials1, null, null, null, null);
            var result = original.WithCallCredentials(credentials2);
            Assert.Same(credentials2, result.Credentials);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithCallCredentials_NullSettings()
        {
            CallSettings noSettings = null;
            Assert.Null(noSettings.WithCallCredentials(null));
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credentials = CallCredentials.FromInterceptor(interceptor);
            var result = noSettings.WithCallCredentials(credentials);
            Assert.Same(credentials, result.Credentials);
        }

        [Fact]
        public void WithCallCredentials_NullCredentials()
        {
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credentials = CallCredentials.FromInterceptor(interceptor);
            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, credentials, null, null, null, null);
            var result = original.WithCallCredentials(null);
            Assert.Null(result.Credentials);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithHeader_NullSettings()
        {
            CallSettings settings = null;
            var result = settings.WithHeader("name", "value");
            var metadata = new Metadata();
            result.HeaderMutation(metadata);
            Assert.Equal("name", metadata[0].Key);
            Assert.Equal("value", metadata[0].Value);
        }

        [Fact]
        public void WithHeader_NonNullSettings()
        {
            CallSettings settings = CallSettings.FromHeader("name1", "value1");
            var result = settings.WithHeader("name2", "value2");
            var metadata = new Metadata();
            result.HeaderMutation(metadata);
            Assert.Equal("name1", metadata[0].Key);
            Assert.Equal("value1", metadata[0].Value);
            Assert.Equal("name2", metadata[1].Key);
            Assert.Equal("value2", metadata[1].Value);
        }

        [Fact]
        public void WithEarlierDeadline_NoSettingsNoDeadline()
        {
            CallSettings settings = null;
            DateTime? deadline = null;

            Assert.Null(settings.WithEarlierDeadline(deadline, new FakeClock()));
        }

        [Fact]
        public void WithEarlierDeadline_SimpleSettingsNoDeadline()
        {
            CallSettings settings = CallSettings.FromHeader("name", "value");
            DateTime? deadline = null;

            Assert.Same(settings, settings.WithEarlierDeadline(deadline, new FakeClock()));
        }

        [Fact]
        public void WithEarlierDeadline_NonTimingSettingsWithDeadline()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token);
            DateTime? deadline = new DateTime(1L, DateTimeKind.Utc);

            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            Assert.Equal(token, newSettings.CancellationToken);
            Assert.Equal(deadline, newSettings.Timing.Expiration.Deadline);
        }

        [Fact]
        public void WithEarlierDeadline_NoSettingsWithDeadline()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = null;
            DateTime? deadline = new DateTime(1L, DateTimeKind.Utc);

            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            Assert.Equal(deadline, newSettings.Timing.Expiration.Deadline);
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsLaterThanExistingDeadline()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithCallTiming(CallTiming.FromExpiration(Expiration.FromDeadline(new DateTime(10L, DateTimeKind.Utc))));
            DateTime? deadline = new DateTime(20L, DateTimeKind.Utc);
            Assert.Same(settings, settings.WithEarlierDeadline(deadline, new FakeClock()));
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsEarlierThanExistingDeadline()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithCallTiming(CallTiming.FromExpiration(Expiration.FromDeadline(new DateTime(10L, DateTimeKind.Utc))));
            DateTime? deadline = new DateTime(1L, DateTimeKind.Utc);

            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            Assert.Equal(deadline, newSettings.Timing.Expiration.Deadline);
            Assert.Equal(token, newSettings.CancellationToken);
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsLaterThanExistingTimeout()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(TimeSpan.FromTicks(100))));
            var clock = new FakeClock();
            DateTime? deadline = clock.GetCurrentDateTimeUtc() + TimeSpan.FromTicks(200);
            Assert.Same(settings, settings.WithEarlierDeadline(deadline, clock));
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsEarlierThanExistingTimeout()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(TimeSpan.FromTicks(200))));
            var clock = new FakeClock();
            DateTime? deadline = clock.GetCurrentDateTimeUtc() + TimeSpan.FromTicks(100);
            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            // New timing has a deadline rather than a timeout
            Assert.Equal(deadline, newSettings.Timing.Expiration.Deadline);
            Assert.Equal(token, newSettings.CancellationToken);
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsLaterThanExistingRetryTotalExpiration()
        {
            var backoffSettings = new BackoffSettings(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), 2.0);
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            var timing = CallTiming.FromRetry(new RetrySettings(backoffSettings, backoffSettings, Expiration.FromDeadline(new DateTime(100L, DateTimeKind.Utc))));
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithCallTiming(timing);
            DateTime? deadline = new DateTime(200L, DateTimeKind.Utc);
            Assert.Same(settings, settings.WithEarlierDeadline(deadline, new FakeClock()));
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsEarlierThanExistingRetryTotalExpiration()
        {
            var backoffSettings = new BackoffSettings(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), 2.0);
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            var timing = CallTiming.FromRetry(new RetrySettings(backoffSettings, backoffSettings, Expiration.FromTimeout(TimeSpan.FromTicks(100))));
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithCallTiming(timing);
            DateTime? deadline = new DateTime(50L, DateTimeKind.Utc);

            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            Assert.Equal(deadline, newSettings.Timing.Retry.TotalExpiration.Deadline);
            Assert.Equal(token, newSettings.CancellationToken);
        }

        [Fact]
        public void WithExpiration_NullExpiration()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token);
            Assert.Throws<ArgumentNullException>(() => settings.WithExpiration(null));
        }

        [Fact]
        public void WithExpiration_NullSettings()
        {
            CallSettings settings = null;
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Equal(expiration, result.Timing.Expiration);
        }

        [Fact]
        public void WithExpiration_SettingsWithNoTiming()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token);
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Equal(expiration, result.Timing.Expiration);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithExpiration_SettingsWithExpiration()
        {
            var token = new CancellationTokenSource().Token;
            var originalTiming = CallTiming.FromTimeout(TimeSpan.FromSeconds(5));
            CallSettings settings = CallSettings.FromCancellationToken(token).WithCallTiming(originalTiming);
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Same(expiration, result.Timing.Expiration);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithExpiration_SettingsWithRetry()
        {
            var token = new CancellationTokenSource().Token;
            var backoffSettings = new BackoffSettings(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10), 1.5);
            var retry = new RetrySettings(backoffSettings, backoffSettings, Expiration.FromTimeout(TimeSpan.FromSeconds(5)));
            var originalTiming = CallTiming.FromRetry(retry);
            CallSettings settings = CallSettings.FromCancellationToken(token).WithCallTiming(originalTiming);
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Same(expiration, result.Timing.Retry.TotalExpiration);
            Assert.Same(backoffSettings, result.Timing.Retry.RetryBackoff);
            Assert.Same(backoffSettings, result.Timing.Retry.TimeoutBackoff);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithResponseMetadataHandler_OnlyHandler()
        {
            Metadata setByHandler = null;
            var settings = ((CallSettings) null).WithResponseMetadataHandler(m => setByHandler = m);
            var metadata = new Metadata();
            settings.ResponseMetadataHandler(metadata);
            Assert.Same(metadata, setByHandler);
        }

        [Fact]
        public void WithTrailingMetadataHandler_OnlyHandler()
        {
            Metadata setByHandler = null;
            var settings = ((CallSettings) null).WithTrailingMetadataHandler(m => setByHandler = m);
            var metadata = new Metadata();
            settings.TrailingMetadataHandler(metadata);
            Assert.Same(metadata, setByHandler);
        }

        [Fact]
        public void WithResponseMetadataHandler_MultipleHandlers()
        {
            Metadata setByHandler1 = null;
            Metadata setByHandler2 = null;
            var settings = ((CallSettings) null)
                .WithResponseMetadataHandler(m => setByHandler1 = m)
                .WithResponseMetadataHandler(m => setByHandler2 = m);
            var metadata = new Metadata();
            settings.ResponseMetadataHandler(metadata);
            Assert.Same(metadata, setByHandler1);
            Assert.Same(metadata, setByHandler2);
        }

        [Fact]
        public void WithTrailingMetadataHandler_MultipleHandlers()
        {
            Metadata setByHandler1 = null;
            Metadata setByHandler2 = null;
            var settings = ((CallSettings) null)
                .WithTrailingMetadataHandler(m => setByHandler1 = m)
                .WithTrailingMetadataHandler(m => setByHandler2 = m);
            var metadata = new Metadata();
            settings.TrailingMetadataHandler(metadata);
            Assert.Same(metadata, setByHandler1);
            Assert.Same(metadata, setByHandler2);
        }
    }
}
