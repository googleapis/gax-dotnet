/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class FakeSchedulerTest
    {
        [Fact]
        public void ScheduleMultipleEvents()
        {
            var scheduler = new FakeScheduler();
            var tcs1 = new TaskCompletionSource<int>();
            var tcs2 = new TaskCompletionSource<int>();
            // The scheduler will start each action at the right fake time, but
            // because nothing is sleeping, we need to be careful to wait until the
            // actions have *finished* before our overall action completes.
            scheduler.Schedule(() => tcs1.SetResult(1), TimeSpan.FromSeconds(1));
            scheduler.Schedule(() => tcs2.SetResult(2), TimeSpan.FromSeconds(2));
            scheduler.Run(() => Task.WaitAll(tcs1.Task, tcs2.Task));
            Assert.Equal(1, tcs1.Task.Result);
            Assert.Equal(2, tcs2.Task.Result);
            Assert.Equal(TimeSpan.FromSeconds(2).Ticks, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Fact]
        public void SynchronousSleep()
        {
            var scheduler = new FakeScheduler();
            scheduler.Run(() => scheduler.Sleep(TimeSpan.FromTicks(1000)));
            Assert.Equal(1000, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }
    }
}
