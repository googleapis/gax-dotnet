/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;

namespace Google.Api.Gax
{
    /// <summary>
    /// Class for representing and working with resource names.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A resource name is represented by a <see cref="PathTemplate"/>, an assignment of resource IDs to parameters in
    /// the template, and an optional service name. This class allows the service name and resource IDs to be
    /// modified, but only within the same template.
    /// </para>
    /// </remarks>
    public sealed class TemplatedResourceName : IResourceName, IEquatable<TemplatedResourceName>
    {
        /// <summary>
        /// The template this resource name is associated with. Never null.
        /// </summary>
        public PathTemplate Template { get; }

        private string _serviceName;
        /// <summary>
        /// The service name part of this resource name, or null if no service name is specified.
        /// </summary>
        public string ServiceName
        {
            get { return _serviceName; }
            set
            {
                PathTemplate.ValidateServiceName(_serviceName, nameof(value));
                _serviceName = value;
            }
        }

        private string[] _resourceIds;

        /// <summary>
        /// Gets or sets the identifier for the specified parameter index.
        /// </summary>
        /// <param name="index">The index of the parameter value to retrieve.</param>
        /// <returns>The identifier within the resource name at the given parameter index.</returns>
        public string this[int index]
        {
            get { return _resourceIds[index]; }
            set
            {
                Template.ValidateResourceId(index, value);
                _resourceIds[index] = value;
            }
        }

        private int GetParameterIndex(string parameterName)
        {
            GaxPreconditions.CheckNotNull(parameterName, nameof(parameterName));
            var names = Template.ParameterNames;
            // Annoyingly, IReadOnlyList doesn't have IndexOf... (and nor does LINQ)
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i] == parameterName)
                {
                    return i;
                }
            }
            throw new KeyNotFoundException($"Template doesn't contain a parameter named '{parameterName}'");
        }

        /// <summary>
        /// Gets or sets the identifier for the specified parameter name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter value to retrieve.</param>
        /// <returns>The identifier within the resource name with the given parameter name.</returns>
        public string this[string parameterName]
        {
            get { return this[GetParameterIndex(parameterName)]; }
            set { this[GetParameterIndex(parameterName)] = value; }
        }

        /// <summary>
        /// Creates a resource name with the given template and resource IDs.
        /// The resource IDs are cloned, so later changes to <paramref name="resourceIds"/>
        /// are ignored. This constructor does not populate the <see cref="ServiceName"/> property,
        /// but that can be set after construction.
        /// </summary>
        /// <param name="template">The template for the new resource name. Must not be null.</param>
        /// <param name="resourceIds">The resource IDs to populate template parameters with. Must not be null.</param>
        public TemplatedResourceName(PathTemplate template, params string[] resourceIds)
        {
            Template = GaxPreconditions.CheckNotNull(template, nameof(Template));
            GaxPreconditions.CheckNotNull(resourceIds, nameof(resourceIds));
            // This is a somewhat annoying defensive copy. Given that we're usually going to just call ToString()
            // on the ResourceName, we don't really need the cloned array, or even the ResourceName itself.
            _resourceIds = (string[]) resourceIds.Clone();
            template.ValidateResourceIds(_resourceIds);
        }

        /// <summary>
        /// Creates a clone of this resource name, which is then independent of the original.
        /// </summary>
        /// <returns>A clone of this resource name.</returns>
        public TemplatedResourceName Clone()
        {
            return new TemplatedResourceName(Template, ServiceName, (string[]) _resourceIds.Clone(), true);
        }

        /// <summary>
        /// Private constructor used by internal code to avoid repeated cloning and validation.
        /// </summary>
        private TemplatedResourceName(PathTemplate template, string serviceName, string[] resourceIds, bool ignored)
        {
            Template = GaxPreconditions.CheckNotNull(template, nameof(template));
            ServiceName = serviceName;
            this._resourceIds = resourceIds;
        }

        internal static TemplatedResourceName CreateWithShallowCopy(PathTemplate template, string serviceName, string[] resourceIds)
        {
            return new TemplatedResourceName(template, serviceName, resourceIds, true);
        }

        /// <inheritdoc />
        public bool IsKnownPattern => true;

        /// <summary>
        /// Returns a string representation of this resource name, expanding the template
        /// parameters with the resource IDs and prepending the service name (if present).
        /// </summary>
        /// <returns>A string representation of this resource name.</returns>
        public override string ToString() => Template.ReplaceParameters(ServiceName, _resourceIds);

        /// <inheritdoc />
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as TemplatedResourceName);

        /// <inheritdoc />
        public bool Equals(TemplatedResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc />
        public static bool operator ==(TemplatedResourceName a, TemplatedResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc />
        public static bool operator !=(TemplatedResourceName a, TemplatedResourceName b) => !(a == b);
    }
}
