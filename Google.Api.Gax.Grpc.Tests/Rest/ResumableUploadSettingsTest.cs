/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ResumableUploadSettingsTest
{
    [Fact]
    public void Default_HasExpectedDefaults()
    {
        var settings = ResumableUploadSettings.Default;
        Assert.NotNull(settings);
        Assert.Equal(ResumableUploadSettings.DefaultChunkSize, settings.ChunkSize);
        Assert.Equal(8 * 1024 * 1024, settings.ChunkSize);
        Assert.Same(ResumableUploadSettings.DefaultUploadDeadline, settings.UploadDeadline);
        Assert.Equal(TimeSpan.FromMinutes(15), settings.UploadDeadline.Timeout);
    }

    [Theory]
    [InlineData(1L)]
    [InlineData(1000L)]
    [InlineData(256 * 1024L)]
    [InlineData(8 * 1024 * 1024L)]
    public void WithChunkSize_ValidChunkSize_Accepted(long chunkSize)
    {
        var settings = ResumableUploadSettings.Default.WithChunkSize(chunkSize);
        Assert.Equal(chunkSize, settings.ChunkSize);
    }

    [Theory]
    [InlineData(0L)]
    [InlineData(-1L)]
    [InlineData(-256 * 1024L)]
    public void WithChunkSize_InvalidChunkSize_ThrowsArgumentOutOfRangeException(long chunkSize)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ResumableUploadSettings.Default.WithChunkSize(chunkSize));
    }

    [Fact]
    public void WithChunkSize_ReturnsNewInstanceWithUpdatedChunkSize()
    {
        var settings = ResumableUploadSettings.Default;
        var custom = settings.WithChunkSize(10000);

        Assert.NotSame(settings, custom);
        Assert.Equal(8 * 1024 * 1024, settings.ChunkSize);
        Assert.Equal(10000, custom.ChunkSize);
        Assert.Same(settings.UploadDeadline, custom.UploadDeadline);
    }

    [Fact]
    public void WithUploadDeadline_ReturnsNewInstanceWithUpdatedDeadline()
    {
        var settings = ResumableUploadSettings.Default;
        var newDeadline = Expiration.FromTimeout(TimeSpan.FromHours(1));
        var custom = settings.WithUploadDeadline(newDeadline);

        Assert.NotSame(settings, custom);
        Assert.Same(newDeadline, custom.UploadDeadline);
        Assert.Equal(settings.ChunkSize, custom.ChunkSize);
    }

    [Fact]
    public void WithUploadDeadline_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ResumableUploadSettings.Default.WithUploadDeadline(null));
    }
}
