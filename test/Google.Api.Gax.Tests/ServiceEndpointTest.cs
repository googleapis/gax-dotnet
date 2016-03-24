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
    public class ServiceEndpointTest
    {
        [Theory]
        [InlineData("foo", 1)]
        [InlineData("bar", 65535)]
        public void Construction_Valid(string host, int port)
        {
            var settings = new ServiceEndpoint(host, port);
            Assert.Equal(host, settings.Host);
            Assert.Equal(port, settings.Port);
        }

        [Theory]
        [InlineData("", 1, typeof(ArgumentException))]
        [InlineData(null, 1, typeof(ArgumentNullException))]
        [InlineData("host", 0, typeof(ArgumentOutOfRangeException))]
        [InlineData("host", -1, typeof(ArgumentOutOfRangeException))]
        [InlineData("host", 65536, typeof(ArgumentOutOfRangeException))]
        public void Construction_Invalid(string host, int port, global::System.Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new ServiceEndpoint(host, port));
        }

        [Fact]
        public void WithPort_Valid()
        {
            var before = new ServiceEndpoint("host", 10);
            var after = before.WithPort(20);

            Assert.Equal(before.Host, after.Host);
            Assert.Equal(10, before.Port);
            Assert.Equal(20, after.Port);
        }

        [Fact]
        public void WithHost_Valid()
        {
            var before = new ServiceEndpoint("before", 10);
            var after = before.WithHost("after");

            Assert.Equal(before.Port, after.Port);
            Assert.Equal("before", before.Host);
            Assert.Equal("after", after.Host);
        }

        [Fact]
        public void ToString_HostColonPort()
        {
            var endpoint = new ServiceEndpoint("foo", 22);
            Assert.Equal("foo:22", endpoint.ToString());
        }
    }
}
