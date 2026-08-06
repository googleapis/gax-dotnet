/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ResumableUploadConfigTest
{
    [Fact]
    public void DefaultValues()
    {
        var config = ResumableUploadConfig.Default;

        Assert.Equal(10 * 1024 * 1024, ResumableUploadConfig.DefaultChunkSize);
        Assert.Equal(256 * 1024, ResumableUploadConfig.MinimumChunkSize);
        Assert.Equal(ResumableUploadConfig.DefaultChunkSize, config.ChunkSize);
    }

    [Fact]
    public void WithChunkSize_ValidValue_CreatesNewInstance()
    {
        var original = ResumableUploadConfig.Default;
        var modified = original.WithChunkSize(ResumableUploadConfig.MinimumChunkSize);

        Assert.NotSame(original, modified);
        Assert.Equal(ResumableUploadConfig.DefaultChunkSize, original.ChunkSize);
        Assert.Equal(ResumableUploadConfig.MinimumChunkSize, modified.ChunkSize);
    }

    [Fact]
    public void WithChunkSize_SameValue_ReturnsSameInstance()
    {
        var original = ResumableUploadConfig.Default;
        var modified = original.WithChunkSize(original.ChunkSize);

        Assert.Same(original, modified);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(256 * 1024 - 1)]
    public void WithChunkSize_InvalidValue_ThrowsArgumentOutOfRangeException(int chunkSize)
    {
        var config = ResumableUploadConfig.Default;
        Assert.Throws<ArgumentOutOfRangeException>(() => config.WithChunkSize(chunkSize));
    }
}
