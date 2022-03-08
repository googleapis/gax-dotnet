/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System.Net.Http;
using System.Runtime.ExceptionServices;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// In <see cref="AsyncUnaryCall{TResponse}"/> the functions to obtain the TResponse
    /// and the <see cref="Status"/> of the call are two different functions.
    /// The function to obtain the response is async, but the function to obtain the
    /// <see cref="Status"/> is not.
    /// For being able to surface error details in <see cref="Status"/> we need to be
    /// able to call <see cref="HttpContent.ReadAsStringAsync"/> which is an async method,
    /// and thus cannot be done, without blocking, on the sync function that obtains the 
    /// <see cref="Status"/> in the <see cref="AsyncUnaryCall{TResponse}"/>.
    /// So we need to make async content reading part of sending the call and not part of
    /// building the TResponse.
    /// This class is just a convenient wrapper for passing together the <see cref="HttpResponseMessage"/>
    /// and its read response.
    /// </summary>
    internal class ReadHttpResponseMessage
    {
        private HttpResponseMessage OriginalResponseMessage { get; }

        private readonly string _content;
        private readonly ExceptionDispatchInfo _readException;

        internal string Content
        {
            get
            {
                _readException?.Throw();
                return _content;
            }
        }

        internal ReadHttpResponseMessage(HttpResponseMessage response, string content) =>
            (OriginalResponseMessage, _content) = (response, content);

        internal ReadHttpResponseMessage(HttpResponseMessage response, ExceptionDispatchInfo readException) =>
            (OriginalResponseMessage, _readException) = (response, readException);

        internal Metadata GetHeaders()
        {
            // TODO: This could be very wrong. I don't know what headers we should really return, and I don't know about semi-colon joining.
            var metadata = new Metadata();
            foreach (var header in OriginalResponseMessage.Headers)
            {
                metadata.Add(header.Key, string.Join(";", header.Value));
            }
            return metadata;
        }

        internal Status GetStatus()
        {
            var grpcStatus = RestGrpcAdapter.ConvertHttpStatusCode((int) OriginalResponseMessage.StatusCode);
            return new Status(grpcStatus,
                // Notice that here, if there was an exception reading the content
                // we'll bubble it up. This is similar to what's done if there's an
                // exception while sending the request, and if there's an exception
                // reading the content for TResponse.
                grpcStatus == StatusCode.OK ? "" : Content);
        }

        internal Metadata GetTrailers() => new Metadata(); // We never have any trailers.
    }
}
