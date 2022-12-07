/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class RpcCancellationContextTest
{
    private const string SampleData = "sample data";

    [Fact]
    public async Task ResultReturningTask_NotCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        var result = await context.RunAsync(ReturnSampleData);
        Assert.Equal(SampleData, result);
    }

    [Fact]
    public async Task ResultReturningTask_DeadlineCtsCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        deadlineCts.Cancel();
        var exception = await Assert.ThrowsAsync<RpcException>(() => context.RunAsync(ReturnSampleData));
        Assert.Equal(StatusCode.DeadlineExceeded, exception.StatusCode);
    }

    [Fact]
    public async Task ResultReturningTask_CallOptionsCtsCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        callOptionsCts.Cancel();
        var exception = await Assert.ThrowsAsync<RpcException>(() => context.RunAsync(ReturnSampleData));
        Assert.Equal(StatusCode.Cancelled, exception.StatusCode);
    }

    [Fact]
    public async Task ResultReturningTask_ContextCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Cancel();
        var exception = await Assert.ThrowsAsync<RpcException>(() => context.RunAsync(ReturnSampleData));
        Assert.Equal(StatusCode.Cancelled, exception.StatusCode);
    }

    [Fact]
    public async Task ResultReturningTask_InvalidatedByDisposal()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Dispose();
        await Assert.ThrowsAsync<ObjectDisposedException>(() => context.RunAsync(ReturnSampleData));
    }

    [Fact]
    public async Task ResultReturningTask_NoDeadlineCts()
    {
        var callOptionsCts = new CancellationTokenSource();
        CancellationTokenSource deadlineCts = null;
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        var result = await context.RunAsync(ReturnSampleData);
        Assert.Equal(SampleData, result);
    }

    [Fact]
    public async Task VoidTask_NotCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        await context.RunAsync(ReturnNothing);
    }

    [Fact]
    public async Task VoidTask_DeadlineCtsCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        deadlineCts.Cancel();
        var exception = await Assert.ThrowsAsync<RpcException>(() => context.RunAsync(ReturnNothing));
        Assert.Equal(StatusCode.DeadlineExceeded, exception.StatusCode);
    }

    [Fact]
    public async Task VoidTask_CallOptionsCtsCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        callOptionsCts.Cancel();
        var exception = await Assert.ThrowsAsync<RpcException>(() => context.RunAsync(ReturnNothing));
        Assert.Equal(StatusCode.Cancelled, exception.StatusCode);
    }

    [Fact]
    public async Task VoidTask_ContextCancelled()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Cancel();
        var exception = await Assert.ThrowsAsync<RpcException>(() => context.RunAsync(ReturnNothing));
        Assert.Equal(StatusCode.Cancelled, exception.StatusCode);
    }

    [Fact]
    public async Task VoidReturningTask_NoDeadlineCts()
    {
        var callOptionsCts = new CancellationTokenSource();
        CancellationTokenSource deadlineCts = null;
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        await context.RunAsync(ReturnNothing);
    }

    [Fact]
    public void Dispose_DisposesOfDeadlineCts()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Dispose();
        Assert.Throws<ObjectDisposedException>(deadlineCts.Cancel);
    }

    [Fact]
    public void Cancel_AfterDisposeSucceeds()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Dispose();
        context.Cancel();
    }

    [Fact]
    public void Cancel_AfterCancelSucceeds()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Cancel();
        context.Cancel();
    }

    [Fact]
    public async Task VoidTask_InvalidatedByDisposal()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Dispose();
        await Assert.ThrowsAsync<ObjectDisposedException>(() => context.RunAsync(ReturnNothing));
    }

    [Fact]
    public void Dispose_NoDeadlineCts()
    {
        var callOptionsCts = new CancellationTokenSource();
        CancellationTokenSource deadlineCts = null;
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Dispose();
    }

    [Fact]
    public void Dispose_AfterDisposeSucceeds()
    {
        var callOptionsCts = new CancellationTokenSource();
        var deadlineCts = new CancellationTokenSource();
        var context = RpcCancellationContext.ForTesting("rpc", deadlineCts, callOptionsCts.Token);
        context.Dispose();
        context.Dispose();
        context.Dispose();
        context.Dispose();
    }

    private static async Task<string> ReturnSampleData(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.Yield();
        return SampleData;
    }

    private static async Task ReturnNothing(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.Yield();
    }
}
