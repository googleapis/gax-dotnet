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
    /// A sequence of resources obtained via API responses, each of which contributes a page of resources.
    /// Application code can treat this as a simple sequence (with API calls automatically being made
    /// lazily as more results are required), or call <see cref="AsPages"/> to retrieve
    /// a page at a time, potentially with additional information.
    /// </summary>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public interface IPagedEnumerable<TResponse, TResource> : IEnumerable<TResource>
    {
        /// <summary>
        /// Returns the sequence of API responses, each of which contributes a page of
        /// resources to this sequence.
        /// </summary>
        /// <returns>A sequence of API responses, each containing a page of resources.</returns>
        IResponseEnumerable<TResponse, TResource> AsPages();
    }

    /// <summary>
    /// A sequence of API responses, each of which contains a page of resources and
    /// potentially additional information (depending on the API).
    /// </summary>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public interface IResponseEnumerable<TResponse, TResource> : IEnumerable<TResponse>
    {
        /// <summary>
        /// Begins lazily iterating over the sequence of pages, with an iterator allowing the page size to
        /// be specified on each step.
        /// </summary>
        /// <returns>An iterator over the pages in the sequence.</returns>
        new IResponseEnumerator<TResponse> GetEnumerator();

        /// <summary>
        /// Creates a lazily-evaluated sequence of pages of resources, where each page other
        /// than the final one is guaranteed to contain exactly <paramref name="pageSize"/> resources.
        /// </summary>
        /// <remarks>
        /// "Natural" pages returned by the API may contain a smaller number of resources than requested.
        /// For example, a request for a page with 100 resources may return a page with 80 resources but
        /// a next page token for more to be retrieved. This is suitable for batch-processing, but not
        /// for user-visible paging such as in a web application, where fixed-size pages are expected.
        /// </remarks>
        /// <param name="pageSize">The page size. Must be greater than 0.</param>
        /// <returns>A lazily-evaluated sequence of fixed-size pages.</returns>
        IEnumerable<FixedSizePage<TResource>> WithFixedSize(int pageSize);
    }

    /// <summary>
    /// An iterator over a sequence of pages of resources. This is similar to a regular
    /// <see cref="IEnumerator{T}"/>, except it allows the size of the requested page to
    /// be modified along the way.
    /// </summary>
    /// <typeparam name="T">The page type.</typeparam>
    public interface IResponseEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Advance to the next page in the sequence, requesting the specified page size.
        /// </summary>
        /// <param name="pageSize">The number of resources to include in the next page.</param>
        /// <returns><c>true</c> if the enumerator was successfully advanced to the next element; <c>false</c> if the enumerator has passed the end of the collection.</returns>
        bool MoveNext(int pageSize);
    }

    /// <summary>
    /// A sequence of resources, obtained lazily via API operations which retrieve a page at a time.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public sealed class PagedEnumerable<TRequest, TResponse, TResource> : IPagedEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly IResponseEnumerable<TResponse, TResource> _pages;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        /// <summary>
        /// Creates a new lazily-evaluated sequence from the given API call, initial request, and call settings.
        /// </summary>
        /// <param name="requestProvider">A factory used to create an initial request each time the sequence is iterated over.</param>
        /// <param name="pageManager">A manager to work with the requests and responses.</param>
        public PagedEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _pages = new ResponseEnumerable<TRequest, TResponse, TResource>(requestProvider, pageManager);
            _pageManager = pageManager;
        }

        /// <inheritdoc/>
        public IResponseEnumerable<TResponse, TResource> AsPages() => _pages;

        /// <inheritdoc/>
        public IEnumerator<TResource> GetEnumerator() =>
            _pages.SelectMany(page => _pageManager.GetResourcesEmptyIfNull(page)).GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// A sequence of API responses, each containing a page of resources.
    /// </summary>
    /// <typeparam name="TRequest">The API request type.</typeparam>
    /// <typeparam name="TResponse">The API response type.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    internal sealed class ResponseEnumerable<TRequest, TResponse, TResource> : IResponseEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly Func<TRequest> _requestProvider;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        public ResponseEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _requestProvider = GaxRestPreconditions.CheckNotNull(requestProvider, nameof(requestProvider));
            _pageManager = GaxRestPreconditions.CheckNotNull(pageManager, nameof(pageManager));
        }

        /// <inheritdoc />
        public IResponseEnumerator<TResponse> GetEnumerator() => new ResponseEnumerator(_requestProvider(), _pageManager);

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        IEnumerator<TResponse> IEnumerable<TResponse>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public IEnumerable<FixedSizePage<TResource>> WithFixedSize(int pageSize)
        {
            GaxRestPreconditions.CheckArgument(pageSize > 0, nameof(pageSize), "Must be greater than 0");
            using (var enumerator = GetEnumerator())
            {
                bool done = false;
                while (!done)
                {
                    var items = new List<TResource>(pageSize);
                    while (items.Count < pageSize)
                    {
                        int requestCount = pageSize - items.Count;
                        done = !enumerator.MoveNext(requestCount);
                        if (done)
                        {
                            break;
                        }
                        var resources = _pageManager.GetResourcesEmptyIfNull(enumerator.Current);
                        items.AddRange(resources);
                        if (items.Count > pageSize)
                        {
                            throw new NotSupportedException("Invalid server response: " +
                                $"requested {requestCount} items, received {resources.Count()} items");
                        }
                    }
                    if (items.Count != 0)
                    {
                        yield return new FixedSizePage<TResource>(items, _pageManager.GetNextPageToken(enumerator.Current));
                    }
                }
            }
        }

        private class ResponseEnumerator : IResponseEnumerator<TResponse>
        {
            private readonly TRequest _request; // This is mutated during iteration
            private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;
            private bool _finished;

            public ResponseEnumerator(TRequest request, IPageManager<TRequest, TResponse, TResource> pageManager)
            {
                _request = request;
                _pageManager = pageManager;
            }

            public TResponse Current { get; private set; }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (_finished)
                {
                    return false;
                }
                Current = _request.Execute();
                var nextPageToken = _pageManager.GetNextPageToken(Current);
                if (nextPageToken == null)
                {
                    _finished = true;
                }
                // Prepare the next request...
                _pageManager.SetPageToken(_request, nextPageToken);
                return true;
            }

            public bool MoveNext(int pageSize)
            {
                _pageManager.SetPageSize(_request, pageSize);
                return MoveNext();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose() { }
        }
    }
}
