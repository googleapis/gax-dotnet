/*
 * Copyright 2024 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc;

internal static class TaskExtensions
{
    // TODO: b/322527105
    // Note: this is duplicated in Google.Apis.Auth, Google.Apis.Core and Google.Api.Gax.Rest as well so it can stay internal.
    // Please change all implementations at the same time.
    /// <summary>
    /// Returns a task which can be cancelled by the given cancellation token, but otherwise observes the original
    /// task's state. This does *not* cancel any work that the original task was doing, and should be used carefully.
    /// </summary>
    internal static Task<T> WithCancellationToken<T>(this Task<T> task, CancellationToken cancellationToken)
    {
        if (!cancellationToken.CanBeCanceled)
        {
            return task;
        }

        return ImplAsync();

        // Separate async method to allow the above optimization to avoid creating any new state machines etc.
        async Task<T> ImplAsync()
        {
            var cts = new TaskCompletionSource<T>();
            using (cancellationToken.Register(() => cts.TrySetCanceled()))
            {
                var completedTask = await Task.WhenAny(task, cts.Task).ConfigureAwait(false);
                return await completedTask.ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Returns a task which can be cancelled by the given cancellation token, but otherwise observes the original
    /// task's state. This does *not* cancel any work that the original task was doing, and should be used carefully.
    /// </summary>
    internal static Task WithCancellationToken(this Task task, CancellationToken cancellationToken)
    {
        if (!cancellationToken.CanBeCanceled)
        {
            return task;
        }

        return ImplAsync();

        // Separate async method to allow the above optimization to avoid creating any new state machines etc.
        async Task ImplAsync()
        {
            var cts = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => cts.TrySetCanceled()))
            {
                var completedTask = await Task.WhenAny(task, cts.Task).ConfigureAwait(false);
                await completedTask.ConfigureAwait(false);
            }
        }
    }
}
