/*
 * Copyright 2025 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Google.Protobuf;
using Google.Api.Gax.Grpc.Tests;
using System.Threading;

namespace Google.Api.Gax.Grpc.Gcp.Tests
{
    public class GcpCallInvokerTest
    {
        private static readonly ServiceMetadata s_serviceMetadata = TestServiceMetadata.TestService;
        private const string Target = "test.googleapis.com";
        private static readonly ChannelCredentials s_credentials = ChannelCredentials.Insecure;
        private static readonly GrpcChannelOptions s_options = GrpcChannelOptions.Empty;

        internal const string BindMethodName = "/test.v1.TestService/BindMethod";
        internal const string BoundMethodName = "/test.v1.TestService/BoundMethod";
        internal const string BindAndBoundMethodName = "/test.v1.TestService/BindAndBoundMethod";
        internal const string UnbindMethodName = "/test.v1.TestService/UnbindMethod";

        internal const string IntroduceDelayKey = "introduceDelayKey";

        private static readonly Method<SimpleRequest, SimpleResponse> s_bindMethod = NewMethod("BindMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_boundMethod = NewMethod("BoundMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_bindAndBoundMethod = NewMethod("BindAndBoundMethod");
        private static readonly Method<SimpleRequest, SimpleResponse> s_unbindMethod = NewMethod("UnbindMethod");

        private static Method<SimpleRequest, SimpleResponse> NewMethod(string methodName) =>
            new Method<SimpleRequest, SimpleResponse>(MethodType.Unary, "test.v1.TestService", methodName, Marshallers.Create(pb => pb.ToByteArray(), SimpleRequest.Parser.ParseFrom), Marshallers.Create(pb => pb.ToByteArray(), SimpleResponse.Parser.ParseFrom));

        private static readonly ApiConfig s_apiConfig = new ApiConfig
        {
            ChannelPool = new ChannelPoolConfig { MaxSize = 10, MaxConcurrentStreamsLowWatermark = 1 },
            Method =
            {
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
            await invoker.AsyncUnaryCall(s_bindMethod, null, default, request).ResponseAsync;

            // Assert
            Assert.Single(fakeAdapter.CreatedChannels);
            var channel = fakeAdapter.CreatedChannels[0];
            Assert.Single(channel.CallInvoker.Calls);
            Assert.Equal(s_bindMethod, channel.CallInvoker.Calls[0].Method);
        }

        [Fact]
        public async Task BindAndBound_DiffRpc_SameAffinity_ReusesChannel()
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
        }

        [Fact]
        public async Task BindAndBound_DiffRpc_DiffAffinity_NewChannel()
        {
            // Arrange
            var fakeAdapter = new FakeGrpcAdapter();
            var invoker = new GcpCallInvoker(s_serviceMetadata, Target, s_credentials, s_options, s_apiConfig, fakeAdapter);
            var nonSharedKeyBound = "nonSharedKey2";
            var bindRequest = new SimpleRequest { Name = IntroduceDelayKey };
            var boundRequest = new SimpleRequest { Name = nonSharedKeyBound };


            // Bind and Bound RPCs need to run in parralel to be able to create a new Channel each based on the MaxConcurrentStreamsLowWatermark setting
            Task task1 = Task.Run(() => invoker.AsyncUnaryCall(s_bindMethod, null, default, bindRequest).ResponseAsync);
            Task task2 = Task.Run(() => invoker.AsyncUnaryCall(s_boundMethod, null, default, boundRequest).ResponseAsync);

            await task1;
            await task2;

            var bindChannel = fakeAdapter.CreatedChannels.First();
            var boundChannel = fakeAdapter.CreatedChannels.Last();

            // Assert
            Assert.Equal(2, fakeAdapter.CreatedChannels.Count);
            Assert.NotEqual(bindChannel, boundChannel);
            Assert.Single(bindChannel.CallInvoker.Calls);
            Assert.Single(boundChannel.CallInvoker.Calls);
            Assert.Equal(s_bindMethod, bindChannel.CallInvoker.Calls[0].Method);
            Assert.Equal(s_boundMethod, boundChannel.CallInvoker.Calls[0].Method);
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
        }

        [Fact]
        public async Task BindAndUnbind_Success()
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

            // Act 2: Unbind
            await invoker.AsyncUnaryCall(s_unbindMethod, null, default, unbindRequest).ResponseAsync;

            // Assert
            Assert.Single(fakeAdapter.CreatedChannels);
            Assert.Equal(s_bindMethod, bindChannel.CallInvoker.Calls[0].Method);
            Assert.Equal(s_unbindMethod, bindChannel.CallInvoker.Calls[1].Method);
        }
    }

    public class FakeGrpcAdapter : GrpcAdapter
    {
        public List<FakeChannel> CreatedChannels { get; } = new List<FakeChannel>();

        public FakeGrpcAdapter() : base(ApiTransports.Grpc) { }

        private protected override ChannelBase CreateChannelImpl(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            var channel = new FakeChannel(CreatedChannels.Count.ToString());
            CreatedChannels.Add(channel);
            return channel;
        }
    }

    public class FakeChannel : ChannelBase
    {
        public string Id { get; }
        public FakeCallInvoker CallInvoker { get; }

        public FakeChannel(string id) : base("test-" + id)
        {
            Id = id;
            CallInvoker = new FakeCallInvoker(this);
        }

        public override CallInvoker CreateCallInvoker() => CallInvoker;
    }

    public class FakeCallInvoker : CallInvoker
    {
        public FakeChannel Channel { get; }
        public List<(Method<SimpleRequest, SimpleResponse> Method, SimpleRequest Request)> Calls { get; } = new List<(Method<SimpleRequest, SimpleResponse>, SimpleRequest)>();

        public FakeCallInvoker(FakeChannel channel)
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
                response.Name = srRequest.Name;

                if (srRequest.Name.Equals(GcpCallInvokerTest.IntroduceDelayKey))
                {
                    // This is to aid new channel creations for different RPCs having different affinity key values
                    // If we do not do this, the channel gets freed up and reused in the test (which is what we want for most of the tests)

                    // TODO: Substitute Thread.Sleep with FakeScheduler.Delay
                    Thread.Sleep(5000);
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