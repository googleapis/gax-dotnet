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
            var helper = new ClientHelper(new SimpleSettings { CallSettings = clientSettings }, logger: null);
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
            var helper = new ClientHelper(new SimpleSettings(), logger: null);
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
