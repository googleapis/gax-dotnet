/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.CommonProtos.TypeExtensions;
using Google.Type;
using System;
using System.Collections.Generic;
using Xunit;

namespace Google.Api.CommonProtos.Tests.TypeExtensions
{
    public class DateExtensionsTests
    {
        /// <summary>
        /// Year, Month, Day
        /// </summary>
        public static IEnumerable<object[]> DateArguments => new[]
        {
            new object[] { 0001, 1 , 1},
            new object[] { 2000, 2 , 29},
            new object[] { 2018, 4 , 28},
            new object[] { 9999, 12 , 31},
        };

        [Fact]
        public void ToDateTimeThrowsArgumentOutOfRangeExceptionWhenDateIsNotInitialized()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Date().ToDateTime());
        }

        [Fact]
        public void ToDateTimeThrowsArgumentOutOfRangeExceptionWhenYearIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Date
                {
                    Month = 1,
                    Day = 1
                }.ToDateTime());           
        }

        [Fact]
        public void ToDateTimeThrowsArgumentOutOfRangeExceptionWhenDayIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Date
                {
                    Year = 2000,
                    Month = 1,
                }.ToDateTime());
        }

        [Fact]
        public void ToDateTimeOffsetThrowsArgumentOutOfRangeExceptionWhenDateIsNotInitialized()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Date().ToDateTimeOffset());
        }

        [Fact]
        public void ToDateTimeOffsetThrowsArgumentOutOfRangeExceptionWhenYearIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Date
                {
                    Month = 1,
                    Day = 1
                }.ToDateTimeOffset());
        }

        [Fact]
        public void ToDateTimeOffsetThrowsArgumentOutOfRangeExceptionWhenDayIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Date
                {
                    Year = 2000,
                    Month = 1,
                }.ToDateTimeOffset());
        }

        [Theory]
        [MemberData(nameof(DateArguments))]
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
        [MemberData(nameof(DateArguments))]
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
        [MemberData(nameof(DateArguments))]
        public void IsConvertedToDateFromDateTime(int year, int month, int day)
        {
            var subjectUnderTest = new DateTime(year, month, day);
            var actualDate = subjectUnderTest.ToDate();
            Assert.Equal(year, actualDate.Year);
            Assert.Equal(month, actualDate.Month);
            Assert.Equal(day, actualDate.Day);
        }

        [Theory]
        [MemberData(nameof(DateArguments))]
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
