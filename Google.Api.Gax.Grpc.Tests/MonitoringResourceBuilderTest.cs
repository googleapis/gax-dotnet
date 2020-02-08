/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class MonitoringResourceBuilderTest
    {
        // See https://cloud.google.com/logging/docs/api/v2/resource-list

        [Fact]
        public void UnknownPlatform()
        {
            var platform = new Platform();
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("global", resource.Type);
            Assert.Empty(resource.Labels);
        }

        [Fact]
        public void GcePlatform()
        {
            const string json = @"
{
  'project': {
    'projectId': 'FakeProjectId'
  },
  'instance': {
    'id': 'FakeInstanceId',
    'zone': 'projects/1234567/zones/FakeZone'
  }
}
";
            var platform = new Platform(GcePlatformDetails.TryLoad(json));
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("gce_instance", resource.Type);
            Assert.Equal(new Dictionary<string, string>
            {
                { "project_id", "FakeProjectId" },
                { "instance_id", "FakeInstanceId" },
                { "zone", "FakeZone" }
            }, resource.Labels);
        }

        [Fact]
        public void GaePlatform()
        {
            var platform = new Platform(new GaePlatformDetails("FakeProjectId", "FakeInstanceId", "FakeService", "FakeVersion"));
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("gae_app", resource.Type);
            Assert.Equal(new Dictionary<string, string>
            {
                { "project_id", "FakeProjectId" },
                { "module_id", "FakeService" },
                { "version_id", "FakeVersion" }
            }, resource.Labels);
        }

        [Fact]
        public void CloudRunPlatform()
        {
            var details = new CloudRunPlatformDetails("json", "projectId", "us-central1-1", "service", "revision", "configuration");
            var resource = MonitoredResourceBuilder.FromPlatform(new Platform(details));
            Assert.Equal("cloud_run_revision", resource.Type);
            Assert.Equal(new Dictionary<string, string>
            {
                { "project_id", "projectId" },
                // Note this is the region, not the zone
                { "location", "us-central1" },
                { "service_name", "service" },
                { "revision_name", "revision" },
                { "configuration_name", "configuration" }
            }, resource.Labels);
        }

        [Fact]
        public void GkePlatform()
        {
            const string metadataJson = @"
{
  'project': {
    'projectId': 'FakeProjectId'
  },
  'instance': {
    'attributes': {
      'cluster-name': 'FakeClusterName',
    },
    'id': '123',
    'zone': 'projects/FakeProject/zones/FakeLocation'
  }
}
";
            const string namespaceJson = @"
{
  'kind': 'Namespace',
  'metadata': {
    'uid': 'namespaceid',
    'name':'namespacename'
  }
}
";
            const string podJson = @"
{
  'kind': 'Pod',
  'metadata': {
    'name': 'podname',
    'uid': 'podid'
  }
}
";
            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
                NamespaceJson = namespaceJson,
                PodJson = podJson,
                MountInfo = new[] { "/var/lib/kubelet/pods/podid/containers/containername/ /dev/termination-log" }
            };
            var platform = new Platform(GkePlatformDetails.TryLoad(metadataJson, kubernetesData));
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("gke_container", resource.Type);
            Assert.Equal(new Dictionary<string, string>
            {
                { "project_id", "FakeProjectId" },
                { "cluster_name", "FakeClusterName" },
                // Although the name of the label is namespace_id, the actual value returned and expected
                // by Stackdriver is the namespace name.
                { "namespace_id", "namespacename" },
                { "instance_id", "123" },
                // Although the name of the label is pod_id, the actual value returned and expected
                // by Stackdriver is the pod name.
                { "pod_id", "podname" },
                { "container_name", "containername" },
                { "zone", "FakeLocation" }
            }, resource.Labels);
        }

        [Fact]
        public void GkePlatform_NewStackdriver()
        {
            const string metadataJson = @"
{
  'project': {
    'projectId': 'FakeProjectId'
  },
  'instance': {
    'attributes': {
      'cluster-location': 'europe-west2',
      'cluster-name': 'FakeClusterName',
      'kube-env': 'ALLOCATE_NODE_CIDRS: ""true""\nAPI_SERVER_TEST_LOG_LEVEL: --v=3\nHEAPSTER_USE_NEW_STACKDRIVER_RESOURCES: ""true""\nHEAPSTER_USE_OLD_STACKDRIVER_RESOURCES: ""false""\nHPA_USE_REST_CLIENTS: ""true""'
    },
    'id': '123',
    'zone': 'projects/FakeProject/zones/europe-west2-a'
  }
}
";

            const string namespaceJson = @"
{
  'kind': 'Namespace',
  'metadata': {
    'uid': 'namespaceid',
    'name':'namespacename'
  }
}
";

            const string podJson = @"
{
  'kind': 'Pod',
  'metadata': {
    'name': 'podname',
    'uid': 'podid'
  }
}
";

            var kubernetesData = new GkePlatformDetails.KubernetesData
            {
                NamespaceJson = namespaceJson,
                PodJson = podJson,
                MountInfo = new[] { "/var/lib/kubelet/pods/podid/containers/containername/ /dev/termination-log" }
            };
            var platform = new Platform(GkePlatformDetails.TryLoad(metadataJson, kubernetesData));
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("k8s_container", resource.Type);
            Assert.Equal(new Dictionary<string, string>
            {
                { "project_id", "FakeProjectId" },
                { "location", "europe-west2" },
                { "cluster_name", "FakeClusterName" },
                { "namespace_name", "namespacename" },
                { "pod_name", "podname" },
                { "container_name", "containername" },
            }, resource.Labels);
        }
    }
}
