/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Helper methods to build a <see cref="MonitoredResource"/> instance.
    /// See the <a href="https://cloud.google.com/logging/docs/api/v2/resource-list">
    /// Monitored Resource List</a> for details.
    /// </summary>
    public static class MonitoredResourceBuilder
    {
        /// <summary>
        /// An instance of a "global" resource, with <see cref="MonitoredResource.Type"/>
        /// set to "global", and an empty set of <see cref="MonitoredResource.Labels"/>.
        /// </summary>
        /// <remarks>
        /// A new instance is returned with each call, as the returned object is mutable.
        /// </remarks>
        public static MonitoredResource GlobalResource =>
            new MonitoredResource { Type = "global" };

        /// <summary>
        /// Builds a <see cref="MonitoredResource"/> from the auto-detected
        /// platform, using <see cref="Platform.Instance"/>.
        /// This call can block for up to 1 second.
        /// </summary>
        /// <returns>A <see cref="MonitoredResource"/> instance, populated most suitably for the given platform.</returns>
        public static MonitoredResource FromPlatform() =>
            FromPlatform(Platform.Instance());

        /// <summary>
        /// Builds a <see cref="MonitoredResource"/> from the auto-detected
        /// platform, using <see cref="Platform.Instance"/>.
        /// </summary>
        /// <returns>A task, the result of which will be a <see cref="MonitoredResource"/> instance,
        /// populated most suitably for the given platform.</returns>
        public static async Task<MonitoredResource> FromPlatformAsync() =>
            FromPlatform(await Platform.InstanceAsync().ConfigureAwait(false));

        /// <summary>
        /// Builds a suitable <see cref="MonitoredResource"/> instance, given
        /// <see cref="Platform"/> information.
        /// Use <see cref="FromPlatform()"/> or <see cref="FromPlatformAsync()"/> to build a
        /// <see cref="MonitoredResource"/> from auto-detected platform information.
        /// </summary>
        /// <param name="platform"><see cref="Platform"/> information, usually auto-detected.</param>
        /// <returns>A <see cref="MonitoredResource"/> instance, populated most suitably for the given platform.</returns>
        public static MonitoredResource FromPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.Unknown:
                    return GlobalResource;
                case PlatformType.Gce:
                    var gce = platform.GceDetails;
                    return new MonitoredResource
                    {
                        Type = "gce_instance",
                        Labels =
                        {
                            { "project_id", gce.ProjectId },
                            { "instance_id", gce.InstanceId },
                            { "zone", gce.ZoneName }
                        }
                    };
                case PlatformType.Gae:
                    var gae = platform.GaeDetails;
                    return new MonitoredResource
                    {
                        Type = "gae_app",
                        Labels =
                        {
                            { "project_id", gae.ProjectId },
                            { "module_id", gae.ServiceId },
                            { "version_id", gae.VersionId }
                        }
                    };
                case PlatformType.Gke:
                    var gke = platform.GkeDetails;
                    return new MonitoredResource
                    {
                        Type = "container",
                        Labels =
                        {
                            { "project_id", gke.ProjectId },
                            { "cluster_name", gke.ClusterName },
                            { "namespace_id", gke.NamespaceId },
                            { "instance_id", gke.InstanceId },
                            { "pod_id", gke.PodId },
                            { "container_name", gke.ContainerName },
                            { "zone", gke.Zone }
                        }
                    };
                default:
                    // This isn't great, but is better than throwing an exception.
                    return GlobalResource;
            }
        }
    }
}
