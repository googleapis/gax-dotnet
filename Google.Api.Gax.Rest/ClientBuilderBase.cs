/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// Base class for API-specific builders.
    /// </summary>
    /// <typeparam name="TClient">The type of client created by this builder.</typeparam>
    public abstract class ClientBuilderBase<TClient>
    {
        /// <summary>
        /// The path to the credentials file to use, or null if credentials are being provided in a different way.
        /// </summary>
        public string CredentialsPath { get; set; }

        /// <summary>
        /// The credentials to use as a JSON string, or null if credentials are being provided in a different way.
        /// </summary>
        public string JsonCredentials { get; set; }

        /// <summary>
        /// A custom application name to use for this client, or null to use the default application name.
        /// </summary>
        public string ApplicationName { get; set; }
        
        /// <summary>
        /// A custom base URI for the service, or null to use the default URI.
        /// </summary>
        public string BaseUri { get; set; }

        /// <summary>
        /// The credential to use for authentication. This cannot be specified alongside other authentication properties.
        /// </summary>
        public ICredential Credential { get; set; }

        /// <summary>
        /// An API key to use instead of a regular credential. If this is non-null and no other credentials are supplied,
        /// it will be used as the only credentials. If other credentials are supplied (such as through <see cref="CredentialsPath"/>)
        /// then the two values will both be used together.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Creates a new instance with no settings.
        /// </summary>
        protected ClientBuilderBase()
        {
        }

        /// <summary>
        /// Validates that the builder is in a consistent state for building. For example, it's invalid to call
        /// <see cref="Build"/> on an instance which has both JSON credentials and a credentials path specified.
        /// </summary>
        /// <exception cref="InvalidOperationException">The builder is in an invalid state.</exception>
        protected virtual void Validate()
        {
            ValidateAtMostOneNotNull("Only one source of credentials can be specified",
                CredentialsPath, JsonCredentials, Credential);
        }

        /// <summary>
        /// Validates that at most one of the given values is not null.
        /// </summary>
        /// <param name="message">The message if the condition is violated.</param>
        /// <param name="values">The values to check for nullity.</param>
        /// <exception cref="InvalidOperationException">More than one value is null.</exception>
        protected void ValidateAtMostOneNotNull(string message, params object[] values)
        {
            int notNull = values.Count(v => v != null);
            GaxPreconditions.CheckState(notNull < 2, message);
        }

        /// <summary>
        /// Creates an initializer for the service. This method does not perform any validation.
        /// </summary>
        /// <returns>An initializer for the service.</returns>
        protected virtual BaseClientService.Initializer CreateServiceInitializer() =>
            new BaseClientService.Initializer
            {
                HttpClientInitializer = GetHttpClientInitializer(),
                ApiKey = ApiKey,
                ApplicationName = ApplicationName ?? GetDefaultApplicationName(),
                BaseUri = BaseUri
            };

        /// <summary>
        /// Creates an initializer for the service asynchronously. This method does not perform any validation.
        /// </summary>
        /// <returns>An initializer for the service.</returns>
        protected virtual async Task<BaseClientService.Initializer> CreateServiceInitializerAsync(CancellationToken cancellationToken) =>
            new BaseClientService.Initializer
            {
                HttpClientInitializer = await GetHttpClientInitializerAsync(cancellationToken).ConfigureAwait(false),
                ApiKey = ApiKey,
                ApplicationName = ApplicationName ?? GetDefaultApplicationName(),
                BaseUri = BaseUri
            };

        /// <summary>
        /// Obtains credentials synchronously. Override this method in a concrete builder type if more
        /// credential mechanisms are supported.
        /// </summary>
        protected virtual IConfigurableHttpClientInitializer GetHttpClientInitializer()
        {
            if (Credential != null)
            {
                return Credential;
            }
            GoogleCredential unscoped =
                CredentialsPath != null ? GoogleCredential.FromFile(CredentialsPath) :
                JsonCredentials != null ? GoogleCredential.FromJson(JsonCredentials) :
                null; // Use default credentials (maybe - see below)
            // While we accept any credentials that are specified even if there's an API key,
            // we don't try to load default credentials.
            if (ApiKey != null && unscoped is null)
            {
                return null;
            }
            return GetScopedCredentialProvider().GetCredentials(unscoped);
        }

        /// <summary>
        /// Obtains credentials asynchronously. Override this method in a concrete builder type if more
        /// credential mechanisms are supported.
        /// </summary>
        protected async virtual Task<IConfigurableHttpClientInitializer> GetHttpClientInitializerAsync(CancellationToken cancellationToken)
        {
            if (Credential != null)
            {
                return Credential;
            }
            GoogleCredential unscoped =
                CredentialsPath != null ? GoogleCredential.FromFile(CredentialsPath) : // TODO: Use an async method when one is available
                JsonCredentials != null ? GoogleCredential.FromJson(JsonCredentials) :
                null; // Use default credentials (maybe - see below)
            // While we accept any credentials that are specified even if there's an API key,
            // we don't try to load default credentials.
            if (ApiKey != null && unscoped is null)
            {
                return null;
            }
            return await GetScopedCredentialProvider().GetCredentialsAsync(unscoped).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the scoped credential provider for this builder.
        /// </summary>
        protected abstract ScopedCredentialProvider GetScopedCredentialProvider();

        /// <summary>
        /// Returns the default application name, used if no custom name is otherwise specified.
        /// </summary>
        protected abstract string GetDefaultApplicationName();

        // Note: The implementation is responsible for performing validation before constructing the client.
        // The Validate method can be used as-is for most builders.

        /// <summary>
        /// Builds the resulting client.
        /// </summary>
        public abstract TClient Build();

        /// <summary>
        /// Builds the resulting client asynchronously.
        /// </summary>
        public abstract Task<TClient> BuildAsync(CancellationToken cancellationToken = default);
    }
}