/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RetryAttemptTest
    {
        private static readonly TimeSpan OneSecond = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan FiveSeconds = TimeSpan.FromSeconds(5);

        [Fact]
        public Task DeadlineRespected()
        {
            var settings = RetrySettings.FromExponentialBackoff(
                maxAttempts: 10, initialBackoff: OneSecond, maxBackoff: FiveSeconds,
                backoffMultiplier: 2, retryFilter: ex => true, backoffJitter: RetrySettings.NoJitter);
            var scheduler = new FakeScheduler();
            var deadline = scheduler.Clock.GetCurrentDateTimeUtc() + FiveSeconds;

            var sequence = RetryAttempt.CreateRetrySequence(settings, scheduler, deadline, scheduler.Clock);
            // Should attempt at T=0, T=1, T=3, then stop because the next attempt would be after the deadline.
            return AssertAttemptsAsync(sequence, scheduler, () => new Exception(), 0, 1, 3);
        }

        [Fact]
        public Task MaxAttemptsRespected()
        {
            var settings = RetrySettings.FromConstantBackoff(
                maxAttempts: 4, backoff: OneSecond, retryFilter: ex => true, backoffJitter: RetrySettings.NoJitter);
            var scheduler = new FakeScheduler();

            var sequence = RetryAttempt.CreateRetrySequence(settings, scheduler);
            // Should attempt at T=0, T=1, T=2, T=3, then stop because we're only allowed four attempts.
            return AssertAttemptsAsync(sequence, scheduler, () => new Exception(), 0, 1, 2, 3);
        }

        [Fact]
        public Task JitterRespected()
        {
            var settings = RetrySettings.FromExponentialBackoff(
                maxAttempts: 6, initialBackoff: TimeSpan.FromSeconds(2), maxBackoff: TimeSpan.FromSeconds(10),
                backoffMultiplier: 2, retryFilter: ex => true, backoffJitter: new HalvingJitter());
            var scheduler = new FakeScheduler();


            var sequence = RetryAttempt.CreateRetrySequence(settings, scheduler);
            // Sequence of theoretical backoffs is 2, 4, 8, 10, 10, 10
            // Sequence of jittered backoffs is 1, 2, 4, 5, 5.
            return AssertAttemptsAsync(sequence, scheduler, () => new Exception(), 0, 1, 3, 7, 12, 17);
        }

        [Fact]
        public Task PredicateRespected()
        {
            int count = 0;
            Func<Exception> exceptionProvider = () => ++count == 3 ? new Exception() : new RpcException(Status.DefaultCancelled);

            var settings = RetrySettings.FromExponentialBackoff(
                maxAttempts: 4, initialBackoff: OneSecond, maxBackoff: FiveSeconds,
                backoffMultiplier: 1, retryFilter: ex => ex is RpcException, backoffJitter: RetrySettings.NoJitter);
            var scheduler = new FakeScheduler();
            var sequence = RetryAttempt.CreateRetrySequence(settings, scheduler);
            return AssertAttemptsAsync(sequence, scheduler, exceptionProvider, 0, 1, 2);
        }

        [Fact]
        public Task InitialBackoffOverrideRespected()
        {
            var settings = RetrySettings.FromConstantBackoff(
                maxAttempts: 4, backoff: FiveSeconds, retryFilter: ex => true, backoffJitter: RetrySettings.NoJitter);
            var scheduler = new FakeScheduler();

            var sequence = RetryAttempt.CreateRetrySequence(settings, scheduler, initialBackoffOverride: OneSecond);
            // Should attempt at T=0, T=1, T=6, T=11.
            return AssertAttemptsAsync(sequence, scheduler, () => new Exception(), 0, 1, 6, 11);
        }

        private Task AssertAttemptsAsync(
            IEnumerable<RetryAttempt> attempts, FakeScheduler scheduler, Func<Exception> exceptionProvider,
            params int[] expectedAttemptTimes)
        {
            var start = scheduler.Clock.GetCurrentDateTimeUtc();
            var iterator = attempts.GetEnumerator();
            Assert.True(iterator.MoveNext());
            return scheduler.RunAsync(async () =>
            {
                for (int i = 0; i < expectedAttemptTimes.Length; i++)
                {
                    var attempt = iterator.Current;
                    bool expectedLastAttempt = (i == expectedAttemptTimes.Length - 1);
                    Assert.Equal(start.AddSeconds(expectedAttemptTimes[i]), scheduler.Clock.GetCurrentDateTimeUtc());
                    if (expectedLastAttempt)
                    {
                        Assert.False(attempt.ShouldRetry(exceptionProvider()));
                    }
                    else
                    {
                        Assert.True(attempt.ShouldRetry(exceptionProvider()));
                        await attempt.BackoffAsync(default);
                        Assert.True(iterator.MoveNext());
                    }
                }
            });
        }

        private class HalvingJitter : RetrySettings.IJitter
        {
            public TimeSpan GetDelay(TimeSpan maxDelay) => TimeSpan.FromTicks(maxDelay.Ticks / 2);
        }
    }
}
