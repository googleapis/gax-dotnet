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
    /// Backoff settings used within <see cref="RetrySettings"/> to implement
    /// exponential backoff.
    /// </summary>
    public sealed class BackoffSettings
    {
        private TimeSpan _delay;
        private TimeSpan _maxDelay;
        private double _delayMultiplier = 1.0;

        /// <summary>
        /// The initial delay, either for the first retry or as the initial RPC timeout.
        /// </summary>
        /// <remarks>
        /// The default value of this property is <see cref="TimeSpan.Zero"/>.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is negative.</exception>
        public TimeSpan Delay
        {
            get { return _delay; }
            set { _delay = GaxPreconditions.CheckNonNegativeDelay(value, nameof(value)); }
        }

        /// <summary>
        /// The multiplier to apply to the delay on each iteration; must be greater than or equal to 1.0.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default value of this property is 1.0.
        /// </para>
        /// <para>
        /// As an example, a multiplier of 2.0 with a delay of 0.1s on an RPC which fails three times before
        /// succeeding would lead to an initial delay between the first response and the second request
        /// of 0.1s; a delay between the second response and the third request of 0.2s, and a delay
        /// between the third response and the fourth request.
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is not a number, or is less than 1.</exception>
        public double DelayMultiplier
        {
            get { return _delayMultiplier; }
            set
            {
                if (value < 1.0 || double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Delay multiplier must be a real number greater than or equal to 1");
                }
                _delayMultiplier = value;
            }
        }

        /// <summary>
        /// The maximum delay to use. If the increasing delay due to the delay multiplier exceeds this,
        /// this maximum is used instead.
        /// </summary>
        /// <remarks>
        /// The default value of this property is <see cref="TimeSpan.Zero"/>.
        /// </remarks>
        /// <value>The maximum delay. Must not be negative.</value>
        /// <exception cref="ArgumentOutOfRangeException">The value is negative.</exception>
        public TimeSpan MaxDelay
        {
            get { return _maxDelay; }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Maximum delay must not be negative");
                }
                _maxDelay = value;
            }
        }

        /// <summary>
        /// Creates a clone of this instance.
        /// </summary>
        /// <returns>A clone of this instance.</returns>
        public BackoffSettings Clone() =>
            new BackoffSettings
            {
                Delay = Delay,
                DelayMultiplier = DelayMultiplier,
                MaxDelay = MaxDelay
            };

        /// <summary>
        /// Works out the next delay from the current one, based on the multiplier and maximum.
        /// </summary>
        internal TimeSpan NextDelay(TimeSpan currentDelay)
        {
            checked
            {
                TimeSpan next = new TimeSpan((long) (currentDelay.Ticks * DelayMultiplier));
                return next < MaxDelay ? next : MaxDelay;
            }
        }
    }
}
