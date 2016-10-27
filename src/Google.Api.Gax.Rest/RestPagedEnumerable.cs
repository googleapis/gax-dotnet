/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Interfaces and implementations of synchronous page streaming. These are gathered into a single file
// for convenience.

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// A sequence of resources, obtained lazily via API operations which retrieve a page at a time.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public sealed class RestPagedEnumerable<TRequest, TResponse, TResource> : PagedEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly Func<TRequest> _requestProvider;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        /// <summary>
        /// Creates a new lazily-evaluated sequence from the given API call, initial request, and call settings.
        /// </summary>
        /// <param name="requestProvider">A factory used to create an initial request each time the sequence is iterated over.</param>
        /// <param name="pageManager">A manager to work with the requests and responses.</param>
        public RestPagedEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _requestProvider = requestProvider;
            _pageManager = pageManager;
        }

        /// <inheritdoc/>
        public override IEnumerable<TResponse> AsRawResponses()
        {
            var request = _requestProvider();
            while (true)
            {
                var current = request.Execute();
                var nextPageToken = _pageManager.GetNextPageToken(current);
                yield return current;
                if (nextPageToken == null)
                {
                    yield break;
                }
                // Prepare the next request...
                _pageManager.SetPageToken(request, nextPageToken);
            }
        }

        /// <inheritdoc/>
        public override IEnumerator<TResource> GetEnumerator() =>
            AsRawResponses().SelectMany(page => _pageManager.GetResourcesEmptyIfNull(page)).GetEnumerator();

        /// <inheritdoc/>
        public override Page<TResource> ReadPage(int pageSize)
        {
            var request = _requestProvider();
            var items = new List<TResource>(pageSize);
            string nextPageToken = null;
            while (items.Count < pageSize)
            {
                int requestCount = pageSize - items.Count;
                _pageManager.SetPageSize(request, requestCount);
                var current = request.Execute();
                var resources = _pageManager.GetResourcesEmptyIfNull(current);
                items.AddRange(resources);
                if (items.Count > pageSize)
                {
                    throw new NotSupportedException("Invalid server response: " +
                        $"requested {requestCount} items, received {resources.Count()} items");
                }
                nextPageToken = _pageManager.GetNextPageToken(current);
                if (nextPageToken == null)
                {
                    break;
                }
                // Prepare the next request...
                _pageManager.SetPageToken(request, nextPageToken);
            }
            return new Page<TResource>(items, nextPageToken);
        }
    }    
}
