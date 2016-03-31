/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings for retrying RPCs.
    /// </summary>
    public sealed class RetrySettings
    {
        /// <summary>
        /// The backoff policy for the time between retries.
        /// </summary>
        public BackoffSettings RetryBackoff { get; set; }

        /// <summary>
        /// The backoff policy for timeouts of retries.
        /// </summary>
        /// <remarks>
        /// This allows an increasing timeout, initially requesting a fast call,
        /// then allowing a bit more time, then a bit more, and so on. However,
        /// the timeout will also be adjusted to accommodate <see cref="TotalTimeout"/>.
        /// </remarks>
        public BackoffSettings TimeoutBackoff { get; set; }

        /// <summary>
        /// A predicate to determine whether or not a particular exception should cause the operation to be retried.
        /// Usually this is simply a matter of checking the status codes.
        /// </summary>
        public Predicate<RpcException> RetryFilter { get; set; } = DefaultFilter;

        /// <summary>
        /// The delay jitter to apply for delays, defaulting to <see cref="RandomJitter"/>.
        /// </summary>
        /// <remarks>
        /// "Jitter" is used to introduce randomness into the pattern of delays. This is to avoid multiple
        /// clients performing the same delay pattern starting at the same point in time,
        /// leading to higher-than-necessary contention. The default jitter simply takes each maximum delay
        /// and returns an actual delay which is a uniformly random value between 0 and the maximum. This
        /// is good enough for most applications, but makes precise testing difficult.
        /// </remarks>
        public IJitter DelayJitter { get; set; } = RandomJitter;

        /// <summary>
        /// Creates a deep clone of this instance. No validation is performed.
        /// It is assumed that the delay jitter does not require deep cloning.
        /// </summary>
        /// <returns>A deep clone of this instance.</returns>
        public RetrySettings Clone() =>
            new RetrySettings
            {
                RetryBackoff = RetryBackoff?.Clone(),
                TimeoutBackoff = TimeoutBackoff?.Clone(),
                DelayJitter = DelayJitter,
                RetryFilter = RetryFilter
            };

        /// <summary>
        /// Validates the settings.
        /// </summary>
        /// <returns>A reference to this instance, for use in chaining calls.</returns>
        /// <param name="paramName">The parameter name to use in any exception thrown.</param>
        /// <exception cref="ArgumentException">The settings are invalid.</exception>
        public RetrySettings Validate(string paramName)
        {
            GaxPreconditions.CheckArgument(RetryBackoff != null, paramName, "No retry backoff specified");
            GaxPreconditions.CheckArgument(TimeoutBackoff != null, paramName, "No timeout backoff specified");
            GaxPreconditions.CheckArgument(DelayJitter != null, paramName, "No delay jitter specified");
            GaxPreconditions.CheckArgument(RetryFilter != null, paramName, "No retry filter specified");
            return this;
        }

        /// <summary>
        /// Provides a mechanism for applying jitter to delays between retries.
        /// See the <see cref="DelayJitter"/> property for more information.
        /// </summary>
        public interface IJitter
        {
            /// <summary>
            /// Returns the actual delay to use given a maximum available delay.
            /// </summary>
            /// <param name="maxDelay">The maximum delay provided by the backoff settings</param>
            /// <returns>The delay to use before retrying.</returns>
            TimeSpan GetDelay(TimeSpan maxDelay);
        }

        /// <summary>
        /// The default jitter which returns a uniformly distributed random delay between 0 and
        /// the specified maximum.
        /// </summary>
        public static IJitter RandomJitter { get; } = new RandomJitterImpl();

        /// <summary>
        /// A jitter which simply returns the specified maximum delay.
        /// </summary>
        public static IJitter NoJitter { get; } = new NoJitterImpl();

        // TODO: Is this a reasonable default? Does it make sense to have a default at all?

        /// <summary>
        /// The default retry filter, which retries operations which fail due to a status code of "not found".
        /// </summary>
        public static Predicate<RpcException> DefaultFilter { get; } = FilterForStatusCodes(StatusCode.NotFound);

        /// <summary>
        /// Creates a retry filter based on status codes.
        /// </summary>
        /// <param name="statusCodes">The status codes to retry. Must not be null.</param>
        /// <returns>A retry filter based on status codes.</returns>
        public static Predicate<RpcException> FilterForStatusCodes(params StatusCode[] statusCodes) =>
            FilterForStatusCodes((IEnumerable<StatusCode>) statusCodes);

        /// <summary>
        /// Creates a retry filter based on status codes.
        /// </summary>
        /// <param name="statusCodes">The status codes to retry. Must not be null.</param>
        /// <returns>A retry filter based on status codes.</returns>
        public static Predicate<RpcException> FilterForStatusCodes(IEnumerable<StatusCode> statusCodes)
        {
            GaxPreconditions.CheckNotNull(statusCodes, nameof(statusCodes));
            // TODO: Take a copy? Optimize for common cases?
            return ex => statusCodes.Contains(ex.Status.StatusCode);
        }

        private sealed class RandomJitterImpl : IJitter
        {
            // We might want to move this code to a more general place, if we need multi-threaded randomness elsewhere.
            private static int seed = Environment.TickCount;

            private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
                new Random(Interlocked.Increment(ref seed))
            );

            public TimeSpan GetDelay(TimeSpan maxDelay)
            {
                var random = randomWrapper.Value;
                return maxDelay.Ticks <= 0 ? maxDelay : new TimeSpan((long) (random.NextDouble() * maxDelay.Ticks));
            }
        }

        private sealed class NoJitterImpl : IJitter
        {
            public TimeSpan GetDelay(TimeSpan maxDelay) => maxDelay;
        }
    }
}
