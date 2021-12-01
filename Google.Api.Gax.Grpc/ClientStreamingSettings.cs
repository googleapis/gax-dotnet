/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */


namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings for client streaming.
    /// </summary>
    public sealed class ClientStreamingSettings
    {
        /// <summary>
        /// Configure settings for client streaming.
        /// </summary>
        /// <param name="bufferedClientWriterCapacity"></param>
        public ClientStreamingSettings(int bufferedClientWriterCapacity)
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
