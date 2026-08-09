/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Facilitates converting a proto message to an HTTP request.
/// </summary>
internal interface ITranscoder
{
    /// <summary>
    /// Extracts relevant information from a proto message, i.e. a request,
    /// that can be used to build an equivalent HTTP request.
    /// </summary>
    ITranscodingOutput Transcode(IMessage request);
}
