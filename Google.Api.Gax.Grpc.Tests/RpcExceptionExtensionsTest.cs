/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Rpc;
using Grpc.Core;
using System;
using Xunit;

using Status = Google.Rpc.Status;
using GrpcStatus = Grpc.Core.Status;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
using static Google.Rpc.Help.Types;

namespace Google.Api.Gax.Grpc.Tests
{
    public class RpcExceptionExtensionsTest
    {
        private static readonly GrpcStatus s_status = new GrpcStatus(StatusCode.InvalidArgument, "Bad request");

        [Fact]
        public void NullArgument_AllMethodsThrow()
        {
            RpcException ex = null;
            Assert.Throws<ArgumentNullException>(() => ex.GetRpcStatus());
            Assert.Throws<ArgumentNullException>(() => ex.GetBadRequest());
            Assert.Throws<ArgumentNullException>(() => ex.GetErrorInfo());
            Assert.Throws<ArgumentNullException>(() => ex.GetHelp());
            Assert.Throws<ArgumentNullException>(() => ex.GetLocalizedMessage());
            Assert.Throws<ArgumentNullException>(() => ex.GetStatusDetail<BadRequest>());
        }

        [Fact]
        public void NoTrailers_AllMethodsReturnNull()
        {
            RpcException ex = new RpcException(s_status);
            AssertAllMethodsReturnNull(ex);
        }

        [Fact]
        public void IrrelevantTrailer_AllMethodsReturnNull()
        {
            var metadata = new Metadata();
            metadata.Add("key", "value");
            RpcException ex = new RpcException(s_status, metadata);
            AssertAllMethodsReturnNull(ex);
        }

        [Fact]
        public void InvalidProtobufStatusTrailer_AllMethodsReturnNull()
        {
            var metadata = new Metadata();
            metadata.Add(RpcExceptionExtensions.StatusDetailsTrailerName, new byte[] { 1, 2, 3, 4 });
            RpcException ex = new RpcException(s_status, metadata);
            AssertAllMethodsReturnNull(ex);
        }

        [Fact]
        public void ValidTrailer_GetRpcStatus()
        {
            var status = new Status
            {
                Code = 123,
                Message = "This is a message",
            };

            var metadata = new Metadata();
            metadata.Add(RpcExceptionExtensions.StatusDetailsTrailerName, status.ToByteArray());
            RpcException ex = new RpcException(s_status, metadata);
            Assert.Equal(status, ex.GetRpcStatus());
            // We don't have any details
            Assert.Null(ex.GetBadRequest());
            Assert.Null(ex.GetErrorInfo());
            Assert.Null(ex.GetHelp());
            Assert.Null(ex.GetLocalizedMessage());
            Assert.Null(ex.GetStatusDetail<DebugInfo>());
        }

        [Fact]
        public void ValidTrailer_ArbitraryMessages()
        {
            var debugInfo = new DebugInfo
            {
                Detail = "This is some debugging information"
            };
            var requestInfo = new RequestInfo
            {
                RequestId = "request-id"
            };
            var badRequest = new BadRequest
            {
                FieldViolations = { new BadRequest.Types.FieldViolation { Description = "Negative", Field = "speed" } }
            };
            var help = new Help
            {
                Links = { new Link { Description = "Google it", Url = "https://google.com" } }
            };
            var localizedMessage = new LocalizedMessage { Locale = "en-US", Message = "Oops" };
            var status = new Status
            {
                Code = 123,
                Message = "This is a message",
                Details =
                {
                    Any.Pack(debugInfo),
                    Any.Pack(requestInfo),
                    Any.Pack(badRequest),
                    Any.Pack(help),
                    Any.Pack(localizedMessage)
                }
            };

            var metadata = new Metadata();
            metadata.Add("key-1", "value1");
            metadata.Add(RpcExceptionExtensions.StatusDetailsTrailerName, status.ToByteArray());
            metadata.Add("other-info-bin", new byte[] { 1, 2, 3 });
            metadata.Add("key-2", "value2");
            RpcException ex = new RpcException(s_status, metadata);

            Assert.Equal(badRequest, ex.GetBadRequest());
            Assert.Null(ex.GetErrorInfo());
            Assert.Equal(debugInfo, ex.GetStatusDetail<DebugInfo>());
            Assert.Equal(requestInfo, ex.GetStatusDetail<RequestInfo>());
            Assert.Equal(badRequest, ex.GetStatusDetail<BadRequest>());
            Assert.Equal(help, ex.GetStatusDetail<Help>());
            Assert.Equal(localizedMessage, ex.GetStatusDetail<LocalizedMessage>());
        }

        [Fact]
        public void GetErrorInfo_Present()
        {
            var errorInfo = new ErrorInfo
            {
                Domain = "googleapis.com",
                Reason = "broken"
            };
            var status = new Status
            {
                Code = 123,
                Message = "This is a message",
                Details =
                {
                    Any.Pack(errorInfo),
                }
            };
            var metadata = new Metadata();
            metadata.Add(RpcExceptionExtensions.StatusDetailsTrailerName, status.ToByteArray());

            RpcException ex = new RpcException(s_status, metadata);
            Assert.Equal(errorInfo, ex.GetErrorInfo());
        }

        [Fact]
        public void GetStatusDetail_BadlyPackedMessage()
        {
            var debugInfo = new DebugInfo { Detail = "Debug information" };
            var any = Any.Pack(debugInfo);
            any.Value = ByteString.CopyFromUtf8("This isn't valid data!");

            var status = new Status { Details = { any } };
            var metadata = new Metadata();
            metadata.Add(RpcExceptionExtensions.StatusDetailsTrailerName, status.ToByteArray());
            RpcException ex = new RpcException(s_status, metadata);

            Assert.Equal(status, ex.GetRpcStatus());
            Assert.Null(ex.GetStatusDetail<DebugInfo>());
        }

        private void AssertAllMethodsReturnNull(RpcException ex)
        {
            Assert.Null(ex.GetRpcStatus());
            Assert.Null(ex.GetBadRequest());
            Assert.Null(ex.GetErrorInfo());
            Assert.Null(ex.GetHelp());
            Assert.Null(ex.GetLocalizedMessage());
            Assert.Null(ex.GetStatusDetail<DebugInfo>());
        }
    }
}
