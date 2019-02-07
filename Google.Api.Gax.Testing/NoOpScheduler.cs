/*
 * Copyright 2019 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Testing
{
    /// <summary>
    /// An implementation of <see cref="IScheduler"/> that doesn't actually delay. This is useful for tests
    /// which aren't interested in precise timing, but just want to be able to use a scheduler.
    /// For more fine-grained control, use <see cref="FakeScheduler"/>.
    /// </summary>
    public sealed class NoOpScheduler : IScheduler
    {
        /// <summary>
        /// Returns a task that will complete "nearly immediately": there's no set delay, but the task
        /// yields before completing, avoiding synchronous execution leading to subtle bugs. The cancellation
        /// token passed in is observed, causing an exception if it's already canceled.
        /// </summary>
        /// <param name="delay">The theoretical delay, ignored by this implementation.</param>
        /// <param name="cancellationToken">A cancellation token which is checked in the returned task.</param>
        /// <returns>A task that will complete immediately after yielding.</returns>
        public async Task Delay(TimeSpan delay, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Yield();
        }
    }
}
