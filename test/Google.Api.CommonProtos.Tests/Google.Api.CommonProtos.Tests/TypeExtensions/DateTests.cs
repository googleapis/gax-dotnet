/*
 * Copyright 2018 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Type;
using System;
using System.Collections.Generic;
using Xunit;

namespace Google.Api.CommonProtos.Tests.TypeExtensions
{
    public class DateTests
    {
        public static IEnumerable<object[]> InvalidDateTestArguments => new[]
        {
            // In the order of Year, Month, Day.
            new object[] { -1, -1 , -1},
            new object[] { 0, 0 , 0},
            new object[] { 0, 4 , 28},
            new object[] { 2018, 0 , 28},
            new object[] { 2018, 4 , 0},
            new object[] { 10000, 4 , 28},
            new object[] { 2018, 13 , 28},
            new object[] { 2018, 4 , 32}
        };

        public static IEnumerable<object[]> ValidDateTestArguments => new[]
        {
            // In the order of Year, Month, Day.
            new object[] { 0001, 1 , 1},
            new object[] { 2000, 2 , 29},
            new object[] { 2018, 4 , 28},
            new object[] { 9999, 12 , 31}
        };

        [Fact]
        public void ToDateTimeThrowsInvalidOperationExceptionWhenDateIsNotInitialized()
        {
            Assert.Throws<InvalidOperationException>(
                () => new Date().ToDateTime());
        }

        [Theory]
        [MemberData(nameof(InvalidDateTestArguments))]
        public void ToDateTimeThrowsInvalidOperationExceptionWhenDateIsInvalidState(int year, int month, int day)
        {
            Assert.Throws<InvalidOperationException>(
                () => new Date
                {
                    Year = year,
                    Month = month,
                    Day = day
                }.ToDateTime());
        }

        [Fact]
        public void ToDateTimeOffsetThrowsInvalidOperationExceptionWhenDateIsNotInitialized()
        {
            Assert.Throws<InvalidOperationException>(
                () => new Date().ToDateTimeOffset());
        }

        [Theory]
        [MemberData(nameof(InvalidDateTestArguments))]
        public void ToDateTimeOffsetThrowsInvalidOperationExceptionWhenDateIsInvalidState(int year, int month, int day)
        {
            Assert.Throws<InvalidOperationException>(
                () => new Date
                {
                    Year = year,
                    Month = month,
                    Day = day
                }.ToDateTimeOffset());
        }

        [Theory]
        [MemberData(nameof(ValidDateTestArguments))]
        public void IsConvertedToDateTime(int year, int month, int day)
        {
            var subjectUnderTest = new Date
            {
                Year = year,
                Month = month,
                Day = day
            };
            var actualDateTime = subjectUnderTest.ToDateTime();
            Assert.Equal(year, actualDateTime.Year);
            Assert.Equal(month, actualDateTime.Month);
            Assert.Equal(day, actualDateTime.Day);
            Assert.Equal(0, actualDateTime.Hour);
            Assert.Equal(0, actualDateTime.Minute);
            Assert.Equal(0, actualDateTime.Second);
            Assert.Equal(0, actualDateTime.Millisecond);
            Assert.Equal(DateTimeKind.Unspecified, actualDateTime.Kind);
        }

        [Theory]
        [MemberData(nameof(ValidDateTestArguments))]
        public void IsConvertedToDateTimeOffset(int year, int month, int day)
        {
            var subjectUnderTest = new Date
            {
                Year = year,
                Month = month,
                Day = day
            };
            var actualDateTime = subjectUnderTest.ToDateTimeOffset();
            Assert.Equal(year, actualDateTime.Year);
            Assert.Equal(month, actualDateTime.Month);
            Assert.Equal(day, actualDateTime.Day);
            Assert.Equal(0, actualDateTime.Hour);
            Assert.Equal(0, actualDateTime.Minute);
            Assert.Equal(0, actualDateTime.Second);
            Assert.Equal(0, actualDateTime.Millisecond);
            Assert.Equal(TimeSpan.Zero, actualDateTime.TimeOfDay);
            Assert.Equal(TimeSpan.Zero, actualDateTime.Offset);  
        }

        [Theory]
        [MemberData(nameof(ValidDateTestArguments))]
        public void IsConvertedToDateFromDateTime(int year, int month, int day)
        {
            var subjectUnderTest = new DateTime(year, month, day);
            var actualDate = subjectUnderTest.ToDate();
            Assert.Equal(year, actualDate.Year);
            Assert.Equal(month, actualDate.Month);
            Assert.Equal(day, actualDate.Day);
        }

        [Theory]
        [MemberData(nameof(ValidDateTestArguments))]
        public void IsConvertedToDateFromDateTimeOffset(int year, int month, int day)
        {
            var someHours = 2;
            var someMinutes = 59;
            var someSeconds = 30;
            var someTimeSpan = TimeSpan.Zero;
            var subjectUnderTest = new DateTimeOffset(year, month, day, someHours, someMinutes, someSeconds, someTimeSpan);
            var actualDate = subjectUnderTest.ToDate();
            Assert.Equal(year, actualDate.Year);
            Assert.Equal(month, actualDate.Month);
            Assert.Equal(day, actualDate.Day);
        }
    }
}
