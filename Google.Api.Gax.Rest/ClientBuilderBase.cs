/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
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
        /// The resulting credential is automatically scoped with the default scopes for the API.
        /// </summary>
        /// <remarks>
        /// Important: If you accept a credential configuration (credential JSON/File/Stream) from an external source
        /// for authentication to Google Cloud, you must validate it before providing it to any Google API or library.
        /// Providing an unvalidated credential configuration to Google APIs can compromise the security of your
        /// systems and data. For more information, refer to
        /// <see href="https://cloud.google.com/docs/authentication/external/externally-sourced-credentials">Validate credential configurations from external sources</see>.
        /// </remarks>
        public string CredentialsPath { get; set; }

        /// <summary>
        /// The credentials to use as a JSON string, or null if credentials are being provided in a different way.
        /// The resulting credential is automatically scoped with the default scopes for the API.
        /// </summary>
        /// <remarks>
        /// Important: If you accept a credential configuration (credential JSON/File/Stream) from an external source
        /// for authentication to Google Cloud, you must validate it before providing it to any Google API or library.
        /// Providing an unvalidated credential configuration to Google APIs can compromise the security of your
        /// systems and data. For more information, refer to
        /// <see href="https://cloud.google.com/docs/authentication/external/externally-sourced-credentials">Validate credential configurations from external sources</see>.
        /// </remarks>
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
        /// The universe domain to connect to, or null to use the default universe domain.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <see cref="UniverseDomain"/> is used to build the base URI to connect to, unless <see cref="BaseUri"/>
        /// is set, in which case <see cref="BaseUri"/> will be used without further modification.
        /// </para>
        /// <para>
        /// If default credentials or one of <see cref="GoogleCredential"/>, <see cref="CredentialsPath"/> or <see cref="JsonCredentials"/>
        /// is used, <see cref="GoogleCredential.GetUniverseDomain"/> should be:
        /// <list type="bullet">
        /// <item>The same as <see cref="UniverseDomain"/> if <see cref="UniverseDomain"/> has been set.</item>
        /// <item>The default universe domain otherwise.</item>
        /// </list>
        /// </para>
        /// </remarks>
        public string UniverseDomain { get; set; }

        /// <summary>
        /// The credential to use for authentication. This cannot be specified alongside other authentication properties.
        /// Note that scopes are not automatically applied to this credential; if a scoped credential is required, the
        /// scoping must be applied by the calling code.
        /// </summary>
        public ICredential Credential { get; set; }

        /// <summary>
        /// The credentials to use as a <see cref="GoogleCredential"/>, or null if credentials are being provided in
        /// a different way. Note that unlike <see cref="Credential"/>, settings for <see cref="QuotaProject"/>, and scopes
        /// will be applied to this credential (creating a new one), in the same way as for
        /// application default credentials and credentials specified using
        /// <see cref="CredentialsPath"/> or <see cref="JsonCredentials"/>.
        /// </summary>
        public GoogleCredential GoogleCredential { get; set; }

        /// <summary>
        /// An API key to use instead of a regular credential. If this is non-null and no other credentials are supplied,
        /// it will be used as the only credentials. If other credentials are supplied (such as through <see cref="CredentialsPath"/>)
        /// then the two values will both be used together.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The GCP project ID that should be used for quota and billing purposes.
        /// May be null.
        /// </summary>
        public string QuotaProject { get; set; }

        /// <summary>
        /// An <see cref="IHttpClientFactory"/> that will be used to obtain
        /// <see cref="ConfigurableHttpClient"/> for making API Http calls.
        /// May be null, in which case an <see cref="Apis.Http.HttpClientFactory"/>
        /// will be used.
        /// </summary>
        /// <remarks>
        /// If you want to use custom HTTP clients, for instance, if you need to set a proxy,
        /// you may do so by either
        /// <list type="bullet">
        /// <item>
        /// Extending <see cref="Apis.Http.HttpClientFactory"/>. Refer to
        /// <see cref="Apis.Http.HttpClientFactory" /> documentation for more information.
        /// </item>
        /// <item>
        /// On .NET Core 2.1 and above, using <see cref="HttpClientFromMessageHandlerFactory"/>
        /// in combination with <code>System.Net.Http.IHttpClientFactory</code>. Refer to
        /// <see cref="HttpClientFromMessageHandlerFactory"/> documentation and
        /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        /// for more information.
        /// </item>
        /// </list>
        /// </remarks>
        public IHttpClientFactory HttpClientFactory { get; set; }

        /// <summary>
        /// Returns whether or not self-signed JWTs will be used over OAuth tokens when OAuth scopes are explicitly set.        
        /// </summary>
        /// <remarks>
        /// In the base implementation, this defaults to <c>false</c> for maximum compatibility.
        /// Subclasses which provide clients for services which support self-signed JWTs with scopes
        /// may change this property value on construction, effectively changing the default to <c>true</c>
        /// from the perspective of user code.
        /// </remarks>
        public bool UseJwtAccessWithScopes { get; set; } = false;

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
                CredentialsPath, JsonCredentials, Credential, GoogleCredential);

            ValidateAtMostOneNotNull($"If an already-built credential is specified via {nameof(Credential)}, {nameof(QuotaProject)} must be null.",
                Credential, QuotaProject);
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
            CreateServiceInitializerImpl(GetHttpClientInitializer());

        /// <summary>
        /// Creates an initializer for the service asynchronously. This method does not perform any validation.
        /// </summary>
        /// <returns>An initializer for the service.</returns>
        protected virtual async Task<BaseClientService.Initializer> CreateServiceInitializerAsync(CancellationToken cancellationToken) =>
            CreateServiceInitializerImpl(await GetHttpClientInitializerAsync(cancellationToken).ConfigureAwait(false));

        private BaseClientService.Initializer CreateServiceInitializerImpl(IConfigurableHttpClientInitializer clientInitializer)
        {
            var initializer = new BaseClientService.Initializer
            {
                HttpClientInitializer = clientInitializer,
                ApiKey = ApiKey,
                ApplicationName = ApplicationName ?? GetDefaultApplicationName(),
                BaseUri = BaseUri,
                UniverseDomain = UniverseDomain,
                HttpClientFactory = HttpClientFactory
            };
            initializer.VersionHeaderBuilder
                .AppendAssemblyVersion("gccl", GetType())
                .AppendAssemblyVersion("gax", typeof(ClientBuilderBase<TClient>));

            return initializer;
        }

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
                GoogleCredential != null ? GoogleCredential :
#pragma warning disable CS0618 // Type or member is obsolete
                CredentialsPath != null ? GoogleCredential.FromFile(CredentialsPath) :
                JsonCredentials != null ? GoogleCredential.FromJson(JsonCredentials) :
#pragma warning restore CS0618 // Type or member is obsolete
                null; // Use default credentials (maybe - see below)

            // While we accept any credentials that are specified even if there's an API key,
            // we don't try to load default credentials.
            if (ApiKey != null && unscoped is null)
            {
                return QuotaProject is null ? null :
                    new ExtraHeadersInitializer(
                        new AccessTokenWithHeaders.Builder { QuotaProject = QuotaProject }.Build(null));
            }
            GoogleCredential scoped = GetScopedCredentialProvider().GetCredentials(unscoped);
            if (scoped.UnderlyingCredential is ServiceAccountCredential serviceCredential
                && serviceCredential.UseJwtAccessWithScopes != UseJwtAccessWithScopes)
            {
                scoped = GoogleCredential.FromServiceAccountCredential(serviceCredential.WithUseJwtAccessWithScopes(UseJwtAccessWithScopes));
            }
            return QuotaProject is null ? scoped : scoped.CreateWithQuotaProject(QuotaProject);
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
                GoogleCredential != null ? GoogleCredential :
#pragma warning disable CS0618 // Type or member is obsolete
                CredentialsPath != null ? await GoogleCredential.FromFileAsync(CredentialsPath, cancellationToken).ConfigureAwait(false) :
                JsonCredentials != null ? GoogleCredential.FromJson(JsonCredentials) :
#pragma warning restore CS0618 // Type or member is obsolete
                null; // Use default credentials (maybe - see below)

            // While we accept any credentials that are specified even if there's an API key,
            // we don't try to load default credentials.
            if (ApiKey != null && unscoped is null)
            {
                return QuotaProject is null ? null :
                    new ExtraHeadersInitializer( 
                        new AccessTokenWithHeaders.Builder {  QuotaProject = QuotaProject }.Build(null));
            }
            GoogleCredential scoped = await GetScopedCredentialProvider().GetCredentialsAsync(unscoped, cancellationToken).ConfigureAwait(false);
            if (scoped.UnderlyingCredential is ServiceAccountCredential serviceCredential
                && serviceCredential.UseJwtAccessWithScopes != UseJwtAccessWithScopes)
            {
                scoped = GoogleCredential.FromServiceAccountCredential(serviceCredential.WithUseJwtAccessWithScopes(UseJwtAccessWithScopes));
            }
            return QuotaProject is null ? scoped : scoped.CreateWithQuotaProject(QuotaProject);
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

        /// <summary>
        /// Populates properties based on those set via dependency injection.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Credentials are only requested from dependency injection if they are not already set
        /// via any of <see cref="CredentialsPath"/>,
        /// <see cref="JsonCredentials"/>, <see cref="Credential"/> or <see cref="GoogleCredential"/>.
        /// </para>
        /// <para>
        /// If credentials are requested, they are tried in the following order:
        /// </para>
        /// <list type="bullet">
        /// <item>ICredential</item>
        /// <item>GoogleCredential</item>
        /// </list>
        /// </remarks>
        /// <param name="provider">The service provider to request dependencies from.</param>
        protected virtual void Configure(IServiceProvider provider)
        {
            GaxPreconditions.CheckNotNull(provider, nameof(provider));

            HttpClientFactory ??= provider.GetService<IHttpClientFactory>();

            if (CredentialsPath is null && JsonCredentials is null && GoogleCredential is null && Credential is null)
            {
                if (provider.GetService<ICredential>() is ICredential credential)
                {
                    Credential = credential;
                }
                else if (provider.GetService<GoogleCredential>() is GoogleCredential googleCredential)
                {
                    GoogleCredential = googleCredential;
                }
            }
        }

        /// <summary>
        /// Class to be used to set the quota project on request headers when
        /// an ApiKey is being used for authentication instead of a credential.
        /// </summary>
        private class ExtraHeadersInitializer : IConfigurableHttpClientInitializer
        {
            private readonly AccessTokenWithHeaders _headers;

            public ExtraHeadersInitializer(AccessTokenWithHeaders headers) =>
                _headers = GaxPreconditions.CheckNotNull(headers, nameof(headers));

            public void Initialize(ConfigurableHttpClient httpClient) =>
                httpClient.MessageHandler.Credential = new ExtraHeadersInterceptor(_headers);
        }

        private class ExtraHeadersInterceptor : IHttpExecuteInterceptor
        {
            private readonly AccessTokenWithHeaders _headers;

            public ExtraHeadersInterceptor(AccessTokenWithHeaders headers) => _headers = headers;

            public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                _headers.AddHeaders(request);
                return Task.FromResult(true);
            }
        }
    }
}
