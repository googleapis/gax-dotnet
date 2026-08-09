/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Represents a chunk of data to be uploaded in a resumable upload request.
/// </summary>
internal sealed class ResumableUploadChunk
{
    /// <summary>
    /// The byte buffer containing the chunk data.
    /// </summary>
    internal byte[] Buffer { get; }

    /// <summary>
    /// The offset in <see cref="Buffer"/> where the chunk data begins.
    /// </summary>
    internal long Offset { get; }

    /// <summary>
    /// The number of bytes in the chunk.
    /// </summary>
    internal int Count { get; }

    internal ResumableUploadChunk(byte[] buffer, long offset, int count)
    {
        Buffer = GaxPreconditions.CheckNotNull(buffer, nameof(buffer));
        Offset = offset;
        Count = count;
    }
}

/// <summary>
/// Synthetic request message used for resumable upload operations (upload chunk, query offset, cancel).
/// </summary>
internal sealed class ResumableUploadRequest : IMessage
{
    /// <summary>
    /// The upload URI for the request.
    /// </summary>
    internal Uri Uri { get; }

    /// <summary>
    /// The chunk of data to upload, or null if no chunk is attached (e.g. query offset or cancel).
    /// </summary>
    internal ResumableUploadChunk UploadChunk { get; }

    internal ResumableUploadRequest(Uri uri, ResumableUploadChunk uploadChunk = null)
    {
        Uri = GaxPreconditions.CheckNotNull(uri, nameof(uri));
        UploadChunk = uploadChunk;
    }

    MessageDescriptor IMessage.Descriptor => throw new NotImplementedException();
    void IMessage.WriteTo(CodedOutputStream output) => throw new NotImplementedException();
    int IMessage.CalculateSize() => throw new NotImplementedException();
    void IMessage.MergeFrom(CodedInputStream input) => throw new NotImplementedException();
}
