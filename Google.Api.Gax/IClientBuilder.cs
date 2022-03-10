/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Interface implemented by all clients that use REST, enabling dependency injection.
    /// (This doesn't help for Google.Apis.Xyz.)
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IClientBuilder<TClient>
    {
        /// <summary>
        /// Builds the client synchronously
        /// </summary>
        /// <returns></returns>
        TClient Build();

        /// <summary>
        /// Builds the client asynchronously
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TClient> BuildAsync(CancellationToken cancellationToken);

        // TODO: change the return type to IClientBuilder<TClient> for simpler method chaining?

        /// <summary>
        /// Populates the builder via dependency injection.
        /// </summary>
        /// <param name="provider"></param>
        void PopulateFromServices(IServiceProvider provider);
    }
}
