/*
 * Copyright 2023 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Grpc.Core;

namespace Google.Api.Gax.Grpc.Tests;

public partial class ClientBuilderBaseTest
{
    public class GetEffectiveSettingsTest
    {
        [Fact]
        public void NoApiKey_NoSettings()
        {
            var builder = new SimpleBuilder(null);
            var effectiveSettings = builder.GetEffectiveSettings(null);
            Assert.Null(effectiveSettings);
        }

        [Fact]
        public void ApiKey_NoSettings()
        {
            var builder = new SimpleBuilder("apikey1");
            var effectiveSettings = builder.GetEffectiveSettings(null);
            Assert.NotNull(effectiveSettings);
            AssertApiKeyHeader(effectiveSettings.CallSettings, "apikey1");
        }

        [Fact]
        public void NoApiKey_WithSettings()
        {
            var builder = new SimpleBuilder("apikey1");
            var originalCallSettings = CallSettings.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(5)));
            var settings = new SimpleSettings { CallSettings = originalCallSettings };
            var effectiveSettings = builder.GetEffectiveSettings(settings);
            Assert.Same(effectiveSettings, settings);
            Assert.NotSame(originalCallSettings, settings.CallSettings);
        }

        [Fact]
        public void ApiKey_WithSettings()
        {
            var builder = new SimpleBuilder("apikey2");
            var originalCallSettings = CallSettings.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(5)));
            var settings = new SimpleSettings
            {
                CallSettings = originalCallSettings,
                RpcCallSettings = CallSettings.FromHeader("x", "y")
            };
            var clone = settings.Clone();
            var effectiveSettings = builder.GetEffectiveSettings(clone);
            // We modify the clone, which is why we need to clone in the first place.
            Assert.Same(effectiveSettings, clone);

            // The CallSettings should have been merged, but the original ones left untouched.
            Assert.NotSame(originalCallSettings, effectiveSettings.CallSettings);
            AssertApiKeyHeader(effectiveSettings.CallSettings, "apikey2");
            Assert.Equal(settings.CallSettings.Expiration, effectiveSettings.CallSettings.Expiration);
            // The RpcCallSettings should be as it was
            Assert.Same(settings.RpcCallSettings, effectiveSettings.RpcCallSettings);
        }

        private void AssertApiKeyHeader(CallSettings callSettings, string expectedApiKey)
        {
            Assert.NotNull(callSettings);
            var metadata = new Metadata();
            callSettings.HeaderMutation(metadata);
            Assert.Equal(1, metadata.Count);
            var entry = metadata[0];
            Assert.Equal(ClientBuilderBase<string>.ApiKeyHeader, entry.Key);
            Assert.False(entry.IsBinary);
            Assert.Equal(expectedApiKey, entry.Value);
        }

        private class SimpleBuilder : ClientBuilderBase<string>
        {
            internal SimpleBuilder(string apiKey) : base(TestServiceMetadata.TestService) =>
                ApiKey = apiKey;

            public SimpleSettings GetEffectiveSettings(SimpleSettings settings) => base.GetEffectiveSettings<SimpleSettings>(settings);

            public new GrpcChannelOptions GetChannelOptions() => base.GetChannelOptions();
            public override string Build() => throw new NotImplementedException();
            public override Task<string> BuildAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
            protected override ChannelPool GetChannelPool() => throw new NotImplementedException();
        }

        /// <summary>
        /// Simple example representative of a generated settings class.
        /// </summary>
        private partial class SimpleSettings : ServiceSettingsBase
        {
            /// <summary>Get a new instance of the default <see cref="SimpleSettings"/>.</summary>
            /// <returns>A new instance of the default <see cref="SimpleSettings"/>.</returns>
            public static SimpleSettings GetDefault() => new SimpleSettings();

            /// <summary>Constructs a new <see cref="SimpleSettings"/> object with default settings.</summary>
            public SimpleSettings()
            {
            }

            private SimpleSettings(SimpleSettings existing) : base(existing)
            {
                GaxPreconditions.CheckNotNull(existing, nameof(existing));
                RpcCallSettings = existing.RpcCallSettings;
                OnCopy(existing);
            }

            /// <summary>
            /// An example of a per-RPC call settings
            /// </summary>
            public CallSettings RpcCallSettings { get; set; } = CallSettings.FromExpiration(Expiration.FromTimeout(TimeSpan.FromMilliseconds(3600000)));

            partial void OnCopy(SimpleSettings existing);

            /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
            /// <returns>A deep clone of this <see cref="SimpleSettings"/> object.</returns>
            public SimpleSettings Clone() => new SimpleSettings(this);
        }
    }
}
