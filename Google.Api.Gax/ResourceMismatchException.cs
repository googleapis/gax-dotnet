/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Exception used to indicate that an attempt was made to get or create a resource,
    /// and the retrieved resource did not match the expected constraints.
    /// </summary>
    public class ResourceMismatchException : Exception
    {
        /// <summary>
        /// Constructs a new instance of the exception.
        /// </summary>
        /// <param name="message">The error message for the exception.</param>
        public ResourceMismatchException(string message) : base(message)
        {
        }
    }
}
