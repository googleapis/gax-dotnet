/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Linq;
using System.Reflection;

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// Common code used for building user agents in REST libraries.
    /// </summary>
    public static class UserAgentHelper
    {
        /// <summary>
        /// Formats a user agent suitable for REST client libraries.
        /// </summary>
        /// <param name="type">The type to extract the version number from.</param>
        /// <returns>A user agent value.</returns>
        public static string GetDefaultUserAgent(Type type) => $"gcloud-dotnet/{FormatAssemblyVersion(type)}";

        private static string FormatAssemblyVersion(System.Type type)
        {
            // Prefer AssemblyInformationalVersion, then AssemblyFileVersion,
            // then AssemblyVersion.

            var assembly = type.GetTypeInfo().Assembly;
            var info = assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion;
            if (info != null)
            {
                return info;
            }
            var file = assembly.GetCustomAttributes<AssemblyFileVersionAttribute>().FirstOrDefault()?.Version;
            if (file != null)
            {
                return string.Join(".", file.Split('.').Take(3));
            }
            var version = assembly.GetName().Version;
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}
