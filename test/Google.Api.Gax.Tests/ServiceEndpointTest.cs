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

        [Fact]
        public void Equality()
        {
            var endpoint1 = new ServiceEndpoint("foo", 22);
            var endpoint2 = new ServiceEndpoint("foo", 22);
            var endpoint3 = new ServiceEndpoint("bar", 22);
            var endpoint4 = new ServiceEndpoint("foo", 23);

            Assert.True(endpoint1.Equals(endpoint2));
            Assert.True(endpoint1.Equals((object) endpoint2));
            Assert.False(endpoint1.Equals(null));
            Assert.False(endpoint1.Equals((object)null));
            Assert.False(endpoint1.Equals(endpoint3));
            Assert.False(endpoint1.Equals((object)endpoint3));
            Assert.False(endpoint1.Equals(endpoint4));
            Assert.False(endpoint1.Equals((object)endpoint4));
            Assert.Equal(endpoint1.GetHashCode(), endpoint2.GetHashCode());
            // These aren't actually guaranteed, but it would be pretty weird for this test
            // to fail without it being a bug.
            Assert.NotEqual(endpoint1.GetHashCode(), endpoint3.GetHashCode());
            Assert.NotEqual(endpoint1.GetHashCode(), endpoint4.GetHashCode());
        }
    }
}
