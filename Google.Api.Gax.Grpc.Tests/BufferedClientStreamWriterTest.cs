/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class BufferedClientStreamWriterTest
    {
        // Timeout configuration: this test can be flaky in low-CPU environments,
        // e.g. Travis. While we don't want tests to take forever to fail, we do
        // want them to be reliable. These are currently pretty generous.

        // How long we wait for a task to be created in FakeWriter.
        private static readonly TimeSpan s_taskWaitTimeout = TimeSpan.FromSeconds(5);
        // How long we wait for tasks to complete when asserting completion status.
        private static readonly TimeSpan s_completionTimeout = TimeSpan.FromSeconds(3);
        // How long we wait for space in the buffer.
        private static readonly TimeSpan s_waitForSpaceTimeout = TimeSpan.FromSeconds(3);

        [Fact]
        public void CompleteWithNoWrites()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            var completionTask = writer.WriteCompleteAsync();
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(completionTask, TaskStatus.RanToCompletion);
            fake.AssertMessages();
            fake.AssertCompleted();
        }

        [Fact]
        public void TryCompleteWithNoWrites()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            var completionTask = writer.TryWriteCompleteAsync();
            Assert.NotNull(completionTask);
            var impossibleCompletationTask = writer.TryWriteCompleteAsync();
            Assert.Null(impossibleCompletationTask);
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(completionTask, TaskStatus.RanToCompletion);
            fake.AssertMessages();
            fake.AssertCompleted();
        }

        [Fact]
        public void CompleteAfterMessages()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            var task1 = writer.WriteAsync("1");
            var task2 = writer.WriteAsync("2");
            var completionTask = writer.WriteCompleteAsync();
            AssertNotCompleted(task1, task2, completionTask);

            // Server handles first message
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(task1, TaskStatus.RanToCompletion);
            AssertNotCompleted(task2, completionTask);

            // Server handles second message
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(task2, TaskStatus.RanToCompletion);
            AssertNotCompleted(completionTask);

            // Server handles completion
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(completionTask, TaskStatus.RanToCompletion);

            fake.AssertMessages("1", "2");
            fake.AssertCompleted();
        }

        [Fact]
        public void WritesAfterMessagesAreSent()
        {
            // Unlike most other tests, here we write a message, the server completes the
            // task, write another message, server completes etc.

            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);

            // First message
            var task1 = writer.WriteAsync("1");
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(task1, TaskStatus.RanToCompletion);

            // Second message
            var task2 = writer.WriteAsync("2");
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(task2, TaskStatus.RanToCompletion);

            // Completion
            var completionTask = writer.WriteCompleteAsync();
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(completionTask, TaskStatus.RanToCompletion);

            fake.AssertMessages("1", "2");
            fake.AssertCompleted();
        }

        [Fact]
        public void FaultedWriteFailsPendingTasks()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            var task1 = writer.WriteAsync("1");
            var task2 = writer.WriteAsync("2");
            var task3 = writer.WriteAsync("3");
            var completionTask = writer.WriteCompleteAsync();
            AssertNotCompleted(task1, task2, task3, completionTask);

            // Server handles first message successfully
            fake.CompleteCurrentTask();
            AssertCompletedWithStatus(task1, TaskStatus.RanToCompletion);
            AssertNotCompleted(task2, task3, completionTask);

            // Server fails second message. All pending tasks become faulted with the same exception.
            var exception = new Exception("Bang");
            fake.FailCurrentTask(exception);
            foreach (var task in new[] { task2, task3, completionTask })
            {
                AssertCompletedWithStatus(task, TaskStatus.Faulted);
                Assert.Same(exception, task.Exception.InnerExceptions[0]);
            }
        }

        [Fact]
        public void FaultedWriteFailsFutureTasks()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            var task1 = writer.WriteAsync("1");

            // Server fails first message
            var exception = new Exception("Bang");
            fake.FailCurrentTask(exception);

            // Subsequent calls to Write and Complete fail
            var task2 = writer.WriteAsync("2");
            var task3 = writer.WriteAsync("3");
            var completionTask = writer.WriteCompleteAsync();

            foreach (var task in new[] { task1, task2, task3, completionTask })
            {
                AssertCompletedWithStatus(task, TaskStatus.Faulted);
                Assert.Same(exception, task.Exception.InnerExceptions[0]);
            }
        }

        [Fact]
        public void WriteBeyondBuffer()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 2);
            var task1 = writer.WriteAsync("1");
            var task2 = writer.WriteAsync("2");
            // The (object) cast is because to make xUnit understand that the call itself should throw;
            // we don't return a failed task.
            Assert.Throws<InvalidOperationException>(() => (object) writer.WriteAsync("3"));

            fake.CompleteCurrentTask(); // Message 1
            WaitForSpace(writer);

            // Now the buffer is smaller, we can write again.
            var task4 = writer.WriteAsync("4");
            // Completion fails, no space in buffer
            Assert.Throws<InvalidOperationException>(() => (object)writer.WriteCompleteAsync());

            fake.CompleteCurrentTask(); // Message 2
            WaitForSpace(writer);
            // Completion succeeds, there is now space in the buffer.
            var completionTask = writer.WriteCompleteAsync();

            fake.CompleteCurrentTask(); // Message 4
            fake.CompleteCurrentTask(); // Completion

            AssertCompletedWithStatus(task1, TaskStatus.RanToCompletion);
            AssertCompletedWithStatus(task2, TaskStatus.RanToCompletion);
            AssertCompletedWithStatus(task4, TaskStatus.RanToCompletion);
            AssertCompletedWithStatus(completionTask, TaskStatus.RanToCompletion);

            fake.AssertMessages("1", "2", "4");
            fake.AssertCompleted();
        }

        [Fact]
        public void TryWriteBeyondBuffer()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 2);
            var task1 = writer.WriteAsync("1");
            var task2 = writer.WriteAsync("2");
            var task3 = writer.TryWriteAsync("3");
            Assert.Null(task3); // Couldn't write.

            fake.CompleteCurrentTask(); // Message 1
            WaitForSpace(writer);

            // Now the buffer is smaller, we can write again.
            var task4 = writer.TryWriteAsync("4");
            Assert.NotNull(task4);
            // Try to write completion, will fail as buffer is full.
            var completionTask1 = writer.TryWriteCompleteAsync();
            Assert.Null(completionTask1);

            fake.CompleteCurrentTask(); // Message 2
            WaitForSpace(writer);

            // Now the buffer is smaller, we can write completion.
            var completionTask2 = writer.TryWriteCompleteAsync();
            Assert.NotNull(completionTask2);

            fake.CompleteCurrentTask(); // Message 4
            fake.CompleteCurrentTask(); // Completion

            AssertCompletedWithStatus(task1, TaskStatus.RanToCompletion);
            AssertCompletedWithStatus(task2, TaskStatus.RanToCompletion);
            AssertCompletedWithStatus(task4, TaskStatus.RanToCompletion);
            AssertCompletedWithStatus(completionTask2, TaskStatus.RanToCompletion);

            fake.AssertMessages("1", "2", "4");
            fake.AssertCompleted();
        }

        [Fact]
        public void CompletionUsesBufferSpace()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 2);
            writer.WriteAsync("1");
            writer.WriteAsync("2");
            // Try completion, should throw because queue is full.
            // The (object) cast is because to make xUnit understand that the call itself should throw;
            // we don't return a failed task.
            Assert.Throws<InvalidOperationException>(() => (object)writer.WriteCompleteAsync());
            // Try completion, should return null because queue is full.
            Assert.Null(writer.TryWriteCompleteAsync());

            fake.CompleteCurrentTask();
            fake.CompleteCurrentTask();
            writer.WriteCompleteAsync();
            fake.CompleteCurrentTask();
            fake.AssertCompleted();
        }

        [Fact]
        public void BehaviorAfterCompleteCalled()
        {
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            writer.WriteCompleteAsync();

            // The (object) casts are because to make xUnit understand that the call itself should throw;
            // we don't return a failed task.
            Assert.Throws<InvalidOperationException>(() => (object) writer.WriteCompleteAsync());
            Assert.Throws<InvalidOperationException>(() => (object) writer.WriteAsync("x"));
            Assert.Null(writer.TryWriteAsync("y"));
        }

        [Fact]
        public void WriteOptions()
        {
            var options1 = new WriteOptions();
            var options2 = new WriteOptions();

            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 5);
            writer.WriteAsync("1");
            writer.WriteAsync("2", options1);
            writer.WriteAsync("3");
            writer.WriteAsync("4", options2);

            fake.CompleteCurrentTask();
            fake.CompleteCurrentTask();
            fake.CompleteCurrentTask();
            fake.CompleteCurrentTask();
            fake.AssertOptions(null, options1, options1, options2);

            // This should pick up options2 from the writer, not from the queue.
            writer.WriteAsync("5");
            fake.CompleteCurrentTask();
            fake.AssertOptions(null, options1, options1, options2, options2);
        }

        [Fact]
        public async Task AtomicTaskCompletion()
        {
            const int testSize = 100;
            var fake = new FakeWriter();
            var writer = new BufferedClientStreamWriter<string>(fake, 1);
            var msgs = Enumerable.Range(0, testSize).Select(x => x.ToString()).ToArray();
            foreach (var msg in msgs)
            {
                // This write can fail if task completion inside writer is not atomic.
                Task task = writer.WriteAsync(msg);
                fake.CompleteCurrentTask();
                await task.ConfigureAwait(false);
            }
            fake.AssertMessages(msgs);
        }

        /// <summary>
        /// Waits for a limited time for the writer to become non-full.
        /// </summary>
        private void WaitForSpace(BufferedClientStreamWriter<string> writer)
        {
            var stopwatch = Stopwatch.StartNew();
            while (writer.BufferedWriteCount >= writer.Capacity && stopwatch.Elapsed < s_waitForSpaceTimeout)
            {
                Thread.Sleep(100);
            }
            Assert.True(writer.BufferedWriteCount < writer.Capacity, $"Count {writer.BufferedWriteCount} should be less than capacity {writer.Capacity}");
        }

        private void AssertNotCompleted(params Task[] tasks)
        {
            foreach (var task in tasks)
            {
                Assert.False(task.IsCompleted);
            }
        }

        /// <summary>
        /// Waits for up to half a second for the task to complete with the expected status.
        /// </summary>
        private void AssertCompletedWithStatus(Task task, TaskStatus expectedStatus)
        {
            var stopwatch = Stopwatch.StartNew();
            // Sort of like task.Wait(), but without throwing an exception.
            while (!task.IsCompleted && stopwatch.Elapsed < s_completionTimeout)
            {
                Thread.Sleep(100);
            }
            Assert.Equal(expectedStatus, task.Status);
        }

        private class FakeWriter : IClientStreamWriter<string>
        {
            private readonly object _lock = new object();
            private TaskCompletionSource<int> _currentTask;
            private List<string> _messages = new List<string>();
            private List<WriteOptions> _options = new List<WriteOptions>();
            private bool _completeCalled;

            public WriteOptions WriteOptions { get; set; }

            public Task CompleteAsync()
            {
                lock (_lock)
                {
                    Assert.Null(_currentTask);
                    Assert.False(_completeCalled);
                    _completeCalled = true;
                    _currentTask = new TaskCompletionSource<int>();
                    Monitor.PulseAll(_lock);
                    return _currentTask.Task;
                }
            }

            public Task WriteAsync(string message)
            {
                lock (_lock)
                {
                    Assert.Null(_currentTask);
                    Assert.False(_completeCalled);
                    _messages.Add(message);
                    _options.Add(WriteOptions);
                    _currentTask = new TaskCompletionSource<int>();
                    Monitor.PulseAll(_lock);
                    return _currentTask.Task;
                }
            }

            private void WaitForTask()
            {
                lock (_lock)
                {
                    // Allow spurious wakes, unlikely though they are.
                    while (_currentTask == null)
                    {
                        Assert.True(Monitor.Wait(_lock, s_taskWaitTimeout), $"Monitor.Wait timed out");
                    }
                }
            }

            public void CompleteCurrentTask()
            {
                WaitForTask();
                lock (_lock)
                {
                    _currentTask.SetResult(0);
                    _currentTask = null;
                }
            }

            public void FailCurrentTask(Exception exception)
            {
                WaitForTask();
                lock (_lock)
                {
                    _currentTask.SetException(exception);
                    _currentTask = null;
                }
            }

            public void CancelCurrentTask()
            {
                WaitForTask();
                lock (_lock)
                {
                    _currentTask.SetCanceled();
                    _currentTask = null;
                }
            }

            public void AssertMessages(params string[] expectedMessages)
            {
                lock (_lock)
                {
                    Assert.Equal(expectedMessages, _messages);
                }
            }

            public void AssertOptions(params WriteOptions[] expectedOptions)
            {
                lock (_lock)
                {
                    Assert.Equal(expectedOptions, _options);
                }
            }

            public void AssertCompleted()
            {
                lock (_lock)
                {
                    Assert.Null(_currentTask);
                    Assert.True(_completeCalled);
                }
            }
        }
    }
}
