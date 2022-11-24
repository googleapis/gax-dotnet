/*
 * Copyright 2019 Google LLC
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
    /// An adapter from the gRPC stream representation (<see cref="IAsyncStreamReader{T}"/>) to <see cref="IAsyncEnumerable{T}"/>
    /// and <see cref="IAsyncEnumerator{T}"/>. Note that <see cref="GetAsyncEnumerator(CancellationToken)"/> can only
    /// be called once per instance due to the "only iterate once" nature of the response stream.
    /// </summary>
    /// <remarks>
    /// This type implements both of the standard asynchronous sequence interfaces for simplicity of use:
    /// <list type="bullet">
    ///   <item>C# 8 users can use  <c>await foreach</c> because it implements <see cref="IAsyncEnumerable{T}"/></item>
    ///   <item>It's compatible with the System.Linq.Async package for query transformations.</item>
    ///   <item>Pre-C# 8 users who will be calling <see cref="MoveNextAsync()" /> and <see cref="Current"/> directly don't need
    ///   to call <see cref="GetAsyncEnumerator(CancellationToken)"/>.</item>
    /// </list>
    /// </remarks>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public sealed class AsyncResponseStream<TResponse> : IAsyncEnumerable<TResponse>, IAsyncEnumerator<TResponse>
    {
        private readonly IAsyncStreamReader<TResponse> _reader;
        private int _getEnumeratorCalled;
        private CancellationToken _cancellationToken;

        internal AsyncResponseStream(IAsyncStreamReader<TResponse> reader) =>
            _reader = reader;

        /// <inheritdoc />
        public TResponse Current => _reader.Current;

        // Pass on the request to dispose to the reader *if* it supports asynchronous disposal. (The gRPC default implementation
        // doesn't; the REGAPIC implementation does.)
        /// <inheritdoc />
        public ValueTask DisposeAsync() => _reader is IAsyncDisposable disposable ? disposable.DisposeAsync() : default;

        /// <summary>
        /// Begins iterating over the response stream, using the specified cancellation token. This method can only be called
        /// once per instance.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use in subsequent <see cref="MoveNextAsync()"/> calls.</param>
        /// <exception cref="InvalidOperationException">This method has already been called on this instance.</exception>
        /// <returns>An iterator over the response stream.</returns>
        public IAsyncEnumerator<TResponse> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            if (Interlocked.CompareExchange(ref _getEnumeratorCalled, 1, 0) != 0)
            {
                throw new InvalidOperationException($"{nameof(GetAsyncEnumerator)} can only be called once for a gRPC response stream wrapper.");
            }
            _cancellationToken = cancellationToken;
            return this;
        }

        /// <summary>
        /// Moves to the next item, using the specified cancellation token.
        /// </summary>
        /// <remarks></remarks>
        /// <param name="cancellationToken">The cancellation token to use for this step.</param>
        /// <returns>A task that will complete with a result of true if the enumerator was successfully advanced to the next element, or false if the enumerator has passed the end of the collection.</returns>
        public async ValueTask<bool> MoveNextAsync(CancellationToken cancellationToken) =>
            await _reader.MoveNext(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Moves to the next item, using the cancellation token configured by <see cref="GetAsyncEnumerator(CancellationToken)"/>.
        /// </summary>
        public ValueTask<bool> MoveNextAsync() => MoveNextAsync(_cancellationToken);
    }
}
