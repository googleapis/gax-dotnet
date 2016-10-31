/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
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
        /// <returns>A task which will complete after the given delay.</returns>
        Task Delay(TimeSpan delay);

        /// <summary>
        /// Synchronously sleeps for the given delay.
        /// </summary>
        /// <param name="delay">Time to sleep for. Must not be negative.</param>
        void Sleep(TimeSpan delay);
    }
}
