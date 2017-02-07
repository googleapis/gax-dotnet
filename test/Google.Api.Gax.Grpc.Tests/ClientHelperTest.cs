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
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = clientSettings
            });
            var server = new DummyServerNonStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.MethodAsync, server.MethodSync, null);
            apiCall.Sync(null, null);
            Assert.Equal(clientSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildServerStreamingApiCall_ClientSettings()
        {
            var clientSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = clientSettings
            });
            var server = new DummyServerServerStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(server.Call, null);
            apiCall.Call(null, null);
            Assert.Equal(clientSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildBidiStreamingApiCall_ClientSettings()
        {
            var clientSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings
            {
                CallSettings = clientSettings
            });
            var server = new DummyServerBidiStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(server.Call, null, null);
            apiCall.Call(null);
            Assert.Equal(clientSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildApiCall_PerMethodSettings()
        {
            var perMethodSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServerNonStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.MethodAsync, server.MethodSync, perMethodSettings);
            apiCall.Sync(null, null);
            Assert.Equal(perMethodSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildServerStreamingApiCall_PerMethodSettings()
        {
            var perMethodSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServerServerStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(server.Call, perMethodSettings);
            apiCall.Call(null, null);
            Assert.Equal(perMethodSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildBidiStreamingApiCall_PerMethodSettings()
        {
            var perMethodSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServerBidiStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.Call, perMethodSettings, null);
            apiCall.Call(null);
            Assert.Equal(perMethodSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildApiCall_PerCallSettings()
        {
            var perCallSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServerNonStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.MethodAsync, server.MethodSync, null);
            apiCall.Sync(null, perCallSettings);
            Assert.Equal(perCallSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildServerStreamingApiCall_PerCallSettings()
        {
            var perCallSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServerServerStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(server.Call, null);
            apiCall.Call(null, perCallSettings);
            Assert.Equal(perCallSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildBidiStreamingApiCall_PerCallSettings()
        {
            var perCallSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServerBidiStreaming();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(server.Call, null, null);
            apiCall.Call(perCallSettings);
            Assert.Equal(perCallSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        private class DummySettings: ServiceSettingsBase
        {
            public DummySettings() { }

            private DummySettings(DummySettings existing) : base(existing) { }

            public DummySettings Clone() => new DummySettings(this);
        }

        private class DummyServerNonStreaming
        {
            public CallOptions CallOptions { get; private set; }

            internal AsyncUnaryCall<SimpleResponse> MethodAsync(SimpleRequest request, CallOptions callOptions)
            {
                throw new NotImplementedException();
            }

            internal SimpleResponse MethodSync(SimpleRequest request, CallOptions callOptions)
            {
                CallOptions = callOptions;
                return null;
            }
        }

        private class DummyServerServerStreaming
        {
            public CallOptions CallOptions { get; private set; }

            internal AsyncServerStreamingCall<SimpleResponse> Call(SimpleRequest request, CallOptions callOptions)
            {
                CallOptions = callOptions;
                return null;
            }
        }

        private class DummyServerBidiStreaming
        {
            public CallOptions CallOptions { get; private set; }

            internal AsyncDuplexStreamingCall<SimpleRequest, SimpleResponse> Call(CallOptions callOptions)
            {
                CallOptions = callOptions;
                return null;
            }
        }
    }
}
