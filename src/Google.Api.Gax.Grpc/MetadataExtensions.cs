/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc
{
    internal static class MetadataExtensions
    {
        public static void Add(this Metadata metadata, IEnumerable<Metadata.Entry> items)
        {
            foreach (var item in items)
            {
                metadata.Add(item);
            }
        }

        public static Metadata Clone(this Metadata metadata) =>
            metadata.IsReadOnly ? metadata : new Metadata { metadata };

        public static Metadata WithVersionHeader(this Metadata metadata, string versionHeader)
        {
            metadata = metadata.Clone();
            metadata.Add(VersionHeaderBuilder.HeaderName, versionHeader);
            return metadata;
        }
    }
}
