/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Grpc.Core;

namespace Google.Api.Gax.Grpc
{
    // TODO: Make this an abstract class instead of a delegate?

    /// <summary>
    /// Creates a channel for the given endpoint, with the given credentials and options.
    /// </summary>
    /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
    /// <param name="credentials">Credentials for the channel. Must not be null.</param>
    /// <param name="options">Options for the channel. Must not be null.</param>
    /// <returns>A channel for the given endpoint.</returns>
    public delegate ChannelBase ChannelFactory(ServiceEndpoint endpoint, ChannelCredentials credentials, GrpcChannelOptions options);
}
