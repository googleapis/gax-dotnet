/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// A transcoder for an HttpRule, including any additional bindings, which are
/// applied in turn until a match is found with a <see cref="TranscodingOutput"/> result.
/// </summary>
internal sealed partial class HttpRuleTranscoder
{
    private readonly List<SingleRuleTranscoder> _transcoders;

    /// <summary>
    /// Creates a transcoder for the given method (named only for error messages) with the specified
    /// request message descriptor and HttpRule. See AIP-127 (https://google.aip.dev/127) and the proto comments
    /// for google.api.HttpRule (https://github.com/googleapis/googleapis/blob/master/google/api/http.proto#L44-L312)
    /// </summary>
    /// <param name="methodName">Name of the method, used only for diagnostic purposes.</param>
    /// <param name="requestMessage">The descriptor for the message request type</param>
    /// <param name="rule">The HttpRule that the new transcoder should represent, excluding any additional bindings.</param>
    internal HttpRuleTranscoder(string methodName, MessageDescriptor requestMessage, HttpRule rule)
    {
        _transcoders = new List<SingleRuleTranscoder> { new SingleRuleTranscoder(methodName, requestMessage, rule) };
        _transcoders.AddRange(rule.AdditionalBindings.Select(binding => new SingleRuleTranscoder(methodName, requestMessage, binding)));
    }

    /// <summary>
    /// Returns the transcoding result from the first matching HttpRule, or
    /// null if no rules match.
    /// </summary>
    internal TranscodingOutput Transcode(IMessage request) =>
        _transcoders
            .Select(t => t.Transcode(request))
            .FirstOrDefault(result => result is not null);

    /// <summary>
    /// A transcoder for a single rule, ignoring additional bindings.
    /// </summary>
    private class SingleRuleTranscoder
    {
        private static readonly HttpMethod s_patchMethod = new HttpMethod("PATCH");

        private readonly HttpMethod _httpMethod;
        private readonly Func<IMessage, string> _bodyTranscoder;
        private readonly HttpRulePathPattern _pathPattern;
        private readonly List<QueryParameterField> _queryParameterFields;

        internal SingleRuleTranscoder(string methodName, MessageDescriptor requestMessage, HttpRule rule)
        {
            (string pattern, _httpMethod) = rule.PatternCase switch
            {
                HttpRule.PatternOneofCase.Get => (rule.Get, HttpMethod.Get),
                HttpRule.PatternOneofCase.Post => (rule.Post, HttpMethod.Post),
                HttpRule.PatternOneofCase.Patch => (rule.Patch, s_patchMethod),
                HttpRule.PatternOneofCase.Put => (rule.Put, HttpMethod.Put),
                HttpRule.PatternOneofCase.Delete => (rule.Delete, HttpMethod.Delete),
                HttpRule.PatternOneofCase.Custom => (rule.Custom.Path, new HttpMethod(rule.Custom.Kind)),
                _ => throw new ArgumentException("HTTP rule has no pattern")
            };

            _pathPattern = HttpRulePathPattern.Parse(pattern, requestMessage);

            (bool allFieldsInBody, string bodyName, _bodyTranscoder) = rule.Body switch
            {
                "*" => (true, null, new Func<IMessage, string>(protoRequest => protoRequest.ToString())),
                "" => (false, null, new Func<IMessage, string>(protoRequest => null)),
                // TODO: If a field is specified, but it's not a message field, should we fail at this point?
                string name when requestMessage.FindFieldByName(name) is FieldDescriptor field => (false, field.JsonName, CreateMessageFormatter(field.Accessor)),
                _ => throw new ArgumentException($"Method {methodName} has a body parameter {rule.Body} in the 'google.api.http' annotation which is not a field in {requestMessage.Name}")
            };

            _queryParameterFields = new List<QueryParameterField>();
            if (!allFieldsInBody)
            {
                var usedFieldPaths = new HashSet<string>(_pathPattern.FieldPaths);
                if (bodyName != null)
                {
                    usedFieldPaths.Add(bodyName);
                }

                _queryParameterFields = GetQueryParameterFields(requestMessage, usedFieldPaths)
                    .OrderBy(field => field.Name, StringComparer.Ordinal)
                    .ToList();
            }

            Func<IMessage, string> CreateMessageFormatter(IFieldAccessor accessor) => protoRequest =>
            {
                if (protoRequest is null)
                {
                    return null;
                }
                var value = accessor.GetValue(protoRequest);
                if (value is not IMessage messageToFormat)
                {
                    return null;
                }
                return JsonFormatter.Default.Format(messageToFormat);
            };
        }

        private static IEnumerable<QueryParameterField> GetQueryParameterFields(MessageDescriptor requestDescriptor, HashSet<string> excludedPaths)
        {
            // Avoid infinite recursion for recursive messages.
            var descriptorStack = new Stack<MessageDescriptor>();
            var result = new List<QueryParameterField>();

            AccumulateMessages(message => message, currentPath: null, requestDescriptor);
            return result;

            void AccumulateMessages(Func<IMessage, IMessage> currentSelector, string currentPath, MessageDescriptor messageDescriptor)
            {
                if (descriptorStack.Contains(messageDescriptor))
                {
                    throw new ArgumentException($"Message descriptor {messageDescriptor.FullName} contains itself recursively.");
                }
                descriptorStack.Push(messageDescriptor);
                foreach (var field in messageDescriptor.Fields.InDeclarationOrder())
                {
                    string path = currentPath is null ? field.JsonName : $"{currentPath}.{field.JsonName}";
                    if (excludedPaths.Contains(path))
                    {
                        continue;
                    }
                    // Note: map fields are repeated fields, so we don't need to explicitly remove them.
                    if (field.FieldType == FieldType.Message && !field.IsRepeated)
                    {
                        AccumulateMessages(
                            message => currentSelector(message) is IMessage parent ? (IMessage) field.Accessor.GetValue(parent) : null,
                            path,
                            field.MessageType);
                    }
                    else if (IsEligibleQueryParameterLeafField(field))
                    {
                        result.Add(new QueryParameterField(currentSelector, path, field));
                    }
                }
                descriptorStack.Pop();
            }

            static bool IsEligibleQueryParameterLeafField(FieldDescriptor field)
            {
                if (field.FieldType == FieldType.Message || field.FieldType == FieldType.Group || field.FieldType == FieldType.Bytes)
                {
                    return false;
                }
                if (field.IsExtension)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Attempts to use this rule to transcode the given request.
        /// </summary>
        /// <param name="request">The request to transcode. Must not be null.</param>
        /// <returns>The result of transcoding, or null if the rule did not match.</returns>
        internal TranscodingOutput Transcode(IMessage request)
        {
            string path = _pathPattern.TryFormat(request);
            if (path is null)
            {
                return null;
            }
            string body = _bodyTranscoder(request);
            var queryParameters = from field in _queryParameterFields
                                  from value in field.GetValues(request)
                                  select new KeyValuePair<string, string>(field.Name, value);
            return new TranscodingOutput(_httpMethod, path, queryParameters, body);
        }
    }

    /// <summary>
    /// A field that might be transcoded as a query parameter.
    /// </summary>
    private class QueryParameterField
    {
        private const uint UnsignedInt32Zero = 0;
        private readonly bool _includeDefaultValues;
        private readonly FieldDescriptor _field;

        /// <summary>
        /// A delegate which accepts the original request message, and returns the parent of _field,
        /// or null if the field isn't present in the request.
        /// </summary>
        private readonly Func<IMessage, IMessage> _parentSelector;

        // The name used for the query parameter
        internal string Name { get; }

        internal QueryParameterField()
        {
        }

        public QueryParameterField(Func<IMessage, IMessage> parentSelector, string path, FieldDescriptor field)
        {
            _parentSelector = parentSelector;
            Name = path;
            _field = field;


            var fieldBehavior = field.GetOptions()?.GetExtension(FieldBehaviorExtensions.FieldBehavior);
            var hasFieldBehaviorRequiredAnnotation = fieldBehavior is not null && fieldBehavior.Contains(FieldBehavior.Required);
            _includeDefaultValues = hasFieldBehaviorRequiredAnnotation || field.HasPresence;
        }

        internal IEnumerable<string> GetValues(IMessage request)
        {
            var parent = _parentSelector(request);
            if (parent is null)
            {
                yield break;
            }

            if (_field.HasPresence && !_field.Accessor.HasValue(request))
            {
                yield break;
            }

            object value = _field.Accessor.GetValue(parent);
            if (value is null)
            {
                yield break;
            }

            if (!_includeDefaultValues && IsDefaultValue(value))
            {
                yield break;
            }

            if (_field.IsRepeated && value is IList list)
            {
                foreach (var item in list)
                {
                    yield return FormatValue(item);
                }
            }
            else
            {
                yield return FormatValue(value);
            }

            static bool IsDefaultValue(object value) =>
                // (Comments are the protobuf language keywords)
                // string
                value is "" ||
                // bool
                value is false ||
                // double, float
                value is 0.0f || value is 0.0d ||
                // int32, sint32, sfixed32, int64, sint64, sfixed64
                value is 0 || value is 0L ||
                // uint32, fixed32, uint64, fixed64
                value is UnsignedInt32Zero || value is 0UL || 
                // bytes
                (value is ByteString bs && bs.IsEmpty);

            static string FormatValue(object value) => 
                value is bool b ? (b ? "true" : "false")
                : value is IFormattable formattable ? formattable.ToString(format: null, CultureInfo.InvariantCulture)
                : value.ToString();
        }
    }
}
