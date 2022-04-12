/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Rest;
using Google.Apis.Auth.OAuth2;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public partial class ClientBuilderBaseTest
    {
        /// <summary>
        /// Tests for <see cref="ClientBuilderBase{TClient}.Configure(IServiceProvider)"/>.
        /// </summary>
        public class DependencyInjection
        {
            [Fact]
            public void GrpcAdapter_NotSetBefore_SingleMatching()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddGrpcNetClientAdapter();
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.IsType<GrpcNetClientAdapter>(builder.GrpcAdapter);
            }

            [Fact]
            public void GrpcAdapter_NotSetBefore_SingleNonMatching()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddRestGrpcAdapter();
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.Null(builder.GrpcAdapter);
            }

            [Fact]
            public void GrpcAdapter_NotSetBefore_MultipleFirstMatchUsed()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddRestGrpcAdapter();
                serviceCollection.AddGrpcNetClientAdapter();
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.IsType<GrpcNetClientAdapter>(builder.GrpcAdapter);
            }

            [Fact]
            public void GrpcAdapter_SetBefore()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddGrpcNetClientAdapter();
                var builder = new FakeBuilder { GrpcAdapter = RestGrpcAdapter.Default };
                builder.Configure(serviceCollection);
                Assert.IsType<RestGrpcAdapter>(builder.GrpcAdapter);
            }

            [Fact]
            public void CallInvoker_NotSetBefore()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<CallInvoker>(new FakeCallInvoker());
                serviceCollection.AddGrpcNetClientAdapter();
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.IsType<FakeCallInvoker>(builder.CallInvoker);
                // Because the CallInvoker was set, nothing else was fetched.
                Assert.Null(builder.GrpcAdapter);
            }

            [Fact]
            public void CallInvoker_SetBefore()
            {
                var manual = new FakeCallInvoker();
                var injected = new FakeCallInvoker();
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<CallInvoker>(injected);
                serviceCollection.AddGrpcNetClientAdapter();
                var builder = new FakeBuilder { CallInvoker = manual };
                builder.Configure(serviceCollection);
                Assert.Same(manual, builder.CallInvoker);
                // Because the CallInvoker was set, the gRPC adapter wasn't injected
                Assert.Null(builder.GrpcAdapter);
            }

            [Fact]
            public void Logger_NotSetBefore()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<CallInvoker>(new FakeCallInvoker());
                serviceCollection.AddLogging(builder => builder.AddProvider(new MemoryLoggerProvider()));
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                // The logger factory and CallInvoker can be injected independently
                Assert.NotNull(builder.Logger);
                Assert.IsType<FakeCallInvoker>(builder.CallInvoker);
            }

            [Fact]
            public void Logger_SetBefore()
            {
                var manual = new MemoryLogger<string>();
                var injected = new MemoryLogger<string>();
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton<ILogger<string>>(injected);
                serviceCollection.AddGrpcNetClientAdapter();
                var builder = new FakeBuilder { Logger = manual };
                builder.Configure(serviceCollection);
                Assert.Same(manual, builder.Logger);
            }

            [Fact]
            public void GrpcChannelOptions_NotSetBefore()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton(GrpcChannelOptions.Empty.WithMaxReceiveMessageSize(10));
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.Equal(10, builder.GrpcChannelOptions.MaxReceiveMessageSize);
            }

            [Fact]
            public void GrpcChannelOptions_SetBefore()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton(GrpcChannelOptions.Empty.WithMaxReceiveMessageSize(10));
                var builder = new FakeBuilder { GrpcChannelOptions = GrpcChannelOptions.Empty.WithMaxSendMessageSize(20) };
                builder.Configure(serviceCollection);
                // The manually-set option is present
                Assert.Equal(20, builder.GrpcChannelOptions.MaxSendMessageSize);
                // The injected option isn't present - we don't merge
                Assert.Null(builder.GrpcChannelOptions.MaxReceiveMessageSize);
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
                    builder => builder.ChannelCredentials = ChannelCredentials.Insecure,
                    builder => builder.JsonCredentials = "{}",
                    builder => builder.CredentialsPath = "abc",
                    builder => builder.Credential = GoogleCredential.FromJson(s_serviceAccountJson),
                    builder => builder.GoogleCredential = GoogleCredential.FromJson(s_serviceAccountJson),
                    builder => builder.TokenAccessMethod = (_, __) => null,
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
            public void CredentialsPrecedence_ChannelCredentials()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddSingleton(ChannelCredentials.Insecure);
                serviceCollection.AddSingleton<ICredential>(GoogleCredential.FromJson(s_serviceAccountJson));
                serviceCollection.AddSingleton(GoogleCredential.FromJson(s_serviceAccountJson));
                var builder = new FakeBuilder();
                builder.Configure(serviceCollection);
                Assert.Same(ChannelCredentials.Insecure, builder.ChannelCredentials);
                Assert.Null(builder.Credential);
                Assert.Null(builder.GoogleCredential);
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
                Assert.Null(builder.ChannelCredentials);
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
                Assert.Null(builder.ChannelCredentials);
                Assert.Null(builder.Credential);
                Assert.Same(credential, builder.GoogleCredential);
            }

            private class FakeBuilder : ClientBuilderBase<string>
            {
                internal FakeBuilder() : base(TestServiceMetadata.TestService)
                {
                }

                // Note: this takes an IServiceCollection instead of an IServiceProvider just for the convenience of testing.
                public void Configure(IServiceCollection collection) => base.Configure(collection.BuildServiceProvider());

                public new GrpcChannelOptions GetChannelOptions() => throw new NotImplementedException();
                public override string Build() => throw new NotImplementedException();
                public override Task<string> BuildAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
                protected override ChannelPool GetChannelPool() => throw new NotImplementedException();
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
        }
    }
}
