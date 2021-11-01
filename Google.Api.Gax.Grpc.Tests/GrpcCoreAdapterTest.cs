/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class GrpcCoreAdapterTest
    {
        // We just test option conversion so far.
        [Fact]
        public void ConvertOptions_PrimaryUserAgent()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var grpcCoreOptions = ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(ChannelOptions.PrimaryUserAgentString, "agent") }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_EnableServiceConfigResolution()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithEnableServiceConfigResolution(false);
            var grpcCoreOptions = ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(GrpcCoreAdapter.ServiceConfigDisableResolution, 1) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_KeepAliveTime()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithKeepAliveTime(TimeSpan.FromSeconds(2));
            var grpcCoreOptions = ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(GrpcCoreAdapter.KeepAliveTimeMs, 2000) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_KeepAliveTimeout()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithKeepAliveTimeout(TimeSpan.FromSeconds(2));
            var grpcCoreOptions = ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(GrpcCoreAdapter.KeepAliveTimeoutMs, 2000) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_MaxReceiveSize()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithMaxReceiveMessageSize(150);
            var grpcCoreOptions = ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(ChannelOptions.MaxReceiveMessageLength, 150) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_MaxSendSize()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithMaxSendMessageSize(150);
            var grpcCoreOptions = ConvertOptions(gaxOptions);

            Assert.Equal(new[] { new ChannelOption(ChannelOptions.MaxSendMessageLength, 150) }, grpcCoreOptions);
        }

        [Fact]
        public void ConvertOptions_CustomOptions()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithCustomOption("c1", 1).WithCustomOption("c2", "two");
            var grpcCoreOptions = ConvertOptions(gaxOptions);
            var expectedOptions = new[]
            {
                new ChannelOption("c1", 1),
                new ChannelOption("c2", "two")
            };
            Assert.Equal(expectedOptions, grpcCoreOptions);
        }

        private IReadOnlyList<ChannelOption> ConvertOptions(GrpcChannelOptions gaxOptions) =>
            GrpcCoreAdapter.ConvertOptions(gaxOptions, (name, intValue) => new ChannelOption(name, intValue), (name, stringValue) => new ChannelOption(name, stringValue));
    }
}
