/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RetrySettingsTest
    {
        private static BackoffSettings s_sampleBackoff = new BackoffSettings(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

        [Fact]
        public void NullChecking()
        {
            Assert.Throws<ArgumentNullException>(() => new RetrySettings(null, s_sampleBackoff, Expiration.None).ToString());
            Assert.Throws<ArgumentNullException>(() => new RetrySettings(s_sampleBackoff, null, Expiration.None).ToString());
            Assert.Throws<ArgumentNullException>(() => new RetrySettings(s_sampleBackoff, s_sampleBackoff, null).ToString());

            // No exceptions here...
            var settings = new RetrySettings(s_sampleBackoff, s_sampleBackoff, Expiration.None, null);
            settings = new RetrySettings(s_sampleBackoff, s_sampleBackoff, Expiration.None, null, null);
        }
    }
}
