/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc;

/// <summary>
/// Extension methods for <see cref="ChannelBase"/>.
/// </summary>
public static class ChannelBaseExtensions
{
    /// <summary>
    /// Shuts down a channel semi-synchronously. This method initially calls <see cref="IDisposable.Dispose"/>
    /// if the channel implements <see cref="IDisposable"/> (e.g. in the case of <see cref="GrpcChannel"/>)
    /// and then calls <see cref="ChannelBase.ShutdownAsync"/>. This method does not wait for the task
    /// to complete, but observes any exceptions (whether the task is faulted or canceled), optionally logging
    /// them to <paramref name="logger"/>.
    /// </summary>
    /// <param name="channel">The channel to shut down.</param>
    /// <param name="logger">An optional logger to record any errors during asynchronous shutdown.</param>
    public static void Shutdown(this ChannelBase channel, ILogger logger = null)
    {
        GaxPreconditions.CheckNotNull(channel, nameof(channel));
        if (channel is IDisposable disposable)
        {
            disposable.Dispose();
        }
        channel.ShutdownAsync().ContinueWith(
            task =>
            {
                // Always observe the exception, whether we've got a logger or not.
                var exception = task.Exception;
                logger?.LogWarning(exception, task.IsCanceled ? "Channel shutdown canceled" : "Channel shutdown failed");
            },
            TaskContinuationOptions.NotOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
    }
}
