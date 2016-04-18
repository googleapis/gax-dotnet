/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Common settings for all services.
    /// </summary>
    /// <remarks>
    /// This non-generic type is used for convenience for code which doesn't need to know about specific
    /// settings types. Generated settings classes derive from <see cref="ServiceSettingsBase{T}"/> to provide
    /// type-safe cloning.
    /// </remarks>
    public abstract class ServiceSettingsBase
    {
        /// <summary>
        /// Constructs a new service settings base object with a default user agent, unset call settings and
        /// unset clock.
        /// </summary>
        protected ServiceSettingsBase()
        {
            UserAgent = new UserAgentBuilder()
                .AppendDotNetEnvironment()
                .AppendAssemblyVersion("gax", typeof(CallSettings))
                .AppendAssemblyVersion("grpc", typeof(Channel))
                // TODO: Use the assembly name instead of the namespace? Allow it to be specified?
                .AppendAssemblyVersion(GetType().Namespace, GetType())
                .ToString();
        }

        /// <summary>
        /// Constructs a new service settings base object by cloning the settings from an existing one.
        /// </summary>
        /// <param name="existing">The existing settings object to clone settings from. Must not be null.</param>
        protected ServiceSettingsBase(ServiceSettingsBase existing)
        {
            GaxPreconditions.CheckNotNull(existing, nameof(existing));
            CallSettings = existing.CallSettings?.Clone();
            Clock = existing.Clock;
            UserAgent = existing.UserAgent;
        }

        internal string UserAgent { get; }

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
    }
}
