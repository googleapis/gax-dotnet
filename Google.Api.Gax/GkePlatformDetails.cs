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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
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

#if NETSTANDARD2_0
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
#elif NET461
        internal static Task<KubernetesData> LoadKubernetesDataAsync()
        {
            // TODO: See if we can support Kubernetes on .NET 4.6.1
            // (We'll need to check support for certificates.)
            return Task.FromResult<KubernetesData>(null);
        }
#else
#error Unsupported platform
#endif

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
}
