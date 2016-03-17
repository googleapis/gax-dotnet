/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

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

    /// <summary>
    /// Generic service settings base class to provide type-safe cloning.
    /// </summary>
    /// <remarks>
    /// The expected usage is that a derived class specifies itself as a type argument. All Google-generated
    /// derived classes follow this pattern.
    /// </remarks>
    /// <typeparam name="T">The type of settings provided by the <see cref="Clone"/> operation; expected
    /// to be the same type as the concrete subclass.</typeparam>
    public abstract class ServiceSettingsBase<T> : ServiceSettingsBase where T : ServiceSettingsBase<T>
    {
        /// <summary>
        /// Copies the properties declared in <see cref="ServiceSettingsBase"/> into a new
        /// settings object.
        /// </summary>
        /// <param name="settings">The settings object to copy properties into</param>
        /// <returns><paramref name="settings"/>, for convenience when calling as part of <see cref="Clone"/>.</returns>
        protected T CloneInto(T settings)
        {
            settings.CallSettings = CallSettings.Clone();
            settings.Clock = Clock;
            return settings;
        }

        /// <summary>
        /// Clones this object as deeply as is generally required.
        /// </summary>
        /// <remarks>The conventional implementation is to call <see cref="ServiceSettingsBase.CloneInto"/> with
        /// a new instance of the concrete subclass, and clone any remaining subclass-specific properties.</remarks>
        /// <returns>A clone of this settings object.</returns>
        public abstract T Clone();
    }
}
