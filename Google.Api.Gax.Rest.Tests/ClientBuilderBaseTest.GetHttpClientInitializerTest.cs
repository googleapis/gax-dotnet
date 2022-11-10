/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Google.Api.Gax.Rest.Tests.TestServiceCredentials;

namespace Google.Api.Gax.Rest.Tests
{
    public partial class ClientBuilderBaseTest
    {
        /// <summary>
        /// Tests for <see cref="ClientBuilderBase{TClient}.GetHttpClientInitializer"/>.
        /// Separated into their own class as there are quite a few of them.
        /// Note that *all* tests require the builder to be configured with a
        /// single credential source: we never want to fetch the application default credential,
        /// as that's a singleton.
        /// </summary>
        public class GetHttpClientInitializerTest
        {
            private static readonly string[] s_scopes = { "scope1", "scope2" };

            [Fact]
            public async Task JsonCredentials_Valid()
            {
                var builder = new FakeBuilder(s_scopes, true)
                {
                    JsonCredentials = TestServiceAccountJson
                };
                await AssertCredentialAsync(builder, AssertBasicProperties);
            }

            [Fact]
            public async Task CredentialsPath_Valid()
            {
                var path = Path.GetTempFileName();
                File.WriteAllText(path, TestServiceAccountJson);

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
                var credential = CreateTestServiceAccountCredential();
                var builder = new FakeBuilder(s_scopes, true)
                {
                    GoogleCredential = credential
                };
                await AssertCredentialAsync(builder, AssertBasicProperties);
            }

            [Fact]
            public async Task UseJwtAccessWithScopesFalse()
            {
                var credential = CreateTestServiceAccountCredential();
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
                var credential = CreateTestServiceAccountCredential();
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
                var cred1 = builder.GetHttpClientInitializer();
                assertion(cred1);
                var cred2 = await builder.GetHttpClientInitializerAsync();
                assertion(cred2);
            }

            private class FakeBuilder : ClientBuilderBase<string>
            {
                private readonly ScopedCredentialProvider _scopedCredentialProvider;

                internal FakeBuilder(string[] defaultScopes, bool useJwtAccessWithScopes)
                {
                    _scopedCredentialProvider = new ScopedCredentialProvider(defaultScopes);
                    UseJwtAccessWithScopes = useJwtAccessWithScopes;
                }

                public new GoogleCredential GetHttpClientInitializer() =>
                    (GoogleCredential) base.GetHttpClientInitializer();
                public async Task<GoogleCredential> GetHttpClientInitializerAsync() =>
                    (GoogleCredential) await base.GetHttpClientInitializerAsync(default);

                protected override string GetDefaultApplicationName() => "test";
                public override string Build() => throw new NotImplementedException();
                public override Task<string> BuildAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
                protected override ScopedCredentialProvider GetScopedCredentialProvider() => _scopedCredentialProvider;
            }
        }
    }
}
