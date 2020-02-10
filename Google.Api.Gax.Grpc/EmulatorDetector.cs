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
    /// Determines whether an emulator configuration should be used or not.
    /// </summary>
    /// <typeparam name="TEmulatorConfiguration"></typeparam>
    public sealed class EmulatorDetector<TEmulatorConfiguration>
        where TEmulatorConfiguration : EmulatorConfiguration
    {
        private EmulatorDetection _emulatorDetection;
        // TODO: Maybe support async in case the configuration is not obtained from env variables.
        private readonly Func<TEmulatorConfiguration> _configurationBuilder;

        /// <summary>
        /// Specifies how the builder responds to the existence of an emulator configuration.
        /// </summary>
        /// <remarks>
        /// This property defaults to <see cref="EmulatorDetection.None"/>, meaning that the emulator
        /// configuration is ignored.
        /// </remarks>
        public EmulatorDetection EmulatorDetection
        {
            get => _emulatorDetection;
            set => _emulatorDetection = GaxPreconditions.CheckEnumValue(value, nameof(value));
        }

        /// <summary>
        /// Constructs a new emulator detector that will use the given function
        /// to obtain emulator configurations.
        /// </summary>
        /// <param name="configurationFactory">A function for obtaning emulator configurations.
        /// May return null or configurations where <see cref="EmulatorConfiguration.IsValid"/> 
        /// is false. Both cases will be treated as if no emulator configuration exists.</param>
        public EmulatorDetector(Func<TEmulatorConfiguration> configurationFactory) =>
            _configurationBuilder = GaxPreconditions.CheckNotNull(configurationFactory, nameof(configurationFactory));

        /// <summary>
        /// Attempts to detect an emulator configuration and if found assigns it to the given patameter.
        /// Detecting an emulator configuration is both affected by whether an actual valid configuration
        /// exists and the value of <see cref="EmulatorDetection"/>.
        /// </summary>
        /// <param name="emulatorConfiguration">The emulator configuration that should be use, if any.</param>
        /// <returns>true if a configuration was detected, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">
        /// If the value of <see cref="EmulatorDetection"/> is <see cref="EmulatorDetection.ProductionOnly"/>
        /// and a valid emulator configuration was detected.
        /// If the value of <see cref="EmulatorDetection"/> is <see cref="EmulatorDetection.EmulatorOnly"/>
        /// and there was no valid emulator configuration detected.
        /// </exception>
        public bool TryDetectEmulator(out TEmulatorConfiguration emulatorConfiguration)
        {
            emulatorConfiguration = null;
            if (EmulatorDetection == EmulatorDetection.None)
            {
                return false;
            }

            var config = _configurationBuilder();
            // Invalid configuration is treated the same as non-existent configuration.
            config = config.IsValid ? config : null;
            switch (EmulatorDetection)
            {
                case EmulatorDetection.ProductionOnly:
                    GaxPreconditions.CheckState(
                        config == null,
                        $"Emulator configuration detected, contrary to use of {EmulatorDetection.ProductionOnly}");
                    return false;
                case EmulatorDetection.EmulatorOnly:
                    GaxPreconditions.CheckState(
                        config != null,
                        "Emulator configuration couldn't be found.");
                    emulatorConfiguration = config;
                    return true;
                case EmulatorDetection.EmulatorOrProduction:
                    if (config != null)
                    {
                        emulatorConfiguration = config;
                        return true;
                    }
                    return false;
            }
            // We should never get to this point.
            // TODO: Consider throwing instead?
            return false;
        }
    }
}
