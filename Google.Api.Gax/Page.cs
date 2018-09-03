/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections;
using System.Collections.Generic;

namespace Google.Api.Gax
{
    /// <summary>
    /// A page of resources which will only have fewer results than requested if
    /// there is no more data to fetch.
    /// </summary>
    /// <typeparam name="TResource">The type of resource within the page.</typeparam>
    public sealed class Page<TResource> : IEnumerable<TResource>
    {
        private readonly IEnumerable<TResource> _resources;

        /// <summary>
        /// The page token to use to fetch the next set of resources.
        /// </summary>
        /// <remarks>
        /// gRPC-based APIs use an empty string as a "no page token", whereas REST-based APIs
        /// use a null reference instead. The value here will be consistent with the value returned
        /// by the API itself.
        /// </remarks>
        public string NextPageToken { get; }

        /// <summary>
        /// Constructs a fixed-size page from the given resource sequence and page token.
        /// </summary>
        /// <param name="resources">The resources in the page.</param>
        /// <param name="nextPageToken">The next page token.</param>
        public Page(IEnumerable<TResource> resources, string nextPageToken)
        {
            _resources = resources;
            NextPageToken = nextPageToken;
        }

        /// <inheritdoc />
        public IEnumerator<TResource> GetEnumerator() => _resources.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
