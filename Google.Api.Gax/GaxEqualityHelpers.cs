/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;

namespace Google.Api.Gax
{
    /// <summary>
    /// Convenience methods to simplify implementing equality comparisons and hash codes.
    /// </summary>
    public static class GaxEqualityHelpers
    {
        private const int HashInitialValue = 3581;

        /// <summary>
        /// Checks if two lists are equal, in an ordering-sensitive manner, using the default equality comparer for the type.
        /// </summary>
        /// <param name="left">The left list to compare. May be null.</param>
        /// <param name="right">The right list to compare. May be null.</param>
        /// <returns>Whether or not the lists are equal</returns>
        public static bool ListsEqual<T>(IReadOnlyList<T> left, IReadOnlyList<T> right)
            where T : IEquatable<T>
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }
            if (left.Count != right.Count)
            {
                return false;
            }
            for (int i = 0; i < left.Count; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Computes an ordering-sensitive hash code for a list, using the default equality comparer for the type.
        /// </summary>
        /// <param name="list">The list to compute a hash code for. May be null.</param>
        /// <returns>The computed hash code.</returns>
        public static int GetListHashCode<T>(IReadOnlyList<T> list)
            where T : IEquatable<T>
        {
            var comparer = EqualityComparer<T>.Default;
            if (list == null)
            {
                return 0;
            }
            unchecked
            {
                int hash = HashInitialValue;
                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    hash = (hash << 5) + hash + comparer.GetHashCode(list[i]);
                }
                return hash;
            }
        }

        // Hash code convenience methods using DJB2 constants, for up to eight hash codes.
        // Alternatives would be generic methods that call GetHashCode directly.

        /// <summary>
        /// Combines two hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                return hash;
            }
        }

        /// <summary>
        /// Combines three hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <param name="hash3">The third hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2, int hash3)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                hash = (hash << 5) + hash + hash3;
                return hash;
            }
        }

        /// <summary>
        /// Combines four hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <param name="hash3">The third hash code.</param>
        /// <param name="hash4">The fourth hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                hash = (hash << 5) + hash + hash3;
                hash = (hash << 5) + hash + hash4;
                return hash;
            }
        }

        /// <summary>
        /// Combines five hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <param name="hash3">The third hash code.</param>
        /// <param name="hash4">The fourth hash code.</param>
        /// <param name="hash5">The fifth hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                hash = (hash << 5) + hash + hash3;
                hash = (hash << 5) + hash + hash4;
                hash = (hash << 5) + hash + hash5;
                return hash;
            }
        }

        /// <summary>
        /// Combines six hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <param name="hash3">The third hash code.</param>
        /// <param name="hash4">The fourth hash code.</param>
        /// <param name="hash5">The fifth hash code.</param>
        /// <param name="hash6">The sixth hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                hash = (hash << 5) + hash + hash3;
                hash = (hash << 5) + hash + hash4;
                hash = (hash << 5) + hash + hash5;
                hash = (hash << 5) + hash + hash6;
                return hash;
            }
        }

        /// <summary>
        /// Combines seven hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <param name="hash3">The third hash code.</param>
        /// <param name="hash4">The fourth hash code.</param>
        /// <param name="hash5">The fifth hash code.</param>
        /// <param name="hash6">The sixth hash code.</param>
        /// <param name="hash7">The seventh hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                hash = (hash << 5) + hash + hash3;
                hash = (hash << 5) + hash + hash4;
                hash = (hash << 5) + hash + hash5;
                hash = (hash << 5) + hash + hash6;
                hash = (hash << 5) + hash + hash7;
                return hash;
            }
        }

        /// <summary>
        /// Combines eight hash codes.
        /// </summary>
        /// <param name="hash1">The first hash code.</param>
        /// <param name="hash2">The second hash code.</param>
        /// <param name="hash3">The third hash code.</param>
        /// <param name="hash4">The fourth hash code.</param>
        /// <param name="hash5">The fifth hash code.</param>
        /// <param name="hash6">The sixth hash code.</param>
        /// <param name="hash7">The seventh hash code.</param>
        /// <param name="hash8">The eight hash code.</param>
        /// <returns>The combined hash code.</returns>
        public static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7, int hash8)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                hash = (hash << 5) + hash + hash3;
                hash = (hash << 5) + hash + hash4;
                hash = (hash << 5) + hash + hash5;
                hash = (hash << 5) + hash + hash6;
                hash = (hash << 5) + hash + hash7;
                hash = (hash << 5) + hash + hash8;
                return hash;
            }
        }
    }
}
