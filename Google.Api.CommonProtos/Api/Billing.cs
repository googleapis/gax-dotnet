/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/billing.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
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
            "Chhnb29nbGUvYXBpL2JpbGxpbmcucHJvdG8SCmdvb2dsZS5hcGkaF2dvb2ds",
            "ZS9hcGkvbWV0cmljLnByb3RvIpMBCgdCaWxsaW5nEkUKFWNvbnN1bWVyX2Rl",
            "c3RpbmF0aW9ucxgIIAMoCzImLmdvb2dsZS5hcGkuQmlsbGluZy5CaWxsaW5n",
            "RGVzdGluYXRpb24aQQoSQmlsbGluZ0Rlc3RpbmF0aW9uEhoKEm1vbml0b3Jl",
            "ZF9yZXNvdXJjZRgBIAEoCRIPCgdtZXRyaWNzGAIgAygJQm4KDmNvbS5nb29n",
            "bGUuYXBpQgxCaWxsaW5nUHJvdG9QAVpFZ29vZ2xlLmdvbGFuZy5vcmcvZ2Vu",
            "cHJvdG8vZ29vZ2xlYXBpcy9hcGkvc2VydmljZWNvbmZpZztzZXJ2aWNlY29u",
            "ZmlnogIER0FQSWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.MetricReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Billing), global::Google.Api.Billing.Parser, new[]{ "ConsumerDestinations" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Billing.Types.BillingDestination), global::Google.Api.Billing.Types.BillingDestination.Parser, new[]{ "MonitoredResource", "Metrics" }, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Billing related configuration of the service.
  ///
  /// The following example shows how to configure monitored resources and metrics
  /// for billing:
  ///
  ///     monitored_resources:
  ///     - type: library.googleapis.com/branch
  ///       labels:
  ///       - key: /city
  ///         description: The city where the library branch is located in.
  ///       - key: /name
  ///         description: The name of the branch.
  ///     metrics:
  ///     - name: library.googleapis.com/book/borrowed_count
  ///       metric_kind: DELTA
  ///       value_type: INT64
  ///     billing:
  ///       consumer_destinations:
  ///       - monitored_resource: library.googleapis.com/branch
  ///         metrics:
  ///         - library.googleapis.com/book/borrowed_count
  /// </summary>
  public sealed partial class Billing : pb::IMessage<Billing> {
    private static readonly pb::MessageParser<Billing> _parser = new pb::MessageParser<Billing>(() => new Billing());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Billing> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.BillingReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Billing() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Billing(Billing other) : this() {
      consumerDestinations_ = other.consumerDestinations_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
    public pbc::RepeatedField<global::Google.Api.Billing.Types.BillingDestination> ConsumerDestinations {
      get { return consumerDestinations_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Billing);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
    public override int GetHashCode() {
      int hash = 1;
      hash ^= consumerDestinations_.GetHashCode();
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
      consumerDestinations_.WriteTo(output, _repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += consumerDestinations_.CalculateSize(_repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Billing other) {
      if (other == null) {
        return;
      }
      consumerDestinations_.Add(other.consumerDestinations_);
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
            consumerDestinations_.AddEntriesFrom(input, _repeated_consumerDestinations_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the Billing message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      /// <summary>
      /// Configuration of a specific billing destination (Currently only support
      /// bill against consumer project).
      /// </summary>
      public sealed partial class BillingDestination : pb::IMessage<BillingDestination> {
        private static readonly pb::MessageParser<BillingDestination> _parser = new pb::MessageParser<BillingDestination>(() => new BillingDestination());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<BillingDestination> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Google.Api.Billing.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public BillingDestination() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public BillingDestination(BillingDestination other) : this() {
          monitoredResource_ = other.monitoredResource_;
          metrics_ = other.metrics_.Clone();
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public BillingDestination Clone() {
          return new BillingDestination(this);
        }

        /// <summary>Field number for the "monitored_resource" field.</summary>
        public const int MonitoredResourceFieldNumber = 1;
        private string monitoredResource_ = "";
        /// <summary>
        /// The monitored resource type. The type must be defined in
        /// [Service.monitored_resources][google.api.Service.monitored_resources] section.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
        /// Each name must be defined in [Service.metrics][google.api.Service.metrics] section.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<string> Metrics {
          get { return metrics_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as BillingDestination);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (MonitoredResource.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(MonitoredResource);
          }
          metrics_.WriteTo(output, _repeated_metrics_codec);
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
        public void MergeFrom(pb::CodedInputStream input) {
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
        }

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
