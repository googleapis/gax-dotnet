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
    /// Singleton implementation of <see cref="IScheduler"/> which uses <see cref="Task.Delay(TimeSpan, CancellationToken)"/>.
    /// </summary>
    public sealed class SystemScheduler : IScheduler
    {
        /// <summary>
        /// Retrieves the singleton instance.
        /// </summary>
        public static SystemScheduler Instance { get; } = new SystemScheduler();

        private SystemScheduler() {}

        /// <inheritdoc />
        public Task Delay(TimeSpan timeSpan, CancellationToken cancellationToken) => Task.Delay(timeSpan, cancellationToken);
    }
}
