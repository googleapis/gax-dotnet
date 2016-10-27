/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.Api.Gax
{
    /// <summary>
    /// A sequence of resources obtained via API responses, each of which contributes a page of resources.
    /// Application code can treat this as a simple sequence (with API calls automatically being made
    /// lazily as more results are required), or call <see cref="AsRawResponses"/> to retrieve
    /// a page at a time, potentially with additional information.
    /// </summary>
    /// <typeparam name="TResponse">The API response type. Each response contains a page of resources.</typeparam>
    /// <typeparam name="TResource">The resource type contained within the response.</typeparam>
    public abstract class PagedEnumerable<TResponse, TResource> : IEnumerable<TResource>
    {
        /// <summary>
        /// Returns the sequence of raw API responses, each of which contributes a page of
        /// resources to this sequence.
        /// </summary>
        /// <returns>A sequence of raw API responses, each containing a page of resources.</returns>
        public virtual IEnumerable<TResponse> AsRawResponses()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously reads a single page of results with a fixed maximum size. The returned page is guaranteed
        /// to have that many results, unless there is no more data available.
        /// </summary>
        /// <remarks>
        /// "Natural" pages returned by the API may contain a smaller number of resources than requested.
        /// For example, a request for a page with 100 resources may return a page with 80 resources but
        /// a next page token for more to be retrieved. This is suitable for batch-processing, but not
        /// for user-visible paging such as in a web application, where fixed-size pages are expected.
        /// This method may make more than one API call in order to fill the page.
        /// </remarks>
        /// <param name="pageSize">The page size. Must be greater than 0.</param>
        /// <returns>An asynchronous operation, the result of which is a page of resources.</returns>
        public virtual Page<TResource> ReadPage(int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual IEnumerator<TResource> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
