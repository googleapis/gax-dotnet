/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// States of a resumable upload session reported via progress notifications.
/// </summary>
public enum ResumableUploadState
{
    /// <summary>
    /// Upload session has been initiated with the server (after successful #start).
    /// </summary>
    Starting,

    /// <summary>
    /// A chunk of data has been successfully uploaded to the server.
    /// </summary>
    Uploading,

    /// <summary>
    /// A recoverable error occurred and session status recovery is starting.
    /// </summary>
    Recovering,

    /// <summary>
    /// The committed byte offset was successfully recovered from the server via #query.
    /// </summary>
    OffsetReceived,

    /// <summary>
    /// The upload session has completed and finalized successfully.
    /// </summary>
    Finalized
}

/// <summary>
/// Immutable snapshot representing the progress and state of a resumable upload session.
/// </summary>
public sealed class ResumableUploadProgress
{
    /// <summary>
    /// The current state of the upload session.
    /// </summary>
    public ResumableUploadState State { get; }

    /// <summary>
    /// The total amount of data (in bytes) confirmed as uploaded by the server.
    /// </summary>
    public long CommittedOffset { get; }

    /// <summary>
    /// The upload URI for the active session.
    /// </summary>
    public Uri UploadUri { get; }

    /// <summary>
    /// The chunk granularity (in bytes) requested or supported by the server, if known.
    /// </summary>
    public long? ChunkGranularity { get; }

    internal ResumableUploadProgress(
        ResumableUploadState state,
        long committedOffset,
        Uri uploadUri,
        long? chunkGranularity)
    {
        State = state;
        CommittedOffset = committedOffset;
        UploadUri = uploadUri;
        ChunkGranularity = chunkGranularity;
    }
}
