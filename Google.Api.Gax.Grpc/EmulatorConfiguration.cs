// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Represents the basic emulator configuration which is
    /// constructed from environment variables.
    /// </summary>
    /// <remarks>Inherit from this class if the current API emulator
    /// needs extra configuration or if it can be configured from other than 
    /// environment variables.</remarks>
    public class EmulatorConfiguration
    {
        /// <summary>
        /// The endpoint to connect to the emulator.
        /// Can be null in which case this configuration will be considered invalid.
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// Whether this configuration is valid or not.
        /// An invalid configuration will be trated as if no configuration exists.
        /// </summary>
        /// <remarks>This property can be overwridden to include more validity constraints.</remarks>
        public virtual bool IsValid => Endpoint != null;

        /// <summary>
        /// Constructs a new emulator configuration obtaining the endpoint value
        /// from the given environment variable.
        /// </summary>
        /// <param name="emulatorEndpointVariable">An environment variable name to obtaing the emulator endpoint from.</param>
        public EmulatorConfiguration(string emulatorEndpointVariable)
        {
            // Note: we treat present-but-empty environment variables as if they were absent.
            string endpoint = Environment.GetEnvironmentVariable(emulatorEndpointVariable)?.Trim();
            Endpoint = string.IsNullOrEmpty(endpoint) ? null : endpoint;
        }
    }
}
