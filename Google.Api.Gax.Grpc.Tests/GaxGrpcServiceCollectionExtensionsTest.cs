/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests;

// Although we can create the adapter on .NET Framework, we can't really test the option propagation.
#if NETCOREAPP3_1_OR_GREATER
public class GaxGrpcServiceCollectionExtensionsTest
{
    [Fact]
    public void AddGrpcNetClientAdapter_NullAction()
    {
        var loggerProvider = new MemoryLoggerProvider();
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddProvider(loggerProvider).SetMinimumLevel(LogLevel.Debug))
            .AddGrpcNetClientAdapter(null)
            .BuildServiceProvider();
        CreateAdapterAndChannelThenAssertLog(serviceProvider, loggerProvider);
    }

    [Fact]
    public void AddGrpcNetClientAdapter_WithAction()
    {
        var loggerProvider = new MemoryLoggerProvider();
        bool actionCalled = false;
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddProvider(loggerProvider).SetMinimumLevel(LogLevel.Debug))
            .AddGrpcNetClientAdapter((provider, options) => actionCalled = true)
            .BuildServiceProvider();

        Assert.False(actionCalled);
        CreateAdapterAndChannelThenAssertLog(serviceProvider, loggerProvider);
        Assert.True(actionCalled);
    }

    [Fact]
    public void AddGrpcNetClientAdapter_NoAction()
    {
        var loggerProvider = new MemoryLoggerProvider();
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddProvider(loggerProvider).SetMinimumLevel(LogLevel.Debug))
            .AddGrpcNetClientAdapter()
            .BuildServiceProvider();
        CreateAdapterAndChannelThenAssertLog(serviceProvider, loggerProvider);
    }

    private void CreateAdapterAndChannelThenAssertLog(IServiceProvider serviceProvider, MemoryLoggerProvider loggerProvider)
    {
        // A URI with a path in triggers a diagnostic log entry when constructing a channel.
        string testUri = "http://ignored.com/withpath";

        var adapter = serviceProvider.GetRequiredService<GrpcAdapter>();
        Assert.IsType<GrpcNetClientAdapter>(adapter);

        adapter.CreateChannel(TestServiceMetadata.TestService, testUri, ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
        var logEntries = loggerProvider.GetLogEntries("Grpc.Net.Client.GrpcChannel");
        var logEntry = Assert.Single(logEntries);
        Assert.Contains(testUri, logEntry.Message);
    }
}
#endif