/*
 * Copyright 2018 Google Inc. All Rights Reserved.
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
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Gcp
{
    // TODO: Move this into Google.Api.Gax.Grpc and make it public? We could then avoid the duplication
    // between this and code in Google.Api.Gax.Grpc.ChannelPool.

    /// <summary>
    /// Caches the application default channel credentials, applying a specified set of scopes if they require any.
    /// </summary>
    internal sealed class DefaultChannelCredentialsCache
    {
        private readonly IEnumerable<string> _scopes;

        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// The same channel credentials are used by all pools. The field is initialized in the constructor, as it uses
        /// _scopes, and you can't refer to an instance field within an instance field initializer.
        /// </summary>
        private readonly Lazy<Task<ChannelCredentials>> _lazyScopedDefaultChannelCredentials;

        /// <summary>
        /// Creates a cache which will apply the specified scopes to the default application credentials
        /// if they require any.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        internal DefaultChannelCredentialsCache(IEnumerable<string> scopes)
        {
            // Always take a copy of the provided scopes, then check the copy doesn't contain any nulls.
            _scopes = GaxPreconditions.CheckNotNull(scopes, nameof(scopes)).ToList();
            GaxPreconditions.CheckArgument(!_scopes.Any(x => x == null), nameof(scopes), "Scopes must not contain any null references");
            // In theory, we don't actually need to store the scopes as field in this class. We could capture a local variable here.
            // However, it won't be any more efficient, and having the scopes easily available when debugging could be handy.
            _lazyScopedDefaultChannelCredentials =
                new Lazy<Task<ChannelCredentials>>(() => Task.Run(async () =>
                {
                    var appDefaultCredentials = await GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);
                    if (appDefaultCredentials.IsCreateScopedRequired)
                    {
                        appDefaultCredentials = appDefaultCredentials.CreateScoped(_scopes);
                    }
                    return appDefaultCredentials.ToChannelCredentials();
                }));
        }

        internal ChannelCredentials GetCredentials() =>
            GetCredentialsAsync().ResultWithUnwrappedExceptions();

        internal Task<ChannelCredentials> GetCredentialsAsync() =>
            _lazyScopedDefaultChannelCredentials.Value;
    }
}
