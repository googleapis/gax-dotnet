/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    [Collection(nameof(ForwardingTestServiceFixture))]
    public class ForwardingCallInvokerTest
    {
        private readonly ForwardingTestServiceFixture _fixture;
        private readonly ForwardingSourceTestService.ForwardingSourceTestServiceClient _sourceClient;

        public ForwardingCallInvokerTest(ForwardingTestServiceFixture fixture)
        {
            _fixture = fixture;
            var targetCallInvoker = new Channel(fixture.Endpoint, ChannelCredentials.Insecure).CreateCallInvoker();
            // Note: this doesn't use ForwardingCallInvoker<T>.Create, as that's only conditionally available.
            // (The implementation is always present, but internal.)
            var sourceCallInvoker = new ForwardingCallInvoker<ForwardingSourceMethod1Request, ForwardingSourceMethod1Response, ForwardingTargetMethod1Request, ForwardingTargetMethod1Response>(
                targetCallInvoker,
                "/google.api.gax.grpc.integration_tests.ForwardingSourceTestService/Method1",
                ForwardingTargetTestService.Method1,
                ConvertRequest,
                ConvertResponse);
            _sourceClient = new ForwardingSourceTestService.ForwardingSourceTestServiceClient(sourceCallInvoker);
        }

        [Fact]
        public void ServerStreamingMethod() =>
            Assert.Throws<InvalidOperationException>(() => _sourceClient.ServerStreamingMethod(new Irrelevant()));

        [Fact]
        public void ClientStreamingMethod() =>
            Assert.Throws<InvalidOperationException>(() => _sourceClient.ClientStreamingMethod());

        [Fact]
        public void BidiStreamingMethod() =>
            Assert.Throws<InvalidOperationException>(() => _sourceClient.BidiStreamingMethod());

        [Fact]
        public void BlockingUnaryMethod_WrongMethod()
        {
            var exception = Assert.Throws<RpcException>(() => _sourceClient.Method2(new ForwardingSourceMethod2Request()));
            Assert.Equal(StatusCode.Unimplemented, exception.StatusCode);
        }

        [Fact]
        public async Task AsyncUnaryMethod_WrongMethod()
        {
            var exception = await Assert.ThrowsAsync<RpcException>(async () => await _sourceClient.Method2Async(new ForwardingSourceMethod2Request()));
            Assert.Equal(StatusCode.Unimplemented, exception.StatusCode);
        }

        // Flow for successful method call tests:
        // ForwardingSourceMethod1Request: SourceName = "abc"
        // ConvertRequest creates ForwardingTargetMethod1Request: TargetName = "xx:abc"
        // Service implementation creates ForwardingTargetMethod1Response: TargetResult = "target:xx:abc"
        // ConvertResponse creates ForwardingTargetMethod1Response: SourceRequestName = "abc", TargetResult = "yy:target:xx:abc"

        [Fact]
        public void BlockingUnaryMethod_Success()
        {
            var actualResponse = _sourceClient.Method1(new ForwardingSourceMethod1Request { SourceName = "abc" });
            var expectedResponse = new ForwardingSourceMethod1Response
            {
                SourceRequestName = "abc",
                TargetResult = "yy:target:xx:abc"
            };
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task AsyncUnaryMethod_Success()
        {
            var actualResponse = await _sourceClient.Method1Async(new ForwardingSourceMethod1Request { SourceName = "abc" });
            var expectedResponse = new ForwardingSourceMethod1Response
            {
                SourceRequestName = "abc",
                TargetResult = "yy:target:xx:abc"
            };
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public void BlockingUnaryMethod_ServiceFailure()
        {
            var request = new ForwardingSourceMethod1Request { SourceName = "error" };
            var exception = Assert.Throws<RpcException>(() => _sourceClient.Method1(request));
            Assert.Equal(StatusCode.Internal, exception.StatusCode);
            Assert.Contains("Bang", exception.Message);
        }

        [Fact]
        public async Task AsyncUnaryMethod_ServiceFailure()
        {
            var request = new ForwardingSourceMethod1Request { SourceName = "error" };
            var exception = await Assert.ThrowsAsync<RpcException>(async () => await _sourceClient.Method1Async(request));
            Assert.Equal(StatusCode.Internal, exception.StatusCode);
            Assert.Contains("Bang", exception.Message);
        }

        private ForwardingTargetMethod1Request ConvertRequest(ForwardingSourceMethod1Request request) =>
            new ForwardingTargetMethod1Request
            {
                TargetName = $"xx:{request.SourceName}"
            };

        private ForwardingSourceMethod1Response ConvertResponse(ForwardingSourceMethod1Request request, ForwardingTargetMethod1Response response) =>
            new ForwardingSourceMethod1Response
            {
                SourceRequestName = request.SourceName,
                TargetResult = $"yy:{response.TargetResult}"
            };

    }

    partial class ForwardingTargetTestService
    {
        internal static Method<ForwardingTargetMethod1Request, ForwardingTargetMethod1Response> Method1 => __Method_Method1;
    }
}
