// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: test_service.proto
// </auto-generated>
// Original file comments:
//
// Copyright 2016 Google Inc. All Rights Reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file or at
// https://developers.google.com/open-source/licenses/bsd
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Google.Api.Gax.Grpc.IntegrationTests {
  public static partial class TestService
  {
    static readonly string __ServiceName = "google.api.gax.grpc.integration_tests.TestService";

    static readonly grpc::Marshaller<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest> __Marshaller_google_api_gax_grpc_integration_tests_SimpleRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse> __Marshaller_google_api_gax_grpc_integration_tests_SimpleResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest, global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse> __Method_DoSimple = new grpc::Method<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest, global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DoSimple",
        __Marshaller_google_api_gax_grpc_integration_tests_SimpleRequest,
        __Marshaller_google_api_gax_grpc_integration_tests_SimpleResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Google.Api.Gax.Grpc.IntegrationTests.TestServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of TestService</summary>
    [grpc::BindServiceMethod(typeof(TestService), "BindService")]
    public abstract partial class TestServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse> DoSimple(global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for TestService</summary>
    public partial class TestServiceClient : grpc::ClientBase<TestServiceClient>
    {
      /// <summary>Creates a new client for TestService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public TestServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for TestService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public TestServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected TestServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected TestServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse DoSimple(global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DoSimple(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse DoSimple(global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DoSimple, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse> DoSimpleAsync(global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DoSimpleAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse> DoSimpleAsync(global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DoSimple, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override TestServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new TestServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(TestServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_DoSimple, serviceImpl.DoSimple).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, TestServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_DoSimple, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Api.Gax.Grpc.IntegrationTests.SimpleRequest, global::Google.Api.Gax.Grpc.IntegrationTests.SimpleResponse>(serviceImpl.DoSimple));
    }

  }
}
#endregion
