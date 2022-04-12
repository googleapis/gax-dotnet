/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace Google.Api.Gax.Grpc.Tests
{
    /// <summary>
    /// Helper method to determine the category for an ILogger{T}, given the type T.
    /// This isn't just the full name of the type, because generics are made prettier - but
    /// the method used isn't easily accessible.
    /// </summary>
    internal static class LoggerTypeNameHelper
    {
        internal static string GetCategoryNameForType<T>()
        {
            var wrapper = new Logger<T>(NoOpLoggerFactory.Instance);
            return ((NoOpLogger) wrapper.BeginScope(null)).CategoryName;
        }

        internal static string GetCategoryNameForType(System.Type type)
        {
            // Annoyingly, we have to use reflection here...
            var method = typeof(LoggerTypeNameHelper).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Single(method => method.Name == nameof(GetCategoryNameForType) && method.IsGenericMethodDefinition);
            method = method.MakeGenericMethod(type);
            return (string) method!.Invoke(null, null) ?? throw new InvalidOperationException("Method returned null");
        }

        private class NoOpLoggerFactory : ILoggerFactory
        {
            internal static ILoggerFactory Instance { get; } = new NoOpLoggerFactory();

            public void AddProvider(ILoggerProvider provider) =>
                throw new NotImplementedException();

            public ILogger CreateLogger(string categoryName) =>
                new NoOpLogger(categoryName);

            public void Dispose() =>
                throw new NotImplementedException();
        }

        /// <summary>
        /// Logger which returns itself when BeginScope is called, allowing us
        /// to get at the category. Yes, this is very weird.
        /// </summary>
        private class NoOpLogger : ILogger, IDisposable
        {
            internal string CategoryName { get; }

            internal NoOpLogger(string categoryName) =>
                CategoryName = categoryName;

            public IDisposable BeginScope<TState>(TState state) => this;

            public void Dispose() =>
                throw new NotImplementedException();

            public bool IsEnabled(LogLevel logLevel) =>
                throw new NotImplementedException();

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) =>
                throw new NotImplementedException();
        }
    }
}