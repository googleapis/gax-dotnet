﻿/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using Grpc.Core;
using Xunit;
using Xunit.Abstractions;

namespace Google.Cloud.Compute.V1.AcceptanceTests
{
    /// <summary>
    /// Main integration test for the Compute Alpha
    /// </summary>s
    public sealed class MainIntegrationTest
    {
        private readonly ITestOutputHelper _output;
        private readonly string _project;
        private readonly string _region;
        private readonly AddressesClient _addrClient;
        private readonly RegionOperationsClient _ropsClient;

        private const string TestCredentialsEnvironmentVariable = "GOOGLE_APPLICATION_CREDENTIALS";
        private const string TestProjectEnvironmentVariable = "COMPUTE_TEST_PROJECT";
        private const string TestRegionEnvironmentVariable = "COMPUTE_TEST_REGION";

        public MainIntegrationTest(ITestOutputHelper output)
        {
            _output = output;
            
            // e.g. "client-debugging";
            _project =  Environment.GetEnvironmentVariable(TestProjectEnvironmentVariable);
            if (string.IsNullOrWhiteSpace(_project))
            {
                throw new ArgumentException($"Test project not set via the {TestProjectEnvironmentVariable} environment variable");
            }

            // e.g. "us-central1";
            _region =  Environment.GetEnvironmentVariable("COMPUTE_TEST_REGION");
            if (string.IsNullOrWhiteSpace(_region))
            {
                throw new ArgumentException($"Test region not set via the {TestRegionEnvironmentVariable} environment variable");
            }

            // e.g. "C:\Path\to\adc.json"
            var credentialsPath = Environment.GetEnvironmentVariable(TestCredentialsEnvironmentVariable);
            if (string.IsNullOrWhiteSpace(credentialsPath))
            {
                throw new ArgumentException($"Credentials are not set via the {TestCredentialsEnvironmentVariable} environment variable");
            }
            
            _addrClient = new AddressesClientBuilder
            {
                CredentialsPath = credentialsPath
            }.Build();

            _ropsClient = new RegionOperationsClientBuilder
            {
                CredentialsPath = credentialsPath
            }.Build();
        }

        [Fact]
        public void CreateDeleteIPIntegration()
        {
            AddressesClient addressesClient = _addrClient;
            var addrName = $"testaddr-csharp-{Guid.NewGuid()}";

            _output.WriteLine($"Retrieving address with the name: {addrName}");

            var exc = Assert.ThrowsAny<RpcException>(
                () => addressesClient.Get(_project, _region, addrName)
            );
            Assert.Equal(StatusCode.NotFound, exc.StatusCode);

            Address addressResource = new Address
            {
                Name = addrName,
                Region = _region,
                NetworkTier = Address.Types.NetworkTier.Premium
            };

            _output.WriteLine($"Creating address with the name: {addrName}");
            Operation insertOp = addressesClient.Insert(_project, _region, addressResource);
            _output.WriteLine($"Operation to create address: {insertOp.Name} status {insertOp.Status}; start time {insertOp.StartTime}");
            insertOp = PollForCompletion(insertOp, "create");
            _output.WriteLine($"Operation to create address completed: status {insertOp.Status}; start time {insertOp.StartTime}; end time {insertOp.EndTime}");

            _output.WriteLine($"Retrieving address with the name: {addrName}");
            Address readAddr = addressesClient.Get(_project, _region, addrName);
            Assert.NotNull(readAddr);
            Assert.Equal(readAddr.Name, addrName);

            _output.WriteLine($"Deleting address with the name: {addrName}");
            Operation deleteOp = addressesClient.Delete(_project, _region, addrName);
            _output.WriteLine($"Operation to delete address: {deleteOp.Name} status {deleteOp.Status}; start time {deleteOp.StartTime}");
            deleteOp = PollForCompletion(deleteOp, "delete");
            _output.WriteLine($"Operation to delete address completed: status {deleteOp.Status}; start time {deleteOp.StartTime}; end time {deleteOp.EndTime}");
        }

        private Operation PollForCompletion(Operation insertOp, string alias)
        {
            RegionOperationsClient regionOperationsClient = _ropsClient;

            var localOps = insertOp;

            TimeSpan timeOut = TimeSpan.FromMinutes(3);
            TimeSpan pollInterval = TimeSpan.FromSeconds(15);

            DateTime deadline = DateTime.UtcNow + timeOut;
            while (localOps.Status != Operation.Types.Status.Done)
            {
                GetRegionOperationRequest request = new GetRegionOperationRequest
                {
                    Operation = insertOp.Name,
                    Region = _region,
                    Project = _project,
                };
                _output.WriteLine($"Checking for {alias} operation status ...");
                localOps = regionOperationsClient.Get(request);

                if (localOps.Status == Operation.Types.Status.Done) 
                {
                    break;
                }
                if(DateTime.UtcNow > deadline)
                {
                    throw new InvalidOperationException(
                        $"Timeout hit while polling for the status of the {alias} operation\n{localOps}");
                }
                _output.WriteLine($"Status: {localOps.Status}. Sleeping for the {pollInterval.TotalSeconds}s");
                Thread.Sleep(pollInterval);
            }

            return localOps;
        }
    }
}
