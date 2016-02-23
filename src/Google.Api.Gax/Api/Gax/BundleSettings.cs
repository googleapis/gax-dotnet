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
    /// Settings determining bundling behavior, primarily around when a bundle of pending requests
    /// triggers a real RPC.
    /// </summary>
    public sealed class BundleSettings
    {
        // TODO: Sync behaviour
        // TODO: Naming consistency with Java.

        private int? _entryCountThreshold;
        private int? _requestSizeThreshold;
        private TimeSpan? _delayThreshold;

        /// <summary>
        /// If not null, the number of entries which triggers a bundle being sent. A single request
        /// may contain multiple entries.
        /// </summary>
        public int? EntryCountThreshold
        {
            get { return _entryCountThreshold; }
            set
            {
                // Not readily handled in GaxPreconditions...
                if (value != null && value.Value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Entry count threshold must be strictly positive if non-null");
                }
                _entryCountThreshold = value;
            }
        }

        /// <summary>
        /// If not null, the size of the bundled request (in bytes) which triggers it being sent.
        /// </summary>
        public int? RequestSizeThreshold
        {
            get { return _requestSizeThreshold; }
            set
            {
                // Not readily handled in GaxPreconditions...
                if (value != null && value.Value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Request size threshold must be strictly positive if non-null");
                }
                _requestSizeThreshold = value;
            }
        }

        /// <summary>
        /// If not null, a delay after which the bundle is sent, regardless of its size.
        /// </summary>
        public TimeSpan? DelayThreshold
        {
            get { return _delayThreshold; }
            set
            {
                // Not readily handled in GaxPreconditions...
                if (value != null && value.Value.Ticks <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Delay threshold must be strictly positive if non-null");
                }
                _delayThreshold = value;
            }
        }

        /// <summary>
        /// Creates a clone of this object, with all the same property values.
        /// </summary>
        /// <returns>A clone of this set of bundle settings.</returns>
        public BundleSettings Clone()
        {
            return new BundleSettings
            {
                EntryCountThreshold = EntryCountThreshold,
                RequestSizeThreshold = RequestSizeThreshold,
                DelayThreshold = DelayThreshold
            };
        }

        /// <summary>
        /// Checks that the settings are valid, throwing an <see cref="ArgumentException"/>
        /// otherwise. As this type is mutable, this method call does not ensure that the
        /// object won't later become invalid.
        /// </summary>
        /// <param name="parameterName">The parameter name to specify in the exception if the
        /// settings are invalid.</param>
        public void Validate(string parameterName)
        {
            GaxPreconditions.CheckArgument(
                EntryCountThreshold != null || RequestSizeThreshold != null || DelayThreshold != null,
                parameterName,
                "At least one trigger (entry count, request size, delay threshold) must be specified");
        }
    }
}
