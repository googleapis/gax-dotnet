/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

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
            string VersionHeader = new VersionHeaderBuilder().AppendDotNetEnvironment().ToString();
#if NETCOREAPP1_0
            Assert.StartsWith("gl-dotnet/1.", VersionHeader);
#else
            Assert.StartsWith("gl-dotnet/4.", VersionHeader);
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
            // Our test assembly is implicitly at v1.0.0. (We don't specify a version in project.json.)
            Assert.Equal("foo/1.0.0",
                new VersionHeaderBuilder().AppendAssemblyVersion("foo", GetType()).ToString());
        }
    }
}
