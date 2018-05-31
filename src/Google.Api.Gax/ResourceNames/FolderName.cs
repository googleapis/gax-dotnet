/*
 * Copyright 2018 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.ResourceNames
{
    /// <summary>
    /// Resource name for the 'folder' resource which is widespread across Google Cloud Platform.
    /// While most resource names are generated on a per-API basis, many APIs use a folder resource, and it's
    /// useful to be able to pass values from one API to another.
    /// </summary>
    public sealed partial class FolderName : IResourceName, IEquatable<FolderName>
    {
        private static readonly PathTemplate s_template = new PathTemplate("folders/{folder}");

        /// <summary>
        /// Parses the given folder resource name in string form into a new
        /// <see cref="FolderName"/> instance.
        /// </summary>
        /// <param name="folderName">The folder resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="FolderName"/> if successful.</returns>
        public static FolderName Parse(string folderName)
        {
            GaxPreconditions.CheckNotNull(folderName, nameof(folderName));
            TemplatedResourceName resourceName = s_template.ParseName(folderName);
            return new FolderName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given folder resource name in string form into a new
        /// <see cref="FolderName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="s::ArgumentNullException"/> if <paramref name="folderName"/> is null,
        /// as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="folderName">The folder resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">When this method returns, the parsed <see cref="FolderName"/>,
        /// or <c>null</c> if parsing fails.</param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string folderName, out FolderName result)
        {
            GaxPreconditions.CheckNotNull(folderName, nameof(folderName));
            TemplatedResourceName resourceName;
            if (s_template.TryParseName(folderName, out resourceName))
            {
                result = new FolderName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="FolderName"/> resource name class
        /// from its component parts.
        /// </summary>
        /// <param name="folderId">The folder ID. Must not be <c>null</c>.</param>
        public FolderName(string folderId)
        {
            FolderId = GaxPreconditions.CheckNotNull(folderId, nameof(folderId));
        }

        /// <summary>
        /// The folder ID. Never <c>null</c>.
        /// </summary>
        public string FolderId { get; }

        /// <inheritdoc />
        public ResourceNameKind Kind => ResourceNameKind.Simple;

        /// <inheritdoc />
        public override string ToString() => s_template.Expand(FolderId);

        /// <inheritdoc />
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as FolderName);

        /// <inheritdoc />
        public bool Equals(FolderName other) => ToString() == other?.ToString();

        /// <inheritdoc />
        public static bool operator ==(FolderName a, FolderName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc />
        public static bool operator !=(FolderName a, FolderName b) => !(a == b);
    }
}
