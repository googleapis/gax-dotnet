using Newtonsoft.Json.Linq;
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
    }
}
