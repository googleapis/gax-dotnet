/*
 * Copyright 2019 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Newtonsoft.Json.Linq;
using System;

namespace Google.Api.Gax
{
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
            // Check environment variables first, to avoid more expensive JSON parsing.
            string serviceName = Environment.GetEnvironmentVariable("K_SERVICE");
            string revisionName = Environment.GetEnvironmentVariable("K_REVISION");
            string configurationName = Environment.GetEnvironmentVariable("K_CONFIGURATION");
            if (serviceName is null || revisionName is null || configurationName is null)
            {
                return null;
            }

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


}
