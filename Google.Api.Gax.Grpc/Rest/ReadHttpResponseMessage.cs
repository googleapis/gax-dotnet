/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private static readonly JsonParser s_responseMetadataParser = new JsonParser(
            JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
        private static readonly JsonParser s_anyParser = new JsonParser(
            JsonParser.Settings.Default
                .WithIgnoreUnknownFields(true).
                WithTypeRegistry(TypeRegistry.FromFiles(Rpc.ErrorDetailsReflection.Descriptor)));

        private HttpResponseMessage OriginalResponseMessage { get; }

        private readonly Rpc.Status _rpcStatus;
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
            (OriginalResponseMessage, _content, _rpcStatus) = (response, content, CreateRpcStatus(response.StatusCode, content));

        internal ReadHttpResponseMessage(HttpResponseMessage response, ExceptionDispatchInfo readException) =>
            // If we didn't manage to read the response, we don't have any information to create a fake status code from.
            // We'll bubble up the _readException instead.
            (OriginalResponseMessage, _readException) = (response, readException);

        internal Metadata GetHeaders() => ReadHeaders(OriginalResponseMessage.Headers);

        internal static Metadata ReadHeaders(HttpResponseHeaders headers)
        {
            // TODO: This could be very wrong. I don't know what headers we should really return, and I don't know about semi-colon joining.
            var metadata = new Metadata();
            foreach (var header in headers)
            {
                metadata.Add(header.Key, string.Join(";", header.Value));
            }
            return metadata;
        }

        internal Status GetStatus()
        {
            // Notice that here, if there was an exception reading the content
            // we'll bubble it up. This is similar to what's done if there's an
            // exception while sending the request, and if there's an exception
            // reading the content for TResponse.
            _readException?.Throw();
            return new Status((StatusCode) _rpcStatus.Code, _rpcStatus.Message);
        }

        internal Metadata GetTrailers()
        {
            if (_rpcStatus is null || _rpcStatus.Code == (int) Rpc.Code.Ok)
            {
                return new Metadata();
            }
            return new Metadata { { RpcExceptionExtensions.StatusDetailsTrailerName, _rpcStatus.ToByteArray() } };
        }

        /// <summary>
        /// Create an RPC status from the HTTP status code, attempting to parse the
        /// content as an Rpc.Status if the HTTP status indicates a failure.
        /// </summary>
        internal static Rpc.Status CreateRpcStatus(HttpStatusCode statusCode, string content)
        {
            var grpcStatusCode = RestGrpcAdapter.ConvertHttpStatusCode((int) statusCode);
            if (grpcStatusCode == StatusCode.OK)
            {
                return new Rpc.Status { Code = (int) grpcStatusCode };
            }
            try
            {
                // Error response messages for streaming APIs are embedded within arrays.
                // If we detect that the content looks like a JSON array, extract it and parse
                // expecting a single object.
                if (content.StartsWith("[") && content.EndsWith("]"))
                {
                    content = content.Substring(1, content.Length - 2);
                }

                var errorFromMetadata = s_responseMetadataParser.Parse<Error>(content);
                var error = errorFromMetadata.Error_;
                // If we got a JSON object that can be parsed as an Error, but doesn't include a nested "error" field,
                // that's similar to a parsing failure.
                if (error is null)
                {
                    return new Rpc.Status { Code = (int) grpcStatusCode, Message = content };
                }
                var status = new Rpc.Status
                {
                    // Sometimes the status field in the JSON isn't populated; fall back to the
                    // translation of the HTTP response code. (We could potentially use error.Code,
                    // but that should always be the same as the status code of the HTTP response
                    // anyway, and this way we don't have to do things conditionally on whether error.Code
                    // is populated or not.)
                    Code = error.Status_ == Rpc.Code.Ok ? (int) grpcStatusCode : (int) error.Status_,
                    Message = error.Message,
                    Details = { error.Details.Select(TryParseAny).Where(a => a is not null) }
                };
                return status;
            }
            catch
            {
                // If we can't parse the result as JSON, just use the content as the error message.
                return new Rpc.Status { Code = (int) grpcStatusCode, Message = content };
            }

            // Attempts to parse the given Struct as an Any, returning null on failure.
            Any TryParseAny(Struct json)
            {
                try
                {
                    return s_anyParser.Parse<Any>(json.ToString());
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }
    }
}
