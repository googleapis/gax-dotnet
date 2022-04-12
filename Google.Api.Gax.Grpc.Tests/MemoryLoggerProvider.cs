/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc.Tests
{
    /// <summary>
    /// A logger provider that creates instances of <see cref="MemoryLogger"/>.
    /// </summary>
    internal sealed class MemoryLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, MemoryLogger> _loggersByCategory =
            new ConcurrentDictionary<string, MemoryLogger>();

        public ILogger CreateLogger(string categoryName) =>
            _loggersByCategory.GetOrAdd(categoryName, name => new MemoryLogger(name));

        internal void Clear() => _loggersByCategory.Clear();

        /// <summary>
        /// Returns a list of log entries for the given category name. If no logs have been
        /// written for the given category, an empty list is returned.
        /// </summary>
        /// <param name="categoryName">The category name for which to get log entries.</param>
        /// <returns>A list of log entries for the given category name.</returns>
        internal List<TestLogEntry> GetLogEntries(string categoryName) =>
            _loggersByCategory.TryGetValue(categoryName, out var logger)
            ? logger.ListLogEntries() : new List<TestLogEntry>();

        public void Dispose()
        {
            // No-op
        }
    }
}