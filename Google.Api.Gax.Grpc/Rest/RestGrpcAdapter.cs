/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
#if REGAPIC
using Google.Protobuf.Reflection;
using Grpc.Core;
using System.Collections.Generic;
using System.Linq;

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
    }
}
#endif