/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Google.Protobuf;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Google.Api.Gax.Grpc.Testing;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RetryTest
    {
        private static readonly BackoffSettings DoublingBackoff =
            new BackoffSettings(TimeSpan.FromTicks(1000), TimeSpan.FromTicks(5000), 2.0);

        private static readonly BackoffSettings ConstantBackoff =
            new BackoffSettings(TimeSpan.FromTicks(1500), TimeSpan.FromTicks(6000), 1.0);

        private static async Task<TResponse> Call<TRequest, TResponse>(
            bool async, ApiCall<TRequest, TResponse> call, TRequest request, CallSettings callSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse> =>
                async ? await call.Async(request, callSettings) : call.Sync(request, callSettings);

        private static async Task<TResponse> Call<TRequest, TResponse>(
            bool async, ApiServerStreamingCall<TRequest, TResponse> call, TRequest request, CallSettings callSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            var streamingCall = async ? await call.CallAsync(request, callSettings) : call.Call(request, callSettings);
            // return the first (and only) response message.
            await streamingCall.ResponseStream.MoveNext();
            return streamingCall.ResponseStream.Current;
        }

        private Task<SimpleResponse> Call(
            bool async, bool serverStreaming, FakeScheduler scheduler, Server server, SimpleRequest request, CallSettings callSettings)
        {
            if (serverStreaming)
            {
                var retryingCallable = server.ServerStreamingCallable.WithRetry(scheduler.Clock, scheduler);
                return Call(async, retryingCallable, request, callSettings);
            }
            else
            {
                var retryingCallable = server.Callable.WithRetry(scheduler.Clock, scheduler);
                return Call(async, retryingCallable, request, callSettings);
            }
        }

        [Theory, CombinatorialData]
        public async Task FirstCallSucceeds(bool async, bool serverStreaming)
        {
            var name = "name"; // Copied from request to response
            var scheduler = new FakeScheduler();
            var time0 = scheduler.Clock.GetCurrentDateTimeUtc();
            var server = new Server(0, TimeSpan.FromTicks(300), scheduler);
            var retrySettings = new RetrySettings(
                retryBackoff: DoublingBackoff,
                timeoutBackoff: ConstantBackoff,
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                retryFilter: null,
                delayJitter: RetrySettings.NoJitter);

            await scheduler.RunAsync(async () =>
            {
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings));
                var request = new SimpleRequest { Name = name };
                var result = await Call(async, serverStreaming, scheduler, server, request, callSettings);
                Assert.Equal(name, result.Name);
            });

            server.AssertCallTimes(time0);
            // Time of last action was when the call returned
            Assert.Equal(300, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory, CombinatorialData]
        public async Task MultipleCallsEventualSuccess(bool async, bool serverStreaming)
        {
            var callDuration = TimeSpan.FromTicks(300);
            var failures = 4; // Fifth call will succeed
            var name = "name"; // Copied from request to response
            var scheduler = new FakeScheduler();
            var time0 = scheduler.Clock.GetCurrentDateTimeUtc();
            var server = new Server(failures, callDuration, scheduler);
            var retrySettings = new RetrySettings(
                retryBackoff: DoublingBackoff,
                timeoutBackoff: ConstantBackoff,
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                retryFilter: null,
                delayJitter: RetrySettings.NoJitter);

            await scheduler.RunAsync(async () =>
            {
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings));
                var request = new SimpleRequest { Name = name };
                var result = await Call(async, serverStreaming, scheduler, server, request, callSettings);
                Assert.Equal(name, result.Name);
            });

            var firstCall = time0;
            var secondCall = firstCall + callDuration + TimeSpan.FromTicks(1000); // Delay for 1000 ticks
            var thirdCall = secondCall + callDuration + TimeSpan.FromTicks(2000); // Delay for 2000 ticks
            var fourthCall = thirdCall + callDuration + TimeSpan.FromTicks(4000); // Delay for 4000 ticks
            var fifthCall = fourthCall + callDuration + TimeSpan.FromTicks(5000); // Delay for 5000 ticks, as that's the max

            server.AssertCallTimes(firstCall, secondCall, thirdCall, fourthCall, fifthCall);
            // Time of last action was when the call returned
            Assert.Equal(fifthCall + callDuration, scheduler.Clock.GetCurrentDateTimeUtc());
        }

        [Theory, CombinatorialData]
        public async Task CallSettingsDeadlineIsObserved(bool async, bool serverStreaming)
        {
            var callDuration = TimeSpan.FromTicks(300);
            var failures = 4; // Fifth call would succeed, but we won't get that far.
            var scheduler = new FakeScheduler();
            var time0 = scheduler.Clock.GetCurrentDateTimeUtc();
            var server = new Server(failures, callDuration, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings(
                retryBackoff: DoublingBackoff,
                timeoutBackoff: ConstantBackoff,
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromTicks(2500)),
                retryFilter: null,
                delayJitter: RetrySettings.NoJitter);

            var task = scheduler.RunAsync(async () =>
            {
                // Expiration makes it fail while waiting to make third call
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings));
                var request = new SimpleRequest { Name = "irrelevant" };
                await Call(async, serverStreaming, scheduler, server, request, callSettings);
            });
            await Assert.ThrowsAsync<RpcException>(() => task);

            var firstCall = time0;
            var secondCall = firstCall + callDuration + TimeSpan.FromTicks(1000);
            server.AssertCallTimes(firstCall, secondCall);

            // We fail immediately when we work out that we would time out before we make the third
            // call - so this is before the actual total timeout.
            Assert.Equal((secondCall + callDuration).Ticks, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory, CombinatorialData]
        public async Task ExponentialTimeouts(bool async, bool serverStreaming)
        {
            var callDuration = TimeSpan.FromTicks(300);
            var failures = 2;
            var scheduler = new FakeScheduler();
            var time0 = scheduler.Clock.GetCurrentDateTimeUtc();
            var server = new Server(failures, callDuration, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings(
                retryBackoff: ConstantBackoff, // 1500 ticks always
                timeoutBackoff: DoublingBackoff, // 1000, then 2000, then 4000
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromTicks(4500)),
                retryFilter: null,
                delayJitter: RetrySettings.NoJitter);

            await scheduler.RunAsync(async () =>
            {
                // Expiration truncates the third timeout. We expect:
                // Call 1: t=0, deadline=1000, completes at 300
                // Call 2: t=1800, deadline=3800 (2000+1800), completes at 2100
                // Call 3, t=3600, deadline=4500 (would be 7600, but overall deadline truncates), completes at 3900 (with success)
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings));
                var request = new SimpleRequest { Name = "irrelevant" };
                await Call(async, serverStreaming, scheduler, server, request, callSettings);
            });

            server.AssertCallTimes(time0, time0 + TimeSpan.FromTicks(1800), time0 + TimeSpan.FromTicks(3600));
            server.AssertDeadlines(time0 + TimeSpan.FromTicks(1000), time0 + TimeSpan.FromTicks(3800), time0 + TimeSpan.FromTicks(4500));
            Assert.Equal(3900L, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory, CombinatorialData]
        public async Task RetryFilter_EventualSuccess(bool async, bool serverStreaming)
        {
            StatusCode failureCode = StatusCode.NotFound;
            StatusCode[] filterCodes = new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded };
            var callDuration = TimeSpan.FromTicks(100);
            var failures = 1;
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler, failureCode);
            // We're not really interested in the timing in this test.
            var retrySettings = new RetrySettings(
                retryBackoff: ConstantBackoff,
                timeoutBackoff: ConstantBackoff,
                delayJitter: RetrySettings.NoJitter,
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                retryFilter: RetrySettings.FilterForStatusCodes(filterCodes));

            await scheduler.RunAsync(async () =>
            {
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings));
                var request = new SimpleRequest { Name = "irrelevant" };
                await Call(async, serverStreaming, scheduler, server, request, callSettings);
            });

            Assert.True(server.CallTimes.Count() > 1);
        }

        [Theory]
        [InlineData(true, false, StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded })]
        [InlineData(true, false, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound })]
        [InlineData(false, false, StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded })]
        [InlineData(false, false, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound })]
        [InlineData(true, true, StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded })]
        [InlineData(true, true, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound })]
        [InlineData(false, true, StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded })]
        [InlineData(false, true, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound })]
        public async Task RetryFilter_EventualFailure(bool async, bool serverStreaming, StatusCode failureCode, StatusCode[] filterCodes)
        {
            var callDuration = TimeSpan.FromTicks(100);
            var failures = 1;
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler, failureCode);
            // We're not really interested in the timing in this test.
            var retrySettings = new RetrySettings(
                retryBackoff: ConstantBackoff,
                timeoutBackoff: ConstantBackoff,
                delayJitter: RetrySettings.NoJitter,
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                retryFilter: RetrySettings.FilterForStatusCodes(filterCodes));

            var task = scheduler.RunAsync(async () =>
            {
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings));
                var request = new SimpleRequest { Name = "irrelevant" };
                await Call(async, serverStreaming, scheduler, server, request, callSettings);
            });
            await Assert.ThrowsAsync<RpcException>(() => task);

            Assert.Equal(1, server.CallTimes.Count());
        }

        [Theory, CombinatorialData]
        public async Task RetryCancellation(bool serverStreaming, [CombinatorialValues(1500, 3500)] int delayMs)
        {
            // Note: Cannot test cancellation during wait for response header, due to FakeScheduler shortcomings.
            var async = true;
            var scheduler = new FakeScheduler();
            var time0 = scheduler.Clock.GetCurrentDateTimeUtc();
            var server = new Server(10, TimeSpan.FromSeconds(1), scheduler);
            var retrySettings = new RetrySettings(
                retryBackoff: new BackoffSettings(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), 1.0),
                timeoutBackoff: new BackoffSettings(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), 1.0),
                delayJitter: RetrySettings.NoJitter,
                totalExpiration: Expiration.FromTimeout(TimeSpan.FromSeconds(10)),
                retryFilter: RetrySettings.DefaultFilter);
            var delay = TimeSpan.FromMilliseconds(delayMs);
            Task task = scheduler.RunAsync(async () =>
            {
                var cts = new CancellationTokenSource();
                var unused = Task.Run(async () =>
                {
                    await scheduler.Delay(delay);
                    cts.Cancel();
                });
                var callSettings = CallSettings.FromCallTiming(CallTiming.FromRetry(retrySettings)).WithCancellationToken(cts.Token);
                var request = new SimpleRequest { Name = "irrelevant" };
                await Call(async, serverStreaming, scheduler, server, request, callSettings);
            });
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            Assert.Equal(time0 + delay, scheduler.Clock.GetCurrentDateTimeUtc());

        }

        private class Server
        {
            private readonly FakeScheduler _scheduler;
            internal IList<DateTime> CallTimes { get; } = new List<DateTime>();
            private IList<CallSettings> CallSettingsReceived { get; } = new List<CallSettings>();
            private readonly TimeSpan _callDuration;
            private readonly StatusCode _failureCode;
            private int _failuresToReturn;

            internal Server(int failuresToReturn, TimeSpan callDuration, FakeScheduler scheduler, StatusCode failureCode = StatusCode.NotFound)
            {
                _callDuration = callDuration;
                _failuresToReturn = failuresToReturn;
                _failureCode = failureCode;
                _scheduler = scheduler;
            }

            public async Task<SimpleResponse> MethodAsync(SimpleRequest request, CallSettings callSettings)
            {
                CallTimes.Add(_scheduler.Clock.GetCurrentDateTimeUtc());
                CallSettingsReceived.Add(callSettings);
                await _scheduler.Delay(_callDuration);
                if (_failuresToReturn > 0)
                {
                    _failuresToReturn--;
                    throw new RpcException(new Status(_failureCode, "Bang"));
                }
                return new SimpleResponse { Name = request.Name };
            }

            // Can't just call MethodAsync(...).Result due to limitations of FakeScheduler
            public SimpleResponse MethodSync(SimpleRequest request, CallSettings callSettings)
            {
                CallTimes.Add(_scheduler.Clock.GetCurrentDateTimeUtc());
                CallSettingsReceived.Add(callSettings);
                _scheduler.Delay(_callDuration).Wait();
                if (_failuresToReturn > 0)
                {
                    _failuresToReturn--;
                    throw new RpcException(new Status(_failureCode, "Bang"));
                }
                return new SimpleResponse { Name = request.Name };
            }

            public ApiCall<SimpleRequest, SimpleResponse> Callable =>
                new ApiCall<SimpleRequest, SimpleResponse>(MethodAsync, MethodSync, null);
            
            public Task<AsyncServerStreamingCall<SimpleResponse>> ServerStreamingMethodAsync(SimpleRequest request, CallSettings callSettings) =>
                Task.FromResult(ServerStreamingMethodSync(request, callSettings));

            public AsyncServerStreamingCall<SimpleResponse> ServerStreamingMethodSync(SimpleRequest request, CallSettings callSettings)
            {
                CallTimes.Add(_scheduler.Clock.GetCurrentDateTimeUtc());
                CallSettingsReceived.Add(callSettings);
                var responses = new[] { new SimpleResponse { Name = request.Name } };
                var responseStream = new AsyncStreamAdapter<SimpleResponse>(responses.ToAsyncEnumerable().GetAsyncEnumerator());
                var responseHeaders = Task.Run(async () =>
                {
                    await _scheduler.Delay(_callDuration, callSettings.CancellationToken.GetValueOrDefault());
                    if (_failuresToReturn > 0)
                    {
                        _failuresToReturn--;
                        throw new RpcException(new Status(_failureCode, "Bang"));
                    }
                    return Metadata.Empty;
                });
                var response = new AsyncServerStreamingCall<SimpleResponse>(responseStream, responseHeaders, null, null, null);
                return response;
            }

            public ApiServerStreamingCall<SimpleRequest, SimpleResponse> ServerStreamingCallable =>
                new ApiServerStreamingCall<SimpleRequest, SimpleResponse>(ServerStreamingMethodAsync, ServerStreamingMethodSync, null);

            public void AssertCallTimes(params DateTime[] times)
            {
                Assert.Equal(times, CallTimes);
            }

            public void AssertDeadlines(params DateTime[] times)
            {
                // Note that this effectively asserts we always end up with a CallSettings with a deadline.
                Assert.Equal(times, CallSettingsReceived.Select(cs => cs.Timing.Expiration.Deadline.Value).ToArray());
            }
        }
    }
}
