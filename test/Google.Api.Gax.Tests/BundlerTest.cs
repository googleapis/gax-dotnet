/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    /// <summary>
    /// Tests for Bundler. There's always room for more, here...
    /// Due to deliberate thread-hopping, this code is somewhat peppered with tasks with small timeouts.
    /// </summary>
    public class BundlerTest
    {
        private static readonly BundleComposer<BundlingRequest, BundlingResponse> s_composer = BundleComposer<BundlingRequest, BundlingResponse>.Create(
            request => request.Name,
            request => request.Entries,
            response => response.Entries);

        [Fact]
        public async Task Simple_OnEntryCount()
        {
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var server = new Server();
            var bundler = CreateBundler(settings, server);
            var task1 = bundler.Call("name", "e1");
            await task1.ShouldNotCompleteWithSmallTimeout();
            Assert.False(server.CallReceived);
            var task2 = bundler.Call("name", "e2", "e3");
            var response1 = await task1.WithSmallTimeout();
            var response2 = await task2.WithSmallTimeout();
            Assert.True(server.CallReceived);

            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e1-r" } }, response1);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e2-r", "e3-r" } }, response2);
        }

        [Fact]
        public async Task Simple_OnMessageSize()
        {
            var firstRequest = new BundlingRequest { Name = "name", Entries = { "e1" } };

            var settings = new BundleSettings { RequestSizeThreshold = firstRequest.CalculateSize() + 1 };
            var server = new Server();
            var bundler = CreateBundler(settings, server);
            var task1 = bundler.Call(firstRequest, CancellationToken.None);
            await task1.ShouldNotCompleteWithSmallTimeout();
            Assert.False(server.CallReceived);
            var task2 = bundler.Call("name", "e2", "e3");
            var response1 = await task1.WithSmallTimeout();
            var response2 = await task2.WithSmallTimeout();
            Assert.True(server.CallReceived);

            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e1-r" } }, response1);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e2-r", "e3-r" } }, response2);
        }

        [Fact]
        public async Task Simple_OnDelay()
        {
            TimeSpan delay = TimeSpan.FromMilliseconds(200); // More than "small timeout"
            var settings = new BundleSettings { DelayThreshold = delay };
            var server = new Server();
            var bundler = CreateBundler(settings, server);
            var task = bundler.Call("name", "e1", "e2");
            await task.ShouldNotCompleteWithSmallTimeout();
            Assert.False(server.CallReceived);
            await Task.Delay(delay);
            var response = await task.WithSmallTimeout();
            Assert.True(server.CallReceived);

            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e1-r", "e2-r" } }, response);
        }

        [Fact]
        public async Task PreFlightCancellation()
        {
            var settings = new BundleSettings { EntryCountThreshold = 3 };
            var server = new Server();
            var tokenSource = new CancellationTokenSource();
            var bundler = CreateBundler(settings, server);
            var task1 = bundler.Call(tokenSource.Token, "name", "e1");
            await task1.ShouldNotCompleteWithSmallTimeout();
            Assert.False(server.CallReceived);
            var task2 = bundler.Call("name", "e2");
            await task1.ShouldNotCompleteWithSmallTimeout();

            // Cancel the first request... after a small delay, the task
            // should be canceled
            tokenSource.Cancel();
            await task2.ShouldNotCompleteWithSmallTimeout();
            Assert.Equal(TaskStatus.Canceled, task1.Status);

            // Adding a third request (two in the bundle) doesn't trigger it
            var task3 = bundler.Call("name", "e3");
            await task3.ShouldNotCompleteWithSmallTimeout();

            // But the fourth does
            var task4 = bundler.Call("name", "e4");
            await task4.WithSmallTimeout();

            Assert.True(server.CallReceived);

            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e2-r" } }, await task2);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e3-r" } }, await task3);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e4-r" } }, await task4);
        }

        [Fact]
        public async Task InFlightCancellation()
        {
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var tokenSource = new CancellationTokenSource();
            var server = new Server { Interceptor = _ => tokenSource.Cancel() };
            var bundler = CreateBundler(settings, server);

            // Send two requests, but cancel one of them before the server has completed the bundled response.
            var task1 = bundler.Call(tokenSource.Token, "name", "e1");
            await task1.ShouldNotCompleteWithSmallTimeout();
            Assert.False(server.CallReceived);
            var task2 = bundler.Call("name", "e2");            
            
            // The cancellation request is basically ignored, because the request has left the building.
            await task2.WithSmallTimeout();
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e1-r" } }, await task1);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e2-r" } }, await task2);
        }

        [Fact]
        public async Task Partitioning()
        {
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var server = new Server();
            var bundler = CreateBundler(settings, server);

            var task1 = bundler.Call("name1", "e11");
            var task2 = bundler.Call("name2", "e21");
            await task1.ShouldNotCompleteWithSmallTimeout();

            var task3 = bundler.Call("name1", "e12");
            await task1.WithSmallTimeout();

            // Task2 is still waiting for a second entry...
            await task2.ShouldNotCompleteWithSmallTimeout();

            Assert.Equal(new BundlingResponse { Name = "name1-r", Entries = { "e11-r" } }, await task1);
            Assert.Equal(new BundlingResponse { Name = "name1-r", Entries = { "e12-r" } }, await task3);
        }

        [Fact]
        public async Task InFlightNewBundle()
        {
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var server = new Server();
            var bundler = CreateBundler(settings, server);
            Task<BundlingResponse> task3 = null;
            server.Interceptor = callIndex =>
            {
                if (callIndex == 0) // First call only
                {
                    task3 = bundler.Call("name", "e3");
                }
            };
            var task1 = bundler.Call("name", "e1");
            var task2 = bundler.Call("name", "e2");
            await task1.WithSmallTimeout();

            await task3.ShouldNotCompleteWithSmallTimeout();
            var task4 = bundler.Call("name", "e4");

            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e1-r" } }, await task1);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e2-r" } }, await task2);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e3-r" } }, await task3);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e4-r" } }, await task4);
        }

        [Fact]
        public async Task MultipleBundlesInFlightAtOnce()
        {
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var server = new Server();
            var bundler = CreateBundler(settings, server);
            Task<BundlingResponse> task3 = null;
            Task<BundlingResponse> task4 = null;
            server.Interceptor = callIndex =>
            {
                if (callIndex == 0) // First call only
                {
                    task3 = bundler.Call("name", "e3");
                    task4 = bundler.Call("name", "e4");
                }
            };
            var task1 = bundler.Call("name", "e1");
            var task2 = bundler.Call("name", "e2");
            await task1.WithSmallTimeout();
            await task3.WithSmallTimeout();

            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e1-r" } }, await task1);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e2-r" } }, await task2);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e3-r" } }, await task3);
            Assert.Equal(new BundlingResponse { Name = "name-r", Entries = { "e4-r" } }, await task4);
        }

        [Fact]
        public async Task SchedulerIsSingleThread()
        {
            var scheduler = new SingleThreadTaskScheduler();
            await scheduler.RunThenStop(async () =>
            {
                await Task.Yield();
            });
        }

        [Fact]
        public async Task ImmediateCompletedTask()
        {
            var settings = new BundleSettings { EntryCountThreshold = 1 };
            var response = new BundlingResponse { Name = "name-r", Entries = { "e1-r" } };
            var bundler = CreateBundler(settings, response);
            var scheduler = new SingleThreadTaskScheduler();
            await scheduler.RunThenStop(async () =>
            {
                var task1 = bundler.Call("name", "e1");
                await task1.WithSmallTimeout().ConfigureAwait(false);
                Assert.Equal(response, await task1);
            });
        }

        // This is an explanatory test more than a requirement. It shows that sometimes, we make the
        // full API call in the calling thread (as if we weren't bundling).
        [Fact]
        public async Task ImmediateEntryCountSendIsOnSameThread()
        {
            var settings = new BundleSettings { EntryCountThreshold = 1 };
            var scheduler = new SingleThreadTaskScheduler();
            var response = new BundlingResponse { Name = "name-r", Entries = { "e1-r" } };
            var bundler = CreateBundler(settings, (req, token) =>
            {
                Assert.Same(scheduler.ExecutionThread, Thread.CurrentThread);
                return Task.FromResult(response);
            });
            await scheduler.RunThenStop(async () =>
            {
                var task1 = bundler.Call("name", "e1");
                await task1.WithSmallTimeout().ConfigureAwait(false);
                Assert.Equal(response, await task1);
            });
        }

        [Fact]
        public async Task ImmediateEntryCountSendIsOutsideLock()
        {
            var settings = new BundleSettings { EntryCountThreshold = 1 };
            var scheduler = new SingleThreadTaskScheduler();
            var response = new BundlingResponse { Name = "name-r", Entries = { "e1-r" } };
            // Separate declaration so we can use bundler inside the action...
            Bundler<BundlingRequest, BundlingResponse> bundler = null;
            bundler = CreateBundler(settings, (req, token) =>
            {
                Assert.Same(scheduler.ExecutionThread, Thread.CurrentThread);
                Assert.False(bundler.InsideLock());
                return Task.FromResult(response);
            });
            await scheduler.RunThenStop(async () =>
            {
                var task1 = bundler.Call("name", "e1");
                await task1.WithSmallTimeout().ConfigureAwait(false);
                Assert.Equal(response, await task1);
            });
        }

        [Fact]
        public async Task ScheduledSendUsesThreadPool()
        {
            var settings = new BundleSettings { DelayThreshold = TimeSpan.FromTicks(1) };
            var scheduler = new SingleThreadTaskScheduler();
            var response = new BundlingResponse { Name = "name-r", Entries = { "e1-r" } };
            // Separate declaration so we can use bundler inside the action...
            Bundler<BundlingRequest, BundlingResponse> bundler = null;
            bundler = CreateBundler(settings, (req, token) =>
            {
                Assert.NotSame(scheduler.ExecutionThread, Thread.CurrentThread);
                Assert.False(bundler.InsideLock());
                return Task.FromResult(response);
            });
            await scheduler.RunThenStop(async () =>
            {
                var task1 = bundler.Call("name", "e1");
                await task1.WithSmallTimeout().ConfigureAwait(false);
                Assert.Equal(response, await task1);
            });
        }

        [Fact]
        public async Task AlreadyCancelledToken_ReturnsCancelledTask()
        {
            var scheduler = new SingleThreadTaskScheduler();
            var tokenSource = new CancellationTokenSource();
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var bundler = CreateBundler(settings, new Server());
            await scheduler.RunThenStop(() =>
            {
                tokenSource.Cancel();
                var task1 = bundler.Call(tokenSource.Token, "name", "e1");
                Assert.Equal(TaskStatus.Canceled, task1.Status);
            });
        }

        [Fact]
        public async Task SingleRequestTriggersSendButAlreadyCancelled()
        {
            var scheduler = new SingleThreadTaskScheduler();
            var tokenSource = new CancellationTokenSource();
            var server = new Server();
            var settings = new BundleSettings { EntryCountThreshold = 1 };
            var bundler = CreateBundler(settings, server);
            await scheduler.RunThenStop(() =>
            {
                tokenSource.Cancel();
                var task1 = bundler.Call(tokenSource.Token, "name", "e1");
                Assert.Equal(TaskStatus.Canceled, task1.Status);
                Assert.False(server.CallReceived);
            });
        }

        [Fact]
        public async Task CancellationTokenCallbackNotInLock_CancellationAfterRequest()
        {
            var scheduler = new SingleThreadTaskScheduler();
            var tokenSource = new CancellationTokenSource();
            var settings = new BundleSettings { EntryCountThreshold = 2 };
            var bundler = CreateBundler(settings, new Server());
            await scheduler.RunThenStop(async () =>
            {
                var task1 = bundler.Call(tokenSource.Token, "name", "e1");
                var assertion = task1.ContinueWith(task => Assert.False(bundler.InsideLock()), TaskContinuationOptions.ExecuteSynchronously);
                tokenSource.Cancel();
                await task1.ShouldBeCancelledWithinSmallTimout();
                await assertion;
            });
        }

        private static Bundler<BundlingRequest, BundlingResponse> CreateBundler(
            BundleSettings settings,
            BundlingResponse response)
        {
            return CreateBundler(settings, (request, token) => Task.FromResult(response));
        }

        private static Bundler<BundlingRequest, BundlingResponse> CreateBundler(
            BundleSettings settings,
            Server server)
        {
            return CreateBundler(settings, server.Call);
        }

        private static Bundler<BundlingRequest, BundlingResponse> CreateBundler(
            BundleSettings settings,
            ApiCallable<BundlingRequest, BundlingResponse> callable)
        {
            return new Bundler<BundlingRequest, BundlingResponse>(settings, s_composer, callable);
        }


        private class Server
        {
            internal bool CallReceived { get; set; }
            private int callsReceived;
            internal Action<int> Interceptor { get; set; } = callIndex => { };

            public async Task<BundlingResponse> Call(BundlingRequest request, CancellationToken cancellationToken)
            {
                var callIndex = Interlocked.Increment(ref callsReceived) - 1;
                CallReceived = true;
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Yield();
                Interceptor(callIndex);
                return new BundlingResponse
                {
                    Name = request.Name + "-r",
                    Entries = { request.Entries.Select(x => x + "-r") }
                };
            }
        }
    }

    internal static class BundlerExtensions
    {
        internal static Task<BundlingResponse> Call(this Bundler<BundlingRequest, BundlingResponse> bundler, string name, params string[] entries)
        {
            return Call(bundler, CancellationToken.None, name, entries);
        }

        internal static Task<BundlingResponse> Call(this Bundler<BundlingRequest, BundlingResponse> bundler, CancellationToken cancellationToken, string name, params string[] entries)
        {
            return bundler.Call(new BundlingRequest { Name = name, Entries = { entries } }, cancellationToken);
        }
    }

    internal static class TaskExtensions
    {
        private static readonly TimeSpan SmallTimeout = TimeSpan.FromMilliseconds(50);

        /// <summary>
        /// Returns a task which will complete with the response of the original task,
        /// expecting it to complete "shortly", i.e. by the time you call this you're only
        /// waiting for context switching etc, not for any other timeouts.
        /// </summary>
        internal static Task<T> WithSmallTimeout<T>(this Task<T> task)
        {
            return task.WithTimeout(SmallTimeout);
        }

        /// <summary>
        /// The inverse of WithSmallTimeout... used to validate that not only
        /// has the task not completed yet, but it's really waiting for something else to happen.
        /// </summary>
        internal static async Task ShouldNotCompleteWithSmallTimeout(this Task task)
        {
            var delay = Task.Delay(SmallTimeout);
            if (await Task.WhenAny(delay, task) == task)
            {
                throw new Exception("Task completed unexpectedly");
            }
        }

        internal static async Task ShouldBeCancelledWithinSmallTimout<T>(this Task<T> task)
        {
            var delay = Task.Delay(SmallTimeout);
            Assert.Same(task, await Task.WhenAny(delay, task));
            Assert.Equal(TaskStatus.Canceled, task.Status);
        }


        internal static async Task<T> WithTimeout<T>(this Task<T> task, TimeSpan timeout)
        {
            var delay = Task.Delay(timeout);
            if (await Task.WhenAny(delay, task) != task)
            {
                throw new TimeoutException("Task timed out");
            }
            return task.Result;
        }
    }

}
