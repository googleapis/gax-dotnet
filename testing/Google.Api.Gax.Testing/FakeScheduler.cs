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
    /// Fake implementation of <see cref="IScheduler" />, designed to work with
    /// <see cref="FakeClock"/>.
    /// </summary>
    public sealed class FakeScheduler : IScheduler
    {
        // TODO: If we can possibly remove this, we should do so. As we expect a lot of things to involve
        // asynchrony, that's tricky. This could easily end up as a source of flakiness.
        private static readonly TimeSpan PauseTime = TimeSpan.FromMilliseconds(100);

        /// <summary>
        /// The clock associated with this scheduler. The clock is advanced as the scheduler runs.
        /// </summary>
        public FakeClock Clock { get; }

        private readonly object _monitor = new object();
        private LinkedList<ScheduledAction> _actions = new LinkedList<ScheduledAction>();

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

        /// <inheritdoc />
        public Task Delay(TimeSpan delay)
        {
            var tcs = new TaskCompletionSource<int>();
            return Schedule(() => tcs.SetResult(0), delay);
        }

        /// <inheritdoc />
        public Task Schedule(Action action, TimeSpan delay)
        {
            var tcs = new TaskCompletionSource<int>();
            AddScheduledAction(new ScheduledAction(action, Clock.GetCurrentDateTimeUtc() + delay, tcs));
            return tcs.Task;
        }

        private void AddScheduledAction(ScheduledAction scheduledAction)
        {
            lock (_monitor)
            {
                var node = _actions.First;
                while (node != null)
                {
                    if (node.Value.ScheduledTime > scheduledAction.ScheduledTime)
                    {
                        _actions.AddBefore(node, scheduledAction);
                        break;
                    }
                }
                if (node == null)
                {
                    _actions.AddLast(scheduledAction);
                }
            }
        }

        /// <summary>
        /// Shorthand method for "run for a logical day". See <see cref="RunUntil(DateTime)"/> for details.
        /// </summary>
        public void Run() => RunFor(TimeSpan.FromDays(1));

        /// <summary>
        /// Runs the scheduler for the given time. See <see cref="RunUntil(DateTime)"/> for details.
        /// </summary>
        /// <param name="timeout">How long to run the scheduler for.</param>
        public void RunFor(TimeSpan timeout) => RunUntil(Clock.GetCurrentDateTimeUtc() + timeout);

        /// <summary>
        /// Runs the scheduler until the given deadline.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The deadline is primarily to guard against any bugs in production code or tests
        /// causing infinite loops. It's still possible, but this helps to reduce the likelihood.
        /// </para>
        /// <para>
        /// The scheduler maintains a queue of scheduled tasks (including "complete a delaying task")
        /// and moves through that queue, executing the tasks as it goes. As tasks are expected to schedule
        /// new tasks, but they're executed on the threadpool, the scheduler pauses for a short period
        /// after each scheduled task to allow the system to go back to an "idle" state before next consulting the
        /// queue.
        /// </para>
        /// <para>
        /// This method returns when either the deadline has been reached, or the scheduler queue is empty.
        /// </para>
        /// </remarks>
        /// <param name="deadline">Logical deadline to run the scheduler until.</param>
        public void RunUntil(DateTime deadline)
        {
            GaxPreconditions.CheckArgument(deadline.Kind == DateTimeKind.Utc, nameof(deadline), "Deadline must have a Kind of Utc");
            while (Clock.GetCurrentDateTimeUtc() < deadline)
            {
                ScheduledAction next;
                lock (_monitor)
                {
                    if (_actions.Count == 0)
                    {
                        return;
                    }
                    next = _actions.First.Value;
                    _actions.RemoveFirst();
                }
                Clock.AdvanceTo(next.ScheduledTime);
                Task.Run(next.Action);
                next.CompletionSource.SetResult(0);
                // Give the scheduled tasks time to complete. This is horrible, but
                // hard to avoid given the nature of tasks executing on the threadpool.
                // TODO: If nothing else, we could execute all the co-scheduled tasks together before pausing...
                Thread.Sleep(PauseTime);
            }
        }        

        private sealed class ScheduledAction
        {
            internal Action Action { get; }
            internal DateTime ScheduledTime { get; }
            internal TaskCompletionSource<int> CompletionSource { get; }

            internal ScheduledAction(Action action, DateTime scheduledTime, TaskCompletionSource<int> tcs)
            {
                Action = action;
                ScheduledTime = scheduledTime;
                CompletionSource = tcs;
            }
        }
    }
}
