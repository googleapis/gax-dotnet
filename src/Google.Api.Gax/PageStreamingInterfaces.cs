﻿/*
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
    public interface IPagedAsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        new IPagedAsyncEnumerator<T> GetEnumerator();
    }

    public interface IPagedAsyncEnumerable<TResponse, TResource> : IPagedAsyncEnumerable<TResponse>
    {
        /// <summary>
        /// Flattens this asynchronous sequence of "pages of resources" to an asynchronous sequence of resources.
        /// </summary>
        /// <remarks>
        /// This is expected to be equivalent to calling <c>SelectMany(page => page.ToAsyncEnumerable())</c>, and could
        /// be implemented as an extension method, but is part of the interface to provide greater discoverability.
        /// </remarks>
        /// <returns>A sequence of resources.</returns>
        IAsyncEnumerable<TResource> Flatten();

        /// <summary>
        /// Returns an asynchronous sequence of fixed-size pages, so that only the final page returned can have fewer items than
        /// <paramref name="pageSize"/>. API requests are made appropriately to ensure that the page token returned at
        /// the end of each page reflects exactly that page boundary; this may entail more API requests than iterating
        /// over the sequence without enforcing fixed page sizes.
        /// </summary>
        /// <param name="pageSize">The size of the pages to return. Must be positive.</param>
        /// <remarks>
        /// This could be implemented as an extension method, but is part of the interface to provide greater discoverability.
        /// </remarks>
        /// <returns>A sequence of fixed-size pages.</returns>
        IAsyncEnumerable<FixedSizePage<TResource>> WithFixedPageSize(int pageSize);
    }

    public interface IPagedAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        Task<bool> MoveNext(int pageSize, CancellationToken cancellationToken);
    }

    public interface IPagedEnumerable<T> : IEnumerable<T>
    {
        new IPagedEnumerator<T> GetEnumerator();
    }

    public interface IPagedEnumerable<TResponse, TResource> : IPagedEnumerable<TResponse>
    {
        /// <summary>
        /// Flattens this sequence of "pages of resources" to a sequence of resources.
        /// </summary>
        /// <remarks>
        /// This is expected to be equivalent to calling <c>SelectMany(page => page)</c>, and could
        /// be implemented as an extension method, but is part of the interface to provide greater discoverability.
        /// </remarks>
        /// <returns>A sequence of resources.</returns>
        IEnumerable<TResource> Flatten();

        /// <summary>
        /// Returns a sequence of fixed-size pages, so that only the final page returned can have fewer items than
        /// <paramref name="pageSize"/>. API requests are made appropriately to ensure that the page token returned at
        /// the end of each page reflects exactly that page boundary; this may entail more API requests than iterating
        /// over the sequence without enforcing fixed page sizes.
        /// </summary>
        /// <param name="pageSize">The size of the pages to return. Must be positive.</param>
        /// <remarks>
        /// This could be implemented as an extension method, but is part of the interface to provide greater discoverability.
        /// </remarks>
        /// <returns>A sequence of fixed-size pages.</returns>
        IEnumerable<FixedSizePage<TResource>> WithFixedPageSize(int pageSize);
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
