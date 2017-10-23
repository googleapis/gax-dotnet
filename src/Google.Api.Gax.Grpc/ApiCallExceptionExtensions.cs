/*
 * Copyright 2018 Google LLC. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiCallExceptionExtensions
    {
        // By design, the code is mostly duplicated between the async and sync calls.

        // Async exception customization
        internal static Func<TRequest, CallSettings, Task<TResponse>> WithExceptionCustomizer<TRequest, TResponse>(
            this Func<TRequest, CallSettings, Task<TResponse>> fn,
            Func<RpcException, RpcException> customizer) =>
            async (request, callSettings) =>
            {
                try
                {
                    return await fn(request, callSettings).ConfigureAwait(false);
                }
                catch (RpcException exception) when (TryCustomize(customizer, exception, out var replacement))
                {
                    throw replacement;
                }
            };

        // Sync exception customization
        internal static Func<TRequest, CallSettings, TResponse> WithExceptionCustomizer<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn,
            Func<RpcException, RpcException> customizer) =>
            (request, callSettings) =>
            {
                try
                {
                    return fn(request, callSettings);
                }
                catch (RpcException exception) when (TryCustomize(customizer, exception, out var replacement))
                {
                    throw replacement;
                }
            };

        private static bool TryCustomize(Func<RpcException, RpcException> customizer, RpcException original, out RpcException replacement)
        {
            replacement = customizer(original);
            return replacement != null;
        }
    }
}
