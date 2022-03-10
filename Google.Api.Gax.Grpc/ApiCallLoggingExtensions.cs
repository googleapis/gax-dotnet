/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiCallLoggingExtensions
    {
        // By design, the code is mostly duplicated between the async and sync calls.

        // Async logging
        internal static Func<TRequest, CallSettings, Task<TResponse>> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, Task<TResponse>> fn, ILogger logger) =>
            async (request, callSettings) =>
            {
                logger?.LogDebug("Starting asynchronous API call.");
                var result = await fn(request, callSettings).ConfigureAwait(false);
                logger?.LogDebug("Call completed.");
                return result;
            };

        // Sync logging
        internal static Func<TRequest, CallSettings, TResponse> WithLogging<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn, ILogger logger) =>
            (request, callSettings) =>
            {
                logger?.LogDebug("Starting synchronous API call.");
                var result = fn(request, callSettings);
                logger?.LogDebug("Call completed.");
                return result;
            };
    }
}
