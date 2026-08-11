/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Constants and helpers used by the resumable upload protocol.
/// </summary>
internal static class ResumableUploadClient
{
    // Request Header Names
    internal const string ProtocolHeaderName = "X-Goog-Upload-Protocol";
    internal const string CommandHeaderName = "X-Goog-Upload-Command";
    internal const string OffsetHeaderName = "X-Goog-Upload-Offset";

    // Response Header Names
    internal const string UploadUrlHeaderName = "X-Goog-Upload-URL";
    internal const string StatusHeaderName = "X-Goog-Upload-Status";
    internal const string SizeReceivedHeaderName = "X-Goog-Upload-Size-Received";
    internal const string ChunkGranularityHeaderName = "X-Goog-Upload-Chunk-Granularity";

    // Header Values
    internal const string ResumableProtocolValue = "resumable";
    internal const string StartCommandValue = "start";
    internal const string UploadCommandValue = "upload";
    internal const string UploadFinalizeCommandValue = "upload, finalize";
    internal const string QueryCommandValue = "query";
    internal const string FinalizeCommandValue = "finalize";
    internal const string ActiveStatusValue = "active";
    internal const string FinalStatusValue = "final";

    /// <summary>
    /// Extracts a header value matching <paramref name="key"/> case-insensitively from <paramref name="headers"/>.
    /// </summary>
    internal static string GetHeaderValue(Metadata headers, string key) =>
        headers?.FirstOrDefault(e => string.Equals(e.Key, key, StringComparison.OrdinalIgnoreCase))?.Value;
}

/// <summary>
/// Client for executing resumable upload commands over REST transport.
/// </summary>
/// <remarks>
/// Synthetic gRPC method descriptors (<c>_startMethod</c> with suffix <c>#start</c> and <c>_startedMethod</c> with suffix <c>#started</c>)
/// are constructed directly from the original protobuf gRPC <see cref="Method{TRequest, TResponse}"/> descriptor passed into the constructor.
/// This avoids dummy marshaller allocations and dynamic method descriptor parsing on hot execution paths by reusing the original
/// request and response marshallers from the original method descriptor.
/// </remarks>
/// <typeparam name="TRequest">The RPC request type.</typeparam>
/// <typeparam name="TResponse">The RPC response type.</typeparam>
internal sealed class ResumableUploadClient<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    private static readonly Marshaller<ResumableUploadRequest> s_resumableUploadRequestMarshaller =
        Marshallers.Create<ResumableUploadRequest>(req => Array.Empty<byte>(), bytes => null);

    private readonly RestCallInvoker _callInvoker;

    /// <summary>
    /// Synthetic gRPC method descriptor for the initial 'start' upload command, appending '#start' to the method name.
    /// Reuses the request and response marshallers from the original gRPC method descriptor.
    /// </summary>
    private readonly Method<TRequest, TResponse> _startMethod;

    /// <summary>
    /// Synthetic gRPC method descriptor for ongoing upload chunk, query, and finalize commands, appending '#started' to the method name.
    /// Uses a no-op marshaller for <see cref="ResumableUploadRequest"/> payloads and reuses the response marshaller from the original gRPC method descriptor.
    /// </summary>
    private readonly Method<ResumableUploadRequest, TResponse> _startedMethod;

    /// <summary>
    /// Constructs a client for the given RPC method.
    /// </summary>
    /// <param name="callInvoker">The call invoker (a <see cref="RestCallInvoker"/>).</param>
    /// <param name="method">The gRPC method descriptor for the original protobuf operation.</param>
    internal ResumableUploadClient(RestCallInvoker callInvoker, Method<TRequest, TResponse> method)
    {
        _callInvoker = GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
        GaxPreconditions.CheckNotNull(method, nameof(method));

        _startMethod = new Method<TRequest, TResponse>(
            method.Type,
            method.ServiceName,
            $"{method.Name}#start",
            method.RequestMarshaller,
            method.ResponseMarshaller);

        _startedMethod = new Method<ResumableUploadRequest, TResponse>(
            method.Type,
            method.ServiceName,
            $"{method.Name}#started",
            s_resumableUploadRequestMarshaller,
            method.ResponseMarshaller);
    }

    /// <summary>
    /// Issues the 'start' command for a resumable upload session.
    /// </summary>
    internal async Task<StartUploadResponse> StartAsync(TRequest request, CallOptions options = default)
    {
        GaxPreconditions.CheckNotNull(request, nameof(request));

        options = WithHeader(options, ResumableUploadClient.ProtocolHeaderName, ResumableUploadClient.ResumableProtocolValue);
        options = WithHeader(options, ResumableUploadClient.CommandHeaderName, ResumableUploadClient.StartCommandValue);

        var call = _callInvoker.AsyncUnaryCall(_startMethod, host: null, options, request);

        await call.ResponseAsync.ConfigureAwait(false);
        var headers = await call.ResponseHeadersAsync.ConfigureAwait(false);

        return StartUploadResponse.FromResponseHeaders(headers);
    }

    /// <summary>
    /// Issues the 'upload' command for a chunk of a resumable upload session.
    /// Attaches the 'X-Goog-Upload-Offset' header extracted from <see cref="ResumableUploadChunk.UploadOffset"/>.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> UploadChunkAsync(ResumableUploadRequest request, CallOptions options = default) =>
        ExecuteStartedCommandAsync(request, ResumableUploadClient.UploadCommandValue, includeUploadOffset: true, options);

    /// <summary>
    /// Issues the 'upload, finalize' command for the final chunk of a resumable upload session.
    /// Attaches the 'X-Goog-Upload-Offset' header extracted from <see cref="ResumableUploadChunk.UploadOffset"/>.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> UploadFinalizeAsync(ResumableUploadRequest request, CallOptions options = default) =>
        ExecuteStartedCommandAsync(request, ResumableUploadClient.UploadFinalizeCommandValue, includeUploadOffset: true, options);

    /// <summary>
    /// Issues the 'query' command to inspect the current committed offset of a resumable upload session.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> QueryOffsetAsync(ResumableUploadRequest request, CallOptions options = default) =>
        ExecuteStartedCommandAsync(request, ResumableUploadClient.QueryCommandValue, includeUploadOffset: false, options);

    /// <summary>
    /// Issues the 'finalize' command for an empty final payload to complete a resumable upload session.
    /// Does not attach the 'X-Goog-Upload-Offset' header as no payload data is transmitted.
    /// </summary>
    internal Task<UploadChunkResponse<TResponse>> FinalizeAsync(ResumableUploadRequest request, CallOptions options = default) =>
        ExecuteStartedCommandAsync(request, ResumableUploadClient.FinalizeCommandValue, includeUploadOffset: false, options);

    private async Task<UploadChunkResponse<TResponse>> ExecuteStartedCommandAsync(ResumableUploadRequest request, string command, bool includeUploadOffset, CallOptions options)
    {
        GaxPreconditions.CheckNotNull(request, nameof(request));
        GaxPreconditions.CheckNotNull(command, nameof(command));

        options = WithHeader(options, ResumableUploadClient.CommandHeaderName, command);

        if (includeUploadOffset)
        {
            var chunk = GaxPreconditions.CheckNotNull(request.UploadChunk, nameof(request.UploadChunk));
            options = WithHeader(options, ResumableUploadClient.OffsetHeaderName, chunk.UploadOffset.ToString());
        }

        var call = _callInvoker.AsyncUnaryCall(_startedMethod, host: null, options, request);
        var responseBody = await call.ResponseAsync.ConfigureAwait(false);
        var headers = await call.ResponseHeadersAsync.ConfigureAwait(false);

        return UploadChunkResponse<TResponse>.FromHeadersAndPayload(headers, responseBody);
    }

    private static CallOptions WithHeader(CallOptions options, string key, string value)
    {
        // Note: We mutate options.Headers directly in-place because CallOptions headers are created per-call during RPC execution and are safe to modify.
        var headers = options.Headers ?? new Metadata();
        headers.Add(key, value);
        return options.Headers is null ? options.WithHeaders(headers) : options;
    }
}
