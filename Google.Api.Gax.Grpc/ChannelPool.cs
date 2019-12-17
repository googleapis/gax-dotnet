/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly GrpcChannelOptions s_defaultOptions = GrpcChannelOptions.FromKeepAlive(TimeSpan.FromMinutes(1))
            .MergedWith(GrpcChannelOptions.FromEnableServiceConfigResolution(false));

        private readonly ChannelFactory _channelFactory;
        private readonly IEnumerable<string> _scopes;

        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// The same channel credentials are used by all pools. The field is initialized in the constructor, as it uses
        /// _scopes, and you can't refer to an instance field within an instance field initializer.
        /// </summary>
        private readonly Lazy<Task<ChannelCredentials>> _lazyScopedDefaultChannelCredentials;

        // TODO: See if we could use ConcurrentDictionary instead of locking. I suspect the issue would be making an atomic
        // "clear and fetch values" for shutdown.
        private readonly Dictionary<Key, ChannelBase> _channels = new Dictionary<Key, ChannelBase>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a channel pool which will apply the specified scopes to the default application credentials
        /// if they require any.
        /// </summary>
        /// <param name="channelFactory">The channel factory to use, or null for the default channel factory.</param>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        public ChannelPool(ChannelFactory channelFactory, IEnumerable<string> scopes)
        {
            _channelFactory = channelFactory;
            // Always take a copy of the provided scopes, then check the copy doesn't contain any nulls.
            _scopes = GaxPreconditions.CheckNotNull(scopes, nameof(scopes)).ToList();
            GaxPreconditions.CheckArgument(!_scopes.Any(x => x == null), nameof(scopes), "Scopes must not contain any null references");
            // In theory, we don't actually need to store the scopes as field in this class. We could capture a local variable here.
            // However, it won't be any more efficient, and having the scopes easily available when debugging could be handy.
            _lazyScopedDefaultChannelCredentials = new Lazy<Task<ChannelCredentials>>(() => Task.Run(CreateChannelCredentialsUncached));
        }

        private async Task<ChannelCredentials> CreateChannelCredentialsUncached()
        {
            var appDefaultCredentials = await GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);
            if (appDefaultCredentials.IsCreateScopedRequired)
            {
                appDefaultCredentials = appDefaultCredentials.CreateScoped(_scopes);
            }
            return appDefaultCredentials.ToChannelCredentials();
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
            // FIXME: Reinstate this
            return Task.CompletedTask;
            /*
            var shutdownTasks = channelsToShutdown.Select(c => c.ShutdownAsync());
            return Task.WhenAll(shutdownTasks);*/
        }

        /// <summary>
        /// Returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>. Default channel options are applied.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <returns>A channel for the specified endpoint.</returns>
        public ChannelBase GetChannel(ServiceEndpoint endpoint) => GetChannel(endpoint, s_defaultOptions);

        /// <summary>
        /// Asynchronously returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>. Default channel options are applied.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be channel for the specified endpoint.</returns>
        public Task<ChannelBase> GetChannelAsync(ServiceEndpoint endpoint) => GetChannelAsync(endpoint, s_defaultOptions);

        /// <summary>
        /// Returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>.
        /// The specified channel options are applied, but only those options.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="channelOptions">The channel options to include. May be null.</param>
        /// <returns>A channel for the specified endpoint.</returns>
        public ChannelBase GetChannel(ServiceEndpoint endpoint, GrpcChannelOptions channelOptions)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _lazyScopedDefaultChannelCredentials.Value.ResultWithUnwrappedExceptions();
            return GetChannel(endpoint, channelOptions, credentials);
        }

        /// <summary>
        /// Asynchronously returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>.
        /// The specified channel options are applied, but only those options.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="channelOptions">The channel options to include. May be null.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be channel for the specified endpoint.</returns>
        public async Task<ChannelBase> GetChannelAsync(ServiceEndpoint endpoint, GrpcChannelOptions channelOptions)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = await _lazyScopedDefaultChannelCredentials.Value.ConfigureAwait(false);
            return GetChannel(endpoint, channelOptions, credentials);
        }

        private ChannelBase GetChannel(ServiceEndpoint endpoint, GrpcChannelOptions channelOptions, ChannelCredentials credentials)
        {
            var key = new Key(endpoint, channelOptions);

            lock (_lock)
            {
                ChannelBase channel;
                if (!_channels.TryGetValue(key, out channel))
                {
                    // FIXME: Handle a default channel factory (null).
                    channel = _channelFactory.Invoke(endpoint, credentials, channelOptions);
                    _channels[key] = channel;
                }
                return channel;
            }
        }

        private struct Key : IEquatable<Key>
        {
            public readonly ServiceEndpoint Endpoint;
            public readonly GrpcChannelOptions Options;

            public Key(ServiceEndpoint endpoint, GrpcChannelOptions options)
            {
                Endpoint = endpoint;
                Options = options;
            }

            public override int GetHashCode() =>
                GaxEqualityHelpers.CombineHashCodes(
                    Endpoint.GetHashCode(),
                    Options.GetHashCode());

            public override bool Equals(object obj) => obj is Key other && Equals(other);

            public bool Equals(Key other) =>
                Endpoint.Equals(other.Endpoint) && Options.Equals(other.Options);
        }
    }
}
