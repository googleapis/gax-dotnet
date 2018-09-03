/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Base class for server streaming RPC methods.
    /// </summary>
    /// <typeparam name="TResponse">RPC streaming response type</typeparam>
    public class ServerStreamingBase<TResponse>
    {
        /// <summary>
        /// The underlying gRPC duplex streaming call.
        /// </summary>
        public virtual AsyncServerStreamingCall<TResponse> GrpcCall
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Async stream to read streaming responses.
        /// </summary>
        public virtual IAsyncEnumerator<TResponse> ResponseStream
        {
            get { throw new NotImplementedException(); }
        }
    }
}
