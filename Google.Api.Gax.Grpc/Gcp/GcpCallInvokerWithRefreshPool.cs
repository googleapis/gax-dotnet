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
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Gcp
{
    /// <summary>
    /// A pool of GCP call invokers for the same service, but with potentially different endpoints and/or channel options.
    /// Each endpoint/options pair has a single <see cref="GcpCallInvoker"/>. All call invokers created by this pool use
    /// default application credentials. This class is thread-safe.
    /// </summary>
    public sealed class GcpCallInvokerWithRefreshPool
    {
        private static GrpcChannelOptions s_defaultOptions = GrpcChannelOptions.Empty
            .WithEnableServiceConfigResolution(false)
            .WithKeepAliveTime(TimeSpan.FromSeconds(60));

        private readonly DefaultChannelCredentialsCache _credentialsCache;

        private readonly ServiceMetadata _serviceMetadata;
        private readonly Dictionary<Key, GcpCallInvokerWithRefresh> _callInvokers = new Dictionary<Key, GcpCallInvokerWithRefresh>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a call invoker pool which will use the given service metadata to determine scopes
        /// and self-signed JWT support.
        /// </summary>
        /// <param name="serviceMetadata">The metadata for the service that this pool will be used with. Must not be null.</param>
        public GcpCallInvokerWithRefreshPool(ServiceMetadata serviceMetadata)
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
            List<GcpCallInvokerWithRefresh> gcpCallInvokersToShutdown;
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
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">The options to use for each channel created by the call invoker. May be null.</param>
        /// <param name="apiConfig">The API configuration used to determine channel keys. Must not be null.</param>
        /// <param name="adapter">The gRPC adapter to use to create call invokers. Must not be null.</param>
        /// <param name="channelPrimer"></param>
        /// <param name="maintenanceDelay"></param>
        /// <param name="timeout"></param>
        /// <returns>A call invoker for the specified endpoint.</returns>
        public GcpCallInvokerWithRefresh GetCallInvoker(string endpoint, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter, Action<CallInvoker> channelPrimer, TimeSpan maintenanceDelay, TimeSpan timeout)
        {
            Console.WriteLine("inside GcpCallInvokerWithRefreshing");
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _credentialsCache.GetCredentials();
            GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig));
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            return GetCallInvoker(endpoint, credentials, options, apiConfig, adapter, channelPrimer, maintenanceDelay, timeout);
        }

        /// <summary>
        /// Asynchronously returns a call invoker from this pool, creating a new one if there is no call invoker
        /// already associated with <paramref name="endpoint"/> and <paramref name="options"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">The options to use for each channel created by the call invoker. May be null.</param>
        /// <param name="apiConfig">The API configuration used to determine channel keys. Must not be null.</param>
        /// <param name="adapter">The gRPC adapter to use to create call invokers. Must not be null.</param>
        /// <param name="channelPrimer"></param>
        /// <param name="maintenanceDelay"></param>
        /// <param name="timeout"></param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be a call invoker for the specified endpoint.</returns>
        public async Task<GcpCallInvokerWithRefresh> GetCallInvokerAsync(string endpoint, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter, Action<CallInvoker> channelPrimer, TimeSpan maintenanceDelay, TimeSpan timeout)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig));
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            var credentials = await _credentialsCache.GetCredentialsAsync().ConfigureAwait(false);
            return GetCallInvoker(endpoint, credentials, options, apiConfig, adapter, channelPrimer, maintenanceDelay, timeout);
        }

        private GcpCallInvokerWithRefresh GetCallInvoker(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter, Action<CallInvoker> channelPrimer, TimeSpan maintenanceDelay, TimeSpan timeout)
        {
            var effectiveOptions = s_defaultOptions.MergedWith(options ?? GrpcChannelOptions.Empty);
            apiConfig = apiConfig.Clone();
            var key = new Key(endpoint, effectiveOptions, apiConfig, adapter);

            lock (_lock)
            {
                if (!_callInvokers.TryGetValue(key, out GcpCallInvokerWithRefresh callInvoker))
                {
                    callInvoker = new GcpCallInvokerWithRefresh(_serviceMetadata, endpoint, credentials, effectiveOptions, apiConfig, adapter, channelPrimer, maintenanceDelay, timeout);
                    _callInvokers[key] = callInvoker;
                }
                return callInvoker;
            }
        }

        private struct Key : IEquatable<Key>
        {
            public readonly string Endpoint;
            public readonly GrpcChannelOptions Options;
            public readonly ApiConfig Config;
            public readonly GrpcAdapter GrpcAdapter;

            public Key(string endpoint, GrpcChannelOptions options, ApiConfig config, GrpcAdapter adapter)
            {
                Endpoint = endpoint;
                Options = options;
                Config = config;
                GrpcAdapter = adapter;
            }

            public override int GetHashCode() =>
                GaxEqualityHelpers.CombineHashCodes(
                    Endpoint.GetHashCode(),
                    Options.GetHashCode(),
                    Config.GetHashCode(),
                    GrpcAdapter.GetHashCode());

            public override bool Equals(object obj) => obj is Key other && Equals(other);

            public bool Equals(Key other) =>
                Endpoint.Equals(other.Endpoint) &&
                Options.Equals(other.Options) &&
                Config.Equals(other.Config) &&
                GrpcAdapter.Equals(other.GrpcAdapter);
        }
    }
}