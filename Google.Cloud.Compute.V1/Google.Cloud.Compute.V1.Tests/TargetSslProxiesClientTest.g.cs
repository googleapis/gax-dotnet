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
    public sealed class GeneratedTargetSslProxiesClientTest
    {
        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            DeleteTargetSslProxyRequest request = new DeleteTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            DeleteTargetSslProxyRequest request = new DeleteTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            DeleteTargetSslProxyRequest request = new DeleteTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.TargetSslProxy);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            DeleteTargetSslProxyRequest request = new DeleteTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.TargetSslProxy, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.TargetSslProxy, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            GetTargetSslProxyRequest request = new GetTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
            };
            TargetSslProxy expectedResponse = new TargetSslProxy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                SslPolicy = "ssl_policybf005a65",
                CreationTimestamp = "creation_timestamp235e59a1",
                SslCertificates =
                {
                    "ssl_certificates50ceaff5",
                },
                Service = "serviced3f0abaa",
                Description = "description2cf9da67",
                ProxyHeader = TargetSslProxy.Types.ProxyHeader.UndefinedProxyHeader,
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxy response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            GetTargetSslProxyRequest request = new GetTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
            };
            TargetSslProxy expectedResponse = new TargetSslProxy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                SslPolicy = "ssl_policybf005a65",
                CreationTimestamp = "creation_timestamp235e59a1",
                SslCertificates =
                {
                    "ssl_certificates50ceaff5",
                },
                Service = "serviced3f0abaa",
                Description = "description2cf9da67",
                ProxyHeader = TargetSslProxy.Types.ProxyHeader.UndefinedProxyHeader,
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<TargetSslProxy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxy responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TargetSslProxy responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            GetTargetSslProxyRequest request = new GetTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
            };
            TargetSslProxy expectedResponse = new TargetSslProxy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                SslPolicy = "ssl_policybf005a65",
                CreationTimestamp = "creation_timestamp235e59a1",
                SslCertificates =
                {
                    "ssl_certificates50ceaff5",
                },
                Service = "serviced3f0abaa",
                Description = "description2cf9da67",
                ProxyHeader = TargetSslProxy.Types.ProxyHeader.UndefinedProxyHeader,
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxy response = client.Get(request.Project, request.TargetSslProxy);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            GetTargetSslProxyRequest request = new GetTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
            };
            TargetSslProxy expectedResponse = new TargetSslProxy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                SslPolicy = "ssl_policybf005a65",
                CreationTimestamp = "creation_timestamp235e59a1",
                SslCertificates =
                {
                    "ssl_certificates50ceaff5",
                },
                Service = "serviced3f0abaa",
                Description = "description2cf9da67",
                ProxyHeader = TargetSslProxy.Types.ProxyHeader.UndefinedProxyHeader,
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<TargetSslProxy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxy responseCallSettings = await client.GetAsync(request.Project, request.TargetSslProxy, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TargetSslProxy responseCancellationToken = await client.GetAsync(request.Project, request.TargetSslProxy, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            InsertTargetSslProxyRequest request = new InsertTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxyResource = new TargetSslProxy(),
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            InsertTargetSslProxyRequest request = new InsertTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxyResource = new TargetSslProxy(),
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            InsertTargetSslProxyRequest request = new InsertTargetSslProxyRequest
            {
                TargetSslProxyResource = new TargetSslProxy(),
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.TargetSslProxyResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            InsertTargetSslProxyRequest request = new InsertTargetSslProxyRequest
            {
                TargetSslProxyResource = new TargetSslProxy(),
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
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.TargetSslProxyResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.TargetSslProxyResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            ListTargetSslProxiesRequest request = new ListTargetSslProxiesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            TargetSslProxyList expectedResponse = new TargetSslProxyList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new TargetSslProxy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxyList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            ListTargetSslProxiesRequest request = new ListTargetSslProxiesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            TargetSslProxyList expectedResponse = new TargetSslProxyList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new TargetSslProxy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<TargetSslProxyList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxyList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TargetSslProxyList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            ListTargetSslProxiesRequest request = new ListTargetSslProxiesRequest
            {
                Project = "projectaa6ff846",
            };
            TargetSslProxyList expectedResponse = new TargetSslProxyList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new TargetSslProxy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxyList response = client.List(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            ListTargetSslProxiesRequest request = new ListTargetSslProxiesRequest
            {
                Project = "projectaa6ff846",
            };
            TargetSslProxyList expectedResponse = new TargetSslProxyList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new TargetSslProxy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<TargetSslProxyList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            TargetSslProxyList responseCallSettings = await client.ListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TargetSslProxyList responseCancellationToken = await client.ListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetBackendServiceRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetBackendServiceTargetSslProxyRequest request = new SetBackendServiceTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetBackendServiceRequestResource = new TargetSslProxiesSetBackendServiceRequest(),
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
            mockGrpcClient.Setup(x => x.SetBackendService(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetBackendService(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetBackendServiceRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetBackendServiceTargetSslProxyRequest request = new SetBackendServiceTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetBackendServiceRequestResource = new TargetSslProxiesSetBackendServiceRequest(),
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
            mockGrpcClient.Setup(x => x.SetBackendServiceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetBackendServiceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetBackendServiceAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetBackendService()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetBackendServiceTargetSslProxyRequest request = new SetBackendServiceTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetBackendServiceRequestResource = new TargetSslProxiesSetBackendServiceRequest(),
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
            mockGrpcClient.Setup(x => x.SetBackendService(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetBackendService(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetBackendServiceRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetBackendServiceAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetBackendServiceTargetSslProxyRequest request = new SetBackendServiceTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetBackendServiceRequestResource = new TargetSslProxiesSetBackendServiceRequest(),
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
            mockGrpcClient.Setup(x => x.SetBackendServiceAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetBackendServiceAsync(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetBackendServiceRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetBackendServiceAsync(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetBackendServiceRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetProxyHeaderRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetProxyHeaderTargetSslProxyRequest request = new SetProxyHeaderTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetProxyHeaderRequestResource = new TargetSslProxiesSetProxyHeaderRequest(),
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
            mockGrpcClient.Setup(x => x.SetProxyHeader(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetProxyHeader(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetProxyHeaderRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetProxyHeaderTargetSslProxyRequest request = new SetProxyHeaderTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetProxyHeaderRequestResource = new TargetSslProxiesSetProxyHeaderRequest(),
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
            mockGrpcClient.Setup(x => x.SetProxyHeaderAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetProxyHeaderAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetProxyHeaderAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetProxyHeader()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetProxyHeaderTargetSslProxyRequest request = new SetProxyHeaderTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetProxyHeaderRequestResource = new TargetSslProxiesSetProxyHeaderRequest(),
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
            mockGrpcClient.Setup(x => x.SetProxyHeader(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetProxyHeader(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetProxyHeaderRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetProxyHeaderAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetProxyHeaderTargetSslProxyRequest request = new SetProxyHeaderTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetProxyHeaderRequestResource = new TargetSslProxiesSetProxyHeaderRequest(),
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
            mockGrpcClient.Setup(x => x.SetProxyHeaderAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetProxyHeaderAsync(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetProxyHeaderRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetProxyHeaderAsync(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetProxyHeaderRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetSslCertificatesRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslCertificatesTargetSslProxyRequest request = new SetSslCertificatesTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetSslCertificatesRequestResource = new TargetSslProxiesSetSslCertificatesRequest(),
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
            mockGrpcClient.Setup(x => x.SetSslCertificates(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetSslCertificates(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetSslCertificatesRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslCertificatesTargetSslProxyRequest request = new SetSslCertificatesTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetSslCertificatesRequestResource = new TargetSslProxiesSetSslCertificatesRequest(),
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
            mockGrpcClient.Setup(x => x.SetSslCertificatesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetSslCertificatesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetSslCertificatesAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetSslCertificates()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslCertificatesTargetSslProxyRequest request = new SetSslCertificatesTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetSslCertificatesRequestResource = new TargetSslProxiesSetSslCertificatesRequest(),
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
            mockGrpcClient.Setup(x => x.SetSslCertificates(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetSslCertificates(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetSslCertificatesRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetSslCertificatesAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslCertificatesTargetSslProxyRequest request = new SetSslCertificatesTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                TargetSslProxiesSetSslCertificatesRequestResource = new TargetSslProxiesSetSslCertificatesRequest(),
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
            mockGrpcClient.Setup(x => x.SetSslCertificatesAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetSslCertificatesAsync(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetSslCertificatesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetSslCertificatesAsync(request.Project, request.TargetSslProxy, request.TargetSslProxiesSetSslCertificatesRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetSslPolicyRequestObject()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslPolicyTargetSslProxyRequest request = new SetSslPolicyTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
                SslPolicyReferenceResource = new SslPolicyReference(),
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
            mockGrpcClient.Setup(x => x.SetSslPolicy(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetSslPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetSslPolicyRequestObjectAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslPolicyTargetSslProxyRequest request = new SetSslPolicyTargetSslProxyRequest
            {
                RequestId = "request_id362c8df6",
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
                SslPolicyReferenceResource = new SslPolicyReference(),
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
            mockGrpcClient.Setup(x => x.SetSslPolicyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetSslPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetSslPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetSslPolicy()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslPolicyTargetSslProxyRequest request = new SetSslPolicyTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
                SslPolicyReferenceResource = new SslPolicyReference(),
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
            mockGrpcClient.Setup(x => x.SetSslPolicy(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetSslPolicy(request.Project, request.TargetSslProxy, request.SslPolicyReferenceResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetSslPolicyAsync()
        {
            moq::Mock<TargetSslProxies.TargetSslProxiesClient> mockGrpcClient = new moq::Mock<TargetSslProxies.TargetSslProxiesClient>(moq::MockBehavior.Strict);
            SetSslPolicyTargetSslProxyRequest request = new SetSslPolicyTargetSslProxyRequest
            {
                TargetSslProxy = "target_ssl_proxy8c6691c6",
                Project = "projectaa6ff846",
                SslPolicyReferenceResource = new SslPolicyReference(),
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
            mockGrpcClient.Setup(x => x.SetSslPolicyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            TargetSslProxiesClient client = new TargetSslProxiesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetSslPolicyAsync(request.Project, request.TargetSslProxy, request.SslPolicyReferenceResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetSslPolicyAsync(request.Project, request.TargetSslProxy, request.SslPolicyReferenceResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
