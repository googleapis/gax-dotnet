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

using gaxgrpc = Google.Api.Gax.Grpc;
using grpccore = Grpc.Core;
using moq = Moq;
using st = System.Threading;
using stt = System.Threading.Tasks;
using xunit = Xunit;

namespace Google.Cloud.Compute.V1.Tests
{
    /// <summary>Generated unit tests.</summary>
    public sealed class GeneratedRegionInstanceGroupsClientTest
    {
        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            GetRegionInstanceGroupRequest request = new GetRegionInstanceGroupRequest
            {
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InstanceGroup expectedResponse = new InstanceGroup
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Size = -1218396681,
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                NamedPorts = { new NamedPort(), },
                SelfLink = "self_link7e87f12d",
                Network = "networkd22ce091",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            InstanceGroup response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            GetRegionInstanceGroupRequest request = new GetRegionInstanceGroupRequest
            {
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InstanceGroup expectedResponse = new InstanceGroup
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Size = -1218396681,
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                NamedPorts = { new NamedPort(), },
                SelfLink = "self_link7e87f12d",
                Network = "networkd22ce091",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InstanceGroup>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            InstanceGroup responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InstanceGroup responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            GetRegionInstanceGroupRequest request = new GetRegionInstanceGroupRequest
            {
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InstanceGroup expectedResponse = new InstanceGroup
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Size = -1218396681,
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                NamedPorts = { new NamedPort(), },
                SelfLink = "self_link7e87f12d",
                Network = "networkd22ce091",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            InstanceGroup response = client.Get(request.Project, request.Region, request.InstanceGroup);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            GetRegionInstanceGroupRequest request = new GetRegionInstanceGroupRequest
            {
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InstanceGroup expectedResponse = new InstanceGroup
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Size = -1218396681,
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                NamedPorts = { new NamedPort(), },
                SelfLink = "self_link7e87f12d",
                Network = "networkd22ce091",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InstanceGroup>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            InstanceGroup responseCallSettings = await client.GetAsync(request.Project, request.Region, request.InstanceGroup, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InstanceGroup responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.InstanceGroup, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListRegionInstanceGroupsRequest request = new ListRegionInstanceGroupsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            RegionInstanceGroupList expectedResponse = new RegionInstanceGroupList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceGroup(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListRegionInstanceGroupsRequest request = new ListRegionInstanceGroupsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            RegionInstanceGroupList expectedResponse = new RegionInstanceGroupList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceGroup(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<RegionInstanceGroupList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            RegionInstanceGroupList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListRegionInstanceGroupsRequest request = new ListRegionInstanceGroupsRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            RegionInstanceGroupList expectedResponse = new RegionInstanceGroupList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceGroup(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListRegionInstanceGroupsRequest request = new ListRegionInstanceGroupsRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            RegionInstanceGroupList expectedResponse = new RegionInstanceGroupList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceGroup(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<RegionInstanceGroupList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            RegionInstanceGroupList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListInstancesRequestObject()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListInstancesRegionInstanceGroupsRequest request = new ListInstancesRegionInstanceGroupsRequest
            {
                PageToken = "page_tokenf09e5538",
                RegionInstanceGroupsListInstancesRequestResource = new RegionInstanceGroupsListInstancesRequest(),
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            RegionInstanceGroupsListInstances expectedResponse = new RegionInstanceGroupsListInstances
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceWithNamedPorts(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListInstances(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupsListInstances response = client.ListInstances(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListInstancesRequestObjectAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListInstancesRegionInstanceGroupsRequest request = new ListInstancesRegionInstanceGroupsRequest
            {
                PageToken = "page_tokenf09e5538",
                RegionInstanceGroupsListInstancesRequestResource = new RegionInstanceGroupsListInstancesRequest(),
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            RegionInstanceGroupsListInstances expectedResponse = new RegionInstanceGroupsListInstances
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceWithNamedPorts(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListInstancesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<RegionInstanceGroupsListInstances>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupsListInstances responseCallSettings = await client.ListInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            RegionInstanceGroupsListInstances responseCancellationToken = await client.ListInstancesAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListInstances()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListInstancesRegionInstanceGroupsRequest request = new ListInstancesRegionInstanceGroupsRequest
            {
                RegionInstanceGroupsListInstancesRequestResource = new RegionInstanceGroupsListInstancesRequest(),
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            RegionInstanceGroupsListInstances expectedResponse = new RegionInstanceGroupsListInstances
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceWithNamedPorts(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListInstances(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupsListInstances response = client.ListInstances(request.Project, request.Region, request.InstanceGroup, request.RegionInstanceGroupsListInstancesRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListInstancesAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            ListInstancesRegionInstanceGroupsRequest request = new ListInstancesRegionInstanceGroupsRequest
            {
                RegionInstanceGroupsListInstancesRequestResource = new RegionInstanceGroupsListInstancesRequest(),
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            RegionInstanceGroupsListInstances expectedResponse = new RegionInstanceGroupsListInstances
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InstanceWithNamedPorts(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListInstancesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<RegionInstanceGroupsListInstances>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            RegionInstanceGroupsListInstances responseCallSettings = await client.ListInstancesAsync(request.Project, request.Region, request.InstanceGroup, request.RegionInstanceGroupsListInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            RegionInstanceGroupsListInstances responseCancellationToken = await client.ListInstancesAsync(request.Project, request.Region, request.InstanceGroup, request.RegionInstanceGroupsListInstancesRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetNamedPortsRequestObject()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            SetNamedPortsRegionInstanceGroupRequest request = new SetNamedPortsRegionInstanceGroupRequest
            {
                RegionInstanceGroupsSetNamedPortsRequestResource = new RegionInstanceGroupsSetNamedPortsRequest(),
                RequestId = "request_id362c8df6",
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Operation expectedResponse = new Operation
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                User = "userb1cb11ee",
                Zone = "zone255f4ea8",
                ClientOperationId = "client_operation_id4e51b631",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                StartTime = "start_timebd8dd9c4",
                HttpErrorStatusCode = 1766362655,
                TargetLink = "target_link9b435dc0",
                Progress = 278622268,
                Error = new Error(),
                EndTime = "end_time89285d30",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                InsertTime = "insert_time7467185a",
                OperationType = "operation_typeece9e153",
                Status = Operation.Types.Status.Pending,
                SelfLink = "self_link7e87f12d",
                HttpErrorMessage = "http_error_messageb5ef3c7f",
                Warnings = { new Warnings(), },
                TargetId = "target_id16dfe255",
            };
            mockGrpcClient.Setup(x => x.SetNamedPorts(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetNamedPorts(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetNamedPortsRequestObjectAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            SetNamedPortsRegionInstanceGroupRequest request = new SetNamedPortsRegionInstanceGroupRequest
            {
                RegionInstanceGroupsSetNamedPortsRequestResource = new RegionInstanceGroupsSetNamedPortsRequest(),
                RequestId = "request_id362c8df6",
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Operation expectedResponse = new Operation
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                User = "userb1cb11ee",
                Zone = "zone255f4ea8",
                ClientOperationId = "client_operation_id4e51b631",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                StartTime = "start_timebd8dd9c4",
                HttpErrorStatusCode = 1766362655,
                TargetLink = "target_link9b435dc0",
                Progress = 278622268,
                Error = new Error(),
                EndTime = "end_time89285d30",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                InsertTime = "insert_time7467185a",
                OperationType = "operation_typeece9e153",
                Status = Operation.Types.Status.Pending,
                SelfLink = "self_link7e87f12d",
                HttpErrorMessage = "http_error_messageb5ef3c7f",
                Warnings = { new Warnings(), },
                TargetId = "target_id16dfe255",
            };
            mockGrpcClient.Setup(x => x.SetNamedPortsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetNamedPortsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetNamedPortsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetNamedPorts()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            SetNamedPortsRegionInstanceGroupRequest request = new SetNamedPortsRegionInstanceGroupRequest
            {
                RegionInstanceGroupsSetNamedPortsRequestResource = new RegionInstanceGroupsSetNamedPortsRequest(),
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Operation expectedResponse = new Operation
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                User = "userb1cb11ee",
                Zone = "zone255f4ea8",
                ClientOperationId = "client_operation_id4e51b631",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                StartTime = "start_timebd8dd9c4",
                HttpErrorStatusCode = 1766362655,
                TargetLink = "target_link9b435dc0",
                Progress = 278622268,
                Error = new Error(),
                EndTime = "end_time89285d30",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                InsertTime = "insert_time7467185a",
                OperationType = "operation_typeece9e153",
                Status = Operation.Types.Status.Pending,
                SelfLink = "self_link7e87f12d",
                HttpErrorMessage = "http_error_messageb5ef3c7f",
                Warnings = { new Warnings(), },
                TargetId = "target_id16dfe255",
            };
            mockGrpcClient.Setup(x => x.SetNamedPorts(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetNamedPorts(request.Project, request.Region, request.InstanceGroup, request.RegionInstanceGroupsSetNamedPortsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetNamedPortsAsync()
        {
            moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient> mockGrpcClient = new moq::Mock<RegionInstanceGroups.RegionInstanceGroupsClient>(moq::MockBehavior.Strict);
            SetNamedPortsRegionInstanceGroupRequest request = new SetNamedPortsRegionInstanceGroupRequest
            {
                RegionInstanceGroupsSetNamedPortsRequestResource = new RegionInstanceGroupsSetNamedPortsRequest(),
                InstanceGroup = "instance_group6bf5a5ef",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Operation expectedResponse = new Operation
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                User = "userb1cb11ee",
                Zone = "zone255f4ea8",
                ClientOperationId = "client_operation_id4e51b631",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                StartTime = "start_timebd8dd9c4",
                HttpErrorStatusCode = 1766362655,
                TargetLink = "target_link9b435dc0",
                Progress = 278622268,
                Error = new Error(),
                EndTime = "end_time89285d30",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                InsertTime = "insert_time7467185a",
                OperationType = "operation_typeece9e153",
                Status = Operation.Types.Status.Pending,
                SelfLink = "self_link7e87f12d",
                HttpErrorMessage = "http_error_messageb5ef3c7f",
                Warnings = { new Warnings(), },
                TargetId = "target_id16dfe255",
            };
            mockGrpcClient.Setup(x => x.SetNamedPortsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionInstanceGroupsClient client = new RegionInstanceGroupsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetNamedPortsAsync(request.Project, request.Region, request.InstanceGroup, request.RegionInstanceGroupsSetNamedPortsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetNamedPortsAsync(request.Project, request.Region, request.InstanceGroup, request.RegionInstanceGroupsSetNamedPortsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
