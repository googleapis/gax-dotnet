/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Json;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Tests.Json
{
    public class JsonTokenizerTest
    {
        [Fact]
        public void EmptyObjectValue()
        {
            AssertTokens("{}", JsonToken.StartObject, JsonToken.EndObject);
        }

        [Fact]
        public void EmptyArrayValue()
        {
            AssertTokens("[]", JsonToken.StartArray, JsonToken.EndArray);
        }

        [Theory]
        [InlineData("foo", "foo")]
        [InlineData("tab\\t", "tab\t")]
        [InlineData("line\\nfeed", "line\nfeed")]
        [InlineData("carriage\\rreturn", "carriage\rreturn")]
        [InlineData("back\\bspace", "back\bspace")]
        [InlineData("form\\ffeed", "form\ffeed")]
        [InlineData("escaped\\/slash", "escaped/slash")]
        [InlineData("escaped\\\\backslash", "escaped\\backslash")]
        [InlineData("escaped\\\"quote", "escaped\"quote")]
        [InlineData("foo {}[] bar", "foo {}[] bar")]
        [InlineData("foo\\u09aFbar", "foo\u09afbar")] // Digits, upper hex, lower hex
        [InlineData("ab\ud800\udc00cd", "ab\ud800\udc00cd")]
        [InlineData("ab\\ud800\\udc00cd", "ab\ud800\udc00cd")]
        public void StringValue(string json, string expectedValue)
        {
            AssertTokensNoReplacement("\"" + json + "\"", JsonToken.Value(expectedValue));
        }

        // Valid surrogate pairs, with mixed escaping. These test cases can't be expressed
        // using InlineData as they have no valid UTF-8 representation.
        // It's unclear exactly how we should handle a mixture of escaped or not: that can't
        // come from UTF-8 text, but could come from a .NET string. For the moment,
        // treat it as valid in the obvious way.
        [Fact]
        public void MixedSurrogatePairs()
        {
            string expected = "\ud800\udc00";
            AssertTokens("'\\ud800\udc00'", JsonToken.Value(expected));
            AssertTokens("'\ud800\\udc00'", JsonToken.Value(expected));
        }

        [Theory]
        [InlineData("embedded tab\t")]
        [InlineData("embedded CR\r")]
        [InlineData("embedded LF\n")]
        [InlineData("embedded bell\u0007")]
        [InlineData("bad escape\\a")]
        [InlineData("incomplete escape\\")]
        [InlineData("incomplete Unicode escape\\u000")]
        [InlineData("invalid Unicode escape\\u000H")]
        // Surrogate pair handling, both in raw .NET strings and escaped. We only need
        // to detect this in strings, as non-ASCII characters anywhere other than in strings
        // will already lead to parsing errors.
        [InlineData("\\ud800")]
        [InlineData("\\udc00")]
        [InlineData("\\ud800x")]
        [InlineData("\\udc00x")]
        [InlineData("\\udc00\\ud800y")]
        public void InvalidStringValue(string json)
        {
            AssertThrowsAfter("\"" + json + "\"");
        }

        // Tests for invalid strings that can't be expressed in attributes,
        // as the constants can't be expressed as UTF-8 strings.
        [Fact]
        public void InvalidSurrogatePairs()
        {
            AssertThrowsAfter("\"\ud800x\"");
            AssertThrowsAfter("\"\udc00y\"");
            AssertThrowsAfter("\"\udc00\ud800y\"");
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("-0", 0)] // We don't distinguish between positive and negative 0
        [InlineData("1", 1)]
        [InlineData("-1", -1)]
        // From here on, assume leading sign is okay...
        [InlineData("1.125", 1.125)]
        [InlineData("1.0", 1)]
        [InlineData("1e5", 100000)]
        [InlineData("1e000000", 1)] // Weird, but not prohibited by the spec
        [InlineData("1E5", 100000)]
        [InlineData("1e+5", 100000)]
        [InlineData("1E-5", 0.00001)]
        [InlineData("123E-2", 1.23)]
        [InlineData("123.45E3", 123450)]
        [InlineData("   1   ", 1)]
        public void NumberValue(string json, double expectedValue)
        {
            AssertTokens(json, JsonToken.Value(expectedValue));
        }

        [Theory]
        [InlineData("00")]
        [InlineData(".5")]
        [InlineData("1.")]
        [InlineData("1e")]
        [InlineData("1e-")]
        [InlineData("--")]
        [InlineData("--1")]
        [InlineData("-1.7977e308")]
        [InlineData("1.7977e308")]
        public void InvalidNumberValue(string json)
        {
            AssertThrowsAfter(json);
        }

        [Theory]
        [InlineData("nul")]
        [InlineData("nothing")]
        [InlineData("truth")]
        [InlineData("fALSEhood")]
        public void InvalidLiterals(string json)
        {
            AssertThrowsAfter(json);
        }

        [Fact]
        public void NullValue()
        {
            AssertTokens("null", JsonToken.Null);
        }

        [Fact]
        public void TrueValue()
        {
            AssertTokens("true", JsonToken.True);
        }

        [Fact]
        public void FalseValue()
        {
            AssertTokens("false", JsonToken.False);
        }

        [Fact]
        public void SimpleObject()
        {
            AssertTokens("{'x': 'y'}",
                JsonToken.StartObject, JsonToken.Name("x"), JsonToken.Value("y"), JsonToken.EndObject);
        }

        [Theory]
        [InlineData("[10, 20", 3)]
        [InlineData("[10,", 2)]
        [InlineData("[10:20]", 2)]
        [InlineData("[", 1)]
        [InlineData("[,", 1)]
        [InlineData("{", 1)]
        [InlineData("{,", 1)]
        [InlineData("{[", 1)]
        [InlineData("{{", 1)]
        [InlineData("{0", 1)]
        [InlineData("{null", 1)]
        [InlineData("{false", 1)]
        [InlineData("{true", 1)]
        [InlineData("}", 0)]
        [InlineData("]", 0)]
        [InlineData(",", 0)]
        [InlineData("'foo' 'bar'", 1)]
        [InlineData(":", 0)]
        [InlineData("'foo", 0)] // Incomplete string
        [InlineData("{ 'foo' }", 2)]
        [InlineData("{ x:1", 1)] // Property names must be quoted
        [InlineData("{]", 1)]
        [InlineData("[}", 1)]
        [InlineData("[1,", 2)]
        [InlineData("{'x':0]", 3)]
        [InlineData("{ 'foo': }", 2)]
        [InlineData("{ 'foo':'bar', }", 3)]
        public void InvalidStructure(string json, int expectedValidTokens)
        {
            // Note: we don't test that the earlier tokens are exactly as expected,
            // partly because that's hard to parameterize.
            var reader = new StringReader(json.Replace('\'', '"'));
            var tokenizer = JsonTokenizer.FromTextReader(reader);
            for (int i = 0; i < expectedValidTokens; i++)
            {
                Assert.NotNull(tokenizer.Next());
            }
            Assert.Throws<InvalidJsonException>(() => tokenizer.Next());
        }

        [Fact]
        public void ArrayMixedType()
        {
            AssertTokens("[1, 'foo', null, false, true, [2], {'x':'y' }]",
                JsonToken.StartArray,
                JsonToken.Value(1),
                JsonToken.Value("foo"),
                JsonToken.Null,
                JsonToken.False,
                JsonToken.True,
                JsonToken.StartArray,
                JsonToken.Value(2),
                JsonToken.EndArray,
                JsonToken.StartObject,
                JsonToken.Name("x"),
                JsonToken.Value("y"),
                JsonToken.EndObject,
                JsonToken.EndArray);
        }

        [Fact]
        public void ObjectMixedType()
        {
            AssertTokens(@"{'a': 1, 'b': 'bar', 'c': null, 'd': false, 'e': true, 
                           'f': [2], 'g': {'x':'y' }}",
                JsonToken.StartObject,
                JsonToken.Name("a"),
                JsonToken.Value(1),
                JsonToken.Name("b"),
                JsonToken.Value("bar"),
                JsonToken.Name("c"),
                JsonToken.Null,
                JsonToken.Name("d"),
                JsonToken.False,
                JsonToken.Name("e"),
                JsonToken.True,
                JsonToken.Name("f"),
                JsonToken.StartArray,
                JsonToken.Value(2),
                JsonToken.EndArray,
                JsonToken.Name("g"),
                JsonToken.StartObject,
                JsonToken.Name("x"),
                JsonToken.Value("y"),
                JsonToken.EndObject,
                JsonToken.EndObject);
        }

        [Fact]
        public void NextAfterEndDocumentThrows()
        {
            var tokenizer = JsonTokenizer.FromTextReader(new StringReader("null"));
            Assert.Equal(JsonToken.Null, tokenizer.Next());
            Assert.Equal(JsonToken.EndDocument, tokenizer.Next());
            Assert.Throws<InvalidOperationException>(() => tokenizer.Next());
        }

        [Fact]
        public void PeekThenNext()
        {
            var tokenizer = JsonTokenizer.FromTextReader(new StringReader("[1, 2]"));
            Assert.Equal(JsonToken.StartArray, tokenizer.Next());
            // Peek at the 1
            Assert.Equal(JsonToken.Value(1), tokenizer.Peek());
            // Now consume it
            Assert.Equal(JsonToken.Value(1), tokenizer.Next());
            Assert.Equal(JsonToken.Value(2), tokenizer.Next());
            Assert.Equal(JsonToken.EndArray, tokenizer.Next());
            Assert.Equal(JsonToken.EndDocument, tokenizer.Next());
        }

        [Theory]
        [InlineData("{ 'skip': 0, 'next': 1")]
        [InlineData("{ 'skip': [0, 1, 2], 'next': 1")]
        [InlineData("{ 'skip': 'x', 'next': 1")]
        [InlineData("{ 'skip': ['x', 'y'], 'next': 1")]
        [InlineData("{ 'skip': {'a': 0}, 'next': 1")]
        [InlineData("{ 'skip': {'a': [0, {'b':[]}]}, 'next': 1")]
        public void SkipValue(string json)
        {
            var tokenizer = JsonTokenizer.FromTextReader(new StringReader(json.Replace('\'', '"')));
            Assert.Equal(JsonToken.StartObject, tokenizer.Next());
            Assert.Equal("skip", tokenizer.Next().StringValue);
            tokenizer.SkipValue();
            Assert.Equal("next", tokenizer.Next().StringValue);
        }

        [Fact]
        public void MaxDepth_Valid()
        {
            var depth = JsonTokenizer.MaxDepth - 1;
            var json = new string('[', depth) + new string(']', depth);
            var expected = Enumerable.Repeat(JsonToken.StartArray, depth)
                .Concat(Enumerable.Repeat(JsonToken.EndArray, depth))
                .ToArray();
            AssertTokens(json, expected);
        }

        [Fact]
        public void MaxDepth_Violated()
        {
            var depth = JsonTokenizer.MaxDepth;
            var json = new string('[', depth) + new string(']', depth);
            var expected = Enumerable.Repeat(JsonToken.StartArray, depth - 1).ToArray();
            AssertThrowsAfter(json, expected);
        }

        /// <summary>
        /// Asserts that the specified JSON is tokenized into the given sequence of tokens.
        /// All apostrophes are first converted to double quotes, allowing any tests
        /// that don't need to check actual apostrophe handling to use apostrophes in the JSON, avoiding
        /// messy string literal escaping. The "end document" token is not specified in the list of 
        /// expected tokens, but is implicit.
        /// </summary>
        private static void AssertTokens(string json, params JsonToken[] expectedTokens)
        {
            AssertTokensNoReplacement(json.Replace('\'', '"'), expectedTokens);
        }

        /// <summary>
        /// Asserts that the specified JSON is tokenized into the given sequence of tokens.
        /// Unlike <see cref="AssertTokens(string, JsonToken[])"/>, this does not perform any character
        /// replacement on the specified JSON, and should be used when the text contains apostrophes which
        /// are expected to be used *as* apostrophes. The "end document" token is not specified in the list of 
        /// expected tokens, but is implicit.
        /// </summary>
        private static void AssertTokensNoReplacement(string json, params JsonToken[] expectedTokens)
        {
            var reader = new StringReader(json);
            var tokenizer = JsonTokenizer.FromTextReader(reader);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                var actualToken = tokenizer.Next();
                if (actualToken == JsonToken.EndDocument)
                {
                    Assert.False(true, $"Expected {expectedTokens[i]} but reached end of token stream");
                }
                Assert.Equal(expectedTokens[i], actualToken);
            }
            var finalToken = tokenizer.Next();
            if (finalToken != JsonToken.EndDocument)
            {
                Assert.False(true, "Expected token stream to be exhausted; received ${finalToken}");
            }
        }

        private static void AssertThrowsAfter(string json, params JsonToken[] expectedTokens)
        {
            var reader = new StringReader(json);
            var tokenizer = JsonTokenizer.FromTextReader(reader);
            for (int i = 0; i < expectedTokens.Length; i++)
            {
                var actualToken = tokenizer.Next();
                if (actualToken == JsonToken.EndDocument)
                {
                    Assert.False(true, $"Expected {expectedTokens[i]} but reached end of document");
                }
                Assert.Equal(expectedTokens[i], actualToken);
            }
            Assert.Throws<InvalidJsonException>(() => tokenizer.Next());
        }
    }
}
