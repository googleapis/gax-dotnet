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
                (_, cs) => grpcCall(cs.ValidateNoRetry().ToCallOptions(clock)),
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
            Func<TRequest, CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> call,
            CallSettings baseCallSettings,
            BidirectionalStreamingSettings streamingSettings)
        {
            _call = GaxPreconditions.CheckNotNull(call, nameof(call));
            BaseCallSettings = baseCallSettings;
            StreamingSettings = streamingSettings;
        }

        private readonly Func<TRequest, CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> _call;

        /// <summary>
        /// The base <see cref="CallSettings"/> for this API call; these can be further overridden by providing
        /// a <c>CallSettings</c> to <see cref="Call(CallSettings)" /> or <see cref="Call(TRequest, CallSettings)"/>.
        /// </summary>
        public CallSettings BaseCallSettings { get; }

        /// <summary>
        /// Streaming settings.
        /// </summary>
        public BidirectionalStreamingSettings StreamingSettings { get; }

        /// <summary>
        /// Initializes a streaming RPC call with no sample request.
        /// </summary>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A gRPC duplex streaming call object.</returns>
        [Obsolete("This overload will be removed in the next major version")]
        public AsyncDuplexStreamingCall<TRequest, TResponse> Call(CallSettings perCallCallSettings) =>
            Call(default, perCallCallSettings);

        /// <summary>
        /// Initializes a streaming RPC call.
        /// </summary>
        /// <param name="sampleRequest">A sample request which may be used to extract initial headers.</param>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A gRPC duplex streaming call object.</returns>
        public AsyncDuplexStreamingCall<TRequest, TResponse> Call(TRequest sampleRequest, CallSettings perCallCallSettings) =>
            _call(sampleRequest, BaseCallSettings.MergedWith(perCallCallSettings).ValidateNoRetry());

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
        /// <param name="callSettingsOverlayFn">Function that builds the overlay <see cref="CallSettings"/>.</param>
        /// <returns>A new <see cref="ApiServerStreamingCall{TRequest, TResponse}"/> with the overlay applied.</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> WithCallSettingsOverlay(Func<TRequest, CallSettings> callSettingsOverlayFn) =>
            new ApiBidirectionalStreamingCall<TRequest, TResponse>(
                (req, cs) => _call(req, cs.MergedWith(callSettingsOverlayFn(req))),
                BaseCallSettings,
                StreamingSettings);

        /// <summary>
        /// Constructs a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an x-goog-request-params header to each request,
        /// using the specified parameter name and a value derived from the request.
        /// </summary>
        /// <remarks>Values produced by the function are URL-encoded; it is expected that <paramref name="parameterName"/> is already URL-encoded.</remarks>
        /// <param name="parameterName">The parameter name in the header. Must not be null.</param>
        /// <param name="valueSelector">A function to call on each request, to determine the value to specify in the header.
        /// The parameter must not be null, but may return null.</param>
        /// <returns>A new <see cref="ApiCall{TRequest, TResponse}"/> which applies the header on each request.</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> WithGoogleRequestParam(string parameterName, Func<TRequest, string> valueSelector)
        {
            GaxPreconditions.CheckNotNull(parameterName, nameof(parameterName));
            GaxPreconditions.CheckNotNull(valueSelector, nameof(valueSelector));
            return WithCallSettingsOverlay(request => CallSettings.FromGoogleRequestParamsHeader(parameterName, request is null ? null : valueSelector(request)));
        }

        /// <summary>
        /// Constructs a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an x-goog-request-params header to each request,
        /// using the <see cref="RoutingHeaderExtractor{TRequest}"/>.
        /// </summary>
        /// <remarks>Values produced by the function are URL-encoded.</remarks>
        /// <param name="extractor">The <see cref="RoutingHeaderExtractor{TRequest}"/> that extracts the value of the routing header from a request.</param>
        /// <returns>>A new <see cref="ApiCall{TRequest, TResponse}"/> which applies the header on each request.</returns>
        public ApiBidirectionalStreamingCall<TRequest, TResponse> WithExtractedGoogleRequestParam(RoutingHeaderExtractor<TRequest> extractor)
        {
            GaxPreconditions.CheckNotNull(extractor, nameof(extractor));

            return WithCallSettingsOverlay(request =>
            {
                if (request is null)
                {
                    return null;
                }
                var headerValue = extractor.ExtractHeader(request);

                return !string.IsNullOrWhiteSpace(headerValue)
                    ? CallSettings.FromGoogleRequestParamsHeader(headerValue)
                    : null; // CallSettings.Merge handles null correctly.
            });
        }
    }
}
