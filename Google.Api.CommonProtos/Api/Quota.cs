/*
 * Copyright 2020 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/quota.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/quota.proto</summary>
  public static partial class QuotaReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/quota.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static QuotaReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZnb29nbGUvYXBpL3F1b3RhLnByb3RvEgpnb29nbGUuYXBpIl0KBVF1b3Rh",
            "EiYKBmxpbWl0cxgDIAMoCzIWLmdvb2dsZS5hcGkuUXVvdGFMaW1pdBIsCgxt",
            "ZXRyaWNfcnVsZXMYBCADKAsyFi5nb29nbGUuYXBpLk1ldHJpY1J1bGUikQEK",
            "Ck1ldHJpY1J1bGUSEAoIc2VsZWN0b3IYASABKAkSPQoMbWV0cmljX2Nvc3Rz",
            "GAIgAygLMicuZ29vZ2xlLmFwaS5NZXRyaWNSdWxlLk1ldHJpY0Nvc3RzRW50",
            "cnkaMgoQTWV0cmljQ29zdHNFbnRyeRILCgNrZXkYASABKAkSDQoFdmFsdWUY",
            "AiABKAM6AjgBIpUCCgpRdW90YUxpbWl0EgwKBG5hbWUYBiABKAkSEwoLZGVz",
            "Y3JpcHRpb24YAiABKAkSFQoNZGVmYXVsdF9saW1pdBgDIAEoAxIRCgltYXhf",
            "bGltaXQYBCABKAMSEQoJZnJlZV90aWVyGAcgASgDEhAKCGR1cmF0aW9uGAUg",
            "ASgJEg4KBm1ldHJpYxgIIAEoCRIMCgR1bml0GAkgASgJEjIKBnZhbHVlcxgK",
            "IAMoCzIiLmdvb2dsZS5hcGkuUXVvdGFMaW1pdC5WYWx1ZXNFbnRyeRIUCgxk",
            "aXNwbGF5X25hbWUYDCABKAkaLQoLVmFsdWVzRW50cnkSCwoDa2V5GAEgASgJ",
            "Eg0KBXZhbHVlGAIgASgDOgI4AUJsCg5jb20uZ29vZ2xlLmFwaUIKUXVvdGFQ",
            "cm90b1ABWkVnb29nbGUuZ29sYW5nLm9yZy9nZW5wcm90by9nb29nbGVhcGlz",
            "L2FwaS9zZXJ2aWNlY29uZmlnO3NlcnZpY2Vjb25maWeiAgRHQVBJYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Quota), global::Google.Api.Quota.Parser, new[]{ "Limits", "MetricRules" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.MetricRule), global::Google.Api.MetricRule.Parser, new[]{ "Selector", "MetricCosts" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.QuotaLimit), global::Google.Api.QuotaLimit.Parser, new[]{ "Name", "Description", "DefaultLimit", "MaxLimit", "FreeTier", "Duration", "Metric", "Unit", "Values", "DisplayName" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Quota configuration helps to achieve fairness and budgeting in service
  /// usage.
  ///
  /// The metric based quota configuration works this way:
  /// - The service configuration defines a set of metrics.
  /// - For API calls, the quota.metric_rules maps methods to metrics with
  ///   corresponding costs.
  /// - The quota.limits defines limits on the metrics, which will be used for
  ///   quota checks at runtime.
  ///
  /// An example quota configuration in yaml format:
  ///
  ///    quota:
  ///      limits:
  ///
  ///      - name: apiWriteQpsPerProject
  ///        metric: library.googleapis.com/write_calls
  ///        unit: "1/min/{project}"  # rate limit for consumer projects
  ///        values:
  ///          STANDARD: 10000
  ///
  ///      # The metric rules bind all methods to the read_calls metric,
  ///      # except for the UpdateBook and DeleteBook methods. These two methods
  ///      # are mapped to the write_calls metric, with the UpdateBook method
  ///      # consuming at twice rate as the DeleteBook method.
  ///      metric_rules:
  ///      - selector: "*"
  ///        metric_costs:
  ///          library.googleapis.com/read_calls: 1
  ///      - selector: google.example.library.v1.LibraryService.UpdateBook
  ///        metric_costs:
  ///          library.googleapis.com/write_calls: 2
  ///      - selector: google.example.library.v1.LibraryService.DeleteBook
  ///        metric_costs:
  ///          library.googleapis.com/write_calls: 1
  ///
  ///  Corresponding Metric definition:
  ///
  ///      metrics:
  ///      - name: library.googleapis.com/read_calls
  ///        display_name: Read requests
  ///        metric_kind: DELTA
  ///        value_type: INT64
  ///
  ///      - name: library.googleapis.com/write_calls
  ///        display_name: Write requests
  ///        metric_kind: DELTA
  ///        value_type: INT64
  /// </summary>
  public sealed partial class Quota : pb::IMessage<Quota> {
    private static readonly pb::MessageParser<Quota> _parser = new pb::MessageParser<Quota>(() => new Quota());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Quota> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.QuotaReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Quota() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Quota(Quota other) : this() {
      limits_ = other.limits_.Clone();
      metricRules_ = other.metricRules_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Quota Clone() {
      return new Quota(this);
    }

    /// <summary>Field number for the "limits" field.</summary>
    public const int LimitsFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Google.Api.QuotaLimit> _repeated_limits_codec
        = pb::FieldCodec.ForMessage(26, global::Google.Api.QuotaLimit.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.QuotaLimit> limits_ = new pbc::RepeatedField<global::Google.Api.QuotaLimit>();
    /// <summary>
    /// List of `QuotaLimit` definitions for the service.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.QuotaLimit> Limits {
      get { return limits_; }
    }

    /// <summary>Field number for the "metric_rules" field.</summary>
    public const int MetricRulesFieldNumber = 4;
    private static readonly pb::FieldCodec<global::Google.Api.MetricRule> _repeated_metricRules_codec
        = pb::FieldCodec.ForMessage(34, global::Google.Api.MetricRule.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.MetricRule> metricRules_ = new pbc::RepeatedField<global::Google.Api.MetricRule>();
    /// <summary>
    /// List of `MetricRule` definitions, each one mapping a selected method to one
    /// or more metrics.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.MetricRule> MetricRules {
      get { return metricRules_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Quota);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Quota other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!limits_.Equals(other.limits_)) return false;
      if(!metricRules_.Equals(other.metricRules_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= limits_.GetHashCode();
      hash ^= metricRules_.GetHashCode();
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
      limits_.WriteTo(output, _repeated_limits_codec);
      metricRules_.WriteTo(output, _repeated_metricRules_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += limits_.CalculateSize(_repeated_limits_codec);
      size += metricRules_.CalculateSize(_repeated_metricRules_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Quota other) {
      if (other == null) {
        return;
      }
      limits_.Add(other.limits_);
      metricRules_.Add(other.metricRules_);
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
          case 26: {
            limits_.AddEntriesFrom(input, _repeated_limits_codec);
            break;
          }
          case 34: {
            metricRules_.AddEntriesFrom(input, _repeated_metricRules_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Bind API methods to metrics. Binding a method to a metric causes that
  /// metric's configured quota behaviors to apply to the method call.
  /// </summary>
  public sealed partial class MetricRule : pb::IMessage<MetricRule> {
    private static readonly pb::MessageParser<MetricRule> _parser = new pb::MessageParser<MetricRule>(() => new MetricRule());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MetricRule> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.QuotaReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MetricRule() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MetricRule(MetricRule other) : this() {
      selector_ = other.selector_;
      metricCosts_ = other.metricCosts_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MetricRule Clone() {
      return new MetricRule(this);
    }

    /// <summary>Field number for the "selector" field.</summary>
    public const int SelectorFieldNumber = 1;
    private string selector_ = "";
    /// <summary>
    /// Selects the methods to which this rule applies.
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

    /// <summary>Field number for the "metric_costs" field.</summary>
    public const int MetricCostsFieldNumber = 2;
    private static readonly pbc::MapField<string, long>.Codec _map_metricCosts_codec
        = new pbc::MapField<string, long>.Codec(pb::FieldCodec.ForString(10, ""), pb::FieldCodec.ForInt64(16, 0L), 18);
    private readonly pbc::MapField<string, long> metricCosts_ = new pbc::MapField<string, long>();
    /// <summary>
    /// Metrics to update when the selected methods are called, and the associated
    /// cost applied to each metric.
    ///
    /// The key of the map is the metric name, and the values are the amount
    /// increased for the metric against which the quota limits are defined.
    /// The value must not be negative.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, long> MetricCosts {
      get { return metricCosts_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MetricRule);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MetricRule other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Selector != other.Selector) return false;
      if (!MetricCosts.Equals(other.MetricCosts)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Selector.Length != 0) hash ^= Selector.GetHashCode();
      hash ^= MetricCosts.GetHashCode();
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
      if (Selector.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Selector);
      }
      metricCosts_.WriteTo(output, _map_metricCosts_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Selector.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Selector);
      }
      size += metricCosts_.CalculateSize(_map_metricCosts_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MetricRule other) {
      if (other == null) {
        return;
      }
      if (other.Selector.Length != 0) {
        Selector = other.Selector;
      }
      metricCosts_.Add(other.metricCosts_);
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
          case 10: {
            Selector = input.ReadString();
            break;
          }
          case 18: {
            metricCosts_.AddEntriesFrom(input, _map_metricCosts_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// `QuotaLimit` defines a specific limit that applies over a specified duration
  /// for a limit type. There can be at most one limit for a duration and limit
  /// type combination defined within a `QuotaGroup`.
  /// </summary>
  public sealed partial class QuotaLimit : pb::IMessage<QuotaLimit> {
    private static readonly pb::MessageParser<QuotaLimit> _parser = new pb::MessageParser<QuotaLimit>(() => new QuotaLimit());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<QuotaLimit> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.QuotaReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QuotaLimit() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QuotaLimit(QuotaLimit other) : this() {
      name_ = other.name_;
      description_ = other.description_;
      defaultLimit_ = other.defaultLimit_;
      maxLimit_ = other.maxLimit_;
      freeTier_ = other.freeTier_;
      duration_ = other.duration_;
      metric_ = other.metric_;
      unit_ = other.unit_;
      values_ = other.values_.Clone();
      displayName_ = other.displayName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QuotaLimit Clone() {
      return new QuotaLimit(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 6;
    private string name_ = "";
    /// <summary>
    /// Name of the quota limit.
    ///
    /// The name must be provided, and it must be unique within the service. The
    /// name can only include alphanumeric characters as well as '-'.
    ///
    /// The maximum length of the limit name is 64 characters.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "description" field.</summary>
    public const int DescriptionFieldNumber = 2;
    private string description_ = "";
    /// <summary>
    /// Optional. User-visible, extended description for this quota limit.
    /// Should be used only when more context is needed to understand this limit
    /// than provided by the limit's display name (see: `display_name`).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Description {
      get { return description_; }
      set {
        description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "default_limit" field.</summary>
    public const int DefaultLimitFieldNumber = 3;
    private long defaultLimit_;
    /// <summary>
    /// Default number of tokens that can be consumed during the specified
    /// duration. This is the number of tokens assigned when a client
    /// application developer activates the service for his/her project.
    ///
    /// Specifying a value of 0 will block all requests. This can be used if you
    /// are provisioning quota to selected consumers and blocking others.
    /// Similarly, a value of -1 will indicate an unlimited quota. No other
    /// negative values are allowed.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long DefaultLimit {
      get { return defaultLimit_; }
      set {
        defaultLimit_ = value;
      }
    }

    /// <summary>Field number for the "max_limit" field.</summary>
    public const int MaxLimitFieldNumber = 4;
    private long maxLimit_;
    /// <summary>
    /// Maximum number of tokens that can be consumed during the specified
    /// duration. Client application developers can override the default limit up
    /// to this maximum. If specified, this value cannot be set to a value less
    /// than the default limit. If not specified, it is set to the default limit.
    ///
    /// To allow clients to apply overrides with no upper bound, set this to -1,
    /// indicating unlimited maximum quota.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long MaxLimit {
      get { return maxLimit_; }
      set {
        maxLimit_ = value;
      }
    }

    /// <summary>Field number for the "free_tier" field.</summary>
    public const int FreeTierFieldNumber = 7;
    private long freeTier_;
    /// <summary>
    /// Free tier value displayed in the Developers Console for this limit.
    /// The free tier is the number of tokens that will be subtracted from the
    /// billed amount when billing is enabled.
    /// This field can only be set on a limit with duration "1d", in a billable
    /// group; it is invalid on any other limit. If this field is not set, it
    /// defaults to 0, indicating that there is no free tier for this service.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long FreeTier {
      get { return freeTier_; }
      set {
        freeTier_ = value;
      }
    }

    /// <summary>Field number for the "duration" field.</summary>
    public const int DurationFieldNumber = 5;
    private string duration_ = "";
    /// <summary>
    /// Duration of this limit in textual notation. Example: "100s", "24h", "1d".
    /// For duration longer than a day, only multiple of days is supported. We
    /// support only "100s" and "1d" for now. Additional support will be added in
    /// the future. "0" indicates indefinite duration.
    ///
    /// Used by group-based quotas only.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Duration {
      get { return duration_; }
      set {
        duration_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "metric" field.</summary>
    public const int MetricFieldNumber = 8;
    private string metric_ = "";
    /// <summary>
    /// The name of the metric this quota limit applies to. The quota limits with
    /// the same metric will be checked together during runtime. The metric must be
    /// defined within the service config.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Metric {
      get { return metric_; }
      set {
        metric_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "unit" field.</summary>
    public const int UnitFieldNumber = 9;
    private string unit_ = "";
    /// <summary>
    /// Specify the unit of the quota limit. It uses the same syntax as
    /// [Metric.unit][]. The supported unit kinds are determined by the quota
    /// backend system.
    ///
    /// Here are some examples:
    /// * "1/min/{project}" for quota per minute per project.
    ///
    /// Note: the order of unit components is insignificant.
    /// The "1" at the beginning is required to follow the metric unit syntax.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Unit {
      get { return unit_; }
      set {
        unit_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "values" field.</summary>
    public const int ValuesFieldNumber = 10;
    private static readonly pbc::MapField<string, long>.Codec _map_values_codec
        = new pbc::MapField<string, long>.Codec(pb::FieldCodec.ForString(10, ""), pb::FieldCodec.ForInt64(16, 0L), 82);
    private readonly pbc::MapField<string, long> values_ = new pbc::MapField<string, long>();
    /// <summary>
    /// Tiered limit values. You must specify this as a key:value pair, with an
    /// integer value that is the maximum number of requests allowed for the
    /// specified unit. Currently only STANDARD is supported.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, long> Values {
      get { return values_; }
    }

    /// <summary>Field number for the "display_name" field.</summary>
    public const int DisplayNameFieldNumber = 12;
    private string displayName_ = "";
    /// <summary>
    /// User-visible display name for this limit.
    /// Optional. If not set, the UI will provide a default display name based on
    /// the quota configuration. This field can be used to override the default
    /// display name generated from the configuration.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DisplayName {
      get { return displayName_; }
      set {
        displayName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as QuotaLimit);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(QuotaLimit other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Description != other.Description) return false;
      if (DefaultLimit != other.DefaultLimit) return false;
      if (MaxLimit != other.MaxLimit) return false;
      if (FreeTier != other.FreeTier) return false;
      if (Duration != other.Duration) return false;
      if (Metric != other.Metric) return false;
      if (Unit != other.Unit) return false;
      if (!Values.Equals(other.Values)) return false;
      if (DisplayName != other.DisplayName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Description.Length != 0) hash ^= Description.GetHashCode();
      if (DefaultLimit != 0L) hash ^= DefaultLimit.GetHashCode();
      if (MaxLimit != 0L) hash ^= MaxLimit.GetHashCode();
      if (FreeTier != 0L) hash ^= FreeTier.GetHashCode();
      if (Duration.Length != 0) hash ^= Duration.GetHashCode();
      if (Metric.Length != 0) hash ^= Metric.GetHashCode();
      if (Unit.Length != 0) hash ^= Unit.GetHashCode();
      hash ^= Values.GetHashCode();
      if (DisplayName.Length != 0) hash ^= DisplayName.GetHashCode();
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
      if (Description.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Description);
      }
      if (DefaultLimit != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(DefaultLimit);
      }
      if (MaxLimit != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(MaxLimit);
      }
      if (Duration.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Duration);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Name);
      }
      if (FreeTier != 0L) {
        output.WriteRawTag(56);
        output.WriteInt64(FreeTier);
      }
      if (Metric.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Metric);
      }
      if (Unit.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(Unit);
      }
      values_.WriteTo(output, _map_values_codec);
      if (DisplayName.Length != 0) {
        output.WriteRawTag(98);
        output.WriteString(DisplayName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Description.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
      }
      if (DefaultLimit != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(DefaultLimit);
      }
      if (MaxLimit != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(MaxLimit);
      }
      if (FreeTier != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(FreeTier);
      }
      if (Duration.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Duration);
      }
      if (Metric.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Metric);
      }
      if (Unit.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Unit);
      }
      size += values_.CalculateSize(_map_values_codec);
      if (DisplayName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DisplayName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(QuotaLimit other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Description.Length != 0) {
        Description = other.Description;
      }
      if (other.DefaultLimit != 0L) {
        DefaultLimit = other.DefaultLimit;
      }
      if (other.MaxLimit != 0L) {
        MaxLimit = other.MaxLimit;
      }
      if (other.FreeTier != 0L) {
        FreeTier = other.FreeTier;
      }
      if (other.Duration.Length != 0) {
        Duration = other.Duration;
      }
      if (other.Metric.Length != 0) {
        Metric = other.Metric;
      }
      if (other.Unit.Length != 0) {
        Unit = other.Unit;
      }
      values_.Add(other.values_);
      if (other.DisplayName.Length != 0) {
        DisplayName = other.DisplayName;
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
          case 18: {
            Description = input.ReadString();
            break;
          }
          case 24: {
            DefaultLimit = input.ReadInt64();
            break;
          }
          case 32: {
            MaxLimit = input.ReadInt64();
            break;
          }
          case 42: {
            Duration = input.ReadString();
            break;
          }
          case 50: {
            Name = input.ReadString();
            break;
          }
          case 56: {
            FreeTier = input.ReadInt64();
            break;
          }
          case 66: {
            Metric = input.ReadString();
            break;
          }
          case 74: {
            Unit = input.ReadString();
            break;
          }
          case 82: {
            values_.AddEntriesFrom(input, _map_values_codec);
            break;
          }
          case 98: {
            DisplayName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
