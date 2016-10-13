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
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RetryTest
    {
        private static readonly BackoffSettings DoublingBackoff = new BackoffSettings
        {
            Delay = TimeSpan.FromTicks(1000),
            DelayMultiplier = 2.0,
            MaxDelay = TimeSpan.FromTicks(5000)
        };

        private static readonly BackoffSettings ConstantBackoff = new BackoffSettings
        {
            Delay = TimeSpan.FromTicks(1500),
            DelayMultiplier = 1.0,
            MaxDelay = TimeSpan.FromTicks(6000) // Irrelevant
        };

        private static Task<TResponse> Call<TRequest, TResponse>(
            bool async, ApiCall<TRequest, TResponse> call, TRequest request, CallSettings callSettings)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            if (async)
            {
                return call.Async(request, callSettings);
            }
            try
            {
                return Task.FromResult(call.Sync(request, callSettings));
            }
            catch (Exception e)
            {
                // Task.FromException<TResponse>(e) is only available from v4.6 :(
                var tcs = new TaskCompletionSource<TResponse>();
                tcs.SetException(e);
                return tcs.Task;
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task FirstCallSucceeds(bool async)
        {
            var name = "name"; // Copied from request to response
            var scheduler = new FakeScheduler();
            var server = new Server(0, 300, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings
            {
                RetryBackoff = DoublingBackoff,
                TimeoutBackoff = ConstantBackoff,
                TotalExpiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                DelayJitter = RetrySettings.NoJitter
            };

            await scheduler.RunAsync(async () =>
            {
                var callSettings = new CallSettings {
                    Timing = CallTiming.FromRetry(retrySettings)
                };
                var retryingCallable = callable.WithRetry(scheduler.Clock, scheduler);
                var result = await Call(async, retryingCallable, new SimpleRequest { Name = name }, callSettings);
                Assert.Equal(name, result.Name);
            });

            server.AssertCallTimes(0L);
            // Time of last action was when the call returned
            Assert.Equal(300, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task MultipleCallsEventualSuccess(bool async)
        {
            var callDuration = 300;
            var failures = 4; // Fifth call will succeed
            var name = "name"; // Copied from request to response
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings
            {
                RetryBackoff = DoublingBackoff,
                TimeoutBackoff = ConstantBackoff,
                TotalExpiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                DelayJitter = RetrySettings.NoJitter
            };

            await scheduler.RunAsync(async () =>
            {
                var callSettings = new CallSettings {
                    Timing = CallTiming.FromRetry(retrySettings)
                };
                var retryingCallable = callable.WithRetry(scheduler.Clock, scheduler);
                var result = await Call(async, retryingCallable, new SimpleRequest { Name = name }, callSettings);
                Assert.Equal(name, result.Name);
            });

            var firstCall = 0L;
            var secondCall = callDuration + 1000; // Delay for 1000 ticks
            var thirdCall = secondCall + callDuration + 2000; // Delay for 2000 ticks
            var fourthCall = thirdCall + callDuration + 4000; // Delay for 4000 ticks
            var fifthCall = fourthCall + callDuration + 5000; // Delay for 5000 ticks, as that's the max

            server.AssertCallTimes(firstCall, secondCall, thirdCall, fourthCall, fifthCall);
            // Time of last action was when the call returned
            Assert.Equal(fifthCall + callDuration, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task CallSettingsDeadlineIsObserved(bool async)
        {
            var callDuration = 300;
            var failures = 4; // Fifth call would succeed, but we won't get that far.
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings
            {
                RetryBackoff = DoublingBackoff,
                TimeoutBackoff = ConstantBackoff,
                TotalExpiration = Expiration.FromTimeout(TimeSpan.FromTicks(2500)),
                DelayJitter = RetrySettings.NoJitter
            };

            var task = scheduler.RunAsync(async () =>
            {
                // Expiration makes it fail while waiting to make third call
                var callSettings = new CallSettings {
                    Timing = CallTiming.FromRetry(retrySettings)
                };
                var retryingCallable = callable.WithRetry(scheduler.Clock, scheduler);
                await Call(async, retryingCallable, new SimpleRequest { Name = "irrelevant" }, callSettings);
            });
            await Assert.ThrowsAsync<RpcException>(() => task);

            var firstCall = 0L;
            var secondCall = callDuration + 1000;
            server.AssertCallTimes(firstCall, secondCall);

            // We fail immediately when we work out that we would time out before we make the third
            // call - so this is before the actual total timeout.
            Assert.Equal(secondCall + callDuration, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ExponentialTimeouts(bool async)
        {
            var callDuration = 300;
            var failures = 2;
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings
            {
                RetryBackoff = ConstantBackoff, // 1500 ticks always
                TimeoutBackoff = DoublingBackoff, // 1000, then 2000, then 4000
                TotalExpiration = Expiration.FromTimeout(TimeSpan.FromTicks(4500)),
                DelayJitter = RetrySettings.NoJitter
            };

            await scheduler.RunAsync(async () =>
            {
                // Expiration truncates the third timeout. We expect:
                // Call 1: t=0, deadline=1000, completes at 300
                // Call 2: t=1800, deadline=3800 (2000+1800), completes at 2100
                // Call 3, t=3600, deadline=4500 (would be 7600, but overall deadline truncates), completes at 3900 (with success)
                var callSettings = new CallSettings {
                    Timing = CallTiming.FromRetry(retrySettings)
                };
                var retryingCallable = callable.WithRetry(scheduler.Clock, scheduler);
                await Call(async, retryingCallable, new SimpleRequest { Name = "irrelevant" }, callSettings);
            });

            server.AssertCallTimes(0L, 1800L, 3600L);
            server.AssertDeadlines(1000L, 3800L, 4500L);
            Assert.Equal(3900L, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory]
        [InlineData(true, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded })]
        [InlineData(false, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded })]
        public async Task RetryFilter_EventualSuccess(bool async, StatusCode failureCode, StatusCode[] filterCodes)
        {
            var callDuration = 100;
            var failures = 1;
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler, failureCode);
            // We're not really interested in the timing in this test.
            var retrySettings = new RetrySettings
            {
                RetryBackoff = ConstantBackoff,
                TimeoutBackoff = ConstantBackoff,
                DelayJitter = RetrySettings.NoJitter,
                TotalExpiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                RetryFilter = RetrySettings.FilterForStatusCodes(filterCodes)
            };

            await scheduler.RunAsync(async () =>
            {
                var callSettings = new CallSettings {
                    Timing = CallTiming.FromRetry(retrySettings)
                };
                var retryingCallable = server.Callable.WithRetry(scheduler.Clock, scheduler);
                await Call(async, retryingCallable, new SimpleRequest { Name = "irrelevant" }, callSettings);
            });

            Assert.True(server.CallTimes.Count() > 1);
        }

        [InlineData(true, StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded }, false)]
        [InlineData(true, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound }, false)]
        [InlineData(false, StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded }, false)]
        [InlineData(false, StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound }, false)]
        public async Task RetryFilter_EventualFailure(bool async, StatusCode failureCode, StatusCode[] filterCodes)
        {
            var callDuration = 100;
            var failures = 1;
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler, failureCode);
            // We're not really interested in the timing in this test.
            var retrySettings = new RetrySettings
            {
                RetryBackoff = ConstantBackoff,
                TimeoutBackoff = ConstantBackoff,
                DelayJitter = RetrySettings.NoJitter,
                TotalExpiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)),
                RetryFilter = RetrySettings.FilterForStatusCodes(filterCodes)
            };

            var task = scheduler.RunAsync(async () =>
            {
                var callSettings = new CallSettings
                {
                    Timing = CallTiming.FromRetry(retrySettings)
                };
                var retryingCallable = server.Callable.WithRetry(scheduler.Clock, scheduler);
                await Call(async, retryingCallable, new SimpleRequest { Name = "irrelevant" }, callSettings);
            });
            await Assert.ThrowsAsync<RpcException>(() => task);

            Assert.Equal(1, server.CallTimes.Count());
        }

        private class Server
        {
            private readonly FakeScheduler scheduler;
            internal IList<DateTime> CallTimes { get; } = new List<DateTime>();
            private IList<CallSettings> CallSettingsReceived { get; } = new List<CallSettings>();
            private readonly TimeSpan callDuration;
            private readonly StatusCode failureCode;
            private int failuresToReturn;

            internal Server(int failuresToReturn, long tickCallDuration, FakeScheduler scheduler, StatusCode failureCode = StatusCode.NotFound)
            {
                callDuration = TimeSpan.FromTicks(tickCallDuration);
                this.failuresToReturn = failuresToReturn;
                this.failureCode = failureCode;
                this.scheduler = scheduler;
            }

            public async Task<SimpleResponse> MethodAsync(SimpleRequest request, CallSettings callSettings)
            {
                CallTimes.Add(scheduler.Clock.GetCurrentDateTimeUtc());
                CallSettingsReceived.Add(callSettings.Clone());
                await scheduler.Delay(callDuration);
                if (failuresToReturn > 0)
                {
                    failuresToReturn--;
                    throw new RpcException(new Status(failureCode, "Bang"));
                }
                return new SimpleResponse { Name = request.Name };
            }

            // Can't just call MethodAsync(...).Result due to limitations of FakeScheduler
            public SimpleResponse MethodSync(SimpleRequest request, CallSettings callSettings)
            {
                CallTimes.Add(scheduler.Clock.GetCurrentDateTimeUtc());
                CallSettingsReceived.Add(callSettings.Clone());
                scheduler.Sleep(callDuration);
                if (failuresToReturn > 0)
                {
                    failuresToReturn--;
                    throw new RpcException(new Status(failureCode, "Bang"));
                }
                return new SimpleResponse { Name = request.Name };
            }

            public ApiCall<SimpleRequest, SimpleResponse> Callable =>
                new ApiCall<SimpleRequest, SimpleResponse>(MethodAsync, MethodSync, new CallSettings());

            public void AssertCallTimes(params long[] ticks)
            {
                Assert.Equal(ticks, CallTimes.Select(dt => dt.Ticks).ToArray());
            }

            public void AssertDeadlines(params long[] ticks)
            {
                // Note that this effectively asserts we always end up with a CallSettings with a deadline.
                Assert.Equal(ticks, CallSettingsReceived.Select(cs => cs.Timing.Expiration.Deadline.Value.Ticks).ToArray());
            }
        }
    }
}
