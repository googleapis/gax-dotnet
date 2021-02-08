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
    public sealed class GeneratedResourcePoliciesClientSnippets
    {
        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedListRequestObject()
        {
            // Snippet: AggregatedList(AggregatedListResourcePoliciesRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            AggregatedListResourcePoliciesRequest request = new AggregatedListResourcePoliciesRequest
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
            ResourcePolicyAggregatedList response = resourcePoliciesClient.AggregatedList(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListRequestObjectAsync()
        {
            // Snippet: AggregatedListAsync(AggregatedListResourcePoliciesRequest, CallSettings)
            // Additional: AggregatedListAsync(AggregatedListResourcePoliciesRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            AggregatedListResourcePoliciesRequest request = new AggregatedListResourcePoliciesRequest
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
            ResourcePolicyAggregatedList response = await resourcePoliciesClient.AggregatedListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedList()
        {
            // Snippet: AggregatedList(string, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            ResourcePolicyAggregatedList response = resourcePoliciesClient.AggregatedList(project);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListAsync()
        {
            // Snippet: AggregatedListAsync(string, CallSettings)
            // Additional: AggregatedListAsync(string, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            ResourcePolicyAggregatedList response = await resourcePoliciesClient.AggregatedListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteResourcePolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            DeleteResourcePolicyRequest request = new DeleteResourcePolicyRequest
            {
                RequestId = "",
                Region = "",
                ResourcePolicy = "",
                Project = "",
            };
            // Make the request
            Operation response = resourcePoliciesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteResourcePolicyRequest, CallSettings)
            // Additional: DeleteAsync(DeleteResourcePolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteResourcePolicyRequest request = new DeleteResourcePolicyRequest
            {
                RequestId = "",
                Region = "",
                ResourcePolicy = "",
                Project = "",
            };
            // Make the request
            Operation response = await resourcePoliciesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resourcePolicy = "";
            // Make the request
            Operation response = resourcePoliciesClient.Delete(project, region, resourcePolicy);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resourcePolicy = "";
            // Make the request
            Operation response = await resourcePoliciesClient.DeleteAsync(project, region, resourcePolicy);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetResourcePolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            GetResourcePolicyRequest request = new GetResourcePolicyRequest
            {
                Region = "",
                ResourcePolicy = "",
                Project = "",
            };
            // Make the request
            ResourcePolicy response = resourcePoliciesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetResourcePolicyRequest, CallSettings)
            // Additional: GetAsync(GetResourcePolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            GetResourcePolicyRequest request = new GetResourcePolicyRequest
            {
                Region = "",
                ResourcePolicy = "",
                Project = "",
            };
            // Make the request
            ResourcePolicy response = await resourcePoliciesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resourcePolicy = "";
            // Make the request
            ResourcePolicy response = resourcePoliciesClient.Get(project, region, resourcePolicy);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resourcePolicy = "";
            // Make the request
            ResourcePolicy response = await resourcePoliciesClient.GetAsync(project, region, resourcePolicy);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicyRequestObject()
        {
            // Snippet: GetIamPolicy(GetIamPolicyResourcePolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            GetIamPolicyResourcePolicyRequest request = new GetIamPolicyResourcePolicyRequest
            {
                Region = "",
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = resourcePoliciesClient.GetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyRequestObjectAsync()
        {
            // Snippet: GetIamPolicyAsync(GetIamPolicyResourcePolicyRequest, CallSettings)
            // Additional: GetIamPolicyAsync(GetIamPolicyResourcePolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            GetIamPolicyResourcePolicyRequest request = new GetIamPolicyResourcePolicyRequest
            {
                Region = "",
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = await resourcePoliciesClient.GetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicy()
        {
            // Snippet: GetIamPolicy(string, string, string, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            // Make the request
            Policy response = resourcePoliciesClient.GetIamPolicy(project, region, resource);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyAsync()
        {
            // Snippet: GetIamPolicyAsync(string, string, string, CallSettings)
            // Additional: GetIamPolicyAsync(string, string, string, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            // Make the request
            Policy response = await resourcePoliciesClient.GetIamPolicyAsync(project, region, resource);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertResourcePolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            InsertResourcePolicyRequest request = new InsertResourcePolicyRequest
            {
                RequestId = "",
                ResourcePolicyResource = new ResourcePolicy(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = resourcePoliciesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertResourcePolicyRequest, CallSettings)
            // Additional: InsertAsync(InsertResourcePolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            InsertResourcePolicyRequest request = new InsertResourcePolicyRequest
            {
                RequestId = "",
                ResourcePolicyResource = new ResourcePolicy(),
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await resourcePoliciesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, ResourcePolicy, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            ResourcePolicy resourcePolicyResource = new ResourcePolicy();
            // Make the request
            Operation response = resourcePoliciesClient.Insert(project, region, resourcePolicyResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, ResourcePolicy, CallSettings)
            // Additional: InsertAsync(string, string, ResourcePolicy, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            ResourcePolicy resourcePolicyResource = new ResourcePolicy();
            // Make the request
            Operation response = await resourcePoliciesClient.InsertAsync(project, region, resourcePolicyResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListResourcePoliciesRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            ListResourcePoliciesRequest request = new ListResourcePoliciesRequest
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
            ResourcePolicyList response = resourcePoliciesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListResourcePoliciesRequest, CallSettings)
            // Additional: ListAsync(ListResourcePoliciesRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            ListResourcePoliciesRequest request = new ListResourcePoliciesRequest
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
            ResourcePolicyList response = await resourcePoliciesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            ResourcePolicyList response = resourcePoliciesClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            ResourcePolicyList response = await resourcePoliciesClient.ListAsync(project, region);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicyRequestObject()
        {
            // Snippet: SetIamPolicy(SetIamPolicyResourcePolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            SetIamPolicyResourcePolicyRequest request = new SetIamPolicyResourcePolicyRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "",
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = resourcePoliciesClient.SetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyRequestObjectAsync()
        {
            // Snippet: SetIamPolicyAsync(SetIamPolicyResourcePolicyRequest, CallSettings)
            // Additional: SetIamPolicyAsync(SetIamPolicyResourcePolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            SetIamPolicyResourcePolicyRequest request = new SetIamPolicyResourcePolicyRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "",
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = await resourcePoliciesClient.SetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicy()
        {
            // Snippet: SetIamPolicy(string, string, string, RegionSetPolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            RegionSetPolicyRequest regionSetPolicyRequestResource = new RegionSetPolicyRequest();
            // Make the request
            Policy response = resourcePoliciesClient.SetIamPolicy(project, region, resource, regionSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyAsync()
        {
            // Snippet: SetIamPolicyAsync(string, string, string, RegionSetPolicyRequest, CallSettings)
            // Additional: SetIamPolicyAsync(string, string, string, RegionSetPolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            RegionSetPolicyRequest regionSetPolicyRequestResource = new RegionSetPolicyRequest();
            // Make the request
            Policy response = await resourcePoliciesClient.SetIamPolicyAsync(project, region, resource, regionSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissionsRequestObject()
        {
            // Snippet: TestIamPermissions(TestIamPermissionsResourcePolicyRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            TestIamPermissionsResourcePolicyRequest request = new TestIamPermissionsResourcePolicyRequest
            {
                Region = "",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = resourcePoliciesClient.TestIamPermissions(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsRequestObjectAsync()
        {
            // Snippet: TestIamPermissionsAsync(TestIamPermissionsResourcePolicyRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(TestIamPermissionsResourcePolicyRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            TestIamPermissionsResourcePolicyRequest request = new TestIamPermissionsResourcePolicyRequest
            {
                Region = "",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = await resourcePoliciesClient.TestIamPermissionsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissions()
        {
            // Snippet: TestIamPermissions(string, string, string, TestPermissionsRequest, CallSettings)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = ResourcePoliciesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = resourcePoliciesClient.TestIamPermissions(project, region, resource, testPermissionsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsAsync()
        {
            // Snippet: TestIamPermissionsAsync(string, string, string, TestPermissionsRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(string, string, string, TestPermissionsRequest, CancellationToken)
            // Create client
            ResourcePoliciesClient resourcePoliciesClient = await ResourcePoliciesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = await resourcePoliciesClient.TestIamPermissionsAsync(project, region, resource, testPermissionsRequestResource);
            // End snippet
        }
    }
}
