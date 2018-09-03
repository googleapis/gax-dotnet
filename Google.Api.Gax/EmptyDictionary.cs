/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Google.Api.Gax
{
    /// <summary>
    /// Provides cached instances of empty dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public static class EmptyDictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets a cached empty <see cref="IDictionary{TKey, TValue}"/>. The returned dictionary is read-only.
        /// </summary>
        public static IDictionary<TKey, TValue> Instance { get; } =
            new ReadOnlyDictionary<TKey, TValue>(new Dictionary<TKey, TValue>(0));
    }
}
