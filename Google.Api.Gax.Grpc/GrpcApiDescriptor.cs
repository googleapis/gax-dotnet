/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Provides metadata about an API. This is expected to be constructed with a single instance
    /// per API; equality is by simple identity.
    /// </summary>
    public sealed partial class GrpcApiDescriptor
    {
        /// <summary>
        /// The protobuf descriptors used by this API.
        /// </summary>
        public IReadOnlyList<FileDescriptor> ProtobufDescriptors { get; }

        /// <summary>
        /// The transports supported by this API.
        /// </summary>
        public GrpcTransports Transports { get; }

        /// <summary>
        /// The name of the API (typically the fully-qualified name of the client library package).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptor"></param>
        /// <param name="transports"></param>
        public GrpcApiDescriptor(string name, IEnumerable<FileDescriptor> descriptor, GrpcTransports transports) =>
            (ProtobufDescriptors, Transports) = (descriptor.ToList().AsReadOnly(), transports);
    }
}
