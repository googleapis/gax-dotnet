/*
 * Copyright 2023 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc;

internal static class ApiCallTracingExtensions
{
    internal const string GrpcCallTypeTag = "grpc.call.type";
    internal const string UnaryCallType = "unary";
    internal const string ServerStreamingCallType = "server_streaming";
    internal const string ClientStreamingCallType = "client_streaming";
    internal const string BidiStreamingCallType = "bidi_streaming";

    // By design, the code is mostly duplicated between the async and sync calls.

    #region Unary calls
    // Async call
    internal static Func<TRequest, CallSettings, Task<TResponse>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, Task<TResponse>> fn, ActivitySource activitySource, string methodName) =>
        async (request, callSettings) =>
        {
            using var activity = activitySource?.StartActivity($"{methodName}/{fn.Method.Name}");
            activity?.SetTag(GrpcCallTypeTag, UnaryCallType);
            try
            {
                return await fn(request, callSettings).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                activity?.SetException(ex);
                throw;
            }
        };

    // Sync call
    internal static Func<TRequest, CallSettings, TResponse> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, TResponse> fn, ActivitySource activitySource, string methodName) =>
        (request, callSettings) =>
        {
            using var activity = activitySource?.StartActivity($"{methodName}/{fn.Method.Name}");
            activity?.SetTag(GrpcCallTypeTag, UnaryCallType);
            try
            {
                return fn(request, callSettings);
            }
            catch (Exception ex)
            {
                activity?.SetException(ex);
                throw;
            }
        };
    #endregion

    #region Server streaming
    // Async call
    internal static Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, Task<AsyncServerStreamingCall<TResponse>>> fn, ActivitySource activitySource, string methodName) =>
        async (request, callSettings) =>
        {
            using var activity = activitySource?.StartActivity($"{methodName}/{fn.Method.Name}");
            activity?.SetTag(GrpcCallTypeTag, ServerStreamingCallType);
            return await fn(request, callSettings).ConfigureAwait(false);
        };

    // Sync call
    internal static Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, AsyncServerStreamingCall<TResponse>> fn, ActivitySource activitySource, string methodName) =>
        (request, callSettings) =>
        {
            using var activity = activitySource?.StartActivity($"{methodName}/{fn.Method.Name}");
            activity?.SetTag(GrpcCallTypeTag, ServerStreamingCallType);
            return fn(request, callSettings);
        };
    #endregion

    #region Client streaming
    internal static Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> WithTracing<TRequest, TResponse>(
        this Func<CallSettings, AsyncClientStreamingCall<TRequest, TResponse>> fn, ActivitySource activitySource, string methodName) =>
        callSettings =>
        {
            using var activity = activitySource?.StartActivity($"{methodName}/{fn.Method.Name}");
            activity?.SetTag(GrpcCallTypeTag, ClientStreamingCallType);
            return fn(callSettings);
        };
    #endregion

    #region Bidi streaming
    internal static Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> WithTracing<TRequest, TResponse>(
        this Func<CallSettings, AsyncDuplexStreamingCall<TRequest, TResponse>> fn, ActivitySource activitySource, string methodName) =>
        callSettings =>
        {
            using var activity = activitySource?.StartActivity($"{methodName}/{fn.Method.Name}");
            activity?.SetTag(GrpcCallTypeTag, BidiStreamingCallType);
            return fn(callSettings);
        };
    #endregion
}
