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
    /// Resource name for the 'organization' resource which is widespread across Google Cloud Platform.
    /// While most resource names are generated on a per-API basis, many APIs use an organization resource, and it's
    /// useful to be able to pass values from one API to another.
    /// </summary>
    public sealed partial class OrganizationName : gax::IResourceName, sys::IEquatable<OrganizationName>
    {
        /// <summary>The possible contents of <see cref="OrganizationName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource name with pattern <c>organizations/{organization}</c>.</summary>
            Organization = 1
        }

        private static gax::PathTemplate s_organization = new gax::PathTemplate("organizations/{organization}");

        /// <summary>Creates a <see cref="OrganizationName"/> containing an unknown resource name.</summary>
        /// <param name="unknownResourceName">The unknown resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="OrganizationName"/> containing the provided
        /// <paramref name="unknownResourceName"/>.
        /// </returns>
        public static OrganizationName FromUnknown(gax::UnknownResourceName unknownResourceName) =>
            new OrganizationName(ResourceNameType.Unknown, gax::GaxPreconditions.CheckNotNull(unknownResourceName, nameof(unknownResourceName)));

        /// <summary>
        /// Creates a <see cref="OrganizationName"/> with the pattern <c>organizations/{organization}</c>.
        /// </summary>
        /// <param name="organizationId">The <c>Organization</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OrganizationName"/> constructed from the provided ids.</returns>
        public static OrganizationName FromOrganization(string organizationId) =>
            new OrganizationName(ResourceNameType.Organization, organizationId: gax::GaxPreconditions.CheckNotNullOrEmpty(organizationId, nameof(organizationId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrganizationName"/> with pattern
        /// <c>organizations/{organization}</c>.
        /// </summary>
        /// <param name="organizationId">The <c>Organization</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OrganizationName"/> with pattern
        /// <c>organizations/{organization}</c>.
        /// </returns>
        public static string Format(string organizationId) => FormatOrganization(organizationId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrganizationName"/> with pattern
        /// <c>organizations/{organization}</c>.
        /// </summary>
        /// <param name="organizationId">The <c>Organization</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OrganizationName"/> with pattern
        /// <c>organizations/{organization}</c>.
        /// </returns>
        public static string FormatOrganization(string organizationId) =>
            s_organization.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(organizationId, nameof(organizationId)));

        /// <summary>Parses the given resource name string into a new <see cref="OrganizationName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>organizations/{organization}</c></description></item></list>
        /// </remarks>
        /// <param name="organizationName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="OrganizationName"/> if successful.</returns>
        public static OrganizationName Parse(string organizationName) => Parse(organizationName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OrganizationName"/> instance; optionally
        /// allowing an unknown resource name to be successfully parsed
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>organizations/{organization}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnknown"/> is <c>true</c>.
        /// </remarks>
        /// <param name="organizationName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c> will successfully parse an unknown resource name into the <see cref="UnknownResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unknown resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="OrganizationName"/> if successful.</returns>
        public static OrganizationName Parse(string organizationName, bool allowUnknown) =>
            TryParse(organizationName, allowUnknown, out OrganizationName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OrganizationName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>organizations/{organization}</c></description></item></list>
        /// </remarks>
        /// <param name="organizationName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OrganizationName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string organizationName, out OrganizationName result) =>
            TryParse(organizationName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OrganizationName"/> instance; optionally
        /// allowing an unknown resource name to be successfully parsed.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>organizations/{organization}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnknown"/> is <c>true</c>.
        /// </remarks>
        /// <param name="organizationName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c> will successfully parse an unknown resource name into the <see cref="UnknownResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unknown resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OrganizationName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string organizationName, bool allowUnknown, out OrganizationName result)
        {
            gax::GaxPreconditions.CheckNotNull(organizationName, nameof(organizationName));
            gax::TemplatedResourceName resourceName;
            if (s_organization.TryParseName(organizationName, out resourceName))
            {
                result = FromOrganization(resourceName[0]);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(organizationName, out gax::UnknownResourceName unknownResourceName))
                {
                    result = FromUnknown(unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private OrganizationName(ResourceNameType type, gax::UnknownResourceName unknownResourceName = null, string organizationId = null)
        {
            Type = type;
            UnknownResource = unknownResourceName;
            OrganizationId = organizationId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="OrganizationName"/> class from the component parts of pattern
        /// <c>organizations/{organization}</c>
        /// </summary>
        /// <param name="organizationId">The <c>Organization</c> ID. Must not be <c>null</c> or empty.</param>
        public OrganizationName(string organizationId) : this(ResourceNameType.Organization, organizationId: gax::GaxPreconditions.CheckNotNullOrEmpty(organizationId, nameof(organizationId)))
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
        /// The <c>Organization</c> ID. Will not be <c>null</c>, unless this instance contains an unknown resource name.
        /// </summary>
        public string OrganizationId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => Type == ResourceNameType.Unknown ? gax::ResourceNameKind.Unknown : gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unknown: return UnknownResource.ToString();
                case ResourceNameType.Organization: return s_organization.Expand(OrganizationId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as OrganizationName);

        /// <inheritdoc/>
        public bool Equals(OrganizationName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(OrganizationName a, OrganizationName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(OrganizationName a, OrganizationName b) => !(a == b);
    }
}
