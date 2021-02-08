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
    public sealed class GeneratedRegionDisksClientSnippets
    {
        /// <summary>Snippet for AddResourcePolicies</summary>
        public void AddResourcePoliciesRequestObject()
        {
            // Snippet: AddResourcePolicies(AddResourcePoliciesRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            AddResourcePoliciesRegionDiskRequest request = new AddResourcePoliciesRegionDiskRequest
            {
                Disk = "",
                RegionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest(),
                RequestId = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionDisksClient.AddResourcePolicies(request);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePoliciesAsync</summary>
        public async Task AddResourcePoliciesRequestObjectAsync()
        {
            // Snippet: AddResourcePoliciesAsync(AddResourcePoliciesRegionDiskRequest, CallSettings)
            // Additional: AddResourcePoliciesAsync(AddResourcePoliciesRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            AddResourcePoliciesRegionDiskRequest request = new AddResourcePoliciesRegionDiskRequest
            {
                Disk = "",
                RegionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest(),
                RequestId = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionDisksClient.AddResourcePoliciesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePolicies</summary>
        public void AddResourcePolicies()
        {
            // Snippet: AddResourcePolicies(string, string, string, RegionDisksAddResourcePoliciesRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            RegionDisksAddResourcePoliciesRequest regionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest();
            // Make the request
            Operation response = regionDisksClient.AddResourcePolicies(project, region, disk, regionDisksAddResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePoliciesAsync</summary>
        public async Task AddResourcePoliciesAsync()
        {
            // Snippet: AddResourcePoliciesAsync(string, string, string, RegionDisksAddResourcePoliciesRequest, CallSettings)
            // Additional: AddResourcePoliciesAsync(string, string, string, RegionDisksAddResourcePoliciesRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            RegionDisksAddResourcePoliciesRequest regionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest();
            // Make the request
            Operation response = await regionDisksClient.AddResourcePoliciesAsync(project, region, disk, regionDisksAddResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for CreateSnapshot</summary>
        public void CreateSnapshotRequestObject()
        {
            // Snippet: CreateSnapshot(CreateSnapshotRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            CreateSnapshotRegionDiskRequest request = new CreateSnapshotRegionDiskRequest
            {
                Disk = "",
                RequestId = "",
                Region = "",
                SnapshotResource = new Snapshot(),
                Project = "",
            };
            // Make the request
            Operation response = regionDisksClient.CreateSnapshot(request);
            // End snippet
        }

        /// <summary>Snippet for CreateSnapshotAsync</summary>
        public async Task CreateSnapshotRequestObjectAsync()
        {
            // Snippet: CreateSnapshotAsync(CreateSnapshotRegionDiskRequest, CallSettings)
            // Additional: CreateSnapshotAsync(CreateSnapshotRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            CreateSnapshotRegionDiskRequest request = new CreateSnapshotRegionDiskRequest
            {
                Disk = "",
                RequestId = "",
                Region = "",
                SnapshotResource = new Snapshot(),
                Project = "",
            };
            // Make the request
            Operation response = await regionDisksClient.CreateSnapshotAsync(request);
            // End snippet
        }

        /// <summary>Snippet for CreateSnapshot</summary>
        public void CreateSnapshot()
        {
            // Snippet: CreateSnapshot(string, string, string, Snapshot, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            Snapshot snapshotResource = new Snapshot();
            // Make the request
            Operation response = regionDisksClient.CreateSnapshot(project, region, disk, snapshotResource);
            // End snippet
        }

        /// <summary>Snippet for CreateSnapshotAsync</summary>
        public async Task CreateSnapshotAsync()
        {
            // Snippet: CreateSnapshotAsync(string, string, string, Snapshot, CallSettings)
            // Additional: CreateSnapshotAsync(string, string, string, Snapshot, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            Snapshot snapshotResource = new Snapshot();
            // Make the request
            Operation response = await regionDisksClient.CreateSnapshotAsync(project, region, disk, snapshotResource);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            DeleteRegionDiskRequest request = new DeleteRegionDiskRequest
            {
                Disk = "",
                RequestId = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionDisksClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteRegionDiskRequest, CallSettings)
            // Additional: DeleteAsync(DeleteRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            DeleteRegionDiskRequest request = new DeleteRegionDiskRequest
            {
                Disk = "",
                RequestId = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionDisksClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            // Make the request
            Operation response = regionDisksClient.Delete(project, region, disk);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            // Make the request
            Operation response = await regionDisksClient.DeleteAsync(project, region, disk);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            GetRegionDiskRequest request = new GetRegionDiskRequest
            {
                Disk = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Disk response = regionDisksClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetRegionDiskRequest, CallSettings)
            // Additional: GetAsync(GetRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            GetRegionDiskRequest request = new GetRegionDiskRequest
            {
                Disk = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Disk response = await regionDisksClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            // Make the request
            Disk response = regionDisksClient.Get(project, region, disk);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            // Make the request
            Disk response = await regionDisksClient.GetAsync(project, region, disk);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicyRequestObject()
        {
            // Snippet: GetIamPolicy(GetIamPolicyRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            GetIamPolicyRegionDiskRequest request = new GetIamPolicyRegionDiskRequest
            {
                Region = "",
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = regionDisksClient.GetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyRequestObjectAsync()
        {
            // Snippet: GetIamPolicyAsync(GetIamPolicyRegionDiskRequest, CallSettings)
            // Additional: GetIamPolicyAsync(GetIamPolicyRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            GetIamPolicyRegionDiskRequest request = new GetIamPolicyRegionDiskRequest
            {
                Region = "",
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = await regionDisksClient.GetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicy()
        {
            // Snippet: GetIamPolicy(string, string, string, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            // Make the request
            Policy response = regionDisksClient.GetIamPolicy(project, region, resource);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyAsync()
        {
            // Snippet: GetIamPolicyAsync(string, string, string, CallSettings)
            // Additional: GetIamPolicyAsync(string, string, string, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            // Make the request
            Policy response = await regionDisksClient.GetIamPolicyAsync(project, region, resource);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            InsertRegionDiskRequest request = new InsertRegionDiskRequest
            {
                DiskResource = new Disk(),
                RequestId = "",
                SourceImage = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionDisksClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertRegionDiskRequest, CallSettings)
            // Additional: InsertAsync(InsertRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            InsertRegionDiskRequest request = new InsertRegionDiskRequest
            {
                DiskResource = new Disk(),
                RequestId = "",
                SourceImage = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionDisksClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, Disk, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Disk diskResource = new Disk();
            // Make the request
            Operation response = regionDisksClient.Insert(project, region, diskResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, Disk, CallSettings)
            // Additional: InsertAsync(string, string, Disk, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            Disk diskResource = new Disk();
            // Make the request
            Operation response = await regionDisksClient.InsertAsync(project, region, diskResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListRegionDisksRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            ListRegionDisksRequest request = new ListRegionDisksRequest
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
            DiskList response = regionDisksClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListRegionDisksRequest, CallSettings)
            // Additional: ListAsync(ListRegionDisksRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            ListRegionDisksRequest request = new ListRegionDisksRequest
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
            DiskList response = await regionDisksClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            DiskList response = regionDisksClient.List(project, region);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            // Make the request
            DiskList response = await regionDisksClient.ListAsync(project, region);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePolicies</summary>
        public void RemoveResourcePoliciesRequestObject()
        {
            // Snippet: RemoveResourcePolicies(RemoveResourcePoliciesRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            RemoveResourcePoliciesRegionDiskRequest request = new RemoveResourcePoliciesRegionDiskRequest
            {
                Disk = "",
                RegionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest(),
                RequestId = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = regionDisksClient.RemoveResourcePolicies(request);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePoliciesAsync</summary>
        public async Task RemoveResourcePoliciesRequestObjectAsync()
        {
            // Snippet: RemoveResourcePoliciesAsync(RemoveResourcePoliciesRegionDiskRequest, CallSettings)
            // Additional: RemoveResourcePoliciesAsync(RemoveResourcePoliciesRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            RemoveResourcePoliciesRegionDiskRequest request = new RemoveResourcePoliciesRegionDiskRequest
            {
                Disk = "",
                RegionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest(),
                RequestId = "",
                Region = "",
                Project = "",
            };
            // Make the request
            Operation response = await regionDisksClient.RemoveResourcePoliciesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePolicies</summary>
        public void RemoveResourcePolicies()
        {
            // Snippet: RemoveResourcePolicies(string, string, string, RegionDisksRemoveResourcePoliciesRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            RegionDisksRemoveResourcePoliciesRequest regionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest();
            // Make the request
            Operation response = regionDisksClient.RemoveResourcePolicies(project, region, disk, regionDisksRemoveResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePoliciesAsync</summary>
        public async Task RemoveResourcePoliciesAsync()
        {
            // Snippet: RemoveResourcePoliciesAsync(string, string, string, RegionDisksRemoveResourcePoliciesRequest, CallSettings)
            // Additional: RemoveResourcePoliciesAsync(string, string, string, RegionDisksRemoveResourcePoliciesRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            RegionDisksRemoveResourcePoliciesRequest regionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest();
            // Make the request
            Operation response = await regionDisksClient.RemoveResourcePoliciesAsync(project, region, disk, regionDisksRemoveResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for Resize</summary>
        public void ResizeRequestObject()
        {
            // Snippet: Resize(ResizeRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            ResizeRegionDiskRequest request = new ResizeRegionDiskRequest
            {
                Disk = "",
                RequestId = "",
                Region = "",
                RegionDisksResizeRequestResource = new RegionDisksResizeRequest(),
                Project = "",
            };
            // Make the request
            Operation response = regionDisksClient.Resize(request);
            // End snippet
        }

        /// <summary>Snippet for ResizeAsync</summary>
        public async Task ResizeRequestObjectAsync()
        {
            // Snippet: ResizeAsync(ResizeRegionDiskRequest, CallSettings)
            // Additional: ResizeAsync(ResizeRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            ResizeRegionDiskRequest request = new ResizeRegionDiskRequest
            {
                Disk = "",
                RequestId = "",
                Region = "",
                RegionDisksResizeRequestResource = new RegionDisksResizeRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await regionDisksClient.ResizeAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Resize</summary>
        public void Resize()
        {
            // Snippet: Resize(string, string, string, RegionDisksResizeRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            RegionDisksResizeRequest regionDisksResizeRequestResource = new RegionDisksResizeRequest();
            // Make the request
            Operation response = regionDisksClient.Resize(project, region, disk, regionDisksResizeRequestResource);
            // End snippet
        }

        /// <summary>Snippet for ResizeAsync</summary>
        public async Task ResizeAsync()
        {
            // Snippet: ResizeAsync(string, string, string, RegionDisksResizeRequest, CallSettings)
            // Additional: ResizeAsync(string, string, string, RegionDisksResizeRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string disk = "";
            RegionDisksResizeRequest regionDisksResizeRequestResource = new RegionDisksResizeRequest();
            // Make the request
            Operation response = await regionDisksClient.ResizeAsync(project, region, disk, regionDisksResizeRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicyRequestObject()
        {
            // Snippet: SetIamPolicy(SetIamPolicyRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            SetIamPolicyRegionDiskRequest request = new SetIamPolicyRegionDiskRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "",
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = regionDisksClient.SetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyRequestObjectAsync()
        {
            // Snippet: SetIamPolicyAsync(SetIamPolicyRegionDiskRequest, CallSettings)
            // Additional: SetIamPolicyAsync(SetIamPolicyRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            SetIamPolicyRegionDiskRequest request = new SetIamPolicyRegionDiskRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "",
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = await regionDisksClient.SetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicy()
        {
            // Snippet: SetIamPolicy(string, string, string, RegionSetPolicyRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            RegionSetPolicyRequest regionSetPolicyRequestResource = new RegionSetPolicyRequest();
            // Make the request
            Policy response = regionDisksClient.SetIamPolicy(project, region, resource, regionSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyAsync()
        {
            // Snippet: SetIamPolicyAsync(string, string, string, RegionSetPolicyRequest, CallSettings)
            // Additional: SetIamPolicyAsync(string, string, string, RegionSetPolicyRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            RegionSetPolicyRequest regionSetPolicyRequestResource = new RegionSetPolicyRequest();
            // Make the request
            Policy response = await regionDisksClient.SetIamPolicyAsync(project, region, resource, regionSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetLabels</summary>
        public void SetLabelsRequestObject()
        {
            // Snippet: SetLabels(SetLabelsRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            SetLabelsRegionDiskRequest request = new SetLabelsRegionDiskRequest
            {
                RequestId = "",
                Region = "",
                Resource = "",
                Project = "",
                RegionSetLabelsRequestResource = new RegionSetLabelsRequest(),
            };
            // Make the request
            Operation response = regionDisksClient.SetLabels(request);
            // End snippet
        }

        /// <summary>Snippet for SetLabelsAsync</summary>
        public async Task SetLabelsRequestObjectAsync()
        {
            // Snippet: SetLabelsAsync(SetLabelsRegionDiskRequest, CallSettings)
            // Additional: SetLabelsAsync(SetLabelsRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            SetLabelsRegionDiskRequest request = new SetLabelsRegionDiskRequest
            {
                RequestId = "",
                Region = "",
                Resource = "",
                Project = "",
                RegionSetLabelsRequestResource = new RegionSetLabelsRequest(),
            };
            // Make the request
            Operation response = await regionDisksClient.SetLabelsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetLabels</summary>
        public void SetLabels()
        {
            // Snippet: SetLabels(string, string, string, RegionSetLabelsRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            RegionSetLabelsRequest regionSetLabelsRequestResource = new RegionSetLabelsRequest();
            // Make the request
            Operation response = regionDisksClient.SetLabels(project, region, resource, regionSetLabelsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetLabelsAsync</summary>
        public async Task SetLabelsAsync()
        {
            // Snippet: SetLabelsAsync(string, string, string, RegionSetLabelsRequest, CallSettings)
            // Additional: SetLabelsAsync(string, string, string, RegionSetLabelsRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            RegionSetLabelsRequest regionSetLabelsRequestResource = new RegionSetLabelsRequest();
            // Make the request
            Operation response = await regionDisksClient.SetLabelsAsync(project, region, resource, regionSetLabelsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissionsRequestObject()
        {
            // Snippet: TestIamPermissions(TestIamPermissionsRegionDiskRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            TestIamPermissionsRegionDiskRequest request = new TestIamPermissionsRegionDiskRequest
            {
                Region = "",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = regionDisksClient.TestIamPermissions(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsRequestObjectAsync()
        {
            // Snippet: TestIamPermissionsAsync(TestIamPermissionsRegionDiskRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(TestIamPermissionsRegionDiskRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            TestIamPermissionsRegionDiskRequest request = new TestIamPermissionsRegionDiskRequest
            {
                Region = "",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = await regionDisksClient.TestIamPermissionsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissions()
        {
            // Snippet: TestIamPermissions(string, string, string, TestPermissionsRequest, CallSettings)
            // Create client
            RegionDisksClient regionDisksClient = RegionDisksClient.Create();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = regionDisksClient.TestIamPermissions(project, region, resource, testPermissionsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsAsync()
        {
            // Snippet: TestIamPermissionsAsync(string, string, string, TestPermissionsRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(string, string, string, TestPermissionsRequest, CancellationToken)
            // Create client
            RegionDisksClient regionDisksClient = await RegionDisksClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string region = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = await regionDisksClient.TestIamPermissionsAsync(project, region, resource, testPermissionsRequestResource);
            // End snippet
        }
    }
}
