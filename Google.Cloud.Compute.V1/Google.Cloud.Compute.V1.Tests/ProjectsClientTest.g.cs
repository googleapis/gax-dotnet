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
    public sealed class GeneratedProjectsClientTest
    {
        [xunit::FactAttribute]
        public void DisableXpnHostRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnHostProjectRequest request = new DisableXpnHostProjectRequest
            {
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.DisableXpnHost(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.DisableXpnHost(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DisableXpnHostRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnHostProjectRequest request = new DisableXpnHostProjectRequest
            {
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.DisableXpnHostAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DisableXpnHostAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DisableXpnHostAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DisableXpnHost()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnHostProjectRequest request = new DisableXpnHostProjectRequest
            {
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
            mockGrpcClient.Setup(x => x.DisableXpnHost(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.DisableXpnHost(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DisableXpnHostAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnHostProjectRequest request = new DisableXpnHostProjectRequest
            {
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
            mockGrpcClient.Setup(x => x.DisableXpnHostAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DisableXpnHostAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DisableXpnHostAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DisableXpnResourceRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnResourceProjectRequest request = new DisableXpnResourceProjectRequest
            {
                RequestId = "request_id362c8df6",
                ProjectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.DisableXpnResource(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.DisableXpnResource(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DisableXpnResourceRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnResourceProjectRequest request = new DisableXpnResourceProjectRequest
            {
                RequestId = "request_id362c8df6",
                ProjectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.DisableXpnResourceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DisableXpnResourceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DisableXpnResourceAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DisableXpnResource()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnResourceProjectRequest request = new DisableXpnResourceProjectRequest
            {
                ProjectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.DisableXpnResource(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.DisableXpnResource(request.Project, request.ProjectsDisableXpnResourceRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DisableXpnResourceAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            DisableXpnResourceProjectRequest request = new DisableXpnResourceProjectRequest
            {
                ProjectsDisableXpnResourceRequestResource = new ProjectsDisableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.DisableXpnResourceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DisableXpnResourceAsync(request.Project, request.ProjectsDisableXpnResourceRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DisableXpnResourceAsync(request.Project, request.ProjectsDisableXpnResourceRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void EnableXpnHostRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnHostProjectRequest request = new EnableXpnHostProjectRequest
            {
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.EnableXpnHost(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.EnableXpnHost(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task EnableXpnHostRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnHostProjectRequest request = new EnableXpnHostProjectRequest
            {
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.EnableXpnHostAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.EnableXpnHostAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.EnableXpnHostAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void EnableXpnHost()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnHostProjectRequest request = new EnableXpnHostProjectRequest
            {
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
            mockGrpcClient.Setup(x => x.EnableXpnHost(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.EnableXpnHost(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task EnableXpnHostAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnHostProjectRequest request = new EnableXpnHostProjectRequest
            {
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
            mockGrpcClient.Setup(x => x.EnableXpnHostAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.EnableXpnHostAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.EnableXpnHostAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void EnableXpnResourceRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnResourceProjectRequest request = new EnableXpnResourceProjectRequest
            {
                RequestId = "request_id362c8df6",
                ProjectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.EnableXpnResource(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.EnableXpnResource(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task EnableXpnResourceRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnResourceProjectRequest request = new EnableXpnResourceProjectRequest
            {
                RequestId = "request_id362c8df6",
                ProjectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.EnableXpnResourceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.EnableXpnResourceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.EnableXpnResourceAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void EnableXpnResource()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnResourceProjectRequest request = new EnableXpnResourceProjectRequest
            {
                ProjectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.EnableXpnResource(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.EnableXpnResource(request.Project, request.ProjectsEnableXpnResourceRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task EnableXpnResourceAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            EnableXpnResourceProjectRequest request = new EnableXpnResourceProjectRequest
            {
                ProjectsEnableXpnResourceRequestResource = new ProjectsEnableXpnResourceRequest(),
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
            mockGrpcClient.Setup(x => x.EnableXpnResourceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.EnableXpnResourceAsync(request.Project, request.ProjectsEnableXpnResourceRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.EnableXpnResourceAsync(request.Project, request.ProjectsEnableXpnResourceRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetProjectRequest request = new GetProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetProjectRequest request = new GetProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Project>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Project responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetProjectRequest request = new GetProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project response = client.Get(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetProjectRequest request = new GetProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Project>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project responseCallSettings = await client.GetAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Project responseCancellationToken = await client.GetAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetXpnHostRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnHostProjectRequest request = new GetXpnHostProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.GetXpnHost(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project response = client.GetXpnHost(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetXpnHostRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnHostProjectRequest request = new GetXpnHostProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.GetXpnHostAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Project>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project responseCallSettings = await client.GetXpnHostAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Project responseCancellationToken = await client.GetXpnHostAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetXpnHost()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnHostProjectRequest request = new GetXpnHostProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.GetXpnHost(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project response = client.GetXpnHost(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetXpnHostAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnHostProjectRequest request = new GetXpnHostProjectRequest
            {
                Project = "projectaa6ff846",
            };
            Project expectedResponse = new Project
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                DefaultServiceAccount = "default_service_accountdf12b0f2",
                CreationTimestamp = "creation_timestamp235e59a1",
                UsageExportLocation = new UsageExportLocation(),
                Quotas = { new Quota(), },
                Description = "description2cf9da67",
                CommonInstanceMetadata = new Metadata(),
                SelfLink = "self_link7e87f12d",
                EnabledFeatures =
                {
                    "enabled_featuresf1f398e0",
                },
                DefaultNetworkTier = Project.Types.DefaultNetworkTier.Premium,
                XpnProjectStatus = Project.Types.XpnProjectStatus.Host,
            };
            mockGrpcClient.Setup(x => x.GetXpnHostAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Project>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Project responseCallSettings = await client.GetXpnHostAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Project responseCancellationToken = await client.GetXpnHostAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetXpnResourcesRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnResourcesProjectsRequest request = new GetXpnResourcesProjectsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ProjectsGetXpnResources expectedResponse = new ProjectsGetXpnResources
            {
                Kind = "kindf7aa39d9",
                NextPageToken = "next_page_tokendbee0940",
                Resources =
                {
                    new XpnResourceId(),
                },
            };
            mockGrpcClient.Setup(x => x.GetXpnResources(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            ProjectsGetXpnResources response = client.GetXpnResources(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetXpnResourcesRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnResourcesProjectsRequest request = new GetXpnResourcesProjectsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ProjectsGetXpnResources expectedResponse = new ProjectsGetXpnResources
            {
                Kind = "kindf7aa39d9",
                NextPageToken = "next_page_tokendbee0940",
                Resources =
                {
                    new XpnResourceId(),
                },
            };
            mockGrpcClient.Setup(x => x.GetXpnResourcesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ProjectsGetXpnResources>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            ProjectsGetXpnResources responseCallSettings = await client.GetXpnResourcesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ProjectsGetXpnResources responseCancellationToken = await client.GetXpnResourcesAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetXpnResources()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnResourcesProjectsRequest request = new GetXpnResourcesProjectsRequest
            {
                Project = "projectaa6ff846",
            };
            ProjectsGetXpnResources expectedResponse = new ProjectsGetXpnResources
            {
                Kind = "kindf7aa39d9",
                NextPageToken = "next_page_tokendbee0940",
                Resources =
                {
                    new XpnResourceId(),
                },
            };
            mockGrpcClient.Setup(x => x.GetXpnResources(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            ProjectsGetXpnResources response = client.GetXpnResources(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetXpnResourcesAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            GetXpnResourcesProjectsRequest request = new GetXpnResourcesProjectsRequest
            {
                Project = "projectaa6ff846",
            };
            ProjectsGetXpnResources expectedResponse = new ProjectsGetXpnResources
            {
                Kind = "kindf7aa39d9",
                NextPageToken = "next_page_tokendbee0940",
                Resources =
                {
                    new XpnResourceId(),
                },
            };
            mockGrpcClient.Setup(x => x.GetXpnResourcesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ProjectsGetXpnResources>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            ProjectsGetXpnResources responseCallSettings = await client.GetXpnResourcesAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ProjectsGetXpnResources responseCancellationToken = await client.GetXpnResourcesAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListXpnHostsRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            ListXpnHostsProjectsRequest request = new ListXpnHostsProjectsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ProjectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest(),
                ReturnPartialSuccess = false,
            };
            XpnHostList expectedResponse = new XpnHostList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Project(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListXpnHosts(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            XpnHostList response = client.ListXpnHosts(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListXpnHostsRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            ListXpnHostsProjectsRequest request = new ListXpnHostsProjectsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ProjectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest(),
                ReturnPartialSuccess = false,
            };
            XpnHostList expectedResponse = new XpnHostList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Project(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListXpnHostsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<XpnHostList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            XpnHostList responseCallSettings = await client.ListXpnHostsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            XpnHostList responseCancellationToken = await client.ListXpnHostsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListXpnHosts()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            ListXpnHostsProjectsRequest request = new ListXpnHostsProjectsRequest
            {
                Project = "projectaa6ff846",
                ProjectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest(),
            };
            XpnHostList expectedResponse = new XpnHostList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Project(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListXpnHosts(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            XpnHostList response = client.ListXpnHosts(request.Project, request.ProjectsListXpnHostsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListXpnHostsAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            ListXpnHostsProjectsRequest request = new ListXpnHostsProjectsRequest
            {
                Project = "projectaa6ff846",
                ProjectsListXpnHostsRequestResource = new ProjectsListXpnHostsRequest(),
            };
            XpnHostList expectedResponse = new XpnHostList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Project(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListXpnHostsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<XpnHostList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            XpnHostList responseCallSettings = await client.ListXpnHostsAsync(request.Project, request.ProjectsListXpnHostsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            XpnHostList responseCancellationToken = await client.ListXpnHostsAsync(request.Project, request.ProjectsListXpnHostsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MoveDiskRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveDiskProjectRequest request = new MoveDiskProjectRequest
            {
                RequestId = "request_id362c8df6",
                DiskMoveRequestResource = new DiskMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveDisk(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.MoveDisk(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MoveDiskRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveDiskProjectRequest request = new MoveDiskProjectRequest
            {
                RequestId = "request_id362c8df6",
                DiskMoveRequestResource = new DiskMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveDiskAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.MoveDiskAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.MoveDiskAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MoveDisk()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveDiskProjectRequest request = new MoveDiskProjectRequest
            {
                DiskMoveRequestResource = new DiskMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveDisk(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.MoveDisk(request.Project, request.DiskMoveRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MoveDiskAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveDiskProjectRequest request = new MoveDiskProjectRequest
            {
                DiskMoveRequestResource = new DiskMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveDiskAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.MoveDiskAsync(request.Project, request.DiskMoveRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.MoveDiskAsync(request.Project, request.DiskMoveRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MoveInstanceRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveInstanceProjectRequest request = new MoveInstanceProjectRequest
            {
                RequestId = "request_id362c8df6",
                InstanceMoveRequestResource = new InstanceMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveInstance(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.MoveInstance(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MoveInstanceRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveInstanceProjectRequest request = new MoveInstanceProjectRequest
            {
                RequestId = "request_id362c8df6",
                InstanceMoveRequestResource = new InstanceMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveInstanceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.MoveInstanceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.MoveInstanceAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void MoveInstance()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveInstanceProjectRequest request = new MoveInstanceProjectRequest
            {
                InstanceMoveRequestResource = new InstanceMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveInstance(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.MoveInstance(request.Project, request.InstanceMoveRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task MoveInstanceAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            MoveInstanceProjectRequest request = new MoveInstanceProjectRequest
            {
                InstanceMoveRequestResource = new InstanceMoveRequest(),
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
            mockGrpcClient.Setup(x => x.MoveInstanceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.MoveInstanceAsync(request.Project, request.InstanceMoveRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.MoveInstanceAsync(request.Project, request.InstanceMoveRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetCommonInstanceMetadataRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetCommonInstanceMetadataProjectRequest request = new SetCommonInstanceMetadataProjectRequest
            {
                MetadataResource = new Metadata(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.SetCommonInstanceMetadata(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetCommonInstanceMetadata(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetCommonInstanceMetadataRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetCommonInstanceMetadataProjectRequest request = new SetCommonInstanceMetadataProjectRequest
            {
                MetadataResource = new Metadata(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.SetCommonInstanceMetadataAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetCommonInstanceMetadataAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetCommonInstanceMetadataAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetCommonInstanceMetadata()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetCommonInstanceMetadataProjectRequest request = new SetCommonInstanceMetadataProjectRequest
            {
                MetadataResource = new Metadata(),
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
            mockGrpcClient.Setup(x => x.SetCommonInstanceMetadata(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetCommonInstanceMetadata(request.Project, request.MetadataResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetCommonInstanceMetadataAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetCommonInstanceMetadataProjectRequest request = new SetCommonInstanceMetadataProjectRequest
            {
                MetadataResource = new Metadata(),
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
            mockGrpcClient.Setup(x => x.SetCommonInstanceMetadataAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetCommonInstanceMetadataAsync(request.Project, request.MetadataResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetCommonInstanceMetadataAsync(request.Project, request.MetadataResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetDefaultNetworkTierRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetDefaultNetworkTierProjectRequest request = new SetDefaultNetworkTierProjectRequest
            {
                RequestId = "request_id362c8df6",
                ProjectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest(),
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
            mockGrpcClient.Setup(x => x.SetDefaultNetworkTier(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetDefaultNetworkTier(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetDefaultNetworkTierRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetDefaultNetworkTierProjectRequest request = new SetDefaultNetworkTierProjectRequest
            {
                RequestId = "request_id362c8df6",
                ProjectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest(),
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
            mockGrpcClient.Setup(x => x.SetDefaultNetworkTierAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetDefaultNetworkTierAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetDefaultNetworkTierAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetDefaultNetworkTier()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetDefaultNetworkTierProjectRequest request = new SetDefaultNetworkTierProjectRequest
            {
                ProjectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest(),
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
            mockGrpcClient.Setup(x => x.SetDefaultNetworkTier(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetDefaultNetworkTier(request.Project, request.ProjectsSetDefaultNetworkTierRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetDefaultNetworkTierAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetDefaultNetworkTierProjectRequest request = new SetDefaultNetworkTierProjectRequest
            {
                ProjectsSetDefaultNetworkTierRequestResource = new ProjectsSetDefaultNetworkTierRequest(),
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
            mockGrpcClient.Setup(x => x.SetDefaultNetworkTierAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetDefaultNetworkTierAsync(request.Project, request.ProjectsSetDefaultNetworkTierRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetDefaultNetworkTierAsync(request.Project, request.ProjectsSetDefaultNetworkTierRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetUsageExportBucketRequestObject()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetUsageExportBucketProjectRequest request = new SetUsageExportBucketProjectRequest
            {
                UsageExportLocationResource = new UsageExportLocation(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.SetUsageExportBucket(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetUsageExportBucket(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetUsageExportBucketRequestObjectAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetUsageExportBucketProjectRequest request = new SetUsageExportBucketProjectRequest
            {
                UsageExportLocationResource = new UsageExportLocation(),
                RequestId = "request_id362c8df6",
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
            mockGrpcClient.Setup(x => x.SetUsageExportBucketAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetUsageExportBucketAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetUsageExportBucketAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetUsageExportBucket()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetUsageExportBucketProjectRequest request = new SetUsageExportBucketProjectRequest
            {
                UsageExportLocationResource = new UsageExportLocation(),
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
            mockGrpcClient.Setup(x => x.SetUsageExportBucket(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetUsageExportBucket(request.Project, request.UsageExportLocationResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetUsageExportBucketAsync()
        {
            moq::Mock<Projects.ProjectsClient> mockGrpcClient = new moq::Mock<Projects.ProjectsClient>(moq::MockBehavior.Strict);
            SetUsageExportBucketProjectRequest request = new SetUsageExportBucketProjectRequest
            {
                UsageExportLocationResource = new UsageExportLocation(),
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
            mockGrpcClient.Setup(x => x.SetUsageExportBucketAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ProjectsClient client = new ProjectsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetUsageExportBucketAsync(request.Project, request.UsageExportLocationResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetUsageExportBucketAsync(request.Project, request.UsageExportLocationResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
