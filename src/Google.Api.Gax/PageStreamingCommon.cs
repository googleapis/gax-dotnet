/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;

// Interfaces used by both synchronous and asynchronous page streaming.

namespace Google.Api.Gax
{
    /// <summary>
    /// A request for a page-streaming operation.
    /// </summary>
    public interface IPageRequest
    {
        /// <summary>
        /// A token indicating the page to return. This is obtained from an earlier response,
        /// via <see cref="IPageResponse{TResource}.NextPageToken"/>.
        /// </summary>
        string PageToken { set; }

        /// <summary>
        /// The maximum number of elements to return in the response.
        /// </summary>
        int PageSize { set; }
    }

    // TODO: Consider having a Resources property instead of this implementing IEnumerable<TResource>.

    /// <summary>
    /// A response in a page-streaming operation.
    /// </summary>
    /// <typeparam name="TResource">The type of resource contained in the response.</typeparam>
    public interface IPageResponse<TResource> : IEnumerable<TResource>
    {
        /// <summary>
        /// The token to set in the <see cref="IPageRequest.PageToken"/> when requesting
        /// the next page of results.
        /// </summary>
        string NextPageToken { get; }
    }
}
