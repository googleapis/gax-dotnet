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
    public sealed class GeneratedSecurityPoliciesClientSnippets
    {
        /// <summary>Snippet for AddRule</summary>
        public void AddRuleRequestObject()
        {
            // Snippet: AddRule(AddRuleSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            AddRuleSecurityPolicyRequest request = new AddRuleSecurityPolicyRequest
            {
                SecurityPolicyRuleResource = new SecurityPolicyRule(),
                SecurityPolicy = "",
                Project = "",
            };
            // Make the request
            Operation response = securityPoliciesClient.AddRule(request);
            // End snippet
        }

        /// <summary>Snippet for AddRuleAsync</summary>
        public async Task AddRuleRequestObjectAsync()
        {
            // Snippet: AddRuleAsync(AddRuleSecurityPolicyRequest, CallSettings)
            // Additional: AddRuleAsync(AddRuleSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            AddRuleSecurityPolicyRequest request = new AddRuleSecurityPolicyRequest
            {
                SecurityPolicyRuleResource = new SecurityPolicyRule(),
                SecurityPolicy = "",
                Project = "",
            };
            // Make the request
            Operation response = await securityPoliciesClient.AddRuleAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AddRule</summary>
        public void AddRule()
        {
            // Snippet: AddRule(string, string, SecurityPolicyRule, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            SecurityPolicyRule securityPolicyRuleResource = new SecurityPolicyRule();
            // Make the request
            Operation response = securityPoliciesClient.AddRule(project, securityPolicy, securityPolicyRuleResource);
            // End snippet
        }

        /// <summary>Snippet for AddRuleAsync</summary>
        public async Task AddRuleAsync()
        {
            // Snippet: AddRuleAsync(string, string, SecurityPolicyRule, CallSettings)
            // Additional: AddRuleAsync(string, string, SecurityPolicyRule, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            SecurityPolicyRule securityPolicyRuleResource = new SecurityPolicyRule();
            // Make the request
            Operation response = await securityPoliciesClient.AddRuleAsync(project, securityPolicy, securityPolicyRuleResource);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            DeleteSecurityPolicyRequest request = new DeleteSecurityPolicyRequest
            {
                RequestId = "",
                SecurityPolicy = "",
                Project = "",
            };
            // Make the request
            Operation response = securityPoliciesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteSecurityPolicyRequest, CallSettings)
            // Additional: DeleteAsync(DeleteSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteSecurityPolicyRequest request = new DeleteSecurityPolicyRequest
            {
                RequestId = "",
                SecurityPolicy = "",
                Project = "",
            };
            // Make the request
            Operation response = await securityPoliciesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            Operation response = securityPoliciesClient.Delete(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, CallSettings)
            // Additional: DeleteAsync(string, string, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            Operation response = await securityPoliciesClient.DeleteAsync(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            GetSecurityPolicyRequest request = new GetSecurityPolicyRequest
            {
                SecurityPolicy = "",
                Project = "",
            };
            // Make the request
            SecurityPolicy response = securityPoliciesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetSecurityPolicyRequest, CallSettings)
            // Additional: GetAsync(GetSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            GetSecurityPolicyRequest request = new GetSecurityPolicyRequest
            {
                SecurityPolicy = "",
                Project = "",
            };
            // Make the request
            SecurityPolicy response = await securityPoliciesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            SecurityPolicy response = securityPoliciesClient.Get(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, CallSettings)
            // Additional: GetAsync(string, string, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            SecurityPolicy response = await securityPoliciesClient.GetAsync(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for GetRule</summary>
        public void GetRuleRequestObject()
        {
            // Snippet: GetRule(GetRuleSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            GetRuleSecurityPolicyRequest request = new GetRuleSecurityPolicyRequest
            {
                SecurityPolicy = "",
                Priority = 0,
                Project = "",
            };
            // Make the request
            SecurityPolicyRule response = securityPoliciesClient.GetRule(request);
            // End snippet
        }

        /// <summary>Snippet for GetRuleAsync</summary>
        public async Task GetRuleRequestObjectAsync()
        {
            // Snippet: GetRuleAsync(GetRuleSecurityPolicyRequest, CallSettings)
            // Additional: GetRuleAsync(GetRuleSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            GetRuleSecurityPolicyRequest request = new GetRuleSecurityPolicyRequest
            {
                SecurityPolicy = "",
                Priority = 0,
                Project = "",
            };
            // Make the request
            SecurityPolicyRule response = await securityPoliciesClient.GetRuleAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetRule</summary>
        public void GetRule()
        {
            // Snippet: GetRule(string, string, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            SecurityPolicyRule response = securityPoliciesClient.GetRule(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for GetRuleAsync</summary>
        public async Task GetRuleAsync()
        {
            // Snippet: GetRuleAsync(string, string, CallSettings)
            // Additional: GetRuleAsync(string, string, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            SecurityPolicyRule response = await securityPoliciesClient.GetRuleAsync(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            InsertSecurityPolicyRequest request = new InsertSecurityPolicyRequest
            {
                RequestId = "",
                SecurityPolicyResource = new SecurityPolicy(),
                Project = "",
            };
            // Make the request
            Operation response = securityPoliciesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertSecurityPolicyRequest, CallSettings)
            // Additional: InsertAsync(InsertSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            InsertSecurityPolicyRequest request = new InsertSecurityPolicyRequest
            {
                RequestId = "",
                SecurityPolicyResource = new SecurityPolicy(),
                Project = "",
            };
            // Make the request
            Operation response = await securityPoliciesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, SecurityPolicy, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            SecurityPolicy securityPolicyResource = new SecurityPolicy();
            // Make the request
            Operation response = securityPoliciesClient.Insert(project, securityPolicyResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, SecurityPolicy, CallSettings)
            // Additional: InsertAsync(string, SecurityPolicy, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            SecurityPolicy securityPolicyResource = new SecurityPolicy();
            // Make the request
            Operation response = await securityPoliciesClient.InsertAsync(project, securityPolicyResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListSecurityPoliciesRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            ListSecurityPoliciesRequest request = new ListSecurityPoliciesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            SecurityPolicyList response = securityPoliciesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListSecurityPoliciesRequest, CallSettings)
            // Additional: ListAsync(ListSecurityPoliciesRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            ListSecurityPoliciesRequest request = new ListSecurityPoliciesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            SecurityPolicyList response = await securityPoliciesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            SecurityPolicyList response = securityPoliciesClient.List(project);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, CallSettings)
            // Additional: ListAsync(string, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            SecurityPolicyList response = await securityPoliciesClient.ListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for ListPreconfiguredExpressionSets</summary>
        public void ListPreconfiguredExpressionSetsRequestObject()
        {
            // Snippet: ListPreconfiguredExpressionSets(ListPreconfiguredExpressionSetsSecurityPoliciesRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            ListPreconfiguredExpressionSetsSecurityPoliciesRequest request = new ListPreconfiguredExpressionSetsSecurityPoliciesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            SecurityPoliciesListPreconfiguredExpressionSetsResponse response = securityPoliciesClient.ListPreconfiguredExpressionSets(request);
            // End snippet
        }

        /// <summary>Snippet for ListPreconfiguredExpressionSetsAsync</summary>
        public async Task ListPreconfiguredExpressionSetsRequestObjectAsync()
        {
            // Snippet: ListPreconfiguredExpressionSetsAsync(ListPreconfiguredExpressionSetsSecurityPoliciesRequest, CallSettings)
            // Additional: ListPreconfiguredExpressionSetsAsync(ListPreconfiguredExpressionSetsSecurityPoliciesRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            ListPreconfiguredExpressionSetsSecurityPoliciesRequest request = new ListPreconfiguredExpressionSetsSecurityPoliciesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            SecurityPoliciesListPreconfiguredExpressionSetsResponse response = await securityPoliciesClient.ListPreconfiguredExpressionSetsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for ListPreconfiguredExpressionSets</summary>
        public void ListPreconfiguredExpressionSets()
        {
            // Snippet: ListPreconfiguredExpressionSets(string, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            SecurityPoliciesListPreconfiguredExpressionSetsResponse response = securityPoliciesClient.ListPreconfiguredExpressionSets(project);
            // End snippet
        }

        /// <summary>Snippet for ListPreconfiguredExpressionSetsAsync</summary>
        public async Task ListPreconfiguredExpressionSetsAsync()
        {
            // Snippet: ListPreconfiguredExpressionSetsAsync(string, CallSettings)
            // Additional: ListPreconfiguredExpressionSetsAsync(string, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            SecurityPoliciesListPreconfiguredExpressionSetsResponse response = await securityPoliciesClient.ListPreconfiguredExpressionSetsAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void PatchRequestObject()
        {
            // Snippet: Patch(PatchSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            PatchSecurityPolicyRequest request = new PatchSecurityPolicyRequest
            {
                RequestId = "",
                SecurityPolicy = "",
                SecurityPolicyResource = new SecurityPolicy(),
                Project = "",
            };
            // Make the request
            Operation response = securityPoliciesClient.Patch(request);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchRequestObjectAsync()
        {
            // Snippet: PatchAsync(PatchSecurityPolicyRequest, CallSettings)
            // Additional: PatchAsync(PatchSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            PatchSecurityPolicyRequest request = new PatchSecurityPolicyRequest
            {
                RequestId = "",
                SecurityPolicy = "",
                SecurityPolicyResource = new SecurityPolicy(),
                Project = "",
            };
            // Make the request
            Operation response = await securityPoliciesClient.PatchAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Patch</summary>
        public void Patch()
        {
            // Snippet: Patch(string, string, SecurityPolicy, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            SecurityPolicy securityPolicyResource = new SecurityPolicy();
            // Make the request
            Operation response = securityPoliciesClient.Patch(project, securityPolicy, securityPolicyResource);
            // End snippet
        }

        /// <summary>Snippet for PatchAsync</summary>
        public async Task PatchAsync()
        {
            // Snippet: PatchAsync(string, string, SecurityPolicy, CallSettings)
            // Additional: PatchAsync(string, string, SecurityPolicy, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            SecurityPolicy securityPolicyResource = new SecurityPolicy();
            // Make the request
            Operation response = await securityPoliciesClient.PatchAsync(project, securityPolicy, securityPolicyResource);
            // End snippet
        }

        /// <summary>Snippet for PatchRule</summary>
        public void PatchRuleRequestObject()
        {
            // Snippet: PatchRule(PatchRuleSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            PatchRuleSecurityPolicyRequest request = new PatchRuleSecurityPolicyRequest
            {
                SecurityPolicyRuleResource = new SecurityPolicyRule(),
                SecurityPolicy = "",
                Priority = 0,
                Project = "",
            };
            // Make the request
            Operation response = securityPoliciesClient.PatchRule(request);
            // End snippet
        }

        /// <summary>Snippet for PatchRuleAsync</summary>
        public async Task PatchRuleRequestObjectAsync()
        {
            // Snippet: PatchRuleAsync(PatchRuleSecurityPolicyRequest, CallSettings)
            // Additional: PatchRuleAsync(PatchRuleSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            PatchRuleSecurityPolicyRequest request = new PatchRuleSecurityPolicyRequest
            {
                SecurityPolicyRuleResource = new SecurityPolicyRule(),
                SecurityPolicy = "",
                Priority = 0,
                Project = "",
            };
            // Make the request
            Operation response = await securityPoliciesClient.PatchRuleAsync(request);
            // End snippet
        }

        /// <summary>Snippet for PatchRule</summary>
        public void PatchRule()
        {
            // Snippet: PatchRule(string, string, SecurityPolicyRule, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            SecurityPolicyRule securityPolicyRuleResource = new SecurityPolicyRule();
            // Make the request
            Operation response = securityPoliciesClient.PatchRule(project, securityPolicy, securityPolicyRuleResource);
            // End snippet
        }

        /// <summary>Snippet for PatchRuleAsync</summary>
        public async Task PatchRuleAsync()
        {
            // Snippet: PatchRuleAsync(string, string, SecurityPolicyRule, CallSettings)
            // Additional: PatchRuleAsync(string, string, SecurityPolicyRule, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            SecurityPolicyRule securityPolicyRuleResource = new SecurityPolicyRule();
            // Make the request
            Operation response = await securityPoliciesClient.PatchRuleAsync(project, securityPolicy, securityPolicyRuleResource);
            // End snippet
        }

        /// <summary>Snippet for RemoveRule</summary>
        public void RemoveRuleRequestObject()
        {
            // Snippet: RemoveRule(RemoveRuleSecurityPolicyRequest, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            RemoveRuleSecurityPolicyRequest request = new RemoveRuleSecurityPolicyRequest
            {
                SecurityPolicy = "",
                Priority = 0,
                Project = "",
            };
            // Make the request
            Operation response = securityPoliciesClient.RemoveRule(request);
            // End snippet
        }

        /// <summary>Snippet for RemoveRuleAsync</summary>
        public async Task RemoveRuleRequestObjectAsync()
        {
            // Snippet: RemoveRuleAsync(RemoveRuleSecurityPolicyRequest, CallSettings)
            // Additional: RemoveRuleAsync(RemoveRuleSecurityPolicyRequest, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            RemoveRuleSecurityPolicyRequest request = new RemoveRuleSecurityPolicyRequest
            {
                SecurityPolicy = "",
                Priority = 0,
                Project = "",
            };
            // Make the request
            Operation response = await securityPoliciesClient.RemoveRuleAsync(request);
            // End snippet
        }

        /// <summary>Snippet for RemoveRule</summary>
        public void RemoveRule()
        {
            // Snippet: RemoveRule(string, string, CallSettings)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = SecurityPoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            Operation response = securityPoliciesClient.RemoveRule(project, securityPolicy);
            // End snippet
        }

        /// <summary>Snippet for RemoveRuleAsync</summary>
        public async Task RemoveRuleAsync()
        {
            // Snippet: RemoveRuleAsync(string, string, CallSettings)
            // Additional: RemoveRuleAsync(string, string, CancellationToken)
            // Create client
            SecurityPoliciesClient securityPoliciesClient = await SecurityPoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string securityPolicy = "";
            // Make the request
            Operation response = await securityPoliciesClient.RemoveRuleAsync(project, securityPolicy);
            // End snippet
        }
    }
}
