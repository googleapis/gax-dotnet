/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Grpc.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    public class ChannelPoolTest
    {
        private static readonly IEnumerable<string> EmptyScopes = Enumerable.Empty<string>();

        [Fact]
        public void SameEndpoint_SameChannel()
        {
            var pool = new ChannelPool(EmptyScopes);
            using (var fixture = new TestServiceFixture())
            {
                var channel1 = pool.GetChannel(fixture.Endpoint);
                var channel2 = pool.GetChannel(fixture.Endpoint);
                Assert.Same(channel1, channel2);                
            }
        }

        [Fact]
        public void DifferentEndpoint_DifferentChannel()
        {
            var pool = new ChannelPool(EmptyScopes);
            using (TestServiceFixture fixture1 = new TestServiceFixture(), fixture2 = new TestServiceFixture())
            {
                var channel1 = pool.GetChannel(fixture1.Endpoint);
                var channel2 = pool.GetChannel(fixture2.Endpoint);
                Assert.NotSame(channel1, channel2);
            }
        }

        [Fact]
        public void SameOptions_SameChannel()
        {
            var options1 = GrpcChannelOptions.Empty.WithCustomOption("x", 5);
            var options2 = GrpcChannelOptions.Empty.WithCustomOption("x", 5);
            var pool = new ChannelPool(EmptyScopes);
            using (var fixture = new TestServiceFixture())
            {
                var channel1 = pool.GetChannel(fixture.Endpoint, options1);
                var channel2 = pool.GetChannel(fixture.Endpoint, options2);
                Assert.Same(channel1, channel2);
            }
        }

        [Fact]
        public void DifferentOptions_DifferentChannel()
        {
            var options1 = GrpcChannelOptions.Empty.WithCustomOption("x", 5);
            var options2 = GrpcChannelOptions.Empty.WithCustomOption("x", 6);
            var pool = new ChannelPool(EmptyScopes);
            using (var fixture = new TestServiceFixture())
            {
                var channel1 = pool.GetChannel(fixture.Endpoint, options1);
                var channel2 = pool.GetChannel(fixture.Endpoint, options2);
                Assert.NotSame(channel1, channel2);
            }
        }

        [Fact]
        public async Task ShutdownAsync_ShutsDownChannel()
        {
            var pool = new ChannelPool(EmptyScopes);
            using (var fixture = new TestServiceFixture())
            {
                var channel = (Channel) pool.GetChannel(fixture.Endpoint);
                Assert.NotEqual(ChannelState.Shutdown, channel.State);
                await pool.ShutdownChannelsAsync();
                Assert.Equal(ChannelState.Shutdown, channel.State);
            }
        }

        [Fact]
        public void ShutdownAsync_EmptiesPool()
        {
            var pool = new ChannelPool(EmptyScopes);
            using (var fixture = new TestServiceFixture())
            {
                var channel1 = pool.GetChannel(fixture.Endpoint);
                // Note: *not* waiting for this to complete.
                pool.ShutdownChannelsAsync();
                var channel2 = pool.GetChannel(fixture.Endpoint);
                Assert.NotSame(channel1, channel2);
            }
        }
    }
}
