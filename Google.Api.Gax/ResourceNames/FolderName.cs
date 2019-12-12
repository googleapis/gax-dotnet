/*
 * Copyright 2018 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using gax = Google.Api.Gax;
using sys = System;

namespace Google.Api.Gax.ResourceNames
{
    /// <summary>
    /// Resource name for the 'folder' resource which is widespread across Google Cloud Platform.
    /// While most resource names are generated on a per-API basis, many APIs use a folder resource, and it's
    /// useful to be able to pass values from one API to another.
    /// </summary>
    public sealed partial class FolderName : gax::IResourceName, sys::IEquatable<FolderName>
    {
        /// <summary>The possible contents of <see cref="FolderName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource name with pattern <c>folders/{folder}</c>.</summary>
            Folder = 1
        }

        private static gax::PathTemplate s_folder = new gax::PathTemplate("folders/{folder}");

        /// <summary>Creates a <see cref="FolderName"/> containing an unknown resource name.</summary>
        /// <param name="unknownResourceName">The unknown resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="FolderName"/> containing the provided <paramref name="unknownResourceName"/>.
        /// </returns>
        public static FolderName FromUnknown(gax::UnknownResourceName unknownResourceName) =>
            new FolderName(ResourceNameType.Unknown, gax::GaxPreconditions.CheckNotNull(unknownResourceName, nameof(unknownResourceName)));

        /// <summary>Creates a <see cref="FolderName"/> with the pattern <c>folders/{folder}</c>.</summary>
        /// <param name="folderId">The <c>Folder</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="FolderName"/> constructed from the provided ids.</returns>
        public static FolderName FromFolder(string folderId) =>
            new FolderName(ResourceNameType.Folder, folderId: gax::GaxPreconditions.CheckNotNullOrEmpty(folderId, nameof(folderId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="FolderName"/> with pattern
        /// <c>folders/{folder}</c>.
        /// </summary>
        /// <param name="folderId">The <c>Folder</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="FolderName"/> with pattern <c>folders/{folder}</c>.
        /// </returns>
        public static string Format(string folderId) => FormatFolder(folderId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="FolderName"/> with pattern
        /// <c>folders/{folder}</c>.
        /// </summary>
        /// <param name="folderId">The <c>Folder</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="FolderName"/> with pattern <c>folders/{folder}</c>.
        /// </returns>
        public static string FormatFolder(string folderId) =>
            s_folder.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(folderId, nameof(folderId)));

        /// <summary>Parses the given resource name string into a new <see cref="FolderName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>folders/{folder}</c></description></item></list>
        /// </remarks>
        /// <param name="folderName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="FolderName"/> if successful.</returns>
        public static FolderName Parse(string folderName) => Parse(folderName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="FolderName"/> instance; optionally allowing an
        /// unknown resource name to be successfully parsed
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>folders/{folder}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnknown"/> is <c>true</c>.
        /// </remarks>
        /// <param name="folderName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c> will successfully parse an unknown resource name into the <see cref="UnknownResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unknown resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="FolderName"/> if successful.</returns>
        public static FolderName Parse(string folderName, bool allowUnknown) =>
            TryParse(folderName, allowUnknown, out FolderName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="FolderName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>folders/{folder}</c></description></item></list>
        /// </remarks>
        /// <param name="folderName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="FolderName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string folderName, out FolderName result) => TryParse(folderName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="FolderName"/> instance; optionally
        /// allowing an unknown resource name to be successfully parsed.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>folders/{folder}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnknown"/> is <c>true</c>.
        /// </remarks>
        /// <param name="folderName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c> will successfully parse an unknown resource name into the <see cref="UnknownResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unknown resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="FolderName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string folderName, bool allowUnknown, out FolderName result)
        {
            gax::GaxPreconditions.CheckNotNull(folderName, nameof(folderName));
            gax::TemplatedResourceName resourceName;
            if (s_folder.TryParseName(folderName, out resourceName))
            {
                result = FromFolder(resourceName[0]);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(folderName, out gax::UnknownResourceName unknownResourceName))
                {
                    result = FromUnknown(unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private FolderName(ResourceNameType type, gax::UnknownResourceName unknownResourceName = null, string folderId = null)
        {
            Type = type;
            UnknownResource = unknownResourceName;
            FolderId = folderId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="FolderName"/> class from the component parts of pattern
        /// <c>folders/{folder}</c>
        /// </summary>
        /// <param name="folderId">The <c>Folder</c> ID. Must not be <c>null</c> or empty.</param>
        public FolderName(string folderId) : this(ResourceNameType.Folder, folderId: gax::GaxPreconditions.CheckNotNullOrEmpty(folderId, nameof(folderId)))
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnknownResourceName"/>. Only non-<c>null</c>if this instance contains an
        /// unknown resource name.
        /// </summary>
        public gax::UnknownResourceName UnknownResource { get; }

        /// <summary>
        /// The <c>Folder</c> ID. Will not be <c>null</c>, unless this instance contains an unknown resource name.
        /// </summary>
        public string FolderId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => Type == ResourceNameType.Unknown ? gax::ResourceNameKind.Unknown : gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unknown: return UnknownResource.ToString();
                case ResourceNameType.Folder: return s_folder.Expand(FolderId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as FolderName);

        /// <inheritdoc/>
        public bool Equals(FolderName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(FolderName a, FolderName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(FolderName a, FolderName b) => !(a == b);
    }
}
