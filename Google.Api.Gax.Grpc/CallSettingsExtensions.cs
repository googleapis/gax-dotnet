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
        /// Obsolete. https://github.com/googleapis/gax-dotnet/blob/master/PER_CALL_CREDENTIAL.md
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
        [Obsolete("https://github.com/googleapis/gax-dotnet/blob/master/PER_CALL_CREDENTIAL.md")]
        public static CallSettings WithCallCredentials(
            this CallSettings settings,
            CallCredentials credentials) =>
            settings == null
                ? CallSettings.FromCallCredentials(credentials)
                : new CallSettings(settings.CancellationToken, credentials,
                    settings.Expiration, settings.Retry, settings.HeaderMutation,
                    settings.WriteOptions, settings.PropagationToken,
                    settings.ResponseMetadataHandler, settings.TrailingMetadataHandler);

        /// <summary>
        /// Returns a new <see cref="CallSettings"/> with the specified expiration,
        /// merged with the (optional) original settings specified by <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Original settings. May be null, in which case the returned settings
        /// will only contain the expiration.</param>
        /// <param name="expiration">Expiration to use in the returned settings, possibly as part of a retry. May be null,
        /// in which case any expiration in <paramref name="settings"/> is not present in the new call settings. If
        /// both this and <paramref name="settings"/> are null, the return value is null.</param>
        /// <returns>A new set of call settings with the specified expiration, or null of both parameters are null.</returns>
        public static CallSettings WithExpiration(
            this CallSettings settings,
            Expiration expiration) =>
            settings == null
                ? CallSettings.FromExpiration(expiration)
#pragma warning disable CS0618 // Type or member is obsolete
                // But as long as user code can specify credentials we should continue to respect that.
                : new CallSettings(settings.CancellationToken, settings.Credentials,
                    expiration, settings.Retry, settings.HeaderMutation,
                    settings.WriteOptions, settings.PropagationToken,
                    settings.ResponseMetadataHandler, settings.TrailingMetadataHandler);
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// Returns a new <see cref="CallSettings"/> with the specified retry settings,
        /// merged with the (optional) original settings specified by <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Original settings. May be null, in which case the returned settings
        /// will only contain call timing.</param>
        /// <param name="retry">Call timing for the new call settings.
        /// This may be null, in which case any retry settings in <paramref name="settings"/> are
        /// not present in the new call settings. If both this and <paramref name="settings"/> are null,
        /// the return value is null.</param>
        /// <returns>A new set of call settings, or null if both parameters are null.</returns>
        public static CallSettings WithRetry(
            this CallSettings settings,
            RetrySettings retry) =>
            settings == null
                ? CallSettings.FromRetry(retry)
#pragma warning disable CS0618 // Type or member is obsolete
                // But as long as user code can specify credentials we should continue to respect that.
                : new CallSettings(settings.CancellationToken, settings.Credentials,
                    settings.Expiration, retry, settings.HeaderMutation,
                    settings.WriteOptions, settings.PropagationToken,
                    settings.ResponseMetadataHandler, settings.TrailingMetadataHandler);
#pragma warning restore CS0618 // Type or member is obsolete

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
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static CallSettings WithResponseMetadataHandler(this CallSettings settings, Action<Metadata> handler) =>
            settings.MergedWith(CallSettings.FromResponseMetadataHandler(handler));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static CallSettings WithTrailingMetadataHandler(this CallSettings settings, Action<Metadata> handler) =>
            settings.MergedWith(CallSettings.FromTrailingMetadataHandler(handler));

        /// <summary>
        /// Returns a <see cref="CallSettings"/> which will have the specified deadline.
        /// </summary>
        /// <param name="settings">Existing settings. May be null, meaning there are currently no settings.</param>
        /// <param name="deadline">The deadline for the new settings.</param>
        /// <returns>A new <see cref="CallSettings"/> with the given deadline.</returns>
        public static CallSettings WithDeadline(this CallSettings settings, DateTime deadline) =>
            settings.WithExpiration(Expiration.FromDeadline(deadline));

        /// <summary>
        /// Returns a <see cref="CallSettings"/> which will have the specified timeout.
        /// </summary>
        /// <param name="settings">Existing settings. May be null, meaning there are currently no settings.</param>
        /// <param name="timeout">The timeout for the new settings.</param>
        /// <returns>A new <see cref="CallSettings"/> with the given timeout.</returns>
        public static CallSettings WithTimeout(this CallSettings settings, TimeSpan timeout) =>
            settings.WithExpiration(Expiration.FromTimeout(timeout));

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
            // No settings, or no expiration in the settings? Create a simple expiration.
            var expiration = settings?.Expiration;
            if (expiration == null)
            {
                // WithDeadline (above) is an extension method - it's fine for settings to be null.
                return settings.WithDeadline(deadline.Value);
            }
            // Okay, we have settings with am existing expiration and a new deadline.
            // We may still return the existing settings, if the new deadline is later than the existing
            // one in the settings. But if the new deadline is earlier, we need to build new settings to accommodate
            // it.
            var existingDeadline = expiration.CalculateDeadline(clock);
            return existingDeadline < deadline.Value
                ? settings
                : settings.WithDeadline(deadline.Value);
        }

        /// <summary>
        /// Throws <see cref="InvalidOperationException"/> if <paramref name="callSettings"/> is non-null and has a Retry;
        /// otherwise returns the parameter.
        /// </summary>
        /// <param name="callSettings">The call settings for the call. May be null.</param>
        /// <returns><paramref name="callSettings"/></returns>
        internal static CallSettings ValidateNoRetry(this CallSettings callSettings)
        {
            GaxPreconditions.CheckState(callSettings?.Retry is null, "Retry not permitted for this operation type");
            return callSettings;
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
                // Note: extension method which handles a null expiration.
                deadline: callSettings.Expiration.CalculateDeadline(clock),
                cancellationToken: callSettings.CancellationToken ?? default(CancellationToken),
                writeOptions: callSettings.WriteOptions,
                propagationToken: callSettings.PropagationToken,
#pragma warning disable CS0618 // Type or member is obsolete
                // But as long as user code can specify credentials we should continue to respect that.
                credentials: callSettings.Credentials);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
