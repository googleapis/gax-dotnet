/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// Representation of a pattern within a google.api.http option, such as "/v4/{parent=projects/*/tenants/*}/jobs".
    /// The pattern is parsed once, and placeholders (such as "parent" in the above) are interpreted as fields within
    /// a protobuf request message. The pattern can then be formatted later within the context of a request.
    /// </summary>
    internal sealed class HttpRulePathPattern
    {
        private static readonly Regex s_braceRegex = new Regex(@"\{[^}]*\}");

        private readonly IEnumerable<HttpRulePathPatternSegment> _segments;

        private HttpRulePathPattern(List<HttpRulePathPatternSegment> segments) =>
            _segments = segments;

        internal static HttpRulePathPattern Parse(string pattern, MessageDescriptor requestDescriptor)
        {
            var segments = new List<HttpRulePathPatternSegment>();
            var matches = s_braceRegex.Matches(pattern);
            int lastEnd = 0;
            foreach (Match match in matches)
            {
                int start = match.Index;
                if (start > lastEnd)
                {
                    string literal = pattern.Substring(lastEnd, start - lastEnd);
                    segments.Add(HttpRulePathPatternSegment.CreateLiteral(literal));
                }
                int endOfName = match.Value.IndexOf('=');
                if (endOfName == -1)
                {
                    // If we don't have an '=', just go as far as the closing brace.
                    endOfName = match.Value.Length - 1;
                }
                string propertyPath = match.Value.Substring(1, endOfName - 1);
                segments.Add(CreatePatternSegment(requestDescriptor, propertyPath));
                lastEnd = match.Index + match.Length;
            }
            if (lastEnd != pattern.Length)
            {
                string literal = pattern.Substring(lastEnd);
                segments.Add(HttpRulePathPatternSegment.CreateLiteral(literal));
            }
            return new HttpRulePathPattern(segments);
        }

        // TODO: do we need to perform URL encoding of anything?
        internal string Format(IMessage message) => string.Join("", _segments.Select(segment => segment.Format(message)));

        /// <summary>
        /// Names of the fields of the top-level message that are bound by this pattern.
        /// </summary>
        internal List<string> TopLevelFieldNames => _segments
            .Where(segment => segment.TopLevelFieldName != null)
            .Select(s => s.TopLevelFieldName)
            .ToList();

        private static HttpRulePathPatternSegment CreatePatternSegment(MessageDescriptor descriptor, string propertyPath)
        {
            int periodIndex = propertyPath.IndexOf('.');
            bool singleFieldPath = periodIndex == -1;
            string fieldName = singleFieldPath  ? propertyPath : propertyPath.Substring(0, periodIndex);

            return new HttpRulePathPatternSegment(fieldName, CreatePropertyAccessor(descriptor, propertyPath));
        }

        private static Func<IMessage, string> CreatePropertyAccessor(MessageDescriptor descriptor, string propertyPath)
        {
            int periodIndex = propertyPath.IndexOf('.');
            bool singleFieldPath = periodIndex == -1;
            string fieldName = singleFieldPath  ? propertyPath : propertyPath.Substring(0, periodIndex);
            var field = descriptor.FindFieldByName(fieldName) ?? throw new ArgumentException($"Field {fieldName} not found in message {descriptor.FullName}");
            var expectedFieldType = singleFieldPath ? FieldType.String : FieldType.Message;

            if (field.FieldType != expectedFieldType || field.IsRepeated || field.IsMap)
            {
                throw new ArgumentException($"Field {fieldName} in message {descriptor.FullName} cannot be used in a resource pattern");
            }

            var accessor = field.Accessor;
            if (singleFieldPath)
            {
                return message => (string) accessor.GetValue(message);
            }

            var remainder = CreatePropertyAccessor(field.MessageType, propertyPath.Substring(periodIndex + 1));
            return message =>
            {
                var nested = (IMessage)accessor.GetValue(message);
                return nested is null ? "" : remainder(nested);
            };
        }

        /// <summary>
        /// A segment of the HTTP Rule pattern.
        /// </summary>
        internal sealed class HttpRulePathPatternSegment
        {
            /// <summary>
            /// Given a message, 'fill in' this segment's value.
            /// </summary>
            private readonly Func<IMessage, string> _formatter;
            
            /// <summary>
            /// A name of the field in the top-level message that the segment is bound to
            /// (e.g. for a binding `{foo.bar}`, this will be `foo`)
            /// </summary>
            internal string TopLevelFieldName { get; }
            
            internal HttpRulePathPatternSegment(string topLevelFieldName, Func<IMessage, string> formatter) =>
                (TopLevelFieldName, _formatter) = (topLevelFieldName, formatter);

            internal string Format(IMessage message) => _formatter(message);

            internal static HttpRulePathPatternSegment CreateLiteral(string literal) =>
                new HttpRulePathPatternSegment(null, _ => literal);
        }
    }
}
