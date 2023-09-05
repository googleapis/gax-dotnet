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
using System.Net.Security;
#if NET462
using System.Reflection;
#endif
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

        internal static async Task<KubernetesData> LoadKubernetesDataAsync()
        {
            var kubernetesServiceHost = Environment.GetEnvironmentVariable("KUBERNETES_SERVICE_HOST");
            int.TryParse(Environment.GetEnvironmentVariable("KUBERNETES_SERVICE_PORT"), out var kubernetesServicePort);
            var podName = Environment.GetEnvironmentVariable("HOSTNAME");

            // Kubernetes Windows doesn't populate HOSTNAME. It populate COMPUTERNAME, but not with
            // the full podname. Dns.GetHostName() returns the full value, but we need to guard against it throwing.
            if (string.IsNullOrEmpty(podName))
            {
                try
                {
                    podName = Dns.GetHostName();
                }
                catch
                {
                    // Leave it empty; we'll end up returning null.
                }
            }

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
                // On Windows GKE, we currently fail to load this certificate - so just skipping even an attempt
                // when on .NET Framework seems reasonable.
#if NETSTANDARD2_1_OR_GREATER
                kubernetesCaCert = new X509Certificate2("/var/run/secrets/kubernetes.io/serviceaccount/ca.crt");
#elif NET462
#else
#error Unsupported platform
#endif
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

            Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> serverCertificateCustomValidationCallback =
                (msg, cert, chain, errs) =>
                {
                    // Add the kubernetes-provided ca
                    chain.ChainPolicy.ExtraStore.Add(kubernetesCaCert);
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                    // Allow ca that is not installed on the current machine
                    // This allows *any* ca to be used, hence the following check for the kubernetes-provided ca
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                    // Check that cert is trusted, and that the root ca is the kubernetes-provided ca
                    return chain.Build(cert) && chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint == kubernetesCaCert.Thumbprint;
                };
            var handler = new HttpClientHandler();
#if NETSTANDARD2_1_OR_GREATER
            handler.ServerCertificateCustomValidationCallback = serverCertificateCustomValidationCallback;
#elif NET462
            // .NET 4.6.2 supposedly supports .NET Standard (which defines HttpClientHandler.ServerCertificateCustomValidationCallback),
            // but doesn't actually have that property. On the othe hand, it's possible that we're using this build of the library due to
            // targeting a later version of .NET Framework.
            // Rather than adding another target just for this oddity, let's set the property by reflection if we can.
            // If we can't, the HTTP call is likely to fail below, but we'll handle it in the same way as anything else.
            var callbackProperty = typeof(HttpClientHandler).GetProperty("ServerCertificateCustomValidationCallback", BindingFlags.Instance | BindingFlags.Public);
            if (callbackProperty?.CanWrite == true && callbackProperty.GetSetMethod().IsPublic)
            {
                callbackProperty.SetValue(handler, serverCertificateCustomValidationCallback);
            }
#else
#error Unsupported platform
#endif
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
            var instanceZone = metadata["instance"]?["zone"]?.Value<string>();
            var clusterLocation = metadata["instance"]?["attributes"]?["cluster-location"]?.Value<string>();
            var namespaceId = namespaceData?["metadata"]?["name"]?.Value<string>() ?? kubernetesData.NamespaceName ?? "";
            var podId = podData?["metadata"]?["name"]?.Value<string>() ?? kubernetesData.PodName ?? "";

            // Note: unlike other variables, we keep null as null here - we're not propagating it anywhere beyond the DeriveContainerName method.
            var podUid = podData?["metadata"]?["uid"]?.Value<string>();
            var containerName = DeriveContainerName(podUid, kubernetesData.MountInfo) ?? "";

            if (hostName != null && projectId != null && clusterName != null && instanceId != null &&
                instanceZone != null && clusterLocation != null && namespaceId != null && podId != null && containerName != null)
            {
                if (Platform.s_zoneTemplate.TryParseName(instanceZone, out var instanceLocation))
                {
                    return new GkePlatformDetails(metadataJson, projectId, clusterName, instanceLocation[1], hostName,
                        instanceId, instanceZone, namespaceId, podId, containerName, clusterLocation);
                }
            }
            return null;
        }

        // A hack to find the container name. There appears to be no official way to do this.
        private static readonly Regex s_mountInfoPathPattern = new Regex("/var/lib/kubelet/pods/(?<uid>[^/]+)/containers/(?<container>[^/]+)/.*");

        private static string DeriveContainerName(string podUid, string[] mountInfoLines)
        {
            if (mountInfoLines is null)
            {
                return null;
            }

            // We expect to find exactly one /dev/termination-log line in the mount info.
            // If we have a pod UID, we check it matches. If we don't have a pod UID, we'll just assume it's okay.
            var nameAndUidEntries = mountInfoLines
                    .Select(GetContainerNameAndPodUidFromMountInfoLine)
                    .Where(pair => pair.name is object)
                    .Take(2)
                    .ToList();

            if (nameAndUidEntries.Count != 1)
            {
                return null;
            }
            
            var (name, actualUid) = nameAndUidEntries[0];
            return podUid is null || podUid == actualUid ? name : null;
            
            static (string name, string uid) GetContainerNameAndPodUidFromMountInfoLine(string line)
            {
                if (!line.Contains(" /dev/termination-log "))
                {
                    return default;
                }
                string[] bits = line.Split(' ');
                if (bits.Length < 5 || bits[4] != "/dev/termination-log")
                {
                    return default;
                }
                var match = s_mountInfoPathPattern.Match(bits[3]);
                return match.Success
                    ? (name: match.Groups["container"].Value, uid: match.Groups["uid"].Value)
                    : default;
            }
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
        /// <param name="clusterLocation">The location of the cluster. Must not be null.</param>
        public GkePlatformDetails(string metadataJson, string projectId, string clusterName, string location, string hostName,
            string instanceId, string zone, string namespaceId, string podId, string containerName, string clusterLocation)
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
            ClusterLocation = GaxPreconditions.CheckNotNull(clusterLocation, nameof(clusterLocation));
        }

        /// <summary>
        /// The full JSON string retrieved from the metadata server.
        /// </summary>
        public string MetadataJson { get; }

        /// <summary>
        /// The Project ID associated with your application, which is visible in the Google Cloud Console.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// The cluster name, which is visible in the Google Cloud Console.
        /// </summary>
        public string ClusterName { get; }

        /// <summary>
        /// The cluster location, which is visible in the Google Cloud Console.
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

        /// <summary>
        /// The location of the cluster.
        /// May be different from node / pod location.
        /// </summary>
        public string ClusterLocation { get; }

        /// <inheritdoc/>
        public override string ToString() =>
            $"[GKE: ProjectId='{ProjectId}', ClusterLocation='{ClusterLocation}', ClusterName='{ClusterName}', HostName='{HostName}', " +
            $"InstanceId='{InstanceId}', Zone='{Zone}', NamespaceId='{NamespaceId}', PodId='{PodId}', ContainerName='{ContainerName}']";
    }
}
