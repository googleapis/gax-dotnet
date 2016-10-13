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
        public void SuccessfulConstruction()
        {
            var expiration = Expiration.FromTimeout(TimeSpan.FromSeconds(1));
            var delay = TimeSpan.FromSeconds(2);
            var settings = new PollSettings(expiration, delay);
            Assert.Same(expiration, settings.Expiration);
            Assert.Equal(delay, settings.Delay);
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
    }
}
