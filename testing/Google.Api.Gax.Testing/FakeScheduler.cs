/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Testing
{
    /// <summary>
    /// Experimental - please read reamarks. Fake implementation of <see cref="IScheduler" />, designed to work with
    /// <see cref="FakeClock"/>.
    /// </summary>
    /// <remarks>
    /// This class is currently hard to use robustly, and cancellation in particular is hard.
    /// The API and behavior may change in future versions without a major version bump - in other words,
    /// this is not considered part of the stable API of the package.
    /// </remarks>
    public sealed class FakeScheduler : IScheduler
    {
        /// <summary>
        /// How long the scheduler can run in real time before timing out.
        /// </summary>
        public TimeSpan RealTimeTimeout { get; set; } = TimeSpan.FromSeconds(10);
        /// <summary>
        /// How long the scheduler can run in simulated time before timing out.
        /// </summary>
        private TimeSpan SimulatedTimeTimeout { get; set; } = TimeSpan.FromDays(10);

        /// <summary>
        /// The clock associated with this scheduler. The clock is advanced as the scheduler runs.
        /// </summary>
        public FakeClock Clock { get; }

        private readonly object _monitor = new object();
        private LinkedList<DelayTimer> _actions = new LinkedList<DelayTimer>();
        private bool _stopped;

        /// <summary>
        /// Constructs a fake scheduler which works with the given clock.
        /// </summary>
        /// <param name="clock">Fake clock to observe for timing purposes.</param>
        public FakeScheduler(FakeClock clock)
        {
            Clock = GaxPreconditions.CheckNotNull(clock, nameof(clock));
        }

        /// <summary>
        /// Constructs a fake scheduler with a new fake clock starting at 0 ticks.
        /// </summary>
        public FakeScheduler() : this(new FakeClock(0L))
        {
        }

        // Defaulting cancellation token makes it simpler to use for some tests.
        /// <inheritdoc />
        public Task Delay(TimeSpan delay, CancellationToken cancellationToken = default(CancellationToken)) =>
            AddTimer(Clock.GetCurrentDateTimeUtc() + delay, cancellationToken);

        /// <summary>
        /// Specialization of <see cref="Run{T}(Func{T})"/> for tasks, to prevent a common usage error.
        /// </summary>
        /// <remarks>
        /// If you pass in a delegate which returns a task, that's almost always because you want to run it
        /// until that task completes - which is what <see cref="RunAsync(Func{Task})"/> does.
        /// </remarks>
        /// <param name="taskProvider">A task provider.</param>
        [Obsolete("Use RunAsync to run a function returning a task", true)]
        public void Run(Func<Task> taskProvider)
        {
            throw new InvalidOperationException("Use RunAsync to run a function returning a task");
        }

        /// <summary>
        /// Specialization of <see cref="Run{T}(Func{T})"/> for tasks, to prevent a common usage error.
        /// </summary>
        /// <remarks>
        /// If you pass in a delegate which returns a task, that's almost always because you want to run it
        /// until that task completes - which is what <see cref="RunAsync{T}(Func{Task{T}})"/> does.
        /// </remarks>
        /// <param name="taskProvider">A task provider.</param>
        [Obsolete("Use RunAsync to run a function returning a task", true)]
        public void Run<T>(Func<Task<T>> taskProvider)
        {
            throw new InvalidOperationException("Use RunAsync to run a function returning a task");
        }

        /// <summary>
        /// <para>
        /// Invokes the given action in a separate thread, and then runs the scheduler until one of four conditions is met:
        /// </para>
        /// <list type="bullet">
        ///   <item>The action completes successfully</item>
        ///   <item>The action completes with an exception</item>
        ///   <item><see cref="RealTimeTimeout"/> of real time has elapsed</item>
        ///   <item><see cref="SimulatedTimeTimeout"/> of simulated time has elapsed</item>
        /// </list>
        /// <para>
        /// Only the first of these results in the method completing normally; otherwise, an exception is thrown.
        /// If the action completes with an exception, that exception is the result of the method.
        /// If the action has effectively hung, the thread is not terminated; it is expected that the test will
        /// fail without the broken method causing any more harm.
        /// </para>
        /// </summary>
        /// <exception cref="SchedulerTimeoutException">The scheduler timed out.</exception>
        /// <param name="action">The action to execute with the scheduler.</param>
        public void Run(Action action) => Run(() => { action(); return 1; });

        /// <summary>
        /// <para>
        /// Invokes the given action in a separate thread, and then runs the scheduler until one of four conditions is met:
        /// </para>
        /// <list type="bullet">
        ///   <item>The action completes successfully</item>
        ///   <item>The action completes with an exception</item>
        ///   <item><see cref="RealTimeTimeout"/> of real time has elapsed</item>
        ///   <item><see cref="SimulatedTimeTimeout"/> of simulated time has elapsed</item>
        /// </list>
        /// <para>
        /// Only the first of these results in the method completing normally; otherwise, an exception is thrown.
        /// If the action completes with an exception, that exception is the result of the method.
        /// If the action has effectively hung, the thread is not terminated; it is expected that the test will
        /// fail without the broken method causing any more harm.
        /// </para>
        /// </summary>
        /// <exception cref="SchedulerTimeoutException">The scheduler timed out.</exception>
        /// <param name="func">The function to execute with the scheduler.</param>
        public T Run<T>(Func<T> func) => RunAsync(() => Task.FromResult(func())).Result;

        /// <summary>
        /// <para>
        /// Invokes the given action in a separate thread, and then runs the scheduler until one of four conditions is met:
        /// </para>
        /// <list type="bullet">
        ///   <item>The action completes successfully</item>
        ///   <item>The action completes with an exception</item>
        ///   <item><see cref="RealTimeTimeout"/> of real time has elapsed</item>
        ///   <item><see cref="SimulatedTimeTimeout"/> of simulated time has elapsed</item>
        /// </list>
        /// <para>
        /// Only the first of these results in the method completing normally; otherwise, an exception is thrown.
        /// If the action completes with an exception, that exception is the result of the method.
        /// If the action has effectively hung, the thread is not terminated; it is expected that the test will
        /// fail without the broken method causing any more harm.
        /// </para>
        /// </summary>
        /// <exception cref="SchedulerTimeoutException">The scheduler timed out.</exception>
        /// <param name="taskProvider">A delegate providing an asynchronous action to execute with the scheduler.</param>
        public Task RunAsync(Func<Task> taskProvider) => RunAsync(async () => { await taskProvider().ConfigureAwait(false); return 0; });

        /// <summary>
        /// Runs a task in a separate thread, and the scheduler alongside it to simulate sleeping and delaying.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The task provider is run in a separate thread, so that even synchronous task providers (e.g. using 
        /// <see cref="Task.FromResult{TResult}(TResult)"/>) work appropriately. The scheduler is run
        /// until one of four conditions is met:
        /// </para>
        /// <list type="bullet">
        ///   <item>The task completes successfully</item>
        ///   <item>The task completes with an exception</item>
        ///   <item><see cref="RealTimeTimeout"/> of real time has elapsed</item>
        ///   <item><see cref="SimulatedTimeTimeout"/> of simulated time has elapsed</item>
        /// </list>
        /// <para>
        /// Only the first of these results in the method completing normally; otherwise, an exception is thrown.
        /// If the task completes with an exception, that exception is the result of the method.
        /// If the task has effectively hung, the thread is not terminated; it is expected that the test will
        /// fail without the broken method causing any more harm.
        /// </para>
        /// </remarks>
        /// <exception cref="SchedulerTimeoutException">The scheduler timed out.</exception>
        /// <param name="taskProvider">A delegate providing an asynchronous function to execute with the scheduler.</param>
        public async Task<T> RunAsync<T>(Func<Task<T>> taskProvider)
        {
            var funcTask = Task.Run(taskProvider);
            var simulatedTimeTask = StartLoopAsync(Clock.GetCurrentDateTimeUtc() + SimulatedTimeTimeout);
            var delayTask = Task.Delay(RealTimeTimeout);
            var completedTask = await Task.WhenAny(funcTask, simulatedTimeTask, delayTask).ConfigureAwait(false);
            lock (_monitor)
            {
                _stopped = true;
                Monitor.PulseAll(_monitor);
            }
            if (completedTask == funcTask)
            {
                return await funcTask.ConfigureAwait(false);
            }
            else if (completedTask == delayTask)
            {
                throw new SchedulerTimeoutException("Real time time-out; deadlock in user code?");
            }
            else if (completedTask == simulatedTimeTask)
            {
                throw new SchedulerTimeoutException("Simulated time time-out; busy loop in user code?");
            }
            else
            {
                throw new InvalidOperationException($"Unexpected return value from Task.WhenAny - none of the expected tasks");
            }
        }

        private Task StartLoopAsync(DateTime simulatedTimeout)
        {
            return Task.Run(() =>
            {
                // Make sure that if real time elapses, the delay task completes first.
                TimeSpan monitorTimeout = RealTimeTimeout + TimeSpan.FromSeconds(2);
                while (Clock.GetCurrentDateTimeUtc() < simulatedTimeout)
                {
                    DelayTimer next;
                    lock (_monitor)
                    {
                        while (!_stopped && _actions.Count == 0)
                        {
                            if (!Monitor.Wait(_monitor, monitorTimeout))
                            {
                                // The test will already have failed by now.
                                return;
                            }
                        }
                        // Test completed already (not necessarily successfully)
                        if (_stopped)
                        {
                            return;
                        }
                        next = _actions.First.Value;
                        _actions.RemoveFirst();
                    }
                    // Ignore cancelled tasks. (They can't be faulted or run to completion yet.)
                    if (!next.CompletionSource.Task.IsCanceled)
                    {
                        Clock.AdvanceTo(next.ScheduledTime);
                        next.CompletionSource.SetResult(0);
                    }
                }
            });
        }

        private void WaitForCancellationPropagation()
        {
        }
        
        private Task AddTimer(DateTime scheduledTime, CancellationToken cancellationToken)
        {
            var timer = new DelayTimer(scheduledTime, new TaskCompletionSource<int>(), cancellationToken);

            lock (_monitor)
            {
                var node = _actions.First;
                while (node != null)
                {
                    if (node.Value.ScheduledTime > scheduledTime)
                    {
                        _actions.AddBefore(node, timer);
                        break;
                    }
                    node = node.Next;
                }
                if (node == null)
                {
                    _actions.AddLast(timer);
                }
                Monitor.PulseAll(_monitor);
            }
            return timer.CompletionSource.Task;
        }

        private sealed class DelayTimer
        {
            internal DateTime ScheduledTime { get; }
            internal TaskCompletionSource<int> CompletionSource { get; }

            internal DelayTimer(DateTime scheduledTime, TaskCompletionSource<int> tcs, CancellationToken cancellationToken)
            {
                ScheduledTime = scheduledTime;
                CompletionSource = tcs;
                if (cancellationToken.CanBeCanceled)
                {
                    cancellationToken.Register(() => CompletionSource.TrySetCanceled());
                }
            }
        }

        /// <summary>
        /// Exception designed not to be caught by tests (which may deliberately expect a timeout of another kind, for example).
        /// This exception indicates that the scheduler timed out either in simulated time (e.g. a busy loop with a condition
        /// never being satisfied) or in wall time (e.g. user code was waiting for a task which was never going to complete, due
        /// to a deadlock).
        /// </summary>
        public sealed class SchedulerTimeoutException : Exception
        {
            /// <summary>
            /// Constructs a new exception with the given message.
            /// </summary>
            /// <param name="message">Message for the exception.</param>
            public SchedulerTimeoutException(string message) : base(message)
            {
            }
        }
    }
}
