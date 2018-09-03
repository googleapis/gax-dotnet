/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    public class GcpCallInvokerPoolTest
    {
        private static readonly IEnumerable<string> EmptyScopes = Enumerable.Empty<string>();

        [Fact]
        public void SameEndpointAndOptions_SameCallInvoker()
        {
            var pool = new GcpCallInvokerPool(EmptyScopes);
            var options = new[] { new ChannelOption(ChannelOptions.PrimaryUserAgentString, "abc") };
            using (var fixture = new TestServiceFixture())
            {
                var callInvoker1 = pool.GetCallInvoker(fixture.Endpoint, options);
                var callInvoker2 = pool.GetCallInvoker(fixture.Endpoint, options);
                Assert.Same(callInvoker1, callInvoker2);                
            }
        }

        [Fact]
        public void DifferentEndpoint_DifferentCallInvoker()
        {
            var pool = new GcpCallInvokerPool(EmptyScopes);
            var options = new[] { new ChannelOption(ChannelOptions.PrimaryUserAgentString, "abc") };
            using (TestServiceFixture fixture1 = new TestServiceFixture(), fixture2 = new TestServiceFixture())
            {
                var callInvoker1 = pool.GetCallInvoker(fixture1.Endpoint, options);
                var callInvoker2 = pool.GetCallInvoker(fixture2.Endpoint, options);
                Assert.NotSame(callInvoker1, callInvoker2);
            }
        }

        [Fact]
        public void DifferentOptions_DifferentCallInvoker()
        {
            var pool = new GcpCallInvokerPool(EmptyScopes);
            var options1 = new[] { new ChannelOption(ChannelOptions.PrimaryUserAgentString, "abc") };
            var options2 = new[] { new ChannelOption(ChannelOptions.PrimaryUserAgentString, "def") };
            using (var fixture = new TestServiceFixture())
            {
                var callInvoker1 = pool.GetCallInvoker(fixture.Endpoint, options1);
                var callInvoker2 = pool.GetCallInvoker(fixture.Endpoint, options2);
                Assert.NotSame(callInvoker1, callInvoker2);
                var callInvoker3 = pool.GetCallInvoker(fixture.Endpoint);
                Assert.NotSame(callInvoker1, callInvoker3);
            }
        }

        [Fact]
        public void ShutdownAsync_EmptiesPool()
        {
            var pool = new GcpCallInvokerPool(EmptyScopes);
            using (var fixture = new TestServiceFixture())
            {
                var callInvoker1 = pool.GetCallInvoker(fixture.Endpoint);
                // Note: *not* waiting for this to complete.
                pool.ShutdownChannelsAsync();
                var callInvoker2 = pool.GetCallInvoker(fixture.Endpoint);
                Assert.NotSame(callInvoker1, callInvoker2);
            }
        }
    }
}
