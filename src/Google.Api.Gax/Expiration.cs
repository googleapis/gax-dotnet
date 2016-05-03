/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    public enum ExpirationType
    {
        None,
        Timeout,
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

        public ExpirationType Type =>
            Timeout != null ? ExpirationType.Timeout :
            Deadline != null ? ExpirationType.Deadline :
            ExpirationType.None;
    }

    public static class ExpirationExtensions
    {
        public static DateTime? CalculateDeadline(this Expiration expiration, IClock clock)
        {
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
