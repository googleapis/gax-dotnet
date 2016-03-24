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
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Common helper code shared by clients.
    /// </summary>
    public class ClientHelper
    {
        /// <summary>
        /// Lazily-created task to retrieve the default application channel credentials. Once completed, this
        /// task can be used whenever channel credentials are required. The returned task always runs in the
        /// thread pool, so its result can be used synchronously from synchronous methods without risk of deadlock.
        /// </summary>
        private static readonly Lazy<Task<ChannelCredentials>> s_lazyDefaultChannelCredentials
            = new Lazy<Task<ChannelCredentials>>(
                () => Task.Run(async () => (await GoogleCredential.GetApplicationDefaultAsync()).ToChannelCredentials()));

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
        /// Creates a channel with the specified endpoint and credentials, defaulting to the application default
        /// credentials.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use, or null to use the application default credentials.</param>
        /// <returns>A task representing the asynchronous operation. When completed, the result of the task will be a
        /// channel for the specified endpoint, with the given credentials or application default credentials.</returns>
        public static async Task<Channel> CreateChannelAsync(ServiceEndpoint endpoint, ChannelCredentials credentials)
        {
            // TODO: Could avoid constructing the task-based state machine if either credentials is supplied or the
            // lazy default channel credentials task has completed.
            var effectiveCredentials = credentials ?? await s_lazyDefaultChannelCredentials.Value.ConfigureAwait(false);
            return new Channel(endpoint.Host, endpoint.Port, effectiveCredentials);
        }

        /// <summary>
        /// Creates a channel with the specified endpoint and credentials, defaulting to the application default
        /// credentials.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use, or null to use the application default credentials.</param>
        /// <returns>A channel for the specified endpoint, with the given credentials or application default credentials.</returns>
        public static Channel CreateChannel(ServiceEndpoint endpoint, ChannelCredentials credentials)
        {
            var effectiveCredentials = credentials ?? s_lazyDefaultChannelCredentials.Value.Result;
            return new Channel(endpoint.Host, endpoint.Port, effectiveCredentials);
        }
        #endregion
    }
}
