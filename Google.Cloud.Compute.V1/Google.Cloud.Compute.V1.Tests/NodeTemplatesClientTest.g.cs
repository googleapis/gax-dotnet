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
    public sealed class GeneratedNodeTemplatesClientTest
    {
        [xunit::FactAttribute]
        public void AggregatedListRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            AggregatedListNodeTemplatesRequest request = new AggregatedListNodeTemplatesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            NodeTemplateAggregatedList expectedResponse = new NodeTemplateAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new NodeTemplatesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateAggregatedList response = client.AggregatedList(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            AggregatedListNodeTemplatesRequest request = new AggregatedListNodeTemplatesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            NodeTemplateAggregatedList expectedResponse = new NodeTemplateAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new NodeTemplatesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<NodeTemplateAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateAggregatedList responseCallSettings = await client.AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            NodeTemplateAggregatedList responseCancellationToken = await client.AggregatedListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AggregatedList()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            AggregatedListNodeTemplatesRequest request = new AggregatedListNodeTemplatesRequest
            {
                Project = "projectaa6ff846",
            };
            NodeTemplateAggregatedList expectedResponse = new NodeTemplateAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new NodeTemplatesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateAggregatedList response = client.AggregatedList(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            AggregatedListNodeTemplatesRequest request = new AggregatedListNodeTemplatesRequest
            {
                Project = "projectaa6ff846",
            };
            NodeTemplateAggregatedList expectedResponse = new NodeTemplateAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new NodeTemplatesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<NodeTemplateAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateAggregatedList responseCallSettings = await client.AggregatedListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            NodeTemplateAggregatedList responseCancellationToken = await client.AggregatedListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            DeleteNodeTemplateRequest request = new DeleteNodeTemplateRequest
            {
                RequestId = "request_id362c8df6",
                NodeTemplate = "node_template118e38ae",
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            DeleteNodeTemplateRequest request = new DeleteNodeTemplateRequest
            {
                RequestId = "request_id362c8df6",
                NodeTemplate = "node_template118e38ae",
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            DeleteNodeTemplateRequest request = new DeleteNodeTemplateRequest
            {
                NodeTemplate = "node_template118e38ae",
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Region, request.NodeTemplate);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            DeleteNodeTemplateRequest request = new DeleteNodeTemplateRequest
            {
                NodeTemplate = "node_template118e38ae",
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Region, request.NodeTemplate, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Region, request.NodeTemplate, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetNodeTemplateRequest request = new GetNodeTemplateRequest
            {
                NodeTemplate = "node_template118e38ae",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            NodeTemplate expectedResponse = new NodeTemplate
            {
                Id = "id74b70bb8",
                Accelerators =
                {
                    new AcceleratorConfig(),
                },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                NodeTypeFlexibility = new NodeTemplateNodeTypeFlexibility(),
                NodeAffinityLabels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Disks = { new LocalDisk(), },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = NodeTemplate.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                NodeType = "node_type98c685da",
                ServerBinding = new ServerBinding(),
                CpuOvercommitType = NodeTemplate.Types.CpuOvercommitType.UndefinedCpuOvercommitType,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplate response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetNodeTemplateRequest request = new GetNodeTemplateRequest
            {
                NodeTemplate = "node_template118e38ae",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            NodeTemplate expectedResponse = new NodeTemplate
            {
                Id = "id74b70bb8",
                Accelerators =
                {
                    new AcceleratorConfig(),
                },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                NodeTypeFlexibility = new NodeTemplateNodeTypeFlexibility(),
                NodeAffinityLabels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Disks = { new LocalDisk(), },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = NodeTemplate.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                NodeType = "node_type98c685da",
                ServerBinding = new ServerBinding(),
                CpuOvercommitType = NodeTemplate.Types.CpuOvercommitType.UndefinedCpuOvercommitType,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<NodeTemplate>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplate responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            NodeTemplate responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetNodeTemplateRequest request = new GetNodeTemplateRequest
            {
                NodeTemplate = "node_template118e38ae",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            NodeTemplate expectedResponse = new NodeTemplate
            {
                Id = "id74b70bb8",
                Accelerators =
                {
                    new AcceleratorConfig(),
                },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                NodeTypeFlexibility = new NodeTemplateNodeTypeFlexibility(),
                NodeAffinityLabels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Disks = { new LocalDisk(), },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = NodeTemplate.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                NodeType = "node_type98c685da",
                ServerBinding = new ServerBinding(),
                CpuOvercommitType = NodeTemplate.Types.CpuOvercommitType.UndefinedCpuOvercommitType,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplate response = client.Get(request.Project, request.Region, request.NodeTemplate);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetNodeTemplateRequest request = new GetNodeTemplateRequest
            {
                NodeTemplate = "node_template118e38ae",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            NodeTemplate expectedResponse = new NodeTemplate
            {
                Id = "id74b70bb8",
                Accelerators =
                {
                    new AcceleratorConfig(),
                },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                StatusMessage = "status_message2c618f86",
                CreationTimestamp = "creation_timestamp235e59a1",
                NodeTypeFlexibility = new NodeTemplateNodeTypeFlexibility(),
                NodeAffinityLabels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                Disks = { new LocalDisk(), },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = NodeTemplate.Types.Status.Ready,
                SelfLink = "self_link7e87f12d",
                NodeType = "node_type98c685da",
                ServerBinding = new ServerBinding(),
                CpuOvercommitType = NodeTemplate.Types.CpuOvercommitType.UndefinedCpuOvercommitType,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<NodeTemplate>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplate responseCallSettings = await client.GetAsync(request.Project, request.Region, request.NodeTemplate, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            NodeTemplate responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.NodeTemplate, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicyRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetIamPolicyNodeTemplateRequest request = new GetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetIamPolicyNodeTemplateRequest request = new GetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicy()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetIamPolicyNodeTemplateRequest request = new GetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request.Project, request.Region, request.Resource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            GetIamPolicyNodeTemplateRequest request = new GetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request.Project, request.Region, request.Resource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request.Project, request.Region, request.Resource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            InsertNodeTemplateRequest request = new InsertNodeTemplateRequest
            {
                RequestId = "request_id362c8df6",
                NodeTemplateResource = new NodeTemplate(),
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            InsertNodeTemplateRequest request = new InsertNodeTemplateRequest
            {
                RequestId = "request_id362c8df6",
                NodeTemplateResource = new NodeTemplate(),
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            InsertNodeTemplateRequest request = new InsertNodeTemplateRequest
            {
                NodeTemplateResource = new NodeTemplate(),
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.Region, request.NodeTemplateResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            InsertNodeTemplateRequest request = new InsertNodeTemplateRequest
            {
                NodeTemplateResource = new NodeTemplate(),
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.Region, request.NodeTemplateResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.Region, request.NodeTemplateResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            ListNodeTemplatesRequest request = new ListNodeTemplatesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            NodeTemplateList expectedResponse = new NodeTemplateList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new NodeTemplate(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            ListNodeTemplatesRequest request = new ListNodeTemplatesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            NodeTemplateList expectedResponse = new NodeTemplateList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new NodeTemplate(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<NodeTemplateList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            NodeTemplateList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            ListNodeTemplatesRequest request = new ListNodeTemplatesRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            NodeTemplateList expectedResponse = new NodeTemplateList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new NodeTemplate(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            ListNodeTemplatesRequest request = new ListNodeTemplatesRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            NodeTemplateList expectedResponse = new NodeTemplateList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new NodeTemplate(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<NodeTemplateList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            NodeTemplateList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            NodeTemplateList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicyRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            SetIamPolicyNodeTemplateRequest request = new SetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            SetIamPolicyNodeTemplateRequest request = new SetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicy()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            SetIamPolicyNodeTemplateRequest request = new SetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            SetIamPolicyNodeTemplateRequest request = new SetIamPolicyNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request.Project, request.Region, request.Resource, request.RegionSetPolicyRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissionsRequestObject()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsNodeTemplateRequest request = new TestIamPermissionsNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsRequestObjectAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsNodeTemplateRequest request = new TestIamPermissionsNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissions()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsNodeTemplateRequest request = new TestIamPermissionsNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsAsync()
        {
            moq::Mock<NodeTemplates.NodeTemplatesClient> mockGrpcClient = new moq::Mock<NodeTemplates.NodeTemplatesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsNodeTemplateRequest request = new TestIamPermissionsNodeTemplateRequest
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
            NodeTemplatesClient client = new NodeTemplatesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request.Project, request.Region, request.Resource, request.TestPermissionsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
