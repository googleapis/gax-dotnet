/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class GaxPreconditionsTest
    {
        const int RangeMin = -4;
        const int RangeMax = 5;

        [Fact]
        public void CheckNotNull_Valid()
        {
            object x = new object();
            Assert.Same(x, GaxPreconditions.CheckNotNull(x, nameof(x)));
        }

        [Fact]
        public void CheckNotNull_Invalid()
        {
            object x = null;
            var exception = Assert.Throws<ArgumentNullException>(() => GaxPreconditions.CheckNotNull(x, nameof(x)));
            Assert.Equal(nameof(x), exception.ParamName);
        }

        [Fact]
        public void CheckNotNullOrEmpty_Valid()
        {
            string x = "foo";
            Assert.Same(x, GaxPreconditions.CheckNotNullOrEmpty(x, nameof(x)));
        }

        [Fact]
        public void CheckNotNull_Null()
        {
            string x = null;
            var exception = Assert.Throws<ArgumentNullException>(() => GaxPreconditions.CheckNotNullOrEmpty(x, nameof(x)));
            Assert.Equal(nameof(x), exception.ParamName);
        }

        [Fact]
        public void CheckNotNull_Empty()
        {
            string x = "";
            var exception = Assert.Throws<ArgumentException>(() => GaxPreconditions.CheckNotNullOrEmpty(x, nameof(x)));
            Assert.Equal(nameof(x), exception.ParamName);
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        public void CheckRangeInt32_Valid(int value)
        {
            Assert.Equal(value, GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin - 1)]
        [InlineData(RangeMax + 1)]
        public void CheckRangeInt32_Invalid(int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        [InlineData(null)]
        public void CheckRangeNullableInt32_Valid(int? value)
        {
            Assert.Equal(value, GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin - 1)]
        [InlineData(RangeMax + 1)]
        public void CheckRangeNullableInt32_Invalid(int? value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        public void CheckRangeInt64_Valid(long value)
        {
            Assert.Equal(value, GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin - 1)]
        [InlineData(RangeMax + 1)]
        public void CheckRangeInt64_Invalid(long value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        [InlineData(null)]
        public void CheckRangeNullableInt64_Valid(long? value)
        {
            Assert.Equal(value, GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin - 1)]
        [InlineData(RangeMax + 1)]
        public void CheckRangeNullableInt64_Invalid(long? value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        public void CheckRangeTDouble_Valid(double value)
        {
            Assert.Equal(value, GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin - 0.1)]
        [InlineData(RangeMax + 0.1)]
        public void CheckRangeTDouble_Invalid(double value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        [InlineData(null)]
        public void CheckRangeNullableTDouble_Valid(double? value)
        {
            Assert.Equal(value, GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        [Theory]
        [InlineData(RangeMin - 0.1)]
        [InlineData(RangeMax + 0.1)]
        public void CheckRangeNullableTDouble_Invalid(double? value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(value, nameof(value), RangeMin, RangeMax));
        }

        private TimeSpan S(int seconds) => TimeSpan.FromSeconds(seconds);
        private TimeSpan? S(int? seconds) => seconds is int s ? (TimeSpan?)TimeSpan.FromSeconds(s) : null;

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        public void CheckRangeTTimeSpan_Valid(int seconds)
        {
            Assert.Equal(S(seconds), GaxPreconditions.CheckArgumentRange(S(seconds), nameof(seconds), S(RangeMin), S(RangeMax)));
        }

        [Theory]
        [InlineData(RangeMin - 1)]
        [InlineData(RangeMax + 1)]
        public void CheckRangeTTimeSpan_Invalid(int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(S(seconds), nameof(seconds), S(RangeMin), S(RangeMax)));
        }

        [Theory]
        [InlineData(RangeMin)]
        [InlineData((RangeMin + RangeMax) / 2)]
        [InlineData(RangeMax)]
        [InlineData(null)]
        public void CheckRangeNullableTTimeSpan_Valid(int? seconds)
        {
            Assert.Equal(S(seconds), GaxPreconditions.CheckArgumentRange(S(seconds), nameof(seconds), S(RangeMin), S(RangeMax)));
        }

        [Theory]
        [InlineData(RangeMin - 1)]
        [InlineData(RangeMax + 1)]
        public void CheckRangeNullableTInt32_Invalid(int? seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckArgumentRange(S(seconds), nameof(seconds), S(RangeMin), S(RangeMax)));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CheckNonNegativeInt32_Valid(int value) => Assert.Equal(value, GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CheckNonNegativeInt32_Invalid(int value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(null)]
        public void CheckNonNegativeNullableInt32_Valid(int? value) => Assert.Equal(value, GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CheckNonNegativeNullableInt32_Invalid(int? value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CheckNonNegativeInt64_Valid(long value) => Assert.Equal(value, GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CheckNonNegativeInt64_Invalid(long value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(null)]
        public void CheckNonNegativeNullableInt64_Valid(long? value) => Assert.Equal(value, GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CheckNonNegativeNullableInt64_Invalid(long? value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CheckNonNegativeDouble_Valid(double value) => Assert.Equal(value, GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CheckNonNegativeDouble_Invalid(double value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(null)]
        public void CheckNonNegativeNullableDouble_Valid(double? value) => Assert.Equal(value, GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void CheckNonNegativeNullableDouble_Invalid(double? value) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => GaxPreconditions.CheckNonNegative(value, nameof(value)));

        [Fact]
        public void CheckState_Valid()
        {
            GaxPreconditions.CheckState(true, "Not used");
        }

        [Fact]
        public void CheckState_Invalid()
        {
            string message = "Exception message";
            var exception = Assert.Throws<InvalidOperationException>(() => GaxPreconditions.CheckState(false, message));
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void CheckArgument_Valid()
        {
            GaxPreconditions.CheckArgument(true, "irrelevantParameterName", "Irrelevant message");
            GaxPreconditions.CheckArgument(true, "irrelevantParameterName", "Irrelevant message", "arg0");
            GaxPreconditions.CheckArgument(true, "irrelevantParameterName", "Irrelevant message", "arg0", "arg1");
        }

        [Fact]
        public void CheckArgument_Invalid()
        {
            var parameterName = "parameterName";
            var message = "Message";
            var exception = Assert.Throws<ArgumentException>(() => GaxPreconditions.CheckArgument(false, parameterName, message));
            // Note: Not Assert.Equal here, as the ArgumentException constructor magically appends "Parameter name: ..."
            // into the Message property :(
            Assert.StartsWith(message, exception.Message);
            Assert.Equal(parameterName, exception.ParamName);
        }

        [Fact]
        public void CheckArgument_Invalid1FormatArgument()
        {
            var parameterName = "parameterName";
            var exception = Assert.Throws<ArgumentException>(() => GaxPreconditions.CheckArgument(false, parameterName, "Foo {0}", 1));
            Assert.StartsWith("Foo 1", exception.Message);
            Assert.Equal(parameterName, exception.ParamName);
        }

        [Fact]
        public void CheckArgument_Invalid2FormatArguments()
        {
            var parameterName = "parameterName";
            var exception = Assert.Throws<ArgumentException>(() => GaxPreconditions.CheckArgument(false, parameterName, "Foo {0} {1}", 1, 2));
            Assert.StartsWith("Foo 1 2", exception.Message);
            Assert.Equal(parameterName, exception.ParamName);
        }

        [Fact]
        public void CheckEnumValue_NotDefined()
        {
            var parameterName = "parameterName";
            var exception = Assert.Throws<ArgumentException>(() => GaxPreconditions.CheckEnumValue((SampleEnum)5, nameof(parameterName)));
            Assert.Equal(parameterName, exception.ParamName);
        }

        [Fact]
        public void CheckEnumValue_Defined()
        {
            var parameterName = "parameterName";
            var value = SampleEnum.DefinedValue;
            Assert.Equal(value, GaxPreconditions.CheckEnumValue(value, nameof(parameterName)));
        }

        enum SampleEnum
        {
            DefinedValue = 1
        }
    }
}