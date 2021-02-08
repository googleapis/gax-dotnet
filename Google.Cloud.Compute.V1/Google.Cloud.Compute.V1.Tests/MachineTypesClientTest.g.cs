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
    public sealed class GeneratedMachineTypesClientTest
    {
        [xunit::FactAttribute]
        public void AggregatedListRequestObject()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            AggregatedListMachineTypesRequest request = new AggregatedListMachineTypesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            MachineTypeAggregatedList expectedResponse = new MachineTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new MachineTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeAggregatedList response = client.AggregatedList(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListRequestObjectAsync()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            AggregatedListMachineTypesRequest request = new AggregatedListMachineTypesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            MachineTypeAggregatedList expectedResponse = new MachineTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new MachineTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<MachineTypeAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeAggregatedList responseCallSettings = await client.AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            MachineTypeAggregatedList responseCancellationToken = await client.AggregatedListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AggregatedList()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            AggregatedListMachineTypesRequest request = new AggregatedListMachineTypesRequest
            {
                Project = "projectaa6ff846",
            };
            MachineTypeAggregatedList expectedResponse = new MachineTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new MachineTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeAggregatedList response = client.AggregatedList(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListAsync()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            AggregatedListMachineTypesRequest request = new AggregatedListMachineTypesRequest
            {
                Project = "projectaa6ff846",
            };
            MachineTypeAggregatedList expectedResponse = new MachineTypeAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new MachineTypesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<MachineTypeAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeAggregatedList responseCallSettings = await client.AggregatedListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            MachineTypeAggregatedList responseCancellationToken = await client.AggregatedListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            GetMachineTypeRequest request = new GetMachineTypeRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
                MachineType = "machine_type68ce40fa",
            };
            MachineType expectedResponse = new MachineType
            {
                Id = "id74b70bb8",
                Accelerators = { new Accelerators(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                ImageSpaceGb = 480303298,
                MemoryMb = -1241574521,
                GuestCpus = 325324266,
                MaximumPersistentDisksSizeGb = "maximum_persistent_disks_size_gb3b744507",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ScratchDisks = { new ScratchDisks(), },
                MaximumPersistentDisks = 774121303,
                Deprecated = new DeprecationStatus(),
                IsSharedCpu = true,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineType response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            GetMachineTypeRequest request = new GetMachineTypeRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
                MachineType = "machine_type68ce40fa",
            };
            MachineType expectedResponse = new MachineType
            {
                Id = "id74b70bb8",
                Accelerators = { new Accelerators(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                ImageSpaceGb = 480303298,
                MemoryMb = -1241574521,
                GuestCpus = 325324266,
                MaximumPersistentDisksSizeGb = "maximum_persistent_disks_size_gb3b744507",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ScratchDisks = { new ScratchDisks(), },
                MaximumPersistentDisks = 774121303,
                Deprecated = new DeprecationStatus(),
                IsSharedCpu = true,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<MachineType>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineType responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            MachineType responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            GetMachineTypeRequest request = new GetMachineTypeRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
                MachineType = "machine_type68ce40fa",
            };
            MachineType expectedResponse = new MachineType
            {
                Id = "id74b70bb8",
                Accelerators = { new Accelerators(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                ImageSpaceGb = 480303298,
                MemoryMb = -1241574521,
                GuestCpus = 325324266,
                MaximumPersistentDisksSizeGb = "maximum_persistent_disks_size_gb3b744507",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ScratchDisks = { new ScratchDisks(), },
                MaximumPersistentDisks = 774121303,
                Deprecated = new DeprecationStatus(),
                IsSharedCpu = true,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineType response = client.Get(request.Project, request.Zone, request.MachineType);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            GetMachineTypeRequest request = new GetMachineTypeRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
                MachineType = "machine_type68ce40fa",
            };
            MachineType expectedResponse = new MachineType
            {
                Id = "id74b70bb8",
                Accelerators = { new Accelerators(), },
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                Zone = "zone255f4ea8",
                CreationTimestamp = "creation_timestamp235e59a1",
                ImageSpaceGb = 480303298,
                MemoryMb = -1241574521,
                GuestCpus = 325324266,
                MaximumPersistentDisksSizeGb = "maximum_persistent_disks_size_gb3b744507",
                Description = "description2cf9da67",
                SelfLink = "self_link7e87f12d",
                ScratchDisks = { new ScratchDisks(), },
                MaximumPersistentDisks = 774121303,
                Deprecated = new DeprecationStatus(),
                IsSharedCpu = true,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<MachineType>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineType responseCallSettings = await client.GetAsync(request.Project, request.Zone, request.MachineType, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            MachineType responseCancellationToken = await client.GetAsync(request.Project, request.Zone, request.MachineType, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            ListMachineTypesRequest request = new ListMachineTypesRequest
            {
                Zone = "zone255f4ea8",
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            MachineTypeList expectedResponse = new MachineTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new MachineType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            ListMachineTypesRequest request = new ListMachineTypesRequest
            {
                Zone = "zone255f4ea8",
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            MachineTypeList expectedResponse = new MachineTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new MachineType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<MachineTypeList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            MachineTypeList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            ListMachineTypesRequest request = new ListMachineTypesRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
            };
            MachineTypeList expectedResponse = new MachineTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new MachineType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeList response = client.List(request.Project, request.Zone);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<MachineTypes.MachineTypesClient> mockGrpcClient = new moq::Mock<MachineTypes.MachineTypesClient>(moq::MockBehavior.Strict);
            ListMachineTypesRequest request = new ListMachineTypesRequest
            {
                Zone = "zone255f4ea8",
                Project = "projectaa6ff846",
            };
            MachineTypeList expectedResponse = new MachineTypeList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new MachineType(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<MachineTypeList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            MachineTypesClient client = new MachineTypesClientImpl(mockGrpcClient.Object, null);
            MachineTypeList responseCallSettings = await client.ListAsync(request.Project, request.Zone, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            MachineTypeList responseCancellationToken = await client.ListAsync(request.Project, request.Zone, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
