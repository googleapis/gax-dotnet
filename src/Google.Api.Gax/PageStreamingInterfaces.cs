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
    public interface IPagedAsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        new IPagedAsyncEnumerator<T> GetEnumerator();
    }

    public interface IPagedAsyncEnumerable<TResponse, TResource> : IPagedAsyncEnumerable<TResponse>
    {
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
