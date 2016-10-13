/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
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
        /// <param name="pollAction">The poll action, typically performing an RPC. </param>
        /// <param name="completionPredicate">The test for whether to return the response (<c>true</c>) or continue
        /// polling (<c>false</c>). Must not be null.</param>
        /// <param name="clock">The clock to use for determining deadlines. Must not be null.</param>
        /// <param name="scheduler">The scheduler to use for delaying between calls. Must not be null.</param>
        /// <param name="pollSettings">The poll settings, controlling timeouts, call settings and delays.</param>
        /// <returns>The completed response.</returns>
        /// <exception cref="TimeoutException">The timeout specified in the poll settings expired.</exception>
        public static TResponse PollRepeatedly<TResponse>(
            Func<CallSettings, TResponse> pollAction,
            Predicate<TResponse> completionPredicate,
            IClock clock,
            IScheduler scheduler,
            PollSettings pollSettings)
        {
            GaxPreconditions.CheckNotNull(pollAction, nameof(pollAction));
            GaxPreconditions.CheckNotNull(completionPredicate, nameof(completionPredicate));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler));
            GaxPreconditions.CheckNotNull(pollSettings, nameof(pollSettings));

            var deadline = pollSettings.Expiration.CalculateDeadline(clock);
            while (true)
            {
                // FIXME: Override the RPC deadline if it's before the one we would use?
                // Or just tweak the documentation for Expiration...
                var latest = pollAction(pollSettings.CallSettings);
                if (completionPredicate(latest))
                {
                    return latest;
                }
                if (clock.GetCurrentDateTimeUtc() + pollSettings.Delay >= deadline)
                {
                    // TODO: Could return null instead. Unclear what's better here.
                    throw new TimeoutException("Operation did not complete within the specified expiry time");
                }
                scheduler.Sleep(pollSettings.Delay);
            }
        }

        /// <summary>
        /// Asynchronously repeatedly calls the specified polling action, delaying between calls,
        /// until a given condition is met in the response.
        /// </summary>
        /// <typeparam name="TResponse">The response type. Must not be null.</typeparam>
        /// <param name="pollAction">The poll action, typically performing an RPC. </param>
        /// <param name="completionPredicate">The test for whether to return the response (<c>true</c>) or continue
        /// polling (<c>false</c>). Must not be null.</param>
        /// <param name="clock">The clock to use for determining deadlines. Must not be null.</param>
        /// <param name="scheduler">The scheduler to use for delaying between calls. Must not be null.</param>
        /// <param name="pollSettings">The poll settings, controlling timeouts, call settings and delays.</param>
        /// <returns>A task representing the asynchronous operation. The result of the task will be the completed response.</returns>
        public static async Task<TResponse> PollRepeatedlyAsync<TResponse>(
            Func<CallSettings, Task<TResponse>> pollAction,
            Predicate<TResponse> completionPredicate,
            IClock clock,
            IScheduler scheduler,
            PollSettings pollSettings)
        {
            GaxPreconditions.CheckNotNull(pollAction, nameof(pollAction));
            GaxPreconditions.CheckNotNull(completionPredicate, nameof(completionPredicate));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler));
            GaxPreconditions.CheckNotNull(pollSettings, nameof(pollSettings));

            var deadline = pollSettings.Expiration.CalculateDeadline(clock);
            while (true)
            {
                // FIXME: Override the RPC deadline if it's before the one we would use?
                // Or just tweak the documentation for Expiration...
                var latest = await pollAction(pollSettings.CallSettings).ConfigureAwait(false);
                if (completionPredicate(latest))
                {
                    return latest;
                }
                if (clock.GetCurrentDateTimeUtc() + pollSettings.Delay >= deadline)
                {
                    // TODO: Could return null instead. Unclear what's better here.
                    throw new TimeoutException("Operation did not complete within the specified expiry time");
                }
                // TODO: Use a cancellation token if we have one. Not clear where we'd get it from though,
                // as it could be in the underlying call settings which we don't have access to. Maybe
                // only use a cancellation token if it's specified in pollSettings.CallSettings?
                await scheduler.Delay(pollSettings.Delay).ConfigureAwait(false);
            }
        }
    }
}
