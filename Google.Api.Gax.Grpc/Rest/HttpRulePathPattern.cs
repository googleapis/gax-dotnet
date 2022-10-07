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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Representation of a pattern within a google.api.http option, such as "/v4/{parent=projects/*/tenants/*}/jobs".
/// The pattern is parsed once, and placeholders (such as "parent" in the above) are interpreted as fields within
/// a protobuf request message. The pattern can then be formatted later within the context of a request.
/// </summary>
internal sealed class HttpRulePathPattern
{
    /// <summary>
    /// The path segments - these are *not* slash-separated segments, but instead they're based on fields. So
    /// /xyz/{a}/abc/{b} would contain four segments, "/xyz/", "{a}", "/abc/", "{b}".
    /// </summary>
    private readonly IEnumerable<IPathSegment> _segments;

    private HttpRulePathPattern(List<IPathSegment> segments) =>
        _segments = segments;

    internal static HttpRulePathPattern Parse(string pattern, MessageDescriptor requestDescriptor)
    {
        var segments = new List<IPathSegment>();

        int currentIndex = 0;
        while (currentIndex < pattern.Length)
        {
            int braceStart = pattern.IndexOf('{', currentIndex);
            int braceEnd = pattern.IndexOf('}', currentIndex);
            if (braceStart == -1)
            {
                if (braceEnd != -1)
                {
                    throw new ArgumentException($"Resource pattern '{pattern}' is invalid: unmatched }}");
                }
                break;
            }
            // Either the closing brace comes before the opening one, or doesn't exist.
            if (braceEnd < braceStart)
            {
                throw new ArgumentException($"Resource pattern '{pattern}' is invalid: unmatched {{");
            }
            if (braceStart != currentIndex)
            {
                string literal = pattern.Substring(currentIndex, braceStart - currentIndex);
                segments.Add(new LiteralSegment(literal));
            }
            segments.Add(new FieldSegment(pattern.Substring(braceStart, braceEnd - braceStart + 1), requestDescriptor));
            currentIndex = braceEnd + 1;
        }
        if (currentIndex != pattern.Length)
        {
            segments.Add(new LiteralSegment(pattern.Substring(currentIndex)));
        }
        return new HttpRulePathPattern(segments);
    }

    /// <summary>
    /// Attempts to format the path with respect to the given request,
    /// returning the formatted segment or null if formatting failed due to the request data.
    /// </summary>
    internal string TryFormat(IMessage message)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var segment in _segments)
        {
            var formattedSegment = segment.TryFormat(message);
            if (formattedSegment is null)
            {
                return null;
            }
            builder.Append(formattedSegment);
        }
        return builder.ToString();
    }

    /// <summary>
    /// Names of the fields of the top-level message that are bound by this pattern.
    /// </summary>
    internal IEnumerable<string> FieldPaths => _segments
        .OfType<FieldSegment>()
        .Select(s => s.JsonFieldPath);

    private interface IPathSegment
    {
        /// <summary>
        /// Formats this segment in the context of the given request,
        /// returning null if the data in the request means that the path doesn't match.
        /// </summary>
        string TryFormat(IMessage request);
    }

    /// <summary>
    /// A path segment that matches a field in the request.
    /// </summary>
    private sealed class FieldSegment : IPathSegment
    {
        /// <summary>
        /// The separator between the field path and the pattern.
        /// </summary>
        private static readonly char[] s_fieldPathPatternSeparator = { '=' };
        /// <summary>
        /// The separator between fields within the field path.
        /// </summary>
        private static readonly char[] s_fieldPathSeparator = { '.' };

        /// <summary>
        /// The field path, used to determine which fields should be populated as query parameters.
        /// Each element of the field path is the JSON name of the field, as it would be used
        /// in a query parameter.
        /// </summary>
        internal string JsonFieldPath { get; }

        private readonly Regex _validationRegex;
        private readonly Func<Match, string> _formatter;
        private readonly Func<IMessage, string> _propertyAccessor;

        /// <summary>
        /// Creates a segment representing the given field text, with respect to
        /// the given request descriptor.
        /// </summary>
        /// <param name="fieldText">The text of the field segment, e.g. "{foo=*}"</param>
        /// <param name="descriptor">The descriptor within which to find the field.</param>
        internal FieldSegment(string fieldText, MessageDescriptor descriptor)
        {
            // Strip the leading and trailing braces
            fieldText = fieldText.Substring(1, fieldText.Length - 2);

            // Split out the field path from the pattern it has to match (if any)
            string[] bits = fieldText.Split(s_fieldPathPatternSeparator, 2);
            string fieldPath = bits[0];
            string pattern = bits.Length == 2 ? bits[1] : "*";
            (_validationRegex, _formatter) = ParsePattern(pattern);

            string[] fieldNames = fieldPath.Split(s_fieldPathSeparator);

            StringBuilder jsonFieldPathBuilder = new StringBuilder();
            Func<IMessage, IMessage> messageSelector = message => message;
            // Create a delegate to navigate down all the fields except the last. These must be singular message fields.
            // TODO: Refactor the lambda expressions that all invoke the previous selector. They're somewhat repetitive.
            for (int i = 0; i < fieldNames.Length - 1; i++)
            {
                var field = GetField(descriptor, fieldNames[i]);
                if (field.FieldType != FieldType.Message)
                {
                    throw new ArgumentException($"Field {fieldNames[i]} in message {descriptor.FullName} cannot be used as non-final field in a resource pattern");
                }
                AppendFieldNameToJsonFieldPath(field);

                var previousSelector = messageSelector;
                messageSelector = message =>
                {
                    var parent = previousSelector(message);
                    return parent is null ? null : (IMessage) field.Accessor.GetValue(parent);
                };
                descriptor = field.MessageType;
            }

            // Now handle the last field, which must be a singular scalar field.
            // (It's extremely unusual for it to be anything other than a string field, but it's easy enough to handle.)
            var lastFieldName = fieldNames.Last();
            var lastField = GetField(descriptor, lastFieldName);
            if (lastField.IsRepeated || lastField.FieldType == FieldType.Message)
            {
                throw new ArgumentException($"Field {lastFieldName} in message {descriptor.FullName} cannot be used as a final field in a resource pattern");
            }
            AppendFieldNameToJsonFieldPath(lastField);
            _propertyAccessor = message =>
            {
                var parent = messageSelector(message);
                return parent is null ? null : ProtobufUtilities.FormatValueAsJsonPrimitive(lastField.Accessor.GetValue(parent));
            };
            JsonFieldPath = jsonFieldPathBuilder.ToString();

            void AppendFieldNameToJsonFieldPath(FieldDescriptor field)
            {
                if (jsonFieldPathBuilder.Length > 0)
                {
                    jsonFieldPathBuilder.Append(".");
                }
                jsonFieldPathBuilder.Append(field.JsonName);
            }

            static FieldDescriptor GetField(MessageDescriptor descriptor, string name)
            {
                var field = descriptor.FindFieldByName(name);
                if (field is null)
                {
                    throw new ArgumentException($"Field {name} not found in message {descriptor.FullName}");
                }
                if (field.IsRepeated || field.IsMap)
                {
                    throw new ArgumentException($"Field {name} in message {descriptor.FullName} cannot be used in a resource pattern");
                }
                return field;
            }

            static (Regex, Func<Match, string>) ParsePattern(string pattern)
            {
                var builder = new StringBuilder("^"); // We want to match the whole string
                Action<Match, StringBuilder> formatBuilder = null;
                int currentIndex = 0;
                int groupIndex = 1;
                while (currentIndex < pattern.Length)
                {
                    int starStart = pattern.IndexOf('*', currentIndex);
                    // Handle the literal between the previous star (if any) and the start of the next one.
                    // If starStart==-1, this is any trailing literal at the end of the pattern.
                    string literal = pattern.Substring(currentIndex, (starStart == -1 ? pattern.Length : starStart) - currentIndex);
                    if (literal != "")
                    {
                        builder.Append(Regex.Escape(literal));
                        formatBuilder += (match, sb) => sb.Append(literal);
                    }
                    if (starStart < 0)
                    {
                        break;
                    }

                    int starEnd = starStart + 1;
                    while (starEnd < pattern.Length && pattern[starEnd] == '*')
                    {
                        starEnd++;
                    }
                    int starCount = starEnd - starStart;
                    // Deliberately local to have a different variable per iteration, as it's captured in the lambda expression.
                    int matchGroupIndex = groupIndex;
                    groupIndex++;
                    switch (starCount)
                    {
                        case 1:
                            builder.Append("([^/]+)");
                            // We won't have any slashes in the value, so we don't need to split then join.
                            formatBuilder += (match, sb) => sb.Append(Uri.EscapeDataString(match.Groups[matchGroupIndex].Value));
                            break;
                        case 2:
                            builder.Append("(.+)");
                            formatBuilder += (match, sb) => sb.Append(string.Join("/", match.Groups[matchGroupIndex].Value.Split('/').Select(segment => Uri.EscapeDataString(segment))));
                            break;
                        default:
                            throw new ArgumentException($"Resource pattern '{pattern}' is invalid");
                    }
                    currentIndex = starEnd;
                }
                builder.Append("$"); // We want to match the whole string
                Func<Match, string> formatter = match =>
                {
                    var sb = new StringBuilder("");
                    formatBuilder(match, sb);
                    return sb.ToString();
                };
                return (new Regex(builder.ToString(), RegexOptions.Compiled), formatter);
            }
        }

        public string TryFormat(IMessage request)
        {
            string result = _propertyAccessor(request);
            if (result is null)
            {
                return null;
            }
            Match match = _validationRegex.Match(result);
            if (!match.Success)
            {
                return null;
            }
            return _formatter(match);
        }
    }

    /// <summary>
    /// A path segment that is just based on a literal string. This always
    /// succeeds, producing the same result every time.
    /// </summary>
    private sealed class LiteralSegment : IPathSegment
    {
        private string _literal;

        internal LiteralSegment(string literal) => _literal = literal;

        public string TryFormat(IMessage request) => _literal;
    }
}
