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
    /// Resource name for the 'billing account' resource which is widespread across Google Cloud Platform.
    /// While most resource names are generated on a per-API basis, many APIs use a billing account resource, and it's
    /// useful to be able to pass values from one API to another.
    /// </summary>
    public sealed partial class BillingAccountName : IResourceName, IEquatable<BillingAccountName>
    {
        private static readonly PathTemplate s_template = new PathTemplate("billingAccounts/{billing_account}");

        /// <summary>
        /// Parses the given billing account resource name in string form into a new
        /// <see cref="BillingAccountName"/> instance.
        /// </summary>
        /// <param name="BillingAccountName">The billing account resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="BillingAccountName"/> if successful.</returns>
        public static BillingAccountName Parse(string BillingAccountName)
        {
            GaxPreconditions.CheckNotNull(BillingAccountName, nameof(BillingAccountName));
            TemplatedResourceName resourceName = s_template.ParseName(BillingAccountName);
            return new BillingAccountName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given billing account resource name in string form into a new
        /// <see cref="BillingAccountName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="s::ArgumentNullException"/> if <paramref name="BillingAccountName"/> is null,
        /// as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="BillingAccountName">The billing account resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">When this method returns, the parsed <see cref="BillingAccountName"/>,
        /// or <c>null</c> if parsing fails.</param>
        /// <returns><c>true</c> if the name was parsed succssfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string BillingAccountName, out BillingAccountName result)
        {
            GaxPreconditions.CheckNotNull(BillingAccountName, nameof(BillingAccountName));
            TemplatedResourceName resourceName;
            if (s_template.TryParseName(BillingAccountName, out resourceName))
            {
                result = new BillingAccountName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="BillingAccountName"/> resource name class
        /// from its component parts.
        /// </summary>
        /// <param name="billingAccountId">The billingAccount ID. Must not be <c>null</c>.</param>
        public BillingAccountName(string billingAccountId)
        {
            BillingAccountId = GaxPreconditions.CheckNotNull(billingAccountId, nameof(billingAccountId));
        }

        /// <summary>
        /// The billingAccount ID. Never <c>null</c>.
        /// </summary>
        public string BillingAccountId { get; }

        /// <inheritdoc />
        public ResourceNameKind Kind => ResourceNameKind.Simple;

        /// <inheritdoc />
        public override string ToString() => s_template.Expand(BillingAccountId);

        /// <inheritdoc />
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as BillingAccountName);

        /// <inheritdoc />
        public bool Equals(BillingAccountName other) => ToString() == other?.ToString();

        /// <inheritdoc />
        public static bool operator ==(BillingAccountName a, BillingAccountName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc />
        public static bool operator !=(BillingAccountName a, BillingAccountName b) => !(a == b);
    }
}
