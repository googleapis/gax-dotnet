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
    /// Collects the explicit routing header extraction instructions and
    /// extracts the routing header parameters from a specific request
    /// using these instructions.
    /// This class is immutable.
    /// </summary>
    public sealed class HeaderParameterExtractor<TRequest>
    {
        private readonly IReadOnlyList<ParamExtraction> _extractions;
        private readonly IReadOnlyDictionary<string, IEnumerable<ParamExtraction>> _groupings;

        /// <summary>
        /// Create a new HeaderParameterExtractor
        /// </summary>
        public HeaderParameterExtractor()
        {
            _extractions = new List<ParamExtraction>();
        }

        private HeaderParameterExtractor(IEnumerable<ParamExtraction> extractions)
        {
            _extractions = new List<ParamExtraction>(extractions);

            // It is important that we Reverse the parameters within the group.
            // The extractions follow the `last successfully matched wins` rule for
            // conflict resolution when there are multiple extractions for the same parameter name.
            // (see `google/api/routing.proto` for further details)
            // But we would prefer to stop evaluating on the first successfully matched extraction,
            // thus the reverse.
            _groupings = _extractions.GroupBy(pe => pe.ParamName)
                .ToDictionary(paramGroup => paramGroup.Key,
                    paramGroup => paramGroup.Reverse());
        }

        /// <summary>
        /// Adds a new header parameter extraction instruction.
        /// The extractions follow the `last successfully matched wins` rule for
        /// conflict resolution when there are multiple extractions for the same parameter name.
        /// (see `google/api/routing.proto` for further details)
        /// </summary>
        /// <param name="paramName">The name of the parameter in the routing header.</param>
        /// <param name="regexStr">The regular expression (in the string form) used to extract the value of the parameter.
        /// Should have exactly one named capturing group.</param>
        /// <param name="selector">A function to call on each request, to determine the string to extract the header value from.
        /// The parameter must not be null, but may return null.</param>
        /// <returns></returns>
        public HeaderParameterExtractor<TRequest> WithParameter(string paramName, string regexStr, Func<TRequest, string> selector)
        {
            GaxPreconditions.CheckNotNullOrEmpty(paramName, nameof(paramName));
            GaxPreconditions.CheckNotNull(regexStr, nameof(regexStr));
            GaxPreconditions.CheckNotNull(selector, nameof(selector));

            var regex = new Regex(regexStr);

            // All regexes have a capturing group named `0` that captures the whole regex
            if (regex.GetGroupNames().Length != 2)
            {
                var errMsg =
                    "The regex used for the routing header extraction should have exactly one named capturing group.";
                throw new ArgumentException(errMsg, nameof(regex));
            }

            return new HeaderParameterExtractor<TRequest>(_extractions.Concat(new[] { new ParamExtraction(paramName, regex, selector) }));
        }

        /// <summary>
        /// Extracts the dictionary of parameter names and values to add to the routing header.
        /// </summary>
        /// <param name="request">A request to extract the routing header parameters and values from</param>
        /// <returns>The dictionary in the form `parameter name => parameter value` to add to the routing header</returns>
        public Dictionary<string, string> Extract(TRequest request)
        {
            if (!_groupings.Any())
            {
                throw new InvalidOperationException(
                    "Cannot extract routing header parameters with an empty list of extractions");
            }

            return _groupings.ToDictionary(
                    headerToExtractions => headerToExtractions.Key,
                    headerToExtractions => headerToExtractions.Value.Select(pe => pe.Extract(request))
                        .FirstOrDefault(val => !string.IsNullOrEmpty(val)))
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
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
