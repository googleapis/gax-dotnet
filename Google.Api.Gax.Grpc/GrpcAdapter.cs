/*
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
    /// Interoperability layer for the aspects of gRPC that aren't covered by Grpc.Core.Api.
    /// </summary>
    public abstract class GrpcAdapter
    {
        private const string AdapterOverrideEnvironmentVariable = "GRPC_DEFAULT_ADAPTER_OVERRIDE";

        private static readonly Lazy<GrpcAdapter> s_defaultFactory = new Lazy<GrpcAdapter>(CreateDefaultAdapter, LazyThreadSafetyMode.PublicationOnly);

        private GrpcTransports _supportedTransports;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supportedTransports"></param>
        protected GrpcAdapter(GrpcTransports supportedTransports)
        {
            // TODO: Validation that all flags are valid, and that there's at least one flag?
            _supportedTransports = supportedTransports;
        }

        /// <summary>
        /// Creates a channel for the given endpoint, using the given credentials and options.
        /// </summary>
        /// <param name="apiDescriptor"></param>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use. Must not be null.</param>
        /// <param name="options">The channel options to use. Must not be null.</param>
        /// <returns>A channel for the specified settings.</returns>
        public ChannelBase CreateChannel(GrpcApiDescriptor apiDescriptor, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            GaxPreconditions.CheckNotNull(apiDescriptor, nameof(apiDescriptor));
            if ((apiDescriptor.Transports & _supportedTransports) == 0)
            {
                throw new ArgumentException($"API {apiDescriptor.Name} does not have any transports in common with {GetType().Name}");
            }
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(credentials, nameof(credentials));
            GaxPreconditions.CheckNotNull(options, nameof(options));
            return CreateChannelImpl(apiDescriptor, endpoint, credentials, options);
        }

        /// <summary>
        /// Creates a channel for the given endpoint, using the given credentials and options. All parameters
        /// are pre-validated to be non-null.
        /// </summary>
        /// <param name="apiDescriptor"></param>
        /// <param name="endpoint">The endpoint to connect to. Will not be null.</param>
        /// <param name="credentials">The channel credentials to use. Will not be null.</param>
        /// <param name="options">The channel options to use. Will not be null.</param>
        /// <returns>A channel for the specified settings.</returns>
        protected abstract ChannelBase CreateChannelImpl(GrpcApiDescriptor apiDescriptor, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grpcApiDescriptor"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static GrpcAdapter GetFallbackAdapter(GrpcApiDescriptor grpcApiDescriptor)
        {
            // TODO: Some way of indicating a preference? Or just set the adapter in the client builder...?
            if (grpcApiDescriptor.Transports.HasFlag(GrpcTransports.Grpc))
            {
                // TODO: This is all a bit of a mess.
                return DefaultAdapter;
            }
            else if (grpcApiDescriptor.Transports.HasFlag(GrpcTransports.Rest))
            {
                return RestGrpcAdapter.Default;
            }
            else
            {
                throw new ArgumentException("No known transports");
            }
        }
    }
}
