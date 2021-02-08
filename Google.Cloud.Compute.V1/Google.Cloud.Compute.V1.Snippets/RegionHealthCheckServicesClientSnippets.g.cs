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
    public sealed class GeneratedRegionHealthCheckServicesClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteRegionHealthCheckServiceRequest, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            DeleteRegionHealthCheckServiceRequest request = new DeleteRegionHealthCheckServiceRequest
            {
                RequestId = "",
                Region = "",
                HealthCheckService = "",
                Project = "",
            };
            // Make the request
            Operation response = regionHealthCheckServicesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteRegionHealthCheckServiceRequest, CallSettings)
            // Additional: DeleteAsync(DeleteRegionHealthCheckServiceRequest, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteRegionHealthCheckServiceRequest request = new DeleteRegionHealthCheckServiceRequest
            {
                RequestId = "",
                Region = "",
                HealthCheckService = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionHealthCheckServicesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string healthCheckService = "";
            // Make the request
            Operation response = regionHealthCheckServicesClient.Delete(project, region, healthCheckService);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string healthCheckService = "";
            // Make the request
            Operation response = await regionHealthCheckServicesClient.DeleteAsync(project, region, healthCheckService);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetRegionHealthCheckServiceRequest, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            GetRegionHealthCheckServiceRequest request = new GetRegionHealthCheckServiceRequest
            {
                Region = "",
                HealthCheckService = "",
                Project = "",
            };
            // Make the request
            HealthCheckService response = regionHealthCheckServicesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetRegionHealthCheckServiceRequest, CallSettings)
            // Additional: GetAsync(GetRegionHealthCheckServiceRequest, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            GetRegionHealthCheckServiceRequest request = new GetRegionHealthCheckServiceRequest
            {
                Region = "",
                HealthCheckService = "",
                Project = "",
            };
            // Make the request
            HealthCheckService response = await regionHealthCheckServicesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string healthCheckService = "";
            // Make the request
            HealthCheckService response = regionHealthCheckServicesClient.Get(project, region, healthCheckService);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string healthCheckService = "";
            // Make the request
            HealthCheckService response = await regionHealthCheckServicesClient.GetAsync(project, region, healthCheckService);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertRegionHealthCheckServiceRequest, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            InsertRegionHealthCheckServiceRequest request = new InsertRegionHealthCheckServiceRequest
            {
                RequestId = "",
                Region = "",
                HealthCheckServiceResource = new HealthCheckService(),
                Project = "",
            };
            // Make the request
            Operation response = regionHealthCheckServicesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertRegionHealthCheckServiceRequest, CallSettings)
            // Additional: InsertAsync(InsertRegionHealthCheckServiceRequest, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            InsertRegionHealthCheckServiceRequest request = new InsertRegionHealthCheckServiceRequest
            {
                RequestId = "",
                Region = "",
                HealthCheckServiceResource = new HealthCheckService(),
                Project = "",
            };
            // Make the request
            Operation response = await regionHealthCheckServicesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, HealthCheckService, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            HealthCheckService healthCheckServiceResource = new HealthCheckService();
            // Make the request
            Operation response = regionHealthCheckServicesClient.Insert(project, region, healthCheckServiceResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, HealthCheckService, CallSettings)
            // Additional: InsertAsync(string, string, HealthCheckService, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            HealthCheckService healthCheckServiceResource = new HealthCheckService();
            // Make the request
            Operation response = await regionHealthCheckServicesClient.InsertAsync(project, region, healthCheckServiceResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListRegionHealthCheckServicesRequest, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            ListRegionHealthCheckServicesRequest request = new ListRegionHealthCheckServicesRequest
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
            HealthCheckServicesList response = regionHealthCheckServicesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListRegionHealthCheckServicesRequest, CallSettings)
            // Additional: ListAsync(ListRegionHealthCheckServicesRequest, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            ListRegionHealthCheckServicesRequest request = new ListRegionHealthCheckServicesRequest
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
            HealthCheckServicesList response = await regionHealthCheckServicesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            HealthCheckServicesList response = regionHealthCheckServicesClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            HealthCheckServicesList response = await regionHealthCheckServicesClient.ListAsync(project, region);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchRegionHealthCheckServiceRequest, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            PatchRegionHealthCheckServiceRequest request = new PatchRegionHealthCheckServiceRequest
            {
                RequestId = "",
                Region = "",
                HealthCheckService = "",
                HealthCheckServiceResource = new HealthCheckService(),
                Project = "",
            };
            // Make the request
            Operation response = regionHealthCheckServicesClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchRegionHealthCheckServiceRequest, CallSettings)
            // Additional: PatchAsync(PatchRegionHealthCheckServiceRequest, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            PatchRegionHealthCheckServiceRequest request = new PatchRegionHealthCheckServiceRequest
            {
                RequestId = "",
                Region = "",
                HealthCheckService = "",
                HealthCheckServiceResource = new HealthCheckService(),
                Project = "",
            };
            // Make the request
            Operation response = await regionHealthCheckServicesClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, string, HealthCheckService, CallSettings)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = RegionHealthCheckServicesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string healthCheckService = "";
            HealthCheckService healthCheckServiceResource = new HealthCheckService();
            // Make the request
            Operation response = regionHealthCheckServicesClient.Patch(project, region, healthCheckService, healthCheckServiceResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, string, HealthCheckService, CallSettings)
            // Additional: PatchAsync(string, string, string, HealthCheckService, CancellationToken)
            // Create client
            RegionHealthCheckServicesClient regionHealthCheckServicesClient = await RegionHealthCheckServicesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string healthCheckService = "";
            HealthCheckService healthCheckServiceResource = new HealthCheckService();
            // Make the request
            Operation response = await regionHealthCheckServicesClient.PatchAsync(project, region, healthCheckService, healthCheckServiceResource);
            // End snippet
        }
    }
}
