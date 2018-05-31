/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Backoff settings used within <see cref="RetrySettings"/> to implement
    /// exponential backoff.
    /// </summary>
    public sealed class BackoffSettings
    {
        /// <summary>
        /// The initial delay, either for the first retry or as the initial RPC timeout.
        /// </summary>
        public TimeSpan Delay { get; }

        /// <summary>
        /// The maximum delay to use. If the increasing delay due to the delay multiplier exceeds this,
        /// this maximum is used instead.
        /// </summary>
        public TimeSpan MaxDelay { get; }

        /// <summary>
        /// The multiplier to apply to the delay on each iteration; must be greater than or equal to 1.0.
        /// </summary>
        /// <remarks>
        /// <para>
        /// As an example, a multiplier of 2.0 with a delay of 0.1s on an RPC which fails three times before
        /// succeeding would lead to an initial delay between the first response and the second request
        /// of 0.1s; a delay between the second response and the third request of 0.2s, and a delay
        /// between the third response and the fourth request.
        /// </para>
        /// </remarks>
        public double DelayMultiplier { get; } = 1.0;

        /// <summary>
        /// Creates a new instance with the specified settings.
        /// </summary>
        /// <param name="delay">The initial delay, either for the first retry or as the initial RPC timeout.</param>
        /// <param name="maxDelay">The maximum delay to use. If the increasing delay due to the delay multiplier exceeds this,
        /// this maximum is used instead.</param>
        /// <param name="delayMultiplier">The multiplier to apply to the delay on each iteration; must be greater than or equal to 1.0.
        /// Defaults to 1.0.</param>
        public BackoffSettings(TimeSpan delay, TimeSpan maxDelay, double delayMultiplier = 1.0)
        {
            GaxPreconditions.CheckNonNegativeDelay(delay, nameof(delay));
            GaxPreconditions.CheckNonNegativeDelay(maxDelay, nameof(maxDelay));
            if (delayMultiplier < 1.0 || double.IsNaN(delayMultiplier))
            {
                throw new ArgumentOutOfRangeException(nameof(delayMultiplier), delayMultiplier,
                    "Delay multiplier must be a real number greater than or equal to 1");
            }
            Delay = delay;
            MaxDelay = maxDelay;
            DelayMultiplier = delayMultiplier;
        }

        /// <summary>
        /// Works out the next delay from the current one, based on the multiplier and maximum.
        /// </summary>
        /// <param name="currentDelay">The current delay to use as a basis for the next one.</param>
        /// <returns>The next delay to use, which is always at least <see cref="Delay"/> and at most <see cref="MaxDelay"/>.</returns>
        public TimeSpan NextDelay(TimeSpan currentDelay)
        {
            checked
            {
                TimeSpan next = new TimeSpan((long) (currentDelay.Ticks * DelayMultiplier));
                return
                    next < Delay ? Delay :        // Lower bound capping
                    next > MaxDelay ? MaxDelay :  // Upper bound capping
                    next;
            }
        }
    }
}
