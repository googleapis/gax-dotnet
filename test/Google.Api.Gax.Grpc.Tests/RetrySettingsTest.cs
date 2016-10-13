using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RetrySettingsTest
    {
        [Fact]
        public void InvalidWithoutRetryBackoff()
        {
            var retrySettings = new RetrySettings
            {
                TimeoutBackoff = new BackoffSettings()
            };
            Assert.Throws<ArgumentException>(() =>
                retrySettings.Validate(""));
        }

        [Fact]
        public void InvalidWithoutTimeoutBackoff()
        {
            var retrySettings = new RetrySettings
            {
                RetryBackoff = new BackoffSettings()
            };
            Assert.Throws<ArgumentException>(() =>
                retrySettings.Validate(""));
        }

        [Fact]
        public void Validity()
        {
            var retrySettings = new RetrySettings
            {
                TimeoutBackoff = new BackoffSettings(),
                RetryBackoff = new BackoffSettings(),
            };
            // Test passes if this doesn't throw
            retrySettings.Validate("");
        }

        class DummyJitter : RetrySettings.IJitter
        {
            public TimeSpan GetDelay(TimeSpan maxDelay) => TimeSpan.Zero;
        }

        [Fact]
        public void Clone()
        {
            var retrySettings = new RetrySettings
            {
                TimeoutBackoff = new BackoffSettings { DelayMultiplier = 1.0 },
                RetryBackoff = new BackoffSettings { DelayMultiplier = 2.0 },
                TotalExpiration = Expiration.None,
                RetryFilter = x => false,
                DelayJitter = new DummyJitter()
            };
            var clone = retrySettings.Clone();
            Assert.Equal(retrySettings.TimeoutBackoff.DelayMultiplier, clone.TimeoutBackoff.DelayMultiplier);
            Assert.Equal(retrySettings.RetryBackoff.DelayMultiplier, clone.RetryBackoff.DelayMultiplier);
            Assert.Same(retrySettings.TotalExpiration, clone.TotalExpiration);
            Assert.Same(retrySettings.RetryFilter, clone.RetryFilter);
            Assert.Same(retrySettings.DelayJitter, clone.DelayJitter);
        }
    }
}
