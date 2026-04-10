/*
 * Copyright 2026 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Google.Api.Gax;

/// <summary>
/// Google Cloud Run Job details.
/// </summary>
public sealed class CloudRunJobPlatformDetails
{
    /// <summary>
    /// Builds a <see cref="CloudRunJobPlatformDetails"/> from the given metadata
    /// and Cloud Run Job environment variables.
    /// The metadata is normally retrieved from the GCE metadata server.
    /// </summary>
    /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.
    /// Must not be <c>null</c>.</param>
    /// <returns>A populated <see cref="CloudRunJobPlatformDetails"/> if the metadata represents a Cloud Run Job;
    /// <c>null</c> otherwise.</returns>
    public static CloudRunJobPlatformDetails TryLoad(string metadataJson)
    {
        // Check environment variables first, to avoid more expensive JSON parsing.
        string jobName = Environment.GetEnvironmentVariable("CLOUD_RUN_JOB");
        if (jobName is null)
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
        string zone = zoneResourceName[1];
        return new CloudRunJobPlatformDetails(metadataJson, projectId, zone, jobName);
    }

    /// <summary>
    /// Constructs details of a Google Cloud Run job execution.
    /// </summary>
    /// <param name="metadataJson">JSON metadata, normally retrieved from the GCE metadata server.
    /// Must not be <c>null</c>.</param>
    /// <param name="projectId">The project ID. Must not be null.</param>
    /// <param name="zone">The zone in which the job code is running. Must not be null.</param>
    /// <param name="jobName">The name of the job. Must not be null.</param>
    public CloudRunJobPlatformDetails(string metadataJson, string projectId, string zone, string jobName)
    {
        MetadataJson = GaxPreconditions.CheckNotNull(metadataJson, nameof(metadataJson));
        ProjectId = GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
        Zone = GaxPreconditions.CheckNotNull(zone, nameof(zone));
        Region = string.Join("-", Zone.Split('-').Take(2));
        JobName = GaxPreconditions.CheckNotNull(jobName, nameof(jobName));
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
    /// The zone of the service, e.g. "us-central1-1". This is never null.
    /// </summary>
    public string Zone { get; }

    /// <summary>
    /// The region part of the zone. For example, a zone of "us-central1-1" has a region
    /// of "us-central1".
    /// </summary>
    public string Region { get; }

    /// <summary>
    /// The name of the Cloud Run job being run. This is never null.
    /// </summary>
    public string JobName { get; }

    /// <inheritdoc/>
    public override string ToString() =>
        $"[Cloud Run Job: ProjectId='{ProjectId}', Zone='{Zone}', JobName='{JobName}']";
}
