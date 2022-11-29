/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

// Partial class for the Sample service to allow access to gRPC Method objects.
public partial class Sample
{
    public static IMethod MethodWithNoHttpOptions => __Method_MethodWithNoHttpOptions;
    public static IMethod SimpleMethod => __Method_SimpleMethod;
    public static IMethod NonExistentMethod => new Method<SimpleRequest, SimpleResponse>(
        MethodType.Unary,
        __ServiceName,
        "WrongName",
        __Marshaller_google_api_gax_grpc_rest_tests_SimpleRequest,
        __Marshaller_google_api_gax_grpc_rest_tests_SimpleResponse);
}

public class RestServiceCollectionTest
{
    [Fact]
    public void SupportedMethod()
    {
        var collection = CreateRestServiceCollectionForTestService();
        Assert.NotNull(collection.GetRestMethod(Sample.SimpleMethod));
    }

    [Fact]
    public void UnsupportedMethod()
    {
        var collection = CreateRestServiceCollectionForTestService();
        var exception = Assert.Throws<RpcException>(() => collection.GetRestMethod(Sample.MethodWithNoHttpOptions));
        Assert.Equal(StatusCode.Unimplemented, exception.StatusCode);
    }

    [Fact]
    public void UnknownMethod()
    {
        var collection = CreateRestServiceCollectionForTestService();
        var exception = Assert.Throws<RpcException>(() => collection.GetRestMethod(Sample.NonExistentMethod));
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
}
