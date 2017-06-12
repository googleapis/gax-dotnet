/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Json;
using System.Collections.Generic;
using Xunit;

namespace Google.Api.Gax.Tests.Json
{
    public class JsonParserTest
    {
        [Theory]
        [InlineData("1.5", 1.5)]
        [InlineData("null", null)]
        [InlineData("\"text\"", "text")]
        [InlineData("false", false)]
        [InlineData("true", true)]
        public void ParseValue_Primitive(string json, object expected)
        {
            var actual = JsonParser.Parse(json);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseValue_Array()
        {
            string json = "[1, \"text\", [2, 3]]";
            var expected = new object[] { 1.0, "text", new object[] { 2.0, 3.0, } };
            var actual = JsonParser.Parse(json);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseValue_Object()
        {
            string json = "{ \"a\": \"text\", \"b\": 1.5 }";
            var expected = new Dictionary<string, object> { { "a", "text" }, { "b", 1.5 } };
            var actual = JsonParser.Parse(json);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseValue_ObjectWithDuplicateKeys()
        {
            string json = "{ \"a\": \"text\", \"a\": 1.5 }";
            Assert.Throws<InvalidJsonException>(() => JsonParser.Parse(json));
        }
    }
}
