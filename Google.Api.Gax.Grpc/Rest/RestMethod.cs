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
        private readonly HttpRulePathPattern _pathPattern;
        private readonly HttpMethod _httpMethod;
        private readonly Func<IMessage, string> _contentFactory;
        private readonly JsonParser _parser;

        internal string FullName { get; }

        private RestMethod(MethodDescriptor protoMethod, HttpRulePathPattern pathPattern, HttpMethod httpMethod, Func<IMessage, string> contentFactory, JsonParser parser) =>
            (_protoMethod, _pathPattern, _httpMethod, _contentFactory, _parser, FullName) =
            (protoMethod, pathPattern, httpMethod, contentFactory, parser, $"/{protoMethod.Service.FullName}/{protoMethod.Name}");

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

            Func<IMessage, string> contentFactory = rule.Body switch
            {
                "*" => message => message.ToString(),
                "" => null,
                string name when method.InputType.FindFieldByName(name) is FieldDescriptor field => message => field.Accessor.GetValue(message).ToString(),
                _ => throw new ArgumentException($"Method {method.Name} in service {method.Service.Name} has body field {rule.Body} which is not a field in {method.InputType.Name}")
            };

            return new RestMethod(method, pathPattern, httpMethod, contentFactory, parser);
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
            string path = _pathPattern.Format(protoRequest);
            var uri = host is null ? new Uri(path, UriKind.Relative) : new UriBuilder { Host = host, Path = path }.Uri;
            string jsonContent = _contentFactory(protoRequest);
            return new HttpRequestMessage
            {
                RequestUri = uri,
                Method = _httpMethod,
                Content = jsonContent is null ? null : new StringContent(jsonContent, Encoding.UTF8, s_applicationJsonMediaType)
            };
        }

        /// <summary>
        /// Parses the response 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal async Task<IMessage> ConvertResponseAsync(HttpResponseMessage response)
        {
            var status = RestChannel.GetStatus(response);
            if (status.StatusCode != StatusCode.OK)
            {
                throw new RpcException(status);
            }
            string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return _parser.Parse(json, _protoMethod.OutputType);
        }

        /// <summary>
        /// Parses the response 
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


    }
}
