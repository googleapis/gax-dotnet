/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
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
        private readonly DefaultChannelCredentialsCache _credentialsCache;

        // TODO: See if we could use ConcurrentDictionary instead of locking. I suspect the issue would be making an atomic
        // "clear and fetch values" for shutdown.
        private readonly Dictionary<ServiceEndpoint, Channel> _channels = new Dictionary<ServiceEndpoint, Channel>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a channel pool which will apply the specified scopes to the default application credentials
        /// if they require any.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        public ChannelPool(IEnumerable<string> scopes) =>
            _credentialsCache = new DefaultChannelCredentialsCache(scopes);

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
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _credentialsCache.GetCredentials();
            return GetChannel(endpoint, credentials);
        }

        /// <summary>
        /// Asynchronously returns a channel from this pool, creating a new one if there is no channel
        /// already associated with <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be a channel for the specified endpoint.</returns>
        public async Task<Channel> GetChannelAsync(ServiceEndpoint endpoint)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = await _credentialsCache.GetCredentialsAsync().ConfigureAwait(false);
            return GetChannel(endpoint, credentials);
        }

        private Channel GetChannel(ServiceEndpoint endpoint, ChannelCredentials credentials)
        {
            lock (_lock)
            {
                Channel channel;
                if (!_channels.TryGetValue(endpoint, out channel))
                {
                    var options = new[]
                    {
                        // "After a duration of this time the client/server pings its peer to see if the
                        // transport is still alive. Int valued, milliseconds."
                        // Required for any channel using a streaming RPC, to ensure an idle stream doesn't
                        // allow the TCP connection to be silently dropped by any intermediary network devices.
                        // 60 second keepalive time is reasonable. This will only add minimal network traffic,
                        // and only if the channel is idle for more than 60 seconds.
                        new ChannelOption("grpc.keepalive_time_ms", 60_000)
                    };
                    channel = new Channel(endpoint.Host, endpoint.Port, credentials, options);
                    _channels[endpoint] = channel;
                }
                return channel;
            }
        }
    }
}
