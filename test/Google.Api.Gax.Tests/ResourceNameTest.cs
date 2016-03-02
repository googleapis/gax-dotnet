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
    public class ResourceNameTest
    {
        private static readonly PathTemplate s_template = new PathTemplate("buckets/{bucket}/objects/{object=**}");

        [Fact]
        public void ToString_Override()
        {
            var name = new ResourceName(s_template, "foo", "bar/baz");
            Assert.Equal("buckets/foo/objects/bar/baz", name.ToString());
        }

        [Fact]
        public void Int32Indexer_Valid()
        {
            var name = new ResourceName(s_template, "foo", "bar/baz");
            Assert.Equal("foo", name[0]);
            Assert.Equal("bar/baz", name[1]);
        }

        [Fact]
        public void StringIndexer_Valid()
        {
            var name = new ResourceName(s_template, "foo", "bar/baz");
            Assert.Equal("foo", name["bucket"]);
            Assert.Equal("bar/baz", name["object"]);
        }

        [Fact]
        public void Indexer_MissingKey()
        {
            var name = new ResourceName(s_template, "foo", "bar/baz");
            Assert.Throws<KeyNotFoundException>(() => name["bad_key"]);
        }

        [Fact]
        public void Mutation()
        {
            var name = new ResourceName(s_template, "foo", "bar") { ServiceName = "svc" };
            Assert.Equal("//svc/buckets/foo/objects/bar", name.ToString());
            name["bucket"] = "baz";
            Assert.Equal("//svc/buckets/baz/objects/bar", name.ToString());
        }

        [Fact]
        public void Clone()
        {
            var name = new ResourceName(s_template, "foo", "bar") { ServiceName = "svc" };
            var clone = name.Clone();
            Assert.Equal("//svc/buckets/foo/objects/bar", name.ToString());
            clone["bucket"] = "baz";
            clone.ServiceName = null;
            // Original is untouched
            Assert.Equal("//svc/buckets/foo/objects/bar", name.ToString());
            // Modifications affect the clone
            Assert.Equal("buckets/baz/objects/bar", clone.ToString());
        }
    }
}
