/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Json;
using System;
using System.Text;
using Xunit;

namespace Google.Api.Gax.Tests.Json
{
    /// <summary>
    /// Note: these are more than just tests; they give some indication of expected usage.
    /// </summary>
    public class JsonBuilderTest
    {
        [Fact]
        public void SimpleObject()
        {
            var json = new JsonBuilder()
                .StartObject()
                .Property("name", "jon")
                .Property("score", 20)
                .EndObject()
                .ToString();
            AssertJson("{'name':'jon','score':20}", json);
        }

        [Fact]
        public void SimpleArray()
        {
            var json = new JsonBuilder()
                .StartArray()
                .Value("jon")
                .Value(20)
                .Value(true)
                .EndArray()
                .ToString();
            AssertJson("['jon',20,true]", json);
        }

        [Fact]
        public void NestedObject()
        {
            var json = new JsonBuilder()
                .StartObject()
                .Property("game", "chess")
                .PropertyName("player")
                .StartObject()
                .Property("name", "jon")
                .Property("score", 20)
                .EndObject()
                .Property("date", "2017-12-14")
                .EndObject()
                .ToString();
            AssertJson("{'game':'chess','player':{'name':'jon','score':20},'date':'2017-12-14'}", json);
        }

        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        public void BooleanHandling(bool value, string expected)
        {
            var json = new JsonBuilder().Value(value).ToString();
            Assert.Equal(expected, json);
        }

        [Fact]
        public void NullHandling()
        {
            var json = new JsonBuilder()
                .StartObject()
                .Property("foo", null)
                .EndObject()
                .ToString();
            AssertJson("{'foo':null}", json);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("text", "text")]
        [InlineData("\"", "\\\"")]
        [InlineData(@"\", @"\\")]
        [InlineData("\r\n\t\b", "\\r\\n\\t\\b")]
        // Example from https://en.wikipedia.org/wiki/UTF-16#U+D800_to_U+DFFF
        [InlineData("\U00024B62", "\\ud852\\udf62")]
        [InlineData("\ufeff", "\\ufeff")] // Escaped for security
        [InlineData("<>", "\\u003c\\u003e")] // Escaped for security
        [InlineData("\u20ac", "\u20ac")] // Not escaped
        public void StringHandling(string input, string expectedValue)
        {
            string expectedJson = $"\"{expectedValue}\"";
            var actualJson = new JsonBuilder().Value(input).ToString();
            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void StringHandling_InvalidSurrogatePairs()
        {
            // The values in these tests can't be accurately stored in attributes, hence the inlining...
            var builder = new JsonBuilder();
            // Surrogate pair in wrong order
            Assert.Throws<ArgumentException>(() => builder.Value("\udf62\ud852"));
            // Lone high surrogate
            Assert.Throws<ArgumentException>(() => builder.Value("\udf62"));
            // Lone low surrogate
            Assert.Throws<ArgumentException>(() => builder.Value("\ud852"));
        }

        [Theory]
        [InlineData(5.0, "5")]
        [InlineData(1.25, "1.25")]
        public void DoubleHandling(double value, string expected)
        {
            // No string wrapping needed this time.
            var actualJson = new JsonBuilder().Value(value).ToString();
            Assert.Equal(expected, actualJson);
        }

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void DoubleHandling_Invalid(double value)
        {
            var builder = new JsonBuilder();
            Assert.Throws<ArgumentException>(() => builder.Value(value));
        }

        [Fact]
        public void NullProperty()
        {
            var builder = new JsonBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.Property(null, ""));
            Assert.Throws<ArgumentNullException>(() => builder.Property(null, true));
            Assert.Throws<ArgumentNullException>(() => builder.Property(null, 2.0));
            Assert.Throws<ArgumentNullException>(() => builder.PropertyName(null));
        }

        [Fact]
        public void InvalidEndCalls()
        {
            var builder = new JsonBuilder()
                .StartObject()
                .Property("foo", "bar")
                .EndObject();
            Assert.Throws<InvalidOperationException>(() => builder.EndObject());
            Assert.Throws<InvalidOperationException>(() => builder.EndArray());
        }

        [Fact]
        public void ExistingStringBuilder()
        {
            var stringBuilder = new StringBuilder("xyz");
            var jsonBuilder = new JsonBuilder(stringBuilder);
            jsonBuilder.Value(5);
            // Note that this includes the earlier data as well
            Assert.Equal("xyz5", jsonBuilder.ToString());
            Assert.Equal("xyz5", stringBuilder.ToString());
        }
        
        /// <summary>
        /// Converts quotes to double-quotes in <paramref name="expected"/> before comparing.
        /// </summary>
        private static void AssertJson(string expected, string actual)
        {
            expected = expected.Replace("'", "\"");
            Assert.Equal(expected, actual);
        }
    }
}
