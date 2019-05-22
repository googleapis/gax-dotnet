/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Grpc.Gcp;
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
    public sealed class GcpCallInvokerPool
    {
        private readonly DefaultChannelCredentialsCache _credentialsCache;

        private readonly Dictionary<Key, GcpCallInvoker> _callInvokers = new Dictionary<Key, GcpCallInvoker>();
        private readonly object _lock = new object();

        /// <summary>
        /// Creates a call invoker pool which will apply the specified scopes to the default application credentials
        /// if they require any.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        public GcpCallInvokerPool(IEnumerable<string> scopes) =>
            _credentialsCache = new DefaultChannelCredentialsCache(scopes);

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
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">
        /// The options to use for each channel created by the call invoker and/or the special
        /// <see cref="GcpCallInvoker.ApiConfigChannelArg">GcpCallInvoker.ApiConfigChannelArg</see> option to
        /// control the <see cref="GcpCallInvoker"/> behavior itself.
        /// </param>
        /// <returns>A call invoker for the specified endpoint.</returns>
        public GcpCallInvoker GetCallInvoker(ServiceEndpoint endpoint, IEnumerable<ChannelOption> options = null)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = _credentialsCache.GetCredentials();
            return GetCallInvoker(endpoint, options, credentials);
        }

        /// <summary>
        /// Asynchronously returns a call invoker from this pool, creating a new one if there is no call invoker
        /// already associated with <paramref name="endpoint"/> and <paramref name="options"/>.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="options">
        /// The options to use for each channel created by the call invoker and/or the special
        /// <see cref="GcpCallInvoker.ApiConfigChannelArg">GcpCallInvoker.ApiConfigChannelArg</see> option to
        /// control the <see cref="GcpCallInvoker"/> behavior itself.
        /// </param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be a call invoker for the specified endpoint.</returns>
        public async Task<GcpCallInvoker> GetCallInvokerAsync(ServiceEndpoint endpoint, IEnumerable<ChannelOption> options = null)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = await _credentialsCache.GetCredentialsAsync().ConfigureAwait(false);
            return GetCallInvoker(endpoint, options, credentials);
        }

        private GcpCallInvoker GetCallInvoker(ServiceEndpoint endpoint, IEnumerable<ChannelOption> options, ChannelCredentials credentials)
        {
            var optionsList = options?.ToList() ?? new List<ChannelOption>();
            // "After a duration of this time the client/server pings its peer to see if the
            // transport is still alive. Int valued, milliseconds."
            // Required for any channel using a streaming RPC, to ensure an idle stream doesn't
            // allow the TCP connection to be silently dropped by any intermediary network devices.
            // 60 second keepalive time is reasonable. This will only add minimal network traffic,
            // and only if the channel is idle for more than 60 seconds.
            optionsList.Add(new ChannelOption("grpc.keepalive_time_ms", 60_000));

            var key = new Key(endpoint, optionsList);

            lock (_lock)
            {
                if (!_callInvokers.TryGetValue(key, out GcpCallInvoker callInvoker))
                {
                    callInvoker = new GcpCallInvoker(endpoint.ToString(), credentials, optionsList);
                    _callInvokers[key] = callInvoker;
                }
                return callInvoker;
            }
        }

        private struct Key : IEquatable<Key>
        {
            public readonly ServiceEndpoint Endpoint;
            public readonly List<ChannelOption> Options;

            public Key(ServiceEndpoint endpoint, List<ChannelOption> options)
            {
                Endpoint = endpoint;
                Options = options;
            }

            public override int GetHashCode() =>
                GaxEqualityHelpers.CombineHashCodes(
                    Endpoint.GetHashCode(),
                    GaxEqualityHelpers.GetListHashCode(Options));

            public override bool Equals(object obj) => obj is Key other && Equals(other);

            public bool Equals(Key other) =>
                Endpoint.Equals(other.Endpoint) && Options.SequenceEqual(other.Options);
        }
    }
}
