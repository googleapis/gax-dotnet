﻿/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.GrpcCore;
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
        private static GrpcChannelOptions s_defaultOptions = GrpcChannelOptions.Empty
            .WithEnableServiceConfigResolution(false)
            .WithKeepAliveTime(TimeSpan.FromSeconds(60));

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
        /// The options to use for each channel created by the call invoker, possibly including the special
        /// <see cref="GcpCallInvoker.ApiConfigChannelArg">GcpCallInvoker.ApiConfigChannelArg</see> option to
        /// control the <see cref="GcpCallInvoker"/> behavior itself.
        /// </param>
        /// <returns>A call invoker for the specified endpoint.</returns>
        public GcpCallInvoker GetCallInvoker(string endpoint, GrpcChannelOptions options = null)
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
        /// The options to use for each channel created by the call invoker, possibly including the special
        /// <see cref="GcpCallInvoker.ApiConfigChannelArg">GcpCallInvoker.ApiConfigChannelArg</see> option to
        /// control the <see cref="GcpCallInvoker"/> behavior itself.
        /// </param>
        /// <returns>A task representing the asynchronous operation. The value of the completed
        /// task will be a call invoker for the specified endpoint.</returns>
        public async Task<GcpCallInvoker> GetCallInvokerAsync(string endpoint, GrpcChannelOptions options = null)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            var credentials = await _credentialsCache.GetCredentialsAsync().ConfigureAwait(false);
            return GetCallInvoker(endpoint, options, credentials);
        }

        private GcpCallInvoker GetCallInvoker(string endpoint, GrpcChannelOptions options, ChannelCredentials credentials)
        {
            var effectiveOptions = s_defaultOptions.MergedWith(options ?? GrpcChannelOptions.Empty);
            var key = new Key(endpoint, effectiveOptions);

            lock (_lock)
            {
                if (!_callInvokers.TryGetValue(key, out GcpCallInvoker callInvoker))
                {
                    callInvoker = new GcpCallInvoker(endpoint, credentials, GrpcCoreAdapter.Instance.ConvertOptions(effectiveOptions));
                    _callInvokers[key] = callInvoker;
                }
                return callInvoker;
            }
        }

        private struct Key : IEquatable<Key>
        {
            public readonly string Endpoint;
            public readonly GrpcChannelOptions Options;

            public Key(string endpoint, GrpcChannelOptions options)
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
