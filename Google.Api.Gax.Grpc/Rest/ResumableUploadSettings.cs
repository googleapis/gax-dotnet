/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using Grpc.Core;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Settings for controlling resumable upload execution.
/// Instances of this class are immutable.
/// </summary>
public sealed class ResumableUploadSettings
{
    /// <summary>
    /// Default chunk size in bytes (8 MiB).
    /// </summary>
    public const long DefaultChunkSize = 8 * 1024 * 1024;

    /// <summary>
    /// Default upload deadline for a resumable upload session (15 minutes).
    /// </summary>
    public static Expiration DefaultUploadDeadline { get; } = Expiration.FromTimeout(TimeSpan.FromMinutes(15));

    /// <summary>
    /// Gets the default deadline for control operations (1 minute).
    /// </summary>
    internal static Expiration ControlOperationDeadline { get; } = Expiration.FromTimeout(TimeSpan.FromMinutes(1));

    /// <summary>
    /// Gets the list of gRPC status codes considered transient (Category 1) errors.
    /// Includes mappings for HTTP status codes 408 (DeadlineExceeded), 429 (ResourceExhausted),
    /// 500/502 (Internal), 503 (Unavailable), and 504 (DeadlineExceeded).
    /// </summary>
    internal static IReadOnlyList<StatusCode> TransientErrorCodes { get; } = new[]
    {
        StatusCode.Unavailable,
        StatusCode.DeadlineExceeded,
        StatusCode.ResourceExhausted,
        StatusCode.Internal
    };

    /// <summary>
    /// Gets the default retry configuration with exponential backoff for transient resumable upload errors.
    /// Initial backoff: 1s, multiplier: 2.0, max backoff: 60s, max attempts: int.MaxValue (bounded by deadline).
    /// </summary>
    internal static RetrySettings DefaultRetry { get; } = RetrySettings.FromExponentialBackoff(
        maxAttempts: int.MaxValue,
        initialBackoff: TimeSpan.FromSeconds(1),
        maxBackoff: TimeSpan.FromSeconds(60),
        backoffMultiplier: 2.0,
        retryFilter: RetrySettings.FilterForStatusCodes(TransientErrorCodes));

    /// <summary>
    /// Gets the default settings instance with <see cref="DefaultChunkSize"/> (8 MiB) and <see cref="DefaultUploadDeadline"/> (15 minutes).
    /// </summary>
    public static ResumableUploadSettings Default { get; } = new ResumableUploadSettings(DefaultChunkSize, DefaultUploadDeadline);

    /// <summary>
    /// Gets the chunk size in bytes. Defaults to <see cref="DefaultChunkSize"/> (8 MiB).
    /// </summary>
    public long ChunkSize { get; }

    /// <summary>
    /// Gets the upload deadline for the entire resumable upload session. This is never null.
    /// Defaults to <see cref="DefaultUploadDeadline"/> (15 minutes).
    /// </summary>
    public Expiration UploadDeadline { get; }

    private ResumableUploadSettings(long chunkSize, Expiration uploadDeadline)
    {
        ChunkSize = GaxPreconditions.CheckArgumentRange(chunkSize, nameof(chunkSize), minInclusive: 1L, maxInclusive: long.MaxValue);
        UploadDeadline = GaxPreconditions.CheckNotNull(uploadDeadline, nameof(uploadDeadline));
    }

    /// <summary>
    /// Returns a new instance of <see cref="ResumableUploadSettings"/> with the specified <see cref="ChunkSize"/>.
    /// </summary>
    /// <param name="chunkSize">The new chunk size in bytes. Must be greater than zero.</param>
    /// <returns>A new <see cref="ResumableUploadSettings"/> instance with the updated chunk size.</returns>
    public ResumableUploadSettings WithChunkSize(long chunkSize) =>
        new ResumableUploadSettings(chunkSize, UploadDeadline);

    /// <summary>
    /// Returns a new instance of <see cref="ResumableUploadSettings"/> with the specified <see cref="UploadDeadline"/>.
    /// </summary>
    /// <param name="uploadDeadline">The new upload deadline. Must not be null.</param>
    /// <returns>A new <see cref="ResumableUploadSettings"/> instance with the updated upload deadline.</returns>
    public ResumableUploadSettings WithUploadDeadline(Expiration uploadDeadline) =>
        new ResumableUploadSettings(ChunkSize, uploadDeadline);

    /// <summary>
    /// Creates a <see cref="CallSettings"/> for control operations (start, query, cancel) using <see cref="ControlOperationDeadline"/> and <see cref="DefaultRetry"/>.
    /// </summary>
    internal CallSettings ToControlCallSettings() =>
        CallSettings.FromExpiration(ControlOperationDeadline).WithRetry(DefaultRetry);

    /// <summary>
    /// Creates a <see cref="CallSettings"/> for data operations (upload chunk) using half of <see cref="UploadDeadline"/> and <see cref="DefaultRetry"/>.
    /// </summary>
    internal CallSettings ToDataCallSettings()
    {
        Expiration dataExpiration = UploadDeadline.Type switch
        {
            ExpirationType.Timeout => Expiration.FromTimeout(TimeSpan.FromTicks(UploadDeadline.Timeout.Value.Ticks / 2)),
            ExpirationType.Deadline => UploadDeadline,
            _ => Expiration.None
        };
        return CallSettings.FromExpiration(dataExpiration).WithRetry(DefaultRetry);
    }
}
