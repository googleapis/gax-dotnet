/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings to determine how an RPC operates. This type is immutable.
    /// </summary>
    public sealed class CallSettings
    {
        internal const string FieldMaskHeader = "x-goog-fieldmask";

        /// <summary>
        /// Constructs an instance with the specified settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token that can be used for cancelling the call.</param>
        /// <param name="credentials">Credentials to use for the call.</param>
        /// <param name="timing"><see cref="CallTiming"/> to use, or null for default retry/expiration behavior.</param>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <param name="writeOptions"><see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.</param>
        /// <param name="propagationToken"><see cref="ContextPropagationToken"/> for propagating settings from a parent call.</param>
        public CallSettings(
            CancellationToken? cancellationToken,
            CallCredentials credentials,
            CallTiming timing,
            Action<Metadata> headerMutation,
            WriteOptions writeOptions,
            ContextPropagationToken propagationToken)
        {
            CancellationToken = cancellationToken;
            Credentials = credentials;
            Timing = timing;
            HeaderMutation = headerMutation;
            WriteOptions = writeOptions;
            PropagationToken = propagationToken;
        }

        /// <summary>
        /// Delegate to mutate the metadata which will be sent at the start of the call,
        /// typically to add custom headers.
        /// </summary>
        public Action<Metadata> HeaderMutation { get; }

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

        /// <summary>
        /// Merges the settings in <paramref name="overlaid"/> with those in
        /// <paramref name="original"/>, with <paramref name="overlaid"/> taking priority.
        /// If both arguments are null, the result is null. If one argument is null,
        /// the other argument is returned. Otherwise, a new object is created with a property-wise
        /// overlay. Any header mutations are combined, however: the mutation from the original is
        /// performed, then the mutation in the overlay.
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
                // Combine mutations so that the overlaid mutation happens last; it can overwrite
                // anything that the previous mutation does.
                original.HeaderMutation + overlaid.HeaderMutation,
                overlaid.WriteOptions ?? original.WriteOptions,
                overlaid.PropagationToken ?? original.PropagationToken);
        }

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the new settings.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromCancellationToken(CancellationToken cancellationToken) =>
            new CallSettings(cancellationToken, null, null, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified call credentials, or returns null
        /// if <paramref name="credentials"/> is null.
        /// </summary>
        /// <param name="credentials">The call credentials for the new settings.</param>
        /// <returns>A new instance, or null if <paramref name="credentials"/> is null.</returns>
        public static CallSettings FromCallCredentials(CallCredentials credentials) =>
            credentials == null ? null : new CallSettings(null, credentials, null, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified call timing, or returns null
        /// if <paramref name="timing"/> is null.
        /// </summary>
        /// <param name="timing">The call timing for the new settings.</param>
        /// <returns>A new instance or null if <paramref name="timing"/> is null..</returns>
        public static CallSettings FromCallTiming(CallTiming timing) =>
            timing == null ? null : new CallSettings(null, null, timing, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified header mutation, or returns null
        /// if <paramref name="headerMutation"/> is null.
        /// </summary>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <returns>A new instance, or null if <paramref name="headerMutation"/> is null..</returns>
        public static CallSettings FromHeaderMutation(Action<Metadata> headerMutation) =>
            headerMutation == null ? null : new CallSettings(null, null, null, headerMutation, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified header name and value.
        /// </summary>
        /// <param name="name">The name of the header to add. Must not be null.</param>
        /// <param name="value">The value of the header to add. Must not be null.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromHeader(string name, string value)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            GaxPreconditions.CheckNotNull(value, nameof(value));
            return FromHeaderMutation(metadata => metadata.Add(name, value));
        }

        /// <summary>
        /// Creates a <see cref="CallSettings"/> that will include a field mask in the request, to
        /// limit which fields are returned in the response.
        /// </summary>
        /// <remarks>
        /// The precise effect on the request is not guaranteed: it may be through a header or a side-channel,
        /// for example. Likewise the effect of combining multiple settings containing field masks is not specified.
        /// </remarks>
        /// <param name="fieldMask">The field mask for the request. Must not be null.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromFieldMask(string fieldMask)
        {
            GaxPreconditions.CheckNotNull(fieldMask, nameof(fieldMask));
            return FromHeaderMutation(metadata => metadata.Add(FieldMaskHeader, fieldMask));
        }

        // TODO: Accept a Google.Protobuf.FieldMask when we're convinced it's useful and we know
        // exactly what to do with it.
    }
}
