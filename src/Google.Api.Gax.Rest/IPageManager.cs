/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax.Rest
{
    /// <summary>
    /// Extension methods on IPageManager, just to avoid repetitive code.
    /// </summary>
    internal static class PageManagerExtensions
    {
        internal static IEnumerable<TResource> GetResourcesEmptyIfNull<TRequest, TResponse, TResource>(
            this IPageManager<TRequest, TResponse, TResource> manager, TResponse response) =>
            manager.GetResources(response) ?? Enumerable.Empty<TResource>();
    }

    /// <summary>
    /// Interface describing the relationship between requests, responses and resources for
    /// page streaming.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <typeparam name="TResource">The resource type.</typeparam>
    public interface IPageManager<TRequest, TResponse, TResource>
    {
        /// <summary>
        /// Applies the given page size to the given request.
        /// </summary>
        /// <param name="request">The request to modify.</param>
        /// <param name="pageSize">The page size for the next remote call.</param>
        void SetPageSize(TRequest request, int pageSize);

        /// <summary>
        /// Applies the given page token to the given request.
        /// </summary>
        /// <param name="request">The request to modify.</param>
        /// <param name="pageToken">The page token for the next remote call.</param>
        void SetPageToken(TRequest request, string pageToken);

        /// <summary>
        /// Extracts resources from a response.
        /// </summary>
        /// <param name="response">The response containing the resources.</param>
        /// <returns>The resources in the response, or <c>null</c> if it contains no resources.</returns>
        IEnumerable<TResource> GetResources(TResponse response);

        /// <summary>
        /// Extracts the next page token from a response.
        /// </summary>
        /// <param name="response">The response to extract the next page token from.</param>
        /// <returns>The next page token, or <c>null</c> if this is the final page of results.</returns>
        string GetNextPageToken(TResponse response);
    }
}
