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
        /// Converts <see cref="Money"/> value to <see cref="decimal"/>, omitting the <see cref="CurrencyCode"/>.
        /// </summary>
        /// <returns>The amount as a <see cref="decimal"/>.</returns>
        public decimal ToDecimal()
        {
            return Units + (Nanos / 1_000_000_000M);
        }
    }
}
