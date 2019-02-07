/*
 * Copyright 2019 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Testing
{
    /// <summary>
    /// Simple adapter to allow an <see cref="IAsyncEnumerator{T}"/> to be used as a gRPC <see cref="IAsyncStreamReader{T}"/>.
    /// The gRPC interface doesn't add any extra members, so this is really just delegation.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    public sealed class AsyncStreamAdapter<T> : IAsyncStreamReader<T>
    {
        private readonly IAsyncEnumerator<T> _enumerator;

        /// <summary>
        /// Wraps the given async enumerator as an async stream reader.
        /// </summary>
        /// <param name="enumerator">The enumerator to wrap</param>
        public AsyncStreamAdapter(IAsyncEnumerator<T> enumerator) =>
            _enumerator = enumerator;

        /// <inheritdoc />
        public T Current => _enumerator.Current;

        /// <inheritdoc />
        public void Dispose() => _enumerator.Dispose();

        /// <inheritdoc />
        public Task<bool> MoveNext(CancellationToken cancellationToken) => _enumerator.MoveNext(cancellationToken);
    }
}
