/*
 * Copyright 2022 Google LLC
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
        private static readonly FieldType[] TypesIneligibleForQueryStringEncoding = { FieldType.Group, FieldType.Message, FieldType.Bytes };
        private static readonly HttpMethod s_patchMethod = new HttpMethod("PATCH");

        private readonly HttpMethod _httpMethod;
        private readonly Func<IMessage, string> _bodyTranscoder;
        private readonly HttpRulePathPattern _pathPattern;
        private readonly List<FieldDescriptor> _queryParameterFields;

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
                // TODO: If a field is specified, but then isn't present in the request, should the request
                // fail or should it just have no body?
                string name when requestMessage.FindFieldByName(name) is FieldDescriptor field => (false, name, new Func<IMessage, string>(protoRequest => field.Accessor.GetValue(protoRequest).ToString())),
                _ => throw new ArgumentException($"Method {methodName} has a body parameter {rule.Body} in the 'google.api.http' annotation which is not a field in {requestMessage.Name}")
            };

            _queryParameterFields = new List<FieldDescriptor>();
            if (!allFieldsInBody)
            {
                var usedFieldNames = new HashSet<string>(_pathPattern.TopLevelFieldNames);
                if (bodyName != null)
                {
                    usedFieldNames.Add(bodyName);
                }

                var queryStringParamsEligibleFields = requestMessage.Fields.InDeclarationOrder()
                    .Where(f => !TypesIneligibleForQueryStringEncoding.Contains(f.FieldType));

                _queryParameterFields = queryStringParamsEligibleFields
                    .Where(field => !usedFieldNames.Contains(field.Name))
                    .OrderBy(field => field.JsonName, StringComparer.Ordinal)
                    .ToList();
            }
        }

        private const uint UnsignedInt32Zero = 0;

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
                                  from value in GetValues(field, request)
                                  select new KeyValuePair<string, string>(field.JsonName, value);
            return new TranscodingOutput(_httpMethod, path, queryParameters, body);

            static IEnumerable<string> GetValues(FieldDescriptor field, IMessage request)
            {
                if (field.HasPresence && !field.Accessor.HasValue(request))
                {
                    yield break;
                }

                object value = field.Accessor.GetValue(request);
                if (!field.HasPresence && (value is "" || value is 0.0f || value is 0.0d || value is 0 || value is 0L || value is 0UL || value is UnsignedInt32Zero))
                {
                    yield break;
                }
                yield return value is IFormattable formattable
                    ? formattable.ToString(format: null, CultureInfo.InvariantCulture)
                    : value?.ToString();

                // TODO: Handle repeated fields
                // TODO: Handle message fields (currently prohibited via TypesIneligibleForQueryStringEncoding, but theoretically valid)
            }
        }
    }
}
