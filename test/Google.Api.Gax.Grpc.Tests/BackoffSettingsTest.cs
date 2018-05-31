/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class BackoffSettingsTest
    {
        [Theory]
        [InlineData(0.0, 1.0)]
        [InlineData(0.75, 1.5)]
        [InlineData(1.0, 2.0)]
        [InlineData(2.0, 4.0)]
        [InlineData(4.0, 5.0)]
        public void NextDelay(double current, double expectedNext)
        {
            var settings = new BackoffSettings(
                delay: TimeSpan.FromSeconds(1.0),
                maxDelay: TimeSpan.FromSeconds(5.0),
                delayMultiplier: 2.0);

            var expected = TimeSpan.FromSeconds(expectedNext);
            var actual = settings.NextDelay(TimeSpan.FromSeconds(current));
            Assert.Equal(expected, actual);
        }
    }
}
