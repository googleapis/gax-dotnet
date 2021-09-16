/*
 * Copyright 2021 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/visibility.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/visibility.proto</summary>
  public static partial class VisibilityReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/visibility.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static VisibilityReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chtnb29nbGUvYXBpL3Zpc2liaWxpdHkucHJvdG8SCmdvb2dsZS5hcGkaIGdv",
            "b2dsZS9wcm90b2J1Zi9kZXNjcmlwdG9yLnByb3RvIjcKClZpc2liaWxpdHkS",
            "KQoFcnVsZXMYASADKAsyGi5nb29nbGUuYXBpLlZpc2liaWxpdHlSdWxlIjcK",
            "DlZpc2liaWxpdHlSdWxlEhAKCHNlbGVjdG9yGAEgASgJEhMKC3Jlc3RyaWN0",
            "aW9uGAIgASgJOlQKD2VudW1fdmlzaWJpbGl0eRIcLmdvb2dsZS5wcm90b2J1",
            "Zi5FbnVtT3B0aW9ucxivyrwiIAEoCzIaLmdvb2dsZS5hcGkuVmlzaWJpbGl0",
            "eVJ1bGU6WgoQdmFsdWVfdmlzaWJpbGl0eRIhLmdvb2dsZS5wcm90b2J1Zi5F",
            "bnVtVmFsdWVPcHRpb25zGK/KvCIgASgLMhouZ29vZ2xlLmFwaS5WaXNpYmls",
            "aXR5UnVsZTpWChBmaWVsZF92aXNpYmlsaXR5Eh0uZ29vZ2xlLnByb3RvYnVm",
            "LkZpZWxkT3B0aW9ucxivyrwiIAEoCzIaLmdvb2dsZS5hcGkuVmlzaWJpbGl0",
            "eVJ1bGU6WgoSbWVzc2FnZV92aXNpYmlsaXR5Eh8uZ29vZ2xlLnByb3RvYnVm",
            "Lk1lc3NhZ2VPcHRpb25zGK/KvCIgASgLMhouZ29vZ2xlLmFwaS5WaXNpYmls",
            "aXR5UnVsZTpYChFtZXRob2RfdmlzaWJpbGl0eRIeLmdvb2dsZS5wcm90b2J1",
            "Zi5NZXRob2RPcHRpb25zGK/KvCIgASgLMhouZ29vZ2xlLmFwaS5WaXNpYmls",
            "aXR5UnVsZTpWCg5hcGlfdmlzaWJpbGl0eRIfLmdvb2dsZS5wcm90b2J1Zi5T",
            "ZXJ2aWNlT3B0aW9ucxivyrwiIAEoCzIaLmdvb2dsZS5hcGkuVmlzaWJpbGl0",
            "eVJ1bGVCbgoOY29tLmdvb2dsZS5hcGlCD1Zpc2liaWxpdHlQcm90b1ABWj9n",
            "b29nbGUuZ29sYW5nLm9yZy9nZW5wcm90by9nb29nbGVhcGlzL2FwaS92aXNp",
            "YmlsaXR5O3Zpc2liaWxpdHn4AQGiAgRHQVBJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pb::Extension[] { VisibilityExtensions.EnumVisibility, VisibilityExtensions.ValueVisibility, VisibilityExtensions.FieldVisibility, VisibilityExtensions.MessageVisibility, VisibilityExtensions.MethodVisibility, VisibilityExtensions.ApiVisibility }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Visibility), global::Google.Api.Visibility.Parser, new[]{ "Rules" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.VisibilityRule), global::Google.Api.VisibilityRule.Parser, new[]{ "Selector", "Restriction" }, null, null, null, null)
          }));
    }
    #endregion

  }
  /// <summary>Holder for extension identifiers generated from the top level of google/api/visibility.proto</summary>
  public static partial class VisibilityExtensions {
    /// <summary>
    /// See `VisibilityRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.EnumOptions, global::Google.Api.VisibilityRule> EnumVisibility =
      new pb::Extension<global::Google.Protobuf.Reflection.EnumOptions, global::Google.Api.VisibilityRule>(72295727, pb::FieldCodec.ForMessage(578365818, global::Google.Api.VisibilityRule.Parser));
    /// <summary>
    /// See `VisibilityRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.EnumValueOptions, global::Google.Api.VisibilityRule> ValueVisibility =
      new pb::Extension<global::Google.Protobuf.Reflection.EnumValueOptions, global::Google.Api.VisibilityRule>(72295727, pb::FieldCodec.ForMessage(578365818, global::Google.Api.VisibilityRule.Parser));
    /// <summary>
    /// See `VisibilityRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.FieldOptions, global::Google.Api.VisibilityRule> FieldVisibility =
      new pb::Extension<global::Google.Protobuf.Reflection.FieldOptions, global::Google.Api.VisibilityRule>(72295727, pb::FieldCodec.ForMessage(578365818, global::Google.Api.VisibilityRule.Parser));
    /// <summary>
    /// See `VisibilityRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.MessageOptions, global::Google.Api.VisibilityRule> MessageVisibility =
      new pb::Extension<global::Google.Protobuf.Reflection.MessageOptions, global::Google.Api.VisibilityRule>(72295727, pb::FieldCodec.ForMessage(578365818, global::Google.Api.VisibilityRule.Parser));
    /// <summary>
    /// See `VisibilityRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.MethodOptions, global::Google.Api.VisibilityRule> MethodVisibility =
      new pb::Extension<global::Google.Protobuf.Reflection.MethodOptions, global::Google.Api.VisibilityRule>(72295727, pb::FieldCodec.ForMessage(578365818, global::Google.Api.VisibilityRule.Parser));
    /// <summary>
    /// See `VisibilityRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.ServiceOptions, global::Google.Api.VisibilityRule> ApiVisibility =
      new pb::Extension<global::Google.Protobuf.Reflection.ServiceOptions, global::Google.Api.VisibilityRule>(72295727, pb::FieldCodec.ForMessage(578365818, global::Google.Api.VisibilityRule.Parser));
  }

  #region Messages
  /// <summary>
  /// `Visibility` defines restrictions for the visibility of service
  /// elements.  Restrictions are specified using visibility labels
  /// (e.g., PREVIEW) that are elsewhere linked to users and projects.
  ///
  /// Users and projects can have access to more than one visibility label. The
  /// effective visibility for multiple labels is the union of each label's
  /// elements, plus any unrestricted elements.
  ///
  /// If an element and its parents have no restrictions, visibility is
  /// unconditionally granted.
  ///
  /// Example:
  ///
  ///     visibility:
  ///       rules:
  ///       - selector: google.calendar.Calendar.EnhancedSearch
  ///         restriction: PREVIEW
  ///       - selector: google.calendar.Calendar.Delegate
  ///         restriction: INTERNAL
  ///
  /// Here, all methods are publicly visible except for the restricted methods
  /// EnhancedSearch and Delegate.
  /// </summary>
  public sealed partial class Visibility : pb::IMessage<Visibility>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Visibility> _parser = new pb::MessageParser<Visibility>(() => new Visibility());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Visibility> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.VisibilityReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Visibility() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Visibility(Visibility other) : this() {
      rules_ = other.rules_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Visibility Clone() {
      return new Visibility(this);
    }

    /// <summary>Field number for the "rules" field.</summary>
    public const int RulesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Google.Api.VisibilityRule> _repeated_rules_codec
        = pb::FieldCodec.ForMessage(10, global::Google.Api.VisibilityRule.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.VisibilityRule> rules_ = new pbc::RepeatedField<global::Google.Api.VisibilityRule>();
    /// <summary>
    /// A list of visibility rules that apply to individual API elements.
    ///
    /// **NOTE:** All service configuration rules follow "last one wins" order.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.VisibilityRule> Rules {
      get { return rules_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Visibility);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Visibility other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!rules_.Equals(other.rules_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= rules_.GetHashCode();
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
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      rules_.WriteTo(output, _repeated_rules_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      rules_.WriteTo(ref output, _repeated_rules_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += rules_.CalculateSize(_repeated_rules_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Visibility other) {
      if (other == null) {
        return;
      }
      rules_.Add(other.rules_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            rules_.AddEntriesFrom(input, _repeated_rules_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            rules_.AddEntriesFrom(ref input, _repeated_rules_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  /// <summary>
  /// A visibility rule provides visibility configuration for an individual API
  /// element.
  /// </summary>
  public sealed partial class VisibilityRule : pb::IMessage<VisibilityRule>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<VisibilityRule> _parser = new pb::MessageParser<VisibilityRule>(() => new VisibilityRule());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<VisibilityRule> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.VisibilityReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VisibilityRule() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VisibilityRule(VisibilityRule other) : this() {
      selector_ = other.selector_;
      restriction_ = other.restriction_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public VisibilityRule Clone() {
      return new VisibilityRule(this);
    }

    /// <summary>Field number for the "selector" field.</summary>
    public const int SelectorFieldNumber = 1;
    private string selector_ = "";
    /// <summary>
    /// Selects methods, messages, fields, enums, etc. to which this rule applies.
    ///
    /// Refer to [selector][google.api.DocumentationRule.selector] for syntax details.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Selector {
      get { return selector_; }
      set {
        selector_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "restriction" field.</summary>
    public const int RestrictionFieldNumber = 2;
    private string restriction_ = "";
    /// <summary>
    /// A comma-separated list of visibility labels that apply to the `selector`.
    /// Any of the listed labels can be used to grant the visibility.
    ///
    /// If a rule has multiple labels, removing one of the labels but not all of
    /// them can break clients.
    ///
    /// Example:
    ///
    ///     visibility:
    ///       rules:
    ///       - selector: google.calendar.Calendar.EnhancedSearch
    ///         restriction: INTERNAL, PREVIEW
    ///
    /// Removing INTERNAL from this restriction will break clients that rely on
    /// this method and only had access to it through INTERNAL.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Restriction {
      get { return restriction_; }
      set {
        restriction_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as VisibilityRule);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(VisibilityRule other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Selector != other.Selector) return false;
      if (Restriction != other.Restriction) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Selector.Length != 0) hash ^= Selector.GetHashCode();
      if (Restriction.Length != 0) hash ^= Restriction.GetHashCode();
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
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      if (Restriction.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Restriction);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      if (Restriction.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Restriction);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Selector.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Selector);
      }
      if (Restriction.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Restriction);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(VisibilityRule other) {
      if (other == null) {
        return;
      }
      if (other.Selector.Length != 0) {
        Selector = other.Selector;
      }
      if (other.Restriction.Length != 0) {
        Restriction = other.Restriction;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            Restriction = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            Restriction = input.ReadString();
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
