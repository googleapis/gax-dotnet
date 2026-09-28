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
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/def" }, "pattern/abc/def" },
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/New York" }, "pattern/abc/New%20York" },
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/caf\u00e9" }, "pattern/abc/caf%C3%A9" },
            { "pattern/{x=abc/**}", new RuleTestRequest { X = "abc/def/ghi" }, "pattern/abc/def/ghi" },
            { "pattern/{x=abc/*/ghi}", new RuleTestRequest { X = "abc/def/ghi" }, "pattern/abc/def/ghi" },
            { "pattern/{x=**}", new RuleTestRequest { X = "abc/New York" }, "pattern/abc/New%20York" },
            { "nested/{nested.a}", new RuleTestRequest { Nested = new RuleTestRequest.Types.Nested { A = "aaa" } }, "nested/aaa" },
            { "before/{int}/end", new RuleTestRequest { Int = 5 }, "before/5/end" },
            // The nested field isn't present, so this doesn't match.
            { "nested/{nested.a}/end", new RuleTestRequest(), null },
            // Single star fields don't match slashes
            { "pattern/{x}", new RuleTestRequest { X = "abc/def" }, null },
            { "pattern/{x=abc/*}", new RuleTestRequest { X = "abc/def/ghi" }, null },
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

        public static TheoryData<string, string, string> PathTraversalAndInjectionData = ConvertTheoryData(new TheoryData<string, RuleTestRequest, string>
        {
            // Dialogflow session (standard single-wildcard segment)
            { "v3/{x=projects/*/locations/*/agents/*/sessions/*}:detectIntent", new RuleTestRequest { X = "projects/p/locations/l/agents/a/sessions/.." }, "Invalid value for x '..'." },
            { "v3/{x=projects/*/locations/*/agents/*/sessions/*}:detectIntent", new RuleTestRequest { X = "projects/p/locations/l/agents/a/sessions/." }, "Invalid value for x '.'." },
            // Firestore documents (reserved double-wildcard path)
            { "v1/{x=projects/*/databases/*/documents/**}/indexes", new RuleTestRequest { X = "projects/sys-prod-123/databases/default/documents/doc-1/../../default" }, "Value for x must not contain segments that are exactly '..'." },
            { "v1/{x=projects/*/databases/*/documents/**}/indexes", new RuleTestRequest { X = "projects/sys-prod-123/databases/default/documents/doc-1/../../../../../../../escape-db" }, "Value for x must not contain segments that are exactly '..'." },
            { "v1/{x=**}/indexes", new RuleTestRequest { X = "../escape-db" }, "Value for x must not contain segments that are exactly '..'." },
            { "v1/{x=projects/*/databases/*/documents/**}/indexes", new RuleTestRequest { X = "projects/sys-prod-123/databases/default/documents/doc-1/./child" }, "Value for x must not contain segments that are exactly '.'." },
            // Webhooks (multiple standard wildcards)
            { "v3/projects/{x}/webhooks/{nested.a}", new RuleTestRequest { X = "p1", Nested = new RuleTestRequest.Types.Nested { A = ".." } }, "Invalid value for nested.a '..'." },
            { "v3/projects/{x}/webhooks/{nested.a}", new RuleTestRequest { X = "p1", Nested = new RuleTestRequest.Types.Nested { A = "." } }, "Invalid value for nested.a '.'." },
        });

        [Theory]
        [MemberData(nameof(PathTraversalAndInjectionData))]
        public void PathTraversalAndInjection_ThrowsArgumentException(string pattern, string requestJson, string expectedErrorMessage)
        {
            var rulePathPattern = ParsePattern(pattern);
            var request = RuleTestRequest.Parser.ParseJson(requestJson);
            var exception = Assert.Throws<ArgumentException>(() => rulePathPattern.TryFormat(request));
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Theory]
        [InlineData("v3/{x=projects/*/locations/*/agents/*/sessions/*}:detectIntent", "projects/p/locations/l/agents/a/sessions/s1", "v3/projects/p/locations/l/agents/a/sessions/s1:detectIntent")]
        [InlineData("v3/{x=projects/*/locations/*/agents/*/sessions/*}:detectIntent", "projects/p/locations/l/agents/a/sessions/s1?key=val", "v3/projects/p/locations/l/agents/a/sessions/s1%3Fkey%3Dval:detectIntent")]
        [InlineData("v3/{x=projects/*/locations/*/agents/*/sessions/*}:detectIntent", "projects/p/locations/l/agents/a/sessions/s1#frag", "v3/projects/p/locations/l/agents/a/sessions/s1%23frag:detectIntent")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/doc-1", "v1/projects/sys-prod-123/databases/default/documents/doc-1/indexes")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/my-file.txt", "v1/projects/sys-prod-123/databases/default/documents/my-file.txt/indexes")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/my-file..txt", "v1/projects/sys-prod-123/databases/default/documents/my-file..txt/indexes")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/doc?key=val", "v1/projects/sys-prod-123/databases/default/documents/doc%3Fkey%3Dval/indexes")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/doc#frag", "v1/projects/sys-prod-123/databases/default/documents/doc%23frag/indexes")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/doc-1/..%2f..%2fescape-db", "v1/projects/sys-prod-123/databases/default/documents/doc-1/..%252f..%252fescape-db/indexes")]
        [InlineData("v1/{x=projects/*/databases/*/documents/**}/indexes", "projects/sys-prod-123/databases/default/documents/doc-1/%2e%2e/escape-db", "v1/projects/sys-prod-123/databases/default/documents/doc-1/%252e%252e/escape-db/indexes")]
        public void ValidRealisticPatterns_Succeed(string pattern, string xValue, string expectedFormatResult)
        {
            var rulePathPattern = ParsePattern(pattern);
            var request = new RuleTestRequest { X = xValue };
            string actualFormatResult = rulePathPattern.TryFormat(request);
            Assert.Equal(expectedFormatResult, actualFormatResult);
        }

        private static HttpRulePathPattern ParsePattern(string pattern) =>
            HttpRulePathPattern.Parse(pattern, RuleTestRequest.Descriptor);
    }
}
