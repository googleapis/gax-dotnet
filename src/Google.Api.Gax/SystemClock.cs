/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
 
 using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// A singleton implementation of <see cref="IClock"/> which delegates to the BCL
    /// <see cref="DateTime.UtcNow"/> property.
    /// </summary>
    public sealed class SystemClock : IClock
    {
        /// <summary>
        /// Retrieves the singleton instance of this type.
        /// </summary>
        public static IClock Instance { get; } = new SystemClock();

        private SystemClock()
        {
        }

        /// <summary>
        /// Returns the current date and time in UTC, using <see cref="DateTime.UtcNow"/>.
        /// </summary>
        /// <returns>The current date and time in UTC.</returns>
        public DateTime GetCurrentDateTimeUtc() => DateTime.UtcNow;
    }
}
