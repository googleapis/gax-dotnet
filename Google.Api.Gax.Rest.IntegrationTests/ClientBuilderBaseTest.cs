/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Rest.IntegrationTests
{
    public class ClientBuilderBaseTest
    {
        private const string SampleApiKey = "SampleApiKey";
        private const string DefaultApplicationName = "DefaultApplicationName";
        private const string SampleQuotaProject = "SampleQuotaProject";

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

        [Fact]
        public async Task ApiKey_NoOtherCredentials()
        {
            var builder = new SampleClientBuilder { ApiKey = SampleApiKey };

            Action<BaseClientService.Initializer> validator = initializer =>
            {
                Assert.Null(initializer.HttpClientInitializer);
                Assert.Equal(SampleApiKey, initializer.ApiKey);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task ApiKey_NoOtherCredentials_QuotaProject()
        {
            var builder = new SampleClientBuilder 
            { 
                ApiKey = SampleApiKey,
                QuotaProject = SampleQuotaProject 
            };

            Action<BaseClientService.Initializer> validator = initializer =>
            {
                Assert.Equal(SampleApiKey, initializer.ApiKey);
                Assert.NotNull(initializer.HttpClientInitializer);

                var quotaProjectInitializer = initializer.HttpClientInitializer;
                using var handler = new FakeMessageHandler();
                using var client = new ConfigurableHttpClient(new ConfigurableMessageHandler(handler));

                quotaProjectInitializer.Initialize(client);
                client.GetAsync("https://will.be.ignored").Wait();

                var header = Assert.Single(handler.LatestRequestHeaders, header => header.Key == "x-goog-user-project");
                var value = Assert.Single(header.Value);
                Assert.Equal(SampleQuotaProject, value);
            };

            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task ApiKey_WithOtherCredentials()
        {
            var builder = new SampleClientBuilder
            {
                ApiKey = SampleApiKey,
                JsonCredentials = DummyServiceAccountCredentialFileContents
            };

            Action<BaseClientService.Initializer> validator = initializer =>
            {
                Assert.NotNull(initializer.HttpClientInitializer);
                Assert.Equal(SampleApiKey, initializer.ApiKey);
            };
            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task ApiKey_WithOtherCredentials_QuotaProject()
        {
            var builder = new SampleClientBuilder
            {
                ApiKey = SampleApiKey,
                JsonCredentials = DummyServiceAccountCredentialFileContents,
                QuotaProject = SampleQuotaProject
            };

            Action<BaseClientService.Initializer> validator = initializer =>
            {
                Assert.Equal(SampleApiKey, initializer.ApiKey);
                var credential = Assert.IsAssignableFrom<GoogleCredential>(initializer.HttpClientInitializer);
                Assert.Equal(SampleQuotaProject, credential.QuotaProject);
            };

            await ValidateResultAsync(builder, validator);
        }

        [Fact]
        public async Task BaseUri()
        {
            string uri = "https://foo.googleapis.com";
            var builder = new SampleClientBuilder { BaseUri = uri };
            await ValidateResultAsync(builder, initializer => Assert.Equal(uri, initializer.BaseUri));
        }

        [Fact]
        public async Task UniverseDomain()
        {
            string universeDomain = "custom.domain";
            var builder = new SampleClientBuilder { UniverseDomain = universeDomain };
            await ValidateResultAsync(builder, initializer => Assert.Equal(universeDomain, initializer.UniverseDomain));
        }

        [Fact]
        public async Task ApplicationNameUnspecified()
        {
            var builder = new SampleClientBuilder();
            await ValidateResultAsync(builder, initializer => Assert.Equal(DefaultApplicationName, initializer.ApplicationName));
        }

        [Fact]
        public async Task ApplicationNameSpecified()
        {
            string applicationName = "CustomApplicationName";
            var builder = new SampleClientBuilder { ApplicationName = applicationName };
            await ValidateResultAsync(builder, initializer => Assert.Equal(applicationName, initializer.ApplicationName));
        }

        [Fact]
        public async Task JsonCredentials()
        {
            var builder = new SampleClientBuilder { JsonCredentials = DummyServiceAccountCredentialFileContents };
            await ValidateResultAsync(builder, initializer => Assert.IsAssignableFrom<GoogleCredential>(initializer.HttpClientInitializer));
        }

        [Fact]
        public async Task JsonCredentials_QuotaProject()
        {
            var builder = new SampleClientBuilder 
            { 
                JsonCredentials = DummyServiceAccountCredentialFileContents,
                QuotaProject = SampleQuotaProject
            };

            Action<BaseClientService.Initializer> validator = initializer =>
            {
                var credential = Assert.IsAssignableFrom<GoogleCredential>(initializer.HttpClientInitializer);
                Assert.Equal(SampleQuotaProject, credential.QuotaProject);
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
                await ValidateResultAsync(builder, initializer => Assert.IsAssignableFrom<GoogleCredential>(initializer.HttpClientInitializer));
            }
            finally
            {
                File.Delete(file);
            }
        }

        [Fact]
        public async Task CredentialsFilePath_QuotaProject()
        {
            var file = Path.GetTempFileName();
            File.WriteAllText(file, DummyServiceAccountCredentialFileContents);

            try
            {
                var builder = new SampleClientBuilder 
                { 
                    CredentialsPath = file,
                    QuotaProject = SampleQuotaProject
                };

                Action<BaseClientService.Initializer> validator = initializer =>
                {
                    var credential = Assert.IsAssignableFrom<GoogleCredential>(initializer.HttpClientInitializer);
                    Assert.Equal(SampleQuotaProject, credential.QuotaProject);
                };

                await ValidateResultAsync(builder, validator);
            }
            finally
            {
                File.Delete(file);
            }
        }

        [Fact]
        public async Task CustomCredential()
        {
            var credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents);
            var builder = new SampleClientBuilder { Credential = credential };
            await ValidateResultAsync(builder, initializer => Assert.Same(credential, initializer.HttpClientInitializer));
        }

        public static TheoryData<SampleClientBuilder> InvalidCombinationsTheoryData = new TheoryData<SampleClientBuilder>
        {
            new SampleClientBuilder("CredentialsPathAndJsonCredentials") { CredentialsPath = "foo.json", JsonCredentials = DummyServiceAccountCredentialFileContents },
            new SampleClientBuilder("CredentialAndJsonCredentials") { Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents), JsonCredentials = DummyServiceAccountCredentialFileContents },
            new SampleClientBuilder("CredentialAndCredentialsPath") { Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents), CredentialsPath = "foo.json" },
            new SampleClientBuilder("CredentialAndQuotaProject") { Credential = GoogleCredential.FromJson(DummyServiceAccountCredentialFileContents), QuotaProject = SampleQuotaProject },
        };

        [Theory, MemberData(nameof(InvalidCombinationsTheoryData))]
        public void InvalidCombination(SampleClientBuilder builder)
        {
            Assert.Throws<InvalidOperationException>(builder.ValidateForTest);
        }

        [Fact]
        public async Task HttpClientFactory()
        {
            var factory = new HttpClientFactory();
            var builder = new SampleClientBuilder { HttpClientFactory = factory };
            await ValidateResultAsync(builder, initializer => Assert.Same(factory, initializer.HttpClientFactory));
        }

        private async Task ValidateResultAsync(SampleClientBuilder builder, Action<BaseClientService.Initializer> validator)
        {
            var initializer = builder.Build();
            validator(initializer);
            initializer = await builder.BuildAsync(default);
            validator(initializer);
        }

        public class SampleClientBuilder : ClientBuilderBase<BaseClientService.Initializer>
        {
            private readonly string _name;

            /// <summary>
            /// Constructor assigning a "name" to a builder for the sake of theory tests.
            /// </summary>
            public SampleClientBuilder(string name) => _name = name;

            public SampleClientBuilder() : this("Unnamed")
            {
            }

            public void ValidateForTest() => Validate();

            public override BaseClientService.Initializer Build() 
            {
                Validate();
                return CreateServiceInitializer();
            }

            public override async Task<BaseClientService.Initializer> BuildAsync(CancellationToken cancellationToken = default)
            {
                Validate();
                return await CreateServiceInitializerAsync(cancellationToken);
            }

            protected override string GetDefaultApplicationName() => ClientBuilderBaseTest.DefaultApplicationName;

            protected override ScopedCredentialProvider GetScopedCredentialProvider() =>
                new ScopedCredentialProvider(new[] { "SampleScope" });

            public override string ToString() => _name;
        }

        private class FakeMessageHandler : HttpMessageHandler
        {
            public HttpRequestHeaders LatestRequestHeaders { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                LatestRequestHeaders = request.Headers;
                return Task.FromResult(new HttpResponseMessage());
            }
        }
    }
}
