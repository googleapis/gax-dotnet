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
    public sealed class GeneratedRegionDisksClientTest
    {
        [xunit::FactAttribute]
        public void AddResourcePoliciesRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            AddResourcePoliciesRegionDiskRequest request = new AddResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.AddResourcePolicies(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.AddResourcePolicies(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AddResourcePoliciesRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            AddResourcePoliciesRegionDiskRequest request = new AddResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.AddResourcePoliciesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.AddResourcePoliciesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.AddResourcePoliciesAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AddResourcePolicies()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            AddResourcePoliciesRegionDiskRequest request = new AddResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest(),
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
            mockGrpcClient.Setup(x => x.AddResourcePolicies(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.AddResourcePolicies(request.Project, request.Region, request.Disk, request.RegionDisksAddResourcePoliciesRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AddResourcePoliciesAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            AddResourcePoliciesRegionDiskRequest request = new AddResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksAddResourcePoliciesRequestResource = new RegionDisksAddResourcePoliciesRequest(),
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
            mockGrpcClient.Setup(x => x.AddResourcePoliciesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.AddResourcePoliciesAsync(request.Project, request.Region, request.Disk, request.RegionDisksAddResourcePoliciesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.AddResourcePoliciesAsync(request.Project, request.Region, request.Disk, request.RegionDisksAddResourcePoliciesRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void CreateSnapshotRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            CreateSnapshotRegionDiskRequest request = new CreateSnapshotRegionDiskRequest
            {
                Disk = "disk028b6875",
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                SnapshotResource = new Snapshot(),
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
            mockGrpcClient.Setup(x => x.CreateSnapshot(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.CreateSnapshot(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task CreateSnapshotRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            CreateSnapshotRegionDiskRequest request = new CreateSnapshotRegionDiskRequest
            {
                Disk = "disk028b6875",
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                SnapshotResource = new Snapshot(),
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
            mockGrpcClient.Setup(x => x.CreateSnapshotAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.CreateSnapshotAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.CreateSnapshotAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void CreateSnapshot()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            CreateSnapshotRegionDiskRequest request = new CreateSnapshotRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                SnapshotResource = new Snapshot(),
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
            mockGrpcClient.Setup(x => x.CreateSnapshot(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.CreateSnapshot(request.Project, request.Region, request.Disk, request.SnapshotResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task CreateSnapshotAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            CreateSnapshotRegionDiskRequest request = new CreateSnapshotRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                SnapshotResource = new Snapshot(),
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
            mockGrpcClient.Setup(x => x.CreateSnapshotAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.CreateSnapshotAsync(request.Project, request.Region, request.Disk, request.SnapshotResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.CreateSnapshotAsync(request.Project, request.Region, request.Disk, request.SnapshotResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            DeleteRegionDiskRequest request = new DeleteRegionDiskRequest
            {
                Disk = "disk028b6875",
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.Delete(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            DeleteRegionDiskRequest request = new DeleteRegionDiskRequest
            {
                Disk = "disk028b6875",
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.DeleteAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            DeleteRegionDiskRequest request = new DeleteRegionDiskRequest
            {
                Disk = "disk028b6875",
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
            mockGrpcClient.Setup(x => x.Delete(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Region, request.Disk);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            DeleteRegionDiskRequest request = new DeleteRegionDiskRequest
            {
                Disk = "disk028b6875",
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
            mockGrpcClient.Setup(x => x.DeleteAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Region, request.Disk, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Region, request.Disk, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetRegionDiskRequest request = new GetRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Disk expectedResponse = new Disk
            {
                Id = "id74b70bb8",
                DiskEncryptionKey = new CustomerEncryptionKey(),
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = "typee2cc9d59",
                Zone = "zone255f4ea8",
                ResourcePolicies =
                {
                    "resource_policiesdff15734",
                },
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LastAttachTimestamp = "last_attach_timestamp4fe3fe94",
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                ReplicaZones =
                {
                    "replica_zonesc1977354",
                },
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                LastDetachTimestamp = "last_detach_timestampffef196b",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                Options = "optionsa965da93",
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                Users = { "users2a5cc69b", },
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Region = "regionedb20d96",
                PhysicalBlockSizeBytes = "physical_block_size_bytes8dab69af",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Disk.Types.Status.Deleting,
                SourceDisk = "source_disk0eec086f",
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                SizeGb = "size_gb066e01fc",
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Disk response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetRegionDiskRequest request = new GetRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Disk expectedResponse = new Disk
            {
                Id = "id74b70bb8",
                DiskEncryptionKey = new CustomerEncryptionKey(),
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = "typee2cc9d59",
                Zone = "zone255f4ea8",
                ResourcePolicies =
                {
                    "resource_policiesdff15734",
                },
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LastAttachTimestamp = "last_attach_timestamp4fe3fe94",
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                ReplicaZones =
                {
                    "replica_zonesc1977354",
                },
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                LastDetachTimestamp = "last_detach_timestampffef196b",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                Options = "optionsa965da93",
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                Users = { "users2a5cc69b", },
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Region = "regionedb20d96",
                PhysicalBlockSizeBytes = "physical_block_size_bytes8dab69af",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Disk.Types.Status.Deleting,
                SourceDisk = "source_disk0eec086f",
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                SizeGb = "size_gb066e01fc",
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Disk>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Disk responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Disk responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetRegionDiskRequest request = new GetRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Disk expectedResponse = new Disk
            {
                Id = "id74b70bb8",
                DiskEncryptionKey = new CustomerEncryptionKey(),
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = "typee2cc9d59",
                Zone = "zone255f4ea8",
                ResourcePolicies =
                {
                    "resource_policiesdff15734",
                },
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LastAttachTimestamp = "last_attach_timestamp4fe3fe94",
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                ReplicaZones =
                {
                    "replica_zonesc1977354",
                },
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                LastDetachTimestamp = "last_detach_timestampffef196b",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                Options = "optionsa965da93",
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                Users = { "users2a5cc69b", },
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Region = "regionedb20d96",
                PhysicalBlockSizeBytes = "physical_block_size_bytes8dab69af",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Disk.Types.Status.Deleting,
                SourceDisk = "source_disk0eec086f",
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                SizeGb = "size_gb066e01fc",
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Disk response = client.Get(request.Project, request.Region, request.Disk);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetRegionDiskRequest request = new GetRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            Disk expectedResponse = new Disk
            {
                Id = "id74b70bb8",
                DiskEncryptionKey = new CustomerEncryptionKey(),
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = "typee2cc9d59",
                Zone = "zone255f4ea8",
                ResourcePolicies =
                {
                    "resource_policiesdff15734",
                },
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LastAttachTimestamp = "last_attach_timestamp4fe3fe94",
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                ReplicaZones =
                {
                    "replica_zonesc1977354",
                },
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                LastDetachTimestamp = "last_detach_timestampffef196b",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                Options = "optionsa965da93",
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                Users = { "users2a5cc69b", },
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Region = "regionedb20d96",
                PhysicalBlockSizeBytes = "physical_block_size_bytes8dab69af",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Disk.Types.Status.Deleting,
                SourceDisk = "source_disk0eec086f",
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                SizeGb = "size_gb066e01fc",
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Disk>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Disk responseCallSettings = await client.GetAsync(request.Project, request.Region, request.Disk, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Disk responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.Disk, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicyRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetIamPolicyRegionDiskRequest request = new GetIamPolicyRegionDiskRequest
            {
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
                OptionsRequestedPolicyVersion = -1471234741,
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.GetIamPolicy(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetIamPolicyRegionDiskRequest request = new GetIamPolicyRegionDiskRequest
            {
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
                OptionsRequestedPolicyVersion = -1471234741,
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.GetIamPolicyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Policy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicy()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetIamPolicyRegionDiskRequest request = new GetIamPolicyRegionDiskRequest
            {
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.GetIamPolicy(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request.Project, request.Region, request.Resource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            GetIamPolicyRegionDiskRequest request = new GetIamPolicyRegionDiskRequest
            {
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.GetIamPolicyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Policy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request.Project, request.Region, request.Resource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request.Project, request.Region, request.Resource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            InsertRegionDiskRequest request = new InsertRegionDiskRequest
            {
                DiskResource = new Disk(),
                RequestId = "request_id362c8df6",
                SourceImage = "source_image5e9c0c38",
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
            mockGrpcClient.Setup(x => x.Insert(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            InsertRegionDiskRequest request = new InsertRegionDiskRequest
            {
                DiskResource = new Disk(),
                RequestId = "request_id362c8df6",
                SourceImage = "source_image5e9c0c38",
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
            mockGrpcClient.Setup(x => x.InsertAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            InsertRegionDiskRequest request = new InsertRegionDiskRequest
            {
                DiskResource = new Disk(),
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
            mockGrpcClient.Setup(x => x.Insert(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.Region, request.DiskResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            InsertRegionDiskRequest request = new InsertRegionDiskRequest
            {
                DiskResource = new Disk(),
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
            mockGrpcClient.Setup(x => x.InsertAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.Region, request.DiskResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.Region, request.DiskResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ListRegionDisksRequest request = new ListRegionDisksRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            DiskList expectedResponse = new DiskList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Disk(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            DiskList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ListRegionDisksRequest request = new ListRegionDisksRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            DiskList expectedResponse = new DiskList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Disk(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            DiskList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ListRegionDisksRequest request = new ListRegionDisksRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            DiskList expectedResponse = new DiskList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Disk(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            DiskList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ListRegionDisksRequest request = new ListRegionDisksRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            DiskList expectedResponse = new DiskList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Disk(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            DiskList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void RemoveResourcePoliciesRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            RemoveResourcePoliciesRegionDiskRequest request = new RemoveResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.RemoveResourcePolicies(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.RemoveResourcePolicies(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task RemoveResourcePoliciesRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            RemoveResourcePoliciesRegionDiskRequest request = new RemoveResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.RemoveResourcePoliciesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.RemoveResourcePoliciesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.RemoveResourcePoliciesAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void RemoveResourcePolicies()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            RemoveResourcePoliciesRegionDiskRequest request = new RemoveResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest(),
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
            mockGrpcClient.Setup(x => x.RemoveResourcePolicies(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.RemoveResourcePolicies(request.Project, request.Region, request.Disk, request.RegionDisksRemoveResourcePoliciesRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task RemoveResourcePoliciesAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            RemoveResourcePoliciesRegionDiskRequest request = new RemoveResourcePoliciesRegionDiskRequest
            {
                Disk = "disk028b6875",
                RegionDisksRemoveResourcePoliciesRequestResource = new RegionDisksRemoveResourcePoliciesRequest(),
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
            mockGrpcClient.Setup(x => x.RemoveResourcePoliciesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.RemoveResourcePoliciesAsync(request.Project, request.Region, request.Disk, request.RegionDisksRemoveResourcePoliciesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.RemoveResourcePoliciesAsync(request.Project, request.Region, request.Disk, request.RegionDisksRemoveResourcePoliciesRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ResizeRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ResizeRegionDiskRequest request = new ResizeRegionDiskRequest
            {
                Disk = "disk028b6875",
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                RegionDisksResizeRequestResource = new RegionDisksResizeRequest(),
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
            mockGrpcClient.Setup(x => x.Resize(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Resize(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ResizeRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ResizeRegionDiskRequest request = new ResizeRegionDiskRequest
            {
                Disk = "disk028b6875",
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                RegionDisksResizeRequestResource = new RegionDisksResizeRequest(),
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
            mockGrpcClient.Setup(x => x.ResizeAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.ResizeAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.ResizeAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Resize()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ResizeRegionDiskRequest request = new ResizeRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                RegionDisksResizeRequestResource = new RegionDisksResizeRequest(),
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
            mockGrpcClient.Setup(x => x.Resize(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Resize(request.Project, request.Region, request.Disk, request.RegionDisksResizeRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ResizeAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            ResizeRegionDiskRequest request = new ResizeRegionDiskRequest
            {
                Disk = "disk028b6875",
                Region = "regionedb20d96",
                RegionDisksResizeRequestResource = new RegionDisksResizeRequest(),
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
            mockGrpcClient.Setup(x => x.ResizeAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.ResizeAsync(request.Project, request.Region, request.Disk, request.RegionDisksResizeRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.ResizeAsync(request.Project, request.Region, request.Disk, request.RegionDisksResizeRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicyRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetIamPolicyRegionDiskRequest request = new SetIamPolicyRegionDiskRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.SetIamPolicy(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetIamPolicyRegionDiskRequest request = new SetIamPolicyRegionDiskRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.SetIamPolicyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Policy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicy()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetIamPolicyRegionDiskRequest request = new SetIamPolicyRegionDiskRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.SetIamPolicy(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetIamPolicyRegionDiskRequest request = new SetIamPolicyRegionDiskRequest
            {
                RegionSetPolicyRequestResource = new RegionSetPolicyRequest(),
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            Policy expectedResponse = new Policy
            {
                Etag = "etage8ad7218",
                AuditConfigs = { new AuditConfig(), },
                Version = 271578922,
                Rules = { new Rule(), },
                Bindings = { new Binding(), },
                IamOwned = false,
            };
            mockGrpcClient.Setup(x => x.SetIamPolicyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Policy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetLabelsRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetLabelsRegionDiskRequest request = new SetLabelsRegionDiskRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
                RegionSetLabelsRequestResource = new RegionSetLabelsRequest(),
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
            mockGrpcClient.Setup(x => x.SetLabels(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetLabels(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetLabelsRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetLabelsRegionDiskRequest request = new SetLabelsRegionDiskRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
                RegionSetLabelsRequestResource = new RegionSetLabelsRequest(),
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
            mockGrpcClient.Setup(x => x.SetLabelsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetLabelsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetLabelsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetLabels()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetLabelsRegionDiskRequest request = new SetLabelsRegionDiskRequest
            {
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
                RegionSetLabelsRequestResource = new RegionSetLabelsRequest(),
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
            mockGrpcClient.Setup(x => x.SetLabels(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetLabels(request.Project, request.Region, request.Resource, request.RegionSetLabelsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetLabelsAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            SetLabelsRegionDiskRequest request = new SetLabelsRegionDiskRequest
            {
                Region = "regionedb20d96",
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
                RegionSetLabelsRequestResource = new RegionSetLabelsRequest(),
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
            mockGrpcClient.Setup(x => x.SetLabelsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetLabelsAsync(request.Project, request.Region, request.Resource, request.RegionSetLabelsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetLabelsAsync(request.Project, request.Region, request.Resource, request.RegionSetLabelsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissionsRequestObject()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            TestIamPermissionsRegionDiskRequest request = new TestIamPermissionsRegionDiskRequest
            {
                Region = "regionedb20d96",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            TestPermissionsResponse expectedResponse = new TestPermissionsResponse
            {
                Permissions =
                {
                    "permissions535a2741",
                },
            };
            mockGrpcClient.Setup(x => x.TestIamPermissions(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsRequestObjectAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            TestIamPermissionsRegionDiskRequest request = new TestIamPermissionsRegionDiskRequest
            {
                Region = "regionedb20d96",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            TestPermissionsResponse expectedResponse = new TestPermissionsResponse
            {
                Permissions =
                {
                    "permissions535a2741",
                },
            };
            mockGrpcClient.Setup(x => x.TestIamPermissionsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<TestPermissionsResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissions()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            TestIamPermissionsRegionDiskRequest request = new TestIamPermissionsRegionDiskRequest
            {
                Region = "regionedb20d96",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            TestPermissionsResponse expectedResponse = new TestPermissionsResponse
            {
                Permissions =
                {
                    "permissions535a2741",
                },
            };
            mockGrpcClient.Setup(x => x.TestIamPermissions(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsAsync()
        {
            moq::Mock<RegionDisks.RegionDisksClient> mockGrpcClient = new moq::Mock<RegionDisks.RegionDisksClient>(moq::MockBehavior.Strict);
            TestIamPermissionsRegionDiskRequest request = new TestIamPermissionsRegionDiskRequest
            {
                Region = "regionedb20d96",
                TestPermissionsRequestResource = new TestPermissionsRequest(),
                Resource = "resource164eab96",
                Project = "projectaa6ff846",
            };
            TestPermissionsResponse expectedResponse = new TestPermissionsResponse
            {
                Permissions =
                {
                    "permissions535a2741",
                },
            };
            mockGrpcClient.Setup(x => x.TestIamPermissionsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<TestPermissionsResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionDisksClient client = new RegionDisksClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
