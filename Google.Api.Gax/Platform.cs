/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
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
