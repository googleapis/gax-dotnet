/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Provides metadata about a single service within an API.
    /// Often most of these aspects will be the same across multiple services,
    /// but they can be specified with different values in the original proto, so 
    /// </summary>
    public sealed class ServiceMetadata
    {
        /// <summary>
        /// The name of the service within the API. This is never null or empty.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The default endpoint for the service. This may be null, if a service has no default endpoint.
        /// </summary>
        public string DefaultEndpoint { get; }

        /// <summary>
        /// The default scopes for the service. This will never be null, but may be empty.
        /// </summary>
        public IReadOnlyList<string> DefaultScopes { get; }

        /// <summary>
        /// Whether this service supports scoped JWT access (in which case
        /// this is preferred by default over OAuth tokens).
        /// </summary>
        public bool SupportsScopedJwts { get; }

        /// <summary>
        /// The metadata for the API this is part of.
        /// </summary>
        public ApiMetadata ApiMetadata { get; }

        /// <summary>
        /// The transports supported by this service.
        /// </summary>
        public GrpcTransports Transports { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultEndpoint"></param>
        /// <param name="defaultScopes"></param>
        /// <param name="supportsScopedJwts"></param>
        /// <param name="transports"></param>
        /// <param name="apiMetadata"></param>
        public ServiceMetadata(string name, string defaultEndpoint, IEnumerable<string> defaultScopes, bool supportsScopedJwts, GrpcTransports transports, ApiMetadata apiMetadata)
        {
            Name = GaxPreconditions.CheckNotNullOrEmpty(name, nameof(name));
            DefaultEndpoint = defaultEndpoint;
            DefaultScopes = GaxPreconditions.CheckNotNull(defaultScopes, nameof(defaultScopes)).ToList().AsReadOnly();
            SupportsScopedJwts = supportsScopedJwts;
            Transports = transports;
            ApiMetadata = apiMetadata;
        }
    }
}
