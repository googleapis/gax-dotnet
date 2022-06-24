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
using System.Linq;
using System.Net.Http;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// A transcoder for a single HttpRule, not including any additional bindings.
/// A <see cref="RestMethod"/> has one or more transcoders, applied in turn until
/// a match is found with a <see cref="TranscodingOutput"/> result.
/// </summary>
internal sealed partial class HttpRuleTranscoder
{
    private static readonly FieldType[] TypesIneligibleForQueryStringEncoding = { FieldType.Group, FieldType.Message, FieldType.Bytes };
    private static readonly HttpMethod s_patchMethod = new HttpMethod("PATCH");

    private readonly HttpMethod _httpMethod;
    private readonly Func<IMessage, string> _bodyTranscoder;
    private readonly HttpRulePathPattern _pathPattern;
    private readonly List<FieldDescriptor> _queryParameterFields;

    /// <summary>
    /// Creates a transcoder for the given method (name only for simplicity of testing) with the specified
    /// request message descriptor and HttpRule. See AIP-127 (https://google.aip.dev/127) and the proto comments
    /// for google.api.HttpRule (https://github.com/googleapis/googleapis/blob/master/google/api/http.proto#L44-L312)
    /// </summary>
    /// <param name="methodName">Name of the method, used only for diagnostic purposes.</param>
    /// <param name="requestMessageDescriptor">The descriptor for the message request type</param>
    /// <param name="rule">The HttpRule that the new transcoder should represent, excluding any additional bindings.</param>
    internal HttpRuleTranscoder(string methodName, MessageDescriptor requestMessageDescriptor, HttpRule rule)
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

        _pathPattern = HttpRulePathPattern.Parse(pattern, requestMessageDescriptor);

        (bool allFieldsInBody, string bodyName, _bodyTranscoder) = rule.Body switch
        {
            // TODO: The body shouldn't contain any fields that are present in the URI.
            "*" => (true, null, new Func<IMessage, string>(protoRequest => protoRequest.ToString())),
            "" => (false, null, new Func<IMessage, string>(protoRequest => null)),
            string name when requestMessageDescriptor.FindFieldByName(name) is FieldDescriptor field => (false, name, new Func<IMessage, string>(protoRequest => field.Accessor.GetValue(protoRequest).ToString())),
            _ => throw new ArgumentException($"Method {methodName} has a body parameter {rule.Body} in the 'google.api.http' annotation which is not a field in {requestMessageDescriptor.Name}")
        };

        _queryParameterFields = new List<FieldDescriptor>();
        if (!allFieldsInBody)
        {
            var usedFieldNames = new HashSet<string>(_pathPattern.TopLevelFieldNames);
            if (bodyName != null)
            {
                usedFieldNames.Add(bodyName);
            }

            var queryStringParamsEligibleFields = requestMessageDescriptor.Fields.InDeclarationOrder()
                .Where(f => !TypesIneligibleForQueryStringEncoding.Contains(f.FieldType));

            _queryParameterFields = queryStringParamsEligibleFields.Where(field => !usedFieldNames.Contains(field.Name)).ToList();
        }
    }

    /// <summary>
    /// Attempts to use this rule to transcode the given request.
    /// </summary>
    /// <param name="request">The request to transcode. Must not be null.</param>
    /// <returns>The result of transcoding, or null if the rule did not match.</returns>
    internal TranscodingOutput Transcode(IMessage request)
    {
        string body = _bodyTranscoder(request);
        string path = _pathPattern.Format(request);
        var queryParameters = _queryParameterFields
            .Where(field => !field.HasPresence || field.Accessor.HasValue(request))
            // TODO: Format the field value with the invariant culture.
            // TODO: Handle repeated fields
            // TODO: Handle message fields (currently prohibited via TypesIneligibleForQueryStringEncoding, but theoretically valid)
            .ToDictionary(field => field.JsonName, field => field.Accessor.GetValue(request).ToString());
        return new TranscodingOutput(_httpMethod, path, queryParameters, body);
    }
}
