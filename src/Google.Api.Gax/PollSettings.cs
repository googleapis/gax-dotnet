/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings controlling repeated polling, for example when waiting for a long-running operation
    /// to complete.
    /// </summary>
    public sealed class PollSettings
    {
        /// <summary>
        /// How long to wait before giving up. This is never null.
        /// </summary>
        public Expiration Expiration { get; }

        /// <summary>
        /// The delay between RPC calls when fetching the operation status. This is never negative.
        /// There is no exponential backoff between calls; the same delay is used for each call.
        /// </summary>
        /// <remarks>
        /// This is the delay between the a successful RPC response being received
        /// and the next RPC request being sent.
        /// </remarks>
        public TimeSpan Delay { get; }
        
        /// <summary>
        /// Creates poll settings from the given expiration, delay and call settings.
        /// </summary>
        /// <param name="expiration">The expiration to use in order to know when to stop polling. Must not be null.</param>
        /// <param name="delay">The delay between RPC calls. Must be non-negative.</param>
        public PollSettings(Expiration expiration, TimeSpan delay)
        {
            Expiration = GaxPreconditions.CheckNotNull(expiration, nameof(expiration));
            Delay = GaxPreconditions.CheckNonNegativeDelay(delay, nameof(delay));
        }
    }
}
