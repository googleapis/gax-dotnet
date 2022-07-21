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

    internal string RelativeUri { get; }
    internal string Body { get; }
    internal HttpMethod Method { get; }

    internal TranscodingOutput(HttpMethod method, string uriPath, IEnumerable<KeyValuePair<string, string>> queryStringParameters, string body) =>
        (Method, RelativeUri, Body) =
        (method, AppendQueryStringParameters(uriPath, queryStringParameters), body);

    internal HttpRequestMessage CreateRequest(string host)
    {
        var uri = host is null ? new Uri(RelativeUri, UriKind.Relative) : new UriBuilder { Host = host, Path = RelativeUri }.Uri;

        var content = Body is null ? null : new StringContent(Body, Encoding.UTF8, ApplicationJsonMediaType);

        return new HttpRequestMessage
        {
            RequestUri = uri,
            Method = Method,
            Content = content,
        };
    }

    /// <summary>
    /// Merges the uri path and the query string parameters, escaping them.
    /// Ignores the possibility that the path can already have parameters or contain an anchor (`#`)
    /// </summary>
    /// <param name="uriPath">The path component of the service URI</param>
    /// <param name="queryStringParameters">The parameters to encode in the query string</param>
    /// <returns>An uri path merged with the encoded query string parameters</returns>
    private static string AppendQueryStringParameters(string uriPath, IEnumerable<KeyValuePair<string, string>> queryStringParameters)
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
}
