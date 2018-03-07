/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/type/latlng.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Type {

  /// <summary>Holder for reflection information generated from google/type/latlng.proto</summary>
  public static partial class LatlngReflection {

    #region Descriptor
    /// <summary>File descriptor for google/type/latlng.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LatlngReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chhnb29nbGUvdHlwZS9sYXRsbmcucHJvdG8SC2dvb2dsZS50eXBlIi0KBkxh",
            "dExuZxIQCghsYXRpdHVkZRgBIAEoARIRCglsb25naXR1ZGUYAiABKAFCYAoP",
            "Y29tLmdvb2dsZS50eXBlQgtMYXRMbmdQcm90b1ABWjhnb29nbGUuZ29sYW5n",
            "Lm9yZy9nZW5wcm90by9nb29nbGVhcGlzL3R5cGUvbGF0bG5nO2xhdGxuZ6IC",
            "A0dUUGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Type.LatLng), global::Google.Type.LatLng.Parser, new[]{ "Latitude", "Longitude" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// An object representing a latitude/longitude pair. This is expressed as a pair
  /// of doubles representing degrees latitude and degrees longitude. Unless
  /// specified otherwise, this must conform to the
  /// &lt;a href="http://www.unoosa.org/pdf/icg/2012/template/WGS_84.pdf">WGS84
  /// standard&lt;/a>. Values must be within normalized ranges.
  ///
  /// Example of normalization code in Python:
  ///
  ///     def NormalizeLongitude(longitude):
  ///       """Wraps decimal degrees longitude to [-180.0, 180.0]."""
  ///       q, r = divmod(longitude, 360.0)
  ///       if r > 180.0 or (r == 180.0 and q &lt;= -1.0):
  ///         return r - 360.0
  ///       return r
  ///
  ///     def NormalizeLatLng(latitude, longitude):
  ///       """Wraps decimal degrees latitude and longitude to
  ///       [-90.0, 90.0] and [-180.0, 180.0], respectively."""
  ///       r = latitude % 360.0
  ///       if r &lt;= 90.0:
  ///         return r, NormalizeLongitude(longitude)
  ///       elif r >= 270.0:
  ///         return r - 360, NormalizeLongitude(longitude)
  ///       else:
  ///         return 180 - r, NormalizeLongitude(longitude + 180.0)
  ///
  ///     assert 180.0 == NormalizeLongitude(180.0)
  ///     assert -180.0 == NormalizeLongitude(-180.0)
  ///     assert -179.0 == NormalizeLongitude(181.0)
  ///     assert (0.0, 0.0) == NormalizeLatLng(360.0, 0.0)
  ///     assert (0.0, 0.0) == NormalizeLatLng(-360.0, 0.0)
  ///     assert (85.0, 180.0) == NormalizeLatLng(95.0, 0.0)
  ///     assert (-85.0, -170.0) == NormalizeLatLng(-95.0, 10.0)
  ///     assert (90.0, 10.0) == NormalizeLatLng(90.0, 10.0)
  ///     assert (-90.0, -10.0) == NormalizeLatLng(-90.0, -10.0)
  ///     assert (0.0, -170.0) == NormalizeLatLng(-180.0, 10.0)
  ///     assert (0.0, -170.0) == NormalizeLatLng(180.0, 10.0)
  ///     assert (-90.0, 10.0) == NormalizeLatLng(270.0, 10.0)
  ///     assert (90.0, 10.0) == NormalizeLatLng(-270.0, 10.0)
  /// </summary>
  public sealed partial class LatLng : pb::IMessage<LatLng> {
    private static readonly pb::MessageParser<LatLng> _parser = new pb::MessageParser<LatLng>(() => new LatLng());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LatLng> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Type.LatlngReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LatLng() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LatLng(LatLng other) : this() {
      latitude_ = other.latitude_;
      longitude_ = other.longitude_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LatLng Clone() {
      return new LatLng(this);
    }

    /// <summary>Field number for the "latitude" field.</summary>
    public const int LatitudeFieldNumber = 1;
    private double latitude_;
    /// <summary>
    /// The latitude in degrees. It must be in the range [-90.0, +90.0].
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Latitude {
      get { return latitude_; }
      set {
        latitude_ = value;
      }
    }

    /// <summary>Field number for the "longitude" field.</summary>
    public const int LongitudeFieldNumber = 2;
    private double longitude_;
    /// <summary>
    /// The longitude in degrees. It must be in the range [-180.0, +180.0].
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Longitude {
      get { return longitude_; }
      set {
        longitude_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LatLng);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LatLng other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Latitude, other.Latitude)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Longitude, other.Longitude)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Latitude != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Latitude);
      if (Longitude != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Longitude);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Latitude != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Latitude);
      }
      if (Longitude != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Longitude);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Latitude != 0D) {
        size += 1 + 8;
      }
      if (Longitude != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LatLng other) {
      if (other == null) {
        return;
      }
      if (other.Latitude != 0D) {
        Latitude = other.Latitude;
      }
      if (other.Longitude != 0D) {
        Longitude = other.Longitude;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 9: {
            Latitude = input.ReadDouble();
            break;
          }
          case 17: {
            Longitude = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
