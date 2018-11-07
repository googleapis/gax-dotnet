/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Extension methods for tasks.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Synchronously waits for the given task to complete, and returns the result.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <typeparam name="T">The result type of the task</typeparam>
        /// <param name="task">The task to wait for.</param>
        /// <returns>The result of the completed task.</returns>
        public static T ResultWithUnwrappedExceptions<T>(this Task<T> task)
        {
            task.WaitWithUnwrappedExceptions();
            return task.Result;
        }

        /// <summary>
        /// Synchronously waits for the given task to complete.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <param name="task">The task to wait for.</param>
        public static void WaitWithUnwrappedExceptions(this Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exception,
                // but let's handle it relatively gracefully.
                // Using ExceptionDispatchInfo to keep the original exception stack trace.
                ExceptionDispatchInfo.Capture(e.InnerExceptions.FirstOrDefault() ?? e).Throw();
            }
        }

        /// <summary>
        /// Synchronously waits for the given task to complete.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <param name="task">The task to wait for.</param>
        /// <param name="timeout">A TimeSpan that represents the number of milliseconds to wait, or
        /// -1 milliseconds to wait indefinitely.</param>
        public static bool WaitWithUnwrappedExceptions(this Task task, TimeSpan timeout)
        {
            try
            {
                return task.Wait(timeout);
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exception,
                // but let's handle it relatively gracefully.
                // Using ExceptionDispatchInfo to keep the original exception stack trace.
                ExceptionDispatchInfo.Capture(e.InnerExceptions.FirstOrDefault() ?? e).Throw();
                throw new InvalidOperationException("Only present to keep the compiler happy");
            }
        }

        /// <summary>
        /// Synchronously waits for the given task to complete.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <param name="task">The task to wait for.</param>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait, or
        /// -1 to wait indefinitely.</param>
        public static bool WaitWithUnwrappedExceptions(this Task task, int millisecondsTimeout)
        {
            try
            {
                return task.Wait(millisecondsTimeout);
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exception,
                // but let's handle it relatively gracefully.
                // Using ExceptionDispatchInfo to keep the original exception stack trace.
                ExceptionDispatchInfo.Capture(e.InnerExceptions.FirstOrDefault() ?? e).Throw();
                throw new InvalidOperationException("Only present to keep the compiler happy");
            }
        }

        /// <summary>
        /// Synchronously waits for the given task to complete.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <param name="task">The task to wait for.</param>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait, or
        /// -1 to wait indefinitely.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete</param>
        public static bool WaitWithUnwrappedExceptions(this Task task, int millisecondsTimeout, CancellationToken cancellationToken)
        {
            try
            {
                return task.Wait(millisecondsTimeout, cancellationToken);
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exception,
                // but let's handle it relatively gracefully.
                // Using ExceptionDispatchInfo to keep the original exception stack trace.
                ExceptionDispatchInfo.Capture(e.InnerExceptions.FirstOrDefault() ?? e).Throw();
                throw new InvalidOperationException("Only present to keep the compiler happy");
            }
        }

        /// <summary>
        /// Synchronously waits for the given task to complete.
        /// Any <see cref="AggregateException"/> thrown is unwrapped to the first inner exception.
        /// </summary>
        /// <param name="task">The task to wait for.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete</param>
        public static void WaitWithUnwrappedExceptions(this Task task, CancellationToken cancellationToken)
        {
            try
            {
                task.Wait(cancellationToken);
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exception,
                // but let's handle it relatively gracefully.
                // Using ExceptionDispatchInfo to keep the original exception stack trace.
                ExceptionDispatchInfo.Capture(e.InnerExceptions.FirstOrDefault() ?? e).Throw();
            }
        }
    }
}
