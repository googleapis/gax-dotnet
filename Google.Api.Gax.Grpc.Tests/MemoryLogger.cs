/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax.Grpc.Tests
{
    /// <summary>
    /// Logger implementation that retains log entries in memory, for test purposes.
    /// </summary>
    public class MemoryLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly ConcurrentQueue<TestLogEntry> _logEntries = new ConcurrentQueue<TestLogEntry>();
        private readonly IExternalScopeProvider _scopeProvider = new LoggerExternalScopeProvider();

        /// <summary>
        /// Creates a logger with the given category name.
        /// </summary>
        /// <param name="categoryName">The category name of the logger.</param>
        public MemoryLogger(string categoryName) => _categoryName = categoryName;

        /// <summary>
        /// Clears the log entries in this logger.
        /// </summary>
        public void Clear()
        {
#if NETCOREAPP3_1_OR_GREATER
            _logEntries.Clear();
#else
            // ConcurrentQueue<T>.Clear doesn't exist in .NET Framework. This is the simplest approach...
            while (_logEntries.TryDequeue(out _)) ;
#endif
        }

        /// <summary>
        /// Creates a list of the log entries in this logger. The returned list is an independent clone
        /// of the current set of log entries. This call does not affect the state of the logger.
        /// </summary>
        /// <returns>A list of log entries in the logger.</returns>
        public List<TestLogEntry> ListLogEntries() => _logEntries.ToList();

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) => _scopeProvider.Push(state);

        /// <summary>
        /// Returns true for any log level other than None; filtering is expected
        /// to be provided by other infrastructure.
        /// </summary>
        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        /// <summary>
        /// Formats the log entry as a <see cref="TestLogEntry"/> and retains it in memory.
        /// </summary>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var entry = TestLogEntry.Create(_categoryName, logLevel, eventId, state, exception, formatter, _scopeProvider);
            _logEntries.Enqueue(entry);
        }
    }

    /// <summary>
    /// Generic implementation of <see cref="ILogger{TCategoryName}"/>.
    /// </summary>
    /// <typeparam name="TCategoryName">The type whose name will be the logger's category name.</typeparam>
    public class MemoryLogger<TCategoryName> : MemoryLogger, ILogger<TCategoryName>
    {
        /// <summary>
        /// Constructs a logger using the type argument as the category name.
        /// </summary>
        public MemoryLogger() : base(LoggerTypeNameHelper.GetCategoryNameForType<TCategoryName>())
        {
        }
    }
}