/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Grpc.Core;
using System.Collections.Concurrent;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// Implementation of <see cref="GrpcAdapter"/> that uses HTTP/1.1 and JSON,
    /// but via a gRPC <see cref="CallInvoker"/>.
    /// </summary>
    public sealed class RestGrpcAdapter : GrpcAdapter
    {
        // TODO: Is it okay for this to be static? Probably...
        private static readonly ConcurrentDictionary<ApiMetadata, RestServiceCollection> s_apiMetadataToServiceCollection = new();

        /// <summary>
        /// 
        /// </summary>
        public static RestGrpcAdapter Default { get; } = new RestGrpcAdapter();

        // TODO: Other configuration? Logging?

        private RestGrpcAdapter() : base(GrpcTransports.Rest)
        {
        }

        /// <inheritdoc />
        private protected override ChannelBase CreateChannelImpl(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            var serviceCollection = s_apiMetadataToServiceCollection.GetOrAdd(serviceMetadata.ApiMetadata, apiMetadata => RestServiceCollection.Create(apiMetadata.ProtobufDescriptors));
            return new RestChannel(serviceCollection, endpoint, credentials, options);
        }

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
