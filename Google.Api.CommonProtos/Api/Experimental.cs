/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/experimental/experimental.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/experimental/experimental.proto</summary>
  public static partial class ExperimentalReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/experimental/experimental.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ExperimentalReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cipnb29nbGUvYXBpL2V4cGVyaW1lbnRhbC9leHBlcmltZW50YWwucHJvdG8S",
            "Cmdvb2dsZS5hcGkaHGdvb2dsZS9hcGkvYW5ub3RhdGlvbnMucHJvdG8aMmdv",
            "b2dsZS9hcGkvZXhwZXJpbWVudGFsL2F1dGhvcml6YXRpb25fY29uZmlnLnBy",
            "b3RvIkYKDEV4cGVyaW1lbnRhbBI2Cg1hdXRob3JpemF0aW9uGAggASgLMh8u",
            "Z29vZ2xlLmFwaS5BdXRob3JpemF0aW9uQ29uZmlnQlsKDmNvbS5nb29nbGUu",
            "YXBpQhFFeHBlcmltZW50YWxQcm90b1ABWi1nb29nbGUuZ29sYW5nLm9yZy9n",
            "ZW5wcm90by9nb29nbGVhcGlzL2FwaTthcGmiAgRHQVBJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, global::Google.Api.AuthorizationConfigReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Experimental), global::Google.Api.Experimental.Parser, new[]{ "Authorization" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Experimental service configuration. These configuration options can
  /// only be used by whitelisted users.
  /// </summary>
  public sealed partial class Experimental : pb::IMessage<Experimental> {
    private static readonly pb::MessageParser<Experimental> _parser = new pb::MessageParser<Experimental>(() => new Experimental());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Experimental> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.ExperimentalReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Experimental() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Experimental(Experimental other) : this() {
      authorization_ = other.authorization_ != null ? other.authorization_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Experimental Clone() {
      return new Experimental(this);
    }

    /// <summary>Field number for the "authorization" field.</summary>
    public const int AuthorizationFieldNumber = 8;
    private global::Google.Api.AuthorizationConfig authorization_;
    /// <summary>
    /// Authorization configuration.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Api.AuthorizationConfig Authorization {
      get { return authorization_; }
      set {
        authorization_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Experimental);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Experimental other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Authorization, other.Authorization)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (authorization_ != null) hash ^= Authorization.GetHashCode();
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
      if (authorization_ != null) {
        output.WriteRawTag(66);
        output.WriteMessage(Authorization);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (authorization_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Authorization);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Experimental other) {
      if (other == null) {
        return;
      }
      if (other.authorization_ != null) {
        if (authorization_ == null) {
          authorization_ = new global::Google.Api.AuthorizationConfig();
        }
        Authorization.MergeFrom(other.Authorization);
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
          case 66: {
            if (authorization_ == null) {
              authorization_ = new global::Google.Api.AuthorizationConfig();
            }
            input.ReadMessage(authorization_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
