/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// An attempt at a retriable operation. Use <see cref="CreateRetrySequence(RetrySettings, IScheduler, DateTime?, IClock, TimeSpan?)"/>
    /// or <see cref="CreateRetrySequence(RetrySettings, IScheduler, TimeSpan?)"/> to create a sequence of attempts that follow the specified settings.
    /// </summary>
    public sealed class RetryAttempt
    {
        private readonly RetrySettings _settings;
        private readonly IScheduler _scheduler;
        private readonly IClock _clock;
        private readonly DateTime? _deadline;

        /// <summary>
        /// The 1-based number of this attempt. If this is equal to <see cref="RetrySettings.MaxAttempts"/> for the settings
        /// used to create this attempt, <see cref="ShouldRetry(Exception)"/> will always return false.
        /// </summary>
        public int AttemptNumber { get; }

        /// <summary>
        /// The time that will be used to sleep or delay in <see cref="Backoff"/> and <see cref="BackoffAsync(CancellationToken)"/>.
        /// This has already had jitter applied to it.
        /// </summary>
        public TimeSpan JitteredBackoff { get; }

        /// <summary>
        /// Returns a sequence of retry attempts. The sequence has <see cref="RetrySettings.MaxAttempts"/> elements, and calling
        /// <see cref="ShouldRetry(Exception)"/> on the last attempt will always return false. This overload assumes no deadline,
        /// and so does not require a clock.
        /// </summary>
        /// <param name="settings">The retry settings to create a sequence for. Must not be null.</param>
        /// <param name="scheduler">The scheduler to use for delays.</param>
        /// <param name="initialBackoffOverride">An override value to allow an initial backoff which is not the same
        /// as <see cref="RetrySettings.InitialBackoff"/>. This is typically to allow an "immediate first retry".</param>
        /// <returns></returns>
        public static IEnumerable<RetryAttempt> CreateRetrySequence(RetrySettings settings, IScheduler scheduler, TimeSpan? initialBackoffOverride = null)
        {
            GaxPreconditions.CheckNotNull(settings, nameof(settings));
            GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler));

            TimeSpan backoff = initialBackoffOverride ?? settings.InitialBackoff;
            for (int i = 1; i <= settings.MaxAttempts; i++)
            {
                yield return new RetryAttempt(settings, null, null, scheduler, i, settings.BackoffJitter.GetDelay(backoff));
                backoff = settings.NextBackoff(backoff);
            }
        }

        /// <summary>
        /// Returns a sequence of retry attempts. The sequence has <see cref="RetrySettings.MaxAttempts"/> elements, and calling
        /// <see cref="ShouldRetry(Exception)"/> on the last attempt will always return false.
        /// </summary>
        /// <param name="settings">The retry settings to create a sequence for. Must not be null.</param>
        /// <param name="scheduler">The scheduler to use for delays.</param>
        /// <param name="deadline">The overall deadline for the operation.</param>
        /// <param name="clock">The clock to use to compare the current time with the deadline.</param>
        /// <param name="initialBackoffOverride">An override value to allow an initial backoff which is not the same
        /// as <see cref="RetrySettings.InitialBackoff"/>. This is typically to allow an "immediate first retry".</param>
        /// <returns></returns>
        public static IEnumerable<RetryAttempt> CreateRetrySequence(RetrySettings settings, IScheduler scheduler, DateTime? deadline, IClock clock, TimeSpan? initialBackoffOverride = null)
        {
            GaxPreconditions.CheckNotNull(settings, nameof(settings));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler));

            // It's simpler not to need nullable logic when computing deadlines.
            var effectiveDeadline = deadline ?? DateTime.MaxValue;
            TimeSpan backoff = initialBackoffOverride ?? settings.InitialBackoff;
            for (int i = 1; i <= settings.MaxAttempts; i++)
            {
                yield return new RetryAttempt(settings, effectiveDeadline, clock, scheduler, i, settings.BackoffJitter.GetDelay(backoff));
                backoff = settings.NextBackoff(backoff);
            }
        }

        private RetryAttempt(RetrySettings settings, DateTime? deadline, IClock clock, IScheduler scheduler, int attemptNumber, TimeSpan jitteredBackoff) =>
            (_settings, _deadline, _clock, _scheduler, AttemptNumber, JitteredBackoff) =
            (settings, deadline, clock, scheduler, attemptNumber, jitteredBackoff);

        /// <summary>
        /// Indicates whether the operation should be retried when the given exception has been thrown.
        /// This will return false if the exception indicates that the operation shouldn't be retried,
        /// or the maximum number of attempts has been reached, or the next backoff would exceed the overall
        /// deadline. (It is assumed that <see cref="Backoff"/> or <see cref="BackoffAsync"/>
        /// will be called immediately afterwards.)
        /// </summary>
        /// <param name="exception">The exception thrown by the retriable operation.</param>
        /// <returns><c>true</c> if the operation should be retried; <c>false</c> otherwise.</returns>
        public bool ShouldRetry(Exception exception) =>
            AttemptNumber < _settings.MaxAttempts &&
            (_deadline is null || _clock.GetCurrentDateTimeUtc() + JitteredBackoff < _deadline) &&
            _settings.RetryFilter(exception);

        /// <summary>
        /// Synchronously sleeps for a period of <see cref="JitteredBackoff"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to apply to the sleep operation.</param>
        public void Backoff(CancellationToken cancellationToken) =>
            _scheduler.Sleep(JitteredBackoff, cancellationToken);

        /// <summary>
        /// Asynchronously delays for a period of <see cref="JitteredBackoff"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to apply to the delay operation.</param>
        public Task BackoffAsync(CancellationToken cancellationToken) =>
            _scheduler.Delay(JitteredBackoff, cancellationToken);
    }
}
