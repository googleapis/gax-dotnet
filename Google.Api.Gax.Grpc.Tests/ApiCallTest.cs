/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Api.Gax.Grpc.Testing;
using Google.Api.Gax.Testing;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiCallTest
    {
        [Fact]
        public void WithCallSettingsOverlay()
        {
            var ctBase = new CancellationTokenSource().Token;
            var ctPerCall = new CancellationTokenSource().Token;
            var ctOverlay = new CancellationTokenSource().Token;

            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<SimpleRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                CallSettings.FromCancellationToken(ctBase));

            // Verify a null overlay has no effect.
            // Async call runs synchonously due to 'call0' definition above.
            var call1 = call0.WithCallSettingsOverlay(req => null);
            call1.Sync(null, CallSettings.FromCancellationToken(ctPerCall));
            call1.Async(null, CallSettings.FromCancellationToken(ctPerCall));
            Assert.Equal(ctPerCall, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, syncCallSettings.CancellationToken.Value);
            Assert.Equal(ctPerCall, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, asyncCallSettings.CancellationToken.Value);

            // Verify an overlay overwrites all else.
            var call2 = call0.WithCallSettingsOverlay(req => CallSettings.FromCancellationToken(ctOverlay));
            call2.Sync(null, CallSettings.FromCancellationToken(ctPerCall));
            call2.Async(null, CallSettings.FromCancellationToken(ctPerCall));
            Assert.Equal(ctOverlay, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctPerCall, syncCallSettings.CancellationToken.Value);
            Assert.Equal(ctOverlay, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctPerCall, asyncCallSettings.CancellationToken.Value);
        }

        [Theory, CombinatorialData]
        public async Task MetadataHandlers(bool responseHandler, bool trailingHandler, bool sync)
        {
            var call = CreateMetadataTestingApiCall();
            Metadata actualResponseMetadata = null;
            Metadata actualTrailingMetadata = null;
            Metadata expectedResponseMetadata = responseHandler ? CreateMetadata("kind", "response") : null;
            Metadata expectedTrailingMetadata = trailingHandler ? CreateMetadata("kind", "trailing") : null;

            CallSettings settings = null;
            if (responseHandler)
            {
                settings = settings.WithResponseMetadataHandler(metadata => actualResponseMetadata = metadata);
            }
            if (trailingHandler)
            {
                settings = settings.WithTrailingMetadataHandler(metadata => actualTrailingMetadata = metadata);
            }
            var request = new SimpleRequest();
            var response = sync ? call.Sync(request, settings) : await call.Async(request, settings);
            Assert.Equal("response", response.Name);

            AssertMetadata(expectedResponseMetadata, actualResponseMetadata);
            AssertMetadata(expectedTrailingMetadata, actualTrailingMetadata);
        }

        private ApiCall<SimpleRequest, SimpleResponse> CreateMetadataTestingApiCall()
        {
            var responseMetadata = CreateMetadata("kind", "response");
            var trailingMetadata = CreateMetadata("kind", "trailing");
            var response = new SimpleResponse { Name = "response" };
            var call = new AsyncUnaryCall<SimpleResponse>(
                Task.FromResult(response),
                Task.FromResult(responseMetadata),
                () => Status.DefaultSuccess,
                () => trailingMetadata,
                disposeAction: () => { });

            return ApiCall.Create<SimpleRequest, SimpleResponse>(
                (request, options) => call,
                (request, options) => response,
                baseCallSettings: null,
                clock: new FakeClock());
        }

        private void AssertMetadata(Metadata expected, Metadata actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, actual[i].Key);
                Assert.Equal(expected[i].Value, actual[i].Value);
            }
        }

        /// <summary>
        /// Creates a Metadata instance for a single key/value pair.
        /// </summary>
        private static Metadata CreateMetadata(string key, string value) =>
            new Metadata { new Metadata.Entry(key, value) };

        [Fact]
        public void WithGoogleRequestParam()
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<SimpleRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            var call1 = call0.WithGoogleRequestParam("parent", request => request.Name);
            call1.Sync(new SimpleRequest { Name = "test" }, null);
            call1.Async(new SimpleRequest { Name = "test" }, null);

            var expectedHeader = "parent=test";
            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        [Fact]
        public void WithTwoGoogleRequestParams()
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<SimpleRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            var call1 = call0.WithGoogleRequestParam("parent", request => request.Name).WithGoogleRequestParam("something_else", request => request.Name);
            call1.Sync(new SimpleRequest { Name = "test" }, null);
            call1.Async(new SimpleRequest { Name = "test" }, null);

            var metadata = new Metadata();
            syncCallSettings.HeaderMutation(metadata);
            Assert.Equal(2, metadata.Count);

            foreach (var entry in metadata)
            {
                Assert.Equal("x-goog-request-params", entry.Key);
            }
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
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/**" }
            // { field: "sub_name", path_template: "subs/{sub.sub_name}" }
            // { field: "app_profile_id", path_template: "{legacy.routing_id=**}" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                        .WithExtractedParameter("project_id",
                            "^(projects/[^/]+)(?:/.*)?$", request => request.TableName)
                        .WithExtractedParameter("sub_name",
                            "^subs/([^/]+)/?$", request => request.Sub.TableName)
                        .WithExtractedParameter("legacy.routing_id",
                            "^(.*)$", request => request.AppProfileId));
            var request = new ExtractedRequestParamRequest
            {
                TableName = tableNameValue, AppProfileId = appProfileIdValue,
                Sub = new ExtractedRequestParamRequest { TableName = subName }
            };

            call1.Sync(request, null);
            call1.Async(request, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        internal class ExtractedRequestParamRequest : IMessage<ExtractedRequestParamRequest>
        {
            public string TableName { get; set; }
            public string AppProfileId { get; set; }
            public ExtractedRequestParamRequest Sub { get; set; }
            public void MergeFrom(ExtractedRequestParamRequest message) => throw new NotImplementedException();
            public void MergeFrom(CodedInputStream input) => throw new NotImplementedException();
            public void WriteTo(CodedOutputStream output) => throw new NotImplementedException();
            public int CalculateSize() => throw new NotImplementedException();
            public MessageDescriptor Descriptor=> throw new NotImplementedException();
            public bool Equals(ExtractedRequestParamRequest other) => throw new NotImplementedException();
            public ExtractedRequestParamRequest Clone() => throw new NotImplementedException();
        }
    }
}
