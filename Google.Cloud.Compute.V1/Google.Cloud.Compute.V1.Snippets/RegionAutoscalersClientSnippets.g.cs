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
    public sealed class GeneratedRegionAutoscalersClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteRegionAutoscalerRequest, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            DeleteRegionAutoscalerRequest request = new DeleteRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = regionAutoscalersClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteRegionAutoscalerRequest, CallSettings)
            // Additional: DeleteAsync(DeleteRegionAutoscalerRequest, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            DeleteRegionAutoscalerRequest request = new DeleteRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = await regionAutoscalersClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string autoscaler = "";
            // Make the request
            Operation response = regionAutoscalersClient.Delete(project, region, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string autoscaler = "";
            // Make the request
            Operation response = await regionAutoscalersClient.DeleteAsync(project, region, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetRegionAutoscalerRequest, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            GetRegionAutoscalerRequest request = new GetRegionAutoscalerRequest
            {
                Region = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Autoscaler response = regionAutoscalersClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetRegionAutoscalerRequest, CallSettings)
            // Additional: GetAsync(GetRegionAutoscalerRequest, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            GetRegionAutoscalerRequest request = new GetRegionAutoscalerRequest
            {
                Region = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Autoscaler response = await regionAutoscalersClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string autoscaler = "";
            // Make the request
            Autoscaler response = regionAutoscalersClient.Get(project, region, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string autoscaler = "";
            // Make the request
            Autoscaler response = await regionAutoscalersClient.GetAsync(project, region, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertRegionAutoscalerRequest, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            InsertRegionAutoscalerRequest request = new InsertRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
            };
            // Make the request
            Operation response = regionAutoscalersClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertRegionAutoscalerRequest, CallSettings)
            // Additional: InsertAsync(InsertRegionAutoscalerRequest, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            InsertRegionAutoscalerRequest request = new InsertRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
            };
            // Make the request
            Operation response = await regionAutoscalersClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, Autoscaler, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = regionAutoscalersClient.Insert(project, region, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, Autoscaler, CallSettings)
            // Additional: InsertAsync(string, string, Autoscaler, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = await regionAutoscalersClient.InsertAsync(project, region, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListRegionAutoscalersRequest, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            ListRegionAutoscalersRequest request = new ListRegionAutoscalersRequest
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
            RegionAutoscalerList response = regionAutoscalersClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListRegionAutoscalersRequest, CallSettings)
            // Additional: ListAsync(ListRegionAutoscalersRequest, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            ListRegionAutoscalersRequest request = new ListRegionAutoscalersRequest
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
            RegionAutoscalerList response = await regionAutoscalersClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            RegionAutoscalerList response = regionAutoscalersClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            RegionAutoscalerList response = await regionAutoscalersClient.ListAsync(project, region);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchRegionAutoscalerRequest, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            PatchRegionAutoscalerRequest request = new PatchRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = regionAutoscalersClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchRegionAutoscalerRequest, CallSettings)
            // Additional: PatchAsync(PatchRegionAutoscalerRequest, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            PatchRegionAutoscalerRequest request = new PatchRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = await regionAutoscalersClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, Autoscaler, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = regionAutoscalersClient.Patch(project, region, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, Autoscaler, CallSettings)
            // Additional: PatchAsync(string, string, Autoscaler, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = await regionAutoscalersClient.PatchAsync(project, region, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void UpdateRequestObject()
        {
            // Snippet: Update(UpdateRegionAutoscalerRequest, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            UpdateRegionAutoscalerRequest request = new UpdateRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = regionAutoscalersClient.Update(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateRequestObjectAsync()
        {
            // Snippet: UpdateAsync(UpdateRegionAutoscalerRequest, CallSettings)
            // Additional: UpdateAsync(UpdateRegionAutoscalerRequest, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            UpdateRegionAutoscalerRequest request = new UpdateRegionAutoscalerRequest
            {
                RequestId = "",
                Region = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = await regionAutoscalersClient.UpdateAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void Update()
        {
            // Snippet: Update(string, string, Autoscaler, CallSettings)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = RegionAutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = regionAutoscalersClient.Update(project, region, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateAsync()
        {
            // Snippet: UpdateAsync(string, string, Autoscaler, CallSettings)
            // Additional: UpdateAsync(string, string, Autoscaler, CancellationToken)
            // Create client
            RegionAutoscalersClient regionAutoscalersClient = await RegionAutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = await regionAutoscalersClient.UpdateAsync(project, region, autoscalerResource);
            // End snippet
        }
    }
}
