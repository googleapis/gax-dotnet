/*
 * Copyright 2017 Google Inc. All Rights Reserved.
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
    /// Helps build version strings for the x-goog-api-client header.
    /// The value is a space-separated list of name/value pairs, where the value
    /// should be a semantic version string. Names must be unique.
    /// </summary>
    public sealed class VersionHeaderBuilder
    {
        /// <summary>
        /// The name of the header to set.
        /// </summary>
        public const string HeaderName = "x-goog-api-client";
        private readonly List<string> _names = new List<string>();
        private readonly List<string> _values = new List<string>();

        /// <summary>
        /// Appends the given name/version string to the list.
        /// </summary>
        /// <param name="name">The name. Must not be null or empty, or contain a space or a slash.</param>
        /// <param name="version">The version. Must not be null or empty, or contain a space or a slash.</param>
        public VersionHeaderBuilder AppendVersion(string name, string version)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            GaxPreconditions.CheckNotNull(version, nameof(version));
            // Deliberate duplication as we may want to have different constraints.
            GaxPreconditions.CheckArgument(name.Length > 0 && !name.Contains(' ') && !name.Contains('/'), nameof(name), $"Invalid name: {name}");
            GaxPreconditions.CheckArgument(version.Length > 0 && !version.Contains(' ') && !version.Contains('/'), nameof(version), $"Invalid version: {version}");
            GaxPreconditions.CheckArgument(!_names.Contains(name), nameof(name), "Names in version headers must be unique");
            _names.Add(name);
            _values.Add(version);
            return this;
        }

        /// <summary>
        /// Appends a name/version string, taking the version from the version of the assembly
        /// containing the given type.
        /// </summary>
        public VersionHeaderBuilder AppendAssemblyVersion(string name, System.Type type)
            => AppendVersion(name, FormatAssemblyVersion(type));

        /// <summary>
        /// Appends the .NET environment information to the list.
        /// </summary>
        public VersionHeaderBuilder AppendDotNetEnvironment()
#if NETSTANDARD1_3
            => AppendVersion("gl-dotnet", FormatVersion(Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default?.Application?.RuntimeFramework?.Version));
#else
            => AppendVersion("gl-dotnet", FormatVersion(Environment.Version));
#endif

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
            return FormatVersion(assembly.GetName().Version);
        }

        private static string FormatVersion(Version version) =>
            version != null ?
            $"{version.Major}.{version.Minor}.{(version.Build != -1 ? version.Build : 0)}" :
            ""; // Empty string means "unknown"

        /// <inheritdoc />
        public override string ToString() => string.Join(" ", _names.Zip(_values, (name, value) => $"{name}/{value}"));

        /// <summary>
        /// Clones this VersionHeaderBuilder, creating an independent copy with the same names/values.
        /// </summary>
        /// <returns>A clone of this builder.</returns>
        public VersionHeaderBuilder Clone()
        {
            var ret = new VersionHeaderBuilder();
            ret._names.AddRange(_names);
            ret._values.AddRange(_values);
            return ret;
        }
    }
}
