/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Testing
{
    /// <summary>
    /// A data source that can be used to easily provide <see cref="PagedEnumerable{TResponse, TResource}"/> and
    /// <see cref="PagedAsyncEnumerable{TResponse, TResource}"/> values for client testing. By default, this is
    /// not capable of creating raw responses; if those are required, just derive a new class from this one and
    /// override <see cref="CreateResponse(Page{TResource})"/>.
    /// </summary>
    /// <remarks>
    /// The generated page tokens are just string representations of resource indexes, e.g. "5" for the page beginning
    /// with resource at index 5.
    /// </remarks>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <typeparam name="TResource">The resource type.</typeparam>
    public class FakeDataSource<TResponse, TResource>
    {
        private readonly List<TResource> _resources;
        private readonly int _defaultPageSize;
        private readonly string _emptyPageToken;

        /// <summary>
        /// Creates a fake data source with the given resources.
        /// </summary>
        /// <param name="resources">The resources to return. Must not be null.</param>
        /// <param name="defaultPageSize">The default page size.</param>
        /// <param name="emptyPageToken">The page token to use for "end of resources"; for gRPC, use an empty string (the default);
        /// for REST use null.</param>
        public FakeDataSource(IEnumerable<TResource> resources, int defaultPageSize = 10, string emptyPageToken = "")
        {
            _resources = resources.ToList();
            _defaultPageSize = defaultPageSize;
            _emptyPageToken = emptyPageToken;
        }

        /// <summary>
        /// Creates a <see cref="PagedAsyncEnumerable{TResponse, TResource}"/>
        /// </summary>
        /// <param name="initialPageToken">The page token to start with, if any. (Defaults to starting at the beginning of the resources.)</param>
        /// <returns>A <see cref="PagedAsyncEnumerable{TResponse, TResource}"/>.</returns>
        public PagedAsyncEnumerable<TResponse, TResource> GetPagedAsyncEnumerable(string initialPageToken = null) =>
            new FakePagedAsyncEnumerable(this, initialPageToken);

        /// <summary>
        /// Creates a <see cref="PagedEnumerable{TResponse, TResource}"/>
        /// </summary>
        /// <param name="initialPageToken">The page token to start with, if any. (Defaults to starting at the beginning of the resources.)</param>
        /// <returns>A <see cref="PagedEnumerable{TResponse, TResource}"/>.</returns>
        public PagedEnumerable<TResponse, TResource> GetPagedEnumerable(string initialPageToken = null) =>
            new FakePagedEnumerable(this, initialPageToken);

        private IEnumerable<TResponse> AsRawResponses(string initialPageToken)
        {
            string pageToken = initialPageToken;
            do
            {
                var page = ReadPage(pageToken, _defaultPageSize);
                yield return CreateResponse(page);
                pageToken = page.NextPageToken;
            } while (pageToken != _emptyPageToken);
        }

        private Page<TResource> ReadPage(string pageToken, int pageSize)
        {
            int start = ParsePageToken(pageToken);
            var pageResources = _resources.Skip(start).Take(pageSize).ToList();
            int end = pageResources.Count + start;
            string nextPageToken = end == _resources.Count ? _emptyPageToken : end.ToString(CultureInfo.InvariantCulture);
            return new Page<TResource>(pageResources, nextPageToken);
        }

        private int ParsePageToken(string token) => int.Parse(token ?? "0", CultureInfo.InvariantCulture);

        /// <summary>
        /// Creates a response for the given page of resources. By default, this method throws <see cref="NotImplementedException"/>;
        /// this method is only called when generating raw responses; if you're testing code that doesn't use <c>AsRawResponses</c>,
        /// </summary>
        /// <param name="page">The page of resources.</param>
        /// <returns>A response for the page of resources.</returns>
        protected virtual TResponse CreateResponse(Page<TResource> page)
        {
            throw new NotImplementedException();
        }

        private IEnumerator<TResource> GetEnumerator(string token) =>
            _resources.Skip(ParsePageToken(token)).GetEnumerator();

        private class FakePagedAsyncEnumerable : PagedAsyncEnumerable<TResponse, TResource>
        {
            private readonly FakeDataSource<TResponse, TResource> _parent;
            private readonly string _initialPageToken;

            public FakePagedAsyncEnumerable(FakeDataSource<TResponse, TResource> parent, string initialPageToken)
            {
                _parent = parent;
                _initialPageToken = initialPageToken;
            }

            public override IAsyncEnumerable<TResponse> AsRawResponses() =>
                _parent.AsRawResponses(_initialPageToken).ToAsyncEnumerable();

            public override Task<Page<TResource>> ReadPageAsync(int pageSize, CancellationToken cancellationToken = default(CancellationToken)) =>
                Task.FromResult(_parent.ReadPage(_initialPageToken, pageSize));

            public override IAsyncEnumerator<TResource> GetEnumerator()
            {
                var iterator = _parent.GetEnumerator(_initialPageToken);
                return AsyncEnumerable.CreateEnumerator(token => Task.FromResult(iterator.MoveNext()), () => iterator.Current, iterator.Dispose);
            }
        }

        private class FakePagedEnumerable : PagedEnumerable<TResponse, TResource>
        {
            private readonly FakeDataSource<TResponse, TResource> _parent;
            private readonly string _initialPageToken;

            public FakePagedEnumerable(FakeDataSource<TResponse, TResource> parent, string initialPageToken)
            {
                _parent = parent;
                _initialPageToken = initialPageToken;
            }

            public override IEnumerable<TResponse> AsRawResponses() => _parent.AsRawResponses(_initialPageToken);

            public override Page<TResource> ReadPage(int pageSize) => _parent.ReadPage(_initialPageToken, pageSize);

            public override IEnumerator<TResource> GetEnumerator() => _parent.GetEnumerator(_initialPageToken);
        }
    }
}
