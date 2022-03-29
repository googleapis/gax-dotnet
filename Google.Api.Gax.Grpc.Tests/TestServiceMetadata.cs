/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;

namespace Google.Api.Gax.Grpc.Tests
{
    internal static class TestServiceMetadata
    {
        internal static ApiMetadata ApiMetadata { get; } = new ApiMetadata("Google.Api.Gax.Grpc.IntegrationTests", new[] { TestMessagesReflection.Descriptor });
        internal static ServiceMetadata TestService = new ServiceMetadata(TestMessagesReflection.Descriptor.Services[0], "service1.googleapis.com", new[] { "scope1" }, true, GrpcTransports.Grpc, ApiMetadata);

        internal static ServiceMetadata WithTransports(this ServiceMetadata metadata, GrpcTransports transports) =>
            new ServiceMetadata(metadata.ServiceDescriptor, metadata.DefaultEndpoint, metadata.DefaultScopes, metadata.SupportsScopedJwts, transports, metadata.ApiMetadata);

        internal static ServiceMetadata WithSupportsScopedJwts(this ServiceMetadata metadata, bool supportsScopedJwts) =>
            new ServiceMetadata(metadata.ServiceDescriptor, metadata.DefaultEndpoint, metadata.DefaultScopes, supportsScopedJwts, metadata.Transports, metadata.ApiMetadata);

        internal static ServiceMetadata WithDefaultScopes(this ServiceMetadata metadata, IEnumerable<string> defaultScopes) =>
            new ServiceMetadata(metadata.ServiceDescriptor, metadata.DefaultEndpoint, defaultScopes, metadata.SupportsScopedJwts, metadata.Transports, metadata.ApiMetadata);
    }
}
