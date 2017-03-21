/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Moq;
using System;
using System.Threading;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ServiceSettingsBaseTest
    {
        class TestSettings : ServiceSettingsBase
        {
            public TestSettings() { }

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
            var callSettings = new CallSettings(new CancellationTokenSource().Token, null, null, null, null, null);
            var settings = new TestSettings
            {
                CallSettings = callSettings,
                Clock = clock.Object,
            };
            var clonedSettings = settings.Clone();
            Assert.NotSame(settings, clonedSettings);
            // CallSettings is immutable, so just a reference copy is fine.
            Assert.Same(callSettings, clonedSettings.CallSettings);
            Assert.Equal(settings.VersionHeader, clonedSettings.VersionHeader);
            Assert.Equal(clock.Object, clonedSettings.Clock);
        }

        [Fact]
        public void CloneWithDefaults()
        {
            var settings = new TestSettings();
            var clonedSettings = settings.Clone();
            Assert.Null(clonedSettings.CallSettings);
            Assert.Null(clonedSettings.Clock);
            Assert.Equal(settings.VersionHeader, clonedSettings.VersionHeader);
        }
    }
}
