/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

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

        /// <summary>
        /// Execution platform is Google Cloud Run.
        /// </summary>
        CloudRun = 4
    }
}
