/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf.Reflection;
using Grpc.Core;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// Implementation of <see cref="GrpcAdapter"/> that uses HTTP/1.1 and JSON,
    /// but via a gRPC <see cref="CallInvoker"/>.
    /// </summary>
    public sealed class RestGrpcAdapter : GrpcAdapter
    {
        private readonly RestServiceCollection _serviceCollection;

        private RestGrpcAdapter(RestServiceCollection serviceCollection) =>
            _serviceCollection = serviceCollection;

        /// <inheritdoc />
        protected override ChannelBase CreateChannelImpl(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            new RestChannel(_serviceCollection, endpoint, credentials, options);

        /// <summary>
        /// Creates a gRPC adapter using HTTP/1.1 and JSON, based on the services within the
        /// given file descriptors.
        /// </summary>
        /// <param name="fileDescriptors">File descriptors for all protos that may be involved in RPCs for this adapter.
        /// All services within the descriptors are expected to be accessible via the same host.</param>
        /// <returns></returns>
        public static RestGrpcAdapter Create(IEnumerable<FileDescriptor> fileDescriptors) =>
            new RestGrpcAdapter(RestServiceCollection.Create(fileDescriptors));

        /// <summary>
        /// Converts an HTTP status code into the corresponding gRPC status code.
        /// Note that there is not a 1:1 correspondence between status code; multiple
        /// HTTP status codes can map to the same gRPC status code.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code to convert</param>
        /// <returns>The converted gRPC status code.</returns>
        public static StatusCode ConvertHttpStatusCode(int httpStatusCode) =>
            (httpStatusCode / 100) switch
            {
                // All 2xx responses map to OK
                2 => StatusCode.OK,

                // 4xx defaults to FailedPrecondition, with specific exceptions
                4 => httpStatusCode switch
                {
                    400 => StatusCode.InvalidArgument,
                    401 => StatusCode.Unauthenticated,
                    403 => StatusCode.PermissionDenied,
                    404 => StatusCode.NotFound,
                    409 => StatusCode.Aborted,
                    416 => StatusCode.OutOfRange,
                    429 => StatusCode.ResourceExhausted,
                    499 => StatusCode.Cancelled,
                    _ => StatusCode.FailedPrecondition,
                },

                // 5xx defaults to Internal, with specific exceptions
                5 => httpStatusCode switch
                {
                    501 => StatusCode.Unimplemented,
                    503 => StatusCode.Unavailable,
                    504 => StatusCode.DeadlineExceeded,
                    _ => StatusCode.Internal
                },

                // Anything else (including all 1xx and 3xx) maps to Unknown
                _ => StatusCode.Unknown
            };
    }
}
