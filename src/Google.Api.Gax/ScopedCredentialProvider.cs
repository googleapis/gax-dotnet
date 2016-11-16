/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Simple factory of scoped credentials, which caches a scoped version of the
    /// default application credentials to avoid repeated authentication.
    /// </summary>
    public sealed class ScopedCredentialProvider
    {
        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// The same channel credentials are used by all pools. The field is initialized in the constructor, as it uses
        /// _scopes, and you can't refer to an instance field within an instance field initializer.
        /// </summary>
        private readonly Lazy<Task<GoogleCredential>> _lazyScopedDefaultCredentials;
        private readonly List<string> _scopes;

        /// <summary>
        /// Creates a channel pool which will apply the specified scopes to the credentials if they require any.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        public ScopedCredentialProvider(IEnumerable<string> scopes)
        {
            // Always take a copy of the provided scopes, then check the copy doesn't contain any nulls.
            _scopes = GaxPreconditions.CheckNotNull(scopes, nameof(scopes)).ToList();
            GaxPreconditions.CheckArgument(!_scopes.Any(x => x == null), nameof(scopes), "Scopes must not contain any null references");
            _lazyScopedDefaultCredentials = new Lazy<Task<GoogleCredential>>(() => Task.Run(CreateDefaultCredentialsUncached));
        }

        /// <summary>
        /// Returns credentials with the scopes applied if required.
        /// </summary>
        /// <param name="credentials">Existing credentials, if any. This may be null,
        /// in which case the default application credentials will be used.</param>
        /// <returns>A task representing the asynchronous operation. The result of the task
        /// is the scoped credentials.</returns>
        public GoogleCredential GetCredentials(GoogleCredential credentials)
        {
            if (credentials != null)
            {
                return ApplyScopes(credentials);
            }
            try
            {
                // No need to apply scopes here - they're already applied.
                return _lazyScopedDefaultCredentials.Value.Result;
            }
            catch (AggregateException e)
            {
                // Unwrap the first exception, a bit like await would.
                // It's very unlikely that we'd ever see an AggregateException without an inner exceptions,
                // but let's handle it relatively gracefully.
                throw e.InnerExceptions.FirstOrDefault() ?? e;
            }
        }

        /// <summary>
        /// Asynchronously returns credentials with the scopes applied if required.
        /// </summary>
        /// <param name="credentials">Existing credentials, if any. This may be null,
        /// in which case the default application credentials will be used.</param>
        /// <returns>A task representing the asynchronous operation. The result of the task
        /// is the scoped credentials.</returns>
        public Task<GoogleCredential> GetCredentialsAsync(GoogleCredential credentials) =>
            credentials == null
                ? _lazyScopedDefaultCredentials.Value
                : Task.FromResult(ApplyScopes(credentials));

        private async Task<GoogleCredential> CreateDefaultCredentialsUncached()
        {
            var credentials = await GoogleCredential.GetApplicationDefaultAsync();
            return ApplyScopes(credentials);
        }

        private GoogleCredential ApplyScopes(GoogleCredential original)
        {
            return original.IsCreateScopedRequired && _scopes.Count > 0
                ? original.CreateScoped(_scopes)
                : original;
        }
    }
}
