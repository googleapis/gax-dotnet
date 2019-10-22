/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Grpc.Core.Interceptors;
using System;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Common settings for all services.
    /// </summary>
    public abstract class ServiceSettingsBase
    {
        /// <summary>
        /// Constructs a new service settings base object for a stable API with a default version header, unset call settings and
        /// unset clock.
        /// </summary>
        protected ServiceSettingsBase() : this(LaunchStage.Ga)
        {
        }

        /// <summary>
        /// Constructs a new service settings base object for the given API stability level with a default version header, unset call settings and
        /// unset clock.
        /// </summary>
        protected ServiceSettingsBase(LaunchStage stabilityLevel)
        {
            VersionHeaderBuilder = new VersionHeaderBuilder()
                .AppendDotNetEnvironment()
                .AppendAssemblyVersion("gccl", GetType())
                .AppendAssemblyVersion("gapic", GetType())
                .AppendAssemblyVersion("gax", typeof(CallSettings))
                .AppendAssemblyVersion("grpc", typeof(Channel));
            StabilityLevel = stabilityLevel;
        }

        /// <summary>
        /// Constructs a new service settings base object by cloning the settings from an existing one.
        /// </summary>
        /// <param name="existing">The existing settings object to clone settings from. Must not be null.</param>
        protected ServiceSettingsBase(ServiceSettingsBase existing)
        {
            GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CallSettings = existing.CallSettings;
            Clock = existing.Clock;
            Scheduler = existing.Scheduler;
            VersionHeaderBuilder = existing.VersionHeaderBuilder.Clone();
            Interceptor = existing.Interceptor;
            StabilityLevel = existing.StabilityLevel;
        }

        /// <summary>
        /// The stability view of the API to be accessed. This affects whether/what X-Goog-Visibilities header
        /// is sent. We may make this public in the future.
        /// </summary>
        internal LaunchStage StabilityLevel { get; }

        /// <summary>
        /// A builder for x-goog-api-client version headers. Additional library versions can be appended via this property.
        /// </summary>
        internal VersionHeaderBuilder VersionHeaderBuilder { get; }

        internal string VersionHeader => VersionHeaderBuilder.ToString();

        /// <summary>
        /// If not null, <see cref="CallSettings"/> that are applied to every RPC performed by the client.
        /// If null or unset, RPC default settings will be used for all settings.
        /// </summary>
        public CallSettings CallSettings { get; set; }

        /// <summary>
        /// If not null, the clock used to calculate RPC deadlines. If null or unset, the <see cref="SystemClock"/> is used.
        /// </summary>
        /// <remarks>
        /// This is primarily only to be set for testing.
        /// In production code generally leave this unset to use the <see cref="SystemClock"/>.
        /// </remarks>
        public IClock Clock { get; set; }

        /// <summary>
        /// If not null, the scheduler used for delays between operations (e.g. for retry).
        /// If null or unset, the <see cref="SystemScheduler"/> is used.
        /// </summary>
        /// <remarks>
        /// This is primarily only to be set for testing.
        /// In production code generally leave this unset to use the <see cref="SystemScheduler"/>.
        /// </remarks>
        public IScheduler Scheduler { get; set; }

        /// <summary>
        /// An optional gRPC interceptor to perform arbitrary interception tasks (such as logging) on gRPC calls.
        /// Note that this property is not used by code generated before August 2nd 2018: only packages created
        /// on or after that date are aware of this property.
        /// </summary>
        public Interceptor Interceptor { get; set; }
    }
}
