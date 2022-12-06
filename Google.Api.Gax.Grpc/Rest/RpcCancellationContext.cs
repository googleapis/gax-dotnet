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

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Centralized handling of cancellation differentiation between time-outs
/// and explicit cancellation, as well as disposal of any CancellationTokenSource objects.
/// This also allows the RPC to be cancelled explicitly (separate from any cancellation tokens
/// previously created); this is expected to be used via <see cref="AsyncUnaryCall{TResponse}.Dispose"/>
/// etc.
/// </summary>
/// <remarks>
/// While it would be nice for this to be fully testable via IClock, the
/// CancellationTokenSource constructor that starts a timer isn't really testable anyway,
/// so everything is done with the system clock instead.
/// </remarks>
internal sealed class RpcCancellationContext : IDisposable
{
    private readonly string _rpcName;
    private readonly CancellationTokenSource _deadlineCancellationTokenSource;
    private readonly CancellationTokenSource _overallCancellationTokenSource;

    private RpcCancellationContext(
        string rpcName,
        CancellationTokenSource deadlineCancellationTokenSource,
        CancellationToken callOptionsCancellationToken)
    {
        _rpcName = rpcName;
        _deadlineCancellationTokenSource = deadlineCancellationTokenSource;
        var deadlineToken = _deadlineCancellationTokenSource?.Token ?? default;
        _overallCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(callOptionsCancellationToken, deadlineToken);
    }

    /// <summary>
    /// Creates an instance using the given cancellation token source for deadlines and the given
    /// call cancellation token. This is only present for test purposes.
    /// </summary>
    internal static RpcCancellationContext ForTesting(
        string rpcName,
        CancellationTokenSource deadlineCancellationTokenSource,
        CancellationToken callCancellationToken) =>
        new RpcCancellationContext(rpcName, deadlineCancellationTokenSource, callCancellationToken);

    /// <summary>
    /// Creates a cancellation context from the given call options.
    /// </summary>
    /// <param name="rpcName">The name of the RPC, used to report exceptions.</param>
    /// <param name="options">The call options used for this RPC call, optionally including
    /// a deadline and cancellation token.</param>
    /// <exception cref="RpcException">The options contain a deadline that has already elapsed</exception>
    internal static RpcCancellationContext FromOptions(string rpcName, CallOptions options)
    {
        CancellationTokenSource deadlineCancellationTokenSource = null;
        if (options.Deadline is DateTime deadline)
        {
            var timeout = deadline - DateTime.UtcNow;
            if (timeout.TotalMilliseconds <= 0)
            {
                throw new RpcException(new Status(StatusCode.DeadlineExceeded, $"RPC '{rpcName}' timed out"));
            }
            deadlineCancellationTokenSource = new CancellationTokenSource(timeout);
        }
        return new RpcCancellationContext(rpcName, deadlineCancellationTokenSource, options.CancellationToken);
    }

    /// <summary>
    /// Combines <paramref name="cancellationToken"/> with the RPC's cancellation tokens, and waits for
    /// the task provided by <paramref name="taskProvider"/> to complete, converting any <see cref="OperationCanceledException"/>
    /// into an <see cref="RpcException"/> with an appropriate status (DeadlineExceeded or Cancelled depending
    /// on which token was responsible for the original exception).
    /// </summary>
    /// <param name="taskProvider">A function which returns a task to await.</param>
    /// <param name="cancellationToken">An additional cancellation token, defaulting to "no extra cancellation token,
    /// just use the RPC's cancellation tokens".</param>
    /// <returns>A task which will complete when the provided task completes.</returns>
    public async Task RunAsync(Func<CancellationToken, Task> taskProvider, CancellationToken cancellationToken = default)
    {
        using (var cts = CancellationTokenSource.CreateLinkedTokenSource(_overallCancellationTokenSource.Token, cancellationToken))
        {
            try
            {
                await taskProvider(cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException ex)
            {
                throw CreateRpcException(ex);
            }
        }
    }

    /// <summary>
    /// Combines <paramref name="cancellationToken"/> with the RPC's cancellation tokens, and waits for
    /// the task provided by <paramref name="taskProvider"/> to complete, converting any <see cref="OperationCanceledException"/>
    /// into an <see cref="RpcException"/> with an appropriate status (DeadlineExceeded or Cancelled depending
    /// on which token was responsible for the original exception).
    /// </summary>
    /// <typeparam name="T">The type of the task provided by <paramref name="taskProvider"/>.</typeparam>
    /// <param name="taskProvider">A function which returns a task to await.</param>
    /// <param name="cancellationToken">An additional cancellation token, defaulting to "no extra cancellation token,
    /// just use the RPC's cancellation tokens".</param>
    /// <returns>A task which will complete when the provided task completes.</returns>
    public async Task<T> RunAsync<T>(Func<CancellationToken, Task<T>> taskProvider, CancellationToken cancellationToken = default)
    {
        using (var cts = CancellationTokenSource.CreateLinkedTokenSource(_overallCancellationTokenSource.Token, cancellationToken))
        {
            try
            {
                return await taskProvider(cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException ex)
            {
                throw CreateRpcException(ex);
            }
        }
    }

    private RpcException CreateRpcException(Exception originalException)
    {
        var status = _deadlineCancellationTokenSource?.Token.IsCancellationRequested == true
            ? new Status(StatusCode.DeadlineExceeded, $"RPC '{_rpcName}' timed out", originalException)
            : new Status(StatusCode.Cancelled, $"RPC '{_rpcName}' was cancelled", originalException);
        return new RpcException(status);
    }

    /// <summary>
    /// Cancels the overall RPC.
    /// </summary>
    public void Cancel()
    {
        // TODO: Handle exceptions from this being disposed?
        _overallCancellationTokenSource.Cancel();
    }

    /// <summary>
    /// Disposes of the resources used by this context. After this method returns,
    /// the context cannot be used: further calls, including <see cref="Cancel"/>,
    /// will throw <see cref="ObjectDisposedException"/>.
    /// </summary>
    public void Dispose()
    {
        _deadlineCancellationTokenSource?.Dispose();
        _overallCancellationTokenSource.Dispose();
    }
}
