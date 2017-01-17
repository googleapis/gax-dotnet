/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Base class for bidirectional streaming RPC methods.
    /// </summary>
    /// <typeparam name="TRequest">RPC request type</typeparam>
    /// <typeparam name="TResponse">RPC response type</typeparam>
    public abstract class BidirectionalStreamingBase<TRequest, TResponse>
    {
        /// <summary>
        /// The underlying gRPC duplex streaming call.
        /// Warning: DO NOT USE <c>GrpcCall.RequestStream</c> at all if using
        /// <see cref="TryWriteAsync(TRequest)"/>, <see cref="WriteAsync(TRequest)"/>,
        /// <see cref="TryWriteAsync(TRequest, WriteOptions)"/> , or <see cref="WriteAsync(TRequest, WriteOptions)"/>.
        /// Doing so will cause conflict with the write-buffer used within the <c>[Try]WriteAsync</c> methods.
        /// </summary>
        public virtual AsyncDuplexStreamingCall<TRequest, TResponse> GrpcCall
        {
            get { throw new NotImplementedException(); }
        }

        // Streaming requests

        /// <summary>
        /// Writes a message to the stream, if there is enough space in the buffer and <see cref="WriteCompleteAsync"/>
        /// hasn't already been called. The same write options will be used as for the previous message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <returns><c>null</c> if the message queue is full or the stream has already been completed;
        /// otherwise, a <see cref="Task"/> which will complete when the message has been written to the stream.</returns>
        public virtual Task TryWriteAsync(TRequest message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a message to the stream, if there is enough space in the buffer and <see cref="WriteCompleteAsync"/>
        /// hasn't already been called. The same write options will be used as for the previous message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <exception cref="InvalidOperationException">There isn't enough space left in the buffer,
        /// or <see cref="WriteCompleteAsync"/> has already been called.</exception>
        /// <returns>A <see cref="Task"/> which will complete when the message has been written to the stream.</returns>
        public virtual Task WriteAsync(TRequest message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a message to the stream, if there is enough space in the buffer and <see cref="WriteCompleteAsync"/>
        /// hasn't already been called.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="options">The write options to use for this message.</param>
        /// <returns><c>null</c> if the message queue is full or the stream has already been completed.</returns>
        public virtual Task TryWriteAsync(TRequest message, WriteOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a message to the stream, if there is enough space in the buffer and <see cref="WriteCompleteAsync"/>
        /// hasn't already been called.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="options">The write options to use for this message.</param>
        /// <exception cref="InvalidOperationException">There isn't enough space left in the buffer,
        /// or <see cref="WriteCompleteAsync"/> has already been called.</exception>
        /// <returns>A <see cref="Task"/> which will complete when the message has been written to the stream.</returns>
        public virtual Task WriteAsync(TRequest message, WriteOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Completes the stream when all buffered messages have been sent. This method can only be called
        /// once, and further messages cannot be written after it has been called.
        /// </summary>
        /// <exception cref="InvalidOperationException">This method has already been called.</exception>
        /// <returns>A <see cref="Task"/> which will complete when the stream has finished being completed.</returns>
        public virtual Task WriteCompleteAsync()
        {
            throw new NotImplementedException();
        }

        // Streaming responses

        /// <summary>
        /// Async stream to read streaming responses.
        /// </summary>
        public virtual IAsyncEnumerator<TResponse> ResponseStream
        {
            get { throw new NotImplementedException(); }
        }
    }
}
