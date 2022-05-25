/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// CallInvoker implementation which uses regular HTTP requests with JSON payloads.
    /// This just delegates back to the <see cref="RestChannel"/> that it wraps.
    /// </summary>
    internal sealed class RestCallInvoker : CallInvoker
    {
        private readonly RestChannel _channel;

        internal RestCallInvoker(RestChannel channel) => _channel = channel;

        /// <inheritdoc />
        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) =>
            throw new NotSupportedException("Streaming methods are not supported by the hybrid REST/gRPC mode");

        /// <inheritdoc />
        public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) =>
            throw new NotSupportedException("Streaming methods are not supported by the hybrid REST/gRPC mode");

        /// <inheritdoc />
        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
            throw new NotSupportedException("Streaming methods are not supported by the hybrid REST/gRPC mode");

        /// <inheritdoc />
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
            _channel.AsyncUnaryCall(method, host, options, request);

        /// <inheritdoc />
        public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
            // TODO: Try to make this more efficient?
            Task.Run(async () => await AsyncUnaryCall(method, host, options, request).ConfigureAwait(false)).ResultWithUnwrappedExceptions();
    }
}
