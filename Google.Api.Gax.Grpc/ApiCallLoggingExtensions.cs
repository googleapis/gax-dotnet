/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiCallLoggingExtensions
    {
        // By design, the code is mostly duplicated between the async and sync calls.

        #region Unary calls
        // Async call
        internal static Func<TRequest, CallSettings, Task<TResponse>> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, Task<TResponse>> fn, ILogger logger) =>
            async (request, callSettings) =>
            {
                logger?.LogTrace("Starting asynchronous API call.");
                var result = await fn(request, callSettings).ConfigureAwait(false);
                logger?.LogTrace("Call completed.");
                return result;
            };

        // Sync call
        internal static Func<TRequest, CallSettings, TResponse> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn, ILogger logger) =>
            (request, callSettings) =>
            {
                logger?.LogTrace("Starting synchronous API call.");
                var result = fn(request, callSettings);
                logger?.LogTrace("Call completed.");
                return result;
            };
        #endregion

        #region Server streaming
        // Async call
        internal static Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> fn, ILogger logger) =>
            async (request, callSettings) =>
            {
                logger?.LogTrace("Starting asynchronous API call.");
                var result = await fn(request, callSettings).ConfigureAwait(false);
                logger?.LogTrace("Initial call completed.");
                return result;
            };

        // Sync call
        internal static Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> fn, ILogger logger) =>
            (request, callSettings) =>
            {
                logger?.LogTrace("Starting synchronous API call.");
                var result = fn(request, callSettings);
                logger?.LogTrace("Initial call completed.");
                return result;
            };
        #endregion

        #region Client streaming
        internal static Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> WithLogging<TRequest, TResponse>(
            this Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> fn, ILogger logger) =>
            callSettings =>
            {
                logger?.LogTrace("Starting client streaming API call.");
                return fn(callSettings);
            };
        #endregion

        #region Bidi streaming
        internal static Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> WithLogging<TRequest, TResponse>(
            this Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> fn, ILogger logger) =>
            callSettings =>
            {
                logger?.LogTrace("Starting duplex streaming API call.");
                return fn(callSettings);
            };
        #endregion
    }
}
