/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    'zone': 'FakeZone'
  }
}
";
            var platform = new Platform(new GcePlatformDetails(json));
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("gce_instance", resource.Type);
            Assert.Equal(3, resource.Labels.Count);
            Assert.Equal("FakeProjectId", resource.Labels["project_id"]);
            Assert.Equal("FakeInstanceId", resource.Labels["instance_id"]);
            Assert.Equal("FakeZone", resource.Labels["zone"]);
        }

        [Fact]
        public void GaePlatform()
        {
            var platform = new Platform(new GaePlatformDetails("FakeProjectId", "FakeInstanceId", "FakeService", "FakeVersion"));
            var resource = MonitoredResourceBuilder.FromPlatform(platform);
            Assert.Equal("gae_app", resource.Type);
            Assert.Equal(3, resource.Labels.Count);
            Assert.Equal("FakeProjectId", resource.Labels["project_id"]);
            Assert.Equal("FakeService", resource.Labels["module_id"]);
            Assert.Equal("FakeVersion", resource.Labels["version_id"]);
        }
    }
}
