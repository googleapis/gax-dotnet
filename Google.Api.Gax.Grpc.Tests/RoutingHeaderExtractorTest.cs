/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RoutingHeaderExtractorTest
    {        
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
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{table_name=projects/*/instances/*/**}" }
            // { field: "table_name", path_template: "{table_name=regions/*/zones/*/**}" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                .WithExtractedParameter("table_name",
                    "^(?<table_name>projects/[^/]+/instances/[^/]+(?:/.*)?)$", request => request.TableName)
                .WithExtractedParameter("table_name",
                    "^(?<table_name>regions/[^/]+/zones/[^/]+(?:/.*)?)$", request => request.TableName);

            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = fieldValue });
            AssertEqualEscaped(expectedHeader, header);
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
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>().WithExtractedParameter("routing_id",
                "^(?<routing_id>projects/[^/]+)(?:/.*)?$", request => request.TableName);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = fieldValue });

            AssertEqualEscaped(expectedHeader, header);
        }

        /// <summary>
        /// Extracting a single routing header key-value pair by matching
        /// several conflictingly named path templates on (parts of) a single request
        /// field. The last template to match "wins" the conflict.
        /// </summary>
        [Theory]
        [InlineData("projects/100", "routing_id=projects/100")]
        [InlineData("projects/100/shards/300", "routing_id=projects/100")]
        [InlineData("projects/100/instances/200", "routing_id=projects/100/instances/200")]
        [InlineData("projects/100/instances/200/shards/300", "routing_id=projects/100/instances/200")]
        [InlineData("orgs/1/projects/100/instances/200", null)]
        [InlineData("foo", null)]
        public void WithExtractedGoogleRequestParam_OverlappingPatterns(string fieldValue, string expectedHeader)
        {
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            // { field: "table_name", path_template: "{routing_id=projects/*/instances/*}/**" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>projects/[^/]+)(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>projects/[^/]+/instances/[^/]+)(?:/.*)?$", request => request.TableName);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = fieldValue });

            AssertEqualEscaped(expectedHeader, header);
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
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/instances/*/**" }
            // { field: "table_name", path_template: "projects/*/{instance_id=instances/*}/**" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                .WithExtractedParameter("project_id",
                    "^(?<project_id>projects/[^/]+)/instances/[^/]+(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("instance_id",
                    "^projects/[^/]+/(?<instance_id>instances/[^/]+)(?:/.*)?$", request => request.TableName);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = fieldValue });

            AssertEqualEscaped(expectedHeader, header);
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
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/**" }
            // { field: "table_name", path_template: "projects/*/{instance_id=instances/*}/**" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>().WithExtractedParameter("project_id",
                    "^(?<project_id>projects/[^/]+)(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("instance_id",
                    "^projects/[^/]+/(?<instance_id>instances/[^/]+)(?:/.*)?$", request => request.TableName);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = fieldValue });

            AssertEqualEscaped(expectedHeader, header);
        }

        /// <summary>
        /// Extracting multiple routing header key-value pairs by matching
        /// several path templates on multiple request fields.
        /// Also tests the parameter names with the `.` and extracting values from a sub-request's field.
        /// </summary>
        [Theory]
        [InlineData("projects/100/instances/200/tables/300", "profiles/profile_17", "subs/sub13", "project_id=projects/100&legacy.routing_id=profiles/profile_17&sub_name=sub13")]
        [InlineData("projects/100", "", "", "project_id=projects/100")]
        [InlineData("projects/100", null, null, "project_id=projects/100")]
        [InlineData(null, null, null, null)]
        public void WithExtractedGoogleRequestParam_MultipleFields(string tableNameValue, string appProfileIdValue, string subName, string expectedHeader)
        {
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{project_id=projects/*}/**" }
            // { field: "sub_name", path_template: "subs/{sub.sub_name}" }
            // { field: "app_profile_id", path_template: "{legacy.routing_id=**}" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                .WithExtractedParameter("project_id",
                    "^(?<project_id>projects/[^/]+)(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("sub_name",
                    "^subs/(?<sub_name>[^/]+)/?$", request => request.Sub.TableName)
                .WithExtractedParameter("legacy.routing_id",
                    "^(?<legacy_routing_id>.*)$", request => request.AppProfileId);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest
            {
                TableName = tableNameValue,
                AppProfileId = appProfileIdValue,
                Sub = new ExtractedRequestParamRequest { TableName = subName }
            });

            AssertEqualEscaped(expectedHeader, header);
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
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            // { field: "table_name", path_template: "{routing_id=regions/*}/**" }
            // { field: "app_profile_id", path_template: "{routing_id=**}" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>projects/[^/]+)(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>regions/[^/]+)(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>.*)$", request => request.AppProfileId);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue});

            AssertEqualEscaped(expectedHeader, header);
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
            // call corresponding to the following routing parameters:
            // { field: "table_name", path_template: "projects/*/{table_location=instances/*}/tables/*" }
            // { field: "table_name", path_template: "{table_location=regions/*/zones/*}/tables/*" }
            // { field: "table_name", path_template: "{routing_id=projects/*}/**" }
            // { field: "app_profile_id", path_template: "{routing_id=**}" }
            // { field: "app_profile_id", path_template: "profiles/{routing_id=*}" }
            var extractor = new RoutingHeaderExtractor<ExtractedRequestParamRequest>()
                .WithExtractedParameter("table_location",
                    "^projects/[^/]+/(?<table_location>instances/[^/]+)/tables/[^/]+/?$", request => request.TableName)
                .WithExtractedParameter("table_location",
                    "^(?<table_location>regions/[^/]+/zones/[^/]+)/tables/[^/]+/?$", request => request.TableName)
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>projects/[^/]+)(?:/.*)?$", request => request.TableName)
                .WithExtractedParameter("routing_id",
                    "^(?<routing_id>.*)$", request => request.AppProfileId)
                .WithExtractedParameter("routing_id",
                    "^profiles/(?<routing_id>[^/]+)/?$", request => request.AppProfileId);
            var header = extractor.ExtractHeader(new ExtractedRequestParamRequest { TableName = tableNameValue, AppProfileId = appProfileIdValue});

            AssertEqualEscaped(expectedHeader, header);
        }

        internal static void AssertEqualEscaped(string expected, string actual)
        {
            if (string.IsNullOrWhiteSpace(expected))
            {
                Assert.True(string.IsNullOrWhiteSpace(actual));
            }
            else
            {
                // The extractor produces the header value string escaped and
                // sorted by parameter name.
                var expectedEscaped = EscapeAndSort(expected);
                Assert.Equal(expectedEscaped, actual);
            }

            string EscapeAndSort(string routingHeader)
            {
                var escapedParamNameValues = routingHeader.Split('&')
                    .Select(pairString => new KeyValuePair<string, string>(pairString.Split('=')[0],
                        Uri.EscapeDataString(pairString.Split('=')[1])))
                    .OrderBy(nameVal => nameVal.Key);

                return string.Join("&", escapedParamNameValues.Select(nameVal => $"{nameVal.Key}={nameVal.Value}"));
            }
        }

        internal class ExtractedRequestParamRequest
        {
            public string TableName { get; set; }
            public string AppProfileId { get; set; }
            public ExtractedRequestParamRequest Sub { get; set; }
        }
    }
}
