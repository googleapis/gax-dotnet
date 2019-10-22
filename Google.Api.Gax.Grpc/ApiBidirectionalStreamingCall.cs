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
                cs => grpcCall(cs.ToCallOptions(clock)),
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
        public AsyncDuplexStreamingCall<TRequest, TResponse> Call(CallSettings perCallCallSettings)
        {
            CallSettings effectiveCallSettings = BaseCallSettings.MergedWith(perCallCallSettings);
            GaxPreconditions.CheckState(effectiveCallSettings?.Timing?.Type != CallTimingType.Retry,
                "Retry cannot be used in a bidirectional streaming method.");
            return _call(effectiveCallSettings);
        }

        /// <summary>
        /// Returns a new API call using the original base call settings merged with <paramref name="callSettings"/>.
        /// Where there's a conflict, the original base call settings have priority.
        /// </summary>
        internal ApiBidirectionalStreamingCall<TRequest, TResponse> WithMergedBaseCallSettings(CallSettings callSettings) =>
            new ApiBidirectionalStreamingCall<TRequest, TResponse>(_call, callSettings.MergedWith(BaseCallSettings), StreamingSettings);
    }
}
