/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Common helper code shared by clients.
    /// </summary>
    public class ClientHelper
    {
        private readonly IClock _clock;
        private readonly CallSettings _globalCallSettings;

        /// <summary>
        /// Constructs a helper from the given settings.
        /// Behavior is undefined if settings are changed after construction.
        /// </summary>
        /// <param name="settings">The service settings.</param>
        public ClientHelper(ServiceSettingsBase settings)
        {
            _clock = settings.Clock ?? SystemClock.Instance;
            _globalCallSettings = settings.CallSettings ?? new CallSettings();
        }

        private DateTime? CalculateDeadline(Expiration expiration)
        {
            if (expiration == null || expiration.IsNone)
            {
                return null;
            }
            return expiration.Deadline ?? _clock.GetCurrentDateTimeUtc() + expiration.Timeout.Value;
        }

        /// <summary>
        /// Builds a suitable <see cref="CallOptions"/> taking service settings into account,
        /// along with a call-specific cancellation token and CallSettings override.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use for this call.</param>
        /// <param name="callOptionsOverride">Optional options override delegate.</param>
        /// <returns></returns>
        public CallOptions BuildCallOptions(
            CancellationToken? cancellationToken,
            CallSettings callSettings)
        {
            if (callSettings == null)
            {
                return new CallOptions(
                    headers: _globalCallSettings.Headers, // TODO: Add GAX header(s)
                    deadline: CalculateDeadline(_globalCallSettings.Expiration),
                    cancellationToken: cancellationToken ?? _globalCallSettings.CancellationToken ?? default(CancellationToken),
                    writeOptions: _globalCallSettings.WriteOptions,
                    propagationToken: _globalCallSettings.PropagationToken,
                    credentials: _globalCallSettings.Credentials);
            }
            return new CallOptions(
                // TODO: Sort out our cloning story.
                headers: callSettings.Headers ?? _globalCallSettings.Headers, // TODO: Add GAX header(s)
                deadline: CalculateDeadline(callSettings.Expiration ?? _globalCallSettings.Expiration),
                cancellationToken: cancellationToken ?? callSettings.CancellationToken ?? _globalCallSettings.CancellationToken ?? default(CancellationToken),
                writeOptions: callSettings.WriteOptions ?? _globalCallSettings.WriteOptions,
                propagationToken: callSettings.PropagationToken ?? _globalCallSettings.PropagationToken,
                credentials: callSettings.Credentials ?? _globalCallSettings.Credentials);
        }

        #region Factory methods for client construction

        /// <summary>
        /// Creates a channel for the host and port in this object, with defaults for unspecified values.
        /// </summary>
        /// <param name="endpoint">Endpoint settings to use. Must not be null.</param>
        /// <param name="defaultHost">The host to use if <see cref="Host"/> is null. Must not be null.</param>
        /// <param name="defaultPort">The port to use if <see cref="Port"/> is null.</param>
        /// <param name="credentials">The credentials to use with the channel. Must not be null.</param>
        /// <returns>A channel for the given endpoint with application default credentials.</returns>
        public static Channel CreateChannel(ServiceEndpointSettings endpoint, string defaultHost, int defaultPort, ChannelCredentials credentials)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(defaultHost, nameof(defaultHost));
            GaxPreconditions.CheckNotNull(credentials, nameof(credentials));
            return new Channel(endpoint.Host ?? defaultHost, endpoint.Port ?? defaultPort, credentials);
        }

        private static async Task<ChannelCredentials> GetScopedApplicationDefaultChannelCredentials(IEnumerable<string> scopes)
        {
            var credentials = await GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);
            if (credentials.IsCreateScopedRequired)
            {
                credentials = credentials.CreateScoped(scopes);
            }
            return ChannelCredentials.Create(new SslCredentials(), credentials.ToCallCredentials());
        }

        /// <summary>
        /// Creates a client using application default credentials, taking care of credential scoping.
        /// Behavior is undefined if any settings are changed after creation.
        /// </summary>
        /// <typeparam name="TClient">Type of the client to construct.</typeparam>
        /// <typeparam name="TSettings">Service-specific settings type.</typeparam>
        /// <param name="settings">The service settings.</param>
        /// <param name="serviceEndpointSettings">The endpoint settings.</param>
        /// <param name="suppliedCredentialScopes">The credential scopes supplied by the client, if any.</param>
        /// <param name="defaultCredentialScopes">The credential scopes to apply if none are supplied. These are not expected to change.</param>
        /// <param name="clientFactory">The factory delegate which creates a client given the relevant credentials, service settings and endpoint.</param>
        /// <returns>A task which, when completed, will have a result of the newly constructed client.</returns>
        public static async Task<TClient> CreateFromDefaultCredentialsAsync<TClient, TSettings>(
            TSettings settings,
            ServiceEndpointSettings serviceEndpointSettings,
            IEnumerable<string> suppliedCredentialScopes,
            IEnumerable<string> defaultCredentialScopes,
            Func<ChannelCredentials, TSettings, ServiceEndpointSettings, TClient> clientFactory)
            where TSettings : ServiceSettingsBase
        {
            var credentialScopes = suppliedCredentialScopes ?? defaultCredentialScopes;
            var credentials = await GetScopedApplicationDefaultChannelCredentials(credentialScopes);
            return clientFactory(credentials, settings, serviceEndpointSettings);
        }

        /// <summary>
        /// Creates a client using application default credentials, taking care of credential scoping.
        /// Behavior is undefined if any settings are changed after creation.
        /// </summary>
        /// <typeparam name="TClient">Type of the client to construct.</typeparam>
        /// <typeparam name="TSettings">Service-specific settings type.</typeparam>
        /// <param name="settings">The service settings.</param>
        /// <param name="serviceEndpointSettings">The endpoint settings.</param>
        /// <param name="suppliedCredentialScopes">The credential scopes supplied by the client, if any.</param>
        /// <param name="defaultCredentialScopes">The credential scopes to apply if none are supplied. These are not expected to change.</param>
        /// <param name="clientFactory">The factory delegate which creates a client given the relevant credentials, service settings and endpoint.</param>
        /// <returns>A newly constructed client.</returns>
        public static TClient CreateFromDefaultCredentials<TClient, TSettings>(
            TSettings settings,
            ServiceEndpointSettings serviceEndpointSettings,
            IEnumerable<string> suppliedCredentialScopes,
            IEnumerable<string> defaultCredentialScopes,
            Func<ChannelCredentials, TSettings, ServiceEndpointSettings, TClient> clientFactory)
            where TSettings : ServiceSettingsBase
        {
            var credentialScopes = suppliedCredentialScopes ?? defaultCredentialScopes;
            return Task.Run(async () =>
            {
                var credentials = await GetScopedApplicationDefaultChannelCredentials(credentialScopes);
                return clientFactory(credentials, settings, serviceEndpointSettings);
            }).Result;
        }
        #endregion
    }
}
