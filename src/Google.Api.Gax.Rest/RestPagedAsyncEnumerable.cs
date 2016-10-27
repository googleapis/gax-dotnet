/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// Interfaces and implementations of asynchronous page streaming. These are gathered into a single file
// for convenience.

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// An asynchronous sequence of resources, obtained lazily via API operations which retrieve a page at a time.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public sealed class RestPagedAsyncEnumerable<TRequest, TResponse, TResource> : PagedAsyncEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly ResponseAsyncEnumerable<TRequest, TResponse, TResource> _pages;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        /// <summary>
        /// Creates a new lazily-evaluated sequence from the given API call, initial request, and call settings.
        /// </summary>
        /// <param name="requestProvider">A factory used to create an initial request each time the sequence is iterated over.</param>
        /// <param name="pageManager">A manager to work with the requests and responses.</param>
        public RestPagedAsyncEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _pages = new ResponseAsyncEnumerable<TRequest, TResponse, TResource>(requestProvider, pageManager);
            _pageManager = pageManager;
        }

        /// <inheritdoc/>
        public override IAsyncEnumerable<TResponse> AsRawResponses() => _pages;

        /// <inheritdoc/>
        public override Task<Page<TResource>> ReadPageAsync(
            int pageSize, CancellationToken cancellationToken = default(CancellationToken)) =>
            _pages.GetCompletePageAsync(pageSize, cancellationToken);

        /// <inheritdoc/>
        public override IAsyncEnumerator<TResource> GetEnumerator() =>
            _pages.SelectMany(page => _pageManager.GetResourcesEmptyIfNull(page).ToAsyncEnumerable()).GetEnumerator();
    }

    /// <summary>
    /// An asynchronous sequence of API responses, each containing a page of resources.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    internal sealed class ResponseAsyncEnumerable<TRequest, TResponse, TResource> : IAsyncEnumerable<TResponse>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly Func<TRequest> _requestProvider;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        public ResponseAsyncEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _requestProvider = GaxPreconditions.CheckNotNull(requestProvider, nameof(requestProvider));
            _pageManager = GaxPreconditions.CheckNotNull(pageManager, nameof(pageManager));
        }

        /// <inheritdoc />
        public IAsyncEnumerator<TResponse> GetEnumerator() =>
            new ResponseAsyncEnumerator(_requestProvider(), _pageManager);

        /// <inheritdoc />
        IAsyncEnumerator<TResponse> IAsyncEnumerable<TResponse>.GetEnumerator() => GetEnumerator();

        internal async Task<Page<TResource>> GetCompletePageAsync(
            int pageSize, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = _requestProvider();
            var items = new List<TResource>(pageSize);
            string nextPageToken = null;
            while (items.Count < pageSize)
            {
                int requestCount = pageSize - items.Count;
                _pageManager.SetPageSize(request, requestCount);
                var current = await request.ExecuteAsync(cancellationToken).ConfigureAwait(false);
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

        private class ResponseAsyncEnumerator : IAsyncEnumerator<TResponse>
        {
            private readonly TRequest _request; // This is mutated during iteration
            private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;
            private bool _finished;

            public ResponseAsyncEnumerator(TRequest request, IPageManager<TRequest, TResponse, TResource> pageManager)
            {
                _request = request;
                _pageManager = pageManager;
            }

            public TResponse Current { get; private set; }

            public async Task<bool> MoveNext(CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (_finished)
                {
                    return false;
                }
                Current = await _request.ExecuteAsync(cancellationToken);
                var nextPageToken = _pageManager.GetNextPageToken(Current);
                if (nextPageToken == null)
                {
                    _finished = true;
                }
                // Prepare the next request...
                _pageManager.SetPageToken(_request, nextPageToken);
                return true;
            }

            public void Dispose() { }
        }        
    }
}
