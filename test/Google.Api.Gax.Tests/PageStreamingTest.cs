/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class PageStreamingTest
    {
        private class FakeServer
        {
            internal FakeServer(PagedResource pagedResource, int brokenBy = 0)
            {
                _pagedItems = pagedResource.Resource;
                _brokenBy = brokenBy;
            }

            private readonly int[][] _pagedItems;
            private readonly int _brokenBy;

            internal Task<PageStreamingResponse> MethodAsync(
                PageStreamingRequest request, CallSettings callSettings) =>
                Task.FromResult(MethodSync(request, callSettings));

            internal PageStreamingResponse MethodSync(
                PageStreamingRequest request, CallSettings callSettings)
            {
                int page = 0;
                int pageOffset = 0;
                if (request.PageToken != "")
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
                        Items = { },
                        NextPageToken = ""
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
                    Items = { items.Take(itemCount) },
                    NextPageToken = nextPage >= _pagedItems.Count() ? "" : $"{nextPage}:{nextPageOffset}"
                };
            }

            internal PagedAsyncEnumerable<PageStreamingRequest, PageStreamingResponse, int> PagedAsync(
                CallSettings baseCallSettings, CallSettings perCallCallSettings, PageStreamingRequest request)
            {
                var apiCall = new ApiCall<PageStreamingRequest, PageStreamingResponse>(
                    MethodAsync, MethodSync, baseCallSettings);
                return new PagedAsyncEnumerable<PageStreamingRequest, PageStreamingResponse, int>(
                    apiCall, request, perCallCallSettings);
            }

            internal PagedEnumerable<PageStreamingRequest, PageStreamingResponse, int> PagedSync(
                CallSettings baseCallSettings, CallSettings perCallCallSettings, PageStreamingRequest request)
            {
                var apiCall = new ApiCall<PageStreamingRequest, PageStreamingResponse>(
                    MethodAsync, MethodSync, baseCallSettings);
                return new PagedEnumerable<PageStreamingRequest, PageStreamingResponse, int>(
                    apiCall, request, perCallCallSettings);
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

            public int[][] Fixed(int pageSize)
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

        public static readonly object[] s_naturalPages = new object[] {
            new [] { s_resourceA }, new[] { s_resourceB } // Not C due to special zero-page behavior
            };

        [Theory, MemberData(nameof(s_naturalPages))]
        public void NaturalPages(PagedResource pagedResource)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest { PageSize = 0 };
            var paged = server.PagedSync(new CallSettings(), null, request);
            Assert.Equal(pagedResource.Resource, paged.Select(x => x.ToArray()).ToArray());
        }

        [Theory, MemberData(nameof(s_naturalPages))]
        public async Task NaturalPagesAsync(PagedResource pagedResource)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest { PageSize = 0 };
            var paged = server.PagedAsync(new CallSettings(), null, request);
            Assert.Equal(pagedResource.Resource, await paged.Select(x => x.ToArray()).ToArray());
        }

        public static MatrixTheoryData<PagedResource, int> s_flatten = MatrixTheoryData.Create(
            new[] { s_resourceA, s_resourceB, s_resourceC },
            new[] { 0, 1, 2, 3, 4 });

        [Theory, MemberData(nameof(s_flatten))]
        public void Flatten(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest { PageSize = pageSize };
            var paged = server.PagedSync(new CallSettings(), null, request);
            Assert.Equal(pagedResource.All, paged.Flatten());
        }

        [Theory, MemberData(nameof(s_flatten))]
        public async Task FlattenAsync(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest { PageSize = pageSize };
            var paged = server.PagedAsync(new CallSettings(), null, request);
            Assert.Equal(pagedResource.All, await paged.Flatten().ToArray());
        }

        public static MatrixTheoryData<PagedResource, int> s_fixedPageSize = MatrixTheoryData.Create(
            new[] { s_resourceA, s_resourceB, s_resourceC },
            new[] { 1, 2, 3, 4, 20 });

        [Theory, MemberData(nameof(s_fixedPageSize))]
        public void FixedPageSize(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest { PageSize = pageSize };
            var paged = server.PagedSync(new CallSettings(), null, request);
            var fixedSizePages = paged.WithFixedPageSize(pageSize).Select(page => page.ToArray()).ToArray();
            var expectedPages = pagedResource.Fixed(pageSize);
            Assert.Equal(expectedPages, fixedSizePages);
        }

        [Theory, MemberData(nameof(s_fixedPageSize))]
        public async Task FixedPageSizeAsync(PagedResource pagedResource, int pageSize)
        {
            var server = new FakeServer(pagedResource);
            var request = new PageStreamingRequest { PageSize = pageSize };
            var paged = server.PagedAsync(new CallSettings(), null, request);
            var fixedSizePages = await paged.WithFixedPageSize(pageSize).Select(page => page.ToArray()).ToArray();
            var expectedPages = pagedResource.Fixed(pageSize);
            Assert.Equal(expectedPages, fixedSizePages);
        }

        [Fact]
        public void NoData()
        {
            var noDataResource = new PagedResource();
            var server = new FakeServer(noDataResource);
            var request = new PageStreamingRequest { PageSize = 0 };
            var paged = server.PagedSync(new CallSettings(), null, request);
            // Natural pages
            Assert.Equal(1, paged.Count());
            var page1 = paged.First();
            Assert.Empty(page1);
            Assert.Equal("", page1.NextPageToken);
            // Unnatural things
            Assert.Empty(paged.Flatten());
            Assert.Empty(paged.WithFixedPageSize(1));
        }

        [Fact]
        public async Task NoDataAsync()
        {
            var noDataResource = new PagedResource();
            var server = new FakeServer(noDataResource);
            var request = new PageStreamingRequest { PageSize = 0 };
            var paged = server.PagedAsync(new CallSettings(), null, request);
            // Natural pages
            Assert.Equal(1, await paged.Count());
            var page1 = await paged.First();
            Assert.Empty(page1);
            Assert.Equal("", page1.NextPageToken);
            // Unnatural things
            Assert.Empty(await paged.Flatten().ToArray());
            Assert.Empty(await paged.WithFixedPageSize(1).ToArray());
        }

        [Fact]
        public void BrokenServerFixedSizePaged()
        {
            var server = new FakeServer(s_resourceA, 1);
            var request = new PageStreamingRequest { PageSize = 0 };
            var paged = server.PagedSync(new CallSettings(), null, request);
            var fixedSize = paged.WithFixedPageSize(1);
            Assert.Throws<NotSupportedException>(() => fixedSize.First());
        }

        [Fact]
        public async Task BrokenServerFixedSizePagedAsync()
        {
            var server = new FakeServer(s_resourceA, 1);
            var request = new PageStreamingRequest { PageSize = 0 };
            var paged = server.PagedAsync(new CallSettings(), null, request);
            var fixedSize = paged.WithFixedPageSize(1);
            var ex = await Record.ExceptionAsync(() => fixedSize.First());
            Assert.IsType<NotSupportedException>(ex.InnerException);
        }
    }
}
