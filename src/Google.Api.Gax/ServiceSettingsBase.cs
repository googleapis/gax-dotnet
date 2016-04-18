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

        internal string UserAgent { get; set; }

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
        /// Copies the properties declared in <see cref="ServiceSettingsBase"/> into a new
        /// settings object.
        /// </summary>
        /// <param name="settings">The settings object to copy properties into</param>
        /// <returns><paramref name="settings"/>, for convenience when calling as part of <see cref="Clone"/>.</returns>
        protected T CloneInto<T>(T settings) where T : ServiceSettingsBase
        {
            settings.CallSettings = CallSettings.Clone();
            settings.Clock = Clock;
            settings.UserAgent = UserAgent;
            return settings;
        }
    }
}
