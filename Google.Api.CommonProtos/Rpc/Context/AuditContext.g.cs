/*
 * Copyright 2023 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/rpc/context/audit_context.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Rpc.Context {

  /// <summary>Holder for reflection information generated from google/rpc/context/audit_context.proto</summary>
  public static partial class AuditContextReflection {

    #region Descriptor
    /// <summary>File descriptor for google/rpc/context/audit_context.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AuditContextReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiZnb29nbGUvcnBjL2NvbnRleHQvYXVkaXRfY29udGV4dC5wcm90bxISZ29v",
            "Z2xlLnJwYy5jb250ZXh0Ghxnb29nbGUvcHJvdG9idWYvc3RydWN0LnByb3Rv",
            "IscBCgxBdWRpdENvbnRleHQSEQoJYXVkaXRfbG9nGAEgASgMEjEKEHNjcnVi",
            "YmVkX3JlcXVlc3QYAiABKAsyFy5nb29nbGUucHJvdG9idWYuU3RydWN0EjIK",
            "EXNjcnViYmVkX3Jlc3BvbnNlGAMgASgLMhcuZ29vZ2xlLnByb3RvYnVmLlN0",
            "cnVjdBIkChxzY3J1YmJlZF9yZXNwb25zZV9pdGVtX2NvdW50GAQgASgFEhcK",
            "D3RhcmdldF9yZXNvdXJjZRgFIAEoCUJrChZjb20uZ29vZ2xlLnJwYy5jb250",
            "ZXh0QhFBdWRpdENvbnRleHRQcm90b1ABWjlnb29nbGUuZ29sYW5nLm9yZy9n",
            "ZW5wcm90by9nb29nbGVhcGlzL3JwYy9jb250ZXh0O2NvbnRleHT4AQFiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.StructReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Rpc.Context.AuditContext), global::Google.Rpc.Context.AuditContext.Parser, new[]{ "AuditLog", "ScrubbedRequest", "ScrubbedResponse", "ScrubbedResponseItemCount", "TargetResource" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// `AuditContext` provides information that is needed for audit logging.
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class AuditContext : pb::IMessage<AuditContext>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<AuditContext> _parser = new pb::MessageParser<AuditContext>(() => new AuditContext());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<AuditContext> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Rpc.Context.AuditContextReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AuditContext() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AuditContext(AuditContext other) : this() {
      auditLog_ = other.auditLog_;
      scrubbedRequest_ = other.scrubbedRequest_ != null ? other.scrubbedRequest_.Clone() : null;
      scrubbedResponse_ = other.scrubbedResponse_ != null ? other.scrubbedResponse_.Clone() : null;
      scrubbedResponseItemCount_ = other.scrubbedResponseItemCount_;
      targetResource_ = other.targetResource_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AuditContext Clone() {
      return new AuditContext(this);
    }

    /// <summary>Field number for the "audit_log" field.</summary>
    public const int AuditLogFieldNumber = 1;
    private pb::ByteString auditLog_ = pb::ByteString.Empty;
    /// <summary>
    /// Serialized audit log.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pb::ByteString AuditLog {
      get { return auditLog_; }
      set {
        auditLog_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "scrubbed_request" field.</summary>
    public const int ScrubbedRequestFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Struct scrubbedRequest_;
    /// <summary>
    /// An API request message that is scrubbed based on the method annotation.
    /// This field should only be filled if audit_log field is present.
    /// Service Control will use this to assemble a complete log for Cloud Audit
    /// Logs and Google internal audit logs.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Struct ScrubbedRequest {
      get { return scrubbedRequest_; }
      set {
        scrubbedRequest_ = value;
      }
    }

    /// <summary>Field number for the "scrubbed_response" field.</summary>
    public const int ScrubbedResponseFieldNumber = 3;
    private global::Google.Protobuf.WellKnownTypes.Struct scrubbedResponse_;
    /// <summary>
    /// An API response message that is scrubbed based on the method annotation.
    /// This field should only be filled if audit_log field is present.
    /// Service Control will use this to assemble a complete log for Cloud Audit
    /// Logs and Google internal audit logs.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Struct ScrubbedResponse {
      get { return scrubbedResponse_; }
      set {
        scrubbedResponse_ = value;
      }
    }

    /// <summary>Field number for the "scrubbed_response_item_count" field.</summary>
    public const int ScrubbedResponseItemCountFieldNumber = 4;
    private int scrubbedResponseItemCount_;
    /// <summary>
    /// Number of scrubbed response items.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int ScrubbedResponseItemCount {
      get { return scrubbedResponseItemCount_; }
      set {
        scrubbedResponseItemCount_ = value;
      }
    }

    /// <summary>Field number for the "target_resource" field.</summary>
    public const int TargetResourceFieldNumber = 5;
    private string targetResource_ = "";
    /// <summary>
    /// Audit resource name which is scrubbed.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string TargetResource {
      get { return targetResource_; }
      set {
        targetResource_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as AuditContext);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(AuditContext other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AuditLog != other.AuditLog) return false;
      if (!object.Equals(ScrubbedRequest, other.ScrubbedRequest)) return false;
      if (!object.Equals(ScrubbedResponse, other.ScrubbedResponse)) return false;
      if (ScrubbedResponseItemCount != other.ScrubbedResponseItemCount) return false;
      if (TargetResource != other.TargetResource) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (AuditLog.Length != 0) hash ^= AuditLog.GetHashCode();
      if (scrubbedRequest_ != null) hash ^= ScrubbedRequest.GetHashCode();
      if (scrubbedResponse_ != null) hash ^= ScrubbedResponse.GetHashCode();
      if (ScrubbedResponseItemCount != 0) hash ^= ScrubbedResponseItemCount.GetHashCode();
      if (TargetResource.Length != 0) hash ^= TargetResource.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (AuditLog.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(AuditLog);
      }
      if (scrubbedRequest_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(ScrubbedRequest);
      }
      if (scrubbedResponse_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(ScrubbedResponse);
      }
      if (ScrubbedResponseItemCount != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(ScrubbedResponseItemCount);
      }
      if (TargetResource.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(TargetResource);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (AuditLog.Length != 0) {
        output.WriteRawTag(10);
        output.WriteBytes(AuditLog);
      }
      if (scrubbedRequest_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(ScrubbedRequest);
      }
      if (scrubbedResponse_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(ScrubbedResponse);
      }
      if (ScrubbedResponseItemCount != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(ScrubbedResponseItemCount);
      }
      if (TargetResource.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(TargetResource);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (AuditLog.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(AuditLog);
      }
      if (scrubbedRequest_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ScrubbedRequest);
      }
      if (scrubbedResponse_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ScrubbedResponse);
      }
      if (ScrubbedResponseItemCount != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ScrubbedResponseItemCount);
      }
      if (TargetResource.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TargetResource);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(AuditContext other) {
      if (other == null) {
        return;
      }
      if (other.AuditLog.Length != 0) {
        AuditLog = other.AuditLog;
      }
      if (other.scrubbedRequest_ != null) {
        if (scrubbedRequest_ == null) {
          ScrubbedRequest = new global::Google.Protobuf.WellKnownTypes.Struct();
        }
        ScrubbedRequest.MergeFrom(other.ScrubbedRequest);
      }
      if (other.scrubbedResponse_ != null) {
        if (scrubbedResponse_ == null) {
          ScrubbedResponse = new global::Google.Protobuf.WellKnownTypes.Struct();
        }
        ScrubbedResponse.MergeFrom(other.ScrubbedResponse);
      }
      if (other.ScrubbedResponseItemCount != 0) {
        ScrubbedResponseItemCount = other.ScrubbedResponseItemCount;
      }
      if (other.TargetResource.Length != 0) {
        TargetResource = other.TargetResource;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            AuditLog = input.ReadBytes();
            break;
          }
          case 18: {
            if (scrubbedRequest_ == null) {
              ScrubbedRequest = new global::Google.Protobuf.WellKnownTypes.Struct();
            }
            input.ReadMessage(ScrubbedRequest);
            break;
          }
          case 26: {
            if (scrubbedResponse_ == null) {
              ScrubbedResponse = new global::Google.Protobuf.WellKnownTypes.Struct();
            }
            input.ReadMessage(ScrubbedResponse);
            break;
          }
          case 32: {
            ScrubbedResponseItemCount = input.ReadInt32();
            break;
          }
          case 42: {
            TargetResource = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            AuditLog = input.ReadBytes();
            break;
          }
          case 18: {
            if (scrubbedRequest_ == null) {
              ScrubbedRequest = new global::Google.Protobuf.WellKnownTypes.Struct();
            }
            input.ReadMessage(ScrubbedRequest);
            break;
          }
          case 26: {
            if (scrubbedResponse_ == null) {
              ScrubbedResponse = new global::Google.Protobuf.WellKnownTypes.Struct();
            }
            input.ReadMessage(ScrubbedResponse);
            break;
          }
          case 32: {
            ScrubbedResponseItemCount = input.ReadInt32();
            break;
          }
          case 42: {
            TargetResource = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
