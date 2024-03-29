﻿/*
 * Copyright 2016 Google Inc. All Rights Reserved.
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

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// A pool of channels for the same service, but with potentially different endpoints. Each endpoint
    /// has a single channel. All channels created by this pool use default application credentials.
    /// This class is thread-safe.
    /// </summary>
    public sealed class ChannelPool
    {
        private readonly ServiceMetadata _serviceMetadata;
        private readonly DefaultChannelCredentialsCache _credentialCache;

        internal bool UseJwtAccessWithScopes => _credentialCache.UseJwtAccessWithScopes;
        
        // TODO: See if we could use ConcurrentDictionary instead of locking. I suspect the issue would be making an atomic
        // "clear and fetch values" for shutdown.
        private readonly Dictionary<Key, ChannelBase> _channels = new Dictionary<Key, ChannelBase>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a channel pool which will use the given service metadata to determine scopes and the use of self-signed JWTs.
        /// </summary>
        /// <param name="serviceMetadata">The metadata for the service that this pool will be used with. Must not be null.</param>
        public ChannelPool(ServiceMetadata serviceMetadata)
        {
            _serviceMetadata = GaxPreconditions.CheckNotNull(serviceMetadata, nameof(serviceMetadata));
            _credentialCache = new DefaultChannelCredentialsCache(serviceMetadata);
        }

        /// <summary>
        /// Shuts down all the currently-allocated channels asynchronously. This does not prevent the channel
        /// pool from being used later on, but the currently-allocated channels will not be reused.
        /// </summary>
        /// <returns>A task which will complete when all the (current) channels have been shut down.</returns>
        public Task ShutdownChannelsAsync()
        {
            List<ChannelBase> channelsToShutdown;
            lock (_lock)
            {
                channelsToShutdown = _channels.Values.ToList();
                _channels.Clear();
            }
            var shutdownTasks = channelsToShutdown.Select(c => c.ShutdownAsync());
            return Task.WhenAll(shutdownTasks);
        }

        /// <summary>
        /// Returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>.
        /// The specified channel options are applied, but only those options.
        /// </summary>
        /// <param name="grpcAdapter">The gRPC implementation to use. Must not be null.</param>
        /// <param name="universeDomain">The universe domain configured for the service client,
        /// to validate against the one configured for the credential. Must not be null.</param>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="channelOptions">The channel options to include. May be null.</param>
        /// <returns>A channel for the specified endpoint.</returns>
        internal ChannelBase GetChannel(GrpcAdapter grpcAdapter, string universeDomain, string endpoint, GrpcChannelOptions channelOptions)
        {
            GaxPreconditions.CheckNotNull(grpcAdapter, nameof(grpcAdapter));
            GaxPreconditions.CheckNotNull(universeDomain, nameof(universeDomain));
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _credentialCache.GetCredentials(universeDomain);
            return GetChannel(grpcAdapter, universeDomain, endpoint, channelOptions, credentials);
        }

        /// <summary>
        /// Asynchronously returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>.
        /// The specified channel options are applied, but only those options.
        /// </summary>
        /// <param name="grpcAdapter">The gRPC implementation to use. Must not be null.</param>
        /// <param name="universeDomain">The universe domain configured for the service client,
        /// to validate against the one configured for the credential. Must not be null.</param>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="channelOptions">The channel options to include. May be null.</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be channel for the specified endpoint.</returns>
        internal async Task<ChannelBase> GetChannelAsync(GrpcAdapter grpcAdapter, string universeDomain, string endpoint, GrpcChannelOptions channelOptions, CancellationToken cancellationToken)
        {
            GaxPreconditions.CheckNotNull(grpcAdapter, nameof(grpcAdapter));
            GaxPreconditions.CheckNotNull(universeDomain, nameof(universeDomain));
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = await _credentialCache.GetCredentialsAsync(universeDomain, cancellationToken).ConfigureAwait(false);
            return GetChannel(grpcAdapter, universeDomain, endpoint, channelOptions, credentials);
        }

        private ChannelBase GetChannel(GrpcAdapter grpcAdapter, string universeDomain, string endpoint, GrpcChannelOptions channelOptions, ChannelCredentials credentials)
        {
            var key = new Key(grpcAdapter, universeDomain, endpoint, channelOptions);

            lock (_lock)
            {
                ChannelBase channel;
                if (!_channels.TryGetValue(key, out channel))
                {
                    channel = grpcAdapter.CreateChannel(_serviceMetadata, endpoint, credentials, channelOptions);
                    _channels[key] = channel;
                }
                return channel;
            }
        }

        private struct Key : IEquatable<Key>
        {
            public readonly string UniverseDomain;
            public readonly string Endpoint;
            public readonly GrpcChannelOptions Options;
            public readonly GrpcAdapter GrpcAdapter;

            public Key(GrpcAdapter grpcAdapter, string universeDomain, string endpoint, GrpcChannelOptions options) =>
                (GrpcAdapter, UniverseDomain, Endpoint, Options) = (grpcAdapter, universeDomain, endpoint, options);

            public override int GetHashCode() =>
                GaxEqualityHelpers.CombineHashCodes(
                    GrpcAdapter.GetHashCode(),
                    UniverseDomain.GetHashCode(),
                    Endpoint.GetHashCode(),
                    Options.GetHashCode());

            public override bool Equals(object obj) => obj is Key other && Equals(other);

            public bool Equals(Key other) =>
                GrpcAdapter.Equals(other.GrpcAdapter) && UniverseDomain.Equals(other.UniverseDomain) && Endpoint.Equals(other.Endpoint) && Options.Equals(other.Options);
        }
    }
}
