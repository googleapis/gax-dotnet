/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.WellKnownTypes;
using Google.Rpc;
using System.Net;
using System.Net.Http;
using Xunit;
using gc = Grpc.Core;

namespace Google.Api.Gax.Grpc.Rest.Tests
{
    public class ReadHttpResponseMessageTest
    {
        private static readonly Status s_sampleStatus = new Status
        {
            Code = (int) gc::StatusCode.AlreadyExists,
            Message = "Some message",
            Details = { Any.Pack(new ErrorInfo { Domain = "googleapis.com", Metadata = { { "x", "y" } }, Reason = "It failed" }) }
        };

        private static readonly string s_sampleJson = @"
{
  'error': {
    'message': 'Some message',
    'status': 'ALREADY_EXISTS',
    'details': [{
      '@type': 'type.googleapis.com/google.rpc.ErrorInfo',
      'domain': 'googleapis.com',
      'reason': 'It failed',
      'metadata': {
        'x': 'y'
      }
    }]
  }
}".Replace('\'', '"');

        [Fact]
        public void GetTrailers_SuccessResponse()
        {
            var json = new Error
            {
                Error_ = new Error.Types.Status { Message = "Some message", Code = 100 }
            }.ToString();
            var response = CreateResponse(HttpStatusCode.OK, json);
            // No trailers, even though it's valid as an error, because the response was a 200.
            Assert.Empty(response.GetTrailers());
        }

        [Theory]
        [InlineData("")]
        [InlineData("<html>Not found</html>")]
        [InlineData("This is just plain text")]
        [InlineData("{}")] // Valid wrapper, but no error property.
        public void CreateRpcStatus_NonErrorStatusResponse(string text)
        {
            var expectedStatus = new Status
            {
                Code = (int) gc::StatusCode.Internal,
                Message = text
            };
            var actualStatus = ReadHttpResponseMessage.CreateRpcStatus(HttpStatusCode.InternalServerError, text);
            Assert.Equal(expectedStatus, actualStatus);
        }

        [Fact]
        public void CreateRpcStatus_ValidStatus()
        {
            // Note: the NotFound is ignored here, because the Code in the status is used instead.
            var actualStatus = ReadHttpResponseMessage.CreateRpcStatus(HttpStatusCode.NotFound, s_sampleJson);
            Assert.Equal(s_sampleStatus, actualStatus);
        }

        [Fact]
        public void CreateRpcStatus_NoGrpcStatusCode()
        {
            // This is what some Compute responses look like. There's no gRPC status code,
            // and no details - but the deprecated "errors" field is populated.
            string json = @"
{
  'error': {
    'code': 404,
    'message': 'The resource xyz was not found',
    'errors': [
      {
        'message': 'The resource xyz was not found',
        'domain': 'global',
        'reason': 'notFound'
      }
    ]
  }
}".Replace('\'', '"');
            var actualStatus = ReadHttpResponseMessage.CreateRpcStatus(HttpStatusCode.NotFound, json);
            var expectedStatus = new Status
            {
                Code = (int) gc::StatusCode.NotFound,
                Message = "The resource xyz was not found"
            };
            Assert.Equal(expectedStatus, actualStatus);
        }

        [Fact]
        public void CreateRpcStatus_UnknownAny()
        {
            string json = @"
{
  'error': {
    'message': 'Some message',
    'status': 'ALREADY_EXISTS',
    'details': [{
      '@type': 'type.googleapis.com/google.rpc.ErrorInfo',
      'domain': 'googleapis.com',
      'reason': 'It failed',
      'metadata': {
        'x': 'y'
      }
    }, {
      '@type': 'type.googleapis.com/google.rpc.SnazzyNewMessage',
      'step3': 'profit'
    }, {
      '@type': 'type.googleapis.com/google.rpc.LocalizedMessage',
      'locale': 'en-US',
      'message': 'It failed badly'
    }]
  }
}".Replace('\'', '"');
            var actualStatus = ReadHttpResponseMessage.CreateRpcStatus(HttpStatusCode.PreconditionFailed, json);
            var expectedStatus = new Status
            {
                Code = (int) gc::StatusCode.AlreadyExists,
                Message = "Some message",
                Details =
                {
                    Any.Pack(new ErrorInfo { Domain = "googleapis.com", Reason = "It failed", Metadata = { { "x", "y" } } }),
                    // The middle details are omitted because we can't parse them.
                    Any.Pack(new LocalizedMessage { Locale = "en-US", Message = "It failed badly" })
                }
            };
            Assert.Equal(expectedStatus, actualStatus);
        }

        [Fact]
        public void GetTrailers_WithStatus()
        {
            var response = CreateResponse(HttpStatusCode.NotFound, s_sampleJson);
            var trailer = Assert.Single(response.GetTrailers());
            Assert.Equal(RpcExceptionExtensions.StatusDetailsTrailerName, trailer.Key);
            var actualStatus = Status.Parser.ParseFrom(trailer.ValueBytes);
            Assert.Equal(s_sampleStatus, actualStatus);
        }

        private static ReadHttpResponseMessage CreateResponse(HttpStatusCode statusCode, string content) =>
            new ReadHttpResponseMessage(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content),
            }, content);
    }
}
