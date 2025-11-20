/*
 * Copyright 2024 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Google.Protobuf;
using Google.Api.Gax.Grpc.Tests;

namespace Google.Api.Gax.Grpc.Gcp.Tests
{
    public class GcpCallInvokerTest
    {
        private static readonly ServiceMetadata s_serviceMetadata = TestServiceMetadata.TestService;
        private const string Target = "test.googleapis.com";
        private static readonly ChannelCredentials s_credentials = ChannelCredentials.Insecure;
        private static readonly GrpcChannelOptions s_options = GrpcChannelOptions.Empty;

        internal const string BindOnlyMethodName = "/test.v1.TestService/BindOnlyMethod";
        internal const string BindMethodName = "/test.v1.TestService/BindMethod";
        internal const string BoundMethodName = "/test.v1.TestService/BoundMethod";
        internal const string BindAndBoundMethodName = "/test.v1.TestService/BindAndBoundMethod";
        internal const string UnbindMethodName = "/test.v1.TestService/UnbindMethod";

        private static readonly Method<SimpleRequest, SimpleResponse> s_bindOnlyMethod = NewMethod("BindOnlyMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_bindMethod = NewMethod("BindMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_boundMethod = NewMethod("BoundMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_bindAndBoundMethod = NewMethod("BindAndBoundMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_unbindMethod = NewMethod("UnbindMethod");

        private static Method<SimpleRequest, SimpleResponse> NewMethod(string methodName) =>
            new Method<SimpleRequest, SimpleResponse>(MethodType.Unary, "test.v1.TestService", methodName, Marshallers.Create(pb => pb.ToByteArray(), SimpleRequest.Parser.ParseFrom), Marshallers.Create(pb => pb.ToByteArray(), SimpleResponse.Parser.ParseFrom));

        private static readonly ApiConfig s_apiConfig = new ApiConfig
        {
            ChannelPool = new ChannelPoolConfig { MaxSize = 10, MaxConcurrentStreamsLowWatermark = 5 },
            Method =
            {
                new MethodConfig { Name = { BindOnlyMethodName }, Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bind, AffinityKey = "name" } },
                new MethodConfig { Name = { BindMethodName }, Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bind, AffinityKey = "name" } },
                new MethodConfig { Name = { BoundMethodName }, Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bound, AffinityKey = "name" } },
                new MethodConfig { Name = { BindAndBoundMethodName }, Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bind, AffinityKey = "name" } },
                new MethodConfig { Name = { BindAndBoundMethodName }, Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Bound, AffinityKey = "name" } },
                new MethodConfig { Name = { UnbindMethodName }, Affinity = new AffinityConfig { Command = AffinityConfig.Types.Command.Unbind, AffinityKey = "name" } },
            }
        };

        [Fact]
        public async Task BindOnly_UsesAvailableChannel()
        {
            // Arrange
            var fakeAdapter = new FakeGrpcAdapter();
            var invoker = new GcpCallInvoker(s_serviceMetadata, Target, s_credentials, s_options, s_apiConfig, fakeAdapter);
            var key = "testKey1";
            var request = new SimpleRequest { Name = key };

            // Act
            await invoker.AsyncUnaryCall(s_bindOnlyMethod, null, default, request).ResponseAsync;

            // Assert
            Assert.Single(fakeAdapter.CreatedChannels);
            var channel = fakeAdapter.CreatedChannels[0];
            Assert.Single(channel.CallInvoker.Calls);
            Assert.Equal(s_bindOnlyMethod, channel.CallInvoker.Calls[0].Method);

            var affinityMap = invoker.GetChannelRefsByAffinityKeyForTest();
            Assert.True(affinityMap.ContainsKey(key), $"Key '{key}' not found in affinity map.");
            Assert.Equal(1, affinityMap[key].AffinityCount);
            Assert.Same(channel, affinityMap[key].Channel);
        }

        [Fact]
        public async Task BindAndBound_DiffRpc_ReusesChannel()
        {
            // Arrange
            var fakeAdapter = new FakeGrpcAdapter();
            var invoker = new GcpCallInvoker(s_serviceMetadata, Target, s_credentials, s_options, s_apiConfig, fakeAdapter);
            var key = "sharedKey1";
            var bindRequest = new SimpleRequest { Name = key };
            var boundRequest = new SimpleRequest { Name = key };

            // Act 1: Bind
            await invoker.AsyncUnaryCall(s_bindMethod, null, default, bindRequest).ResponseAsync;
            var bindChannel = fakeAdapter.CreatedChannels.Last();

            // Act 2: Bound
            await invoker.AsyncUnaryCall(s_boundMethod, null, default, boundRequest).ResponseAsync;
            var boundChannel = fakeAdapter.CreatedChannels.Last();

            // Assert
            Assert.Single(fakeAdapter.CreatedChannels);
            Assert.Same(bindChannel, boundChannel);
            Assert.Equal(s_bindMethod, bindChannel.CallInvoker.Calls[0].Method);
            Assert.Equal(s_boundMethod, bindChannel.CallInvoker.Calls[1].Method);

            var affinityMap = invoker.GetChannelRefsByAffinityKeyForTest();
            Assert.True(affinityMap.ContainsKey(key), $"Key '{key}' not found in affinity map.");
        }

        [Fact]
        public async Task BindAndBound_SameRpc_ReusesChannel()
        {
            // Arrange
            var fakeAdapter = new FakeGrpcAdapter();
            var invoker = new GcpCallInvoker(s_serviceMetadata, Target, s_credentials, s_options, s_apiConfig, fakeAdapter);
            var key = "selfBoundKey1";
            var request = new SimpleRequest { Name = key };

            // Act 1: First call (binds)
            await invoker.AsyncUnaryCall(s_bindAndBoundMethod, null, default, request).ResponseAsync;
            var channel1 = fakeAdapter.CreatedChannels.Last();

            // Act 2: Second call (should use bound channel)
            await invoker.AsyncUnaryCall(s_bindAndBoundMethod, null, default, request).ResponseAsync;
            var channel2 = fakeAdapter.CreatedChannels.Last();

            // Assert
            Assert.Single(fakeAdapter.CreatedChannels);
            Assert.Same(channel1, channel2);
            Assert.Equal(2, channel1.CallInvoker.Calls.Count);
            Assert.Equal(s_bindAndBoundMethod, channel1.CallInvoker.Calls[0].Method);
            Assert.Equal(s_bindAndBoundMethod, channel1.CallInvoker.Calls[1].Method);

            var affinityMap = invoker.GetChannelRefsByAffinityKeyForTest();
            Assert.True(affinityMap.ContainsKey(key), $"Key '{key}' not found in affinity map.");
            Assert.Equal(2, affinityMap[key].AffinityCount);
        }

        [Fact]
        public async Task BindAndUnbind_FreesChannel()
        {
            // Arrange
            var fakeAdapter = new FakeGrpcAdapter();
            var invoker = new GcpCallInvoker(s_serviceMetadata, Target, s_credentials, s_options, s_apiConfig, fakeAdapter);
            var key = "bindUnbindKey1";
            var bindRequest = new SimpleRequest { Name = key };
            var unbindRequest = new SimpleRequest { Name = key };

            // Act 1: Bind
            await invoker.AsyncUnaryCall(s_bindMethod, null, default, bindRequest).ResponseAsync;
            var bindChannel = fakeAdapter.CreatedChannels.Last();
            var affinityMap1 = invoker.GetChannelRefsByAffinityKeyForTest();
            Assert.True(affinityMap1.ContainsKey(key), $"Key '{key}' not found in affinity map after Bind.");

            // Act 2: Unbind
            await invoker.AsyncUnaryCall(s_unbindMethod, null, default, unbindRequest).ResponseAsync;

            // Assert
            Assert.Single(fakeAdapter.CreatedChannels);
            Assert.Equal(s_bindMethod, bindChannel.CallInvoker.Calls[0].Method);
            Assert.Equal(s_unbindMethod, bindChannel.CallInvoker.Calls[1].Method);

            var affinityMap2 = invoker.GetChannelRefsByAffinityKeyForTest();
            Assert.False(affinityMap2.ContainsKey(key), $"Key '{key}' still found in affinity map after Unbind.");
        }
    }

    public class FakeGrpcAdapter : GrpcAdapter
    {
        public List<FakeChannelBase> CreatedChannels { get; } = new List<FakeChannelBase>();

        public FakeGrpcAdapter() : base(ApiTransports.Grpc) { }

        private protected override ChannelBase CreateChannelImpl(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            var channel = new FakeChannelBase(CreatedChannels.Count.ToString());
            CreatedChannels.Add(channel);
            return channel;
        }
    }

    public class FakeChannelBase : ChannelBase
    {
        public string Id { get; }
        public FakeCallInvoker CallInvoker { get; }

        public FakeChannelBase(string id) : base("test-" + id)
        {
            Id = id;
            CallInvoker = new FakeCallInvoker(this);
        }

        public override CallInvoker CreateCallInvoker() => CallInvoker;
    }

    public class FakeCallInvoker : CallInvoker
    {
        public FakeChannelBase Channel { get; }
        public List<(Method<SimpleRequest, SimpleResponse> Method, SimpleRequest Request)> Calls { get; } = new List<(Method<SimpleRequest, SimpleResponse>, SimpleRequest)>();

        public FakeCallInvoker(FakeChannelBase channel)
        {
            Channel = channel;
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            if (method is Method<SimpleRequest, SimpleResponse> srMethod && request is SimpleRequest srRequest)
            {
                Calls.Add((srMethod, srRequest));

                SimpleResponse response = new SimpleResponse();
                // For Bind methods, the key is extracted from the response's "name" field.
                // We use the request's "name" to populate this for the test.
                if (method.FullName == GcpCallInvokerTest.BindMethodName || method.FullName == GcpCallInvokerTest.BindOnlyMethodName || method.FullName == GcpCallInvokerTest.BindAndBoundMethodName)
                {
                    response.Name = srRequest.Name;
                }
                return CreateAsyncUnaryCall(response as TResponse);
            }
            throw new NotSupportedException($"Method type not supported in fake: {method.Type}");
        }

        private AsyncUnaryCall<TResponse> CreateAsyncUnaryCall<TResponse>(TResponse response) where TResponse : class =>
            new AsyncUnaryCall<TResponse>(Task.FromResult(response), Task.FromResult(new Metadata()), () => Status.DefaultSuccess, () => new Metadata(), () => { });

        public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) => throw new NotImplementedException();
        public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) => throw new NotImplementedException();
        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
    }
}