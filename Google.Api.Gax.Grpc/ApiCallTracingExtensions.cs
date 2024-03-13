/*  
 * Copyright 2024 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc;

/// <summary>
/// Extension methods to provide tracing via <see cref="ActivitySource"/>.
/// </summary>
internal static class ApiCallTracingExtensions
{
    // Unary async
    internal static Func<TRequest, CallSettings, Task<TResponse>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, Task<TResponse>> fn, ActivitySource activitySource, string methodName) =>
        fn;

    // Unary sync
    internal static Func<TRequest, CallSettings, TResponse> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, TResponse> fn, ActivitySource activitySource, string methodName) =>
        fn;

    // Server-streaming async
    internal static Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> fn, ActivitySource activitySource, string methodName) =>
        fn;

    // Server-streaming sync
    internal static Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> fn, ActivitySource activitySource, string methodName) =>
        fn;

    // Client-streaming
    internal static Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> WithTracing<TRequest, TResponse>(
        this Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> fn, ActivitySource activitySource, string methodName) =>
        fn;

    // Bidi-streaming
    internal static Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> WithTracing<TRequest, TResponse>(
        this Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> fn, ActivitySource activitySource, string methodName) =>
        fn;
}
