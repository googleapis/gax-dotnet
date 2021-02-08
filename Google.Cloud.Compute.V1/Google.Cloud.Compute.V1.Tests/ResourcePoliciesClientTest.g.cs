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
    public sealed class GeneratedResourcePoliciesClientTest
    {
        [xunit::FactAttribute]
        public void AggregatedListRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            AggregatedListResourcePoliciesRequest request = new AggregatedListResourcePoliciesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ResourcePolicyAggregatedList expectedResponse = new ResourcePolicyAggregatedList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new ResourcePoliciesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyAggregatedList response = client.AggregatedList(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            AggregatedListResourcePoliciesRequest request = new AggregatedListResourcePoliciesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ResourcePolicyAggregatedList expectedResponse = new ResourcePolicyAggregatedList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new ResourcePoliciesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ResourcePolicyAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyAggregatedList responseCallSettings = await client.AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ResourcePolicyAggregatedList responseCancellationToken = await client.AggregatedListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AggregatedList()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            AggregatedListResourcePoliciesRequest request = new AggregatedListResourcePoliciesRequest
            {
                Project = "projectaa6ff846",
            };
            ResourcePolicyAggregatedList expectedResponse = new ResourcePolicyAggregatedList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new ResourcePoliciesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyAggregatedList response = client.AggregatedList(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            AggregatedListResourcePoliciesRequest request = new AggregatedListResourcePoliciesRequest
            {
                Project = "projectaa6ff846",
            };
            ResourcePolicyAggregatedList expectedResponse = new ResourcePolicyAggregatedList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new ResourcePoliciesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ResourcePolicyAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyAggregatedList responseCallSettings = await client.AggregatedListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ResourcePolicyAggregatedList responseCancellationToken = await client.AggregatedListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            DeleteResourcePolicyRequest request = new DeleteResourcePolicyRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            DeleteResourcePolicyRequest request = new DeleteResourcePolicyRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            DeleteResourcePolicyRequest request = new DeleteResourcePolicyRequest
            {
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Region, request.ResourcePolicy);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            DeleteResourcePolicyRequest request = new DeleteResourcePolicyRequest
            {
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Region, request.ResourcePolicy, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Region, request.ResourcePolicy, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetResourcePolicyRequest request = new GetResourcePolicyRequest
            {
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
                Project = "projectaa6ff846",
            };
            ResourcePolicy expectedResponse = new ResourcePolicy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                GroupPlacementPolicy = new ResourcePolicyGroupPlacementPolicy(),
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = ResourcePolicy.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                SnapshotSchedulePolicy = new ResourcePolicySnapshotSchedulePolicy(),
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicy response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetResourcePolicyRequest request = new GetResourcePolicyRequest
            {
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
                Project = "projectaa6ff846",
            };
            ResourcePolicy expectedResponse = new ResourcePolicy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                GroupPlacementPolicy = new ResourcePolicyGroupPlacementPolicy(),
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = ResourcePolicy.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                SnapshotSchedulePolicy = new ResourcePolicySnapshotSchedulePolicy(),
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ResourcePolicy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicy responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ResourcePolicy responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetResourcePolicyRequest request = new GetResourcePolicyRequest
            {
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
                Project = "projectaa6ff846",
            };
            ResourcePolicy expectedResponse = new ResourcePolicy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                GroupPlacementPolicy = new ResourcePolicyGroupPlacementPolicy(),
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = ResourcePolicy.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                SnapshotSchedulePolicy = new ResourcePolicySnapshotSchedulePolicy(),
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicy response = client.Get(request.Project, request.Region, request.ResourcePolicy);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetResourcePolicyRequest request = new GetResourcePolicyRequest
            {
                Region = "regionedb20d96",
                ResourcePolicy = "resource_policydde7e557",
                Project = "projectaa6ff846",
            };
            ResourcePolicy expectedResponse = new ResourcePolicy
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                GroupPlacementPolicy = new ResourcePolicyGroupPlacementPolicy(),
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = ResourcePolicy.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                SnapshotSchedulePolicy = new ResourcePolicySnapshotSchedulePolicy(),
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ResourcePolicy>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicy responseCallSettings = await client.GetAsync(request.Project, request.Region, request.ResourcePolicy, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ResourcePolicy responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.ResourcePolicy, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicyRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetIamPolicyResourcePolicyRequest request = new GetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetIamPolicyResourcePolicyRequest request = new GetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicy()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetIamPolicyResourcePolicyRequest request = new GetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request.Project, request.Region, request.Resource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            GetIamPolicyResourcePolicyRequest request = new GetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request.Project, request.Region, request.Resource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request.Project, request.Region, request.Resource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            InsertResourcePolicyRequest request = new InsertResourcePolicyRequest
            {
                RequestId = "request_id362c8df6",
                ResourcePolicyResource = new ResourcePolicy(),
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            InsertResourcePolicyRequest request = new InsertResourcePolicyRequest
            {
                RequestId = "request_id362c8df6",
                ResourcePolicyResource = new ResourcePolicy(),
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            InsertResourcePolicyRequest request = new InsertResourcePolicyRequest
            {
                ResourcePolicyResource = new ResourcePolicy(),
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.Region, request.ResourcePolicyResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            InsertResourcePolicyRequest request = new InsertResourcePolicyRequest
            {
                ResourcePolicyResource = new ResourcePolicy(),
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.Region, request.ResourcePolicyResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.Region, request.ResourcePolicyResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            ListResourcePoliciesRequest request = new ListResourcePoliciesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ResourcePolicyList expectedResponse = new ResourcePolicyList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new ResourcePolicy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            ListResourcePoliciesRequest request = new ListResourcePoliciesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ResourcePolicyList expectedResponse = new ResourcePolicyList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new ResourcePolicy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ResourcePolicyList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ResourcePolicyList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            ListResourcePoliciesRequest request = new ListResourcePoliciesRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            ResourcePolicyList expectedResponse = new ResourcePolicyList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new ResourcePolicy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            ListResourcePoliciesRequest request = new ListResourcePoliciesRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            ResourcePolicyList expectedResponse = new ResourcePolicyList
            {
                Id = "id74b70bb8",
                Etag = "etage8ad7218",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new ResourcePolicy(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ResourcePolicyList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            ResourcePolicyList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ResourcePolicyList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicyRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            SetIamPolicyResourcePolicyRequest request = new SetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            SetIamPolicyResourcePolicyRequest request = new SetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicy()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            SetIamPolicyResourcePolicyRequest request = new SetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            SetIamPolicyResourcePolicyRequest request = new SetIamPolicyResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissionsRequestObject()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsResourcePolicyRequest request = new TestIamPermissionsResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsRequestObjectAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsResourcePolicyRequest request = new TestIamPermissionsResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissions()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsResourcePolicyRequest request = new TestIamPermissionsResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsAsync()
        {
            moq::Mock<ResourcePolicies.ResourcePoliciesClient> mockGrpcClient = new moq::Mock<ResourcePolicies.ResourcePoliciesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsResourcePolicyRequest request = new TestIamPermissionsResourcePolicyRequest
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
            ResourcePoliciesClient client = new ResourcePoliciesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
