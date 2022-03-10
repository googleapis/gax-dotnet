/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax;
using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods enabling dependency injection of Google API clients.
    /// </summary>
    public static class GaxServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the given Google API client type as a singleton, configuring it with any dependencies injected (e.g. credentials,
        /// gRPC adapter). The client type must be annotated with <see cref="GoogleApiClientAttribute"/>;
        /// the implementation creates an instance of the indicated <see cref="IClientBuilder{TClient}"/>,
        /// populates it from the service-provider, and builds it.
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddGoogleApiClient<TClient>(this IServiceCollection services) where TClient : class
        {
            // TODO: Error checking, efficiency etc.
            // TODO: Should we actually inherit this so we can inject an "impl"?
            var attribute = typeof(TClient).GetCustomAttribute<GoogleApiClientAttribute>(inherit: false);
            var builder = (IClientBuilder<TClient>) Activator.CreateInstance(attribute.BuilderType);
            return services.AddSingleton(provider =>
            {
                builder.PopulateFromServices(provider);
                return builder.Build();
            });
        }
    }
}
