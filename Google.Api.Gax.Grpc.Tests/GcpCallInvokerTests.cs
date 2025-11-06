/*
 * Copyright 2025 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using NSubstitute;
using System.Linq;
using Xunit;
using Google.Api.Gax.Grpc.Tests;

namespace Google.Api.Gax.Grpc.Gcp.Tests
{
    public class GcpCallInvokerTest
    {
        private static readonly ServiceMetadata s_serviceMetadata = TestServiceMetadata.TestService;
        private const string Target = "test.googleapis.com";
        private static readonly ChannelCredentials s_credentials = ChannelCredentials.Insecure;
        private static readonly GrpcChannelOptions s_options = GrpcChannelOptions.Empty;
        private static readonly ApiConfig s_apiConfig = new ApiConfig
        {
            ChannelPool = new ChannelPoolConfig { MaxSize = 10, MaxConcurrentStreamsLowWatermark = 5 },
            Method =
            {
                new MethodConfig
                {
                    Name = { "test.v1.BindTestService/BindMethod" },
                    Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bind, AffinityKey = "name" }
                },
                new MethodConfig
                {
                    Name = { "test.v1.UnbindTestService/UnbindMethod" },
                    Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Unbind, AffinityKey = "name" }
                },
                new MethodConfig
                {
                    Name = { "test.v1.BoundTestService/BoundMethod" },
                    Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bound, AffinityKey = "name" }
                }
            }
        };

        [Fact]
        public void InitAffinityByMethodIndex_Succeeds()
        {
            // Act
            var affinityByMethod = GcpCallInvoker.InitAffinityByMethodIndex(s_apiConfig);

            // Assert
            Assert.Equal(3, affinityByMethod.Count);
            Assert.Equal(AffinityConfig.Types.Command.Bind, affinityByMethod["test.v1.BindTestService/BindMethod"].Command);
            Assert.Equal(AffinityConfig.Types.Command.Unbind, affinityByMethod["test.v1.UnbindTestService/UnbindMethod"].Command);
            Assert.Equal(AffinityConfig.Types.Command.Bound, affinityByMethod["test.v1.BoundTestService/BoundMethod"].Command);
        }

        [Fact]
        public void Bind_NewKey_AddsKey()
        {
            // Arrange
            var invoker = CreateInvoker();
            var channelRef = new ChannelRef(new FakeChannelBase(), 0);
            string key = "newKey";

            // Act
            invoker.Bind(channelRef, key);

            // Assert
            Assert.True(invoker._channelRefByAffinityKey.ContainsKey(key));
            Assert.Equal(1, invoker._channelRefByAffinityKey[key].AffinityCount);
            Assert.Same(channelRef, invoker._channelRefByAffinityKey[key]);
        }

        [Fact]
        public void Bind_ExistingKey_IncrementsCount()
        {
            // Arrange
            var invoker = CreateInvoker();
            var channelRef = new ChannelRef(new FakeChannelBase(), 0);
            string key = "existingKey";
            invoker.Bind(channelRef, key);

            // Act
            invoker.Bind(channelRef, key);

            // Assert
            Assert.True(invoker._channelRefByAffinityKey.ContainsKey(key));
            Assert.Equal(2, invoker._channelRefByAffinityKey[key].AffinityCount);
        }

        [Fact]
        public void Unbind_ExistingKey_DecrementsCountOrRemoves()
        {
            // Arrange
            var invoker = CreateInvoker();
            var channelRef = new ChannelRef(new FakeChannelBase(), 0);
            string key = "existingKey";
            invoker.Bind(channelRef, key);
            invoker.Bind(channelRef, key);

            // Act
            invoker.Unbind(key);

            // Assert
            Assert.True(invoker._channelRefByAffinityKey.ContainsKey(key));
            Assert.Equal(1, invoker._channelRefByAffinityKey[key].AffinityCount);

            // Act
            invoker.Unbind(key);

            // Assert
            Assert.False(invoker._channelRefByAffinityKey.ContainsKey(key));
        }

        [Fact]
        public void Unbind_NonExistingKey_DoesNotThrow()
        {
            // Arrange
            var invoker = CreateInvoker();
            string key = "nonExistingKey";

            // Act
            invoker.Unbind(key); // Should not throw

            // Assert
            Assert.False(invoker._channelRefByAffinityKey.ContainsKey(key));
        }

        [Theory]
        [InlineData(AffinityConfig.Types.Command.Bound)]
        [InlineData(AffinityConfig.Types.Command.Unbind)]
        public void PreProcess_ReturnsExistingChannelRef(AffinityConfig.Types.Command affinityCommand)
        {
            // Arrange
            var invoker = CreateInvoker();
            var bindChannelRef = new ChannelRef(new FakeChannelBase(), 0);
            string key = "testKey";
            invoker.Bind(bindChannelRef, key);
            var request = new SimpleRequest { Name = key };
            var affinityConfig = s_apiConfig.Method.First(m => m.Affinity.Command == affinityCommand).Affinity;

            // Act
            var channelRef = invoker.PreProcess(affinityConfig, request);

            // Assert
            Assert.NotNull(channelRef);
            Assert.Same(bindChannelRef, channelRef);
            Assert.Equal(1, channelRef.ActiveStreamCount);
        }

        [Fact]
        public void PreProcess_Bound_KeyNotFound_ReturnsNewChannelRef()
        {
            // Arrange
            var invoker = CreateInvoker();
            var request = new SimpleRequest { Name = "notFoundKey" };
            var affinityConfig = s_apiConfig.Method.First(m => m.Affinity.Command == AffinityConfig.Types.Command.Bound).Affinity;
            var existingChannelRef = new ChannelRef(new FakeChannelBase(), 0);
            invoker.Bind(existingChannelRef, "anotherKey");

            // Act
            var channelRef = invoker.PreProcess(affinityConfig, request);

            // Assert
            Assert.NotNull(channelRef);
            Assert.NotSame(existingChannelRef, channelRef);
            Assert.Equal(1, channelRef.ActiveStreamCount);
        }

        [Fact]
        public void PostProcess_Bind_AddsKey()
        {
            // Arrange
            var invoker = CreateInvoker();
            var channelRef = new ChannelRef(new FakeChannelBase(), 0);
            channelRef.ActiveStreamCountIncr();
            var request = new SimpleRequest();
            string key = "bindKey";
            var response = new SimpleResponse { Name = key };
            var affinityConfig = s_apiConfig.Method.First(m => m.Affinity.Command == AffinityConfig.Types.Command.Bind).Affinity;

            // Act
            invoker.PostProcess(affinityConfig, channelRef, request, response);

            // Assert
            Assert.Equal(0, channelRef.ActiveStreamCount);
            Assert.True(invoker._channelRefByAffinityKey.ContainsKey(key));
            Assert.Equal(1, invoker._channelRefByAffinityKey[key].AffinityCount);
            Assert.Same(channelRef, invoker._channelRefByAffinityKey[key]);
        }

        [Fact]
        public void PostProcess_Unbind_RemovesKey()
        {
            // Arrange
            var invoker = CreateInvoker();
            var channelRef = new ChannelRef(new FakeChannelBase(), 0);
            string key = "unbindKey";
            invoker.Bind(channelRef, key);
            channelRef.ActiveStreamCountIncr();
            var request = new SimpleRequest { Name = key };
            var response = new SimpleResponse();
            var affinityConfig = s_apiConfig.Method.First(m => m.Affinity.Command == AffinityConfig.Types.Command.Unbind).Affinity;

            // Act
            invoker.PostProcess(affinityConfig, channelRef, request, response);

            // Assert
            Assert.Equal(0, channelRef.ActiveStreamCount);
            Assert.False(invoker._channelRefByAffinityKey.ContainsKey(key));
        }

        [Fact]
        public void PostProcess_Failure_NoAffinityChange()
        {
            // Arrange
            var invoker = CreateInvoker();
            var channelRef = new ChannelRef(new FakeChannelBase(), 0);
            channelRef.ActiveStreamCountIncr();
            var request = new SimpleRequest { Name = "key" };
            SimpleResponse response = null; // Simulate failure
            var affinityConfig = s_apiConfig.Method.First(m => m.Affinity.Command == AffinityConfig.Types.Command.Bind).Affinity;

            // Act
            invoker.PostProcess(affinityConfig, channelRef, request, response);

            // Assert
            Assert.Equal(0, channelRef.ActiveStreamCount);
            Assert.Empty(invoker._channelRefByAffinityKey);
        }

        private GcpCallInvoker CreateInvoker()
        {
            var fakeAdapter = new FakeGrpcAdapter();
            return new GcpCallInvoker(s_serviceMetadata, Target, s_credentials, s_options, s_apiConfig, fakeAdapter);
        }
    }

    // Dummy GrpcAdapter for testing
    public class FakeGrpcAdapter : GrpcAdapter
    {
        public FakeGrpcAdapter() : base(ApiTransports.Grpc) { }

        private protected override ChannelBase CreateChannelImpl(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            new FakeChannelBase();
    }

    // Dummy ChannelBase for testing
    public class FakeChannelBase : ChannelBase
    {
        public FakeChannelBase() : base("test") { }

        public override CallInvoker CreateCallInvoker() => Substitute.For<CallInvoker>();
    }
}