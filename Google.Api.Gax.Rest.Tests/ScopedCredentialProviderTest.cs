/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Google.Api.Gax.Testing.TestCredentials;

namespace Google.Api.Gax.Rest.Tests
{
    // Note: we can't easily test the default credentials part here, as that relies
    // on environment variables etc. (We could potentially set the environment variable
    // within the test, but we'd quickly get into ordering issues etc.)
    public class ScopedCredentialProviderTest
    {
        [Fact]
        public void GetCredentials_EmptyScopes_NoOp()
        {
            var provider = new ScopedCredentialProvider(new string[0]);
            var originalCredentials = CreateTestServiceAccountCredential();
            var provided = provider.GetCredentials(originalCredentials);
            Assert.Same(originalCredentials, provided);
        }

        [Fact]
        public void GetCredentials_ScopesApplied_UnspecifiedUseJwts()
        {
            var provider = new ScopedCredentialProvider(new[] { "abc" });
            var originalCredentials = CreateTestServiceAccountCredential();
            var provided = provider.GetCredentials(originalCredentials);
            // Can't actually test the scopes...
            Assert.NotSame(originalCredentials, provided);
        }

        [Theory, CombinatorialData]
        public void GetCredentials_ScopesApplied_UseJwtWithScopesSpecified(bool useJwtWithScopes)
        {
            var provider = new ScopedCredentialProvider(new[] { "abc" }, useJwtWithScopes);
            var originalCredentials = CreateTestServiceAccountCredential();
            var provided = provider.GetCredentials(originalCredentials);
            Assert.NotSame(originalCredentials, provided);
            var serviceAccount = provided.UnderlyingCredential as ServiceAccountCredential;
            Assert.NotNull(serviceAccount);
            Assert.Equal(useJwtWithScopes, serviceAccount.UseJwtAccessWithScopes);
        }

        [Fact]
        public async Task GetCredentialsAsync_EmptyScopes_NoOp()
        {
            var provider = new ScopedCredentialProvider(new string[0]);
            var originalCredentials = CreateTestServiceAccountCredential();
            var provided = await provider.GetCredentialsAsync(originalCredentials, CancellationToken.None);
            Assert.Same(originalCredentials, provided);
        }

        [Fact]
        public async Task GetCredentialsAsync_ScopesApplied()
        {
            var provider = new ScopedCredentialProvider(new[] { "abc" });
            var originalCredentials = CreateTestServiceAccountCredential();
            var provided = await provider.GetCredentialsAsync(originalCredentials, CancellationToken.None);
            // Can't actually test the scopes...
            Assert.NotSame(originalCredentials, provided);
        }
    }
}
