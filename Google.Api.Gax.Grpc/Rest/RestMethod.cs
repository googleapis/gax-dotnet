/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// Class to convert between proto request/response messages and HTTP request/response messages.
    /// </summary>
    internal class RestMethod
    {
        private static readonly string s_applicationJsonMediaType = "application/json";
        private static readonly HttpMethod s_patchMethod = new HttpMethod("PATCH");

        private readonly MethodDescriptor _protoMethod;
        private readonly HttpMethod _httpMethod;
        private readonly JsonParser _parser;
        private readonly Func<IMessage, TranscodingOutput> _contentFactory;

        private static readonly FieldType[] TypesIneligibleForQueryStringEncoding = { FieldType.Group, FieldType.Message, FieldType.Bytes };

        internal string FullName { get; }

        private RestMethod(MethodDescriptor protoMethod, HttpMethod httpMethod, JsonParser parser, Func<IMessage, TranscodingOutput> contentFactory) =>
            (_protoMethod,  _httpMethod,  _parser, FullName, _contentFactory) =
                (protoMethod, httpMethod, parser, $"/{protoMethod.Service.FullName}/{protoMethod.Name}", contentFactory);

        /// <summary>
        /// Creates a <see cref="RestMethod"/> representation from the given protobuf method representation.
        /// </summary>
        /// <param name="method">The protobuf method to represent.</param>
        /// <param name="parser">The JSON parser to use when parsing requests.</param>
        /// <returns>A representation of the method that can be used to handle HTTP requests/responses.</returns>
        internal static RestMethod Create(MethodDescriptor method, JsonParser parser)
        {
            var rule = method.GetOptions().GetExtension(AnnotationsExtensions.Http);
            if (rule is null)
            {
                throw new ArgumentException($"Method {method.Name} in service {method.Service.Name} has no HTTP rule");
            }

            (string pattern, HttpMethod httpMethod) = rule.PatternCase switch
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

            Func<IMessage, TranscodingOutput> contentFactory = CreateTranscodingContentFactory(method, pathPattern, rule.Body);

            return new RestMethod(method, httpMethod, parser, contentFactory);
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
        private static Func<IMessage, TranscodingOutput> CreateTranscodingContentFactory(MethodDescriptor protoMethod, HttpRulePathPattern pathPattern, string httpBodyPattern)
        {
            Func<IMessage, string> pathFactory =  pathPattern.Format;

            (bool allFieldsInBody, string bodyName, Func<IMessage, string> bodyFactory) = httpBodyPattern switch {
                "*" => (true, null, new Func<IMessage, string>(protoRequest =>  protoRequest.ToString())),
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

                var fieldsToEncode = unusedEligibleFields.Where(field =>
                    field.IsRequired || !IsDefaultValueForTranscoding(field, field.Accessor.GetValue(message)));

                var queryStringParams = fieldsToEncode.ToDictionary(field => field.JsonName,
                    field => field.Accessor.GetValue(message).ToString());

                return new TranscodingOutput(path, queryStringParams, body);
            };
        }

        /// <summary>
        /// Creates a new <see cref="HttpRequestMessage"/> representing a call to the service method. This only
        /// populates the URI, HTTP method and content of the request. Other headers are expected to be populated afterwards.
        /// </summary>
        /// <param name="protoRequest">The request, in protobuf representation.</param>
        /// <param name="host">The host to create the request for, or null to use the default host for the client sending the request.</param>
        /// <returns>A request with the URI, method and content populated.</returns>
        internal HttpRequestMessage CreateRequest(IMessage protoRequest, string host)
        {
            var transcodingResult = _contentFactory(protoRequest);

            var uriPathWithParams = transcodingResult.QueryStringParameters.Any() 
                ? AppendQueryStringParameters(transcodingResult.UriPath, transcodingResult.QueryStringParameters.OrderBy(kvp => kvp.Key))
                : transcodingResult.UriPath;
            
            var uri = host is null ? new Uri(uriPathWithParams, UriKind.Relative) : new UriBuilder { Host = host, Path = uriPathWithParams }.Uri;
            
            return new HttpRequestMessage
            {
                RequestUri = uri,
                Method = _httpMethod,
                Content = transcodingResult.Body is null ? null : new StringContent(transcodingResult.Body, Encoding.UTF8, s_applicationJsonMediaType),
            };
        }

        /// <summary>
        /// Merges the uri path and the query string parameters, escaping them.
        /// Ignores the possibility that the path can already have parameters or contain an anchor (`#`)
        /// </summary>
        /// <param name="uriPath">The path component of the service URI</param>
        /// <param name="queryStringParameters">The parameters to encode in the query string</param>
        /// <returns>An uri path merged with the encoded query string parameters</returns>
        private static string AppendQueryStringParameters(string uriPath, IOrderedEnumerable<KeyValuePair<string, string>> queryStringParameters)
        {
            var sb = new StringBuilder();
            sb.Append(uriPath);
            bool sbHasParameters = false;

            foreach (var kvpNameValue in queryStringParameters)
            {
                sb.Append(sbHasParameters ? "&" : "?");
                sbHasParameters = true;
                sb.Append(Uri.EscapeDataString(kvpNameValue.Key));
                sb.Append("=");
                sb.Append(Uri.EscapeDataString(kvpNameValue.Value));
            }
            
            return sb.ToString();
        }
        
        private static bool IsDefaultValueForTranscoding(FieldDescriptor field, object fieldValue)
        {
            if (TypesIneligibleForQueryStringEncoding.Contains(field.FieldType))
                throw new NotImplementedException($"Field {field.Name} in method service {field.MessageType.Name} has a type {field.FieldType} for which a default value comparison for GRPC Transcoding should not be performed since the type {field.FieldType} should not be transcoded.");

            switch(field.FieldType)
            {   case FieldType.Bool:
                    return (bool) fieldValue;
                case FieldType.String:
                    return (string) fieldValue == "";
                case FieldType.Enum:
                    return (int) fieldValue == 0;
                case FieldType.Double:
                    return (double) fieldValue == 0;
                case FieldType.Float:
                    return (float) fieldValue == 0F;
                case FieldType.Int32:
                case FieldType.SInt32:
                case FieldType.SFixed32:
                    return (int) fieldValue == 0;
                case FieldType.Int64:
                case FieldType.SInt64:
                case FieldType.SFixed64:
                    return (long) fieldValue == 0L;
                case FieldType.UInt32:
                case FieldType.Fixed32:
                    return (uint) fieldValue == 0U;
                case FieldType.UInt64:
                case FieldType.Fixed64:
                    return (ulong) fieldValue == 0UL;
                default:
                    throw new ArgumentException($"Field {field.Name} in method service {field.MessageType.Name} has a type {field.FieldType} for which a default value comparison is not defined in the Gax");
            }
        }

        // TODO: Handle cancellation?
        /// <summary>
        /// Parses the response and converts it into the protobuf response type.
        /// </summary>
        internal async Task<TResponse> ReadResponseAsync<TResponse>(Task<HttpResponseMessage> httpResponseTask)
        {
            var httpResponse = await httpResponseTask.ConfigureAwait(false);
            var status = RestChannel.GetStatus(httpResponse);
            if (status.StatusCode != StatusCode.OK)
            {
                throw new RpcException(status);
            }
            string json = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            return (TResponse) _parser.Parse(json, _protoMethod.OutputType);
        }

        private class TranscodingOutput
        {
            internal string UriPath { get; }
            internal Dictionary<string, string> QueryStringParameters { get; }
            internal string Body { get; }

            internal TranscodingOutput(string uriPath, Dictionary<string, string> queryStringParameters, string body) =>
                (UriPath, QueryStringParameters, Body) =
                (uriPath, new Dictionary<string, string>(queryStringParameters), body);
        }
    }
}
