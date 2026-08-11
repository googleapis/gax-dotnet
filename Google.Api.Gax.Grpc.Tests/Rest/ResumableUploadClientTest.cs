/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Rest;
using Google.Api.Gax.Grpc.Tests;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ResumableUploadClientTest
{
    private static readonly Method<SimpleRequest, SimpleResponse> s_originalMethod = new Method<SimpleRequest, SimpleResponse>(
        MethodType.Unary,
        serviceName: "google.showcase.v1beta1.ResumableUploadService",
        name: "UploadMedia",
        requestMarshaller: Marshallers.Create<SimpleRequest>(req => new byte[0], bytes => new SimpleRequest()),
        responseMarshaller: Marshallers.Create<SimpleResponse>(res => new byte[0], bytes => new SimpleResponse { Name = "response" }));

    private static MethodDescriptor CreateResumableUploadMethodDescriptor()
    {
        var methodProto = new MethodDescriptorProto
        {
            Name = "UploadMedia",
            InputType = ".google.api.gax.grpc.rest.tests.SimpleRequest",
            OutputType = ".google.api.gax.grpc.rest.tests.SimpleResponse",
            Options = new MethodOptions()
        };
        methodProto.Options.SetExtension(AnnotationsExtensions.Http, new HttpRule { Post = "/v1beta1/media/upload", Body = "*" });

        var fileProto = new FileDescriptorProto
        {
            Name = "showcase.proto",
            Package = "google.showcase.v1beta1",
            Dependency = { TestServiceReflection.Descriptor.Name, HttpRule.Descriptor.File.Name },
            Service =
            {
                new ServiceDescriptorProto
                {
                    Name = "ResumableUploadService",
                    Method = { methodProto }
                }
            }
        };

        byte[] bytes = fileProto.ToByteArray();
        var fileDescriptor = FileDescriptor.FromGeneratedCode(bytes, new[] { TestServiceReflection.Descriptor, HttpRule.Descriptor.File }, new GeneratedClrTypeInfo(null, null, null));
        return Assert.Single(fileDescriptor.Services, s => s.Name == "ResumableUploadService").FindMethodByName("UploadMedia");
    }

    private (ResumableUploadClient<SimpleRequest, SimpleResponse> client, FakeHttpMessageHandler handler) CreateClientAndHandler()
    {
        var descriptor = CreateResumableUploadMethodDescriptor();
        var apiMetadata = new ApiMetadata("google.showcase.v1beta1", new[] { descriptor.File });
        var handler = new FakeHttpMessageHandler();
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost/") };
        var serviceCollection = RestServiceCollection.Create(apiMetadata);
        var channel = new RestChannel(serviceCollection, "localhost", ChannelCredentials.Insecure, GrpcChannelOptions.Empty, httpClient);
        var callInvoker = (RestCallInvoker) channel.CreateCallInvoker();
        var client = new ResumableUploadClient<SimpleRequest, SimpleResponse>(callInvoker, s_originalMethod);
        return (client, handler);
    }

    [Fact]
    public async Task StartAsync_SendsHeaders_AndExtractsUploadUri()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.ResponseHeaders.Add(ResumableUploadClient.UploadUrlHeaderName, "http://localhost/upload/session123");
        handler.ResponseHeaders.Add(ResumableUploadClient.StatusHeaderName, ResumableUploadClient.ActiveStatusValue);
        handler.ResponseHeaders.Add(ResumableUploadClient.ChunkGranularityHeaderName, "262144");

        var request = new SimpleRequest { Name = "test" };
        var response = await client.StartAsync(request);

        Assert.Equal("resumable", handler.LastRequestHeaders.GetValues(ResumableUploadClient.ProtocolHeaderName).FirstOrDefault());
        Assert.Equal("start", handler.LastRequestHeaders.GetValues(ResumableUploadClient.CommandHeaderName).FirstOrDefault());
        Assert.NotNull(response);
        Assert.Equal(new Uri("http://localhost/upload/session123"), response.UploadUri);
        Assert.Equal(ResumableUploadClient.ActiveStatusValue, response.Status);
        Assert.Equal(262144, response.ChunkGranularity);
    }

    [Fact]
    public async Task StartAsync_PreservesCustomCallOptionsHeaders()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.ResponseHeaders.Add(ResumableUploadClient.UploadUrlHeaderName, "http://localhost/upload/session123");
        handler.ResponseHeaders.Add(ResumableUploadClient.StatusHeaderName, ResumableUploadClient.ActiveStatusValue);

        var request = new SimpleRequest { Name = "test" };
        var customHeaders = new Metadata { { "x-custom-header", "custom-value" } };
        var options = new CallOptions(headers: customHeaders);

        var response = await client.StartAsync(request, options);

        Assert.Equal("custom-value", handler.LastRequestHeaders.GetValues("x-custom-header").FirstOrDefault());
        Assert.Equal("resumable", handler.LastRequestHeaders.GetValues(ResumableUploadClient.ProtocolHeaderName).FirstOrDefault());
        Assert.Equal("start", handler.LastRequestHeaders.GetValues(ResumableUploadClient.CommandHeaderName).FirstOrDefault());
    }

    [Fact]
    public async Task UploadChunkAsync_SendsHeaders_AndExtractsCommittedOffset()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.ResponseHeaders.Add(ResumableUploadClient.SizeReceivedHeaderName, "1024");
        handler.ResponseHeaders.Add(ResumableUploadClient.StatusHeaderName, ResumableUploadClient.ActiveStatusValue);

        var chunk = new ResumableUploadChunk(new byte[1024], bufferOffset: 0, count: 1024, uploadOffset: 0);
        var request = new ResumableUploadRequest(new Uri("http://localhost/upload/session123"), chunk);
        var response = await client.UploadChunkAsync(request);

        Assert.Equal("upload", handler.LastRequestHeaders.GetValues(ResumableUploadClient.CommandHeaderName).FirstOrDefault());
        Assert.Equal("0", handler.LastRequestHeaders.GetValues(ResumableUploadClient.OffsetHeaderName).FirstOrDefault());
        Assert.NotNull(response);
        Assert.Equal(1024, response.CommittedOffset);
        Assert.Equal(ResumableUploadClient.ActiveStatusValue, response.Status);
        Assert.False(response.IsFinal);
        Assert.Null(response.ResponseBody);
    }

    [Fact]
    public async Task UploadFinalizeAsync_SendsHeaders_AndExtractsFinalStatusAndPayload()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.ResponseHeaders.Add(ResumableUploadClient.SizeReceivedHeaderName, "2048");
        handler.ResponseHeaders.Add(ResumableUploadClient.StatusHeaderName, ResumableUploadClient.FinalStatusValue);
        handler.ResponseBody = "{\"name\":\"completed\"}";

        var chunk = new ResumableUploadChunk(new byte[1024], bufferOffset: 0, count: 1024, uploadOffset: 1024);
        var request = new ResumableUploadRequest(new Uri("http://localhost/upload/session123"), chunk);
        var response = await client.UploadFinalizeAsync(request);

        Assert.Equal("upload, finalize", handler.LastRequestHeaders.GetValues(ResumableUploadClient.CommandHeaderName).FirstOrDefault());
        Assert.Equal("1024", handler.LastRequestHeaders.GetValues(ResumableUploadClient.OffsetHeaderName).FirstOrDefault());
        Assert.NotNull(response);
        Assert.Equal(2048, response.CommittedOffset);
        Assert.Equal(ResumableUploadClient.FinalStatusValue, response.Status);
        Assert.True(response.IsFinal);
        Assert.NotNull(response.ResponseBody);
        Assert.Equal("completed", response.ResponseBody.Name);
    }

    [Fact]
    public async Task QueryOffsetAsync_SendsHeaders()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.ResponseHeaders.Add(ResumableUploadClient.SizeReceivedHeaderName, "512");
        handler.ResponseHeaders.Add(ResumableUploadClient.StatusHeaderName, ResumableUploadClient.ActiveStatusValue);

        var request = new ResumableUploadRequest(new Uri("http://localhost/upload/session123"));
        var response = await client.QueryOffsetAsync(request);

        Assert.Equal("query", handler.LastRequestHeaders.GetValues(ResumableUploadClient.CommandHeaderName).FirstOrDefault());
        Assert.False(handler.LastRequestHeaders.Contains(ResumableUploadClient.OffsetHeaderName));
        Assert.NotNull(response);
        Assert.Equal(512, response.CommittedOffset);
        Assert.Equal(ResumableUploadClient.ActiveStatusValue, response.Status);
        Assert.Null(response.ResponseBody);
    }

    [Fact]
    public async Task FinalizeAsync_SendsHeaders_WithoutOffsetHeader()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.ResponseHeaders.Add(ResumableUploadClient.SizeReceivedHeaderName, "4096");
        handler.ResponseHeaders.Add(ResumableUploadClient.StatusHeaderName, ResumableUploadClient.FinalStatusValue);
        handler.ResponseBody = "{\"name\":\"done\"}";

        var request = new ResumableUploadRequest(new Uri("http://localhost/upload/session123"));
        var response = await client.FinalizeAsync(request);

        Assert.Equal("finalize", handler.LastRequestHeaders.GetValues(ResumableUploadClient.CommandHeaderName).FirstOrDefault());
        Assert.False(handler.LastRequestHeaders.Contains(ResumableUploadClient.OffsetHeaderName));
        Assert.NotNull(response);
        Assert.Equal(4096, response.CommittedOffset);
        Assert.True(response.IsFinal);
        Assert.NotNull(response.ResponseBody);
    }

    [Fact]
    public async Task Error_PropagatesRpcException()
    {
        var (client, handler) = CreateClientAndHandler();
        handler.StatusCode = HttpStatusCode.Unauthorized;

        var request = new SimpleRequest { Name = "test" };
        var ex = await Assert.ThrowsAsync<RpcException>(() => client.StartAsync(request));
        Assert.Equal(StatusCode.Unauthenticated, ex.StatusCode);
    }

    private class FakeHttpMessageHandler : HttpMessageHandler
    {
        internal Dictionary<string, string> ResponseHeaders { get; } = new Dictionary<string, string>();
        internal string ResponseBody { get; set; } = "";
        internal HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        internal HttpRequestHeaders LastRequestHeaders { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequestHeaders = request.Headers;
            var response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(ResponseBody)
            };

            foreach (var kvp in ResponseHeaders)
            {
                response.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
            }

            return Task.FromResult(response);
        }
    }
}
