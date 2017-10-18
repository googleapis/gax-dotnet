﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class PlatformTest
    {
        private string LoadResourceString(string name)
        {
            var assembly = typeof(PlatformTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"Google.Api.Gax.Tests.Resources.{name}");
            var ms = new MemoryStream();
            stream.CopyTo(ms);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        [Fact]
        public void Gae_NoData()
        {
            Assert.Throws<ArgumentNullException>(() => new GaePlatformDetails(null, "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GaePlatformDetails("", null, "", ""));
            Assert.Throws<ArgumentNullException>(() => new GaePlatformDetails("", "", null, ""));
            Assert.Throws<ArgumentNullException>(() => new GaePlatformDetails("", "", "", null));
        }

        [Fact]
        public void Gce_NoData()
        {
            Assert.Throws<ArgumentNullException>(() => GcePlatformDetails.TryLoad(null));
            Assert.Null(GcePlatformDetails.TryLoad(""));
            Assert.Throws<ArgumentNullException>(() => new GcePlatformDetails(null, "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GcePlatformDetails("", null, "", ""));
            Assert.Throws<ArgumentNullException>(() => new GcePlatformDetails("", "", null, ""));
            Assert.Throws<ArgumentNullException>(() => new GcePlatformDetails("", "", "", null));
        }

        [Fact]
        public void Gke_NoData()
        {
            Assert.Throws<ArgumentNullException>(() => GkePlatformDetails.TryLoad(null, new GkePlatformDetails.KubernetesData()));
            Assert.Throws<ArgumentNullException>(() => GkePlatformDetails.TryLoad("", null));
            Assert.Null(GkePlatformDetails.TryLoad("", new GkePlatformDetails.KubernetesData()));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails(null, "", "", "", "", "", "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", null, "", "", "", "", "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", null, "", "", "", "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", null, "", "", "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", "", null, "", "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", "", "", null, "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", "", "", "", null, "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", "", "", "", "", null, "", ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", "", "", "", "", "", null, ""));
            Assert.Throws<ArgumentNullException>(() => new GkePlatformDetails("", "", "", "", "", "", "", "", "", null));
        }

        [Fact]
        public void Gke_PartialData()
        {
            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
                PodName = "testpodname"
            };
            var gke = GkePlatformDetails.TryLoad(LoadResourceString("Metadata.json"), kubernetesData);
            Assert.NotNull(gke);
            Assert.Equal("chrisbacon-testing", gke.ProjectId);
            Assert.Equal("platformintegrationtest", gke.ClusterName);
            Assert.Equal("europe-west2-c", gke.Location);
            Assert.Equal("testpodname", gke.HostName);
            Assert.Equal("2917200381659545756", gke.InstanceId);
            Assert.Equal("projects/233772281425/zones/europe-west2-c", gke.Zone);
            Assert.Equal("", gke.NamespaceId);
            Assert.Equal("", gke.PodId);
            Assert.Equal("", gke.ContainerName);
        }

        [Theory, CombinatorialData]
        public void Gke_WithData(bool withPodName)
        {
            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
                PodName = withPodName ? "platformintegrationtest-1135066300-rpzm4" : null,
                NamespaceJson = LoadResourceString("Namespace.json"),
                PodJson = LoadResourceString("Pod.json"),
                MountInfo = new[]
                {
                    "1591 1575 8:1 /var/lib/kubelet/pods/de3bf4eb-b036-11e7-8e33-42010a9a0fdd/containers/platformintegrationtest/7672e8ec " +
                    "/dev/termination-log rw,relatime - ext4 /dev/sda1 rw,commit=30,data=ordered"
                }
            };
            var gke = GkePlatformDetails.TryLoad(LoadResourceString("Metadata.json"), kubernetesData);
            Assert.NotNull(gke);
            Assert.Equal("chrisbacon-testing", gke.ProjectId);
            Assert.Equal("platformintegrationtest", gke.ClusterName);
            Assert.Equal("europe-west2-c", gke.Location);
            Assert.Equal("platformintegrationtest-1135066300-rpzm4", gke.HostName);
            Assert.Equal("2917200381659545756", gke.InstanceId);
            Assert.Equal("projects/233772281425/zones/europe-west2-c", gke.Zone);
            Assert.Equal("9f1c8731-ae9c-11e7-90fc-42010a9a0fdd", gke.NamespaceId);
            Assert.Equal("de3bf4eb-b036-11e7-8e33-42010a9a0fdd", gke.PodId);
            Assert.Equal("platformintegrationtest", gke.ContainerName);
        }
    }
}
