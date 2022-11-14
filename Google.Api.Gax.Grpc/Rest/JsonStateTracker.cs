/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Simple state tracker to indicate when a server-streamed response is "done".
/// </summary>
/// <remarks>
/// We expect that:
/// - The overall response is an array
/// - The later JSON parser will perform fuller validation (e.g. this code
///   won't spot that [{[{]}}] is broken.
///
/// Note that this is mutable rather than us creating a new instance on each "push"
/// of a character, because:
/// - It's not *just* a simple state machine: we count open/close object/arrays
/// - We could make it a struct containing those counters and a detailed state enum,
///   it's not obvious that would be easier to use.
/// </remarks>
internal sealed class JsonStateTracker
{
    private int arrayDepth;
    private int objectDepth;

    private State state = State.BeforeTopArray;

    /// <summary>
    /// Pushes a single character, returning the appropriate action to be taken next.
    /// </summary>
    public NextAction Push(char c) => state switch
    {
        // Errors are unrecoverable.
        State.Error => NextAction.SignalError,
        State.BeforeTopArray => PushFromBeforeTopArray(c),
        State.AfterTopArray => PushFromAfterTopArray(c),
        State.JustInsideTopArray => PushFromJustInsideTopArray(c),
        State.WithinObject => PushFromWithinObject(c),
        State.StringLiteralNoEscape => PushFromStringLiteralNoEscape(c),
        State.StringLiteralEscape => PushFromStringLiteralAfterEscape(c),
        _ => throw new InvalidOperationException($"Unknown state {state}")
    };

    private NextAction PushFromBeforeTopArray(char c)
    {
        if (IsJsonWhitespace(c))
        {
            return NextAction.IgnoreAndContinue;
        }
        if (c == '[')
        {
            state = State.JustInsideTopArray;
            arrayDepth++;
            return NextAction.IgnoreAndContinue;
        }
        state = State.Error;
        return NextAction.SignalError;
    }

    private NextAction PushFromAfterTopArray(char c)
    {
        if (IsJsonWhitespace(c))
        {
            return NextAction.IgnoreAndContinue;
        }
        state = State.Error;
        return NextAction.SignalError;
    }

    private NextAction PushFromJustInsideTopArray(char c)
    {
        switch (c)
        {
            case char when IsJsonWhitespace(c):
            case ',':
                return NextAction.IgnoreAndContinue;
            case '{':
                objectDepth++;
                state = State.WithinObject;
                return NextAction.BufferAndContinue;
            case ']':
                arrayDepth--;
                state = State.AfterTopArray;
                return NextAction.SignalEndOfResponses;
            default:
                state = State.Error;
                return NextAction.SignalError;
        };
    }

    private NextAction PushFromWithinObject(char c)
    {
        switch (c)
        {
            case '{':
                objectDepth++;
                break;
            case '}':
                objectDepth--;
                if (objectDepth == 0)
                {
                    state = State.JustInsideTopArray;
                    return NextAction.ParseResponse;
                }
                break;
            case '[':
                arrayDepth++;
                break;
            case ']':
                arrayDepth--;
                if (arrayDepth == 0)
                {
                    state = State.Error;
                    return NextAction.SignalError;
                }
                break;
            case '"':
                state = State.StringLiteralNoEscape;
                break;
        }
        return NextAction.BufferAndContinue;
    }

    private NextAction PushFromStringLiteralNoEscape(char c)
    {
        state = c == '"' ? State.WithinObject
            : c == '\\' ? State.StringLiteralEscape
            : State.StringLiteralNoEscape;
        return NextAction.BufferAndContinue;
    }

    private NextAction PushFromStringLiteralAfterEscape(char c)
    {
        // We don't care what was escaped, so long as it was valid.
        // (In the case of a hex escape, we don't even care about the
        // hex digits following it.)
        if (c == '"' || c == '\\' || c == '/' ||
            c == 'b' || c == 'f' || c == 'n' ||
            c == 'r' || c == 't' || c == 'u')
        {
            state = State.StringLiteralNoEscape;
            return NextAction.BufferAndContinue;
        }
        state = State.Error;
        return NextAction.SignalError;
    }

    private static bool IsJsonWhitespace(char c) =>
        c == ' ' || c == '\t' || c == '\r' || c == '\n';

    private enum State
    {
        /// <summary>
        /// Before we first see [
        /// We stay in this state, only accepting whitespace or [ until we see the first [
        /// </summary>
        BeforeTopArray,

        /// <summary>
        /// Between response objects.
        /// In this state, we only accept:
        /// - Whitespace (stay in this state)
        /// - Comma (stay in this state)
        /// - { (move to Normal state)
        /// - ] (move to AfterTopArray state)
        /// </summary>
        JustInsideTopArray,

        /// <summary>
        /// Not in a string token, but somewhere within the top-level array.
        /// </summary>
        WithinObject,

        /// <summary>
        /// In a string token, but not directly after a backslash.
        /// </summary>
        StringLiteralNoEscape,

        /// <summary>
        /// In a string token, directly after a backslash.
        /// (The only permitted characters to follow this are double-quote, backslash, slash, b, f, n, r, t or u.
        /// Although u should then be followed by four hex digits, we don't enforce that.)
        /// </summary>
        StringLiteralEscape,

        /// <summary>
        /// We have detected an error. This is unrecoverable.
        /// </summary>
        Error,

        /// <summary>
        /// After the final ]
        /// We can only accept whitespace after this.
        /// </summary>
        AfterTopArray
    }

    /// <summary>
    /// The action that should be taken by the caller immediately after a call to <see cref="Push(char)"/>.
    /// </summary>
    internal enum NextAction
    {
        /// <summary>
        /// We've received the closing ] at the end of the top level array.
        /// There should be no further non-whitespace characters.
        /// </summary>
        SignalEndOfResponses,

        /// <summary>
        /// We've received the closing } at the end of an object directly
        /// within the top level array. Remember that pushed } and parse
        /// everything remembered since the last response was parsed.
        /// </summary>
        ParseResponse,

        /// <summary>
        /// We've detected an error. Signal this to the higher-level caller.
        /// We don't have details of the failure. 
        /// </summary>
        SignalError,

        /// <summary>
        /// Continue reading data and pushing it with the <see cref="Push"/> method.
        /// The character that has been pushed does not need to be retained.
        /// </summary>
        IgnoreAndContinue,

        /// <summary>
        /// Remember the pushed character (because it's part of a top-level object).
        /// Continue reading data and pushing it with the <see cref="Push"/> method.
        /// </summary>
        BufferAndContinue,
    }
}
