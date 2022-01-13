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
        private readonly IReadOnlyList<ParamExtraction> _extractions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="regex"></param>
        /// <param name="selector"></param>
        public HeaderParameterExtractor(string paramName, Regex regex, Func<TRequest, string> selector)
        {
            _extractions = new List<ParamExtraction> { new ParamExtraction(paramName, regex, selector) };
        }

        private HeaderParameterExtractor(IEnumerable<ParamExtraction> extractions)
        {
            _extractions = new List<ParamExtraction>(extractions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="regex"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public HeaderParameterExtractor<TRequest> Add(string paramName, Regex regex, Func<TRequest, string> selector)
        {
            return new HeaderParameterExtractor<TRequest>(_extractions.Concat(new[] { new ParamExtraction(paramName, regex, selector) }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Dictionary<string, string> Extract(TRequest request)
        {
            return _extractions.GroupBy(pe => pe.ParamName)
                .ToDictionary(paramGroup => paramGroup.Key,
                              paramGroup => paramGroup.Reverse()
                                  .Select(pe => pe.Extract(request))
                                  .FirstOrDefault(val => !string.IsNullOrEmpty(val)))
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                .ToDictionary(kvp=>kvp.Key, kvp => kvp.Value);
        }

        private class ParamExtraction
        {
            public string ParamName { get; }
            private readonly Regex _regex;
            private readonly Func<TRequest, string> _selector;

            public ParamExtraction(string paramName, Regex regex, Func<TRequest, string> selector)
            {
                ParamName = paramName;
                _regex = regex;
                _selector = selector;
            }

            public string Extract(TRequest request)
            {
                var match = _regex.Match(_selector(request) ?? "");
                return match.Success ? match.Groups[1].Value : null;
            }
        }
    }
}
