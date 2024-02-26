/*
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
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiCall
    {
        internal static ApiCall<TRequest, TResponse> Create<TRequest, TResponse>(
            string methodName,
            Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> asyncGrpcCall,
            Func<TRequest, CallOptions, TResponse> syncGrpcCall,
            CallSettings baseCallSettings,
            IClock clock)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            var adapter = new GrpcCallAdapter<TRequest, TResponse>(asyncGrpcCall, syncGrpcCall, clock);
            return new ApiCall<TRequest, TResponse>(methodName, adapter.CallAsync, adapter.CallSync, baseCallSettings);
        }

        /// <summary>
        /// Adapter used to mask the fact that when we need response/trailing metadata, a sync call may need
        /// to use the async gRPC code.
        /// </summary>
        private class GrpcCallAdapter<TRequest, TResponse>
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            private readonly Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> _asyncGrpcCall;
            private readonly Func<TRequest, CallOptions, TResponse> _syncGrpcCall;
            private readonly IClock _clock;

            internal GrpcCallAdapter(
                Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> asyncGrpcCall,
                Func<TRequest, CallOptions, TResponse> syncGrpcCall,
                IClock clock)
            {
                _asyncGrpcCall = asyncGrpcCall;
                _syncGrpcCall = syncGrpcCall;
                _clock = clock;
            }

            internal Task<TResponse> CallAsync(TRequest request, CallSettings callSettings)
            {
                var unaryCall = _asyncGrpcCall(request, callSettings.ToCallOptions(_clock));
                var responseMetadataHandler = callSettings?.ResponseMetadataHandler;
                var trailingMetadataHandler = callSettings?.TrailingMetadataHandler;

                // If we don't have any response/trailing metadata handlers, it's simplest just to
                // return the gRPC task.
                if (responseMetadataHandler == null && trailingMetadataHandler == null)
                {
                    return unaryCall.ResponseAsync;
                }

                // Otherwise, we want to pass the returned metadata to the handlers before our returned task completes,
                // so we create a proxy task.
                return WaitAndCallHandlers();

                // Implementation note: we capture local variables here, forcing the compiler to create
                // a class to hold that state, as well as a regular async state machine. This could be avoided
                // with parameters, but the cost is small compared with the network access (and it's a relatively rare case).
                async Task<TResponse> WaitAndCallHandlers()
                {
                    var response = await unaryCall.ResponseAsync.ConfigureAwait(false);
                    var responseHeadersTask = unaryCall.ResponseHeadersAsync;
                    if (responseHeadersTask.Status == TaskStatus.RanToCompletion)
                    {
                        responseMetadataHandler?.Invoke(responseHeadersTask.Result);
                    }
                    trailingMetadataHandler?.Invoke(unaryCall.GetTrailers());
                    return response;
                }
            }

            internal TResponse CallSync(TRequest request, CallSettings callSettings)
            {
                // If we don't have complicated requirements, use the gRPC sync call. Otherwise,
                // async the sync call.
                if (callSettings?.ResponseMetadataHandler == null && callSettings?.TrailingMetadataHandler == null)
                {
                    return _syncGrpcCall(request, callSettings.ToCallOptions(_clock));
                }
                return CallAsync(request, callSettings).ResultWithUnwrappedExceptions();
            }
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
        private readonly string _methodName;
        private readonly Func<TRequest, CallSettings, Task<TResponse>> _asyncCall;
        private readonly Func<TRequest, CallSettings, TResponse> _syncCall;

        internal ApiCall(
            string methodName,
            Func<TRequest, CallSettings, Task<TResponse>> asyncCall,
            Func<TRequest, CallSettings, TResponse> syncCall,
            CallSettings baseCallSettings)
        {
            _methodName = GaxPreconditions.CheckNotNull(methodName, nameof(methodName));
            _asyncCall = GaxPreconditions.CheckNotNull(asyncCall, nameof(asyncCall));
            _syncCall = GaxPreconditions.CheckNotNull(syncCall, nameof(syncCall));
            BaseCallSettings = baseCallSettings;
        }

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

        /// <summary>
        /// Returns a new API call using the original base call settings merged with <paramref name="callSettings"/>.
        /// Where there's a conflict, the original base call settings have priority.
        /// </summary>
        internal ApiCall<TRequest, TResponse> WithMergedBaseCallSettings(CallSettings callSettings) =>
            new ApiCall<TRequest, TResponse>(_methodName, _asyncCall, _syncCall, callSettings.MergedWith(BaseCallSettings));

        // Note: it seems unfortunate that we can't reuse whatever logger is already configured here, but we don't
        // have access to it. This is the logger for logging "I'm about to back off / retry" rather than the actual calls.
        // TODO: Check whether ActivitySource is needed or since it is called later we don't need it.
        internal ApiCall<TRequest, TResponse> WithRetry(IClock clock, IScheduler scheduler, ILogger retryLogger) =>
            new ApiCall<TRequest, TResponse>(
                _methodName,
                _asyncCall.WithRetry(clock, scheduler, retryLogger, _methodName),
                _syncCall.WithRetry(clock, scheduler, retryLogger, _methodName),
                BaseCallSettings);

        internal ApiCall<TRequest, TResponse> WithLogging(ILogger logger) =>
            logger is null
                ? this
                : new ApiCall<TRequest, TResponse>(
                    _methodName, _asyncCall.WithLogging(logger, _methodName),
                    _syncCall.WithLogging(logger, _methodName),
                    BaseCallSettings);

        internal ApiCall<TRequest, TResponse> WithTracing(ActivitySource source) =>
           source is null
               ? this
               : new ApiCall<TRequest, TResponse>(
                   _methodName, _asyncCall.WithTracing(source, _methodName),
                   _syncCall.WithTracing(source, _methodName),
                   BaseCallSettings);

        /// <summary>
        /// Constructs a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an overlay to
        /// the underlying <see cref="CallSettings"/>. If a value exists in both the original and
        /// the overlay, the overlay takes priority.
        /// </summary>
        /// <param name="callSettingsOverlayFn">Function that builds the overlay <see cref="CallSettings"/>.</param>
        /// <returns>A new <see cref="ApiCall{TRequest, TResponse}"/> with the overlay applied.</returns>
        public ApiCall<TRequest, TResponse> WithCallSettingsOverlay(Func<TRequest, CallSettings> callSettingsOverlayFn) =>
            new ApiCall<TRequest, TResponse>(
                _methodName,
                (req, cs) => _asyncCall(req, cs.MergedWith(callSettingsOverlayFn(req))),
                (req, cs) => _syncCall(req, cs.MergedWith(callSettingsOverlayFn(req))),
                BaseCallSettings);

        /// <summary>
        /// Constructs a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an x-goog-request-params header to each request,
        /// using the specified parameter name and a value derived from the request.
        /// </summary>
        /// <remarks>Values produced by the function are URL-encoded; it is expected that <paramref name="parameterName"/> is already URL-encoded.</remarks>
        /// <param name="parameterName">The parameter name in the header. Must not be null.</param>
        /// <param name="valueSelector">A function to call on each request, to determine the value to specify in the header.
        /// The parameter must not be null, but may return null.</param>
        /// <returns>A new <see cref="ApiCall{TRequest, TResponse}"/> which applies the header on each request.</returns>
        public ApiCall<TRequest, TResponse> WithGoogleRequestParam(string parameterName, Func<TRequest, string> valueSelector)
        {
            GaxPreconditions.CheckNotNull(parameterName, nameof(parameterName));
            GaxPreconditions.CheckNotNull(valueSelector, nameof(valueSelector));
            return WithCallSettingsOverlay(request => CallSettings.FromGoogleRequestParamsHeader(parameterName, valueSelector(request)));
        }

        /// <summary>
        /// Constructs a new <see cref="ApiCall{TRequest, TResponse}"/> that applies an x-goog-request-params header to each request,
        /// using the <see cref="RoutingHeaderExtractor{TRequest}"/>.
        /// </summary>
        /// <remarks>Values produced by the function are URL-encoded.</remarks>
        /// <param name="extractor">The <see cref="RoutingHeaderExtractor{TRequest}"/> that extracts the value of the routing header from a request.</param>
        /// <returns>>A new <see cref="ApiCall{TRequest, TResponse}"/> which applies the header on each request.</returns>
        public ApiCall<TRequest, TResponse> WithExtractedGoogleRequestParam(RoutingHeaderExtractor<TRequest> extractor)
        {
            GaxPreconditions.CheckNotNull(extractor, nameof(extractor));

            return WithCallSettingsOverlay(request =>
            {
                var headerValue = extractor.ExtractHeader(request);

                return !string.IsNullOrWhiteSpace(headerValue)
                    ? CallSettings.FromGoogleRequestParamsHeader(headerValue)
                    : null; // CallSettings.Merge handles null correctly.
            });
        }
    }
}
