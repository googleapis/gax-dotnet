/*
 * Copyright 2018 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;

namespace Google.Api.Gax.Grpc.Gcp
{
    /// <summary>
    /// Keeps record of channel affinity and active streams.
    /// This class is thread-safe.
    /// </summary>
    internal sealed class ChannelRef
    {
        private int _affinityCount;
        private int _activeStreamCount;
        internal int _id;
        internal Guid _channelId;
        public  DateTime ChannelStartTime { get; set; }
        public Action<CallInvoker> ChannelPrimer { get; set; }
        public bool Grace { get; set; }

        internal ChannelRef(ChannelBase channel, int id, int affinityCount = 0, int activeStreamCount = 0, Action<CallInvoker> channelPrimer = null, Guid channelId = default)
        {
            Channel = channel;
            CallInvoker = channel.CreateCallInvoker();
            ChannelStartTime = DateTime.UtcNow;
            this._id = id;
            this._affinityCount = affinityCount;
            this._activeStreamCount = activeStreamCount;
            ChannelPrimer = channelPrimer;
            Grace = false;
            
            // prime the channel if the primer is set.
            if (ChannelPrimer != null)
            {
                ChannelPrimer(CallInvoker);
            }
            _channelId = channelId;
        }

        internal ChannelBase Channel { get; }
        internal CallInvoker CallInvoker { get; }
        internal int AffinityCount => Interlocked.CompareExchange(ref _affinityCount, 0, 0);
        internal int ActiveStreamCount => Interlocked.CompareExchange(ref _activeStreamCount, 0, 0);

        internal int AffinityCountIncr() => Interlocked.Increment(ref _affinityCount);
        internal int AffinityCountDecr() => Interlocked.Decrement(ref _affinityCount);
        internal int ActiveStreamCountIncr() => Interlocked.Increment(ref _activeStreamCount);
        internal int ActiveStreamCountDecr() => Interlocked.Decrement(ref _activeStreamCount);

        internal ChannelRef Clone() => new ChannelRef(Channel, _id, AffinityCount, ActiveStreamCount, ChannelPrimer);
    }
}
