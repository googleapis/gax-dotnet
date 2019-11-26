/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RetrySettingsTest
    {
        [Theory]
        [InlineData(0.0, 1.0)]
        [InlineData(0.75, 1.5)]
        [InlineData(1.0, 2.0)]
        [InlineData(2.0, 4.0)]
        [InlineData(4.0, 5.0)]
        public void NextBackoff(double current, double expectedNext)
        {
            var settings = new RetrySettings(
                maxAttempts: 5,
                initialBackoff: TimeSpan.FromSeconds(1.0),
                maxBackoff: TimeSpan.FromSeconds(5.0),
                backoffMultiplier: 2.0,
                e => true,
                RetrySettings.NoJitter);

            var expected = TimeSpan.FromSeconds(expectedNext);
            var actual = settings.NextBackoff(TimeSpan.FromSeconds(current));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FromConstantBackoff_DefaultJitter()
        {
            var backoff = TimeSpan.FromSeconds(3);
            var filter = RetrySettings.FilterForStatusCodes(StatusCode.Aborted);
            var settings = RetrySettings.FromConstantBackoff(10, backoff, filter);
            Assert.Equal(10, settings.MaxAttempts);
            Assert.Equal(backoff, settings.InitialBackoff);
            Assert.Equal(backoff, settings.MaxBackoff);
            Assert.Same(filter, settings.RetryFilter);
            Assert.Same(RetrySettings.RandomJitter, settings.BackoffJitter);
        }

        [Fact]
        public void FromConstantBackoff_SpecificJitter()
        {
            var backoff = TimeSpan.FromSeconds(3);
            var filter = RetrySettings.FilterForStatusCodes(StatusCode.Aborted);
            var settings = RetrySettings.FromConstantBackoff(10, backoff, filter, RetrySettings.NoJitter);
            Assert.Equal(10, settings.MaxAttempts);
            Assert.Equal(backoff, settings.InitialBackoff);
            Assert.Equal(backoff, settings.MaxBackoff);
            Assert.Equal(1.0, settings.BackoffMultiplier);
            Assert.Same(filter, settings.RetryFilter);
            Assert.Same(RetrySettings.NoJitter, settings.BackoffJitter);
        }

        [Fact]
        public void FromExponentialBackoff_DefaultJitter()
        {
            var initialBackoff = TimeSpan.FromSeconds(3);
            var maxBackoff = TimeSpan.FromSeconds(5);
            var filter = RetrySettings.FilterForStatusCodes(StatusCode.Aborted);
            var settings = RetrySettings.FromExponentialBackoff(10, initialBackoff, maxBackoff, 1.5, filter);
            Assert.Equal(10, settings.MaxAttempts);
            Assert.Equal(initialBackoff, settings.InitialBackoff);
            Assert.Equal(maxBackoff, settings.MaxBackoff);
            Assert.Equal(1.5, settings.BackoffMultiplier);
            Assert.Same(filter, settings.RetryFilter);
            Assert.Same(RetrySettings.RandomJitter, settings.BackoffJitter);
        }

        [Fact]
        public void FromExponentialBackoff_SpecificJitter()
        {
            var initialBackoff = TimeSpan.FromSeconds(3);
            var maxBackoff = TimeSpan.FromSeconds(5);
            var filter = RetrySettings.FilterForStatusCodes(StatusCode.Aborted);
            var settings = RetrySettings.FromExponentialBackoff(10, initialBackoff, maxBackoff, 1.5, filter, RetrySettings.NoJitter);
            Assert.Equal(10, settings.MaxAttempts);
            Assert.Equal(initialBackoff, settings.InitialBackoff);
            Assert.Equal(maxBackoff, settings.MaxBackoff);
            Assert.Equal(1.5, settings.BackoffMultiplier);
            Assert.Same(filter, settings.RetryFilter);
            Assert.Same(RetrySettings.NoJitter, settings.BackoffJitter);
        }
    }
}
