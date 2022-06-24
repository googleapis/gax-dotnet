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

    private readonly Func<IMessage, TranscodingOutput> _contentFactory;

    internal HttpRuleTranscoder(MethodDescriptor method, HttpRule rule)
    {
        (string pattern, var httpMethod) = rule.PatternCase switch
        {
            HttpRule.PatternOneofCase.Get => (rule.Get, HttpMethod.Get),
            HttpRule.PatternOneofCase.Post => (rule.Post, HttpMethod.Post),
            HttpRule.PatternOneofCase.Patch => (rule.Patch, s_patchMethod),
            HttpRule.PatternOneofCase.Put => (rule.Put, HttpMethod.Put),
            HttpRule.PatternOneofCase.Delete => (rule.Delete, HttpMethod.Delete),
            HttpRule.PatternOneofCase.Custom => (rule.Custom.Path, new HttpMethod(rule.Custom.Kind)),
            _ => throw new ArgumentException("HTTP rule has no pattern")
        };

        var pathPattern = HttpRulePathPattern.Parse(pattern, method.InputType);

        // TODO: Refactor this to fit the new class structure.
        _contentFactory = CreateTranscodingContentFactory(method, httpMethod, pathPattern, rule.Body);
    }

    /// <summary>
    /// This function creates a GRPC Transcoding lambda with curried method descriptor
    ///
    /// GRPC Transcoding returns the parameters of the http request, namely
    ///  - the path of the uri
    ///  - the query string parameters
    ///  - the body
    /// based on the
    ///  - method descriptor, specifically the list of input message fields, and the `google.api.http` annotation
    ///  - the request message
    /// It is described in the AIP-127 (https://google.aip.dev/127) and the proto comments for google.api.HttpRule
    /// (https://github.com/googleapis/googleapis/blob/master/google/api/http.proto#L44-L312)
    /// </summary>
    /// <returns>A lambda that will provide the transcoding output when the request method is known</returns>
    private static Func<IMessage, TranscodingOutput> CreateTranscodingContentFactory(MethodDescriptor protoMethod, HttpMethod httpMethod, HttpRulePathPattern pathPattern, string httpBodyPattern)
    {
        Func<IMessage, string> pathFactory = pathPattern.Format;

        (bool allFieldsInBody, string bodyName, Func<IMessage, string> bodyFactory) = httpBodyPattern switch
        {
            "*" => (true, null, new Func<IMessage, string>(protoRequest => protoRequest.ToString())),
            "" => (false, null, new Func<IMessage, string>(protoRequest => null)),
            string name when protoMethod.InputType.FindFieldByName(name) is FieldDescriptor field => (false, name, new Func<IMessage, string>(protoRequest => field.Accessor.GetValue(protoRequest).ToString())),
            _ => throw new ArgumentException($"Method {protoMethod.Name} in service {protoMethod.Service.Name} has a body parameter {httpBodyPattern} in the 'google.api.http' annotation which is not a field in {protoMethod.InputType.Name}")
        };

        List<FieldDescriptor> unusedEligibleFields = new List<FieldDescriptor>();
        if (!allFieldsInBody)
        {
            var usedFieldNames = new HashSet<string>(pathPattern.TopLevelFieldNames);
            if (bodyName != null)
            {
                usedFieldNames.Add(bodyName);
            }

            var queryStringParamsEligibleFields = protoMethod.InputType.Fields.InDeclarationOrder()
                .Where(f => !TypesIneligibleForQueryStringEncoding.Contains(f.FieldType));

            unusedEligibleFields = queryStringParamsEligibleFields.Where(field => !usedFieldNames.Contains(field.Name)).ToList();
        }

        return message =>
        {
            var path = pathFactory(message);
            var body = bodyFactory(message);

            var fieldsToEncode = unusedEligibleFields.Where(field => !field.HasPresence || field.Accessor.HasValue(message));

            var queryStringParams = fieldsToEncode.ToDictionary(field => field.JsonName,
                field => field.Accessor.GetValue(message).ToString());

            return new TranscodingOutput(httpMethod, path, queryStringParams, body);
        };
    }

    /// <summary>
    /// Attempts to use this rule to transcode the given request.
    /// </summary>
    /// <param name="request">The request to transcode. Must not be null.</param>
    /// <returns>The result of transcoding, or null if the rule did not match.</returns>
    internal TranscodingOutput Transcode(IMessage request) => _contentFactory(request);
}
