/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static Google.Api.Gax.Grpc.IntegrationTests.ForwardingTargetTestService;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    /// <summary>
    /// Test fixture for a simple gRPC service hosted on a local port. This can be manually constructed,
    /// or used as a dependency for a test collection.
    /// </summary>
    [CollectionDefinition(nameof(ForwardingTestServiceFixture))]
    public class ForwardingTestServiceFixture : IDisposable, ICollectionFixture<ForwardingTestServiceFixture>
    {
        private readonly Server _server;

        public int Port => _server.Ports.First().BoundPort;
        public string Endpoint => $"localhost:{Port}";

        public ForwardingTestServiceFixture()
        {
            _server = new Server
            {
                Services = { BindService(new ForwardingTargetTestServiceImpl()) },
                Ports = { new ServerPort("localhost", 0, ServerCredentials.Insecure) }
            };
            _server.Start();
        }

        public void Dispose()
        {
            Task.Run(() => _server.ShutdownAsync()).Wait();
        }

        private class ForwardingTargetTestServiceImpl : ForwardingTargetTestServiceBase
        {
            public override Task<ForwardingTargetMethod1Response> Method1(ForwardingTargetMethod1Request request, ServerCallContext context) =>
                request.TargetName.EndsWith("error")
                ? Task.FromException<ForwardingTargetMethod1Response>(new RpcException(new Status(StatusCode.Internal, "Bang")))
                : Task.FromResult(new ForwardingTargetMethod1Response { TargetResult = $"target:{request.TargetName}" });

            public override Task<ForwardingTargetMethod2Response> Method2(ForwardingTargetMethod2Request request, ServerCallContext context) =>
                Task.FromResult(new ForwardingTargetMethod2Response { Jkl = ByteString.CopyFromUtf8("some jkl value") });
        }
    }
}
