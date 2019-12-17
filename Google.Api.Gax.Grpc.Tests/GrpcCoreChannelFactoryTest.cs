/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class GrpcCoreChannelFactoryTest
    {
        // We just test option conversion so far.
        [Fact]
        public void ConvertOptions_PrimaryUserAgent()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var grpcCoreOptions = GrpcCoreChannelFactory.ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(ChannelOptions.PrimaryUserAgentString, "agent") }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_EnableServiceConfigResolution()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithEnableServiceConfigResolution(false);
            var grpcCoreOptions = GrpcCoreChannelFactory.ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(GrpcCoreChannelFactory.ServiceConfigDisableResolution, 1) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_KeepAliveTime()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithKeepAliveTime(TimeSpan.FromSeconds(2));
            var grpcCoreOptions = GrpcCoreChannelFactory.ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(GrpcCoreChannelFactory.KeepAliveTimeMs, 2000) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_MaxReceiveSize()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithMaxReceiveMessageSize(150);
            var grpcCoreOptions = GrpcCoreChannelFactory.ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(ChannelOptions.MaxReceiveMessageLength, 150) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_MaxSendSize()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithMaxSendMessageSize(150);
            var grpcCoreOptions = GrpcCoreChannelFactory.ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(ChannelOptions.MaxSendMessageLength, 150) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_CustomOptions()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithCustomOption("c1", 1).WithCustomOption("c2", "two");
            var grpcCoreOptions = GrpcCoreChannelFactory.ConvertOptions(gaxOptions);
            var expectedOptions = new[]
            {
                new ChannelOption("c1", 1),
                new ChannelOption("c2", "two")
            };
            Assert.Equal(expectedOptions, grpcCoreOptions);
        }
    }
}
