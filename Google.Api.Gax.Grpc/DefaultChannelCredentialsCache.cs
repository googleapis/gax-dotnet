/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Caches the application default channel credentials for an individual service, applying a specified set of scopes when required.
    /// </summary>
    internal sealed class DefaultChannelCredentialsCache
    {
        private readonly IEnumerable<string> _scopes;

        internal bool UseJwtAccessWithScopes { get; }

        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// The same channel credentials are used by all pools. The field is initialized in the constructor, as it uses
        /// _scopes, and you can't refer to an instance field within an instance field initializer.
        /// </summary>
        private readonly Lazy<Task<GoogleCredential>> _lazyScopedDefaultChannelCredentials;

        /// <summary>
        /// Creates a cache which will apply the specified scopes to the default application credentials
        /// if they require any.
        /// </summary>
        /// <param name="serviceMetadata">The metadata of the service the credentials will be used with. Must not be null.</param>
        internal DefaultChannelCredentialsCache(ServiceMetadata serviceMetadata)
        {
            UseJwtAccessWithScopes = serviceMetadata.SupportsScopedJwts;

            // In theory, we don't actually need to store the scopes as field in this class. We could capture a local variable here.
            // However, it won't be any more efficient, and having the scopes easily available when debugging could be handy.
            _scopes = serviceMetadata.DefaultScopes;
            _lazyScopedDefaultChannelCredentials =
                new Lazy<Task<GoogleCredential>>(() => Task.Run(async () =>
                {
                    var appDefaultCredentials = await GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);
                    if (appDefaultCredentials.IsCreateScopedRequired)
                    {
                        appDefaultCredentials = appDefaultCredentials.CreateScoped(_scopes);
                    }

                    if (appDefaultCredentials.UnderlyingCredential is ServiceAccountCredential serviceCredential
                        && serviceCredential.UseJwtAccessWithScopes != UseJwtAccessWithScopes)
                    {
                        appDefaultCredentials = GoogleCredential.FromServiceAccountCredential(serviceCredential.WithUseJwtAccessWithScopes(UseJwtAccessWithScopes));
                    }
                    return appDefaultCredentials;
                }));
        }

        internal ChannelCredentials GetCredentials(string universeDomain) =>
            GetCredentialsAsync(universeDomain, default).ResultWithUnwrappedExceptions();

        internal async Task<ChannelCredentials> GetCredentialsAsync(string universeDomain, CancellationToken cancellationToken)
        {
            var googleCredential = await _lazyScopedDefaultChannelCredentials.Value.WithCancellationToken(cancellationToken).ConfigureAwait(false);
            return googleCredential.ToChannelCredentials(universeDomain);
        }
    }
}
