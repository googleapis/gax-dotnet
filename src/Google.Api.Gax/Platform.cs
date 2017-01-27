using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;

namespace Google.Api.Gax
{
    public enum PlatformType
    {
        Unknown = 0,
        Gce = 1,
        Gae = 2,
    }

    public sealed class GcePlatformDetails
    {
        public GcePlatformDetails(string metadataJson)
        {
            MetadataJson = metadataJson;
            var json = Newtonsoft.Json.Linq.JObject.Parse(metadataJson);
            ProjectId = json["project"]["projectId"].ToString();
            InstanceId = json["instance"]["id"].ToString();
            ZoneName = json["instance"]["zone"].ToString();
        }

        public string MetadataJson { get; }
        public string ProjectId { get; }
        public string InstanceId { get; }
        public string ZoneName { get; }
    }

    public sealed class GaePlatformDetails
    {
        public GaePlatformDetails(string gcloudProject, string gaeInstance, string gaeVersion)
        {
            ProjectId = gcloudProject;

        }

        public string ProjectId { get; }
        public string ModuleId { get; }
        public string VersionId { get; }
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
            const string metadataUrl = "http://metadata.google.internal/computeMetadata/v1?recursive=true";
            const string metadataFlavorKey = "Metadata-Flavor";
            const string metadataFlavorValue = "Google";
            const long maxContentLength = 512 * 1024; // Maximum allowed metadata size.
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, metadataUrl);
            httpRequest.Headers.Add(metadataFlavorKey, metadataFlavorValue); // Required for any query.
            var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(1000)); // 1000 found to be reasonable.
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(httpRequest, cts.Token);
            IEnumerable<string> metadataValues;
            if (response.StatusCode == HttpStatusCode.OK
                && response.Content.Headers.TryGetValues(metadataFlavorKey, out metadataValues)
                && metadataValues.Contains(metadataFlavorValue)
                && response.Content.Headers.ContentLength < maxContentLength)
            {
                // Valid response from metadata server.
                string metadataJson = await response.Content.ReadAsStringAsync();
                try
                {
                    return new GcePlatformDetails(metadataJson);
                }
                catch
                {
                    // TODO: How to log problems?
                }
            }
            return null;
        }

        private static GaePlatformDetails LoadGaeDetails()
        {
            // See https://cloud.google.com/appengine/docs/flexible/python/runtime#environment_variables
            // for details on environment variables.
            var gcloudProject = Environment.GetEnvironmentVariable("GCLOUD_PROJECT");
            var gaeInstance = Environment.GetEnvironmentVariable("GAE_INSTANCE");
            var gaeVersion = Environment.GetEnvironmentVariable("GAE_VERSION");
            if (gcloudProject != null && gaeInstance != null && gaeVersion != null)
            {
                return new GaePlatformDetails(gcloudProject, gaeInstance, gaeVersion);
            }
            return null;
        }

        private static async Task<Platform> LoadInstance()
        {
            // The order matters here, for two reasons:
            // * The GCE detection will probably also detect GAE, so GAE must be done first.
            // * GCE detection can take time, so to GAE first.
            GaePlatformDetails gaeDetails = LoadGaeDetails();
            GcePlatformDetails gceDetails = gaeDetails == null ? await LoadGceDetails() : null;
            return new Platform(gaeDetails, gceDetails);
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

    }
}
