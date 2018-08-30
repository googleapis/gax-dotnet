/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Api.Gax.Grpc
{
    // TODO: These are copied from Firestore utilities. If we make them public, they can be reused there.
    //       Just make sure we have everything Firestore needs here if we do decide to do that.
    internal static class EqualityHelpers
    {
        private const int HashInitialValue = 3581;

        /// <summary>
        /// Checks if two lists are equal, in an ordering-sensitive manner.
        /// </summary>
        internal static bool ListsEqual<T>(IReadOnlyList<T> left, IReadOnlyList<T> right)
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
        /// Computes an ordering-sensitive hash code for a list.
        /// </summary>
        internal static int GetListHashCode<T>(IReadOnlyList<T> list, IEqualityComparer<T> comparer)
        {
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

        // Hash code convenience methods using DJB2 constants.
        // Alternatives would be generic methods that call GetHashCode directly.
        // Only necessary overloads are present; more can be added.
        internal static int CombineHashCodes(int hash1, int hash2)
        {
            unchecked
            {
                int hash = HashInitialValue;
                hash = (hash << 5) + hash + hash1;
                hash = (hash << 5) + hash + hash2;
                return hash;
            }
        }

        internal static int CombineHashCodes(int hash1, int hash2, int hash3)
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

        internal static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4)
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

        internal static int CombineHashCodes(int hash1, int hash2, int hash3, int hash4, int hash5, int hash6, int hash7, int hash8)
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
