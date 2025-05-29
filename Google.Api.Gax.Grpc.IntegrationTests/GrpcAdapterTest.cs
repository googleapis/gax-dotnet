/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

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
            // Note: this test fails under .NET Framework on some versions of Windows, when it's using the WinHttpHandler.
            // (WinHttpException: Error 12152 calling WINHTTP_CALLBACK_STATUS_REQUEST_ERROR)
            // We believe this is due to talking to a server hosted by Grpc.Net.Client with insecure channel credentials.
            // As far as we're aware it's fine talking to real services using HTTPS (otherwise all our integration
            // tests in google-cloud-dotnet would fail), and the same tests currently pass on CI.
            var adapter = GrpcAdapter.GetFallbackAdapter(TestServiceMetadata.TestService);
            var channel = adapter.CreateChannel(TestServiceMetadata.TestService, _fixture.Endpoint, ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
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
