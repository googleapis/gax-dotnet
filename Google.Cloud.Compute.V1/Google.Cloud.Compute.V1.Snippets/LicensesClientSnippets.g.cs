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
    public sealed class GeneratedLicensesClientSnippets
    {
        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteLicenseRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            DeleteLicenseRequest request = new DeleteLicenseRequest
            {
                RequestId = "",
                License = "",
                Project = "",
            };
            // Make the request
            Operation response = licensesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteLicenseRequest, CallSettings)
            // Additional: DeleteAsync(DeleteLicenseRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteLicenseRequest request = new DeleteLicenseRequest
            {
                RequestId = "",
                License = "",
                Project = "",
            };
            // Make the request
            Operation response = await licensesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string license = "";
            // Make the request
            Operation response = licensesClient.Delete(project, license);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, CallSettings)
            // Additional: DeleteAsync(string, string, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string license = "";
            // Make the request
            Operation response = await licensesClient.DeleteAsync(project, license);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetLicenseRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            GetLicenseRequest request = new GetLicenseRequest
            {
                License = "",
                Project = "",
            };
            // Make the request
            License response = licensesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetLicenseRequest, CallSettings)
            // Additional: GetAsync(GetLicenseRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            GetLicenseRequest request = new GetLicenseRequest
            {
                License = "",
                Project = "",
            };
            // Make the request
            License response = await licensesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string license = "";
            // Make the request
            License response = licensesClient.Get(project, license);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, CallSettings)
            // Additional: GetAsync(string, string, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string license = "";
            // Make the request
            License response = await licensesClient.GetAsync(project, license);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicyRequestObject()
        {
            // Snippet: GetIamPolicy(GetIamPolicyLicenseRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            GetIamPolicyLicenseRequest request = new GetIamPolicyLicenseRequest
            {
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = licensesClient.GetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyRequestObjectAsync()
        {
            // Snippet: GetIamPolicyAsync(GetIamPolicyLicenseRequest, CallSettings)
            // Additional: GetIamPolicyAsync(GetIamPolicyLicenseRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            GetIamPolicyLicenseRequest request = new GetIamPolicyLicenseRequest
            {
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = await licensesClient.GetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicy()
        {
            // Snippet: GetIamPolicy(string, string, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string resource = "";
            // Make the request
            Policy response = licensesClient.GetIamPolicy(project, resource);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyAsync()
        {
            // Snippet: GetIamPolicyAsync(string, string, CallSettings)
            // Additional: GetIamPolicyAsync(string, string, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string resource = "";
            // Make the request
            Policy response = await licensesClient.GetIamPolicyAsync(project, resource);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertLicenseRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            InsertLicenseRequest request = new InsertLicenseRequest
            {
                RequestId = "",
                LicenseResource = new License(),
                Project = "",
            };
            // Make the request
            Operation response = licensesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertLicenseRequest, CallSettings)
            // Additional: InsertAsync(InsertLicenseRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            InsertLicenseRequest request = new InsertLicenseRequest
            {
                RequestId = "",
                LicenseResource = new License(),
                Project = "",
            };
            // Make the request
            Operation response = await licensesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, License, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            License licenseResource = new License();
            // Make the request
            Operation response = licensesClient.Insert(project, licenseResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, License, CallSettings)
            // Additional: InsertAsync(string, License, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            License licenseResource = new License();
            // Make the request
            Operation response = await licensesClient.InsertAsync(project, licenseResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListLicensesRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            ListLicensesRequest request = new ListLicensesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            LicensesListResponse response = licensesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListLicensesRequest, CallSettings)
            // Additional: ListAsync(ListLicensesRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            ListLicensesRequest request = new ListLicensesRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            LicensesListResponse response = await licensesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            LicensesListResponse response = licensesClient.List(project);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, CallSettings)
            // Additional: ListAsync(string, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            LicensesListResponse response = await licensesClient.ListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicyRequestObject()
        {
            // Snippet: SetIamPolicy(SetIamPolicyLicenseRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            SetIamPolicyLicenseRequest request = new SetIamPolicyLicenseRequest
            {
                GlobalSetPolicyRequestResource = new GlobalSetPolicyRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = licensesClient.SetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyRequestObjectAsync()
        {
            // Snippet: SetIamPolicyAsync(SetIamPolicyLicenseRequest, CallSettings)
            // Additional: SetIamPolicyAsync(SetIamPolicyLicenseRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            SetIamPolicyLicenseRequest request = new SetIamPolicyLicenseRequest
            {
                GlobalSetPolicyRequestResource = new GlobalSetPolicyRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = await licensesClient.SetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicy()
        {
            // Snippet: SetIamPolicy(string, string, GlobalSetPolicyRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string resource = "";
            GlobalSetPolicyRequest globalSetPolicyRequestResource = new GlobalSetPolicyRequest();
            // Make the request
            Policy response = licensesClient.SetIamPolicy(project, resource, globalSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyAsync()
        {
            // Snippet: SetIamPolicyAsync(string, string, GlobalSetPolicyRequest, CallSettings)
            // Additional: SetIamPolicyAsync(string, string, GlobalSetPolicyRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string resource = "";
            GlobalSetPolicyRequest globalSetPolicyRequestResource = new GlobalSetPolicyRequest();
            // Make the request
            Policy response = await licensesClient.SetIamPolicyAsync(project, resource, globalSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissionsRequestObject()
        {
            // Snippet: TestIamPermissions(TestIamPermissionsLicenseRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            TestIamPermissionsLicenseRequest request = new TestIamPermissionsLicenseRequest
            {
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = licensesClient.TestIamPermissions(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsRequestObjectAsync()
        {
            // Snippet: TestIamPermissionsAsync(TestIamPermissionsLicenseRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(TestIamPermissionsLicenseRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            TestIamPermissionsLicenseRequest request = new TestIamPermissionsLicenseRequest
            {
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = await licensesClient.TestIamPermissionsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissions()
        {
            // Snippet: TestIamPermissions(string, string, TestPermissionsRequest, CallSettings)
            // Create client
            LicensesClient licensesClient = LicensesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = licensesClient.TestIamPermissions(project, resource, testPermissionsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsAsync()
        {
            // Snippet: TestIamPermissionsAsync(string, string, TestPermissionsRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(string, string, TestPermissionsRequest, CancellationToken)
            // Create client
            LicensesClient licensesClient = await LicensesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = await licensesClient.TestIamPermissionsAsync(project, resource, testPermissionsRequestResource);
            // End snippet
        }
    }
}
