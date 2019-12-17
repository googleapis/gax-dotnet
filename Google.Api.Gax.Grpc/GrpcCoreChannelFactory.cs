/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc
{
    internal sealed class GrpcCoreChannelFactory
    {
        internal const string ServiceConfigDisableResolution = "grpc.service_config_disable_resolution";
        internal const string KeepAliveTimeMs = "grpc.keepalive_time_ms";

#if CORE_API_ONLY
        internal ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            throw new NotImplementedException("GrpcCoreChannelFactory is not implemented in CORE_API_ONLY builds");
#else
        internal ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            // TODO: Cache the result of ConvertOptions? It's probably not called terribly frequently.
            new Channel(endpoint, credentials, ConvertOptions(options));

        // Internal for the sake of testing.
        internal static List<ChannelOption> ConvertOptions(GrpcChannelOptions options)
        {
            List<ChannelOption> ret = new List<ChannelOption>();
            if (options.EnableServiceConfigResolution is bool enableServiceConfigResolution)
            {
                ret.Add(new ChannelOption("grpc.service_config_disable_resolution", enableServiceConfigResolution ? 0 : 1));
            }
            if (options.KeepAliveTime is TimeSpan keepAlive)
            {
                ret.Add(new ChannelOption("grpc.keepalive_time_ms", (int) keepAlive.TotalMilliseconds));
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
            return ret;
        }
#endif
    }
}
