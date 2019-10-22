/*
 * Copyright 2019 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Centralized 
    /// </summary>
    internal static class StabilityHeaders
    {
        private static readonly Dictionary<LaunchStage, CallSettings> s_stabilityVisibilityLabels =
            new Dictionary<LaunchStage, CallSettings>
        {
            { LaunchStage.Alpha, CallSettingsForVisibility("STABILITY_ALPHA") },
            { LaunchStage.Beta, CallSettingsForVisibility("STABILITY_BETA") },
            { LaunchStage.Ga, null }
        };

        private static CallSettings CallSettingsForVisibility(string visibility) =>
            CallSettings.FromHeader("X-Goog-Visibilities", visibility);

        /// <summary>
        /// Returns the call settings to apply for the given stability level.
        /// </summary>
        /// <param name="stability">The stability level to apply.</param>
        /// <exception cref="ArgumentOutOfRangeException">The given launch stage isn't a valid stability level.</exception>
        /// <returns>The call settings to apply for the stability level, or null if no call settings are required.</returns>
        internal static CallSettings CallSettingsForStability(LaunchStage stability) =>
            s_stabilityVisibilityLabels.TryGetValue(stability, out var settings)
            ? settings
            : throw new ArgumentOutOfRangeException($"Invalid launch stage for stability: {stability}");
    }
}
