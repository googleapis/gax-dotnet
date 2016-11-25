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
        public async Task Cancellation()
        {
            var scheduler = new FakeScheduler();
            await scheduler.RunAsync(async () =>
            {
                var cts = new CancellationTokenSource();
                scheduler.ScheduleCancellation(TimeSpan.FromTicks(500), cts);
                var task = scheduler.Delay(TimeSpan.FromTicks(1000), cts.Token);
                await Assert.ThrowsAsync<TaskCanceledException>(() => scheduler.Delay(TimeSpan.FromTicks(1000), cts.Token));
            });
            Assert.Equal(500, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }
    }
}
