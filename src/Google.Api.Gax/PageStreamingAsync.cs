/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// Interfaces and implementations of asynchronous page streaming. These are gathered into a single file
// for convenience.

namespace Google.Api.Gax
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
}
