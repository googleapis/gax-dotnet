/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using Xunit;
using Google.Cloud.Compute.V1;
using Grpc.Core;
using Xunit.Abstractions;

namespace ComputeDemo
{
    public sealed class ComputeAlphaMainIntegrationTest
    {
        private readonly ITestOutputHelper _output;
        private readonly string _project;
        private readonly string _region;
        private readonly AddressesClient _addrClient;
        private readonly RegionOperationsClient _ropsClient;

        const string CredentialsPath = @"C:\Users\virost\AppData\Roaming\gcloud\legacy_credentials\virost@google.com\adc.json";

        public ComputeAlphaMainIntegrationTest(ITestOutputHelper output)
        {
            _output = output;
            _project = "client-debugging";
            _region = "us-central1";
            
            _addrClient = new AddressesClientBuilder
            {
                CredentialsPath = CredentialsPath
            }.Build();

            _ropsClient = new RegionOperationsClientBuilder
            {
                CredentialsPath = CredentialsPath
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
