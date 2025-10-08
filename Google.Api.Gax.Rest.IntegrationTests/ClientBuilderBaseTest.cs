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
using static Google.Api.Gax.Testing.TestCredentials;

namespace Google.Api.Gax.Rest.IntegrationTests
{
    public class ClientBuilderBaseTest
    {
        private const string SampleApiKey = "SampleApiKey";
        private const string DefaultApplicationName = "DefaultApplicationName";
        private const string SampleQuotaProject = "SampleQuotaProject";

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
                GoogleCredential = CreateTestServiceAccountCredential()
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
                GoogleCredential = CreateTestServiceAccountCredential(),
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

#pragma warning disable CS0618 // Type or member is obsolete
        [Fact]
        public async Task JsonCredentials()
        {
            var builder = new SampleClientBuilder { JsonCredentials = TestServiceAccountJson };
            await ValidateResultAsync(builder, initializer => Assert.IsAssignableFrom<GoogleCredential>(initializer.HttpClientInitializer));
        }

        [Fact]
        public async Task JsonCredentials_QuotaProject()
        {
            var builder = new SampleClientBuilder 
            { 
                JsonCredentials = TestServiceAccountJson,
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
            File.WriteAllText(file, TestServiceAccountJson);

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
            File.WriteAllText(file, TestServiceAccountJson);

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
#pragma warning restore CS0618 // Type or member is obsolete

        [Fact]
        public async Task CustomCredential()
        {
            var credential = CreateTestServiceAccountCredential();
            var builder = new SampleClientBuilder { Credential = credential };
            await ValidateResultAsync(builder, initializer => Assert.Same(credential, initializer.HttpClientInitializer));
        }

        public static TheoryData<SampleClientBuilder> InvalidCombinationsTheoryData = new TheoryData<SampleClientBuilder>
        {
#pragma warning disable CS0618 // Type or member is obsolete
            new SampleClientBuilder("CredentialsPathAndJsonCredentials") { CredentialsPath = "foo.json", JsonCredentials = TestServiceAccountJson },
            new SampleClientBuilder("CredentialAndJsonCredentials") { Credential = CreateTestServiceAccountCredential(), JsonCredentials = TestServiceAccountJson },
            new SampleClientBuilder("CredentialAndCredentialsPath") { Credential = CreateTestServiceAccountCredential(), CredentialsPath = "foo.json" },
#pragma warning restore CS0618 // Type or member is obsolete
            new SampleClientBuilder("CredentialAndQuotaProject") { Credential = CreateTestServiceAccountCredential(), QuotaProject = SampleQuotaProject },
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
