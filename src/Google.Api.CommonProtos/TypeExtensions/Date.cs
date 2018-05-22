/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Type
{
    /// <summary>
    /// Extensions to <see cref="Date"/>.
    /// </summary>
    public partial class Date
    {
        /// <summary>
        /// Converts <see cref="Date"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <returns>The converted <see cref="DateTime"/> with no time specified.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Date.Year"/>, <see cref="Date.Month"/>, and/or <see cref="Date.Day"/> are not within the valid range.</exception>
        public DateTime ToDateTime()
        {
            try
            {
                return new DateTime(Year, Month, Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException($"Cannot convert to {nameof(DateTime)} because {nameof(Year)}, {nameof(Month)}, and/or {nameof(Day)} must be within the valid range for a {nameof(DateTime)}.");
            }
        }

        /// <summary>
        /// Converts <see cref="Date"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <returns>The converted <see cref="DateTimeOffset"/> with no time specified and an Offset of <see cref="TimeSpan.Zero"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <see cref="Date.Year"/>, <see cref="Date.Month"/>, and/or <see cref="Date.Day"/> are not within the valid range.</exception>        
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
        /// Creates a <see cref="Date"/> instance from the <see cref="DateTime.Date"/> part of <see cref="DateTime"/>.
        /// </summary>     
        /// <param name="dateTimeToConvert">The <see cref="DateTime"/> instance being converted.</param>
        /// <returns>The created <see cref="Date"/>.</returns>
        public static Date CreateDate(DateTime dateTimeToConvert) =>
            new Date
            {
                Year = dateTimeToConvert.Year,
                Month = dateTimeToConvert.Month,
                Day = dateTimeToConvert.Day
            };

        /// <summary>
        /// Creates a <see cref="Date"/> instance from the <see cref="DateTimeOffset.Date"/> part of <see cref="DateTimeOffset"/>.
        /// </summary>  
        /// <param name="dateTimeOffsetToConvert">The <see cref="DateTimeOffset"/> instance being converted.</param>
        /// <returns>The created <see cref="Date"/>.</returns>
        public static Date CreateDate(DateTimeOffset dateTimeOffsetToConvert) =>
            new Date
            {
                Year = dateTimeOffsetToConvert.Year,
                Month = dateTimeOffsetToConvert.Month,
                Day = dateTimeOffsetToConvert.Day
            };
    }

    /// <summary>
    /// Extension methods built for <see cref="Date"/>.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Converts the <see cref="DateTime.Date"/> part of <see cref="DateTime"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="dateTimeToConvert">The <see cref="DateTime"/> instance being converted.</param>
        /// <returns>The <see cref="Date"/>.</returns>
        public static Date ToDate(this DateTime dateTimeToConvert) =>
            Date.CreateDate(dateTimeToConvert);

        /// <summary>
        /// Converts the <see cref="DateTimeOffset.Date"/> part of <see cref="DateTimeOffset"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="dateTimeOffsetToConvert">The <see cref="DateTimeOffset"/> instance being converted.</param>
        /// <returns>The converted <see cref="Date"/>.</returns>
        public static Date ToDate(this DateTimeOffset dateTimeOffsetToConvert) =>
            Date.CreateDate(dateTimeOffsetToConvert);
    }
}
