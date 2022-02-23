/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;

namespace Google.Api.Gax.Grpc.Gcp.IntegrationTests
{
    /// <summary>
    /// Fake implementation of <see cref="ChannelBase"/> which returns <see cref="FakeCallInvoker"/>
    /// instances as call invokers.
    /// </summary>
    internal class FakeChannel : ChannelBase
    {
        public ChannelCredentials Credentials { get; }
        public GrpcChannelOptions Options { get; }


        public FakeChannel(string target, ChannelCredentials credentials, GrpcChannelOptions options) : base(target)
        {
            Credentials = credentials;
            Options = options;
        }

        public override CallInvoker CreateCallInvoker() => new FakeCallInvoker(this);
    }
}