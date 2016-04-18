/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class UserAgentBuilderTest
    {
        [Fact]
        public void InitiallyEmpty()
        {
            Assert.Equal("", new UserAgentBuilder().ToString());
        }

        [Fact]
        public void AppendDotNetEnvironment_AddsDotNetEntry()
        {
            Assert.Contains("dotnet/",
                new UserAgentBuilder().AppendDotNetEnvironment().ToString());
        }

        [Fact]
        public void AppendVersion()
        {
            Assert.Equal("foo/1.2.3-bar",
                new UserAgentBuilder().AppendVersion("foo", "1.2.3-bar").ToString());
        }

        [Fact]
        public void MultipleEntries()
        {
            Assert.Equal("foo/1.2.3-bar baz/1.0.0",
                new UserAgentBuilder()
                    .AppendVersion("foo", "1.2.3-bar")
                    .AppendVersion("baz", "1.0.0")
                    .ToString());
        }

        [Fact]
        public void AppendAssemblyVersion()
        {
            // Our test assembly is implicitly at v1.0.0. (We don't specify a version in project.json.)
            Assert.Equal("foo/1.0.0",
                new UserAgentBuilder().AppendAssemblyVersion("foo", GetType()).ToString());
        }
    }
}
