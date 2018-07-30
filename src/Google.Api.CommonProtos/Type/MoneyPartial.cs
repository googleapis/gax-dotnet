/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Type
{
    public partial class Money
    {
        /// <summary>
        /// The amount of money in <see cref="decimal"/> format.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The integral part of the decimal must be a valid <see cref="Int64"/>, and the fractional part must have a maximum of 9 digits of precision.</exception>
        public decimal DecimalValue {

            get => Units + (Nanos / 1_000_000_000M);

            set {
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

                Units = units;
                Nanos = (int)fractionalPart;
            }
        }
    }
}
