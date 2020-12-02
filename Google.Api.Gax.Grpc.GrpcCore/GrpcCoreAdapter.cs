/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc.GrpcCore
{
    /// <summary>
    /// Implementation of <see cref="GrpcAdapter"/> for Grpc.Core.
    /// </summary>
    public sealed class GrpcCoreAdapter : GrpcAdapter
    {
        internal const string ServiceConfigDisableResolution = "grpc.service_config_disable_resolution";
        internal const string KeepAliveTimeMs = "grpc.keepalive_time_ms";
        internal const string KeepAliveTimeoutMs = "grpc.keepalive_timeout_ms";

        /// <summary>
        /// Returns the singleton instance of this class.
        /// </summary>
        public static GrpcCoreAdapter Instance { get; } = new GrpcCoreAdapter();

        private GrpcCoreAdapter()
        {
        }

        /// <inheritdoc />
        protected override ChannelBase CreateChannelImpl(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            // TODO: Cache the result of ConvertOptions? It's probably not called terribly frequently.
            new Channel(endpoint, credentials, ConvertOptions(options));

        /// <summary>
        /// Converts a <see cref="GrpcChannelOptions"/> (defined in Google.Api.Gax.Grpc) into a list
        /// of <see cref="ChannelOption"/> (defined in Grpc.Core).
        /// </summary>
        /// <param name="options">The options to convert. Must not be null.</param>
        /// <returns>The converted list of options.</returns>
        public IReadOnlyList<ChannelOption> ConvertOptions(GrpcChannelOptions options)
        {
            GaxPreconditions.CheckNotNull(options, nameof(options));
            List<ChannelOption> ret = new List<ChannelOption>();
            if (options.EnableServiceConfigResolution is bool enableServiceConfigResolution)
            {
                ret.Add(new ChannelOption(ServiceConfigDisableResolution, enableServiceConfigResolution ? 0 : 1));
            }
            if (options.KeepAliveTime is TimeSpan keepAlive)
            {
                ret.Add(new ChannelOption(KeepAliveTimeMs, (int) keepAlive.TotalMilliseconds));
            }
            if (options.KeepAliveTimeout is TimeSpan keepAliveout)
            {
                ret.Add(new ChannelOption(KeepAliveTimeoutMs, (int) keepAliveout.TotalMilliseconds));
            }
            if (options.MaxReceiveMessageSize is int maxReceiveMessageSize)
            {
                ret.Add(new ChannelOption(ChannelOptions.MaxReceiveMessageLength, maxReceiveMessageSize));
            }
            if (options.MaxSendMessageSize is int maxSendMessageSize)
            {
                ret.Add(new ChannelOption(ChannelOptions.MaxSendMessageLength, maxSendMessageSize));
            }
            if (options.PrimaryUserAgent is string primaryUserAgent)
            {
                ret.Add(new ChannelOption(ChannelOptions.PrimaryUserAgentString, primaryUserAgent));
            }
            foreach (var customOption in options.CustomOptions)
            {
                var channelOption = customOption.Type switch
                {
                    GrpcChannelOptions.CustomOption.OptionType.Integer => new ChannelOption(customOption.Name, customOption.IntegerValue),
                    GrpcChannelOptions.CustomOption.OptionType.String => new ChannelOption(customOption.Name, customOption.StringValue),
                    _ => throw new InvalidOperationException($"Unknown custom option type: {customOption.Type}")
                };
                ret.Add(channelOption);
            }
            return ret.AsReadOnly();
        }
    }
}
