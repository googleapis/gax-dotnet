/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax.Json
{
    // Note: this is internal for the moment, allowing us to commit it without exposing it until
    // we're ready. Libraries using this will temporarily use InternalsVisibleTo to access it, but that
    // will be removed before they are fully released (by which point this type must be public).
    // (Unlike JsonParser, it's not clear whether this will *ever* be public.)

    internal sealed class JsonToken : IEquatable<JsonToken>
    {
        // Tokens with no value can be reused.
        internal static JsonToken Null { get; } = new JsonToken(TokenType.Null);
        internal static JsonToken False { get; } = new JsonToken(TokenType.False);
        internal static JsonToken True { get; } = new JsonToken(TokenType.True);
        internal static JsonToken StartObject { get; } = new JsonToken(TokenType.StartObject);
        internal static JsonToken EndObject { get; } = new JsonToken(TokenType.EndObject);
        internal static JsonToken StartArray { get; } = new JsonToken(TokenType.StartArray);
        internal static JsonToken EndArray { get; } = new JsonToken(TokenType.EndArray);
        internal static JsonToken EndDocument { get; } = new JsonToken(TokenType.EndDocument);

        // Factory methods for tokens with values.
        internal static JsonToken Name(string name) => new JsonToken(TokenType.Name, stringValue: name);
        internal static JsonToken Value(string value) => new JsonToken(TokenType.StringValue, stringValue: value);
        internal static JsonToken Value(double value) => new JsonToken(TokenType.Number, numberValue: value);

        internal enum TokenType
        {
            Null,
            False,
            True,
            StringValue,
            Number,
            Name,
            StartObject,
            EndObject,
            StartArray,
            EndArray,
            EndDocument
        }

        // A value is a string, number, array, object, null, true or false
        // Arrays and objects have start/end
        // A document consists of a value
        // Objects are name/value sequences.
        internal TokenType Type { get; }
        internal string StringValue { get; }
        internal double NumberValue { get; }

        private JsonToken(TokenType type, string stringValue = null, double numberValue = 0)
        {
            Type = type;
            StringValue = stringValue;
            NumberValue = numberValue;
        }

        public override bool Equals(object obj) => Equals(obj as JsonToken);

        public bool Equals(JsonToken other) =>
            !ReferenceEquals(other, null) &&
            other.Type == Type &&
            other.StringValue == StringValue &&
            other.NumberValue.Equals(NumberValue);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + (int) Type;
                hash = hash * 31 + StringValue == null ? 0 : StringValue.GetHashCode();
                hash = hash * 31 + NumberValue.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            switch (Type)
            {
                case TokenType.Null:
                    return "null";
                case TokenType.True:
                    return "true";
                case TokenType.False:
                    return "false";
                case TokenType.Name:
                    return "name (" + StringValue + ")";
                case TokenType.StringValue:
                    return "value (" + StringValue + ")";
                case TokenType.Number:
                    return "number (" + NumberValue + ")";
                case TokenType.StartObject:
                    return "start-object";
                case TokenType.EndObject:
                    return "end-object";
                case TokenType.StartArray:
                    return "start-array";
                case TokenType.EndArray:
                    return "end-array";
                case TokenType.EndDocument:
                    return "end-document";
                default:
                    throw new InvalidOperationException("Token is of unknown type " + Type);
            }
        }
    }
}
