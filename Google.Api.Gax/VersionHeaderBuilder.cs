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
using System.Runtime.Versioning;

namespace Google.Api.Gax
{
    // Note: this code is now duplicated in Google.Apis.
    // The duplication is annoying, but hard to avoid due to dependencies.
    // Any changes should be made in both places.

    /// <summary>
    /// Helps build version strings for the x-goog-api-client header.
    /// The value is a space-separated list of name/value pairs, where the value
    /// should be a semantic version string. Names must be unique.
    /// </summary>
    public sealed class VersionHeaderBuilder
    {
        private static readonly Lazy<string> s_environmentVersion = new Lazy<string>(GetEnvironmentVersion);

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
        /// <param name="version">The version. Must not be null, or contain a space or a slash.</param>
        public VersionHeaderBuilder AppendVersion(string name, string version)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            GaxPreconditions.CheckNotNull(version, nameof(version));
            // Names can't be empty, but versions can. (We use the empty string to indicate an unknown version.)
            GaxPreconditions.CheckArgument(name.Length > 0 && IsHeaderNameValueValid(name), nameof(name), $"Invalid name: {name}");
            GaxPreconditions.CheckArgument(IsHeaderNameValueValid(version), nameof(version), $"Invalid version: {version}");
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
        public VersionHeaderBuilder AppendDotNetEnvironment() => AppendVersion("gl-dotnet", s_environmentVersion.Value);
        
        /// <summary>
        /// Whether the name or value that are supposed to be included in a header are valid
        /// </summary>
        private static bool IsHeaderNameValueValid(string nameOrValue) => 
            !nameOrValue.Contains(" ") && !nameOrValue.Contains("/");

        private static string GetEnvironmentVersion()
        {
            // We can pick between the version reported by System.Environment.Version, or the version in the
            // entry assembly, if any. Neither gives us exactly what we might want, 
            string systemEnvironmentVersion =
#if NETSTANDARD1_3
                null;
#else
                FormatVersion(Environment.Version);
#endif
            string entryAssemblyVersion = GetEntryAssemblyVersionOrNull();

            return entryAssemblyVersion ?? systemEnvironmentVersion ?? "";
        }

        private static string GetEntryAssemblyVersionOrNull()
        {
            try
            {
                // Assembly.GetEntryAssembly() isn't available in netstandard1.3. Attempt to fetch it with reflection, which is ugly but should work.
                // This is a slightly more robust version of the code we previously used in Microsoft.Extensions.PlatformAbstractions.
                var getEntryAssemblyMethod = typeof(Assembly)
                    .GetTypeInfo()
                    .DeclaredMethods
                    .Where(m => m.Name == "GetEntryAssembly" && m.IsStatic && m.GetParameters().Length == 0 && m.ReturnType == typeof(Assembly))
                    .FirstOrDefault();
                if (getEntryAssemblyMethod == null)
                {
                    return null;
                }
                Assembly entryAssembly = (Assembly)getEntryAssemblyMethod.Invoke(null, new object[0]);
                var frameworkName = entryAssembly?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
                return frameworkName == null ? null : FormatVersion(new FrameworkName(frameworkName).Version);
            }
            catch
            {
                // If we simply can't get the version for whatever reason, don't fail.
                return null;
            }
        }
        
        private static string FormatAssemblyVersion(System.Type type)
        {
            // Prefer AssemblyInformationalVersion, then AssemblyFileVersion,
            // then AssemblyVersion.

            var assembly = type.GetTypeInfo().Assembly;
            var info = assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion;
            if (info != null && IsHeaderNameValueValid(info)) // Skip informational version if it's not a valid header value
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
