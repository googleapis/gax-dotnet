/*
 * Copyright 2018 Google LLC. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Extension methods for <see cref="TaskCompletionSource{TResult}"/>.
    /// </summary>
    public static class TaskCompletionSourceExtensions
    {
        /// <summary>
        /// Returns a task from a task completion source, but observing a given cancellation token.
        /// </summary>
        /// <typeparam name="TResult">The result type of the task completion source</typeparam>
        /// <param name="source">The task completion source. Must not be null.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        /// <returns>A task that will complete when <paramref name="source"/> completes, but
        /// will observe <paramref name="cancellationToken"/> for cancellation.</returns>
        public static Task<TResult> WithCancellationToken<TResult>(this TaskCompletionSource<TResult> source, CancellationToken cancellationToken)
        {
            GaxPreconditions.CheckNotNull(source, nameof(source));
            if (!cancellationToken.CanBeCanceled)
            {
                return source.Task;
            }
            return Wait();

            async Task<TResult> Wait()
            {
                using (cancellationToken.Register(() => source.TrySetCanceled()))
                {
                    return await source.Task.ConfigureAwait(false);
                }
            }
        }
    }
}
