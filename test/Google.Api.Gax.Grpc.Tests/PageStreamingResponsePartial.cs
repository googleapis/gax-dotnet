/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections;
using System.Collections.Generic;

// Namespace of gRPC codegen
namespace Google.Api.Gax.Grpc
{
    public partial class PageStreamingResponse : IPageResponse<int>
    {
        public IEnumerator<int> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
