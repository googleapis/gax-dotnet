/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Provides metadata about a single service within an API.
    /// Often most of these aspects will be the same across multiple services,
    /// but they can be specified with different values in the original proto, so
    /// they are specified individually here. This class is expected to be constructed
    /// with a single instance per service; equality is by simple identity.
    /// </summary>
    public sealed class ServiceMetadata
    {
        internal const string DefaultUniverseDomain = "googleapis.com";

        /// <summary>
        /// The protobuf service descriptor for this service. This is never null.
        /// </summary>
        public ServiceDescriptor ServiceDescriptor { get; }

        /// <summary>
        /// The name of the service within the API, e.g. "Subscriber". This is never null or empty.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The default endpoint for the service. This may be null, if a service has no default endpoint.
        /// </summary>
        public string DefaultEndpoint { get; }

        /// <summary>
        /// The default scopes for the service. This will never be null, but may be empty.
        /// This will never contain any null references.
        /// This will never change after construction.
        /// </summary>
        public IReadOnlyList<string> DefaultScopes { get; }

        /// <summary>
        /// Whether this service supports scoped JWT access (in which case
        /// this is preferred by default over OAuth tokens).
        /// </summary>
        public bool SupportsScopedJwts { get; }

        /// <summary>
        /// The metadata for the API this is part of. This is never null.
        /// </summary>
        public ApiMetadata ApiMetadata { get; }

        /// <summary>
        /// The transports supported by this service.
        /// </summary>
        public ApiTransports Transports { get; }

        /// <summary>
        /// Constructs a new instance for a given service.
        /// </summary>
        /// <param name="serviceDescriptor">The protobuf descriptor for the service.</param>
        /// <param name="defaultEndpoint">The default endpoint to connect to.</param>
        /// <param name="defaultScopes">The default scopes for the service. Must not be null, and must not contain any null elements. May be empty.</param>
        /// <param name="supportsScopedJwts">Whether the service supports scoped JWTs as credentials.</param>
        /// <param name="transports">The transports supported by this service.</param>
        /// <param name="apiMetadata">The metadata for this API, including all of the services expected to be available at the same endpoint, and all associated protos.</param>
        public ServiceMetadata(ServiceDescriptor serviceDescriptor, string defaultEndpoint, IEnumerable<string> defaultScopes, bool supportsScopedJwts, ApiTransports transports, ApiMetadata apiMetadata)
        {
            ServiceDescriptor = GaxPreconditions.CheckNotNull(serviceDescriptor, nameof(serviceDescriptor));
            Name = serviceDescriptor.Name;
            GaxPreconditions.CheckArgument(Name.Length > 0, nameof(serviceDescriptor), "Service has an empty name");
            DefaultEndpoint = defaultEndpoint;
            DefaultScopes = GaxPreconditions.CheckNotNull(defaultScopes, nameof(defaultScopes)).ToList().AsReadOnly();
            GaxPreconditions.CheckArgument(!DefaultScopes.Any(x => x == null), nameof(defaultScopes), "Scopes must not contain any null references");
            SupportsScopedJwts = supportsScopedJwts;
            Transports = transports;
            ApiMetadata = GaxPreconditions.CheckNotNull(apiMetadata, nameof(apiMetadata));
        }
    }
}
