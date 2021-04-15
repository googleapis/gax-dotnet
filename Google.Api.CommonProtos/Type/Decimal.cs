/*
 * Copyright 2021 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Globalization;

namespace Google.Type
{
    public partial class Decimal
    {
        /// <summary>
        /// Converts the given <see cref="System.Decimal"/> value to the protobuf <see cref="Decimal"/>
        /// representation. If the input value naturally contains trailing decimal zeroes (e.g. "1.00")
        /// these are preserved in the protobuf representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The protobuf representation.</returns>
        public static Decimal FromClrDecimal(decimal value) =>
            new Decimal { Value = value.ToString(CultureInfo.InvariantCulture) };

        /// <summary>
        /// Converts this protobuf <see cref="Decimal"/> value to a CLR <see cref="System.Decimal"/>
        /// value. If the value is within the range of <see cref="System.Decimal"/> but contains
        /// more than 29 significant digits, the returned value is truncated towards zero.
        /// </summary>
        /// <returns>The CLR representation of this value.</returns>
        /// <exception cref="FormatException">This protobuf value is invalid, either because
        /// <see cref="Value"/> has not been set, or because it does not represent a valid decimal value.</exception>
        /// <exception cref="OverflowException">The protobuf value is too large or small to be represented
        /// by <see cref="System.Decimal"/>.</exception>
        public decimal ToClrDecimal() =>
            decimal.Parse(
                Value,
                NumberStyles.AllowExponent | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture);
    }
}
