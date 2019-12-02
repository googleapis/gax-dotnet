/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    internal static class ApiCallRetryExtensions
    {
        // By design, the code is mostly duplicated between the async and sync calls.

        // Async retry
        internal static Func<TRequest, CallSettings, Task<TResponse>> WithRetry<TRequest, TResponse>(
            this Func<TRequest, CallSettings, Task<TResponse>> fn,
            IClock clock, IScheduler scheduler, Func<TResponse, Task> postResponse) =>
            async (request, callSettings) =>
            {
                RetrySettings retrySettings = callSettings.Retry;
                if (retrySettings == null)
                {
                    return await fn(request, callSettings).ConfigureAwait(false);
                }
                DateTime? overallDeadline = callSettings.Expiration.CalculateDeadline(clock);
                // Every attempt should use the same deadline, calculated from the start of the call.
                if (callSettings.Expiration?.Type == ExpirationType.Timeout)
                {
                    callSettings = callSettings.WithDeadline(overallDeadline.Value);
                }
                int attempt = 0;
                foreach (var retryBackoff in retrySettings.GetJitteredBackoffSequence())
                {
                    try
                    {
                        attempt++;
                        var response = await fn(request, callSettings).ConfigureAwait(false);
                        if (postResponse != null)
                        {
                            await postResponse(response).ConfigureAwait(false);
                        }
                        return response;
                    }
                    catch (RpcException e) when (
                        // We can retry if...
                        attempt < retrySettings.MaxAttempts &&  // We still have at least one attempt left
                        retrySettings.RetryFilter(e) &&         // The retry filter says to retry
                        (overallDeadline == null || clock.GetCurrentDateTimeUtc() + retryBackoff <= overallDeadline)) // The retry backoff won't take us over the deadline
                    {
                        await scheduler.Delay(retryBackoff, callSettings.CancellationToken.GetValueOrDefault()).ConfigureAwait(false);
                    }
                }
                throw new InvalidOperationException("Infinite sequence of backoffs ran out. (Bug in GAX. Please report at https://github.com/googleapis/gax-dotnet)");
            };

        // Sync retry
        internal static Func<TRequest, CallSettings, TResponse> WithRetry<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn,
            IClock clock, IScheduler scheduler, Action<TResponse> postResponse) =>
            (request, callSettings) =>
            {
                RetrySettings retrySettings = callSettings.Retry;
                if (retrySettings == null)
                {
                    return fn(request, callSettings);
                }
                DateTime? overallDeadline = callSettings.Expiration.CalculateDeadline(clock);
                // Every attempt should use the same deadline, calculated from the start of the call.
                if (callSettings.Expiration?.Type == ExpirationType.Timeout)
                {
                    callSettings = callSettings.WithDeadline(overallDeadline.Value);
                }
                int attempt = 0;
                foreach (var retryBackoff in retrySettings.GetJitteredBackoffSequence())
                {
                    try
                    {
                        attempt++;
                        var response = fn(request, callSettings);
                        postResponse?.Invoke(response);
                        return response;
                    }
                    catch (RpcException e) when (
                        // We can retry if...
                        attempt < retrySettings.MaxAttempts &&  // We still have at least one attempt left
                        retrySettings.RetryFilter(e) &&         // The retry filter says to retry
                        (overallDeadline == null || clock.GetCurrentDateTimeUtc() + retryBackoff <= overallDeadline)) // The retry backoff won't take us over the deadline
                    {
                        scheduler.Sleep(retryBackoff, callSettings.CancellationToken.GetValueOrDefault());
                    }
                }
                throw new InvalidOperationException("Infinite sequence of backoffs ran out. (Bug in GAX. Please report at https://github.com/googleapis/gax-dotnet)");
            };
    }
}
