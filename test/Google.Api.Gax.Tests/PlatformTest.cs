using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class PlatformTest
    {
        [Fact]
        public void NoData()
        {
            Assert.Null(GkePlatformDetails.TryLoad("", new GkePlatformDetails.KubernetesData { NamespaceJson = "", PodJson = "" }));
        }

        private string LoadResourceString(string name)
        {
            var assembly = typeof(PlatformTest).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"Google.Api.Gax.Tests.Resources.{name}");
            var ms = new MemoryStream();
            stream.CopyTo(ms);
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        [Fact]
        public void WithData()
        {
            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
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
