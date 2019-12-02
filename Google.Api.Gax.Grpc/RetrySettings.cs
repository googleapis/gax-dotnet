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
        /// The maximum number of attempts to make. Always greater than or equal to 1.
        /// </summary>
        public int MaxAttempts { get; }

        /// <summary>
        /// The backoff time between the first attempt and the first retry. Always non-negative.
        /// </summary>
        public TimeSpan InitialBackoff { get; }
        
        /// <summary>
        /// The maximum backoff time between retries. Always non-negative.
        /// </summary>
        public TimeSpan MaxBackoff { get; }

        /// <summary>
        /// The multiplier to apply to the backoff on each iteration; always greater than or equal to 1.0.
        /// </summary>
        /// <remarks>
        /// <para>
        /// As an example, a multiplier of 2.0 with an initial backoff of 0.1s on an RPC would then apply
        /// a backoff of 0.2s, then 0.4s until it is capped by <see cref="MaxBackoff"/>.
        /// </para>
        /// </remarks>
        public double BackoffMultiplier { get; }

        /// <summary>
        /// A predicate to determine whether or not a particular exception should cause the operation to be retried.
        /// Usually this is simply a matter of checking the status codes. This is never null.
        /// </summary>
        public Predicate<RpcException> RetryFilter { get; }

        /// <summary>
        /// The delay jitter to apply for delays, defaulting to <see cref="RandomJitter"/>. This is never null.
        /// </summary>
        /// <remarks>
        /// "Jitter" is used to introduce randomness into the pattern of delays. This is to avoid multiple
        /// clients performing the same delay pattern starting at the same point in time,
        /// leading to higher-than-necessary contention. The default jitter simply takes each maximum delay
        /// and returns an actual delay which is a uniformly random value between 0 and the maximum. This
        /// is good enough for most applications, but makes precise testing difficult.
        /// </remarks>
        public IJitter BackoffJitter { get; }

        /// <summary>
        /// Creates a new instance with the given settings.
        /// </summary>
        /// <param name="maxAttempts">The maximum number of attempts to make. Must be positive.</param>
        /// <param name="initialBackoff">The backoff after the initial failure. Must be non-negative.</param>
        /// <param name="maxBackoff">The maximum backoff. Must be at least <paramref name="initialBackoff"/>.</param>
        /// <param name="backoffMultiplier">The multiplier to apply to backoff times. Must be at least 1.0.</param>
        /// <param name="retryFilter">The predicate to use to check whether an error should be retried. Must not be null.</param>
        /// <param name="backoffJitter">The jitter to use on each backoff. Must not be null.</param>
        internal RetrySettings(
            int maxAttempts,
            TimeSpan initialBackoff,
            TimeSpan maxBackoff,
            double backoffMultiplier,
            Predicate<RpcException> retryFilter,
            IJitter backoffJitter)
        {
            MaxAttempts = GaxPreconditions.CheckArgumentRange(maxAttempts, nameof(maxAttempts), 1, int.MaxValue);
            InitialBackoff = GaxPreconditions.CheckNonNegativeDelay(initialBackoff, nameof(initialBackoff));
            MaxBackoff = GaxPreconditions.CheckNonNegativeDelay(maxBackoff, nameof(maxBackoff));
            GaxPreconditions.CheckArgument(maxBackoff >= initialBackoff, nameof(maxBackoff), "Maximum backoff must be at least as large as initial backoff");
            BackoffMultiplier = GaxPreconditions.CheckArgumentRange(backoffMultiplier, nameof(backoffMultiplier), 1.0, double.MaxValue);
            RetryFilter = GaxPreconditions.CheckNotNull(retryFilter, nameof(retryFilter));
            BackoffJitter = GaxPreconditions.CheckNotNull(backoffJitter, nameof(backoffJitter));
        }

        /// <summary>
        /// Returns a <see cref="RetrySettings"/> using the specified maximum number of attempts and a constant backoff.
        /// Jitter is still applied to each backoff, but the "base" value of the backoff is always <paramref name="backoff"/>.
        /// </summary>
        /// <param name="maxAttempts">The maximum number of attempts to make. Must be positive.</param>
        /// <param name="backoff">The backoff after each failure. Must be non-negative.</param>
        /// <param name="retryFilter">The predicate to use to check whether an error should be retried. Must not be null.</param>
        /// <param name="backoffJitter">The jitter to use on each backoff. May be null, in which case <see cref="RandomJitter"/> is used.</param>
        /// <returns>A retry with constant backoff.</returns>
        public static RetrySettings FromConstantBackoff(int maxAttempts, TimeSpan backoff, Predicate<RpcException> retryFilter, IJitter backoffJitter = null) =>
            new RetrySettings(maxAttempts, backoff, backoff, 1.0, retryFilter, backoffJitter ?? RandomJitter);

        /// <summary>
        /// Returns a <see cref="RetrySettings"/> using the specified maximum number of attempts and an exponential backoff.
        /// </summary>
        /// <param name="maxAttempts">The maximum number of attempts to make. Must be positive.</param>
        /// <param name="initialBackoff">The backoff after the initial failure. Must be non-negative.</param>
        /// <param name="maxBackoff">The maximum backoff. Must be at least <paramref name="initialBackoff"/>.</param>
        /// <param name="backoffMultiplier">The multiplier to apply to backoff times. Must be at least 1.0.</param>
        /// <param name="retryFilter">The predicate to use to check whether an error should be retried. Must not be null.</param>
        /// <param name="backoffJitter">The jitter to use on each backoff. May be null, in which case <see cref="RandomJitter"/> is used.</param>
        /// <returns>A retry with exponential backoff.</returns>
        public static RetrySettings FromExponentialBackoff(int maxAttempts,
            TimeSpan initialBackoff,
            TimeSpan maxBackoff,
            double backoffMultiplier,
            Predicate<RpcException> retryFilter,
            IJitter backoffJitter = null) => 
            new RetrySettings(maxAttempts, initialBackoff, maxBackoff, backoffMultiplier, retryFilter, backoffJitter ?? RandomJitter);

        /// <summary>
        /// Provides a mechanism for applying jitter to delays between retries.
        /// See the <see cref="BackoffJitter"/> property for more information.
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
        /// Works out the next backoff from the current one, based on the multiplier and maximum.
        /// This does not apply any jitter; the intention is that NextBackoff is applied to an unjittered sequence of
        /// values, but jitter is then applied to each one for actual delays.
        /// </summary>
        /// <param name="currentBackoff">The current backoff to use as a basis for the next one.</param>
        /// <returns>The next backoff to use, which is always at least <see cref="InitialBackoff"/> and at most <see cref="MaxBackoff"/>.</returns>
        internal TimeSpan NextBackoff(TimeSpan currentBackoff)
        {
            checked
            {
                TimeSpan next = new TimeSpan((long) (currentBackoff.Ticks * BackoffMultiplier));
                return
                    next < InitialBackoff ? InitialBackoff:        // Lower bound capping
                    next > MaxBackoff ? MaxBackoff:  // Upper bound capping
                    next;
            }
        }

        /// <summary>
        /// Returns a sequence of already-jittered backoffs. A caller can just iterate over this
        /// sequence and delay by each returned timespan. This sequence is infinite; callers do not
        /// need to test the result of MoveNext. (In particular, this sequence does *not* request MaxAttempts.)
        /// </summary>
        /// <param name="initialBackoffOverride">The initial backoff to apply, or null to use <see cref="InitialBackoff"/>;
        /// this can be used to retry immediately after an initial failure, or to start with a longer-than-normal backoff.</param>
        /// <returns>A sequence of jittered backoffs, suitable for delays.</returns>
        public IEnumerable<TimeSpan> GetJitteredBackoffSequence(TimeSpan? initialBackoffOverride = null)
        {
            TimeSpan unjittered = initialBackoffOverride ?? InitialBackoff;
            while (true)
            {
                yield return BackoffJitter.GetDelay(unjittered);
                unjittered = NextBackoff(unjittered);
            }
        }

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
