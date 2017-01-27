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

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings for retrying RPCs.
    /// </summary>
    public sealed class RetrySettings
    {
        /// <summary>
        /// The backoff policy for the time between retries. This is never null.
        /// </summary>
        public BackoffSettings RetryBackoff { get; }

        /// <summary>
        /// The backoff policy for timeouts of retries. This is never null.
        /// </summary>
        /// <remarks>
        /// This allows an increasing timeout, initially requesting a fast call,
        /// then allowing a bit more time, then a bit more, and so on. However,
        /// the timeout will also be adjusted to accommodate <see cref="TotalExpiration"/>.
        /// </remarks>
        public BackoffSettings TimeoutBackoff { get; }

        /// <summary>
        /// The total expiration, across all retries. This is never null.
        /// </summary>
        public Expiration TotalExpiration { get; }

        /// <summary>
        /// A predicate to determine whether or not a particular exception should cause the operation to be retried.
        /// Usually this is simply a matter of checking the status codes.
        /// </summary>
        public Predicate<RpcException> RetryFilter { get; }

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
        public IJitter DelayJitter { get; }

        /// <summary>
        /// Constructs an instance with the given backoff configuration, the default RPC filter and
        /// jitter.
        /// </summary>
        /// <param name="retryBackoff">The backoff policy for the time between retries. Must not be null.</param>
        /// <param name="timeoutBackoff">The backoff policy for timeouts of retries. Must not be null.</param>
        /// <param name="totalExpiration">The total expiration, across all retries. Must not be null.</param>
        public RetrySettings(
            BackoffSettings retryBackoff,
            BackoffSettings timeoutBackoff,
            Expiration totalExpiration) : this(retryBackoff, timeoutBackoff, totalExpiration, null, null)
        {
        }

        /// <summary>
        /// Constructs an instance with the given configuration, and the default jitter.
        /// </summary>
        /// <param name="retryBackoff">The backoff policy for the time between retries. Must not be null.</param>
        /// <param name="timeoutBackoff">The backoff policy for timeouts of retries. Must not be null.</param>
        /// <param name="totalExpiration">The total expiration, across all retries. Must not be null.</param>
        /// <param name="retryFilter">A predicate to determine whether or not a particular exception should cause the operation to be retried,
        /// or null for the default filter.</param>
        public RetrySettings(
            BackoffSettings retryBackoff,
            BackoffSettings timeoutBackoff,
            Expiration totalExpiration,
            Predicate<RpcException> retryFilter) : this(retryBackoff, timeoutBackoff, totalExpiration, retryFilter, null)
        {
        }

        /// <summary>
        /// Constructs an instance with the given configuration.
        /// </summary>
        /// <param name="retryBackoff">The backoff policy for the time between retries. Must not be null.</param>
        /// <param name="timeoutBackoff">The backoff policy for timeouts of retries. Must not be null.</param>
        /// <param name="totalExpiration">The total expiration, across all retries. Must not be null.</param>
        /// <param name="retryFilter">A predicate to determine whether or not a particular exception should cause the operation to be retried,
        /// or null for the default filter.</param>
        /// <param name="delayJitter">The delay jitter to apply for delays, or null for the defautl (random) jitter.</param>
        public RetrySettings(
            BackoffSettings retryBackoff,
            BackoffSettings timeoutBackoff,
            Expiration totalExpiration,
            Predicate<RpcException> retryFilter,
            IJitter delayJitter)
        {
            RetryBackoff = GaxPreconditions.CheckNotNull(retryBackoff, nameof(retryBackoff));
            TimeoutBackoff = GaxPreconditions.CheckNotNull(timeoutBackoff, nameof(timeoutBackoff));
            TotalExpiration = GaxPreconditions.CheckNotNull(totalExpiration, nameof(totalExpiration));
            RetryFilter = retryFilter ?? DefaultFilter;
            DelayJitter = delayJitter ?? RandomJitter;
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

        /// <summary>
        /// Builds a new RetrySettings which is identical to this one, but with the given expiration.
        /// </summary>
        /// <param name="expiration">New expiration</param>
        internal RetrySettings WithTotalExpiration(Expiration expiration) =>
            new RetrySettings(RetryBackoff, TimeoutBackoff, expiration, RetryFilter, DelayJitter);

        private sealed class RandomJitterImpl : IJitter
        {
            private readonly object _lock = new object();

            // See http://stackoverflow.com/questions/36376888 for why we don't have a thread-local RNG.
            // We only ever create one instance of RandomJitterImpl, so it doesn't really matter
            // whether this is an instance variable or static; we'll only have a single Random instance.
            private readonly Random _random = new Random();

            public TimeSpan GetDelay(TimeSpan maxDelay)
            {
                if (maxDelay <= TimeSpan.Zero)
                {
                    return maxDelay;
                }
                lock (_lock)
                {
                    return new TimeSpan((long)(_random.NextDouble() * maxDelay.Ticks));
                }                
            }
        }

        private sealed class NoJitterImpl : IJitter
        {
            public TimeSpan GetDelay(TimeSpan maxDelay) => maxDelay;
        }
    }
}
