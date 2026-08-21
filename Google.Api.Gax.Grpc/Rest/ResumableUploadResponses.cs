/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Grpc.Core;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Response for the start command of a resumable upload.
/// </summary>
internal sealed class StartUploadResponse
{
    /// <summary>
    /// The upload session URI extracted from response header 'X-Goog-Upload-URL'.
    /// </summary>
    internal Uri UploadUri { get; }

    /// <summary>
    /// The status extracted from response header 'X-Goog-Upload-Status'.
    /// </summary>
    internal string Status { get; }

    /// <summary>
    /// The required chunk granularity extracted from response header 'X-Goog-Upload-Chunk-Granularity', or <c>null</c> if not specified.
    /// </summary>
    internal int? ChunkGranularity { get; }

    internal StartUploadResponse(Uri uploadUri, string status, int? chunkGranularity = null) =>
        (UploadUri, Status, ChunkGranularity) = (uploadUri, status, chunkGranularity);

    internal static StartUploadResponse FromResponseHeaders(Metadata headers)
    {
        string uploadUrlStr = ResumableUploadClient.GetHeaderValue(headers, ResumableUploadClient.UploadUrlHeaderName);
        Uri uploadUri = uploadUrlStr is not null ? new Uri(uploadUrlStr) : null;
        string status = ResumableUploadClient.GetHeaderValue(headers, ResumableUploadClient.StatusHeaderName);
        string granularityStr = ResumableUploadClient.GetHeaderValue(headers, ResumableUploadClient.ChunkGranularityHeaderName);
        int? chunkGranularity = int.TryParse(granularityStr, out int parsedGranularity) ? parsedGranularity : null;
        return new StartUploadResponse(uploadUri, status, chunkGranularity);
    }
}

/// <summary>
/// Response for chunk upload, query, and finalize commands of a resumable upload.
/// </summary>
/// <typeparam name="TResponse">The RPC response type (which may be null for non-final chunks).</typeparam>
internal sealed class UploadChunkResponse<TResponse>
    where TResponse : class
{
    /// <summary>
    /// The committed byte offset extracted from response header 'X-Goog-Upload-Size-Received'.
    /// </summary>
    internal long? CommittedOffset { get; }

    /// <summary>
    /// The status extracted from response header 'X-Goog-Upload-Status' (e.g. "active" or "final").
    /// </summary>
    internal string Status { get; }

    /// <summary>
    /// True if the status indicates the upload is complete ("final").
    /// </summary>
    internal bool IsFinal => string.Equals(Status, ResumableUploadClient.FinalStatusValue, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// The deserialized RPC response payload, present when the upload is final (or null for non-final chunks).
    /// </summary>
    internal TResponse ResponseBody { get; }

    internal UploadChunkResponse(long? committedOffset, string status, TResponse responseBody) =>
        (CommittedOffset, Status, ResponseBody) = (committedOffset, status, responseBody);

    internal static UploadChunkResponse<TResponse> FromHeadersAndPayload(Metadata headers, TResponse responseBody)
    {
        string offsetStr = ResumableUploadClient.GetHeaderValue(headers, ResumableUploadClient.SizeReceivedHeaderName);
        long? committedOffset = long.TryParse(offsetStr, out long parsed) ? parsed : null;
        string status = ResumableUploadClient.GetHeaderValue(headers, ResumableUploadClient.StatusHeaderName);
        return new UploadChunkResponse<TResponse>(committedOffset, status, responseBody);
    }
}
