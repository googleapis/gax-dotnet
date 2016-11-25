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
        // Note: no tests for cancellation at the moment as they're fiendishly difficult to write in a robust way.
        // We need to revisit FakeScheduler yet again...

        [Fact]
        public async Task SimpleDelay()
        {
            var scheduler = new FakeScheduler();
            await scheduler.RunAsync(() => scheduler.Delay(TimeSpan.FromTicks(1000)));
            Assert.Equal(1000, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }
    }
}
