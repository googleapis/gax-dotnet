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
        public static TheoryData<string, RuleTestRequest, string> ValidPatternData = new TheoryData<string, RuleTestRequest, string>
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
            // The segment resolves to an empty string instead of failing
            { "nested/{nested.a}/end", new RuleTestRequest(), "nested//end" }
        };

        [Theory]
        [MemberData(nameof(ValidPatternData))]
        public void ValidPattern(string pattern, RuleTestRequest request, string expectedFormatResult)
        {
            var rulePathPattern = ParsePattern(pattern);
            string actualFormatResult = rulePathPattern.Format(request);
            Assert.Equal(expectedFormatResult, actualFormatResult);
        }

        [Theory]
        [InlineData("before/{unterminated-brace/end", Skip = "We don't detect this at the moment.")]
        [InlineData("before/{missing}/end")]
        [InlineData("before/{nested}/end")]
        [InlineData("before/{int}/end")]
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
