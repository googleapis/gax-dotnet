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
        /// Converts the <see cref="System.DateTime.Date"/> part of <see cref="System.DateTime"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="System.DateTime"/> instance being converted.</param>
        /// <returns>The <see cref="Date"/>.</returns>
        public static Date ToDate(this System.DateTime dateTime) =>
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
