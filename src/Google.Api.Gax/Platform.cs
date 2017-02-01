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

        // TODO: Add GKE if/when possible.
    }

    /// <summary>
    /// Google Compute Engine details.
    /// </summary>
    public sealed class GcePlatformDetails
    {
        /// <summary>
        /// Construct details of Google Compute Engine
        /// </summary>
        /// <param name="metadataJson">The full JSON string retrieved from the metadata server.</param>
        public GcePlatformDetails(string metadataJson)
        {
            MetadataJson = metadataJson;
            var json = Newtonsoft.Json.Linq.JObject.Parse(metadataJson);
            ProjectId = json["project"]["projectId"].ToString();
            InstanceId = json["instance"]["id"].ToString();
            ZoneName = json["instance"]["zone"].ToString();
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

        private static async Task<GcePlatformDetails> LoadGceDetails()
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
                var response = await httpClient.SendAsync(httpRequest, cts.Token); // TODO: Consider retrying on IO Exception.
                IEnumerable<string> metadataValues;
                if (response.StatusCode == HttpStatusCode.OK
                    && response.Headers.TryGetValues(metadataFlavorKey, out metadataValues)
                    && metadataValues.Contains(metadataFlavorValue)
                    && response.Content.Headers.ContentLength < maxContentLength)
                {
                    // Valid response from metadata server.
                    string metadataJson = await response.Content.ReadAsStringAsync();
                    return new GcePlatformDetails(metadataJson);
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
            // The order matters here, for two reasons:
            // * The GCE detection will probably also detect GAE, so GAE must be done first.
            // * GCE detection can take time, so to GAE first.
            GaePlatformDetails gaeDetails = LoadGaeDetails();
            if (gaeDetails != null)
            {
                return new Platform(gaeDetails, null);
            }
            GcePlatformDetails gceDetails = await LoadGceDetails();
            if (gceDetails != null)
            {
                return new Platform(null, gceDetails);
            }
            return new Platform(null, null);
        }

        private Platform(GaePlatformDetails gaeDetails, GcePlatformDetails gceDetails)
        {
            GaeDetails = gaeDetails;
            GceDetails = gceDetails;
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
        /// The current execution platform.
        /// </summary>
        public PlatformType Type =>
            GaeDetails != null ? PlatformType.Gae :
            GceDetails != null ? PlatformType.Gce :
            PlatformType.Unknown;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case PlatformType.Gae:
                    return GaeDetails.ToString();
                case PlatformType.Gce:
                    return GceDetails.ToString();
                case PlatformType.Unknown:
                    return "[Unknown platform]";
                default:
                    return "[Unknown platform type]";
            }
        }
    }
}
