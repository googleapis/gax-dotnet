/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ResumableUploadTranscoderTest
{
    private static readonly ITranscoder s_transcoder = ResumableUploadTranscoder.Instance;

    [Fact]
    public void Transcode_InvalidMessageType_ThrowsArgumentException()
    {
        IMessage invalidMessage = new SimpleRequest();
        Assert.Throws<ArgumentException>(() => s_transcoder.Transcode(invalidMessage));
    }

    [Fact]
    public void Transcode_NullRequest_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => s_transcoder.Transcode(null));
    }

    [Fact]
    public async Task Transcode_WithChunk_BuildsHttpRequestMessageWithContent()
    {
        var uploadUri = new Uri("https://storage.googleapis.com/upload/session123");
        byte[] buffer = new byte[] { 10, 20, 30, 40, 50 };
        var chunk = new ResumableUploadChunk(buffer, offset: 1, count: 3);
        var request = new ResumableUploadRequest(uploadUri, chunk);

        ITranscodingOutput output = s_transcoder.Transcode(request);
        Assert.NotNull(output);

        var httpRequest = output.ToHttpRequestMessage(host: null);
        Assert.Equal(HttpMethod.Post, httpRequest.Method);
        Assert.Equal(uploadUri, httpRequest.RequestUri);

        Assert.NotNull(httpRequest.Content);
        byte[] contentBytes = await httpRequest.Content.ReadAsByteArrayAsync();
        Assert.Equal(new byte[] { 20, 30, 40 }, contentBytes);
    }

    [Fact]
    public void Transcode_WithoutChunk_BuildsHttpRequestMessageWithNullContent()
    {
        var uploadUri = new Uri("https://storage.googleapis.com/upload/session123");
        var request = new ResumableUploadRequest(uploadUri, uploadChunk: null);

        ITranscodingOutput output = s_transcoder.Transcode(request);
        Assert.NotNull(output);

        var httpRequest = output.ToHttpRequestMessage(host: null);
        Assert.Equal(HttpMethod.Post, httpRequest.Method);
        Assert.Equal(uploadUri, httpRequest.RequestUri);
        Assert.Null(httpRequest.Content);
    }

    [Fact]
    public void SyntheticMessage_UnusedIMessageMembers_ThrowNotImplementedException()
    {
        var uploadUri = new Uri("https://storage.googleapis.com/upload/session123");
        IMessage message = new ResumableUploadRequest(uploadUri);

        Assert.Throws<NotImplementedException>(() => message.Descriptor);
        Assert.Throws<NotImplementedException>(() => message.WriteTo(null));
        Assert.Throws<NotImplementedException>(() => message.CalculateSize());
        Assert.Throws<NotImplementedException>(() => message.MergeFrom(null));
    }
}
