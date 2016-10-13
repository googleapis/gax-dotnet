/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings controlling repeated polling, for example when waiting for a long-running operation
    /// to complete.
    /// </summary>
    public sealed class PollSettings
    {
        /// <summary>
        /// Settings to override the default call settings when polling, if any.
        /// </summary>
        public CallSettings CallSettings { get; set; }

        /// <summary>
        /// How long to wait before giving up. This may be null, which is equivalent to <see cref="Expiration.None"/>
        /// to indicate that the call should never give up unless the RPCs fail.
        /// </summary>
        public Expiration Expiration { get; set; }

        private TimeSpan _delay;
        /// <summary>
        /// The delay between RPC calls when fetching the operation status. This cannot be negative. There is no exponential
        /// backoff between calls; the same delay is used for each call.
        /// </summary>
        /// <remarks>
        /// This is the delay between the a successful RPC response being received
        /// and the next RPC request being sent.
        /// </remarks>
        public TimeSpan Delay
        {
            get { return _delay; }
            set
            {
                _delay = GaxPreconditions.CheckNonNegativeDelay(value, nameof(value));
            }
        }

        /// <summary>
        /// Returns a deep clone of this object.
        /// </summary>
        /// <returns>A deep clone of this object.</returns>
        public PollSettings Clone() => new PollSettings(Expiration, Delay, CallSettings?.Clone());

        /// <summary>
        /// Creates poll settings from the given expiration, delay and call settings.
        /// </summary>
        /// <param name="expiration">The expiration to use in order to know when to stop polling. Must not be null.</param>
        /// <param name="delay">The delay between RPC calls. Must be non-negative.</param>
        /// <param name="callSettings">The call settings to override the defaults for the call.
        /// May be null, in which case no settings are overridden.</param>
        public PollSettings(Expiration expiration, TimeSpan delay, CallSettings callSettings = null)
        {
            Expiration = expiration;
            // Check separately to make sure we get the right name in the exception.
            Delay = GaxPreconditions.CheckNonNegativeDelay(delay, nameof(delay));
            CallSettings = callSettings;
        }
    }
}
