/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Rest;
using Grpc.Core;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests.Rest;

public class RestServiceCollectionTest
{
    [Fact]
    public void SupportedMethod()
    {
        var method = new FakeGrpcMethod("google.api.gax.grpc.rest.Sample.SimpleMethod");
        var collection = CreateRestServiceCollectionForTestService();
        Assert.NotNull(collection.GetRestMethod(method));
    }

    [Fact]
    public void UnsupportedMethod()
    {
        var method = new FakeGrpcMethod("google.api.gax.grpc.rest.Sample.MethodWithNoHttpOptions");
        var collection = CreateRestServiceCollectionForTestService();
        var exception = Assert.Throws<RpcException>(() => collection.GetRestMethod(method));
        Assert.Equal(StatusCode.Unimplemented, exception.StatusCode);
    }

    [Fact]
    public void UnknownMethod()
    {
        var method = new FakeGrpcMethod("google.api.gax.grpc.rest.Sample.ThisDoesntExist");
        var collection = CreateRestServiceCollectionForTestService();
        var exception = Assert.Throws<RpcException>(() => collection.GetRestMethod(method));
        Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);
    }

    private static RestServiceCollection CreateRestServiceCollectionForTestService() =>
        RestServiceCollection.Create(new ApiMetadata("test", new[] { TestServiceReflection.Descriptor }));

    [Fact]
    public void BadService()
    {
        var metadata = new ApiMetadata("test", new[] { BadServiceReflection.Descriptor });
        Assert.Throws<ArgumentException>(() => RestServiceCollection.Create(metadata));
    }

    // Just enough of IMethod to meet RestServiceCollection's needs.
    private sealed class FakeGrpcMethod : IMethod
    {
        public string FullName { get; }

        public FakeGrpcMethod(string fullName) => FullName = fullName;

        public MethodType Type => throw new NotImplementedException();
        public string ServiceName => throw new NotImplementedException();
        public string Name => throw new NotImplementedException();
    }
}
