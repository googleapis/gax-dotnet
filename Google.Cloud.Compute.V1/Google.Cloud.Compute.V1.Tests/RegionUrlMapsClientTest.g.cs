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
    public sealed class GeneratedRegionUrlMapsClientTest
    {
        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            DeleteRegionUrlMapRequest request = new DeleteRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                UrlMap = "url_map3ccdbf57",
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            DeleteRegionUrlMapRequest request = new DeleteRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                UrlMap = "url_map3ccdbf57",
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            DeleteRegionUrlMapRequest request = new DeleteRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Region, request.UrlMap);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            DeleteRegionUrlMapRequest request = new DeleteRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Region, request.UrlMap, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Region, request.UrlMap, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            GetRegionUrlMapRequest request = new GetRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMap expectedResponse = new UrlMap
            {
                Id = "id74b70bb8",
                PathMatchers = { new PathMatcher(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                HostRules = { new HostRule(), },
                HeaderAction = new HttpHeaderAction(),
                DefaultUrlRedirect = new HttpRedirectAction(),
                DefaultService = "default_serviceb867731a",
                Tests = { new UrlMapTest(), },
                DefaultRouteAction = new HttpRouteAction(),
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMap response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            GetRegionUrlMapRequest request = new GetRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMap expectedResponse = new UrlMap
            {
                Id = "id74b70bb8",
                PathMatchers = { new PathMatcher(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                HostRules = { new HostRule(), },
                HeaderAction = new HttpHeaderAction(),
                DefaultUrlRedirect = new HttpRedirectAction(),
                DefaultService = "default_serviceb867731a",
                Tests = { new UrlMapTest(), },
                DefaultRouteAction = new HttpRouteAction(),
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<UrlMap>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMap responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            UrlMap responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            GetRegionUrlMapRequest request = new GetRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMap expectedResponse = new UrlMap
            {
                Id = "id74b70bb8",
                PathMatchers = { new PathMatcher(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                HostRules = { new HostRule(), },
                HeaderAction = new HttpHeaderAction(),
                DefaultUrlRedirect = new HttpRedirectAction(),
                DefaultService = "default_serviceb867731a",
                Tests = { new UrlMapTest(), },
                DefaultRouteAction = new HttpRouteAction(),
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMap response = client.Get(request.Project, request.Region, request.UrlMap);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            GetRegionUrlMapRequest request = new GetRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMap expectedResponse = new UrlMap
            {
                Id = "id74b70bb8",
                PathMatchers = { new PathMatcher(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                HostRules = { new HostRule(), },
                HeaderAction = new HttpHeaderAction(),
                DefaultUrlRedirect = new HttpRedirectAction(),
                DefaultService = "default_serviceb867731a",
                Tests = { new UrlMapTest(), },
                DefaultRouteAction = new HttpRouteAction(),
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                Fingerprint = "fingerprint009e6052",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<UrlMap>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMap responseCallSettings = await client.GetAsync(request.Project, request.Region, request.UrlMap, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            UrlMap responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.UrlMap, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            InsertRegionUrlMapRequest request = new InsertRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            InsertRegionUrlMapRequest request = new InsertRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            InsertRegionUrlMapRequest request = new InsertRegionUrlMapRequest
            {
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.Region, request.UrlMapResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            InsertRegionUrlMapRequest request = new InsertRegionUrlMapRequest
            {
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.Region, request.UrlMapResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.Region, request.UrlMapResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ListRegionUrlMapsRequest request = new ListRegionUrlMapsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            UrlMapList expectedResponse = new UrlMapList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new UrlMap(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ListRegionUrlMapsRequest request = new ListRegionUrlMapsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            UrlMapList expectedResponse = new UrlMapList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new UrlMap(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<UrlMapList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            UrlMapList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ListRegionUrlMapsRequest request = new ListRegionUrlMapsRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMapList expectedResponse = new UrlMapList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new UrlMap(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ListRegionUrlMapsRequest request = new ListRegionUrlMapsRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMapList expectedResponse = new UrlMapList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new UrlMap(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<UrlMapList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            UrlMapList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void PatchRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            PatchRegionUrlMapRequest request = new PatchRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.Patch(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Patch(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PatchRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            PatchRegionUrlMapRequest request = new PatchRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.PatchAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.PatchAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Patch()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            PatchRegionUrlMapRequest request = new PatchRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.Patch(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Patch(request.Project, request.Region, request.UrlMap, request.UrlMapResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PatchAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            PatchRegionUrlMapRequest request = new PatchRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.PatchAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.PatchAsync(request.Project, request.Region, request.UrlMap, request.UrlMapResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.PatchAsync(request.Project, request.Region, request.UrlMap, request.UrlMapResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void UpdateRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            UpdateRegionUrlMapRequest request = new UpdateRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.Update(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Update(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task UpdateRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            UpdateRegionUrlMapRequest request = new UpdateRegionUrlMapRequest
            {
                RequestId = "request_id362c8df6",
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.UpdateAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.UpdateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.UpdateAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Update()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            UpdateRegionUrlMapRequest request = new UpdateRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.Update(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Update(request.Project, request.Region, request.UrlMap, request.UrlMapResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task UpdateAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            UpdateRegionUrlMapRequest request = new UpdateRegionUrlMapRequest
            {
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                UrlMapResource = new UrlMap(),
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
            mockGrpcClient.Setup(x => x.UpdateAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.UpdateAsync(request.Project, request.Region, request.UrlMap, request.UrlMapResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.UpdateAsync(request.Project, request.Region, request.UrlMap, request.UrlMapResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ValidateRequestObject()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ValidateRegionUrlMapRequest request = new ValidateRegionUrlMapRequest
            {
                RegionUrlMapsValidateRequestResource = new RegionUrlMapsValidateRequest(),
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMapsValidateResponse expectedResponse = new UrlMapsValidateResponse
            {
                Result = new UrlMapValidationResult(),
            };
            mockGrpcClient.Setup(x => x.Validate(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapsValidateResponse response = client.Validate(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ValidateRequestObjectAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ValidateRegionUrlMapRequest request = new ValidateRegionUrlMapRequest
            {
                RegionUrlMapsValidateRequestResource = new RegionUrlMapsValidateRequest(),
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMapsValidateResponse expectedResponse = new UrlMapsValidateResponse
            {
                Result = new UrlMapValidationResult(),
            };
            mockGrpcClient.Setup(x => x.ValidateAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<UrlMapsValidateResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapsValidateResponse responseCallSettings = await client.ValidateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            UrlMapsValidateResponse responseCancellationToken = await client.ValidateAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Validate()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ValidateRegionUrlMapRequest request = new ValidateRegionUrlMapRequest
            {
                RegionUrlMapsValidateRequestResource = new RegionUrlMapsValidateRequest(),
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMapsValidateResponse expectedResponse = new UrlMapsValidateResponse
            {
                Result = new UrlMapValidationResult(),
            };
            mockGrpcClient.Setup(x => x.Validate(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapsValidateResponse response = client.Validate(request.Project, request.Region, request.UrlMap, request.RegionUrlMapsValidateRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ValidateAsync()
        {
            moq::Mock<RegionUrlMaps.RegionUrlMapsClient> mockGrpcClient = new moq::Mock<RegionUrlMaps.RegionUrlMapsClient>(moq::MockBehavior.Strict);
            ValidateRegionUrlMapRequest request = new ValidateRegionUrlMapRequest
            {
                RegionUrlMapsValidateRequestResource = new RegionUrlMapsValidateRequest(),
                UrlMap = "url_map3ccdbf57",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            UrlMapsValidateResponse expectedResponse = new UrlMapsValidateResponse
            {
                Result = new UrlMapValidationResult(),
            };
            mockGrpcClient.Setup(x => x.ValidateAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<UrlMapsValidateResponse>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            RegionUrlMapsClient client = new RegionUrlMapsClientImpl(mockGrpcClient.Object, null);
            UrlMapsValidateResponse responseCallSettings = await client.ValidateAsync(request.Project, request.Region, request.UrlMap, request.RegionUrlMapsValidateRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            UrlMapsValidateResponse responseCancellationToken = await client.ValidateAsync(request.Project, request.Region, request.UrlMap, request.RegionUrlMapsValidateRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
