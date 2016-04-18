/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Google.Api.Gax
{
    /// <summary>
    /// Helps build user agent strings for the X-Goog-Api-Client header.
    /// Our user agent is a space-separated list of name/value pairs, where the value
    /// should be a semantic version string.
    /// </summary>
    internal sealed class UserAgentBuilder
    {
        /// <summary>
        /// The name of the header to set in gRPC calls.
        /// </summary>
        internal const string HeaderName = "X-Goog-Api-Client";
        private readonly List<string> _values = new List<string>();

        /// <summary>
        /// Appends the given name/version string to the list.
        /// </summary>
        internal UserAgentBuilder AppendVersion(string name, string version)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            GaxPreconditions.CheckNotNull(version, nameof(version));
            _values.Add($"{name}/{version}");
            return this;
        }

        /// <summary>
        /// Appends a name/version string, taking the version from the version of the assembly
        /// containing the given type.
        /// </summary>
        internal UserAgentBuilder AppendAssemblyVersion(string name, System.Type type)
            => AppendVersion(name, FormatAssemblyVersion(type));

        // TODO: This probably won't work as-is on .NET Core.
        /// <summary>
        /// Appends the .NET environment information to the list.
        /// </summary>
        internal UserAgentBuilder AppendDotNetEnvironment()
            => AppendVersion("dotnet", FormatVersion(Environment.Version));

        private static string FormatAssemblyVersion(System.Type type)
        {
            // Prefer AssemblyInformationalVersion, then AssemblyFileVersion,
            // then AssemblyVersion.

            var assembly = type.Assembly;
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
            return FormatVersion(type.Assembly.GetName().Version);
        }

        private static string FormatVersion(Version version) => $"{version.Major}.{version.Minor}.{version.Build}";

        public override string ToString() => string.Join(" ", _values);
    }
}
