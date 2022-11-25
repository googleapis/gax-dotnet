/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Reflection;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// Represents a set of methods all expected to be accessible via the same host.
    /// (The host itself is not part of the state of this class.)
    /// TODO: Do we need this class, or could we keep the dictionary directly in RestChannel?
    /// </summary>
    internal sealed class RestServiceCollection
    {
        // Note: this dictionary can contain null values, indicating that the method exists but
        // is not supported by REGAPIC.
        private readonly IReadOnlyDictionary<string, RestMethod> _methodsByFullName;

        /// <summary>
        /// Returns the <see cref="RestMethod"/> corresponding to <paramref name="method"/>.
        /// </summary>
        /// <exception cref="RpcException">The method is not supported by REGAPIC, or is not in the service at all.</exception>
        internal RestMethod GetRestMethod(IMethod method) =>
            _methodsByFullName.TryGetValue(method.FullName, out var restMethod)
            ? restMethod ?? throw new RpcException(new Status(StatusCode.Unimplemented, "This RPC is not supported by the REST transport"))
            : throw new RpcException(new Status(StatusCode.InvalidArgument, "Unknown method"));

        private RestServiceCollection(IReadOnlyDictionary<string, RestMethod> methodsByFullName)
        {
            _methodsByFullName = methodsByFullName;
        }

        internal static RestServiceCollection Create(ApiMetadata metadata)
        {
            var fileDescriptors = metadata.ProtobufDescriptors;
            var services = fileDescriptors.SelectMany(file => file.Services);
            var typeRegistry = TypeRegistry.FromFiles(fileDescriptors.ToArray());
            var parser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true).WithTypeRegistry(typeRegistry));
            var methodsByName = services.SelectMany(service => service.Methods)
                .ToDictionary(
                    method => method.FullName,
                    method => RestMethod.Create(metadata, method, parser),
                    StringComparer.Ordinal);
            return new RestServiceCollection(new ReadOnlyDictionary<string, RestMethod>(methodsByName));
        }
    }
}
