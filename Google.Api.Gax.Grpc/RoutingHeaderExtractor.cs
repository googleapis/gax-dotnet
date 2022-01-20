/*
 * Copyright 2021 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Collects the explicit routing header extraction instructions and
    /// extracts the routing header value from a specific request
    /// using these instructions.
    /// This class is immutable.
    /// </summary>
    public sealed class RoutingHeaderExtractor<TRequest>
    {
        /// <summary>
        /// The individual pattern extractors present in this extractor. These
        /// are only present for chaining purposes while building up the full
        /// extractor. (If we ever move to a builder pattern, we could remove these.)
        /// These are retained in declaration order.
        /// </summary>
        private readonly IReadOnlyList<SinglePatternExtractor> _patternExtractors;

        /// <summary>
        /// The parameter extractors, created from <see cref="_patternExtractors"/>.
        /// These are used at execution time to extract the values for parameters.
        /// </summary>
        private readonly IReadOnlyList<SingleParameterExtractor> _parameterExtractors;

        /// <summary>
        /// Create a new RoutingHeaderExtractor with no patterns. (This cannot be used
        /// to extract headers; new instances must be created with <see cref="WithExtractedParameter"/>
        /// which provides patterns to use to extract values.)
        /// </summary>
        public RoutingHeaderExtractor()
        {
            _patternExtractors = new List<SinglePatternExtractor>();
        }

        private RoutingHeaderExtractor(List<SinglePatternExtractor> patternExtractors)
        {
            // Note: we rely on this constructor only being called by WithExtractedParameter, which
            // constructs a new list. If we ever want to make this public, we'd probably
            // change the parameter to IEnumerable<SinglePatternExtractor> and clone it
            // in this constructor.
            _patternExtractors = patternExtractors;

            _parameterExtractors = patternExtractors
                .GroupBy(pe => pe.ParameterName)
                .Select(group => new SingleParameterExtractor(group))
                .ToList();
        }

        /// <summary>
        /// Returns a new instance with the same parameter extractors as this one, with an additional one specified as arguments.
        /// The extractions follow the "last successfully matched wins" rule for
        /// conflict resolution when there are multiple extractions for the same parameter name.
        /// (See `google/api/routing.proto` for further details.) If multiple parameters
        /// with different names are present, the extracted header will contain them in the order
        /// in which they have been added with this method, based on the first occurrence of
        /// each parameter name.
        /// </summary>
        /// <param name="paramName">The name of the parameter in the routing header.</param>
        /// <param name="extractionRegex">The regular expression (in string form) used to extract the value of the parameter.
        /// Must have exactly one capturing group (in addition to the implicit "group 0" which captures the whole match).</param>
        /// <param name="selector">A function to call on each request, to determine the string to extract the header value from.
        /// The parameter must not be null, but may return null.</param>
        /// <returns></returns>
        public RoutingHeaderExtractor<TRequest> WithExtractedParameter(string paramName, string extractionRegex, Func<TRequest, string> selector)
        {
            GaxPreconditions.CheckNotNullOrEmpty(paramName, nameof(paramName));
            GaxPreconditions.CheckNotNull(extractionRegex, nameof(extractionRegex));
            GaxPreconditions.CheckNotNull(selector, nameof(selector));

            var regex = new Regex(extractionRegex);

            // All regexes have an implicit capturing group 0 that captures the whole regex; we require
            // one additional capturing group which captures the value to include in the header.
            GaxPreconditions.CheckArgument(
                regex.GetGroupNumbers().Length == 2,
                nameof(extractionRegex),
                "The regex used for the routing header extraction must have exactly one capturing group.");

            var newExtractors = new List<SinglePatternExtractor>(_patternExtractors)
            {
                new SinglePatternExtractor(paramName, regex, selector)
            };
            return new RoutingHeaderExtractor<TRequest>(newExtractors);
        }

        /// <summary>
        /// Extracts the routing header value to apply based on a request.
        /// </summary>
        /// <param name="request">A request to extract the routing header parameters and values from</param>
        /// <returns>The value to use for the routing header. This may contain multiple &amp;-separated parameters.</returns>
        public string ExtractHeader(TRequest request)
        {
            GaxPreconditions.CheckState(
                _parameterExtractors is object,
                "Cannot extract routing header parameters with an empty list of extractions");

            var keyValuePairs = _parameterExtractors
                .Select(pe => pe.ExtractKeyValuePair(request))
                .Where(kvp => kvp is object);

            var candidate = string.Join("&", keyValuePairs);
            return candidate == "" ? null : candidate;
        }

        /// <summary>
        /// An extractor for a single parameter, which may check multiple patterns to extract a value.
        /// </summary>
        private class SingleParameterExtractor
        {
            private readonly IReadOnlyList<SinglePatternExtractor> _patternExtractors;

            /// <summary>
            /// Creates an instance based on the single-pattern extractors, in the order in which they are
            /// declared. They will be *applied* in reverse order. It is assumed that all pattern extractors
            /// are for the same parameter name.
            /// </summary>
            internal SingleParameterExtractor(IEnumerable<SinglePatternExtractor> patternExtractorsInDeclarationOrder)
            {
                // It is important that we Reverse the parameters within the group.
                // The extractions follow the `last successfully matched wins` rule for
                // conflict resolution when there are multiple extractions for the same parameter name.
                // (see `google/api/routing.proto` for further details)
                // But we would prefer to stop evaluating on the first successfully matched extraction,
                // thus the reverse.
                _patternExtractors = patternExtractorsInDeclarationOrder.Reverse().ToList();
            }

            /// <summary>
            /// Extracts the value from the request and returns it in a form ready to be included in the
            /// header
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            public string ExtractKeyValuePair(TRequest request) => 
                _patternExtractors
                    .Select(pe => pe.ExtractKeyValuePair(request))
                    .FirstOrDefault(v => v is string);
        }

        /// <summary>
        /// An extractor for a single pattern, used one option within a <see cref="SingleParameterExtractor"/>.
        /// </summary>
        private class SinglePatternExtractor
        {
            public string ParameterName { get; }
            private readonly Regex _regex;
            private readonly Func<TRequest, string> _selector;

            public SinglePatternExtractor(string parameterName, Regex regex, Func<TRequest, string> selector)
            {
                ParameterName = parameterName;
                _regex = regex;
                _selector = selector;
            }

            /// <summary>
            /// Extracts the value from the request by matching it against the pattern,
            /// returning the the key/value pair in the form key=value, after URI-escaping the value.
            /// </summary>
            public string ExtractKeyValuePair(TRequest request)
            {
                var match = _regex.Match(_selector(request) ?? "");
                if (!match.Success)
                {
                    return null;
                }
                string value = match.Groups[1].Value;
                if (value.Length == 0)
                {
                    return null;
                }
                return $"{ParameterName}={Uri.EscapeDataString(value)}";
            }
        }
    }
}
