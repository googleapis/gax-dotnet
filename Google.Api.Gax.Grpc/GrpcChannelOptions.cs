/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Convenience methods for obtaining channel options.
    /// </summary>
    internal static class GrpcChannelOptions
    {
        /// <summary>
        /// "After a duration of this time the client/server pings its peer to see if the
        /// transport is still alive. Int valued, milliseconds."
        /// Required for any channel using a streaming RPC, to ensure an idle stream doesn't
        /// allow the TCP connection to be silently dropped by any intermediary network devices.
        /// 60 second keepalive time is reasonable. This will only add minimal network traffic,
        /// and only if the channel is idle for more than 60 seconds.
        /// </summary>
        internal static ChannelOption OneMinuteKeepalive { get; } = new ChannelOption("grpc.keepalive_time_ms", 60_000);
    }
}
