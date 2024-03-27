/*
 * Copyright 2024 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Concurrent;
using System.Diagnostics;

namespace Google.Api.Gax;

/// <summary>
/// Helper methods for obtaining <see cref="ActivitySource"/> values.
/// Note that while some conventions suggest a single activity source per assembly, libraries for Google Cloud APIs
/// use an activity source per client type, for simpler filtering. These can easily be obtained via the static
/// properties on the client type itself, but this class allows a more generic approach where necessary.
/// </summary>
public static class ActivitySources
{
    private static readonly ConcurrentDictionary<System.Type, ActivitySource> s_activitySources = new();

    /// <summary>
    /// Returns an <see cref="ActivitySource"/> named after the given client type.
    /// </summary>
    /// <remarks>
    /// Multiple calls to this method (or <see cref="FromClientType{T}()"/>) for the same
    /// type will return the same cached activity source.
    /// </remarks>
    /// <param name="type">The client type to obtain an activity source for. Must not be null.</param>
    /// <returns>An <see cref="ActivitySource"/> named after the given client type.</returns>
    public static ActivitySource FromClientType(System.Type type)
    {
        GaxPreconditions.CheckNotNull(type, nameof(type));
        return s_activitySources.GetOrAdd(type, CreateActivitySource);
    }

    /// <summary>
    /// Returns an <see cref="ActivitySource"/> named after the given client type.
    /// </summary>
    /// <remarks>
    /// Multiple calls to this method (or <see cref="FromClientType(System.Type)"/>) for the same
    /// type will return the same cached activity source.
    /// </remarks>
    /// <typeparam name="T">The client type to obtain an activity source for.</typeparam>
    /// <returns>An <see cref="ActivitySource"/> named after the given client type.</returns>
    public static ActivitySource FromClientType<T>() => FromClientType(typeof(T));

    private static ActivitySource CreateActivitySource(System.Type type) =>
        // TODO: Move FormatAssemblyVersion to a separate type? It's odd to be here.
        new ActivitySource(type.FullName, VersionHeaderBuilder.FormatAssemblyVersion(type));
}
