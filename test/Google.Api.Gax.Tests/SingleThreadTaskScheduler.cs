/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Tests
{
    /// <summary>
    /// A task scheduler which uses a single new (non-thread-pool) thread, similar to UI event loops.
    /// This is designed to be used for tests which need to ensure that callbacks do or don't have scheduler affinity.
    /// </summary>
    public class SingleThreadTaskScheduler : TaskScheduler
    {
        // Monitor protecting the task queue
        private readonly object _lock = new object();
        // Queued tasks to execute. Would use Queue<T> or ConcurrentQueue<T>, but they don't allow arbitrary removal, required in TryDequeue.
        private readonly LinkedList<Task> _taskQueue = new LinkedList<Task>();

        // Whether to continue processing, or stop. 
        private bool _stopRequested = false;

        private readonly TaskCompletionSource<int> _executionCompletionSource;

        /// <summary>
        /// The thread executing the scheduled tasks.
        /// </summary>
        public Thread ExecutionThread { get; }

        /// <summary>
        /// A task used to allow the equivalent of "JoinAsync" on ExecutionThread. This task
        /// will be completed when the execution thread has stopped.
        /// </summary>
        private Task ExecutionTask => _executionCompletionSource.Task;

        /// <summary>
        /// Constructs a new scheduler, starting a background thread for it to execute tasks on.
        /// </summary>
        /// <param name="caller">The caller to use in the thread name; this will automatically be the
        /// name of the calling member if it is not specified explicitly.</param>
        public SingleThreadTaskScheduler([CallerMemberName] string caller = null)
        {
            _executionCompletionSource = new TaskCompletionSource<int>();
            ExecutionThread = new Thread(Run) { Name = $"SingleThreadTaskScheduler ({caller})", IsBackground = true };
            ExecutionThread.Start();
        }

        /// <summary>
        /// Signals that the scheduler should stop, and returns a task that will complete
        /// when the scheduler thread has stopped. Any previously-scheduled tasks will still execute, although
        /// if they add further continuations, those continuations will not execute.
        /// (Ideally we'd cancel all of those tasks, although it's not clear how we can do so.)
        /// </summary>
        /// <returns>A task that will complete when the scheduler thread has stopped.</returns>
        public Task Stop()
        {
            RunThenStop(() => { });
            return ExecutionTask;
        }

        /// <summary>
        /// Runs the given asynchronous action in the scheduler thread, and then signals that the scheduler should stop.
        /// </summary>
        /// <param name="action">The asynchronous action to run in the scheduler thread.</param>
        /// <returns>A task that will complete when the scheduler thread has stopped.</returns>
        public Task RunThenStop(Func<Task> action)
        {
            // We don't use the result of StartNew, because we don't actually care when this particular
            // task completes.
            new TaskFactory(this).StartNew(async () =>
            {
                try
                {
                    await action();
                }
                finally
                {
                    _stopRequested = true;
                }
            });
            return ExecutionTask;
        }

        /// <summary>
        /// Runs the given action in the scheduler thread, and then signals that the scheduler should stop.
        /// </summary>
        /// <param name="action">The action to run in the scheduler thread.</param>
        /// <returns>A task that will complete when the scheduler thread has stopped.</returns>
        public Task RunThenStop(Action action)
        {
            // We're only constructing a Func<Task> for the sake of convenience here.
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            return RunThenStop(async () => action());
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        }

        /// <summary>
        /// Entry point of the scheduler thread.
        /// </summary>
        private void Run()
        {
            try
            {
                while (!_stopRequested)
                {
                    Task nextTask;
                    lock (_lock)
                    {
                        while (_taskQueue.Count == 0)
                        {
                            Monitor.Wait(_lock);
                        }
                        nextTask = _taskQueue.First.Value;
                        _taskQueue.RemoveFirst();
                    }
                    TryExecuteTask(nextTask);
                }
            }
            catch (Exception e)
            {
                _executionCompletionSource.TrySetException(e);
            }
            finally
            {
                // If TrySetException has already been called, this will silently fail - that's fine.
                _executionCompletionSource.TrySetResult(0);
            }
        }

        /// <summary>
        /// Returns a clone of the current task queue, for use in the debugger.
        /// </summary>
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            List<Task> copy;
            lock (_lock)
            {
                copy = _taskQueue.ToList();
            }
            return copy;
        }

        /// <summary>
        /// Adds the given task to the queue, unless we have been requested to stop.
        /// </summary>
        protected override void QueueTask(Task task)
        {
            lock (_lock)
            {
                // Don't actually die... just ignore the request.
                if (_stopRequested)
                {
                    return;
                }
                _taskQueue.AddLast(task);
                Monitor.Pulse(_lock);
            }
        }

        /// <summary>
        /// Executes the given task inline, if a) the current thread is the scheduler thread, and
        /// b) either the task hasn't been queued or we manage to remove it from the queue.
        /// If those conditions are met, we *try* to execute it - but that could still fail.
        /// </summary>
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
            Thread.CurrentThread == ExecutionThread &&
            (!taskWasPreviouslyQueued || TryDequeue(task)) &&
            TryExecuteTask(task);

        /// <summary>
        /// Removes the given task from the queue, if possible.
        /// </summary>
        protected override bool TryDequeue(Task task)
        {
            lock (_lock)
            {
                return _taskQueue.Remove(task);
            }
        }
    }
}
