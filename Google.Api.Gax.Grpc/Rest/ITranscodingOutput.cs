/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Net.Http;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Information usually extracted from a proto message that may be use to
/// build an HTTP request.
/// </summary>
internal interface ITranscodingOutput
{
    /// <summary>
    /// Creates an HTTP request message that is equivalent to this transcoded information.
    /// </summary>
    HttpRequestMessage ToHttpRequestMessage(string host);
}
