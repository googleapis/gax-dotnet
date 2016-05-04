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

namespace Google.Api.Gax
{
    /// <summary>
    /// A pool of channels for the same service, but with potentially different endpoints. Each endpoint
    /// has a single channel. All channels created by this pool use default application credentials.
    /// This class is thread-safe.
    /// </summary>
    public sealed class ChannelPool
    {
        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// The same channel credentials are used by all pools.
        /// </summary>
        private static readonly Lazy<Task<ChannelCredentials>> s_lazyDefaultChannelCredentials
            = new Lazy<Task<ChannelCredentials>>(
                () => Task.Run(async () => (await GoogleCredential.GetApplicationDefaultAsync()).ToChannelCredentials()));

        // TODO: See if we could use ConcurrentDictionary instead of locking. I suspect the issue would be making an atomic
        // "clear and fetch values" for shutdown.
        private readonly Dictionary<ServiceEndpoint, Channel> _channels = new Dictionary<ServiceEndpoint, Channel>();
        private readonly object _lock = new object();

        /// <summary>
        /// Shuts down all the currently-allocated channels asynchronously. This does not prevent the channel
        /// pool from being used later on, but the currently-allocated channels will not be reused.
        /// </summary>
        /// <returns></returns>
        public Task ShutdownChannelsAsync()
        {
            List<Channel> channelsToShutdown;
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
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <returns>A channel for the specified endpoint.</returns>
        public Channel GetChannel(ServiceEndpoint endpoint)
        {
            var credentials = s_lazyDefaultChannelCredentials.Value.Result;
            return GetChannel(endpoint, credentials);
        }

        /// <summary>
        /// Asynchronously returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be channel for the specified endpoint.</returns>
        public async Task<Channel> GetChannelAsync(ServiceEndpoint endpoint)
        {
            var credentials = await s_lazyDefaultChannelCredentials.Value;
            return GetChannel(endpoint, credentials);
        }

        private Channel GetChannel(ServiceEndpoint endpoint, ChannelCredentials credentials)
        {
            lock (_lock)
            {
                Channel channel;
                if (!_channels.TryGetValue(endpoint, out channel))
                {
                    channel = new Channel(endpoint.Host, endpoint.Port, credentials);
                    _channels[endpoint] = channel;
                }
                return channel;
            }
        }
    }
}
