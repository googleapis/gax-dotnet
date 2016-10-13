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
    internal static class ApiCallExtensions
    {
        /// <summary>
        /// Maps a function that takes an arbitrary type as its second parameter,
        /// to a function that takes a <see cref="CallSettings"/> second parameter.
        /// </summary>
        /// <typeparam name="A">The type of the first function parameter.</typeparam>
        /// <typeparam name="B">The type of the second input function parameter.</typeparam>
        /// <typeparam name="R">The return type of the function.</typeparam>
        /// <param name="f">The function of which to map the seconds parameter.</param>
        /// <param name="fMap">Function that maps type B to <see cref="CallSettings"/>.</param>
        /// <returns>The mapped function.</returns>
        internal static Func<A, CallSettings, R> MapArg<A, B, R>(
            this Func<A, B, R> f, Func<CallSettings, B> fMap) =>
            (a, callSettings) => f(a, fMap(callSettings));

        /// <summary>
        /// Map a function that gRPC function that returns a <see cref="AsyncUnaryCall{TResponse}"/>
        /// to return a <see cref="Task{TResponse}"/> of the response.
        /// </summary>
        /// <typeparam name="TRequest">The gRPC request type.</typeparam>
        /// <typeparam name="TResponse">The gRPC response type.</typeparam>
        /// <param name="fn">The function of which to map the return value.</param>
        /// <returns>The mapped function.</returns>
        internal static Func<TRequest, CallOptions, Task<TResponse>> WithTaskTransform<TRequest, TResponse>(
            this Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> fn) =>
            (request, callOptions) => fn(request, callOptions).ResponseAsync;
    }
}
