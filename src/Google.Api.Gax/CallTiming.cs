using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// The type of <see cref="CallTiming"/>; retry or expiration (no retry).
    /// </summary>
    public enum CallTimingType
    {
        /// <summary>
        /// Call uses retry, specified with a <see cref="RetrySettings"/>.
        /// </summary>
        Retry,

        /// <summary>
        /// Call does not use retry; call expiration is specified with an <see cref="Google.Api.Gax.Expiration"/> .
        /// </summary>
        Expiration,
    }

    /// <summary>
    /// An RPC simple expiration; or retry settings.
    /// </summary>
    public sealed class CallTiming
    {
        /// <summary>
        /// Create a <see cref="CallTiming"/> with retry.
        /// </summary>
        /// <param name="retry">The <see cref="RetrySettings"/> for a call.</param>
        /// <returns>A <see cref="CallTiming"/> with the specified retry settings.</returns>
        public static CallTiming FromRetry(RetrySettings retry) =>
            new CallTiming(GaxPreconditions.CheckNotNull(retry, nameof(retry)).Validate(nameof(retry)), null);

        /// <summary>
        /// Create a <see cref="CallTiming"/> with a simple expiration; no retry.
        /// </summary>
        /// <param name="expiration">The <see cref="Google.Api.Gax.Expiration"/> for a call without retry.</param>
        /// <returns>A <see cref="CallTiming"/> with the specified expiration; without retry.</returns>
        public static CallTiming FromExpiration(Expiration expiration) =>
            new CallTiming(null, GaxPreconditions.CheckNotNull(expiration, nameof(expiration)));

        /// <summary>
        /// Create a <see cref="CallTiming"/> with a simple timeout; no retry.
        /// </summary>
        /// <param name="timeout">The relative timeout for a call without retry.</param>
        /// <returns>A <see cref="CallTiming"/> with the specified timeout; without retry.</returns>
        public static CallTiming FromTimeout(TimeSpan timeout) =>
            FromExpiration(Expiration.FromTimeout(timeout));

        /// <summary>
        /// Create a <see cref="CallTiming"/> with a simple deadline; no retry.
        /// </summary>
        /// <param name="deadline">The absolute deadline for a call without retry.</param>
        /// <returns>A <see cref="CallTiming"/> with the specified deadline; without retry.</returns>
        public static CallTiming FromDeadline(DateTime deadline) =>
            FromExpiration(Expiration.FromDeadline(deadline));

        private CallTiming(RetrySettings retry, Expiration expiration)
        {
            Retry = retry;
            Expiration = expiration;
        }

        /// <summary>
        /// If not null, the <see cref="RetrySettings"/> specifying how retry is performed
        /// for this call.
        /// </summary>
        public RetrySettings Retry { get; }

        /// <summary>
        /// If not null, the <see cref="Expiration"/> specifying when this call expires
        /// (with no retry).
        /// </summary>
        public Expiration Expiration { get; }

        /// <summary>
        /// What <see cref="CallTimingType"/> is contained in this <see cref="CallTiming"/>.
        /// </summary>
        public CallTimingType Type =>
            Retry != null ? CallTimingType.Retry : CallTimingType.Expiration;

        public CallTiming Clone() => new CallTiming(Retry?.Clone(), Expiration);
    }

    internal static class CallTimingExtensions
    {
        /// <summary>
        /// Calculate a deadline from a <see cref="CallTiming"/> and a <see cref="IClock"/>.
        /// </summary>
        /// <param name="callTiming"><see cref="CallTiming"/>, may be null.</param>
        /// <param name="clock"><see cref="IClock"/> to use for deadline calculation.</param>
        /// <returns>The calculated absolute deadline, or null is no deadline should be used.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="callTiming"/> uses retry. Only a simple expiration is valid
        /// for calculating a deadline.
        /// </exception>
        internal static DateTime? CalculateDeadline(this CallTiming callTiming, IClock clock)
        {
            if (callTiming == null)
            {
                return null;
            }
            if (callTiming.Type != CallTimingType.Expiration)
            {
                throw new InvalidOperationException("Cannot calculate deadline from retry.");
            }
            return callTiming.Expiration.CalculateDeadline(clock);
        }
    }
}
