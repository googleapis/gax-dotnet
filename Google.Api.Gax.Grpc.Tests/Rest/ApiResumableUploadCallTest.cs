/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ApiResumableUploadCallTest
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
    public async Task AllFiveCommands_ExecutedCorrectly()
    {
        bool startCalled = false;
        bool uploadChunkCalled = false;
        bool uploadFinalizeCalled = false;
        bool queryOffsetCalled = false;
        bool finalizeCalled = false;

        var clock = SystemClock.Instance;

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) =>
            {
                startCalled = true;
                return CreateAsyncUnaryCall(new StartUploadResponse(new Uri("https://example.com/upload"), "active"));
            },
            CallSettings.FromHeader("start-header", "1"),
            clock);

        var uploadChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) =>
            {
                uploadChunkCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(100, "active", responseBody: null));
            },
            CallSettings.FromHeader("chunk-header", "1"),
            clock);

        var uploadFinalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload,finalize",
            (req, options) =>
            {
                uploadFinalizeCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(200, "final", responseBody: new FakeResponse { Result = "done" }));
            },
            CallSettings.FromHeader("finalize-header", "1"),
            clock);

        var queryOffsetCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) =>
            {
                queryOffsetCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(50, "active", responseBody: null));
            },
            CallSettings.FromHeader("query-header", "1"),
            clock);

        var finalizeCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#finalize",
            (req, options) =>
            {
                finalizeCalled = true;
                return CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(200, "final", responseBody: new FakeResponse { Result = "finalized" }));
            },
            CallSettings.FromHeader("final-header", "1"),
            clock);

        var call = new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall,
            uploadChunkCall,
            uploadFinalizeCall,
            queryOffsetCall,
            finalizeCall,
            ResumableUploadSettings.Default,
            clock);

        Assert.Same(clock, call.Clock);

        var startResp = await call.StartAsync(new FakeRequest { Name = "test" });
        Assert.True(startCalled);
        Assert.Equal("https://example.com/upload", startResp.UploadUri.AbsoluteUri);

        var chunkReq = new ResumableUploadRequest(
            new Uri("https://example.com/upload"),
            new ResumableUploadChunk(new byte[100], 0, 100, uploadOffset: 0));

        var chunkResp = await call.UploadChunkAsync(chunkReq);
        Assert.True(uploadChunkCalled);
        Assert.Equal(100, chunkResp.CommittedOffset);

        var finalizeChunkResp = await call.UploadFinalizeAsync(chunkReq);
        Assert.True(uploadFinalizeCalled);
        Assert.True(finalizeChunkResp.IsFinal);
        Assert.Equal("done", finalizeChunkResp.ResponseBody.Result);

        var queryReq = new ResumableUploadRequest(new Uri("https://example.com/upload"), null);
        var queryResp = await call.QueryOffsetAsync(queryReq);
        Assert.True(queryOffsetCalled);
        Assert.Equal(50, queryResp.CommittedOffset);

        var finalReq = new ResumableUploadRequest(new Uri("https://example.com/upload"), null);
        var finalResp = await call.FinalizeAsync(finalReq);
        Assert.True(finalizeCalled);
        Assert.Equal("finalized", finalResp.ResponseBody.Result);
    }

    [Fact]
    public void WithMergedBaseCallSettings_AppliesToStartCallOnly()
    {
        var call = CreateDummyCall();
        var extraCallSettings = CallSettings.FromHeader("extra", "value");

        var updatedCall = call.WithMergedBaseCallSettings(extraCallSettings);

        Assert.NotSame(call, updatedCall);
        Assert.NotSame(call.StartCall, updatedCall.StartCall);
        Assert.Same(call.UploadChunkCall, updatedCall.UploadChunkCall);
        Assert.Same(call.UploadFinalizeCall, updatedCall.UploadFinalizeCall);
        Assert.Same(call.QueryOffsetCall, updatedCall.QueryOffsetCall);
        Assert.Same(call.FinalizeCall, updatedCall.FinalizeCall);
        Assert.Same(call.Clock, updatedCall.Clock);
    }

    [Fact]
    public void WithGoogleRequestParam_AppliesToStartCallOnly()
    {
        var call = CreateDummyCall();
        var updatedCall = call.WithGoogleRequestParam("name", req => req.Name);

        Assert.NotSame(call, updatedCall);
        Assert.NotSame(call.StartCall, updatedCall.StartCall);
        Assert.Same(call.UploadChunkCall, updatedCall.UploadChunkCall);
        Assert.Same(call.UploadFinalizeCall, updatedCall.UploadFinalizeCall);
        Assert.Same(call.QueryOffsetCall, updatedCall.QueryOffsetCall);
        Assert.Same(call.FinalizeCall, updatedCall.FinalizeCall);
        Assert.Same(call.Clock, updatedCall.Clock);
    }

    [Fact]
    public void WithRetry_AppliesToAllSubCalls()
    {
        var call = CreateDummyCall();
        var updatedCall = call.WithRetry(SystemClock.Instance, new FakeScheduler(), null);

        Assert.NotSame(call, updatedCall);
        Assert.NotSame(call.StartCall, updatedCall.StartCall);
        Assert.NotSame(call.UploadChunkCall, updatedCall.UploadChunkCall);
        Assert.NotSame(call.UploadFinalizeCall, updatedCall.UploadFinalizeCall);
        Assert.NotSame(call.QueryOffsetCall, updatedCall.QueryOffsetCall);
        Assert.NotSame(call.FinalizeCall, updatedCall.FinalizeCall);
        Assert.Same(call.Clock, updatedCall.Clock);
    }

    private ApiResumableUploadCall<FakeRequest, FakeResponse> CreateDummyCall()
    {
        var clock = SystemClock.Instance;

        var startCall = ApiCall.Create<FakeRequest, StartUploadResponse>(
            "test#start",
            (req, options) => CreateAsyncUnaryCall(new StartUploadResponse(new Uri("https://example.com/upload"), "active")),
            CallSettings.FromHeader("base", "1"),
            clock);

        var chunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "active", null)),
            CallSettings.FromHeader("base", "1"),
            clock);

        var finalizeChunkCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#upload,finalize",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "final", null)),
            CallSettings.FromHeader("base", "1"),
            clock);

        var queryCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#query",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "active", null)),
            CallSettings.FromHeader("base", "1"),
            clock);

        var finalCall = ApiCall.Create<ResumableUploadRequest, UploadChunkResponse<FakeResponse>>(
            "test#finalize",
            (req, options) => CreateAsyncUnaryCall(new UploadChunkResponse<FakeResponse>(0, "final", null)),
            CallSettings.FromHeader("base", "1"),
            clock);

        return new ApiResumableUploadCall<FakeRequest, FakeResponse>(
            startCall,
            chunkCall,
            finalizeChunkCall,
            queryCall,
            finalCall,
            ResumableUploadSettings.Default,
            clock);
    }
}
