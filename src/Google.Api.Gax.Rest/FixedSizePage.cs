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
    public sealed class FixedSizePage<TResource> : IEnumerable<TResource>
    {
        private readonly IEnumerable<TResource> _resources;
        public string NextPageToken { get; }

        public FixedSizePage(IEnumerable<TResource> resources, string nextPageToken)
        {
            _resources = resources;
            NextPageToken = nextPageToken;
        }

        public IEnumerator<TResource> GetEnumerator() => _resources.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
