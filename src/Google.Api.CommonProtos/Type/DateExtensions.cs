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
    /// Extension methods built for <see cref="Date"/>.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Converts the <see cref="DateTime.Date"/> part of <see cref="DateTime"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> instance being converted.</param>
        /// <returns>The <see cref="Date"/>.</returns>
        public static Date ToDate(this DateTime dateTime) =>
            Date.FromDateTime(dateTime);

        /// <summary>
        /// Converts the <see cref="DateTimeOffset.Date"/> part of <see cref="DateTimeOffset"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> instance being converted.</param>
        /// <returns>The converted <see cref="Date"/>.</returns>
        public static Date ToDate(this DateTimeOffset dateTimeOffset) =>
            Date.FromDateTimeOffset(dateTimeOffset);
    }
}
