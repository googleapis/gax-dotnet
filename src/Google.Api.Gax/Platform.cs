﻿/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Google.Api.Gax
{
    /// <summary>
    /// Execution platform type.
    /// </summary>
    public enum PlatformType
    {
        /// <summary>
        /// Unknown execution platform.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Execution platform is Google Compute Engine.
        /// </summary>
        Gce = 1,

        /// <summary>
        /// Execution platform is Google App Engine.
        /// </summary>
        Gae = 2,

        /// <summary>
        /// Execution platform is Google Container Engine (Kubernetes).
        /// </summary>
        Gke = 3,
    }

    /// <summary>
    /// Google Compute Engine details.
    /// </summary>
    public sealed class GcePlatformDetails
    {
        /// <summary>
        /// Builds a <see cref="GcePlatformDetails"/> from the given metadata.
        /// This metadata is normally retrieved from the GCE metadata server.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.</param>
        /// <returns>A populated <see cref="GcePlatformDetails"/> if the metadata represents and GCE instance;
        /// <c>null</c> otherwise.</returns>
        public static GcePlatformDetails TryLoad(string metadataJson)
        {
            JObject metadata;
            try
            {
                metadata = JObject.Parse(metadataJson);
            }
            catch
            {
                return null;
            }
            var projectId = metadata["project"]?["projectId"]?.ToString();
            var instanceId = metadata["instance"]?["id"]?.ToString();
            var zoneName = metadata["instance"]?["zone"]?.ToString();
            if (projectId != null && instanceId != null && zoneName != null)
            {
                return new GcePlatformDetails(metadataJson, projectId, instanceId, zoneName);
            }
            return null;
        }

        /// <summary>
        /// Construct details of Google Compute Engine
        /// </summary>
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server.</param>
        /// <param name="projectId">The project ID.</param>
        /// <param name="instanceId">The instance ID.</param>
        /// <param name="zoneName">The zone name.</param>
        public GcePlatformDetails(string metadataJson, string projectId, string instanceId, string zoneName)
        {
            MetadataJson = metadataJson;
            ProjectId = projectId;
            InstanceId = instanceId;
            ZoneName = zoneName;
        }

        /// <summary>
        /// The full JSON string retrieved from the metadata server.
        /// </summary>
        public string MetadataJson { get; }

        /// <summary>
        /// The Project ID under which this GCE instance is running.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        ///  The Instance ID of the GCE instance on which this is running.
        /// </summary>
        public string InstanceId { get; }

        /// <summary>
        /// The zone name where this GCE instance is running.
        /// </summary>
        public string ZoneName { get; }

        /// <inheritdoc/>
        public override string ToString() =>
            $"[GCE: ProjectId='{ProjectId}', InstanceId='{InstanceId}', ZoneName='{ZoneName}']";
    }

    /// <summary>
    /// Google App Engine details.
    /// </summary>
    public sealed class GaePlatformDetails
    {
        /// <summary>
        /// Construct details of Google App Engine
        /// </summary>
        /// <param name="gcloudProject">The Project ID associated with your application,
        /// which is visible in the Google Cloud Platform Console.</param>
        /// <param name="gaeInstance">The name of the current instance.</param>
        /// <param name="gaeService">The service name specified in your application's app.yaml file,
        /// or if no service name is specified, it is set to default.</param>
        /// <param name="gaeVersion">The version label of the current application.</param>
        public GaePlatformDetails(string gcloudProject, string gaeInstance, string gaeService, string gaeVersion)
        {
            ProjectId = gcloudProject;
            InstanceId = gaeInstance;
            ServiceId = gaeService;
            VersionId = gaeVersion;
        }

        /// <summary>
        /// The Project ID associated with your application, which is visible in the Google Cloud Platform Console.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// The name of the current instance.
        /// </summary>
        public string InstanceId { get; }

        /// <summary>
        /// The service name specified in your application's app.yaml file, or if no service name is specified, it is set to default.
        /// </summary>
        public string ServiceId { get; }

        /// <summary>
        /// The version label of the current application.
        /// </summary>
        public string VersionId { get; }

        /// <inheritdoc/>
        public override string ToString() =>
            $"[GAE: ProjectId='{ProjectId}', InstanceId='{InstanceId}', ServiceId='{ServiceId}', VersionId='{VersionId}']";
    }

    /// <summary>
    /// Google Container (Kubernetes) Engine details.
    /// </summary>
    public sealed class GkePlatformDetails
    {
        /// <summary>
        /// Data from the Kubernetes API
        /// </summary>
        public class KubernetesData
        {
            /// <summary>
            /// JSON from https://kubernetes/api/v1/namespaces/{namespace}
            /// </summary>
            public string NamespaceJson { get; set; }

            /// <summary>
            /// JSON from https://kubernetes/api/v1/namespaces/{namespace}/pods/{pod-name}
            /// </summary>
            public string PodJson { get; set; }

            /// <summary>
            /// Lines from /proc/self/mountinfo
            /// </summary>
            public string[] MountInfo { get; set; }
        }

        private static readonly PathTemplate s_zoneTemplate = new PathTemplate("projects/*/zones/*");

#if NETSTANDARD1_3
        internal static async Task<KubernetesData> LoadKubernetesDataAsync()
        {
            var kubernetesServiceHost = Environment.GetEnvironmentVariable("KUBERNETES_SERVICE_HOST");
            int.TryParse(Environment.GetEnvironmentVariable("KUBERNETES_SERVICE_PORT"), out var kubernetesServicePort);
            var podName = Environment.GetEnvironmentVariable("HOSTNAME");
            if (string.IsNullOrEmpty(kubernetesServiceHost) || kubernetesServicePort == 0 || string.IsNullOrEmpty(podName))
            {
                // Not running on GKE
                return null;
            }
            var baseUrl = $"https://{kubernetesServiceHost}:{kubernetesServicePort}/api/v1";
            string kubernetesNamespace;
            string kubernetesToken;
            string kubernetesCa;
            string[] mountInfo;
            try
            {
                kubernetesNamespace = File.ReadAllText("/var/run/secrets/kubernetes.io/serviceaccount/namespace");
                kubernetesToken = File.ReadAllText("/var/run/secrets/kubernetes.io/serviceaccount/token");
                kubernetesCa = File.ReadAllText("/var/run/secrets/kubernetes.io/serviceaccount/ca.crt");
                mountInfo = File.ReadAllLines("/proc/self/mountinfo");
            }
            catch
            {
                // Various errors can occur, all of which mean probably not running on GKE
                return null;
            }
            if (string.IsNullOrEmpty(kubernetesNamespace) || string.IsNullOrEmpty(kubernetesToken) ||
                string.IsNullOrEmpty(kubernetesCa) || mountInfo == null || mountInfo.Length == 0)
            {
                // These files should contain useful data on GKE
                return null;
            }

            var handler = new HttpClientHandler
            {
                // TODO: Properly check that the certificate is valid, using kubernetesCa
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errs) => true
            };
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", kubernetesToken);
                var urlNamespace = $"{baseUrl}/namespaces/{kubernetesNamespace}";
                var urlPod = $"{baseUrl}/namespaces/{kubernetesNamespace}/pods/{podName}";
                try
                {
                    return new KubernetesData
                    {
                        NamespaceJson = await client.GetStringAsync(urlNamespace).ConfigureAwait(false),
                        PodJson = await client.GetStringAsync(urlPod).ConfigureAwait(false),
                        MountInfo = mountInfo
                    };
                }
                catch
                {
                    return null;
                }
            }
        }
#elif NET45
        internal static Task<KubernetesData> LoadKubernetesDataAsync()
        {
            // .NET45 code cannot run on Kubernetes.
            // And .NET45 does not cert functionality that we require.
            return Task.FromResult<KubernetesData>(null);
        }
#else
#error Unsupported platform
#endif

        /// <summary>
        /// Builds a <see cref="GkePlatformDetails"/> from the given metadata.
        /// This metadata is normally retrieved from the GCE metadata server.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.</param>
        /// <returns>A populated <see cref="GkePlatformDetails"/> if the metadata represents and GKE instance;
        /// <c>null</c> otherwise.</returns>
        [Obsolete("Use TryLoad(string, KubernetesData) instead.")]
        public static GkePlatformDetails TryLoad(string metadataJson) =>
            TryLoad(metadataJson, GkePlatformDetails.LoadKubernetesDataAsync().Result);

        /// <summary>
        /// Builds a <see cref="GkePlatformDetails"/> from the given metadata and kubernetes data.
        /// The metadata is normally retrieved from the GCE metadata server.
        /// The kubernetes data is normally retrieved using the kubernetes API.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.</param>
        /// <param name="kubernetesData">Kubernetes data, normally retrieved using the kubernetes API.</param>
        /// <returns></returns>
        public static GkePlatformDetails TryLoad(string metadataJson, KubernetesData kubernetesData)
        {
            JObject metadata;
            JObject namespaceData;
            JObject podData;
            try
            {
                metadata = JObject.Parse(metadataJson);
                namespaceData = JObject.Parse(kubernetesData.NamespaceJson);
                podData = JObject.Parse(kubernetesData.PodJson);
            }
            catch
            {
                return null;
            }
            if (namespaceData["kind"].Value<string>() != "Namespace" || podData["kind"].Value<string>() != "Pod")
            {
                return null;
            }
            var hostName = podData["metadata"]?["name"]?.Value<string>(); // Pod name is the hostname
            var projectId = metadata["project"]?["projectId"]?.Value<string>();
            var clusterName = metadata["instance"]?["attributes"]?["cluster-name"]?.Value<string>();
            var instanceId = metadata["instance"]?["id"]?.Value<string>();
            var zone = metadata["instance"]?["zone"]?.Value<string>();
            var namespaceId = namespaceData["metadata"]?["uid"]?.Value<string>();
            var podId = podData["metadata"]?["uid"]?.Value<string>();
            // A hack to find the container name. There appears to be no official way to do this.
            var regex = new Regex($"/var/lib/kubelet/pods/{podId}/containers/([^/]+)/.*/dev/termination-log");
            var containerNames = kubernetesData.MountInfo.Select(x =>
            {
                var match = regex.Match(x);
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
                return null;
            }).Where(x => x != null).ToList();
            var containerName = containerNames.Count == 1 ? containerNames[0] : "";
            if (hostName != null && projectId != null && clusterName != null && instanceId != null &&
                zone != null && namespaceId != null && podId != null && containerName != null)
            {
                if (s_zoneTemplate.TryParseName(zone, out var zoneResourceName))
                    return new GkePlatformDetails(metadataJson, projectId, clusterName, zoneResourceName[1], hostName,
                        instanceId, zone, namespaceId, podId, containerName);
            }
            return null;
        }

        /// <summary>
        /// Construct details of Google Container (Kubernetes) Engine
        /// </summary>
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server.</param>
        /// <param name="projectId">The project ID.</param>
        /// <param name="clusterName">The cluster name.</param>
        /// <param name="location">The location.</param>
        /// <param name="hostName">The instance host name.</param>
        [Obsolete("Only partial fills instance with data; use alternative constructor.")]
        public GkePlatformDetails(string metadataJson, string projectId, string clusterName, string location, string hostName)
            : this(metadataJson, projectId, clusterName, location, hostName, null, null, null, null, null)
        {
        }

        /// <summary>
        /// Construct details of Google Container (Kubernetes) Engine
        /// </summary>
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server.</param>
        /// <param name="projectId">The project ID.</param>
        /// <param name="clusterName">The cluster name.</param>
        /// <param name="location">The location.</param>
        /// <param name="hostName">The instance host name.</param>
        /// <param name="instanceId">The GCE instance ID.</param>
        /// <param name="zone">The zone.</param>
        /// <param name="namespaceId">The kubernetes namespace ID.</param>
        /// <param name="podId">The kubernetes pod ID.</param>
        /// <param name="containerName">The container name.</param>
        public GkePlatformDetails(string metadataJson, string projectId, string clusterName, string location, string hostName,
            string instanceId, string zone, string namespaceId, string podId, string containerName)
        {
            MetadataJson = metadataJson;
            ProjectId = projectId;
            ClusterName = clusterName;
            Location = location;
            HostName = hostName;
            InstanceId = instanceId;
            Zone = zone;
            NamespaceId = namespaceId;
            PodId = podId;
            ContainerName = containerName;
        }

        /// <summary>
        /// The full JSON string retrieved from the metadata server.
        /// </summary>
        public string MetadataJson { get; }

        /// <summary>
        /// The Project ID associated with your application, which is visible in the Google Cloud Platform Console.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// The cluster name, which is visible in the Google Cloud Platform Console.
        /// </summary>
        public string ClusterName { get; }

        /// <summary>
        /// The cluster location, which is visible in the Google Cloud Platform Console.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// The hostname of this instance.
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// The GCE instance this container is running in.
        /// </summary>
        public string InstanceId { get; }

        /// <summary>
        /// The GCE zone in which the instance is running.
        /// </summary>
        public string Zone { get; }

        /// <summary>
        /// The cluster namespace the container is running in.
        /// </summary>
        public string NamespaceId { get; }

        /// <summary>
        /// The pos the container is running in.
        /// </summary>
        public string PodId { get; }

        /// <summary>
        /// The name of the container.
        /// </summary>
        public string ContainerName { get; }

        /// <inheritdoc/>
        public override string ToString() =>
            $"[GKE: ProjectId='{ProjectId}', ClusterName='{ClusterName}', HostName='{HostName}', " +
            $"InstanceId='{InstanceId}', Zone='{Zone}', NamespaceId='{NamespaceId}', PodId='{PodId}', ContainerName='{ContainerName}']";
    }

    /// <summary>
    /// Information about the current execution platform.
    /// Supported execution platforms are Google App Engine (GAE), Google Container Engine (GKE), and Google Compute Engine (GCE).
    /// </summary>
    public sealed class Platform
    {
        private readonly static Lazy<Task<Platform>> s_instance = new Lazy<Task<Platform>>(LoadInstanceAsync);

        /// <summary>
        /// Asyncrhonously get execution platform information.
        /// </summary>
        /// <returns>A task containing the execution platform information.</returns>
        public static Task<Platform> InstanceAsync() => s_instance.Value;

        /// <summary>
        /// Get execution platform information. This may block for up to one second.
        /// </summary>
        /// <returns>Execution platform information.</returns>
        public static Platform Instance() => InstanceAsync().Result;

        private static async Task<string> LoadMetadataAsync()
        {
            // Check if emulator is in use by looking for an emulator host in environment variable
            // METADATA_EMULATOR_HOST. This is the undocumented but the de-facto mechanism for doing this.
            var metadataEmulatorHost = Environment.GetEnvironmentVariable("METADATA_EMULATOR_HOST");
            const string metadataHost = "metadata.google.internal";
            const string metadataFlavorKey = "Metadata-Flavor";
            const string metadataFlavorValue = "Google";
            const long maxContentLength = 512 * 1024; // Maximum allowed metadata size.
            try
            {
                var effectiveMetadataHost = string.IsNullOrEmpty(metadataEmulatorHost) ? metadataHost : metadataEmulatorHost;
                var metadataUrl = $"http://{effectiveMetadataHost}/computeMetadata/v1?recursive=true";
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, metadataUrl);
                httpRequest.Headers.Add(metadataFlavorKey, metadataFlavorValue); // Required for any query.
                var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(1000)); // 1000 found to be reasonable.
                var httpClient = new HttpClient();
                var response = await httpClient.SendAsync(httpRequest, cts.Token).ConfigureAwait(false); // TODO: Consider retrying on IO Exception.
                IEnumerable<string> metadataValues;
                if (response.StatusCode == HttpStatusCode.OK
                    && response.Headers.TryGetValues(metadataFlavorKey, out metadataValues)
                    && metadataValues.Contains(metadataFlavorValue)
                    && response.Content.Headers.ContentLength < maxContentLength)
                {
                    // Valid response from metadata server.
                    return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            catch
            {
                // Possible exceptions, in all cases there's nothing we can do except
                // assume we're not running on GCE, and hence return null.
                // OperationCanceledException: on timeout
                // HttpRequestException: On general request failure
                // WebException: DNS problem on Mono
                // TODO: Decide what to do here.
            }
            return null;
        }

        private static GaePlatformDetails LoadGaeDetails()
        {
            // See https://cloud.google.com/appengine/docs/flexible/python/runtime#environment_variables
            // for details on environment variables.
            var gcloudProject = Environment.GetEnvironmentVariable("GCLOUD_PROJECT");
            var gaeInstance = Environment.GetEnvironmentVariable("GAE_INSTANCE");
            var gaeService = Environment.GetEnvironmentVariable("GAE_SERVICE");
            var gaeVersion = Environment.GetEnvironmentVariable("GAE_VERSION");
            if (gcloudProject != null && gaeInstance != null && gaeService != null && gaeVersion != null)
            {
                return new GaePlatformDetails(gcloudProject, gaeInstance, gaeService, gaeVersion);
            }
            return null;
        }

        private static async Task<Platform> LoadInstanceAsync()
        {
            // The order matters here:
            // * GAE runs on GCE, so do GAE before GCE.
            // * GKE runs on GCE, so do GKE before GCE.
            // * Metadata server access can take time, so do GAE first.
            GaePlatformDetails gaeDetails = LoadGaeDetails();
            if (gaeDetails != null)
            {
                return new Platform(gaeDetails);
            }
            var metadataJson = await LoadMetadataAsync().ConfigureAwait(false);
            if (metadataJson != null)
            {
                var kubernetesData = await GkePlatformDetails.LoadKubernetesDataAsync().ConfigureAwait(false);
                GkePlatformDetails gkeDetails = GkePlatformDetails.TryLoad(metadataJson, kubernetesData);
                if (gkeDetails != null)
                {
                    return new Platform(gkeDetails);
                }
                GcePlatformDetails gceDetails = GcePlatformDetails.TryLoad(metadataJson);
                if (gceDetails != null)
                {
                    return new Platform(gceDetails);
                }
            }
            return new Platform();
        }

        /// <summary>
        /// Construct with no details.
        /// This leads to a platform <see cref="Type"/> of <see cref="PlatformType.Unknown"/>.
        /// </summary>
        public Platform()
        {
        }

        /// <summary>
        /// Construct with details of Google Compute Engine.
        /// </summary>
        /// <param name="gceDetails">Details of Google Compute Engine.</param>
        public Platform(GcePlatformDetails gceDetails)
        {
            GceDetails = GaxPreconditions.CheckNotNull(gceDetails, nameof(gceDetails));
        }

        /// <summary>
        /// Construct with details of Google App Engine.
        /// </summary>
        /// <param name="gaeDetails">Details of Google App Engine.</param>
        public Platform(GaePlatformDetails gaeDetails)
        {
            GaeDetails = GaxPreconditions.CheckNotNull(gaeDetails, nameof(gaeDetails));
        }

        /// <summary>
        /// Construct with details of Google Container (Kubernetes) Engine.
        /// </summary>
        /// <param name="gkeDetails">Details of Google Container (Kubernetes) Engine.</param>
        public Platform(GkePlatformDetails gkeDetails)
        {
            GkeDetails = GaxPreconditions.CheckNotNull(gkeDetails, nameof(gkeDetails));
        }

        /// <summary>
        /// Google App Engine (GAE) platform details.
        /// <c>null</c> if not executing on GAE.
        /// </summary>
        public GaePlatformDetails GaeDetails { get; }

        /// <summary>
        /// Google Compute Engine (GCE) platform details.
        /// <c>null</c> if not executing on GCE. 
        /// </summary>
        public GcePlatformDetails GceDetails { get; }

        /// <summary>
        /// Google Container (Kubernetes) Engine (GKE) platform details.
        /// <c>null</c> if not executing on GKE. 
        /// </summary>
        public GkePlatformDetails GkeDetails { get; }

        /// <summary>
        /// The current execution platform.
        /// </summary>
        public PlatformType Type =>
            GaeDetails != null ? PlatformType.Gae :
            GceDetails != null ? PlatformType.Gce :
            GkeDetails != null ? PlatformType.Gke :
            PlatformType.Unknown;

        /// <summary>
        /// The current Project ID.
        /// <c>null</c> if the Project ID cannot be determined on the current execution platform.
        /// </summary>
        public string ProjectId
        {
            get
            {
                switch (Type)
                {
                    case PlatformType.Gae:
                        return GaeDetails.ProjectId;
                    case PlatformType.Gce:
                        return GceDetails.ProjectId;
                    case PlatformType.Gke:
                        return GkeDetails.ProjectId;
                    default:
                        return null;
                }
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case PlatformType.Gae:
                    return GaeDetails.ToString();
                case PlatformType.Gce:
                    return GceDetails.ToString();
                case PlatformType.Gke:
                    return GkeDetails.ToString();
                case PlatformType.Unknown:
                    return "[Unknown platform]";
                default:
                    return $"[Unknown platform type: '{Type}']";
            }
        }
    }
}
