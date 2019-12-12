/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class UnknownResourceNameTest
    {
        [Fact]
        public void Parse()
        {
            Assert.Equal("a", UnknownResourceName.Parse("a").ToString());
            Assert.Throws<ArgumentNullException>(() => UnknownResourceName.Parse(null));
            Assert.Throws<ArgumentException>(() => UnknownResourceName.Parse(""));
        }

        [Fact]
        public void TryParse()
        {
            UnknownResourceName result;
            Assert.True(UnknownResourceName.TryParse("a", out result));
            Assert.Equal("a", result.ToString());
            Assert.False(UnknownResourceName.TryParse(null, out result));
            Assert.False(UnknownResourceName.TryParse("", out result));
        }

        [Fact]
        public void Kind()
        {
            Assert.False(UnknownResourceName.Parse("a").IsKnown);
        }

        [Fact]
        public void ValueEquality()
        {
            var name1 = UnknownResourceName.Parse("a");
            var name2 = UnknownResourceName.Parse("a");
            Assert.True(name1.GetHashCode() == name2.GetHashCode());
            Assert.True(name1.Equals(name2));
            Assert.True(name1.Equals((object)name2));
            Assert.True(name2.Equals(name1));
            Assert.True(name2.Equals((object)name1));
            Assert.True(name1 == name2);
            Assert.False(name1 != name2);
            var name3 = UnknownResourceName.Parse("b");
            Assert.False(name1.GetHashCode() == name3.GetHashCode());
            Assert.False(name1.Equals(name3));
            Assert.False(name1.Equals((object)name3));
            Assert.False(name3.Equals(name1));
            Assert.False(name3.Equals((object)name1));
            Assert.False(name1 == name3);
            Assert.True(name1 != name3);
        }
    }
}
