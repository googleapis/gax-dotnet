/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.Extensions.Logging;
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
            IClock clock, IScheduler scheduler, ILogger logger, string methodName) =>
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
                foreach (var attempt in RetryAttempt.CreateRetrySequence(retrySettings, scheduler, overallDeadline, clock))
                {
                    try
                    {
                        return await fn(request, callSettings).ConfigureAwait(false);
                    }
                    catch (Exception e) when (attempt.ShouldRetry(e))
                    {
                        logger?.LogDebug("Backing off before retry of method {method}", methodName);
                        await attempt.BackoffAsync(callSettings.CancellationToken.GetValueOrDefault()).ConfigureAwait(false);
                    }
                }
                throw new InvalidOperationException("Bug in GAX retry handling: finished sequence of attempts");
            };

        // Sync retry
        internal static Func<TRequest, CallSettings, TResponse> WithRetry<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn,
            IClock clock, IScheduler scheduler, ILogger logger, string methodName) =>
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
                foreach (var attempt in RetryAttempt.CreateRetrySequence(retrySettings, scheduler, overallDeadline, clock))
                {
                    try
                    {
                        return fn(request, callSettings);
                    }
                    catch (Exception e) when (attempt.ShouldRetry(e))
                    {
                        logger?.LogDebug("Backing off before retry of method {method}", methodName);
                        attempt.Backoff(callSettings.CancellationToken.GetValueOrDefault());
                    }
                }
                throw new InvalidOperationException("Bug in GAX retry handling: finished sequence of attempts");
            };

    }
}
