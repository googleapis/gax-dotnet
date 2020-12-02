/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Google.Api.Gax.Grpc
{
    // TODO: How do you clear one of these properties?

    /// <summary>
    /// Portable abstraction of channel options
    /// </summary>
    public sealed class GrpcChannelOptions : IEquatable<GrpcChannelOptions>
    {
        private static readonly IReadOnlyList<CustomOption> s_emptyOptions = new List<CustomOption>().AsReadOnly();

        /// <summary>
        /// An empty set of channel options.
        /// </summary>
        public static GrpcChannelOptions Empty { get; } = new GrpcChannelOptions();

        private GrpcChannelOptions(
            bool? enableServiceConfigResolution = null,
            TimeSpan? keepAliveTime = null,
            TimeSpan? keepAliveTimeout = null,
            string primaryUserAgent = null,
            int? maxSendMessageSize = null,
            int? maxReceiveMessageSize = null,
            IReadOnlyList<CustomOption> customOptions = null)
        {
            EnableServiceConfigResolution = enableServiceConfigResolution;
            KeepAliveTime = keepAliveTime;
            KeepAliveTimeout = keepAliveTimeout;
            PrimaryUserAgent = primaryUserAgent;
            MaxSendMessageSize = maxSendMessageSize;
            MaxReceiveMessageSize = maxReceiveMessageSize;
            CustomOptions = customOptions ?? s_emptyOptions;
        }

        /// <summary>
        /// If non-null, explicitly enables or disables service configuration resolution.
        /// </summary>
        public bool? EnableServiceConfigResolution { get; }

        /// <summary>
        /// If non-null, explicitly specifies the keep-alive period for the channel.
        /// This specifies how often a keep-alive request is sent.
        /// </summary>
        public TimeSpan? KeepAliveTime { get; }

        /// <summary>
        /// If non-null, explicitly specifies the keep-alive timeout for the channel.
        /// This specifies how long gRPC will wait for a keep-alive response before
        /// assuming the channel is no longer valid, and closing it.
        /// </summary>
        public TimeSpan? KeepAliveTimeout { get; }

        /// <summary>
        /// If non-null, explicitly specifies the primary user agent for the channel.
        /// </summary>
        public string PrimaryUserAgent { get; }

        /// <summary>
        /// If non-null, explicitly specifies the maximum size in bytes that can be sent from the client, per request.
        /// </summary>
        public int? MaxSendMessageSize { get; }

        /// <summary>
        /// If non-null, explicitly specifies the maximum size in bytes that can be received from the client, per response.
        /// </summary>
        public int? MaxReceiveMessageSize { get; }

        /// <summary>
        /// Immutable list of custom options. This is never null, but may be empty.
        /// </summary>
        public IReadOnlyList<CustomOption> CustomOptions { get; }

        /// <summary>
        /// Returns a new instance with the same options as this one, but with <see cref="PrimaryUserAgent"/> set to
        /// <paramref name="primaryUserAgent"/>.
        /// </summary>
        /// <param name="primaryUserAgent">The new primary user agent. Must not be null.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithPrimaryUserAgent(string primaryUserAgent) =>
            MergedWith(new GrpcChannelOptions(primaryUserAgent: GaxPreconditions.CheckNotNull(primaryUserAgent, nameof(primaryUserAgent))));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with <see cref="EnableServiceConfigResolution"/> set to
        /// <paramref name="enableServiceConfigResolution"/>.
        /// </summary>
        /// <param name="enableServiceConfigResolution">The new option for enabling service config resolution.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithEnableServiceConfigResolution(bool enableServiceConfigResolution) =>
            MergedWith(new GrpcChannelOptions(enableServiceConfigResolution: enableServiceConfigResolution));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with <see cref="KeepAliveTime"/> set to
        /// <paramref name="keepAliveTime"/>.
        /// </summary>
        /// <param name="keepAliveTime">The new keep-alive time.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithKeepAliveTime(TimeSpan keepAliveTime) =>
            MergedWith(new GrpcChannelOptions(keepAliveTime: keepAliveTime));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with <see cref="KeepAliveTimeout"/> set to
        /// <paramref name="keepAliveTimeout"/>.
        /// </summary>
        /// <param name="keepAliveTimeout">The new keep-alive timeout.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithKeepAliveTimeout(TimeSpan keepAliveTimeout) =>
            MergedWith(new GrpcChannelOptions(keepAliveTimeout: keepAliveTimeout));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with <see cref="MaxSendMessageSize"/> set to
        /// <paramref name="maxSendMessageSize"/>.
        /// </summary>
        /// <param name="maxSendMessageSize">The new maximum send message size, in bytes.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithMaxSendMessageSize(int maxSendMessageSize) =>
            MergedWith(new GrpcChannelOptions(maxSendMessageSize: maxSendMessageSize));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with <see cref="MaxReceiveMessageSize"/> set to
        /// <paramref name="maxReceiveMessageSize"/>.
        /// </summary>
        /// <param name="maxReceiveMessageSize">The new maximum receive message size, in bytes.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithMaxReceiveMessageSize(int maxReceiveMessageSize) =>
            MergedWith(new GrpcChannelOptions(maxReceiveMessageSize: maxReceiveMessageSize));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with a new integer-valued <see cref="CustomOption"/>
        /// at the end of <see cref="CustomOptions"/>.
        /// </summary>
        /// <param name="name">The name of the new custom option. Must not be null.</param>
        /// <param name="value">The value of the new custom option.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithCustomOption(string name, int value) =>
            WithCustomOption(new CustomOption(name, value));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with a new string-valued <see cref="CustomOption"/>
        /// at the end of <see cref="CustomOptions"/>.
        /// </summary>
        /// <param name="name">The name of the new custom option. Must not be null.</param>
        /// <param name="value">The value of the new custom option. Must not be null.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithCustomOption(string name, string value) =>
            WithCustomOption(new CustomOption(name, value));

        /// <summary>
        /// Returns a new instance with the same options as this one, but with a new integer-valued <see cref="CustomOption"/>
        /// at the end of <see cref="CustomOptions"/>.
        /// </summary>
        /// <param name="option">The additional custom option to include. Must not be null.</param>
        /// <returns>The new options.</returns>
        public GrpcChannelOptions WithCustomOption(CustomOption option) =>
            MergedWith(new GrpcChannelOptions(
                customOptions: new ReadOnlyCollection<CustomOption>(new[] { GaxPreconditions.CheckNotNull(option, nameof(option)) })));

        /// <summary>
        /// Returns a new object, with options from this object merged with <paramref name="overlaidOptions"/>.
        /// If an option is non-null in both objects, the one from <paramref name="overlaidOptions"/> takes priority.
        /// </summary>
        /// <param name="overlaidOptions">The overlaid options. Must not be null.</param>
        /// <returns>The new merged options.</returns>
        public GrpcChannelOptions MergedWith(GrpcChannelOptions overlaidOptions)
        {
            GaxPreconditions.CheckNotNull(overlaidOptions, nameof(overlaidOptions));
            return new GrpcChannelOptions(
                overlaidOptions.EnableServiceConfigResolution ?? EnableServiceConfigResolution,
                overlaidOptions.KeepAliveTime ?? KeepAliveTime,
                overlaidOptions.KeepAliveTimeout ?? KeepAliveTimeout,
                overlaidOptions.PrimaryUserAgent ?? PrimaryUserAgent,
                overlaidOptions.MaxSendMessageSize ?? MaxSendMessageSize,
                overlaidOptions.MaxReceiveMessageSize ?? MaxReceiveMessageSize,
                MergeCustomOptions(CustomOptions, overlaidOptions.CustomOptions));

            IReadOnlyList<CustomOption> MergeCustomOptions(IReadOnlyList<CustomOption> originalOptions, IReadOnlyList<CustomOption> overlaidOptions)
            {
                if (originalOptions.Count == 0)
                {
                    return overlaidOptions;
                }
                if (overlaidOptions.Count == 0)
                {
                    return originalOptions;
                }

                // TODO: Implement the following functionality (TODO: check this is desirable!)
                // - For all distinctly-named options, include the original options followed by the overlaid options
                // - For any option in both collections, include the new value in the original position (and not later)
                // - What happens if any option is in both places?
                return originalOptions.Concat(overlaidOptions).ToList().AsReadOnly();
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as GrpcChannelOptions);

        /// <inheritdoc />
        public override int GetHashCode() =>
            GaxEqualityHelpers.CombineHashCodes(
                EnableServiceConfigResolution.GetHashCode(),
                KeepAliveTime.GetHashCode(),
                KeepAliveTimeout.GetHashCode(),
                PrimaryUserAgent?.GetHashCode() ?? 0,
                MaxSendMessageSize.GetHashCode(),
                MaxReceiveMessageSize.GetHashCode(),
                GaxEqualityHelpers.GetListHashCode(CustomOptions));

        /// <inheritdoc />
        public bool Equals(GrpcChannelOptions other) =>
            other is object &&
            EnableServiceConfigResolution == other.EnableServiceConfigResolution &&
            KeepAliveTime == other.KeepAliveTime &&
            KeepAliveTimeout == other.KeepAliveTimeout &&
            PrimaryUserAgent == other.PrimaryUserAgent &&
            MaxSendMessageSize == other.MaxSendMessageSize &&
            MaxReceiveMessageSize == other.MaxReceiveMessageSize &&
            GaxEqualityHelpers.ListsEqual(CustomOptions, other.CustomOptions);

        /// <summary>
        /// A custom option, with a name and a value of either a 32-bit integer or a string.
        /// </summary>
        public class CustomOption : IEquatable<CustomOption>
        {
            /// <summary>
            /// Possible types of value within a custom option.
            /// </summary>
            public enum OptionType
            {
                /// <summary>
                /// Channel option with an integer value.
                /// </summary>
                Integer,

                /// <summary>
                /// Channel option with a string value.
                /// </summary>
                String
            }

            /// <summary>
            /// Name of the option. This is never null.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Value of the option, for string options. This is never null for string options, and always
            /// null for other options.
            /// </summary>
            public string StringValue { get; }

            /// <summary>
            /// Value of the option, for integer options, or 0 for other options.
            /// </summary>
            public int IntegerValue { get; }

            /// <summary>
            /// The type of value represented within this option.
            /// </summary>
            public OptionType Type { get; }

            /// <summary>
            /// Creates a custom integer option.
            /// </summary>
            /// <param name="name">The name of the option. Must not be null.</param>
            /// <param name="value">Value of the option.</param>
            public CustomOption(string name, int value)
            {
                Name = GaxPreconditions.CheckNotNull(name, nameof(name));
                StringValue = null;
                IntegerValue = value;
                Type = OptionType.Integer;
            }

            /// <summary>
            /// Creates a custom string option.
            /// </summary>
            /// <param name="name">The name of the option. Must not be null.</param>
            /// <param name="value">Value of the option. Must not be null.</param>
            public CustomOption(string name, string value)
            {
                Name = GaxPreconditions.CheckNotNull(name, nameof(name));
                StringValue = GaxPreconditions.CheckNotNull(value, nameof(value));
                IntegerValue = 0;
                Type = OptionType.String;
            }

            /// <inheritdoc />
            public override bool Equals(object obj) => Equals(obj as CustomOption);

            /// <inheritdoc />
            public override int GetHashCode() => GaxEqualityHelpers.CombineHashCodes((int) Type, IntegerValue, Name.GetHashCode(), StringValue?.GetHashCode() ?? 0);

            /// <inheritdoc />
            public bool Equals(CustomOption other) =>
                other is object &&
                Type == other.Type &&
                Name == other.Name &&
                StringValue == other.StringValue &&
                IntegerValue == other.IntegerValue;
        }
    }
}
