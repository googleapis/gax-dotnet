/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Google.Api.Gax.Grpc.Rest
{
    class RestChannelCredentialsConfigurator : ChannelCredentialsConfiguratorBase
    {
        internal AsyncAuthInterceptor Interceptor { get; private set; }

        public override void SetCompositeCredentials(object state, ChannelCredentials channelCredentials, CallCredentials callCredentials)
        {
            var configurator = new RestCallCredentialsConfigurator();
            callCredentials.InternalPopulateConfiguration(configurator, null);
            Interceptor = configurator.Interceptor;
        }

        public override void SetInsecureCredentials(object state)
        {
            throw new NotImplementedException();
        }

        public override void SetSslCredentials(object state, string rootCertificates, KeyCertificatePair keyCertificatePair, VerifyPeerCallback verifyPeerCallback)
        {
            // No-op
        }
    }

    class RestCallCredentialsConfigurator : CallCredentialsConfiguratorBase
    {
        internal AsyncAuthInterceptor Interceptor { get; private set; }

        public override void SetAsyncAuthInterceptorCredentials(object state, AsyncAuthInterceptor interceptor)
        {
            Interceptor = interceptor;
        }

        public override void SetCompositeCredentials(object state, IReadOnlyList<CallCredentials> credentials)
        {
            throw new NotImplementedException();
        }
    }
}
