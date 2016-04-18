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
            public TestSettings()
            {
            }

            private TestSettings(TestSettings existing) : base(existing) { }

            public TestSettings Clone() => new TestSettings(this);
        }

        [Fact]
        public void DefaultToNulls()
        {
            var settings = new TestSettings();
            Assert.Null(settings.CallSettings);
            Assert.Null(settings.Clock);
        }

        [Fact]
        public void Clone()
        {
            var clock = new Mock<IClock>();
            var callSettings = new CallSettings();
            var settings = new TestSettings
            {
                CallSettings = callSettings,
                Clock = clock.Object,
            };
            var clonedSettings = settings.Clone();
            Assert.NotSame(settings, clonedSettings);
            Assert.NotSame(callSettings, clonedSettings.CallSettings);
            Assert.Equal(settings.UserAgent, clonedSettings.UserAgent);
            Assert.Equal(clock.Object, clonedSettings.Clock);
        }

        [Fact]
        public void CloneWithDefaults()
        {
            var settings = new TestSettings();
            var clonedSettings = settings.Clone();
            Assert.Null(clonedSettings.CallSettings);
            Assert.Null(clonedSettings.Clock);
            Assert.Equal(settings.UserAgent, clonedSettings.UserAgent);
        }
    }
}
