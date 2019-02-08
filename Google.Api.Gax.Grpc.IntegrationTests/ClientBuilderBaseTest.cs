﻿/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    public class ClientBuilderBaseTest
    {
        private const string DummyServiceAccountCredentialFileContents = @"{
""private_key_id"": ""PRIVATE_KEY_ID"",
""private_key"": ""-----BEGIN PRIVATE KEY-----
MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAJJM6HT4s6btOsfe
2x4zrzrwSUtmtR37XTTi0sPARTDF8uzmXy8UnE5RcVJzEH5T2Ssz/ylX4Sl/CI4L
no1l8j9GiHJb49LSRjWe4Yx936q0Xj9H0R1HTxvjUPqwAsTwy2fKBTog+q1frqc9
o8s2r6LYivUGDVbhuUzCaMJsf+x3AgMBAAECgYEAi0FTXsu/zRswAUGaViQiHjrL
uU65BSHXNVjV/2fLNEKnGWGqpli68z1IXY+S2nwbUak7rnGsq9/0F6jtsW+hZbLk
KXUOuuExpeC5Kd6ngWX/f2jqmhlUabiQijU9cVk7pMq8EHkRtvlosnMTUAEzempu
QUPwn1PZHhmJkBvZ4lECQQDCErrxl+e3BwUDcS0yVEEmCNSG6xdXs2878b8rzbe7
3Mmi6SuuOLi3PU92J+j+f/MOdtYrk13mEDdYmd5dhrt5AkEAwPvDEsDT/W4y4h5n
gv1awGBA5aLFE1JNWM/Gwn4D1cGpEDHKFREaBtxMDCASpHJuw8r7zUywpKhmBZcf
GS37bwJANdSAKfbafLfjuhqwUJ9yGpykZm/a36aTmerp/bpn1iHdg+RtCzwMcDb/
TWSwibbvsflgWmHbz657y4WSWhq+8QJAWrpCNN/ZCk2zuGDo80lfUBAwkoVat8G6
wWU1oZyS+vzIGef+hLb8kHsjeZPej9eIwZ39kcBbT54oELrCkRjwGwJAQ8V2A7lT
ZUp8AsbVqF6rbLiiUfJMo2btGclQu4DEVyS+ymFA65tXDLUuR9EDqJYdqHNZJ5B8
4Z5p2prkjWTLcA==
-----END PRIVATE KEY-----"",
""client_email"": ""CLIENT_EMAIL"",
""client_id"": ""CLIENT_ID"",
""type"": ""service_account""}";

        // Horrible hack, but we can change it if it ever fails.
        private static readonly FieldInfo s_defaultCallInvokerChannelField = typeof(DefaultCallInvoker).GetTypeInfo()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Single(f => f.FieldType == typeof(Channel));

        // It doesn't matter what kind of CallInvoker we use. DefaultCallInvoker is just a handy one.
        private static readonly CallInvoker CustomInvoker = new DefaultCallInvoker(new Channel("other.nowhere.com", 443, ChannelCredentials.Insecure));

        private static readonly Func<string, CancellationToken, Task<string>> CustomTokenAccess = (authUri, cancellationToken) => Task.FromResult("token");

        [Fact]
        public async Task DefaultsToChannelPool()
        {
            var builder = new SampleClientBuilder();

            Channel channelFromPool = builder.ChannelPool.GetChannel(SampleClientBuilder.DefaultEndpoint);

            Action<CallInvoker> validator = invoker =>
            {
                var channelFromBuilder = GetChannel(invoker);
                Assert.Same(channelFromPool, channelFromBuilder);
                Assert.Null(builder.ChannelCreated);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task DifferentEndpoint_StillFromChannelPool()
        {
            var endpoint = new ServiceEndpoint("custom.nowhere.com", 443); ;
            var builder = new SampleClientBuilder { Endpoint = endpoint };

            Channel channelFromPoolWithDefaultEndpoint = builder.ChannelPool.GetChannel(SampleClientBuilder.DefaultEndpoint);
            Channel channelFromPoolWithCustomEndpoint = builder.ChannelPool.GetChannel(new ServiceEndpoint("custom.nowhere.com", 443));

            Action<CallInvoker> validator = invoker =>
            {
                var channelFromBuilder = GetChannel(invoker);
                Assert.Same(channelFromPoolWithCustomEndpoint, channelFromBuilder);
                Assert.NotSame(channelFromPoolWithDefaultEndpoint, channelFromBuilder);
                Assert.Null(builder.ChannelCreated);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task CustomChannelCredentials()
        {
            var builder = new SampleClientBuilder { ChannelCredentials = ChannelCredentials.Insecure };

            Action<CallInvoker> validator = invoker =>
            {
                Assert.NotNull(builder.ChannelCreated);
                Assert.Same(builder.ChannelCreated, GetChannel(invoker));
                Assert.Equal(SampleClientBuilder.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
                Assert.Same(builder.ChannelCredentials, builder.CredentialsUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task CustomChannelCredentialsAndEndpoint()
        {
            var endpoint = new ServiceEndpoint("custom.nowhere.com", 443);
            var builder = new SampleClientBuilder { ChannelCredentials = ChannelCredentials.Insecure, Endpoint = endpoint };

            Action<CallInvoker> validator = invoker =>
            {
                Assert.NotNull(builder.ChannelCreated);
                Assert.Same(builder.ChannelCreated, GetChannel(invoker));
                Assert.Equal(endpoint, builder.EndpointUsedToCreateChannel);
                Assert.Same(builder.ChannelCredentials, builder.CredentialsUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task JsonCredentials()
        {
            var builder = new SampleClientBuilder { JsonCredentials = DummyServiceAccountCredentialFileContents };

            // We won't use the channel pool when custom credentials are specified.
            // We can't easily check anything about the actual credentials though.
            Action<CallInvoker> validator = invoker =>
            {
                Assert.NotNull(builder.ChannelCreated);
                Assert.Same(builder.ChannelCreated, GetChannel(invoker));
                Assert.Equal(SampleClientBuilder.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task CredentialsFilePath()
        {
            var file = Path.GetTempFileName();
            File.WriteAllText(file, DummyServiceAccountCredentialFileContents);

            try
            {
                var builder = new SampleClientBuilder { CredentialsPath = file };

                // We won't use the channel pool when custom credentials are specified.
                // We can't easily check anything about the actual credentials though.
                Action<CallInvoker> validator = invoker =>
                {
                    Assert.NotNull(builder.ChannelCreated);
                    Assert.Same(builder.ChannelCreated, GetChannel(invoker));
                    Assert.Equal(SampleClientBuilder.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
                };

                await ValidateResultAsync(builder, validator);
            }
            finally
            {
                File.Delete(file);
            }
        }

        [Fact]
        public async Task CustomScopes()
        {
            var builder = new SampleClientBuilder { Scopes = new[] { "a", "b" } };

            // We won't use the channel pool when there are custom scopes.
            // We can't easily check anything about the actual credentials though.
            Action<CallInvoker> validator = invoker =>
            {
                Assert.NotNull(builder.ChannelCreated);
                Assert.Same(builder.ChannelCreated, GetChannel(invoker));
                Assert.Equal(SampleClientBuilder.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task CustomCallInvoker()
        {
            var builder = new SampleClientBuilder { CallInvoker = CustomInvoker };

            // We won't use the channel pool when there are custom scopes.
            // We can't easily check anything about the actual credentials though.
            Action<CallInvoker> validator = invoker =>
            {
                Assert.Same(invoker, CustomInvoker);
                Assert.Null(builder.ChannelCreated);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task TokenAccessMethod()
        {
            var builder = new SampleClientBuilder { TokenAccessMethod = CustomTokenAccess };

            // We won't use the channel pool when there are custom scopes.
            // We can't easily check anything about the actual credentials though.
            Action<CallInvoker> validator = invoker =>
            {
                Assert.NotNull(builder.ChannelCreated);
                Assert.Same(builder.ChannelCreated, GetChannel(invoker));
                Assert.Equal(SampleClientBuilder.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        private static Channel GetChannel(CallInvoker invoker)
        {
            if (!(invoker is DefaultCallInvoker dci))
            {
                throw new ArgumentException($"Call invoker is of type {invoker?.GetType()} instead of {nameof(DefaultCallInvoker)}");
            }
            return (Channel)s_defaultCallInvokerChannelField.GetValue(dci);
        }

        private async Task ValidateResultAsync(SampleClientBuilder builder, Action<CallInvoker> validator)
        {
            var callInvoker = builder.Build();
            validator(callInvoker);
            builder.ResetChannelCreation();
            callInvoker = await builder.BuildAsync(default);
            validator(callInvoker);
            builder.ResetChannelCreation();
        }

        public static TheoryData<SampleClientBuilder> InvalidCombinationsTheoryData = new TheoryData<SampleClientBuilder>
        {
            // CallInvoker excludes everything else
            new SampleClientBuilder("CallInvokerAndTokenAccessMethod") { CallInvoker = CustomInvoker, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("CallInvokerAndEndpoint") { CallInvoker = CustomInvoker, Endpoint = SampleClientBuilder.DefaultEndpoint },
            new SampleClientBuilder("CallInvokerAndScopes") { CallInvoker = CustomInvoker, Scopes = new[] { "a", "b" } },
            new SampleClientBuilder("CallInvokerAndCredentialsPath") { CallInvoker = CustomInvoker, CredentialsPath = "foo.json" },
            new SampleClientBuilder("CallInvokerAndChannelCredentials") { CallInvoker = CustomInvoker, ChannelCredentials = ChannelCredentials.Insecure },
            new SampleClientBuilder("CallInvokerAndJsonCredentials") { CallInvoker = CustomInvoker, JsonCredentials = DummyServiceAccountCredentialFileContents },
            new SampleClientBuilder("CallInvokerAndTokenAccesMethod") { CallInvoker = CustomInvoker, TokenAccessMethod = CustomTokenAccess },

            // Each method of specifying credentials excludes the rest (tests are not exhaustive)
            new SampleClientBuilder("ChannelCredentialsAndCredentialsPath") { ChannelCredentials = ChannelCredentials.Insecure, CredentialsPath = "foo.json" },
            new SampleClientBuilder("ChannelCredentialsAndJsonCredentials") { ChannelCredentials = ChannelCredentials.Insecure, JsonCredentials = DummyServiceAccountCredentialFileContents },
            new SampleClientBuilder("ChannelCredentialsAndTokenAccessMethod") { ChannelCredentials = ChannelCredentials.Insecure, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("JsonCredentialsAndTokenAccessMethod") { JsonCredentials = DummyServiceAccountCredentialFileContents, TokenAccessMethod = CustomTokenAccess },

            // Scopes only work with default credentials, a credentials file, or JSON
            new SampleClientBuilder("ScopesAndTokenAccess") { Scopes = new[] { "a" }, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("ScopesAndChannelCredentials") { Scopes = new[] { "a" }, ChannelCredentials = ChannelCredentials.Insecure },

        };

        [Theory, MemberData(nameof(InvalidCombinationsTheoryData))]
        public void InvalidCombination(SampleClientBuilder builder)
        {
            Assert.Throws<InvalidOperationException>(builder.ValidateForTest);
        }
        
        public class SampleClientBuilder : ClientBuilderBase<CallInvoker>
        {
            public static ServiceEndpoint DefaultEndpoint { get; } = new ServiceEndpoint("default.nowhere.com", 443);
            public static string[] DefaultScopes { get; } = new[] { "scope1", "scope2" };
            public ChannelPool ChannelPool { get; } = new ChannelPool(DefaultScopes);

            public ServiceEndpoint EndpointUsedToCreateChannel { get; private set; }
            public ChannelCredentials CredentialsUsedToCreateChannel { get; private set; }
            public Channel ChannelCreated { get; private set; }

            private readonly string _name;

            /// <summary>
            /// Constructor assigning a "name" to a builder for the sake of theory tests.
            /// </summary>
            public SampleClientBuilder(string name) => _name = name;

            public SampleClientBuilder() : this("Unnamed")
            {
            }

            public override CallInvoker Build()
            {
                base.Validate();
                return CreateCallInvoker();
            }

            public void ValidateForTest() => Validate();

            public override async Task<CallInvoker> BuildAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                base.Validate();
                return await CreateCallInvokerAsync(cancellationToken);
            }

            protected override ChannelPool GetChannelPool() => ChannelPool;

            protected override ServiceEndpoint GetDefaultEndpoint() => DefaultEndpoint;

            protected override IReadOnlyList<string> GetDefaultScopes() => DefaultScopes;

            public void ResetChannelCreation()
            {
                EndpointUsedToCreateChannel = null;
                CredentialsUsedToCreateChannel = null;
                ChannelCreated = null;
            }

            private protected override Channel CreateChannel(ServiceEndpoint endpoint, ChannelCredentials credentials)
            {
                CredentialsUsedToCreateChannel = credentials;
                EndpointUsedToCreateChannel = endpoint;
                ChannelCreated = base.CreateChannel(endpoint, credentials);
                return ChannelCreated;
            }

            public override string ToString() => _name;
        }
    }
}
