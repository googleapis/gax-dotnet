/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class TaskExtensionsTest
    {
        [Fact]
        public void ResultWithUnwrappedException_Faulted()
        {
            var exception = new IOException("Bang");
            var task = TaskFromException<int>(exception);
            var thrown = Assert.Throws<IOException>(() => task.ResultWithUnwrappedExceptions());
            Assert.Same(exception, thrown);
        }

        [Fact]
        public void WaitWithUnwrappedException_Faulted()
        {
            var exception = new IOException("Bang");
            var task = TaskFromException<int>(exception);
            var thrown = Assert.Throws<IOException>(() => task.WaitWithUnwrappedExceptions());
            Assert.Same(exception, thrown);

        }

        [Fact]
        public void ResultWithUnwrappedException_Completed()
        {
            var task = Task.FromResult(10);
            Assert.Equal(10, task.ResultWithUnwrappedExceptions());
        }

        [Fact]
        public void WaitWithUnwrappedException_Completed()
        {
            var task = Task.FromResult(10);
            task.WaitWithUnwrappedExceptions();
        }

        // Task.FromException doesn't exist in .NET 4.5.1 :(
        private static Task<T> TaskFromException<T>(Exception e)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetException(e);
            return tcs.Task;
        }
    }
}
