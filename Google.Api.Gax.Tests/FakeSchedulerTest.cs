/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class FakeSchedulerTest
    {
        [Fact]
        public async Task SimpleDelay()
        {
            var scheduler = new FakeScheduler();
            await scheduler.RunAsync(() => scheduler.Delay(TimeSpan.FromTicks(1000)));
            Assert.Equal(1000, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }

        [Fact]
        public async Task CancelDelay()
        {
            var scheduler = new FakeScheduler();
            var time0 = scheduler.Clock.GetCurrentDateTimeUtc();
            var cts = new CancellationTokenSource();
            Task task = scheduler.RunAsync(async () =>
            {
                var unused = Task.Run(async () =>
                {
                    await scheduler.Delay(TimeSpan.FromSeconds(1));
                    cts.Cancel();
                });
                await scheduler.Delay(TimeSpan.FromSeconds(2), cts.Token);
            });
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            Assert.True(cts.IsCancellationRequested);
            Assert.Equal(time0 + TimeSpan.FromSeconds(1), scheduler.Clock.GetCurrentDateTimeUtc());
        }
    }
}
