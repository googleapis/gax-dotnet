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

namespace Google.Api.Gax.Rest
{
    public sealed class PagedEnumerable<TRequest, TResponse, TResource> : IPagedEnumerable<TResponse, TResource>
        where TRequest : class, IClientServiceRequest<TResponse>
        where TResponse : class
    {
        private readonly Func<TRequest> _requestProvider;
        private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;

        public PagedEnumerable(Func<TRequest> requestProvider,
            IPageManager<TRequest, TResponse, TResource> pageManager)
        {
            _requestProvider = GaxRestPreconditions.CheckNotNull(requestProvider, nameof(requestProvider));
            _pageManager = GaxRestPreconditions.CheckNotNull(pageManager, nameof(pageManager));
        }

        public IPagedEnumerator<TResponse> GetEnumerator() => new PagedEnumerator(_requestProvider(), _pageManager);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<TResponse> IEnumerable<TResponse>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public IEnumerable<TResource> Flatten() => this.SelectMany(page => _pageManager.GetResourcesEmptyIfNull(page));

        /// <inheritdoc />
        public IEnumerable<FixedSizePage<TResource>> WithFixedPageSize(int pageSize)
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

        private class PagedEnumerator : IPagedEnumerator<TResponse>
        {
            private readonly TRequest _request; // This is mutated during iteration
            private readonly IPageManager<TRequest, TResponse, TResource> _pageManager;
            private bool _finished;

            public PagedEnumerator(TRequest request, IPageManager<TRequest, TResponse, TResource> pageManager)
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
