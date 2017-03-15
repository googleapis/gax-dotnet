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
        /// <para>
        /// This is the delay between the a successful RPC response being received
        /// and the next RPC request being sent.
        /// </para>
        /// <para>
        /// This is named 'InitialDelay' as backoff properties will be added to this class later.
        /// </para>
        /// </remarks>
        public TimeSpan InitialDelay { get; }
        
        // TODO: Add properties defining backoff.

        /// <summary>
        /// Creates poll settings from the given expiration and delay, with no backoff.
        /// </summary>
        /// <param name="expiration">The expiration to use in order to know when to stop polling. Must not be null.</param>
        /// <param name="delay">The delay between RPC calls. Must be non-negative.</param>
        public PollSettings(Expiration expiration, TimeSpan delay)
        {
            Expiration = GaxPreconditions.CheckNotNull(expiration, nameof(expiration));
            InitialDelay = GaxPreconditions.CheckNonNegativeDelay(delay, nameof(delay));
        }
    }
}
