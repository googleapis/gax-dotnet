/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// Methods to convert ChannelCredentials and CallCredentials into AsyncAuthInterceptors,
    /// so we can ask them to populate auth headers.
    /// </summary>
    internal static class CredentialExtensions
    {
        /// <summary>
        /// Returns the async auth interceptor derived from the given channel credentials, or null
        /// if the channel credentials don't involve an interceptor.
        /// </summary>
        /// <param name="credentials">The channel credentials to convert.</param>
        internal static AsyncAuthInterceptor ToAsyncAuthInterceptor(this ChannelCredentials credentials)
        {
            var configurator = new RestChannelCredentialsConfigurator();
            credentials.InternalPopulateConfiguration(configurator, state: null);
            return configurator.Interceptor;
        }

        /// <summary>
        /// Returns the async auth interceptor derived from the given channel credentials, or null
        /// if the channel credentials don't involve an interceptor.
        /// </summary>
        /// <param name="credentials">The channel credentials to convert.</param>
        internal static AsyncAuthInterceptor ToAsyncAuthInterceptor(this CallCredentials credentials)
        {
            var configurator = new RestCallCredentialsConfigurator();
            credentials.InternalPopulateConfiguration(configurator, null);
            return configurator.Interceptor;
        }

        private sealed class RestChannelCredentialsConfigurator : ChannelCredentialsConfiguratorBase
        {
            internal AsyncAuthInterceptor Interceptor { get; private set; }

            // TODO: Validate that we're okay to discard the ChannelCredentials.
            // This isn't very clearly documented...
            public override void SetCompositeCredentials(object state, ChannelCredentials channelCredentials, CallCredentials callCredentials)
            {
                Interceptor = callCredentials.ToAsyncAuthInterceptor();
            }

            public override void SetInsecureCredentials(object state)
            {
                // No-op
            }

            public override void SetSslCredentials(object state, string rootCertificates, KeyCertificatePair keyCertificatePair, VerifyPeerCallback verifyPeerCallback)
            {
                // No-op
            }
        }

        private sealed class RestCallCredentialsConfigurator : CallCredentialsConfiguratorBase
        {
            internal AsyncAuthInterceptor Interceptor { get; private set; }

            public override void SetAsyncAuthInterceptorCredentials(object state, AsyncAuthInterceptor interceptor)
            {
                Interceptor = interceptor;
            }

            public override void SetCompositeCredentials(object state, IReadOnlyList<CallCredentials> credentials) =>
                throw new NotSupportedException("Composite credentials are not supported");
        }
    }
}
