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
    public sealed class GeneratedZoneOperationsClientTest
    {
        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            DeleteZoneOperationRequest request = new DeleteZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
                Project = "projectaa6ff846",
            };
            DeleteZoneOperationResponse expectedResponse = new DeleteZoneOperationResponse { };
            mockGrpcClient.Setup(x => x.Delete(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            DeleteZoneOperationResponse response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            DeleteZoneOperationRequest request = new DeleteZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
                Project = "projectaa6ff846",
            };
            DeleteZoneOperationResponse expectedResponse = new DeleteZoneOperationResponse { };
            mockGrpcClient.Setup(x => x.DeleteAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DeleteZoneOperationResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            DeleteZoneOperationResponse responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DeleteZoneOperationResponse responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            DeleteZoneOperationRequest request = new DeleteZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
                Project = "projectaa6ff846",
            };
            DeleteZoneOperationResponse expectedResponse = new DeleteZoneOperationResponse { };
            mockGrpcClient.Setup(x => x.Delete(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            DeleteZoneOperationResponse response = client.Delete(request.Project, request.Zone, request.Operation);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            DeleteZoneOperationRequest request = new DeleteZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
                Project = "projectaa6ff846",
            };
            DeleteZoneOperationResponse expectedResponse = new DeleteZoneOperationResponse { };
            mockGrpcClient.Setup(x => x.DeleteAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DeleteZoneOperationResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            DeleteZoneOperationResponse responseCallSettings = await client.DeleteAsync(request.Project, request.Zone, request.Operation, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DeleteZoneOperationResponse responseCancellationToken = await client.DeleteAsync(request.Project, request.Zone, request.Operation, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            GetZoneOperationRequest request = new GetZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            GetZoneOperationRequest request = new GetZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            GetZoneOperationRequest request = new GetZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Get(request.Project, request.Zone, request.Operation);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            GetZoneOperationRequest request = new GetZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.GetAsync(request.Project, request.Zone, request.Operation, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.GetAsync(request.Project, request.Zone, request.Operation, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            ListZoneOperationsRequest request = new ListZoneOperationsRequest
            {
                Zone = "zone255f4ea8",
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            OperationList expectedResponse = new OperationList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Operation(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            OperationList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            ListZoneOperationsRequest request = new ListZoneOperationsRequest
            {
                Zone = "zone255f4ea8",
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            OperationList expectedResponse = new OperationList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Operation(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<OperationList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            OperationList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            OperationList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            ListZoneOperationsRequest request = new ListZoneOperationsRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
            };
            OperationList expectedResponse = new OperationList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Operation(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            OperationList response = client.List(request.Project, request.Zone);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            ListZoneOperationsRequest request = new ListZoneOperationsRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
            };
            OperationList expectedResponse = new OperationList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Operation(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<OperationList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            OperationList responseCallSettings = await client.ListAsync(request.Project, request.Zone, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            OperationList responseCancellationToken = await client.ListAsync(request.Project, request.Zone, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void WaitRequestObject()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            WaitZoneOperationRequest request = new WaitZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.Wait(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Wait(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WaitRequestObjectAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            WaitZoneOperationRequest request = new WaitZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.WaitAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.WaitAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.WaitAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Wait()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            WaitZoneOperationRequest request = new WaitZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.Wait(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Wait(request.Project, request.Zone, request.Operation);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task WaitAsync()
        {
            moq::Mock<ZoneOperations.ZoneOperationsClient> mockGrpcClient = new moq::Mock<ZoneOperations.ZoneOperationsClient>(moq::MockBehavior.Strict);
            WaitZoneOperationRequest request = new WaitZoneOperationRequest
            {
                Zone = "zone255f4ea8",
                Operation = "operation615a23f7",
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
            mockGrpcClient.Setup(x => x.WaitAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ZoneOperationsClient client = new ZoneOperationsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.WaitAsync(request.Project, request.Zone, request.Operation, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.WaitAsync(request.Project, request.Zone, request.Operation, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
