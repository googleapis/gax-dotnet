/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Common settings for all services.
    /// </summary>
    public abstract class ServiceSettingsBase
    {
        private TimeSpan? _timeout;

        /// <summary>
        /// If not null, a timeout for all RPC calls. If null or unset, the RPC method default timeout will be used.
        /// </summary>
        public TimeSpan? Timeout
        {
            get { return _timeout; }
            set
            {
                if (value != null && value.Value.Ticks <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Timeout must be positive and cannot be zero");
                }
                _timeout = value;
            }
        }

        /// <summary>
        /// If not null, the clock used to calculate RPC deadlines. If null or unset, the <see cref="SystemClock"/> is used.
        /// </summary>
        /// <remarks>
        /// This is primarily only to be set for testing.
        /// In production code generally leave this unset to use the <see cref="SystemClock"/>.
        /// </remarks>
        public IClock Clock { get; set; }

        protected virtual T CloneInto<T>(T settings) where T : ServiceSettingsBase
        {
            settings.Timeout = Timeout;
            settings.Clock = Clock;
            return settings;
        }
    }
}
