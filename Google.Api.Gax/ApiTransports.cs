/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// The transports that can be used to make calls to an API.
    /// </summary>
    [Flags]
    public enum ApiTransports
    {
        /// <summary>
        /// No transports specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// Native gRPC support via binary protobuf serialization.
        /// </summary>
        Grpc = 1,

        /// <summary>
        /// "REST"-like support via JSON.
        /// </summary>
        Rest = 2
    }
}
