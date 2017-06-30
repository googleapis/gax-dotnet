/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

// Note: we'd really like to have a Google.Common package, but at the moment
// it would only contain Preconditions, which seems a small benefit for the cost
// of a dependency (and repo). We could make this class internal, but then it
// couldn't be used by of the generated code, which we want to be valid. Calling
// the class GaxPreconditions avoids naming collisions in the future if we *do*
// introduce a straight Preconditions class later on. Note that Google.Protobuf
// already contains Preconditions, which is unfortunate.

namespace Google.Api.Gax
{
    /// <summary>
    /// Preconditions for checking method arguments, state etc.
    /// </summary>
    public static class GaxPreconditions
    {
        // Possible future directions:
        // - Debug-only preconditions, as used extensively in Noda Time (for checking and self-documenting internal
        //   assumptions)
        // - Methods that return null or "something that will throw an exception" to be chained with string interpolation
        // - Methods accepting a string format and one or two arguments (to avoid any arrays being created at
        //   execution time, but still allow for string formatting)
        // - Conditional public/internal access, so that we can create a Google.Common assembly exposing all of this
        //   publicly, without duplication.

        /// <summary>
        /// Checks that the given argument (to the calling method) is non-null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="argument">The argument provided for the parameter.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null</exception>
        /// <returns><paramref name="argument"/> if it is not null</returns>
        public static T CheckNotNull<T>(T argument, string paramName) where T : class =>
            argument == null ? throw new ArgumentNullException(paramName) : argument;

        /// <summary>
        /// Checks that a string argument is neither null, nor an empty string.
        /// </summary>
        /// <param name="argument">The argument provided for the parameter.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> is empty</exception>
        /// <returns><paramref name="argument"/> if it is not null or empty</returns>
        public static string CheckNotNullOrEmpty(string argument, string paramName) =>
            argument == null ? throw new ArgumentNullException(paramName) :
            argument == "" ? throw new ArgumentException("An empty string was provided, but is not valid", paramName) :
            argument;

        /// <summary>
        /// Checks that the given argument value is valid.
        /// </summary>
        /// <remarks>
        /// Note that the upper bound (<paramref name="maxInclusive"/>) is inclusive,
        /// not exclusive. This is deliberate, to allow the specification of ranges which include
        /// <see cref="Int32.MaxValue"/>.
        /// </remarks>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <param name="minInclusive">The smallest valid value.</param>
        /// <param name="maxInclusive">The largest valid value.</param>
        /// <returns><paramref name="argument"/> if it was in range</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was outside the specified range.</exception>
        public static int CheckArgumentRange(int argument, string paramName, int minInclusive, int maxInclusive) =>
            argument < minInclusive || argument > maxInclusive ?
            throw new ArgumentOutOfRangeException(paramName, $"Value {argument} should be in range [{minInclusive}, {maxInclusive}]") : argument;

        /// <summary>
        /// Checks that the given argument value is valid.
        /// </summary>
        /// <remarks>
        /// Note that the upper bound (<paramref name="maxInclusive"/>) is inclusive,
        /// not exclusive. This is deliberate, to allow the specification of ranges which include
        /// <see cref="Int64.MaxValue"/>.
        /// </remarks>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <param name="minInclusive">The smallest valid value.</param>
        /// <param name="maxInclusive">The largest valid value.</param>
        /// <returns><paramref name="argument"/> if it was in range</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was outside the specified range.</exception>
        public static T CheckArgumentRange<T>(T argument, string paramName, T minInclusive, T maxInclusive) where T : IComparable<T> =>
            argument.CompareTo(minInclusive) < 0 || argument.CompareTo(maxInclusive) > 0 ?
            throw new ArgumentOutOfRangeException(paramName, $"Value {argument} should be in range [{minInclusive}, {maxInclusive}]") : argument;

        /// <summary>
        /// Checks that the given argument value, if not <c>null</c>, is valid.
        /// </summary>
        /// <remarks>
        /// Note that the upper bound (<paramref name="maxInclusive"/>) is inclusive,
        /// not exclusive. This is deliberate, to allow the specification of ranges which include
        /// <see cref="Int32.MaxValue"/>.
        /// </remarks>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <param name="minInclusive">The smallest valid value.</param>
        /// <param name="maxInclusive">The largest valid value.</param>
        /// <returns><paramref name="argument"/> if it was in range, or <c>null</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was outside the specified range.</exception>
        public static T? CheckArgumentRange<T>(T? argument, string paramName, T minInclusive, T maxInclusive) where T : struct, IComparable<T> =>
            argument is T arg ? CheckArgumentRange(arg, paramName, minInclusive, maxInclusive) : argument;

        /// <summary>
        /// Checks that the given argument value is not negative.
        /// </summary>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <returns><paramref name="argument"/> if it was non-negative.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was negative.</exception>
        public static int CheckNonNegative(int argument, string paramName) =>
            argument < 0 ? throw new ArgumentOutOfRangeException(paramName, $"Value {argument} should be non-negative.") : argument;

        /// <summary>
        /// Checks that the given argument value, if not <c>null</c>, is not negative.
        /// </summary>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <returns><paramref name="argument"/> if it was non-negative, or <c>null</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was negative.</exception>
        public static int? CheckNonNegative(int? argument, string paramName) =>
            argument is int arg ? CheckNonNegative(arg, paramName) : argument;

        /// <summary>
        /// Checks that the given argument value is not negative.
        /// </summary>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <returns><paramref name="argument"/> if it was non-negative.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was negative.</exception>
        public static long CheckNonNegative(long argument, string paramName) =>
            argument < 0 ? throw new ArgumentOutOfRangeException(paramName, $"Value {argument} should be non-negative.") : argument;

        /// <summary>
        /// Checks that the given argument value, if not <c>null</c>, is not negative.
        /// </summary>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <returns><paramref name="argument"/> if it was non-negative, or <c>null</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was negative.</exception>
        public static long? CheckNonNegative(long? argument, string paramName) =>
            argument is long arg ? CheckNonNegative(arg, paramName) : argument;

        /// <summary>
        /// Checks that the given argument value is not negative.
        /// </summary>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <returns><paramref name="argument"/> if it was non-negative.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was negative.</exception>
        public static double CheckNonNegative(double argument, string paramName) =>
            argument < 0 ? throw new ArgumentOutOfRangeException(paramName, $"Value {argument} should be non-negative.") : argument;

        /// <summary>
        /// Checks that the given argument value, if not <c>null</c>, is not negative.
        /// </summary>
        /// <param name="argument">The value of the argument passed to the calling method.</param>
        /// <param name="paramName">The name of the parameter in the calling method.</param>
        /// <returns><paramref name="argument"/> if it was non-negative, or <c>null</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The argument was negative.</exception>
        public static double? CheckNonNegative(double? argument, string paramName) =>
            argument is double arg ? CheckNonNegative(arg, paramName) : argument;

        /// <summary>
        /// Checks that given condition is met, throwing an <see cref="InvalidOperationException"/> otherwise.
        /// </summary>
        /// <param name="condition">The (already evaluated) condition to check.</param>
        /// <param name="message">The message to include in the exception, if generated. This should not
        /// use interpolation, as the interpolation would be performed regardless of whether or
        /// not an exception is thrown.</param>
        public static void CheckState(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Checks that given condition is met, throwing an <see cref="InvalidOperationException"/> otherwise.
        /// </summary>
        /// <param name="condition">The (already evaluated) condition to check.</param>
        /// <param name="format">The format string to use to create the exception message if the
        /// condition is not met.</param>
        /// <param name="arg0">The argument to the format string.</param>
        public static void CheckState<T>(bool condition, string format, T arg0)
        {
            if (!condition)
            {
                throw new InvalidOperationException(string.Format(format, arg0));
            }
        }

        /// <summary>
        /// Checks that given condition is met, throwing an <see cref="InvalidOperationException"/> otherwise.
        /// </summary>
        /// <param name="condition">The (already evaluated) condition to check.</param>
        /// <param name="format">The format string to use to create the exception message if the
        /// condition is not met.</param>
        /// <param name="arg0">The first argument to the format string.</param>
        /// <param name="arg1">The second argument to the format string.</param>
        public static void CheckState<T1, T2>(bool condition, string format, T1 arg0, T2 arg1)
        {
            if (!condition)
            {
                throw new InvalidOperationException(string.Format(format, arg0, arg1));
            }
        }


        /// <summary>
        /// Checks that given argument-based condition is met, throwing an <see cref="ArgumentException"/> otherwise.
        /// </summary>
        /// <param name="condition">The (already evaluated) condition to check.</param>
        /// <param name="paramName">The name of the parameter whose value is being tested.</param>
        /// <param name="message">The message to include in the exception, if generated. This should not
        /// use interpolation, as the interpolation would be performed regardless of whether or not an exception
        /// is thrown.</param>
        public static void CheckArgument(bool condition, string paramName, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        /// Checks that given argument-based condition is met, throwing an <see cref="ArgumentException"/> otherwise.
        /// </summary>
        /// <param name="condition">The (already evaluated) condition to check.</param>
        /// <param name="paramName">The name of the parameter whose value is being tested.</param>
        /// <param name="format">The format string to use to create the exception message if the
        /// condition is not met.</param>
        /// <param name="arg0">The argument to the format string.</param>
        public static void CheckArgument<T>(bool condition, string paramName, string format, T arg0)
        {
            if (!condition)
            {
                throw new ArgumentException(string.Format(format, arg0), paramName);
            }
        }

        /// <summary>
        /// Checks that given argument-based condition is met, throwing an <see cref="ArgumentException"/> otherwise.
        /// </summary>
        /// <param name="condition">The (already evaluated) condition to check.</param>
        /// <param name="paramName">The name of the parameter whose value is being tested.</param>
        /// <param name="format">The format string to use to create the exception message if the
        /// condition is not met.</param>
        /// <param name="arg0">The first argument to the format string.</param>
        /// <param name="arg1">The second argument to the format string.</param>
        public static void CheckArgument<T1, T2>(bool condition, string paramName, string format, T1 arg0, T2 arg1)
        {
            if (!condition)
            {
                throw new ArgumentException(string.Format(format, arg0, arg1), paramName);
            }
        }

        /// <summary>
        /// Checks that the given value is in fact defined in the enum used as the type argument of the method.
        /// </summary>
        /// <typeparam name="T">The enum type to check the value within.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The name of the parameter whose value is being tested.</param>
        /// <returns><paramref name="value"/> if it was a defined value</returns>
        public static T CheckEnumValue<T>(T value, string paramName) where T : struct
        {
            CheckArgument(
                Enum.IsDefined(typeof(T), value),
                paramName,
                "Value {0} not defined in enum {1}", value, typeof(T).Name);
            return value;
        }

        /// <summary>
        /// Checks that the given <see cref="TimeSpan"/> used as a delay is non-negative. This is internal
        /// as it's very specialized.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The name of the parameter whose value is being tested.</param>
        internal static TimeSpan CheckNonNegativeDelay(TimeSpan value, string paramName) =>
            value < TimeSpan.Zero ? throw new ArgumentOutOfRangeException(nameof(value), value, "Delay must not be negative") : value;
    }
}