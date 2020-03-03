/*
 * Copyright 2020 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/api/annotations.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Api {

  /// <summary>Holder for reflection information generated from google/api/annotations.proto</summary>
  public static partial class AnnotationsReflection {

    #region Descriptor
    /// <summary>File descriptor for google/api/annotations.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AnnotationsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chxnb29nbGUvYXBpL2Fubm90YXRpb25zLnByb3RvEgpnb29nbGUuYXBpGhVn",
            "b29nbGUvYXBpL2h0dHAucHJvdG8aIGdvb2dsZS9wcm90b2J1Zi9kZXNjcmlw",
            "dG9yLnByb3RvOkUKBGh0dHASHi5nb29nbGUucHJvdG9idWYuTWV0aG9kT3B0",
            "aW9ucxiwyrwiIAEoCzIULmdvb2dsZS5hcGkuSHR0cFJ1bGVCbgoOY29tLmdv",
            "b2dsZS5hcGlCEEFubm90YXRpb25zUHJvdG9QAVpBZ29vZ2xlLmdvbGFuZy5v",
            "cmcvZ2VucHJvdG8vZ29vZ2xlYXBpcy9hcGkvYW5ub3RhdGlvbnM7YW5ub3Rh",
            "dGlvbnOiAgRHQVBJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.HttpReflection.Descriptor, global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pb::Extension[] { AnnotationsExtensions.Http }, null));
    }
    #endregion

  }
  /// <summary>Holder for extension identifiers generated from the top level of google/api/annotations.proto</summary>
  public static partial class AnnotationsExtensions {
    /// <summary>
    /// See `HttpRule`.
    /// </summary>
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.MethodOptions, global::Google.Api.HttpRule> Http =
      new pb::Extension<global::Google.Protobuf.Reflection.MethodOptions, global::Google.Api.HttpRule>(72295728, pb::FieldCodec.ForMessage(578365826, global::Google.Api.HttpRule.Parser));
  }

}

#endregion Designer generated code
