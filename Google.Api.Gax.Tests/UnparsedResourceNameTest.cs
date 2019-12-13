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
    public class UnparsedResourceNameTest
    {
        [Fact]
        public void Parse()
        {
            Assert.Equal("a", UnparsedResourceName.Parse("a").ToString());
            Assert.Throws<ArgumentNullException>(() => UnparsedResourceName.Parse(null));
            Assert.Throws<ArgumentException>(() => UnparsedResourceName.Parse(""));
        }

        [Fact]
        public void TryParse()
        {
            UnparsedResourceName result;
            Assert.True(UnparsedResourceName.TryParse("a", out result));
            Assert.Equal("a", result.ToString());
            Assert.False(UnparsedResourceName.TryParse(null, out result));
            Assert.False(UnparsedResourceName.TryParse("", out result));
        }

        [Fact]
        public void IsKnownPattern()
        {
            Assert.False(UnparsedResourceName.Parse("a").IsKnownPattern);
        }

        [Fact]
        public void ValueEquality()
        {
            var name1 = UnparsedResourceName.Parse("a");
            var name2 = UnparsedResourceName.Parse("a");
            Assert.True(name1.GetHashCode() == name2.GetHashCode());
            Assert.True(name1.Equals(name2));
            Assert.True(name1.Equals((object)name2));
            Assert.True(name2.Equals(name1));
            Assert.True(name2.Equals((object)name1));
            Assert.True(name1 == name2);
            Assert.False(name1 != name2);
            var name3 = UnparsedResourceName.Parse("b");
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
