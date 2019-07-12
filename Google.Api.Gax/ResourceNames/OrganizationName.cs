﻿/*
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
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("organizations/{organization}");

        /// <summary>
        /// Parses the given organization resource name in string form into a new
        /// <see cref="OrganizationName"/> instance.
        /// </summary>
        /// <param name="organizationName">The organization resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="OrganizationName"/> if successful.</returns>
        public static OrganizationName Parse(string organizationName)
        {
            gax::GaxPreconditions.CheckNotNull(organizationName, nameof(organizationName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(organizationName);
            return new OrganizationName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given organization resource name in string form into a new
        /// <see cref="OrganizationName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="organizationName"/> is null,
        /// as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="organizationName">The organization resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">When this method returns, the parsed <see cref="OrganizationName"/>,
        /// or <c>null</c> if parsing fails.</param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string organizationName, out OrganizationName result)
        {
            gax::GaxPreconditions.CheckNotNull(organizationName, nameof(organizationName));
            gax::TemplatedResourceName resourceName;
            if (s_template.TryParseName(organizationName, out resourceName))
            {
                result = new OrganizationName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="OrganizationName"/>.</summary>
        /// <param name="organizationId">The <c>organization</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="OrganizationName"/>.</returns>
        public static string Format(string organizationId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(organizationId, nameof(organizationId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="OrganizationName"/> resource name class
        /// from its component parts.
        /// </summary>
        /// <param name="organizationId">The organization ID. Must not be <c>null</c>.</param>
        public OrganizationName(string organizationId)
        {
            OrganizationId = gax::GaxPreconditions.CheckNotNull(organizationId, nameof(organizationId));
        }

        /// <summary>
        /// The organization ID. Never <c>null</c>.
        /// </summary>
        public string OrganizationId { get; }

        /// <inheritdoc />
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc />
        public override string ToString() => s_template.Expand(OrganizationId);

        /// <inheritdoc />
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as OrganizationName);

        /// <inheritdoc />
        public bool Equals(OrganizationName other) => ToString() == other?.ToString();

        /// <inheritdoc />
        public static bool operator ==(OrganizationName a, OrganizationName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc />
        public static bool operator !=(OrganizationName a, OrganizationName b) => !(a == b);
    }
}
