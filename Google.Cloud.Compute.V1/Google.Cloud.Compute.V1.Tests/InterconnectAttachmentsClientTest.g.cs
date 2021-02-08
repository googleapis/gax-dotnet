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
    public sealed class GeneratedInterconnectAttachmentsClientTest
    {
        [xunit::FactAttribute]
        public void AggregatedListRequestObject()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            AggregatedListInterconnectAttachmentsRequest request = new AggregatedListInterconnectAttachmentsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            InterconnectAttachmentAggregatedList expectedResponse = new InterconnectAttachmentAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new InterconnectAttachmentsScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentAggregatedList response = client.AggregatedList(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListRequestObjectAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            AggregatedListInterconnectAttachmentsRequest request = new AggregatedListInterconnectAttachmentsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            InterconnectAttachmentAggregatedList expectedResponse = new InterconnectAttachmentAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new InterconnectAttachmentsScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InterconnectAttachmentAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentAggregatedList responseCallSettings = await client.AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InterconnectAttachmentAggregatedList responseCancellationToken = await client.AggregatedListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AggregatedList()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            AggregatedListInterconnectAttachmentsRequest request = new AggregatedListInterconnectAttachmentsRequest
            {
                Project = "projectaa6ff846",
            };
            InterconnectAttachmentAggregatedList expectedResponse = new InterconnectAttachmentAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new InterconnectAttachmentsScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentAggregatedList response = client.AggregatedList(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            AggregatedListInterconnectAttachmentsRequest request = new AggregatedListInterconnectAttachmentsRequest
            {
                Project = "projectaa6ff846",
            };
            InterconnectAttachmentAggregatedList expectedResponse = new InterconnectAttachmentAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new InterconnectAttachmentsScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InterconnectAttachmentAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentAggregatedList responseCallSettings = await client.AggregatedListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InterconnectAttachmentAggregatedList responseCancellationToken = await client.AggregatedListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            DeleteInterconnectAttachmentRequest request = new DeleteInterconnectAttachmentRequest
            {
                RequestId = "request_id362c8df6",
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            DeleteInterconnectAttachmentRequest request = new DeleteInterconnectAttachmentRequest
            {
                RequestId = "request_id362c8df6",
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            DeleteInterconnectAttachmentRequest request = new DeleteInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Region, request.InterconnectAttachment);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            DeleteInterconnectAttachmentRequest request = new DeleteInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Region, request.InterconnectAttachment, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Region, request.InterconnectAttachment, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            GetInterconnectAttachmentRequest request = new GetInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InterconnectAttachment expectedResponse = new InterconnectAttachment
            {
                Id = "id74b70bb8",
                Mtu = 1280318054,
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = InterconnectAttachment.Types.Type.PartnerProvider,
                CloudRouterIpAddress = "cloud_router_ip_address62b476a9",
                CreationTimestamp = "creation_timestamp235e59a1",
                DataplaneVersion = -763719012,
                CustomerRouterIpAddress = "customer_router_ip_address819aa186",
                PartnerMetadata = new InterconnectAttachmentPartnerMetadata(),
                EdgeAvailabilityDomain = InterconnectAttachment.Types.EdgeAvailabilityDomain.AvailabilityDomain1,
                State = InterconnectAttachment.Types.State.Unspecified,
                VlanTag8021Q = 1290733749,
                Region = "regionedb20d96",
                Router = "routerd55c39f3",
                Description = "description2cf9da67",
                PartnerAsn = "partner_asn50096c15",
                PairingKey = "pairing_keyfe878c44",
                AdminEnabled = true,
                Bandwidth = InterconnectAttachment.Types.Bandwidth.Bps500M,
                SelfLink = "self_link7e87f12d",
                OperationalStatus = InterconnectAttachment.Types.OperationalStatus.UndefinedOperationalStatus,
                Interconnect = "interconnect253e8bf5",
                PrivateInterconnectInfo = new InterconnectAttachmentPrivateInfo(),
                CandidateSubnets =
                {
                    "candidate_subnets3377adaa",
                },
                GoogleReferenceId = "google_reference_id815b6ab4",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachment response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            GetInterconnectAttachmentRequest request = new GetInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InterconnectAttachment expectedResponse = new InterconnectAttachment
            {
                Id = "id74b70bb8",
                Mtu = 1280318054,
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = InterconnectAttachment.Types.Type.PartnerProvider,
                CloudRouterIpAddress = "cloud_router_ip_address62b476a9",
                CreationTimestamp = "creation_timestamp235e59a1",
                DataplaneVersion = -763719012,
                CustomerRouterIpAddress = "customer_router_ip_address819aa186",
                PartnerMetadata = new InterconnectAttachmentPartnerMetadata(),
                EdgeAvailabilityDomain = InterconnectAttachment.Types.EdgeAvailabilityDomain.AvailabilityDomain1,
                State = InterconnectAttachment.Types.State.Unspecified,
                VlanTag8021Q = 1290733749,
                Region = "regionedb20d96",
                Router = "routerd55c39f3",
                Description = "description2cf9da67",
                PartnerAsn = "partner_asn50096c15",
                PairingKey = "pairing_keyfe878c44",
                AdminEnabled = true,
                Bandwidth = InterconnectAttachment.Types.Bandwidth.Bps500M,
                SelfLink = "self_link7e87f12d",
                OperationalStatus = InterconnectAttachment.Types.OperationalStatus.UndefinedOperationalStatus,
                Interconnect = "interconnect253e8bf5",
                PrivateInterconnectInfo = new InterconnectAttachmentPrivateInfo(),
                CandidateSubnets =
                {
                    "candidate_subnets3377adaa",
                },
                GoogleReferenceId = "google_reference_id815b6ab4",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InterconnectAttachment>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachment responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InterconnectAttachment responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            GetInterconnectAttachmentRequest request = new GetInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InterconnectAttachment expectedResponse = new InterconnectAttachment
            {
                Id = "id74b70bb8",
                Mtu = 1280318054,
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = InterconnectAttachment.Types.Type.PartnerProvider,
                CloudRouterIpAddress = "cloud_router_ip_address62b476a9",
                CreationTimestamp = "creation_timestamp235e59a1",
                DataplaneVersion = -763719012,
                CustomerRouterIpAddress = "customer_router_ip_address819aa186",
                PartnerMetadata = new InterconnectAttachmentPartnerMetadata(),
                EdgeAvailabilityDomain = InterconnectAttachment.Types.EdgeAvailabilityDomain.AvailabilityDomain1,
                State = InterconnectAttachment.Types.State.Unspecified,
                VlanTag8021Q = 1290733749,
                Region = "regionedb20d96",
                Router = "routerd55c39f3",
                Description = "description2cf9da67",
                PartnerAsn = "partner_asn50096c15",
                PairingKey = "pairing_keyfe878c44",
                AdminEnabled = true,
                Bandwidth = InterconnectAttachment.Types.Bandwidth.Bps500M,
                SelfLink = "self_link7e87f12d",
                OperationalStatus = InterconnectAttachment.Types.OperationalStatus.UndefinedOperationalStatus,
                Interconnect = "interconnect253e8bf5",
                PrivateInterconnectInfo = new InterconnectAttachmentPrivateInfo(),
                CandidateSubnets =
                {
                    "candidate_subnets3377adaa",
                },
                GoogleReferenceId = "google_reference_id815b6ab4",
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachment response = client.Get(request.Project, request.Region, request.InterconnectAttachment);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            GetInterconnectAttachmentRequest request = new GetInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InterconnectAttachment expectedResponse = new InterconnectAttachment
            {
                Id = "id74b70bb8",
                Mtu = 1280318054,
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Type = InterconnectAttachment.Types.Type.PartnerProvider,
                CloudRouterIpAddress = "cloud_router_ip_address62b476a9",
                CreationTimestamp = "creation_timestamp235e59a1",
                DataplaneVersion = -763719012,
                CustomerRouterIpAddress = "customer_router_ip_address819aa186",
                PartnerMetadata = new InterconnectAttachmentPartnerMetadata(),
                EdgeAvailabilityDomain = InterconnectAttachment.Types.EdgeAvailabilityDomain.AvailabilityDomain1,
                State = InterconnectAttachment.Types.State.Unspecified,
                VlanTag8021Q = 1290733749,
                Region = "regionedb20d96",
                Router = "routerd55c39f3",
                Description = "description2cf9da67",
                PartnerAsn = "partner_asn50096c15",
                PairingKey = "pairing_keyfe878c44",
                AdminEnabled = true,
                Bandwidth = InterconnectAttachment.Types.Bandwidth.Bps500M,
                SelfLink = "self_link7e87f12d",
                OperationalStatus = InterconnectAttachment.Types.OperationalStatus.UndefinedOperationalStatus,
                Interconnect = "interconnect253e8bf5",
                PrivateInterconnectInfo = new InterconnectAttachmentPrivateInfo(),
                CandidateSubnets =
                {
                    "candidate_subnets3377adaa",
                },
                GoogleReferenceId = "google_reference_id815b6ab4",
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InterconnectAttachment>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachment responseCallSettings = await client.GetAsync(request.Project, request.Region, request.InterconnectAttachment, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InterconnectAttachment responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.InterconnectAttachment, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            InsertInterconnectAttachmentRequest request = new InsertInterconnectAttachmentRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
                Project = "projectaa6ff846",
                ValidateOnly = true,
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            InsertInterconnectAttachmentRequest request = new InsertInterconnectAttachmentRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
                Project = "projectaa6ff846",
                ValidateOnly = true,
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            InsertInterconnectAttachmentRequest request = new InsertInterconnectAttachmentRequest
            {
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.Region, request.InterconnectAttachmentResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            InsertInterconnectAttachmentRequest request = new InsertInterconnectAttachmentRequest
            {
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.Region, request.InterconnectAttachmentResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.Region, request.InterconnectAttachmentResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            ListInterconnectAttachmentsRequest request = new ListInterconnectAttachmentsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            InterconnectAttachmentList expectedResponse = new InterconnectAttachmentList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InterconnectAttachment(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            ListInterconnectAttachmentsRequest request = new ListInterconnectAttachmentsRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            InterconnectAttachmentList expectedResponse = new InterconnectAttachmentList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InterconnectAttachment(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InterconnectAttachmentList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InterconnectAttachmentList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            ListInterconnectAttachmentsRequest request = new ListInterconnectAttachmentsRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InterconnectAttachmentList expectedResponse = new InterconnectAttachmentList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InterconnectAttachment(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            ListInterconnectAttachmentsRequest request = new ListInterconnectAttachmentsRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            InterconnectAttachmentList expectedResponse = new InterconnectAttachmentList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    new InterconnectAttachment(),
                },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<InterconnectAttachmentList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            InterconnectAttachmentList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            InterconnectAttachmentList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void PatchRequestObject()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            PatchInterconnectAttachmentRequest request = new PatchInterconnectAttachmentRequest
            {
                RequestId = "request_id362c8df6",
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Patch(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PatchRequestObjectAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            PatchInterconnectAttachmentRequest request = new PatchInterconnectAttachmentRequest
            {
                RequestId = "request_id362c8df6",
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.PatchAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Patch()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            PatchInterconnectAttachmentRequest request = new PatchInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Patch(request.Project, request.Region, request.InterconnectAttachment, request.InterconnectAttachmentResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PatchAsync()
        {
            moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient> mockGrpcClient = new moq::Mock<InterconnectAttachments.InterconnectAttachmentsClient>(moq::MockBehavior.Strict);
            PatchInterconnectAttachmentRequest request = new PatchInterconnectAttachmentRequest
            {
                InterconnectAttachment = "interconnect_attachmentc83a7a7c",
                Region = "regionedb20d96",
                InterconnectAttachmentResource = new InterconnectAttachment(),
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
            InterconnectAttachmentsClient client = new InterconnectAttachmentsClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.PatchAsync(request.Project, request.Region, request.InterconnectAttachment, request.InterconnectAttachmentResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.PatchAsync(request.Project, request.Region, request.InterconnectAttachment, request.InterconnectAttachmentResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
