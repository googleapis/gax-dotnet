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
                RetrySettings retrySettings = callSettings.Timing?.Retry;
                if (retrySettings == null)
                {
                    return await fn(request, callSettings);
                }
                DateTime? overallDeadline = retrySettings.TotalExpiration.CalculateDeadline(clock);
                TimeSpan retryDelay = retrySettings.RetryBackoff.Delay;
                TimeSpan callTimeout = retrySettings.TimeoutBackoff.Delay;
                // May not need to clone, not yet quite sure...
                CallSettings attemptCallSettings = callSettings.Clone();
                while (true)
                {
                    DateTime attemptDeadline = clock.GetCurrentDateTimeUtc() + callTimeout;
                    // Note: this handles a null total deadline due to "<" returning false if overallDeadline is null.
                    DateTime combinedDeadline = overallDeadline < attemptDeadline ? overallDeadline.Value : attemptDeadline;
                    attemptCallSettings.Timing = CallTiming.FromDeadline(combinedDeadline);
                    try
                    {
                        return await fn(request, attemptCallSettings);
                    }
                    catch (RpcException e) when (retrySettings.RetryFilter(e))
                    {
                        TimeSpan actualDelay = retrySettings.DelayJitter.GetDelay(retryDelay);
                        DateTime expectedRetryTime = clock.GetCurrentDateTimeUtc() + actualDelay;
                        if (expectedRetryTime > overallDeadline)
                        {
                            throw;
                        }
                        await scheduler.Delay(actualDelay);
                        retryDelay = retrySettings.RetryBackoff.NextDelay(retryDelay);
                        callTimeout = retrySettings.TimeoutBackoff.NextDelay(callTimeout);
                    }
                }
            };

        // Sync retry
        internal static Func<TRequest, CallSettings, TResponse> WithRetry<TRequest, TResponse>(
            this Func<TRequest, CallSettings, TResponse> fn,
            IClock clock, IScheduler scheduler) =>
            (request, callSettings) =>
            {
                RetrySettings retrySettings = callSettings.Timing?.Retry;
                if (retrySettings == null)
                {
                    return fn(request, callSettings);
                }
                DateTime? overallDeadline = retrySettings.TotalExpiration.CalculateDeadline(clock);
                TimeSpan retryDelay = retrySettings.RetryBackoff.Delay;
                TimeSpan callTimeout = retrySettings.TimeoutBackoff.Delay;
                // May not need to clone, not yet quite sure...
                CallSettings attemptCallSettings = callSettings.Clone();
                while (true)
                {
                    DateTime attemptDeadline = clock.GetCurrentDateTimeUtc() + callTimeout;
                    // Note: this handles a null total deadline due to "<" returning false if overallDeadline is null.
                    DateTime combinedDeadline = overallDeadline < attemptDeadline ? overallDeadline.Value : attemptDeadline;
                    attemptCallSettings.Timing = CallTiming.FromDeadline(combinedDeadline);
                    try
                    {
                        return fn(request, attemptCallSettings);
                    }
                    catch (RpcException e) when (retrySettings.RetryFilter(e))
                    {
                        TimeSpan actualDelay = retrySettings.DelayJitter.GetDelay(retryDelay);
                        DateTime expectedRetryTime = clock.GetCurrentDateTimeUtc() + actualDelay;
                        if (expectedRetryTime > overallDeadline)
                        {
                            throw;
                        }
                        scheduler.Sleep(actualDelay);
                        retryDelay = retrySettings.RetryBackoff.NextDelay(retryDelay);
                        callTimeout = retrySettings.TimeoutBackoff.NextDelay(callTimeout);
                    }
                }
            };

    }
}

