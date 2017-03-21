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

        /// <summary>
        /// Creates a request modifier which sets the Google-specific version header in HTTP requests.
        /// </summary>
        /// <param name="type">The type to extract the version number from.</param>
        /// <returns>A request modifier.</returns>
        public static Action<HttpRequestMessage> CreateRequestModifier(Type type)
        {
            var value = new VersionHeaderBuilder()
                .AppendDotNetEnvironment()
                .AppendAssemblyVersion("gccl", type)
                .AppendAssemblyVersion("gax", typeof(UserAgentHelper))
                .ToString();
            return request =>
            {
                request.Headers.Remove(VersionHeaderBuilder.HeaderName);
                request.Headers.Add(VersionHeaderBuilder.HeaderName, value);
            };
        }
    }
}
