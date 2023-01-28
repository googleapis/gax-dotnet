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
            Expiration expiration1 = Expiration.None;
            Expiration expiration2 = Expiration.FromDeadline(DateTime.UtcNow);

            CancellationToken token = new CancellationTokenSource().Token;

            var settings1 = new CallSettings(token, expiration1, null, null, null, null);
            var settings2 = new CallSettings(null, expiration2, null, null, null, null);
            var merged = settings1.MergedWith(settings2);
            Assert.Equal(token, merged.CancellationToken);
            Assert.Same(expiration2, merged.Expiration);
        }

        [Fact]
        public void WithCancellationToken()
        {
            CancellationToken token1 = new CancellationTokenSource().Token;
            var original = new CallSettings(token1, Expiration.None, null, null, null, null);

            CancellationToken token2 = new CancellationTokenSource().Token;
            var result = original.WithCancellationToken(token2);
            Assert.Same(Expiration.None, result.Expiration);
            Assert.Equal(token2, result.CancellationToken);
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
            Assert.Equal(deadline, newSettings.Expiration.Deadline);
        }

        [Fact]
        public void WithEarlierDeadline_NoSettingsWithDeadline()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = null;
            DateTime? deadline = new DateTime(1L, DateTimeKind.Utc);

            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            Assert.Equal(deadline, newSettings.Expiration.Deadline);
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsLaterThanExistingDeadline()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithDeadline(new DateTime(10L, DateTimeKind.Utc));
            DateTime? deadline = new DateTime(20L, DateTimeKind.Utc);
            Assert.Same(settings, settings.WithEarlierDeadline(deadline, new FakeClock()));
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsEarlierThanExistingDeadline()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithDeadline(new DateTime(10L, DateTimeKind.Utc));
            DateTime? deadline = new DateTime(1L, DateTimeKind.Utc);

            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            Assert.Equal(deadline, newSettings.Expiration.Deadline);
            Assert.Equal(token, newSettings.CancellationToken);
        }

        [Fact]
        public void WithEarlierDeadline_DeadlineIsLaterThanExistingTimeout()
        {
            // Use a cancellation token to emphasize that it's not just the timing.
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token)
                .WithTimeout(TimeSpan.FromTicks(100));
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
                .WithTimeout(TimeSpan.FromTicks(200));
            var clock = new FakeClock();
            DateTime? deadline = clock.GetCurrentDateTimeUtc() + TimeSpan.FromTicks(100);
            CallSettings newSettings = settings.WithEarlierDeadline(deadline, new FakeClock());
            // New timing has a deadline rather than a timeout
            Assert.Equal(deadline, newSettings.Expiration.Deadline);
            Assert.Equal(token, newSettings.CancellationToken);
        }

        [Fact]
        public void WithRetry_NullInSettings_NullRetry()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token);
            var result = settings.WithRetry(null);
            Assert.Equal(token, result.CancellationToken);
            Assert.Null(result.Retry);
        }

        [Fact]
        public void WithRetry_NotNullInSettings_NullRetry()
        {
            RetrySettings retry = RetrySettings.FromExponentialBackoff(
                10, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), 1.5, ex => true);
            CallSettings settings = CallSettings.FromRetry(retry);
            var result = settings.WithRetry(null);
            Assert.Null(result.Retry);
        }

        [Fact]
        public void WithRetry_NullSettings()
        {
            CallSettings settings = null;
            RetrySettings retry = RetrySettings.FromExponentialBackoff(
                10, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), 1.5, ex => true);
            var result = settings.WithRetry(retry);
            Assert.Equal(retry, result.Retry);
        }

        [Fact]
        public void WithRetry_BothNull()
        {
            CallSettings settings = null;
            RetrySettings retry = null;
            var result = settings.WithRetry(retry);
            Assert.Null(result);
        }

        [Fact]
        public void WithExpiration_NullInSettings_NullExpiration()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token);
            var result = settings.WithExpiration(null);
            Assert.Equal(token, result.CancellationToken);
            Assert.Null(result.Expiration);
        }

        [Fact]
        public void WithExpiration_NotNullInSettings_NullExpiration()
        {
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            CallSettings settings = CallSettings.FromExpiration(expiration);
            var result = settings.WithExpiration(null);
            Assert.Null(result.Expiration);
        }

        [Fact]
        public void WithExpiration_NullSettings()
        {
            CallSettings settings = null;
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Equal(expiration, result.Expiration);
        }

        [Fact]
        public void WithExpiration_BothNull()
        {
            CallSettings settings = null;
            Expiration expiration = null;
            var result = settings.WithExpiration(expiration);
            Assert.Null(result);
        }

        [Fact]
        public void WithExpiration_SettingsWithNoTiming()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token);
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Equal(expiration, result.Expiration);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithExpiration_SettingsWithExpiration()
        {
            var token = new CancellationTokenSource().Token;
            CallSettings settings = CallSettings.FromCancellationToken(token).WithTimeout(TimeSpan.FromSeconds(5));
            Expiration expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var result = settings.WithExpiration(expiration);
            Assert.Same(expiration, result.Expiration);
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
