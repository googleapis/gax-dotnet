/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;

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
                (req, cs) => Task.FromResult(grpcCall(req, cs.ToCallOptions(clock))),
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
            Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> asyncCall,
            Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> syncCall,
            CallSettings baseCallSettings)
        {
            _asyncCall = asyncCall;
            _syncCall = syncCall;
            BaseCallSettings = baseCallSettings;
        }

        private readonly Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> _asyncCall;
        private readonly Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> _syncCall;

        /// <summary>
        /// The base <see cref="CallSettings"/> for this API call; these can be further overridden by providing
        /// a <c>CallSettings</c> to <see cref="Call"/>.
        /// </summary>
        public CallSettings BaseCallSettings { get; }

        /// <summary>
        /// Initializes a streaming RPC call asynchronously.
        /// </summary>
        /// <param name="request">The RPC request.</param>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A task representing the gRPC duplex streaming call object.</returns>
        public Task<AsyncServerStreamingCall<TResponse>> CallAsync(TRequest request, CallSettings perCallCallSettings) =>
            _asyncCall(request, BaseCallSettings.MergedWith(perCallCallSettings));

        /// <summary>
        /// Initializes a streaming RPC call.
        /// </summary>
        /// <param name="request">The RPC request.</param>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A gRPC duplex streaming call object.</returns>
        public AsyncServerStreamingCall<TResponse> Call(TRequest request, CallSettings perCallCallSettings) =>
            _syncCall(request, BaseCallSettings.MergedWith(perCallCallSettings));

        internal ApiServerStreamingCall<TRequest, TResponse> WithVersionHeader(string versionHeader) =>
            new ApiServerStreamingCall<TRequest, TResponse>(
                _asyncCall,
                _syncCall,
                CallSettings.FromHeader(VersionHeaderBuilder.HeaderName, versionHeader).MergedWith(BaseCallSettings));

        internal ApiServerStreamingCall<TRequest, TResponse> WithRetry(IClock clock, IScheduler scheduler) =>
            new ApiServerStreamingCall<TRequest, TResponse>(
                _asyncCall.WithRetry(clock, scheduler, response => response.ResponseHeadersAsync),
                _syncCall.WithRetry(clock, scheduler, response => response.ResponseHeadersAsync.WaitWithUnwrappedExceptions()),
                BaseCallSettings);
    }
}
