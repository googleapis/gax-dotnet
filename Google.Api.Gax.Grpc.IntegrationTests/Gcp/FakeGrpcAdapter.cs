/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;

namespace Google.Api.Gax.Grpc.Gcp.IntegrationTests
{
    // TODO: Implement a bit more of this, and put these in the Testing package?
    internal class FakeGrpcAdapter : GrpcAdapter
    {
        protected override ChannelBase CreateChannelImpl(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            new FakeChannel(endpoint, credentials, options);
    }
}
