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
    /// The type of <see cref="Expiration"/>; none, timeout or deadline.
    /// </summary>
    public enum ExpirationType
    {
        /// <summary>
        /// No expiration; an infinite timeout.
        /// </summary>
        None,

        /// <summary>
        /// Expiration is a relative timeout, represented by a <see cref="TimeSpan"/>.
        /// </summary>
        Timeout,

        /// <summary>
        /// Expiration is an absolute deadline, represented by a <see cref="DateTime"/>.
        /// </summary>
        Deadline,
    }

    /// <summary>
    /// Expiration specified by relative timeout or absolute deadline.
    /// </summary>
    public sealed class Expiration
    {
        /// <summary>
        /// Create an <see cref="Expiration"/> with a relative timeout.
        /// </summary>
        /// <param name="timeout">The relative timeout.</param>
        /// <returns>An <see cref="Expiration"/> with the specified relative timeout.</returns>
        /// <remarks>
        /// Zero or negative timeouts are valid, and will cause immediate failure of the operation being performed.
        /// </remarks>
        public static Expiration FromTimeout(TimeSpan timeout) => new Expiration(timeout, null);

        /// <summary>
        /// Create an <see cref="Expiration"/> with an absolute deadline.
        /// </summary>
        /// <param name="deadline">The absolute deadline. Should be a UTC datetime.</param>
        /// <returns>An <see cref="Expiration"/> with the specified absolute deadline.</returns>
        /// <remarks>
        /// Deadlines in the past are valid, and will cause immediate failure of the operation being performed.
        /// </remarks>
        public static Expiration FromDeadline(DateTime deadline) => new Expiration(null, deadline);

        /// <summary>
        /// An <see cref="Expiration"/> with no timeout or deadline.
        /// </summary>
        /// <remarks>
        /// Indicates that no expiration is required.
        /// </remarks>
        public static Expiration None { get; } = new Expiration(null, null);

        private Expiration(TimeSpan? timeout, DateTime? deadline)
        {
            Timeout = timeout;
            Deadline = deadline;
        }

        /// <summary>
        /// If not null, the relative timeout of this expiration.
        /// </summary>
        public TimeSpan? Timeout { get; }

        /// <summary>
        /// If not null, the absolute deadline of this expiration.
        /// </summary>
        public DateTime? Deadline { get; }

        /// <summary>
        /// What <see cref="ExpirationType"/> is contained in this <see cref="Expiration"/>.
        /// </summary>
        public ExpirationType Type =>
            Timeout != null ? ExpirationType.Timeout :
            Deadline != null ? ExpirationType.Deadline :
            ExpirationType.None;
    }

    /// <summary>
    /// Extension methods for <see cref="Expiration"/>.
    /// </summary>
    public static class ExpirationExtensions
    {
        /// <summary>
        /// Calculate a deadline from an <see cref="Expiration"/> and a <see cref="IClock"/>.
        /// </summary>
        /// <param name="expiration"><see cref="Expiration"/>, may be null.</param>
        /// <param name="clock"><see cref="IClock"/> to use for deadline calculation.</param>
        /// <returns>The calculated absolute deadline, or null if no deadline should be used.</returns>
        public static DateTime? CalculateDeadline(this Expiration expiration, IClock clock)
        {
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            if (expiration == null)
            {
                return null;
            }
            switch (expiration.Type)
            {
                case ExpirationType.None:
                    return null;
                case ExpirationType.Timeout:
                    return clock.GetCurrentDateTimeUtc() + expiration.Timeout.Value;
                case ExpirationType.Deadline:
                    return expiration.Deadline.Value;
                default:
                    throw new ArgumentException("Invalid expiration", nameof(expiration));
            }
        }
    }
}
