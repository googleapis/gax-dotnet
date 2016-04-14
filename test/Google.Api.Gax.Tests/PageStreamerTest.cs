/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class PageStreamerTest
    {
        private static readonly PageStreamedResource s_simpleResource = new PageStreamedResource(
            nameof(s_simpleResource),
            new PageStreamingPage { NextPageToken = "x", Items = { 1, 2, 3 } },
            new PageStreamingPage { NextPageToken = "y", Items = { 4, 5 } },
            new PageStreamingPage { NextPageToken = "", Items = { 6, 7 } });

        private static readonly PageStreamedResource s_resourceWithEmptyPages = new PageStreamedResource(
            nameof(s_resourceWithEmptyPages),
            new PageStreamingPage { NextPageToken = "a", Items = { 1, 2, 3 } },
            new PageStreamingPage { NextPageToken = "b" },
            new PageStreamingPage { NextPageToken = "c" },
            new PageStreamingPage { NextPageToken = "d", Items = { 4, 5 } },
            new PageStreamingPage { NextPageToken = "" });

        private static readonly PageStreamedResource s_requestCheckingResource = new PageStreamedResource(
            nameof(s_requestCheckingResource),
            new PageStreamingPage { NextPageToken = "x", Items = { 1, 2, 3 } },
            new PageStreamingPage { NextPageToken = "", Items = { 4, 5 } })
        {
            RequestCheck = "foo"
        };

        public static object[] AllResources { get; } = { new object[] { s_simpleResource }, new object[] { s_resourceWithEmptyPages }, new object[] { s_requestCheckingResource } };

        [Theory, MemberData(nameof(AllResources))]
        public void Fetch(PageStreamedResource resource)
        {
            var actual = PageStreamedResource.PageStreamer.Fetch(
                null, new PageStreamingRequest { Check = resource.RequestCheck }, resource.ApiCall);
            Assert.Equal(resource.AllItems, actual);
        }

        [Theory, MemberData(nameof(AllResources))]
        public async Task FetchAsync(PageStreamedResource resource)
        {
            var asyncSequence = PageStreamedResource.PageStreamer.FetchAsync(
                null, new PageStreamingRequest { Check = resource.RequestCheck }, resource.ApiCall);
            var actual = await asyncSequence.ToList();
            Assert.Equal(resource.AllItems, actual);
        }

        [Fact]
        public async Task Cancellation()
        {
            var cts = new CancellationTokenSource();
            var resource = s_simpleResource;
            var actual = PageStreamedResource.PageStreamer.FetchAsync(
                null, new PageStreamingRequest { Check = resource.RequestCheck }, resource.ApiCall);
            var iterator = actual.GetEnumerator();
            Assert.True(await iterator.MoveNext(cts.Token));
            cts.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await iterator.MoveNext(cts.Token));
        }

        // Has to be public so we can use it as a parameter for test cases
        public class PageStreamedResource
        {
            internal static readonly PageStreamer<int, PageStreamingRequest, PageStreamingPage, string> PageStreamer =
                new PageStreamer<int, PageStreamingRequest, PageStreamingPage, string>(
                    (request, token) => new PageStreamingRequest { Check = request.Check, Token = token },
                    page => page.NextPageToken,
                    page => page.Items,
                    "");

            internal List<PageStreamingPage> Pages { get; } = new List<PageStreamingPage>();
            internal string Name { get; set; }
            internal string RequestCheck { get; set; } = "";

            internal PageStreamedResource(string name, params PageStreamingPage[] pages)
            {
                this.Name = name;
                this.Pages = pages.ToList();
            }

            public override string ToString()
            {
                return Name;
            }

            internal PageStreamingPage GetPage(PageStreamingRequest request, CallSettings callSettings)
            {
                Assert.Equal(RequestCheck, request.Check);
                int index = Pages.FindIndex(page => page.NextPageToken == request.Token);
                // A request for the first page will have the NextPageToken of the last page... so we should always
                // find something.
                Assert.NotEqual(-1, index);
                index = (index + 1) % Pages.Count;
                return Pages[index];
            }

            internal async Task<PageStreamingPage> GetPageAsync(PageStreamingRequest request, CallSettings callSettings)
            {
                callSettings?.CancellationToken?.ThrowIfCancellationRequested();
                await Task.Yield();
                return GetPage(request, callSettings);
            }

            internal ApiCall<PageStreamingRequest, PageStreamingPage> ApiCall =>
                new ApiCall<PageStreamingRequest, PageStreamingPage>(GetPageAsync, GetPage);

            public IEnumerable<int> AllItems => Pages.SelectMany(page => page.Items);
        }
    }
}
