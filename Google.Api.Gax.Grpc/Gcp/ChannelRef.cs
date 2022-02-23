// Copyright 2018 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Grpc.Core;
using System.Threading;

namespace Grpc.Gcp
{
    /// <summary>
    /// Keeps record of channel affinity and active streams.
    /// This class is thread-safe.
    /// </summary>
    internal sealed class ChannelRef
    {
        private int affinityCount;
        private int activeStreamCount;
        private int id;

        public ChannelRef(Channel channel, int id, int affinityCount = 0, int activeStreamCount = 0)
        {
            Channel = channel;
            this.id = id;
            this.affinityCount = affinityCount;
            this.activeStreamCount = activeStreamCount;
        }

        internal Channel Channel { get; }
        internal int AffinityCount => Interlocked.CompareExchange(ref affinityCount, 0, 0);
        internal int ActiveStreamCount => Interlocked.CompareExchange(ref activeStreamCount, 0, 0);

        internal int AffinityCountIncr() => Interlocked.Increment(ref affinityCount);
        internal int AffinityCountDecr() => Interlocked.Decrement(ref affinityCount);
        internal int ActiveStreamCountIncr() => Interlocked.Increment(ref activeStreamCount);
        internal int ActiveStreamCountDecr() => Interlocked.Decrement(ref activeStreamCount);

        internal ChannelRef Clone() => new ChannelRef(Channel, id, AffinityCount, ActiveStreamCount);
    }
}
 