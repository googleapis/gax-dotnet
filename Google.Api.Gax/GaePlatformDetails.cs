/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax
{
    /// <summary>
    /// Google App Engine details.
    /// </summary>
    public sealed class GaePlatformDetails
    {
        /// <summary>
        /// Construct details of Google App Engine
        /// </summary>
        /// <param name="gcloudProject">The Project ID associated with your application,
        /// which is visible in the Google Cloud Console. Must not be <c>null</c>.</param>
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
        /// The Project ID associated with your application, which is visible in the Google Cloud Console.
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
}
