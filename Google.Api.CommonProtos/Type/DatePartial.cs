/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Type
{
    public partial class Date
    {
        /// <summary>
        /// Converts <see cref="Date"/> to <see cref="System.DateTime"/>.
        /// </summary>
        /// <returns>The converted <see cref="DateTime"/> with time at midnight and <see cref="System.DateTime.Kind"/> of <see cref="DateTimeKind.Unspecified"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Year"/>, <see cref="Month"/>, and/or <see cref="Day"/> are not within the valid range.</exception>
        public System.DateTime ToDateTime()
        {
            try
            {
                return new System.DateTime(Year, Month, Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException($"Cannot convert to {nameof(DateTime)} because {nameof(Year)}, {nameof(Month)}, and/or {nameof(Day)} must be within the valid range for a {nameof(DateTime)}.");
            }
        }

        /// <summary>
        /// Converts <see cref="Date"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <returns>The converted <see cref="DateTimeOffset"/> with time at midnight, <see cref="System.DateTime.Kind"/> of <see cref="DateTimeKind.Unspecified"/>, and an <see cref="DateTimeOffset.Offset"/> of <see cref="TimeSpan.Zero"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Year"/>, <see cref="Month"/>, and/or <see cref="Day"/> are not within the valid range.</exception>        
        public DateTimeOffset ToDateTimeOffset()
        {
            try
            {
                return new DateTimeOffset(Year, Month, Day, 0, 0, 0, TimeSpan.Zero);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException($"Cannot convert to {nameof(DateTimeOffset)} because {nameof(Year)}, {nameof(Month)}, and/or {nameof(Day)} must be within the valid range for a {nameof(DateTimeOffset)}.");
            }
        }

        /// <summary>
        /// Creates a <see cref="Date"/> instance from the <see cref="System.DateTime.Date"/> part of <see cref="DateTime"/>.
        /// </summary>     
        /// <param name="dateTime">The <see cref="System.DateTime"/> value being converted.</param>
        /// <returns>The created <see cref="Date"/>.</returns>
        public static Date FromDateTime(System.DateTime dateTime) =>
            new Date
            {
                Year = dateTime.Year,
                Month = dateTime.Month,
                Day = dateTime.Day
            };

        /// <summary>
        /// Creates a <see cref="Date"/> instance from the <see cref="DateTimeOffset.Date"/> part of <see cref="DateTimeOffset"/>.
        /// </summary>  
        /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> value being converted.</param>
        /// <returns>The created <see cref="Date"/>.</returns>
        public static Date FromDateTimeOffset(DateTimeOffset dateTimeOffset) =>
            new Date
            {
                Year = dateTimeOffset.Year,
                Month = dateTimeOffset.Month,
                Day = dateTimeOffset.Day
            };
    }
}
