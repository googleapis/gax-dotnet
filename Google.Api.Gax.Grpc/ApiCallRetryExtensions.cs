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
            IClock clock, IScheduler scheduler) =>
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
                TimeSpan backoffDelay = retrySettings.InitialBackoff;
                int attempt = 0;
                while (true)
                {
                    try
                    {
                        attempt++;
                        return await fn(request, callSettings).ConfigureAwait(false);
                    }
                    catch (RpcException e) when (attempt < retrySettings.MaxAttempts && retrySettings.RetryFilter(e))
                    {
                        TimeSpan actualDelay = retrySettings.BackoffJitter.GetDelay(backoffDelay);
                        DateTime expectedRetryTime = clock.GetCurrentDateTimeUtc() + actualDelay;
                        if (expectedRetryTime > overallDeadline)
                        {
                            throw;
                        }
                        await scheduler.Delay(actualDelay, callSettings.CancellationToken.GetValueOrDefault()).ConfigureAwait(false);
                        backoffDelay = retrySettings.NextBackoff(backoffDelay);
                    }
                }
            };

        // Sync retry
        internal static Func<TRequest, CallSettings, TResponse> WithRetry<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn,
            IClock clock, IScheduler scheduler) =>
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
                TimeSpan backoffDelay = retrySettings.InitialBackoff;
                int attempt = 0;
                while (true)
                {
                    try
                    {
                        attempt++;
                        return fn(request, callSettings);
                    }
                    catch (RpcException e) when (attempt < retrySettings.MaxAttempts && retrySettings.RetryFilter(e))
                    {
                        TimeSpan actualDelay = retrySettings.BackoffJitter.GetDelay(backoffDelay);
                        DateTime expectedRetryTime = clock.GetCurrentDateTimeUtc() + actualDelay;
                        if (expectedRetryTime > overallDeadline)
                        {
                            throw;
                        }
                        scheduler.Sleep(actualDelay, callSettings.CancellationToken.GetValueOrDefault());
                        backoffDelay = retrySettings.NextBackoff(backoffDelay);
                    }
                }
            };

    }
}
