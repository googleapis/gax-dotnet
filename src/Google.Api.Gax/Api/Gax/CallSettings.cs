/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System.Threading;

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings to determine how an RPC operates.
    /// </summary>
    public sealed class CallSettings
    {
        /// <summary>
        /// Headers to send at the beginning of the call.
        /// </summary>
        //public Metadata Headers
        public Metadata Headers { get; set; }

        /// <summary>
        /// Call expiration.
        /// </summary>
        public Expiration Expiration { get; set; }

        /// <summary>
        /// Cancellation token that can be used for cancelling the call.
        /// </summary>
        public CancellationToken? CancellationToken { get; set; }

        /// <summary>
        /// <see cref="Grpc.Core.WriteOptions"/> that will be used for the call.
        /// </summary>
        public WriteOptions WriteOptions { get; set; }

        /// <summary>
        /// <see cref="Grpc.Core.ContextPropagationToken"/> for propagating settings from a parent call.
        /// </summary>
        public ContextPropagationToken PropagationToken { get; set; }

        /// <summary>
        /// Credentials to use for the call.
        /// </summary>
        public CallCredentials Credentials { get; set; }

        /// <summary>
        /// Creates a clone of this object, with all the same property values.
        /// </summary>
        /// <returns>A clone of these <see cref="CallSettings"/>.</returns>
        /// <remarks>
        /// The <see cref="Headers"/> are deep-cloned, so changes to the original Headers
        /// will not affect the cloned Headers.
        /// </remarks>
        public CallSettings Clone() => new CallSettings
        {
            Headers = Headers?.Clone(),
            Expiration = Expiration,
            CancellationToken = CancellationToken,
            WriteOptions = WriteOptions,
            PropagationToken = PropagationToken,
            Credentials = Credentials,
        };
    }
}
