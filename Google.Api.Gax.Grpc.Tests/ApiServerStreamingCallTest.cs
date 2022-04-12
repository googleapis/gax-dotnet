/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiServerStreamingCallTest
    {
        [Fact]
        public async Task FailWithRetry()
        {
            var apiCall = ApiServerStreamingCall.Create<int, int>(
                "Method",
                (request, callOptions) => null,
                CallSettings.FromRetry(new RetrySettings(5, TimeSpan.Zero, TimeSpan.Zero, 1.0, e => false, RetrySettings.RandomJitter)),
                new FakeClock());
            await Assert.ThrowsAsync<InvalidOperationException>(() => apiCall.CallAsync(0, null));
            Assert.Throws<InvalidOperationException>(() => apiCall.Call(0, null));
        }

        [Fact]
        public async Task SucceedWithExpiration()
        {
            var apiCall = ApiServerStreamingCall.Create<int, int>(
                "Method",
                (request, callOptions) => null,
                CallSettings.FromExpiration(Expiration.FromTimeout(TimeSpan.FromSeconds(100))),
                new FakeClock());
            Assert.Null(await apiCall.CallAsync(0, null));
            Assert.Null(apiCall.Call(0, null));
        }

        [Fact]
        public void WithCallSettingsOverlay()
        {
            var ctBase = new CancellationTokenSource().Token;
            var ctPerCall = new CancellationTokenSource().Token;
            var ctOverlay = new CancellationTokenSource().Token;

            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiServerStreamingCall<SimpleRequest, SimpleResponse>(
                "Method",
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                CallSettings.FromCancellationToken(ctBase));

            // Verify a null overlay has no effect.
            // CallAsync call runs synchonously due to 'call0' definition above.
            var call1 = call0.WithCallSettingsOverlay(req => null);
            call1.Call(null, CallSettings.FromCancellationToken(ctPerCall));
            call1.CallAsync(null, CallSettings.FromCancellationToken(ctPerCall));
            Assert.Equal(ctPerCall, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, syncCallSettings.CancellationToken.Value);
            Assert.Equal(ctPerCall, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, asyncCallSettings.CancellationToken.Value);

            // Verify an overlay overwrites all else.
            var call2 = call0.WithCallSettingsOverlay(req => CallSettings.FromCancellationToken(ctOverlay));
            call2.Call(null, CallSettings.FromCancellationToken(ctPerCall));
            call2.CallAsync(null, CallSettings.FromCancellationToken(ctPerCall));
            Assert.Equal(ctOverlay, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctPerCall, syncCallSettings.CancellationToken.Value);
            Assert.Equal(ctOverlay, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctPerCall, asyncCallSettings.CancellationToken.Value);
        }

        [Fact]
        public void WithGoogleRequestParam()
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiServerStreamingCall<SimpleRequest, SimpleResponse>(
                "Method",
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            var call1 = call0.WithGoogleRequestParam("parent", request => request.Name);
            call1.Call(new SimpleRequest { Name = "test" }, null);
            call1.CallAsync(new SimpleRequest { Name = "test" }, null);

            CallSettingsTest.AssertSingleHeader(syncCallSettings, CallSettings.RequestParamsHeader, "parent=test");
            CallSettingsTest.AssertSingleHeader(asyncCallSettings, CallSettings.RequestParamsHeader, "parent=test");
        }

        
        /// <summary>
        /// Extracting multiple routing header key-value pairs by matching
        /// several path templates on multiple request fields.
        /// Also tests the parameter names with the `.` and extracting values from a sub-request's field.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "profiles/profile_17", "subs/sub13", "project_id=projects%2F100&sub_name=sub13&legacy.routing_id=profiles%2Fprofile_17")]
        [InlineData("projects/100", "", "", "project_id=projects%2F100")]
        [InlineData("projects/100", null, null, "project_id=projects%2F100")]
        [InlineData(null, null, null, null)]
        public void WithExtractedGoogleRequestParam_MultipleFields(string tableNameValue, string appProfileIdValue, string subName, string expectedHeader)
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiServerStreamingCall<ApiCallTest.ExtractedRequestParamRequest, SimpleResponse>(
                "Method",
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/**" }
            // { field: "sub_name", path_template: "subs/{sub.sub_name}" }
            // { field: "app_profile_id", path_template: "{legacy.routing_id=**}" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new RoutingHeaderExtractor<ApiCallTest.ExtractedRequestParamRequest>()
                        .WithExtractedParameter("project_id",
                            "^(projects/[^/]+)(?:/.*)?$", request => request.TableName)
                        .WithExtractedParameter("sub_name",
                            "^subs/([^/]+)/?$", request => request.Sub.TableName)
                        .WithExtractedParameter("legacy.routing_id",
                            "^(.*)$", request => request.AppProfileId));
            var request = new ApiCallTest.ExtractedRequestParamRequest
            {
                TableName = tableNameValue, AppProfileId = appProfileIdValue,
                Sub = new ApiCallTest.ExtractedRequestParamRequest { TableName = subName }
            };

            call1.Call(request, null);
            call1.CallAsync(request, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }
    }
}
