/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Grpc.Core;
using System.Threading;

namespace Google.Api.Gax
{
    public static class ApiCallRetryExtensions
    {
        public static ApiCall<TRequest, TResponse> WithRetry<TRequest, TResponse>(
            this ApiCall<TRequest, TResponse> originalCall,
            RetrySettings retrySettings,
            IClock clock,
            IScheduler scheduler)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            GaxPreconditions.CheckNotNull(originalCall, nameof(originalCall));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));

            if (retrySettings == null)
            {
                // If retry isn't required, simply return the original call.
                return originalCall;
            }

            retrySettings.Validate(nameof(retrySettings));
            scheduler = scheduler ?? SystemScheduler.Instance;

            // By design, the code is mostly duplicated between the async and sync calls.

            ApiCall<TRequest, TResponse>.AsyncCall asyncCall = async (request, callSettings) =>
            {
                var overallDeadline = ClientHelper.CalculateDeadline(clock, callSettings.Expiration);
                var cancellationToken = callSettings.CancellationToken ?? CancellationToken.None;
                var retryDelay = retrySettings.RetryBackoff.Delay;
                var callTimeout = retrySettings.TimeoutBackoff.Delay;
                // The CallSettings, mutated as required for each attempt.
                var attemptSettings = callSettings.Clone();
                while (true)
                {
                    var callDeadline = clock.GetCurrentDateTimeUtc() + callTimeout;
                    // Note: this handles a null total deadline due to "<" returning false if overallDeadline is null.
                    attemptSettings.Expiration = Expiration.FromDeadline(overallDeadline < callDeadline ? overallDeadline.Value : callDeadline);

                    try
                    {
                        return await originalCall.Async(request, attemptSettings).ConfigureAwait(false);
                    }
                    catch (RpcException e) when (retrySettings.RetryFilter(e))
                    {
                        var actualDelay = retrySettings.DelayJitter.GetDelay(retryDelay);
                        var expectedRetryTime = clock.GetCurrentDateTimeUtc() + actualDelay;
                        if (expectedRetryTime > overallDeadline)
                        {
                            throw;
                        }
                        await scheduler.Delay(actualDelay).ConfigureAwait(false);
                        retryDelay = retrySettings.RetryBackoff.NextDelay(retryDelay);
                        callTimeout = retrySettings.TimeoutBackoff.NextDelay(callTimeout);
                    }
                }
            };

            ApiCall<TRequest, TResponse>.SyncCall syncCall = (request, callSettings) =>
            {
                var overallDeadline = ClientHelper.CalculateDeadline(clock, callSettings.Expiration);
                var cancellationToken = callSettings.CancellationToken ?? CancellationToken.None;
                var retryDelay = retrySettings.RetryBackoff.Delay;
                var callTimeout = retrySettings.TimeoutBackoff.Delay;
                // The CallSettings, mutated as required for each attempt.
                var attemptSettings = callSettings.Clone();
                while (true)
                {
                    var callDeadline = clock.GetCurrentDateTimeUtc() + callTimeout;
                    // Note: this handles a null total deadline due to "<" returning false if overallDeadline is null.
                    attemptSettings.Expiration = Expiration.FromDeadline(overallDeadline < callDeadline ? overallDeadline.Value : callDeadline);

                    try
                    {
                        return originalCall.Sync(request, attemptSettings);
                    }
                    catch (RpcException e) when (retrySettings.RetryFilter(e))
                    {
                        var actualDelay = retrySettings.DelayJitter.GetDelay(retryDelay);
                        var expectedRetryTime = clock.GetCurrentDateTimeUtc() + actualDelay;
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

            return new ApiCall<TRequest, TResponse>(asyncCall, syncCall);
        }
    }
}

