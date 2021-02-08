// Copyright 2021 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

namespace Google.Cloud.Compute.V1.Snippets
{
    using System.Threading.Tasks;

    /// <summary>Generated snippets.</summary>
    public sealed class GeneratedRegionTargetHttpsProxiesClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteRegionTargetHttpsProxyRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            DeleteRegionTargetHttpsProxyRequest request = new DeleteRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteRegionTargetHttpsProxyRequest, CallSettings)
            // Additional: DeleteAsync(DeleteRegionTargetHttpsProxyRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteRegionTargetHttpsProxyRequest request = new DeleteRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.Delete(project, region, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.DeleteAsync(project, region, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetRegionTargetHttpsProxyRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            GetRegionTargetHttpsProxyRequest request = new GetRegionTargetHttpsProxyRequest
            {
                TargetHttpsProxy = "",
                Region = "",
                Project = "",
            };
            // Make the request
            TargetHttpsProxy response = regionTargetHttpsProxiesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetRegionTargetHttpsProxyRequest, CallSettings)
            // Additional: GetAsync(GetRegionTargetHttpsProxyRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            GetRegionTargetHttpsProxyRequest request = new GetRegionTargetHttpsProxyRequest
            {
                TargetHttpsProxy = "",
                Region = "",
                Project = "",
            };
            // Make the request
            TargetHttpsProxy response = await regionTargetHttpsProxiesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            // Make the request
            TargetHttpsProxy response = regionTargetHttpsProxiesClient.Get(project, region, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            // Make the request
            TargetHttpsProxy response = await regionTargetHttpsProxiesClient.GetAsync(project, region, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertRegionTargetHttpsProxyRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            InsertRegionTargetHttpsProxyRequest request = new InsertRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                Region = "",
                TargetHttpsProxyResource = new TargetHttpsProxy(),
                Project = "",
            };
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertRegionTargetHttpsProxyRequest, CallSettings)
            // Additional: InsertAsync(InsertRegionTargetHttpsProxyRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            InsertRegionTargetHttpsProxyRequest request = new InsertRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                Region = "",
                TargetHttpsProxyResource = new TargetHttpsProxy(),
                Project = "",
            };
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, TargetHttpsProxy, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            TargetHttpsProxy targetHttpsProxyResource = new TargetHttpsProxy();
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.Insert(project, region, targetHttpsProxyResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, TargetHttpsProxy, CallSettings)
            // Additional: InsertAsync(string, string, TargetHttpsProxy, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            TargetHttpsProxy targetHttpsProxyResource = new TargetHttpsProxy();
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.InsertAsync(project, region, targetHttpsProxyResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListRegionTargetHttpsProxiesRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            ListRegionTargetHttpsProxiesRequest request = new ListRegionTargetHttpsProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                Region = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpsProxyList response = regionTargetHttpsProxiesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListRegionTargetHttpsProxiesRequest, CallSettings)
            // Additional: ListAsync(ListRegionTargetHttpsProxiesRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            ListRegionTargetHttpsProxiesRequest request = new ListRegionTargetHttpsProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                Region = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpsProxyList response = await regionTargetHttpsProxiesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            TargetHttpsProxyList response = regionTargetHttpsProxiesClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            TargetHttpsProxyList response = await regionTargetHttpsProxiesClient.ListAsync(project, region);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificates</summary>
        public void SetSslCertificatesRequestObject()
        {
            // Snippet: SetSslCertificates(SetSslCertificatesRegionTargetHttpsProxyRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            SetSslCertificatesRegionTargetHttpsProxyRequest request = new SetSslCertificatesRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                RegionTargetHttpsProxiesSetSslCertificatesRequestResource = new RegionTargetHttpsProxiesSetSslCertificatesRequest(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.SetSslCertificates(request);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificatesAsync</summary>
        public async Task SetSslCertificatesRequestObjectAsync()
        {
            // Snippet: SetSslCertificatesAsync(SetSslCertificatesRegionTargetHttpsProxyRequest, CallSettings)
            // Additional: SetSslCertificatesAsync(SetSslCertificatesRegionTargetHttpsProxyRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetSslCertificatesRegionTargetHttpsProxyRequest request = new SetSslCertificatesRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                RegionTargetHttpsProxiesSetSslCertificatesRequestResource = new RegionTargetHttpsProxiesSetSslCertificatesRequest(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.SetSslCertificatesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificates</summary>
        public void SetSslCertificates()
        {
            // Snippet: SetSslCertificates(string, string, string, RegionTargetHttpsProxiesSetSslCertificatesRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            RegionTargetHttpsProxiesSetSslCertificatesRequest regionTargetHttpsProxiesSetSslCertificatesRequestResource = new RegionTargetHttpsProxiesSetSslCertificatesRequest();
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.SetSslCertificates(project, region, targetHttpsProxy, regionTargetHttpsProxiesSetSslCertificatesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificatesAsync</summary>
        public async Task SetSslCertificatesAsync()
        {
            // Snippet: SetSslCertificatesAsync(string, string, string, RegionTargetHttpsProxiesSetSslCertificatesRequest, CallSettings)
            // Additional: SetSslCertificatesAsync(string, string, string, RegionTargetHttpsProxiesSetSslCertificatesRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            RegionTargetHttpsProxiesSetSslCertificatesRequest regionTargetHttpsProxiesSetSslCertificatesRequestResource = new RegionTargetHttpsProxiesSetSslCertificatesRequest();
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.SetSslCertificatesAsync(project, region, targetHttpsProxy, regionTargetHttpsProxiesSetSslCertificatesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMap</summary>
        public void SetUrlMapRequestObject()
        {
            // Snippet: SetUrlMap(SetUrlMapRegionTargetHttpsProxyRequest, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            SetUrlMapRegionTargetHttpsProxyRequest request = new SetUrlMapRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                UrlMapReferenceResource = new UrlMapReference(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.SetUrlMap(request);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMapAsync</summary>
        public async Task SetUrlMapRequestObjectAsync()
        {
            // Snippet: SetUrlMapAsync(SetUrlMapRegionTargetHttpsProxyRequest, CallSettings)
            // Additional: SetUrlMapAsync(SetUrlMapRegionTargetHttpsProxyRequest, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetUrlMapRegionTargetHttpsProxyRequest request = new SetUrlMapRegionTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                UrlMapReferenceResource = new UrlMapReference(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.SetUrlMapAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMap</summary>
        public void SetUrlMap()
        {
            // Snippet: SetUrlMap(string, string, string, UrlMapReference, CallSettings)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = RegionTargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            UrlMapReference urlMapReferenceResource = new UrlMapReference();
            // Make the request
            Operation response = regionTargetHttpsProxiesClient.SetUrlMap(project, region, targetHttpsProxy, urlMapReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMapAsync</summary>
        public async Task SetUrlMapAsync()
        {
            // Snippet: SetUrlMapAsync(string, string, string, UrlMapReference, CallSettings)
            // Additional: SetUrlMapAsync(string, string, string, UrlMapReference, CancellationToken)
            // Create client
            RegionTargetHttpsProxiesClient regionTargetHttpsProxiesClient = await RegionTargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string targetHttpsProxy = "";
            UrlMapReference urlMapReferenceResource = new UrlMapReference();
            // Make the request
            Operation response = await regionTargetHttpsProxiesClient.SetUrlMapAsync(project, region, targetHttpsProxy, urlMapReferenceResource);
            // End snippet
        }
    }
}
