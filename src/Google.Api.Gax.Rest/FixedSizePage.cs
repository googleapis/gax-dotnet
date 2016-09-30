/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections;
using System.Collections.Generic;

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// A page of resources which will only have fewer results than requested if
    /// there is no more data to fetch.
    /// </summary>
    /// <typeparam name="TResource">The type of resource within the page.</typeparam>
    public sealed class FixedSizePage<TResource> : IEnumerable<TResource>
    {
        private readonly IEnumerable<TResource> _resources;

        /// <inheritdoc />
        public string NextPageToken { get; }

        /// <summary>
        /// Constructs a fixed-size page from the given resource sequence and page token.
        /// </summary>
        /// <param name="resources">The resources in the page.</param>
        /// <param name="nextPageToken">The next page token.</param>
        public FixedSizePage(IEnumerable<TResource> resources, string nextPageToken)
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
