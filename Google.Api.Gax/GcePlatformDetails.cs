/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Newtonsoft.Json.Linq;
using System;

namespace Google.Api.Gax
{
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
}
