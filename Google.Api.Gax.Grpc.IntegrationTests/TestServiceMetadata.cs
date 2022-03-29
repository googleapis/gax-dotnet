/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    internal static class TestServiceMetadata
    {
        internal static ApiMetadata ApiMetadata { get; } = new ApiMetadata("Google.Api.Gax.Grpc.IntegrationTests", new[] { TestServiceReflection.Descriptor });
        internal static ServiceMetadata TestService = new ServiceMetadata(IntegrationTests.TestService.Descriptor, "service1.googleapis.com", new[] { "scope1" }, true, GrpcTransports.Grpc, ApiMetadata);

        internal static ServiceMetadata WithTransports(this ServiceMetadata metadata, GrpcTransports transports) =>
            new ServiceMetadata(metadata.ServiceDescriptor, metadata.DefaultEndpoint, metadata.DefaultScopes, metadata.SupportsScopedJwts, transports, metadata.ApiMetadata);

        internal static ServiceMetadata WithSupportsScopedJwts(this ServiceMetadata metadata, bool supportsScopedJwts) =>
            new ServiceMetadata(metadata.ServiceDescriptor, metadata.DefaultEndpoint, metadata.DefaultScopes, supportsScopedJwts, metadata.Transports, metadata.ApiMetadata);
    }
}
