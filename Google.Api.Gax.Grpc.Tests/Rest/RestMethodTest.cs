/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Tests;
using Google.Protobuf;
using System.Collections.Generic;
using System.Linq;
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
        var methodDescriptor = TestServiceReflection.Descriptor.Services
            .Single(svc => svc.Name == "Sample")
            .FindMethodByName("SimpleMethod");
        var restMethod = RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default);

        var request = new SimpleRequest { Name = "abc" };
        var httpRequest = restMethod.CreateRequest(request, null);
        Assert.Equal(httpRequest.RequestUri.ToString(), expectedUri);
    }

    [Fact]
    public void CreateRequest_WithHttpOverrides()
    {
        var rule = new HttpRule { Get = "/v2/def/{name}" };
        var methodDescriptor = TestServiceReflection.Descriptor.Services
            .Single(svc => svc.Name == "Sample")
            .FindMethodByName("SimpleMethod");
        var overrides = new Dictionary<string, ByteString> { { methodDescriptor.FullName, rule.ToByteString() } };
        var apiMetadata = TestApiMetadata.Test.WithHttpRuleOverrides(overrides);
        var restMethod = RestMethod.Create(apiMetadata, methodDescriptor, JsonParser.Default);

        var request = new SimpleRequest { Name = "ghi" };
        var httpRequest = restMethod.CreateRequest(request, null);
        Assert.Equal("/v2/def/ghi", httpRequest.RequestUri.ToString());
    }
}
