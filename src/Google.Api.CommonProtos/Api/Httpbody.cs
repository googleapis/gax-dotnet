/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: google/api/httpbody.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/httpbody.proto</summary>
  public static partial class HttpbodyReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/httpbody.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static HttpbodyReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chlnb29nbGUvYXBpL2h0dHBib2R5LnByb3RvEgpnb29nbGUuYXBpIi4KCEh0",
            "dHBCb2R5EhQKDGNvbnRlbnRfdHlwZRgBIAEoCRIMCgRkYXRhGAIgASgMQigK",
            "DmNvbS5nb29nbGUuYXBpQg1IdHRwQm9keVByb3RvUAGiAgRHQVBJYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.HttpBody), global::Google.Api.HttpBody.Parser, new[]{ "ContentType", "Data" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///  Message that represents an arbitrary HTTP body. It should only be used for
  ///  payload formats that can't be represented as JSON, such as raw binary or
  ///  an HTML page.
  ///
  ///  This message can be used both in streaming and non-streaming API methods in
  ///  the request as well as the response.
  ///
  ///  It can be used as a top-level request field, which is convenient if one
  ///  wants to extract parameters from either the URL or HTTP template into the
  ///  request fields and also want access to the raw HTTP body.
  ///
  ///  Example:
  ///
  ///      message GetResourceRequest {
  ///        // A unique request id.
  ///        string request_id = 1;
  ///
  ///        // The raw HTTP body is bound to this field.
  ///        google.api.HttpBody http_body = 2;
  ///      }
  ///
  ///      service ResourceService {
  ///        rpc GetResource(GetResourceRequest) returns (google.api.HttpBody);
  ///        rpc UpdateResource(google.api.HttpBody) returns (google.protobuf.Empty);
  ///      }
  ///
  ///  Example with streaming methods:
  ///
  ///      service CaldavService {
  ///        rpc GetCalendar(stream google.api.HttpBody)
  ///          returns (stream google.api.HttpBody);
  ///        rpc UpdateCalendar(stream google.api.HttpBody)
  ///          returns (stream google.api.HttpBody);
  ///      }
  ///
  ///  Use of this type only changes how the request and response bodies are
  ///  handled, all other features will continue to work unchanged.
  /// </summary>
  public sealed partial class HttpBody : pb::IMessage<HttpBody> {
    private static readonly pb::MessageParser<HttpBody> _parser = new pb::MessageParser<HttpBody>(() => new HttpBody());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HttpBody> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.HttpbodyReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HttpBody() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HttpBody(HttpBody other) : this() {
      contentType_ = other.contentType_;
      data_ = other.data_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HttpBody Clone() {
      return new HttpBody(this);
    }

    /// <summary>Field number for the "content_type" field.</summary>
    public const int ContentTypeFieldNumber = 1;
    private string contentType_ = "";
    /// <summary>
    ///  The HTTP Content-Type string representing the content type of the body.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ContentType {
      get { return contentType_; }
      set {
        contentType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 2;
    private pb::ByteString data_ = pb::ByteString.Empty;
    /// <summary>
    ///  HTTP body binary data.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HttpBody);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HttpBody other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ContentType != other.ContentType) return false;
      if (Data != other.Data) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ContentType.Length != 0) hash ^= ContentType.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ContentType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ContentType);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(18);
        output.WriteBytes(Data);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ContentType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ContentType);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HttpBody other) {
      if (other == null) {
        return;
      }
      if (other.ContentType.Length != 0) {
        ContentType = other.ContentType;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            ContentType = input.ReadString();
            break;
          }
          case 18: {
            Data = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
