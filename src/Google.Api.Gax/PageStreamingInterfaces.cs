/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    public interface IPagedAsyncEnumerable<TResponse, TResource> : IAsyncEnumerable<TResource>
    {
        /// <summary>
        /// Returns the sequence of pages as they are obtained from the underlying API. The individual
        /// resources can be retrieved from each page, along with additional information.
        /// </summary>
        /// <remarks>
        /// The underlying API may not fill pages in all cases. For example, with a requested page size of
        /// 100, it is possible for an API to return 80 results in a page but still have more pages to
        /// return. If your application needs guarantees around the sizes of retrieved pages, use
        /// <see cref="AsFixedSizePages"/>.
        /// </remarks>
        /// <returns>A sequence of responses, each containing a page of results.</returns>
        IAsyncEnumerable<TResponse> AsPages();

        /// <summary>
        /// Returns a sequence of fixed-size pages, so that only the final page returned can have fewer items than
        /// <paramref name="pageSize"/>. API requests are made appropriately to ensure that the page token returned at
        /// the end of each page reflects exactly that page boundary; this may entail more API requests than iterating
        /// over the sequence without enforcing fixed page sizes.
        /// </summary>
        /// <param name="pageSize">The size of the pages to return. Must be positive.</param>
        /// <returns>A sequence of fixed-size pages.</returns>
        IAsyncEnumerable<FixedSizePage<TResource>> AsFixedSizePages(int pageSize);
    }

    public interface IPagedEnumerable<TResponse, TResource> : IEnumerable<TResource>
    {
        /// <summary>
        /// Returns the sequence of pages as they are obtained from the underlying API. The individual
        /// resources can be retrieved from each page, along with additional information.
        /// </summary>
        /// <remarks>
        /// The underlying API may not fill pages in all cases. For example, with a requested page size of
        /// 100, it is possible for an API to return 80 results in a page but still have more pages to
        /// return. If your application needs guarantees around the sizes of retrieved pages, use
        /// <see cref="AsFixedSizePages"/>.
        /// </remarks>
        /// <returns>A sequence of responses, each containing a page of results.</returns>
        IEnumerable<TResponse> AsPages();

        /// <summary>
        /// Returns a sequence of fixed-size pages, so that only the final page returned can have fewer items than
        /// <paramref name="pageSize"/>. API requests are made appropriately to ensure that the page token returned at
        /// the end of each page reflects exactly that page boundary; this may entail more API requests than iterating
        /// over the sequence without enforcing fixed page sizes.
        /// </summary>
        /// <param name="pageSize">The size of the pages to return. Must be positive.</param>
        /// <returns>A sequence of fixed-size pages.</returns>
        IEnumerable<FixedSizePage<TResource>> AsFixedSizePages(int pageSize);
    }

    public interface IPagedEnumerator<T> : IEnumerator<T>
    {
        bool MoveNext(int pageSize);
    }

    public interface IPageRequest
    {
        string PageToken { set; }
        int PageSize { set; }
    }

    public interface IPageResponse<TResource> : IEnumerable<TResource>
    {
        string NextPageToken { get; }
    }
}
