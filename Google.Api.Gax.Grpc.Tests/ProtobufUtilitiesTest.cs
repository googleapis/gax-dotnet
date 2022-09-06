/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Xunit;
using static Google.Api.Gax.Grpc.Rest.Tests.QueryTestMessage.Types;

namespace Google.Api.Gax.Grpc.Tests;

public class ProtobufUtilitiesTest
{
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
    public void FormatValueAsJsonPrimitive(object value, string expectedText)
    {
        string actual = ProtobufUtilities.FormatValueAsJsonPrimitive(value);
        Assert.Equal(expectedText, actual);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("xyz", "eHl6")] // ByteString uses base64 representation
    public void FormatValueAsJsonPrimitive_ByteString(string utf8, string expectedText)
    {
        ByteString bs = ByteString.CopyFromUtf8(utf8);
        string actual = ProtobufUtilities.FormatValueAsJsonPrimitive(bs);
        Assert.Equal(expectedText, actual);
    }
}
