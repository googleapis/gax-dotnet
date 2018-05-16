using System;

namespace Google.Type
{
    /// <summary>
    /// Extensions to Google.Type.Date
    /// </summary>
    public partial class Date
    {
        /// <summary>
        /// Converts Date => System.DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime() =>
            new DateTime(Year, Month, Day);

        /// <summary>
        /// Converts Date => System.DateTimeOffset
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset ToDateTimeOffset() =>
            new DateTimeOffset(Year, Month, Day, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// Creates a Date instance from the Date part of System.DateTime
        /// </summary>
        /// <param name="dateTimeToConvert"></param>
        /// <returns></returns>
        public static Date CreateDate(DateTime dateTimeToConvert) =>
            new Date
            {
                Year = dateTimeToConvert.Year,
                Month = dateTimeToConvert.Month,
                Day = dateTimeToConvert.Day
            };

        /// <summary>
        /// Creates a Date instance from the Date part of System.DateTimeOffset
        /// </summary>
        /// <param name="dateTimeOffsetToConvert"></param>
        /// <returns></returns>
        public static Date CreateDate(DateTimeOffset dateTimeOffsetToConvert) =>
            new Date
            {
                Year = dateTimeOffsetToConvert.Year,
                Month = dateTimeOffsetToConvert.Month,
                Day = dateTimeOffsetToConvert.Day
            };

    }
}
