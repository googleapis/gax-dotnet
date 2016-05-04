﻿/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Apis.Auth.OAuth2;
using Google.Protobuf;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Common helper code shared by clients.
    /// </summary>
    public class ClientHelper
    {
        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// </summary>
        private static readonly Lazy<Task<ChannelCredentials>> s_lazyDefaultChannelCredentials
            = new Lazy<Task<ChannelCredentials>>(
                () => Task.Run(async () => (await GoogleCredential.GetApplicationDefaultAsync()).ToChannelCredentials()));

        private readonly IClock _clock;
        private readonly CallSettings _clientCallSettings;
        private readonly string _userAgent;

        /// <summary>
        /// Constructs a helper from the given settings.
        /// Behavior is undefined if settings are changed after construction.
        /// </summary>
        /// <param name="settings">The service settings.</param>
        public ClientHelper(ServiceSettingsBase settings)
        {
            GaxPreconditions.CheckNotNull(settings, nameof(settings));
            _clock = settings.Clock ?? SystemClock.Instance;
            _userAgent = settings.UserAgent;
        }

        /// <summary>
        /// Builds an <see cref="ApiCall"/> given suitable underlying async and sync calls.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="asyncGrpcCall">The underlying synchronous gRPC call.</param>
        /// <param name="syncGrpcCall">The underlying asynchronous gRPC call.</param>
        /// <returns></returns>
        public ApiCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> asyncGrpcCall,
            Func<TRequest, CallOptions, TResponse> syncGrpcCall,
            CallSettings perMethodCallSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings =
                (perMethodCallSettings?.Clone() ?? new CallSettings())
                .Merge(_clientCallSettings);
            // These operations are applied in reverse order.
            // I.e. User-agent is added first, then retry is performed.
            return ApiCall.Create(asyncGrpcCall, syncGrpcCall, baseCallSettings, _clock)
                .WithRetry(_clock, SystemScheduler.Instance)
                .WithUserAgent(_userAgent);
        }

        #region Factory methods for client construction

        /// <summary>
        /// Creates a channel with the specified endpoint and credentials, defaulting to the application default
        /// credentials.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use, or null to use the application default credentials.</param>
        /// <returns>A task representing the asynchronous operation. When completed, the result of the task will be a
        /// channel for the specified endpoint, with the given credentials or application default credentials.</returns>
        public static async Task<Channel> CreateChannelAsync(ServiceEndpoint endpoint, ChannelCredentials credentials)
        {
            // TODO: Could avoid constructing the task-based state machine if either credentials is supplied or the
            // lazy default channel credentials task has completed.
            var effectiveCredentials = credentials ?? await s_lazyDefaultChannelCredentials.Value.ConfigureAwait(false);
            return new Channel(endpoint.Host, endpoint.Port, effectiveCredentials);
        }

        /// <summary>
        /// Creates a channel with the specified endpoint and credentials, defaulting to the application default
        /// credentials.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use, or null to use the application default credentials.</param>
        /// <returns>A channel for the specified endpoint, with the given credentials or application default credentials.</returns>
        public static Channel CreateChannel(ServiceEndpoint endpoint, ChannelCredentials credentials)
        {
            try
            {
                var effectiveCredentials = credentials ?? s_lazyDefaultChannelCredentials.Value.Result;
                return new Channel(endpoint.Host, endpoint.Port, effectiveCredentials);
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exceptions,
                // but let's handle it relatively gracefully.
                throw e.InnerExceptions.FirstOrDefault() ?? e;
            }
        }
        #endregion
    }
}
