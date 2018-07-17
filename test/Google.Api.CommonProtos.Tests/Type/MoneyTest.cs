/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Type;
using System;
using Xunit;

namespace Google.Api.CommonProtos.Tests.Type
{
    public class MoneyTest
    {
        /// <summary>
        /// ISO-4217 specifically reserves the code "XTS" for testing.
        /// </summary>
        public const string TestCurrencyCode = "XTS";

        public static TheoryData<long, int, decimal> ValidMoneyValues = new TheoryData<long, int, decimal>
        {
            { 0L, 0, 0M },
            { 1L, 0, 1M },
            { 0L, 1, 0.000_000_001M },
            { -1L, 0, -1M },
            { 0L, -1, -0.000_000_001M },
            { -1L, -990_000_000, -1.99M },
            { 1L, 990_000_000, 1.99M },
            { long.MaxValue, 999_999_999, 9_223_372_036_854_775_807.999_999_999M },
            { long.MinValue, -999_999_999, -9_223_372_036_854_775_808.999_999_999M }
        };

        public static TheoryData<decimal, string> InvalidMoneyValues = new TheoryData<decimal, string>
        {
            { 9_223_372_036_854_775_808.0M, "integral part" },
            { -9_223_372_036_854_775_809.0M, "integral part" },
            { 0.000_000_000_1M, "digits after the decimal" },
            { -0.000_000_000_1M, "digits after the decimal" },
            { 9_223_372_036_854_775_808.000_000_000_1M, "integral part" },
            { -9_223_372_036_854_775_809.000_000_000_1M, "integral part" },
        };

        [Theory, MemberData(nameof(InvalidMoneyValues))]
        public void ToMoneyWithOutOfRangeValueThrowsArgumentOutOfRangeException(decimal valueToConvert, string expectedMessage)
        {
            bool caughtArgumentOutOfRangeException = false;
            try
            {
                valueToConvert.ToMoney(TestCurrencyCode);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                caughtArgumentOutOfRangeException = true;
                Assert.Contains(expectedMessage, ex.Message);
            }
            Assert.True(caughtArgumentOutOfRangeException);
        }

        [Theory, MemberData(nameof(ValidMoneyValues))]
        public void IsConvertedToDecimal(long units, int nanos, decimal expected)
        {
            var subjectUnderTest = new Money
            {
                CurrencyCode = TestCurrencyCode,
                Nanos = nanos,
                Units = units
            };
            Assert.Equal(expected, subjectUnderTest.ToDecimal());
        }

        [Theory, MemberData(nameof(ValidMoneyValues))]
        public void DecimalIsConvertedToMoneyWithEmptyCurrency(long expectedUnits, int expectedNanos, decimal valueToConvert)
        {
            var actual = valueToConvert.ToMoney("");

            Assert.Equal(expectedUnits, actual.Units);
            Assert.Equal(expectedNanos, actual.Nanos);
            Assert.Equal("", actual.CurrencyCode);
        }

        [Theory, MemberData(nameof(ValidMoneyValues))]
        public void DecimalIsConvertedToMoneyWithCurrencySpecified(long expectedUnits, int expectedNanos, decimal valueToConvert)
        {
            var actual = valueToConvert.ToMoney(TestCurrencyCode);

            Assert.Equal(expectedUnits, actual.Units);
            Assert.Equal(expectedNanos, actual.Nanos);
            Assert.Equal(TestCurrencyCode, actual.CurrencyCode);
        }
    }
}
