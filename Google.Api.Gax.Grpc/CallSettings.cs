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
        internal const string RequestParamsHeader = "x-goog-request-params";
        internal const string RequestReasonHeader = "x-goog-request-reason";

        internal static CallSettings CancellationTokenNone { get; } = new CallSettings(default(CancellationToken), null, null, null, null, null);

        /// <summary>
        /// Constructs an instance with the specified settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token that can be used for cancelling the call.</param>
        /// <param name="expiration"><see cref="Expiration"/> to use, or null for default expiration behavior.</param>
        /// <param name="retry"><see cref="Retry"/> to use, or null for default retry behavior.</param>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <param name="writeOptions"><see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.</param>
        /// <param name="propagationToken"><see cref="ContextPropagationToken"/> for propagating settings from a parent call.</param>
        public CallSettings(
            CancellationToken? cancellationToken,
            Expiration expiration,
            RetrySettings retry,
            Action<Metadata> headerMutation,
            WriteOptions writeOptions,
            ContextPropagationToken propagationToken) : this(cancellationToken, expiration, retry, headerMutation, writeOptions, propagationToken, null, null)
        {
        }

        /// <summary>
        /// Obsolete.
        /// This is obsolete as it allows per-call credentials to be specified.
        /// Please use <see cref="CallSettings(System.Threading.CancellationToken?, Expiration, RetrySettings, Action{Metadata}, WriteOptions, ContextPropagationToken)"/>,
        /// and see https://github.com/googleapis/gax-dotnet/blob/main/docs/PER_CALL_CREDENTIAL.md for more information.
        /// Constructs an instance with the specified settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token that can be used for cancelling the call.</param>
        /// <param name="credentials">Credentials to use for the call.</param>
        /// <param name="expiration"><see cref="Expiration"/> to use, or null for default expiration behavior.</param>
        /// <param name="retry"><see cref="Retry"/> to use, or null for default retry behavior.</param>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <param name="writeOptions"><see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.</param>
        /// <param name="propagationToken"><see cref="ContextPropagationToken"/> for propagating settings from a parent call.</param>
        [Obsolete("This is obsolete as it allows per-call credentials to be specified. Please use an alternative overload and see https://github.com/googleapis/gax-dotnet/blob/main/docs/PER_CALL_CREDENTIAL.md for more information.")]
        public CallSettings(
            CancellationToken? cancellationToken,
            CallCredentials credentials,
            Expiration expiration,
            RetrySettings retry,
            Action<Metadata> headerMutation,
            WriteOptions writeOptions,
            ContextPropagationToken propagationToken) : this(cancellationToken, credentials, expiration, retry, headerMutation, writeOptions, propagationToken, null, null)
        {
        }

        /// <summary>
        /// Constructs an instance with the specified settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token that can be used for cancelling the call.</param>
        /// <param name="expiration"><see cref="Expiration"/> to use, or null for default expiration behavior.</param>
        /// <param name="retry"><see cref="Retry"/> to use, or null for default retry behavior.</param>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <param name="writeOptions"><see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.</param>
        /// <param name="propagationToken"><see cref="ContextPropagationToken"/> for propagating settings from a parent call.</param>
        /// <param name="responseMetadataHandler">Action to invoke when response metadata is received.</param>
        /// <param name="trailingMetadataHandler">Action to invoke when trailing metadata is received.</param>
        public CallSettings(
            CancellationToken? cancellationToken,
            Expiration expiration,
            RetrySettings retry,
            Action<Metadata> headerMutation,
            WriteOptions writeOptions,
            ContextPropagationToken propagationToken,
            Action<Metadata> responseMetadataHandler,
            Action<Metadata> trailingMetadataHandler)
#pragma warning disable CS0618 // Type or member is obsolete
            : this(cancellationToken, null, expiration, retry, headerMutation, writeOptions, propagationToken, responseMetadataHandler, trailingMetadataHandler)
#pragma warning restore CS0618 // Type or member is obsolete
        {
        }

        /// <summary>
        /// Obsolete.
        /// This is obsolete as it allows per-call credentials to be specified.
        /// Please use <see cref="CallSettings(CancellationToken?, Expiration, RetrySettings, Action{Metadata}, WriteOptions, ContextPropagationToken, Action{Metadata}, Action{Metadata})"/>,
        /// and see https://github.com/googleapis/gax-dotnet/blob/main/docs/PER_CALL_CREDENTIAL.md for more information.
        /// Constructs an instance with the specified settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token that can be used for cancelling the call.</param>
        /// <param name="credentials">Credentials to use for the call.</param>
        /// <param name="expiration"><see cref="Expiration"/> to use, or null for default expiration behavior.</param>
        /// <param name="retry"><see cref="Retry"/> to use, or null for default retry behavior.</param>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <param name="writeOptions"><see cref="global::Grpc.Core.WriteOptions"/> that will be used for the call.</param>
        /// <param name="propagationToken"><see cref="ContextPropagationToken"/> for propagating settings from a parent call.</param>
        /// <param name="responseMetadataHandler">Action to invoke when response metadata is received.</param>
        /// <param name="trailingMetadataHandler">Action to invoke when trailing metadata is received.</param>
        [Obsolete("This is obsolete as it allows per-call credentials to be specified. Please use an alternative overload and see https://github.com/googleapis/gax-dotnet/blob/main/docs/PER_CALL_CREDENTIAL.md for more information.")]
        public CallSettings(
            CancellationToken? cancellationToken,
            CallCredentials credentials,
            Expiration expiration,
            RetrySettings retry,
            Action<Metadata> headerMutation,
            WriteOptions writeOptions,
            ContextPropagationToken propagationToken,
            Action<Metadata> responseMetadataHandler,
            Action<Metadata> trailingMetadataHandler)
        {
            CancellationToken = cancellationToken;
            Credentials = credentials;
            Expiration = expiration;
            Retry = retry;
            HeaderMutation = headerMutation;
            WriteOptions = writeOptions;
            PropagationToken = propagationToken;
            ResponseMetadataHandler = responseMetadataHandler;
            TrailingMetadataHandler = trailingMetadataHandler;
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
        [Obsolete("https://github.com/googleapis/gax-dotnet/blob/main/PER_CALL_CREDENTIAL.md")]
        public CallCredentials Credentials { get; }

        /// <summary>
        /// The expiration for the call (either a timeout or a deadline), or null for the default expiration.
        /// </summary>
        public Expiration Expiration { get; }

        /// <summary>
        /// <see cref="RetrySettings"/> to use, or null for default retry behavior.
        /// </summary>
        public RetrySettings Retry { get; }

        /// <summary>
        /// Delegate to receive the metadata associated with a response.
        /// </summary>
        public Action<Metadata> ResponseMetadataHandler { get; }

        /// <summary>
        /// Delegate to receive the metadata sent after the response.
        /// </summary>
        public Action<Metadata> TrailingMetadataHandler { get; }

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
            if (original is null)
            {
                return overlaid;
            }
            if (overlaid is null)
            {
                return original;
            }
#pragma warning disable CS0618 // Type or member is obsolete.
            // But as long as user code can specify credentials we should continue to respect that.
            return new CallSettings(
                overlaid.CancellationToken ?? original.CancellationToken,
                overlaid.Credentials ?? original.Credentials,
                overlaid.Expiration ?? original.Expiration,
                overlaid.Retry ?? original.Retry,
                // Combine mutations so that the overlaid mutation happens last; it can overwrite
                // anything that the previous mutation does.
                original.HeaderMutation + overlaid.HeaderMutation,
                overlaid.WriteOptions ?? original.WriteOptions,
                overlaid.PropagationToken ?? original.PropagationToken,
                original.ResponseMetadataHandler + overlaid.ResponseMetadataHandler,
                original.TrailingMetadataHandler + overlaid.TrailingMetadataHandler);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the new settings.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromCancellationToken(CancellationToken cancellationToken) =>
            cancellationToken.CanBeCanceled ? new CallSettings(cancellationToken, null, null, null, null, null) : CancellationTokenNone;

        /// <summary>
        /// Obsolete. See: https://github.com/googleapis/gax-dotnet/blob/main/PER_CALL_CREDENTIAL.md
        /// Creates a <see cref="CallSettings"/> for the specified call credentials, or returns null
        /// if <paramref name="credentials"/> is null.
        /// </summary>
        /// <param name="credentials">The call credentials for the new settings.</param>
        /// <returns>A new instance, or null if <paramref name="credentials"/> is null.</returns>
        [Obsolete("https://github.com/googleapis/gax-dotnet/blob/main/PER_CALL_CREDENTIAL.md")]
        public static CallSettings FromCallCredentials(CallCredentials credentials) =>
            credentials == null ? null : new CallSettings(null, credentials, null, null, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified call expiration, or returns null
        /// if <paramref name="expiration"/> is null.
        /// </summary>
        /// <param name="expiration">The call timing for the new settings.</param>
        /// <returns>A new instance or null if <paramref name="expiration"/> is null..</returns>
        public static CallSettings FromExpiration(Expiration expiration) =>
            expiration == null ? null : new CallSettings(null, expiration,  null, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified retry settings, or returns null
        /// if <paramref name="retry"/> is null.
        /// </summary>
        /// <param name="retry">The call timing for the new settings.</param>
        /// <returns>A new instance or null if <paramref name="retry"/> is null..</returns>
        public static CallSettings FromRetry(RetrySettings retry) =>
            retry == null ? null : new CallSettings(null, null, retry, null, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified header mutation, or returns null
        /// if <paramref name="headerMutation"/> is null.
        /// </summary>
        /// <param name="headerMutation">Action to modify the headers to send at the beginning of the call.</param>
        /// <returns>A new instance, or null if <paramref name="headerMutation"/> is null..</returns>
        public static CallSettings FromHeaderMutation(Action<Metadata> headerMutation) =>
            headerMutation == null ? null : new CallSettings(null, null, null, headerMutation, null, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified response metadata handler, or returns null
        /// if <paramref name="responseMetadataHandler"/> is null.
        /// </summary>
        /// <param name="responseMetadataHandler">Action to receive response metadata when the call completes.</param>
        /// <returns>A new instance, or null if <paramref name="responseMetadataHandler"/> is null..</returns>
        public static CallSettings FromResponseMetadataHandler(Action<Metadata> responseMetadataHandler) =>
            responseMetadataHandler == null ? null : new CallSettings(null, null, null, null, null, null, responseMetadataHandler, null);

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified trailing metadata handler, or returns null
        /// if <paramref name="trailingMetadataHandler"/> is null.
        /// </summary>
        /// <param name="trailingMetadataHandler">Action to receive trailing metadata when the call completes.</param>
        /// <returns>A new instance, or null if <paramref name="trailingMetadataHandler"/> is null..</returns>
        public static CallSettings FromTrailingMetadataHandler(Action<Metadata> trailingMetadataHandler) =>
            trailingMetadataHandler == null ? null : new CallSettings(null, null, null, null, null, null, null, trailingMetadataHandler);
        
        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified header name and value.
        /// </summary>
        /// <param name="name">The name of the header to add. Must not be null.</param>
        /// <param name="value">The value of the header to add. Must not be null.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromHeader(string name, string value)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            CallSettingsExtensions.CheckHeader(name);
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

        /// <summary>
        /// Creates a CallSettings which applies an x-goog-request-params header with the specified
        /// parameter name and value.
        /// </summary>
        /// <remarks>The value is URL-encoded; it is expected that <paramref name="parameterName"/> is already URL-encoded.</remarks>
        /// <param name="parameterName">The name of the parameter. Must not be null.</param>
        /// <param name="value">The value of the parameter, which may be null. A null value is equivalent to providing an empty string.</param>
        /// <returns>A CallSettings which applies the appropriate parameter.</returns>
        internal static CallSettings FromGoogleRequestParamsHeader(string parameterName, string value) =>
            FromHeader(RequestParamsHeader, parameterName + "=" + Uri.EscapeDataString(value ?? ""));

        /// <summary>
        /// Creates a CallSettings which applies an x-goog-request-reason header with the specified reason.
        /// </summary>
        /// <param name="reason">The request reason to specify in the x-goog-request-reason header. Must not be null</param>
        /// <returns>A CallSettings which applies the appropriate header.</returns>
        internal static CallSettings FromRequestReasonHeader(string reason) =>
            FromHeader(RequestReasonHeader, GaxPreconditions.CheckNotNull(reason, nameof(reason)));
    }
}
