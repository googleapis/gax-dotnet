/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;
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
        {
            CancellationToken = cancellationToken;
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
            return new CallSettings(
                overlaid.CancellationToken ?? original.CancellationToken,
                overlaid.Expiration ?? original.Expiration,
                overlaid.Retry ?? original.Retry,
                // Combine mutations so that the overlaid mutation happens last; it can overwrite
                // anything that the previous mutation does.
                original.HeaderMutation + overlaid.HeaderMutation,
                overlaid.WriteOptions ?? original.WriteOptions,
                overlaid.PropagationToken ?? original.PropagationToken,
                original.ResponseMetadataHandler + overlaid.ResponseMetadataHandler,
                original.TrailingMetadataHandler + overlaid.TrailingMetadataHandler);
        }

        /// <summary>
        /// Creates a <see cref="CallSettings"/> for the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the new settings.</param>
        /// <returns>A new instance.</returns>
        public static CallSettings FromCancellationToken(CancellationToken cancellationToken) =>
            cancellationToken.CanBeCanceled ? new CallSettings(cancellationToken, null, null, null, null, null) : CancellationTokenNone;

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
        /// Creates a <see cref="CallSettings"/> which applies an x-goog-request-params header with the specified
        /// parameter name and value.
        /// </summary>
        /// <remarks>The value is URL-encoded; it is expected that <paramref name="parameterName"/> is already URL-encoded.</remarks>
        /// <param name="parameterName">The name of the parameter. Must not be null.</param>
        /// <param name="value">The value of the parameter, which may be null. A null value is equivalent to providing an empty string.</param>
        /// <returns>A <see cref="CallSettings"/> which applies the appropriate header with a single parameter.</returns>
        internal static CallSettings FromGoogleRequestParamsHeader(string parameterName, string value) =>
            FromHeader(RequestParamsHeader, parameterName + "=" + Uri.EscapeDataString(value ?? ""));

        /// <summary>
        /// Creates a <see cref="CallSettings"/> which applies an x-goog-request-params header with the specified
        /// escaped header value.
        /// </summary>
        /// <param name="escapedHeaderValue">The value of the x-goog-request-params header.
        /// Must be escaped. Must not be null or empty.</param>
        /// <returns>A <see cref="CallSettings"/> which applies the appropriate header.</returns>
        internal static CallSettings FromGoogleRequestParamsHeader(string escapedHeaderValue) =>
            FromHeader(RequestParamsHeader, GaxPreconditions.CheckNotNullOrEmpty(escapedHeaderValue, nameof(escapedHeaderValue)));

        /// <summary>
        /// Creates a CallSettings which applies an x-goog-request-reason header with the specified reason.
        /// </summary>
        /// <param name="reason">The request reason to specify in the x-goog-request-reason header. Must not be null</param>
        /// <returns>A CallSettings which applies the appropriate header.</returns>
        internal static CallSettings FromRequestReasonHeader(string reason) =>
            FromHeader(RequestReasonHeader, GaxPreconditions.CheckNotNull(reason, nameof(reason)));

        // TODO: Consider moving some of these methods to Grcp.Core.Metadata, as this code is very
        // aware of Metadata implementation details for optimization purposes.
        /// <summary>
        /// Helper class defining some common metadata mutation actions.
        /// </summary>
        internal static class MetadataMutations
        {
            /// <summary>
            /// Removes from <paramref name="entries"/> all entries with <paramref name="name"/> if any.
            /// </summary>
            /// <param name="entries">The metadata set to modify. Must no be null.</param>
            /// <param name="name">The name of entries to override. Must no be null.</param>
            internal static void RemoveAll(Metadata entries, string name)
            {
                GaxPreconditions.CheckNotNull(entries, nameof(entries));
                GaxPreconditions.CheckNotNull(name, nameof(name));

                // This is the most efficient way to remove all entries with a given name.
                // It's O(n) where n is the total number of entries.

                // First we find the first element that we need to remove, and use its index as
                // the first target index to copy other elements over.
                int target;
                for (target = 0; target < entries.Count && entries[target].Key != name; target++) ;

                // Now, we examine the rest of the elements one by one, skipping the ones we want
                // to remove. When we find one that we want to keep we copy it over to target,
                // and increase target by one.
                int source;
                for (source = target + 1; source < entries.Count; source++)
                {
                    if (entries[source].Key != name)
                    {
                        entries[target++] = entries[source];
                    }
                }

                // Now we remove all remaining elements from target till the end of the collection.
                // The ones that we want to keep have already been copied over before target and the
                // rest are the ones that we wanted to remove in the first place.
                // Remove back to front for efficiency.
                for (int j = entries.Count - 1; j >= target; j--)
                {
                    entries.RemoveAt(j);
                }
            }

            /// <summary>
            /// Removes from <paramref name="entries"/> all entries with <paramref name="name"/> if any
            /// and adds a single entry with the given name and value.
            /// </summary>
            /// <param name="entries">The metadata set to modify. Must no be null.</param>
            /// <param name="name">The name of entries to override. Must no be null.</param>
            /// <param name="value">The value to associate to a new entry with the given name. Must not be null.</param>
            internal static void Override(Metadata entries, string name, string value)
            {
                GaxPreconditions.CheckNotNull(entries, nameof(entries));
                GaxPreconditions.CheckNotNull(name, nameof(name));
                CallSettingsExtensions.CheckHeader(name);
                GaxPreconditions.CheckNotNull(value, nameof(value));

                // Remove all entries associated to the given name.
                RemoveAll(entries, name);
                // Add the new value associated to the given name.
                entries.Add(name, value);
            }

            /// <summary>
            /// If two or more entries with <paramref name="name"/> exist in <paramref name="entries"/>
            /// they are removed and their values concatenated using <paramref name="separator"/> and a new entry
            /// is added for the given name, with the resulting concatenated value.
            /// </summary>
            /// <param name="entries">The metadata set to modify. Must not be null.</param>
            /// <param name="name">The name of entries whose values are to be concatenated. Must not be null.</param>
            /// <param name="separator">The separator to use for concatenation. Must not be null.</param>
            internal static void Concatenate(Metadata entries, string name, string separator)
            {
                GaxPreconditions.CheckNotNull(entries, nameof(entries));
                GaxPreconditions.CheckNotNull(name, nameof(name));
                GaxPreconditions.CheckNotNull(separator, nameof(separator));

                // Find the first and sencond entry to concatenate.
                int firstIndex, secondIndex;
                for (firstIndex = 0; firstIndex < entries.Count && entries[firstIndex].Key != name; firstIndex++);
                for (secondIndex = firstIndex + 1; secondIndex < entries.Count && entries[secondIndex].Key != name; secondIndex++) ;
                // If there are less than two values associated to name, there's nothing we need to do.
                if (firstIndex == entries.Count || secondIndex == entries.Count)
                {
                    return;
                }

                StringBuilder builder = new StringBuilder(entries[firstIndex].Value)
                    .Append(separator)
                    .Append(entries[secondIndex].Value);
                // Concatenate the rest of the entries if any.
                for (int i = secondIndex + 1; i < entries.Count; i++)
                {
                    if (entries[i].Key == name)
                    {
                        builder.Append(separator).Append(entries[i].Value);
                    }
                }

                // Note that we could have removed the concatenated entries while iterating over them
                // for concatenation, but if there's an error within the iteration, for instance, because
                // an entry has a bytes values instead of a string value, then the entry set will remain
                // in an inconsistent state, where some of the existing entries have been removed
                // but not all, and the concatenated value has not been added.
                Override(entries, name, builder.ToString());
            }
        }
    }
}
