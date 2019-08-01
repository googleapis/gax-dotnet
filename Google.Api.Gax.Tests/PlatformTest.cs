/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
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
        public void Gce_ValidZoneFormatLocation()
        {
            var metadataJson = "{'project':{'projectId':'FakeProjectId'},'instance':{'id':'123','zone':'projects/123456/zones/FakeLocation'}}";
            var gce = new GcePlatformDetails(metadataJson, "FakeProjectId", "123", "projects/123456/zones/FakeLocation");
            Assert.Equal("FakeLocation", gce.Location);
        }

        [Fact]
        public void Gce_InvalidZoneFormatLocation()
        {
            var metadataJson = "{'project':{'projectId':'FakeProjectId'},'instance':{'id':'123','zone':'FakeLocation'}}";
            var gce = new GcePlatformDetails(metadataJson, "FakeProjectId", "123", "FakeLocation");
            Assert.Throws<InvalidOperationException>(() => gce.Location);
        }

        [Fact]
        public void CloudRun_Valid()
        {
            var details = new CloudRunPlatformDetails("json", "project", "us-central1-1", "service", "revision", "configuration");
            Assert.Equal("json", details.MetadataJson);
            Assert.Equal("project", details.ProjectId);
            Assert.Equal("us-central1-1", details.Zone);
            Assert.Equal("us-central1", details.Region);
            Assert.Equal("service", details.ServiceName);
            Assert.Equal("revision", details.RevisionName);
            Assert.Equal("configuration", details.ConfigurationName);
        }

        [Fact]
        public void CloudRun_Invalid()
        {
            Assert.Throws<ArgumentNullException>(() => new CloudRunPlatformDetails(null, "", "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new CloudRunPlatformDetails("", null, "", "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new CloudRunPlatformDetails("", "", null, "", "", ""));
            Assert.Throws<ArgumentNullException>(() => new CloudRunPlatformDetails("", "", "", null, "", ""));
            Assert.Throws<ArgumentNullException>(() => new CloudRunPlatformDetails("", "", "", "", null, ""));
            Assert.Throws<ArgumentNullException>(() => new CloudRunPlatformDetails("", "", "", "", "", null));
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

        [Theory]
        [InlineData(null, null, "", "")]
        [InlineData("", "", "", "")]
        [InlineData("podName", null, "podName", "")]
        [InlineData(null, "namespace", "", "namespace")]
        [InlineData("podName", "namespace", "podName", "namespace")]
        public void Gke_PartialData(string podName, string namespaceName, string expectedPodName, string expectedNamespaceName)
        {
            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
                PodName = podName,
                NamespaceName = namespaceName
            };
            var gke = GkePlatformDetails.TryLoad(LoadResourceString("Metadata.json"), kubernetesData);
            Assert.NotNull(gke);
            Assert.Equal("chrisbacon-testing", gke.ProjectId);
            Assert.Equal("platformintegrationtest", gke.ClusterName);
            Assert.Equal("europe-west2-c", gke.Location);
            Assert.Equal(expectedPodName, gke.HostName);
            Assert.Equal("2917200381659545756", gke.InstanceId);
            Assert.Equal("projects/233772281425/zones/europe-west2-c", gke.Zone);
            Assert.Equal(expectedNamespaceName, gke.NamespaceId);
            Assert.Equal(expectedPodName, gke.PodId);
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
            Assert.Equal("default", gke.NamespaceId);
            Assert.Equal("platformintegrationtest-1135066300-rpzm4", gke.PodId);
            Assert.Equal("platformintegrationtest", gke.ContainerName);
        }

        const string metadataValid = "{'project':{'projectId':'FakeProjectId'},'instance':{'attributes':{'cluster-name':'FakeClusterName'},'id':'123','zone':'projects/FakeProject/zones/FakeLocation'}}";
        const string metadataIncomplete = "{'project':{'projectId':'FakeProjectId'},'instance':{'attr";
        const string namespaceValid = "{'kind':'Namespace','metadata':{'name':'namespacename'}}";
        const string namespaceMissingKind = "{'notkind':'Namespace','metadata':{'name':'namespacename'}}";
        const string namespaceWrongKind = "{'kind':'NotNamespace','metadata':{'name':'namespacename'}}";
        const string namespaceIncomplete = "{'kind':'Namespace','m";
        const string podValid = "{'kind':'Pod','metadata':{'name':'podname','uid':'podid'}}";
        const string podMissingKind = "{'notkind':'Pod','metadata':{'name':'podname','uid':'podid'}}";
        const string podWrongKind = "{'kind':'NotPod','metadata':{'name':'podname','uid':'podid'}}";
        const string podIncomplete = "{'kind':'Pod','metadata':{";
        const string mountInfoValid = "123\n/var/lib/kubelet/pods/podid/containers/containername/ /dev/termination-log\nabc";
        const string mountInfoMultiple = "var/lib/kubelet/pods/podid/containers/containername1/ /dev/termination-log\nvar/lib/kubelet/pods/podid/containers/containername2/ /dev/termination-log";
        const string mountInfoMissing = "123\n/var/lib/kubelet/pods/podid/notcontainers/containername/ /dev/termination-log\nabc";

        [Theory, PairwiseData]
        public void Gke_IncompleteData(
            [CombinatorialValues("", metadataIncomplete, metadataValid)] string metadataJson,
            [CombinatorialValues(null, "", namespaceIncomplete, namespaceWrongKind, namespaceMissingKind, namespaceValid)] string namespaceJson,
            [CombinatorialValues(null, "", podIncomplete, podWrongKind, podMissingKind, podValid)] string podJson,
            [CombinatorialValues(null, "", mountInfoMultiple, mountInfoMissing, mountInfoValid)] string mountInfo)
        {
            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
                NamespaceJson = namespaceJson,
                PodJson = podJson,
                MountInfo = mountInfo?.Split('\n').Where(x => x != "").ToArray()
            };
            var gke = GkePlatformDetails.TryLoad(metadataJson, kubernetesData);
            if (metadataJson != metadataValid)
            {
                Assert.Null(gke);
                return;
            }
            Assert.NotNull(gke);
            if (namespaceJson == namespaceValid)
            {
                Assert.Equal("namespacename", gke.NamespaceId);
            }
            else
            {
                Assert.Equal("", gke.NamespaceId);
            }
            if (podJson == podValid)
            {
                Assert.Equal("podname", gke.PodId);
                Assert.Equal("podname", gke.HostName);
            }
            else
            {
                Assert.Equal("", gke.PodId);
                Assert.Equal("", gke.HostName);
            }
            if (mountInfo == mountInfoValid && podJson == podValid)
            {
                Assert.Equal("containername", gke.ContainerName);
            }
            else
            {
                Assert.Equal("", gke.ContainerName);
            }
        }

        [Fact]
        public void Project_Gke()
        {
            var details = new GkePlatformDetails(
                "json", "gke-project", "cluster", "location", "host", "instance",
                "projects/123/zone", "namespace", "pod", "container");
            var platform = new Platform(details);
            Assert.Equal("gke-project", platform.ProjectId);
        }

        [Fact]
        public void Project_Gce()
        {
            var details = new GcePlatformDetails("json", "gce-project", "instance", "projects/123/zones/zone");
            var platform = new Platform(details);
            Assert.Equal("gce-project", platform.ProjectId);
        }

        [Fact]
        public void Project_Gae()
        {
            var details = new GaePlatformDetails("gae-project", "instance", "service", "version");
            var platform = new Platform(details);
            Assert.Equal("gae-project", platform.ProjectId);
        }

        [Fact]
        public void Project_CloudRun()
        {
            var details = new CloudRunPlatformDetails("json", "cr-project", "us-central1-1", "service", "revision", "configuration");
            var platform = new Platform(details);
            Assert.Equal("cr-project", platform.ProjectId);
        }

        [Fact]
        public void Project_Unknown()
        {
            var platform = new Platform();
            Assert.Null(platform.ProjectId);
        }
    }
}
