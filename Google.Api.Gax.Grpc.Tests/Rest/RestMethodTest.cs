/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Tests;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class RestMethodTest
{
    [Theory]
    [InlineData(false, "/v1/abc")]
    [InlineData(true, "/v1/abc?%24alt=json%3Benum-encoding%3Dint")]
    public void CreateRequest_WithRequestNumericEnumJson(bool value, string expectedUri)
    {
        var apiMetadata = TestApiMetadata.Test.WithRequestNumericEnumJsonEncoding(value);
        var methodDescriptor = GetMethod("Sample", "SimpleMethod");
        var restMethod = Assert.Single(RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default)).Value;

        var request = new SimpleRequest { Name = "abc" };
        var httpRequest = restMethod.CreateRequest(request, null);
        Assert.Equal(httpRequest.RequestUri.ToString(), expectedUri);
    }

    [Fact]
    public void CreateRequest_WithHttpOverrides()
    {
        var rule = new HttpRule { Get = "/v2/def/{name}" };
        var methodDescriptor = GetMethod("Sample", "SimpleMethod");
        var overrides = new Dictionary<string, ByteString> { { methodDescriptor.FullName, rule.ToByteString() } };
        var apiMetadata = TestApiMetadata.Test.WithHttpRuleOverrides(overrides);
        var restMethod = Assert.Single(RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default)).Value;

        var request = new SimpleRequest { Name = "ghi" };
        var httpRequest = restMethod.CreateRequest(request, null);
        Assert.Equal("/v2/def/ghi", httpRequest.RequestUri.ToString());
    }

    [Fact]
    public void Create_HttpRuleOverridesCanApplyToMethodsWithNoOptions()
    {
        var rule = new HttpRule { Get = "/v2/def/{name}" };
        var methodDescriptor = GetMethod("Sample", "MethodWithNoHttpOptions");
        var overrides = new Dictionary<string, ByteString> { { methodDescriptor.FullName, rule.ToByteString() } };
        var apiMetadata = TestApiMetadata.Test.WithHttpRuleOverrides(overrides);
        var restMethod = Assert.Single(RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default)).Value;
        Assert.NotNull(restMethod);
    }

    [Theory]
    [InlineData("MethodWithNoHttpOptions")]
    [InlineData("BidirectionalStreamingMethod")]
    [InlineData("ClientStreamingMethod")]
    public void UnsupportedMethods(string method)
    {
        var methodDescriptor = GetMethod("Sample", method);
        var apiMetadata = TestApiMetadata.Test;
        var pair = Assert.Single(RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default));
        Assert.Null(pair.Value);
    }

    [Fact]
    public void InvalidMethod()
    {
        var methodDescriptor = BadServiceReflection.Descriptor.Services.Single()
            .FindMethodByName("BadResourcePath");
        var apiMetadata = TestApiMetadata.Test;
        Assert.Throws<ArgumentException>(() => RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default).ToList());
    }

    [Fact]
    public void TranscodeFailure()
    {
        var apiMetadata = TestApiMetadata.Test;
        var methodDescriptor = GetMethod("Sample", "SimpleMethod");
        var restMethod = Assert.Single(RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default)).Value;

        var request = new SimpleRequest();
        var exception = Assert.Throws<RpcException>(() => restMethod.CreateRequest(request, null));
        Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);
    }

    [Theory]
    [InlineData("google.showcase.v1beta1.ResumableUploadService.UploadMedia", true, "/resumable/upload")]
    [InlineData("google.ads.googleads.v23.services.YouTubeVideoUploadService.CreateYouTubeVideoUpload", true, "/resumable/upload")]
    [InlineData("google.ads.googleads.v24.services.YouTubeVideoUploadService.CreateYouTubeVideoUpload", true, "/resumable/upload")]
    [InlineData("google.ads.googleads.v25.services.YouTubeVideoUploadService.CreateYouTubeVideoUpload", true, "/resumable/upload")]
    [InlineData("google.showcase.v1beta1.ResumableUploadService.OtherMethod", false, null)]
    public void IsResumableUploadMethod(string methodFullName, bool expectedResult, string expectedPrefix)
    {
        var apiMetadata = TestApiMetadata.Test;
        bool isResumable = RestMethod.IsResumableUploadMethod(methodFullName, apiMetadata, out var prefix);
        Assert.Equal(expectedResult, isResumable);
        Assert.Equal(expectedPrefix, prefix);
    }

    [Fact]
    public void Create_ResumableUploadMethod_WithPrefix()
    {
        var methodDescriptor = CreateResumableUploadMethodDescriptor(includeHttpOption: true);
        var apiMetadata = TestApiMetadata.Test;
        var methods = RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default).ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Equal(2, methods.Count);
        Assert.True(methods.ContainsKey("/google.showcase.v1beta1.ResumableUploadService/UploadMedia#start"));
        Assert.True(methods.ContainsKey("/google.showcase.v1beta1.ResumableUploadService/UploadMedia#started"));

        var startMethod = methods["/google.showcase.v1beta1.ResumableUploadService/UploadMedia#start"];
        var startedMethod = methods["/google.showcase.v1beta1.ResumableUploadService/UploadMedia#started"];
        Assert.NotNull(startMethod);
        Assert.NotNull(startedMethod);

        // Verify startMethod HTTP request
        var startRequest = new SimpleRequest { Name = "test" };
        var startHttpRequest = startMethod.CreateRequest(startRequest, host: null);
        Assert.Equal("/resumable/upload/v1/media/upload", startHttpRequest.RequestUri.ToString());
        Assert.Equal(HttpMethod.Post, startHttpRequest.Method);

        // Verify startedMethod HTTP request
        var uploadRequest = new ResumableUploadRequest(new Uri("http://localhost/upload/123"));
        var startedHttpRequest = startedMethod.CreateRequest(uploadRequest, host: null);
        Assert.Equal("http://localhost/upload/123", startedHttpRequest.RequestUri.ToString());
        Assert.Equal(HttpMethod.Post, startedHttpRequest.Method);
    }

    [Fact]
    public void Create_ResumableUploadMethod_WithoutHttpRule()
    {
        var methodDescriptor = CreateResumableUploadMethodDescriptor(includeHttpOption: false);
        var apiMetadata = TestApiMetadata.Test;
        var pair = Assert.Single(RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default));

        Assert.Equal("/google.showcase.v1beta1.ResumableUploadService/UploadMedia", pair.Key);
        Assert.Null(pair.Value);
    }

    private static MethodDescriptor CreateResumableUploadMethodDescriptor(bool includeHttpOption)
    {
        var methodProto = new MethodDescriptorProto
        {
            Name = "UploadMedia",
            InputType = ".google.api.gax.grpc.rest.tests.SimpleRequest",
            OutputType = ".google.api.gax.grpc.rest.tests.SimpleResponse",
        };
        if (includeHttpOption)
        {
            methodProto.Options = new MethodOptions();
            methodProto.Options.SetExtension(AnnotationsExtensions.Http, new HttpRule { Post = "/v1/media/upload", Body = "*" });
        }

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

    private static MethodDescriptor GetMethod(string service, string method) =>
        Assert.Single(TestServiceReflection.Descriptor.Services, svc => svc.Name == service)
            .FindMethodByName(method);
}
