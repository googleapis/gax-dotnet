/*
 * Copyright 2023 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace Google.Api.Gax;

/// <summary>
/// Helper class for getting the ActivitySource for a specified client type.
/// </summary>
public static class ActivitySourceHelper
{
    private static readonly ConcurrentDictionary<Type, ActivitySource> s_activitySources = new();

    /// <summary>
    /// Gets the instance of ActivitySource for the specified client type.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of client for which to get the ActivitySource.</param>
    /// <returns>The ActivitySource.</returns>
    /// <remarks>
    /// This method should only be invoked from the generated .NET client libraries and only for a client type.
    /// </remarks>
    public static ActivitySource FromClientType(Type type)
    {
        GaxPreconditions.CheckNotNull(type, nameof(type));
        return GetActivitySource(type);
    }

    /// <summary>
    /// Gets the instance of ActivitySource for the specified client type.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of client for which to get the ActivitySource.</typeparam>
    /// <returns>The ActivitySource.</returns>
    /// <remarks>
    /// This method should only be invoked from the generated .NET client libraries and only for a client type.
    /// </remarks>
    public static ActivitySource FromClientType<T>() => FromClientType(typeof(T));

    private static ActivitySource GetActivitySource(Type type) => s_activitySources.GetOrAdd(type, MaybeCreateActivitySource);

    private static ActivitySource MaybeCreateActivitySource(Type type)
    {
        var assembly = type.Assembly;
        var sourceName = type.FullName;
        var appVersion = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
        return new ActivitySource(sourceName, appVersion);
    }
}