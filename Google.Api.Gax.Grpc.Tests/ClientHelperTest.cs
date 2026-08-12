/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ClientHelperTest
    {
        [Fact]
        public void BuildApiCall_ClientSettings()
        {
            var clientSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var options = new ClientHelper.Options { Settings = new SimpleSettings { CallSettings = clientSettings } };
            var helper = new ClientHelper(options);
            var server = new TestServer();

            var unaryCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                "Method", server.UnaryAsync, server.UnarySync, null);
            unaryCall.Sync(null, null);
            Assert.Equal(clientSettings.CancellationToken, server.UnaryCallOptions.CancellationToken);

            var serverStreamingCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>("Method", server.ServerStreaming, null);
            serverStreamingCall.Call(null, null);
            Assert.Equal(clientSettings.CancellationToken, server.ServerStreamingCallOptions.CancellationToken);

            var bidiStreamingCall = helper.BuildApiCall("Method", server.BidiStreaming, null, null);
            bidiStreamingCall.Call(null);
            Assert.Equal(clientSettings.CancellationToken, server.BidiStreamingCallOptions.CancellationToken);

            var clientStreamingCall = helper.BuildApiCall("Method", server.ClientStreaming, null, null);
            clientStreamingCall.Call(null);
            Assert.Equal(clientSettings.CancellationToken, server.ClientStreamingCallOptions.CancellationToken);
        }

        [Fact]
        public void BuildApiCall_PerMethodSettings()
        {
            var perMethodSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var options = new ClientHelper.Options { Settings = new SimpleSettings() };
            var helper = new ClientHelper(options);
            var server = new TestServer();

            var unaryCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                "Method", server.UnaryAsync, server.UnarySync, perMethodSettings);
            unaryCall.Sync(null, null);
            Assert.Equal(perMethodSettings.CancellationToken, server.UnaryCallOptions.CancellationToken);

            var serverStreamingCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>("Method", server.ServerStreaming, perMethodSettings);
            serverStreamingCall.Call(null, null);
            Assert.Equal(perMethodSettings.CancellationToken, server.ServerStreamingCallOptions.CancellationToken);

            var bidiStreamingCall = helper.BuildApiCall("Method", server.BidiStreaming, perMethodSettings, null);
            bidiStreamingCall.Call(null);
            Assert.Equal(perMethodSettings.CancellationToken, server.BidiStreamingCallOptions.CancellationToken);

            var clientStreamingCall = helper.BuildApiCall("Method", server.ClientStreaming, perMethodSettings, null);
            clientStreamingCall.Call(null);
            Assert.Equal(perMethodSettings.CancellationToken, server.ClientStreamingCallOptions.CancellationToken);
        }

        [Fact]
        public void WithApiVersionHeader()
        {
            string apiVersion = "abc";
            var options = new ClientHelper.Options { Settings = new SimpleSettings(), ApiVersion = apiVersion };
            var helper = new ClientHelper(options);

            var server = new TestServer();

            var unaryCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                "Method", server.UnaryAsync, server.UnarySync, null);
            unaryCall.Sync(null, null);
            AssertVersionHeader(server.UnaryCallOptions);

            var serverStreamingCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>("Method", server.ServerStreaming, null);
            serverStreamingCall.Call(null, null);
            AssertVersionHeader(server.ServerStreamingCallOptions);

            var bidiStreamingCall = helper.BuildApiCall("Method", server.BidiStreaming, null, null);
            bidiStreamingCall.Call(null);
            AssertVersionHeader(server.BidiStreamingCallOptions);

            var clientStreamingCall = helper.BuildApiCall("Method", server.ClientStreaming, null, null);
            clientStreamingCall.Call(null);
            AssertVersionHeader(server.ClientStreamingCallOptions);

            void AssertVersionHeader(CallOptions callOptions)
            {
                var entry = Assert.Single(callOptions.Headers, entry => entry.Key == ClientHelper.ApiVersionHeaderName);
                Assert.Equal(apiVersion, entry.Value);
            }
        }

        [Fact]
        public void NoApiVersionHeader()
        {
            var options = new ClientHelper.Options { Settings = new SimpleSettings() };
            var helper = new ClientHelper(options);

            var server = new TestServer();

            var unaryCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                "Method", server.UnaryAsync, server.UnarySync, null);
            unaryCall.Sync(null, null);
            AssertNoVersionHeader(server.UnaryCallOptions);

            var serverStreamingCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>("Method", server.ServerStreaming, null);
            serverStreamingCall.Call(null, null);
            AssertNoVersionHeader(server.ServerStreamingCallOptions);

            var bidiStreamingCall = helper.BuildApiCall("Method", server.BidiStreaming, null, null);
            bidiStreamingCall.Call(null);
            AssertNoVersionHeader(server.BidiStreamingCallOptions);

            var clientStreamingCall = helper.BuildApiCall("Method", server.ClientStreaming, null, null);
            clientStreamingCall.Call(null);
            AssertNoVersionHeader(server.ClientStreamingCallOptions);

            void AssertNoVersionHeader(CallOptions callOptions) =>
                Assert.DoesNotContain(callOptions.Headers, entry => entry.Key == ClientHelper.ApiVersionHeaderName);
        }

        [Fact]
        public void BuildResumableUploadCall_NonRestCallInvoker_ThrowsArgumentException()
        {
            var options = new ClientHelper.Options { Settings = new SimpleSettings() };
            var helper = new ClientHelper(options);
            var dummyCallInvoker = new DummyCallInvoker();

            var ex = Assert.Throws<ArgumentException>(() =>
                helper.BuildResumableUploadCall<SimpleRequest, SimpleResponse>("google.showcase.v1beta1.Compliance", "UploadMedia", dummyCallInvoker, null));

            Assert.Contains("Resumable uploads require a REST transport (RestCallInvoker)", ex.Message);
        }

        [Fact]
        public void BuildResumableUploadCall_WithRestCallInvoker_ReturnsCall()
        {
            var options = new ClientHelper.Options { Settings = new SimpleSettings() };
            var helper = new ClientHelper(options);
            var serviceCollection = Rest.RestServiceCollection.Create(TestServiceMetadata.TestService.ApiMetadata);
            var channel = new Rest.RestChannel(serviceCollection, "localhost", ChannelCredentials.Insecure, GrpcChannelOptions.Empty);
            var restCallInvoker = (Rest.RestCallInvoker) channel.CreateCallInvoker();

            var apiCall = helper.BuildResumableUploadCall<SimpleRequest, SimpleResponse>("google.showcase.v1beta1.Compliance", "UploadMedia", restCallInvoker, null);

            Assert.NotNull(apiCall);
        }

        private class DummyCallInvoker : CallInvoker
        {
            public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) => throw new NotImplementedException();
            public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) => throw new NotImplementedException();
            public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
            public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
            public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) => throw new NotImplementedException();
        }



        private class SimpleSettings: ServiceSettingsBase
        {
            public SimpleSettings() { }
            private SimpleSettings(SimpleSettings existing) : base(existing) { }
            public SimpleSettings Clone() => new SimpleSettings(this);
        }

        private class TestServer
        {
            public CallOptions UnaryCallOptions { get; private set; }
            public CallOptions BidiStreamingCallOptions { get; private set; }
            public CallOptions ServerStreamingCallOptions { get; private set; }
            public CallOptions ClientStreamingCallOptions { get; private set; }

            internal AsyncUnaryCall<SimpleResponse> UnaryAsync(SimpleRequest request, CallOptions callOptions) =>
                throw new NotImplementedException();

            internal SimpleResponse UnarySync(SimpleRequest request, CallOptions callOptions)
            {
                UnaryCallOptions = callOptions;
                return null;
            }


            internal AsyncServerStreamingCall<SimpleResponse> ServerStreaming(SimpleRequest request, CallOptions callOptions)
            {
                ServerStreamingCallOptions = callOptions;
                return null;
            }

            internal AsyncDuplexStreamingCall<SimpleRequest, SimpleResponse> BidiStreaming(CallOptions callOptions)
            {
                BidiStreamingCallOptions = callOptions;
                return null;
            }

            internal AsyncClientStreamingCall<SimpleRequest, SimpleResponse> ClientStreaming(CallOptions callOptions)
            {
                ClientStreamingCallOptions = callOptions;
                return null;
            }
        }
    }
}
