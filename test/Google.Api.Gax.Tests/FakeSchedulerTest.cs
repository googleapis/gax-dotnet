/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int a = 0;
            int b = 0;
            scheduler.Schedule(() => a = 1, TimeSpan.FromSeconds(1));
            scheduler.Schedule(() => b = 2, TimeSpan.FromSeconds(2));
            scheduler.Run();
            Assert.Equal(1, a);
            Assert.Equal(2, b);
        }

        [Fact]
        public void SynchronousSleep()
        {
            var scheduler = new FakeScheduler();
            scheduler.Run<Object>(() =>
            {
                scheduler.Sleep(TimeSpan.FromTicks(1000));
                return null;
            });
            Assert.Equal(1000, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }
    }
}
