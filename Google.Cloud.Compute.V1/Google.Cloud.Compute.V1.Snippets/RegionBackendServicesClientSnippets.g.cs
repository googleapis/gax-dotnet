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
    public sealed class GeneratedRegionBackendServicesClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteRegionBackendServiceRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            DeleteRegionBackendServiceRequest request = new DeleteRegionBackendServiceRequest
            {
                RequestId = "",
                BackendService = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionBackendServicesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteRegionBackendServiceRequest, CallSettings)
            // Additional: DeleteAsync(DeleteRegionBackendServiceRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteRegionBackendServiceRequest request = new DeleteRegionBackendServiceRequest
            {
                RequestId = "",
                BackendService = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionBackendServicesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            // Make the request
            Operation response = regionBackendServicesClient.Delete(project, region, backendService);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            // Make the request
            Operation response = await regionBackendServicesClient.DeleteAsync(project, region, backendService);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetRegionBackendServiceRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            GetRegionBackendServiceRequest request = new GetRegionBackendServiceRequest
            {
                BackendService = "",
                Region = "",
                Project = "",
            };
            // Make the request
            BackendService response = regionBackendServicesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetRegionBackendServiceRequest, CallSettings)
            // Additional: GetAsync(GetRegionBackendServiceRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            GetRegionBackendServiceRequest request = new GetRegionBackendServiceRequest
            {
                BackendService = "",
                Region = "",
                Project = "",
            };
            // Make the request
            BackendService response = await regionBackendServicesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            // Make the request
            BackendService response = regionBackendServicesClient.Get(project, region, backendService);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            // Make the request
            BackendService response = await regionBackendServicesClient.GetAsync(project, region, backendService);
            // End snippet
        }

        /// <summary>Snippet for GetHealth</summary>
        public void GetHealthRequestObject()
        {
            // Snippet: GetHealth(GetHealthRegionBackendServiceRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            GetHealthRegionBackendServiceRequest request = new GetHealthRegionBackendServiceRequest
            {
                BackendService = "",
                ResourceGroupReferenceResource = new ResourceGroupReference(),
                Region = "",
                Project = "",
            };
            // Make the request
            BackendServiceGroupHealth response = regionBackendServicesClient.GetHealth(request);
            // End snippet
        }

        /// <summary>Snippet for GetHealthAsync</summary>
        public async Task GetHealthRequestObjectAsync()
        {
            // Snippet: GetHealthAsync(GetHealthRegionBackendServiceRequest, CallSettings)
            // Additional: GetHealthAsync(GetHealthRegionBackendServiceRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            GetHealthRegionBackendServiceRequest request = new GetHealthRegionBackendServiceRequest
            {
                BackendService = "",
                ResourceGroupReferenceResource = new ResourceGroupReference(),
                Region = "",
                Project = "",
            };
            // Make the request
            BackendServiceGroupHealth response = await regionBackendServicesClient.GetHealthAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetHealth</summary>
        public void GetHealth()
        {
            // Snippet: GetHealth(string, string, string, ResourceGroupReference, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            ResourceGroupReference resourceGroupReferenceResource = new ResourceGroupReference();
            // Make the request
            BackendServiceGroupHealth response = regionBackendServicesClient.GetHealth(project, region, backendService, resourceGroupReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for GetHealthAsync</summary>
        public async Task GetHealthAsync()
        {
            // Snippet: GetHealthAsync(string, string, string, ResourceGroupReference, CallSettings)
            // Additional: GetHealthAsync(string, string, string, ResourceGroupReference, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            ResourceGroupReference resourceGroupReferenceResource = new ResourceGroupReference();
            // Make the request
            BackendServiceGroupHealth response = await regionBackendServicesClient.GetHealthAsync(project, region, backendService, resourceGroupReferenceResource);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertRegionBackendServiceRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            InsertRegionBackendServiceRequest request = new InsertRegionBackendServiceRequest
            {
                RequestId = "",
                BackendServiceResource = new BackendService(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionBackendServicesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertRegionBackendServiceRequest, CallSettings)
            // Additional: InsertAsync(InsertRegionBackendServiceRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            InsertRegionBackendServiceRequest request = new InsertRegionBackendServiceRequest
            {
                RequestId = "",
                BackendServiceResource = new BackendService(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionBackendServicesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, BackendService, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            BackendService backendServiceResource = new BackendService();
            // Make the request
            Operation response = regionBackendServicesClient.Insert(project, region, backendServiceResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, BackendService, CallSettings)
            // Additional: InsertAsync(string, string, BackendService, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            BackendService backendServiceResource = new BackendService();
            // Make the request
            Operation response = await regionBackendServicesClient.InsertAsync(project, region, backendServiceResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListRegionBackendServicesRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            ListRegionBackendServicesRequest request = new ListRegionBackendServicesRequest
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
            BackendServiceList response = regionBackendServicesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListRegionBackendServicesRequest, CallSettings)
            // Additional: ListAsync(ListRegionBackendServicesRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            ListRegionBackendServicesRequest request = new ListRegionBackendServicesRequest
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
            BackendServiceList response = await regionBackendServicesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            BackendServiceList response = regionBackendServicesClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            BackendServiceList response = await regionBackendServicesClient.ListAsync(project, region);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchRegionBackendServiceRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            PatchRegionBackendServiceRequest request = new PatchRegionBackendServiceRequest
            {
                RequestId = "",
                BackendService = "",
                BackendServiceResource = new BackendService(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionBackendServicesClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchRegionBackendServiceRequest, CallSettings)
            // Additional: PatchAsync(PatchRegionBackendServiceRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            PatchRegionBackendServiceRequest request = new PatchRegionBackendServiceRequest
            {
                RequestId = "",
                BackendService = "",
                BackendServiceResource = new BackendService(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionBackendServicesClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, string, BackendService, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            BackendService backendServiceResource = new BackendService();
            // Make the request
            Operation response = regionBackendServicesClient.Patch(project, region, backendService, backendServiceResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, string, BackendService, CallSettings)
            // Additional: PatchAsync(string, string, string, BackendService, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            BackendService backendServiceResource = new BackendService();
            // Make the request
            Operation response = await regionBackendServicesClient.PatchAsync(project, region, backendService, backendServiceResource);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void UpdateRequestObject()
        {
            // Snippet: Update(UpdateRegionBackendServiceRequest, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            UpdateRegionBackendServiceRequest request = new UpdateRegionBackendServiceRequest
            {
                RequestId = "",
                BackendService = "",
                BackendServiceResource = new BackendService(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionBackendServicesClient.Update(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateRequestObjectAsync()
        {
            // Snippet: UpdateAsync(UpdateRegionBackendServiceRequest, CallSettings)
            // Additional: UpdateAsync(UpdateRegionBackendServiceRequest, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            UpdateRegionBackendServiceRequest request = new UpdateRegionBackendServiceRequest
            {
                RequestId = "",
                BackendService = "",
                BackendServiceResource = new BackendService(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionBackendServicesClient.UpdateAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void Update()
        {
            // Snippet: Update(string, string, string, BackendService, CallSettings)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = RegionBackendServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            BackendService backendServiceResource = new BackendService();
            // Make the request
            Operation response = regionBackendServicesClient.Update(project, region, backendService, backendServiceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateAsync()
        {
            // Snippet: UpdateAsync(string, string, string, BackendService, CallSettings)
            // Additional: UpdateAsync(string, string, string, BackendService, CancellationToken)
            // Create client
            RegionBackendServicesClient regionBackendServicesClient = await RegionBackendServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string backendService = "";
            BackendService backendServiceResource = new BackendService();
            // Make the request
            Operation response = await regionBackendServicesClient.UpdateAsync(project, region, backendService, backendServiceResource);
            // End snippet
        }
    }
}
