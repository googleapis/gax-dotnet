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

namespace Google.Api.Gax
{
    /// <summary>
    /// Specifies whether or not an emulator configuration should be present and 
    /// whether or not it should be used. Emulator configuration is usually specified
    /// through environment variables.
    /// </summary>
    public enum EmulatorDetection
    {
        /// <summary>
        /// Ignores the presence or absence of emulator configuration.
        /// </summary>
        None = 0,

        /// <summary>
        /// Always connect to the production servers, but throw an exception if
        /// an emulator configuration is detected that would suggest connecting to
        /// an emulator is expected.
        /// </summary>
        ProductionOnly = 1,

        /// <summary>
        /// Always connect to the emulator, throwing an exception if no emulator
        /// configuration is detected.
        /// </summary>
        EmulatorOnly = 2,

        /// <summary>
        /// Connect to the emulator if an emulator configuration is detected,
        /// or production otherwise. This is a convenient option, but risks damage to
        /// production databases or running up unexpected bills if tests are accidentally
        /// run in production due to the emulator configuration being absent unexpectedly.
        /// (Using separate projects for production and testing is a best practice for
        /// preventing the first issue, but may be unrealistic for small or hobby projects.)
        /// </summary>
        EmulatorOrProduction = 3
    }
}