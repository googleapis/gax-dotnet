/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class PollSettingsTest
    {
        [Fact]
        public void CloneIsDeep()
        {
            var callSettings = new CallSettings();

            var pollSettings = new PollSettings(Expiration.None, TimeSpan.Zero, callSettings);
            var cloned = pollSettings.Clone();

            cloned.CallSettings.CancellationToken = CancellationToken.None;

            // Check that it really has stuck...
            Assert.NotNull(cloned.CallSettings.CancellationToken);
            // ... but hasn't affected the original call settings
            Assert.Null(callSettings.CancellationToken);
        }
    }
}
