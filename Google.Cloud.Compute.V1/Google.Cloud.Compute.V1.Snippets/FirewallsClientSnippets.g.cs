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
    public sealed class GeneratedFirewallsClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteFirewallRequest, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            DeleteFirewallRequest request = new DeleteFirewallRequest
            {
                RequestId = "",
                Project = "",
                Firewall = "",
            };
            // Make the request
            Operation response = firewallsClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteFirewallRequest, CallSettings)
            // Additional: DeleteAsync(DeleteFirewallRequest, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            DeleteFirewallRequest request = new DeleteFirewallRequest
            {
                RequestId = "",
                Project = "",
                Firewall = "",
            };
            // Make the request
            Operation response = await firewallsClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            // Make the request
            Operation response = firewallsClient.Delete(project, firewall);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, CallSettings)
            // Additional: DeleteAsync(string, string, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            // Make the request
            Operation response = await firewallsClient.DeleteAsync(project, firewall);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetFirewallRequest, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            GetFirewallRequest request = new GetFirewallRequest
            {
                Project = "",
                Firewall = "",
            };
            // Make the request
            Firewall response = firewallsClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetFirewallRequest, CallSettings)
            // Additional: GetAsync(GetFirewallRequest, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            GetFirewallRequest request = new GetFirewallRequest
            {
                Project = "",
                Firewall = "",
            };
            // Make the request
            Firewall response = await firewallsClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            // Make the request
            Firewall response = firewallsClient.Get(project, firewall);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, CallSettings)
            // Additional: GetAsync(string, string, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            // Make the request
            Firewall response = await firewallsClient.GetAsync(project, firewall);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertFirewallRequest, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            InsertFirewallRequest request = new InsertFirewallRequest
            {
                RequestId = "",
                FirewallResource = new Firewall(),
                Project = "",
            };
            // Make the request
            Operation response = firewallsClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertFirewallRequest, CallSettings)
            // Additional: InsertAsync(InsertFirewallRequest, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            InsertFirewallRequest request = new InsertFirewallRequest
            {
                RequestId = "",
                FirewallResource = new Firewall(),
                Project = "",
            };
            // Make the request
            Operation response = await firewallsClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, Firewall, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            string project = "";
            Firewall firewallResource = new Firewall();
            // Make the request
            Operation response = firewallsClient.Insert(project, firewallResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, Firewall, CallSettings)
            // Additional: InsertAsync(string, Firewall, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            Firewall firewallResource = new Firewall();
            // Make the request
            Operation response = await firewallsClient.InsertAsync(project, firewallResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListFirewallsRequest, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            ListFirewallsRequest request = new ListFirewallsRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            FirewallList response = firewallsClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListFirewallsRequest, CallSettings)
            // Additional: ListAsync(ListFirewallsRequest, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            ListFirewallsRequest request = new ListFirewallsRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            FirewallList response = await firewallsClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            FirewallList response = firewallsClient.List(project);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, CallSettings)
            // Additional: ListAsync(string, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            FirewallList response = await firewallsClient.ListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchFirewallRequest, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            PatchFirewallRequest request = new PatchFirewallRequest
            {
                RequestId = "",
                FirewallResource = new Firewall(),
                Project = "",
                Firewall = "",
            };
            // Make the request
            Operation response = firewallsClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchFirewallRequest, CallSettings)
            // Additional: PatchAsync(PatchFirewallRequest, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            PatchFirewallRequest request = new PatchFirewallRequest
            {
                RequestId = "",
                FirewallResource = new Firewall(),
                Project = "",
                Firewall = "",
            };
            // Make the request
            Operation response = await firewallsClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, Firewall, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            Firewall firewallResource = new Firewall();
            // Make the request
            Operation response = firewallsClient.Patch(project, firewall, firewallResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, Firewall, CallSettings)
            // Additional: PatchAsync(string, string, Firewall, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            Firewall firewallResource = new Firewall();
            // Make the request
            Operation response = await firewallsClient.PatchAsync(project, firewall, firewallResource);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void UpdateRequestObject()
        {
            // Snippet: Update(UpdateFirewallRequest, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            UpdateFirewallRequest request = new UpdateFirewallRequest
            {
                RequestId = "",
                FirewallResource = new Firewall(),
                Project = "",
                Firewall = "",
            };
            // Make the request
            Operation response = firewallsClient.Update(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateRequestObjectAsync()
        {
            // Snippet: UpdateAsync(UpdateFirewallRequest, CallSettings)
            // Additional: UpdateAsync(UpdateFirewallRequest, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            UpdateFirewallRequest request = new UpdateFirewallRequest
            {
                RequestId = "",
                FirewallResource = new Firewall(),
                Project = "",
                Firewall = "",
            };
            // Make the request
            Operation response = await firewallsClient.UpdateAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void Update()
        {
            // Snippet: Update(string, string, Firewall, CallSettings)
            // Create client
            FirewallsClient firewallsClient = FirewallsClient.Create();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            Firewall firewallResource = new Firewall();
            // Make the request
            Operation response = firewallsClient.Update(project, firewall, firewallResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateAsync()
        {
            // Snippet: UpdateAsync(string, string, Firewall, CallSettings)
            // Additional: UpdateAsync(string, string, Firewall, CancellationToken)
            // Create client
            FirewallsClient firewallsClient = await FirewallsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string firewall = "";
            Firewall firewallResource = new Firewall();
            // Make the request
            Operation response = await firewallsClient.UpdateAsync(project, firewall, firewallResource);
            // End snippet
        }
    }
}
