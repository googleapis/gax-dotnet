/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Globalization;
using System.Text;

namespace Google.Api.Gax.Json
{
    // Note: this is internal for the moment, allowing us to commit it without exposing it until
    // we're ready. Libraries using this will temporarily use InternalsVisibleTo to access it, but that
    // will be removed before they are fully released (by which point this type must be public).

    /// <summary>
    /// Utility class for generating JSON. This class doesn't perform much in the way of validity
    /// checks - that's left as the responsibility of the caller. However, it allows values and properties
    /// to be written in a simple, chainable way, without the caller needing to worry about adding commas.
    /// </summary>
    internal sealed class JsonBuilder
    {
        /// <summary>
        /// The JSON representation of the first 160 characters of Unicode.
        /// Empty strings are replaced by the static constructor.
        /// </summary>
        private static readonly string[] CommonRepresentations = {
          // C0 (ASCII and derivatives) control characters
          "\\u0000", "\\u0001", "\\u0002", "\\u0003",  // 0x00
          "\\u0004", "\\u0005", "\\u0006", "\\u0007",
          "\\b",     "\\t",     "\\n",     "\\u000b",
          "\\f",     "\\r",     "\\u000e", "\\u000f",
          "\\u0010", "\\u0011", "\\u0012", "\\u0013",  // 0x10
          "\\u0014", "\\u0015", "\\u0016", "\\u0017",
          "\\u0018", "\\u0019", "\\u001a", "\\u001b",
          "\\u001c", "\\u001d", "\\u001e", "\\u001f",
          // Escaping of " and \ are required by www.json.org string definition.
          // Escaping of < and > are required for HTML security.
          "", "", "\\\"", "", "",        "", "",        "",  // 0x20
          "", "", "",     "", "",        "", "",        "",
          "", "", "",     "", "",        "", "",        "",  // 0x30
          "", "", "",     "", "\\u003c", "", "\\u003e", "",
          "", "", "",     "", "",        "", "",        "",  // 0x40
          "", "", "",     "", "",        "", "",        "",
          "", "", "",     "", "",        "", "",        "",  // 0x50
          "", "", "",     "", "\\\\",    "", "",        "",
          "", "", "",     "", "",        "", "",        "",  // 0x60
          "", "", "",     "", "",        "", "",        "",
          "", "", "",     "", "",        "", "",        "",  // 0x70
          "", "", "",     "", "",        "", "",        "\\u007f",
          // C1 (ISO 8859 and Unicode) extended control characters
          "\\u0080", "\\u0081", "\\u0082", "\\u0083",  // 0x80
          "\\u0084", "\\u0085", "\\u0086", "\\u0087",
          "\\u0088", "\\u0089", "\\u008a", "\\u008b",
          "\\u008c", "\\u008d", "\\u008e", "\\u008f",
          "\\u0090", "\\u0091", "\\u0092", "\\u0093",  // 0x90
          "\\u0094", "\\u0095", "\\u0096", "\\u0097",
          "\\u0098", "\\u0099", "\\u009a", "\\u009b",
          "\\u009c", "\\u009d", "\\u009e", "\\u009f"
        };

        static JsonBuilder()
        {
            for (int i = 0; i < CommonRepresentations.Length; i++)
            {
                if (CommonRepresentations[i] == "")
                {
                    CommonRepresentations[i] = ((char) i).ToString();
                }
            }
        }

        private readonly StringBuilder _builder;
        private bool _trailingComma = false;
        private int _depth = 0;

        /// <summary>
        /// Constructs a new instance using the specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to append to. Must not be null.</param>
        internal JsonBuilder(StringBuilder builder)
        {
            _builder = GaxPreconditions.CheckNotNull(builder, nameof(builder));
        }

        /// <summary>
        /// Constructs a new instance with a new <see cref="StringBuilder"/>.
        /// </summary>
        internal JsonBuilder() : this(new StringBuilder())
        {
        }

        /// <summary>
        /// Writes the start of an object to the builder.
        /// </summary>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder StartObject()
        {
            _builder.Append('{');
            _trailingComma = false;
            _depth++;
            return this;
        }

        /// <summary>
        /// Writes the start of an array to the builder.
        /// </summary>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder StartArray()
        {
            _builder.Append('[');
            _trailingComma = false;
            _depth++;
            return this;
        }

        /// <summary>
        /// Writes the end of an array to the builder.
        /// </summary>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder EndArray()
        {
            StripTrailingComma();
            _builder.Append(']');
            GaxPreconditions.CheckState(_depth > 0, "Attempted to end more objects than started");
            _depth--;
            MaybeAppendComma();
            return this;
        }

        /// <summary>
        /// Writes the end of an object to the builder.
        /// </summary>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder EndObject()
        {
            StripTrailingComma();
            _builder.Append('}');
            GaxPreconditions.CheckState(_depth > 0, "Attempted to end more objects than started");
            _depth--;
            MaybeAppendComma();
            return this;
        }

        /// <summary>
        /// Writes a string value to the builder, escaping it if necessary.
        /// </summary>
        /// <param name="value">The value to write. May be null.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder Value(string value)
        {
            WriteString(value);
            MaybeAppendComma();
            return this;
        }

        /// <summary>
        /// Writes a Boolean value to the builder.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder Value(bool value)
        {
            _builder.Append(value ? "true" : "false");
            MaybeAppendComma();
            return this;
        }

        /// <summary>
        /// Writes a numeric value to the builder.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder Value(double value)
        {
            // TODO: We could take the protobuf approach of appending a string value instead...
            GaxPreconditions.CheckArgument(!double.IsNaN(value) && !double.IsInfinity(value), nameof(value), "Cannot format infinite/NaN values in JSON");
            _builder.Append(value.ToString("r", CultureInfo.InvariantCulture));
            MaybeAppendComma();
            return this;
        }

        /// <summary>
        /// Writes a name/value property pair to the builder for a string value.
        /// </summary>
        /// <param name="name">The name of the property. Must not be null.</param>
        /// <param name="value">The value of the property. May be null.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder Property(string name, string value) => PropertyName(name).Value(value);

        /// <summary>
        /// Writes a name/value property pair to the builder for a Boolean value.
        /// </summary>
        /// <param name="name">The name of the property. Must not be null.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder Property(string name, bool value) => PropertyName(name).Value(value);

        /// <summary>
        /// Writes a name/value property pair to the builder for a numeric value.
        /// </summary>
        /// <param name="name">The name of the property. Must not be null.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder Property(string name, double value) => PropertyName(name).Value(value);

        /// <summary>
        /// Writes a property name to the builder, so that an array or object value may then be written.
        /// </summary>
        /// <param name="name">The name of the property. Must not be null.</param>
        /// <returns>A reference to the same <see cref="JsonBuilder"/> the method was called on, for chaining.</returns>
        internal JsonBuilder PropertyName(string name)
        {
            GaxPreconditions.CheckNotNull(name, nameof(name));
            WriteString(name);
            _builder.Append(':');
            return this;
        }

        /// <summary>
        /// Returns the string representation of the underlying <see cref="StringBuilder"/>.
        /// If this builder was created with an existing StringBuilder instance, any data written earlier
        /// will be included in the result.
        /// </summary>
        /// <returns>The string representation of the builder.</returns>
        public override string ToString() => _builder.ToString();

        private void StripTrailingComma()
        {
            if (_trailingComma)
            {
                _builder.Length--;
                _trailingComma = false;
            }
        }

        private void MaybeAppendComma()
        {
            if (_depth > 0)
            {
                _builder.Append(',');
            }
            _trailingComma = true;
        }

        private void WriteString(string value)
        {
            if (value == null)
            {
                _builder.Append("null");
                return;
            }

            _builder.Append('"');

            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c < 0xa0)
                {
                    _builder.Append(CommonRepresentations[c]);
                    continue;
                }
                if (char.IsHighSurrogate(c))
                {
                    // Encountered first part of a surrogate pair.
                    // Check that we have the whole pair, and encode both parts as hex.
                    i++;
                    if (i == value.Length || !char.IsLowSurrogate(value[i]))
                    {
                        throw new ArgumentException("String contains low surrogate not followed by high surrogate");
                    }
                    HexEncodeUtf16CodeUnit(c);
                    HexEncodeUtf16CodeUnit(value[i]);
                    continue;
                }
                else if (char.IsLowSurrogate(c))
                {
                    throw new ArgumentException("String contains high surrogate not preceded by low surrogate");
                }
                switch ((uint) c)
                {
                    // These are not required by json spec
                    // but used to prevent security bugs in javascript.
                    case 0xfeff:  // Zero width no-break space
                    case 0xfff9:  // Interlinear annotation anchor
                    case 0xfffa:  // Interlinear annotation separator
                    case 0xfffb:  // Interlinear annotation terminator

                    case 0x00ad:  // Soft-hyphen
                    case 0x06dd:  // Arabic end of ayah
                    case 0x070f:  // Syriac abbreviation mark
                    case 0x17b4:  // Khmer vowel inherent Aq
                    case 0x17b5:  // Khmer vowel inherent Aa
                        HexEncodeUtf16CodeUnit(c);
                        break;

                    default:
                        if ((c >= 0x0600 && c <= 0x0603) ||  // Arabic signs
                            (c >= 0x200b && c <= 0x200f) ||  // Zero width etc.
                            (c >= 0x2028 && c <= 0x202e) ||  // Separators etc.
                            (c >= 0x2060 && c <= 0x2064) ||  // Invisible etc.
                            (c >= 0x206a && c <= 0x206f))
                        {
                            HexEncodeUtf16CodeUnit(c);
                        }
                        else
                        {
                            // No handling of surrogates here - that's done earlier
                            _builder.Append(c);
                        }
                        break;
                }
            }
            _builder.Append('"');
        }

        private const string Hex = "0123456789abcdef";
        private void HexEncodeUtf16CodeUnit(char c)
        {
            _builder.Append("\\u");
            _builder.Append(Hex[(c >> 12) & 0xf]);
            _builder.Append(Hex[(c >> 8) & 0xf]);
            _builder.Append(Hex[(c >> 4) & 0xf]);
            _builder.Append(Hex[(c >> 0) & 0xf]);
        }
    }
}
