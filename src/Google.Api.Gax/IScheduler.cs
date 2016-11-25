/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Abstraction of scheduler-like operations, used for testability.
    /// </summary>
    /// <remarks>
    /// Note that this is different to <see cref="TaskScheduler"/>, which is really involved
    /// with assigning tasks to threads rather than any sort of delay.
    /// </remarks>
    public interface IScheduler
    {
        /// <summary>
        /// Returns a task which will complete after the given delay. Whether the returned
        /// awaitable is configured to capture the current context or not is implementation-specific.
        /// (A test implementation may capture the current context to enable reliable testing.)
        /// </summary>
        /// <param name="delay">Time to delay for. Must not be negative.</param>
        /// <param name="cancellationToken">The cancellation token that will be checked prior to completing the returned task.</param>
        /// <returns>A task which will complete after the given delay.</returns>
        Task Delay(TimeSpan delay, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Extension methods for <see cref="IScheduler"/>.
    /// </summary>
    public static class SchedulerExtensions
    {
        /// <summary>
        /// Simulates a synchronous delay by calling <see cref="IScheduler.Delay(TimeSpan, CancellationToken)"/> on
        /// <paramref name="scheduler"/>, and unwrapping any exceptions generated (typically cancellation).
        /// </summary>
        /// <param name="scheduler">The scheduler to use for the sleep operation.</param>
        /// <param name="delay">Time to sleep for. Must not be negative.</param>
        /// <param name="cancellationToken">The cancellation token that will be watched during the sleep operation.</param>
        /// <exception cref="OperationCanceledException">The cancellation token was cancelled during the sleep.</exception>
        public static void Sleep(this IScheduler scheduler, TimeSpan delay, CancellationToken cancellationToken)
            => GaxPreconditions.CheckNotNull(scheduler, nameof(scheduler))
                .Delay(delay, cancellationToken)
                .WaitWithUnwrappedExceptions();
    }
}
