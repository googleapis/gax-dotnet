/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc;
using Google.Api.Gax.Grpc.Rest;
using Grpc.Net.Client;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for dependency injection.
    /// </summary>
    public static class GaxGrpcServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a singleton <see cref="GrpcNetClientAdapter"/> to the given service collection
        /// as the preferred <see cref="GrpcAdapter"/> implementation,
        /// using the default instance with any additional options configured via <paramref name="optionsConfigurer"/>.
        /// Before executing the specified action, the <see cref="Grpc.Net.Client.GrpcChannelOptions.ServiceProvider"/>
        /// is set to the provider. This enables logging, for example.
        /// </summary>
        /// <param name="services">The service collection to add the adapter to.</param>
        /// <param name="optionsConfigurer">The configuration action to perform on each <see cref="Grpc.Net.Client.GrpcChannelOptions"/>
        /// when it is used by the adapter to construct a channel. May be null, in which case this method only sets the
        /// service provider.</param>
        /// <returns>The same service collection reference, for method chaining.</returns>
        public static IServiceCollection AddGrpcNetClientAdapter(this IServiceCollection services, Action<IServiceProvider, Grpc.Net.Client.GrpcChannelOptions> optionsConfigurer) =>
            services.AddSingleton<GrpcAdapter>(provider => GrpcNetClientAdapter.Default
                .WithAdditionalOptions(options => options.ServiceProvider = provider)
                .WithAdditionalOptions(options => optionsConfigurer?.Invoke(provider, options)));

        /// <summary>
        /// Adds a singleton <see cref="GrpcNetClientAdapter"/> to the given service collection
        /// as the preferred <see cref="GrpcAdapter"/> implementation,
        /// such that any <see cref="GrpcChannel"/> created uses the service provider from
        /// created this service collection. This enables logging, for example.
        /// </summary>
        /// <param name="services">The service collection to add the adapter to.</param>
        /// <returns>The same service collection reference, for method chaining.</returns>
        public static IServiceCollection AddGrpcNetClientAdapter(this IServiceCollection services) =>
            services.AddGrpcNetClientAdapter(null);

        /// <summary>
        /// Adds a singleton <see cref="GrpcCoreAdapter"/> to the given service collection
        /// as the preferred <see cref="GrpcAdapter"/> implementation.
        /// </summary>
        /// <param name="services">The service collection to add the adapter to.</param>
        /// <returns>The same service collection reference, for method chaining.</returns>
        public static IServiceCollection AddGrpcCoreAdapter(this IServiceCollection services) =>
            // Note: this is still lazy, to avoid initializing Grpc.Core earlier than necessary.
            services.AddSingleton<GrpcAdapter>(provider => GrpcCoreAdapter.Instance);

        /// <summary>
        /// Adds a singleton <see cref="RestGrpcAdapter"/> to the given service collection
        /// as the preferred <see cref="GrpcAdapter"/> implementation.
        /// </summary>
        /// <param name="services">The service collection to add the adapter to.</param>
        /// <returns>The same service collection reference, for method chaining.</returns>
        public static IServiceCollection AddRestGrpcAdapter(this IServiceCollection services) =>
            services.AddSingleton<GrpcAdapter>(RestGrpcAdapter.Default);
    }
}
