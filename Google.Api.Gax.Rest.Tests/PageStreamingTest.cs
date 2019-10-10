/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Net.Http;
using Google.Apis.Services;
using Google.Apis.Discovery;
using Google.Apis.Requests;

namespace Google.Api.Gax.Rest
{
    public class PageStreamingTest
    {
        private sealed class FakeServer
        {
            internal FakeServer(PagedResource pagedResource, int brokenBy = 0)
            {
                _pagedItems = pagedResource.Resource;
                _brokenBy = brokenBy;
            }

            private readonly int[][] _pagedItems;
            private readonly int _brokenBy;

            internal Task<PageStreamingResponse> MethodAsync(PageStreamingRequest request) =>
                Task.FromResult(MethodSync(request));

            internal PageStreamingResponse MethodSync(PageStreamingRequest request)
            {
                int page = 0;
                int pageOffset = 0;
                if (request.PageToken != null)
                {
                    var pageToken = request.PageToken.Split(':').Select(i => int.Parse(i)).ToArray();
                    page = pageToken[0];
                    pageOffset = pageToken[1];
                }
                var pageItems = _pagedItems.Skip(page).FirstOrDefault();
                if (pageItems == null)
                {
                    return new PageStreamingResponse
                    {
                        Items = null,
                        NextPageToken = null
                    };
                }
                var items = pageItems.Skip(pageOffset).ToArray();
                int itemCount = request.PageSize == 0 ?
                    items.Length : Math.Min(items.Length, request.PageSize + _brokenBy);
                int nextPage = page;
                int nextPageOffset = pageOffset + itemCount;
                if (nextPageOffset >= pageItems.Length)
                {
                    nextPage += 1;
                    nextPageOffset = 0;
                }
                return new PageStreamingResponse
                {
                    Items = items.Take(itemCount),
                    NextPageToken = nextPage >= _pagedItems.Count() ? null : $"{nextPage}:{nextPageOffset}"
                };
            }

            internal RestPagedAsyncEnumerable<PageStreamingRequest, PageStreamingResponse, int> PagedAsync(PageStreamingRequest request) =>
                new RestPagedAsyncEnumerable<PageStreamingRequest, PageStreamingResponse, int>(CreateRequestProvider(request), new PageManager());

            internal RestPagedEnumerable<PageStreamingRequest, PageStreamingResponse, int> PagedSync(PageStreamingRequest request) =>
                new RestPagedEnumerable<PageStreamingRequest, PageStreamingResponse, int>(CreateRequestProvider(request), new PageManager());

            // We can't just return request each time, as otherwise if a PagedEnumerable is used twice,
            // we'll end up reusing the page token.
            private Func<PageStreamingRequest> CreateRequestProvider(PageStreamingRequest request)
                => () => new PageStreamingRequest(request.Server) { PageToken = request.PageToken, PageSize = request.PageSize };

            private class PageManager : IPageManager<PageStreamingRequest, PageStreamingResponse, int>
            {
                public string GetNextPageToken(PageStreamingResponse response) => response.NextPageToken;
                public IEnumerable<int> GetResources(PageStreamingResponse response) => response.Items;
                public void SetPageSize(PageStreamingRequest request, int pageSize) => request.PageSize = pageSize;
                public void SetPageToken(PageStreamingRequest request, string pageToken) => request.PageToken = pageToken;
            }
        }

        public class PagedResource
        {
            public PagedResource(params int[][] resource)
            {
                Resource = resource;
            }

            public int[][] Resource { get; }

            public int[] All => Resource.SelectMany(resources => resources).ToArray();

            public int[][] ToFullPages(int pageSize)
            {
                List<int[]> ret = new List<int[]>();
                IEnumerable<int> values = All;
                while (values.Any())
                {
                    ret.Add(values.Take(pageSize).ToArray());
                    values = values.Skip(pageSize);
                }
                return ret.ToArray();
            }
        }

        private static class MatrixTheoryData
        {
            public static MatrixTheoryData<T1, T2> Create<T1, T2>(
                IEnumerable<T1> data1, IEnumerable<T2> data2) =>
                new MatrixTheoryData<T1, T2>(data1, data2);
        }

        public class MatrixTheoryData<T1, T2> : TheoryData<T1, T2>
        {
            public MatrixTheoryData(IEnumerable<T1> data1, IEnumerable<T2> data2)
            {
                foreach (T1 item1 in data1)
                {
                    foreach (T2 item2 in data2)
                    {
                        Add(item1, item2);
                    }
                }
            }
        }

        private static readonly PagedResource s_resourceA = new PagedResource(
            new[] { 0, 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7 });

        private static readonly PagedResource s_resourceB = new PagedResource(
            new int[0],
            new[] { 0 },
            new int[0],
            new int[0],
            new[] { 1 },
            new int[0]);

        private static readonly PagedResource s_resourceC = new PagedResource();

        public static readonly IEnumerable<object[]> s_naturalPages = new object[][] {
            new [] { s_resourceA }, new[] { s_resourceB } // Not C due to special zero-page behavior
            };

        [Theory, MemberData(nameof(s_naturalPages))]
        public void NaturalPages(PagedResource pagedResource)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest(server) { PageSize = 0 };
            var paged = server.PagedSync(request);
            Assert.Equal(pagedResource.Resource, paged.AsRawResponses().Select(x => x.Items.ToArray()).ToArray());
        }

        [Theory, MemberData(nameof(s_naturalPages))]
        public async Task NaturalPagesAsync(PagedResource pagedResource)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest(server) { PageSize = 0 };
            var paged = server.PagedAsync(request);
            Assert.Equal(pagedResource.Resource, await paged.AsRawResponses().Select(x => x.Items.ToArray()).ToArrayAsync());
        }

        [Fact]
        public void SpecifyPageTokenAtStart()
        {
            var server = new FakeServer(s_resourceA, 1);
            var request = new PageStreamingRequest(server) { PageSize = 0, PageToken = "1:0" };
            var paged = server.PagedSync(request);
            Assert.Equal(s_resourceA.Resource.Skip(1), paged.AsRawResponses().Select(x => x.Items.ToArray()));
        }

        [Fact]
        public async Task SpecifyPageTokenAtStartAsync()
        {
            var server = new FakeServer(s_resourceA, 1);
            var request = new PageStreamingRequest(server) { PageSize = 0, PageToken = "1:0" };
            var paged = server.PagedAsync(request);
            Assert.Equal(s_resourceA.Resource.Skip(1), await paged.AsRawResponses().Select(x => x.Items.ToArray()).ToArrayAsync());
        }

        public static MatrixTheoryData<PagedResource, int> s_flatten = MatrixTheoryData.Create(
            new[] { s_resourceA, s_resourceB, s_resourceC },
            new[] { 0, 1, 2, 3, 4 });

        [Theory, MemberData(nameof(s_flatten))]
        public void Flatten(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest(server) { PageSize = pageSize };
            var paged = server.PagedSync(request);
            Assert.Equal(pagedResource.All, paged);
        }

        [Theory, MemberData(nameof(s_flatten))]
        public async Task FlattenAsync(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest(server) { PageSize = pageSize };
            var paged = server.PagedAsync(request);
            Assert.Equal(pagedResource.All, await paged.ToArrayAsync());
        }

        public static MatrixTheoryData<PagedResource, int> s_fixedPageSize = MatrixTheoryData.Create(
            new[] { s_resourceA, s_resourceB, s_resourceC },
            new[] { 1, 2, 3, 4, 20 });

        [Theory, MemberData(nameof(s_fixedPageSize))]
        public void ReadPage(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            string pageToken = null;
            var actualPages = new List<Page<int>>();
            do
            {
                var request = new PageStreamingRequest(server) { PageSize = pageSize, PageToken = pageToken };
                var paged = server.PagedSync(request);
                actualPages.Add(paged.ReadPage(pageSize));
            } while ((pageToken = actualPages.Last().NextPageToken) != null);
            var expectedPages = pagedResource.ToFullPages(pageSize);
            // Ignore trailing empty pages; we could change the fake server to avoid returning a page
            // token when we've reached (but not gone past) the end.
            Assert.Equal(expectedPages, actualPages.TakeWhile(p => p.Any()).Select(p => p.ToArray()).ToArray());
        }

        [Theory, MemberData(nameof(s_fixedPageSize))]
        public async Task ReadPageAsync(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            string pageToken = null;
            var actualPages = new List<Page<int>>();
            do
            {
                var request = new PageStreamingRequest(server) { PageSize = pageSize, PageToken = pageToken };
                var paged = server.PagedAsync(request);
                actualPages.Add(await paged.ReadPageAsync(pageSize));
            } while ((pageToken = actualPages.Last().NextPageToken) != null);
            var expectedPages = pagedResource.ToFullPages(pageSize);
            // Ignore trailing empty pages; we could change the fake server to avoid returning a page
            // token when we've reached (but not gone past) the end.
            Assert.Equal(expectedPages, actualPages.TakeWhile(p => p.Any()).Select(p => p.ToArray()).ToArray());
        }

        [Fact]
        public void NoData()
        {
            var noDataResource = new PagedResource();
            var server = new FakeServer(noDataResource);
            var request = new PageStreamingRequest(server) { PageSize = 0 };
            var paged = server.PagedSync(request);
            // Natural pages
            Assert.Equal(1, paged.AsRawResponses().Count());
            var page1 = paged.AsRawResponses().First();
            Assert.Null(page1.Items);
            Assert.Null(page1.NextPageToken);
            // Unnatural things
            Assert.Empty(paged);
            Assert.Empty(paged.ReadPage(1));
        }

        [Fact]
        public async Task NoDataAsync()
        {
            var noDataResource = new PagedResource();
            var server = new FakeServer(noDataResource);
            var request = new PageStreamingRequest(server) { PageSize = 0 };
            var paged = server.PagedAsync(request);
            // Natural pages
            Assert.Equal(1, await paged.AsRawResponses().CountAsync());
            var page1 = await paged.AsRawResponses().FirstAsync();
            Assert.Null(page1.Items);
            Assert.Null(page1.NextPageToken);
            // Unnatural things
            Assert.Empty(await paged.ToArrayAsync());
            Assert.Empty(await paged.ReadPageAsync(1));
        }

        [Fact]
        public void BrokenServerFixedSizePaged()
        {
            var server = new FakeServer(s_resourceA, 1);
            var request = new PageStreamingRequest(server) { PageSize = 0 };
            var paged = server.PagedSync(request);
            Assert.Throws<NotSupportedException>(() => paged.ReadPage(1));
        }

        [Fact]
        public async Task BrokenServerFixedSizePagedAsync()
        {
            var server = new FakeServer(s_resourceA, 1);
            var request = new PageStreamingRequest(server) { PageSize = 0 };
            var paged = server.PagedAsync(request);
            await Assert.ThrowsAsync<NotSupportedException>(() => paged.ReadPageAsync(1));
        }

        private class PageStreamingRequest : IClientServiceRequest<PageStreamingResponse>
        {
            public FakeServer Server { get; }
            public string PageToken { get; set; }
            public int PageSize { get; set; }

            internal PageStreamingRequest(FakeServer server)
            {
                Server = server;
            }

            public PageStreamingResponse Execute() => Server.MethodSync(this);
            public Task<PageStreamingResponse> ExecuteAsync() => Server.MethodAsync(this);
            public Task<PageStreamingResponse> ExecuteAsync(CancellationToken token) => Server.MethodAsync(this);

            #region Unimplemented interface methods
            // This is simpler than actually setting up streams and serializing/deserializing...
            public string HttpMethod { get { throw new NotImplementedException(); } }
            public string MethodName { get { throw new NotImplementedException(); } }
            public string RestPath { get { throw new NotImplementedException(); } }
            public IDictionary<string, IParameter> RequestParameters { get { throw new NotImplementedException(); } }
            public IClientService Service { get { throw new NotImplementedException(); } }


            public HttpRequestMessage CreateRequest(bool? overrideGZipEnabled = default(bool?))
            {
                throw new NotImplementedException();
            }

            public Task<Stream> ExecuteAsStreamAsync()
            {
                throw new NotImplementedException();
            }

            public Task<Stream> ExecuteAsStreamAsync(CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public Stream ExecuteAsStream()
            {
                throw new NotImplementedException();
            }
            #endregion
        }

        private class PageStreamingResponse
        {
            public IEnumerable<int> Items { get; set; }
            public string NextPageToken { get; set; }
        }
    }
}
