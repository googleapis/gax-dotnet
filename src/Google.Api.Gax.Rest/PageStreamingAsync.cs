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
    /// An asynchronous sequence of resources obtained via API responses. Application code
    /// can treat this as a simple sequence (with API calls automatically being made
    /// lazily as more results are required), or call <see cref="AsPages"/> to retrieve
    /// a page at a time, potentially with additional information.
    /// </summary>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public interface IPagedAsyncEnumerable<TResponse, TResource> : IAsyncEnumerable<TResource>
    {
        /// <summary>
        /// Returns the sequence of API responses, each of which contributes a page of
        /// resources to this sequence.
        /// </summary>
        /// <returns>An asynchronous sequence of API responses, each containing a page of resources.</returns>
        IResponseAsyncEnumerable<TResponse, TResource> AsPages();
    }

    /// <summary>
    /// An asynchronous sequence of API responses, each of which contains a page of resources and
    /// potentially additional information (depending on the API).
    /// </summary>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public interface IResponseAsyncEnumerable<TResponse, TResource> : IAsyncEnumerable<TResponse>
    {
        /// <summary>
        /// Begins lazily iterating over the sequence of pages, with an iterator allowing the page size to
        /// be specified on each step.
        /// </summary>
        /// <returns>An asynchronous iterator over the pages in the sequence.</returns>
        new IResponseAsyncEnumerator<TResponse> GetEnumerator();

        /// <summary>
        /// Creates a lazily-evaluated asynchronous sequence of pages of resources, where each page other
        /// than the final one is guaranteed to contain exactly <paramref name="pageSize"/> resources.
        /// </summary>
        /// <remarks>
        /// "Natural" pages returned by the API may contain a smaller number of resources than requested.
        /// For example, a request for a page with 100 resources may return a page with 80 resources but
        /// a next page token for more to be retrieved. This is suitable for batch-processing, but not
        /// for user-visible paging such as in a web application, where fixed-size pages are expected.
        /// </remarks>
        /// <param name="pageSize">The page size. Must be greater than 0.</param>
        /// <returns>A lazily-evaluated asynchronous sequence of fixed-size pages.</returns>
        IAsyncEnumerable<FixedSizePage<TResource>> WithFixedSize(int pageSize);
    }

    /// <summary>
    /// An asynchronous iterator over a sequence of pages of resources. This is similar to a regular
    /// <see cref="IAsyncEnumerator{T}"/>, except it allows the size of the requested page to
    /// be modified along the way.
    /// </summary>
    /// <typeparam name="T">The page type.</typeparam>
    public interface IResponseAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        /// <summary>
        /// Advance to the next page in the sequence, requesting the specified page size.
        /// </summary>
        /// <param name="pageSize">The number of resources to include in the next page.</param>
        /// <param name="cancellationToken">A cancellation token for the asynchronous operation.</param>
        /// <returns>A task with a result of <c>true</c> if the enumerator was successfully advanced to the next element or
        /// <c>false</c> if the enumerator has passed the end of the collection.</returns>
        Task<bool> MoveNext(int pageSize, CancellationToken cancellationToken);
    }

    /// <summary>
    /// An asynchronous sequence of resources, obtained lazily via API operations which retrieve a page at a time.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public sealed class PagedAsyncEnumerable<TRequest, TResponse, TResource> : IPagedAsyncEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly IResponseAsyncEnumerable<TResponse, TResource> _pages;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        /// <summary>
        /// Creates a new lazily-evaluated sequence from the given API call, initial request, and call settings.
        /// </summary>
        /// <param name="requestProvider">A factory used to create an initial request each time the sequence is iterated over.</param>
        /// <param name="pageManager">A manager to work with the requests and responses.</param>
        public PagedAsyncEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _pages = new ResponseAsyncEnumerable<TRequest, TResponse, TResource>(requestProvider, pageManager);
            _pageManager = pageManager;
        }

        /// <inheritdoc/>
        public IResponseAsyncEnumerable<TResponse, TResource> AsPages() => _pages;

        /// <inheritdoc/>
        public IAsyncEnumerator<TResource> GetEnumerator() =>
            _pages.SelectMany(page => _pageManager.GetResourcesEmptyIfNull(page).ToAsyncEnumerable()).GetEnumerator();
    }

    /// <summary>
    /// An asynchronous sequence of API responses, each containing a page of resources.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    internal sealed class ResponseAsyncEnumerable<TRequest, TResponse, TResource> : IResponseAsyncEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly Func<TRequest> _requestProvider;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        public ResponseAsyncEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _requestProvider = GaxRestPreconditions.CheckNotNull(requestProvider, nameof(requestProvider));
            _pageManager = GaxRestPreconditions.CheckNotNull(pageManager, nameof(pageManager));
        }


        public IResponseAsyncEnumerator<TResponse> GetEnumerator() =>
            new ResponseAsyncEnumerator(_requestProvider(), _pageManager);

        IAsyncEnumerator<TResponse> IAsyncEnumerable<TResponse>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public IAsyncEnumerable<FixedSizePage<TResource>> WithFixedSize(int pageSize) =>
            new FixedPageSizeAsyncEnumerable(this, _pageManager, pageSize);

        private class ResponseAsyncEnumerator : IResponseAsyncEnumerator<TResponse>
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

            public Task<bool> MoveNext(int pageSize, CancellationToken cancellationToken)
            {
                GaxRestPreconditions.CheckArgument(pageSize > 0, nameof(pageSize), "Must be greater than 0");
                _pageManager.SetPageSize(_request, pageSize);
                return MoveNext(cancellationToken);
            }

            public void Dispose() { }
        }

        private class FixedPageSizeAsyncEnumerable : IAsyncEnumerable<FixedSizePage<TResource>>
        {
            private readonly IResponseAsyncEnumerable<TResponse, TResource> _source;
            private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;
            private readonly int _pageSize;

            internal FixedPageSizeAsyncEnumerable(
                IResponseAsyncEnumerable<TResponse, TResource> source,
                IPageManager<TRequest, TResponse, TResource> pageManager,
                int pageSize)
            {
                GaxRestPreconditions.CheckArgument(pageSize > 0, nameof(pageSize), "Must be greater than 0");
                _source = source;
                _pageManager = pageManager;
                _pageSize = pageSize;
            }

            public IAsyncEnumerator<FixedSizePage<TResource>> GetEnumerator() =>
                new Enumerator(_source.GetEnumerator(), _pageManager, _pageSize);

            private class Enumerator : IAsyncEnumerator<FixedSizePage<TResource>>
            {
                private readonly IResponseAsyncEnumerator<TResponse> _enumerator;
                private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;
                private readonly int _pageSize;

                internal Enumerator(
                    IResponseAsyncEnumerator<TResponse> enumerator,
                    IPageManager<TRequest, TResponse, TResource> pageManager,
                    int pageSize)
                {
                    _enumerator = enumerator;
                    _pageManager = pageManager;
                    _pageSize = pageSize;
                }

                public FixedSizePage<TResource> Current { get; private set; }

                public async Task<bool> MoveNext(CancellationToken cancellationToken)
                {
                    var items = new List<TResource>(_pageSize);
                    while (items.Count < _pageSize)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        int requestCount = _pageSize - items.Count;
                        var done = !(await _enumerator.MoveNext(requestCount, cancellationToken).ConfigureAwait(false));
                        if (done)
                        {
                            break;
                        }
                        var resources = _pageManager.GetResourcesEmptyIfNull(_enumerator.Current);
                        items.AddRange(resources);
                        if (items.Count > _pageSize)
                        {
                            // TODO: Better exception type?
                            throw new NotSupportedException("Invalid server response: " +
                                $"requested {requestCount} items, received {resources.Count()} items");
                        }
                    }
                    if (items.Count != 0)
                    {
                        Current = new FixedSizePage<TResource>(items, _pageManager.GetNextPageToken(_enumerator.Current));
                        return true;
                    }
                    Current = null;
                    return false;
                }

                public void Dispose()
                {
                    _enumerator.Dispose();
                }
            }
        }
    }
}
