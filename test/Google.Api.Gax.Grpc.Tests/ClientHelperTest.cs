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
            var server = new DummyServer();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.MethodAsync, server.MethodSync, null);
            apiCall.Sync(null, null);
            Assert.Equal(clientSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildApiCall_PerMethodSettings()
        {
            var perMethodSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServer();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.MethodAsync, server.MethodSync, perMethodSettings);
            apiCall.Sync(null, null);
            Assert.Equal(perMethodSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        [Fact]
        public void BuildApiCall_PerCallSettings()
        {
            var perCallSettings = CallSettings.FromCancellationToken(new CancellationTokenSource().Token);
            var helper = new ClientHelper(new DummySettings());
            var server = new DummyServer();
            var apiCall = helper.BuildApiCall<SimpleRequest, SimpleResponse>(
                server.MethodAsync, server.MethodSync, null);
            apiCall.Sync(null, perCallSettings);
            Assert.Equal(perCallSettings.CancellationToken, server.CallOptions.CancellationToken);
        }

        private class DummySettings: ServiceSettingsBase
        {
            public DummySettings() { }

            private DummySettings(DummySettings existing) : base(existing) { }

            public DummySettings Clone() => new DummySettings(this);
        }

        private class DummyServer
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
    }
}
