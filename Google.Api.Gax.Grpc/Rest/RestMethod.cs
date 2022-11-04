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
    private readonly ApiMetadata _apiMetadata;
    private readonly MethodDescriptor _protoMethod;
    private readonly JsonParser _parser;
    private readonly HttpRuleTranscoder _transcoder;

    /// <summary>
    /// The service-qualified method name, as used by gRPC, e.g. "/google.somepackage.SomeService/SomeMethod"
    /// </summary>
    internal string FullName { get; }

    private RestMethod(ApiMetadata apiMetadata, MethodDescriptor protoMethod, JsonParser parser, HttpRuleTranscoder transcoder) =>
        (_apiMetadata, _protoMethod,  _parser, FullName, _transcoder) =
        (apiMetadata, protoMethod, parser, $"/{protoMethod.Service.FullName}/{protoMethod.Name}", transcoder);

    /// <summary>
    /// Creates a <see cref="RestMethod"/> representation from the given protobuf method representation.
    /// </summary>
    /// <param name="apiMetadata">The metadata for the API that this method is part of.</param>
    /// <param name="method">The protobuf method to represent.</param>
    /// <param name="parser">The JSON parser to use when parsing requests.</param>
    /// <returns>A representation of the method that can be used to handle HTTP requests/responses.</returns>
    internal static RestMethod Create(ApiMetadata apiMetadata, MethodDescriptor method, JsonParser parser)
    {
        var rule = method.GetOptions()?.GetExtension(AnnotationsExtensions.Http);
        if (rule is null)
        {
            throw new ArgumentException($"Method {method.Name} in service {method.Service.Name} has no HTTP rule");
        }
        // If we have an override, it completely replaces the original rule.
        if (apiMetadata.HttpRuleOverrides.TryGetValue(method.FullName, out var overrideByteString))
        {
            rule = HttpRule.Parser.ParseFrom(overrideByteString);
        }
        var transcoder = new HttpRuleTranscoder(method.FullName, method.InputType, rule);
        return new RestMethod(apiMetadata, method, parser, transcoder);
    }

    internal HttpRequestMessage CreateRequest(IMessage request, string host)
    {
        var transcodingOutput = _transcoder.Transcode(request)
            // TODO: Is this the right exception to use?
            ?? throw new ArgumentException("Request could not be transcoded; it does not match any HTTP rule.");

        if (_apiMetadata.RequestNumericEnumJsonEncoding)
        {
            transcodingOutput = transcodingOutput.WithAdditionalQueryParameter("$alt", "json;enum-encoding=int");
        }
        return transcodingOutput.CreateRequest(host);
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

    internal IAsyncStreamReader<TResponse> ResponseStreamAsync<TResponse>(Task<HttpResponseMessage> httpResponseTask)
    {
        return new PartialDecodingStreamReader<TResponse>(httpResponseTask, (string s) =>  (TResponse) _parser.Parse(s, _protoMethod.OutputType) );
    }
}
