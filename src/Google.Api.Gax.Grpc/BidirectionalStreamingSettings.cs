/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings for bidirectional streaming.
    /// </summary>
    public sealed class BidirectionalStreamingSettings
    {
        /// <summary>
        /// Configure settings for bidirectional streaming.
        /// </summary>
        /// <param name="bufferedClientWriterCapacity">The capacity of the write buffer.</param>
        public BidirectionalStreamingSettings(
            int bufferedClientWriterCapacity)
        {
            BufferedClientWriterCapacity = bufferedClientWriterCapacity;
        }

        /// <summary>
        /// The capacity of the write buffer, that locally buffers streaming requests
        /// before they are sent to the server.
        /// </summary>
        public int BufferedClientWriterCapacity { get; }
    }
}
