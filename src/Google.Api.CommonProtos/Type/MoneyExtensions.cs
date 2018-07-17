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
    /// Extension methods built for use with <see cref="Money"/>.
    /// </summary>
    public static class MoneyExtensions
    {
        /// <summary>
        /// Converts a <see cref="decimal"/> to <see cref="Money"/>.
        /// </summary>
        /// <param name="value">The amount of money.</param>
        /// <param name="currencyCode">The 3-letter currency code defined in ISO 4217.</param>
        /// <returns>A <see cref="Money"/> containing the decimal value in the specified currency</returns>
        /// <exception cref="ArgumentOutOfRangeException">The integral part of the decimal must be a valid <see cref="Int64"/>, and the fractional part must have a maximum of 9 digits of precision.</exception>
        public static Money ToMoney(this decimal value, string currencyCode)
        {
            decimal integralPart = Math.Truncate(value);
            long units;

            try
            {
                units = (long)integralPart;
            }
            catch (OverflowException ex)
            {
                throw new ArgumentOutOfRangeException($"Unable to convert the value {value.ToString()} to Money.  The integral part of the amount must be a valid System.Int64 value.", ex);
            }

            decimal fractionalPart = (value - integralPart) * 1_000_000_000M;

            if (fractionalPart != Math.Truncate(fractionalPart))
            {
                throw new ArgumentOutOfRangeException($"Unable to convert the value {value.ToString()} to Money precisely.  The Money type supports a maximum of 9 digits after the decimal.");
            }

            return new Money
            {
                CurrencyCode = currencyCode,
                Units = units,
                Nanos = (int)fractionalPart
            };
        }
    }
}
