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
    /// An abstraction of the ability to determine the current date and time.
    /// </summary>
    /// <remarks>
    /// This interface primarily exists for testing purposes, allowing test code to
    /// isolate itself from the system clock. In production, the <see cref="SystemClock"/>
    /// implementation is by far the most likely one to be used, and the only one provided
    /// within this library. Code that uses a clock should generally be designed to allow it
    /// to be optionally specified, defaulting to <see cref="SystemClock.Instance"/>.
    /// </remarks>
    public interface IClock
    {
        /// <summary>
        /// Returns the current date and time in UTC, with a kind of <see cref="DateTimeKind.Utc"/>.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the current date and time in UTC.</returns>
        DateTime GetCurrentDateTimeUtc();
    }
}
