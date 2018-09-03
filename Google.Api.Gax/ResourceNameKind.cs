/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax
{
    /// <summary>
    /// The kind of resource name.
    /// </summary>
    public enum ResourceNameKind
    {
        /// <summary>
        /// A simple, well-typed, resource name. 
        /// </summary>
        Simple,

        /// <summary>
        /// One of a selection of resource names.
        /// </summary>
        Oneof,

        /// <summary>
        /// A fixed string instead of a resource name.
        /// </summary>
        Fixed,

        /// <summary>
        /// A <see cref="TemplatedResourceName"/>.  
        /// </summary>
        Templated,

        /// <summary>
        /// An <see cref="UnknownResourceName"/>. 
        /// </summary>
        Unknown,
    }
}
