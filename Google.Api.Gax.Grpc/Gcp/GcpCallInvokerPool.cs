/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Gcp
{
    /// <summary>
    /// A pool of GCP call invokers for the same service, but with potentially different endpoints and/or channel options.
    /// Each endpoint/options pair has a single <see cref="GcpCallInvoker"/>. All call invokers created by this pool use
    /// default application credentials. This class is thread-safe.
    /// </summary>
    public sealed class GcpCallInvokerPool
    {
        private static GrpcChannelOptions s_defaultOptions = GrpcChannelOptions.Empty
            .WithEnableServiceConfigResolution(false)
            .WithKeepAliveTime(TimeSpan.FromSeconds(60));

        private readonly DefaultChannelCredentialsCache _credentialsCache;

        private readonly ServiceMetadata _serviceMetadata;
        private readonly Dictionary<Key, GcpCallInvoker> _callInvokers = new Dictionary<Key, GcpCallInvoker>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a call invoker pool which will use the given service metadata to determine scopes
        /// and self-signed JWT support.
        /// </summary>
        /// <param name="serviceMetadata">The metadata for the service that this pool will be used with. Must not be null.</param>
        public GcpCallInvokerPool(ServiceMetadata serviceMetadata)
        {
            _serviceMetadata = GaxPreconditions.CheckNotNull(serviceMetadata, nameof(serviceMetadata));
            _credentialsCache = new DefaultChannelCredentialsCache(serviceMetadata);
        }

        /// <summary>
        /// Shuts down all the open channels of all currently-allocated call invokers asynchronously. This does not prevent
        /// the call invoker pool from being used later on, but the currently-allocated call invokers will not be reused.
        /// </summary>
        /// <returns>A task which will complete when all the (current) channels have been shut down.</returns>
        public Task ShutdownChannelsAsync()
        {
            List<GcpCallInvoker> gcpCallInvokersToShutdown;
            lock (_lock)
            {
                gcpCallInvokersToShutdown = _callInvokers.Values.ToList();
                _callInvokers.Clear();
            }
            var shutdownTasks = gcpCallInvokersToShutdown.Select(c => c.ShutdownAsync());
            return Task.WhenAll(shutdownTasks);
        }

        /// <summary>
        /// Returns a call invoker from this pool, creating a new one if there is no call invoker
        /// already associated with <paramref name="endpoint"/> and <paramref name="options"/>.
        /// </summary>
        /// <param name="universeDomain">The universe domain configured for the service client,
        /// to validate against the one configured for the credential. Must not be null.</param>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">The options to use for each channel created by the call invoker. May be null.</param>
        /// <param name="apiConfig">The API configuration used to determine channel keys. Must not be null.</param>
        /// <param name="adapter">The gRPC adapter to use to create call invokers. Must not be null.</param>
        /// <returns>A call invoker for the specified endpoint.</returns>
        public GcpCallInvoker GetCallInvoker(string universeDomain, string endpoint, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _credentialsCache.GetCredentials(universeDomain);
            GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig));
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            return GetCallInvoker(universeDomain, endpoint, credentials, options, apiConfig, adapter);
        }

        /// <summary>
        /// Asynchronously returns a call invoker from this pool, creating a new one if there is no call invoker
        /// already associated with <paramref name="endpoint"/> and <paramref name="options"/>.
        /// </summary>
        /// <param name="universeDomain">The universe domain configured for the service client,
        /// to validate against the one configured for the credential. Must not be null.</param>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">The options to use for each channel created by the call invoker. May be null.</param>
        /// <param name="apiConfig">The API configuration used to determine channel keys. Must not be null.</param>
        /// <param name="adapter">The gRPC adapter to use to create call invokers. Must not be null.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be a call invoker for the specified endpoint.</returns>
        public async Task<GcpCallInvoker> GetCallInvokerAsync(string universeDomain, string endpoint, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter, CancellationToken cancellationToken)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig));
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            var credentials = await _credentialsCache.GetCredentialsAsync(universeDomain, cancellationToken).ConfigureAwait(false);
            return GetCallInvoker(universeDomain, endpoint, credentials, options, apiConfig, adapter);
        }

        /// <summary>
        /// Returns a call invoker from this pool, creating a new one if there is no call invoker
        /// already associated with <paramref name="endpoint"/> and <paramref name="options"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">The options to use for each channel created by the call invoker. May be null.</param>
        /// <param name="apiConfig">The API configuration used to determine channel keys. Must not be null.</param>
        /// <param name="adapter">The gRPC adapter to use to create call invokers. Must not be null.</param>
        /// <returns>A call invoker for the specified endpoint.</returns>
        [Obsolete("Please use the overloads that accept a universe domain to make certain the credentials used are valid in the target universe domain.")]
        public GcpCallInvoker GetCallInvoker(string endpoint, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter)
        {
            // We use the dedault universe domain here for obtaining credentials and the call invoker as this is obsolete code
            // that's not multi universe domain enabled, so it must only ever execute in the default universe domain.
            // If the credential being used is not from the default universe domain, validation will fail and no requests will be made.
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _credentialsCache.GetCredentials(ServiceMetadata.DefaultUniverseDomain);
            GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig));
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            return GetCallInvoker(ServiceMetadata.DefaultUniverseDomain, endpoint, credentials, options, apiConfig, adapter);
        }

        /// <summary>
        /// Asynchronously returns a call invoker from this pool, creating a new one if there is no call invoker
        /// already associated with <paramref name="endpoint"/> and <paramref name="options"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">The options to use for each channel created by the call invoker. May be null.</param>
        /// <param name="apiConfig">The API configuration used to determine channel keys. Must not be null.</param>
        /// <param name="adapter">The gRPC adapter to use to create call invokers. Must not be null.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be a call invoker for the specified endpoint.</returns>
        [Obsolete("Please use the overloads that accept a universe domain to make certain the credentials used are valid in the target universe domain.")]
        public async Task<GcpCallInvoker> GetCallInvokerAsync(string endpoint, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter)
        {
            // We use the dedault universe domain here for obtaining credentials and the call invoker as this is obsolete code
            // that's not multi universe domain enabled, so it must only ever execute in the default universe domain.
            // If the credential being used is not from the default universe domain, validation will fail and no requests will be made.
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig));
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            var credentials = await _credentialsCache.GetCredentialsAsync(ServiceMetadata.DefaultUniverseDomain, default).ConfigureAwait(false);
            return GetCallInvoker(ServiceMetadata.DefaultUniverseDomain, endpoint, credentials, options, apiConfig, adapter);
        }

        private GcpCallInvoker GetCallInvoker(string universeDomain, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter)
        {
            var effectiveOptions = s_defaultOptions.MergedWith(options ?? GrpcChannelOptions.Empty);
            apiConfig = apiConfig.Clone();
            var key = new Key(universeDomain, endpoint, effectiveOptions, apiConfig, adapter);

            lock (_lock)
            {
                if (!_callInvokers.TryGetValue(key, out GcpCallInvoker callInvoker))
                {
                    callInvoker = new GcpCallInvoker(_serviceMetadata, endpoint, credentials, effectiveOptions, apiConfig, adapter);
                    _callInvokers[key] = callInvoker;
                }
                return callInvoker;
            }
        }

        private struct Key : IEquatable<Key>
        {
            public readonly string UniverseDomain;
            public readonly string Endpoint;
            public readonly GrpcChannelOptions Options;
            public readonly ApiConfig Config;
            public readonly GrpcAdapter GrpcAdapter;

            public Key(string universedomain, string endpoint, GrpcChannelOptions options, ApiConfig config, GrpcAdapter adapter)
            {
                UniverseDomain = universedomain;
                Endpoint = endpoint;
                Options = options;
                Config = config;
                GrpcAdapter = adapter;
            }

            public override int GetHashCode() =>
                GaxEqualityHelpers.CombineHashCodes(
                    UniverseDomain.GetHashCode(),
                    Endpoint.GetHashCode(),
                    Options.GetHashCode(),
                    Config.GetHashCode(),
                    GrpcAdapter.GetHashCode());

            public override bool Equals(object obj) => obj is Key other && Equals(other);

            public bool Equals(Key other) =>
                UniverseDomain.Equals(other.UniverseDomain) &&
                Endpoint.Equals(other.Endpoint) &&
                Options.Equals(other.Options) &&
                Config.Equals(other.Config) &&
                GrpcAdapter.Equals(other.GrpcAdapter);
        }
    }
}