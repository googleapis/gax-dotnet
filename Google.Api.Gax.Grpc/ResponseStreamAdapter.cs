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
    /// An adapter from the gRPC stream representation (IAsyncStreamReader) to IAsyncEnumerable.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    internal class ResponseStreamAdapter<TResponse> : IAsyncEnumerable<TResponse>
    {
        private readonly IAsyncStreamReader<TResponse> _reader;
        private int _getEnumeratorCalled;

        internal ResponseStreamAdapter(IAsyncStreamReader<TResponse> reader) =>
            _reader = reader;

        public IAsyncEnumerator<TResponse> GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            if (Interlocked.CompareExchange(ref _getEnumeratorCalled, 0, 1) != 0)
            {
                throw new InvalidOperationException($"{nameof(GetAsyncEnumerator)} can only be called once for a gRPC response stream wrapper.");
            }
            return new Enumerator(_reader, cancellationToken);
        }

        private class Enumerator : IAsyncEnumerator<TResponse>
        {
            private readonly IAsyncStreamReader<TResponse> _reader;
            private readonly CancellationToken _cancellationToken;

            internal Enumerator(IAsyncStreamReader<TResponse> reader, CancellationToken cancellationToken)
            {
                _reader = reader;
                _cancellationToken = cancellationToken;
            }

            public TResponse Current => _reader.Current;

            // The gRPC response stream doesn't support disposal. The gRPC call (AsyncDuplexStreamingCall or AsyncServerStreamingCall) does,
            // but users should dispose that themselves if they want to rather than us doing it here.
            public ValueTask DisposeAsync() => default;

            public async ValueTask<bool> MoveNextAsync() => await _reader.MoveNext(_cancellationToken).ConfigureAwait(false);
        }
    }
}
