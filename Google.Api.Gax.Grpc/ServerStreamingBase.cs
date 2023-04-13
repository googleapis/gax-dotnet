/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Base class for server streaming RPC methods. This wraps an underlying call returned by gRPC,
    /// in order to provide a wrapper for the async response stream, allowing users to take advantage
    /// of <code>await foreach</code> support from C# 8 onwards.
    /// </summary>
    /// <remarks>
    /// To avoid memory leaks, users must dispose of gRPC streams.
    /// Additionally, you are strongly advised to read the whole response stream, even if the data
    /// is not required - this avoids effectively cancelling the call.
    /// </remarks>
    /// <typeparam name="TResponse">RPC streaming response type</typeparam>
    public class ServerStreamingBase<TResponse> : IDisposable
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
        /// stream, and adapt it to <see cref="AsyncResponseStream{T}"/>.
        /// </summary>
        /// <remarks>
        /// If this method is called more than once, all the returned enumerators will be enumerating over the
        /// same underlying response stream, which may cause confusion. Additionally, the sequence returned by
        /// this method can only be iterated over a single time. Attempting to iterate more than once will cause
        /// an <see cref="InvalidOperationException"/>.
        /// </remarks>
        public virtual AsyncResponseStream<TResponse> GetResponseStream() =>
            new AsyncResponseStream<TResponse>(GrpcCall.ResponseStream);

        /// <summary>
        /// Disposes of the underlying gRPC call. There is no need to dispose of both the wrapper
        /// and the underlying call; it's typically simpler to dispose of the wrapper with a
        /// <code>using</code> statement as the wrapper is returned by client libraries.
        /// </summary>
        /// <remarks>The default implementation just calls Dispose on the result of <see cref="GrpcCall"/>.</remarks>
        public virtual void Dispose() => GrpcCall.Dispose();
    }
}
