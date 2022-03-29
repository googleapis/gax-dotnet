/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public partial class ClientBuilderBaseTest
    {
        /// <summary>
        /// Tests for <see cref="ClientBuilderBase{TClient}.GetGoogleCredential"/>.
        /// Separated into their own class as there are quite a few of them.
        /// Note that *all* tests require the builder to be configured with a
        /// single credential source: we never want to fetch the application default credential,
        /// as that's a singleton.
        /// </summary>
        public class GetGoogleCredentialTest
        {
            private static readonly string[] s_scopes = { "scope1", "scope2" };
            // Taken from https://github.com/googleapis/google-api-dotnet-client/blob/main/Src/Support/Google.Apis.Auth.Tests/OAuth2/ServiceAccountCredentialTests.cs
            private static readonly string s_serviceAccountJson = @"{
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

            [Fact]
            public async Task JsonCredentials_Valid()
            {
                var builder = new FakeBuilder(s_scopes, true)
                {
                    JsonCredentials = s_serviceAccountJson
                };
                await AssertCredentialAsync(builder, AssertBasicProperties);
            }

            [Fact]
            public async Task CredentialsPath_Valid()
            {
                var path = Path.GetTempFileName();
                File.WriteAllText(path, s_serviceAccountJson);

                var builder = new FakeBuilder(s_scopes, true)
                {
                    CredentialsPath = path
                };
                await AssertCredentialAsync(builder, AssertBasicProperties);
                File.Delete(path);
            }

            [Fact]
            public async Task GoogleCredential_Valid()
            {
                var credential = GoogleCredential.FromJson(s_serviceAccountJson);
                var builder = new FakeBuilder(s_scopes, true)
                {
                    GoogleCredential = credential
                };
                await AssertCredentialAsync(builder, AssertBasicProperties);
            }

            [Fact]
            public async Task UseJwtAccessWithScopesFalse()
            {
                var credential = GoogleCredential.FromJson(s_serviceAccountJson);
                var builder = new FakeBuilder(s_scopes, false)
                {
                    GoogleCredential = credential
                };
                await AssertCredentialAsync(builder,
                    credential => Assert.False(((ServiceAccountCredential)credential.UnderlyingCredential).UseJwtAccessWithScopes));
            }

            [Fact]
            public async Task QuotaProject()
            {
                var credential = GoogleCredential.FromJson(s_serviceAccountJson);
                var builder = new FakeBuilder(s_scopes, true)
                {
                    GoogleCredential = credential,
                    QuotaProject = "quota-project"
                };
                await AssertCredentialAsync(builder,
                    credential => Assert.Equal("quota-project", ((ServiceAccountCredential) credential.UnderlyingCredential).QuotaProject));
            }

            private static void AssertBasicProperties(GoogleCredential credential)
            {
                var sa = Assert.IsType<ServiceAccountCredential>(credential.UnderlyingCredential);
                Assert.Equal("CLIENT_EMAIL", sa.Id);
                Assert.Equal(s_scopes, sa.Scopes);
                Assert.True(sa.UseJwtAccessWithScopes);
            }

            private async Task AssertCredentialAsync(FakeBuilder builder, Action<GoogleCredential> assertion)
            {
                var cred1 = builder.GetGoogleCredential();
                assertion(cred1);
                var cred2 = await builder.GetGoogleCredentialAsync(default);
                assertion(cred2);
            }

            private class FakeBuilder : ClientBuilderBase<string>
            {
                public IReadOnlyList<string> DefaultScopes { get; }

                internal FakeBuilder(string[] defaultScopes, bool useJwtAccessWithScopes)
                {
                    UseJwtAccessWithScopes = useJwtAccessWithScopes;
                    Scopes = defaultScopes;
                }

                public new GrpcChannelOptions GetChannelOptions() => throw new NotImplementedException();
                protected override ApiMetadata ApiMetadata => TestApiMetadata.TestGrpc;
                public override string Build() => throw new NotImplementedException();
                public override Task<string> BuildAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
                protected override ChannelPool GetChannelPool() => throw new NotImplementedException();
                protected override string GetDefaultEndpoint() => throw new NotImplementedException();
                protected override IReadOnlyList<string> GetDefaultScopes() => DefaultScopes;
            }
        }
    }
}
