/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings to determine how an RPC operates. This type is immutable.
    /// </summary>
    public sealed class CallSettings
    {
        /// <summary>
        /// Constructs an instance with the specified settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token that can be used for cancelling the call.</param>
        /// <param name="credentials">Credentials to use for the call.</param>
        /// <param name="timing"><see cref="CallTiming"/> to use, or null for default retry/expiration behavior.</param>
        /// <param name="headers">Headers to send at the beginning of the call.</param>
        /// <param name="writeOptions"><see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.</param>
        /// <param name="propagationToken"><see cref="ContextPropagationToken"/> for propagating settings from a parent call.</param>
        public CallSettings(
            CancellationToken? cancellationToken,
            CallCredentials credentials,
            CallTiming timing,
            Metadata headers,
            WriteOptions writeOptions,
            ContextPropagationToken propagationToken)
        {
            CancellationToken = cancellationToken;
            Credentials = credentials;
            Timing = timing;
            Headers = headers;
            WriteOptions = writeOptions;
            PropagationToken = propagationToken;
        }

        // TODO: Modify this to be an Action<Metadata>, for flexibility and immutability.

        /// <summary>
        /// Headers to send at the beginning of the call.
        /// </summary>
        public Metadata Headers { get; }

        /// <summary>
        /// Cancellation token that can be used for cancelling the call.
        /// </summary>
        public CancellationToken? CancellationToken { get; }

        /// <summary>
        /// <see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.
        /// </summary>
        public WriteOptions WriteOptions { get; }

        /// <summary>
        /// <see cref="ContextPropagationToken"/> for propagating settings from a parent call.
        /// </summary>
        public ContextPropagationToken PropagationToken { get; }

        /// <summary>
        /// Credentials to use for the call.
        /// </summary>
        public CallCredentials Credentials { get; }

        /// <summary>
        /// <see cref="CallTiming"/> to use, or null for default retry/expiration behavior.
        /// </summary>
        /// <remarks>
        /// Allows selecting between retry and simple expiration.
        /// </remarks>
        public CallTiming Timing { get; }

        // TODO: Expose this?

        /// <summary>
        /// Merges the settings in <paramref name="overlaid"/> with those in
        /// <paramref name="original"/>, with <paramref name="overlaid"/> taking priority.
        /// If both arguments are null, the result is null. If one argument is null,
        /// the other argument is returned. Otherwise, a new object is created with a property-wise
        /// overlay.
        /// </summary>
        /// <param name="original">Original settings. May be null.</param>
        /// <param name="overlaid">Settings to overlay. May be null.</param>
        /// <returns>A merged set of call settings.</returns>
        internal static CallSettings Merge(CallSettings original, CallSettings overlaid)
        {
            if (original == null)
            {
                return overlaid;
            }
            if (overlaid == null)
            {
                return original;
            }
            return new CallSettings(
                overlaid.CancellationToken ?? original.CancellationToken,
                overlaid.Credentials ?? original.Credentials,
                overlaid.Timing ?? original.Timing,
                overlaid.Headers ?? original.Headers,
                overlaid.WriteOptions ?? original.WriteOptions,
                overlaid.PropagationToken ?? original.PropagationToken);
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
        /// Creates a <see cref="CallSettings"/> for the specified user agent.
        /// </summary>
        internal static CallSettings ForUserAgent(string userAgent) =>
            new CallSettings(null, null, null, new Metadata { { UserAgentBuilder.HeaderName, userAgent } }, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the new settings.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromCancellationToken(CancellationToken cancellationToken) =>
            new CallSettings(cancellationToken, null, null, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified call credentials.
        /// </summary>
        /// <param name="credentials">The call credentials for the new settings.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromCallCredentials(CallCredentials credentials) =>
            new CallSettings(null, credentials, null, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified call timing.
        /// </summary>
        /// <param name="timing">The call timing for the new settings.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromCallTiming(CallTiming timing) =>
            new CallSettings(null, null, timing, null, null, null);
        
    }
}
