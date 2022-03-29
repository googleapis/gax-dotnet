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

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    [Collection(nameof(TestServiceFixture))]
    public class GrpcAdapterTest
    {
        private readonly TestServiceFixture _fixture;

        public GrpcAdapterTest(TestServiceFixture fixture) => _fixture = fixture;

        [Fact]
        public void CreateChannelMakeCall()
        {
            var adapter = GrpcAdapter.DefaultAdapter;
            // This is unfortunate, but required for the test.
            // ("localhost:12345" is only valid in Grpc.Core; "http://localhost:12345" is only valid in Grpc.Net.Client.)
            var endpoint = adapter is GrpcNetClientAdapter ? _fixture.HttpEndpoint : _fixture.Endpoint;
            var channel = adapter.CreateChannel(TestApiMetadata.TestGrpc, endpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
            var client = new TestServiceClient(channel);
            var response = client.DoSimple(new SimpleRequest { Name = "test-call" });
            Assert.Equal("test-call", response.Name);
        }

#if NETCOREAPP3_1_OR_GREATER
        [Theory]
        [InlineData("Grpc.Net.Client")]
        [InlineData("  Grpc.Net.Client  ")]
        public void AdapterOverride_GrpcNetClient(string environmentVariable)
        {
            var adapter = GrpcAdapter.GetDefaultFromEnvironmentVariable(environmentVariable);
            Assert.IsAssignableFrom<GrpcNetClientAdapter>(adapter);
        }
#endif

        [Theory]
        [InlineData("Grpc.Core")]
        [InlineData("  Grpc.Core  ")]
        public void AdapterOverride_GrpcCore(string environmentVariable)
        {
            var adapter = GrpcAdapter.GetDefaultFromEnvironmentVariable(environmentVariable);
            Assert.IsAssignableFrom<GrpcCoreAdapter>(adapter);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void AdapterOverride_NullOrEmpty(string environmentVariable)
        {
            var adapter = GrpcAdapter.GetDefaultFromEnvironmentVariable(environmentVariable);
            Assert.Null(adapter);
        }

        [Fact]
        public void AdapterOverride_Invalid() =>
            Assert.Throws<InvalidOperationException>(() => GrpcAdapter.GetDefaultFromEnvironmentVariable("garbage"));
    }
}
