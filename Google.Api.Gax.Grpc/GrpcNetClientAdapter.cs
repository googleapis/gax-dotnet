/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Grpc.Net.Client;
using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Implementation of <see cref="GrpcAdapter"/> for Grpc.Net.Client.
    /// </summary>
    public sealed class GrpcNetClientAdapter : GrpcAdapter
    {
        // Note: this is "Default" rather than "Instance" as we expect to have other factory methods later, e.g. accepting
        // an HTTP client factory.

        /// <summary>
        /// Returns the default instance of this class.
        /// </summary>
        public static GrpcNetClientAdapter Default { get; } = new GrpcNetClientAdapter();

        private GrpcNetClientAdapter()
        {
        }

        /// <inheritdoc />
        protected override ChannelBase CreateChannelImpl(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            var grpcNetClientOptions = ConvertOptions(credentials, options);
            var address = ConvertEndpoint(endpoint);
            return GrpcChannel.ForAddress(address, grpcNetClientOptions);
        }

        // Internal for testing
        internal static global::Grpc.Net.Client.GrpcChannelOptions ConvertOptions(ChannelCredentials credentials, GrpcChannelOptions options)
        {
            // If service config resolution is explicitly enabled, throw - we can't support that,
            // and users may be depending on it.
            if (options.EnableServiceConfigResolution == true)
            {
                throw new ArgumentException($"{nameof(options.EnableServiceConfigResolution)} is not currently supported in {nameof(GrpcNetClientAdapter)}");
            }

            if (options.CustomOptions.Count > 0)
            {
                throw new ArgumentException($"Custom options are not currently supported in {nameof(GrpcNetClientAdapter)}");
            }

            // Options we ignore:
            // - PrimaryUserAgent
            // - KeepAliveTime

            return new global::Grpc.Net.Client.GrpcChannelOptions
            {
                Credentials = credentials,
                MaxReceiveMessageSize = options.MaxReceiveMessageSize,
                MaxSendMessageSize = options.MaxSendMessageSize
            };
        }

        // Internal for testing
        internal static string ConvertEndpoint(string endpoint) =>
            // Note that we assume HTTPS for any bare address; this feels like a reasonable assumption for now.
            endpoint.StartsWith("http:", StringComparison.Ordinal) || endpoint.StartsWith("https:", StringComparison.Ordinal)
            ? endpoint : $"https://{endpoint}";
    }
}
