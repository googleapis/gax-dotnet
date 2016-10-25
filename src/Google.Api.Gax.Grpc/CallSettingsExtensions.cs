/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Grpc.Core;
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Extension methods for <see cref="CallSettings"/>.
    /// All methods accept a null first parameter as valid unless stated otherwise.
    /// </summary>
    public static class CallSettingsExtensions
    {
        /// <summary>
        /// This method merges the settings in <paramref name="overlaid"/> with those in
        /// <paramref name="original"/>, with <paramref name="overlaid"/> taking priority.
        /// If both arguments are null, the result is null. If one argument is null,
        /// the other argument is returned. Otherwise, a new object is created with a property-wise
        /// overlay, where null values do not override non-null values.
        /// Any header mutations are combined, however: the mutation from the original is
        /// performed, then the mutation in the overlay.
        /// </summary>
        /// <param name="original">Original settings. May be null.</param>
        /// <param name="overlaid">Settings to overlay. May be null.</param>
        /// <returns>A merged set of call settings, or null if both parameters are null.</returns>
        public static CallSettings MergedWith(this CallSettings original, CallSettings overlaid)
            => CallSettings.Merge(original, overlaid);

        /// <summary>
        /// Returns a new <see cref="CallSettings"/> with the specified cancellation token,
        /// merged with the (optional) original settings specified by <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Original settings. May be null, in which case the returned settings
        /// will only contain the cancellation token.</param>
        /// <param name="cancellationToken">Cancellation token for the new call settings.</param>
        /// <returns>A new set of call settings.</returns>
        public static CallSettings WithCancellationToken(
            this CallSettings settings,
            CancellationToken cancellationToken) =>
            settings.MergedWith(CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns a new <see cref="CallSettings"/> with the specified call credentials,
        /// merged with the (optional) original settings specified by <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Original settings. May be null, in which case the returned settings
        /// will only contain call credentials.</param>
        /// <param name="credentials">Call credentials for the new call settings.
        /// This may be null, in which case any call credentials in <paramref name="settings"/> are
        /// not present in the new call settings. If both this and <paramref name="settings"/> are null,
        /// the return value is null.</param>
        /// <returns>A new set of call settings, or null if both parameters are null.</returns>
        public static CallSettings WithCallCredentials(
            this CallSettings settings,
            CallCredentials credentials) =>
            settings == null
                ? CallSettings.FromCallCredentials(credentials)
                : new CallSettings(settings.CancellationToken, credentials,
                    settings.Timing, settings.HeaderMutation,
                    settings.WriteOptions, settings.PropagationToken);

        /// <summary>
        /// Returns a new <see cref="CallSettings"/> with the specified call timing,
        /// merged with the (optional) original settings specified by <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Original settings. May be null, in which case the returned settings
        /// will only contain call timing.</param>
        /// <param name="timing">Call timing for the new call settings.
        /// This may be null, in which case any call timing in <paramref name="settings"/> are
        /// not present in the new call settings. If both this and <paramref name="settings"/> are null,
        /// the return value is null.</param>
        /// <returns>A new set of call settings, or null if both parameters are null.</returns>
        public static CallSettings WithCallTiming(
            this CallSettings settings,
            CallTiming timing) =>
            settings == null
                ? CallSettings.FromCallTiming(timing)
                : new CallSettings(settings.CancellationToken, settings.Credentials,
                    timing, settings.HeaderMutation,
                    settings.WriteOptions, settings.PropagationToken);

        /// <summary>
        /// Returns a new <see cref="CallSettings"/> with the specified header,
        /// merged with the (optional) original settings specified by <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Original settings. May be null, in which case the returned settings
        /// will only contain the header.</param>
        /// <param name="name">Header name. Must not be null.</param>
        /// <param name="value">Header value. Must not be null.</param>
        /// <returns>A new set of call settings including the specified header.</returns>
        public static CallSettings WithHeader(this CallSettings settings, string name, string value) =>
            settings.MergedWith(CallSettings.FromHeader(name, value));

        /// <summary>
        /// Transfers settings contained in this into a <see cref="CallOptions"/>.
        /// </summary>
        /// <param name="baseSettings">The base settings for the call. May be null.</param>
        /// <param name="callSettings">The settings for the specific call. May be null.</param>
        /// <param name="clock">The clock to use for deadline calculation.</param>
        /// <returns>A <see cref="CallOptions"/> configured from this <see cref="CallSettings"/>.</returns>
        internal static CallOptions ToCallOptions(this CallSettings baseSettings, CallSettings callSettings, IClock clock)
        {
            CallSettings effectiveSettings = baseSettings.MergedWith(callSettings);
            if (effectiveSettings == null)
            {
                return default(CallOptions);
            }
            var metadata = new Metadata();
            effectiveSettings.HeaderMutation?.Invoke(metadata);
            return new CallOptions(
                headers: metadata,
                deadline: effectiveSettings.Timing.CalculateDeadline(clock),
                cancellationToken: effectiveSettings.CancellationToken ?? default(CancellationToken),
                writeOptions: effectiveSettings.WriteOptions,
                propagationToken: effectiveSettings.PropagationToken,
                credentials: effectiveSettings.Credentials);
        }
    }
}
