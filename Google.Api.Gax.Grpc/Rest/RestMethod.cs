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
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Class to convert between proto request/response messages and HTTP request/response messages.
/// (Details of request transcoding are mostly in <see cref="HttpRuleTranscoder"/>,
/// but they are abstracted by this class.)
/// </summary>
internal class RestMethod
{
    private readonly MethodDescriptor _protoMethod;
    private readonly JsonParser _parser;
    private readonly HttpRuleTranscoder _transcoder;

    internal string FullName { get; }

    private RestMethod(MethodDescriptor protoMethod, JsonParser parser, HttpRuleTranscoder transcoder) =>
        (_protoMethod,  _parser, FullName, _transcoder) =
            (protoMethod, parser, $"/{protoMethod.Service.FullName}/{protoMethod.Name}", transcoder);

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
        // TODO: create multiple rules with annotation bindings
        var transcoder = new HttpRuleTranscoder(method.FullName, method.InputType, rule);
        return new RestMethod(method, parser, transcoder);
    }

    internal HttpRequestMessage CreateRequest(IMessage request, string host)
    {
        // TODO: Use multiple rules, iterating over them until a match is found.
        var output = _transcoder.Transcode(request);
        return output.CreateRequest(host);
    }

    // TODO: Handle cancellation?
    /// <summary>
    /// Parses the response and converts it into the protobuf response type.
    /// </summary>
    internal async Task<TResponse> ReadResponseAsync<TResponse>(Task<ReadHttpResponseMessage> httpResponseTask)
    {
        var httpResponse = await httpResponseTask.ConfigureAwait(false);
        var status = httpResponse.GetStatus();
        if (status.StatusCode != StatusCode.OK)
        {
            throw new RpcException(status, httpResponse.GetTrailers());
        }
        return (TResponse) _parser.Parse(httpResponse.Content, _protoMethod.OutputType);
    }
}
