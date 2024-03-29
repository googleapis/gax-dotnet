﻿/*
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
        private Action<global::Grpc.Net.Client.GrpcChannelOptions> _optionsConfigurationAction;

        // Note: this is "Default" rather than "Instance" as we expect to have other factory methods later, e.g. accepting
        // an HTTP client factory.

        /// <summary>
        /// Returns the default instance of this class.
        /// </summary>
        public static GrpcNetClientAdapter Default { get; } = new GrpcNetClientAdapter(null);

        private GrpcNetClientAdapter(Action<global::Grpc.Net.Client.GrpcChannelOptions> optionsConfigurationAction) : base(ApiTransports.Grpc)
        {
            _optionsConfigurationAction = optionsConfigurationAction;
        }

        /// <summary>
        /// Returns a new instance based on this one, but with the additional options configurer specified.
        /// The options configurer is called after creating the <see cref="global::Grpc.Net.Client.GrpcChannelOptions"/> from
        /// other settings, but before creating the <see cref="GrpcChannel"/>.
        /// </summary>
        /// <param name="configure">An optional configuration delegate to apply to instances of <see cref="global::Grpc.Net.Client.GrpcChannelOptions"/>
        /// before they are provided to a <see cref="GrpcChannel"/>, after any configuration applied by this adapter. May be null,
        /// in which case a new instance is returned but with the same option configurer as this one.
        /// </param>
        /// <returns>A new adapter based on this one, but with an additional channel options configuration action.</returns>
        public GrpcNetClientAdapter WithAdditionalOptions(Action<global::Grpc.Net.Client.GrpcChannelOptions> configure) =>
            new GrpcNetClientAdapter(_optionsConfigurationAction + configure);

        /// <inheritdoc />
        private protected override ChannelBase CreateChannelImpl(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            var grpcNetClientOptions = ConvertOptions(credentials, options);
            _optionsConfigurationAction?.Invoke(grpcNetClientOptions);
            bool secureCredentials = SecureChannelDetector.AreCredentialsSecure(credentials);
            var address = ConvertEndpoint(endpoint, secureCredentials);
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

            // Options we ignore:
            // - PrimaryUserAgent
            // - KeepAliveTime
            // - Custom options

            return new global::Grpc.Net.Client.GrpcChannelOptions
            {
                Credentials = credentials,
                MaxReceiveMessageSize = options.MaxReceiveMessageSize,
                MaxSendMessageSize = options.MaxSendMessageSize
            };
        }

        // Internal for testing
        internal static string ConvertEndpoint(string endpoint, bool secureCredentials)
        {
            string defaultScheme = secureCredentials ? "https" : "http";
            // We assume HTTPS for any bare address if the credentials are secure, or HTTP otherwise.
            // This matches what GrpcChannel itself does in terms of validation.
            return endpoint.StartsWith("http:", StringComparison.Ordinal) || endpoint.StartsWith("https:", StringComparison.Ordinal)
                ? endpoint : $"{defaultScheme}://{endpoint}";
        }

        // Internal for testing
        internal class SecureChannelDetector : ChannelCredentialsConfiguratorBase
        {
            private bool? IsSecure { get; set; }

            internal static bool AreCredentialsSecure(ChannelCredentials credentials)
            {
                var instance = new SecureChannelDetector();
                credentials.InternalPopulateConfiguration(instance, null);
                // Default to detecting credentials as insecure.
                return instance.IsSecure ?? false;
            }

            public override void SetCompositeCredentials(object state, ChannelCredentials channelCredentials, CallCredentials callCredentials) =>
                channelCredentials.InternalPopulateConfiguration(this, state);

            public override void SetInsecureCredentials(object state) =>
                IsSecure = false;

            public override void SetSslCredentials(object state, string rootCertificates, KeyCertificatePair keyCertificatePair, VerifyPeerCallback verifyPeerCallback) =>
                IsSecure = true;
        }
    }
}
