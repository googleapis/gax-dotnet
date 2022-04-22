/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Protobuf.Reflection;
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

        private const string SampleQuotaProject = "SampleQuotaProject";

        [Fact]
        public async Task DefaultsToChannelPool()
        {
            var builder = new SampleClientBuilder();

            ChannelBase channelFromPool = builder.ChannelPool.GetChannel(GrpcCoreAdapter.Instance, TestServiceMetadata.TestService.DefaultEndpoint, SampleClientBuilder.DefaultOptions);

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
            var endpoint = "custom.nowhere.com";
            var builder = new SampleClientBuilder { Endpoint = endpoint };

            ChannelBase channelFromPoolWithDefaultEndpoint = builder.ChannelPool.GetChannel(GrpcCoreAdapter.Instance, TestServiceMetadata.TestService.DefaultEndpoint, SampleClientBuilder.DefaultOptions);
            ChannelBase channelFromPoolWithCustomEndpoint = builder.ChannelPool.GetChannel(GrpcCoreAdapter.Instance, "custom.nowhere.com", SampleClientBuilder.DefaultOptions);

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
                Assert.Equal(TestServiceMetadata.TestService.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
                Assert.Same(builder.ChannelCredentials, builder.CredentialsUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task CustomChannelCredentialsAndEndpoint()
        {
            var endpoint = "custom.nowhere.com";
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
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }

        [Fact]
        public async Task GoogleCredentialProperty()
        {
            var builder = new SampleClientBuilder { GoogleCredential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents) };
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }

        [Fact]
        public async Task Credential()
        {
            var builder = new SampleClientBuilder { Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents) };
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }

        [Fact]
        public async Task CredentialsFilePath()
        {
            var file = Path.GetTempFileName();
            File.WriteAllText(file, DummyServiceAccountCredentialFileContents);

            try
            {
                var builder = new SampleClientBuilder { CredentialsPath = file };
                await ValidateResultAsync(builder, AssertNonChannelPool(builder));
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
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }

        [Fact]
        public async Task QuotaProject()
        {
            var builder = new SampleClientBuilder { QuotaProject = SampleQuotaProject };
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }

        [Fact]
        public async Task CustomCallInvoker()
        {
            var builder = new SampleClientBuilder { CallInvoker = CustomInvoker };

            Action<CallInvoker> validator = invoker =>
            {
                Assert.Same(invoker, CustomInvoker);
                Assert.Null(builder.ChannelCreated);
            };
            await ValidateResultAsync(builder, validator);
        }

#pragma warning disable CS0618 // Type or member is obsolete
        [Fact]
        public async Task TokenAccessMethod()
        {
            var builder = new SampleClientBuilder { TokenAccessMethod = CustomTokenAccess };
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }
#pragma warning restore CS0618 // Type or member is obsolete

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public async Task JwtClientEnabledTest(bool clientUsesJwt, bool poolUsesJwt)
        {
            var builder = new SampleClientBuilder(clientUsesJwt, poolUsesJwt) { JsonCredentials = DummyServiceAccountCredentialFileContents };
            ChannelBase channelFromPool = builder.ChannelPool.GetChannel(GrpcCoreAdapter.Instance, TestServiceMetadata.TestService.DefaultEndpoint, SampleClientBuilder.DefaultOptions);

            // Jwt of client does not match pool, so we won't use channel pool
            await ValidateResultAsync(builder, AssertNonChannelPool(builder));
        }

        [Theory]
        [CombinatorialData]
        public async Task JwtClientAndPoolEnabledTest(bool enabledJwts)
        {
            var builder = new SampleClientBuilder(enabledJwts, enabledJwts);
            ChannelBase channelFromPool = builder.ChannelPool.GetChannel(GrpcCoreAdapter.Instance, TestServiceMetadata.TestService.DefaultEndpoint, SampleClientBuilder.DefaultOptions);

            // Jwt is either enabled or disabled for both client and pool
            // We use channel pool
            Action<CallInvoker> validator = invoker =>
            {
                var channelFromBuilder = GetChannel(invoker);
                Assert.Null(builder.ChannelCreated);
                Assert.Same(builder.ChannelCredentials, builder.CredentialsUsedToCreateChannel);
            };
            await ValidateResultAsync(builder, validator);
        }

        // We won't use the channel pool when custom credentials are specified.
        // We can't easily check anything about the actual credentials though.
        private static Action<CallInvoker> AssertNonChannelPool(SampleClientBuilder builder) => invoker =>
        {
            Assert.NotNull(builder.ChannelCreated);
            Assert.Same(builder.ChannelCreated, GetChannel(invoker));
            Assert.Equal(TestServiceMetadata.TestService.DefaultEndpoint, builder.EndpointUsedToCreateChannel);
        };

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

#pragma warning disable CS0618 // Type or member is obsolete
        public static TheoryData<SampleClientBuilder> InvalidCombinationsTheoryData = new TheoryData<SampleClientBuilder>
        {
            // CallInvoker excludes everything else
            new SampleClientBuilder("CallInvokerAndTokenAccessMethod") { CallInvoker = CustomInvoker, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("CallInvokerAndEndpoint") { CallInvoker = CustomInvoker, Endpoint = "test.googleapis.com" },
            new SampleClientBuilder("CallInvokerAndScopes") { CallInvoker = CustomInvoker, Scopes = new[] { "a", "b" } },
            new SampleClientBuilder("CallInvokerAndCredentialsPath") { CallInvoker = CustomInvoker, CredentialsPath = "foo.json" },
            new SampleClientBuilder("CallInvokerAndChannelCredentials") { CallInvoker = CustomInvoker, ChannelCredentials = ChannelCredentials.Insecure },
            new SampleClientBuilder("CallInvokerAndJsonCredentials") { CallInvoker = CustomInvoker, JsonCredentials = DummyServiceAccountCredentialFileContents },
            new SampleClientBuilder("CallInvokerAndTokenAccesMethod") { CallInvoker = CustomInvoker, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("CallInvokerAndQuotaProject") { CallInvoker = CustomInvoker, QuotaProject = SampleQuotaProject },
            new SampleClientBuilder("CallInvokerAndCredential") { CallInvoker = CustomInvoker, Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents) },
            new SampleClientBuilder("CallInvokerAndGoogleCredential") { CallInvoker = CustomInvoker, GoogleCredential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents) },

            // ChannelCredentials also excludes quota project.
            new SampleClientBuilder("ChannelCredentialsAndQuotaProject") { ChannelCredentials = ChannelCredentials.Insecure, QuotaProject = SampleQuotaProject },

            // Each method of specifying credentials excludes the rest (tests are not exhaustive)
            new SampleClientBuilder("ChannelCredentialsAndCredentialsPath") { ChannelCredentials = ChannelCredentials.Insecure, CredentialsPath = "foo.json" },
            new SampleClientBuilder("ChannelCredentialsAndJsonCredentials") { ChannelCredentials = ChannelCredentials.Insecure, JsonCredentials = DummyServiceAccountCredentialFileContents },
            new SampleClientBuilder("ChannelCredentialsAndTokenAccessMethod") { ChannelCredentials = ChannelCredentials.Insecure, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("JsonCredentialsAndTokenAccessMethod") { JsonCredentials = DummyServiceAccountCredentialFileContents, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("CredentialAndTokenAccessMethod") { Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents), TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("GoogleCredentialAndTokenAccessMethod") { GoogleCredential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents), TokenAccessMethod = CustomTokenAccess },

            // Scopes only work with default credentials, a GoogleCredential, a credentials file, or JSON
            new SampleClientBuilder("ScopesAndTokenAccess") { Scopes = new[] { "a" }, TokenAccessMethod = CustomTokenAccess },
            new SampleClientBuilder("ScopesAndCredential") { Scopes = new[] { "a" }, Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents) },
            new SampleClientBuilder("ScopesAndChannelCredentials") { Scopes = new[] { "a" }, ChannelCredentials = ChannelCredentials.Insecure },
        };
#pragma warning restore CS0618 // Type or member is obsolete

        [Theory, MemberData(nameof(InvalidCombinationsTheoryData))]
        public void InvalidCombination(SampleClientBuilder builder)
        {
            Assert.Throws<InvalidOperationException>(builder.ValidateForTest);
        }
        
        public class SampleClientBuilder : ClientBuilderBase<CallInvoker>
        {
            public ChannelPool ChannelPool { get; }

            // The default options are protected in ClientBuilderBase, but we want to access them for testing.
            public static new GrpcChannelOptions DefaultOptions => ClientBuilderBase<CallInvoker>.DefaultOptions;

            public string EndpointUsedToCreateChannel { get; private set; }
            public ChannelCredentials CredentialsUsedToCreateChannel { get; private set; }
            public ChannelBase ChannelCreated { get; private set; }

            private readonly string _name;

            /// <summary>
            /// Constructor assigning a "name" to a builder and setting Jwt flags for the sake of theory tests.
            /// </summary>
            public SampleClientBuilder(string name, bool clientUsesJwt, bool poolUsesJwt) : base(TestServiceMetadata.TestService.WithSupportsScopedJwts(poolUsesJwt))
            {
                _name = name;
                ChannelPool = new ChannelPool(ServiceMetadata);
                UseJwtAccessWithScopes = clientUsesJwt;
                GrpcAdapter = GrpcCoreAdapter.Instance;
            }

            public SampleClientBuilder(bool clientUsesJwt, bool poolUsesJwt)
                : this("Unnamed", clientUsesJwt, poolUsesJwt)
            {
            }

            public SampleClientBuilder(string name) : this(name, false, false)
            {
            }

            public SampleClientBuilder() : this(false, false)
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
            
            public void ResetChannelCreation()
            {
                EndpointUsedToCreateChannel = null;
                CredentialsUsedToCreateChannel = null;
                ChannelCreated = null;
            }

            protected override ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials)
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
