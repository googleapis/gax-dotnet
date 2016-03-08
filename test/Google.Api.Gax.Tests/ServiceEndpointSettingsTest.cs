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
    public class ServiceEndpointSettingsTest
    {
        [Fact]
        public void DefaultToNulls()
        {
            var settings = new ServiceEndpointSettings();
            Assert.Null(settings.Host);
            Assert.Null(settings.Port);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("host")]
        public void Host_Valid(string host)
        {
            var settings = new ServiceEndpointSettings { Host = host };
            Assert.Equal(host, settings.Host);
        }

        [Theory]
        [InlineData("")]
        public void Host_Invalid(string host)
        {
            Assert.Throws<ArgumentException>(() => new ServiceEndpointSettings { Host = host });
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(65535)]
        public void Port_Valid(int? port)
        {
            var settings = new ServiceEndpointSettings { Port = port };
            Assert.Equal(port, settings.Port);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(65536)]
        [InlineData(-1)]
        public void Port_Invalid(int? port)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ServiceEndpointSettings { Port = port });
        }
    }
}
