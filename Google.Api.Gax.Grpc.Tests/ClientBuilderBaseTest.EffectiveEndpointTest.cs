/*
 * Copyright 2024 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests;

public partial class ClientBuilderBaseTest
{
    public class EffectiveEndpointTest
    {
        private const string DefaultUniverseDomain = "googleapis.com";
        private const string CustomUniverseDomain = "custom.domain.com";
        private const string DefaultEndpointAtDefaultDomain = "service1.googleapis.com";
        private const string DefaultEndpointNotAtDefaultDomain = "service1";
        private const string EffectiveEndpointAtCustomUniverseDomain = "service1.custom.domain.com";

        public static TheoryData<string, string, string> EffectiveEndpointWillHaveValue =>
            new TheoryData<string, string, string>
            {
                // Default endpoint, universe domain, expected effective endpoint
                { DefaultEndpointAtDefaultDomain, null, DefaultEndpointAtDefaultDomain},
                { DefaultEndpointAtDefaultDomain, DefaultUniverseDomain, DefaultEndpointAtDefaultDomain},
                { DefaultEndpointAtDefaultDomain, DefaultUniverseDomain, DefaultEndpointAtDefaultDomain},
                { DefaultEndpointAtDefaultDomain, CustomUniverseDomain, EffectiveEndpointAtCustomUniverseDomain},
                { DefaultEndpointNotAtDefaultDomain, null, DefaultEndpointNotAtDefaultDomain},
                { DefaultEndpointNotAtDefaultDomain, DefaultUniverseDomain, DefaultEndpointNotAtDefaultDomain},
            };

        public static TheoryData<string, string> EffectiveEndpointWillBeNull =>
            new TheoryData<string, string>
            {
                // Default endpoint, universe domain
                { null, null},
                { null, DefaultUniverseDomain },
                { null, CustomUniverseDomain },
                { DefaultEndpointNotAtDefaultDomain, CustomUniverseDomain }
            };

        [Theory]
        [MemberData(nameof(EffectiveEndpointWillHaveValue))]
        public void EffectiveEndpoint_HasValue(string defaultEndpoint, string universeDomain, string expectedEffectiveEndpoint)
        {
            FakeClientBuilder clientBuilder = new FakeClientBuilder(TestServiceMetadata.TestService.WithDefaultEndpoint(defaultEndpoint))
            {
                UniverseDomain = universeDomain,
            };
            Assert.Equal(expectedEffectiveEndpoint, clientBuilder.EffectiveEndpoint);
            clientBuilder.Validate();
        }

        [Theory]
        [MemberData(nameof(EffectiveEndpointWillBeNull))]
        public void EffectiveEndpoint_IsNull(string defaultEndpoint, string universeDomain)
        {
            FakeClientBuilder clientBuilder = new FakeClientBuilder(TestServiceMetadata.TestService.WithDefaultEndpoint(defaultEndpoint))
            {
                UniverseDomain = universeDomain,
            };
            Assert.Null(clientBuilder.EffectiveEndpoint);
            clientBuilder.Validate();
        }

        public class FakeClientBuilder : ClientBuilderBase<string>
        {
            public FakeClientBuilder(ServiceMetadata serviceMetadata) : base(serviceMetadata)
            { }

            public override string Build() =>
                throw new NotImplementedException();

            public override Task<string> BuildAsync(CancellationToken cancellationToken = default) =>
                throw new NotImplementedException();

            protected override ChannelPool GetChannelPool() =>
                throw new NotImplementedException();

            public new void Validate() => base.Validate();

            public new string EffectiveEndpoint => base.EffectiveEndpoint;
        }
    }
}
