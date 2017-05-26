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
using System.Net.Http;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;

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
        private static readonly PathTemplate s_zoneTemplate = new PathTemplate("projects/*/zones/*");

        /// <summary>
        /// Builds a <see cref="GkePlatformDetails"/> from the given metadata.
        /// This metadata is normally retrieved from the GCE metadata server.
        /// </summary>
        /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.</param>
        /// <returns>A populated <see cref="GkePlatformDetails"/> if the metadata represents and GKE instance;
        /// <c>null</c> otherwise.</returns>
        public static GkePlatformDetails TryLoad(string metadataJson)
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
            var clusterName = metadata["instance"]?["attributes"]?["cluster-name"]?.ToString();
            var zone = metadata["instance"]?["zone"]?.ToString();
            var hostName = metadata["instance"]?["hostname"]?.ToString();
            if (projectId != null && clusterName != null && zone != null)
            {
                TemplatedResourceName zoneResourceName;
                if (s_zoneTemplate.TryParseName(zone, out zoneResourceName))
                {
                    return new GkePlatformDetails(metadataJson, projectId, clusterName, zoneResourceName[1], hostName);
                }
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
        public GkePlatformDetails(string metadataJson, string projectId, string clusterName, string location, string hostName)
        {
            MetadataJson = metadataJson;
            ProjectId = projectId;
            ClusterName = clusterName;
            Location = location;
            HostName = hostName;
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

        /// <inheritdoc/>
        public override string ToString() =>
            $"[GKE: ProjectId='{ProjectId}', ClusterName='{ClusterName}', Location='{Location}', HostName='{HostName}']";
    }

    /// <summary>
    /// Information about the current execution platform.
    /// Supported execption platforms are Google App Engine (GAE) and Google Compute Engine (GCE).
    /// </summary>
    public sealed class Platform
    {
        private readonly static Lazy<Task<Platform>> s_instance = new Lazy<Task<Platform>>(LoadInstance);

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

        private static async Task<Platform> LoadInstance()
        {
            // The order matters here:
            // * GAE runs on GCE, so do GAE before GCE.
            // * GKE runs on GCE, so do GKE before GCE.
            // * Metadata server access can take time, so to GAE first.
            GaePlatformDetails gaeDetails = LoadGaeDetails();
            if (gaeDetails != null)
            {
                return new Platform(gaeDetails);
            }
            var metadataJson = await LoadMetadataAsync().ConfigureAwait(false);
            if (metadataJson != null)
            {
                GkePlatformDetails gkeDetails = GkePlatformDetails.TryLoad(metadataJson);
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
