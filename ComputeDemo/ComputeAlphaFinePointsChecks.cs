using System;
using System.Threading;
using gaxgrpc = Google.Api.Gax.Grpc;
using grpccore = Grpc.Core;
using moq = Moq;
using xunit = Xunit;
using Google.Cloud.Compute.V1;
using Xunit.Abstractions;


namespace ComputeDemo
{
    public sealed class ComputeAlphaFinePointsChecks
    {
        private readonly ITestOutputHelper _output;
        private readonly string _project;
        private readonly string _region;
        private readonly ZonesClient _zonesClient;

        const string CredentialsPath = @"C:\Users\virost\AppData\Roaming\gcloud\legacy_credentials\virost@google.com\adc.json";

        public ComputeAlphaFinePointsChecks(ITestOutputHelper output)
        {
            _output = output;
            _project = "client-debugging";
            _region = "us-central1";
            
            _zonesClient = new ZonesClientBuilder { CredentialsPath = CredentialsPath }.Build();
        }

        [xunit::Fact]
        public void TestZonesListMaxResults()
        {
            var allZones = _zonesClient.List(_project);
            xunit.Assert.True(allZones.Items.Count > 2);
            _output.WriteLine($"Total number of zones: {allZones.Items.Count}");

            var twoZones = _zonesClient.List(new ListZonesRequest { Project = _project, MaxResults = 2});
            xunit.Assert.Equal(2, twoZones.Items.Count);
        }
    }
}
