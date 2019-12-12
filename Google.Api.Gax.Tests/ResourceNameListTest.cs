/*
 * Copyright 2016 Google Inc. All Rights Reserved.
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
    public class ResourceNameListTest
    {
        private IList<string> List(params string[] items) => new List<string>(items);
        private ResourceNameList<UnparsedResourceName> ResourceList(IList<string> list) =>
            new ResourceNameList<UnparsedResourceName>(list, s => new UnparsedResourceName(s));


        [Fact]
        public void Count()
        {
            Assert.Equal(2, ResourceList(List("a", "b")).Count);
        }

        [Fact]
        public void IsReadOnly()
        {
            Assert.False(ResourceList(List()).IsReadOnly);
        }

        [Fact]
        public void Indexer()
        {
            var list = List("a", "b");
            var resourceList = ResourceList(list);
            resourceList[1] = new UnparsedResourceName("c");
            Assert.Equal("c", list[1]);
            Assert.Equal("a", resourceList[0].ToString());
        }

        [Fact]
        public void Add()
        {
            var list = List("a", "b");
            var resourceList = ResourceList(list);
            resourceList.Add(new UnparsedResourceName("c"));
            Assert.Equal(List("a", "b", "c"), list);
        }

        [Fact]
        public void AddRange()
        {
            var list = List("a", "b");
            var resourceList = ResourceList(list);
            resourceList.Add(new[] { new UnparsedResourceName("c"), new UnparsedResourceName("d") });
            Assert.Equal(List("a", "b", "c", "d"), list);
        }

        [Fact]
        public void Add_NullElement()
        {
            var resourceList = ResourceList(List());
            Assert.Throws<ArgumentNullException>(() => resourceList.Add((UnparsedResourceName)null));
        }

        [Fact]
        public void AddRange_NullEnumerable()
        {
            var resourceList = ResourceList(List());
            Assert.Throws<ArgumentNullException>(() => resourceList.Add((IEnumerable<UnparsedResourceName>)null));
        }

        [Fact]
        public void Clear()
        {
            var list = List("a", "b");
            ResourceList(list).Clear();
            Assert.Empty(list);
        }

        [Fact]
        public void Contains()
        {
            var list = List("a", "b");
            var resourceList = ResourceList(list);
#pragma warning disable xUnit2017 // We're testing the Contains method...
            Assert.True(resourceList.Contains(new UnparsedResourceName("a")));
            Assert.True(resourceList.Contains(new UnparsedResourceName("b")));
            Assert.False(resourceList.Contains(new UnparsedResourceName("c")));
#pragma warning restore xUnit2017            
        }

        [Fact]
        public void CopyTo()
        {
            var list = List("a", "b");
            var resourceList = ResourceList(list);
            Assert.Throws<ArgumentNullException>(() => resourceList.CopyTo(null, 0));
            UnparsedResourceName[] copy = new UnparsedResourceName[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => resourceList.CopyTo(copy, -1));
            Assert.Throws<ArgumentException>(() => resourceList.CopyTo(copy, 3));
            resourceList.CopyTo(copy, 1);
            Assert.Equal(new[] { null, new UnparsedResourceName("a"), new UnparsedResourceName("b"), null }, copy);
        }

        [Fact]
        public void Enumerate()
        {
            var list = List("a", "b");
            var resourceList = ResourceList(list);
            Assert.Equal(list, resourceList.Select(x => x.ToString()));
        }

        [Fact]
        public void IndexOf()
        {
            var resourceList = ResourceList(List("a", "b"));
            Assert.Equal(0, resourceList.IndexOf(new UnparsedResourceName("a")));
            Assert.Equal(1, resourceList.IndexOf(new UnparsedResourceName("b")));
        }

        [Fact]
        public void Insert()
        {
            var list = List("a", "b");
            ResourceList(list).Insert(1, new UnparsedResourceName("c"));
            Assert.Equal(List("a", "c", "b"), list);
        }

        [Fact]
        public void Remove()
        {
            var list = List("a", "b");
            ResourceList(list).Remove(new UnparsedResourceName("b"));
            Assert.Equal(List("a"), list);
        }

        [Fact]
        public void RemoveAt()
        {
            var list = List("a", "b");
            ResourceList(list).RemoveAt(1);
            Assert.Equal(List("a"), list);
        }
    }
}
