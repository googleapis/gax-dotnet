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
    public sealed class GeneratedProjectsClientSnippets
    {
        /// <summary>Snippet for DisableXpnHost</summary>
        public void DisableXpnHostRequestObject()
        {
            // Snippet: DisableXpnHost(DisableXpnHostProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            DisableXpnHostProjectRequest request = new DisableXpnHostProjectRequest
            {
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.DisableXpnHost(request);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnHostAsync</summary>
        public async Task DisableXpnHostRequestObjectAsync()
        {
            // Snippet: DisableXpnHostAsync(DisableXpnHostProjectRequest, CallSettings)
            // Additional: DisableXpnHostAsync(DisableXpnHostProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            DisableXpnHostProjectRequest request = new DisableXpnHostProjectRequest
            {
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.DisableXpnHostAsync(request);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnHost</summary>
        public void DisableXpnHost()
        {
            // Snippet: DisableXpnHost(string, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Operation response = projectsClient.DisableXpnHost(project);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnHostAsync</summary>
        public async Task DisableXpnHostAsync()
        {
            // Snippet: DisableXpnHostAsync(string, CallSettings)
            // Additional: DisableXpnHostAsync(string, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Operation response = await projectsClient.DisableXpnHostAsync(project);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnResource</summary>
        public void DisableXpnResourceRequestObject()
        {
            // Snippet: DisableXpnResource(DisableXpnResourceProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            DisableXpnResourceProjectRequest request = new DisableXpnResourceProjectRequest
            {
                RequestId = "",
                ProjectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest(),
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.DisableXpnResource(request);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnResourceAsync</summary>
        public async Task DisableXpnResourceRequestObjectAsync()
        {
            // Snippet: DisableXpnResourceAsync(DisableXpnResourceProjectRequest, CallSettings)
            // Additional: DisableXpnResourceAsync(DisableXpnResourceProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            DisableXpnResourceProjectRequest request = new DisableXpnResourceProjectRequest
            {
                RequestId = "",
                ProjectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.DisableXpnResourceAsync(request);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnResource</summary>
        public void DisableXpnResource()
        {
            // Snippet: DisableXpnResource(string, ProjectsDisableXpnResourceRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            ProjectsDisableXpnResourceRequest projectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest();
            // Make the request
            Operation response = projectsClient.DisableXpnResource(project, projectsDisableXpnResourceRequestResource);
            // End snippet
        }

        /// <summary>Snippet for DisableXpnResourceAsync</summary>
        public async Task DisableXpnResourceAsync()
        {
            // Snippet: DisableXpnResourceAsync(string, ProjectsDisableXpnResourceRequest, CallSettings)
            // Additional: DisableXpnResourceAsync(string, ProjectsDisableXpnResourceRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            ProjectsDisableXpnResourceRequest projectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest();
            // Make the request
            Operation response = await projectsClient.DisableXpnResourceAsync(project, projectsDisableXpnResourceRequestResource);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnHost</summary>
        public void EnableXpnHostRequestObject()
        {
            // Snippet: EnableXpnHost(EnableXpnHostProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            EnableXpnHostProjectRequest request = new EnableXpnHostProjectRequest
            {
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.EnableXpnHost(request);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnHostAsync</summary>
        public async Task EnableXpnHostRequestObjectAsync()
        {
            // Snippet: EnableXpnHostAsync(EnableXpnHostProjectRequest, CallSettings)
            // Additional: EnableXpnHostAsync(EnableXpnHostProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            EnableXpnHostProjectRequest request = new EnableXpnHostProjectRequest
            {
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.EnableXpnHostAsync(request);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnHost</summary>
        public void EnableXpnHost()
        {
            // Snippet: EnableXpnHost(string, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Operation response = projectsClient.EnableXpnHost(project);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnHostAsync</summary>
        public async Task EnableXpnHostAsync()
        {
            // Snippet: EnableXpnHostAsync(string, CallSettings)
            // Additional: EnableXpnHostAsync(string, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Operation response = await projectsClient.EnableXpnHostAsync(project);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnResource</summary>
        public void EnableXpnResourceRequestObject()
        {
            // Snippet: EnableXpnResource(EnableXpnResourceProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            EnableXpnResourceProjectRequest request = new EnableXpnResourceProjectRequest
            {
                RequestId = "",
                ProjectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest(),
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.EnableXpnResource(request);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnResourceAsync</summary>
        public async Task EnableXpnResourceRequestObjectAsync()
        {
            // Snippet: EnableXpnResourceAsync(EnableXpnResourceProjectRequest, CallSettings)
            // Additional: EnableXpnResourceAsync(EnableXpnResourceProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            EnableXpnResourceProjectRequest request = new EnableXpnResourceProjectRequest
            {
                RequestId = "",
                ProjectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.EnableXpnResourceAsync(request);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnResource</summary>
        public void EnableXpnResource()
        {
            // Snippet: EnableXpnResource(string, ProjectsEnableXpnResourceRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            ProjectsEnableXpnResourceRequest projectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest();
            // Make the request
            Operation response = projectsClient.EnableXpnResource(project, projectsEnableXpnResourceRequestResource);
            // End snippet
        }

        /// <summary>Snippet for EnableXpnResourceAsync</summary>
        public async Task EnableXpnResourceAsync()
        {
            // Snippet: EnableXpnResourceAsync(string, ProjectsEnableXpnResourceRequest, CallSettings)
            // Additional: EnableXpnResourceAsync(string, ProjectsEnableXpnResourceRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            ProjectsEnableXpnResourceRequest projectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest();
            // Make the request
            Operation response = await projectsClient.EnableXpnResourceAsync(project, projectsEnableXpnResourceRequestResource);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            GetProjectRequest request = new GetProjectRequest { Project = "", };
            // Make the request
            Project response = projectsClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetProjectRequest, CallSettings)
            // Additional: GetAsync(GetProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            GetProjectRequest request = new GetProjectRequest { Project = "", };
            // Make the request
            Project response = await projectsClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Project response = projectsClient.Get(project);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, CallSettings)
            // Additional: GetAsync(string, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Project response = await projectsClient.GetAsync(project);
            // End snippet
        }

        /// <summary>Snippet for GetXpnHost</summary>
        public void GetXpnHostRequestObject()
        {
            // Snippet: GetXpnHost(GetXpnHostProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            GetXpnHostProjectRequest request = new GetXpnHostProjectRequest { Project = "", };
            // Make the request
            Project response = projectsClient.GetXpnHost(request);
            // End snippet
        }

        /// <summary>Snippet for GetXpnHostAsync</summary>
        public async Task GetXpnHostRequestObjectAsync()
        {
            // Snippet: GetXpnHostAsync(GetXpnHostProjectRequest, CallSettings)
            // Additional: GetXpnHostAsync(GetXpnHostProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            GetXpnHostProjectRequest request = new GetXpnHostProjectRequest { Project = "", };
            // Make the request
            Project response = await projectsClient.GetXpnHostAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetXpnHost</summary>
        public void GetXpnHost()
        {
            // Snippet: GetXpnHost(string, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Project response = projectsClient.GetXpnHost(project);
            // End snippet
        }

        /// <summary>Snippet for GetXpnHostAsync</summary>
        public async Task GetXpnHostAsync()
        {
            // Snippet: GetXpnHostAsync(string, CallSettings)
            // Additional: GetXpnHostAsync(string, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            Project response = await projectsClient.GetXpnHostAsync(project);
            // End snippet
        }

        /// <summary>Snippet for GetXpnResources</summary>
        public void GetXpnResourcesRequestObject()
        {
            // Snippet: GetXpnResources(GetXpnResourcesProjectsRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            GetXpnResourcesProjectsRequest request = new GetXpnResourcesProjectsRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            ProjectsGetXpnResources response = projectsClient.GetXpnResources(request);
            // End snippet
        }

        /// <summary>Snippet for GetXpnResourcesAsync</summary>
        public async Task GetXpnResourcesRequestObjectAsync()
        {
            // Snippet: GetXpnResourcesAsync(GetXpnResourcesProjectsRequest, CallSettings)
            // Additional: GetXpnResourcesAsync(GetXpnResourcesProjectsRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            GetXpnResourcesProjectsRequest request = new GetXpnResourcesProjectsRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            ProjectsGetXpnResources response = await projectsClient.GetXpnResourcesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetXpnResources</summary>
        public void GetXpnResources()
        {
            // Snippet: GetXpnResources(string, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            ProjectsGetXpnResources response = projectsClient.GetXpnResources(project);
            // End snippet
        }

        /// <summary>Snippet for GetXpnResourcesAsync</summary>
        public async Task GetXpnResourcesAsync()
        {
            // Snippet: GetXpnResourcesAsync(string, CallSettings)
            // Additional: GetXpnResourcesAsync(string, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            ProjectsGetXpnResources response = await projectsClient.GetXpnResourcesAsync(project);
            // End snippet
        }

        /// <summary>Snippet for ListXpnHosts</summary>
        public void ListXpnHostsRequestObject()
        {
            // Snippet: ListXpnHosts(ListXpnHostsProjectsRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            ListXpnHostsProjectsRequest request = new ListXpnHostsProjectsRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ProjectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest(),
                ReturnPartialSuccess = false,
            };
            // Make the request
            XpnHostList response = projectsClient.ListXpnHosts(request);
            // End snippet
        }

        /// <summary>Snippet for ListXpnHostsAsync</summary>
        public async Task ListXpnHostsRequestObjectAsync()
        {
            // Snippet: ListXpnHostsAsync(ListXpnHostsProjectsRequest, CallSettings)
            // Additional: ListXpnHostsAsync(ListXpnHostsProjectsRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            ListXpnHostsProjectsRequest request = new ListXpnHostsProjectsRequest
            {
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ProjectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest(),
                ReturnPartialSuccess = false,
            };
            // Make the request
            XpnHostList response = await projectsClient.ListXpnHostsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for ListXpnHosts</summary>
        public void ListXpnHosts()
        {
            // Snippet: ListXpnHosts(string, ProjectsListXpnHostsRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            ProjectsListXpnHostsRequest projectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest();
            // Make the request
            XpnHostList response = projectsClient.ListXpnHosts(project, projectsListXpnHostsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for ListXpnHostsAsync</summary>
        public async Task ListXpnHostsAsync()
        {
            // Snippet: ListXpnHostsAsync(string, ProjectsListXpnHostsRequest, CallSettings)
            // Additional: ListXpnHostsAsync(string, ProjectsListXpnHostsRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            ProjectsListXpnHostsRequest projectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest();
            // Make the request
            XpnHostList response = await projectsClient.ListXpnHostsAsync(project, projectsListXpnHostsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for MoveDisk</summary>
        public void MoveDiskRequestObject()
        {
            // Snippet: MoveDisk(MoveDiskProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            MoveDiskProjectRequest request = new MoveDiskProjectRequest
            {
                RequestId = "",
                DiskMoveRequestResource = new DiskMoveRequest(),
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.MoveDisk(request);
            // End snippet
        }

        /// <summary>Snippet for MoveDiskAsync</summary>
        public async Task MoveDiskRequestObjectAsync()
        {
            // Snippet: MoveDiskAsync(MoveDiskProjectRequest, CallSettings)
            // Additional: MoveDiskAsync(MoveDiskProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            MoveDiskProjectRequest request = new MoveDiskProjectRequest
            {
                RequestId = "",
                DiskMoveRequestResource = new DiskMoveRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.MoveDiskAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MoveDisk</summary>
        public void MoveDisk()
        {
            // Snippet: MoveDisk(string, DiskMoveRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            DiskMoveRequest diskMoveRequestResource = new DiskMoveRequest();
            // Make the request
            Operation response = projectsClient.MoveDisk(project, diskMoveRequestResource);
            // End snippet
        }

        /// <summary>Snippet for MoveDiskAsync</summary>
        public async Task MoveDiskAsync()
        {
            // Snippet: MoveDiskAsync(string, DiskMoveRequest, CallSettings)
            // Additional: MoveDiskAsync(string, DiskMoveRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            DiskMoveRequest diskMoveRequestResource = new DiskMoveRequest();
            // Make the request
            Operation response = await projectsClient.MoveDiskAsync(project, diskMoveRequestResource);
            // End snippet
        }

        /// <summary>Snippet for MoveInstance</summary>
        public void MoveInstanceRequestObject()
        {
            // Snippet: MoveInstance(MoveInstanceProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            MoveInstanceProjectRequest request = new MoveInstanceProjectRequest
            {
                RequestId = "",
                InstanceMoveRequestResource = new InstanceMoveRequest(),
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.MoveInstance(request);
            // End snippet
        }

        /// <summary>Snippet for MoveInstanceAsync</summary>
        public async Task MoveInstanceRequestObjectAsync()
        {
            // Snippet: MoveInstanceAsync(MoveInstanceProjectRequest, CallSettings)
            // Additional: MoveInstanceAsync(MoveInstanceProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            MoveInstanceProjectRequest request = new MoveInstanceProjectRequest
            {
                RequestId = "",
                InstanceMoveRequestResource = new InstanceMoveRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.MoveInstanceAsync(request);
            // End snippet
        }

        /// <summary>Snippet for MoveInstance</summary>
        public void MoveInstance()
        {
            // Snippet: MoveInstance(string, InstanceMoveRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            InstanceMoveRequest instanceMoveRequestResource = new InstanceMoveRequest();
            // Make the request
            Operation response = projectsClient.MoveInstance(project, instanceMoveRequestResource);
            // End snippet
        }

        /// <summary>Snippet for MoveInstanceAsync</summary>
        public async Task MoveInstanceAsync()
        {
            // Snippet: MoveInstanceAsync(string, InstanceMoveRequest, CallSettings)
            // Additional: MoveInstanceAsync(string, InstanceMoveRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            InstanceMoveRequest instanceMoveRequestResource = new InstanceMoveRequest();
            // Make the request
            Operation response = await projectsClient.MoveInstanceAsync(project, instanceMoveRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetCommonInstanceMetadata</summary>
        public void SetCommonInstanceMetadataRequestObject()
        {
            // Snippet: SetCommonInstanceMetadata(SetCommonInstanceMetadataProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            SetCommonInstanceMetadataProjectRequest request = new SetCommonInstanceMetadataProjectRequest
            {
                MetadataResource = new Metadata(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.SetCommonInstanceMetadata(request);
            // End snippet
        }

        /// <summary>Snippet for SetCommonInstanceMetadataAsync</summary>
        public async Task SetCommonInstanceMetadataRequestObjectAsync()
        {
            // Snippet: SetCommonInstanceMetadataAsync(SetCommonInstanceMetadataProjectRequest, CallSettings)
            // Additional: SetCommonInstanceMetadataAsync(SetCommonInstanceMetadataProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            SetCommonInstanceMetadataProjectRequest request = new SetCommonInstanceMetadataProjectRequest
            {
                MetadataResource = new Metadata(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.SetCommonInstanceMetadataAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetCommonInstanceMetadata</summary>
        public void SetCommonInstanceMetadata()
        {
            // Snippet: SetCommonInstanceMetadata(string, Metadata, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            Metadata metadataResource = new Metadata();
            // Make the request
            Operation response = projectsClient.SetCommonInstanceMetadata(project, metadataResource);
            // End snippet
        }

        /// <summary>Snippet for SetCommonInstanceMetadataAsync</summary>
        public async Task SetCommonInstanceMetadataAsync()
        {
            // Snippet: SetCommonInstanceMetadataAsync(string, Metadata, CallSettings)
            // Additional: SetCommonInstanceMetadataAsync(string, Metadata, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            Metadata metadataResource = new Metadata();
            // Make the request
            Operation response = await projectsClient.SetCommonInstanceMetadataAsync(project, metadataResource);
            // End snippet
        }

        /// <summary>Snippet for SetDefaultNetworkTier</summary>
        public void SetDefaultNetworkTierRequestObject()
        {
            // Snippet: SetDefaultNetworkTier(SetDefaultNetworkTierProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            SetDefaultNetworkTierProjectRequest request = new SetDefaultNetworkTierProjectRequest
            {
                RequestId = "",
                ProjectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest(),
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.SetDefaultNetworkTier(request);
            // End snippet
        }

        /// <summary>Snippet for SetDefaultNetworkTierAsync</summary>
        public async Task SetDefaultNetworkTierRequestObjectAsync()
        {
            // Snippet: SetDefaultNetworkTierAsync(SetDefaultNetworkTierProjectRequest, CallSettings)
            // Additional: SetDefaultNetworkTierAsync(SetDefaultNetworkTierProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            SetDefaultNetworkTierProjectRequest request = new SetDefaultNetworkTierProjectRequest
            {
                RequestId = "",
                ProjectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.SetDefaultNetworkTierAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetDefaultNetworkTier</summary>
        public void SetDefaultNetworkTier()
        {
            // Snippet: SetDefaultNetworkTier(string, ProjectsSetDefaultNetworkTierRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            ProjectsSetDefaultNetworkTierRequest projectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest();
            // Make the request
            Operation response = projectsClient.SetDefaultNetworkTier(project, projectsSetDefaultNetworkTierRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetDefaultNetworkTierAsync</summary>
        public async Task SetDefaultNetworkTierAsync()
        {
            // Snippet: SetDefaultNetworkTierAsync(string, ProjectsSetDefaultNetworkTierRequest, CallSettings)
            // Additional: SetDefaultNetworkTierAsync(string, ProjectsSetDefaultNetworkTierRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            ProjectsSetDefaultNetworkTierRequest projectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest();
            // Make the request
            Operation response = await projectsClient.SetDefaultNetworkTierAsync(project, projectsSetDefaultNetworkTierRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetUsageExportBucket</summary>
        public void SetUsageExportBucketRequestObject()
        {
            // Snippet: SetUsageExportBucket(SetUsageExportBucketProjectRequest, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            SetUsageExportBucketProjectRequest request = new SetUsageExportBucketProjectRequest
            {
                UsageExportLocationResource = new UsageExportLocation(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = projectsClient.SetUsageExportBucket(request);
            // End snippet
        }

        /// <summary>Snippet for SetUsageExportBucketAsync</summary>
        public async Task SetUsageExportBucketRequestObjectAsync()
        {
            // Snippet: SetUsageExportBucketAsync(SetUsageExportBucketProjectRequest, CallSettings)
            // Additional: SetUsageExportBucketAsync(SetUsageExportBucketProjectRequest, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            SetUsageExportBucketProjectRequest request = new SetUsageExportBucketProjectRequest
            {
                UsageExportLocationResource = new UsageExportLocation(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await projectsClient.SetUsageExportBucketAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetUsageExportBucket</summary>
        public void SetUsageExportBucket()
        {
            // Snippet: SetUsageExportBucket(string, UsageExportLocation, CallSettings)
            // Create client
            ProjectsClient projectsClient = ProjectsClient.Create();
            // Initialize request argument(s)
            string project = "";
            UsageExportLocation usageExportLocationResource = new UsageExportLocation();
            // Make the request
            Operation response = projectsClient.SetUsageExportBucket(project, usageExportLocationResource);
            // End snippet
        }

        /// <summary>Snippet for SetUsageExportBucketAsync</summary>
        public async Task SetUsageExportBucketAsync()
        {
            // Snippet: SetUsageExportBucketAsync(string, UsageExportLocation, CallSettings)
            // Additional: SetUsageExportBucketAsync(string, UsageExportLocation, CancellationToken)
            // Create client
            ProjectsClient projectsClient = await ProjectsClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            UsageExportLocation usageExportLocationResource = new UsageExportLocation();
            // Make the request
            Operation response = await projectsClient.SetUsageExportBucketAsync(project, usageExportLocationResource);
            // End snippet
        }
    }
}
