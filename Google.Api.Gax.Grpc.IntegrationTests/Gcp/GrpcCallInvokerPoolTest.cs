/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.IntegrationTests;
using Google.Protobuf.Reflection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Grpc.Gcp.IntegrationTests
{
    // Note: this is an integration test because it needs to access the Application Default Credentials.
    public class GcpCallInvokerPoolTest
    {
        private static readonly GrpcAdapter FakeAdapter = new FakeGrpcAdapter();
        private static readonly ApiConfig Config1 = new ApiConfig { ChannelPool = new ChannelPoolConfig { MaxSize = 5 } };

        [Fact]
        public void SameEndpointAndOptions_SameCallInvoker()
        {
            var pool = new GcpCallInvokerPool(TestServiceMetadata.TestService);
            var options = GrpcChannelOptions.Empty.WithPrimaryUserAgent("abc");
            var callInvoker1 = pool.GetCallInvoker("endpoint", options, Config1, FakeAdapter);
            var callInvoker2 = pool.GetCallInvoker("endpoint", options, Config1, FakeAdapter);
            Assert.Same(callInvoker1, callInvoker2);
        }

        [Fact]
        public void SameEndpointAndEqualOptions_SameCallInvoker()
        {
            var pool = new GcpCallInvokerPool(TestServiceMetadata.TestService);
            var options1 = GrpcChannelOptions.Empty.WithPrimaryUserAgent("abc");
            var options2 = GrpcChannelOptions.Empty.WithPrimaryUserAgent("abc");
            var callInvoker1 = pool.GetCallInvoker("endpoint", options1, Config1, FakeAdapter);
            var callInvoker2 = pool.GetCallInvoker("endpoint", options2, Config1, FakeAdapter);
            Assert.Same(callInvoker1, callInvoker2);
        }

        [Fact]
        public void DifferentEndpoint_DifferentCallInvoker()
        {
            var pool = new GcpCallInvokerPool(TestServiceMetadata.TestService);
            var options = GrpcChannelOptions.Empty.WithPrimaryUserAgent("abc");
            var callInvoker1 = pool.GetCallInvoker("endpoint1", options, Config1, FakeAdapter);
            var callInvoker2 = pool.GetCallInvoker("endpoint2", options, Config1, FakeAdapter);
            Assert.NotSame(callInvoker1, callInvoker2);
        }

        [Fact]
        public void DifferentOptions_DifferentCallInvoker()
        {
            var pool = new GcpCallInvokerPool(TestServiceMetadata.TestService);
            var options1 = GrpcChannelOptions.Empty.WithPrimaryUserAgent("abc");
            var options2 = GrpcChannelOptions.Empty.WithPrimaryUserAgent("def");
            var callInvoker1 = pool.GetCallInvoker("endpoint", options1, Config1, FakeAdapter);
            var callInvoker2 = pool.GetCallInvoker("endpoint", options2, Config1, FakeAdapter);
            Assert.NotSame(callInvoker1, callInvoker2);
            var callInvoker3 = pool.GetCallInvoker("endpoint", options: null, Config1, FakeAdapter);
            Assert.NotSame(callInvoker1, callInvoker3);
        }

        // TODO: equal/non-equal configs, different adapters.

        [Fact]
        public void ShutdownAsync_EmptiesPool()
        {
            var pool = new GcpCallInvokerPool(TestServiceMetadata.TestService);
            var callInvoker1 = pool.GetCallInvoker("endpoint", options: null, Config1, FakeAdapter);
            // Note: *not* waiting for this to complete.
            pool.ShutdownChannelsAsync();
            var callInvoker2 = pool.GetCallInvoker("endpoint", options: null, Config1, FakeAdapter);
            Assert.NotSame(callInvoker1, callInvoker2);
        }
    }
}
