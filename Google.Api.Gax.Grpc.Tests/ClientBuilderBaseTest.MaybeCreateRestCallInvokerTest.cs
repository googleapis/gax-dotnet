/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Rest;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests;

public partial class ClientBuilderBaseTest
{
    public class MaybeCreateRestCallInvokerTest
    {
        private static readonly ServiceMetadata s_serviceMetadata =
            TestServiceMetadata.TestService.WithTransports(ApiTransports.Grpc | ApiTransports.Rest);

        private static RestCallInvoker CreateRestCallInvoker()
        {
            var serviceCollection = RestServiceCollection.Create(s_serviceMetadata.ApiMetadata);
            var channel = new RestChannel(serviceCollection, "localhost", ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
            return (RestCallInvoker) channel.CreateCallInvoker();
        }

        [Fact]
        public void MaybeCreateRestCallInvoker_WithRestCallInvoker_ReturnsSameInvoker()
        {
            var builder = new TestClientBuilder(s_serviceMetadata);
            var restCallInvoker = CreateRestCallInvoker();

            var result = builder.TestMaybeCreateRestCallInvoker(restCallInvoker);
            Assert.Same(restCallInvoker, result);
        }

        [Fact]
        public async Task MaybeCreateRestCallInvokerAsync_WithRestCallInvoker_ReturnsSameInvoker()
        {
            var builder = new TestClientBuilder(s_serviceMetadata);
            var restCallInvoker = CreateRestCallInvoker();

            var result = await builder.TestMaybeCreateRestCallInvokerAsync(restCallInvoker, CancellationToken.None);
            Assert.Same(restCallInvoker, result);
        }

        [Fact]
        public void MaybeCreateRestCallInvoker_WithGrpcAdapter_ReturnsNull()
        {
            var builder = new TestClientBuilder(s_serviceMetadata)
            {
                GrpcAdapter = GrpcNetClientAdapter.Default
            };
            var dummyCallInvoker = new DummyCallInvoker();

            var result = builder.TestMaybeCreateRestCallInvoker(dummyCallInvoker);
            Assert.Null(result);
        }

        [Fact]
        public async Task MaybeCreateRestCallInvokerAsync_WithGrpcAdapter_ReturnsNull()
        {
            var builder = new TestClientBuilder(s_serviceMetadata)
            {
                GrpcAdapter = GrpcNetClientAdapter.Default
            };
            var dummyCallInvoker = new DummyCallInvoker();

            var result = await builder.TestMaybeCreateRestCallInvokerAsync(dummyCallInvoker, CancellationToken.None);
            Assert.Null(result);
        }

        [Fact]
        public void MaybeCreateRestCallInvoker_WithRestGrpcAdapter_CreatesRestCallInvoker()
        {
            var builder = new TestClientBuilder(s_serviceMetadata)
            {
                GrpcAdapter = RestGrpcAdapter.Default,
                Endpoint = "localhost:8080"
            };
            var dummyCallInvoker = new DummyCallInvoker();

            var result = builder.TestMaybeCreateRestCallInvoker(dummyCallInvoker);
            Assert.NotNull(result);
            Assert.IsType<RestCallInvoker>(result);
        }

        [Fact]
        public async Task MaybeCreateRestCallInvokerAsync_WithRestGrpcAdapter_CreatesRestCallInvoker()
        {
            var builder = new TestClientBuilder(s_serviceMetadata)
            {
                GrpcAdapter = RestGrpcAdapter.Default,
                Endpoint = "localhost:8080"
            };
            var dummyCallInvoker = new DummyCallInvoker();

            var result = await builder.TestMaybeCreateRestCallInvokerAsync(dummyCallInvoker, CancellationToken.None);
            Assert.NotNull(result);
            Assert.IsType<RestCallInvoker>(result);
        }

        private class TestClientBuilder : ClientBuilderBase<string>
        {
            public TestClientBuilder(ServiceMetadata serviceMetadata) : base(serviceMetadata) { }

            public override string Build() => throw new NotImplementedException();
            public override Task<string> BuildAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
            protected override ChannelPool GetChannelPool() => throw new NotImplementedException();

            public CallInvoker TestMaybeCreateRestCallInvoker(CallInvoker callInvoker) =>
                MaybeCreateRestCallInvoker(callInvoker);

            public Task<CallInvoker> TestMaybeCreateRestCallInvokerAsync(CallInvoker callInvoker, CancellationToken cancellationToken) =>
                MaybeCreateRestCallInvokerAsync(callInvoker, cancellationToken);

            protected override ChannelCredentials GetChannelCredentials() => ChannelCredentials.Insecure;

            protected override Task<ChannelCredentials> GetChannelCredentialsAsync(CancellationToken cancellationToken) => Task.FromResult(ChannelCredentials.Insecure);
        }

        private class DummyCallInvoker : CallInvoker
        {
            public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) => throw new NotImplementedException();
            public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) => throw new NotImplementedException();
            public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
            public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
            public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
        }
    }
}
