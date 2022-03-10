/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc;
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
        /// Adds a singleton <see cref="GrpcNetClientAdapter"/> to the given service collection,
        /// using the default with any additional options configured via <paramref name="optionsConfigurer"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsConfigurer"></param>
        /// <returns></returns>
        public static IServiceCollection AddGrpcNetClientAdapter(this IServiceCollection services, Action<IServiceProvider, global::Grpc.Net.Client.GrpcChannelOptions> optionsConfigurer) =>
            services.AddSingleton<GrpcAdapter>(provider => GrpcNetClientAdapter.Default.WithAdditionalOptions(options => optionsConfigurer(provider, options)));

        /// <summary>
        /// Adds a singleton <see cref="GrpcNetClientAdapter"/> to the given service collection,
        /// such that any <see cref="GrpcChannel"/> created uses the service provider from
        /// created this service collection. This enables logging, for example.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGrpcNetClientAdapter(this IServiceCollection services) =>
            services.AddSingleton<GrpcAdapter>(provider => GrpcNetClientAdapter.Default.WithAdditionalOptions(options => options.ServiceProvider = provider));
    }
}
