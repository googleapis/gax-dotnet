/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
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
            var channel = adapter.CreateChannel(endpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
            var client = new TestServiceClient(channel);
            var response = client.DoSimple(new SimpleRequest { Name = "test-call" });
            Assert.Equal("test-call", response.Name);
        }
    }
}
