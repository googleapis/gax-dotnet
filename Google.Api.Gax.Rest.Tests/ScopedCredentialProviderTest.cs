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

namespace Google.Api.Gax.Rest.Tests
{
    // Note: we can't easily test the default credentials part here, as that relies
    // on environment variables etc. (We could potentially set the environment variable
    // within the test, but we'd quickly get into ordering issues etc.)
    public class ScopedCredentialProviderTest
    {
        // This is a valid PKCS8 private key, but it isn't used for anything in the real world.
        // It was generated purely for the sake of this test, so that we could generate server
        // account credentials which *look* valid.
        private static readonly string s_samplePrivateKey =
@"-----BEGIN PRIVATE KEY-----
MIIBVAIBADANBgkqhkiG9w0BAQEFAASCAT4wggE6AgEAAkEAwxUlt4jqmcFg45Ke
xjUM8fV+NN+a3OHSONasKwOLoDxQSZlGsWMifQUYBvhHM9qhG+sagW2HVYy1bV1X
43rphQIDAQABAkEAmqsRlEpBdlYTc1qz94HoGY4B2fnO1oFUIyxQpGnTMd48zPAu
R0KHbx+2oG2EFgu+lFtO05xtnKqBQEChs/oZoQIhAO58ArcePssfbyuLKDCy21z/
1kbm72ltNH8Av8lAnBNPAiEA0WkYTIhgsSUHh1gfNfqX0YeswWYsSQ/CSdeeI4Xr
0OsCIHj8sOP1lCW4bM3KazlJg8BKioqt3ge+P0OvPZz8CjJBAiBCQS0F8dQd1+hk
4vWk/28PRQzcd7YlO44uDMEk3hc5FwIgEC3IjYC5eSpfphW0VATvHiFoFYxpYzzk
j5XmfIZhC9k =
-----END PRIVATE KEY-----".Replace("\r", "").Replace("\n", "");

        [Fact]
        public void GetCredentials_EmptyScopes_NoOp()
        {
            var provider = new ScopedCredentialProvider(new string[0]);
            var originalCredentials = CreateServiceCredentials();
            var provided = provider.GetCredentials(originalCredentials);
            Assert.Same(originalCredentials, provided);
        }

        [Fact]
        public void GetCredentials_ScopesApplied_UnspecifiedUseJwts()
        {
            var provider = new ScopedCredentialProvider(new[] { "abc" });
            var originalCredentials = CreateServiceCredentials();
            var provided = provider.GetCredentials(originalCredentials);
            // Can't actually test the scopes...
            Assert.NotSame(originalCredentials, provided);
        }

        [Theory, CombinatorialData]
        public void GetCredentials_ScopesApplied_UseJwtWithScopesSpecified(bool useJwtWithScopes)
        {
            var provider = new ScopedCredentialProvider(new[] { "abc" }, useJwtWithScopes);
            var originalCredentials = CreateServiceCredentials();
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
            var originalCredentials = CreateServiceCredentials();
            var provided = await provider.GetCredentialsAsync(originalCredentials, CancellationToken.None);
            Assert.Same(originalCredentials, provided);
        }

        [Fact]
        public async Task GetCredentialsAsync_ScopesApplied()
        {
            var provider = new ScopedCredentialProvider(new[] { "abc" });
            var originalCredentials = CreateServiceCredentials();
            var provided = await provider.GetCredentialsAsync(originalCredentials, CancellationToken.None);
            // Can't actually test the scopes...
            Assert.NotSame(originalCredentials, provided);
        }

        private GoogleCredential CreateServiceCredentials()
        {
            var parameters = new JsonCredentialParameters
            {
                Type = JsonCredentialParameters.ServiceAccountCredentialType,
                ClientEmail = "noone@example.com",
                PrivateKey = s_samplePrivateKey
            };
            string json = JsonConvert.SerializeObject(parameters);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            return GoogleCredential.FromStream(stream);
        }
    }
}
