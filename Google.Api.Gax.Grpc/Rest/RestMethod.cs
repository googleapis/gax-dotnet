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
    private readonly ITranscoder _transcoder;

    /// <summary>
    /// The service-qualified method name, as used by gRPC, e.g. "/google.somepackage.SomeService/SomeMethod"
    /// </summary>
    internal string FullName { get; }

    private RestMethod(MethodDescriptor protoMethod, JsonParser parser, string fullName, HttpRuleTranscoder transcoder) =>
        (_protoMethod,  _parser, FullName, _transcoder) =
        (protoMethod, parser, fullName, transcoder);

    /// <summary>
    /// Returns the name by which gRPC will refer to the given proto method,
    /// e.g. "/google.somepackage.SomeService/SomeMethod".
    /// </summary>
    private static string GetGrpcFullName(MethodDescriptor method) => $"/{method.Service.FullName}/{method.Name}";

    /// <summary>
    /// Creates <see cref="RestMethod"/> representations from the given protobuf method representation.
    /// </summary>
    /// <param name="apiMetadata">The metadata for the API that this method is part of.</param>
    /// <param name="method">The protobuf method to represent.</param>
    /// <param name="parser">The JSON parser to use when parsing requests.</param>
    /// <returns>
    /// A sequence of representations of the method that can be used to handle HTTP requests/responses.
    /// A representation may be null if the method is currently not supported in REGAPIC.
    /// </returns>
    /// <remarks>
    /// Most protobuf methods will have a single representation. But in some cases, like for
    /// resumable upload, a single protobuf method will have several representations, e.g.
    /// one for "start", one for "upload", one for "query", etc.
    /// </remarks>
    internal static IEnumerable<KeyValuePair<string,RestMethod>> Create(ApiMetadata apiMetadata, MethodDescriptor method, JsonParser parser)
    {
        string methodGrpcName = GetGrpcFullName(method);
        // We don't support client streaming (and bidi) methods with REST.
        if (method.IsClientStreaming)
        {
            yield return new KeyValuePair<string, RestMethod>(methodGrpcName, null);
            yield break;
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
            yield return new KeyValuePair<string, RestMethod>(methodGrpcName, null);
            yield break;
        }
        var transcoder = new HttpRuleTranscoder(method.FullName, method.InputType, rule, apiMetadata);
        yield return new KeyValuePair<string, RestMethod>(methodGrpcName, new RestMethod(method, parser, methodGrpcName, transcoder));
    }

    internal HttpRequestMessage CreateRequest(IMessage request, string host)
    {
        var transcodingOutput = _transcoder.Transcode(request)
            ?? throw new RpcException(new Status(StatusCode.InvalidArgument,
                "Request could not be transcoded; it does not match any HTTP rule. Please check that all required fields are set with appropriate values."));
        return transcodingOutput.ToHttpRequestMessage(host);
    }

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

        string jsonToParse = httpResponse.Content;

        // See b/436913122#comment13. Returns the default value on an empty response
        // instead of converting to an empty JSON element string ("{}") to prevent JSON parsing issues.
        return string.IsNullOrEmpty(jsonToParse) ? default : ParseJson<TResponse>(jsonToParse);
    }

    /// <summary>
    /// Parses a single JSON object as a <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">The response type to parse; this is expected to match the method output type.</typeparam>
    internal TResponse ParseJson<TResponse>(string json) =>
        (TResponse) _parser.Parse(json, _protoMethod.OutputType);

    // TODO: Hardcoded method names will be replaced by inspecting a value on the HttpRule
    // once service configs and proto annotations are available.
    internal static bool IsResumableUploadMethod(string methodFullName, ApiMetadata apiMetadata, out string resumableUploadPrefix)
    {
        resumableUploadPrefix = null;
        // TODO: This should examine the HttpRule associated to the method once that's possible.
        bool isResumableUpload = s_resumableUploadAllowlist.Contains(methodFullName);
        if (isResumableUpload)
        {
            resumableUploadPrefix = apiMetadata.ResumableUploadPrefix;
        }
        // Note that it's possible to return true here, but there might be no prefix.
        // That's fine, we need to skip a method that's marked as resumable upload in the annotation
        // but where there are no resumable upload settings on the service configuration.
        return isResumableUpload;
    }

    private static readonly HashSet<string> s_resumableUploadAllowlist = new HashSet<string>(StringComparer.Ordinal)
    {
        "google.showcase.v1beta1.ResumableUploadService.UploadMedia",
        "google.ads.googleads.v23.services.YouTubeVideoUploadService.CreateYouTubeVideoUpload",
        "google.ads.googleads.v24.services.YouTubeVideoUploadService.CreateYouTubeVideoUpload",
        "google.ads.googleads.v25.services.YouTubeVideoUploadService.CreateYouTubeVideoUpload",
    };
}
