/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiBidirectionalStreamingCall
    {
        internal static ApiBidirectionalStreamingCall<TRequest, TResponse> Create<TRequest, TResponse>(
            Func<CallOptions, AsyncDuplexStreamingCall<TRequest, TResponse>> grpcCall,
            CallSettings baseCallSettings,
            BidirectionalStreamingSettings streamingSettings,
            IClock clock)
        {
            return new ApiBidirectionalStreamingCall<TRequest, TResponse>(
                cs => grpcCall(cs.ValidateNoRetry().ToCallOptions(clock)),
                baseCallSettings,
                streamingSettings);
        }
    }

    /// <summary>
    /// Bridge between a duplex streaming RPC method and higher level
    /// abstractions, applying call settings as required.
    /// </summary>
    /// <typeparam name="TRequest">RPC request type</typeparam>
    /// <typeparam name="TResponse">RPC response type</typeparam>
    public sealed class ApiBidirectionalStreamingCall<TRequest, TResponse>
    {
        internal ApiBidirectionalStreamingCall(
            Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> call,
            CallSettings baseCallSettings,
            BidirectionalStreamingSettings streamingSettings)
        {
            _call = GaxPreconditions.CheckNotNull(call, nameof(call));
            BaseCallSettings = baseCallSettings;
            StreamingSettings = streamingSettings;
        }

        private readonly Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> _call;

        /// <summary>
        /// The base <see cref="CallSettings"/> for this API call; these can be further overridden by providing
        /// a <c>CallSettings</c> to <see cref="Call"/>.
        /// </summary>
        public CallSettings BaseCallSettings { get; }

        /// <summary>
        /// Streaming settings.
        /// </summary>
        public BidirectionalStreamingSettings StreamingSettings { get; }

        /// <summary>
        /// Initializes a streaming RPC call.
        /// </summary>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A gRPC duplex streaming call object.</returns>
        public AsyncDuplexStreamingCall<TRequest, TResponse> Call(CallSettings perCallCallSettings) =>
            _call(BaseCallSettings.MergedWith(perCallCallSettings).ValidateNoRetry());

        /// <summary>
        /// Returns a new API call using the original base call settings merged with <paramref name="callSettings"/>.
        /// Where there's a conflict, the original base call settings have priority.
        /// </summary>
        internal ApiBidirectionalStreamingCall<TRequest, TResponse> WithMergedBaseCallSettings(CallSettings callSettings) =>
            new ApiBidirectionalStreamingCall<TRequest, TResponse>(_call, callSettings.MergedWith(BaseCallSettings), StreamingSettings);

        /// <summary>
        /// Constructs a new <see cref="ApiServerStreamingCall{TRequest, TResponse}"/> that applies an overlay to
        /// the underlying <see cref="CallSettings"/>. If a value exists in both the original and
        /// the overlay, the overlay takes priority.
        /// </summary>
        /// <param name="callSettingsOverlay">The overlay <see cref="CallSettings"/>.</param>
        /// <returns>A new <see cref="ApiServerStreamingCall{TRequest, TResponse}"/> with the overlay applied.</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> WithCallSettingsOverlay(CallSettings callSettingsOverlay) =>
            new ApiBidirectionalStreamingCall<TRequest, TResponse>(
                cs => _call(cs.MergedWith(callSettingsOverlay)),
                BaseCallSettings,
                StreamingSettings);

        /// <summary>
        /// Constructs a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an x-goog-request-params header to each request,
        /// using the specified parameter name and value.
        /// </summary>
        /// <remarks>It is expected that <paramref name="parameterName"/> and <paramref name="value"/> are already URL-encoded.</remarks>
        /// <param name="parameterName">The parameter name in the header. Must not be null.</param>
        /// <param name="value">The value to specify in the header. May be null.</param>
        /// <returns>A new <see cref="ApiCall{TRequest, TResponse}"/> which applies the header on each request.</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> WithGoogleRequestParam(string parameterName, string value)
        {
            GaxPreconditions.CheckNotNull(parameterName, nameof(parameterName));
            return WithCallSettingsOverlay(CallSettings.FromGoogleRequestParamsHeader(parameterName, value));
        }
    }
}
