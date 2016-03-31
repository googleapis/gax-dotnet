/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
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

        [Fact]
        public void FirstCallSucceeds()
        {
            var name = "name"; // Copied from request to response
            var scheduler = new FakeScheduler();
            var server = new Server(0, 300, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings
            {
                RetryBackoff = DoublingBackoff,
                TimeoutBackoff = ConstantBackoff,
                DelayJitter = RetrySettings.NoJitter
            };

            var callSettings = new CallSettings { Expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)) };
            var retryingCallable = callable.WithRetry(retrySettings, scheduler.Clock, scheduler);
            var rpcTask = retryingCallable(new SimpleRequest { Name = name }, callSettings);

            scheduler.Run();

            server.AssertCallTimes(0L);
            // Time of last action was when the call returned
            Assert.Equal(300, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);

            Assert.Equal(TaskStatus.RanToCompletion, rpcTask.Status);

            // And the response is propagated
            Assert.Equal(name, rpcTask.Result.Name);
        }

        [Fact]
        public void MultipleCallsEventualSuccess()
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
                DelayJitter = RetrySettings.NoJitter
            };

            var callSettings = new CallSettings { Expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)) };
            var retryingCallable = callable.WithRetry(retrySettings, scheduler.Clock, scheduler);
            var rpcTask = retryingCallable(new SimpleRequest { Name = name }, callSettings);

            scheduler.Run();

            var firstCall = 0L;
            var secondCall = callDuration + 1000; // Delay for 1000 ticks
            var thirdCall = secondCall + callDuration + 2000; // Delay for 2000 ticks
            var fourthCall = thirdCall + callDuration + 4000; // Delay for 4000 ticks
            var fifthCall = fourthCall + callDuration + 5000; // Delay for 5000 ticks, as that's the max

            server.AssertCallTimes(firstCall, secondCall, thirdCall, fourthCall, fifthCall);
            // Time of last action was when the call returned
            Assert.Equal(fifthCall + callDuration, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);

            Assert.Equal(TaskStatus.RanToCompletion, rpcTask.Status);

            // And the response is propagated
            Assert.Equal(name, rpcTask.Result.Name);
        }

        [Fact]
        public void CallSettingsDeadlineIsObserved()
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
                DelayJitter = RetrySettings.NoJitter
            };

            // Expiration makes it fail while waiting to make third call
            var callSettings = new CallSettings { Expiration = Expiration.FromTimeout(TimeSpan.FromTicks(2500)) };
            var retryingCallable = callable.WithRetry(retrySettings, scheduler.Clock, scheduler);
            var rpcTask = retryingCallable(new SimpleRequest { Name = "irrelevant" }, callSettings);

            scheduler.Run();

            var firstCall = 0L;
            var secondCall = callDuration + 1000;
            server.AssertCallTimes(firstCall, secondCall);

            // We fail immediately when we work out that we would time out before we make the third
            // call - so this is before the actual total timeout.
            Assert.Equal(secondCall + callDuration, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);

            Assert.Equal(TaskStatus.Faulted, rpcTask.Status);
            Assert.IsType<RpcException>(rpcTask.Exception.InnerExceptions[0]);
        }

        [Fact]
        public void ExponentialTimeouts()
        {
            var callDuration = 300;
            var failures = 2;
            var scheduler = new FakeScheduler();
            var server = new Server(failures, callDuration, scheduler);
            var callable = server.Callable;
            var retrySettings = new RetrySettings
            {
                RetryBackoff = ConstantBackoff, // 1500 ticks always
                TimeoutBackoff = DoublingBackoff, // 1000, then 2000, then 3000
                DelayJitter = RetrySettings.NoJitter
            };

            // Expiration truncates the third timeout. We expect:
            // Call 1: t=0, deadline=1000, completes at 300
            // Call 2: t=1800, deadline=3800 (2000+1800), completes at 2100
            // Call 3, t=3600, deadline=4500 (would be 7600, but overall deadline truncates), completes at 3900 (with success)
            var callSettings = new CallSettings { Expiration = Expiration.FromTimeout(TimeSpan.FromTicks(4500)) };
            var retryingCallable = callable.WithRetry(retrySettings, scheduler.Clock, scheduler);
            var rpcTask = retryingCallable(new SimpleRequest { Name = "irrelevant" }, callSettings);

            scheduler.Run();
            server.AssertCallTimes(0L, 1800L, 3600L);
            server.AssertDeadlines(1000L, 3800L, 4500L);

            Assert.Equal(TaskStatus.RanToCompletion, rpcTask.Status);
            Assert.Equal(3900L, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Theory]
        [InlineData(StatusCode.Internal, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded }, false)]
        [InlineData(StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound, StatusCode.DeadlineExceeded }, true)]
        [InlineData(StatusCode.DeadlineExceeded, new[] { StatusCode.NotFound }, false)]
        public void RetryFilter(StatusCode failureCode, StatusCode[] filterCodes, bool expectedToRetry)
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
                RetryFilter = RetrySettings.FilterForStatusCodes(filterCodes)
            };

            var callSettings = new CallSettings { Expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1)) };
            var retryingCallable = server.Callable.WithRetry(retrySettings, scheduler.Clock, scheduler);
            var rpcTask = retryingCallable(new SimpleRequest { Name = "irrelevant" }, callSettings);

            scheduler.Run();

            bool retried = server.CallTimes.Count() > 1;
            Assert.Equal(expectedToRetry, retried);
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

            public async Task<SimpleResponse> Method(SimpleRequest request, CallSettings callSettings)
            {
                CallTimes.Add(scheduler.Clock.GetCurrentDateTimeUtc());
                CallSettingsReceived.Add(callSettings);
                await scheduler.Delay(callDuration);
                if (failuresToReturn > 0)
                {
                    failuresToReturn--;
                    throw new RpcException(new Status(failureCode, "Bang"));
                }
                return new SimpleResponse { Name = request.Name };
            }

            public ApiCallable<SimpleRequest, SimpleResponse> Callable => Method;

            public void AssertCallTimes(params long[] ticks)
            {
                Assert.Equal(ticks, CallTimes.Select(dt => dt.Ticks).ToArray());
            }

            public void AssertDeadlines(params long[] ticks)
            {
                // Note that this effectively asserts we always end up with a CallSettings with a deadline.
                Assert.Equal(ticks, CallSettingsReceived.Select(cs => cs.Expiration.Deadline.Value.Ticks).ToArray());
            }
        }
    }
}
