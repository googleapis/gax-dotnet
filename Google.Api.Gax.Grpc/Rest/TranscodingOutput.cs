/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// The result of transcoding a protobuf request using an HttpRule.
/// This is produced by <see cref="HttpRuleTranscoder"/>.
/// </summary>
internal sealed class TranscodingOutput
{
    private const string ApplicationJsonMediaType = "application/json";

    private IEnumerable<KeyValuePair<string, string>> _queryStringParameters;
    private string _uriPath;
    internal string Body { get; }
    internal HttpMethod Method { get; }

    internal TranscodingOutput(HttpMethod method, string uriPath, IEnumerable<KeyValuePair<string, string>> queryStringParameters, string body) =>
        (Method, _uriPath, _queryStringParameters, Body) =
        (method, uriPath, queryStringParameters, body);

    // TODO: Rename to ToHttpRequestMessage?
    internal HttpRequestMessage CreateRequest(string host)
    {
        var relativeUri = GetRelativeUri();
        var uri = host is null ? new Uri(relativeUri, UriKind.Relative) : new UriBuilder { Host = host, Path = relativeUri }.Uri;

        var content = Body is null ? null : new StringContent(Body, Encoding.UTF8, ApplicationJsonMediaType);

        return new HttpRequestMessage
        {
            RequestUri = uri,
            Method = Method,
            Content = content,
        };
    }

    internal TranscodingOutput WithAdditionalQueryParameter(string name, string value) =>
        new TranscodingOutput(Method, _uriPath, _queryStringParameters.Concat(new[] { new KeyValuePair<string, string>(name, value) }), Body);

    /// <summary>
    /// Merges the uri path and the query string parameters, escaping them.
    /// Ignores the possibility that the path can already have parameters or contain an anchor (`#`).
    /// This method is visible for testing; production code should generally call <see cref="CreateRequest(string)"/>
    /// instead.
    /// </summary>
    /// <returns>The URI path merged with the encoded query string parameters</returns>
    internal string GetRelativeUri()
    {
        var sb = new StringBuilder();
        sb.Append(_uriPath);
        bool sbHasParameters = false;

        foreach (var kvpNameValue in _queryStringParameters)
        {
            sb.Append(sbHasParameters ? "&" : "?");
            sbHasParameters = true;
            sb.Append(Uri.EscapeDataString(kvpNameValue.Key));
            sb.Append("=");
            sb.Append(Uri.EscapeDataString(kvpNameValue.Value));
        }

        return sb.ToString();
    }
}
