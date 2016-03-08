/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Moq;
using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class ServiceSettingsBaseTest
    {
        class TestSettings : ServiceSettingsBase
        {
            public TestSettings Clone()
            {
                return CloneInto(new TestSettings());
            }
        }

        [Fact]
        public void DefaultToNulls()
        {
            var settings = new TestSettings();
            Assert.Null(settings.Timeout);
            Assert.Null(settings.Clock);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        public void Timeout_Valid(int? millis)
        {
            var timeout = millis == null ? default(TimeSpan?) : TimeSpan.FromMilliseconds(millis.Value);
            var settings = new TestSettings { Timeout = timeout };
            Assert.Equal(timeout, settings.Timeout);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Timeout_Invalid(int? millis)
        {
            var timeout = millis == null ? default(TimeSpan?) : TimeSpan.FromMilliseconds(millis.Value);
            Assert.Throws<ArgumentOutOfRangeException>(() => new TestSettings { Timeout = timeout });
        }

        [Fact]
        public void Clone()
        {
            var clock = new Mock<IClock>();
            var timeout = TimeSpan.FromSeconds(1);
            var settings = new TestSettings
            {
                Timeout = timeout,
                Clock = clock.Object,
            };
            var clonedSettings = settings.Clone();
            Assert.NotSame(settings, clonedSettings);
            Assert.Equal(timeout, clonedSettings.Timeout);
            Assert.Equal(clock.Object, clonedSettings.Clock);
        }

    }
}
