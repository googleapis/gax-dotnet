/*
 * Copyright 2021 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/system_parameter.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/system_parameter.proto</summary>
  public static partial class SystemParameterReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/system_parameter.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SystemParameterReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiFnb29nbGUvYXBpL3N5c3RlbV9wYXJhbWV0ZXIucHJvdG8SCmdvb2dsZS5h",
            "cGkiQgoQU3lzdGVtUGFyYW1ldGVycxIuCgVydWxlcxgBIAMoCzIfLmdvb2ds",
            "ZS5hcGkuU3lzdGVtUGFyYW1ldGVyUnVsZSJYChNTeXN0ZW1QYXJhbWV0ZXJS",
            "dWxlEhAKCHNlbGVjdG9yGAEgASgJEi8KCnBhcmFtZXRlcnMYAiADKAsyGy5n",
            "b29nbGUuYXBpLlN5c3RlbVBhcmFtZXRlciJRCg9TeXN0ZW1QYXJhbWV0ZXIS",
            "DAoEbmFtZRgBIAEoCRITCgtodHRwX2hlYWRlchgCIAEoCRIbChN1cmxfcXVl",
            "cnlfcGFyYW1ldGVyGAMgASgJQnYKDmNvbS5nb29nbGUuYXBpQhRTeXN0ZW1Q",
            "YXJhbWV0ZXJQcm90b1ABWkVnb29nbGUuZ29sYW5nLm9yZy9nZW5wcm90by9n",
            "b29nbGVhcGlzL2FwaS9zZXJ2aWNlY29uZmlnO3NlcnZpY2Vjb25maWeiAgRH",
            "QVBJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.SystemParameters), global::Google.Api.SystemParameters.Parser, new[]{ "Rules" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.SystemParameterRule), global::Google.Api.SystemParameterRule.Parser, new[]{ "Selector", "Parameters" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.SystemParameter), global::Google.Api.SystemParameter.Parser, new[]{ "Name", "HttpHeader", "UrlQueryParameter" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// ### System parameter configuration
  ///
  /// A system parameter is a special kind of parameter defined by the API
  /// system, not by an individual API. It is typically mapped to an HTTP header
  /// and/or a URL query parameter. This configuration specifies which methods
  /// change the names of the system parameters.
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class SystemParameters : pb::IMessage<SystemParameters>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SystemParameters> _parser = new pb::MessageParser<SystemParameters>(() => new SystemParameters());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SystemParameters> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.SystemParameterReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameters() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameters(SystemParameters other) : this() {
      rules_ = other.rules_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameters Clone() {
      return new SystemParameters(this);
    }

    /// <summary>Field number for the "rules" field.</summary>
    public const int RulesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Google.Api.SystemParameterRule> _repeated_rules_codec
        = pb::FieldCodec.ForMessage(10, global::Google.Api.SystemParameterRule.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.SystemParameterRule> rules_ = new pbc::RepeatedField<global::Google.Api.SystemParameterRule>();
    /// <summary>
    /// Define system parameters.
    ///
    /// The parameters defined here will override the default parameters
    /// implemented by the system. If this field is missing from the service
    /// config, default system parameters will be used. Default system parameters
    /// and names is implementation-dependent.
    ///
    /// Example: define api key for all methods
    ///
    ///     system_parameters
    ///       rules:
    ///         - selector: "*"
    ///           parameters:
    ///             - name: api_key
    ///               url_query_parameter: api_key
    ///
    /// Example: define 2 api key names for a specific method.
    ///
    ///     system_parameters
    ///       rules:
    ///         - selector: "/ListShelves"
    ///           parameters:
    ///             - name: api_key
    ///               http_header: Api-Key1
    ///             - name: api_key
    ///               http_header: Api-Key2
    ///
    /// **NOTE:** All service configuration rules follow "last one wins" order.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Google.Api.SystemParameterRule> Rules {
      get { return rules_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as SystemParameters);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SystemParameters other) {
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
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= rules_.GetHashCode();
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
      rules_.WriteTo(output, _repeated_rules_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      rules_.WriteTo(ref output, _repeated_rules_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += rules_.CalculateSize(_repeated_rules_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SystemParameters other) {
      if (other == null) {
        return;
      }
      rules_.Add(other.rules_);
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
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
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
  /// Define a system parameter rule mapping system parameter definitions to
  /// methods.
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class SystemParameterRule : pb::IMessage<SystemParameterRule>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SystemParameterRule> _parser = new pb::MessageParser<SystemParameterRule>(() => new SystemParameterRule());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SystemParameterRule> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.SystemParameterReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameterRule() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameterRule(SystemParameterRule other) : this() {
      selector_ = other.selector_;
      parameters_ = other.parameters_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameterRule Clone() {
      return new SystemParameterRule(this);
    }

    /// <summary>Field number for the "selector" field.</summary>
    public const int SelectorFieldNumber = 1;
    private string selector_ = "";
    /// <summary>
    /// Selects the methods to which this rule applies. Use '*' to indicate all
    /// methods in all APIs.
    ///
    /// Refer to [selector][google.api.DocumentationRule.selector] for syntax
    /// details.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Selector {
      get { return selector_; }
      set {
        selector_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "parameters" field.</summary>
    public const int ParametersFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Google.Api.SystemParameter> _repeated_parameters_codec
        = pb::FieldCodec.ForMessage(18, global::Google.Api.SystemParameter.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.SystemParameter> parameters_ = new pbc::RepeatedField<global::Google.Api.SystemParameter>();
    /// <summary>
    /// Define parameters. Multiple names may be defined for a parameter.
    /// For a given method call, only one of them should be used. If multiple
    /// names are used the behavior is implementation-dependent.
    /// If none of the specified names are present the behavior is
    /// parameter-dependent.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Google.Api.SystemParameter> Parameters {
      get { return parameters_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as SystemParameterRule);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SystemParameterRule other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Selector != other.Selector) return false;
      if(!parameters_.Equals(other.parameters_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Selector.Length != 0) hash ^= Selector.GetHashCode();
      hash ^= parameters_.GetHashCode();
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
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      parameters_.WriteTo(output, _repeated_parameters_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      parameters_.WriteTo(ref output, _repeated_parameters_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Selector.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Selector);
      }
      size += parameters_.CalculateSize(_repeated_parameters_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SystemParameterRule other) {
      if (other == null) {
        return;
      }
      if (other.Selector.Length != 0) {
        Selector = other.Selector;
      }
      parameters_.Add(other.parameters_);
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
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            parameters_.AddEntriesFrom(input, _repeated_parameters_codec);
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
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            parameters_.AddEntriesFrom(ref input, _repeated_parameters_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  /// <summary>
  /// Define a parameter's name and location. The parameter may be passed as either
  /// an HTTP header or a URL query parameter, and if both are passed the behavior
  /// is implementation-dependent.
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class SystemParameter : pb::IMessage<SystemParameter>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SystemParameter> _parser = new pb::MessageParser<SystemParameter>(() => new SystemParameter());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SystemParameter> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.SystemParameterReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameter() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameter(SystemParameter other) : this() {
      name_ = other.name_;
      httpHeader_ = other.httpHeader_;
      urlQueryParameter_ = other.urlQueryParameter_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SystemParameter Clone() {
      return new SystemParameter(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    /// <summary>
    /// Define the name of the parameter, such as "api_key" . It is case sensitive.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "http_header" field.</summary>
    public const int HttpHeaderFieldNumber = 2;
    private string httpHeader_ = "";
    /// <summary>
    /// Define the HTTP header name to use for the parameter. It is case
    /// insensitive.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string HttpHeader {
      get { return httpHeader_; }
      set {
        httpHeader_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "url_query_parameter" field.</summary>
    public const int UrlQueryParameterFieldNumber = 3;
    private string urlQueryParameter_ = "";
    /// <summary>
    /// Define the URL query parameter name to use for the parameter. It is case
    /// sensitive.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UrlQueryParameter {
      get { return urlQueryParameter_; }
      set {
        urlQueryParameter_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as SystemParameter);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SystemParameter other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (HttpHeader != other.HttpHeader) return false;
      if (UrlQueryParameter != other.UrlQueryParameter) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (HttpHeader.Length != 0) hash ^= HttpHeader.GetHashCode();
      if (UrlQueryParameter.Length != 0) hash ^= UrlQueryParameter.GetHashCode();
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
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (HttpHeader.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(HttpHeader);
      }
      if (UrlQueryParameter.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(UrlQueryParameter);
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
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (HttpHeader.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(HttpHeader);
      }
      if (UrlQueryParameter.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(UrlQueryParameter);
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
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (HttpHeader.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HttpHeader);
      }
      if (UrlQueryParameter.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UrlQueryParameter);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SystemParameter other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.HttpHeader.Length != 0) {
        HttpHeader = other.HttpHeader;
      }
      if (other.UrlQueryParameter.Length != 0) {
        UrlQueryParameter = other.UrlQueryParameter;
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
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            HttpHeader = input.ReadString();
            break;
          }
          case 26: {
            UrlQueryParameter = input.ReadString();
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
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            HttpHeader = input.ReadString();
            break;
          }
          case 26: {
            UrlQueryParameter = input.ReadString();
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
