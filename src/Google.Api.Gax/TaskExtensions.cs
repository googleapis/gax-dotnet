/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Extension methods for tasks.
    /// </summary>
    internal static class TaskExtensions
    {
        /// <summary>
        /// Synchronously waits for the given task to complete, and returns the result.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <typeparam name="T">The result type of the task</typeparam>
        /// <param name="task">The task to wait for.</param>
        /// <returns>The result of the completed task.</returns>
        internal static T ResultWithUnwrappedExceptions<T>(this Task<T> task)
        {
            task.WaitWithUnwrappedExceptions();
            return task.Result;
        }

        /// <summary>
        /// Synchronously waits for the given task to complete.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <param name="task">The task to wait for.</param>
        internal static void WaitWithUnwrappedExceptions(this Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exceptions,
                // but let's handle it relatively gracefully.
                throw e.InnerExceptions.FirstOrDefault() ?? e;
            }

        }
    }
}
