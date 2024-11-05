/*
 * Copyright 2024 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc;

/// <summary>
/// Extension methods for Google credential universe domain validation.
/// </summary>
internal static class GoogleCredentialExtensions
{
    /// <summary>
    /// Returns a channel credential based on <paramref name="googleCredential"/>, that will validate its own universe domain
    /// against <paramref name="universeDomain"/>.
    /// </summary>
    /// <param name="googleCredential">The Google credential to build the channel credentials from. Must not be null.</param>
    /// <param name="universeDomain">The universe domain to validate against. Must not be null.
    /// <see cref="GoogleCredential.GetUniverseDomainAsync(CancellationToken)"/> should result in the same value as this.</param>
    internal static ChannelCredentials ToChannelCredentials(this GoogleCredential googleCredential, string universeDomain) =>
        new GoogleCredentialWithUniverseDomainValidation(googleCredential, universeDomain).ToChannelCredentials();

    private class GoogleCredentialWithUniverseDomainValidation : ITokenAccessWithHeaders
    {
        private readonly ITokenAccessWithHeaders _underlying;
        private readonly string _universeDomain;
        private readonly Lazy<Task> _universeDomainsMatchCheckCache;

        public GoogleCredentialWithUniverseDomainValidation(GoogleCredential googleCredential, string universeDomain)
        {
            _underlying = GaxPreconditions.CheckNotNull(googleCredential, nameof(googleCredential));
            _universeDomain = GaxPreconditions.CheckNotNull(universeDomain, nameof(universeDomain));
            _universeDomainsMatchCheckCache = new Lazy<Task>(UniverseDomainsMatchCheckUncached);
        }

        public async Task<string> GetAccessTokenForRequestAsync(string authUri = null, CancellationToken cancellationToken = default)
        {
            await _universeDomainsMatchCheckCache.Value.WithCancellationToken(cancellationToken).ConfigureAwait(false);
            return await _underlying.GetAccessTokenForRequestAsync(authUri, cancellationToken).ConfigureAwait(false);
        }

        public async Task<AccessTokenWithHeaders> GetAccessTokenWithHeadersForRequestAsync(string authUri = null, CancellationToken cancellationToken = default)
        {
            await _universeDomainsMatchCheckCache.Value.WithCancellationToken(cancellationToken).ConfigureAwait(false);
            return await _underlying.GetAccessTokenWithHeadersForRequestAsync(authUri, cancellationToken).ConfigureAwait(false);
        }

        private async Task UniverseDomainsMatchCheckUncached()
        {
            GoogleCredential googleCredential = _underlying as GoogleCredential;
            // b/377378462 Temporarily avoid automatic requests to the MDS UniverseDomain endpoint.
            if (googleCredential.UnderlyingCredential is ComputeCredential)
            {
                return;
            }
            string credentialUniverseDomain = await (googleCredential).GetUniverseDomainAsync(default).ConfigureAwait(false);
            if (credentialUniverseDomain != _universeDomain)
            {
                throw new InvalidOperationException(
                    $"The service client universe domain {_universeDomain} does not match the credential universe domain {credentialUniverseDomain}." +
                    $"You can configure the universe domain for your service client by using the UniverseDomain property on the corresponding client builder.");
            }
        }
    }
}
