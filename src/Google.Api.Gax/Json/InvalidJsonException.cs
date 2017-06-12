/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.IO;

namespace Google.Api.Gax.Json
{
    // Note: this is internal for the moment, allowing us to commit it without exposing it until
    // we're ready. Libraries using this will temporarily use InternalsVisibleTo to access it, but that
    // will be removed before they are fully released (by which point this type must be public).

    /// <summary>
    /// Thrown when an attempt is made to parse invalid JSON, e.g. using
    /// a non-string property key, or including a redundant comma.
    /// </summary>
    internal sealed class InvalidJsonException : IOException
    {
        internal InvalidJsonException(string message)
            : base(message)
        {
        }
    }
}