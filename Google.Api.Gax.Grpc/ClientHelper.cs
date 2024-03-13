﻿/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Common helper code shared by clients. This class is primarily expected to be used from generated code.
    /// </summary>
    public class ClientHelper
    {
        // Visible for testing
        internal const string ApiVersionHeaderName = "x-goog-api-version";

        private readonly CallSettings _clientCallSettings;

        /// <summary>
        /// Call settings specifying headers for the client version (x-goog-api-client) and
        /// optionally the API version (x-goog-api-version).
        /// </summary>
        private readonly CallSettings _versionCallSettings;

        private readonly ActivitySource _activitySource;

        /// <summary>
        /// Constructs a helper from the given settings.
        /// Behavior is undefined if settings are changed after construction.
        /// </summary>
        /// <remarks>
        /// This constructor will be removed in the next major version of GAX.
        /// </remarks>
        /// <param name="settings">The service settings.</param>
        /// <param name="logger">The logger to use for API calls</param>
        public ClientHelper(ServiceSettingsBase settings, ILogger logger)
            : this(new Options { Settings = GaxPreconditions.CheckNotNull(settings, nameof(settings)), Logger = logger })
        {
        }

        /// <summary>
        /// Constructs a helper from the given options. See the properties in <see cref="Options"/>
        /// for validity constraints.
        /// </summary>
        /// <param name="options">The options for the helper.</param>
        public ClientHelper(Options options)
        {
            GaxPreconditions.CheckNotNull(options, nameof(options));
            var settings = options.Settings;
            GaxPreconditions.CheckArgument(settings is not null, nameof(options), "{0} in options must not be null", nameof(Options.Settings));
            Logger = options.Logger;
            Clock = settings.Clock ?? SystemClock.Instance;
            Scheduler = settings.Scheduler ?? SystemScheduler.Instance;
            _clientCallSettings = settings.CallSettings;
            _versionCallSettings = CallSettings.FromHeader(VersionHeaderBuilder.HeaderName, settings.VersionHeader);
            if (options.ApiVersion is not null)
            {
                _versionCallSettings = _versionCallSettings.WithHeader(ApiVersionHeaderName, options.ApiVersion);
            }
            _activitySource = settings.ActivitySource ?? options.ActivitySource;
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
        /// The logger used by this instance, or null if it does not perform logging.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>
        /// Builds an <see cref="ApiCall"/> given suitable underlying async and sync calls.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="methodName">The underlying method name, for diagnostic purposes.</param>
        /// <param name="asyncGrpcCall">The underlying synchronous gRPC call.</param>
        /// <param name="syncGrpcCall">The underlying asynchronous gRPC call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            string methodName,
            Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> asyncGrpcCall,
            Func<TRequest, CallOptions, TResponse> syncGrpcCall,
            CallSettings perMethodCallSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            // These operations are applied in reverse order.
            // I.e. Version header is added first, then retry is performed.
            return ApiCall.Create(methodName, asyncGrpcCall, syncGrpcCall, baseCallSettings, Clock)
                .WithLogging(Logger)
                .WithTracing(_activitySource)
                .WithRetry(Clock, Scheduler, Logger)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// Builds an <see cref="ApiServerStreamingCall"/> given a suitable underlying server streaming call.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="methodName">The underlying method name, for diagnostic purposes.</param>
        /// <param name="grpcCall">The underlying gRPC server streaming call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiServerStreamingCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            string methodName, Func<TRequest, CallOptions, AsyncServerStreamingCall<TResponse>> grpcCall,
            CallSettings perMethodCallSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            // These operations are applied in reverse order.
            // I.e. Version header is added first, then retry is performed.
            return ApiServerStreamingCall.Create(methodName, grpcCall, baseCallSettings, Clock)
                .WithLogging(Logger)
                .WithTracing(_activitySource)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// Builds an <see cref="ApiBidirectionalStreamingCall"/> given a suitable underlying duplex call.
        /// </summary>
        /// <param name="methodName">The underlying method name, for diagnostic purposes.</param>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="grpcCall">The underlying gRPC duplex streaming call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <param name="streamingSettings">The default streaming settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            string methodName,
            Func<CallOptions, AsyncDuplexStreamingCall<TRequest, TResponse>> grpcCall,
            CallSettings perMethodCallSettings,
            BidirectionalStreamingSettings streamingSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            return ApiBidirectionalStreamingCall.Create(methodName, grpcCall, baseCallSettings, streamingSettings, Clock)
                .WithLogging(Logger)
                .WithTracing(_activitySource)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// Builds an <see cref="ApiClientStreamingCall"/> given a suitable underlying client streaming call.
        /// </summary>
        /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
        /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
        /// <param name="methodName">The underlying method name, for diagnostic purposes.</param>
        /// <param name="grpcCall">The underlying gRPC client streaming call.</param>
        /// <param name="perMethodCallSettings">The default method call settings.</param>
        /// <param name="streamingSettings">The default streaming settings.</param>
        /// <returns>An API call to proxy to the RPC calls</returns>
        public ApiClientStreamingCall<TRequest, TResponse> BuildApiCall<TRequest, TResponse>(
            string methodName,
            Func<CallOptions, AsyncClientStreamingCall<TRequest, TResponse>> grpcCall,
            CallSettings perMethodCallSettings,
            ClientStreamingSettings streamingSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            CallSettings baseCallSettings = _clientCallSettings.MergedWith(perMethodCallSettings);
            return ApiClientStreamingCall.Create(methodName, grpcCall, baseCallSettings, streamingSettings, Clock)
                .WithLogging(Logger)
                .WithTracing(_activitySource)
                .WithMergedBaseCallSettings(_versionCallSettings);
        }

        /// <summary>
        /// The options used to construct a <see cref="ClientHelper"/>.
        /// </summary>
        /// <remarks>
        /// This class is designed to allow additional configuration to be introduced without
        /// either overloading the ClientHelper constructor or making breaking changes.
        /// </remarks>
        public sealed class Options
        {
            /// <summary>
            /// The service settings. This must not be null when the options
            /// are passed to the <see cref="ClientHelper"/> constructor.
            /// </summary>
            public ServiceSettingsBase Settings { get; set; }

            /// <summary>
            /// The logger to use, if any. This may be null.
            /// </summary>
            public ILogger Logger { get; set; }

            /// <summary>
            /// The API version to send in the x-goog-api-version header, if any. This may be null.
            /// </summary>
            public string ApiVersion { get; set; }

            /// <summary>
            /// The activity source to use for tracing, if any. This may be null. This is ignored
            /// if <see cref="Settings"/> specifies an activity source.
            /// Note: currently internal until we're ready to roll out OpenTelemetry support "properly".
            /// </summary>
            internal ActivitySource ActivitySource { get; set; }
        }
    }
}
