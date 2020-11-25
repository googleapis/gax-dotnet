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

        private readonly IEnumerable<Func<IMessage, string>> _segments;

        private HttpRulePathPattern(List<Func<IMessage, string>> segments) =>
            _segments = segments;

        internal static HttpRulePathPattern Parse(string pattern, MessageDescriptor requestDescriptor)
        {
            List<Func<IMessage, string>> segments = new List<Func<IMessage, string>>();
            var matches = s_braceRegex.Matches(pattern);
            int lastEnd = 0;
            foreach (Match match in matches)
            {
                int start = match.Index;
                if (start > lastEnd)
                {
                    string literal = pattern.Substring(lastEnd, start - lastEnd);
                    segments.Add(message => literal);
                }
                int endOfName = match.Value.IndexOf('=');
                if (endOfName == -1)
                {
                    // If we don't have an '=', just go as far as the closing brace.
                    endOfName = match.Value.Length - 1;
                }
                string propertyPath = match.Value.Substring(1, endOfName - 1);
                segments.Add(CreatePropertyAccessor(requestDescriptor, propertyPath));
                lastEnd = match.Index + match.Length;
            }
            if (lastEnd != pattern.Length)
            {
                string literal = pattern.Substring(lastEnd);
                segments.Add(message => literal);
            }
            return new HttpRulePathPattern(segments);
        }

        // TODO: do we need to perform URL encoding of anything?
        internal string Format(IMessage message) => string.Join("", _segments.Select(segment => segment(message)));

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
            else
            {
                var remainder = CreatePropertyAccessor(field.MessageType, propertyPath.Substring(periodIndex + 1));
                return message =>
                {
                    var nested = (IMessage)accessor.GetValue(message);
                    return nested is null ? "" : remainder(nested);
                };
            }
        }
    }
}
