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
    public class VersionHeaderBuilderTest
    {
        [Fact]
        public void InitiallyEmpty()
        {
            Assert.Equal("", new VersionHeaderBuilder().ToString());
        }

        [Fact]
        public void AppendDotNetEnvironment_AddsDotNetEntry()
        {
            string versionHeader = new VersionHeaderBuilder().AppendDotNetEnvironment().ToString();
#if NETCOREAPP1_0
            Assert.StartsWith("gl-dotnet/1.", versionHeader);
#else
            Assert.StartsWith("gl-dotnet/4.", versionHeader);
#endif
        }

        [Fact]
        public void AppendVersion()
        {
            Assert.Equal("foo/1.2.3-bar",
                new VersionHeaderBuilder().AppendVersion("foo", "1.2.3-bar").ToString());
        }

        [Fact]
        public void MultipleEntries()
        {
            Assert.Equal("foo/1.2.3-bar baz/1.0.0",
                new VersionHeaderBuilder()
                    .AppendVersion("foo", "1.2.3-bar")
                    .AppendVersion("baz", "1.0.0")
                    .ToString());
        }

        [Fact]
        public void AppendAssemblyVersion()
        {
            Assert.StartsWith("foo/1.0.0",
                new VersionHeaderBuilder().AppendAssemblyVersion("foo", GetType()).ToString());
        }

        [Fact]
        public void NamesAreUnique()
        {
            var builder = new VersionHeaderBuilder();
            builder.AppendVersion("name", "1.0.0");
            Assert.Throws<ArgumentException>(() => builder.AppendVersion("name", "2.0.0"));
        }

        [Fact]
        public void Clone()
        {
            var builder1 = new VersionHeaderBuilder();
            builder1.AppendVersion("x", "1.0.0");
            var builder2 = builder1.Clone();
            builder1.AppendVersion("y", "2.0.0");
            builder2.AppendVersion("z", "3.0.0");
            Assert.Equal("x/1.0.0 y/2.0.0", builder1.ToString());
            Assert.Equal("x/1.0.0 z/3.0.0", builder2.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData("x y")]
        [InlineData("x/y")]
        public void InvalidName(string name)
        {
            var builder = new VersionHeaderBuilder();
            Assert.Throws<ArgumentException>(() => builder.AppendVersion(name, "1.0.0"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("x y")]
        [InlineData("x/y")]
        public void InvalidVersion(string version)
        {
            var builder = new VersionHeaderBuilder();
            Assert.Throws<ArgumentException>(() => builder.AppendVersion("name", version));
        }
    }
}
