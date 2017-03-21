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
    internal static class ApiServerStreamingCall
    {
        internal static ApiServerStreamingCall<TRequest, TResponse> Create<TRequest, TResponse>(
            Func<TRequest, CallOptions, AsyncServerStreamingCall<TResponse>> grpcCall,
            CallSettings baseCallSettings,
            IClock clock)
        {
            return new ApiServerStreamingCall<TRequest, TResponse>(
                (req, cs) => grpcCall(req, cs.ToCallOptions(clock)),
                baseCallSettings);
        }
    }

    /// <summary>
    /// Bridge between a server streaming RPC method and higher level
    /// abstractions, applying call settings as required.
    /// </summary>
    /// <typeparam name="TRequest">RPC request type</typeparam>
    /// <typeparam name="TResponse">RPC response type</typeparam>
    public sealed class ApiServerStreamingCall<TRequest, TResponse>
    {
        internal ApiServerStreamingCall(
            Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> call,
            CallSettings baseCallSettings)
        {
            _call = call;
            BaseCallSettings = baseCallSettings;
        }

        private readonly Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> _call;

        /// <summary>
        /// The base <see cref="CallSettings"/> for this API call; these can be further overridden by providing
        /// a <c>CallSettings</c> to <see cref="Call"/>.
        /// </summary>
        public CallSettings BaseCallSettings { get; }

        /// <summary>
        /// Initializes a streaming RPC call.
        /// </summary>
        /// <param name="request">The RPC request.</param>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A gRPC duplex streaming call object.</returns>
        public AsyncServerStreamingCall<TResponse> Call(TRequest request, CallSettings perCallCallSettings)
        {
            CallSettings effectiveCallSettings = BaseCallSettings.MergedWith(perCallCallSettings);
            // TODO: Determine if retry should be available.
            GaxPreconditions.CheckState(effectiveCallSettings?.Timing?.Type != CallTimingType.Retry,
                "Retry cannot be used in a server streaming method.");
            return _call(request, effectiveCallSettings);
        }

        internal ApiServerStreamingCall<TRequest, TResponse> WithVersionHeader(string versionHeader) =>
            new ApiServerStreamingCall<TRequest, TResponse>(
                _call,
                CallSettings.FromHeader(VersionHeaderBuilder.HeaderName, versionHeader).MergedWith(BaseCallSettings));

    }
}
