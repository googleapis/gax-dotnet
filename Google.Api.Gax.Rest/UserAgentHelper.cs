/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Net.Http;

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// Common code used for building user agents and related headers in REST libraries.
    /// </summary>
    public static class UserAgentHelper
    {
        /// <summary>
        /// Formats a user agent suitable for REST client libraries.
        /// </summary>
        /// <param name="type">The type to extract the version number from.</param>
        /// <returns>A user agent value.</returns>
        public static string GetDefaultUserAgent(Type type) => new VersionHeaderBuilder().AppendAssemblyVersion("gcloud-dotnet", type).ToString();
    }
}
