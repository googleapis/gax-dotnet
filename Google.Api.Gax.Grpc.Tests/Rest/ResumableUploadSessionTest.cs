/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Google.Api.Gax.Testing;
using Grpc.Core;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ResumableUploadSessionTest
{
    private class FakeRequest
    {
        public string Name { get; set; }
    }

    private class FakeResponse
    {
        public string Result { get; set; }
    }

    private static AsyncUnaryCall<TResponse> CreateAsyncUnaryCall<TResponse>(TResponse response) =>
        new AsyncUnaryCall<TResponse>(
            Task.FromResult(response),
            Task.FromResult(new Metadata()),
            () => Status.DefaultSuccess,
            () => new Metadata(),
            () => { });

    [Fact]
    public async Task BeginUploadAsync_SuccessfulUpload()
    {
        bool startCalled = false;
        bool uploadFinalizeCalled = false;
        var clock = SystemClock.Instance;
        var uploadUri = new Uri("http://localhost/upload/session123");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) =>
            {
                startCalled = true;
                return CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active"));
            },
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#uploadFinalize",
            (req, options) =>
            {
                uploadFinalizeCalled = true;
                Assert.Equal(uploadUri, req.Uri);
                Assert.Equal(0, req.UploadChunk.UploadOffset);
                Assert.Equal(5, req.UploadChunk.Count);
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(5, "final", new FakeResponse { Result = "SUCCESS" }));
            },
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var finalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#finalize",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall,
            uploadChunkCall,
            uploadFinalizeCall,
            queryOffsetCall,
            finalizeCall,
            ResumableUploadSettings.Default.WithChunkSize(10),
            clock);

        var session = uploadCall.CreateSession();
        Assert.Null(session.UploadUri);

        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Hello"));
        var result = await session.BeginUploadAsync(new FakeRequest { Name = "test" }, memoryStream);

        Assert.True(startCalled);
        Assert.True(uploadFinalizeCalled);
        Assert.Equal("SUCCESS", result.Result);
        Assert.Equal(uploadUri, session.UploadUri);

        // Subsequent call to BeginUploadAsync or ResumeUploadAsync should throw InvalidOperationException
        await Assert.ThrowsAsync<InvalidOperationException>(() => session.BeginUploadAsync(new FakeRequest(), memoryStream));
        await Assert.ThrowsAsync<InvalidOperationException>(() => session.ResumeUploadAsync(uploadUri, memoryStream));
    }

    [Fact]
    public async Task ResumeUploadAsync_QueriesOffsetAndResumesStream()
    {
        bool queryCalled = false;
        bool uploadFinalizeCalled = false;
        var clock = SystemClock.Instance;
        var resumeUri = new Uri("http://localhost/upload/session456");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#uploadFinalize",
            (req, options) =>
            {
                uploadFinalizeCalled = true;
                Assert.Equal(resumeUri, req.Uri);
                Assert.Equal(5, req.UploadChunk.UploadOffset);
                Assert.Equal(5, req.UploadChunk.Count);
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(10, "final", new FakeResponse { Result = "RESUMED_SUCCESS" }));
            },
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) =>
            {
                queryCalled = true;
                Assert.Equal(resumeUri, req.Uri);
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(5, "active", null));
            },
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var finalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#finalize",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None),
            clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall,
            uploadChunkCall,
            uploadFinalizeCall,
            queryOffsetCall,
            finalizeCall,
            ResumableUploadSettings.Default.WithChunkSize(10),
            clock);

        var session = uploadCall.CreateSession();

        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));
        var result = await session.ResumeUploadAsync(resumeUri, memoryStream);

        Assert.True(queryCalled);
        Assert.True(uploadFinalizeCalled);
        Assert.Equal("RESUMED_SUCCESS", result.Result);
        Assert.Equal(resumeUri, session.UploadUri);
    }

    [Fact]
    public void WithAdjustedChunkSize_CalculatesClosestSmallerMultiple()
    {
        var defaultSettings = ResumableUploadSettings.Default.WithChunkSize(8000000);
        Assert.Equal(7864320, ResumableUploadSession<FakeRequest, FakeResponse>.WithAdjustedChunkSize(defaultSettings, 262144).ChunkSize);

        var alignedSettings = ResumableUploadSettings.Default.WithChunkSize(8388608);
        Assert.Same(alignedSettings, ResumableUploadSession<FakeRequest, FakeResponse>.WithAdjustedChunkSize(alignedSettings, 262144));

        var smallSettings = ResumableUploadSettings.Default.WithChunkSize(100000);
        Assert.Equal(262144, ResumableUploadSession<FakeRequest, FakeResponse>.WithAdjustedChunkSize(smallSettings, 262144).ChunkSize);

        Assert.Same(defaultSettings, ResumableUploadSession<FakeRequest, FakeResponse>.WithAdjustedChunkSize(defaultSettings, null));
        Assert.Same(defaultSettings, ResumableUploadSession<FakeRequest, FakeResponse>.WithAdjustedChunkSize(defaultSettings, 0));
    }

    [Fact]
    public async Task UploadChunks_RecoversOnFailedPreconditionOrMissingStatusHeader()
    {
        int uploadChunkCalls = 0;
        bool queryCalled = false;
        var clock = new FakeClock();
        var uploadUri = new Uri("http://localhost/upload/session123");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active")),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) =>
            {
                uploadChunkCalls++;
                // Verify chunk deadline is trimmed to half of remaining session deadline (10 minutes session -> 5 minutes chunk deadline)
                Assert.NotNull(options.Deadline);
                Assert.Equal(clock.GetCurrentDateTimeUtc().AddMinutes(5), options.Deadline.Value);

                if (uploadChunkCalls == 1)
                {
                    // First call fails with HTTP 412 -> StatusCode.FailedPrecondition
                    throw new RpcException(new Status(StatusCode.FailedPrecondition, "Precondition failed"));
                }
                if (uploadChunkCalls == 2)
                {
                    // Second call succeeds with active status
                    return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(5, "active", null));
                }
                // Third call returns missing status header (null status), triggering another query recovery
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(5, null, null));
            },
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#uploadFinalize",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(10, "final", new FakeResponse { Result = "RECOVERED" })),
            CallSettings.FromExpiration(Expiration.None), clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) =>
            {
                queryCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "active", null));
            },
            CallSettings.FromExpiration(Expiration.None), clock);

        var finalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#finalize",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None), clock);

        var settings = ResumableUploadSettings.Default
            .WithChunkSize(5)
            .WithUploadDeadline(Expiration.FromTimeout(TimeSpan.FromMinutes(10)));

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall, uploadChunkCall, uploadFinalizeCall, queryOffsetCall, finalizeCall, settings, clock);

        var session = uploadCall.CreateSession();
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));
        var result = await session.BeginUploadAsync(new FakeRequest { Name = "test" }, stream);

        Assert.True(queryCalled);
        Assert.Equal("RECOVERED", result.Result);
    }

    [Fact]
    public async Task ResumeUpload_ThrowsWhenCommittedOffsetMissing()
    {
        var clock = new FakeClock();
        var uploadUri = new Uri("http://localhost/upload/session123");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active")),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#uploadFinalize",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None), clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(null, "active", null)),
            CallSettings.FromExpiration(Expiration.None), clock);

        var finalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#finalize",
            (req, options) => throw new InvalidOperationException("Not expected"),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall, uploadChunkCall, uploadFinalizeCall, queryOffsetCall, finalizeCall, ResumableUploadSettings.Default, clock);

        var session = uploadCall.CreateSession();
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => session.ResumeUploadAsync(uploadUri, stream));
        Assert.Equal("Server query response did not contain a committed offset.", ex.Message);
    }

    [Fact]
    public async Task UploadChunks_NotFoundStatusIsUnrecoverable()
    {
        var clock = new FakeClock();
        var uploadUri = new Uri("http://localhost/upload/session123");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active")),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) => throw new RpcException(new Status(StatusCode.NotFound, "Not Found")),
            CallSettings.FromExpiration(Expiration.None), clock);

        var queryCalled = false;
        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) =>
            {
                queryCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "active", null));
            },
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall, uploadChunkCall, uploadChunkCall, queryOffsetCall, uploadChunkCall, ResumableUploadSettings.Default, clock);

        var session = uploadCall.CreateSession();
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));

        var ex = await Assert.ThrowsAsync<RpcException>(() => session.BeginUploadAsync(new FakeRequest(), stream));
        Assert.Equal(StatusCode.NotFound, ex.StatusCode);
        Assert.False(queryCalled);
    }

    [Fact]
    public async Task UploadChunks_StatusHeaderFinalIsUnrecoverable()
    {
        var clock = new FakeClock();
        var uploadUri = new Uri("http://localhost/upload/session123");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active")),
            CallSettings.FromExpiration(Expiration.None), clock);

        var trailers = new Metadata { { "x-goog-upload-status", "final" } };
        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) => throw new RpcException(new Status(StatusCode.InvalidArgument, "Finalized"), trailers),
            CallSettings.FromExpiration(Expiration.None), clock);

        var queryCalled = false;
        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) =>
            {
                queryCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "active", null));
            },
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall, uploadChunkCall, uploadChunkCall, queryOffsetCall, uploadChunkCall, ResumableUploadSettings.Default, clock);

        var session = uploadCall.CreateSession();
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));

        var ex = await Assert.ThrowsAsync<RpcException>(() => session.BeginUploadAsync(new FakeRequest(), stream));
        Assert.Equal(StatusCode.InvalidArgument, ex.StatusCode);
        Assert.False(queryCalled);
    }

    [Fact]
    public async Task UploadChunks_ReportsProgressEvents()
    {
        var clock = new FakeClock();
        var uploadUri = new Uri("http://localhost/upload/session123");
        int granularity = 5;

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active", granularity)),
            CallSettings.FromExpiration(Expiration.None), clock);

        var firstAttempt = true;
        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) =>
            {
                if (firstAttempt)
                {
                    firstAttempt = false;
                    throw new RpcException(new Status(StatusCode.Unavailable, "Transient"));
                }
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(5, "active", null));
            },
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#uploadFinalize",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(10, "final", new FakeResponse { Result = "OK" })),
            CallSettings.FromExpiration(Expiration.None), clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "active", null)),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall, uploadChunkCall, uploadFinalizeCall, queryOffsetCall, uploadFinalizeCall, ResumableUploadSettings.Default, clock);

        var session = uploadCall.CreateSession();
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));

        var progressList = new List<ResumableUploadProgress>();
        var progressMock = new SyncProgress<ResumableUploadProgress>(p => progressList.Add(p));
        var settings = ResumableUploadSettings.Default.WithChunkSize(5).WithProgress(progressMock);

        var result = await session.BeginUploadAsync(new FakeRequest(), stream, uploadSettings: settings);

        Assert.Equal("OK", result.Result);
        Assert.Equal(5, progressList.Count);

        Assert.Equal(ResumableUploadState.Starting, progressList[0].State);
        Assert.Equal(0, progressList[0].CommittedOffset);
        Assert.Equal(uploadUri, progressList[0].UploadUri);
        Assert.Equal(granularity, progressList[0].ChunkGranularity);

        Assert.Equal(ResumableUploadState.Recovering, progressList[1].State);
        Assert.Equal(0, progressList[1].CommittedOffset);

        Assert.Equal(ResumableUploadState.OffsetReceived, progressList[2].State);
        Assert.Equal(0, progressList[2].CommittedOffset);

        Assert.Equal(ResumableUploadState.Uploading, progressList[3].State);
        Assert.Equal(5, progressList[3].CommittedOffset);

        Assert.Equal(ResumableUploadState.Finalized, progressList[4].State);
        Assert.Equal(10, progressList[4].CommittedOffset);
    }

    [Fact]
    public async Task UploadChunks_IsolatesProgressCallbackExceptions()
    {
        var clock = new FakeClock();
        var uploadUri = new Uri("http://localhost/upload/session123");

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(uploadUri, "active")),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#uploadFinalize",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(10, "final", new FakeResponse { Result = "OK" })),
            CallSettings.FromExpiration(Expiration.None), clock);

        var uploadCall = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall, uploadFinalizeCall, uploadFinalizeCall, uploadFinalizeCall, uploadFinalizeCall, ResumableUploadSettings.Default, clock);

        var session = uploadCall.CreateSession();
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes("0123456789"));

        var progressMock = new SyncProgress<ResumableUploadProgress>(p => throw new InvalidOperationException("User Callback Exception"));
        var settings = ResumableUploadSettings.Default.WithProgress(progressMock);

        var result = await session.BeginUploadAsync(new FakeRequest(), stream, uploadSettings: settings);
        Assert.Equal("OK", result.Result);
    }

    private class SyncProgress<T> : IProgress<T>
    {
        private readonly Action<T> _handler;
        public SyncProgress(Action<T> handler) => _handler = handler;
        public void Report(T value) => _handler(value);
    }
}
