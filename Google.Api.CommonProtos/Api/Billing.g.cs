/*
 * Copyright 2021 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/billing.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/billing.proto</summary>
  public static partial class BillingReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/billing.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BillingReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chhnb29nbGUvYXBpL2JpbGxpbmcucHJvdG8SCmdvb2dsZS5hcGkikwEKB0Jp",
            "bGxpbmcSRQoVY29uc3VtZXJfZGVzdGluYXRpb25zGAggAygLMiYuZ29vZ2xl",
            "LmFwaS5CaWxsaW5nLkJpbGxpbmdEZXN0aW5hdGlvbhpBChJCaWxsaW5nRGVz",
            "dGluYXRpb24SGgoSbW9uaXRvcmVkX3Jlc291cmNlGAEgASgJEg8KB21ldHJp",
            "Y3MYAiADKAlCbgoOY29tLmdvb2dsZS5hcGlCDEJpbGxpbmdQcm90b1ABWkVn",
            "b29nbGUuZ29sYW5nLm9yZy9nZW5wcm90by9nb29nbGVhcGlzL2FwaS9zZXJ2",
            "aWNlY29uZmlnO3NlcnZpY2Vjb25maWeiAgRHQVBJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Billing), global::Google.Api.Billing.Parser, new[]{ "ConsumerDestinations" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Billing.Types.BillingDestination), global::Google.Api.Billing.Types.BillingDestination.Parser, new[]{ "MonitoredResource", "Metrics" }, null, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Billing related configuration of the service.
  ///
  /// The following example shows how to configure monitored resources and metrics
  /// for billing, `consumer_destinations` is the only supported destination and
  /// the monitored resources need at least one label key
  /// `cloud.googleapis.com/location` to indicate the location of the billing
  /// usage, using different monitored resources between monitoring and billing is
  /// recommended so they can be evolved independently:
  ///
  ///     monitored_resources:
  ///     - type: library.googleapis.com/billing_branch
  ///       labels:
  ///       - key: cloud.googleapis.com/location
  ///         description: |
  ///           Predefined label to support billing location restriction.
  ///       - key: city
  ///         description: |
  ///           Custom label to define the city where the library branch is located
  ///           in.
  ///       - key: name
  ///         description: Custom label to define the name of the library branch.
  ///     metrics:
  ///     - name: library.googleapis.com/book/borrowed_count
  ///       metric_kind: DELTA
  ///       value_type: INT64
  ///       unit: "1"
  ///     billing:
  ///       consumer_destinations:
  ///       - monitored_resource: library.googleapis.com/billing_branch
  ///         metrics:
  ///         - library.googleapis.com/book/borrowed_count
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class Billing : pb::IMessage<Billing>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Billing> _parser = new pb::MessageParser<Billing>(() => new Billing());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Billing> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.BillingReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Billing() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Billing(Billing other) : this() {
      consumerDestinations_ = other.consumerDestinations_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Billing Clone() {
      return new Billing(this);
    }

    /// <summary>Field number for the "consumer_destinations" field.</summary>
    public const int ConsumerDestinationsFieldNumber = 8;
    private static readonly pb::FieldCodec<global::Google.Api.Billing.Types.BillingDestination> _repeated_consumerDestinations_codec
        = pb::FieldCodec.ForMessage(66, global::Google.Api.Billing.Types.BillingDestination.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.Billing.Types.BillingDestination> consumerDestinations_ = new pbc::RepeatedField<global::Google.Api.Billing.Types.BillingDestination>();
    /// <summary>
    /// Billing configurations for sending metrics to the consumer project.
    /// There can be multiple consumer destinations per service, each one must have
    /// a different monitored resource type. A metric can be used in at most
    /// one consumer destination.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Google.Api.Billing.Types.BillingDestination> ConsumerDestinations {
      get { return consumerDestinations_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Billing);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Billing other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!consumerDestinations_.Equals(other.consumerDestinations_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= consumerDestinations_.GetHashCode();
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
      consumerDestinations_.WriteTo(output, _repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      consumerDestinations_.WriteTo(ref output, _repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += consumerDestinations_.CalculateSize(_repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Billing other) {
      if (other == null) {
        return;
      }
      consumerDestinations_.Add(other.consumerDestinations_);
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
          case 66: {
            consumerDestinations_.AddEntriesFrom(input, _repeated_consumerDestinations_codec);
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
          case 66: {
            consumerDestinations_.AddEntriesFrom(ref input, _repeated_consumerDestinations_codec);
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the Billing message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Types {
      /// <summary>
      /// Configuration of a specific billing destination (Currently only support
      /// bill against consumer project).
      /// </summary>
      [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
      public sealed partial class BillingDestination : pb::IMessage<BillingDestination>
      #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
          , pb::IBufferMessage
      #endif
      {
        private static readonly pb::MessageParser<BillingDestination> _parser = new pb::MessageParser<BillingDestination>(() => new BillingDestination());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static pb::MessageParser<BillingDestination> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Google.Api.Billing.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public BillingDestination() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public BillingDestination(BillingDestination other) : this() {
          monitoredResource_ = other.monitoredResource_;
          metrics_ = other.metrics_.Clone();
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public BillingDestination Clone() {
          return new BillingDestination(this);
        }

        /// <summary>Field number for the "monitored_resource" field.</summary>
        public const int MonitoredResourceFieldNumber = 1;
        private string monitoredResource_ = "";
        /// <summary>
        /// The monitored resource type. The type must be defined in
        /// [Service.monitored_resources][google.api.Service.monitored_resources]
        /// section.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public string MonitoredResource {
          get { return monitoredResource_; }
          set {
            monitoredResource_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        /// <summary>Field number for the "metrics" field.</summary>
        public const int MetricsFieldNumber = 2;
        private static readonly pb::FieldCodec<string> _repeated_metrics_codec
            = pb::FieldCodec.ForString(18);
        private readonly pbc::RepeatedField<string> metrics_ = new pbc::RepeatedField<string>();
        /// <summary>
        /// Names of the metrics to report to this billing destination.
        /// Each name must be defined in
        /// [Service.metrics][google.api.Service.metrics] section.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public pbc::RepeatedField<string> Metrics {
          get { return metrics_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override bool Equals(object other) {
          return Equals(other as BillingDestination);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public bool Equals(BillingDestination other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (MonitoredResource != other.MonitoredResource) return false;
          if(!metrics_.Equals(other.metrics_)) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override int GetHashCode() {
          int hash = 1;
          if (MonitoredResource.Length != 0) hash ^= MonitoredResource.GetHashCode();
          hash ^= metrics_.GetHashCode();
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
          if (MonitoredResource.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(MonitoredResource);
          }
          metrics_.WriteTo(output, _repeated_metrics_codec);
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        #endif
        }

        #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
          if (MonitoredResource.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(MonitoredResource);
          }
          metrics_.WriteTo(ref output, _repeated_metrics_codec);
          if (_unknownFields != null) {
            _unknownFields.WriteTo(ref output);
          }
        }
        #endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int CalculateSize() {
          int size = 0;
          if (MonitoredResource.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(MonitoredResource);
          }
          size += metrics_.CalculateSize(_repeated_metrics_codec);
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void MergeFrom(BillingDestination other) {
          if (other == null) {
            return;
          }
          if (other.MonitoredResource.Length != 0) {
            MonitoredResource = other.MonitoredResource;
          }
          metrics_.Add(other.metrics_);
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
                MonitoredResource = input.ReadString();
                break;
              }
              case 18: {
                metrics_.AddEntriesFrom(input, _repeated_metrics_codec);
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
                MonitoredResource = input.ReadString();
                break;
              }
              case 18: {
                metrics_.AddEntriesFrom(ref input, _repeated_metrics_codec);
                break;
              }
            }
          }
        }
        #endif

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
