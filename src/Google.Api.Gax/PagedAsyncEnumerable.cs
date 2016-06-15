/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    public sealed class PagedAsyncEnumerable<TRequest, TResponse, TResource> : IPagedAsyncEnumerable<TResponse, TResource>
        where TRequest : class, IPageRequest, IMessage<TRequest>
        where TResponse : class, IPageResponse<TResource>, IMessage<TResponse>
    {
        private readonly CallSettings _callSettings;
        private readonly TRequest _request;
        private readonly ApiCall<TRequest, TResponse> _apiCall;

        public PagedAsyncEnumerable(ApiCall<TRequest, TResponse> apiCall,
            TRequest request, CallSettings callSettings)
        {
            _callSettings = callSettings;
            _request = request;
            _apiCall = apiCall;
        }

        private PagedAsyncEnumerator GetPagedEnumerator() => new PagedAsyncEnumerator(_callSettings, _request.Clone(), _apiCall);

        /// <inheritdoc />
        public IAsyncEnumerable<TResponse> AsPages() => new PageAsyncEnumerable(this);

        /// <inheritdoc />
        public IAsyncEnumerator<TResource> GetEnumerator() => AsPages().SelectMany(page => page.ToAsyncEnumerable()).GetEnumerator();

        /// <inheritdoc />
        public IAsyncEnumerable<FixedSizePage<TResource>> AsFixedSizePages(int pageSize) =>
            new FixedPageSizeAsyncEnumerable(this, pageSize);

        private class PageAsyncEnumerable : IAsyncEnumerable<TResponse>
        {
            private readonly PagedAsyncEnumerable<TRequest, TResponse, TResource> _source;

            internal PageAsyncEnumerable(PagedAsyncEnumerable<TRequest, TResponse, TResource> source)
            {
                _source = source;
            }

            public IAsyncEnumerator<TResponse> GetEnumerator() => _source.GetPagedEnumerator();
        }

        private class PagedAsyncEnumerator : IAsyncEnumerator<TResponse>
        {
            private readonly CallSettings _callSettings;
            private readonly ApiCall<TRequest, TResponse> _apiCall;
            private readonly TRequest _request; // This is mutated during iteration
            private bool _finished;

            public PagedAsyncEnumerator(CallSettings callSettings,
                TRequest request, ApiCall<TRequest, TResponse> apiCall)
            {
                _callSettings = callSettings;
                _request = request;
                _apiCall = apiCall;
            }

            public TResponse Current { get; private set; }

            public async Task<bool> MoveNext(CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (_finished)
                {
                    return false;
                }
                CallSettings effectiveCallSettings = _callSettings;
                if (cancellationToken != default(CancellationToken))
                {
                    effectiveCallSettings = new CallSettings(_callSettings) { CancellationToken = cancellationToken };
                }
                Current = await _apiCall.Async(_request, effectiveCallSettings);
                var nextPageToken = Current.NextPageToken;
                if (nextPageToken == "")
                {
                    _finished = true;
                }
                // Prepare the next request...
                _request.PageToken = nextPageToken;
                return true;
            }

            public Task<bool> MoveNext(int pageSize, CancellationToken cancellationToken)
            {
                _request.PageSize = pageSize;
                return MoveNext(cancellationToken);
            }

            public void Dispose() { }
        }

        private class FixedPageSizeAsyncEnumerable : IAsyncEnumerable<FixedSizePage<TResource>>
        {
            private readonly PagedAsyncEnumerable<TRequest, TResponse, TResource> _source;
            private readonly int _pageSize;

            internal FixedPageSizeAsyncEnumerable(
                PagedAsyncEnumerable<TRequest, TResponse, TResource> source, int pageSize)
            {
                _source = source;
                _pageSize = pageSize;
            }

            public IAsyncEnumerator<FixedSizePage<TResource>> GetEnumerator() =>
                new Enumerator(_source.GetPagedEnumerator(), _pageSize);

            private class Enumerator : IAsyncEnumerator<FixedSizePage<TResource>>
            {
                private readonly PagedAsyncEnumerator _enumerator;
                private readonly int _pageSize;

                internal Enumerator(
                    PagedAsyncEnumerator enumerator, int pageSize)
                {
                    _enumerator = enumerator;
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
                        items.AddRange(_enumerator.Current);
                        if (items.Count > _pageSize)
                        {
                            // TODO: Better exception type?
                            throw new NotSupportedException("Invalid server response: " +
                                $"requested {requestCount} items, received {_enumerator.Current.Count()} items");
                        }
                    }
                    if (items.Count != 0)
                    {
                        Current = new FixedSizePage<TResource>(items, _enumerator.Current.NextPageToken);
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
