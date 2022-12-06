/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.IntegrationTests;
using Google.Protobuf.Collections;
using Grpc.Core;
using Grpc.Core.Utils;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Google.Api.Gax.Grpc.IntegrationTests.TestService;

namespace Google.Api.Gax.Grpc.Rest.IntegrationTests;

public class RestChannelTest
{
    [Fact]
    public void Unary_Success()
    {
        var client = CreateClient();
        var response = client.DoSimple(new SimpleRequest { Name = "test name" });
        Assert.Equal("test name", response.Name);
    }

    [Fact]
    public void Unary_Error()
    {
        var client = CreateClient();
        var exception = Assert.Throws<RpcException>(() => client.DoSimple(new SimpleRequest { Name = "error" }));
        Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);
        Assert.Equal("Error details", exception.Status.Detail);
    }

    [Fact]
    public async Task Streaming_Success()
    {
        var client = CreateClient();
        var response = client.ServerStreaming(new SimpleRequest { Name = "test" });
        var elements = await response.ResponseStream.ToListAsync();
        var expected = new[]
        {
            new SimpleResponse { Name = "test0" },
            new SimpleResponse { Name = "test1" },
            new SimpleResponse { Name = "test2" },
        };
        Assert.Equal(expected, elements);
    }

    [Fact]
    public async Task Streaming_Error()
    {
        var client = CreateClient();
        var response = client.ServerStreaming(new SimpleRequest { Name = "error" });
        var exception = await Assert.ThrowsAsync<RpcException>(() => response.ResponseStream.MoveNext(default));
        Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);
        Assert.Equal("Error details", exception.Status.Detail);
    }

    private TestServiceClient CreateClient()
    {
        var metadata = TestServiceMetadata.ApiMetadata;
        var serviceCollection = RestServiceCollection.Create(metadata);
        var httpClient = new HttpClient(new TestServerHandler()) { BaseAddress = new Uri("http://localserver") };
        var channel = new RestChannel(serviceCollection, "http://localserver", ChannelCredentials.Insecure, options: default, httpClient);
        return new TestServiceClient(channel);
    }

    private class TestServerHandler : HttpMessageHandler
    {
        private const string SimplePathPrefix = "/v1/simple/";
        private const string ServerStreamingPathPrefix = "/v1/serverStreaming/";
        private const string CustomPathPrefix = "/v1/custom:";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uri = request.RequestUri;
            string path = uri.AbsolutePath;
            var response =
                path.StartsWith(SimplePathPrefix) ? GetSimpleResponse(request)
                : path.StartsWith(ServerStreamingPathPrefix) ? GetStreamingResponse(request)
                : path.StartsWith(CustomPathPrefix) ? GetCustomMethod(request)
                : new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound };
            return Task.FromResult(response);
        }

        private HttpResponseMessage GetSimpleResponse(HttpRequestMessage request)
        {
            var uri = request.RequestUri;
            string path = uri.AbsolutePath;
            string name = Uri.UnescapeDataString(path.Substring(SimplePathPrefix.Length));
            if (name == "error")
            {
                return CreateErrorResponseMessage(HttpStatusCode.BadRequest,
                    StatusCode.InvalidArgument, "Error details");
            }
            return CreateSuccessResponseMessage(new SimpleResponse { Name = name });
        }

        private HttpResponseMessage GetStreamingResponse(HttpRequestMessage request)
        {
            var uri = request.RequestUri;
            string path = uri.AbsolutePath;
            string name = Uri.UnescapeDataString(path.Substring(ServerStreamingPathPrefix.Length));
            if (name == "error")
            {
                var repeatedError = new RepeatedField<Error> { CreateError(StatusCode.InvalidArgument, "Error details") };
                return CreateErrorResponseMessage(HttpStatusCode.BadRequest, repeatedError);
            }

            var responses = Enumerable.Range(0, 3).Select(index => new SimpleResponse { Name = name + index });
            var repeated = new RepeatedField<SimpleResponse>();
            repeated.AddRange(responses);
            return CreateSuccessResponseMessage(repeated);
        }

        private HttpResponseMessage GetCustomMethod(HttpRequestMessage request)
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.NotImplemented };
        }

        private static HttpResponseMessage CreateSuccessResponseMessage(object message)
        {
            string json = message.ToString();
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }

        private static HttpResponseMessage CreateErrorResponseMessage(HttpStatusCode httpStatusCode, StatusCode gRpcStatusCode, string message) =>
            CreateErrorResponseMessage(httpStatusCode, CreateError(gRpcStatusCode, message));

        private static HttpResponseMessage CreateErrorResponseMessage(HttpStatusCode httpStatusCode, object error)
        {
            string json = error.ToString();
            return new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }

        private static Error CreateError(StatusCode gRpcStatusCode, string message) =>
            new Error
            {
                Error_ = new Error.Types.Status
                {
                    Status_ = (Rpc.Code) gRpcStatusCode,
                    Message = message
                }
            };
    }
}
