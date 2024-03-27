/*  
 * Copyright 2024 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc;

/// <summary>
/// Extension methods to provide tracing via <see cref="ActivitySource"/>.
/// </summary>
internal static class ApiCallTracingExtensions
{
    internal const string AttributeExceptionEventName = "exception";
    internal const string AttributeExceptionType = "exception.type";
    internal const string AttributeExceptionMessage = "exception.message";
    internal const string AttributeExceptionStacktrace = "exception.stacktrace";

    internal const string GrpcCallTypeTag = "grpc.call.type";
    internal const string UnaryCallType = "unary";
    internal const string ServerStreamingCallType = "server_streaming";
    internal const string ClientStreamingCallType = "client_streaming";
    internal const string BidiStreamingCallType = "bidi_streaming";

    // Unary async
    internal static Func<TRequest, CallSettings, Task<TResponse>> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, Task<TResponse>> fn, ActivitySource activitySource, string methodName)
    {
        GaxPreconditions.CheckNotNull(activitySource, nameof(activitySource));
        var activityName = FormatActivityName(fn, methodName);
        return async (request, callSettings) =>
        {
            using var activity = activitySource.StartActivity(activityName, ActivityKind.Client);
            activity?.SetTag(GrpcCallTypeTag, UnaryCallType);
            // TODO: Add a tag with the name of the client, in case a custom source has been provided?
            try
            {
                var response = await fn(request, callSettings).ConfigureAwait(false);
                activity?.SetStatus(ActivityStatusCode.Ok);
                return response;
            }
            catch (Exception ex) when (SetActivityException(activity, ex))
            {
                // We'll never actually get here, because SetActivityException always returns false.
                // Alternative: catch without an exception filter, make SetActivityException return void,
                // and call ExceptionDispatchInfo.Capture(e).Throw();.
                throw;
            }
        };
    }

    // Unary sync
    internal static Func<TRequest, CallSettings, TResponse> WithTracing<TRequest, TResponse>(
        this Func<TRequest, CallSettings, TResponse> fn, ActivitySource activitySource, string methodName)
    {
        GaxPreconditions.CheckNotNull(activitySource, nameof(activitySource));
        var activityName = FormatActivityName(fn, methodName);
        return (request, callSettings) =>
        {
            using var activity = activitySource.StartActivity(activityName, ActivityKind.Client);
            activity?.SetTag(GrpcCallTypeTag, UnaryCallType);
            // TODO: Add a tag with the name of the client, in case a custom source has been provided?
            try
            {
                var response = fn(request, callSettings);
                activity?.SetStatus(ActivityStatusCode.Ok);
                return response;
            }
            catch (Exception ex) when (SetActivityException(activity, ex))
            {
                // We'll never actually get here, because SetActivityException always returns false.
                // Alternative: catch without an exception filter, make SetActivityException return void,
                // and call ExceptionDispatchInfo.Capture(e).Throw();.
                // (As this is a sync method we may be okay just to use a throw statement. But we need to
                // validate that we're not losing any info.)
                throw;
            }
        };
    }

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

    // This is still very much up in the air, and may even require changes to the parameters, so that we get more information
    // (e.g. the full RPC name, the client name etc).
    private static string FormatActivityName(Delegate fn, string methodName) => $"{fn.Method.Name}/{methodName}";

    // TODO: See if there's a standard way of doing this. It seems odd to have to do it ourselves.
    /// <summary>
    /// Sets an exception within an activity. We may wish to expose this publicly for integration purposes.
    /// This always returns false, so that it can be used as an exception filter.
    /// </summary>
    private static bool SetActivityException(Activity activity, Exception ex)
    {
        if (ex is null || activity is null)
        {
            return false;
        }

        var tagsCollection = new ActivityTagsCollection
        {
            { AttributeExceptionType, ex.GetType().FullName },
            { AttributeExceptionStacktrace, ex.ToString() },
        };

        if (!string.IsNullOrWhiteSpace(ex.Message))
        {
            tagsCollection[AttributeExceptionMessage] = ex.Message;
        }

        activity.SetStatus(ActivityStatusCode.Error, ex.Message);
        activity.AddEvent(new ActivityEvent(AttributeExceptionEventName, default, tagsCollection));
        return false;
    }
}
