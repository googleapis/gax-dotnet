/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Implementation of <see cref="IAsyncEnumerable{T}"/> used for page streaming.
    /// </summary>
    internal sealed class PageStreamingAsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly Func<CancellationToken, Task<IEnumerable<T>>> _provider;

        internal PageStreamingAsyncEnumerable(Func<CancellationToken, Task<IEnumerable<T>>> provider)
        {
            _provider = provider;
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return new PagingAsyncEnumerator<T>(_provider);
        }
    }

    internal sealed class PagingAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private static readonly IEnumerable<T> s_emptySequence = Enumerable.Empty<T>();

        private readonly Func<CancellationToken, Task<IEnumerable<T>>> _provider;

        /// <summary>
        /// The enumerator we're currently looping through, or null if we've exhausted the source.
        /// Note that this is always the enumerator from a list or Enumerable.Empty,
        /// so we don't need to worry about disposing of it.
        /// </summary>
        private IEnumerator<T> _enumerator = s_emptySequence.GetEnumerator();

        public T Current { get; private set; }

        internal PagingAsyncEnumerator(Func<CancellationToken, Task<IEnumerable<T>>> provider)
        {
            _provider = provider;
        }

        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (_enumerator == null)
            {
                return false;
            }
            // Note: need to loop here in case our provider returns an empty sequence.
            while (!_enumerator.MoveNext())
            {
                var nextSequence = await _provider(cancellationToken).ConfigureAwait(false);
                if (nextSequence == null)
                {
                    _enumerator = null;
                    Current = default(T);
                    return false;
                }
                _enumerator = nextSequence.ToList().GetEnumerator();
            }
            Current = _enumerator.Current;
            return true;
        }

        /// <summary>
        /// No-op implementation of IDisposable, at least for now.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
