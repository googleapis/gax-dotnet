/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class HeaderParameterExtractor<TRequest>
    {
        private readonly List<Regex> _regexes;
        private readonly List<Func<TRequest, string>> _selectors;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="selector"></param>
        public HeaderParameterExtractor(Regex regex, Func<TRequest, string> selector)
        {
            _regexes = new List<Regex> { regex };
            _selectors = new List<Func<TRequest, string>> { selector };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public HeaderParameterExtractor<TRequest> Add(Regex regex, Func<TRequest, string> selector)
        {
            _regexes.Add(regex);
            _selectors.Add(selector);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Extract(TRequest request)
        {
            foreach (var (extractionRegex, valueSelector) in _regexes.Zip(_selectors, (regex, func) => (regex, func))
                .AsEnumerable().Reverse())
            {
                var value = valueSelector(request);

                if (extractionRegex.IsMatch(value))
                {
                    return extractionRegex.Matches(value)[0].Value;
                }
            }

            return null;
        }
    }
}
