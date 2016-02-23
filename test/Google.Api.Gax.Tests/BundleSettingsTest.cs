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
    public class BundleSettingsTest
    {
        [Fact]
        public void DefaultToNulls()
        {
            var settings = new BundleSettings();
            Assert.Null(settings.DelayThreshold);
            Assert.Null(settings.EntryCountThreshold);
            Assert.Null(settings.RequestSizeThreshold);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public void DelayThreshold_Valid(int? minutes)
        {
            TimeSpan? threshold = minutes == null ? default(TimeSpan?) : TimeSpan.FromMinutes(minutes.Value);
            var settings = new BundleSettings { DelayThreshold = threshold };
            Assert.Equal(threshold, settings.DelayThreshold);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void DelayThreshold_Invalid(int minutes)
        {
            TimeSpan? threshold = TimeSpan.FromMinutes(minutes);
            Assert.Throws<ArgumentOutOfRangeException>(() => new BundleSettings { DelayThreshold = threshold });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public void EntryCountThreshold_Valid(int? threshold)
        {
            var settings = new BundleSettings { EntryCountThreshold = threshold };
            Assert.Equal(threshold, settings.EntryCountThreshold);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void EntryCountThreshold_Invalid(int threshold)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new BundleSettings { EntryCountThreshold = threshold });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public void RequestSizeThreshold_Valid(int? threshold)
        {
            var settings = new BundleSettings { RequestSizeThreshold = threshold };
            Assert.Equal(threshold, settings.RequestSizeThreshold);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void RequestSizeThreshold_Invalid(int threshold)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new BundleSettings { RequestSizeThreshold = threshold });
        }

        [Theory]
        [InlineData(1, null, null)]
        [InlineData(null, 1, null)]
        [InlineData(null, null, 1)]
        [InlineData(1, 1, 1)]
        public void Validate_Valid(int? delayThresholdMinutes, int? entryCountThreshold, int? requestSizeThreshold)
        {
            TimeSpan? delayThreshold = delayThresholdMinutes == null ? default(TimeSpan?) : TimeSpan.FromMinutes(delayThresholdMinutes.Value);
            var settings = new BundleSettings
            {
                DelayThreshold = delayThreshold,
                RequestSizeThreshold = requestSizeThreshold,
                EntryCountThreshold = entryCountThreshold
            };
            settings.Validate(nameof(settings));
        }

        [Fact]
        public void Validate_Invalid()
        {
            var settings = new BundleSettings();
            Assert.Throws<ArgumentException>(() => settings.Validate(nameof(settings)));
        }
    }
}
