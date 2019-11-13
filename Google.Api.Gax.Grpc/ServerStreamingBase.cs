/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        /// Async stream to read streaming responses, exposed as an async sequence.
        /// The default implementation will use <see cref="GrpcCall"/> to extract a response
        /// stream, and adapt it to <see cref="IAsyncEnumerator{T}"/>, passing in the specified cancellation
        /// token on each call to the gRPC stream.
        /// </summary>
        /// <remarks>
        /// If this method is called more than once, all the returned enumerators will be enumerating over the
        /// same underlying response stream, which may cause confusion. Additionally, the sequence returned by
        /// this method can only be iterated over a single time. Attempting to iterate more than once will cause
        /// an <see cref="InvalidOperationException"/>.
        /// </remarks>
        public virtual IAsyncEnumerable<TResponse> GetResponseStream() =>
            new ResponseStreamAdapter<TResponse>(GrpcCall.ResponseStream);
    }
}
