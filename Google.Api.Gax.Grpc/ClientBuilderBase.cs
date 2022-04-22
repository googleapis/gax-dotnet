/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Base class for API-specific builders.
    /// </summary>
    /// <typeparam name="TClient">The type of client created by this builder.</typeparam>
    public abstract class ClientBuilderBase<TClient>
    {
        /// <summary>
        /// The default gRPC options.
        /// </summary>
        protected static GrpcChannelOptions DefaultOptions { get; } = GrpcChannelOptions.Empty
            .WithKeepAliveTime(TimeSpan.FromMinutes(1))
            .WithEnableServiceConfigResolution(false)
            .WithMaxReceiveMessageSize(int.MaxValue);

        /// <summary>
        /// The metadata associated with the service that this client will make requests to.
        /// </summary>
        protected ServiceMetadata ServiceMetadata { get; }

        /// <summary>
        /// The endpoint to connect to, or null to use the default endpoint.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// The logger to include in the client, if any.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// The scopes to use, or null to use the default scopes.
        /// </summary>
        public IReadOnlyList<string> Scopes { get; set; }

        /// <summary>
        /// The channel credentials to use, or null if credentials are being provided in a different way.
        /// </summary>
        public ChannelCredentials ChannelCredentials { get; set; }

        /// <summary>
        /// The path to the credentials file to use, or null if credentials are being provided in a different way.
        /// </summary>
        public string CredentialsPath { get; set; }

        /// <summary>
        /// The credentials to use as a JSON string, or null if credentials are being provided in a different way.
        /// </summary>
        public string JsonCredentials { get; set; }

        /// <summary>
        /// The credentials to use as a <see cref="GoogleCredential"/>, or null if credentials are being provided in
        /// a different way. Note that unlike <see cref="ChannelCredentials"/> and <see cref="TokenAccessMethod"/>,
        /// settings for <see cref="Scopes"/>, <see cref="QuotaProject"/> and self-signed JWTs will be applied to this
        /// credential (creating a new one), in the same way as for application default credentials and credentials
        /// specified using <see cref="CredentialsPath"/> or <see cref="JsonCredentials"/>.
        /// </summary>
        public GoogleCredential GoogleCredential { get; set; }

        /// <summary>
        /// The credentials to use in "raw" form, for conversion into channel credentials. No other settings
        /// (e.g. <see cref="QuotaProject"/> or <see cref="Scopes"/>) are applied to these credentials.
        /// </summary>
        public ICredential Credential { get; set; }

        /// <summary>
        /// The token access method to use, or null if credentials are being provided in a different way.
        /// </summary>
        [Obsolete("The Credential property is preferred for simplicity. This property may be removed in a future major version.")]
        public Func<string, CancellationToken, Task<string>> TokenAccessMethod { get; set; }

        /// <summary>
        /// The call invoker to use, or null to create the call invoker when the client is built.
        /// </summary>
        public CallInvoker CallInvoker { get; set; }

        /// <summary>
        /// A custom user agent to specify in the channel metadata, or null if no custom user agent is required.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// The gRPC implementation to use, or null to use the default implementation.
        /// </summary>
        public GrpcAdapter GrpcAdapter { get; set; }

        private EmulatorDetection _emulatorDetection = EmulatorDetection.None;
        /// <summary>
        /// The emulator detection policy to apply when building a client. Derived classes which support
        /// emulators should create public properties which delegate to this one. The default value is
        /// <see cref="EmulatorDetection.None"/>.
        /// </summary>
        protected EmulatorDetection EmulatorDetection
        {
            get => _emulatorDetection;
            set => _emulatorDetection = GaxPreconditions.CheckEnumValue(value, nameof(value));
        }

        /// <summary>
        /// The GCP project ID that should be used for quota and billing purposes.
        /// May be null.
        /// </summary>
        public string QuotaProject { get; set; }

        /// <summary>
        /// Any custom channel options to merge with the default options.
        /// If an option specified both here and in the default options, the custom option
        /// will take priority. This property may be null (the default) in which case the default
        /// options are used.
        /// </summary>
        public GrpcChannelOptions GrpcChannelOptions { get; set; }

        // Note: when adding any more properties, CopyCommonSettings must also be updated,
        // and potentially CopySettingsForEmulator.

        /// <summary>
        /// Creates a new instance with no explicit settings.
        /// This takes the value of <see cref="UseJwtAccessWithScopes" /> from <paramref name="serviceMetadata"/>.
        /// </summary>
        /// <param name="serviceMetadata">The metadata for the service that the client will be used with. Must not be null.</param>
        protected ClientBuilderBase(ServiceMetadata serviceMetadata)
        {
            ServiceMetadata = serviceMetadata;
            UseJwtAccessWithScopes = serviceMetadata.SupportsScopedJwts;
        }

        /// <summary>
        /// Copies common settings from the specified builder into this one. This is a shallow copy.
        /// </summary>
        /// <typeparam name="TOther">The other client type</typeparam>
        /// <param name="source">The builder to copy from.</param>
        protected void CopyCommonSettings<TOther>(ClientBuilderBase<TOther> source)
        {
            GaxPreconditions.CheckNotNull(source, nameof(source));
            Endpoint = source.Endpoint;
            Scopes = source.Scopes;
            ChannelCredentials = source.ChannelCredentials;
            CredentialsPath = source.CredentialsPath;
            JsonCredentials = source.JsonCredentials;
            GoogleCredential = source.GoogleCredential;
            Credential = source.Credential;
#pragma warning disable CS0618 // Type or member is obsolete
            TokenAccessMethod = source.TokenAccessMethod;
#pragma warning restore CS0618 // Type or member is obsolete
            CallInvoker = source.CallInvoker;
            UserAgent = source.UserAgent;
            GrpcAdapter = source.GrpcAdapter;
            GrpcChannelOptions = source.GrpcChannelOptions;
            QuotaProject = source.QuotaProject;
            UseJwtAccessWithScopes = source.UseJwtAccessWithScopes;
            Logger = source.Logger;

            // Note that we may be copying from one type that supports emulators (e.g. FirestoreDbBuilder)
            // to another type that doesn't (e.g. FirestoreClientBuilder). That ends up in a slightly odd situation,
            // but the code in the emulator-unaware type won't use the property anyway. If we're ever copying from
            // one type that supports emulators to another, it would make sense to propagate the setting anyway.
            EmulatorDetection = source.EmulatorDetection;
        }

        /// <summary>
        /// Copies common settings from the specified builder, expecting that any settings around
        /// credentials and endpoints will be set by the caller, along with any client-specific settings.
        /// Emulator detection is not copied, to avoid infinite recursion when building.
        /// </summary>
        protected void CopySettingsForEmulator(ClientBuilderBase<TClient> source)
        {
            GaxPreconditions.CheckNotNull(source, nameof(source));
            UserAgent = source.UserAgent;
            GrpcAdapter = source.GrpcAdapter;
            Logger = source.Logger;
        }

        /// <summary>
        /// Validates that the builder is in a consistent state for building. For example, it's invalid to call
        /// <see cref="Build()"/> on an instance which has both JSON credentials and a credentials path specified.
        /// </summary>
        /// <exception cref="InvalidOperationException">The builder is in an invalid state.</exception>
        protected virtual void Validate()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            // If there's a call invoker, we shouldn't have any credentials-related information or an endpoint.
            ValidateOptionExcludesOthers($"{nameof(CallInvoker)} cannot be specified with credentials settings or an endpoint", CallInvoker,
                ChannelCredentials, CredentialsPath, JsonCredentials, Scopes, Endpoint, TokenAccessMethod, GoogleCredential, Credential);

            ValidateAtMostOneNotNull("Only one source of credentials can be specified",
                ChannelCredentials, CredentialsPath, JsonCredentials, TokenAccessMethod, GoogleCredential, Credential);

            ValidateOptionExcludesOthers("Scopes are not relevant when a token access method, channel credentials or ICredential are supplied", Scopes,
                TokenAccessMethod, ChannelCredentials, Credential);
#pragma warning restore CS0618 // Type or member is obsolete

            ValidateOptionExcludesOthers($"{nameof(QuotaProject)} cannot be specified if a {nameof(CallInvoker)}, {nameof(ChannelCredentials)} or {nameof(Credential)} is specified", QuotaProject,
                CallInvoker, ChannelCredentials, Credential);
        }

        /// <summary>
        /// Performs basic emulator detection and validation based on the given environment variables.
        /// This method is expected to be called by a derived class that supports emulators, in order to perform the common
        /// work of checking whether the emulator is configured in the environment.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the emulator should not be used, either due to being disabled in <see cref="EmulatorDetection"/> or
        /// the appropriate environment variables not being set, this method returns null.
        /// </para>
        /// <para>
        /// Otherwise, a dictionary is returned mapping every value in <paramref name="allEmulatorEnvironmentVariables"/> to the value in
        /// the environment. Any missing, empty or whitespace-only values are mapped to a null reference in the returned dictionary, but
        /// the entry will still be present (so callers can use an indexer with the returned dictionary for every environment variable passed in).
        /// </para>
        /// </remarks>
        /// <exception cref="InvalidOperationException">The configuration is inconsistent, e.g. due to some environment variables
        /// being set but not all the required ones, or any environment variables being set in a production-only environment.</exception>
        /// <param name="requiredEmulatorEnvironmentVariables">Required emulator environment variables.</param>
        /// <param name="allEmulatorEnvironmentVariables">All emulator environment variables.</param>
        /// <param name="environmentVariableProvider">The provider used to retrieve environment variables. This is used to faciliate testing, and defaults
        /// to using <see cref="Environment.GetEnvironmentVariable(string)"/>.</param>
        /// <returns>A key/value mapping of the emulator environment variables to their values, or null if the emulator should not be used.</returns>
        protected Dictionary<string, string> GetEmulatorEnvironment(
            IEnumerable<string> requiredEmulatorEnvironmentVariables,
            IEnumerable<string> allEmulatorEnvironmentVariables,
            Func<string, string> environmentVariableProvider = null)
        {
            environmentVariableProvider ??= Environment.GetEnvironmentVariable;
            var environment = allEmulatorEnvironmentVariables.ToDictionary(key => key, key => GetEnvironmentVariableOrNull(key));

            switch (EmulatorDetection)
            {
                case EmulatorDetection.None:
                    return default;
                case EmulatorDetection.ProductionOnly:
                    foreach (var variable in allEmulatorEnvironmentVariables)
                    {
                        GaxPreconditions.CheckState(
                            environment[variable] is null,
                            "Emulator environment variable '{0}' is set, contrary to use of {1}.{2}",
                            variable, nameof(EmulatorDetection), nameof(EmulatorDetection.ProductionOnly));
                    }
                    return default;
                case EmulatorDetection.EmulatorOnly:
                    foreach (var variable in requiredEmulatorEnvironmentVariables)
                    {
                        GaxPreconditions.CheckState(
                            environment[variable] is object,
                            "Emulator environment variable '{0}' is not set, contrary to use of {1}.{2}",
                            variable, nameof(EmulatorDetection), nameof(EmulatorDetection.EmulatorOnly));
                    }
                    // When the settings *only* support the use of an emulator, the other properties shouldn't be set.
                    CheckNotSet(Endpoint, nameof(Endpoint));
                    CheckNotSet(CallInvoker, nameof(CallInvoker));
                    CheckNotSet(ChannelCredentials, nameof(ChannelCredentials));
                    CheckNotSet(CredentialsPath, nameof(CredentialsPath));
                    CheckNotSet(JsonCredentials, nameof(JsonCredentials));
                    CheckNotSet(Scopes, nameof(Scopes));
#pragma warning disable CS0618 // Type or member is obsolete
                    CheckNotSet(TokenAccessMethod, nameof(TokenAccessMethod));
#pragma warning restore CS0618 // Type or member is obsolete
                    CheckNotSet(QuotaProject, nameof(QuotaProject));
                    CheckNotSet(Credential, nameof(Credential));
                    CheckNotSet(GoogleCredential, nameof(GoogleCredential));

                    void CheckNotSet(object obj, string name)
                    {
                        GaxPreconditions.CheckState(obj is null, "{0} is set, contrary to use of {1}.{2}",
                            name, nameof(EmulatorDetection), nameof(EmulatorDetection.EmulatorOnly));
                    }
                    return environment;
                case EmulatorDetection.EmulatorOrProduction:
                    bool anySet = allEmulatorEnvironmentVariables.Any(v => environment[v] is object);
                    if (!anySet)
                    {
                        return default;
                    }
                    bool allRequiredSet = requiredEmulatorEnvironmentVariables.All(v => environment[v] is object);
                    if (!allRequiredSet)
                    {
                        var sampleSet = allEmulatorEnvironmentVariables.First(v => environment[v] is object);
                        var sampleNotSet = requiredEmulatorEnvironmentVariables.First(v => environment[v] is null);
                        GaxPreconditions.CheckState(false,
                            "Emulator environment variable '{0}' is set, but '{1}' is not set.",
                            sampleSet, sampleNotSet);
                    }
                    // We allow other properties such as the endpoint to be set, although we expect them to be ignored
                    // by the calling code. This allows users to write code that has customizations in settings, but still doesn't need
                    // to be changed at all in order to use the emulator.
                    return environment;
                default:
                    throw new InvalidOperationException($"Invalid emulator detection value: {EmulatorDetection}");
            }

            // Retrieves an environment variable from <see cref="EnvrionmentVariableProvider"/>, mapping empty or whitespace-only strings to null.
            string GetEnvironmentVariableOrNull(string variable)
            {
                var value = environmentVariableProvider(variable);
                return string.IsNullOrWhiteSpace(value) ? null : value;
            }
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
        /// Validates that if <paramref name="controlling"/> is not null, then every value in <paramref name="values"/> is null.
        /// </summary>
        /// <param name="message">The message if the condition is violated.</param>
        /// <param name="controlling">The value controlling whether or not any other value can be non-null.</param>
        /// <param name="values">The values checked for non-nullity if <paramref name="controlling"/> is non-null.</param>
        protected void ValidateOptionExcludesOthers(string message, object controlling, params object[] values)
        {
            GaxPreconditions.CheckState(controlling == null || values.All(v => v == null), message);
        }

        /// <summary>
        /// Creates a call invoker synchronously. Override this method in a concrete builder type if more
        /// call invoker mechanisms are supported.
        /// This implementation calls <see cref="GetChannelCredentials"/> if no call invoker is specified.
        /// </summary>
        protected virtual CallInvoker CreateCallInvoker()
        {
            if (CallInvoker != null)
            {
                return CallInvoker;
            }
            var endpoint = Endpoint ?? ServiceMetadata.DefaultEndpoint;
            ChannelBase channel;
            if (CanUseChannelPool)
            {
                channel = GetChannelPool().GetChannel(EffectiveGrpcAdapter, endpoint, GetChannelOptions());
            }
            else
            {
                var credentials = GetChannelCredentials();
                channel = CreateChannel(endpoint, credentials);
            }
            return channel.CreateCallInvoker();
        }

        /// <summary>
        /// Creates a call invoker asynchronously. Override this method in a concrete builder type if more
        /// call invoker mechanisms are supported.
        /// This implementation calls <see cref="GetChannelCredentialsAsync(CancellationToken)"/> if no call
        /// invoker is specified.
        /// </summary>
        protected virtual async Task<CallInvoker> CreateCallInvokerAsync(CancellationToken cancellationToken)
        {
            if (CallInvoker != null)
            {
                return CallInvoker;
            }
            var endpoint = Endpoint ?? ServiceMetadata.DefaultEndpoint;
            ChannelBase channel;
            if (CanUseChannelPool)
            {
                channel = await GetChannelPool()
                    .GetChannelAsync(EffectiveGrpcAdapter, endpoint, GetChannelOptions(), cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                var credentials = await GetChannelCredentialsAsync(cancellationToken).ConfigureAwait(false);
                channel = CreateChannel(endpoint, credentials);
            }
            return channel.CreateCallInvoker();
        }

        /// <summary>
        /// Obtains channel credentials synchronously. Override this method in a concrete builder type if more
        /// credential mechanisms are supported.
        /// </summary>
        protected virtual ChannelCredentials GetChannelCredentials() =>
            MaybeGetSimpleChannelCredentials() ?? GetGoogleCredential().ToChannelCredentials();

        /// <summary>
        /// Obtains channel credentials asynchronously. Override this method in a concrete builder type if more
        /// credential mechanisms are supported.
        /// </summary>
        protected async virtual Task<ChannelCredentials> GetChannelCredentialsAsync(CancellationToken cancellationToken) =>
            MaybeGetSimpleChannelCredentials()
            ?? (await GetGoogleCredentialAsync(cancellationToken).ConfigureAwait(false)).ToChannelCredentials();

        /// <summary>
        /// Obtains channel credentials synchronously if they've been supplied in a ready-to-go fashion.
        /// This avoids code duplication in the sync and async paths.
        /// Returns null if the credentials aren't available.
        /// </summary>
        private ChannelCredentials MaybeGetSimpleChannelCredentials() =>
            ChannelCredentials ?? Credential?.ToChannelCredentials() ??
#pragma warning disable CS0618 // Type or member is obsolete
            (TokenAccessMethod is not null ? new DelegatedTokenAccess(TokenAccessMethod, QuotaProject).ToChannelCredentials() : null);
#pragma warning restore CS0618 // Type or member is obsolete

        // Visible for testing
        internal GoogleCredential GetGoogleCredential()
        {
            GoogleCredential unscoped =
                GoogleCredential != null ? GoogleCredential :
                CredentialsPath != null ? GoogleCredential.FromFile(CredentialsPath) :
                JsonCredentials != null ? GoogleCredential.FromJson(JsonCredentials) :
                GoogleCredential.GetApplicationDefault();
            GoogleCredential scoped = unscoped.CreateScoped(Scopes ?? ServiceMetadata.DefaultScopes);
            GoogleCredential maybeWithProject = QuotaProject is null ? scoped : scoped.CreateWithQuotaProject(QuotaProject);
            if (maybeWithProject.UnderlyingCredential is ServiceAccountCredential serviceCredential
                && serviceCredential.UseJwtAccessWithScopes != UseJwtAccessWithScopes)
            {
                maybeWithProject = GoogleCredential.FromServiceAccountCredential(serviceCredential.WithUseJwtAccessWithScopes(UseJwtAccessWithScopes));
            }

            return maybeWithProject;
        }

        // Visible for testing
        internal async Task<GoogleCredential> GetGoogleCredentialAsync(CancellationToken cancellationToken)
        {
            GoogleCredential unscoped =
                GoogleCredential != null ? GoogleCredential :
                CredentialsPath != null ? await GoogleCredential.FromFileAsync(CredentialsPath, cancellationToken).ConfigureAwait(false) :
                JsonCredentials != null ? GoogleCredential.FromJson(JsonCredentials) :
                await GoogleCredential.GetApplicationDefaultAsync(cancellationToken).ConfigureAwait(false);
            GoogleCredential scoped = unscoped.CreateScoped(Scopes ?? ServiceMetadata.DefaultScopes);
            GoogleCredential maybeWithProject = QuotaProject is null ? scoped : scoped.CreateWithQuotaProject(QuotaProject);
            if (maybeWithProject.UnderlyingCredential is ServiceAccountCredential serviceCredential
                && serviceCredential.UseJwtAccessWithScopes != UseJwtAccessWithScopes)
            {
                maybeWithProject = GoogleCredential.FromServiceAccountCredential(serviceCredential.WithUseJwtAccessWithScopes(UseJwtAccessWithScopes));
            }

            return maybeWithProject;
        }

        /// <summary>
        /// Returns the channel pool to use when no other options are specified. This method is not called unless
        /// <see cref="CanUseChannelPool"/> returns true, so if a channel pool is unavailable, override that property
        /// to return false and throw an exception from this method.
        /// </summary>
        protected abstract ChannelPool GetChannelPool();

        /// <summary>
        /// Returns the effective <see cref="GrpcAdapter"/> for this builder,
        /// using the <see cref="GrpcAdapter"/> property if that is set, or the appropriate fallback adapter
        /// for <see cref="ServiceMetadata"/> otherwise.
        /// </summary>
        protected GrpcAdapter EffectiveGrpcAdapter => GrpcAdapter ?? GrpcAdapter.GetFallbackAdapter(ServiceMetadata);

        /// <summary>
        /// Returns the options to use when creating a channel, taking <see cref="GrpcChannelOptions"/>
        /// into account.
        /// </summary>
        /// <returns>The options to use when creating a channel.</returns>
        protected virtual GrpcChannelOptions GetChannelOptions()
        {
            var defaultOptions = UserAgent == null
                ? DefaultOptions
                : DefaultOptions.WithPrimaryUserAgent(UserAgent);
            // While we could use the "CustomChannelOptions ?? GrpcChannelOptions.Empty"
            // and merge unconditionally, there's no point in creating a new object
            // if we have no options.
            return GrpcChannelOptions is null
                ? defaultOptions
                : defaultOptions.MergedWith(GrpcChannelOptions);
        }

        /// <summary>
        /// Returns whether or not a channel pool can be used if a channel is required. The default behavior is to return
        /// true if and only if no quota project, scopes, credentials or token access method have been specified and 
        /// if UseJwtAccessWithScopes flag matches the flag in ChannelPool. 
        /// Derived classes should override this property if there are other reasons why the channel pool should not be used.
        /// </summary>
        protected virtual bool CanUseChannelPool =>
            ChannelCredentials == null &&
            CredentialsPath == null &&
            JsonCredentials == null &&
#pragma warning disable CS0618 // Type or member is obsolete
            TokenAccessMethod == null &&
#pragma warning restore CS0618 // Type or member is obsolete
            Scopes == null &&
            QuotaProject == null &&
            GoogleCredential == null &&
            Credential == null &&
            UseJwtAccessWithScopes == GetChannelPool().UseJwtAccessWithScopes;

        /// <summary>
        /// Returns whether or not self-signed JWTs will be used over OAuth tokens when OAuth scopes are explicitly set.        
        /// </summary>
        /// <remarks>
        /// In the base implementation, this defaults to <c>true</c>. Subclasses may add code in their own constructors
        /// to make the default effectively <c>false</c>, however.
        /// </remarks>
        public bool UseJwtAccessWithScopes { get; set; }

        // Note: The implementation is responsible for performing validation before constructing the client.
        // The Validate method can be used as-is for most builders.

        /// <summary>
        /// Builds the resulting client.
        /// </summary>
        public abstract TClient Build();

        /// <summary>
        /// Populates properties based on those set via dependency injection.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If gRPC adapters are configured in <paramref name="provider"/>, the first one that supports
        /// the <see cref="ServiceMetadata"/> will be used.
        /// </para>
        /// <para>
        /// Credentials are only requested from dependency injection if they are not already set
        /// via any of <see cref="ChannelCredentials"/>, <see cref="CredentialsPath"/>,
        /// <see cref="JsonCredentials"/>, <see cref="Credential"/>, <see cref="GoogleCredential"/>
        /// or <see cref="TokenAccessMethod"/>.
        /// </para>
        /// <para>
        /// If credentials are requested, they are tried in the following order:
        /// </para>
        /// <list type="bullet">
        /// <item>ChannelCredentials</item>
        /// <item>ICredential</item>
        /// <item>GoogleCredential</item>
        /// </list>
        /// </remarks>
        /// <param name="provider">The service provider to request dependencies from.</param>
        protected virtual void Configure(IServiceProvider provider)
        {
            GaxPreconditions.CheckNotNull(provider, nameof(provider));

            Logger ??= provider.GetService<ILogger<TClient>>();
            CallInvoker ??= provider.GetService<CallInvoker>();
            if (CallInvoker is object)
            {
                return;
            }

            GrpcAdapter ??= provider.GetServices<GrpcAdapter>().FirstOrDefault(adapter => adapter.SupportsApi(ServiceMetadata));
            GrpcChannelOptions ??= provider.GetService<GrpcChannelOptions>();

#pragma warning disable CS0618 // Type or member is obsolete
            if (ChannelCredentials is null && CredentialsPath is null && JsonCredentials is null && TokenAccessMethod is null &&
#pragma warning restore CS0618 // Type or member is obsolete
                GoogleCredential is null && Credential is null)
            {
                if (provider.GetService<ChannelCredentials>() is ChannelCredentials channelCredentials)
                {
                    ChannelCredentials = channelCredentials;
                }
                else if (provider.GetService<ICredential>() is ICredential credential)
                {
                    Credential = credential;
                }
                else if (provider.GetService<GoogleCredential>() is GoogleCredential googleCredential)
                {
                    GoogleCredential = googleCredential;
                }
            }
        }

        // Note: The implementation is responsible for performing validation before constructing the client.
        // The Validate method can be used as-is for most builders.

        /// <summary>
        /// Builds the resulting client asynchronously.
        /// </summary>
        public abstract Task<TClient> BuildAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Populates properties supplied via dependency injection, then builds a client.
        /// </summary>
        /// <param name="provider">The service provider to request dependencies from. Must not be null.</param>
        /// <returns>An API client configured from this builder.</returns>
        public TClient Build(IServiceProvider provider)
        {
            Configure(provider);
            return Build();
        }

        /// <summary>
        /// Populates properties supplied via dependency injection, then builds a client asynchronously.
        /// </summary>
        /// <param name="provider">The service provider to request dependencies from. Must not be null.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>An API client configured from this builder.</returns>
        public async Task<TClient> BuildAsync(IServiceProvider provider, CancellationToken cancellationToken = default)
        {
            Configure(provider);
            return await BuildAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns a <see cref="ChannelBase"/> as created by <see cref="EffectiveGrpcAdapter"/>
        /// for the specified endpoint and credentials, using the gRPC channel options from
        /// <see cref="GetChannelOptions"/>.
        /// </summary>
        /// <remarks>
        /// This is only useful in very specific situations where a known channel is required;
        /// <see cref="CreateCallInvoker"/> and its async equivalent are more usually useful.
        /// </remarks>
        /// <param name="endpoint">The endpoint of the channel.</param>
        /// <param name="credentials">The channel credentials.</param>
        /// <returns>The channel created by the gRPC adapter.</returns>
        protected virtual ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials) =>
            EffectiveGrpcAdapter.CreateChannel(ServiceMetadata, endpoint, credentials, GetChannelOptions());

        private class DelegatedTokenAccess : ITokenAccessWithHeaders
        {
            private readonly Func<string, CancellationToken, Task<string>> _tokenAccessMethod;
            private readonly string _quotaProject;

            internal DelegatedTokenAccess(Func<string, CancellationToken, Task<string>> tokenAccessMethod, string quotaProject) =>
                (_tokenAccessMethod, _quotaProject) = (tokenAccessMethod, quotaProject);

            public Task<string> GetAccessTokenForRequestAsync(string authUri, CancellationToken cancellationToken) =>
                _tokenAccessMethod(authUri, cancellationToken);

            public async Task<AccessTokenWithHeaders> GetAccessTokenWithHeadersForRequestAsync(string authUri = null, CancellationToken cancellationToken = default)
            {
                string token = await _tokenAccessMethod(authUri, cancellationToken).ConfigureAwait(false);
                return _quotaProject is null ? 
                    new AccessTokenWithHeaders(token, null) : 
                    new AccessTokenWithHeaders.Builder { QuotaProject = _quotaProject }.Build(token);
            }
        }
    }
}