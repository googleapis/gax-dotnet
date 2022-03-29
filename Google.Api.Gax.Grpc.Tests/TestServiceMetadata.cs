/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax.Grpc.Tests
{
    internal class TestServiceMetadata
    {
        public static ServiceMetadata Service1 = new ServiceMetadata("Service1", "service1.googleapis.com", new[] { "scope1" }, true, GrpcTransports.Grpc, TestApiMetadata.Test);
    }
}
