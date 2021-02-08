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
    public sealed class GeneratedAutoscalersClientSnippets
    {
        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedListRequestObject()
        {
            // Snippet: AggregatedList(AggregatedListAutoscalersRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            AggregatedListAutoscalersRequest request = new AggregatedListAutoscalersRequest
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
            AutoscalerAggregatedList response = autoscalersClient.AggregatedList(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListRequestObjectAsync()
        {
            // Snippet: AggregatedListAsync(AggregatedListAutoscalersRequest, CallSettings)
            // Additional: AggregatedListAsync(AggregatedListAutoscalersRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            AggregatedListAutoscalersRequest request = new AggregatedListAutoscalersRequest
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
            AutoscalerAggregatedList response = await autoscalersClient.AggregatedListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedList()
        {
            // Snippet: AggregatedList(string, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            AutoscalerAggregatedList response = autoscalersClient.AggregatedList(project);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListAsync()
        {
            // Snippet: AggregatedListAsync(string, CallSettings)
            // Additional: AggregatedListAsync(string, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            AutoscalerAggregatedList response = await autoscalersClient.AggregatedListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteAutoscalerRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            DeleteAutoscalerRequest request = new DeleteAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = autoscalersClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteAutoscalerRequest, CallSettings)
            // Additional: DeleteAsync(DeleteAutoscalerRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            DeleteAutoscalerRequest request = new DeleteAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = await autoscalersClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string autoscaler = "";
            // Make the request
            Operation response = autoscalersClient.Delete(project, zone, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string autoscaler = "";
            // Make the request
            Operation response = await autoscalersClient.DeleteAsync(project, zone, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetAutoscalerRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            GetAutoscalerRequest request = new GetAutoscalerRequest
            {
                Zone = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Autoscaler response = autoscalersClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetAutoscalerRequest, CallSettings)
            // Additional: GetAsync(GetAutoscalerRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            GetAutoscalerRequest request = new GetAutoscalerRequest
            {
                Zone = "",
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Autoscaler response = await autoscalersClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string autoscaler = "";
            // Make the request
            Autoscaler response = autoscalersClient.Get(project, zone, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string autoscaler = "";
            // Make the request
            Autoscaler response = await autoscalersClient.GetAsync(project, zone, autoscaler);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertAutoscalerRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            InsertAutoscalerRequest request = new InsertAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
            };
            // Make the request
            Operation response = autoscalersClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertAutoscalerRequest, CallSettings)
            // Additional: InsertAsync(InsertAutoscalerRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            InsertAutoscalerRequest request = new InsertAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
            };
            // Make the request
            Operation response = await autoscalersClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, Autoscaler, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = autoscalersClient.Insert(project, zone, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, Autoscaler, CallSettings)
            // Additional: InsertAsync(string, string, Autoscaler, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = await autoscalersClient.InsertAsync(project, zone, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListAutoscalersRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            ListAutoscalersRequest request = new ListAutoscalersRequest
            {
                Zone = "",
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            AutoscalerList response = autoscalersClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListAutoscalersRequest, CallSettings)
            // Additional: ListAsync(ListAutoscalersRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            ListAutoscalersRequest request = new ListAutoscalersRequest
            {
                Zone = "",
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            AutoscalerList response = await autoscalersClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            // Make the request
            AutoscalerList response = autoscalersClient.List(project, zone);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            // Make the request
            AutoscalerList response = await autoscalersClient.ListAsync(project, zone);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchAutoscalerRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            PatchAutoscalerRequest request = new PatchAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = autoscalersClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchAutoscalerRequest, CallSettings)
            // Additional: PatchAsync(PatchAutoscalerRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            PatchAutoscalerRequest request = new PatchAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = await autoscalersClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, Autoscaler, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = autoscalersClient.Patch(project, zone, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, Autoscaler, CallSettings)
            // Additional: PatchAsync(string, string, Autoscaler, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = await autoscalersClient.PatchAsync(project, zone, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void UpdateRequestObject()
        {
            // Snippet: Update(UpdateAutoscalerRequest, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            UpdateAutoscalerRequest request = new UpdateAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = autoscalersClient.Update(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateRequestObjectAsync()
        {
            // Snippet: UpdateAsync(UpdateAutoscalerRequest, CallSettings)
            // Additional: UpdateAsync(UpdateAutoscalerRequest, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            UpdateAutoscalerRequest request = new UpdateAutoscalerRequest
            {
                Zone = "",
                RequestId = "",
                AutoscalerResource = new Autoscaler(),
                Project = "",
                Autoscaler = "",
            };
            // Make the request
            Operation response = await autoscalersClient.UpdateAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void Update()
        {
            // Snippet: Update(string, string, Autoscaler, CallSettings)
            // Create client
            AutoscalersClient autoscalersClient = AutoscalersClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = autoscalersClient.Update(project, zone, autoscalerResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateAsync()
        {
            // Snippet: UpdateAsync(string, string, Autoscaler, CallSettings)
            // Additional: UpdateAsync(string, string, Autoscaler, CancellationToken)
            // Create client
            AutoscalersClient autoscalersClient = await AutoscalersClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Autoscaler autoscalerResource = new Autoscaler();
            // Make the request
            Operation response = await autoscalersClient.UpdateAsync(project, zone, autoscalerResource);
            // End snippet
        }
    }
}
