/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Grpc.Core;
using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Common helper code shared by clients.
    /// </summary>
    public class ClientHelper
    {
        private readonly CallSettings _clientCallSettings;
        private readonly CallSettings _versionCallSettings;

        /// <summary>
        /// Constructs a helper from the given settings.
        /// Behavior is undefined if settings are changed after construction.
        /// </summary>
        /// <param name="settings">The service settings.</param>
        public ClientHelper(ServiceSettingsBase settings)
        {
            GaxPreconditions.CheckNotNull(settings, nameof(settings));
            Clock = settings.Clock ?? SystemClock.Instance;
            Scheduler = settings.Scheduler ?? SystemScheduler.Instance;
            _clientCallSettings = settings.CallSettings;
            _versionCallSettings = CallSettings.FromHeader(VersionHeaderBuilder.HeaderName, settings.VersionHeader);
        }

        /// <summary>
        /// The clock used for timing of retries and deadlines. This is never
        /// null; if the clock isn't specified in the settings, this property
        /// will return the <see cref="SystemClock"/> instance.
        /// </summary>
        public IClock Clock { get; }

        /// <summary>
        /// The scheduler used for delays of retries. This is never
        /// null; if the scheduler isn't specified in the settings, this property
        /// will return the <see cref="SystemScheduler"/> instance.
        /// </summary>
        public IScheduler Scheduler { get; }

        /// <summary>
        /// Builds an <see cref="ApiCall"/> given suitable underlying async and sync calls.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="asyncGrpcCall">The underlying synchronous gRPC call.</param>
        /// <param name="syncGrpcCall">The underlying asynchronous gRPC call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> asyncGrpcCall,
            Func<TRequest, CallOptions, TResponse> syncGrpcCall,
            CallSettings perMethodCallSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            // These operations are applied in reverse order.
            // I.e. Version header is added first, then retry is performed.
            return ApiCall.Create(asyncGrpcCall, syncGrpcCall, baseCallSettings, Clock)
                .WithRetry(Clock, Scheduler)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// Builds an <see cref="ApiServerStreamingCall"/> given a suitable underlying server streaming call.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="grpcCall">The underlying gRPC duplex streaming call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiServerStreamingCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            Func<TRequest, CallOptions, AsyncServerStreamingCall<TResponse>> grpcCall,
            CallSettings perMethodCallSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            // These operations are applied in reverse order.
            // I.e. Version header is added first, then retry is performed.
            return ApiServerStreamingCall.Create(grpcCall, baseCallSettings, Clock)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// Builds an <see cref="ApiBidirectionalStreamingCall"/> given a suitable underlying duplex call.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="grpcCall">The underlying gRPC duplex streaming call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <param name="streamingSettings">The default streaming settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            Func<CallOptions, AsyncDuplexStreamingCall<TRequest, TResponse>> grpcCall,
            CallSettings perMethodCallSettings,
            BidirectionalStreamingSettings streamingSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            return ApiBidirectionalStreamingCall.Create(grpcCall, baseCallSettings, streamingSettings, Clock)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// Builds an <see cref="ApiBidirectionalStreamingCall"/> given a suitable underlying client streaming call.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="grpcCall">The underlying gRPC duplex streaming call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <param name="streamingSettings">The default streaming settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiClientStreamingCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            Func<CallOptions, AsyncClientStreamingCall<TRequest, TResponse>> grpcCall,
            CallSettings perMethodCallSettings,
            ClientStreamingSettings streamingSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            return ApiClientStreamingCall.Create(grpcCall, baseCallSettings, streamingSettings, Clock)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }
    }
}
