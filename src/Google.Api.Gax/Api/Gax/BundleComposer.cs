/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax
{
    /// <summary>
    /// Describes operations used by a <see cref="Bundler"/> to combine requests together and split a
    /// single response into its components to reply to the original requests.
    /// </summary>
    /// <remarks>This type is almost never needed by manually written code.
    /// The intended usage is for instances to be constructed by generated code, and then used for bundling
    /// operations.</remarks>
    /// <typeparam name="TRequest">Operation request type</typeparam>
    /// <typeparam name="TResponse">Operation response type</typeparam>
    public abstract class BundleComposer<TRequest, TResponse>
        where TRequest : class, IMessage<TRequest>
        where TResponse : class, IMessage<TResponse>
    {
        internal IEqualityComparer<TRequest> RequestComparer { get; }
        
        private BundleComposer(IEqualityComparer<TRequest> requestComparer)
        {
            this.RequestComparer = requestComparer;
        }

        /// <summary>
        /// Adds the entries from <paramref name="extra"/> to <paramref name="bundleRequest"/>.
        /// It is assumed that the request has already been cloned and will not be modified further,
        /// and so no additional cloning is required.
        /// </summary>
        /// <param name="bundleRequest">The current amalgamated request.</param>
        /// <param name="extra">The extra request to add entries from.</param>
        internal abstract void AddRequestEntries(TRequest bundleRequest, TRequest extra);

        /// <summary>
        /// Clears the entries from a request, e.g. when cancelling part of a bundle, or
        /// obtaining the initial request.
        /// </summary>
        internal abstract void ClearEntries(TRequest request);

        /// <summary>
        /// Returns the number of entries in the given request.
        /// </summary>
        internal abstract int GetEntryCount(TRequest request);

        /// <summary>
        /// Splits a given single response into multiple responses, with the number of entries
        /// in each response corresponding to the number of entries in each original request.
        /// </summary>
        internal abstract IList<TResponse> SplitResponse(IList<TRequest> requests, TResponse response);

        /// <summary>
        /// Constructs an instance based on individual primitive operations on requests and responses, in the case where all
        /// requests to a particular service can be combined, without partitioning.
        /// </summary>
        /// <typeparam name="TRequestEntry">The type of the entries within a request.</typeparam>
        /// <typeparam name="TResponseEntry">The type of the entries within a response.</typeparam>
        /// <param name="requestEntryExtractor">A projection from a request to a sequence of entries.</param>
        /// <param name="responseEntryExtractor">A projection from a response to a sequence of entries.</param>
        /// <returns>A <see cref="BundleComposer{TRequest, TResponse}"/> using the given operations for composition and decomposition.</returns>
        public static BundleComposer<TRequest, TResponse> Create<TRequestEntry, TResponseEntry>(
            Func<TRequest, RepeatedField<TRequestEntry>> requestEntryExtractor,
            Func<TResponse, RepeatedField<TResponseEntry>> responseEntryExtractor)
        {
            var comparer = new AlwaysEqualComparer();
            return new BundleComposerImpl<TRequestEntry, TResponseEntry>(comparer, requestEntryExtractor, responseEntryExtractor);
        }

        /// <summary>
        /// Constructs an instance based on individual primitive operations on requests and responses, in the case
        /// where only requests are partitioned by a key (such as a pubsub topic).
        /// </summary>
        /// <typeparam name="TKey">The key type of a request, used to determine which requests can be combined.</typeparam>
        /// <typeparam name="TRequestEntry">The type of the entries within a request.</typeparam>
        /// <typeparam name="TResponseEntry">The type of the entries within a response.</typeparam>
        /// <param name="keySelector">A projection from a request to a key; only requests with equal keys can be combined.</param>
        /// <param name="requestEntryExtractor">A projection from a request to a sequence of entries.</param>
        /// <param name="responseEntryExtractor">A projection from a response to a sequence of entries.</param>
        /// <returns>A <see cref="BundleComposer{TRequest, TResponse}"/> using the given operations for composition and decomposition.</returns>
        public static BundleComposer<TRequest, TResponse> Create<TKey, TRequestEntry, TResponseEntry>(
            Func<TRequest, TKey> keySelector,
            Func<TRequest, RepeatedField<TRequestEntry>> requestEntryExtractor,
            Func<TResponse, RepeatedField<TResponseEntry>> responseEntryExtractor)
        {
            var comparer = new ProjectionEqualityComparer<TKey>(GaxPreconditions.CheckNotNull(keySelector, nameof(keySelector)));
            return new BundleComposerImpl<TRequestEntry, TResponseEntry>(comparer, requestEntryExtractor, responseEntryExtractor);
        }

        /// <summary>
        /// Only actual implementation of BundlingDescriptor. It's structured this way so we can retain type parameters TRequestEntry and TResponseEntry
        /// without baking them into the public API.
        /// </summary>
        private sealed class BundleComposerImpl<TRequestEntry, TResponseEntry> : BundleComposer<TRequest, TResponse>
        {
            private readonly Func<TRequest, RepeatedField<TRequestEntry>> _requestEntryExtractor;
            private readonly Func<TResponse, RepeatedField<TResponseEntry>> _responseEntryExtractor;

            internal BundleComposerImpl(
                IEqualityComparer<TRequest> requestComparer,
                Func<TRequest, RepeatedField<TRequestEntry>> requestEntryExtractor,
                Func<TResponse, RepeatedField<TResponseEntry>> responseEntryExtractor)
                : base(requestComparer)
            {
                this._requestEntryExtractor = GaxPreconditions.CheckNotNull(requestEntryExtractor, nameof(requestEntryExtractor));
                this._responseEntryExtractor = GaxPreconditions.CheckNotNull(responseEntryExtractor, nameof(responseEntryExtractor));
            }

            internal override IList<TResponse> SplitResponse(IList<TRequest> requests, TResponse response)
            {
                var totalRequestEntries = requests.Sum(r => _requestEntryExtractor(r).Count);
                var splitResponses = new List<TResponse>(totalRequestEntries);
                // We don't mutate the response itself, for testing purposes. Instead, we clone the whole
                // response once, then clear the list in the clone, to act as a response template.
                var responseEntries = _responseEntryExtractor(response);

                GaxPreconditions.CheckArgument(
                    totalRequestEntries == responseEntries.Count,
                    nameof(response),
                    "Requests contained {0} entries; response contained {1} entries.",
                    totalRequestEntries,
                    responseEntries.Count);                
                         
                var splitResponseTemplate = response.Clone();
                _responseEntryExtractor(splitResponseTemplate).Clear();

                int responseEntryIndex = 0;
                foreach (var request in requests)
                {
                    var requestEntryCount = _requestEntryExtractor(request).Count;
                    var individualResponse = splitResponseTemplate.Clone();
                    var individualEntries = _responseEntryExtractor(individualResponse);
                    // We could potentially use Skip/Take here.
                    for (int j = 0; j < requestEntryCount; j++)
                    {
                        individualEntries.Add(responseEntries[responseEntryIndex++]);
                    }
                    splitResponses.Add(individualResponse);
                }
                return splitResponses;
            }

            internal override void AddRequestEntries(TRequest bundleRequest, TRequest extra)
            {
                var existingEntries = _requestEntryExtractor(bundleRequest);
                var newEntries = _requestEntryExtractor(extra);
                existingEntries.Add(newEntries);
            }

            internal override int GetEntryCount(TRequest request)
            {
                return _requestEntryExtractor(request).Count;
            }

            internal override void ClearEntries(TRequest request)
            {
                _requestEntryExtractor(request).Clear();
            }
        }

        // TODO: Move this to a top-level type if we need it anywhere else.
        /// <summary>
        /// Equality comparer based on a projection from an original type to a key, which is assumed
        /// to be naturally-equatable. (There's no constraint on TKey as otherwise we couldn't project
        /// to anonymous types, which could be handy.)
        /// </summary>
        /// <typeparam name="TKey">The type project to.</typeparam>
        private class ProjectionEqualityComparer<TKey> : IEqualityComparer<TRequest>
        {
            private readonly Func<TRequest, TKey> _keySelector;

            internal ProjectionEqualityComparer(Func<TRequest, TKey> keySelector)
            {
                this._keySelector = keySelector;
            }

            public bool Equals(TRequest x, TRequest y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }
                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                {
                    return false;
                }
                return EqualityComparer<TKey>.Default.Equals(_keySelector(x), _keySelector(y));
            }

            public int GetHashCode(TRequest obj)
            {
                if (ReferenceEquals(obj, null))
                {
                    return 0;
                }
                return EqualityComparer<TKey>.Default.GetHashCode(_keySelector(obj));
            }
        }

        /// <summary>
        /// An equality comparer which claims that all requests are equal. Used when there is no key aspect to a request.
        /// </summary>
        private class AlwaysEqualComparer : IEqualityComparer<TRequest>
        {
            public bool Equals(TRequest x, TRequest y)
            {
                return true;
            }

            public int GetHashCode(TRequest obj)
            {
                return 0;
            }
        }
    }
}
