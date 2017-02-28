/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class EmptyDictionaryTest
    {
        [Fact]
        public void IsCached()
        {
            var a1 = EmptyDictionary<int, string>.Instance;
            var b1 = EmptyDictionary<string, int>.Instance;
            var a2 = EmptyDictionary<int, string>.Instance;
            var b2 = EmptyDictionary<string, int>.Instance;
            Assert.Same(a1, a2);
            Assert.Same(b1, b2);
            Assert.NotSame(a1, b1);
            Assert.NotSame(a2, b2);
        }

        [Fact]
        public void IsReadonly()
        {
            var a = EmptyDictionary<int, string>.Instance;
            Assert.Throws<NotSupportedException>(() => a[0] = "Zero");
        }

        [Fact]
        public void IsEmpty()
        {
            var a = EmptyDictionary<int, string>.Instance;
            Assert.Equal(0, a.Count);
        }
    }
}
