/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;

namespace Google.Api.Gax.Grpc.Gcp.IntegrationTests
{
    // TODO: Implement a bit more of this, and put these in the Testing package?

    /// <summary>
    /// Fake implementation of <see cref="GrpcAdapter"/> that returns a <see cref="FakeChannel"/>.
    /// </summary>
    internal class FakeGrpcAdapter : GrpcAdapter
    {
        internal FakeGrpcAdapter(GrpcTransports transports = GrpcTransports.Grpc) : base(transports)
        {
        }

        private protected override ChannelBase CreateChannelImpl(ApiMetadata apiMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            new FakeChannel(apiMetadata, endpoint, credentials, options);
    }
}