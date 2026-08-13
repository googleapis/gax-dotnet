/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Manages a resumable upload session for a specific request and response type.
/// </summary>
/// <typeparam name="TRequest">The request message type.</typeparam>
/// <typeparam name="TResponse">The response message type.</typeparam>
public sealed class ResumableUploadSession<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    private readonly ApiResumableUploadCall<TRequest, TResponse> _uploadCall;
    private readonly object _lock = new object();
    private Uri _uploadUri;
    private long? _chunkGranularity;

    /// <summary>
    /// Gets the upload URI assigned to this session, or <c>null</c> if not yet started or resumed.
    /// </summary>
    public Uri UploadUri
    {
        get
        {
            lock (_lock)
            {
                return _uploadUri;
            }
        }
    }

    /// <summary>
    /// Gets the server-specified chunk granularity in bytes returned by the start command, or <c>null</c> if not specified or not yet started.
    /// </summary>
    public long? ChunkGranularity
    {
        get
        {
            lock (_lock)
            {
                return _chunkGranularity;
            }
        }
    }

    internal ResumableUploadSession(ApiResumableUploadCall<TRequest, TResponse> uploadCall)
    {
        _uploadCall = GaxPreconditions.CheckNotNull(uploadCall, nameof(uploadCall));
    }

    /// <summary>
    /// Begins a new resumable upload session.
    /// </summary>
    /// <param name="request">The initial request payload to initiate the upload.</param>
    /// <param name="stream">The content stream to upload.</param>
    /// <param name="uploadSettings">Optional settings overriding default upload configuration.</param>
    /// <param name="callSettings">Optional call settings to apply to initial start RPC.</param>
    /// <returns>A task returning the completed response object upon successful upload.</returns>
    public async Task<TResponse> BeginUploadAsync(
        TRequest request,
        Stream stream,
        ResumableUploadSettings uploadSettings = null,
        CallSettings callSettings = null)
    {
        GaxPreconditions.CheckNotNull(request, nameof(request));
        GaxPreconditions.CheckNotNull(stream, nameof(stream));
        GaxPreconditions.CheckState(UploadUri is null, "Session has already been started or resumed.");

        ResumableUploadSettings effectiveUploadSettings = uploadSettings ?? _uploadCall.ResumableUploadSettings;

        StartUploadResponse startResponse = await _uploadCall.StartAsync(request, callSettings).ConfigureAwait(false);

        SetStateAfterStart(startResponse);

        effectiveUploadSettings = WithAdjustedChunkSize(effectiveUploadSettings, startResponse.ChunkGranularity);

        using IResumableUploadStream resumableStream = ResumableUploadStream.Create(stream, effectiveUploadSettings.ChunkSize, leaveOpen: true);
        var engine = new ResumableUploadProtocolEngine<TRequest, TResponse>(_uploadCall, UploadUri, resumableStream, effectiveUploadSettings);
        return await engine.UploadChunksAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Resumes an existing resumable upload session using a known upload URI.
    /// </summary>
    /// <param name="uploadUri">The upload URI for the existing resumable session.</param>
    /// <param name="stream">The content stream to upload.</param>
    /// <param name="uploadSettings">Optional settings overriding default upload configuration.</param>
    /// <returns>A task returning the completed response object upon successful upload.</returns>
    public async Task<TResponse> ResumeUploadAsync(
        Uri uploadUri,
        Stream stream,
        ResumableUploadSettings uploadSettings = null)
    {
        GaxPreconditions.CheckNotNull(uploadUri, nameof(uploadUri));
        GaxPreconditions.CheckNotNull(stream, nameof(stream));

        SetStateAfterResume(uploadUri);

        ResumableUploadSettings effectiveUploadSettings = uploadSettings ?? _uploadCall.ResumableUploadSettings;

        using IResumableUploadStream resumableStream = ResumableUploadStream.Create(stream, effectiveUploadSettings.ChunkSize, leaveOpen: true);
        var engine = new ResumableUploadProtocolEngine<TRequest, TResponse>(_uploadCall, UploadUri, resumableStream, effectiveUploadSettings);
        return await engine.ResumeAsync().ConfigureAwait(false);
    }

    private void SetStateAfterStart(StartUploadResponse startResponse)
    {
        GaxPreconditions.CheckNotNull(startResponse, nameof(startResponse));
        GaxPreconditions.CheckNotNull(startResponse.UploadUri, nameof(startResponse.UploadUri));

        lock (_lock)
        {
            GaxPreconditions.CheckState(_uploadUri is null, "Session has already been started or resumed.");
            _uploadUri = startResponse.UploadUri;
            _chunkGranularity = startResponse.ChunkGranularity;
        }
    }

    private void SetStateAfterResume(Uri uploadUri)
    {
        GaxPreconditions.CheckNotNull(uploadUri, nameof(uploadUri));

        lock (_lock)
        {
            GaxPreconditions.CheckState(_uploadUri is null, "Session has already been started or resumed.");
            _uploadUri = uploadUri;
        }
    }

    internal static ResumableUploadSettings WithAdjustedChunkSize(ResumableUploadSettings uploadSettings, long? serverGranularity)
    {
        GaxPreconditions.CheckNotNull(uploadSettings, nameof(uploadSettings));

        if (!serverGranularity.HasValue || serverGranularity.Value <= 0)
        {
            return uploadSettings;
        }

        long granularity = serverGranularity.Value;
        long multiple = uploadSettings.ChunkSize / granularity;

        long adjustedChunkSize = multiple == 0 ? granularity : multiple * granularity;

        return adjustedChunkSize == uploadSettings.ChunkSize
            ? uploadSettings
            : uploadSettings.WithChunkSize(adjustedChunkSize);
    }
}

/// <summary>
/// Internal protocol engine orchestrating state transitions, chunked upload execution,
/// error recovery, stream rewinding, and status querying.
/// </summary>
internal sealed class ResumableUploadProtocolEngine<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    private readonly ApiResumableUploadCall<TRequest, TResponse> _uploadCall;
    private readonly Uri _uploadUri;
    private readonly IResumableUploadStream _stream;
    private readonly ResumableUploadSettings _uploadSettings;
    private readonly byte[] _chunkBuffer;
    private readonly DateTime? _overallDeadline;

    private long _currentOffset;

    public ResumableUploadProtocolEngine(
        ApiResumableUploadCall<TRequest, TResponse> uploadCall,
        Uri uploadUri,
        IResumableUploadStream stream,
        ResumableUploadSettings uploadSettings)
    {
        _uploadCall = GaxPreconditions.CheckNotNull(uploadCall, nameof(uploadCall));
        _uploadUri = GaxPreconditions.CheckNotNull(uploadUri, nameof(uploadUri));
        _stream = GaxPreconditions.CheckNotNull(stream, nameof(stream));
        _uploadSettings = GaxPreconditions.CheckNotNull(uploadSettings, nameof(uploadSettings));
        _chunkBuffer = new byte[(int) Math.Min(_uploadSettings.ChunkSize, int.MaxValue)];

        _overallDeadline = _uploadSettings.UploadDeadline.Type switch
        {
            ExpirationType.Deadline => _uploadSettings.UploadDeadline.Deadline,
            ExpirationType.Timeout => _uploadCall.Clock.GetCurrentDateTimeUtc() + _uploadSettings.UploadDeadline.Timeout,
            _ => null
        };
    }

    /// <summary>
    /// Entry point for starting or continuing chunk upload execution.
    /// </summary>
    public Task<TResponse> UploadChunksAsync() => ReadNextChunkAsync();

    /// <summary>
    /// Entry point for resuming an existing upload session by querying the server's committed offset.
    /// </summary>
    public Task<TResponse> ResumeAsync() => QueryAsync();

    /// <summary>
    /// Recovering State: Queries the server for current committed offset, rewinds stream, and resumes upload chunking.
    /// </summary>
    private async Task<TResponse> QueryAsync()
    {
        var queryRequest = new ResumableUploadRequest(_uploadUri);
        UploadChunkResponse<TResponse> queryResponse = await _uploadCall.QueryOffsetAsync(queryRequest).ConfigureAwait(false);

        if (queryResponse.IsFinal)
        {
            return queryResponse.ResponseBody;
        }

        if (!queryResponse.CommittedOffset.HasValue)
        {
            throw new InvalidOperationException("Server query response did not contain a committed offset.");
        }

        long serverCommittedOffset = queryResponse.CommittedOffset.Value;
        if (!_stream.TryRewind(serverCommittedOffset))
        {
            throw new InvalidOperationException($"Unable to position stream to server committed offset {serverCommittedOffset}.");
        }

        _currentOffset = serverCommittedOffset;
        return await ReadNextChunkAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Reading / Chunk Preparation State: Reads next chunk from stream and transitions to UploadChunkAsync or UploadFinalChunkAsync.
    /// </summary>
    private async Task<TResponse> ReadNextChunkAsync()
    {
        int bytesRead = await _stream.ReadAsync(_chunkBuffer, 0, _chunkBuffer.Length, CancellationToken.None).ConfigureAwait(false);

        bool isFinal = _stream.Length.HasValue && (_currentOffset + bytesRead) >= _stream.Length.Value;

        var chunk = new ResumableUploadChunk(_chunkBuffer, 0, bytesRead, _currentOffset);
        var chunkRequest = new ResumableUploadRequest(_uploadUri, chunk);
        Expiration chunkExpiration = GetNextChunkExpiration();

        return await UploadChunkAsync(chunkRequest, chunkExpiration, isFinal).ConfigureAwait(false);
    }

    /// <summary>
    /// Uploading State: Sends a chunk to the server using #upload (non-final) or #upload, finalize (final).
    /// </summary>
    private async Task<TResponse> UploadChunkAsync(ResumableUploadRequest chunkRequest, Expiration chunkExpiration, bool isFinal)
    {
        UploadChunkResponse<TResponse> chunkResponse;
        try
        {
            chunkResponse = isFinal
                ? await _uploadCall.UploadFinalizeAsync(chunkRequest, chunkExpiration).ConfigureAwait(false)
                : await _uploadCall.UploadChunkAsync(chunkRequest, chunkExpiration).ConfigureAwait(false);
        }
        catch (RpcException ex) when (IsRecoverableError(ex))
        {
            return await QueryAsync().ConfigureAwait(false);
        }

        if (chunkResponse.Status is null)
        {
            return await QueryAsync().ConfigureAwait(false);
        }

        if (chunkResponse.IsFinal)
        {
            return chunkResponse.ResponseBody;
        }

        _currentOffset = chunkResponse.CommittedOffset ?? (_currentOffset + chunkRequest.UploadChunk.Count);
        return await ReadNextChunkAsync().ConfigureAwait(false);
    }

    private Expiration GetNextChunkExpiration()
    {
        if (!_overallDeadline.HasValue)
        {
            return Expiration.None;
        }

        DateTime now = _uploadCall.Clock.GetCurrentDateTimeUtc();
        TimeSpan remaining = _overallDeadline.Value - now;
        if (remaining <= TimeSpan.Zero)
        {
            return Expiration.FromTimeout(TimeSpan.Zero);
        }

        TimeSpan halfRemaining = TimeSpan.FromTicks(remaining.Ticks / 2);
        return Expiration.FromTimeout(halfRemaining);
    }

    private static bool IsRecoverableError(RpcException ex)
    {
        if (ex == null)
        {
            return false;
        }

        // 1. Non-recoverable conditions:
        // - HTTP 404 (StatusCode.NotFound)
        // - Response header X-Goog-Upload-Status: final
        if (ex.StatusCode == StatusCode.NotFound)
        {
            return false;
        }

        string uploadStatus = ResumableUploadClient.GetHeaderValue(ex.Trailers, ResumableUploadClient.StatusHeaderName);
        if (string.Equals(uploadStatus, ResumableUploadClient.FinalStatusValue, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        // 2. Recoverable conditions:
        // - Category 2 status codes (HTTP 400 InvalidArgument, HTTP 412 FailedPrecondition, HTTP 416 OutOfRange)
        // - Category 1 status codes (transient errors: Unavailable, DeadlineExceeded, ResourceExhausted, Internal)
        return ex.StatusCode == StatusCode.InvalidArgument
            || ex.StatusCode == StatusCode.FailedPrecondition
            || ex.StatusCode == StatusCode.OutOfRange
            || ResumableUploadSettings.TransientErrorCodes.Contains(ex.StatusCode);
    }
}
