/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests
{
    public class HttpRulePathPatternTest
    {
        // We want to end up with theory parameters that are all serializable for XUnit, but avoid calling ToString in each line of the test description.
        public static TheoryData<string, string, string> ValidPatternData = ConvertTheoryData(new TheoryData<string, RuleTestRequest, string>
        {
            { "x/y:custom", new RuleTestRequest(), "x/y:custom" },
            { "firstPart/{x}/secondPart/{y}", new RuleTestRequest { X = "x1", Y = "y2" }, "firstPart/x1/secondPart/y2" },
            { "combined/{x}-{y}/end", new RuleTestRequest { X = "xx", Y = "yy" }, "combined/xx-yy/end" },
            { "pattern/{x}", new RuleTestRequest { X = "abc/def" }, "pattern/abc%2Fdef" },
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/def" }, "pattern/abc/def" },
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/New York" }, "pattern/abc/New%20York" },
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/abc/caf\u00e9" }, "pattern/abc/abc/caf%C3%A9" },
            { "pattern/{x=abc/**}", new RuleTestRequest { X = "abc/def/ghi" }, "pattern/abc/def/ghi" },
            { "pattern/{x=**}", new RuleTestRequest { X = "abc/New York" }, "pattern/abc/New%20York" },
            { "nested/{nested.a}", new RuleTestRequest { Nested = new RuleTestRequest.Types.Nested { A = "aaa" } }, "nested/aaa" },
            // The nested field isn't present, so this doesn't match.
            { "nested/{nested.a}/end", new RuleTestRequest(), null },
            { "before/{int}/end", new RuleTestRequest { Int = 5 }, "before/5/end" },
        });

        private static TheoryData<string, string, string> ConvertTheoryData(TheoryData<string, RuleTestRequest, string> theoryData)
        {
            var ret = new TheoryData<string, string, string>();
            foreach (var item in theoryData)
            {
                ret.Add((string) item[0], ((RuleTestRequest) item[1]).ToString(), (string) item[2]);
            }
            return ret;
        }

        [Theory]
        [MemberData(nameof(ValidPatternData))]
        public void ValidPattern(string pattern, string requestJson, string expectedFormatResult)
        {
            var rulePathPattern = ParsePattern(pattern);
            var request = RuleTestRequest.Parser.ParseJson(requestJson);
            string actualFormatResult = rulePathPattern.TryFormat(request);
            Assert.Equal(expectedFormatResult, actualFormatResult);
        }

        [Theory]
        [InlineData("before/{unterminated-brace/end")]
        [InlineData("before/unstarted-brace}/end")]
        [InlineData("before/unstarted-brace}/{valid}/end")]
        [InlineData("before/{missing}/end")]
        [InlineData("before/{nested}/end")]
        [InlineData("before/{repeated}/end")]
        [InlineData("before/{map}/end")]
        public void InvalidPattern(string pattern)
        {
            Assert.Throws<ArgumentException>(() => HttpRulePathPattern.Parse(pattern, RuleTestRequest.Descriptor));
        }        

        private static HttpRulePathPattern ParsePattern(string pattern) =>
            HttpRulePathPattern.Parse(pattern, RuleTestRequest.Descriptor);
    }
}
