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
    /// <summary>
    /// Extension methods on <see cref="ApiCallable{TRequest, TResponse}"/>.
    /// </summary>
    public static class ApiCallableExtensions
    {
        /// <summary>
        /// Creates a retrying equivalent of the given callable delegate.
        /// </summary>
        /// <typeparam name="TRequest">Request message type</typeparam>
        /// <typeparam name="TResponse">Response message type</typeparam>
        /// <param name="originalCall">Original callable delegate</param>
        /// <param name="retrySettings">Retry settings</param>
        /// <param name="clock">Clock to consult for retry timing</param>
        /// <returns>A retrying equivalent of <paramref name="originalCall"/></returns>
        public static ApiCallable<TRequest, TResponse> WithRetry<TRequest, TResponse>(
            this ApiCallable<TRequest, TResponse> originalCall,
            RetrySettings retrySettings,
            IClock clock)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse> => WithRetry(originalCall, retrySettings, clock, null);

        /// <summary>
        /// Creates a retrying equivalent of the given callable delegate.
        /// </summary>
        /// <typeparam name="TRequest">Request message type</typeparam>
        /// <typeparam name="TResponse">Response message type</typeparam>
        /// <param name="originalCall">Original callable delegate</param>
        /// <param name="retrySettings">Retry settings</param>
        /// <param name="clock">Clock to consult for retry timing</param>
        /// <param name="scheduler">Scheduler to use for delays</param>
        /// <returns>A retrying equivalent of <paramref name="originalCall"/></returns>
        public static ApiCallable<TRequest, TResponse> WithRetry<TRequest, TResponse>(
            this ApiCallable<TRequest, TResponse> originalCall,
            RetrySettings retrySettings,
            IClock clock,
            IScheduler scheduler)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            GaxPreconditions.CheckNotNull(originalCall, nameof(originalCall));
            GaxPreconditions.CheckNotNull(retrySettings, nameof(retrySettings));
            retrySettings.Validate(nameof(retrySettings));
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            scheduler = scheduler ?? SystemScheduler.Instance;

            return async (request, callSettings) =>
            {
                var overallDeadline = ClientHelper.CalculateDeadline(clock, callSettings.Expiration);
                var cancellationToken = callSettings.CancellationToken ?? CancellationToken.None;
                var retryDelay = retrySettings.RetryBackoff.Delay;
                var callTimeout = retrySettings.TimeoutBackoff.Delay;
                while (true)
                {
                    // The CallSettings for this particular attempt.
                    var attemptSettings = callSettings.Clone();
                    var callDeadline = clock.GetCurrentDateTimeUtc() + callTimeout;
                    // Note: this handles a null total deadline due to "<" returning false if overallDeadline is null.
                    attemptSettings.Expiration = Expiration.FromDeadline(overallDeadline < callDeadline ? overallDeadline.Value : callDeadline);

                    try
                    {
                        return await originalCall(request, attemptSettings).ConfigureAwait(false);
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
        }
    }
}
