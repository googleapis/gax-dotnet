using Google.Type;
using System;

namespace Google.Api.CommonProtos.TypeExtensions
{
    /// <summary>
    /// Extension methods built around Google.Type
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts a System.DateTime (Date part) to Date
        /// </summary>
        /// <param name="dateTimeToConvert"></param>
        /// <returns></returns>
        public static Date ToDate(this DateTime dateTimeToConvert) =>
            Date.CreateDate(dateTimeToConvert);

        /// <summary>
        /// Converts a System.DateTimeOffset (Date part) to Date
        /// </summary>
        /// <param name="dateTimeOffsetToConvert"></param>
        /// <returns></returns>
        public static Date ToDate(this DateTimeOffset dateTimeOffsetToConvert) =>
            Date.CreateDate(dateTimeOffsetToConvert);

    }
}
