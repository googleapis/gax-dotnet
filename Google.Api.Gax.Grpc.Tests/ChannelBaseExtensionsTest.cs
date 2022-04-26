/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests;

public class ChannelBaseExtensionsTest
{
    [Fact]
    public void Shutdown_NonDisposable()
    {
        var logger = new MemoryLogger("shutdown");
        var channel = new CustomChannel(Task.CompletedTask);
        channel.Shutdown(logger);
        Assert.True(channel.ShutdownCalled);
        Assert.Empty(logger.ListLogEntries());
    }

    [Fact]
    public void Shutdown_Disposable()
    {
        var logger = new MemoryLogger("shutdown");
        var channel = new CustomDisposableChannel(Task.CompletedTask);
        channel.Shutdown(logger);
        Assert.True(channel.ShutdownCalled);
        Assert.True(channel.DisposeCalled);
        Assert.Empty(logger.ListLogEntries());
    }

    [Fact]
    public void Shutdown_FaultedTask()
    {
        var logger = new MemoryLogger("shutdown");
        var exception = new Exception("Bang");
        var channel = new CustomDisposableChannel(Task.FromException(exception));
        channel.Shutdown(logger);
        Assert.True(channel.ShutdownCalled);
        Assert.True(channel.DisposeCalled);
        var entry = Assert.Single(logger.ListLogEntries());
        Assert.Contains("failed", entry.Message, StringComparison.OrdinalIgnoreCase);
        var aggregate = Assert.IsType<AggregateException>(entry.Exception);
        Assert.Same(exception, aggregate.InnerExceptions[0]);
    }

    [Fact]
    public void Shutdown_FaultedTask_NoLogger()
    {
        var exception = new Exception("Bang");
        var channel = new CustomDisposableChannel(Task.FromException(exception));
        channel.Shutdown();
        Assert.True(channel.ShutdownCalled);
        Assert.True(channel.DisposeCalled);
    }

    [Fact]
    public void Shutdown_CanceledTask()
    {
        var logger = new MemoryLogger("shutdown");
        var source = new CancellationTokenSource();
        source.Cancel();
        var channel = new CustomDisposableChannel(Task.FromCanceled(source.Token));
        channel.Shutdown(logger);
        Assert.True(channel.ShutdownCalled);
        Assert.True(channel.DisposeCalled);
        var entry = Assert.Single(logger.ListLogEntries());
        Assert.Contains("canceled", entry.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Null(entry.Exception);
    }

    private class CustomChannel : ChannelBase
    {
        internal bool ShutdownCalled { get; private set; }
        internal Task ShutdownTask { get; }

        internal CustomChannel(Task shutdownTask) : base("target")
        {
            ShutdownTask = shutdownTask;
        }

        public override CallInvoker CreateCallInvoker() =>
            throw new NotImplementedException();

        protected override Task ShutdownAsyncCore()
        {
            ShutdownCalled = true;
            return ShutdownTask;
        }
    }

    private class CustomDisposableChannel : CustomChannel, IDisposable
    {
        internal bool DisposeCalled { get; private set; }

        internal CustomDisposableChannel(Task shutdownTask) : base(shutdownTask)
        {
        }

        public void Dispose() => DisposeCalled = true;
    }
}
