/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/monitoring.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/monitoring.proto</summary>
  public static partial class MonitoringReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/monitoring.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MonitoringReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chtnb29nbGUvYXBpL21vbml0b3JpbmcucHJvdG8SCmdvb2dsZS5hcGki7AEK",
            "Ck1vbml0b3JpbmcSSwoVcHJvZHVjZXJfZGVzdGluYXRpb25zGAEgAygLMiwu",
            "Z29vZ2xlLmFwaS5Nb25pdG9yaW5nLk1vbml0b3JpbmdEZXN0aW5hdGlvbhJL",
            "ChVjb25zdW1lcl9kZXN0aW5hdGlvbnMYAiADKAsyLC5nb29nbGUuYXBpLk1v",
            "bml0b3JpbmcuTW9uaXRvcmluZ0Rlc3RpbmF0aW9uGkQKFU1vbml0b3JpbmdE",
            "ZXN0aW5hdGlvbhIaChJtb25pdG9yZWRfcmVzb3VyY2UYASABKAkSDwoHbWV0",
            "cmljcxgCIAMoCUJxCg5jb20uZ29vZ2xlLmFwaUIPTW9uaXRvcmluZ1Byb3Rv",
            "UAFaRWdvb2dsZS5nb2xhbmcub3JnL2dlbnByb3RvL2dvb2dsZWFwaXMvYXBp",
            "L3NlcnZpY2Vjb25maWc7c2VydmljZWNvbmZpZ6ICBEdBUEliBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Monitoring), global::Google.Api.Monitoring.Parser, new[]{ "ProducerDestinations", "ConsumerDestinations" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Google.Api.Monitoring.Types.MonitoringDestination), global::Google.Api.Monitoring.Types.MonitoringDestination.Parser, new[]{ "MonitoredResource", "Metrics" }, null, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Monitoring configuration of the service.
  ///
  /// The example below shows how to configure monitored resources and metrics
  /// for monitoring. In the example, a monitored resource and two metrics are
  /// defined. The `library.googleapis.com/book/returned_count` metric is sent
  /// to both producer and consumer projects, whereas the
  /// `library.googleapis.com/book/overdue_count` metric is only sent to the
  /// consumer project.
  ///
  ///     monitored_resources:
  ///     - type: library.googleapis.com/branch
  ///       labels:
  ///       - key: /city
  ///         description: The city where the library branch is located in.
  ///       - key: /name
  ///         description: The name of the branch.
  ///     metrics:
  ///     - name: library.googleapis.com/book/returned_count
  ///       metric_kind: DELTA
  ///       value_type: INT64
  ///       labels:
  ///       - key: /customer_id
  ///     - name: library.googleapis.com/book/overdue_count
  ///       metric_kind: GAUGE
  ///       value_type: INT64
  ///       labels:
  ///       - key: /customer_id
  ///     monitoring:
  ///       producer_destinations:
  ///       - monitored_resource: library.googleapis.com/branch
  ///         metrics:
  ///         - library.googleapis.com/book/returned_count
  ///       consumer_destinations:
  ///       - monitored_resource: library.googleapis.com/branch
  ///         metrics:
  ///         - library.googleapis.com/book/returned_count
  ///         - library.googleapis.com/book/overdue_count
  /// </summary>
  public sealed partial class Monitoring : pb::IMessage<Monitoring> {
    private static readonly pb::MessageParser<Monitoring> _parser = new pb::MessageParser<Monitoring>(() => new Monitoring());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Monitoring> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Api.MonitoringReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Monitoring() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Monitoring(Monitoring other) : this() {
      producerDestinations_ = other.producerDestinations_.Clone();
      consumerDestinations_ = other.consumerDestinations_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Monitoring Clone() {
      return new Monitoring(this);
    }

    /// <summary>Field number for the "producer_destinations" field.</summary>
    public const int ProducerDestinationsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Google.Api.Monitoring.Types.MonitoringDestination> _repeated_producerDestinations_codec
        = pb::FieldCodec.ForMessage(10, global::Google.Api.Monitoring.Types.MonitoringDestination.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.Monitoring.Types.MonitoringDestination> producerDestinations_ = new pbc::RepeatedField<global::Google.Api.Monitoring.Types.MonitoringDestination>();
    /// <summary>
    /// Monitoring configurations for sending metrics to the producer project.
    /// There can be multiple producer destinations. A monitored resouce type may
    /// appear in multiple monitoring destinations if different aggregations are
    /// needed for different sets of metrics associated with that monitored
    /// resource type. A monitored resource and metric pair may only be used once
    /// in the Monitoring configuration.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.Monitoring.Types.MonitoringDestination> ProducerDestinations {
      get { return producerDestinations_; }
    }

    /// <summary>Field number for the "consumer_destinations" field.</summary>
    public const int ConsumerDestinationsFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Google.Api.Monitoring.Types.MonitoringDestination> _repeated_consumerDestinations_codec
        = pb::FieldCodec.ForMessage(18, global::Google.Api.Monitoring.Types.MonitoringDestination.Parser);
    private readonly pbc::RepeatedField<global::Google.Api.Monitoring.Types.MonitoringDestination> consumerDestinations_ = new pbc::RepeatedField<global::Google.Api.Monitoring.Types.MonitoringDestination>();
    /// <summary>
    /// Monitoring configurations for sending metrics to the consumer project.
    /// There can be multiple consumer destinations. A monitored resouce type may
    /// appear in multiple monitoring destinations if different aggregations are
    /// needed for different sets of metrics associated with that monitored
    /// resource type. A monitored resource and metric pair may only be used once
    /// in the Monitoring configuration.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Google.Api.Monitoring.Types.MonitoringDestination> ConsumerDestinations {
      get { return consumerDestinations_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Monitoring);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Monitoring other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!producerDestinations_.Equals(other.producerDestinations_)) return false;
      if(!consumerDestinations_.Equals(other.consumerDestinations_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= producerDestinations_.GetHashCode();
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
      producerDestinations_.WriteTo(output, _repeated_producerDestinations_codec);
      consumerDestinations_.WriteTo(output, _repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += producerDestinations_.CalculateSize(_repeated_producerDestinations_codec);
      size += consumerDestinations_.CalculateSize(_repeated_consumerDestinations_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Monitoring other) {
      if (other == null) {
        return;
      }
      producerDestinations_.Add(other.producerDestinations_);
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
          case 10: {
            producerDestinations_.AddEntriesFrom(input, _repeated_producerDestinations_codec);
            break;
          }
          case 18: {
            consumerDestinations_.AddEntriesFrom(input, _repeated_consumerDestinations_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the Monitoring message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      /// <summary>
      /// Configuration of a specific monitoring destination (the producer project
      /// or the consumer project).
      /// </summary>
      public sealed partial class MonitoringDestination : pb::IMessage<MonitoringDestination> {
        private static readonly pb::MessageParser<MonitoringDestination> _parser = new pb::MessageParser<MonitoringDestination>(() => new MonitoringDestination());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<MonitoringDestination> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Google.Api.Monitoring.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MonitoringDestination() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MonitoringDestination(MonitoringDestination other) : this() {
          monitoredResource_ = other.monitoredResource_;
          metrics_ = other.metrics_.Clone();
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MonitoringDestination Clone() {
          return new MonitoringDestination(this);
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
        /// Types of the metrics to report to this monitoring destination.
        /// Each type must be defined in [Service.metrics][google.api.Service.metrics] section.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<string> Metrics {
          get { return metrics_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as MonitoringDestination);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(MonitoringDestination other) {
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
        public void MergeFrom(MonitoringDestination other) {
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
