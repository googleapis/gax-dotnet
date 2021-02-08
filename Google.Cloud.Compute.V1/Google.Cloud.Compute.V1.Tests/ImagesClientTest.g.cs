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
    public sealed class GeneratedImagesClientTest
    {
        [xunit::FactAttribute]
        public void DeleteRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeleteImageRequest request = new DeleteImageRequest
            {
                RequestId = "request_id362c8df6",
                Image = "image225a8078",
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeleteImageRequest request = new DeleteImageRequest
            {
                RequestId = "request_id362c8df6",
                Image = "image225a8078",
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Delete()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeleteImageRequest request = new DeleteImageRequest
            {
                Image = "image225a8078",
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Delete(request.Project, request.Image);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeleteAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeleteImageRequest request = new DeleteImageRequest
            {
                Image = "image225a8078",
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeleteAsync(request.Project, request.Image, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeleteAsync(request.Project, request.Image, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void DeprecateRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeprecateImageRequest request = new DeprecateImageRequest
            {
                RequestId = "request_id362c8df6",
                DeprecationStatusResource = new DeprecationStatus(),
                Image = "image225a8078",
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
            mockGrpcClient.Setup(x => x.Deprecate(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Deprecate(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecateRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeprecateImageRequest request = new DeprecateImageRequest
            {
                RequestId = "request_id362c8df6",
                DeprecationStatusResource = new DeprecationStatus(),
                Image = "image225a8078",
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
            mockGrpcClient.Setup(x => x.DeprecateAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeprecateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeprecateAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Deprecate()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeprecateImageRequest request = new DeprecateImageRequest
            {
                DeprecationStatusResource = new DeprecationStatus(),
                Image = "image225a8078",
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
            mockGrpcClient.Setup(x => x.Deprecate(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Deprecate(request.Project, request.Image, request.DeprecationStatusResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task DeprecateAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            DeprecateImageRequest request = new DeprecateImageRequest
            {
                DeprecationStatusResource = new DeprecationStatus(),
                Image = "image225a8078",
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
            mockGrpcClient.Setup(x => x.DeprecateAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.DeprecateAsync(request.Project, request.Image, request.DeprecationStatusResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.DeprecateAsync(request.Project, request.Image, request.DeprecationStatusResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetImageRequest request = new GetImageRequest
            {
                Image = "image225a8078",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image response = client.Get(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetImageRequest request = new GetImageRequest
            {
                Image = "image225a8078",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Image>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image responseCallSettings = await client.GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Image responseCancellationToken = await client.GetAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Get()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetImageRequest request = new GetImageRequest
            {
                Image = "image225a8078",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.Get(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image response = client.Get(request.Project, request.Image);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetImageRequest request = new GetImageRequest
            {
                Image = "image225a8078",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.GetAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Image>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image responseCallSettings = await client.GetAsync(request.Project, request.Image, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Image responseCancellationToken = await client.GetAsync(request.Project, request.Image, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetFromFamilyRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetFromFamilyImageRequest request = new GetFromFamilyImageRequest
            {
                Family = "family0bda3f0d",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.GetFromFamily(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image response = client.GetFromFamily(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetFromFamilyRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetFromFamilyImageRequest request = new GetFromFamilyImageRequest
            {
                Family = "family0bda3f0d",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.GetFromFamilyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Image>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image responseCallSettings = await client.GetFromFamilyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Image responseCancellationToken = await client.GetFromFamilyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetFromFamily()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetFromFamilyImageRequest request = new GetFromFamilyImageRequest
            {
                Family = "family0bda3f0d",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.GetFromFamily(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image response = client.GetFromFamily(request.Project, request.Family);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetFromFamilyAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetFromFamilyImageRequest request = new GetFromFamilyImageRequest
            {
                Family = "family0bda3f0d",
                Project = "projectaa6ff846",
            };
            Image expectedResponse = new Image
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Name = "name1c9368b0",
                CreationTimestamp = "creation_timestamp235e59a1",
                SourceSnapshotEncryptionKey = new CustomerEncryptionKey(),
                LicenseCodes =
                {
                    "license_codesdd63b74e",
                },
                DiskSizeGb = "disk_size_gbf071de02",
                SourceImage = "source_image5e9c0c38",
                SourceImageId = "source_image_id954b5e55",
                StorageLocations =
                {
                    "storage_locationse772402d",
                },
                Family = "family0bda3f0d",
                Licenses =
                {
                    "licensesd1cc2f9d",
                },
                GuestOsFeatures =
                {
                    new GuestOsFeature(),
                },
                SourceSnapshotId = "source_snapshot_id008ab5dd",
                ImageEncryptionKey = new CustomerEncryptionKey(),
                ArchiveSizeBytes = "archive_size_bytes3bae3605",
                SourceImageEncryptionKey = new CustomerEncryptionKey(),
                SourceSnapshot = "source_snapshot1fcf3da1",
                Description = "description2cf9da67",
                LabelFingerprint = "label_fingerprint06ccff3a",
                Status = Image.Types.Status.Ready,
                SourceDisk = "source_disk0eec086f",
                SourceType = Image.Types.SourceType.UndefinedSourceType,
                SourceDiskId = "source_disk_id020f9fb8",
                SelfLink = "self_link7e87f12d",
                ShieldedInstanceInitialState = new InitialStateConfig(),
                Labels =
                {
                    {
                        "key8a0b6e3c",
                        "value60c16320"
                    },
                },
                RawDisk = new RawDisk(),
                Deprecated = new DeprecationStatus(),
                SourceDiskEncryptionKey = new CustomerEncryptionKey(),
            };
            mockGrpcClient.Setup(x => x.GetFromFamilyAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Image>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Image responseCallSettings = await client.GetFromFamilyAsync(request.Project, request.Family, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Image responseCancellationToken = await client.GetFromFamilyAsync(request.Project, request.Family, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicyRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetIamPolicyImageRequest request = new GetIamPolicyImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetIamPolicyImageRequest request = new GetIamPolicyImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void GetIamPolicy()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetIamPolicyImageRequest request = new GetIamPolicyImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.GetIamPolicy(request.Project, request.Resource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task GetIamPolicyAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            GetIamPolicyImageRequest request = new GetIamPolicyImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.GetIamPolicyAsync(request.Project, request.Resource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.GetIamPolicyAsync(request.Project, request.Resource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void InsertRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            InsertImageRequest request = new InsertImageRequest
            {
                RequestId = "request_id362c8df6",
                ImageResource = new Image(),
                ForceCreate = false,
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            InsertImageRequest request = new InsertImageRequest
            {
                RequestId = "request_id362c8df6",
                ImageResource = new Image(),
                ForceCreate = false,
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Insert()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            InsertImageRequest request = new InsertImageRequest
            {
                ImageResource = new Image(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Insert(request.Project, request.ImageResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task InsertAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            InsertImageRequest request = new InsertImageRequest
            {
                ImageResource = new Image(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.InsertAsync(request.Project, request.ImageResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.InsertAsync(request.Project, request.ImageResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void ListRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            ListImagesRequest request = new ListImagesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ImageList expectedResponse = new ImageList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Image(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            ImageList response = client.List(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            ListImagesRequest request = new ListImagesRequest
            {
                PageToken = "page_tokenf09e5538",
                MaxResults = 2806814450U,
                Filter = "filtere47ac9b2",
                OrderBy = "order_byb4d33ada",
                Project = "projectaa6ff846",
                ReturnPartialSuccess = false,
            };
            ImageList expectedResponse = new ImageList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Image(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ImageList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            ImageList responseCallSettings = await client.ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ImageList responseCancellationToken = await client.ListAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void List()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            ListImagesRequest request = new ListImagesRequest
            {
                Project = "projectaa6ff846",
            };
            ImageList expectedResponse = new ImageList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Image(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.List(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            ImageList response = client.List(request.Project);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task ListAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            ListImagesRequest request = new ListImagesRequest
            {
                Project = "projectaa6ff846",
            };
            ImageList expectedResponse = new ImageList
            {
                Id = "id74b70bb8",
                Kind = "kindf7aa39d9",
                Warning = new Warning(),
                NextPageToken = "next_page_tokendbee0940",
                Items = { new Image(), },
                SelfLink = "self_link7e87f12d",
            };
            mockGrpcClient.Setup(x => x.ListAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<ImageList>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            ImageList responseCallSettings = await client.ListAsync(request.Project, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            ImageList responseCancellationToken = await client.ListAsync(request.Project, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void PatchRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            PatchImageRequest request = new PatchImageRequest
            {
                RequestId = "request_id362c8df6",
                Image = "image225a8078",
                ImageResource = new Image(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Patch(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PatchRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            PatchImageRequest request = new PatchImageRequest
            {
                RequestId = "request_id362c8df6",
                Image = "image225a8078",
                ImageResource = new Image(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.PatchAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void Patch()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            PatchImageRequest request = new PatchImageRequest
            {
                Image = "image225a8078",
                ImageResource = new Image(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.Patch(request.Project, request.Image, request.ImageResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task PatchAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            PatchImageRequest request = new PatchImageRequest
            {
                Image = "image225a8078",
                ImageResource = new Image(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.PatchAsync(request.Project, request.Image, request.ImageResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.PatchAsync(request.Project, request.Image, request.ImageResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicyRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetIamPolicyImageRequest request = new SetIamPolicyImageRequest
            {
                GlobalSetPolicyRequestResource = new GlobalSetPolicyRequest(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetIamPolicyImageRequest request = new SetIamPolicyImageRequest
            {
                GlobalSetPolicyRequestResource = new GlobalSetPolicyRequest(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetIamPolicy()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetIamPolicyImageRequest request = new SetIamPolicyImageRequest
            {
                GlobalSetPolicyRequestResource = new GlobalSetPolicyRequest(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy response = client.SetIamPolicy(request.Project, request.Resource, request.GlobalSetPolicyRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetIamPolicyAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetIamPolicyImageRequest request = new SetIamPolicyImageRequest
            {
                GlobalSetPolicyRequestResource = new GlobalSetPolicyRequest(),
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Policy responseCallSettings = await client.SetIamPolicyAsync(request.Project, request.Resource, request.GlobalSetPolicyRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Policy responseCancellationToken = await client.SetIamPolicyAsync(request.Project, request.Resource, request.GlobalSetPolicyRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetLabelsRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetLabelsImageRequest request = new SetLabelsImageRequest
            {
                GlobalSetLabelsRequestResource = new GlobalSetLabelsRequest(),
                Resource = "resource164eab96",
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
            mockGrpcClient.Setup(x => x.SetLabels(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetLabels(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetLabelsRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetLabelsImageRequest request = new SetLabelsImageRequest
            {
                GlobalSetLabelsRequestResource = new GlobalSetLabelsRequest(),
                Resource = "resource164eab96",
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
            mockGrpcClient.Setup(x => x.SetLabelsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetLabelsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetLabelsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void SetLabels()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetLabelsImageRequest request = new SetLabelsImageRequest
            {
                GlobalSetLabelsRequestResource = new GlobalSetLabelsRequest(),
                Resource = "resource164eab96",
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
            mockGrpcClient.Setup(x => x.SetLabels(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(expectedResponse);
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation response = client.SetLabels(request.Project, request.Resource, request.GlobalSetLabelsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task SetLabelsAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            SetLabelsImageRequest request = new SetLabelsImageRequest
            {
                GlobalSetLabelsRequestResource = new GlobalSetLabelsRequest(),
                Resource = "resource164eab96",
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
            mockGrpcClient.Setup(x => x.SetLabelsAsync(request, moq::It.IsAny<grpccore::CallOptions>())).Returns(new grpccore::AsyncUnaryCall<Operation>(stt::Task.FromResult(expectedResponse), null, null, null, null));
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            Operation responseCallSettings = await client.SetLabelsAsync(request.Project, request.Resource, request.GlobalSetLabelsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            Operation responseCancellationToken = await client.SetLabelsAsync(request.Project, request.Resource, request.GlobalSetLabelsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissionsRequestObject()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsImageRequest request = new TestIamPermissionsImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsRequestObjectAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsImageRequest request = new TestIamPermissionsImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public void TestIamPermissions()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsImageRequest request = new TestIamPermissionsImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse response = client.TestIamPermissions(request.Project, request.Resource, request.TestPermissionsRequestResource);
            xunit::Assert.Same(expectedResponse, response);
            mockGrpcClient.VerifyAll();
        }

        [xunit::FactAttribute]
        public async stt::Task TestIamPermissionsAsync()
        {
            moq::Mock<Images.ImagesClient> mockGrpcClient = new moq::Mock<Images.ImagesClient>(moq::MockBehavior.Strict);
            TestIamPermissionsImageRequest request = new TestIamPermissionsImageRequest
            {
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
            ImagesClient client = new ImagesClientImpl(mockGrpcClient.Object, null);
            TestPermissionsResponse responseCallSettings = await client.TestIamPermissionsAsync(request.Project, request.Resource, request.TestPermissionsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(st::CancellationToken.None));
            xunit::Assert.Same(expectedResponse, responseCallSettings);
            TestPermissionsResponse responseCancellationToken = await client.TestIamPermissionsAsync(request.Project, request.Resource, request.TestPermissionsRequestResource, st::CancellationToken.None);
            xunit::Assert.Same(expectedResponse, responseCancellationToken);
            mockGrpcClient.VerifyAll();
        }
    }
}
