/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */


namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientStreamingSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferedClientWriterCapacity"></param>
        public ClientStreamingSettings(int bufferedClientWriterCapacity)
        {
            BufferedClientWriterCapacity = bufferedClientWriterCapacity;
        }

        /// <summary>
        /// 
        /// </summary>
        public int BufferedClientWriterCapacity { get; }
    }
}
