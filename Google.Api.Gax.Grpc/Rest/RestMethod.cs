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
using System.IO;
using System.Net.Http;
using System.Threading;
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
        (apiMetadata, protoMethod, parser, GetGrpcFullName(protoMethod), transcoder);

    /// <summary>
    /// Returns the name by which gRPC will refer to the given proto method,
    /// e.g. "/google.somepackage.SomeService/SomeMethod".
    /// </summary>
    internal static string GetGrpcFullName(MethodDescriptor method) => $"/{method.Service.FullName}/{method.Name}";

    /// <summary>
    /// Creates a <see cref="RestMethod"/> representation from the given protobuf method representation.
    /// </summary>
    /// <param name="apiMetadata">The metadata for the API that this method is part of.</param>
    /// <param name="method">The protobuf method to represent.</param>
    /// <param name="parser">The JSON parser to use when parsing requests.</param>
    /// <returns>A representation of the method that can be used to handle HTTP requests/responses,
    /// or null if the method is currently not supported in REGAPIC.</returns>
    internal static RestMethod Create(ApiMetadata apiMetadata, MethodDescriptor method, JsonParser parser)
    {
        // We don't support client streaming (and bidi) methods with REST.
        if (method.IsClientStreaming)
        {
            return null;
        }
        var rule = method.GetOptions()?.GetExtension(AnnotationsExtensions.Http);
        // If we have an override, it completely replaces the original rule,
        // and can even provide a rule when none was previously present.
        if (apiMetadata.HttpRuleOverrides.TryGetValue(method.FullName, out var overrideByteString))
        {
            rule = HttpRule.Parser.ParseFrom(overrideByteString);
        }
        // If we still haven't got a rule, this method isn't supported in REGAPIC.
        if (rule is null)
        {
            return null;
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

    // Note: this doesn't just return IAsyncStreamReader<TResponse> as we need know it implements IDisposable too.
    internal PartialDecodingStreamReader<TResponse> ResponseStreamAsync<TResponse>(Task<HttpResponseMessage> httpResponseTask, RpcCancellationContext cancellationContext)
    {
        var textReaderTask = GetTextReader(httpResponseTask);
        Func<string, TResponse> responseConverter = json =>  (TResponse) _parser.Parse(json, _protoMethod.OutputType);

        return new PartialDecodingStreamReader<TResponse>(textReaderTask, responseConverter, cancellationContext);
    }

    private static async Task<TextReader> GetTextReader(Task<HttpResponseMessage> httpResponseTask)
    {
        var httpResponse = await httpResponseTask.ConfigureAwait(false);
        httpResponse.EnsureSuccessStatusCode();
        var stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return new StreamReader(stream);
    }
}
