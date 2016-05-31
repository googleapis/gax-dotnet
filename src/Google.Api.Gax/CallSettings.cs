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
        public CallSettings() { }

        internal CallSettings(CallSettings other)
        {
            if (other != null)
            {
                Headers = other.Headers?.Clone();
                CancellationToken = other.CancellationToken;
                WriteOptions = other.WriteOptions;
                PropagationToken = other.PropagationToken;
                Credentials = other.Credentials;
                Timing = other.Timing?.Clone();
            }
        }
        /// <summary>
        /// Headers to send at the beginning of the call.
        /// </summary>
        //public Metadata Headers
        public Metadata Headers { get; set; }

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
        /// <see cref="CallTiming"/> to use, or null for default retry/expiration behavior.
        /// </summary>
        /// <remarks>
        /// Allows selecting between retry and simple expiration.
        /// </remarks>
        public CallTiming Timing { get; set; }

        /// <summary>
        /// Creates a clone of this object, with all the same property values.
        /// </summary>
        /// <returns>A clone of these <see cref="CallSettings"/>.</returns>
        /// <remarks>
        /// The <see cref="Headers"/> are deep-cloned, so changes to the original Headers
        /// will not affect the cloned Headers.
        /// </remarks>
        public CallSettings Clone() => new CallSettings(this);

        /// <summary>
        /// Merge the specified <see cref="CallSettings"/> into this.
        /// </summary>
        /// <param name="other">The <see cref="CallSettings"/> to merge into this.</param>
        /// <returns>This, with the other <see cref="CallSettings"/>merged.</returns>
        /// <remarks>
        /// This is mutated. The other <see cref="CallSettings"/> is not mutated.
        /// </remarks>
        internal CallSettings Merge(CallSettings other)
        {
            if (other == null)
            {
                return this;
            }
            // Should a merge of Headers be additive, instead of overridding?
            // If additive, how to remove headers during an override?
            Headers = other.Headers ?? Headers;
            CancellationToken = other.CancellationToken ?? CancellationToken;
            WriteOptions = other.WriteOptions ?? WriteOptions;
            PropagationToken = other.PropagationToken ?? PropagationToken;
            Credentials = other.Credentials ?? Credentials;
            Timing = other.Timing ?? Timing;
            return this;
        }

        /// <summary>
        /// Transfers settings contained in this into a <see cref="CallOptions"/>.
        /// </summary>
        /// <param name="clock">The clock to use for deadline calculation.</param>
        /// <returns>A <see cref="CallOptions"/> configured from this <see cref="CallSettings"/>.</returns>
        internal CallOptions ToCallOptions(IClock clock) => new CallOptions(
            headers: Headers,
            deadline: Timing.CalculateDeadline(clock),
            cancellationToken: CancellationToken ?? default(CancellationToken),
            writeOptions: WriteOptions,
            propagationToken: PropagationToken,
            credentials: Credentials);

        /// <summary>
        /// Adds the specified user agent to <see cref="Metadata"/> <see cref="Headers"/>.
        /// Will instantiate a <see cref="Metadata"/> object if required.
        /// </summary>
        /// <param name="userAgent">The user agent string to add to headers.</param>
        /// <returns>This</returns>
        internal CallSettings AddUserAgent(string userAgent)
        {
            if (Headers == null)
            {
                Headers = new Metadata();
            }
            Headers.Add(UserAgentBuilder.HeaderName, userAgent);
            return this;
        }
    }
}
