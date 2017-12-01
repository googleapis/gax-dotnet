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
        private readonly Dictionary<ServiceEndpoint, Channel> _channels = new Dictionary<ServiceEndpoint, Channel>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a channel pool which will apply the specified scopes to the default application credentials
        /// if they require any.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        public ChannelPool(IEnumerable<string> scopes)
        {
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
            var credentials = _lazyScopedDefaultChannelCredentials.Value.ResultWithUnwrappedExceptions();
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
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = await _lazyScopedDefaultChannelCredentials.Value.ConfigureAwait(false);
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
