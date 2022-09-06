/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Google.Api.Gax.Grpc;

/// <summary>
/// Utility methods for protobufs. This is deliberately internal; these methods may be effectively exposed
/// in specific public classes, but only in a way that allows different use cases that happen to have the
/// same behavior now to be separated later. Code here is also a reasonable candidate to be exposed in Google.Protobuf.
/// </summary>
internal static class ProtobufUtilities
{
    private const uint UnsignedInt32Zero = 0;

    /// <summary>
    /// Determines whether the given value is a protobuf default value - i.e. if it's
    /// null, an empty string, a zero value (integer, numeric or enum) or an empty byte string.
    /// </summary>
    internal static bool IsDefaultValue(object value) =>
        value is null ||
        // (Comments are the protobuf language keywords)
        // string
        value is "" ||
        // bool
        value is false ||
        // double, float
        value is 0.0f || value is 0.0d ||
        // int32, sint32, sfixed32, int64, sint64, sfixed64
        value is 0 || value is 0L ||
        // uint32, fixed32, uint64, fixed64
        value is UnsignedInt32Zero || value is 0UL ||
        // bytes
        (value is ByteString bs && bs.IsEmpty) ||
        // Any enum (all protobuf enums have an underlying type of Int32)
        (value is Enum enumValue && Convert.ToInt32(enumValue) == 0);

    /// <summary>
    /// Formats a value in a way that is suitable for a header, URL path segment (after URL-encoding), or query parameter. The value
    /// is effectively formatted the same way it is in the JSON representation. The return value of this
    /// method is only guaranteed for single primitive values - not repeated fields, maps, or messages.
    /// </summary>
    /// <returns>A string representation of the given value, or null if the value is null</returns>
    internal static string FormatValueAsJsonPrimitive(object value) =>
        value is null ? null
        : value is bool b ? (b ? "true" : "false")
        : value is Enum enumValue ? OriginalEnumValueHelper.GetOriginalName(enumValue)
        : value is IFormattable formattable ? formattable.ToString(format: null, CultureInfo.InvariantCulture)
        : value is ByteString bs ? bs.ToBase64()
        : value.ToString();

    // Effectively a cache of mapping from enum values to the original name as specified in the proto file,
    // fetched by reflection. This code is taken from the protobuf JsonFormatter.
    private static class OriginalEnumValueHelper
    {
        private static readonly ConcurrentDictionary<System.Type, Dictionary<object, string>> _dictionaries
            = new ConcurrentDictionary<System.Type, Dictionary<object, string>>();

        internal static string GetOriginalName(object value)
        {
            var enumType = value.GetType();
            Dictionary<object, string> nameMapping = _dictionaries.GetOrAdd(enumType, type => GetNameMapping(type));

            // If this returns false, originalName will be null, which is what we want.
            nameMapping.TryGetValue(value, out string originalName);
            return originalName;
        }

        private static Dictionary<object, string> GetNameMapping(System.Type enumType) =>
            enumType.GetTypeInfo().DeclaredFields
                .Where(f => f.IsStatic)
                .Where(f => f.GetCustomAttributes<OriginalNameAttribute>()
                             .FirstOrDefault()?.PreferredAlias ?? true)
                .ToDictionary(f => f.GetValue(null),
                              f => f.GetCustomAttributes<OriginalNameAttribute>()
                                    .FirstOrDefault()
                                    // If the attribute hasn't been applied, fall back to the name of the field.
                                    ?.Name ?? f.Name);
    }
}
