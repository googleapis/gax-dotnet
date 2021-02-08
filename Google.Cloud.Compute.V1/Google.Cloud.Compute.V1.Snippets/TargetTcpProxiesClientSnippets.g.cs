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
    public sealed class GeneratedTargetTcpProxiesClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteTargetTcpProxyRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            DeleteTargetTcpProxyRequest request = new DeleteTargetTcpProxyRequest
            {
                RequestId = "",
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            Operation response = targetTcpProxiesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteTargetTcpProxyRequest, CallSettings)
            // Additional: DeleteAsync(DeleteTargetTcpProxyRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteTargetTcpProxyRequest request = new DeleteTargetTcpProxyRequest
            {
                RequestId = "",
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            Operation response = await targetTcpProxiesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            // Make the request
            Operation response = targetTcpProxiesClient.Delete(project, targetTcpProxy);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, CallSettings)
            // Additional: DeleteAsync(string, string, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            // Make the request
            Operation response = await targetTcpProxiesClient.DeleteAsync(project, targetTcpProxy);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetTargetTcpProxyRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            GetTargetTcpProxyRequest request = new GetTargetTcpProxyRequest
            {
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            TargetTcpProxy response = targetTcpProxiesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetTargetTcpProxyRequest, CallSettings)
            // Additional: GetAsync(GetTargetTcpProxyRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            GetTargetTcpProxyRequest request = new GetTargetTcpProxyRequest
            {
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            TargetTcpProxy response = await targetTcpProxiesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            // Make the request
            TargetTcpProxy response = targetTcpProxiesClient.Get(project, targetTcpProxy);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, CallSettings)
            // Additional: GetAsync(string, string, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            // Make the request
            TargetTcpProxy response = await targetTcpProxiesClient.GetAsync(project, targetTcpProxy);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertTargetTcpProxyRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            InsertTargetTcpProxyRequest request = new InsertTargetTcpProxyRequest
            {
                RequestId = "",
                TargetTcpProxyResource = new TargetTcpProxy(),
                Project = "",
            };
            // Make the request
            Operation response = targetTcpProxiesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertTargetTcpProxyRequest, CallSettings)
            // Additional: InsertAsync(InsertTargetTcpProxyRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            InsertTargetTcpProxyRequest request = new InsertTargetTcpProxyRequest
            {
                RequestId = "",
                TargetTcpProxyResource = new TargetTcpProxy(),
                Project = "",
            };
            // Make the request
            Operation response = await targetTcpProxiesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, TargetTcpProxy, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            TargetTcpProxy targetTcpProxyResource = new TargetTcpProxy();
            // Make the request
            Operation response = targetTcpProxiesClient.Insert(project, targetTcpProxyResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, TargetTcpProxy, CallSettings)
            // Additional: InsertAsync(string, TargetTcpProxy, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            TargetTcpProxy targetTcpProxyResource = new TargetTcpProxy();
            // Make the request
            Operation response = await targetTcpProxiesClient.InsertAsync(project, targetTcpProxyResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListTargetTcpProxiesRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            ListTargetTcpProxiesRequest request = new ListTargetTcpProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetTcpProxyList response = targetTcpProxiesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListTargetTcpProxiesRequest, CallSettings)
            // Additional: ListAsync(ListTargetTcpProxiesRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            ListTargetTcpProxiesRequest request = new ListTargetTcpProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetTcpProxyList response = await targetTcpProxiesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetTcpProxyList response = targetTcpProxiesClient.List(project);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, CallSettings)
            // Additional: ListAsync(string, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetTcpProxyList response = await targetTcpProxiesClient.ListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for SetBackendService</summary>
        public void SetBackendServiceRequestObject()
        {
            // Snippet: SetBackendService(SetBackendServiceTargetTcpProxyRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            SetBackendServiceTargetTcpProxyRequest request = new SetBackendServiceTargetTcpProxyRequest
            {
                TargetTcpProxiesSetBackendServiceRequestResource = new TargetTcpProxiesSetBackendServiceRequest(),
                RequestId = "",
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            Operation response = targetTcpProxiesClient.SetBackendService(request);
            // End snippet
        }

        /// <summary>Snippet for SetBackendServiceAsync</summary>
        public async Task SetBackendServiceRequestObjectAsync()
        {
            // Snippet: SetBackendServiceAsync(SetBackendServiceTargetTcpProxyRequest, CallSettings)
            // Additional: SetBackendServiceAsync(SetBackendServiceTargetTcpProxyRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetBackendServiceTargetTcpProxyRequest request = new SetBackendServiceTargetTcpProxyRequest
            {
                TargetTcpProxiesSetBackendServiceRequestResource = new TargetTcpProxiesSetBackendServiceRequest(),
                RequestId = "",
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            Operation response = await targetTcpProxiesClient.SetBackendServiceAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetBackendService</summary>
        public void SetBackendService()
        {
            // Snippet: SetBackendService(string, string, TargetTcpProxiesSetBackendServiceRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            TargetTcpProxiesSetBackendServiceRequest targetTcpProxiesSetBackendServiceRequestResource = new TargetTcpProxiesSetBackendServiceRequest();
            // Make the request
            Operation response = targetTcpProxiesClient.SetBackendService(project, targetTcpProxy, targetTcpProxiesSetBackendServiceRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetBackendServiceAsync</summary>
        public async Task SetBackendServiceAsync()
        {
            // Snippet: SetBackendServiceAsync(string, string, TargetTcpProxiesSetBackendServiceRequest, CallSettings)
            // Additional: SetBackendServiceAsync(string, string, TargetTcpProxiesSetBackendServiceRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            TargetTcpProxiesSetBackendServiceRequest targetTcpProxiesSetBackendServiceRequestResource = new TargetTcpProxiesSetBackendServiceRequest();
            // Make the request
            Operation response = await targetTcpProxiesClient.SetBackendServiceAsync(project, targetTcpProxy, targetTcpProxiesSetBackendServiceRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetProxyHeader</summary>
        public void SetProxyHeaderRequestObject()
        {
            // Snippet: SetProxyHeader(SetProxyHeaderTargetTcpProxyRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            SetProxyHeaderTargetTcpProxyRequest request = new SetProxyHeaderTargetTcpProxyRequest
            {
                RequestId = "",
                TargetTcpProxiesSetProxyHeaderRequestResource = new TargetTcpProxiesSetProxyHeaderRequest(),
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            Operation response = targetTcpProxiesClient.SetProxyHeader(request);
            // End snippet
        }

        /// <summary>Snippet for SetProxyHeaderAsync</summary>
        public async Task SetProxyHeaderRequestObjectAsync()
        {
            // Snippet: SetProxyHeaderAsync(SetProxyHeaderTargetTcpProxyRequest, CallSettings)
            // Additional: SetProxyHeaderAsync(SetProxyHeaderTargetTcpProxyRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetProxyHeaderTargetTcpProxyRequest request = new SetProxyHeaderTargetTcpProxyRequest
            {
                RequestId = "",
                TargetTcpProxiesSetProxyHeaderRequestResource = new TargetTcpProxiesSetProxyHeaderRequest(),
                Project = "",
                TargetTcpProxy = "",
            };
            // Make the request
            Operation response = await targetTcpProxiesClient.SetProxyHeaderAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetProxyHeader</summary>
        public void SetProxyHeader()
        {
            // Snippet: SetProxyHeader(string, string, TargetTcpProxiesSetProxyHeaderRequest, CallSettings)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = TargetTcpProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            TargetTcpProxiesSetProxyHeaderRequest targetTcpProxiesSetProxyHeaderRequestResource = new TargetTcpProxiesSetProxyHeaderRequest();
            // Make the request
            Operation response = targetTcpProxiesClient.SetProxyHeader(project, targetTcpProxy, targetTcpProxiesSetProxyHeaderRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetProxyHeaderAsync</summary>
        public async Task SetProxyHeaderAsync()
        {
            // Snippet: SetProxyHeaderAsync(string, string, TargetTcpProxiesSetProxyHeaderRequest, CallSettings)
            // Additional: SetProxyHeaderAsync(string, string, TargetTcpProxiesSetProxyHeaderRequest, CancellationToken)
            // Create client
            TargetTcpProxiesClient targetTcpProxiesClient = await TargetTcpProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetTcpProxy = "";
            TargetTcpProxiesSetProxyHeaderRequest targetTcpProxiesSetProxyHeaderRequestResource = new TargetTcpProxiesSetProxyHeaderRequest();
            // Make the request
            Operation response = await targetTcpProxiesClient.SetProxyHeaderAsync(project, targetTcpProxy, targetTcpProxiesSetProxyHeaderRequestResource);
            // End snippet
        }
    }
}
