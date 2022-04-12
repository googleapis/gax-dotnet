/*
 * Copyright 2022 Google Inc. All Rights Reserved.
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
            this Func<TRequest, CallSettings, Task<TResponse>> fn, ILogger logger, string methodName) =>
            async (request, callSettings) =>
            {
                // TODO: Use a scope?
                logger?.LogTrace("Starting asynchronous API call to {method}.", methodName);
                var result = await fn(request, callSettings).ConfigureAwait(false);
                logger?.LogTrace("Call to {method} completed.", methodName);
                return result;
            };

        // Sync call
        internal static Func<TRequest, CallSettings, TResponse> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn, ILogger logger, string methodName) =>
            (request, callSettings) =>
            {
                logger?.LogTrace("Starting synchronous API call to {method}.", methodName);
                var result = fn(request, callSettings);
                logger?.LogTrace("Call completed to {method}.", methodName);
                return result;
            };
        #endregion

        #region Server streaming
        // Async call
        internal static Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> fn, ILogger logger, string methodName) =>
            async (request, callSettings) =>
            {
                logger?.LogTrace("Starting asynchronous API call to {method}.", methodName);
                var result = await fn(request, callSettings).ConfigureAwait(false);
                logger?.LogTrace("Initial call to {method} completed.", methodName);
                return result;
            };

        // Sync call
        internal static Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> fn, ILogger logger, string methodName) =>
            (request, callSettings) =>
            {
                logger?.LogTrace("Starting synchronous API call to {method}.", methodName);
                var result = fn(request, callSettings);
                logger?.LogTrace("Initial call to {method} completed.", methodName);
                return result;
            };
        #endregion

        #region Client streaming
        internal static Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> WithLogging<TRequest, TResponse>(
            this Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> fn, ILogger logger, string methodName) =>
            callSettings =>
            {
                logger?.LogTrace("Starting client streaming API call to {method}.", methodName);
                return fn(callSettings);
            };
        #endregion

        #region Bidi streaming
        internal static Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> WithLogging<TRequest, TResponse>(
            this Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> fn, ILogger logger, string methodName) =>
            callSettings =>
            {
                logger?.LogTrace("Starting duplex streaming API call to {method}.", methodName);
                return fn(callSettings);
            };
        #endregion
    }
}
