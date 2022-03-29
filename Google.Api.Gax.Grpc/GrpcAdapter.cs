﻿/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Rest;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Interoperability layer for different gRPC transports. Concrete subclasses are
    /// <see cref="GrpcCoreAdapter"/>, <see cref="GrpcNetClientAdapter"/> and <see cref="RestGrpcAdapter"/>.
    /// </summary>
    /// <remarks>
    /// This is an abstract class with all concrete subclasses internal, and internal abstract methods
    /// to prevent instantiation elsewhere. (The abstraction itself may change over time.)
    /// </remarks>
    public abstract class GrpcAdapter
    {
        private const string AdapterOverrideEnvironmentVariable = "GRPC_DEFAULT_ADAPTER_OVERRIDE";

        private static readonly Lazy<GrpcAdapter> s_defaultFactory = new Lazy<GrpcAdapter>(CreateDefaultAdapter, LazyThreadSafetyMode.PublicationOnly);

        private readonly GrpcTransports _supportedTransports;

        private protected GrpcAdapter(GrpcTransports supportedTransports)
        {
            _supportedTransports = supportedTransports;
        }

        /// <summary>
        /// Returns whether or not this adapter supports the specified API.
        /// </summary>
        /// <param name="serviceMetadata">The descriptor of the API. Must not be null.</param>
        /// <returns><c>true</c> if this adapter supports the given API; <c>false</c> otherwise.</returns>
        public bool SupportsApi(ServiceMetadata serviceMetadata)
        {
            GaxPreconditions.CheckNotNull(serviceMetadata, nameof(serviceMetadata));
            return (serviceMetadata.Transports & _supportedTransports) != 0;
        }

        /// <summary>
        /// Returns a fallback provider suitable for the given API
        /// </summary>
        /// <param name="serviceMetadata">The descriptor of the API. Must not be null.</param>
        /// <returns>A suitable GrpcAdapter for the given API, preferring the use of the binary gRPC transport where available.</returns>
        public static GrpcAdapter GetFallbackAdapter(ServiceMetadata serviceMetadata)
        {
            // TODO: Some way of indicating a preference? Or just set the adapter in the client builder...?
            if (serviceMetadata.Transports.HasFlag(GrpcTransports.Grpc))
            {
                // TODO: This is all a bit of a mess.
                return DefaultAdapter;
            }
            else if (serviceMetadata.Transports.HasFlag(GrpcTransports.Rest))
            {
                return RestGrpcAdapter.Default;
            }
            else
            {
                throw new ArgumentException("No known adapters support the given API.");
            }
        }

        /// <summary>
        /// Creates a channel for the given endpoint, using the given credentials and options.
        /// </summary>
        /// <param name="serviceMetadata">The metadata for the service. Must not be null.</param>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use. Must not be null.</param>
        /// <param name="options">The channel options to use. Must not be null.</param>
        /// <returns>A channel for the specified settings.</returns>
        internal ChannelBase CreateChannel(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            if (!SupportsApi(serviceMetadata))
            {
                throw new ArgumentException($"API {serviceMetadata.Name} does not have any transports in common with {GetType().Name}");
            }
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(credentials, nameof(credentials));
            GaxPreconditions.CheckNotNull(options, nameof(options));
            return CreateChannelImpl(serviceMetadata, endpoint, credentials, options);
        }

        /// <summary>
        /// Creates a channel for the given endpoint, using the given credentials and options. All parameters
        /// are pre-validated to be non-null.
        /// </summary>
        /// <param name="apiMetadata"></param>
        /// <param name="endpoint">The endpoint to connect to. Will not be null.</param>
        /// <param name="credentials">The channel credentials to use. Will not be null.</param>
        /// <param name="options">The channel options to use. Will not be null.</param>
        /// <returns>A channel for the specified settings.</returns>
        private protected abstract ChannelBase CreateChannelImpl(ServiceMetadata apiMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options);

        /// <summary>
        /// Returns the default gRPC adapter based on the available gRPC implementations.
        /// </summary>
        public static GrpcAdapter DefaultAdapter => s_defaultFactory.Value;

        private static GrpcAdapter CreateDefaultAdapter() =>
            GetDefaultFromEnvironmentVariable() ?? DetectDefaultPreferringGrpcNetClient();

        private static GrpcAdapter GetDefaultFromEnvironmentVariable() =>
            GetDefaultFromEnvironmentVariable(Environment.GetEnvironmentVariable(AdapterOverrideEnvironmentVariable));

        // Visible for testing, and accepting a string for simplicity (to avoid modifying the environment in tests).
        internal static GrpcAdapter GetDefaultFromEnvironmentVariable(string environmentVariable)
        {
            var env = environmentVariable?.Trim();
            return env switch
            {
                "Grpc.Net.Client" => GrpcNetClientAdapter.Default,
                "Grpc.Core" => GrpcCoreAdapter.Instance,
                null => null,
                "" => null,
                _ => throw new InvalidOperationException($"Unknown value for environment variable '{AdapterOverrideEnvironmentVariable}': '{env}'")
            };
        }

        // TODO: Is this really what we want? Definitely simple, but not great in other ways...
        private static GrpcAdapter DetectDefaultPreferringGrpcNetClient()
        {
            try
            {
                GrpcChannel.ForAddress("https://ignored.com");
                return GrpcNetClientAdapter.Default;
            }
            catch
            {
                return GrpcCoreAdapter.Instance;
            }
        }

    }
}
