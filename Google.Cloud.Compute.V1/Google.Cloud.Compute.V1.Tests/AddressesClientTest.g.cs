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
    public sealed class GeneratedAddressesClientTest
    {
        [xunit::FactAttribute]
        public void AggregatedListRequestObject()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            AggregatedListAddressesRequest request = new AggregatedListAddressesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            AddressAggregatedList expectedResponse = new AddressAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new AddressesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressAggregatedList response = client.AggregatedList(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListRequestObjectAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            AggregatedListAddressesRequest request = new AggregatedListAddressesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                IncludeAllScopes = false,
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            AddressAggregatedList expectedResponse = new AddressAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new AddressesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<AddressAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressAggregatedList responseCallSettings = await client.AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            AddressAggregatedList responseCancellationToken = await client.AggregatedListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void AggregatedList()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            AggregatedListAddressesRequest request = new AggregatedListAddressesRequest
            {
                Project = "projectaa6ff846",
            };
            AddressAggregatedList expectedResponse = new AddressAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new AddressesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedList(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressAggregatedList response = client.AggregatedList(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task AggregatedListAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            AggregatedListAddressesRequest request = new AggregatedListAddressesRequest
            {
                Project = "projectaa6ff846",
            };
            AddressAggregatedList expectedResponse = new AddressAggregatedList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items =
                {
                    {
                        "key8a0b6e3c",
                        new AddressesScopedList()
                    },
                },
                SelfLink = "self_link7e87f12d",
                Unreachables =
                {
                    "unreachables3ca950ee",
                },
            };
            mockGrpcClient.Setup(x => x.AggregatedListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<AddressAggregatedList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressAggregatedList responseCallSettings = await client.AggregatedListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            AddressAggregatedList responseCancellationToken = await client.AggregatedListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            DeleteAddressRequest request = new DeleteAddressRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                Address = "address04984d88",
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            DeleteAddressRequest request = new DeleteAddressRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                Address = "address04984d88",
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            DeleteAddressRequest request = new DeleteAddressRequest
            {
                Region = "regionedb20d96",
                Address = "address04984d88",
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Region, request.Address);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            DeleteAddressRequest request = new DeleteAddressRequest
            {
                Region = "regionedb20d96",
                Address = "address04984d88",
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Region, request.Address, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Region, request.Address, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            GetAddressRequest request = new GetAddressRequest
            {
                Region = "regionedb20d96",
                Address = "address04984d88",
                Project = "projectaa6ff846",
            };
            Address expectedResponse = new Address
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                IpVersion = Address.Types.IpVersion.UndefinedIpVersion,
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Purpose = Address.Types.Purpose.VpcPeering,
                Users = { "users2a5cc69b", },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = Address.Types.Status.Reserved,
                PrefixLength = -686118004,
                SelfLink = "self_link7e87f12d",
                Address_ = "address04984d88",
                Network = "networkd22ce091",
                NetworkTier = Address.Types.NetworkTier.Standard,
                AddressType = Address.Types.AddressType.Internal,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Address response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            GetAddressRequest request = new GetAddressRequest
            {
                Region = "regionedb20d96",
                Address = "address04984d88",
                Project = "projectaa6ff846",
            };
            Address expectedResponse = new Address
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                IpVersion = Address.Types.IpVersion.UndefinedIpVersion,
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Purpose = Address.Types.Purpose.VpcPeering,
                Users = { "users2a5cc69b", },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = Address.Types.Status.Reserved,
                PrefixLength = -686118004,
                SelfLink = "self_link7e87f12d",
                Address_ = "address04984d88",
                Network = "networkd22ce091",
                NetworkTier = Address.Types.NetworkTier.Standard,
                AddressType = Address.Types.AddressType.Internal,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Address>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Address responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Address responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            GetAddressRequest request = new GetAddressRequest
            {
                Region = "regionedb20d96",
                Address = "address04984d88",
                Project = "projectaa6ff846",
            };
            Address expectedResponse = new Address
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                IpVersion = Address.Types.IpVersion.UndefinedIpVersion,
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Purpose = Address.Types.Purpose.VpcPeering,
                Users = { "users2a5cc69b", },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = Address.Types.Status.Reserved,
                PrefixLength = -686118004,
                SelfLink = "self_link7e87f12d",
                Address_ = "address04984d88",
                Network = "networkd22ce091",
                NetworkTier = Address.Types.NetworkTier.Standard,
                AddressType = Address.Types.AddressType.Internal,
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Address response = client.Get(request.Project, request.Region, request.Address);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            GetAddressRequest request = new GetAddressRequest
            {
                Region = "regionedb20d96",
                Address = "address04984d88",
                Project = "projectaa6ff846",
            };
            Address expectedResponse = new Address
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                IpVersion = Address.Types.IpVersion.UndefinedIpVersion,
                CreationTimestamp = "creation_timestamp235e59a1",
                Subnetwork = "subnetworkf55bf572",
                Purpose = Address.Types.Purpose.VpcPeering,
                Users = { "users2a5cc69b", },
                Region = "regionedb20d96",
                Description = "description2cf9da67",
                Status = Address.Types.Status.Reserved,
                PrefixLength = -686118004,
                SelfLink = "self_link7e87f12d",
                Address_ = "address04984d88",
                Network = "networkd22ce091",
                NetworkTier = Address.Types.NetworkTier.Standard,
                AddressType = Address.Types.AddressType.Internal,
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Address>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Address responseCallSettings = await client.GetAsync(request.Project, request.Region, request.Address, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Address responseCancellationToken = await client.GetAsync(request.Project, request.Region, request.Address, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            InsertAddressRequest request = new InsertAddressRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                AddressResource = new Address(),
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            InsertAddressRequest request = new InsertAddressRequest
            {
                RequestId = "request_id362c8df6",
                Region = "regionedb20d96",
                AddressResource = new Address(),
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            InsertAddressRequest request = new InsertAddressRequest
            {
                Region = "regionedb20d96",
                AddressResource = new Address(),
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.Region, request.AddressResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            InsertAddressRequest request = new InsertAddressRequest
            {
                Region = "regionedb20d96",
                AddressResource = new Address(),
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
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.Region, request.AddressResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.Region, request.AddressResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            ListAddressesRequest request = new ListAddressesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            AddressList expectedResponse = new AddressList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Address(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            ListAddressesRequest request = new ListAddressesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                Region = "regionedb20d96",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            AddressList expectedResponse = new AddressList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Address(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<AddressList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            AddressList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            ListAddressesRequest request = new ListAddressesRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            AddressList expectedResponse = new AddressList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Address(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressList response = client.List(request.Project, request.Region);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<Addresses.AddressesClient> mockGrpcClient = new moq::Mock<Addresses.AddressesClient>(moq::MockBehavior.Strict);
            ListAddressesRequest request = new ListAddressesRequest
            {
                Region = "regionedb20d96",
                Project = "projectaa6ff846",
            };
            AddressList expectedResponse = new AddressList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Address(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<AddressList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            AddressesClient client = new AddressesClientImpl(mockGrpcClient.Object, null);
            AddressList responseCallSettings = await client.ListAsync(request.Project, request.Region, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            AddressList responseCancellationToken = await client.ListAsync(request.Project, request.Region, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
