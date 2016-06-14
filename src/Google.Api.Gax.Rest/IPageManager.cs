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

    public interface IPageManager<TRequest, TResponse, TResource>
    {
        void SetPageSize(TRequest request, int pageSize);
        void SetPageToken(TRequest request, string pageToken);
        IEnumerable<TResource> GetResources(TResponse response);
        string GetNextPageToken(TResponse response);
    }
}
