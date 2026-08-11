/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System;
using System.Net.Http;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Transcoder for resumable upload operations (upload chunk, query offset, cancel).
/// </summary>
internal sealed class ResumableUploadTranscoder : ITranscoder
{
    internal static ResumableUploadTranscoder Instance { get; } = new ResumableUploadTranscoder();

    private ResumableUploadTranscoder() { }

    ITranscodingOutput ITranscoder.Transcode(IMessage request)
    {
        GaxPreconditions.CheckNotNull(request, nameof(request));
        if (request is not ResumableUploadRequest resumableRequest)
        {
            throw new ArgumentException($"Expected request of type {nameof(ResumableUploadRequest)} but got {request.GetType().FullName}", nameof(request));
        }

        return new ResumableUploadTranscodingOutput(resumableRequest);
    }
}

/// <summary>
/// Transcoding output for resumable upload requests.
/// Constructs an <see cref="HttpRequestMessage"/> with the target URI and chunk payload (if present).
/// </summary>
internal sealed class ResumableUploadTranscodingOutput : ITranscodingOutput
{
    private readonly ResumableUploadRequest _request;

    internal ResumableUploadTranscodingOutput(ResumableUploadRequest request)
    {
        _request = GaxPreconditions.CheckNotNull(request, nameof(request));
    }

    HttpRequestMessage ITranscodingOutput.ToHttpRequestMessage(string _)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, _request.Uri);
        if (_request.UploadChunk is not null)
        {
            httpRequest.Content = new ByteArrayContent(_request.UploadChunk.Buffer, (int) _request.UploadChunk.BufferOffset, _request.UploadChunk.Count);
        }

        return httpRequest;
    }
}
