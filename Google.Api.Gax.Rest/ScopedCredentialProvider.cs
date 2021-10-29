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
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// Simple factory of scoped credentials, which caches a scoped version of the
    /// default application credentials to avoid repeated authentication.
    /// </summary>
    public sealed class ScopedCredentialProvider
    {
        /// <summary>
        /// Lazily-created task to retrieve the default application credentials. Once completed, this
        /// task can be used whenever credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// The field is initialized in the constructor, as it uses _scopes,
        /// and you can't refer to an instance field within an instance field initializer.
        /// </summary>
        private readonly Lazy<Task<GoogleCredential>> _lazyScopedDefaultCredentials;
        private readonly List<string> _scopes;
        private readonly bool _useJwtWithScopes;

        /// <summary>
        /// Creates a channel pool which will apply the specified scopes to the credentials if they require any.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        /// <param name="useJwtWithScopes">A flag preferring use of self-signed JWTs over OAuth tokens when OAuth scopes are explicitly set.</param>
        public ScopedCredentialProvider(IEnumerable<string> scopes, bool useJwtWithScopes)
        {
            // Always take a copy of the provided scopes, then check the copy doesn't contain any nulls.
            _scopes = GaxPreconditions.CheckNotNull(scopes, nameof(scopes)).ToList();
            GaxPreconditions.CheckArgument(!_scopes.Any(x => x == null), nameof(scopes), "Scopes must not contain any null references");
            _useJwtWithScopes = useJwtWithScopes;
            _lazyScopedDefaultCredentials = new Lazy<Task<GoogleCredential>>(() => Task.Run(CreateDefaultCredentialsUncached));
        }

        /// <summary>
        /// Creates a channel pool which will apply the specified scopes to the credentials if they require any.
        /// A provider created with this overload is equivalent to calling <see cref="ScopedCredentialProvider(IEnumerable{string}, bool)"/>
        /// with a second argument of <c>false</c>.
        /// </summary>
        /// <param name="scopes">The scopes to apply. Must not be null, and must not contain null references. May be empty.</param>
        public ScopedCredentialProvider(IEnumerable<string> scopes) : this(scopes, false)
        {
        }

        /// <summary>
        /// Returns credentials with the scopes applied if required.
        /// </summary>
        /// <param name="credentials">Existing credentials, if any. This may be null,
        /// in which case the default application credentials will be used.</param>
        /// <returns>A task representing the asynchronous operation. The result of the task
        /// is the scoped credentials.</returns>
        internal GoogleCredential GetCredentials(GoogleCredential credentials) =>
            credentials == null
                // No need to apply scopes here - they're already applied.
                ? _lazyScopedDefaultCredentials.Value.ResultWithUnwrappedExceptions()
                : ApplyScopes(credentials);

        /// <summary>
        /// Asynchronously returns credentials with the scopes applied if required.
        /// </summary>
        /// <param name="credentials">Existing credentials, if any. This may be null,
        /// in which case the default application credentials will be used.</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>A task representing the asynchronous operation. The result of the task
        /// is the scoped credentials.</returns>
        internal Task<GoogleCredential> GetCredentialsAsync(GoogleCredential credentials, CancellationToken cancellationToken) =>
            credentials == null
                ? WithCancellationToken(_lazyScopedDefaultCredentials.Value, cancellationToken)
                : Task.FromResult(ApplyScopes(credentials));

        private async Task<GoogleCredential> CreateDefaultCredentialsUncached()
        {
            // ConfigureAwait isn't really needed here as we're calling Task.Run anyway, but it's harmless.
            var credentials = await GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);
            return ApplyScopes(credentials);
        }

        /// <summary>
        /// Applies scopes when they're available, and potentially specifies a preference for
        /// using self-signed JWTs.
        /// </summary>
        private GoogleCredential ApplyScopes(GoogleCredential original)
        {
            if (!original.IsCreateScopedRequired || _scopes.Count == 0)
            {
                return original;
            }
            var scoped = original.CreateScoped(_scopes);
            return _useJwtWithScopes && scoped.UnderlyingCredential is ServiceAccountCredential serviceCredential
                ? GoogleCredential.FromServiceAccountCredential(serviceCredential.WithUseJwtAccessWithScopes(true))
                : scoped;
        }

        // Note: this is duplicated in Google.Apis.Auth, Google.Apis.Core and Google.Api.Gax.Grpc as well so it can stay internal.
        // Please change all implementations at the same time.
        /// <summary>
        /// Returns a task which can be cancelled by the given cancellation token, but otherwise observes the original
        /// task's state. This does *not* cancel any work that the original task was doing, and should be used carefully.
        /// </summary>
        private static Task<T> WithCancellationToken<T>(Task<T> task, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return task;
            }

            return ImplAsync();

            // Separate async method to allow the above optimization to avoid creating any new state machines etc.
            async Task<T> ImplAsync()
            {
                var cts = new TaskCompletionSource<T>();
                using (cancellationToken.Register(() => cts.TrySetCanceled()))
                {
                    var completedTask = await Task.WhenAny(task, cts.Task).ConfigureAwait(false);
                    return await completedTask.ConfigureAwait(false);
                }
            }
        }
    }
}
