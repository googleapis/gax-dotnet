/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Attribute to indicate that a class represents a Google API client which can be
    /// instantiated via the given builder type. (This would be generated.)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GoogleApiClientAttribute : Attribute
    {
        /// <summary>
        /// The builder type for the client.
        /// </summary>
        public Type BuilderType { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="builderType"></param>
        public GoogleApiClientAttribute(Type builderType)
        {
            BuilderType = builderType;
        }
    }
}
