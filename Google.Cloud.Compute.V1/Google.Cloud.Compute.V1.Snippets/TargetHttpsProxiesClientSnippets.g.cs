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
    public sealed class GeneratedTargetHttpsProxiesClientSnippets
    {
        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedListRequestObject()
        {
            // Snippet: AggregatedList(AggregatedListTargetHttpsProxiesRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            AggregatedListTargetHttpsProxiesRequest request = new AggregatedListTargetHttpsProxiesRequest
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
            TargetHttpsProxyAggregatedList response = targetHttpsProxiesClient.AggregatedList(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListRequestObjectAsync()
        {
            // Snippet: AggregatedListAsync(AggregatedListTargetHttpsProxiesRequest, CallSettings)
            // Additional: AggregatedListAsync(AggregatedListTargetHttpsProxiesRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            AggregatedListTargetHttpsProxiesRequest request = new AggregatedListTargetHttpsProxiesRequest
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
            TargetHttpsProxyAggregatedList response = await targetHttpsProxiesClient.AggregatedListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedList()
        {
            // Snippet: AggregatedList(string, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpsProxyAggregatedList response = targetHttpsProxiesClient.AggregatedList(project);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListAsync()
        {
            // Snippet: AggregatedListAsync(string, CallSettings)
            // Additional: AggregatedListAsync(string, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpsProxyAggregatedList response = await targetHttpsProxiesClient.AggregatedListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            DeleteTargetHttpsProxyRequest request = new DeleteTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = targetHttpsProxiesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteTargetHttpsProxyRequest, CallSettings)
            // Additional: DeleteAsync(DeleteTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteTargetHttpsProxyRequest request = new DeleteTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpsProxiesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            // Make the request
            Operation response = targetHttpsProxiesClient.Delete(project, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, CallSettings)
            // Additional: DeleteAsync(string, string, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            // Make the request
            Operation response = await targetHttpsProxiesClient.DeleteAsync(project, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            GetTargetHttpsProxyRequest request = new GetTargetHttpsProxyRequest
            {
                TargetHttpsProxy = "",
                Project = "",
            };
            // Make the request
            TargetHttpsProxy response = targetHttpsProxiesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetTargetHttpsProxyRequest, CallSettings)
            // Additional: GetAsync(GetTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            GetTargetHttpsProxyRequest request = new GetTargetHttpsProxyRequest
            {
                TargetHttpsProxy = "",
                Project = "",
            };
            // Make the request
            TargetHttpsProxy response = await targetHttpsProxiesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            // Make the request
            TargetHttpsProxy response = targetHttpsProxiesClient.Get(project, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, CallSettings)
            // Additional: GetAsync(string, string, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            // Make the request
            TargetHttpsProxy response = await targetHttpsProxiesClient.GetAsync(project, targetHttpsProxy);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            InsertTargetHttpsProxyRequest request = new InsertTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxyResource = new TargetHttpsProxy(),
                Project = "",
            };
            // Make the request
            Operation response = targetHttpsProxiesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertTargetHttpsProxyRequest, CallSettings)
            // Additional: InsertAsync(InsertTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            InsertTargetHttpsProxyRequest request = new InsertTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxyResource = new TargetHttpsProxy(),
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpsProxiesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, TargetHttpsProxy, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            TargetHttpsProxy targetHttpsProxyResource = new TargetHttpsProxy();
            // Make the request
            Operation response = targetHttpsProxiesClient.Insert(project, targetHttpsProxyResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, TargetHttpsProxy, CallSettings)
            // Additional: InsertAsync(string, TargetHttpsProxy, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            TargetHttpsProxy targetHttpsProxyResource = new TargetHttpsProxy();
            // Make the request
            Operation response = await targetHttpsProxiesClient.InsertAsync(project, targetHttpsProxyResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListTargetHttpsProxiesRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            ListTargetHttpsProxiesRequest request = new ListTargetHttpsProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpsProxyList response = targetHttpsProxiesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListTargetHttpsProxiesRequest, CallSettings)
            // Additional: ListAsync(ListTargetHttpsProxiesRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            ListTargetHttpsProxiesRequest request = new ListTargetHttpsProxiesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            TargetHttpsProxyList response = await targetHttpsProxiesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpsProxyList response = targetHttpsProxiesClient.List(project);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, CallSettings)
            // Additional: ListAsync(string, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            TargetHttpsProxyList response = await targetHttpsProxiesClient.ListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for SetQuicOverride</summary>
        public void SetQuicOverrideRequestObject()
        {
            // Snippet: SetQuicOverride(SetQuicOverrideTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            SetQuicOverrideTargetHttpsProxyRequest request = new SetQuicOverrideTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                TargetHttpsProxiesSetQuicOverrideRequestResource = new TargetHttpsProxiesSetQuicOverrideRequest(),
                Project = "",
            };
            // Make the request
            Operation response = targetHttpsProxiesClient.SetQuicOverride(request);
            // End snippet
        }

        /// <summary>Snippet for SetQuicOverrideAsync</summary>
        public async Task SetQuicOverrideRequestObjectAsync()
        {
            // Snippet: SetQuicOverrideAsync(SetQuicOverrideTargetHttpsProxyRequest, CallSettings)
            // Additional: SetQuicOverrideAsync(SetQuicOverrideTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetQuicOverrideTargetHttpsProxyRequest request = new SetQuicOverrideTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                TargetHttpsProxiesSetQuicOverrideRequestResource = new TargetHttpsProxiesSetQuicOverrideRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetQuicOverrideAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetQuicOverride</summary>
        public void SetQuicOverride()
        {
            // Snippet: SetQuicOverride(string, string, TargetHttpsProxiesSetQuicOverrideRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            TargetHttpsProxiesSetQuicOverrideRequest targetHttpsProxiesSetQuicOverrideRequestResource = new TargetHttpsProxiesSetQuicOverrideRequest();
            // Make the request
            Operation response = targetHttpsProxiesClient.SetQuicOverride(project, targetHttpsProxy, targetHttpsProxiesSetQuicOverrideRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetQuicOverrideAsync</summary>
        public async Task SetQuicOverrideAsync()
        {
            // Snippet: SetQuicOverrideAsync(string, string, TargetHttpsProxiesSetQuicOverrideRequest, CallSettings)
            // Additional: SetQuicOverrideAsync(string, string, TargetHttpsProxiesSetQuicOverrideRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            TargetHttpsProxiesSetQuicOverrideRequest targetHttpsProxiesSetQuicOverrideRequestResource = new TargetHttpsProxiesSetQuicOverrideRequest();
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetQuicOverrideAsync(project, targetHttpsProxy, targetHttpsProxiesSetQuicOverrideRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificates</summary>
        public void SetSslCertificatesRequestObject()
        {
            // Snippet: SetSslCertificates(SetSslCertificatesTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            SetSslCertificatesTargetHttpsProxyRequest request = new SetSslCertificatesTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                TargetHttpsProxiesSetSslCertificatesRequestResource = new TargetHttpsProxiesSetSslCertificatesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = targetHttpsProxiesClient.SetSslCertificates(request);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificatesAsync</summary>
        public async Task SetSslCertificatesRequestObjectAsync()
        {
            // Snippet: SetSslCertificatesAsync(SetSslCertificatesTargetHttpsProxyRequest, CallSettings)
            // Additional: SetSslCertificatesAsync(SetSslCertificatesTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetSslCertificatesTargetHttpsProxyRequest request = new SetSslCertificatesTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                TargetHttpsProxiesSetSslCertificatesRequestResource = new TargetHttpsProxiesSetSslCertificatesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetSslCertificatesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificates</summary>
        public void SetSslCertificates()
        {
            // Snippet: SetSslCertificates(string, string, TargetHttpsProxiesSetSslCertificatesRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            TargetHttpsProxiesSetSslCertificatesRequest targetHttpsProxiesSetSslCertificatesRequestResource = new TargetHttpsProxiesSetSslCertificatesRequest();
            // Make the request
            Operation response = targetHttpsProxiesClient.SetSslCertificates(project, targetHttpsProxy, targetHttpsProxiesSetSslCertificatesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetSslCertificatesAsync</summary>
        public async Task SetSslCertificatesAsync()
        {
            // Snippet: SetSslCertificatesAsync(string, string, TargetHttpsProxiesSetSslCertificatesRequest, CallSettings)
            // Additional: SetSslCertificatesAsync(string, string, TargetHttpsProxiesSetSslCertificatesRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            TargetHttpsProxiesSetSslCertificatesRequest targetHttpsProxiesSetSslCertificatesRequestResource = new TargetHttpsProxiesSetSslCertificatesRequest();
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetSslCertificatesAsync(project, targetHttpsProxy, targetHttpsProxiesSetSslCertificatesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetSslPolicy</summary>
        public void SetSslPolicyRequestObject()
        {
            // Snippet: SetSslPolicy(SetSslPolicyTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            SetSslPolicyTargetHttpsProxyRequest request = new SetSslPolicyTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                Project = "",
                SslPolicyReferenceResource = new SslPolicyReference(),
            };
            // Make the request
            Operation response = targetHttpsProxiesClient.SetSslPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for SetSslPolicyAsync</summary>
        public async Task SetSslPolicyRequestObjectAsync()
        {
            // Snippet: SetSslPolicyAsync(SetSslPolicyTargetHttpsProxyRequest, CallSettings)
            // Additional: SetSslPolicyAsync(SetSslPolicyTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetSslPolicyTargetHttpsProxyRequest request = new SetSslPolicyTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                Project = "",
                SslPolicyReferenceResource = new SslPolicyReference(),
            };
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetSslPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetSslPolicy</summary>
        public void SetSslPolicy()
        {
            // Snippet: SetSslPolicy(string, string, SslPolicyReference, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            SslPolicyReference sslPolicyReferenceResource = new SslPolicyReference();
            // Make the request
            Operation response = targetHttpsProxiesClient.SetSslPolicy(project, targetHttpsProxy, sslPolicyReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for SetSslPolicyAsync</summary>
        public async Task SetSslPolicyAsync()
        {
            // Snippet: SetSslPolicyAsync(string, string, SslPolicyReference, CallSettings)
            // Additional: SetSslPolicyAsync(string, string, SslPolicyReference, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            SslPolicyReference sslPolicyReferenceResource = new SslPolicyReference();
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetSslPolicyAsync(project, targetHttpsProxy, sslPolicyReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMap</summary>
        public void SetUrlMapRequestObject()
        {
            // Snippet: SetUrlMap(SetUrlMapTargetHttpsProxyRequest, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            SetUrlMapTargetHttpsProxyRequest request = new SetUrlMapTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                UrlMapReferenceResource = new UrlMapReference(),
                Project = "",
            };
            // Make the request
            Operation response = targetHttpsProxiesClient.SetUrlMap(request);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMapAsync</summary>
        public async Task SetUrlMapRequestObjectAsync()
        {
            // Snippet: SetUrlMapAsync(SetUrlMapTargetHttpsProxyRequest, CallSettings)
            // Additional: SetUrlMapAsync(SetUrlMapTargetHttpsProxyRequest, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            SetUrlMapTargetHttpsProxyRequest request = new SetUrlMapTargetHttpsProxyRequest
            {
                RequestId = "",
                TargetHttpsProxy = "",
                UrlMapReferenceResource = new UrlMapReference(),
                Project = "",
            };
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetUrlMapAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMap</summary>
        public void SetUrlMap()
        {
            // Snippet: SetUrlMap(string, string, UrlMapReference, CallSettings)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = TargetHttpsProxiesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            UrlMapReference urlMapReferenceResource = new UrlMapReference();
            // Make the request
            Operation response = targetHttpsProxiesClient.SetUrlMap(project, targetHttpsProxy, urlMapReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for SetUrlMapAsync</summary>
        public async Task SetUrlMapAsync()
        {
            // Snippet: SetUrlMapAsync(string, string, UrlMapReference, CallSettings)
            // Additional: SetUrlMapAsync(string, string, UrlMapReference, CancellationToken)
            // Create client
            TargetHttpsProxiesClient targetHttpsProxiesClient = await TargetHttpsProxiesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string targetHttpsProxy = "";
            UrlMapReference urlMapReferenceResource = new UrlMapReference();
            // Make the request
            Operation response = await targetHttpsProxiesClient.SetUrlMapAsync(project, targetHttpsProxy, urlMapReferenceResource);
            // End snippet
        }
    }
}
