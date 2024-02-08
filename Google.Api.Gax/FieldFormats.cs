/*
 * Copyright 2024 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax;

/// <summary>
/// Convenience methods for handling field formats documented in https://google.aip.dev/202.
/// </summary>
public static class FieldFormats
{
    /// <summary>
    /// Generates a UUID v4 value and formats it as xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx,
    /// using lower-case letters for hex digits.
    /// </summary>
    public static string GenerateUuid4() => Guid.NewGuid().ToString();
}
