/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// Execution platform is Google Cloud Run.
        /// </summary>
        CloudRun = 4
    }

    /// <summary>
    /// Google Cloud Run details.
    /// </summary>
    public sealed class CloudRunPlatformDetails
    {
        /// <summary>
        /// Builds a <see cref="CloudRunPlatformDetails"/> from the given metadata
        /// and Cloud Run environment variables.
        /// The metadata is normally retrieved from the GCE metadata server.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.
        /// Must not be <c>null</c>.</param>
        /// <returns>A populated <see cref="CloudRunPlatformDetails"/> if the metadata represents and GCE instance;
        /// <c>null</c> otherwise.</returns>
        public static CloudRunPlatformDetails TryLoad(string metadataJson)
        {
            GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
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
            var zoneName = metadata["instance"]?["zone"]?.ToString();
            if (projectId == null || zoneName == null || !Platform.s_zoneTemplate.TryParseName(zoneName, out var zoneResourceName))
            {
                return null;
            }
            string location = zoneResourceName[1];
            string serviceName = Environment.GetEnvironmentVariable("K_SERVICE");
            string revisionName = Environment.GetEnvironmentVariable("K_REVISION");
            string configurationName = Environment.GetEnvironmentVariable("K_CONFIGURATION");
            if (serviceName is null || revisionName is null || configurationName is null)
            {
                return null;
            }
            return new CloudRunPlatformDetails(metadataJson, projectId, location, serviceName, revisionName, configurationName);
        }

        /// <summary>
        /// Constructs details of a Google Cloud Run service revision.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.
        /// Must not be <c>null</c>.</param>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="location">The location in which the service code is running. Must not be null.</param>
        /// <param name="serviceName">The name of the service. Must not be null.</param>
        /// <param name="revisionName">The name of the revision. Must not be null.</param>
        /// <param name="configurationName">The name of the configuration. Must not be null.</param>
        public CloudRunPlatformDetails(
            string metadataJson, string projectId, string location,
            string serviceName, string revisionName, string configurationName)
        {
            MetadataJson = GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
            ProjectId = GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
            Location = GaxPreconditions.CheckNotNull(location, nameof(location));
            ServiceName = GaxPreconditions.CheckNotNull(serviceName, nameof(serviceName));
            RevisionName = GaxPreconditions.CheckNotNull(revisionName, nameof(revisionName));
            ConfigurationName = GaxPreconditions.CheckNotNull(configurationName, nameof(configurationName));
        }

        /// <summary>
        /// The full JSON string retrieved from the metadata server. This is never null.
        /// </summary>
        public string MetadataJson { get; }

        /// <summary>
        /// The Project ID under which this service is running. This is never null.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// The location, e.g. "us-central1". This is never null.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// The name of the Cloud Run service being run. This is never null.
        /// </summary>
        public string ServiceName { get; }
        
        /// <summary>
        /// The name of the Cloud Run revision being run. This is never null.
        /// </summary>
        public string RevisionName { get; }

        /// <summary>
        /// The name of the Cloud Run configuration being run. This is never null.
        /// </summary>
        public string ConfigurationName { get; }

        /// <inheritdoc/>
        public override string ToString() =>
            $"[Cloud Run: ProjectId='{ProjectId}', Location='{Location}', " +
            $"ServiceName='{ServiceName}', RevisionName='{RevisionName}', ConfigurationName='{ConfigurationName}']";
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
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.
        /// Must not be <c>null</c>.</param>
        /// <returns>A populated <see cref="GcePlatformDetails"/> if the metadata represents and GCE instance;
        /// <c>null</c> otherwise.</returns>
        public static GcePlatformDetails TryLoad(string metadataJson)
        {
            GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
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
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server. Must not be <c>null</c>.</param>
        /// <param name="projectId">The project ID. Must not be <c>null</c>.</param>
        /// <param name="instanceId">The instance ID. Must not be <c>null</c>.</param>
        /// <param name="zoneName">The zone name. Must not be <c>null</c>.
        /// If this value is in the format <code>projects/&lt;project-number&gt;/zones/&lt;zone-name&gt;</code>
        /// then <see cref="Location"/> will return the <code>&lt;zone-name&gt;</code> part of this value.
        /// If not, <see cref="Location"/> will throw <see cref="InvalidOperationException"/>.
        /// If this value has been retrived from Google Compute Engine, the it's format will be the one
        /// described above.</param>
        public GcePlatformDetails(string metadataJson, string projectId, string instanceId, string zoneName)
        {
            MetadataJson = GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
            ProjectId = GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
            InstanceId = GaxPreconditions.CheckNotNull(instanceId, nameof(instanceId));
            ZoneName = GaxPreconditions.CheckNotNull(zoneName, nameof(zoneName));
        }

        /// <summary>
        /// The full JSON string retrieved from the metadata server. This is never null.
        /// </summary>
        public string MetadataJson { get; }

        /// <summary>
        /// The Project ID under which this GCE instance is running. This is never null.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        ///  The Instance ID of the GCE instance on which this is running. This is never null.
        /// </summary>
        public string InstanceId { get; }

        /// <summary>
        /// The zone where this GCE instance is running. This is never null.
        /// This will be in the format <code>projects/&lt;project-number&gt;/zones/&lt;zone-name&gt;</code>
        /// id the value has been retrieved from Google Compute Engine.
        /// </summary>
        public string ZoneName { get; }

        /// <summary>
        /// The zone name where this GCE instance is running.
        /// If <see cref="ZoneName"/> is in the format <code>projects/&lt;project-number&gt;/zones/&lt;zone-name&gt;</code>
        /// this value will be the <code>&lt;zone-name&gt;</code> part in <see cref="ZoneName"/>.
        /// If <see cref="ZoneName"/> is in a different format then this getting the value of this property will
        /// throw <see cref="InvalidOperationException"/>.
        /// </summary>
        public string Location
        {
            get
            {
                if (Platform.s_zoneTemplate.TryParseName(ZoneName, out var zoneResourceName))
                {
                    return zoneResourceName[1];
                }
                throw new InvalidOperationException($@"For {nameof(Location)} to have a value the format of {nameof(ZoneName)} 
should be projects/<project_number>/zones/<zone_name>. {nameof(ZoneName)} current value is {ZoneName}.");
            }
        }

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
        /// which is visible in the Google Cloud Platform Console. Must not be <c>null</c>.</param>
        /// <param name="gaeInstance">The name of the current instance. Must not be <c>null</c>.</param>
        /// <param name="gaeService">The service name specified in your application's app.yaml file,
        /// or if no service name is specified, it is set to default. Must not be <c>null</c>.</param>
        /// <param name="gaeVersion">The version label of the current application. Must not be <c>null</c>.</param>
        public GaePlatformDetails(string gcloudProject, string gaeInstance, string gaeService, string gaeVersion)
        {
            ProjectId = GaxPreconditions.CheckNotNull(gcloudProject, nameof(gcloudProject));
            InstanceId = GaxPreconditions.CheckNotNull(gaeInstance, nameof(gaeInstance));
            ServiceId = GaxPreconditions.CheckNotNull(gaeService, nameof(gaeService));
            VersionId = GaxPreconditions.CheckNotNull(gaeVersion, nameof(gaeVersion));
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
            /// The Kubernetes pod name
            /// </summary>
            public string PodName { get; set; }

            /// <summary>
            /// The Kubernetes namespace name
            /// </summary>
            public string NamespaceName { get; set; }

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

#if NETSTANDARD1_3 || NETSTANDARD2_0
        internal static async Task<KubernetesData> LoadKubernetesDataAsync()
        {
            var kubernetesServiceHost = Environment.GetEnvironmentVariable("KUBERNETES_SERVICE_HOST");
            int.TryParse(Environment.GetEnvironmentVariable("KUBERNETES_SERVICE_PORT"), out var kubernetesServicePort);
            var podName = Environment.GetEnvironmentVariable("HOSTNAME");
            if (string.IsNullOrEmpty(kubernetesServiceHost) || kubernetesServicePort == 0 || string.IsNullOrEmpty(podName))
            {
                // Not running on kubernetes
                return null;
            }
            // If anything following fails, then the return value will still show that we're running on kubernetes.
            var baseUrl = $"https://{kubernetesServiceHost}:{kubernetesServicePort}/api/v1";
            string kubernetesNamespace = null;
            string kubernetesToken = null;
            X509Certificate2 kubernetesCaCert = null;
            string[] mountInfo = null;
            try
            {
                kubernetesNamespace = File.ReadAllText("/var/run/secrets/kubernetes.io/serviceaccount/namespace");
                kubernetesToken = File.ReadAllText("/var/run/secrets/kubernetes.io/serviceaccount/token");
                kubernetesCaCert = new X509Certificate2("/var/run/secrets/kubernetes.io/serviceaccount/ca.crt");
                mountInfo = File.ReadAllLines("/proc/self/mountinfo");
            }
            catch
            {
                // Ignore all errors, we still return partial data.
            }
            if (string.IsNullOrEmpty(kubernetesNamespace) || string.IsNullOrEmpty(kubernetesToken) ||
                kubernetesCaCert == null || mountInfo == null || mountInfo.Length == 0)
            {
                // These files should contain useful data on GKE. If anything is missing then return what we already know.
                return new KubernetesData
                {
                    PodName = podName,
                    NamespaceName = kubernetesNamespace,
                    MountInfo = mountInfo
                };
            }

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errs) =>
                {
                    // Add the kubernetes-provided ca
                    chain.ChainPolicy.ExtraStore.Add(kubernetesCaCert);
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                    // Allow ca that is not installed on the current machine
                    // This allows *any* ca to be used, hence the following check for the kubernetes-provided ca
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                    // Check that cert is trusted, and that the root ca is the kubernetes-provided ca
                    return chain.Build(cert) && chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint == kubernetesCaCert.Thumbprint;
                }
            };
            string namespaceJson = null;
            string podJson = null;
            // TODO: Consider retrying.
            using (var client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromSeconds(1);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", kubernetesToken);
                var urlNamespace = $"{baseUrl}/namespaces/{kubernetesNamespace}";
                var urlPod = $"{baseUrl}/namespaces/{kubernetesNamespace}/pods/{podName}";
                try
                {
                    namespaceJson = await client.GetStringAsync(urlNamespace).ConfigureAwait(false);
                    podJson = await client.GetStringAsync(urlPod).ConfigureAwait(false);
                }
                catch
                {
                    // Ignore all errors
                }
            }
            return new KubernetesData
            {
                PodName = podName,
                NamespaceName = kubernetesNamespace,
                NamespaceJson = namespaceJson,
                PodJson = podJson,
                MountInfo = mountInfo
            };
        }
#elif NET45
        internal static Task<KubernetesData> LoadKubernetesDataAsync()
        {
            // .NET45 code cannot currently run on Kubernetes.
            // And .NET45 does not support the certificate functionality that we require.
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
        /// This method attempts to return as much information as it is present on <paramref name="metadataJson"/>
        /// and <paramref name="kubernetesData"/> but will return <see cref="string.Empty"/> for <see cref="GkePlatformDetails"/>
        /// properties whose corresponding information is corrupt or missing in <paramref name="metadataJson"/>
        /// or <paramref name="kubernetesData"/>.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.
        /// Must not be <c>null</c>.</param>
        /// <param name="kubernetesData">Kubernetes data, normally retrieved using the kubernetes API.
        /// Must not be <c>null</c>.</param>
        /// <returns>A populated <see cref="GkePlatformDetails"/> if the metadata represents and GKE instance;
        /// <c>null</c> otherwise.</returns>
        public static GkePlatformDetails TryLoad(string metadataJson, KubernetesData kubernetesData)
        {
            GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
            GaxPreconditions.CheckNotNull(kubernetesData, nameof(kubernetesData));
            JObject metadata = null;
            JObject namespaceData = null;
            JObject podData = null;
            // Parse JSON, ignoring all errors; partially available data is supported
            try { metadata = JObject.Parse(metadataJson); } catch { }
            try { namespaceData = JObject.Parse(kubernetesData.NamespaceJson); } catch { }
            try { podData = JObject.Parse(kubernetesData.PodJson); } catch { }
            if (metadata == null)
            {
                // Metadata is required. If it's not present, or the JSON cannot be parsed, return null.
                return null;
            }
            if (namespaceData?["kind"]?.Value<string>() != "Namespace")
            {
                // If namespaceData looks corrupt/incomplete, ignore it.
                namespaceData = null;
            }
            if (podData?["kind"]?.Value<string>() != "Pod")
            {
                // If podData looks corrupt/incomplete, ignore it.
                podData = null;
            }
            var hostName = kubernetesData.PodName ?? podData?["metadata"]?["name"]?.Value<string>() ?? ""; // Pod name is the hostname
            var projectId = metadata["project"]?["projectId"]?.Value<string>();
            var clusterName = metadata["instance"]?["attributes"]?["cluster-name"]?.Value<string>();
            var instanceId = metadata["instance"]?["id"]?.Value<string>();
            var zone = metadata["instance"]?["zone"]?.Value<string>();
            var namespaceId = namespaceData?["metadata"]?["name"]?.Value<string>() ?? kubernetesData.NamespaceName ?? "";
            var podId = podData?["metadata"]?["name"]?.Value<string>() ?? kubernetesData.PodName ?? "";
            var podUid = podData?["metadata"]?["uid"]?.Value<string>() ?? "";
            // A hack to find the container name. There appears to be no official way to do this.
            var regex = new Regex($"/var/lib/kubelet/pods/{podUid}/containers/([^/]+)/.*/dev/termination-log");
            var containerNames = kubernetesData.MountInfo?.Select(x =>
            {
                var match = regex.Match(x);
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
                return null;
            }).Where(x => x != null).ToList();
            var containerName = containerNames?.Count == 1 ? containerNames[0] : "";
            if (hostName != null && projectId != null && clusterName != null && instanceId != null &&
                zone != null && namespaceId != null && podId != null && containerName != null)
            {
                if (Platform.s_zoneTemplate.TryParseName(zone, out var zoneResourceName))
                {
                    return new GkePlatformDetails(metadataJson, projectId, clusterName, zoneResourceName[1], hostName,
                        instanceId, zone, namespaceId, podId, containerName);
                }
            }
            return null;
        }

        /// <summary>
        /// Construct details of Google Container (Kubernetes) Engine
        /// </summary>
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server. Must not be <c>null</c>.</param>
        /// <param name="projectId">The project ID. Must not be <c>null</c>.</param>
        /// <param name="clusterName">The cluster name. Must not be <c>null</c>.</param>
        /// <param name="location">The location. Must not be <c>null</c>.</param>
        /// <param name="hostName">The instance host name. Must not be <c>null</c>.</param>
        [Obsolete("Only partially fills instance with data; use alternative constructor.")]
        public GkePlatformDetails(string metadataJson, string projectId, string clusterName, string location, string hostName)
            : this(metadataJson, projectId, clusterName, location, hostName, "", "", "", "", "")
        {
        }

        /// <summary>
        /// Construct details of Google Container (Kubernetes) Engine
        /// </summary>
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server. Must not be <c>null</c>.</param>
        /// <param name="projectId">The project ID. Must not be <c>null</c>.</param>
        /// <param name="clusterName">The cluster name. Must not be <c>null</c>.</param>
        /// <param name="location">The location. Must not be <c>null</c>.</param>
        /// <param name="hostName">The instance host name. Must not be <c>null</c>.</param>
        /// <param name="instanceId">The GCE instance ID. Must not be <c>null</c>.</param>
        /// <param name="zone">The zone. Must not be <c>null</c>.</param>
        /// <param name="namespaceId">The kubernetes namespace ID. Must not be <c>null</c>.</param>
        /// <param name="podId">The kubernetes pod ID. Must not be <c>null</c>.</param>
        /// <param name="containerName">The container name. Must not be <c>null</c>.</param>
        public GkePlatformDetails(string metadataJson, string projectId, string clusterName, string location, string hostName,
            string instanceId, string zone, string namespaceId, string podId, string containerName)
        {
            MetadataJson = GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
            ProjectId = GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
            ClusterName = GaxPreconditions.CheckNotNull(clusterName, nameof(clusterName));
            Location = GaxPreconditions.CheckNotNull(location, nameof(location));
            HostName = GaxPreconditions.CheckNotNull(hostName, nameof(hostName));
            InstanceId = GaxPreconditions.CheckNotNull(instanceId, nameof(instanceId));
            Zone = GaxPreconditions.CheckNotNull(zone, nameof(zone));
            NamespaceId = GaxPreconditions.CheckNotNull(namespaceId, nameof(namespaceId));
            PodId = GaxPreconditions.CheckNotNull(podId, nameof(podId));
            ContainerName = GaxPreconditions.CheckNotNull(containerName, nameof(containerName));
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
        /// This is equivalent to the value of the <code>&lt;zone-name&gt;</code> part in
        /// <see cref="Zone"/>
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
        /// This is in the format <code>projects/&lt;project-number&gt;/zones/&lt;zone-name&gt;</code>.
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
        internal static readonly PathTemplate s_zoneTemplate = new PathTemplate("projects/*/zones/*");
        private static readonly Lazy<Task<Platform>> s_instance = new Lazy<Task<Platform>>(LoadInstanceAsync);

        /// <summary>
        /// Asyncrhonously get execution platform information.
        /// </summary>
        /// <returns>A task containing the execution platform information.</returns>
        public static Task<Platform> InstanceAsync() => s_instance.Value;

        /// <summary>
        /// Get execution platform information. This may block briefly while network operations are in progress.
        /// </summary>
        /// <returns>Execution platform information.</returns>
        public static Platform Instance() => InstanceAsync().Result;

        private static async Task<string> LoadMetadataAsync()
        {
            // Check if emulator is in use by looking for an emulator host in environment variable
            // METADATA_EMULATOR_HOST. This is the undocumented but the de-facto mechanism for doing this.
            var metadataEmulatorHost = Environment.GetEnvironmentVariable("METADATA_EMULATOR_HOST");
            // Use the IP address rather than the IP name to avoid a DNS lookup, which can cause intermittent failures.
            const string metadataHost = "169.254.169.254";
            const string metadataFlavorKey = "Metadata-Flavor";
            const string metadataFlavorValue = "Google";
            const int metadataServerPingAttempts = 3;
            const long maxContentLength = 512 * 1024; // Maximum allowed metadata size.
            // Reasonably short timeout; we sometimes see a first request take over a second if left to its own devices, but
            // a retry is fast.
            TimeSpan timeout = TimeSpan.FromMilliseconds(500);

            var effectiveMetadataHost = string.IsNullOrEmpty(metadataEmulatorHost) ? metadataHost : metadataEmulatorHost;
            var metadataUrl = $"http://{effectiveMetadataHost}/computeMetadata/v1?recursive=true";
            // Using the built-in HttpClient, as we want bare bones functionality - we'll control retries.
            // Use the same one across all attempts, which may contribute to speedier retries.
            using (var httpClient = new HttpClient())
            {
                for (int i = 0; i < metadataServerPingAttempts; i++)
                {
                    try
                    {
                        var cts = new CancellationTokenSource(timeout);
                        var httpRequest = new HttpRequestMessage(HttpMethod.Get, metadataUrl);
                        httpRequest.Headers.Add(metadataFlavorKey, metadataFlavorValue); // Required for any query.
                        var response = await httpClient.SendAsync(httpRequest, cts.Token).ConfigureAwait(false);
                        if (response.StatusCode == HttpStatusCode.OK
                            && response.Headers.TryGetValues(metadataFlavorKey, out var metadataValues)
                            && metadataValues.Contains(metadataFlavorValue)
                            && response.Content.Headers.ContentLength < maxContentLength)
                        {
                            // Valid response from metadata server.
                            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        }
                    }
                    catch
                    {
                        // No-op; we'll retry.
                        // Possible exceptions, in all cases there's nothing we can do except
                        // assume we're not running on GCE, and hence return null after retrying.
                        // OperationCanceledException: on timeout
                        // HttpRequestException: On general request failure
                        // WebException: DNS problem on Mono
                        // TODO: Decide what to do here.
                    }
                }
                // Multiple attempts failed.
                return null;
            }
        }

        private static GaePlatformDetails LoadGaeDetails()
        {
            // See https://cloud.google.com/appengine/docs/flexible/dotnet/runtime#environment_variables
            // for details on environment variables.
            var gcloudProject = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT") ?? Environment.GetEnvironmentVariable("GCLOUD_PROJECT");
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
                if (kubernetesData != null)
                {
                    GkePlatformDetails gkeDetails = GkePlatformDetails.TryLoad(metadataJson, kubernetesData);
                    if (gkeDetails != null)
                    {
                        return new Platform(gkeDetails);
                    }
                }
                GcePlatformDetails gceDetails = GcePlatformDetails.TryLoad(metadataJson);
                if (gceDetails != null)
                {
                    return new Platform(gceDetails);
                }
                CloudRunPlatformDetails cloudRunDetails = CloudRunPlatformDetails.TryLoad(metadataJson);
                if (cloudRunDetails != null)
                {
                    return new Platform(cloudRunDetails);
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
        /// Construct with details of Google Cloud Run.
        /// </summary>
        /// <param name="cloudRunDetails">Details of Google Cloud Run.</param>
        public Platform(CloudRunPlatformDetails cloudRunDetails)
        {
            CloudRunDetails = GaxPreconditions.CheckNotNull(cloudRunDetails, nameof(cloudRunDetails));
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
        /// Google Cloud Run platform details.
        /// <c>null</c> if not executing on Google Cloud Run. 
        /// </summary>
        public CloudRunPlatformDetails CloudRunDetails { get; }

        /// <summary>
        /// The current execution platform.
        /// </summary>
        public PlatformType Type =>
            GaeDetails != null ? PlatformType.Gae :
            GceDetails != null ? PlatformType.Gce :
            GkeDetails != null ? PlatformType.Gke :
            CloudRunDetails != null ? PlatformType.CloudRun :
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
                case PlatformType.CloudRun:
                    return CloudRunDetails.ToString();
                case PlatformType.Unknown:
                    return "[Unknown platform]";
                default:
                    return $"[Unknown platform type: '{Type}']";
            }
        }
    }
}
