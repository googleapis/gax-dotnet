/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Helper methods to create <see cref="ApiResumableUploadCall{TRequest, TResponse}"/> instances.
/// </summary>
internal static class ApiResumableUploadCall
{
    internal static ApiResumableUploadCall<TRequest, TResponse> Create<TRequest, TResponse>(
        string methodName,
        CallInvoker callInvoker,
        Method<TRequest, TResponse> method,
        CallSettings startMethodCallSettings,
        ResumableUploadSettings resumableUploadSettings,
        IClock clock)
        where TRequest : class
        where TResponse : class
    {
        GaxPreconditions.CheckNotNull(methodName, nameof(methodName));
        GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
        GaxPreconditions.CheckNotNull(method, nameof(method));

        GaxPreconditions.CheckArgument(
            callInvoker is RestCallInvoker,
            nameof(callInvoker),
            "Resumable uploads require a REST transport (RestCallInvoker).");

        resumableUploadSettings ??= ResumableUploadSettings.Default;
        var restCallInvoker = (RestCallInvoker) callInvoker;
        var resumableUploadClient = new ResumableUploadClient<TRequest, TResponse>(restCallInvoker, method);

        var controlCallSettings = resumableUploadSettings.ToControlCallSettings();
        var dataCallSettings = resumableUploadSettings.ToDataCallSettings();

        var startCall = ApiCall.Create<TRequest, StartUploadResponse>(
            $"{methodName}#start",
            resumableUploadClient.StartAsync,
            controlCallSettings.MergedWith(startMethodCallSettings), clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<TResponse>>(
            $"{methodName}#upload",
            resumableUploadClient.UploadChunkAsync,
            dataCallSettings, clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<TResponse>>(
            $"{methodName}#upload,finalize",
            resumableUploadClient.UploadFinalizeAsync,
            dataCallSettings, clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<TResponse>>(
            $"{methodName}#query",
            resumableUploadClient.QueryOffsetAsync,
            controlCallSettings, clock);

        var finalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<TResponse>>(
            $"{methodName}#finalize",
            resumableUploadClient.FinalizeAsync,
            dataCallSettings, clock);

        return new ApiResumableUploadCall<TRequest, TResponse>(
            startCall,
            uploadChunkCall,
            uploadFinalizeCall,
            queryOffsetCall,
            finalizeCall,
            resumableUploadSettings,
            clock);
    }
}

/// <summary>
/// Bridge between a GAPIC client and a <see cref="ResumableUploadClient{TRequest, TResponse}"/> over REST transport.
/// Manages the 5 underlying commands (<c>start</c>, <c>upload</c>, <c>upload, finalize</c>, <c>query</c>, and <c>finalize</c>)
/// using GAX <see cref="ApiCall"/> pipeline infrastructure.
/// Instances of this class are immutable.
/// </summary>
/// <typeparam name="TRequest">The RPC request type.</typeparam>
/// <typeparam name="TResponse">The RPC response type.</typeparam>
public sealed class ApiResumableUploadCall<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    /// <summary>
    /// The <see cref="ApiCall{TRequest, TResponse}"/> for the 'start' command.
    /// </summary>
    internal ApiCall<TRequest, StartUploadResponse> StartCall { get; }

    /// <summary>
    /// The <see cref="ApiCall{TRequest, TResponse}"/> for ongoing 'upload' chunk commands.
    /// </summary>
    internal ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> UploadChunkCall { get; }

    /// <summary>
    /// The <see cref="ApiCall{TRequest, TResponse}"/> for the 'upload, finalize' final chunk command.
    /// </summary>
    internal ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> UploadFinalizeCall { get; }

    /// <summary>
    /// The <see cref="ApiCall{TRequest, TResponse}"/> for the 'query' offset recovery command.
    /// </summary>
    internal ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> QueryOffsetCall { get; }

    /// <summary>
    /// The <see cref="ApiCall{TRequest, TResponse}"/> for the 'finalize' empty payload command.
    /// </summary>
    internal ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> FinalizeCall { get; }

    /// <summary>
    /// Gets the <see cref="ResumableUploadSettings"/> for this call.
    /// </summary>
    internal ResumableUploadSettings ResumableUploadSettings { get; }

    /// <summary>
    /// Gets the <see cref="IClock"/> for this call.
    /// </summary>
    internal IClock Clock { get; }

    /// <summary>
    /// Constructs a new <see cref="ApiResumableUploadCall{TRequest, TResponse}"/> with the specified parameters.
    /// </summary>
    internal ApiResumableUploadCall(
        ApiCall<TRequest, StartUploadResponse> startCall,
        ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> uploadChunkCall,
        ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> uploadFinalizeCall,
        ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> queryOffsetCall,
        ApiCall<ResumableUploadRequest, UploadChunkResponse<TResponse>> finalizeCall,
        ResumableUploadSettings resumableUploadSettings,
        IClock clock)
    {
        StartCall = GaxPreconditions.CheckNotNull(startCall, nameof(startCall));
        UploadChunkCall = GaxPreconditions.CheckNotNull(uploadChunkCall, nameof(uploadChunkCall));
        UploadFinalizeCall = GaxPreconditions.CheckNotNull(uploadFinalizeCall, nameof(uploadFinalizeCall));
        QueryOffsetCall = GaxPreconditions.CheckNotNull(queryOffsetCall, nameof(queryOffsetCall));
        FinalizeCall = GaxPreconditions.CheckNotNull(finalizeCall, nameof(finalizeCall));
        ResumableUploadSettings = GaxPreconditions.CheckNotNull(resumableUploadSettings, nameof(resumableUploadSettings));
        Clock = GaxPreconditions.CheckNotNull(clock, nameof(clock));
    }

    /// <summary>
    /// Creates a new <see cref="ResumableUploadSession{TRequest, TResponse}"/> managed by this call wrapper.
    /// </summary>
    /// <returns>A new <see cref="ResumableUploadSession{TRequest, TResponse}"/> instance.</returns>
    public ResumableUploadSession<TRequest, TResponse> CreateSession() =>
        new ResumableUploadSession<TRequest, TResponse>(this);


    /// <summary>
    /// Executes the 'start' command asynchronously.
    /// </summary>
    internal Task<StartUploadResponse> StartAsync(TRequest request, CallSettings perCallCallSettings = null) =>
        StartCall.Async(request, perCallCallSettings);

    /// <summary>
    /// Executes the 'upload' command asynchronously for a chunk with optional expiration.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> UploadChunkAsync(ResumableUploadRequest request, Expiration expiration = null) =>
        UploadChunkCall.Async(request, CallSettings.FromExpiration(expiration));

    /// <summary>
    /// Executes the 'upload, finalize' command asynchronously for the final chunk with optional expiration.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> UploadFinalizeAsync(ResumableUploadRequest request, Expiration expiration = null) =>
        UploadFinalizeCall.Async(request, CallSettings.FromExpiration(expiration));

    /// <summary>
    /// Executes the 'query' command asynchronously to recover the committed offset with optional expiration.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> QueryOffsetAsync(ResumableUploadRequest request, Expiration expiration = null) =>
        QueryOffsetCall.Async(request, CallSettings.FromExpiration(expiration));

    /// <summary>
    /// Executes the 'finalize' command asynchronously for an empty final payload with optional expiration.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> FinalizeAsync(ResumableUploadRequest request, Expiration expiration = null) =>
        FinalizeCall.Async(request, CallSettings.FromExpiration(expiration));

    internal ApiResumableUploadCall<TRequest, TResponse> WithMergedBaseCallSettings(CallSettings settings) =>
        new ApiResumableUploadCall<TRequest, TResponse>(
            StartCall.WithMergedBaseCallSettings(settings),
            UploadChunkCall,
            UploadFinalizeCall,
            QueryOffsetCall,
            FinalizeCall,
            ResumableUploadSettings,
            Clock);

    /// <summary>
    /// Constructs a new <see cref="ApiResumableUploadCall{TRequest, TResponse}"/> that applies an overlay to the underlying <see cref="CallSettings"/> of the <see cref="StartCall"/>.
    /// </summary>
    public ApiResumableUploadCall<TRequest, TResponse> WithCallSettingsOverlay(Func<TRequest, CallSettings> callSettingsOverlayFn) =>
        new ApiResumableUploadCall<TRequest, TResponse>(
            StartCall.WithCallSettingsOverlay(callSettingsOverlayFn),
            UploadChunkCall,
            UploadFinalizeCall,
            QueryOffsetCall,
            FinalizeCall,
            ResumableUploadSettings,
            Clock);

    internal ApiResumableUploadCall<TRequest, TResponse> WithLogging(ILogger logger) =>
        logger is null
            ? this
            : new ApiResumableUploadCall<TRequest, TResponse>(
                StartCall.WithLogging(logger),
                UploadChunkCall.WithLogging(logger),
                UploadFinalizeCall.WithLogging(logger),
                QueryOffsetCall.WithLogging(logger),
                FinalizeCall.WithLogging(logger),
                ResumableUploadSettings,
                Clock);

    internal ApiResumableUploadCall<TRequest, TResponse> WithTracing(ActivitySource activitySource) =>
        activitySource is null
            ? this
            : new ApiResumableUploadCall<TRequest, TResponse>(
                StartCall.WithTracing(activitySource),
                UploadChunkCall.WithTracing(activitySource),
                UploadFinalizeCall.WithTracing(activitySource),
                QueryOffsetCall.WithTracing(activitySource),
                FinalizeCall.WithTracing(activitySource),
                ResumableUploadSettings,
                Clock);

    /// <summary>
    /// Constructs a new <see cref="ApiResumableUploadCall{TRequest, TResponse}"/> with retry applied to all underlying sub-calls.
    /// </summary>
    internal ApiResumableUploadCall<TRequest, TResponse> WithRetry(IClock clock, IScheduler scheduler, ILogger retryLogger) =>
        new ApiResumableUploadCall<TRequest, TResponse>(
            StartCall.WithRetry(clock, scheduler, retryLogger),
            UploadChunkCall.WithRetry(clock, scheduler, retryLogger),
            UploadFinalizeCall.WithRetry(clock, scheduler, retryLogger),
            QueryOffsetCall.WithRetry(clock, scheduler, retryLogger),
            FinalizeCall.WithRetry(clock, scheduler, retryLogger),
            ResumableUploadSettings,
            clock ?? Clock);

    /// <summary>
    /// Constructs a new <see cref="ApiResumableUploadCall{TRequest, TResponse}"/> that applies an x-goog-request-params header to the <see cref="StartCall"/>.
    /// </summary>
    public ApiResumableUploadCall<TRequest, TResponse> WithGoogleRequestParam(string parameterName, Func<TRequest, string> valueSelector) =>
        new ApiResumableUploadCall<TRequest, TResponse>(
            StartCall.WithGoogleRequestParam(parameterName, valueSelector),
            UploadChunkCall,
            UploadFinalizeCall,
            QueryOffsetCall,
            FinalizeCall,
            ResumableUploadSettings,
            Clock);

    /// <summary>
    /// Constructs a new <see cref="ApiResumableUploadCall{TRequest, TResponse}"/> that applies an extracted routing header to the <see cref="StartCall"/>.
    /// </summary>
    public ApiResumableUploadCall<TRequest, TResponse> WithExtractedGoogleRequestParam(RoutingHeaderExtractor<TRequest> extractor) =>
        new ApiResumableUploadCall<TRequest, TResponse>(
            StartCall.WithExtractedGoogleRequestParam(extractor),
            UploadChunkCall,
            UploadFinalizeCall,
            QueryOffsetCall,
            FinalizeCall,
            ResumableUploadSettings,
            Clock);
}
