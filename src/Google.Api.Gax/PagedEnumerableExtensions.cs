/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    public static class PagedEnumerableExtensions
    {
        public static IEnumerable<TResource> Flatten<TResponse, TResource>(
            this IPagedEnumerable<TResponse, TResource> source)
            where TResponse : IEnumerable<TResource> =>
            source.SelectMany(page => page);

        public static IAsyncEnumerable<TResource> Flatten<TResponse, TResource>(
            this IPagedAsyncEnumerable<TResponse, TResource> source)
            where TResponse : IEnumerable<TResource> =>
            source.SelectMany(page => page.ToAsyncEnumerable());

        private class FixedPageSizeAsyncEnumerable<TResponse, TResource> : IAsyncEnumerable<FixedSizePage<TResource>>
            where TResponse : IPageResponse<TResource>
        {
            private readonly IPagedAsyncEnumerable<TResponse, TResource> _source;
            private readonly int _pageSize;

            internal FixedPageSizeAsyncEnumerable(
                IPagedAsyncEnumerable<TResponse, TResource> source, int pageSize)
            {
                _source = source;
                _pageSize = pageSize;
            }

            public IAsyncEnumerator<FixedSizePage<TResource>> GetEnumerator() =>
                new Enumerator(_source.GetEnumerator(), _pageSize);

            private class Enumerator : IAsyncEnumerator<FixedSizePage<TResource>>
            {
                private readonly IPagedAsyncEnumerator<TResponse> _enumerator;
                private readonly int _pageSize;

                internal Enumerator(
                    IPagedAsyncEnumerator<TResponse> enumerator, int pageSize)
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

                public void Dispose() {
                    _enumerator.Dispose();
                }
            }
        }

        public static IAsyncEnumerable<FixedSizePage<TResource>> WithFixedPageSize<TResponse, TResource>(
            this IPagedAsyncEnumerable<TResponse, TResource> source, int pageSize)
            where TResponse : IPageResponse<TResource> =>
            new FixedPageSizeAsyncEnumerable<TResponse, TResource>(source, pageSize);

        public static IEnumerable<FixedSizePage<TResource>> WithFixedPageSize<TResponse, TResource>(
            this IPagedEnumerable<TResponse, TResource> source, int pageSize)
            where TResponse : IPageResponse<TResource>
        {
            GaxPreconditions.CheckNotNull(source, nameof(source));
            GaxPreconditions.CheckArgument(pageSize > 0, nameof(pageSize), "Must be greater than 0");
            using (var enumerator = source.GetEnumerator())
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
                        items.AddRange(enumerator.Current);
                        if (items.Count > pageSize)
                        {
                            throw new NotSupportedException("Invalid server response: " +
                                $"requested {requestCount} items, received {enumerator.Current.Count()} items");
                        }
                    }
                    if (items.Count != 0)
                    {
                        yield return new FixedSizePage<TResource>(items, enumerator.Current.NextPageToken);
                    }
                }
            }
        }
    }
}
