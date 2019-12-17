/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Convenience methods for obtaining channel options.
    /// </summary>
    public class GrpcChannelOptions : IEquatable<GrpcChannelOptions>
    {
        /*
        /// <summary>
        /// "After a duration of this time the client/server pings its peer to see if the
        /// transport is still alive. Int valued, milliseconds."
        /// Required for any channel using a streaming RPC, to ensure an idle stream doesn't
        /// allow the TCP connection to be silently dropped by any intermediary network devices.
        /// 60 second keepalive time is reasonable. This will only add minimal network traffic,
        /// and only if the channel is idle for more than 60 seconds.
        /// </summary>
        internal static ChannelOption OneMinuteKeepalive { get; } = new ChannelOption("grpc.keepalive_time_ms", 60_000);

        /// <summary>
        /// "Disable looking up the service config via the name resolver."
        /// </summary>
        /// <remarks>
        /// Currently this defaults to "on" (so disabled) anyway, but that may change later.
        /// Explicitly disable service config resolution for now; we'll allow it to be enabled when we have code to change
        /// our retry policy.
        /// </remarks>
        internal static ChannelOption DisableServiceConfigResolution { get; } = new ChannelOption("grpc.service_config_disable_resolution", 1);
        /// <summary>
        /// Creates a channel option for the primary user agent, which appears first in the channel metadata.
        /// </summary>
        /// <param name="userAgent">Custom primary user agent for the channel. Must not be null.</param>
        /// <returns>A channel option for the primary user agent</returns>
        internal static ChannelOption PrimaryUserAgent(string userAgent) =>
            new ChannelOption(ChannelOptions.PrimaryUserAgentString, GaxPreconditions.CheckNotNull(userAgent, nameof(userAgent)));
            */
        /// <summary>
        /// An empty set of channel options.
        /// </summary>
        public static GrpcChannelOptions Empty { get; } = new GrpcChannelOptions();

        private GrpcChannelOptions(
            bool? enableServiceConfigResolution = null,
            TimeSpan? keepAlive = null,
            string primaryUserAgent = null)
        {
            EnableServiceConfigResolution = enableServiceConfigResolution;
            KeepAlive = keepAlive;
            PrimaryUserAgent = primaryUserAgent;
        }

        /// <summary>
        /// If non-null, explicitly enables or disables service configuration resolution.
        /// </summary>
        public bool? EnableServiceConfigResolution { get; }

        /// <summary>
        /// If non-null, explicitly specifies the keep-alive period for the channel.
        /// </summary>
        public TimeSpan? KeepAlive { get; }

        /// <summary>
        /// If non-null, explicitly specifies the primary user agent for the channel.
        /// </summary>
        public string PrimaryUserAgent { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static GrpcChannelOptions FromPrimaryUserAgent(string userAgent) =>
            new GrpcChannelOptions(primaryUserAgent: userAgent);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableServiceConfigResolution"></param>
        /// <returns></returns>
        public static GrpcChannelOptions FromEnableServiceConfigResolution(bool enableServiceConfigResolution) =>
            new GrpcChannelOptions(enableServiceConfigResolution: enableServiceConfigResolution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keepAlive"></param>
        /// <returns></returns>
        public static GrpcChannelOptions FromKeepAlive(TimeSpan keepAlive) =>
            new GrpcChannelOptions(keepAlive: keepAlive);

        /// <summary>
        /// Returns a new object, with options from this object merged with <paramref name="overlaidOptions"/>.
        /// If an option is non-null in both objects, the one from <paramref name="overlaidOptions"/> takes priority.
        /// </summary>
        /// <param name="overlaidOptions">The overlaid options.</param>
        /// <returns></returns>
        public GrpcChannelOptions MergedWith(GrpcChannelOptions overlaidOptions) =>
            new GrpcChannelOptions(
                overlaidOptions.EnableServiceConfigResolution ?? EnableServiceConfigResolution,
                overlaidOptions.KeepAlive ?? KeepAlive,
                overlaidOptions.PrimaryUserAgent ?? PrimaryUserAgent);

        /// <inheritdoc />
        public override int GetHashCode() => throw new NotImplementedException();

        /// <inheritdoc />
        public bool Equals(GrpcChannelOptions other) => throw new NotImplementedException();

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as GrpcChannelOptions);
    }
}
