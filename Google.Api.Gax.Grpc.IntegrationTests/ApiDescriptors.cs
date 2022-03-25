/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.Reflection;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    internal static class ApiDescriptors
    {
        internal static ApiDescriptor TestGrpc { get; } = new ApiDescriptor(nameof(TestGrpc), GrpcTransports.Grpc, new FileDescriptor[0]);
        internal static ApiDescriptor TestRest { get; } = new ApiDescriptor(nameof(TestRest), GrpcTransports.Rest, new FileDescriptor[0]);
    }
}
