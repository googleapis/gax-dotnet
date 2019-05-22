/*
 * Copyright 2019 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class GaxEqualityHelpersTest
    {
        [Fact]
        public void ListsEqual()
        {
            var list1 = new List<int> { 1 };
            var list2a = new List<int> { 1, 2 };
            var list2b = new List<int> { 1, 2 };
            var list2c = new List<int> { 1, 3 };

            Assert.True(GaxEqualityHelpers.ListsEqual<int>(null, null));
            Assert.False(GaxEqualityHelpers.ListsEqual(list1, null));
            Assert.False(GaxEqualityHelpers.ListsEqual(null, list1));

            Assert.True(GaxEqualityHelpers.ListsEqual(list1, list1));
            Assert.True(GaxEqualityHelpers.ListsEqual(list2a, list2b));

            // This gets an "early out" due to the counts differing.
            Assert.False(GaxEqualityHelpers.ListsEqual(list1, list2a));
            // Here we have to actually iterate.
            Assert.False(GaxEqualityHelpers.ListsEqual(list2b, list2c));
        }

        [Fact]
        public void CombineHashCodes2() =>
            CheckCombineHashCodes(2, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1]));

        [Fact]
        public void CombineHashCodes3() =>
            CheckCombineHashCodes(3, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1], array[2]));

        [Fact]
        public void CombineHashCodes4() =>
            CheckCombineHashCodes(4, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1], array[2], array[3]));

        [Fact]
        public void CombineHashCodes5() =>
            CheckCombineHashCodes(5, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1], array[2], array[3], array[4]));

        [Fact]
        public void CombineHashCodes6() =>
            CheckCombineHashCodes(6, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1], array[2], array[3], array[4], array[5]));

        [Fact]
        public void CombineHashCodes7() =>
            CheckCombineHashCodes(7, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1], array[2], array[3], array[4], array[5], array[6]));

        [Fact]
        public void CombineHashCodes8() =>
            CheckCombineHashCodes(8, array => GaxEqualityHelpers.CombineHashCodes(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]));

        // Okay, so this isn't actually just combining hash codes, but it's fine.
        [Fact]
        public void GetListHashCode_NotNull() =>
            CheckCombineHashCodes(4, array => GaxEqualityHelpers.GetListHashCode(array.ToList()));

        [Fact]
        public void GetListHashCode_Null() =>
            Assert.Equal(0, GaxEqualityHelpers.GetListHashCode<string>(null));

        /// <summary>
        /// Combines all the possible combinations for up to <paramref name="length"/> values, of values 0...3.
        /// The resulting hash codes must be unique - which they are with the combiners we're using.
        /// (It would be feasible for there to be collisions even within a valid implementation, but being unique is encouraging, and proves order sensitivity at least.)
        /// </summary>
        private static void CheckCombineHashCodes(int length, Func<int[], int> combiner)
        {
            int[] values = new int[length];
            var hashCodes = new HashSet<int>();

            do
            {
                var code = combiner(values);
                // We should get the same answer back for multiple calls.
                Assert.Equal(code, combiner(values));

                // We should always be adding a new hash code, i.e. the codes should be unique.
                hashCodes.Add(combiner(values));
            } while (IncrementValues());

            bool IncrementValues()
            {
                int index = length - 1;
                while (index >= 0)
                {
                    values[index]++;
                    if (values[index] != 4)
                    {
                        return true;
                    }
                    values[index] = 0;
                    index--;
                }
                // Exhausted all the values
                return false;
            }
        }
    }
}
