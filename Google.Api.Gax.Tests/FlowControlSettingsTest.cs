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
    public class FlowControlSettingsTest
    {
        [Fact]
        public void SuccessfulConstruction()
        {
            var flow0 = new FlowControlSettings(null, null);
            Assert.Null(flow0.MaxOutstandingElementCount);
            Assert.Null(flow0.MaxOutstandingByteCount);
            var flow1 = new FlowControlSettings(1, 2);
            Assert.Equal(1, flow1.MaxOutstandingElementCount);
            Assert.Equal(2, flow1.MaxOutstandingByteCount);
        }

        [Fact]
        public void UnsuccessfulConstruction()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FlowControlSettings(-1, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => new FlowControlSettings(null, -1));
        }
    }
}
