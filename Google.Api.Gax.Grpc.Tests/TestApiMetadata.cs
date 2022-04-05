/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.Reflection;

namespace Google.Api.Gax.Grpc.Tests
{
    internal static class TestApiMetadata
    {
        internal static ApiMetadata Test { get; } = new ApiMetadata(nameof(Test), new FileDescriptor[0]);
    }
}
