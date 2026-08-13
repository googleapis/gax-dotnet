/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Grpc.Core;
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

    [Fact]
    public void StaticInternalProperties_HaveExpectedValues()
    {
        Assert.NotNull(ResumableUploadSettings.TransientErrorCodes);
        Assert.Equal(4, ResumableUploadSettings.TransientErrorCodes.Count);
        Assert.Contains(StatusCode.Unavailable, ResumableUploadSettings.TransientErrorCodes);
        Assert.Contains(StatusCode.DeadlineExceeded, ResumableUploadSettings.TransientErrorCodes);
        Assert.Contains(StatusCode.ResourceExhausted, ResumableUploadSettings.TransientErrorCodes);
        Assert.Contains(StatusCode.Internal, ResumableUploadSettings.TransientErrorCodes);

        Assert.NotNull(ResumableUploadSettings.ControlOperationDeadline);
        Assert.Equal(TimeSpan.FromMinutes(1), ResumableUploadSettings.ControlOperationDeadline.Timeout);

        Assert.NotNull(ResumableUploadSettings.DefaultRetry);
        Assert.Equal(int.MaxValue, ResumableUploadSettings.DefaultRetry.MaxAttempts);
        Assert.Equal(TimeSpan.FromSeconds(1), ResumableUploadSettings.DefaultRetry.InitialBackoff);
        Assert.Equal(TimeSpan.FromSeconds(60), ResumableUploadSettings.DefaultRetry.MaxBackoff);
        Assert.Equal(2.0, ResumableUploadSettings.DefaultRetry.BackoffMultiplier);
        Assert.NotNull(ResumableUploadSettings.DefaultRetry.RetryFilter);
        Assert.NotNull(ResumableUploadSettings.DefaultRetry.BackoffJitter);
    }

    [Fact]
    public void ToControlCallSettings_ReturnsExpectedCallSettings()
    {
        var settings = ResumableUploadSettings.Default;
        var controlCallSettings = settings.ToControlCallSettings();

        Assert.NotNull(controlCallSettings);
        Assert.Same(ResumableUploadSettings.ControlOperationDeadline, controlCallSettings.Expiration);
        Assert.Same(ResumableUploadSettings.DefaultRetry, controlCallSettings.Retry);
    }

    [Fact]
    public void ToDataCallSettings_ReturnsExpectedCallSettings()
    {
        var settings = ResumableUploadSettings.Default;
        var dataCallSettings = settings.ToDataCallSettings();

        Assert.NotNull(dataCallSettings);
        Assert.NotNull(dataCallSettings.Expiration);
        Assert.Equal(ExpirationType.Timeout, dataCallSettings.Expiration.Type);
        Assert.Equal(TimeSpan.FromMinutes(7.5), dataCallSettings.Expiration.Timeout);
        Assert.Same(ResumableUploadSettings.DefaultRetry, dataCallSettings.Retry);

        var customSettings = settings.WithUploadDeadline(Expiration.FromTimeout(TimeSpan.FromMinutes(20)));
        var customDataCallSettings = customSettings.ToDataCallSettings();
        Assert.Equal(ExpirationType.Timeout, customDataCallSettings.Expiration.Type);
        Assert.Equal(TimeSpan.FromMinutes(10), customDataCallSettings.Expiration.Timeout);
        Assert.Same(ResumableUploadSettings.DefaultRetry, customDataCallSettings.Retry);

        var deadlineSettings = settings.WithUploadDeadline(Expiration.FromDeadline(DateTime.UtcNow.AddMinutes(10)));
        var deadlineDataCallSettings = deadlineSettings.ToDataCallSettings();
        Assert.NotNull(deadlineDataCallSettings.Expiration);
        Assert.Equal(ExpirationType.Deadline, deadlineDataCallSettings.Expiration.Type);
        Assert.Same(deadlineSettings.UploadDeadline, deadlineDataCallSettings.Expiration);

        var noneSettings = settings.WithUploadDeadline(Expiration.None);
        var noneDataCallSettings = noneSettings.ToDataCallSettings();
        Assert.NotNull(noneDataCallSettings.Expiration);
        Assert.Equal(ExpirationType.None, noneDataCallSettings.Expiration.Type);
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
