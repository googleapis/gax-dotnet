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
    public class GrpcCoreAdapterTest
    {
        private readonly TestServiceFixture _fixture;

        public GrpcCoreAdapterTest(TestServiceFixture fixture) => _fixture = fixture;

        [Fact]
        public void CreateChannelMakeCall()
        {
            var channel = GrpcCoreAdapter.Instance.CreateChannel(CreateServiceMetadata(TestApiMetadata.TestGrpc), _fixture.Endpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
            var client = new TestServiceClient(channel);
            var response = client.DoSimple(new SimpleRequest { Name = "test-call" });
            Assert.Equal("test-call", response.Name);
        }

        // If we can propagate *any* custom option, it's pretty reasonable to expect that they'll all work,
        // at least in terms of the infrastructure.
        [Fact]
        public void PrimaryUserAgentOption()
        {
            var options = GrpcChannelOptions.Empty.WithPrimaryUserAgent("test-user-agent");
            var channel = GrpcCoreAdapter.Instance.CreateChannel(CreateServiceMetadata(TestApiMetadata.TestGrpc), _fixture.Endpoint, ChannelCredentials.Insecure, options);
            var client = new TestServiceClient(channel);
            var response = client.EchoHeaders(new EchoHeadersRequest());
            var userAgent = response.Headers["user-agent"].StringValue;
            Assert.StartsWith("test-user-agent", userAgent);
        }

        [Fact]
        public void FailsForRestOnlyDescriptor() =>
            Assert.Throws<ArgumentException>(() =>
                GrpcCoreAdapter.Instance.CreateChannel(CreateServiceMetadata(TestApiMetadata.TestRest), _fixture.Endpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty));

        private static ServiceMetadata CreateServiceMetadata(ApiMetadata apiMetadata) =>
            new ServiceMetadata("Test", "test.googleapis.com", new string[0], false, apiMetadata);
    }
}
