/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class GrpcChannelOptionsTest
    {
        [Fact]
        public void WithPrimaryUserAgent()
        {
            var original = GrpcChannelOptions.Empty;
            var withChange = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");

            Assert.Null(original.PrimaryUserAgent);
            Assert.Equal("agent", withChange.PrimaryUserAgent);
        }

        [Fact]
        public void WithEnableServiceConfigResolution()
        {
            var original = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var withChange = original.WithEnableServiceConfigResolution(false);

            Assert.Null(original.EnableServiceConfigResolution);
            Assert.Equal(false, withChange.EnableServiceConfigResolution);
            Assert.Equal("agent", withChange.PrimaryUserAgent);
        }

        [Fact]
        public void WithKeepAliveTime()
        {
            var original = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var keepAlive = TimeSpan.FromHours(1);
            var withChange = original.WithKeepAliveTime(keepAlive);

            Assert.Null(original.KeepAliveTime);
            Assert.Equal(keepAlive, withChange.KeepAliveTime);
            Assert.Equal("agent", withChange.PrimaryUserAgent);
        }

        [Fact]
        public void WithMaxReceiveMessageSize()
        {
            var original = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var withChange = original.WithMaxReceiveMessageSize(100);

            Assert.Null(original.MaxReceiveMessageSize);
            Assert.Equal(100, withChange.MaxReceiveMessageSize);
            Assert.Equal("agent", withChange.PrimaryUserAgent);
        }

        [Fact]
        public void WithMaxSendMessageSize()
        {
            var original = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var withChange = original.WithMaxSendMessageSize(100);

            Assert.Null(original.MaxSendMessageSize);
            Assert.Equal(100, withChange.MaxSendMessageSize);
            Assert.Equal("agent", withChange.PrimaryUserAgent);
        }

        [Fact]
        public void WithCustomOption()
        {
            var original = GrpcChannelOptions.Empty.WithPrimaryUserAgent("agent");
            var withChange = original
                .WithCustomOption("option1", "first")
                .WithCustomOption("option2", 2)
                .WithCustomOption(new GrpcChannelOptions.CustomOption("option3", 3));

            Assert.Empty(original.CustomOptions);
            var expectedOptions = new[]
            {
                new GrpcChannelOptions.CustomOption("option1", "first"),
                new GrpcChannelOptions.CustomOption("option2", 2),
                new GrpcChannelOptions.CustomOption("option3", 3)
            };
            Assert.Equal(expectedOptions, withChange.CustomOptions);
        }

        [Fact]
        public void Equality()
        {
            var mutations = new Func<GrpcChannelOptions, GrpcChannelOptions>[]
            {
                options => options.WithPrimaryUserAgent("agent"),
                options => options.WithEnableServiceConfigResolution(true),
                options => options.WithKeepAliveTime(TimeSpan.FromSeconds(1)),
                options => options.WithMaxReceiveMessageSize(100),
                options => options.WithMaxSendMessageSize(200),
                options => options.WithCustomOption("custom", 1)
            };

            foreach (var mutation in mutations)
            {
                var option1 = mutation(GrpcChannelOptions.Empty);
                var option2 = mutation(GrpcChannelOptions.Empty);
                Assert.Equal(option1, option2);
                Assert.Equal(option1.GetHashCode(), option2.GetHashCode());
                Assert.NotEqual(option1, GrpcChannelOptions.Empty);
                Assert.NotEqual(option1.GetHashCode(), GrpcChannelOptions.Empty.GetHashCode());
            }
        }
    }
}
