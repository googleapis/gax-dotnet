/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class BatchingSettingsTest
    {
        [Fact]
        public void SuccessfulConstruction()
        {
            var batching0 = new BatchingSettings(null, null, null);
            Assert.Null(batching0.ElementCountThreshold);
            Assert.Null(batching0.ByteCountThreshold);
            Assert.Null(batching0.DelayThreshold);
            var batching1 = new BatchingSettings(1, 2, TimeSpan.FromSeconds(3));
            Assert.Equal(1, batching1.ElementCountThreshold);
            Assert.Equal(2, batching1.ByteCountThreshold);
            Assert.Equal(TimeSpan.FromSeconds(3), batching1.DelayThreshold);
        }

        [Fact]
        public void UnsuccessfulConstruction()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new BatchingSettings(-1, null, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => new BatchingSettings(null, -1, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => new BatchingSettings(null, null, TimeSpan.FromSeconds(-1)));
        }
    }
}
