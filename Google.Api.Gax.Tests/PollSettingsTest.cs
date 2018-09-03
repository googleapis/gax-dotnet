/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class PollSettingsTest
    {
        [Fact]
        public void SuccessfulConstructionConstant()
        {
            var expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var delay = TimeSpan.FromSeconds(2);
            var settings = new PollSettings(expiration, delay);
            Assert.Same(expiration, settings.Expiration);
            Assert.Equal(delay, settings.Delay);
            Assert.Equal(1.0, settings.DelayMultiplier);
            Assert.Equal(delay, settings.MaxDelay);
        }

        [Fact]
        public void SuccessfulConstructionExponential()
        {
            var expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var delay = TimeSpan.FromSeconds(2);
            var maxDelay = TimeSpan.FromSeconds(3);
            var settings = new PollSettings(expiration, delay, 2.0, maxDelay);
            Assert.Same(expiration, settings.Expiration);
            Assert.Equal(delay, settings.Delay);
            Assert.Equal(2.0, settings.DelayMultiplier);
            Assert.Equal(maxDelay, settings.MaxDelay);
        }

        [Fact]
        public void NegativeDelayProhibited()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new PollSettings(Expiration.FromTimeout(TimeSpan.FromSeconds(1)), TimeSpan.FromSeconds(-2)).ToString());
        }

        [Fact]
        public void NullExpirationProhibited()
        {
            Assert.Throws<ArgumentNullException>(() => new PollSettings(null, TimeSpan.FromSeconds(1)).ToString());
        }

        [Fact]
        public void NegativeMaxDelayProhibitied()
        {
            var expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new PollSettings(expiration, TimeSpan.FromSeconds(2), 1.0, TimeSpan.FromSeconds(-2)));
        }

        [Fact]
        public void Sub1MultiplierProhibitied()
        {
            var expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new PollSettings(expiration, TimeSpan.FromSeconds(2), 0.9, TimeSpan.FromSeconds(2)));
        }
    }
}
