/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
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
    private static readonly HashSet<string> s_wellKnownTypeNames = new HashSet<string>
    {
        "google/protobuf/any.proto",
        "google/protobuf/api.proto",
        "google/protobuf/duration.proto",
        "google/protobuf/empty.proto",
        "google/protobuf/wrappers.proto",
        "google/protobuf/timestamp.proto",
        "google/protobuf/field_mask.proto",
        "google/protobuf/source_context.proto",
        "google/protobuf/struct.proto",
        "google/protobuf/type.proto",
    };

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
        (value is System.Enum enumValue && Convert.ToInt32(enumValue) == 0);

    /// <summary>
    /// Formats a value in a way that is suitable for a header, URL path segment (after URL-encoding), or query parameter. The value
    /// is effectively formatted the same way it is in the JSON representation. The return value of this
    /// method is only guaranteed for single primitive values - not repeated fields, maps, or messages.
    /// </summary>
    /// <remarks>
    /// <see cref="ByteString"/> values are always formatted as web-safe base64 (no trailing '='; '-' instead of '+'; '_' instead of '/').
    /// </remarks>
    /// <returns>A string representation of the given value, or null if the value is null</returns>
    internal static string FormatValueAsJsonPrimitive(object value) =>
        value switch
        {
            null => null,
            bool b => b ? "true" : "false",
            System.Enum enumValue => OriginalEnumValueHelper.GetOriginalName(enumValue) ?? ((int) value).ToString(CultureInfo.InvariantCulture),
            StringValue stringValue => stringValue.Value,
            Timestamp or Duration or FieldMask or Int64Value or UInt64Value or DoubleValue or FloatValue or BytesValue =>
                RemoveWellKnownTypeQuotes(value),
            IFormattable formattable => formattable.ToString(format: null, CultureInfo.InvariantCulture),
            ByteString bs => bs.ToBase64().Replace('+', '-').Replace('/', '_').TrimEnd('='),
            _ => value.ToString()
        };

    /// <summary>
    /// Format a well-known type value, and if it has quotes around it, remove them. (For some well-known types, e.g. FloatValue,
    /// it will sometimes be formatted as a JSON string and sometimes not.)
    /// </summary>
    private static string RemoveWellKnownTypeQuotes(object value)
    {
        string json = value.ToString();
        return json.Length >= 2 && json[0] == '"' && json[json.Length - 1] == '"'
            ? json.Substring(1, json.Length - 2)
            : json;
    }

    /// <summary>
    /// Determines whether the given message descriptor represents a well-known type.
    /// This is an internal method in Google.Protobuf; we might consider exposing it at some point.
    /// </summary>
    internal static bool IsWellKnownType(this MessageDescriptor messageDescriptor) =>
        messageDescriptor.File.Package == "google.protobuf" && s_wellKnownTypeNames.Contains(messageDescriptor.File.Name);

    // Effectively a cache of mapping from enum values to the original name as specified in the proto file,
    // fetched by reflection. This code is taken from the protobuf JsonFormatter.
    private static class OriginalEnumValueHelper
    {
        private static readonly ConcurrentDictionary<System.Type, Dictionary<object, string>> _dictionaries
            = new ConcurrentDictionary<System.Type, Dictionary<object, string>>();

        /// <summary>
        /// Returns the original name of the given enum value, or null if the value is unknown.
        /// </summary>
        internal static string GetOriginalName(System.Enum value)
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
