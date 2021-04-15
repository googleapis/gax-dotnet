/*
 * Copyright 2021 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.CommonProtos.Tests.Type
{
    public class DecimalTest
    {
        // Note: we can't use InlineData in the tests with decimal values, as decimals can't be used in attributes.
        // See https://codeblog.jonskeet.uk/2014/08/22/when-is-a-constant-not-a-constant-when-its-a-decimal/
        // for details.

        public static TheoryData<string, decimal> RoundtripData = new TheoryData<string, decimal>
        {
            { "1.23", 1.23m },
            { "-1.23", -1.23m },
            { "5", 5m },
            { "1.00", 1.00m },
            { "1.2345678901234567890123456789", 1.2345678901234567890123456789m },
            { "0.0000000000000000000000000001", 0.0000000000000000000000000001m },
            { "79228162514264337593543950335", 79228162514264337593543950335m },
            { "-79228162514264337593543950335", -79228162514264337593543950335m },
            { "0.00", 0.00m }
        };

        public static TheoryData<string, decimal> ParseOnlyData = new TheoryData<string, decimal>
        {
            // Leading insignificant zeroes
            { "000.23", 0.23m },
            // Missing leading zero
            { ".23", 0.23m },
            // Exponents
            { "2.3e4", 23000m },
            { "2.3e+4", 23000m },
            { "2.3e-4", 0.00023m },
            { "2.3E4", 23000m },
            { "2.3E-4", 0.00023m },
            { "-2.3e4", -23000m },
            { "-2.3e-4", -0.00023m },
            // Explicit positive sign
            { "+1.23", 1.23m },
            // Truncation towards zero
            { "0.123456789012345678901234567899", 0.12345678901234567890123456789m },
            { "-0.123456789012345678901234567899", -0.12345678901234567890123456789m },
            // Negative zero does not have the sign preserved
            { "-0.00", 0.00m }
        };

        [Theory]
        [MemberData(nameof(RoundtripData))]
        public void FromClrDecimal(string expectedText, decimal value)
        {
            var proto = Google.Type.Decimal.FromClrDecimal(value);
            Assert.Equal(expectedText, proto.Value);
        }

        [Theory]
        [MemberData(nameof(RoundtripData))]
        [MemberData(nameof(ParseOnlyData))]
        public void ToClrDecimal(string text, decimal expectedValue)
        {
            var proto = new Google.Type.Decimal { Value = text };
            var clr = proto.ToClrDecimal();
            Assert.Equal(expectedValue, clr);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   1.23")]
        [InlineData("1.23   ")]
        [InlineData("1.23-")]
        [InlineData("--1.23")]
        [InlineData("++1.23")]
        [InlineData("+-1.23")]
        [InlineData("-+1.23")]
        [InlineData("1-1")]
        [InlineData("0.-1")]
        [InlineData("1,23")]
        [InlineData("0x10")]
        [InlineData("1.2.3")]
        [InlineData("garbage")]
        [InlineData("\u00BD")] // 1/2 character
        public void ToClrDecimal_Invalid(string text)
        {
            var proto = new Google.Type.Decimal { Value = text };
            Assert.Throws<FormatException>(() => proto.ToClrDecimal());
        }

        [Theory]
        [InlineData("79228162514264337593543950336")]
        [InlineData("-79228162514264337593543950336")]
        [InlineData("1e30")]
        [InlineData("-1e30")]
        public void ToClrDecimal_Overflow(string text)
        {
            var proto = new Google.Type.Decimal { Value = text };
            Assert.Throws<OverflowException>(() => proto.ToClrDecimal());
        }
    }
}
