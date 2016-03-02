/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;

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
    public sealed class ResourceName
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
                if (value == "")
                {
                    throw new ArgumentException("Service name cannot be empty", nameof(value));
                }
                if (value != null && value.Contains("/"))
                {
                    throw new ArgumentException("Service name cannot be contain /", nameof(value));
                }
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
            int index = Template.ParameterNames.IndexOf(parameterName);
            if (index == -1)
            {
                throw new KeyNotFoundException($"Template doesn't contain a parameter named '{parameterName}'");
            }
            return index;
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
        public ResourceName(PathTemplate template, params string[] resourceIds)
        {
            Template = template;
            this._resourceIds = (string[]) resourceIds.Clone();
            GaxPreconditions.CheckNotNull(resourceIds, nameof(resourceIds));
            // This is a somewhat annoying defensive copy. Given that we're usually going to just call ToString()
            // on the ResourceName, we don't really need the cloned array, or even the ResourceName itself.
            resourceIds = (string[]) resourceIds.Clone();
            template.ValidateResourceIds(resourceIds);
        }

        /// <summary>
        /// Creates a clone of this resource name, which is then independent of the original.
        /// </summary>
        /// <returns>A clone of this resource name.</returns>
        public ResourceName Clone()
        {
            return new ResourceName(Template, ServiceName, (string[]) _resourceIds.Clone(), true);
        }

        /// <summary>
        /// Private constructor used by internal code to avoid repeated cloning and validation.
        /// </summary>
        private ResourceName(PathTemplate template, string serviceName, string[] resourceIds, bool ignored)
        {
            Template = GaxPreconditions.CheckNotNull(template, nameof(template));
            ServiceName = serviceName;
            this._resourceIds = resourceIds;
        }

        internal static ResourceName CreateWithShallowCopy(PathTemplate template, string serviceName, string[] resourceIds)
        {
            return new ResourceName(template, serviceName, resourceIds, true);
        }

        public override string ToString() => Template.ReplaceParameters(ServiceName, _resourceIds);
    }
}
