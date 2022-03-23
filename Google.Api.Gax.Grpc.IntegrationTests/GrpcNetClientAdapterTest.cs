/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.Reflection;
using Grpc.Core;
using System;
using Xunit;
using static Google.Api.Gax.Grpc.IntegrationTests.TestService;

#if NETCOREAPP3_1_OR_GREATER
namespace Google.Api.Gax.Grpc.IntegrationTests
{
    [Collection(nameof(TestServiceFixture))]
    public class GrpcNetClientAdapterTest
    {
        private static readonly GrpcApiDescriptor s_apiDescriptor = new("Test", new FileDescriptor[0], GrpcTransports.Grpc);
        private readonly TestServiceFixture _fixture;

        public GrpcNetClientAdapterTest(TestServiceFixture fixture) => _fixture = fixture;

        [Fact]
        public void CreateChannelMakeCall()
        {
            var channel = GrpcNetClientAdapter.Default.CreateChannel(s_apiDescriptor, _fixture.HttpEndpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
            var client = new TestServiceClient(channel);
            var response = client.DoSimple(new SimpleRequest { Name = "test-call" });
            Assert.Equal("test-call", response.Name);
        }

        [Fact]
        public void FailsForRestOnlyDescriptor()
        {
            var descriptor = new GrpcApiDescriptor("REST-only", new FileDescriptor[0], GrpcTransports.Rest);
            Assert.Throws<ArgumentException>(() => GrpcCoreAdapter.Instance.CreateChannel(descriptor, _fixture.Endpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty));
        }
    }
}
#endif