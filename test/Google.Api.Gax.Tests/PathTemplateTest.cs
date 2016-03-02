/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class PathTemplateTest
    {
        [Theory]
        [InlineData("shelves/{shelf}/books/{book}")]
        [InlineData("shelves/{shelf}/books/*")]
        [InlineData("shelves/{shelf=*}/books/{book=*}")]
        [InlineData("shelves/*/books/*")]
        [InlineData("shelves/*/books/**")]
        [InlineData("shelves/{shelf=*}/books/{book=**}")]
        public void Construction_Valid(string template)
        {
            // Just the constructor wouldn't be a valid statement. If we're going to have to call anything,
            // we might as well call ToString and validate that...
            Assert.Equal(new PathTemplate(template).ToString(), template);
        }

        [Theory]
        [InlineData("shelves/**/books/**")]
        [InlineData("bar/**/{name=foo/**}:verb")]
        [InlineData("shelves/foo}")]
        [InlineData("shelves/*}")]
        [InlineData("shelves/{")]
        [InlineData("shelves/{name")]
        [InlineData("shelves/{name=")]
        [InlineData("shelves/{name=foo/*")]
        public void Construction_Invalid(string template)
        {
            Assert.Throws<ArgumentException>(() => new PathTemplate(template));
        }

        [Theory]
        [InlineData("buckets/*/*/objects/*", "buckets/f/o/o/objects/bar")]
        [InlineData("buckets/*/*/objects/*", "buckets/f/o/objects")]
        [InlineData("buckets/*/*/objects/*", "buckets/f/o/objects/too/long")]
        [InlineData("buckets/*/*/objects/*", "wrong/a/b/objects/c")]
        [InlineData("buckets/*/*/objects/*", "buckets/a/b/wrong/c")]
        [InlineData("buckets/*/*/objects/*", "extra/buckets/a/b/objects/c")]
        [InlineData("buckets/*/*/objects/*", "///buckets/*/*/objects/*")]
        [InlineData("buckets/*/*/objects/*", "////buckets/*/*/objects/*")]
        [InlineData("buckets/*/*/objects/*", "/foo//buckets/*/*/objects/*")]
        [InlineData("buckets/*/*/objects/*", "//foo//buckets/*/*/objects/*")]
        public void ParseName_Invalid(string templateText, string name)
        {
            var template = new PathTemplate(templateText);
            Assert.Throws<ArgumentException>(() => template.ParseName(name));
            Assert.Null(template.TryParseName(name));
        }

        [Theory]
        [InlineData("buckets/*/*/objects/*", "buckets/f/o/objects/bar", new[] { "f", "o", "bar" }, null)]
        [InlineData("buckets/*/objects/**", "buckets/foo/objects/bar/baz", new[] { "foo", "bar/baz" }, null)]
        [InlineData("bar/**/foo/*", "bar/foo/foo/foo/bar", new[] { "foo/foo", "bar" }, null)]
        [InlineData("bar/**/foo/*", "bar/foo/bar", new[] { "", "bar" }, null)]
        [InlineData("bar/*/foo/*", "//service/bar/x/foo/y", new[] { "x", "y" }, "service")]
        public void ParseName_Valid(string templateText, string name, string[] expectedResourceIds, string expectedServiceName)
        {
            var template = new PathTemplate(templateText);
            var resourceName = template.ParseName(name);
            for (int i = 0; i < expectedResourceIds.Length; i++)
            {
                Assert.Equal(resourceName[i], expectedResourceIds[i]);
            }
            Assert.Equal(expectedServiceName, resourceName.ServiceName);
        }

        [Theory]
        [InlineData("buckets/*/objects/*", new[] { "foo", "bar" }, "buckets/foo/objects/bar")]
        [InlineData("buckets/**/objects/*", new[] { "foo/qux", "bar" }, "buckets/foo/qux/objects/bar")]
        [InlineData("buckets/**/objects/*", new[] { "", "bar" }, "buckets/objects/bar")]
        public void Expand_Valid(string templateText, string[] resourceIds, string expectedResult)
        {
            var template = new PathTemplate(templateText);
            var actual = template.Expand(resourceIds);
            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData("buckets/*/objects/*", new[] { "foo/qux", "bar" })]
        [InlineData("buckets/**/objects/*", new[] { "bar" })]
        [InlineData("buckets/*/objects/*", new[] { "foo", "bar", "baz" })]
        [InlineData("buckets/*/objects/*", new[] { "foo", "" })]
        [InlineData("buckets/**/objects/*", new[] { "foo", "bar", "baz" })]
        public void Expand_Invalid(string templateText, string[] resourceIds)
        {
            var template = new PathTemplate(templateText);
            Assert.Throws<ArgumentException>(() => template.Expand(resourceIds));
        }

        [Theory]
        [InlineData("buckets/*/objects/*", null, new[] { "foo", "bar" }, "buckets/foo/objects/bar")]
        [InlineData("buckets/*/objects/*", "service", new[] { "foo", "bar" }, "//service/buckets/foo/objects/bar")]
        public void ExpandWithService_Valid(string templateText, string serviceName, string[] resourceIds, string expectedResult)
        {
            var template = new PathTemplate(templateText);
            var actual = template.ExpandWithService(serviceName, resourceIds);
            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData("buckets/*/objects/*", null, new[] { "foo/qux", "bar" })]
        [InlineData("buckets/*/objects/*", "", new[] { "foo", "bar" })]
        [InlineData("buckets/*/objects/*", "a/b", new[] { "foo", "bar" })]
        public void ExpandWithService_Invalid(string templateText, string serviceName, string[] resourceIds)
        {
            var template = new PathTemplate(templateText);
            Assert.Throws<ArgumentException>(() => template.ExpandWithService(serviceName, resourceIds));
        }
    }
}
