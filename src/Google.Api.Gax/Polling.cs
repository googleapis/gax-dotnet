/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Helper methods for polling scenarios.
    /// </summary>
    public static class Polling
    {
        /// <summary>
        /// Repeatedly calls the specified polling action, delaying between calls,
        /// until a given condition is met in the response.
        /// </summary>
        /// <typeparam name="TResponse">The response type. Must not be null.</typeparam>
        /// <param name="pollAction">The poll action, typically performing an RPC. The value passed to the
        /// action is the overall deadline, so that the RPC settings can be adjusted accordingly. A null value
        /// indicates no deadline.</param>
        /// <param name="completionPredicate">The test for whether to return the response (<c>true</c>) or continue
        /// polling (<c>false</c>). Must not be null.</param>
        /// <param name="clock">The clock to use for determining deadlines. Must not be null.</param>
        /// <param name="scheduler">The scheduler to use for delaying between calls. Must not be null.</param>
        /// <param name="pollSettings">The poll settings, controlling timeouts, call settings and delays.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel delays, if any.</param>
        /// <returns>The completed response.</returns>
        /// <exception cref="TimeoutException">The timeout specified in the poll settings expired.</exception>
        public static TResponse PollRepeatedly<TResponse>(
            Func<DateTime?, TResponse> pollAction,
            Predicate<TResponse> completionPredicate,
            IClock clock,
            IScheduler scheduler,
            PollSettings pollSettings,
            CancellationToken cancellationToken)
        {
            GaxPreconditions.CheckNotNull(pollAction, nameof(pollAction));
            GaxPreconditions.CheckNotNull(completionPredicate, nameof(completionPredicate));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler));
            GaxPreconditions.CheckNotNull(pollSettings, nameof(pollSettings));

            var deadline = pollSettings.Expiration.CalculateDeadline(clock);
            while (true)
            {
                var latest = pollAction(deadline);
                if (completionPredicate(latest))
                {
                    return latest;
                }
                if (clock.GetCurrentDateTimeUtc() + pollSettings.Delay >= deadline)
                {
                    // TODO: Could return null instead. Unclear what's better here.
                    throw new TimeoutException("Operation did not complete within the specified expiry time");
                }
                scheduler.Sleep(pollSettings.Delay, cancellationToken);
            }
        }

        /// <summary>
        /// Asynchronously repeatedly calls the specified polling action, delaying between calls,
        /// until a given condition is met in the response.
        /// </summary>
        /// <typeparam name="TResponse">The response type. Must not be null.</typeparam>
        /// <param name="pollAction">The poll action, typically performing an RPC. The value passed to the
        /// action is the overall deadline, so that the RPC settings can be adjusted accordingly. A null
        /// value indicates no deadline.</param>
        /// <param name="completionPredicate">The test for whether to return the response (<c>true</c>) or continue
        /// polling (<c>false</c>). Must not be null.</param>
        /// <param name="clock">The clock to use for determining deadlines. Must not be null.</param>
        /// <param name="scheduler">The scheduler to use for delaying between calls. Must not be null.</param>
        /// <param name="pollSettings">The poll settings, controlling timeouts, call settings and delays.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel delays, if any.</param>
        /// <returns>A task representing the asynchronous operation. The result of the task will be the completed response.</returns>
        public static async Task<TResponse> PollRepeatedlyAsync<TResponse>(
            Func<DateTime?, Task<TResponse>> pollAction,
            Predicate<TResponse> completionPredicate,
            IClock clock,
            IScheduler scheduler,
            PollSettings pollSettings,
            CancellationToken cancellationToken)
        {
            GaxPreconditions.CheckNotNull(pollAction, nameof(pollAction));
            GaxPreconditions.CheckNotNull(completionPredicate, nameof(completionPredicate));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler));
            GaxPreconditions.CheckNotNull(pollSettings, nameof(pollSettings));

            var deadline = pollSettings.Expiration.CalculateDeadline(clock);
            while (true)
            {
                var latest = await pollAction(deadline).ConfigureAwait(false);
                if (completionPredicate(latest))
                {
                    return latest;
                }
                if (clock.GetCurrentDateTimeUtc() + pollSettings.Delay >= deadline)
                {
                    // TODO: Could return null instead. Unclear what's better here.
                    throw new TimeoutException("Operation did not complete within the specified expiry time");
                }
                await scheduler.Delay(pollSettings.Delay, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
