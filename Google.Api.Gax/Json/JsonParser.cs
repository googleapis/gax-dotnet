/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Google.Api.Gax.Json
{
    // Note: this is internal for the moment, allowing us to commit it without exposing it until
    // we're ready. Libraries using this will temporarily use InternalsVisibleTo to access it, but that
    // will be removed before they are fully released (by which point this type must be public).

    /// <summary>
    /// Crude JSON parser. This is only capable of parsing documents that are fully compliant with RFC 7159.
    /// Each JSON value is represented as:
    /// 
    /// - JSON string: System.String
    /// - JSON number: System.Double
    /// - JSON array: System.Collections.Generic.List`1{System.Object}
    /// - JSON object: System.Collections.Generic.Dictionary`1{System.String, System.Object}
    /// - JSON Boolean: System.Boolean
    /// - JSON null: null reference
    /// </summary>
    internal static class JsonParser
    {
        internal static object Parse(string json) => Parse(new StringReader(GaxPreconditions.CheckNotNull(json, nameof(json))));

        internal static object Parse(TextReader reader)
        {
            GaxPreconditions.CheckNotNull(reader, nameof(reader));
            var tokenizer = JsonTokenizer.FromTextReader(reader);
            object ret = ParseValue(tokenizer);
            var token = tokenizer.Next();
            if (token.Type != JsonToken.TokenType.EndDocument)
            {
                throw new InvalidOperationException($"JsonTokenizer returned token type {token.Type} when it should be at end of document");
            }
            return ret;
        }

        private static object ParseValue(JsonTokenizer tokenizer)
        {
            var token = tokenizer.Next();
            switch (token.Type)
            {
                case JsonToken.TokenType.StartArray: return ParseArray(tokenizer);
                case JsonToken.TokenType.StartObject: return ParseObject(tokenizer);
                case JsonToken.TokenType.StringValue: return token.StringValue;
                case JsonToken.TokenType.Number: return token.NumberValue;
                case JsonToken.TokenType.True: return true;
                case JsonToken.TokenType.False: return false;
                case JsonToken.TokenType.Null: return null;
                default: throw new InvalidOperationException($"JsonTokenizer returned token type {token.Type} at start of value");
            }
        }

        private static Dictionary<string, object> ParseObject(JsonTokenizer tokenizer)
        {
            var properties = new Dictionary<string, object>();
            while (true)
            {
                var token = tokenizer.Next();
                switch (token.Type)
                {
                    case JsonToken.TokenType.Name:
                        string name = token.StringValue;
                        if (properties.ContainsKey(name))
                        {
                            throw new InvalidJsonException("JsonParser does not support JSON containing duplicate keys");
                        }
                        object value = ParseValue(tokenizer);
                        properties[name] = value;
                        break;
                    case JsonToken.TokenType.EndObject:
                        return properties;
                    default: throw new InvalidOperationException($"JsonTokenizer returned token type {token.Type} within object");
                }
            }
        }

        private static List<object> ParseArray(JsonTokenizer tokenizer)
        {
            List<object> values = new List<object>();
            while (true)
            {
                var token = tokenizer.Peek();
                switch (token.Type)
                {
                    case JsonToken.TokenType.EndArray:
                        tokenizer.Next(); // Consume the token
                        return values;
                    // All the token types representing values
                    case JsonToken.TokenType.StartArray:
                    case JsonToken.TokenType.StartObject:
                    case JsonToken.TokenType.StringValue:
                    case JsonToken.TokenType.Number:
                    case JsonToken.TokenType.True:
                    case JsonToken.TokenType.False:
                    case JsonToken.TokenType.Null:
                        values.Add(ParseValue(tokenizer));
                        break;
                    default: throw new InvalidOperationException($"JsonTokenizer returned token type {token.Type} within array");
                }
            }
        }        
    }
}
