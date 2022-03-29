/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Implementation of <see cref="GrpcAdapter"/> for Grpc.Core.
    /// </summary>
    public sealed class GrpcCoreAdapter : GrpcAdapter
    {
        private const string GrpcCoreAssemblyName = "Grpc.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=d754f35622e28bad";

        // Option names, copied from ChannelOptions
        internal const string ServiceConfigDisableResolution = "grpc.service_config_disable_resolution";
        internal const string KeepAliveTimeMs = "grpc.keepalive_time_ms";
        internal const string KeepAliveTimeoutMs = "grpc.keepalive_timeout_ms";
        internal const string MaxReceiveMessageLength = "grpc.max_receive_message_length";
        internal const string MaxSendMessageLength = "grpc.max_send_message_length";
        internal const string PrimaryUserAgentString = "grpc.primary_user_agent";

        // Note: we create the channel factory lazily rather than as part of type initialization as it can
        // throw if the dependency is missing. Type initialization failing can make all kinds of things messy.
        private static Lazy<Func<string, ChannelCredentials, GrpcChannelOptions, ChannelBase>> channelFactory =
            new Lazy<Func<string, ChannelCredentials, GrpcChannelOptions, ChannelBase>>(CreateChannelFactory, LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Prevent lazy type initialization.
        /// </summary>
        static GrpcCoreAdapter()
        {
        }

        /// <summary>
        /// Returns the singleton instance of this class.
        /// </summary>
        public static GrpcCoreAdapter Instance { get; } = new GrpcCoreAdapter();

        private GrpcCoreAdapter() : base(GrpcTransports.Grpc)
        {
        }

        /// <inheritdoc />
        private protected override ChannelBase CreateChannelImpl(ServiceMetadata serviceMetadata, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            channelFactory.Value.Invoke(endpoint, credentials, options);

        /// <summary>
        /// Creates a delegate that can be used to create a channel in <see cref="CreateChannelImpl"/>. We do this once, via
        /// expression trees, to avoid having to perform a lot of reflection every time we create a channel.
        /// </summary>
        private static Func<string, ChannelCredentials, GrpcChannelOptions, ChannelBase> CreateChannelFactory()
        {
            var optionType = System.Type.GetType("Grpc.Core.ChannelOption, " + GrpcCoreAssemblyName);
            if (optionType is null)
            {
                throw new InvalidOperationException("Unable to find Grpc.Core types. Please ensure you have a suitable Grpc.Core dependency");
            }

            // Result should be equivalent to
            // new Channel(endpoint, credentials, ConvertOptions(options));

            // TODO: Benchmark using expressions vs invoking the Channel constructor by reflection.
            // The latter may be more friendly to environments where expression trees do not work -
            // but in those environments, it's unlikely that Grpc.Core is being used anyway.
            // The other methods can be invoked with delegates, but delegates can't refer directly to methods.

            // TODO: Somehow cache the result of ConvertOptions? It's probably not called terribly frequently.

            // Create a delegate that calls new ChannelOption(string, int)
            var int32OptionNameParam = Expression.Parameter(typeof(string), "name");
            var int32OptionValueParam = Expression.Parameter(typeof(int), "intValue");
            var int32OptionCtor = optionType.GetConstructor(new[] { typeof(string), typeof(int) });
            var int32OptionFunc = Expression.Lambda(
                typeof(Func<,,>).MakeGenericType(typeof(string), typeof(int), optionType),
                Expression.New(int32OptionCtor, int32OptionNameParam, int32OptionValueParam),
                int32OptionNameParam, int32OptionValueParam)
                .Compile();

            // Create a delegate that calls new ChannelOption(string, string)
            var stringOptionNameParam = Expression.Parameter(typeof(string), "name");
            var stringOptionValueParam = Expression.Parameter(typeof(string), "stringValue");
            var stringOptionCtor = optionType.GetConstructor(new[] { typeof(string), typeof(string) });
            var stringOptionFunc = Expression.Lambda(
                typeof(Func<,,>).MakeGenericType(typeof(string), typeof(string), optionType),
                Expression.New(stringOptionCtor, stringOptionNameParam, stringOptionValueParam),
                stringOptionNameParam, stringOptionValueParam)
                .Compile();

            // Create an expression tree that calls ConvertOptions<ChannelOption>(...)
            var neutralOptionsParam = Expression.Parameter(typeof(GrpcChannelOptions), "options");
            var convertOptionsMethod = typeof(GrpcCoreAdapter).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Single(method => method.Name == nameof(ConvertOptions))
                .MakeGenericMethod(optionType);
            var convertOptionsCall = Expression.Call(null, convertOptionsMethod, neutralOptionsParam, Expression.Constant(int32OptionFunc), Expression.Constant(stringOptionFunc));

            // Create an expression tree for the Channel constructor call
            var channelType = System.Type.GetType("Grpc.Core.Channel, " + GrpcCoreAssemblyName);
            var optionsType = typeof(IEnumerable<>).MakeGenericType(optionType);
            var channelCtor = channelType.GetConstructor(new[] { typeof(string), typeof(ChannelCredentials), optionsType });
            var targetParam = Expression.Parameter(typeof(string), "target");
            var credentialsParam = Expression.Parameter(typeof(ChannelCredentials), "credentials");
            var ctorExpression = Expression.New(channelCtor, targetParam, credentialsParam, convertOptionsCall);

            // Compile the expression tree into a delegate we can use.
            return Expression.Lambda<Func<string, ChannelCredentials, GrpcChannelOptions, ChannelBase>>(ctorExpression, targetParam, credentialsParam, neutralOptionsParam)
                .Compile();
        }

        /// <summary>
        /// Converts a <see cref="GrpcChannelOptions"/> (defined in Google.Api.Gax.Grpc) into a list
        /// of ChannelOption (defined in Grpc.Core). This is generic to allow the simple use of delegates
        /// for option factories. Internal for testing.
        /// </summary>
        /// <param name="options">The options to convert. Must not be null.</param>
        /// <param name="int32OptionFactory">Factory delegate to create an option from an integer value</param>
        /// <param name="stringOptionFactory">Factory delegate to create an option from an integer value</param>
        internal static IReadOnlyList<T> ConvertOptions<T>(GrpcChannelOptions options, Func<string, int, T> int32OptionFactory, Func<string, string, T> stringOptionFactory)
        {
            GaxPreconditions.CheckNotNull(options, nameof(options));
            List<T> ret = new List<T>();
            if (options.EnableServiceConfigResolution is bool enableServiceConfigResolution)
            {
                ret.Add(int32OptionFactory(ServiceConfigDisableResolution, enableServiceConfigResolution ? 0 : 1));
            }
            if (options.KeepAliveTime is TimeSpan keepAlive)
            {
                ret.Add(int32OptionFactory(KeepAliveTimeMs, (int) keepAlive.TotalMilliseconds));
            }
            if (options.KeepAliveTimeout is TimeSpan keepAliveout)
            {
                ret.Add(int32OptionFactory(KeepAliveTimeoutMs, (int) keepAliveout.TotalMilliseconds));
            }
            if (options.MaxReceiveMessageSize is int maxReceiveMessageSize)
            {
                ret.Add(int32OptionFactory(MaxReceiveMessageLength, maxReceiveMessageSize));
            }
            if (options.MaxSendMessageSize is int maxSendMessageSize)
            {
                ret.Add(int32OptionFactory(MaxSendMessageLength, maxSendMessageSize));
            }
            if (options.PrimaryUserAgent is string primaryUserAgent)
            {
                ret.Add(stringOptionFactory(PrimaryUserAgentString, primaryUserAgent));
            }
            foreach (var customOption in options.CustomOptions)
            {
                var channelOption = customOption.Type switch
                {
                    GrpcChannelOptions.CustomOption.OptionType.Integer => int32OptionFactory(customOption.Name, customOption.IntegerValue),
                    GrpcChannelOptions.CustomOption.OptionType.String => stringOptionFactory(customOption.Name, customOption.StringValue),
                    _ => throw new InvalidOperationException($"Unknown custom option type: {customOption.Type}")
                };
                ret.Add(channelOption);
            }
            return ret.AsReadOnly();
        }
    }
}
