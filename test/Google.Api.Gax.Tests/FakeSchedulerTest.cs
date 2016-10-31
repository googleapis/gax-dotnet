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
        public void SynchronousSleep()
        {
            var scheduler = new FakeScheduler();
            scheduler.Run(() => scheduler.Sleep(TimeSpan.FromTicks(1000)));
            Assert.Equal(1000, scheduler.Clock.GetCurrentDateTimeUtc().Ticks);
        }
    }
}
