/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api.Gax {

  /// <summary>Holder for reflection information generated from test_messages.proto</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public static partial class TestMessagesReflection {

    #region Descriptor
    /// <summary>File descriptor for test_messages.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TestMessagesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChN0ZXN0X21lc3NhZ2VzLnByb3RvEg5nb29nbGUuYXBpLmdheCIwCg9CdW5k",
            "bGluZ1JlcXVlc3QSDAoEbmFtZRgBIAEoCRIPCgdlbnRyaWVzGAIgAygJIjEK",
            "EEJ1bmRsaW5nUmVzcG9uc2USDAoEbmFtZRgCIAEoCRIPCgdlbnRyaWVzGAMg",
            "AygJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedCodeInfo(null, new pbr::GeneratedCodeInfo[] {
            new pbr::GeneratedCodeInfo(typeof(global::Google.Api.Gax.BundlingRequest), global::Google.Api.Gax.BundlingRequest.Parser, new[]{ "Name", "Entries" }, null, null, null),
            new pbr::GeneratedCodeInfo(typeof(global::Google.Api.Gax.BundlingResponse), global::Google.Api.Gax.BundlingResponse.Parser, new[]{ "Name", "Entries" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class BundlingRequest : pb::IMessage<BundlingRequest> {
    private static readonly pb::MessageParser<BundlingRequest> _parser = new pb::MessageParser<BundlingRequest>(() => new BundlingRequest());
    public static pb::MessageParser<BundlingRequest> Parser { get { return _parser; } }

    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.Gax.TestMessagesReflection.Descriptor.MessageTypes[0]; }
    }

    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    public BundlingRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    public BundlingRequest(BundlingRequest other) : this() {
      name_ = other.name_;
      entries_ = other.entries_.Clone();
    }

    public BundlingRequest Clone() {
      return new BundlingRequest(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    public string Name {
      get { return name_; }
      set {
        name_ = pb::Preconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "entries" field.</summary>
    public const int EntriesFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_entries_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> entries_ = new pbc::RepeatedField<string>();
    public pbc::RepeatedField<string> Entries {
      get { return entries_; }
    }

    public override bool Equals(object other) {
      return Equals(other as BundlingRequest);
    }

    public bool Equals(BundlingRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if(!entries_.Equals(other.entries_)) return false;
      return true;
    }

    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      hash ^= entries_.GetHashCode();
      return hash;
    }

    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      entries_.WriteTo(output, _repeated_entries_codec);
    }

    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      size += entries_.CalculateSize(_repeated_entries_codec);
      return size;
    }

    public void MergeFrom(BundlingRequest other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      entries_.Add(other.entries_);
    }

    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            entries_.AddEntriesFrom(input, _repeated_entries_codec);
            break;
          }
        }
      }
    }

  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class BundlingResponse : pb::IMessage<BundlingResponse> {
    private static readonly pb::MessageParser<BundlingResponse> _parser = new pb::MessageParser<BundlingResponse>(() => new BundlingResponse());
    public static pb::MessageParser<BundlingResponse> Parser { get { return _parser; } }

    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.Gax.TestMessagesReflection.Descriptor.MessageTypes[1]; }
    }

    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    public BundlingResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    public BundlingResponse(BundlingResponse other) : this() {
      name_ = other.name_;
      entries_ = other.entries_.Clone();
    }

    public BundlingResponse Clone() {
      return new BundlingResponse(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    public string Name {
      get { return name_; }
      set {
        name_ = pb::Preconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "entries" field.</summary>
    public const int EntriesFieldNumber = 3;
    private static readonly pb::FieldCodec<string> _repeated_entries_codec
        = pb::FieldCodec.ForString(26);
    private readonly pbc::RepeatedField<string> entries_ = new pbc::RepeatedField<string>();
    public pbc::RepeatedField<string> Entries {
      get { return entries_; }
    }

    public override bool Equals(object other) {
      return Equals(other as BundlingResponse);
    }

    public bool Equals(BundlingResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if(!entries_.Equals(other.entries_)) return false;
      return true;
    }

    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      hash ^= entries_.GetHashCode();
      return hash;
    }

    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      entries_.WriteTo(output, _repeated_entries_codec);
    }

    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      size += entries_.CalculateSize(_repeated_entries_codec);
      return size;
    }

    public void MergeFrom(BundlingResponse other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      entries_.Add(other.entries_);
    }

    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            entries_.AddEntriesFrom(input, _repeated_entries_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
