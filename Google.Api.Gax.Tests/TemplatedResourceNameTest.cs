/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class TemplatedResourceNameTest
    {
        private static readonly PathTemplate s_template = new PathTemplate("buckets/{bucket}/objects/{object=**}");

        [Fact]
        public void ToString_Override()
        {
            var name = new TemplatedResourceName(s_template, "foo", "bar/baz");
            Assert.Equal("buckets/foo/objects/bar/baz", name.ToString());
        }

        [Fact]
        public void ValueEquality()
        {
            var name1 = new TemplatedResourceName(s_template, "foo", "bar/baz");
            var name2 = new TemplatedResourceName(s_template, "foo", "bar/baz");
            Assert.True(name1.GetHashCode() == name2.GetHashCode());
            Assert.True(name1.Equals(name2));
            Assert.True(name1.Equals((object)name2));
            Assert.True(name2.Equals(name1));
            Assert.True(name2.Equals((object)name1));
            Assert.True(name1 == name2);
            Assert.False(name1 != name2);
            var name3 = new TemplatedResourceName(s_template, "bar", "baz/foo");
            Assert.False(name1.GetHashCode() == name3.GetHashCode());
            Assert.False(name1.Equals(name3));
            Assert.False(name1.Equals((object)name3));
            Assert.False(name3.Equals(name1));
            Assert.False(name3.Equals((object)name1));
            Assert.False(name1 == name3);
            Assert.True(name1 != name3);
        }

        [Fact]
        public void Int32Indexer_Valid()
        {
            var name = new TemplatedResourceName(s_template, "foo", "bar/baz");
            Assert.Equal("foo", name[0]);
            Assert.Equal("bar/baz", name[1]);
        }

        [Fact]
        public void StringIndexer_Valid()
        {
            var name = new TemplatedResourceName(s_template, "foo", "bar/baz");
            Assert.Equal("foo", name["bucket"]);
            Assert.Equal("bar/baz", name["object"]);
        }

        [Fact]
        public void Indexer_MissingKey()
        {
            var name = new TemplatedResourceName(s_template, "foo", "bar/baz");
            Assert.Throws<KeyNotFoundException>(() => name["bad_key"]);
        }

        [Fact]
        public void Mutation()
        {
            var name = new TemplatedResourceName(s_template, "foo", "bar") { ServiceName = "svc" };
            Assert.Equal("//svc/buckets/foo/objects/bar", name.ToString());
            name["bucket"] = "baz";
            Assert.Equal("//svc/buckets/baz/objects/bar", name.ToString());
        }

        [Fact]
        public void Clone()
        {
            var name = new TemplatedResourceName(s_template, "foo", "bar") { ServiceName = "svc" };
            var clone = name.Clone();
            Assert.Equal("//svc/buckets/foo/objects/bar", name.ToString());
            clone["bucket"] = "baz";
            clone.ServiceName = null;
            // Original is untouched
            Assert.Equal("//svc/buckets/foo/objects/bar", name.ToString());
            // Modifications affect the clone
            Assert.Equal("buckets/baz/objects/bar", clone.ToString());
        }

        [Fact]
        public void Kind()
        {
            Assert.True(new TemplatedResourceName(s_template, "foo", "bar").IsKnownPattern);
        }
    }
}
