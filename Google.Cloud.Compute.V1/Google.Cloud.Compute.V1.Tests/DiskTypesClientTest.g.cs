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
    public sealed class GeneratedDiskTypesClientTest
    {
        [xunit::FactAttribute]
        public void AggregatedListRequestObject()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            AggregatedListDiskTypesRequest request = new AggregatedListDiskTypesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            DiskTypeAggregatedList expectedResponse = new DiskTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new DiskTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeAggregatedList response = client.AggregatedList(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListRequestObjectAsync()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            AggregatedListDiskTypesRequest request = new AggregatedListDiskTypesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            DiskTypeAggregatedList expectedResponse = new DiskTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new DiskTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskTypeAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeAggregatedList responseCallSettings = await client.AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskTypeAggregatedList responseCancellationToken = await client.AggregatedListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AggregatedList()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            AggregatedListDiskTypesRequest request = new AggregatedListDiskTypesRequest
            {
                Project = "projectaa6ff846",
            };
            DiskTypeAggregatedList expectedResponse = new DiskTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new DiskTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeAggregatedList response = client.AggregatedList(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListAsync()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            AggregatedListDiskTypesRequest request = new AggregatedListDiskTypesRequest
            {
                Project = "projectaa6ff846",
            };
            DiskTypeAggregatedList expectedResponse = new DiskTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new DiskTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskTypeAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeAggregatedList responseCallSettings = await client.AggregatedListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskTypeAggregatedList responseCancellationToken = await client.AggregatedListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            GetDiskTypeRequest request = new GetDiskTypeRequest
            {
                Zone = "zone255f4ea8",
                DiskType = "disk_type355e37bc",
                Project = "projectaa6ff846",
            };
            DiskType expectedResponse = new DiskType
            {
                Id = "id74b70bb8",
                DefaultDiskSizeGb = "default_disk_size_gbc588dc05",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ValidDiskSize = "valid_disk_size58dd558f",
                Deprecated = new DeprecationStatus(),
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskType response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            GetDiskTypeRequest request = new GetDiskTypeRequest
            {
                Zone = "zone255f4ea8",
                DiskType = "disk_type355e37bc",
                Project = "projectaa6ff846",
            };
            DiskType expectedResponse = new DiskType
            {
                Id = "id74b70bb8",
                DefaultDiskSizeGb = "default_disk_size_gbc588dc05",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ValidDiskSize = "valid_disk_size58dd558f",
                Deprecated = new DeprecationStatus(),
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskType>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskType responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskType responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            GetDiskTypeRequest request = new GetDiskTypeRequest
            {
                Zone = "zone255f4ea8",
                DiskType = "disk_type355e37bc",
                Project = "projectaa6ff846",
            };
            DiskType expectedResponse = new DiskType
            {
                Id = "id74b70bb8",
                DefaultDiskSizeGb = "default_disk_size_gbc588dc05",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ValidDiskSize = "valid_disk_size58dd558f",
                Deprecated = new DeprecationStatus(),
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskType response = client.Get(request.Project, request.Zone, request.DiskType);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            GetDiskTypeRequest request = new GetDiskTypeRequest
            {
                Zone = "zone255f4ea8",
                DiskType = "disk_type355e37bc",
                Project = "projectaa6ff846",
            };
            DiskType expectedResponse = new DiskType
            {
                Id = "id74b70bb8",
                DefaultDiskSizeGb = "default_disk_size_gbc588dc05",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ValidDiskSize = "valid_disk_size58dd558f",
                Deprecated = new DeprecationStatus(),
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskType>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskType responseCallSettings = await client.GetAsync(request.Project, request.Zone, request.DiskType, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskType responseCancellationToken = await client.GetAsync(request.Project, request.Zone, request.DiskType, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            ListDiskTypesRequest request = new ListDiskTypesRequest
            {
                Zone = "zone255f4ea8",
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            DiskTypeList expectedResponse = new DiskTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new DiskType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            ListDiskTypesRequest request = new ListDiskTypesRequest
            {
                Zone = "zone255f4ea8",
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            DiskTypeList expectedResponse = new DiskTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new DiskType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskTypeList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskTypeList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            ListDiskTypesRequest request = new ListDiskTypesRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
            };
            DiskTypeList expectedResponse = new DiskTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new DiskType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeList response = client.List(request.Project, request.Zone);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<DiskTypes.DiskTypesClient> mockGrpcClient = new moq::Mock<DiskTypes.DiskTypesClient>(moq::MockBehavior.Strict);
            ListDiskTypesRequest request = new ListDiskTypesRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
            };
            DiskTypeList expectedResponse = new DiskTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new DiskType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<DiskTypeList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            DiskTypesClient client = new DiskTypesClientImpl(mockGrpcClient.Object, null);
            DiskTypeList responseCallSettings = await client.ListAsync(request.Project, request.Zone, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            DiskTypeList responseCancellationToken = await client.ListAsync(request.Project, request.Zone, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
