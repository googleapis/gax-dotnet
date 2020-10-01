/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Tests
{
    /// <summary>
    /// Helper to restore the value of an environment variable when it's disposed.
    /// </summary>
    internal sealed class EnvironmentVariableRestorer : IDisposable
    {
        private readonly string m_variableName;
        private readonly string m_originalValue;

        /// <summary>
        /// Stores the existing value of an environment variable without changing it.
        /// </summary>
        internal EnvironmentVariableRestorer(string name) =>
            (m_variableName, m_originalValue) = (name, Environment.GetEnvironmentVariable(name));

        /// <summary>
        /// Stores the existing value of an environment variable and sets a new value.
        /// </summary>
        internal EnvironmentVariableRestorer(string name, string valueToSet) : this(name)
        {
            // Chained constructor will already have saved the orignal value.
            Environment.SetEnvironmentVariable(name, valueToSet);
        }

        public void Dispose() => Environment.SetEnvironmentVariable(m_variableName, m_originalValue);
    }
}
