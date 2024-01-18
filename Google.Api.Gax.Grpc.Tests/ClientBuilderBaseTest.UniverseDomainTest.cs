/*
 * Copyright 2024 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests;

public partial class ClientBuilderBaseTest
{
    public class UniverseDomainTest
    {
        private const string DefaultUniverseDomain = "googleapis.com";

        public static TheoryData<FakeClientBuilder> UniverseDomainKnowable =>
            new TheoryData<FakeClientBuilder>
            {
                new FakeClientBuilder (),
                new FakeClientBuilder { Endpoint = "ignored" },
                new FakeClientBuilder { ChannelCredentials = ChannelCredentials.Insecure },
                new FakeClientBuilder { Credential = new FakeCredential() },
#pragma warning disable CS0618 // Type or member is obsolete
                new FakeClientBuilder { TokenAccessMethod = (_,_) => Task.FromResult("token") },
#pragma warning restore CS0618 // Type or member is obsolete
            };

        public static TheoryData<FakeClientBuilder> UniverseDomainUnknowable =>
            new TheoryData<FakeClientBuilder>
            {
                new FakeClientBuilder { CallInvoker = new FakeCallInvoker() },
                new FakeClientBuilder { Endpoint = "ignored", ChannelCredentials = ChannelCredentials.Insecure },
                new FakeClientBuilder { Endpoint = "ignored", Credential = new FakeCredential() },
#pragma warning disable CS0618 // Type or member is obsolete
                new FakeClientBuilder { Endpoint = "ignored", TokenAccessMethod = (_,_) => Task.FromResult("token") },
#pragma warning restore CS0618 // Type or member is obsolete
            };

        [Theory]
        [MemberData(nameof(UniverseDomainKnowable))]
        public void UniverseDomainKnowable_Unset(FakeClientBuilder clientBuilder)
        {
            Assert.Null(clientBuilder.UniverseDomain);
            Assert.Equal(DefaultUniverseDomain, clientBuilder.EffectiveUniverseDomain);
            clientBuilder.Validate();
        }

        [Theory]
        [MemberData(nameof(UniverseDomainKnowable))]
        public void UniverseDomainKnowable_Set(FakeClientBuilder clientBuilder)
        {
            clientBuilder.UniverseDomain = "custom";

            Assert.Equal("custom", clientBuilder.UniverseDomain);
            Assert.Equal("custom", clientBuilder.EffectiveUniverseDomain);
            clientBuilder.Validate();
        }

        [Theory]
        [MemberData(nameof(UniverseDomainUnknowable))]
        public void UniverseDomainUnknowable_Unset(FakeClientBuilder clientBuilder)
        {
            Assert.Null(clientBuilder.EffectiveUniverseDomain);
            clientBuilder.Validate();
        }

        [Theory]
        [MemberData(nameof(UniverseDomainUnknowable))]
        public void UniverseDomainUnknowable_Set(FakeClientBuilder clientBuilder)
        {
            clientBuilder.UniverseDomain = "custom";
            Assert.Throws<InvalidOperationException>(clientBuilder.Validate);
        }

        public class FakeClientBuilder : ClientBuilderBase<string>
        {
            public FakeClientBuilder() : base(TestServiceMetadata.TestService)
            { }

            public override string Build() =>
                throw new NotImplementedException();

            public override Task<string> BuildAsync(CancellationToken cancellationToken = default) =>
                throw new NotImplementedException();

            protected override ChannelPool GetChannelPool() =>
                throw new NotImplementedException();

            public new string EffectiveUniverseDomain => base.EffectiveUniverseDomain;
            public new void Validate() => base.Validate();
        }

        private class FakeCallInvoker : CallInvoker
        {
            public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) =>
                throw new NotImplementedException();

            public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) =>
                throw new NotImplementedException();

            public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
                throw new NotImplementedException();

            public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
                throw new NotImplementedException();

            public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
                throw new NotImplementedException();
        }

        private class FakeCredential : ICredential
        {
            public Task<string> GetAccessTokenForRequestAsync(string authUri = null, CancellationToken cancellationToken = default) =>
                throw new NotImplementedException();

            public void Initialize(ConfigurableHttpClient httpClient) =>
                throw new NotImplementedException();
        }
    }
}
