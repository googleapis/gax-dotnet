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
    /// Resource name for the 'billing account' resource which is widespread across Google Cloud Platform.
    /// While most resource names are generated on a per-API basis, many APIs use a billing account resource, and it's
    /// useful to be able to pass values from one API to another.
    /// </summary>
    public sealed partial class BillingAccountName : gax::IResourceName, sys::IEquatable<BillingAccountName>
    {
        /// <summary>The possible contents of <see cref="BillingAccountName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource name with pattern <c>billingAccounts/{billing_account}</c>.</summary>
            BillingAccount = 1
        }

        private static gax::PathTemplate s_billingAccount = new gax::PathTemplate("billingAccounts/{billing_account}");

        /// <summary>Creates a <see cref="BillingAccountName"/> containing an unknown resource name.</summary>
        /// <param name="unknownResourceName">The unknown resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="BillingAccountName"/> containing the provided
        /// <paramref name="unknownResourceName"/>.
        /// </returns>
        public static BillingAccountName FromUnknown(gax::UnknownResourceName unknownResourceName) =>
            new BillingAccountName(ResourceNameType.Unknown, gax::GaxPreconditions.CheckNotNull(unknownResourceName, nameof(unknownResourceName)));

        /// <summary>
        /// Creates a <see cref="BillingAccountName"/> with the pattern <c>billingAccounts/{billing_account}</c>.
        /// </summary>
        /// <param name="billingAccountId">The <c>BillingAccount</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="BillingAccountName"/> constructed from the provided ids.</returns>
        public static BillingAccountName FromBillingAccount(string billingAccountId) =>
            new BillingAccountName(ResourceNameType.BillingAccount, billingAccountId: gax::GaxPreconditions.CheckNotNullOrEmpty(billingAccountId, nameof(billingAccountId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="BillingAccountName"/> with pattern
        /// <c>billingAccounts/{billing_account}</c>.
        /// </summary>
        /// <param name="billingAccountId">The <c>BillingAccount</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="BillingAccountName"/> with pattern
        /// <c>billingAccounts/{billing_account}</c>.
        /// </returns>
        public static string Format(string billingAccountId) => FormatBillingAccount(billingAccountId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="BillingAccountName"/> with pattern
        /// <c>billingAccounts/{billing_account}</c>.
        /// </summary>
        /// <param name="billingAccountId">The <c>BillingAccount</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="BillingAccountName"/> with pattern
        /// <c>billingAccounts/{billing_account}</c>.
        /// </returns>
        public static string FormatBillingAccount(string billingAccountId) =>
            s_billingAccount.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(billingAccountId, nameof(billingAccountId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="BillingAccountName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>billingAccounts/{billing_account}</c></description></item></list>
        /// </remarks>
        /// <param name="billingAccountName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="BillingAccountName"/> if successful.</returns>
        public static BillingAccountName Parse(string billingAccountName) => Parse(billingAccountName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="BillingAccountName"/> instance; optionally
        /// allowing an unknown resource name to be successfully parsed
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>billingAccounts/{billing_account}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnknown"/> is <c>true</c>.
        /// </remarks>
        /// <param name="billingAccountName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c> will successfully parse an unknown resource name into the <see cref="UnknownResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unknown resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="BillingAccountName"/> if successful.</returns>
        public static BillingAccountName Parse(string billingAccountName, bool allowUnknown) =>
            TryParse(billingAccountName, allowUnknown, out BillingAccountName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="BillingAccountName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>billingAccounts/{billing_account}</c></description></item></list>
        /// </remarks>
        /// <param name="billingAccountName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="BillingAccountName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string billingAccountName, out BillingAccountName result) =>
            TryParse(billingAccountName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="BillingAccountName"/> instance;
        /// optionally allowing an unknown resource name to be successfully parsed.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>billingAccounts/{billing_account}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnknown"/> is <c>true</c>.
        /// </remarks>
        /// <param name="billingAccountName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c> will successfully parse an unknown resource name into the <see cref="UnknownResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unknown resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="BillingAccountName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string billingAccountName, bool allowUnknown, out BillingAccountName result)
        {
            gax::GaxPreconditions.CheckNotNull(billingAccountName, nameof(billingAccountName));
            gax::TemplatedResourceName resourceName;
            if (s_billingAccount.TryParseName(billingAccountName, out resourceName))
            {
                result = FromBillingAccount(resourceName[0]);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(billingAccountName, out gax::UnknownResourceName unknownResourceName))
                {
                    result = FromUnknown(unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private BillingAccountName(ResourceNameType type, gax::UnknownResourceName unknownResourceName = null, string billingAccountId = null)
        {
            Type = type;
            UnknownResource = unknownResourceName;
            BillingAccountId = billingAccountId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="BillingAccountName"/> class from the component parts of pattern
        /// <c>billingAccounts/{billing_account}</c>
        /// </summary>
        /// <param name="billingAccountId">The <c>BillingAccount</c> ID. Must not be <c>null</c> or empty.</param>
        public BillingAccountName(string billingAccountId) : this(ResourceNameType.BillingAccount, billingAccountId: gax::GaxPreconditions.CheckNotNullOrEmpty(billingAccountId, nameof(billingAccountId)))
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
        /// The <c>BillingAccount</c> ID. Will not be <c>null</c>, unless this instance contains an unknown resource
        /// name.
        /// </summary>
        public string BillingAccountId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => Type == ResourceNameType.Unknown ? gax::ResourceNameKind.Unknown : gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unknown: return UnknownResource.ToString();
                case ResourceNameType.BillingAccount: return s_billingAccount.Expand(BillingAccountId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as BillingAccountName);

        /// <inheritdoc/>
        public bool Equals(BillingAccountName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(BillingAccountName a, BillingAccountName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(BillingAccountName a, BillingAccountName b) => !(a == b);
    }

}
