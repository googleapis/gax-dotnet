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
    public sealed class GeneratedInstancesClientSnippets
    {
        /// <summary>Snippet for AddAccessConfig</summary>
        public void AddAccessConfigRequestObject()
        {
            // Snippet: AddAccessConfig(AddAccessConfigInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            AddAccessConfigInstanceRequest request = new AddAccessConfigInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                NetworkInterface = "",
                AccessConfigResource = new AccessConfig(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.AddAccessConfig(request);
            // End snippet
        }

        /// <summary>Snippet for AddAccessConfigAsync</summary>
        public async Task AddAccessConfigRequestObjectAsync()
        {
            // Snippet: AddAccessConfigAsync(AddAccessConfigInstanceRequest, CallSettings)
            // Additional: AddAccessConfigAsync(AddAccessConfigInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            AddAccessConfigInstanceRequest request = new AddAccessConfigInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                NetworkInterface = "",
                AccessConfigResource = new AccessConfig(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.AddAccessConfigAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AddAccessConfig</summary>
        public void AddAccessConfig()
        {
            // Snippet: AddAccessConfig(string, string, string, string, AccessConfig, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string networkInterface = "";
            AccessConfig accessConfigResource = new AccessConfig();
            // Make the request
            Operation response = instancesClient.AddAccessConfig(project, zone, instance, networkInterface, accessConfigResource);
            // End snippet
        }

        /// <summary>Snippet for AddAccessConfigAsync</summary>
        public async Task AddAccessConfigAsync()
        {
            // Snippet: AddAccessConfigAsync(string, string, string, string, AccessConfig, CallSettings)
            // Additional: AddAccessConfigAsync(string, string, string, string, AccessConfig, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string networkInterface = "";
            AccessConfig accessConfigResource = new AccessConfig();
            // Make the request
            Operation response = await instancesClient.AddAccessConfigAsync(project, zone, instance, networkInterface, accessConfigResource);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePolicies</summary>
        public void AddResourcePoliciesRequestObject()
        {
            // Snippet: AddResourcePolicies(AddResourcePoliciesInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            AddResourcePoliciesInstanceRequest request = new AddResourcePoliciesInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesAddResourcePoliciesRequestResource = new InstancesAddResourcePoliciesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.AddResourcePolicies(request);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePoliciesAsync</summary>
        public async Task AddResourcePoliciesRequestObjectAsync()
        {
            // Snippet: AddResourcePoliciesAsync(AddResourcePoliciesInstanceRequest, CallSettings)
            // Additional: AddResourcePoliciesAsync(AddResourcePoliciesInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            AddResourcePoliciesInstanceRequest request = new AddResourcePoliciesInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesAddResourcePoliciesRequestResource = new InstancesAddResourcePoliciesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.AddResourcePoliciesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePolicies</summary>
        public void AddResourcePolicies()
        {
            // Snippet: AddResourcePolicies(string, string, string, InstancesAddResourcePoliciesRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesAddResourcePoliciesRequest instancesAddResourcePoliciesRequestResource = new InstancesAddResourcePoliciesRequest();
            // Make the request
            Operation response = instancesClient.AddResourcePolicies(project, zone, instance, instancesAddResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for AddResourcePoliciesAsync</summary>
        public async Task AddResourcePoliciesAsync()
        {
            // Snippet: AddResourcePoliciesAsync(string, string, string, InstancesAddResourcePoliciesRequest, CallSettings)
            // Additional: AddResourcePoliciesAsync(string, string, string, InstancesAddResourcePoliciesRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesAddResourcePoliciesRequest instancesAddResourcePoliciesRequestResource = new InstancesAddResourcePoliciesRequest();
            // Make the request
            Operation response = await instancesClient.AddResourcePoliciesAsync(project, zone, instance, instancesAddResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedListRequestObject()
        {
            // Snippet: AggregatedList(AggregatedListInstancesRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            AggregatedListInstancesRequest request = new AggregatedListInstancesRequest
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
            InstanceAggregatedList response = instancesClient.AggregatedList(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListRequestObjectAsync()
        {
            // Snippet: AggregatedListAsync(AggregatedListInstancesRequest, CallSettings)
            // Additional: AggregatedListAsync(AggregatedListInstancesRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            AggregatedListInstancesRequest request = new AggregatedListInstancesRequest
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
            InstanceAggregatedList response = await instancesClient.AggregatedListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AggregatedList</summary>
        public void AggregatedList()
        {
            // Snippet: AggregatedList(string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            InstanceAggregatedList response = instancesClient.AggregatedList(project);
            // End snippet
        }

        /// <summary>Snippet for AggregatedListAsync</summary>
        public async Task AggregatedListAsync()
        {
            // Snippet: AggregatedListAsync(string, CallSettings)
            // Additional: AggregatedListAsync(string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            // Make the request
            InstanceAggregatedList response = await instancesClient.AggregatedListAsync(project);
            // End snippet
        }

        /// <summary>Snippet for AttachDisk</summary>
        public void AttachDiskRequestObject()
        {
            // Snippet: AttachDisk(AttachDiskInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            AttachDiskInstanceRequest request = new AttachDiskInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                AttachedDiskResource = new AttachedDisk(),
                ForceAttach = false,
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.AttachDisk(request);
            // End snippet
        }

        /// <summary>Snippet for AttachDiskAsync</summary>
        public async Task AttachDiskRequestObjectAsync()
        {
            // Snippet: AttachDiskAsync(AttachDiskInstanceRequest, CallSettings)
            // Additional: AttachDiskAsync(AttachDiskInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            AttachDiskInstanceRequest request = new AttachDiskInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                AttachedDiskResource = new AttachedDisk(),
                ForceAttach = false,
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.AttachDiskAsync(request);
            // End snippet
        }

        /// <summary>Snippet for AttachDisk</summary>
        public void AttachDisk()
        {
            // Snippet: AttachDisk(string, string, string, AttachedDisk, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            AttachedDisk attachedDiskResource = new AttachedDisk();
            // Make the request
            Operation response = instancesClient.AttachDisk(project, zone, instance, attachedDiskResource);
            // End snippet
        }

        /// <summary>Snippet for AttachDiskAsync</summary>
        public async Task AttachDiskAsync()
        {
            // Snippet: AttachDiskAsync(string, string, string, AttachedDisk, CallSettings)
            // Additional: AttachDiskAsync(string, string, string, AttachedDisk, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            AttachedDisk attachedDiskResource = new AttachedDisk();
            // Make the request
            Operation response = await instancesClient.AttachDiskAsync(project, zone, instance, attachedDiskResource);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void DeleteRequestObject()
        {
            // Snippet: Delete(DeleteInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            DeleteInstanceRequest request = new DeleteInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.Delete(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteRequestObjectAsync()
        {
            // Snippet: DeleteAsync(DeleteInstanceRequest, CallSettings)
            // Additional: DeleteAsync(DeleteInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteInstanceRequest request = new DeleteInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.DeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Delete</summary>
        public void Delete()
        {
            // Snippet: Delete(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = instancesClient.Delete(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for DeleteAsync</summary>
        public async Task DeleteAsync()
        {
            // Snippet: DeleteAsync(string, string, string, CallSettings)
            // Additional: DeleteAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = await instancesClient.DeleteAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for DeleteAccessConfig</summary>
        public void DeleteAccessConfigRequestObject()
        {
            // Snippet: DeleteAccessConfig(DeleteAccessConfigInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            DeleteAccessConfigInstanceRequest request = new DeleteAccessConfigInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                AccessConfig = "",
                NetworkInterface = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.DeleteAccessConfig(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAccessConfigAsync</summary>
        public async Task DeleteAccessConfigRequestObjectAsync()
        {
            // Snippet: DeleteAccessConfigAsync(DeleteAccessConfigInstanceRequest, CallSettings)
            // Additional: DeleteAccessConfigAsync(DeleteAccessConfigInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            DeleteAccessConfigInstanceRequest request = new DeleteAccessConfigInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                AccessConfig = "",
                NetworkInterface = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.DeleteAccessConfigAsync(request);
            // End snippet
        }

        /// <summary>Snippet for DeleteAccessConfig</summary>
        public void DeleteAccessConfig()
        {
            // Snippet: DeleteAccessConfig(string, string, string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string accessConfig = "";
            string networkInterface = "";
            // Make the request
            Operation response = instancesClient.DeleteAccessConfig(project, zone, instance, accessConfig, networkInterface);
            // End snippet
        }

        /// <summary>Snippet for DeleteAccessConfigAsync</summary>
        public async Task DeleteAccessConfigAsync()
        {
            // Snippet: DeleteAccessConfigAsync(string, string, string, string, string, CallSettings)
            // Additional: DeleteAccessConfigAsync(string, string, string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string accessConfig = "";
            string networkInterface = "";
            // Make the request
            Operation response = await instancesClient.DeleteAccessConfigAsync(project, zone, instance, accessConfig, networkInterface);
            // End snippet
        }

        /// <summary>Snippet for DetachDisk</summary>
        public void DetachDiskRequestObject()
        {
            // Snippet: DetachDisk(DetachDiskInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            DetachDiskInstanceRequest request = new DetachDiskInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                DeviceName = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.DetachDisk(request);
            // End snippet
        }

        /// <summary>Snippet for DetachDiskAsync</summary>
        public async Task DetachDiskRequestObjectAsync()
        {
            // Snippet: DetachDiskAsync(DetachDiskInstanceRequest, CallSettings)
            // Additional: DetachDiskAsync(DetachDiskInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            DetachDiskInstanceRequest request = new DetachDiskInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                DeviceName = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.DetachDiskAsync(request);
            // End snippet
        }

        /// <summary>Snippet for DetachDisk</summary>
        public void DetachDisk()
        {
            // Snippet: DetachDisk(string, string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string deviceName = "";
            // Make the request
            Operation response = instancesClient.DetachDisk(project, zone, instance, deviceName);
            // End snippet
        }

        /// <summary>Snippet for DetachDiskAsync</summary>
        public async Task DetachDiskAsync()
        {
            // Snippet: DetachDiskAsync(string, string, string, string, CallSettings)
            // Additional: DetachDiskAsync(string, string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string deviceName = "";
            // Make the request
            Operation response = await instancesClient.DetachDiskAsync(project, zone, instance, deviceName);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void GetRequestObject()
        {
            // Snippet: Get(GetInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            GetInstanceRequest request = new GetInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            Instance response = instancesClient.Get(request);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetRequestObjectAsync()
        {
            // Snippet: GetAsync(GetInstanceRequest, CallSettings)
            // Additional: GetAsync(GetInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            GetInstanceRequest request = new GetInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            Instance response = await instancesClient.GetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Get</summary>
        public void Get()
        {
            // Snippet: Get(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Instance response = instancesClient.Get(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetAsync</summary>
        public async Task GetAsync()
        {
            // Snippet: GetAsync(string, string, string, CallSettings)
            // Additional: GetAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Instance response = await instancesClient.GetAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetGuestAttributes</summary>
        public void GetGuestAttributesRequestObject()
        {
            // Snippet: GetGuestAttributes(GetGuestAttributesInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            GetGuestAttributesInstanceRequest request = new GetGuestAttributesInstanceRequest
            {
                Zone = "",
                Instance = "",
                QueryPath = "",
                VariableKey = "",
                Project = "",
            };
            // Make the request
            GuestAttributes response = instancesClient.GetGuestAttributes(request);
            // End snippet
        }

        /// <summary>Snippet for GetGuestAttributesAsync</summary>
        public async Task GetGuestAttributesRequestObjectAsync()
        {
            // Snippet: GetGuestAttributesAsync(GetGuestAttributesInstanceRequest, CallSettings)
            // Additional: GetGuestAttributesAsync(GetGuestAttributesInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            GetGuestAttributesInstanceRequest request = new GetGuestAttributesInstanceRequest
            {
                Zone = "",
                Instance = "",
                QueryPath = "",
                VariableKey = "",
                Project = "",
            };
            // Make the request
            GuestAttributes response = await instancesClient.GetGuestAttributesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetGuestAttributes</summary>
        public void GetGuestAttributes()
        {
            // Snippet: GetGuestAttributes(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            GuestAttributes response = instancesClient.GetGuestAttributes(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetGuestAttributesAsync</summary>
        public async Task GetGuestAttributesAsync()
        {
            // Snippet: GetGuestAttributesAsync(string, string, string, CallSettings)
            // Additional: GetGuestAttributesAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            GuestAttributes response = await instancesClient.GetGuestAttributesAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicyRequestObject()
        {
            // Snippet: GetIamPolicy(GetIamPolicyInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            GetIamPolicyInstanceRequest request = new GetIamPolicyInstanceRequest
            {
                Zone = "",
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = instancesClient.GetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyRequestObjectAsync()
        {
            // Snippet: GetIamPolicyAsync(GetIamPolicyInstanceRequest, CallSettings)
            // Additional: GetIamPolicyAsync(GetIamPolicyInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            GetIamPolicyInstanceRequest request = new GetIamPolicyInstanceRequest
            {
                Zone = "",
                Resource = "",
                Project = "",
                OptionsRequestedPolicyVersion = 0,
            };
            // Make the request
            Policy response = await instancesClient.GetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicy</summary>
        public void GetIamPolicy()
        {
            // Snippet: GetIamPolicy(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            // Make the request
            Policy response = instancesClient.GetIamPolicy(project, zone, resource);
            // End snippet
        }

        /// <summary>Snippet for GetIamPolicyAsync</summary>
        public async Task GetIamPolicyAsync()
        {
            // Snippet: GetIamPolicyAsync(string, string, string, CallSettings)
            // Additional: GetIamPolicyAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            // Make the request
            Policy response = await instancesClient.GetIamPolicyAsync(project, zone, resource);
            // End snippet
        }

        /// <summary>Snippet for GetScreenshot</summary>
        public void GetScreenshotRequestObject()
        {
            // Snippet: GetScreenshot(GetScreenshotInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            GetScreenshotInstanceRequest request = new GetScreenshotInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            Screenshot response = instancesClient.GetScreenshot(request);
            // End snippet
        }

        /// <summary>Snippet for GetScreenshotAsync</summary>
        public async Task GetScreenshotRequestObjectAsync()
        {
            // Snippet: GetScreenshotAsync(GetScreenshotInstanceRequest, CallSettings)
            // Additional: GetScreenshotAsync(GetScreenshotInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            GetScreenshotInstanceRequest request = new GetScreenshotInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            Screenshot response = await instancesClient.GetScreenshotAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetScreenshot</summary>
        public void GetScreenshot()
        {
            // Snippet: GetScreenshot(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Screenshot response = instancesClient.GetScreenshot(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetScreenshotAsync</summary>
        public async Task GetScreenshotAsync()
        {
            // Snippet: GetScreenshotAsync(string, string, string, CallSettings)
            // Additional: GetScreenshotAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Screenshot response = await instancesClient.GetScreenshotAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetSerialPortOutput</summary>
        public void GetSerialPortOutputRequestObject()
        {
            // Snippet: GetSerialPortOutput(GetSerialPortOutputInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            GetSerialPortOutputInstanceRequest request = new GetSerialPortOutputInstanceRequest
            {
                Port = 0,
                Zone = "",
                Instance = "",
                Start = "",
                Project = "",
            };
            // Make the request
            SerialPortOutput response = instancesClient.GetSerialPortOutput(request);
            // End snippet
        }

        /// <summary>Snippet for GetSerialPortOutputAsync</summary>
        public async Task GetSerialPortOutputRequestObjectAsync()
        {
            // Snippet: GetSerialPortOutputAsync(GetSerialPortOutputInstanceRequest, CallSettings)
            // Additional: GetSerialPortOutputAsync(GetSerialPortOutputInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            GetSerialPortOutputInstanceRequest request = new GetSerialPortOutputInstanceRequest
            {
                Port = 0,
                Zone = "",
                Instance = "",
                Start = "",
                Project = "",
            };
            // Make the request
            SerialPortOutput response = await instancesClient.GetSerialPortOutputAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetSerialPortOutput</summary>
        public void GetSerialPortOutput()
        {
            // Snippet: GetSerialPortOutput(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            SerialPortOutput response = instancesClient.GetSerialPortOutput(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetSerialPortOutputAsync</summary>
        public async Task GetSerialPortOutputAsync()
        {
            // Snippet: GetSerialPortOutputAsync(string, string, string, CallSettings)
            // Additional: GetSerialPortOutputAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            SerialPortOutput response = await instancesClient.GetSerialPortOutputAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetShieldedInstanceIdentity</summary>
        public void GetShieldedInstanceIdentityRequestObject()
        {
            // Snippet: GetShieldedInstanceIdentity(GetShieldedInstanceIdentityInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            GetShieldedInstanceIdentityInstanceRequest request = new GetShieldedInstanceIdentityInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            ShieldedInstanceIdentity response = instancesClient.GetShieldedInstanceIdentity(request);
            // End snippet
        }

        /// <summary>Snippet for GetShieldedInstanceIdentityAsync</summary>
        public async Task GetShieldedInstanceIdentityRequestObjectAsync()
        {
            // Snippet: GetShieldedInstanceIdentityAsync(GetShieldedInstanceIdentityInstanceRequest, CallSettings)
            // Additional: GetShieldedInstanceIdentityAsync(GetShieldedInstanceIdentityInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            GetShieldedInstanceIdentityInstanceRequest request = new GetShieldedInstanceIdentityInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            ShieldedInstanceIdentity response = await instancesClient.GetShieldedInstanceIdentityAsync(request);
            // End snippet
        }

        /// <summary>Snippet for GetShieldedInstanceIdentity</summary>
        public void GetShieldedInstanceIdentity()
        {
            // Snippet: GetShieldedInstanceIdentity(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            ShieldedInstanceIdentity response = instancesClient.GetShieldedInstanceIdentity(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for GetShieldedInstanceIdentityAsync</summary>
        public async Task GetShieldedInstanceIdentityAsync()
        {
            // Snippet: GetShieldedInstanceIdentityAsync(string, string, string, CallSettings)
            // Additional: GetShieldedInstanceIdentityAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            ShieldedInstanceIdentity response = await instancesClient.GetShieldedInstanceIdentityAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void InsertRequestObject()
        {
            // Snippet: Insert(InsertInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            InsertInstanceRequest request = new InsertInstanceRequest
            {
                Zone = "",
                RequestId = "",
                SourceInstanceTemplate = "",
                InstanceResource = new Instance(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.Insert(request);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertRequestObjectAsync()
        {
            // Snippet: InsertAsync(InsertInstanceRequest, CallSettings)
            // Additional: InsertAsync(InsertInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            InsertInstanceRequest request = new InsertInstanceRequest
            {
                Zone = "",
                RequestId = "",
                SourceInstanceTemplate = "",
                InstanceResource = new Instance(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.InsertAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Insert</summary>
        public void Insert()
        {
            // Snippet: Insert(string, string, Instance, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Instance instanceResource = new Instance();
            // Make the request
            Operation response = instancesClient.Insert(project, zone, instanceResource);
            // End snippet
        }

        /// <summary>Snippet for InsertAsync</summary>
        public async Task InsertAsync()
        {
            // Snippet: InsertAsync(string, string, Instance, CallSettings)
            // Additional: InsertAsync(string, string, Instance, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            Instance instanceResource = new Instance();
            // Make the request
            Operation response = await instancesClient.InsertAsync(project, zone, instanceResource);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void ListRequestObject()
        {
            // Snippet: List(ListInstancesRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            ListInstancesRequest request = new ListInstancesRequest
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
            InstanceList response = instancesClient.List(request);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListRequestObjectAsync()
        {
            // Snippet: ListAsync(ListInstancesRequest, CallSettings)
            // Additional: ListAsync(ListInstancesRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            ListInstancesRequest request = new ListInstancesRequest
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
            InstanceList response = await instancesClient.ListAsync(request);
            // End snippet
        }

        /// <summary>Snippet for List</summary>
        public void List()
        {
            // Snippet: List(string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            // Make the request
            InstanceList response = instancesClient.List(project, zone);
            // End snippet
        }

        /// <summary>Snippet for ListAsync</summary>
        public async Task ListAsync()
        {
            // Snippet: ListAsync(string, string, CallSettings)
            // Additional: ListAsync(string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            // Make the request
            InstanceList response = await instancesClient.ListAsync(project, zone);
            // End snippet
        }

        /// <summary>Snippet for ListReferrers</summary>
        public void ListReferrersRequestObject()
        {
            // Snippet: ListReferrers(ListReferrersInstancesRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            ListReferrersInstancesRequest request = new ListReferrersInstancesRequest
            {
                Zone = "",
                Instance = "",
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            InstanceListReferrers response = instancesClient.ListReferrers(request);
            // End snippet
        }

        /// <summary>Snippet for ListReferrersAsync</summary>
        public async Task ListReferrersRequestObjectAsync()
        {
            // Snippet: ListReferrersAsync(ListReferrersInstancesRequest, CallSettings)
            // Additional: ListReferrersAsync(ListReferrersInstancesRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            ListReferrersInstancesRequest request = new ListReferrersInstancesRequest
            {
                Zone = "",
                Instance = "",
                PageToken = "",
                MaxResults = 0U,
                Filter = "",
                OrderBy = "",
                Project = "",
                ReturnPartialSuccess = false,
            };
            // Make the request
            InstanceListReferrers response = await instancesClient.ListReferrersAsync(request);
            // End snippet
        }

        /// <summary>Snippet for ListReferrers</summary>
        public void ListReferrers()
        {
            // Snippet: ListReferrers(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            InstanceListReferrers response = instancesClient.ListReferrers(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for ListReferrersAsync</summary>
        public async Task ListReferrersAsync()
        {
            // Snippet: ListReferrersAsync(string, string, string, CallSettings)
            // Additional: ListReferrersAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            InstanceListReferrers response = await instancesClient.ListReferrersAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePolicies</summary>
        public void RemoveResourcePoliciesRequestObject()
        {
            // Snippet: RemoveResourcePolicies(RemoveResourcePoliciesInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            RemoveResourcePoliciesInstanceRequest request = new RemoveResourcePoliciesInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesRemoveResourcePoliciesRequestResource = new InstancesRemoveResourcePoliciesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.RemoveResourcePolicies(request);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePoliciesAsync</summary>
        public async Task RemoveResourcePoliciesRequestObjectAsync()
        {
            // Snippet: RemoveResourcePoliciesAsync(RemoveResourcePoliciesInstanceRequest, CallSettings)
            // Additional: RemoveResourcePoliciesAsync(RemoveResourcePoliciesInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            RemoveResourcePoliciesInstanceRequest request = new RemoveResourcePoliciesInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesRemoveResourcePoliciesRequestResource = new InstancesRemoveResourcePoliciesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.RemoveResourcePoliciesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePolicies</summary>
        public void RemoveResourcePolicies()
        {
            // Snippet: RemoveResourcePolicies(string, string, string, InstancesRemoveResourcePoliciesRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesRemoveResourcePoliciesRequest instancesRemoveResourcePoliciesRequestResource = new InstancesRemoveResourcePoliciesRequest();
            // Make the request
            Operation response = instancesClient.RemoveResourcePolicies(project, zone, instance, instancesRemoveResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for RemoveResourcePoliciesAsync</summary>
        public async Task RemoveResourcePoliciesAsync()
        {
            // Snippet: RemoveResourcePoliciesAsync(string, string, string, InstancesRemoveResourcePoliciesRequest, CallSettings)
            // Additional: RemoveResourcePoliciesAsync(string, string, string, InstancesRemoveResourcePoliciesRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesRemoveResourcePoliciesRequest instancesRemoveResourcePoliciesRequestResource = new InstancesRemoveResourcePoliciesRequest();
            // Make the request
            Operation response = await instancesClient.RemoveResourcePoliciesAsync(project, zone, instance, instancesRemoveResourcePoliciesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for Reset</summary>
        public void ResetRequestObject()
        {
            // Snippet: Reset(ResetInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            ResetInstanceRequest request = new ResetInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.Reset(request);
            // End snippet
        }

        /// <summary>Snippet for ResetAsync</summary>
        public async Task ResetRequestObjectAsync()
        {
            // Snippet: ResetAsync(ResetInstanceRequest, CallSettings)
            // Additional: ResetAsync(ResetInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            ResetInstanceRequest request = new ResetInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.ResetAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Reset</summary>
        public void Reset()
        {
            // Snippet: Reset(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = instancesClient.Reset(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for ResetAsync</summary>
        public async Task ResetAsync()
        {
            // Snippet: ResetAsync(string, string, string, CallSettings)
            // Additional: ResetAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = await instancesClient.ResetAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for SetDeletionProtection</summary>
        public void SetDeletionProtectionRequestObject()
        {
            // Snippet: SetDeletionProtection(SetDeletionProtectionInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetDeletionProtectionInstanceRequest request = new SetDeletionProtectionInstanceRequest
            {
                Zone = "",
                RequestId = "",
                DeletionProtection = false,
                Resource = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetDeletionProtection(request);
            // End snippet
        }

        /// <summary>Snippet for SetDeletionProtectionAsync</summary>
        public async Task SetDeletionProtectionRequestObjectAsync()
        {
            // Snippet: SetDeletionProtectionAsync(SetDeletionProtectionInstanceRequest, CallSettings)
            // Additional: SetDeletionProtectionAsync(SetDeletionProtectionInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetDeletionProtectionInstanceRequest request = new SetDeletionProtectionInstanceRequest
            {
                Zone = "",
                RequestId = "",
                DeletionProtection = false,
                Resource = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetDeletionProtectionAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetDeletionProtection</summary>
        public void SetDeletionProtection()
        {
            // Snippet: SetDeletionProtection(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            // Make the request
            Operation response = instancesClient.SetDeletionProtection(project, zone, resource);
            // End snippet
        }

        /// <summary>Snippet for SetDeletionProtectionAsync</summary>
        public async Task SetDeletionProtectionAsync()
        {
            // Snippet: SetDeletionProtectionAsync(string, string, string, CallSettings)
            // Additional: SetDeletionProtectionAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            // Make the request
            Operation response = await instancesClient.SetDeletionProtectionAsync(project, zone, resource);
            // End snippet
        }

        /// <summary>Snippet for SetDiskAutoDelete</summary>
        public void SetDiskAutoDeleteRequestObject()
        {
            // Snippet: SetDiskAutoDelete(SetDiskAutoDeleteInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetDiskAutoDeleteInstanceRequest request = new SetDiskAutoDeleteInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                DeviceName = "",
                AutoDelete = false,
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetDiskAutoDelete(request);
            // End snippet
        }

        /// <summary>Snippet for SetDiskAutoDeleteAsync</summary>
        public async Task SetDiskAutoDeleteRequestObjectAsync()
        {
            // Snippet: SetDiskAutoDeleteAsync(SetDiskAutoDeleteInstanceRequest, CallSettings)
            // Additional: SetDiskAutoDeleteAsync(SetDiskAutoDeleteInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetDiskAutoDeleteInstanceRequest request = new SetDiskAutoDeleteInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                DeviceName = "",
                AutoDelete = false,
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetDiskAutoDeleteAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetDiskAutoDelete</summary>
        public void SetDiskAutoDelete()
        {
            // Snippet: SetDiskAutoDelete(string, string, string, bool, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            bool autoDelete = false;
            string deviceName = "";
            // Make the request
            Operation response = instancesClient.SetDiskAutoDelete(project, zone, instance, autoDelete, deviceName);
            // End snippet
        }

        /// <summary>Snippet for SetDiskAutoDeleteAsync</summary>
        public async Task SetDiskAutoDeleteAsync()
        {
            // Snippet: SetDiskAutoDeleteAsync(string, string, string, bool, string, CallSettings)
            // Additional: SetDiskAutoDeleteAsync(string, string, string, bool, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            bool autoDelete = false;
            string deviceName = "";
            // Make the request
            Operation response = await instancesClient.SetDiskAutoDeleteAsync(project, zone, instance, autoDelete, deviceName);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicyRequestObject()
        {
            // Snippet: SetIamPolicy(SetIamPolicyInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetIamPolicyInstanceRequest request = new SetIamPolicyInstanceRequest
            {
                Zone = "",
                ZoneSetPolicyRequestResource = new ZoneSetPolicyRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = instancesClient.SetIamPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyRequestObjectAsync()
        {
            // Snippet: SetIamPolicyAsync(SetIamPolicyInstanceRequest, CallSettings)
            // Additional: SetIamPolicyAsync(SetIamPolicyInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetIamPolicyInstanceRequest request = new SetIamPolicyInstanceRequest
            {
                Zone = "",
                ZoneSetPolicyRequestResource = new ZoneSetPolicyRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            Policy response = await instancesClient.SetIamPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicy</summary>
        public void SetIamPolicy()
        {
            // Snippet: SetIamPolicy(string, string, string, ZoneSetPolicyRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            ZoneSetPolicyRequest zoneSetPolicyRequestResource = new ZoneSetPolicyRequest();
            // Make the request
            Policy response = instancesClient.SetIamPolicy(project, zone, resource, zoneSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetIamPolicyAsync</summary>
        public async Task SetIamPolicyAsync()
        {
            // Snippet: SetIamPolicyAsync(string, string, string, ZoneSetPolicyRequest, CallSettings)
            // Additional: SetIamPolicyAsync(string, string, string, ZoneSetPolicyRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            ZoneSetPolicyRequest zoneSetPolicyRequestResource = new ZoneSetPolicyRequest();
            // Make the request
            Policy response = await instancesClient.SetIamPolicyAsync(project, zone, resource, zoneSetPolicyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetLabels</summary>
        public void SetLabelsRequestObject()
        {
            // Snippet: SetLabels(SetLabelsInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetLabelsInstanceRequest request = new SetLabelsInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesSetLabelsRequestResource = new InstancesSetLabelsRequest(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetLabels(request);
            // End snippet
        }

        /// <summary>Snippet for SetLabelsAsync</summary>
        public async Task SetLabelsRequestObjectAsync()
        {
            // Snippet: SetLabelsAsync(SetLabelsInstanceRequest, CallSettings)
            // Additional: SetLabelsAsync(SetLabelsInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetLabelsInstanceRequest request = new SetLabelsInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesSetLabelsRequestResource = new InstancesSetLabelsRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetLabelsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetLabels</summary>
        public void SetLabels()
        {
            // Snippet: SetLabels(string, string, string, InstancesSetLabelsRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetLabelsRequest instancesSetLabelsRequestResource = new InstancesSetLabelsRequest();
            // Make the request
            Operation response = instancesClient.SetLabels(project, zone, instance, instancesSetLabelsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetLabelsAsync</summary>
        public async Task SetLabelsAsync()
        {
            // Snippet: SetLabelsAsync(string, string, string, InstancesSetLabelsRequest, CallSettings)
            // Additional: SetLabelsAsync(string, string, string, InstancesSetLabelsRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetLabelsRequest instancesSetLabelsRequestResource = new InstancesSetLabelsRequest();
            // Make the request
            Operation response = await instancesClient.SetLabelsAsync(project, zone, instance, instancesSetLabelsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetMachineResources</summary>
        public void SetMachineResourcesRequestObject()
        {
            // Snippet: SetMachineResources(SetMachineResourcesInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetMachineResourcesInstanceRequest request = new SetMachineResourcesInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesSetMachineResourcesRequestResource = new InstancesSetMachineResourcesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetMachineResources(request);
            // End snippet
        }

        /// <summary>Snippet for SetMachineResourcesAsync</summary>
        public async Task SetMachineResourcesRequestObjectAsync()
        {
            // Snippet: SetMachineResourcesAsync(SetMachineResourcesInstanceRequest, CallSettings)
            // Additional: SetMachineResourcesAsync(SetMachineResourcesInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetMachineResourcesInstanceRequest request = new SetMachineResourcesInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesSetMachineResourcesRequestResource = new InstancesSetMachineResourcesRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetMachineResourcesAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetMachineResources</summary>
        public void SetMachineResources()
        {
            // Snippet: SetMachineResources(string, string, string, InstancesSetMachineResourcesRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetMachineResourcesRequest instancesSetMachineResourcesRequestResource = new InstancesSetMachineResourcesRequest();
            // Make the request
            Operation response = instancesClient.SetMachineResources(project, zone, instance, instancesSetMachineResourcesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetMachineResourcesAsync</summary>
        public async Task SetMachineResourcesAsync()
        {
            // Snippet: SetMachineResourcesAsync(string, string, string, InstancesSetMachineResourcesRequest, CallSettings)
            // Additional: SetMachineResourcesAsync(string, string, string, InstancesSetMachineResourcesRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetMachineResourcesRequest instancesSetMachineResourcesRequestResource = new InstancesSetMachineResourcesRequest();
            // Make the request
            Operation response = await instancesClient.SetMachineResourcesAsync(project, zone, instance, instancesSetMachineResourcesRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetMachineType</summary>
        public void SetMachineTypeRequestObject()
        {
            // Snippet: SetMachineType(SetMachineTypeInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetMachineTypeInstanceRequest request = new SetMachineTypeInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
                InstancesSetMachineTypeRequestResource = new InstancesSetMachineTypeRequest(),
            };
            // Make the request
            Operation response = instancesClient.SetMachineType(request);
            // End snippet
        }

        /// <summary>Snippet for SetMachineTypeAsync</summary>
        public async Task SetMachineTypeRequestObjectAsync()
        {
            // Snippet: SetMachineTypeAsync(SetMachineTypeInstanceRequest, CallSettings)
            // Additional: SetMachineTypeAsync(SetMachineTypeInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetMachineTypeInstanceRequest request = new SetMachineTypeInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
                InstancesSetMachineTypeRequestResource = new InstancesSetMachineTypeRequest(),
            };
            // Make the request
            Operation response = await instancesClient.SetMachineTypeAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetMachineType</summary>
        public void SetMachineType()
        {
            // Snippet: SetMachineType(string, string, string, InstancesSetMachineTypeRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetMachineTypeRequest instancesSetMachineTypeRequestResource = new InstancesSetMachineTypeRequest();
            // Make the request
            Operation response = instancesClient.SetMachineType(project, zone, instance, instancesSetMachineTypeRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetMachineTypeAsync</summary>
        public async Task SetMachineTypeAsync()
        {
            // Snippet: SetMachineTypeAsync(string, string, string, InstancesSetMachineTypeRequest, CallSettings)
            // Additional: SetMachineTypeAsync(string, string, string, InstancesSetMachineTypeRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetMachineTypeRequest instancesSetMachineTypeRequestResource = new InstancesSetMachineTypeRequest();
            // Make the request
            Operation response = await instancesClient.SetMachineTypeAsync(project, zone, instance, instancesSetMachineTypeRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetMetadata</summary>
        public void SetMetadataRequestObject()
        {
            // Snippet: SetMetadata(SetMetadataInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetMetadataInstanceRequest request = new SetMetadataInstanceRequest
            {
                Zone = "",
                Instance = "",
                MetadataResource = new Metadata(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetMetadata(request);
            // End snippet
        }

        /// <summary>Snippet for SetMetadataAsync</summary>
        public async Task SetMetadataRequestObjectAsync()
        {
            // Snippet: SetMetadataAsync(SetMetadataInstanceRequest, CallSettings)
            // Additional: SetMetadataAsync(SetMetadataInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetMetadataInstanceRequest request = new SetMetadataInstanceRequest
            {
                Zone = "",
                Instance = "",
                MetadataResource = new Metadata(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetMetadataAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetMetadata</summary>
        public void SetMetadata()
        {
            // Snippet: SetMetadata(string, string, string, Metadata, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Metadata metadataResource = new Metadata();
            // Make the request
            Operation response = instancesClient.SetMetadata(project, zone, instance, metadataResource);
            // End snippet
        }

        /// <summary>Snippet for SetMetadataAsync</summary>
        public async Task SetMetadataAsync()
        {
            // Snippet: SetMetadataAsync(string, string, string, Metadata, CallSettings)
            // Additional: SetMetadataAsync(string, string, string, Metadata, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Metadata metadataResource = new Metadata();
            // Make the request
            Operation response = await instancesClient.SetMetadataAsync(project, zone, instance, metadataResource);
            // End snippet
        }

        /// <summary>Snippet for SetMinCpuPlatform</summary>
        public void SetMinCpuPlatformRequestObject()
        {
            // Snippet: SetMinCpuPlatform(SetMinCpuPlatformInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetMinCpuPlatformInstanceRequest request = new SetMinCpuPlatformInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesSetMinCpuPlatformRequestResource = new InstancesSetMinCpuPlatformRequest(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetMinCpuPlatform(request);
            // End snippet
        }

        /// <summary>Snippet for SetMinCpuPlatformAsync</summary>
        public async Task SetMinCpuPlatformRequestObjectAsync()
        {
            // Snippet: SetMinCpuPlatformAsync(SetMinCpuPlatformInstanceRequest, CallSettings)
            // Additional: SetMinCpuPlatformAsync(SetMinCpuPlatformInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetMinCpuPlatformInstanceRequest request = new SetMinCpuPlatformInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesSetMinCpuPlatformRequestResource = new InstancesSetMinCpuPlatformRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetMinCpuPlatformAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetMinCpuPlatform</summary>
        public void SetMinCpuPlatform()
        {
            // Snippet: SetMinCpuPlatform(string, string, string, InstancesSetMinCpuPlatformRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetMinCpuPlatformRequest instancesSetMinCpuPlatformRequestResource = new InstancesSetMinCpuPlatformRequest();
            // Make the request
            Operation response = instancesClient.SetMinCpuPlatform(project, zone, instance, instancesSetMinCpuPlatformRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetMinCpuPlatformAsync</summary>
        public async Task SetMinCpuPlatformAsync()
        {
            // Snippet: SetMinCpuPlatformAsync(string, string, string, InstancesSetMinCpuPlatformRequest, CallSettings)
            // Additional: SetMinCpuPlatformAsync(string, string, string, InstancesSetMinCpuPlatformRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetMinCpuPlatformRequest instancesSetMinCpuPlatformRequestResource = new InstancesSetMinCpuPlatformRequest();
            // Make the request
            Operation response = await instancesClient.SetMinCpuPlatformAsync(project, zone, instance, instancesSetMinCpuPlatformRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetScheduling</summary>
        public void SetSchedulingRequestObject()
        {
            // Snippet: SetScheduling(SetSchedulingInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetSchedulingInstanceRequest request = new SetSchedulingInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                SchedulingResource = new Scheduling(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetScheduling(request);
            // End snippet
        }

        /// <summary>Snippet for SetSchedulingAsync</summary>
        public async Task SetSchedulingRequestObjectAsync()
        {
            // Snippet: SetSchedulingAsync(SetSchedulingInstanceRequest, CallSettings)
            // Additional: SetSchedulingAsync(SetSchedulingInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetSchedulingInstanceRequest request = new SetSchedulingInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                SchedulingResource = new Scheduling(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetSchedulingAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetScheduling</summary>
        public void SetScheduling()
        {
            // Snippet: SetScheduling(string, string, string, Scheduling, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Scheduling schedulingResource = new Scheduling();
            // Make the request
            Operation response = instancesClient.SetScheduling(project, zone, instance, schedulingResource);
            // End snippet
        }

        /// <summary>Snippet for SetSchedulingAsync</summary>
        public async Task SetSchedulingAsync()
        {
            // Snippet: SetSchedulingAsync(string, string, string, Scheduling, CallSettings)
            // Additional: SetSchedulingAsync(string, string, string, Scheduling, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Scheduling schedulingResource = new Scheduling();
            // Make the request
            Operation response = await instancesClient.SetSchedulingAsync(project, zone, instance, schedulingResource);
            // End snippet
        }

        /// <summary>Snippet for SetServiceAccount</summary>
        public void SetServiceAccountRequestObject()
        {
            // Snippet: SetServiceAccount(SetServiceAccountInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetServiceAccountInstanceRequest request = new SetServiceAccountInstanceRequest
            {
                Zone = "",
                InstancesSetServiceAccountRequestResource = new InstancesSetServiceAccountRequest(),
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetServiceAccount(request);
            // End snippet
        }

        /// <summary>Snippet for SetServiceAccountAsync</summary>
        public async Task SetServiceAccountRequestObjectAsync()
        {
            // Snippet: SetServiceAccountAsync(SetServiceAccountInstanceRequest, CallSettings)
            // Additional: SetServiceAccountAsync(SetServiceAccountInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetServiceAccountInstanceRequest request = new SetServiceAccountInstanceRequest
            {
                Zone = "",
                InstancesSetServiceAccountRequestResource = new InstancesSetServiceAccountRequest(),
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetServiceAccountAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetServiceAccount</summary>
        public void SetServiceAccount()
        {
            // Snippet: SetServiceAccount(string, string, string, InstancesSetServiceAccountRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetServiceAccountRequest instancesSetServiceAccountRequestResource = new InstancesSetServiceAccountRequest();
            // Make the request
            Operation response = instancesClient.SetServiceAccount(project, zone, instance, instancesSetServiceAccountRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetServiceAccountAsync</summary>
        public async Task SetServiceAccountAsync()
        {
            // Snippet: SetServiceAccountAsync(string, string, string, InstancesSetServiceAccountRequest, CallSettings)
            // Additional: SetServiceAccountAsync(string, string, string, InstancesSetServiceAccountRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesSetServiceAccountRequest instancesSetServiceAccountRequestResource = new InstancesSetServiceAccountRequest();
            // Make the request
            Operation response = await instancesClient.SetServiceAccountAsync(project, zone, instance, instancesSetServiceAccountRequestResource);
            // End snippet
        }

        /// <summary>Snippet for SetShieldedInstanceIntegrityPolicy</summary>
        public void SetShieldedInstanceIntegrityPolicyRequestObject()
        {
            // Snippet: SetShieldedInstanceIntegrityPolicy(SetShieldedInstanceIntegrityPolicyInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetShieldedInstanceIntegrityPolicyInstanceRequest request = new SetShieldedInstanceIntegrityPolicyInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                ShieldedInstanceIntegrityPolicyResource = new ShieldedInstanceIntegrityPolicy(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetShieldedInstanceIntegrityPolicy(request);
            // End snippet
        }

        /// <summary>Snippet for SetShieldedInstanceIntegrityPolicyAsync</summary>
        public async Task SetShieldedInstanceIntegrityPolicyRequestObjectAsync()
        {
            // Snippet: SetShieldedInstanceIntegrityPolicyAsync(SetShieldedInstanceIntegrityPolicyInstanceRequest, CallSettings)
            // Additional: SetShieldedInstanceIntegrityPolicyAsync(SetShieldedInstanceIntegrityPolicyInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetShieldedInstanceIntegrityPolicyInstanceRequest request = new SetShieldedInstanceIntegrityPolicyInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                ShieldedInstanceIntegrityPolicyResource = new ShieldedInstanceIntegrityPolicy(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetShieldedInstanceIntegrityPolicyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetShieldedInstanceIntegrityPolicy</summary>
        public void SetShieldedInstanceIntegrityPolicy()
        {
            // Snippet: SetShieldedInstanceIntegrityPolicy(string, string, string, ShieldedInstanceIntegrityPolicy, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            ShieldedInstanceIntegrityPolicy shieldedInstanceIntegrityPolicyResource = new ShieldedInstanceIntegrityPolicy();
            // Make the request
            Operation response = instancesClient.SetShieldedInstanceIntegrityPolicy(project, zone, instance, shieldedInstanceIntegrityPolicyResource);
            // End snippet
        }

        /// <summary>Snippet for SetShieldedInstanceIntegrityPolicyAsync</summary>
        public async Task SetShieldedInstanceIntegrityPolicyAsync()
        {
            // Snippet: SetShieldedInstanceIntegrityPolicyAsync(string, string, string, ShieldedInstanceIntegrityPolicy, CallSettings)
            // Additional: SetShieldedInstanceIntegrityPolicyAsync(string, string, string, ShieldedInstanceIntegrityPolicy, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            ShieldedInstanceIntegrityPolicy shieldedInstanceIntegrityPolicyResource = new ShieldedInstanceIntegrityPolicy();
            // Make the request
            Operation response = await instancesClient.SetShieldedInstanceIntegrityPolicyAsync(project, zone, instance, shieldedInstanceIntegrityPolicyResource);
            // End snippet
        }

        /// <summary>Snippet for SetTags</summary>
        public void SetTagsRequestObject()
        {
            // Snippet: SetTags(SetTagsInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SetTagsInstanceRequest request = new SetTagsInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                TagsResource = new Tags(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SetTags(request);
            // End snippet
        }

        /// <summary>Snippet for SetTagsAsync</summary>
        public async Task SetTagsRequestObjectAsync()
        {
            // Snippet: SetTagsAsync(SetTagsInstanceRequest, CallSettings)
            // Additional: SetTagsAsync(SetTagsInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SetTagsInstanceRequest request = new SetTagsInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                TagsResource = new Tags(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SetTagsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SetTags</summary>
        public void SetTags()
        {
            // Snippet: SetTags(string, string, string, Tags, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Tags tagsResource = new Tags();
            // Make the request
            Operation response = instancesClient.SetTags(project, zone, instance, tagsResource);
            // End snippet
        }

        /// <summary>Snippet for SetTagsAsync</summary>
        public async Task SetTagsAsync()
        {
            // Snippet: SetTagsAsync(string, string, string, Tags, CallSettings)
            // Additional: SetTagsAsync(string, string, string, Tags, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Tags tagsResource = new Tags();
            // Make the request
            Operation response = await instancesClient.SetTagsAsync(project, zone, instance, tagsResource);
            // End snippet
        }

        /// <summary>Snippet for SimulateMaintenanceEvent</summary>
        public void SimulateMaintenanceEventRequestObject()
        {
            // Snippet: SimulateMaintenanceEvent(SimulateMaintenanceEventInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            SimulateMaintenanceEventInstanceRequest request = new SimulateMaintenanceEventInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.SimulateMaintenanceEvent(request);
            // End snippet
        }

        /// <summary>Snippet for SimulateMaintenanceEventAsync</summary>
        public async Task SimulateMaintenanceEventRequestObjectAsync()
        {
            // Snippet: SimulateMaintenanceEventAsync(SimulateMaintenanceEventInstanceRequest, CallSettings)
            // Additional: SimulateMaintenanceEventAsync(SimulateMaintenanceEventInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            SimulateMaintenanceEventInstanceRequest request = new SimulateMaintenanceEventInstanceRequest
            {
                Zone = "",
                Instance = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.SimulateMaintenanceEventAsync(request);
            // End snippet
        }

        /// <summary>Snippet for SimulateMaintenanceEvent</summary>
        public void SimulateMaintenanceEvent()
        {
            // Snippet: SimulateMaintenanceEvent(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = instancesClient.SimulateMaintenanceEvent(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for SimulateMaintenanceEventAsync</summary>
        public async Task SimulateMaintenanceEventAsync()
        {
            // Snippet: SimulateMaintenanceEventAsync(string, string, string, CallSettings)
            // Additional: SimulateMaintenanceEventAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = await instancesClient.SimulateMaintenanceEventAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for Start</summary>
        public void StartRequestObject()
        {
            // Snippet: Start(StartInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            StartInstanceRequest request = new StartInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.Start(request);
            // End snippet
        }

        /// <summary>Snippet for StartAsync</summary>
        public async Task StartRequestObjectAsync()
        {
            // Snippet: StartAsync(StartInstanceRequest, CallSettings)
            // Additional: StartAsync(StartInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            StartInstanceRequest request = new StartInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.StartAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Start</summary>
        public void Start()
        {
            // Snippet: Start(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = instancesClient.Start(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for StartAsync</summary>
        public async Task StartAsync()
        {
            // Snippet: StartAsync(string, string, string, CallSettings)
            // Additional: StartAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = await instancesClient.StartAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for StartWithEncryptionKey</summary>
        public void StartWithEncryptionKeyRequestObject()
        {
            // Snippet: StartWithEncryptionKey(StartWithEncryptionKeyInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            StartWithEncryptionKeyInstanceRequest request = new StartWithEncryptionKeyInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesStartWithEncryptionKeyRequestResource = new InstancesStartWithEncryptionKeyRequest(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.StartWithEncryptionKey(request);
            // End snippet
        }

        /// <summary>Snippet for StartWithEncryptionKeyAsync</summary>
        public async Task StartWithEncryptionKeyRequestObjectAsync()
        {
            // Snippet: StartWithEncryptionKeyAsync(StartWithEncryptionKeyInstanceRequest, CallSettings)
            // Additional: StartWithEncryptionKeyAsync(StartWithEncryptionKeyInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            StartWithEncryptionKeyInstanceRequest request = new StartWithEncryptionKeyInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                InstancesStartWithEncryptionKeyRequestResource = new InstancesStartWithEncryptionKeyRequest(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.StartWithEncryptionKeyAsync(request);
            // End snippet
        }

        /// <summary>Snippet for StartWithEncryptionKey</summary>
        public void StartWithEncryptionKey()
        {
            // Snippet: StartWithEncryptionKey(string, string, string, InstancesStartWithEncryptionKeyRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesStartWithEncryptionKeyRequest instancesStartWithEncryptionKeyRequestResource = new InstancesStartWithEncryptionKeyRequest();
            // Make the request
            Operation response = instancesClient.StartWithEncryptionKey(project, zone, instance, instancesStartWithEncryptionKeyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for StartWithEncryptionKeyAsync</summary>
        public async Task StartWithEncryptionKeyAsync()
        {
            // Snippet: StartWithEncryptionKeyAsync(string, string, string, InstancesStartWithEncryptionKeyRequest, CallSettings)
            // Additional: StartWithEncryptionKeyAsync(string, string, string, InstancesStartWithEncryptionKeyRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            InstancesStartWithEncryptionKeyRequest instancesStartWithEncryptionKeyRequestResource = new InstancesStartWithEncryptionKeyRequest();
            // Make the request
            Operation response = await instancesClient.StartWithEncryptionKeyAsync(project, zone, instance, instancesStartWithEncryptionKeyRequestResource);
            // End snippet
        }

        /// <summary>Snippet for Stop</summary>
        public void StopRequestObject()
        {
            // Snippet: Stop(StopInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            StopInstanceRequest request = new StopInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.Stop(request);
            // End snippet
        }

        /// <summary>Snippet for StopAsync</summary>
        public async Task StopRequestObjectAsync()
        {
            // Snippet: StopAsync(StopInstanceRequest, CallSettings)
            // Additional: StopAsync(StopInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            StopInstanceRequest request = new StopInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.StopAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Stop</summary>
        public void Stop()
        {
            // Snippet: Stop(string, string, string, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = instancesClient.Stop(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for StopAsync</summary>
        public async Task StopAsync()
        {
            // Snippet: StopAsync(string, string, string, CallSettings)
            // Additional: StopAsync(string, string, string, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            // Make the request
            Operation response = await instancesClient.StopAsync(project, zone, instance);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissionsRequestObject()
        {
            // Snippet: TestIamPermissions(TestIamPermissionsInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            TestIamPermissionsInstanceRequest request = new TestIamPermissionsInstanceRequest
            {
                Zone = "",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = instancesClient.TestIamPermissions(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsRequestObjectAsync()
        {
            // Snippet: TestIamPermissionsAsync(TestIamPermissionsInstanceRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(TestIamPermissionsInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            TestIamPermissionsInstanceRequest request = new TestIamPermissionsInstanceRequest
            {
                Zone = "",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "",
                Project = "",
            };
            // Make the request
            TestPermissionsResponse response = await instancesClient.TestIamPermissionsAsync(request);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissions</summary>
        public void TestIamPermissions()
        {
            // Snippet: TestIamPermissions(string, string, string, TestPermissionsRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = instancesClient.TestIamPermissions(project, zone, resource, testPermissionsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for TestIamPermissionsAsync</summary>
        public async Task TestIamPermissionsAsync()
        {
            // Snippet: TestIamPermissionsAsync(string, string, string, TestPermissionsRequest, CallSettings)
            // Additional: TestIamPermissionsAsync(string, string, string, TestPermissionsRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string resource = "";
            TestPermissionsRequest testPermissionsRequestResource = new TestPermissionsRequest();
            // Make the request
            TestPermissionsResponse response = await instancesClient.TestIamPermissionsAsync(project, zone, resource, testPermissionsRequestResource);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void UpdateRequestObject()
        {
            // Snippet: Update(UpdateInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            UpdateInstanceRequest request = new UpdateInstanceRequest
            {
                MinimalAction = "",
                Zone = "",
                Instance = "",
                RequestId = "",
                MostDisruptiveAllowedAction = "",
                InstanceResource = new Instance(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.Update(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateRequestObjectAsync()
        {
            // Snippet: UpdateAsync(UpdateInstanceRequest, CallSettings)
            // Additional: UpdateAsync(UpdateInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            UpdateInstanceRequest request = new UpdateInstanceRequest
            {
                MinimalAction = "",
                Zone = "",
                Instance = "",
                RequestId = "",
                MostDisruptiveAllowedAction = "",
                InstanceResource = new Instance(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.UpdateAsync(request);
            // End snippet
        }

        /// <summary>Snippet for Update</summary>
        public void Update()
        {
            // Snippet: Update(string, string, string, Instance, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Instance instanceResource = new Instance();
            // Make the request
            Operation response = instancesClient.Update(project, zone, instance, instanceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAsync</summary>
        public async Task UpdateAsync()
        {
            // Snippet: UpdateAsync(string, string, string, Instance, CallSettings)
            // Additional: UpdateAsync(string, string, string, Instance, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            Instance instanceResource = new Instance();
            // Make the request
            Operation response = await instancesClient.UpdateAsync(project, zone, instance, instanceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAccessConfig</summary>
        public void UpdateAccessConfigRequestObject()
        {
            // Snippet: UpdateAccessConfig(UpdateAccessConfigInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            UpdateAccessConfigInstanceRequest request = new UpdateAccessConfigInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                NetworkInterface = "",
                AccessConfigResource = new AccessConfig(),
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.UpdateAccessConfig(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAccessConfigAsync</summary>
        public async Task UpdateAccessConfigRequestObjectAsync()
        {
            // Snippet: UpdateAccessConfigAsync(UpdateAccessConfigInstanceRequest, CallSettings)
            // Additional: UpdateAccessConfigAsync(UpdateAccessConfigInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            UpdateAccessConfigInstanceRequest request = new UpdateAccessConfigInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                NetworkInterface = "",
                AccessConfigResource = new AccessConfig(),
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.UpdateAccessConfigAsync(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateAccessConfig</summary>
        public void UpdateAccessConfig()
        {
            // Snippet: UpdateAccessConfig(string, string, string, string, AccessConfig, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string networkInterface = "";
            AccessConfig accessConfigResource = new AccessConfig();
            // Make the request
            Operation response = instancesClient.UpdateAccessConfig(project, zone, instance, networkInterface, accessConfigResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateAccessConfigAsync</summary>
        public async Task UpdateAccessConfigAsync()
        {
            // Snippet: UpdateAccessConfigAsync(string, string, string, string, AccessConfig, CallSettings)
            // Additional: UpdateAccessConfigAsync(string, string, string, string, AccessConfig, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string networkInterface = "";
            AccessConfig accessConfigResource = new AccessConfig();
            // Make the request
            Operation response = await instancesClient.UpdateAccessConfigAsync(project, zone, instance, networkInterface, accessConfigResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateDisplayDevice</summary>
        public void UpdateDisplayDeviceRequestObject()
        {
            // Snippet: UpdateDisplayDevice(UpdateDisplayDeviceInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            UpdateDisplayDeviceInstanceRequest request = new UpdateDisplayDeviceInstanceRequest
            {
                Zone = "",
                Instance = "",
                DisplayDeviceResource = new DisplayDevice(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.UpdateDisplayDevice(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateDisplayDeviceAsync</summary>
        public async Task UpdateDisplayDeviceRequestObjectAsync()
        {
            // Snippet: UpdateDisplayDeviceAsync(UpdateDisplayDeviceInstanceRequest, CallSettings)
            // Additional: UpdateDisplayDeviceAsync(UpdateDisplayDeviceInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            UpdateDisplayDeviceInstanceRequest request = new UpdateDisplayDeviceInstanceRequest
            {
                Zone = "",
                Instance = "",
                DisplayDeviceResource = new DisplayDevice(),
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.UpdateDisplayDeviceAsync(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateDisplayDevice</summary>
        public void UpdateDisplayDevice()
        {
            // Snippet: UpdateDisplayDevice(string, string, string, DisplayDevice, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            DisplayDevice displayDeviceResource = new DisplayDevice();
            // Make the request
            Operation response = instancesClient.UpdateDisplayDevice(project, zone, instance, displayDeviceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateDisplayDeviceAsync</summary>
        public async Task UpdateDisplayDeviceAsync()
        {
            // Snippet: UpdateDisplayDeviceAsync(string, string, string, DisplayDevice, CallSettings)
            // Additional: UpdateDisplayDeviceAsync(string, string, string, DisplayDevice, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            DisplayDevice displayDeviceResource = new DisplayDevice();
            // Make the request
            Operation response = await instancesClient.UpdateDisplayDeviceAsync(project, zone, instance, displayDeviceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateNetworkInterface</summary>
        public void UpdateNetworkInterfaceRequestObject()
        {
            // Snippet: UpdateNetworkInterface(UpdateNetworkInterfaceInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            UpdateNetworkInterfaceInstanceRequest request = new UpdateNetworkInterfaceInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                NetworkInterfaceResource = new NetworkInterface(),
                NetworkInterface = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.UpdateNetworkInterface(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateNetworkInterfaceAsync</summary>
        public async Task UpdateNetworkInterfaceRequestObjectAsync()
        {
            // Snippet: UpdateNetworkInterfaceAsync(UpdateNetworkInterfaceInstanceRequest, CallSettings)
            // Additional: UpdateNetworkInterfaceAsync(UpdateNetworkInterfaceInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            UpdateNetworkInterfaceInstanceRequest request = new UpdateNetworkInterfaceInstanceRequest
            {
                Zone = "",
                Instance = "",
                RequestId = "",
                NetworkInterfaceResource = new NetworkInterface(),
                NetworkInterface = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.UpdateNetworkInterfaceAsync(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateNetworkInterface</summary>
        public void UpdateNetworkInterface()
        {
            // Snippet: UpdateNetworkInterface(string, string, string, string, NetworkInterface, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string networkInterface = "";
            NetworkInterface networkInterfaceResource = new NetworkInterface();
            // Make the request
            Operation response = instancesClient.UpdateNetworkInterface(project, zone, instance, networkInterface, networkInterfaceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateNetworkInterfaceAsync</summary>
        public async Task UpdateNetworkInterfaceAsync()
        {
            // Snippet: UpdateNetworkInterfaceAsync(string, string, string, string, NetworkInterface, CallSettings)
            // Additional: UpdateNetworkInterfaceAsync(string, string, string, string, NetworkInterface, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            string networkInterface = "";
            NetworkInterface networkInterfaceResource = new NetworkInterface();
            // Make the request
            Operation response = await instancesClient.UpdateNetworkInterfaceAsync(project, zone, instance, networkInterface, networkInterfaceResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateShieldedInstanceConfig</summary>
        public void UpdateShieldedInstanceConfigRequestObject()
        {
            // Snippet: UpdateShieldedInstanceConfig(UpdateShieldedInstanceConfigInstanceRequest, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            UpdateShieldedInstanceConfigInstanceRequest request = new UpdateShieldedInstanceConfigInstanceRequest
            {
                ShieldedInstanceConfigResource = new ShieldedInstanceConfig(),
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = instancesClient.UpdateShieldedInstanceConfig(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateShieldedInstanceConfigAsync</summary>
        public async Task UpdateShieldedInstanceConfigRequestObjectAsync()
        {
            // Snippet: UpdateShieldedInstanceConfigAsync(UpdateShieldedInstanceConfigInstanceRequest, CallSettings)
            // Additional: UpdateShieldedInstanceConfigAsync(UpdateShieldedInstanceConfigInstanceRequest, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            UpdateShieldedInstanceConfigInstanceRequest request = new UpdateShieldedInstanceConfigInstanceRequest
            {
                ShieldedInstanceConfigResource = new ShieldedInstanceConfig(),
                Zone = "",
                Instance = "",
                RequestId = "",
                Project = "",
            };
            // Make the request
            Operation response = await instancesClient.UpdateShieldedInstanceConfigAsync(request);
            // End snippet
        }

        /// <summary>Snippet for UpdateShieldedInstanceConfig</summary>
        public void UpdateShieldedInstanceConfig()
        {
            // Snippet: UpdateShieldedInstanceConfig(string, string, string, ShieldedInstanceConfig, CallSettings)
            // Create client
            InstancesClient instancesClient = InstancesClient.Create();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            ShieldedInstanceConfig shieldedInstanceConfigResource = new ShieldedInstanceConfig();
            // Make the request
            Operation response = instancesClient.UpdateShieldedInstanceConfig(project, zone, instance, shieldedInstanceConfigResource);
            // End snippet
        }

        /// <summary>Snippet for UpdateShieldedInstanceConfigAsync</summary>
        public async Task UpdateShieldedInstanceConfigAsync()
        {
            // Snippet: UpdateShieldedInstanceConfigAsync(string, string, string, ShieldedInstanceConfig, CallSettings)
            // Additional: UpdateShieldedInstanceConfigAsync(string, string, string, ShieldedInstanceConfig, CancellationToken)
            // Create client
            InstancesClient instancesClient = await InstancesClient.CreateAsync();
            // Initialize request argument(s)
            string project = "";
            string zone = "";
            string instance = "";
            ShieldedInstanceConfig shieldedInstanceConfigResource = new ShieldedInstanceConfig();
            // Make the request
            Operation response = await instancesClient.UpdateShieldedInstanceConfigAsync(project, zone, instance, shieldedInstanceConfigResource);
            // End snippet
        }
    }
}
