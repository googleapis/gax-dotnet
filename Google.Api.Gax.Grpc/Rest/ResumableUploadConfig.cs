/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Configuration settings for a resumable upload operation. This type is immutable.
/// </summary>
public sealed class ResumableUploadConfig
{
    /// <summary>
    /// Default chunk size in bytes (10 MiB).
    /// </summary>
    public const int DefaultChunkSize = 10 * 1024 * 1024;

    /// <summary>
    /// Minimum allowed chunk size in bytes (256 KiB).
    /// </summary>
    public const int MinimumChunkSize = 256 * 1024;

    /// <summary>
    /// Gets the default configuration instance.
    /// </summary>
    public static ResumableUploadConfig Default { get; } = new ResumableUploadConfig(DefaultChunkSize);

    /// <summary>
    /// Gets the chunk size in bytes to use for each upload request.
    /// Defaults to <see cref="DefaultChunkSize"/>.
    /// </summary>
    public int ChunkSize { get; }

    private ResumableUploadConfig(int chunkSize)
    {
        ChunkSize = GaxPreconditions.CheckArgumentRange(chunkSize, nameof(chunkSize), MinimumChunkSize, int.MaxValue);
    }

    /// <summary>
    /// Returns a new instance of <see cref="ResumableUploadConfig"/> with the specified chunk size.
    /// </summary>
    /// <param name="chunkSize">The chunk size in bytes. Must be at least <see cref="MinimumChunkSize"/>.</param>
    /// <returns>A new configuration instance with the updated chunk size.</returns>
    public ResumableUploadConfig WithChunkSize(int chunkSize) =>
        chunkSize == ChunkSize ? this : new ResumableUploadConfig(chunkSize);
}
