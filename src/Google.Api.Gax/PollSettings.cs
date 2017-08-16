/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings controlling repeated polling, for example when waiting for a long-running operation
    /// to complete.
    /// </summary>
    public sealed class PollSettings
    {
        /// <summary>
        /// How long to wait before giving up. This is never null.
        /// </summary>
        public Expiration Expiration { get; }

        /// <summary>
        /// The delay between RPC calls when fetching the operation status. This is never negative.
        /// There is no exponential backoff between calls; the same delay is used for each call.
        /// </summary>
        /// <remarks>
        /// This is the delay between the a successful RPC response being received
        /// and the next RPC request being sent.
        /// </remarks>
        public TimeSpan Delay { get; }

        /// <summary>
        /// The multiplier to apply to the delay on each iteration; must be greater or equal to 1.0.
        /// </summary>
        public double DelayMultiplier { get; }

        /// <summary>
        /// The maximum delay to use. If the increasing delay due to the delay multiplier exceeds this,
        /// this maximum is used instead.
        /// </summary>
        public TimeSpan MaxDelay { get; }

        /// <summary>
        /// Creates poll settings from the given expiration and constant delay.
        /// </summary>
        /// <param name="expiration">The expiration to use in order to know when to stop polling. Must not be null.</param>
        /// <param name="delay">The constant delay between RPC calls. Must be non-negative.</param>
        public PollSettings(Expiration expiration, TimeSpan delay) : this (expiration, delay, 1.0, delay) { }

        /// <summary>
        /// Creates poll settings from the given expiration, delay, delay multiplier and maximum delay.
        /// </summary>
        /// <param name="expiration">The expiration to use in order to know when to stop polling. Must not be null.</param>
        /// <param name="delay">The delay between RPC calls. Must be non-negative.</param>
        /// <param name="delayMultiplier">The multiplier to apply to the delay on each iteration; must be greater or equal to 1.0.</param>
        /// <param name="maxDelay">The maximum delay to use.</param>
        public PollSettings(Expiration expiration, TimeSpan delay, double delayMultiplier, TimeSpan maxDelay)
        {
            Expiration = GaxPreconditions.CheckNotNull(expiration, nameof(expiration));
            Delay = GaxPreconditions.CheckNonNegativeDelay(delay, nameof(delay));
            if (delayMultiplier < 1.0 || double.IsNaN(delayMultiplier))
            {
                throw new ArgumentOutOfRangeException(nameof(delayMultiplier), delayMultiplier,
                    "Delay multiplier must be a real number greater than or equal to 1");
            }
            DelayMultiplier = delayMultiplier;
            MaxDelay = GaxPreconditions.CheckNonNegativeDelay(maxDelay, nameof(maxDelay));
        }

        /// <summary>
        /// Works out the next delay from the current one, based on the multiplier and maximum.
        /// </summary>
        /// <param name="currentDelay">The current delay.</param>
        /// <returns>The next delay.</returns>
        internal TimeSpan NextDelay(TimeSpan currentDelay)
        {
            checked
            {
                TimeSpan next = new TimeSpan((long)(currentDelay.Ticks * DelayMultiplier));
                return next < MaxDelay ? next : MaxDelay;
            }
        }
    }
}
