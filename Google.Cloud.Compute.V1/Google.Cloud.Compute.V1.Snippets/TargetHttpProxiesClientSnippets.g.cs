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
    public sealed class GeneratedTargetHttpProxiesClientSnippets
    {
        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedListRequestObject()
        {
            // Snippet: AggregatedList(AggregatedListTargetHttpProxiesRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            AggregatedListTargetHttpProxiesRequest request = new AggregatedListTargetHttpProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                IncludeAllScopes = false,
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpProxyAggregatedList response = targetHttpProxiesClient.AggregatedList(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListRequestObjectAsync()
        {
            // Snippet: AggregatedListAsync(AggregatedListTargetHttpProxiesRequest, CallSettings)
            // Additional: AggregatedListAsync(AggregatedListTargetHttpProxiesRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            AggregatedListTargetHttpProxiesRequest request = new AggregatedListTargetHttpProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                IncludeAllScopes = false,
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpProxyAggregatedList response = await targetHttpProxiesClient.AggregatedListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedList()
        {
            // Snippet: AggregatedList(string, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpProxyAggregatedList response = targetHttpProxiesClient.AggregatedList(project);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListAsync()
        {
            // Snippet: AggregatedListAsync(string, CallSettings)
            // Additional: AggregatedListAsync(string, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpProxyAggregatedList response = await targetHttpProxiesClient.AggregatedListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteTargetHttpProxyRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            DeleteTargetHttpProxyRequest request = new DeleteTargetHttpProxyRequest
            {
                RequestId = "",
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = targetHttpProxiesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteTargetHttpProxyRequest, CallSettings)
            // Additional: DeleteAsync(DeleteTargetHttpProxyRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteTargetHttpProxyRequest request = new DeleteTargetHttpProxyRequest
            {
                RequestId = "",
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpProxiesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            // Make the request
            Operation response = targetHttpProxiesClient.Delete(project, targetHttpProxy);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, CallSettings)
            // Additional: DeleteAsync(string, string, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            // Make the request
            Operation response = await targetHttpProxiesClient.DeleteAsync(project, targetHttpProxy);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetTargetHttpProxyRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            GetTargetHttpProxyRequest request = new GetTargetHttpProxyRequest
            {
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            TargetHttpProxy response = targetHttpProxiesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetTargetHttpProxyRequest, CallSettings)
            // Additional: GetAsync(GetTargetHttpProxyRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            GetTargetHttpProxyRequest request = new GetTargetHttpProxyRequest
            {
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            TargetHttpProxy response = await targetHttpProxiesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            // Make the request
            TargetHttpProxy response = targetHttpProxiesClient.Get(project, targetHttpProxy);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, CallSettings)
            // Additional: GetAsync(string, string, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            // Make the request
            TargetHttpProxy response = await targetHttpProxiesClient.GetAsync(project, targetHttpProxy);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertTargetHttpProxyRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            InsertTargetHttpProxyRequest request = new InsertTargetHttpProxyRequest
            {
                TargetHttpProxyResource = new TargetHttpProxy(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = targetHttpProxiesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertTargetHttpProxyRequest, CallSettings)
            // Additional: InsertAsync(InsertTargetHttpProxyRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            InsertTargetHttpProxyRequest request = new InsertTargetHttpProxyRequest
            {
                TargetHttpProxyResource = new TargetHttpProxy(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpProxiesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, TargetHttpProxy, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            TargetHttpProxy targetHttpProxyResource = new TargetHttpProxy();
            // Make the request
            Operation response = targetHttpProxiesClient.Insert(project, targetHttpProxyResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, TargetHttpProxy, CallSettings)
            // Additional: InsertAsync(string, TargetHttpProxy, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            TargetHttpProxy targetHttpProxyResource = new TargetHttpProxy();
            // Make the request
            Operation response = await targetHttpProxiesClient.InsertAsync(project, targetHttpProxyResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListTargetHttpProxiesRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            ListTargetHttpProxiesRequest request = new ListTargetHttpProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpProxyList response = targetHttpProxiesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListTargetHttpProxiesRequest, CallSettings)
            // Additional: ListAsync(ListTargetHttpProxiesRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            ListTargetHttpProxiesRequest request = new ListTargetHttpProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpProxyList response = await targetHttpProxiesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpProxyList response = targetHttpProxiesClient.List(project);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, CallSettings)
            // Additional: ListAsync(string, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpProxyList response = await targetHttpProxiesClient.ListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchTargetHttpProxyRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            PatchTargetHttpProxyRequest request = new PatchTargetHttpProxyRequest
            {
                TargetHttpProxyResource = new TargetHttpProxy(),
                RequestId = "",
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = targetHttpProxiesClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchTargetHttpProxyRequest, CallSettings)
            // Additional: PatchAsync(PatchTargetHttpProxyRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            PatchTargetHttpProxyRequest request = new PatchTargetHttpProxyRequest
            {
                TargetHttpProxyResource = new TargetHttpProxy(),
                RequestId = "",
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpProxiesClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, TargetHttpProxy, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            TargetHttpProxy targetHttpProxyResource = new TargetHttpProxy();
            // Make the request
            Operation response = targetHttpProxiesClient.Patch(project, targetHttpProxy, targetHttpProxyResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, TargetHttpProxy, CallSettings)
            // Additional: PatchAsync(string, string, TargetHttpProxy, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            TargetHttpProxy targetHttpProxyResource = new TargetHttpProxy();
            // Make the request
            Operation response = await targetHttpProxiesClient.PatchAsync(project, targetHttpProxy, targetHttpProxyResource);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMap</summary>
        public void SetUrlMapRequestObject()
        {
            // Snippet: SetUrlMap(SetUrlMapTargetHttpProxyRequest, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            SetUrlMapTargetHttpProxyRequest request = new SetUrlMapTargetHttpProxyRequest
            {
                RequestId = "",
                UrlMapReferenceResource = new UrlMapReference(),
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = targetHttpProxiesClient.SetUrlMap(request);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMapAsync</summary>
        public async Task SetUrlMapRequestObjectAsync()
        {
            // Snippet: SetUrlMapAsync(SetUrlMapTargetHttpProxyRequest, CallSettings)
            // Additional: SetUrlMapAsync(SetUrlMapTargetHttpProxyRequest, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetUrlMapTargetHttpProxyRequest request = new SetUrlMapTargetHttpProxyRequest
            {
                RequestId = "",
                UrlMapReferenceResource = new UrlMapReference(),
                TargetHttpProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpProxiesClient.SetUrlMapAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMap</summary>
        public void SetUrlMap()
        {
            // Snippet: SetUrlMap(string, string, UrlMapReference, CallSettings)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = TargetHttpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            UrlMapReference urlMapReferenceResource = new UrlMapReference();
            // Make the request
            Operation response = targetHttpProxiesClient.SetUrlMap(project, targetHttpProxy, urlMapReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMapAsync</summary>
        public async Task SetUrlMapAsync()
        {
            // Snippet: SetUrlMapAsync(string, string, UrlMapReference, CallSettings)
            // Additional: SetUrlMapAsync(string, string, UrlMapReference, CancellationToken)
            // Create client
            TargetHttpProxiesClient targetHttpProxiesClient = await TargetHttpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpProxy = "";
            UrlMapReference urlMapReferenceResource = new UrlMapReference();
            // Make the request
            Operation response = await targetHttpProxiesClient.SetUrlMapAsync(project, targetHttpProxy, urlMapReferenceResource);
            // End snippet
        }
    }
}
