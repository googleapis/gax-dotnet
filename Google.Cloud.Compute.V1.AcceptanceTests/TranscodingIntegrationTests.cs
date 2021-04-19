/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;
using Google.Cloud.Compute.V1;
using Xunit.Abstractions;


namespace ComputeDemo
{
    /// <summary>
    /// Integration tests focused on the GRPC Transcoding
    /// </summary>
    public sealed class TranscodingIntegrationTests
    {
        private readonly ITestOutputHelper _output;
        private readonly string _project;
        private readonly ZonesClient _zonesClient;

        private const string TestCredentialsEnvironmentVariable = "GOOGLE_APPLICATION_CREDENTIALS";
        private const string TestProjectEnvironmentVariable = "COMPUTE_TEST_PROJECT";
        
        public TranscodingIntegrationTests(ITestOutputHelper output)
        {
            _output = output;
            // e.g. "client-debugging";
            _project =  Environment.GetEnvironmentVariable(TestProjectEnvironmentVariable);
            if (string.IsNullOrWhiteSpace(_project))
            {
                throw new ArgumentException($"Test project not set via the {TestProjectEnvironmentVariable} environment variable");
            }

            // e.g. "C:\Path\to\adc.json"
            var credentialsPath = Environment.GetEnvironmentVariable(TestCredentialsEnvironmentVariable);
            if (string.IsNullOrWhiteSpace(credentialsPath))
            {
                throw new ArgumentException($"Credentials are not set via the {TestCredentialsEnvironmentVariable} environment variable");
            }
            
            _zonesClient = new ZonesClientBuilder { CredentialsPath = credentialsPath }.Build();
        }

        [Fact]
        public void TestZonesListMaxResults()
        {
            var allZones = _zonesClient.List(_project);
            _output.WriteLine($"Total number of zones: {allZones.Items.Count}");
            Assert.True(allZones.Items.Count > 2);

            var twoZones = _zonesClient.List(new ListZonesRequest { Project = _project, MaxResults = 2});
            Assert.Equal(2, twoZones.Items.Count);
        }
    }
}
