/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Xunit;
using static Google.Api.Gax.Grpc.Rest.Tests.QueryTestMessage.Types;

namespace Google.Api.Gax.Grpc.Tests;

public class ProtobufUtilitiesTest
{
    public static TheoryData<object, string> ComplexFormatTestData { get; } = new TheoryData<object, string>
    {
        { ByteString.CopyFromUtf8(""), "" },
        { ByteString.CopyFromUtf8("xyz"), "eHl6" }, // ByteString uses base64
        { new Timestamp { Seconds = 86401, Nanos = 123456789 }, "1970-01-02T00:00:01.123456789Z" },
        { new Duration { Seconds = 5, Nanos = 600_000_000 }, "5.600s" },
        { new FieldMask { Paths = { "a", "b", "c" } }, "a,b,c" },
        { new StringValue { Value = "text" }, "text" },
        // We don't want the JSON-escaped text here
        { new StringValue { Value = @"a\b" }, @"a\b" },
        { new Int32Value { Value = 123 }, "123" },
        { new Int64Value { Value = 123L }, "123" },
        { new Int64Value { Value = 12345678901L }, "12345678901" },
        { new UInt32Value { Value = 123 }, "123" },
        { new UInt64Value { Value = 123UL }, "123" },
        { new UInt64Value { Value = 12345678901UL }, "12345678901" },
        { new DoubleValue { Value = -123d }, "-123" },
        { new DoubleValue { Value = double.NegativeInfinity }, "-Infinity" }, // NaN and infinite values are JSON-encoded as strings
        { new FloatValue { Value = 123f }, "123" },
        { new FloatValue { Value = float.NaN }, "NaN" }, // NaN and infinite values are JSON-encoded as strings
        { new BytesValue { Value = ByteString.CopyFromUtf8("xyz") }, "eHl6" },
    };

    [Theory]
    [InlineData("xyz")]
    [InlineData(" ")]
    [InlineData(true)]
    [InlineData(1)]
    [InlineData(1L)]
    [InlineData((uint) 1)]
    [InlineData(1UL)]
    [InlineData(1.0f)]
    [InlineData(1.0d)]
    [InlineData(SampleEnum.FirstValue)]
    public void IsDefaultValue_False(object value) =>
        Assert.False(ProtobufUtilities.IsDefaultValue(value));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(false)]
    [InlineData(0)]
    [InlineData(0L)]
    [InlineData((uint) 0)]
    [InlineData(0UL)]
    [InlineData(0f)]
    [InlineData(0d)]
    [InlineData(SampleEnum.Unspecified)]
    public void IsDefaultValue_True(object value) =>
        Assert.True(ProtobufUtilities.IsDefaultValue(value));

    [Theory]
    [InlineData("", true)]
    [InlineData("xyz", false)]
    public void IsDefaultValue_ByteString(string text, bool expectedValue) =>
        Assert.Equal(expectedValue, ProtobufUtilities.IsDefaultValue(ByteString.CopyFromUtf8(text)));

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("abc", "abc")]
    [InlineData(false, "false")]
    [InlineData(true, "true")]
    [InlineData(123, "123")]
    [InlineData((uint)123, "123")]
    [InlineData(123L, "123")]
    [InlineData(123UL, "123")]
    [InlineData(123.45f, "123.45")]
    [InlineData(123.45d, "123.45")]
    [InlineData(SampleEnum.Unspecified, "SAMPLE_ENUM_UNSPECIFIED")]
    [InlineData(SampleEnum.FirstValue, "FIRST_VALUE")]
    [InlineData((SampleEnum) 123, "123")]
    [MemberData(nameof(ComplexFormatTestData))]
    public void FormatValueAsJson(object value, string expectedText)
    {
        string actual = ProtobufUtilities.FormatValueAsJsonPrimitive(value);
        Assert.Equal(expectedText, actual);
    }
}
