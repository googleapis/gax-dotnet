/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings used to control data flow.
    /// </summary>
    /// <remarks>
    /// The precise meaning of the settings in this class
    /// is context-sensitive. For example, when used by a library which creates multiple
    /// streams of data, the flow control settings may restrict flow on a per-stream basis,
    /// or on an aggregate basis. Please consult the documentation of the library that consumes
    /// these settings for more details on how they're used in that context.
    /// </remarks>
    public sealed class FlowControlSettings
    {
        /// <summary>
        /// Creates a new instance with the specified settings.
        /// </summary>
        /// <param name="maxOutstandingElementCount">The maximum number of elements that can be outstanding before data flow is restricted, or
        /// null if there is no specified limit.</param>
        /// <param name="maxOutstandingByteCount">The maximum number of bytes that can be outstanding before data flow is restricted, or
        /// null if there is no specified limit.</param>
        public FlowControlSettings(long? maxOutstandingElementCount, long? maxOutstandingByteCount)
        {
            MaxOutstandingElementCount = GaxPreconditions.CheckNonNegative(maxOutstandingElementCount, nameof(maxOutstandingElementCount));
            MaxOutstandingByteCount = GaxPreconditions.CheckNonNegative(maxOutstandingByteCount, nameof(maxOutstandingByteCount));
        }

        /// <summary>
        /// The maximum number of elements that can be outstanding before data flow is restricted, or
        /// null if there is no specified limit.
        /// </summary>
        public long? MaxOutstandingElementCount { get; }

        /// <summary>
        /// The maximum number of bytes that can be outstanding before data flow is restricted, or
        /// null if there is no specified limit.
        /// </summary>
        public long? MaxOutstandingByteCount { get; }
    }
}
