/*
 * Copyright 2023 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Diagnostics;

namespace Google.Api.Gax;

/// <summary>
/// The extension methods for Activity.
/// </summary>
public static class ActivityExtensions
{
    internal const string AttributeExceptionEventName = "exception";

    internal const string AttributeExceptionType = "exception.type";

    internal const string AttributeExceptionMessage = "exception.message";

    internal const string AttributeExceptionStacktrace = "exception.stacktrace";

    /// <summary>
    /// Sets the exception as an event.
    /// </summary>
    /// <param name="activity">The activity on which the exception is set.</param>
    /// <param name="ex">The exception object.</param>
    public static void SetException(this Activity activity, Exception ex)
    {
        if (ex is null || activity is null)
        {
            return;
        }

        var tagsCollection = new ActivityTagsCollection
        {
            { AttributeExceptionType, ex.GetType().FullName },
            { AttributeExceptionStacktrace, ex.ToString() },
        };

        if (!string.IsNullOrWhiteSpace(ex.Message))
        {
            tagsCollection[AttributeExceptionMessage] = ex.Message;
        }

        activity.AddEvent(new ActivityEvent(AttributeExceptionEventName, default, tagsCollection));
    }
}
