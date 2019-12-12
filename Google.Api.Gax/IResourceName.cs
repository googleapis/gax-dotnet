/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax
{
    /// <summary>
    /// A resource name.
    /// </summary>
    public interface IResourceName
    {
        /// <summary>
        /// Whether this instance contains a resource name with a known pattern.
        /// </summary>
        bool IsKnownPattern { get; }

        /// <summary>
        /// The string representation of the resource name.
        /// </summary>
        /// <returns>The string representation of the resource name.</returns>
        string ToString();
    }
}
