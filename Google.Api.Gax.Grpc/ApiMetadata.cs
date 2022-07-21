/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Rest;
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

        /// <summary>
        /// When true, <see cref="RestGrpcAdapter"/> will request that enums are encoded as numbers in JSON
        /// rather than as strings, preserving unknown values.
        /// </summary>
        public bool RequestNumericEnumJsonEncoding { get; }

        private ApiMetadata(string name, Lazy<IReadOnlyList<FileDescriptor>> fileDescriptorsProvider, bool requestNumericEnumJsonEncoding)
        {
            Name = GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name));
            RequestNumericEnumJsonEncoding = requestNumericEnumJsonEncoding;
            _fileDescriptorsProvider = fileDescriptorsProvider;
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
        public ApiMetadata(string name, IEnumerable<FileDescriptor> descriptors) : this(name, BuildDescriptorsProviderFromDescriptors(descriptors), false)
        {
        }

        /// <summary>
        /// Method used in the above constructor to create the lazy provider.
        /// (Unfortunately this can't be a local method.)
        /// </summary>
        private static Lazy<IReadOnlyList<FileDescriptor>> BuildDescriptorsProviderFromDescriptors(IEnumerable<FileDescriptor> descriptors)
        {
            var actualDescriptors = descriptors.ToList().AsReadOnly();
            return new Lazy<IReadOnlyList<FileDescriptor>>(() => actualDescriptors);
        }
        
        /// <summary>
        /// Creates an API descriptor which lazily requests the protobuf descriptors when <see cref="ProtobufDescriptors"/> is first called.
        /// </summary>
        /// <param name="name">The name of the API. Must not be null or empty.</param>
        /// <param name="descriptorsProvider">A provider function for the protobuf descriptors of the API. Must not be null, and must not
        /// return a null value. This will only be called once by this API descriptor, when first requested.</param>
        public ApiMetadata(string name, Func<IEnumerable<FileDescriptor>> descriptorsProvider) : this(name, BuildDescriptorsProviderFromOtherProvider(descriptorsProvider), false)
        {
        }

        /// <summary>
        /// Method used in the above constructor to create the lazy provider.
        /// (Unfortunately this can't be a local method.)
        /// </summary>
        private static Lazy<IReadOnlyList<FileDescriptor>> BuildDescriptorsProviderFromOtherProvider(Func<IEnumerable<FileDescriptor>> descriptorsProvider)
        {
            Func<IReadOnlyList<FileDescriptor>> function = () => descriptorsProvider().ToList().AsReadOnly();
            return new Lazy<IReadOnlyList<FileDescriptor>>(function, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        /// Returns a new instance based on this one, but with the specified value for <see cref="RequestNumericEnumJsonEncoding"/>.
        /// </summary>
        /// <param name="value">The desired value of <see cref="RequestNumericEnumJsonEncoding"/> in the new instance.</param>
        /// <returns>The new instance.</returns>
        public ApiMetadata WithRequestNumericEnumJsonEncoding(bool value) =>
            new ApiMetadata(Name, _fileDescriptorsProvider, value);
    }
}
