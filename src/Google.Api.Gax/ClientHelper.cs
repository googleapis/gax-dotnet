/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf;
using Grpc.Core;
using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Common helper code shared by clients.
    /// </summary>
    public class ClientHelper
    {
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
            _clientCallSettings = settings.CallSettings;
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
    }
}
