/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Rest.Tests
{
    public partial class ClientBuilderBaseTest
    {
        /// <summary>
        /// Tests for <see cref="ClientBuilderBase{TClient}.Configure(IServiceProvider)"/>.
        /// </summary>
        public class DependencyInjection
        {
            [Fact]
            public void HttpClientFactory_NotSetBefore()
            {
                var factory = new HttpClientFactory();
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<IHttpClientFactory>(factory);
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.Same(factory, builder.HttpClientFactory);
            }

            [Fact]
            public void HttpClientFactory_SetBefore()
            {
                var manual = new HttpClientFactory();
                var dependency = new HttpClientFactory();
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<IHttpClientFactory>(dependency);
                var builder = new FakeBuilder { HttpClientFactory = manual };
                builder.Configure(serviceCollection);
                Assert.Same(manual, builder.HttpClientFactory);
            }

            [Fact]
            public void CredentialsNotUsedWhenAlreadySet()
            {
                var serviceCollection = new ServiceCollection();
                var dependencyCredential = GoogleCredential.FromJson(s_serviceAccountJson);
                serviceCollection.AddSingleton(dependencyCredential);
#pragma warning disable CS0618 // Type or member is obsolete
                Action<FakeBuilder>[] actions = new Action<FakeBuilder>[]
                {
                    builder => builder.JsonCredentials = "{}",
                    builder => builder.CredentialsPath = "abc",
                    builder => builder.Credential = GoogleCredential.FromJson(s_serviceAccountJson),
                    builder => builder.GoogleCredential = GoogleCredential.FromJson(s_serviceAccountJson),
                };
#pragma warning restore CS0618 // Type or member is obsolete
                foreach (var action in actions)
                {
                    var builder = new FakeBuilder();
                    action(builder);
                    builder.Configure(serviceCollection);
                    // Note that in one test we'll set the GoogleCredential to a non-null value, but
                    // it won't be the same object.
                    Assert.NotSame(dependencyCredential, builder.GoogleCredential);
                }
            }

            [Fact]
            public void CredentialsPrecedence_ICredential()
            {
                var credential1 = GoogleCredential.FromJson(s_serviceAccountJson);
                var credential2 = GoogleCredential.FromJson(s_serviceAccountJson);
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<ICredential>(credential1);
                serviceCollection.AddSingleton(credential2);
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.Same(credential1, builder.Credential);
                Assert.Null(builder.GoogleCredential);
            }

            [Fact]
            public void CredentialsPrecedence_GoogleCredential()
            {
                var credential = GoogleCredential.FromJson(s_serviceAccountJson);
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton(credential);
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.Null(builder.Credential);
                Assert.Same(credential, builder.GoogleCredential);
            }

            private class FakeBuilder : ClientBuilderBase<string>
            {
                // Note: this takes an IServiceCollection instead of an IServiceProvider just for the convenience of testing.
                public void Configure(IServiceCollection collection) => base.Configure(collection.BuildServiceProvider());

                public override string Build() =>
                    throw new NotImplementedException();

                public override Task<string> BuildAsync(CancellationToken cancellationToken = default) =>
                    throw new NotImplementedException();

                protected override string GetDefaultApplicationName() =>
                    throw new NotImplementedException();

                protected override ScopedCredentialProvider GetScopedCredentialProvider() =>
                    throw new NotImplementedException();
            }
        }
    }
}
