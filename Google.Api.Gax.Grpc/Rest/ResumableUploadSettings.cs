/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

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
}
