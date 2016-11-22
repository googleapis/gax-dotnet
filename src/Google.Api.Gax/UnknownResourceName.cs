/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// A resource-name in which nothing is known about the name structure.
    /// </summary>
    public sealed class UnknownResourceName : IResourceName, IEquatable<UnknownResourceName>
    {
        /// <summary>
        /// Parse a resource-name into an <see cref="UnknownResourceName"/>.
        /// Only minimal verification is carried out that <paramref name="name"/> is a value resource-name string.
        /// </summary>
        /// <param name="name">A resource-name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an invalid resource-name.</exception>
        /// <returns>An <see cref="UnknownResourceName"/> representing the given string.</returns>
        public static UnknownResourceName Parse(string name) => new UnknownResourceName(name);

        /// <summary>
        /// Tries to parse the given resource-name into an <see cref="UnknownResourceName"/>.
        /// Only minimal verification is carried out that <paramref name="name"/> is a value resource-name string.
        /// </summary>
        /// <param name="name">A resource-name.</param>
        /// <param name="result">The <see cref="UnknownResourceName"/> result if parsing is successful, otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if <paramref name="name"/> was successfully parsed, otherwise <c>false</c>.</returns>
        public static bool TryParse(string name, out UnknownResourceName result)
        {
            try
            {
                result = new UnknownResourceName(name);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        private readonly string _name;

        /// <summary>
        /// Creates an unkown resource-name from the given resource-name string.
        /// Only minimal verification is carried out that <paramref name="name"/> is a value resource-name string.
        /// </summary>
        /// <param name="name"></param>
        public UnknownResourceName(string name)
        {
            // TODO: Verify it looks like a resource-name.
            _name = GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name));
        }

        /// <inheritdoc />
        public ResourceNameKind Kind => ResourceNameKind.Unknown;

        /// <inheritdoc />
        public override string ToString() => _name;

        /// <inheritdoc />
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as UnknownResourceName);

        /// <inheritdoc />
        public bool Equals(UnknownResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc />
        public static bool operator ==(UnknownResourceName a, UnknownResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc />
        public static bool operator !=(UnknownResourceName a, UnknownResourceName b) => !(a == b);
    }
}
