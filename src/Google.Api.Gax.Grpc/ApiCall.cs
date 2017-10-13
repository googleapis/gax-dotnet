/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiCall
    {
        internal static ApiCall<TRequest, TResponse> Create<TRequest, TResponse>(
            Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> asyncGrpcCall,
            Func<TRequest, CallOptions, TResponse> syncGrpcCall,
            CallSettings baseCallSettings,
            IClock clock)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            return new ApiCall<TRequest, TResponse>(
                (req, cs) => asyncGrpcCall(req, cs.ToCallOptions(clock)).ResponseAsync,
                (req, cs) => syncGrpcCall(req, cs.ToCallOptions(clock)),
                baseCallSettings);
        }
    }

    /// <summary>
    /// Bridge between an RPC method (with synchronous and asynchronous variants) and higher level
    /// abstractions, applying call settings as required.
    /// </summary>
    /// <typeparam name="TRequest">RPC request type</typeparam>
    /// <typeparam name="TResponse">RPC response type</typeparam>
    public sealed class ApiCall<TRequest, TResponse>
        where TRequest : class, IMessage<TRequest>
        where TResponse : class, IMessage<TResponse>
    {
        internal ApiCall(
            Func<TRequest, CallSettings, Task<TResponse>> asyncCall,
            Func<TRequest, CallSettings, TResponse> syncCall,
            CallSettings baseCallSettings)
        {
            _asyncCall = GaxPreconditions.CheckNotNull(asyncCall, nameof(asyncCall));
            _syncCall = GaxPreconditions.CheckNotNull(syncCall, nameof(syncCall));
            BaseCallSettings = baseCallSettings;
        }

        private readonly Func<TRequest, CallSettings, Task<TResponse>> _asyncCall;
        private readonly Func<TRequest, CallSettings, TResponse> _syncCall;

        /// <summary>
        /// The base <see cref="CallSettings"/> for this API call; these can be further overridden by providing
        /// a <c>CallSettings</c> to <see cref="Async"/> or <see cref="Sync"/>.
        /// </summary>
        public CallSettings BaseCallSettings { get; }

        /// <summary>
        /// Performs an RPC call asynchronously.
        /// </summary>
        /// <param name="request">The RPC request.</param>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>A task representing the asynchronous operation. The result of the completed task
        /// will be the RPC response.</returns>
        public Task<TResponse> Async(TRequest request, CallSettings perCallCallSettings) =>
            _asyncCall(request, BaseCallSettings.MergedWith(perCallCallSettings));

        /// <summary>
        /// Performs an RPC call synchronously.
        /// </summary>
        /// <param name="request">The RPC request.</param>
        /// <param name="perCallCallSettings">The call settings to apply to this specific call,
        /// overriding defaults where necessary.</param>
        /// <returns>The RPC response.</returns>
        public TResponse Sync(TRequest request, CallSettings perCallCallSettings) =>
            _syncCall(request, BaseCallSettings.MergedWith(perCallCallSettings));

        internal ApiCall<TRequest, TResponse> WithVersionHeader(string versionHeader) =>
            // TODO: Check that this is what we want. It allows call settings to remove our
            // version header. The caller can always do this manually anyway, of course, so
            // I'm tempted to leave it...
            new ApiCall<TRequest, TResponse>(
                _asyncCall,
                _syncCall,
                CallSettings.FromHeader(VersionHeaderBuilder.HeaderName, versionHeader)
                    .MergedWith(BaseCallSettings));

        internal ApiCall<TRequest, TResponse> WithRetry(IClock clock, IScheduler scheduler) =>
            new ApiCall<TRequest, TResponse>(
                _asyncCall.WithRetry(clock, scheduler, null),
                _syncCall.WithRetry(clock, scheduler, null),
                BaseCallSettings);

        /// <summary>
        /// Construct a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an overlay to
        /// the underlying <see cref="CallSettings"/>. If a value exists in both the original and
        /// the overlay, the overlay takes priority.
        /// </summary>
        /// <param name="callSettingsOverlayFn">Function that builds the overlay <see cref="CallSettings"/>.</param>
        /// <returns>A new <see cref="ApiCall{TRequest, TResponse}"/> with the overlay applied.</returns>
        public ApiCall<TRequest, TResponse> WithCallSettingsOverlay(Func<TRequest, CallSettings> callSettingsOverlayFn) =>
            new ApiCall<TRequest, TResponse>(
                (req, cs) => _asyncCall(req, cs.MergedWith(callSettingsOverlayFn(req))),
                (req, cs) => _syncCall(req, cs.MergedWith(callSettingsOverlayFn(req))),
                BaseCallSettings);
    }
}
