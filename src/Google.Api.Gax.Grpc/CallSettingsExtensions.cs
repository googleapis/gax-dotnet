/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Grpc.Core;
using System;
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
        /// Returns a <see cref="CallSettings"/> which will have an effective deadline of at least <paramref name="deadline"/>.
        /// If <paramref name="settings"/> already observes an earlier deadline (with respect to <paramref name="clock"/>),
        /// or if <paramref name="deadline"/> is null, the original settings will be returned.
        /// </summary>
        /// <param name="settings">Existing settings. May be null, meaning there are currently no settings.</param>
        /// <param name="deadline">Deadline to enforce. May be null, meaning there is no deadline to enforce.</param>
        /// <param name="clock">The clock to use when computing deadlines. Must not be null.</param>
        /// <returns>The call settings to use to observe the given deadline.</returns>
        public static CallSettings WithEarlierDeadline(this CallSettings settings, DateTime? deadline, IClock clock)
        {
            GaxPreconditions.CheckNotNull(clock, nameof(clock));
            // No deadline? Return what we already have.
            if (deadline == null)
            {
                return settings;
            }
            // No settings, or no timing in the settings? Create a simple expiration.
            if (settings == null || settings.Timing == null)
            {
                // WithCallTiming (above) is an extension method - it's fine for settings to be null.
                return settings.WithCallTiming(CallTiming.FromDeadline(deadline.Value));
            }
            // Okay, we have settings with a genuine timing component and a new deadline.
            // We may still return the existing settings, if the new deadline is later than the existing
            // one in the settings. But if the new deadline is earlier, we need to build new settings to accommodate
            // it.
            var timing = settings.Timing;
            switch (timing.Type)
            {
                // For simple expirations, we can just replace one deadline for another simple one,
                // if necessary.
                case CallTimingType.Expiration:
                    return timing.Expiration.CalculateDeadline(clock) < deadline.Value
                        ? settings
                        : settings.WithCallTiming(CallTiming.FromDeadline(deadline.Value));
                // For retries, we may need to create a new RetrySettings with all the same other aspects,
                // but a new deadline.
                case CallTimingType.Retry:
                    if (timing.Retry.TotalExpiration.CalculateDeadline(clock) < deadline.Value)
                    {
                        return settings;
                    }
                    var newTiming = CallTiming.FromRetry(timing.Retry.WithTotalExpiration(Expiration.FromDeadline(deadline.Value)));
                    return settings.WithCallTiming(newTiming);
                default:
                    throw new InvalidOperationException("Invalid call timing type");
            }
        }

        /// <summary>
        /// Transfers settings contained in this into a <see cref="CallOptions"/>.
        /// </summary>
        /// <param name="callSettings">The call settings for the call. May be null.</param>
        /// <param name="clock">The clock to use for deadline calculation.</param>
        /// <returns>A <see cref="CallOptions"/> configured from this <see cref="CallSettings"/>.</returns>
        internal static CallOptions ToCallOptions(this CallSettings callSettings, IClock clock)
        {
            if (callSettings == null)
            {
                return default(CallOptions);
            }
            var metadata = new Metadata();
            callSettings.HeaderMutation?.Invoke(metadata);
            return new CallOptions(
                headers: metadata,
                deadline: callSettings.Timing.CalculateDeadline(clock),
                cancellationToken: callSettings.CancellationToken ?? default(CancellationToken),
                writeOptions: callSettings.WriteOptions,
                propagationToken: callSettings.PropagationToken,
                credentials: callSettings.Credentials);
        }
    }
}
