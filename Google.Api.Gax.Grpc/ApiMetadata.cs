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
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Provides metadata about an API. This is expected to be constructed with a single instance
    /// per API; equality is by simple identity.
    /// </summary>
    public sealed partial class ApiMetadata
    {
        private Lazy<IReadOnlyList<FileDescriptor>> _fileDescriptorsProvider;

        /// <summary>
        /// The protobuf descriptors used by this API.
        /// </summary>
        public IReadOnlyList<FileDescriptor> ProtobufDescriptors => _fileDescriptorsProvider.Value;

        private Lazy<TypeRegistry> _typeRegistryProvider;

        /// <summary>
        /// A type registry containing all the types in <see cref="ProtobufDescriptors"/>.
        /// </summary>
        public TypeRegistry TypeRegistry => _typeRegistryProvider.Value;

        /// <summary>
        /// The name of the API (typically the fully-qualified name of the client library package).
        /// This is never null or empty.
        /// </summary>
        public string Name { get; }

        private ApiMetadata(string name)
        {
            GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name));
            Name = name;
            _typeRegistryProvider = new Lazy<TypeRegistry>(() => TypeRegistry.FromFiles(ProtobufDescriptors));
        }

        /// <summary>
        /// Creates an API descriptor from a sequence of file descriptors.
        /// </summary>
        /// <remarks>
        /// The sequence is evaluated once, on construction.
        /// </remarks>
        /// <param name="name">The name of the API. Must not be null or empty.</param>
        /// <param name="descriptors">The protobuf descriptors of the API. Must not be null.</param>
        public ApiMetadata(string name, IEnumerable<FileDescriptor> descriptors) : this(name)
        {
            var actualDescriptors = descriptors.ToList().AsReadOnly();
            _fileDescriptorsProvider = new Lazy<IReadOnlyList<FileDescriptor>>(() => actualDescriptors);
        }

        /// <summary>
        /// Creates an API descriptor which lazily requests the protobuf descriptors when <see cref="ProtobufDescriptors"/> is first called.
        /// </summary>
        /// <param name="name">The name of the API. Must not be null or empty.</param>
        /// <param name="descriptorsProvider">A provider function for the protobuf descriptors of the API. Must not be null, and must not
        /// return a null value. This will only be called once by this API descriptor, when first requested.</param>
        public ApiMetadata(string name, Func<IEnumerable<FileDescriptor>> descriptorsProvider) : this(name)
        {
            Func<IReadOnlyList<FileDescriptor>> function = () => descriptorsProvider().ToList().AsReadOnly();
            _fileDescriptorsProvider = new Lazy<IReadOnlyList<FileDescriptor>>(function, LazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
}
