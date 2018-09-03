/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Google.Api.Gax.Json
{
    // Note: this is internal for the moment, allowing us to commit it without exposing it until
    // we're ready. Libraries using this will temporarily use InternalsVisibleTo to access it, but that
    // will be removed before they are fully released (by which point this type must be public).
    // (Unlike JsonParser, it's not clear whether this will *ever* be public.)

    /// <summary>
    /// Simple but strict JSON tokenizer, rigidly following RFC 7159.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This tokenizer is stateful, and only returns "useful" tokens - names, values etc.
    /// It does not create tokens for the separator between names and values, or for the comma
    /// between values. It validates the token stream as it goes - so callers can assume that the
    /// tokens it produces are appropriate. For example, it would never produce "start object, end array."
    /// </para>
    /// <para>Not thread-safe.</para>
    /// </remarks>
    internal sealed class JsonTokenizer
    {
        // We may want to make this configurable at some point...
        internal const int MaxDepth = 10;

        // The set of states in which a value is valid next token.
        private static readonly State ValueStates = State.ArrayStart | State.ArrayAfterComma | State.ObjectAfterColon | State.StartOfDocument;

        private readonly Stack<ContainerType> containerStack = new Stack<ContainerType>();
        private readonly PushBackReader reader;
        private State state;

        // Populated when Peek is called... when Next() is then called, bufferedToken is returned.
        // After Peek is called, the internal state is "the state after the token", but that's okay because
        // we can only ever get to a place where it matters by consuming the peeked-at token.
        private JsonToken bufferedToken;

        /// <summary>
        ///  Creates a tokenizer that reads from the given text reader.
        /// </summary>
        internal static JsonTokenizer FromTextReader(TextReader reader)
        {
            return new JsonTokenizer(reader);
        }

        private JsonTokenizer(TextReader reader)
        {
            this.reader = new PushBackReader(reader);
            state = State.StartOfDocument;
            PushContainer(ContainerType.Document);
        }

        /// <summary>
        /// Pushes a new container type onto the stack and validates that we don't violate the maximum depth.
        /// </summary>
        /// <param name="type"></param>
        private void PushContainer(ContainerType type)
        {
            containerStack.Push(type);
            if (containerStack.Count > MaxDepth)
            {
                // TODO: Is it okay to throw InvalidJsonException? The JSON may be valid - just JSON we
                // don't want to accept.
                throw reader.CreateException($"Maximum nesting depth of {MaxDepth} exceeded.");
            }
        }

        /// <summary>
        /// Peeks at the next token in the stream, without changing the visible state.
        /// </summary>
        /// <returns>The next token in the stream.</returns>
        internal JsonToken Peek()
        {
            if (bufferedToken != null)
            {
                return bufferedToken;
            }
            bufferedToken = Next();
            return bufferedToken;
        }

        /// <summary>
        /// Skips the value we're about to read. This must only be called immediately after reading a property name.
        /// If the value is an object or an array, the complete object/array is skipped.
        /// </summary>
        internal void SkipValue()
        {
            // We'll assume that Next() makes sure that the end objects and end arrays are all valid.
            // All we care about is the total nesting depth we need to close.
            int depth = 0;

            // do/while rather than while loop so that we read at least one token.
            do
            {
                var token = Next();
                switch (token.Type)
                {
                    case JsonToken.TokenType.EndArray:
                    case JsonToken.TokenType.EndObject:
                        depth--;
                        break;
                    case JsonToken.TokenType.StartArray:
                    case JsonToken.TokenType.StartObject:
                        depth++;
                        break;
                }
            } while (depth != 0);
        }

        // Implementation notes: this method essentially just loops through characters skipping whitespace, validating and
        // changing state (e.g. from ObjectBeforeColon to ObjectAfterColon)
        // until it reaches something which will be a genuine token (e.g. a start object, or a value) at which point
        // it returns the token. Although the method is large, it would be relatively hard to break down further... most
        // of it is the large switch statement, which sometimes returns and sometimes doesn't.

        /// <summary>
        /// Returns the next JSON token in the stream.
        /// </summary>
        /// <exception cref="InvalidOperationException">This method is called after an EndDocument token has been returned</exception>
        /// <exception cref="InvalidJsonException">The input text does not comply with RFC 7159</exception>
        /// <returns>The next token in the stream.</returns>
        internal JsonToken Next()
        {
            if (bufferedToken != null)
            {
                var ret = bufferedToken;
                bufferedToken = null;
                return ret;
            }
            if (state == State.ReaderExhausted)
            {
                throw new InvalidOperationException("Next() called after end of document");
            }
            while (true)
            {
                var next = reader.Read();
                if (next == null)
                {
                    ValidateState(State.ExpectedEndOfDocument, "Unexpected end of document in state: ");
                    state = State.ReaderExhausted;
                    return JsonToken.EndDocument;
                }
                switch (next.Value)
                {
                    // Skip whitespace between tokens
                    case ' ':
                    case '\t':
                    case '\r':
                    case '\n':
                        break;
                    case ':':
                        ValidateState(State.ObjectBeforeColon, "Invalid state to read a colon: ");
                        state = State.ObjectAfterColon;
                        break;
                    case ',':
                        ValidateState(State.ObjectAfterProperty | State.ArrayAfterValue, "Invalid state to read a comma: ");
                        state = state == State.ObjectAfterProperty ? State.ObjectAfterComma : State.ArrayAfterComma;
                        break;
                    case '"':
                        string stringValue = ReadString();
                        if ((state & (State.ObjectStart | State.ObjectAfterComma)) != 0)
                        {
                            state = State.ObjectBeforeColon;
                            return JsonToken.Name(stringValue);
                        }
                        else
                        {
                            ValidateAndModifyStateForValue("Invalid state to read a double quote: ");
                            return JsonToken.Value(stringValue);
                        }
                    case '{':
                        ValidateState(ValueStates, "Invalid state to read an open brace: ");
                        state = State.ObjectStart;
                        PushContainer(ContainerType.Object);
                        return JsonToken.StartObject;
                    case '}':
                        ValidateState(State.ObjectAfterProperty | State.ObjectStart, "Invalid state to read a close brace: ");
                        PopContainer();
                        return JsonToken.EndObject;
                    case '[':
                        ValidateState(ValueStates, "Invalid state to read an open square bracket: ");
                        state = State.ArrayStart;
                        PushContainer(ContainerType.Array);
                        return JsonToken.StartArray;
                    case ']':
                        ValidateState(State.ArrayAfterValue | State.ArrayStart, "Invalid state to read a close square bracket: ");
                        PopContainer();
                        return JsonToken.EndArray;
                    case 'n': // Start of null
                        ConsumeLiteral("null");
                        ValidateAndModifyStateForValue("Invalid state to read a null literal: ");
                        return JsonToken.Null;
                    case 't': // Start of true
                        ConsumeLiteral("true");
                        ValidateAndModifyStateForValue("Invalid state to read a true literal: ");
                        return JsonToken.True;
                    case 'f': // Start of false
                        ConsumeLiteral("false");
                        ValidateAndModifyStateForValue("Invalid state to read a false literal: ");
                        return JsonToken.False;
                    case '-': // Start of a number
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        double number = ReadNumber(next.Value);
                        ValidateAndModifyStateForValue("Invalid state to read a number token: ");
                        return JsonToken.Value(number);
                    default:
                        throw new InvalidJsonException("Invalid first character of token: " + next.Value);
                }
            }
        }

        private void ValidateState(State validStates, string errorPrefix)
        {
            if ((validStates & state) == 0)
            {
                throw reader.CreateException(errorPrefix + state);
            }
        }

        /// <summary>
        /// Reads a string token. It is assumed that the opening " has already been read.
        /// </summary>
        private string ReadString()
        {
            var value = new StringBuilder();
            bool haveHighSurrogate = false;
            while (true)
            {
                char c = reader.ReadOrFail("Unexpected end of text while reading string");
                if (c < ' ')
                {
                    throw reader.CreateException(string.Format(CultureInfo.InvariantCulture, "Invalid character in string literal: U+{0:x4}", (int) c));
                }
                if (c == '"')
                {
                    if (haveHighSurrogate)
                    {
                        throw reader.CreateException("Invalid use of surrogate pair code units");
                    }
                    return value.ToString();
                }
                if (c == '\\')
                {
                    c = ReadEscapedCharacter();
                }
                // TODO: Consider only allowing surrogate pairs that are either both escaped,
                // or both not escaped. It would be a very odd text stream that contained a "lone" high surrogate
                // followed by an escaped low surrogate or vice versa... and that couldn't even be represented in UTF-8.
                if (haveHighSurrogate != char.IsLowSurrogate(c))
                {
                    throw reader.CreateException("Invalid use of surrogate pair code units");
                }
                haveHighSurrogate = char.IsHighSurrogate(c);
                value.Append(c);
            }
        }

        /// <summary>
        /// Reads an escaped character. It is assumed that the leading backslash has already been read.
        /// </summary>
        private char ReadEscapedCharacter()
        {
            char c = reader.ReadOrFail("Unexpected end of text while reading character escape sequence");
            switch (c)
            {
                case 'n':
                    return '\n';
                case '\\':
                    return '\\';
                case 'b':
                    return '\b';
                case 'f':
                    return '\f';
                case 'r':
                    return '\r';
                case 't':
                    return '\t';
                case '"':
                    return '"';
                case '/':
                    return '/';
                case 'u':
                    return ReadUnicodeEscape();
                default:
                    throw reader.CreateException(string.Format(CultureInfo.InvariantCulture, "Invalid character in character escape sequence: U+{0:x4}", (int) c));
            }
        }

        /// <summary>
        /// Reads an escaped Unicode 4-nybble hex sequence. It is assumed that the leading \u has already been read.
        /// </summary>
        private char ReadUnicodeEscape()
        {
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                char c = reader.ReadOrFail("Unexpected end of text while reading Unicode escape sequence");
                int nybble;
                if (c >= '0' && c <= '9')
                {
                    nybble = c - '0';
                }
                else if (c >= 'a' && c <= 'f')
                {
                    nybble = c - 'a' + 10;
                }
                else if (c >= 'A' && c <= 'F')
                {
                    nybble = c - 'A' + 10;
                }
                else
                {
                    throw reader.CreateException(string.Format(CultureInfo.InvariantCulture, "Invalid character in character escape sequence: U+{0:x4}", (int) c));
                }
                result = (result << 4) + nybble;
            }
            return (char) result;
        }

        /// <summary>
        /// Consumes a text-only literal, throwing an exception if the read text doesn't match it.
        /// It is assumed that the first letter of the literal has already been read.
        /// </summary>
        private void ConsumeLiteral(string text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                char? next = reader.Read();
                if (next == null)
                {
                    throw reader.CreateException("Unexpected end of text while reading literal token " + text);
                }
                if (next.Value != text[i])
                {
                    throw reader.CreateException("Unexpected character while reading literal token " + text);
                }
            }
        }

        private double ReadNumber(char initialCharacter)
        {
            StringBuilder builder = new StringBuilder();
            if (initialCharacter == '-')
            {
                builder.Append("-");
            }
            else
            {
                reader.PushBack(initialCharacter);
            }
            // Each method returns the character it read that doesn't belong in that part,
            // so we know what to do next, including pushing the character back at the end.
            // null is returned for "end of text".
            char? next = ReadInt(builder);
            if (next == '.')
            {
                next = ReadFrac(builder);
            }
            if (next == 'e' || next == 'E')
            {
                next = ReadExp(builder);
            }
            // If we read a character which wasn't part of the number, push it back so we can read it again
            // to parse the next token.
            if (next != null)
            {
                reader.PushBack(next.Value);
            }

            // TODO: What exception should we throw if the value can't be represented as a double?
            try
            {
                return double.Parse(builder.ToString(),
                    NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent,
                    CultureInfo.InvariantCulture);
            }
            catch (OverflowException)
            {
                throw reader.CreateException("Numeric value out of range: " + builder);
            }
        }

        private char? ReadInt(StringBuilder builder)
        {
            char first = reader.ReadOrFail("Invalid numeric literal");
            if (first < '0' || first > '9')
            {
                throw reader.CreateException("Invalid numeric literal");
            }
            builder.Append(first);
            int digitCount;
            char? next = ConsumeDigits(builder, out digitCount);
            if (first == '0' && digitCount != 0)
            {
                throw reader.CreateException("Invalid numeric literal: leading 0 for non-zero value.");
            }
            return next;
        }

        private char? ReadFrac(StringBuilder builder)
        {
            builder.Append('.'); // Already consumed this
            int digitCount;
            char? next = ConsumeDigits(builder, out digitCount);
            if (digitCount == 0)
            {
                throw reader.CreateException("Invalid numeric literal: fraction with no trailing digits");
            }
            return next;
        }

        private char? ReadExp(StringBuilder builder)
        {
            builder.Append('E'); // Already consumed this (or 'e')
            char? next = reader.Read();
            if (next == null)
            {
                throw reader.CreateException("Invalid numeric literal: exponent with no trailing digits");
            }
            if (next == '-' || next == '+')
            {
                builder.Append(next.Value);
            }
            else
            {
                reader.PushBack(next.Value);
            }
            int digitCount;
            next = ConsumeDigits(builder, out digitCount);
            if (digitCount == 0)
            {
                throw reader.CreateException("Invalid numeric literal: exponent without value");
            }
            return next;
        }

        private char? ConsumeDigits(StringBuilder builder, out int count)
        {
            count = 0;
            while (true)
            {
                char? next = reader.Read();
                if (next == null || next.Value < '0' || next.Value > '9')
                {
                    return next;
                }
                count++;
                builder.Append(next.Value);
            }
        }

        /// <summary>
        /// Validates that we're in a valid state to read a value (using the given error prefix if necessary)
        /// and changes the state to the appropriate one, e.g. ObjectAfterColon to ObjectAfterProperty.
        /// </summary>
        private void ValidateAndModifyStateForValue(string errorPrefix)
        {
            ValidateState(ValueStates, errorPrefix);
            switch (state)
            {
                case State.StartOfDocument:
                    state = State.ExpectedEndOfDocument;
                    return;
                case State.ObjectAfterColon:
                    state = State.ObjectAfterProperty;
                    return;
                case State.ArrayStart:
                case State.ArrayAfterComma:
                    state = State.ArrayAfterValue;
                    return;
                default:
                    throw new InvalidOperationException("ValidateAndModifyStateForValue does not handle all value states (and should)");
            }
        }

        /// <summary>
        /// Pops the top-most container, and sets the state to the appropriate one for the end of a value
        /// in the parent container.
        /// </summary>
        private void PopContainer()
        {
            containerStack.Pop();
            var parent = containerStack.Peek();
            switch (parent)
            {
                case ContainerType.Object:
                    state = State.ObjectAfterProperty;
                    break;
                case ContainerType.Array:
                    state = State.ArrayAfterValue;
                    break;
                case ContainerType.Document:
                    state = State.ExpectedEndOfDocument;
                    break;
                default:
                    throw new InvalidOperationException("Unexpected container type: " + parent);
            }
        }

        private enum ContainerType
        {
            Document, Object, Array
        }

        /// <summary>
        /// Possible states of the tokenizer.
        /// </summary>
        /// <remarks>
        /// <para>This is a flags enum purely so we can simply and efficiently represent a set of valid states
        /// for checking.</para>
        /// <para>
        /// Each is documented with an example,
        /// where ^ represents the current position within the text stream. The examples all use string values,
        /// but could be any value, including nested objects/arrays.
        /// The complete state of the tokenizer also includes a stack to indicate the contexts (arrays/objects).
        /// Any additional notional state of "AfterValue" indicates that a value has been completed, at which 
        /// point there's an immediate transition to ExpectedEndOfDocument,  ObjectAfterProperty or ArrayAfterValue.
        /// </para>
        /// <para>
        /// These states were derived manually by reading RFC 7159 carefully.
        /// </para>
        /// </remarks>
        [Flags]
        private enum State
        {
            /// <summary>
            /// ^ { "foo": "bar" }
            /// Before the value in a document. Next states: ObjectStart, ArrayStart, "AfterValue"
            /// </summary>
            StartOfDocument = 1 << 0,
            /// <summary>
            /// { "foo": "bar" } ^
            /// After the value in a document. Next states: ReaderExhausted
            /// </summary>
            ExpectedEndOfDocument = 1 << 1,
            /// <summary>
            /// { "foo": "bar" } ^ (and already read to the end of the reader)
            /// Terminal state.
            /// </summary>
            ReaderExhausted = 1 << 2,
            /// <summary>
            /// { ^ "foo": "bar" }
            /// Before the *first* property in an object.
            /// Next states:
            /// "AfterValue" (empty object)
            /// ObjectBeforeColon (read a name)
            /// </summary>
            ObjectStart = 1 << 3,
            /// <summary>
            /// { "foo" ^ : "bar", "x": "y" }
            /// Next state: ObjectAfterColon
            /// </summary>
            ObjectBeforeColon = 1 << 4,
            /// <summary>
            /// { "foo" : ^ "bar", "x": "y" }
            /// Before any property other than the first in an object.
            /// (Equivalently: after any property in an object) 
            /// Next states:
            /// "AfterValue" (value is simple)
            /// ObjectStart (value is object)
            /// ArrayStart (value is array)
            /// </summary>
            ObjectAfterColon = 1 << 5,
            /// <summary>
            /// { "foo" : "bar" ^ , "x" : "y" }
            /// At the end of a property, so expecting either a comma or end-of-object
            /// Next states: ObjectAfterComma or "AfterValue"
            /// </summary>
            ObjectAfterProperty = 1 << 6,
            /// <summary>
            /// { "foo":"bar", ^ "x":"y" }
            /// Read the comma after the previous property, so expecting another property.
            /// This is like ObjectStart, but closing brace isn't valid here
            /// Next state: ObjectBeforeColon.
            /// </summary>
            ObjectAfterComma = 1 << 7,
            /// <summary>
            /// [ ^ "foo", "bar" ]
            /// Before the *first* value in an array.
            /// Next states:
            /// "AfterValue" (read a value)
            /// "AfterValue" (end of array; will pop stack)
            /// </summary>
            ArrayStart = 1 << 8,
            /// <summary>
            /// [ "foo" ^ , "bar" ]
            /// After any value in an array, so expecting either a comma or end-of-array
            /// Next states: ArrayAfterComma or "AfterValue"
            /// </summary>
            ArrayAfterValue = 1 << 9,
            /// <summary>
            /// [ "foo", ^ "bar" ]
            /// After a comma in an array, so there *must* be another value (simple or complex).
            /// Next states: "AfterValue" (simple value), StartObject, StartArray
            /// </summary>
            ArrayAfterComma = 1 << 10
        }

        /// <summary>
        /// Wrapper around a text reader allowing small amounts of buffering and location handling.
        /// </summary>
        private class PushBackReader
        {
            // TODO: Add locations for errors etc.

            private readonly TextReader reader;

            internal PushBackReader(TextReader reader)
            {
                // TODO: Wrap the reader in a BufferedReader?
                this.reader = reader;
            }

            /// <summary>
            /// The buffered next character, if we have one.
            /// </summary>
            private char? nextChar;

            /// <summary>
            /// Returns the next character in the stream, or null if we have reached the end.
            /// </summary>
            /// <returns></returns>
            internal char? Read()
            {
                if (nextChar != null)
                {
                    char? tmp = nextChar;
                    nextChar = null;
                    return tmp;
                }
                int next = reader.Read();
                return next == -1 ? null : (char?) next;
            }

            internal char ReadOrFail(string messageOnFailure)
            {
                char? next = Read();
                if (next == null)
                {
                    throw CreateException(messageOnFailure);
                }
                return next.Value;
            }

            internal void PushBack(char c)
            {
                if (nextChar != null)
                {
                    throw new InvalidOperationException("Cannot push back when already buffering a character");
                }
                nextChar = c;
            }

            /// <summary>
            /// Creates a new exception appropriate for the current state of the reader.
            /// </summary>
            internal InvalidJsonException CreateException(string message)
            {
                // TODO: Keep track of and use the location.
                return new InvalidJsonException(message);
            }
        }
    }
}
