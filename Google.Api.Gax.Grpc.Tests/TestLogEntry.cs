/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Google.Api.Gax.Grpc.Tests
{
    /// <summary>
    /// A very simplified representation of a log entry, aimed at testing.
    /// </summary>
    public sealed class TestLogEntry
    {
        private static readonly IReadOnlyList<object> EmptyScopeList = new List<object>().AsReadOnly();

        /// <summary>
        /// The category name of the log entry.
        /// </summary>
        public string CategoryName { get; }

        /// <summary>
        /// The level of the log entry.
        /// </summary>
        public LogLevel Level { get; }

        /// <summary>
        /// The exception in the log entry, or null if there was no exception.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// The event ID of the log entry.
        /// </summary>
        public EventId EventId { get; }

        /// <summary>
        /// The message of the log entry.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// The scopes of the log entry. This is never null, but may be empty.
        /// </summary>
        public IReadOnlyList<object> Scopes { get; }

        private TestLogEntry(string categoryName, LogLevel level, EventId eventId, string message, Exception exception, IReadOnlyList<object> scopes) =>
            (CategoryName, Level, EventId, Message, Exception, Scopes) =
            (categoryName, level, eventId, message, exception, scopes);

        internal static TestLogEntry Create<TState>(
            string categoryName, LogLevel logLevel, EventId eventId,
            TState state, Exception exception, Func<TState, Exception, string> formatter,
            IExternalScopeProvider scopeProvider)
        {
            var message = formatter(state, exception);
            List<object> scopes = null;
            scopeProvider.ForEachScope((scope, state) =>
            {
                if (scopes is null)
                {
                    scopes = new List<object>();
                }
                scopes.Add(scope);
            }, state: (object) null);

            return new TestLogEntry(categoryName, logLevel, eventId, message, exception, scopes?.AsReadOnly() ?? EmptyScopeList);
        }

        /// <summary>
        /// Returns a diagnostic form of the log entry, in the form "[Level]: Message",
        /// to simplify debugging.
        /// </summary>
        /// <returns>A diagnostic form of the log entry.</returns>
        public override string ToString() => $"[{Level}]: {Message}";
    }
}