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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
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

        /// <summary>
        /// Extracting a field from the request to put into the routing header,
        /// while matching a path template syntax on the field's value.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200", "table_name=projects/100/instances/200")]
        [InlineData("projects/100/instances/200/whatever", "table_name=projects/100/instances/200/whatever")]
        [InlineData("regions/100/zones/200", "table_name=regions/100/zones/200")]
        [InlineData("foo", null)]
        public void WithExtractedGoogleRequestParam_FieldMatch(string fieldValue, string expectedHeader)
        {
            const string headerName = "table_name";

            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{table_name=projects/*/instances/*/**}" }
            // { field: "table_name", path_template: "{table_name=regions/*/zones/*/**}" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>(headerName,
                            new Regex("^(?<table_name>projects/[^/]+/instances/[^/]+(?:/.*)?)$"), request => request.TableName)
                        .Add(headerName,
                            new Regex("^(?<table_name>regions/[^/]+/zones/[^/]+(?:/.*)?)$"), request => request.TableName));
            call1.Sync(new ExtractedRequestParamRequest { TableName = fieldValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = fieldValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Extracting a single routing header key-value pair by matching a
        /// template syntax on (a part of) a single request field.
        /// </summary>
        [Theory]
        [InlineData("projects/100", "routing_id=projects/100")]
        [InlineData("projects/100/instances/200", "routing_id=projects/100")]
        [InlineData("foo/10/projects/100", null)]
        [InlineData("foo", null)]
        public void WithExtractedGoogleRequestParam_SimpleExtract(string fieldValue, string expectedHeader)
        {
            const string headerName = "routing_id";

            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>(headerName,
                    new Regex("^(?<routing_id>projects/[^/]+)(?:/.*)?$"), request => request.TableName));
            call1.Sync(new ExtractedRequestParamRequest { TableName = fieldValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = fieldValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Extracting a single routing header key-value pair by matching
        /// several conflictingly named path templates on (parts of) a single request
        /// field. The last template to match "wins" the conflict.
        /// </summary>
        [Theory]
        [InlineData("projects/100", "table_name=projects/100")]
        [InlineData("projects/100/shards/300", "table_name=projects/100")]
        [InlineData("projects/100/instances/200", "table_name=projects/100/instances/200")]
        [InlineData("projects/100/instances/200/shards/300", "table_name=projects/100/instances/200")]
        [InlineData("orgs/1/projects/100/instances/200", null)]
        [InlineData("foo", null)]
        public void WithExtractedGoogleRequestParam_OverlappingPatterns(string fieldValue, string expectedHeader)
        {
            const string headerName = "table_name";

            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            // { field: "table_name", path_template: "{routing_id=projects/*/instances/*}/**" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>(headerName,
                            new Regex("^(?<routing_id>projects/[^/]+)(?:/.*)?$"), request => request.TableName)
                        .Add(headerName,
                            new Regex("^(?<routing_id>projects/[^/]+/instances/[^/]+)(?:/.*)?$"), request => request.TableName));
            call1.Sync(new ExtractedRequestParamRequest { TableName = fieldValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = fieldValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Extracting multiple routing header key-value pairs by matching
        /// several non-conflicting path templates on (parts of) a single request field.
        /// Make the templates strict, so that if the `table_name` does not
        /// have an instance information, nothing is sent.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "project_id=projects/100&instance_id=instances/200")]
        [InlineData("projects/100", null)]
        public void WithExtractedGoogleRequestParam_MultiplePairs(string fieldValue, string expectedHeader)
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/instances/*/**" }
            // { field: "table_name", path_template: "projects/*/{instance_id=instances/*}/**" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>("project_id",
                        new Regex("^(?<project_id>projects/[^/]+)/instances/[^/]+(?:/.*)?$"), request => request.TableName)
                        .Add("instance_id",
                            new Regex("^projects/[^/]+/(?<instance_id>instances/[^/]+)(?:/.*)?$"), request => request.TableName));
            call1.Sync(new ExtractedRequestParamRequest { TableName = fieldValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = fieldValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Extracting multiple routing header key-value pairs by matching
        /// several non-conflicting path templates on (parts of) a single request field.
        /// Make the templates loose, so that if the `table_name` does not
        /// have an instance information, just the project id part is sent.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "project_id=projects/100&instance_id=instances/200")]
        [InlineData("projects/100", "project_id=projects/100")]
        [InlineData("org/projects/100", null)]
        public void WithExtractedGoogleRequestParam_MultiplePairsLoose(string fieldValue, string expectedHeader)
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/**" }
            // { field: "table_name", path_template: "projects/*/{instance_id=instances/*}/**" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>("project_id",
                        new Regex("^(?<project_id>projects/[^/]+)(?:/.*)?$"), request => request.TableName)
                        .Add("instance_id",
                            new Regex("^projects/[^/]+/(?<instance_id>instances/[^/]+)(?:/.*)?$"), request => request.TableName));
            call1.Sync(new ExtractedRequestParamRequest { TableName = fieldValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = fieldValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Extracting multiple routing header key-value pairs by matching
        /// several path templates on multiple request fields.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "profiles/profile_17", "project_id=projects/100&routing_id=profiles/profile_17")]
        [InlineData("projects/100", "", "project_id=projects/100")]
        [InlineData("projects/100", null, "project_id=projects/100")]
        [InlineData(null, null, null)]
        public void WithExtractedGoogleRequestParam_MultipleFields(string tableNameValue, string appProfileIdValue, string expectedHeader)
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/**" }
            // { field: "app_profile_id", path_template: "{routing_id=**}" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>("project_id",
                        new Regex("^(?<project_id>projects/[^/]+)(?:/.*)?$"), request => request.TableName)
                        .Add("routing_id",
                            new Regex("^(?<routing_id>.*)$"), request => request.AppProfileId));
            call1.Sync(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Extracting multiple routing header key-value pairs by matching
        /// several conflictingly named path templates on several request fields. The
        /// last template to match "wins" the conflict.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "profiles/profile_17", "routing_id=profiles/profile_17")]
        [InlineData("regions/100", "", "routing_id=regions/100")]
        public void WithExtractedGoogleRequestParam_MultipleConflictsFields(string tableNameValue, string appProfileIdValue, string expectedHeader)
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            // { field: "table_name", path_template: "{routing_id=regions/*}/**" }
            // { field: "app_profile_id", path_template: "{routing_id=**}" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>("routing_id",
                        new Regex("^(?<routing_id>projects/[^/]+)(?:/.*)?$"), request => request.TableName)
                        .Add("routing_id",
                            new Regex("^(?<routing_id>regions/[^/]+)(?:/.*)?$"), request => request.TableName)
                        .Add("routing_id",
                            new Regex("^(?<routing_id>.*)$"), request => request.AppProfileId));
            call1.Sync(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        /// <summary>
        /// Test a complex scenario with a kitchen sink of concerns
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "profiles/profile_17", "table_location=instances/200&routing_id=profile_17")]
        [InlineData("projects/100/instances/200/tables/300", "profile_17", "table_location=instances/200&routing_id=profile_17")]
        [InlineData("projects/100/instances/200/tables/300", null, "table_location=instances/200&routing_id=projects/100")]
        public void WithExtractedGoogleRequestParam_KitchenSink(string tableNameValue, string appProfileIdValue, string expectedHeader)
        {
            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<ExtractedRequestParamRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                null);

            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "projects/*/{table_location=instances/*}/tables/*" }
            // { field: "table_name", path_template: "{table_location=regions/*/zones/*}/tables/*" }
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            // { field: "app_profile_id", path_template: "{routing_id=**}" }
            // { field: "app_profile_id", path_template: "profiles/{routing_id=*}" }
            var call1 = call0
                .WithExtractedGoogleRequestParam(
                    new HeaderParameterExtractor<ExtractedRequestParamRequest>("table_location",
                        new Regex("^projects/[^/]+/(?<table_location>instances/[^/]+)/tables/[^/]+/?$"), request => request.TableName)
                        .Add("table_location",
                            new Regex("^(?<table_location>regions/[^/]+/zones/[^/]+)/tables/[^/]+/?$"), request => request.TableName)
                        .Add("routing_id",
                            new Regex("^(?<routing_id>projects/[^/]+)(?:/.*)?$"), request => request.TableName)
                        .Add("routing_id",
                            new Regex("^(?<routing_id>.*)$"), request => request.AppProfileId)
                        .Add("routing_id",
                            new Regex("^profiles/(?<routing_id>[^/]+)/?$"), request => request.AppProfileId));
            call1.Sync(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue}, null);
            call1.Async(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue }, null);

            CallSettingsTest.AssertRoutingHeader(syncCallSettings, expectedHeader);
            CallSettingsTest.AssertRoutingHeader(asyncCallSettings, expectedHeader);
        }

        internal class ExtractedRequestParamRequest : IMessage<ExtractedRequestParamRequest>
        {
            public string TableName { get; set; }
            public string AppProfileId { get; set; }
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
