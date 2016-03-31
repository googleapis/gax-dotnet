/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;

namespace Google.Api.Gax.Testing
{
    /// <summary>
    /// Implementation of <see cref="IClock"/> which allows manually-specified times
    /// and increments.
    /// </summary>
    /// <remarks>
    /// This implementation is thread-safe.
    /// </remarks>
    public class FakeClock : IClock
    {
        private long _ticks;

        /// <summary>
        /// Creates an instance with an initial time of 2000-01-01T00:00:00Z.
        /// </summary>
        public FakeClock() : this(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc))
        {
        }

        /// <summary>
        /// Creates an instance with the specified initial time, which must have a kind of
        /// Utc or Unspecified (the latter being for convenience).
        /// </summary>
        /// <param name="dateTime">The initial time for the clock.</param>
        public FakeClock(DateTime dateTime) : this(dateTime.Ticks)
        {
            GaxPreconditions.CheckArgument(dateTime.Kind != DateTimeKind.Local, nameof(dateTime),
                "The initial time for the clock must be specified with a kind of Utc or Unspecified, not Local");
        }

        /// <summary>
        /// Creates an instance with the specified number of ticks since 0001-01-1T00:00:00Z 
        /// as the initial time, for convenience when testing code with numeric values.
        /// </summary>
        /// <param name="ticks"></param>
        public FakeClock(long ticks)
        {
            this._ticks = ticks;
        }

        /// <summary>
        /// Advances the clock to the given time.
        /// </summary>
        /// <remarks>
        /// This will raise the <see cref="TimeChanged"/> event, synchronously.
        /// </remarks>
        /// <param name="dateTime">The time to advance to.</param>
        public void AdvanceTo(DateTime dateTime)
        {
            Advance(dateTime.Ticks - Interlocked.Read(ref _ticks));
        }

        /// <summary>
        /// Advances the clock by the given number of ticks.
        /// </summary>
        /// <remarks>
        /// This will raise the <see cref="TimeChanged"/> event, synchronously.
        /// </remarks>
        /// <param name="ticks">Ticks to advance the clock by.</param>
        public void Advance(long ticks)
        {
            Interlocked.Add(ref this._ticks, ticks);
        }

        /// <summary>
        /// Advances the clock by the given time span.
        /// </summary>
        /// <remarks>
        /// This will raise the <see cref="TimeChanged"/> event, synchronously.
        /// </remarks>
        /// <param name="timeSpan">Time span to advance the clock by.</param>
        public void Advance(TimeSpan timeSpan) => Advance(timeSpan.Ticks);

        /// <summary>
        /// Returns the current date and time in UTC, with a kind of <see cref="DateTimeKind.Utc"/>.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the clock's date and time in UTC.</returns>
        public DateTime GetCurrentDateTimeUtc() => new DateTime(Interlocked.Read(ref _ticks), DateTimeKind.Utc);
    }
}
