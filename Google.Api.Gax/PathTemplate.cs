/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Api.Gax
{
    /// <summary>
    /// Represents a path template used for resource names which may be composed of multiple IDs.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Templates use a subset of the syntax of the API platform. See
    /// https://github.com/googleapis/googleapis/blob/master/google/api/http.proto
    /// for details of the API platform.
    /// </para>
    /// <para>
    /// This class performs no URL escaping or unescaping. It is designed for use within GRPC, where no
    /// URL encoding is required.
    /// </para>
    /// </remarks>
    public sealed class PathTemplate
    {
        /// <summary>
        /// Just an array containing a single slash, to avoid constructing a new array every time we need
        /// to split.
        /// </summary>
        private static readonly char[] s_slashSplit = { '/' };

        /// <summary>
        /// List of segments in this template. Never modified after construction.
        /// </summary>
        private readonly IReadOnlyList<Segment> _segments;

        /// <summary>
        /// List of the segments in this template which are wildcards. Never modified after construction.
        /// </summary>
        private readonly IReadOnlyList<Segment> _parameterSegments;

        private readonly string _originalTemplate;
        private readonly bool _hasPathWildcard;

        /// <summary>
        /// The names of the parameters within the template. This collection has one element per parameter,
        /// but unnamed parameters have a name of <c>null</c>.
        /// </summary>
        public IReadOnlyList<string> ParameterNames { get; }

        /// <summary>
        /// Constructs a template from its textual representation, such as <c>shelves/*/books/**</c>.
        /// </summary>
        /// <param name="template">The textual representation of the template. Must not be null.</param>
        public PathTemplate(string template)
        {
            GaxPreconditions.CheckNotNull(template, nameof(template));
            _segments = template.Split(s_slashSplit).Select(Segment.Parse).ToList();
            _parameterSegments = _segments.Where(s => s.Kind != SegmentKind.Literal).ToList();
            int pathWildcardCount = _segments.Count(s => s.Kind == SegmentKind.PathWildcard);
            if (pathWildcardCount > 1)
            {
                throw new ArgumentException("Template contains multiple path wildcards", nameof(template));
            }
            _hasPathWildcard = pathWildcardCount != 0;
            _originalTemplate = template;
            ParameterNames = _parameterSegments.Select(x => x.Value).ToList().AsReadOnly();
        }

        /// <summary>
        /// The number of parameter segments (regular wildcards or path wildcards, named or unnamed) in the template.
        /// </summary>
        public int ParameterCount => _parameterSegments.Count;

        /// <summary>
        /// Validates a service name, ensuring it is not empty and doesn't contain any slashes.
        /// (In the future, we may want to make this stricter, e.g. that it's a valid DNS-like name.)
        /// </summary>
        /// <param name="serviceName">The name to validate</param>
        /// <param name="parameterName">The name of the parameter</param>
        internal static void ValidateServiceName(string serviceName, string parameterName)
        {
            if (serviceName == null)
            {
                return;
            }
            if (serviceName == "")
            {
                throw new ArgumentException("Service name cannot be empty", parameterName);
            }
            if (serviceName.Contains("/"))
            {
                throw new ArgumentException("Service name cannot be contain /", parameterName);
            }
            // TODO: More restrictions when they've been determined.
        }

        /// <summary>
        /// Validate a single value from a sequence. This is used in both parsing and instantiating.
        /// </summary>
        internal void ValidateResourceId(int index, string resourceId)
        {
            _parameterSegments[index].ValidateWildcardValue(resourceId);
        }

        /// <summary>
        /// Validates a whole array of resource IDs, including that the count matches.
        /// </summary>
        internal void ValidateResourceIds(string[] resourceIds)
        {
            GaxPreconditions.CheckNotNull(resourceIds, nameof(resourceIds));
            if (resourceIds.Length != ParameterCount)
            {
                throw new ArgumentException($"Expected {ParameterCount} ids, got {resourceIds.Length}", nameof(resourceIds));
            }
            for (int i = 0; i < resourceIds.Length; i++)
            {
                ValidateResourceId(i, resourceIds[i]);
            }
        }

        /// <summary>
        /// Validates that the given resource IDs are valid for this template, and returns a string representation
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is equivalent to calling <c>new ResourceName(template, resourceIds).ToString()</c>, but simpler in
        /// calling code and more efficient in terms of memory allocation.
        /// </para>
        /// <para>
        /// This method assumes no service name is required. Call <see cref="ExpandWithService"/> to specify a service name.
        /// </para>
        /// </remarks>
        /// <param name="resourceIds">The resource IDs to use to populate the parameters in this template. Must not be null.</param>
        /// <returns>The string representation of the resource name.</returns>
        public string Expand(params string[] resourceIds) => ExpandWithService(null, resourceIds);

        /// <summary>
        /// Validates that the given resource IDs are valid for this template, and returns a string representation
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="resourceIds">The resource IDs to use to populate the parameters in this template. Must not be null.</param>
        /// <param name="serviceName">The service name, which may be null.</param>
        /// <returns>The string representation of the resource name.</returns>
        public string ExpandWithService(string serviceName, params string[] resourceIds)
        {
            ValidateResourceIds(resourceIds);
            ValidateServiceName(serviceName, nameof(serviceName));
            return ReplaceParameters(serviceName, resourceIds);
        }

        /// <summary>
        /// Returns a string representation of the template with parameters replaced by resource IDs.
        /// </summary>
        /// <param name="serviceName">The name of the service, for full resource names. May be null, to produce a relative resource name.</param>
        /// <param name="resourceIds">Resource IDs to interpolate the template with. Expected to have been validated already.</param>
        internal string ReplaceParameters(string serviceName, string[] resourceIds)
        {
            int nextIdIndex = 0;
            var result = new StringBuilder();
            if (serviceName != null)
            {
                result.Append("//").Append(serviceName);
            }
            foreach (var segment in _segments)
            {
                if (result.Length != 0)
                {
                    result.Append('/');
                }
                switch (segment.Kind)
                {
                    case SegmentKind.Literal:
                        result.Append(segment.Value);
                        break;
                    case SegmentKind.Wildcard:
                        result.Append(resourceIds[nextIdIndex++]);
                        break;
                    case SegmentKind.PathWildcard:
                        string path = resourceIds[nextIdIndex++];
                        result.Append(path);
                        if (path == "" && result.Length > 0)
                        {
                            // Swallow any slash that we've already added for this.
                            result.Length--;
                        }
                        break;
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Attempts to parse the given resource name against this template, returning <c>null</c> on failure.
        /// </summary>
        /// <remarks>
        /// Although this method returns <c>null</c> if a name is passed in which doesn't match the template,
        /// it still throws <see cref="ArgumentNullException"/> if <paramref name="name"/> is null, as this would
        /// usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="name">The resource name to parse against this template. Must not be null.</param>
        /// <param name="result">When this method returns, the parsed resource name or <c>null</c> if parsing fails.</param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public bool TryParseName(string name, out TemplatedResourceName result)
        {
            return TryParseNameInternal(name, out result) == null;
        }

        /// <summary>
        /// Attempts to parse the given resource name against this template, throwing <see cref="ArgumentException" /> on failure.
        /// </summary>
        /// <param name="name">The resource name to parse against this template. Must not be null.</param>
        /// <returns>The parsed name as a <see cref="TemplatedResourceName"/>.</returns>
        public TemplatedResourceName ParseName(string name)
        {
            TemplatedResourceName resourceName;
            string errorText = TryParseNameInternal(name, out resourceName);
            if (resourceName == null)
            {
                throw new FormatException(errorText);
            }
            return resourceName;
        }

        /// <summary>
        /// Implementation of parsing, returning the error message for a FormatException if parsing fails.
        /// </summary>
        private string TryParseNameInternal(string name, out TemplatedResourceName result)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            string serviceName = null;
            if (name.StartsWith("//", StringComparison.Ordinal))
            {
                int nameEnd = name.IndexOf('/', 2);
                // Can't call ValidateServiceName as we don't want to throw...
                if (nameEnd == 2)
                {
                    result = null;
                    return "Service name cannot be empty";
                }
                // It's *just about* plausible to have a template of ** and a value of "//service".
                if (nameEnd == -1)
                {
                    serviceName = name.Substring(2);
                    name = "";
                }
                else
                {
                    serviceName = name.Substring(2, nameEnd - 2);
                    name = name.Substring(nameEnd + 1);
                }
            }
            string[] nameSegments = name == "" ? new string[0] : name.Split(s_slashSplit);
            if (_hasPathWildcard)
            {
                // The path wildcard can be empty...
                if (nameSegments.Length < _segments.Count - 1)
                {
                    result = null;
                    return "Name does not match template: too few segments";
                }
            }
            else if (nameSegments.Length != _segments.Count)
            {
                result = null;
                return "Name does not match template: incorrect number of segments";
            }
            string[] resourceIds = new string[ParameterCount];
            int resourceIdIndex = 0;
            int nameSegmentIndex = 0;
            foreach (var segment in _segments)
            {
                switch (segment.Kind)
                {
                    case SegmentKind.Literal:
                        var nameSegment = nameSegments[nameSegmentIndex++];
                        if (nameSegment != segment.Value)
                        {
                            result = null;
                            return $"Name does not match template in literal segment: '{nameSegment}' != '{segment.Value}'";
                        }
                        break;
                    case SegmentKind.Wildcard:
                        // Could use segment.ValidateWildcard, but the exception wouldn't be as clean.
                        var value = nameSegments[nameSegmentIndex++];
                        if (value == "")
                        {
                            result = null;
                            return "Name does not match template: wildcard segment is empty";
                        }
                        resourceIds[resourceIdIndex++] = value;
                        break;
                    case SegmentKind.PathWildcard:
                        // Work out how many segments to consume based on the number of segments in the template and the
                        // actual number of segments in the specified name
                        int count = nameSegments.Length - _segments.Count + 1;
                        // Make the common case more efficient
                        if (count == 1)
                        {
                            resourceIds[resourceIdIndex++] = nameSegments[nameSegmentIndex++];
                        }
                        else
                        {
                            resourceIds[resourceIdIndex++] = string.Join("/", nameSegments.Skip(nameSegmentIndex).Take(count));
                            nameSegmentIndex += count;
                        }
                        break;
                }
            }
            result = TemplatedResourceName.CreateWithShallowCopy(this, serviceName, resourceIds);
            return null; // Success!
        }

        /// <summary>
        /// Returns the textual representation of this template.
        /// </summary>
        /// <returns>The same textual representation that this template was initially constructed with.</returns>
        public override string ToString() => _originalTemplate;

        private enum SegmentKind
        {
            /// <summary>
            /// A literal path segment.
            /// </summary>
            Literal,

            /// <summary>
            /// A simple wildcard ('*').
            /// </summary>
            Wildcard,

            /// <summary>
            /// A path wildcard ('**').
            /// </summary>
            PathWildcard,
        }

        /// <summary>
        /// A segment of a path.
        /// </summary>
        private sealed class Segment
        {
            private static readonly Segment s_unnamedWildcard = new Segment(SegmentKind.Wildcard, null);
            private static readonly Segment s_unnamedPathWildcard = new Segment(SegmentKind.PathWildcard, null);

            internal SegmentKind Kind { get; }
            /// <summary>
            /// The literal value or the name of a wildcard.
            /// null for unnamed wildcards.
            /// </summary>
            internal string Value { get; }

            private Segment(SegmentKind kind, string value)
            {
                Kind = kind;
                Value = value;
            }

            internal void ValidateWildcardValue(string value)
            {
                GaxPreconditions.CheckNotNull(value, nameof(value));
                // TODO: Use subclasses instead?
                switch (Kind)
                {
                    case SegmentKind.Literal:
                        throw new InvalidOperationException("Values cannot be specified for literal segments");
                    case SegmentKind.PathWildcard:
                        if (value.StartsWith("/", StringComparison.Ordinal) || value.EndsWith("/", StringComparison.Ordinal))
                        {
                            throw new ArgumentException("Path wildcard values must not start or end with /", nameof(value));
                        }
                        break;
                    case SegmentKind.Wildcard:
                        if (value == "")
                        {
                            throw new ArgumentException("Wildcard resource ids must not be empty", nameof(value));
                        }
                        if (value.Contains("/"))
                        {
                            throw new ArgumentException("Wildcard resource ids must not contain /", nameof(value));
                        }
                        break;
                }
            }

            internal static Segment Parse(string segment)
            {
                if (segment == "")
                {
                    throw new ArgumentException("Invalid template: empty segment", nameof(segment));
                }
                if (segment == "*")
                {
                    return s_unnamedWildcard;
                }
                if (segment == "**")
                {
                    return s_unnamedPathWildcard;
                }
                bool startsWithBrace = segment.StartsWith("{", StringComparison.Ordinal);
                bool endsWithBrace = segment.EndsWith("}", StringComparison.Ordinal);
                if (startsWithBrace != endsWithBrace)
                {
                    throw new ArgumentException($"Invalid template segment: {segment}", nameof(segment));
                }
                if (!startsWithBrace)
                {
                    return new Segment(SegmentKind.Literal, segment);
                }
                int equalsIndex = segment.IndexOf('=');
                if (equalsIndex == -1)
                {
                    // Implicitly named wildcard
                    return new Segment(SegmentKind.Wildcard, segment.Substring(1, segment.Length - 2));
                }
                string name = segment.Substring(1, equalsIndex - 1);
                if (name == "")
                {
                    throw new ArgumentException($"Invalid template segment: {segment}", nameof(segment));
                }
                string match = segment.Substring(equalsIndex);
                switch (match)
                {
                    case "=*}":
                        return new Segment(SegmentKind.Wildcard, name);
                    case "=**}":
                        return new Segment(SegmentKind.PathWildcard, name);
                    default:
                        throw new ArgumentException($"Invalid template segment: {segment}", nameof(segment));
                }
            }
        }
    }
}
