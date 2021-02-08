// Copyright 2021 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;

using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Google.Cloud.Compute.V1
{
    /// <summary>Settings for <see cref="GlobalOrganizationOperationsClient"/> instances.</summary>
    public sealed partial class GlobalOrganizationOperationsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="GlobalOrganizationOperationsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="GlobalOrganizationOperationsSettings"/>.</returns>
        public static GlobalOrganizationOperationsSettings GetDefault() => new GlobalOrganizationOperationsSettings();

        /// <summary>
        /// Constructs a new <see cref="GlobalOrganizationOperationsSettings"/> object with default settings.
        /// </summary>
        public GlobalOrganizationOperationsSettings()
        {
        }

        private GlobalOrganizationOperationsSettings(GlobalOrganizationOperationsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            ListSettings = existing.ListSettings;
            OnCopy(existing);
        }

        partial void OnCopy(GlobalOrganizationOperationsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>GlobalOrganizationOperationsClient.Delete</c> and <c>GlobalOrganizationOperationsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>GlobalOrganizationOperationsClient.Get</c> and <c>GlobalOrganizationOperationsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>GlobalOrganizationOperationsClient.List</c> and <c>GlobalOrganizationOperationsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="GlobalOrganizationOperationsSettings"/> object.</returns>
        public GlobalOrganizationOperationsSettings Clone() => new GlobalOrganizationOperationsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="GlobalOrganizationOperationsClient"/> to provide simple configuration of
    /// credentials, endpoint etc.
    /// </summary>
    public sealed partial class GlobalOrganizationOperationsClientBuilder : gaxgrpc::ClientBuilderBase<GlobalOrganizationOperationsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public GlobalOrganizationOperationsSettings Settings { get; set; }

        partial void InterceptBuild(ref GlobalOrganizationOperationsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<GlobalOrganizationOperationsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override GlobalOrganizationOperationsClient Build()
        {
            GlobalOrganizationOperationsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<GlobalOrganizationOperationsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<GlobalOrganizationOperationsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private GlobalOrganizationOperationsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return GlobalOrganizationOperationsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<GlobalOrganizationOperationsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return GlobalOrganizationOperationsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => GlobalOrganizationOperationsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => GlobalOrganizationOperationsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => GlobalOrganizationOperationsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>GlobalOrganizationOperations client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The GlobalOrganizationOperations API.
    /// </remarks>
    public abstract partial class GlobalOrganizationOperationsClient
    {
        /// <summary>
        /// The default endpoint for the GlobalOrganizationOperations service, which is a host of
        /// "compute.googleapis.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default GlobalOrganizationOperations scopes.</summary>
        /// <remarks>
        /// The default GlobalOrganizationOperations scopes are:
        /// <list type="bullet">
        /// <item><description>https://www.googleapis.com/auth/compute</description></item>
        /// <item><description>https://www.googleapis.com/auth/cloud-platform</description></item>
        /// </list>
        /// </remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[]
        {
            "https://www.googleapis.com/auth/compute",
            "https://www.googleapis.com/auth/cloud-platform",
        });

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="GlobalOrganizationOperationsClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="GlobalOrganizationOperationsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="GlobalOrganizationOperationsClient"/>.</returns>
        public static stt::Task<GlobalOrganizationOperationsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new GlobalOrganizationOperationsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="GlobalOrganizationOperationsClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="GlobalOrganizationOperationsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="GlobalOrganizationOperationsClient"/>.</returns>
        public static GlobalOrganizationOperationsClient Create() => new GlobalOrganizationOperationsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="GlobalOrganizationOperationsClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="GlobalOrganizationOperationsSettings"/>.</param>
        /// <returns>The created <see cref="GlobalOrganizationOperationsClient"/>.</returns>
        internal static GlobalOrganizationOperationsClient Create(grpccore::CallInvoker callInvoker, GlobalOrganizationOperationsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            GlobalOrganizationOperations.GlobalOrganizationOperationsClient grpcClient = new GlobalOrganizationOperations.GlobalOrganizationOperationsClient(callInvoker);
            return new GlobalOrganizationOperationsClientImpl(grpcClient, settings);
        }

        /// <summary>
        /// Shuts down any channels automatically created by <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/>. Channels which weren't automatically created are not
        /// affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/> will create new channels, which could in turn be shut down
        /// by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => ChannelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC GlobalOrganizationOperations client</summary>
        public virtual GlobalOrganizationOperations.GlobalOrganizationOperationsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual DeleteGlobalOrganizationOperationResponse Delete(DeleteGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteGlobalOrganizationOperationResponse> DeleteAsync(DeleteGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteGlobalOrganizationOperationResponse> DeleteAsync(DeleteGlobalOrganizationOperationRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual DeleteGlobalOrganizationOperationResponse Delete(string operation, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteGlobalOrganizationOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteGlobalOrganizationOperationResponse> DeleteAsync(string operation, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteGlobalOrganizationOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteGlobalOrganizationOperationResponse> DeleteAsync(string operation, st::CancellationToken cancellationToken) =>
            DeleteAsync(operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Get(GetGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(GetGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(GetGlobalOrganizationOperationRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Get(string operation, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetGlobalOrganizationOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
            }, callSettings);

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(string operation, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetGlobalOrganizationOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
            }, callSettings);

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(string operation, st::CancellationToken cancellationToken) =>
            GetAsync(operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual OperationList List(ListGlobalOrganizationOperationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(ListGlobalOrganizationOperationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(ListGlobalOrganizationOperationsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual OperationList List(gaxgrpc::CallSettings callSettings = null) =>
            List(new ListGlobalOrganizationOperationsRequest { }, callSettings);

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListGlobalOrganizationOperationsRequest { }, callSettings);

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(st::CancellationToken cancellationToken) =>
            ListAsync(gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>GlobalOrganizationOperations client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The GlobalOrganizationOperations API.
    /// </remarks>
    public sealed partial class GlobalOrganizationOperationsClientImpl : GlobalOrganizationOperationsClient
    {
        private readonly gaxgrpc::ApiCall<DeleteGlobalOrganizationOperationRequest, DeleteGlobalOrganizationOperationResponse> _callDelete;

        private readonly gaxgrpc::ApiCall<GetGlobalOrganizationOperationRequest, Operation> _callGet;

        private readonly gaxgrpc::ApiCall<ListGlobalOrganizationOperationsRequest, OperationList> _callList;

        /// <summary>
        /// Constructs a client wrapper for the GlobalOrganizationOperations service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="GlobalOrganizationOperationsSettings"/> used within this client.
        /// </param>
        public GlobalOrganizationOperationsClientImpl(GlobalOrganizationOperations.GlobalOrganizationOperationsClient grpcClient, GlobalOrganizationOperationsSettings settings)
        {
            GrpcClient = grpcClient;
            GlobalOrganizationOperationsSettings effectiveSettings = settings ?? GlobalOrganizationOperationsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteGlobalOrganizationOperationRequest, DeleteGlobalOrganizationOperationResponse>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetGlobalOrganizationOperationRequest, Operation>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callList = clientHelper.BuildApiCall<ListGlobalOrganizationOperationsRequest, OperationList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteGlobalOrganizationOperationRequest, DeleteGlobalOrganizationOperationResponse> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetGlobalOrganizationOperationRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListGlobalOrganizationOperationsRequest, OperationList> call);

        partial void OnConstruction(GlobalOrganizationOperations.GlobalOrganizationOperationsClient grpcClient, GlobalOrganizationOperationsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC GlobalOrganizationOperations client</summary>
        public override GlobalOrganizationOperations.GlobalOrganizationOperationsClient GrpcClient { get; }

        partial void Modify_DeleteGlobalOrganizationOperationRequest(ref DeleteGlobalOrganizationOperationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetGlobalOrganizationOperationRequest(ref GetGlobalOrganizationOperationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListGlobalOrganizationOperationsRequest(ref ListGlobalOrganizationOperationsRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override DeleteGlobalOrganizationOperationResponse Delete(DeleteGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteGlobalOrganizationOperationRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<DeleteGlobalOrganizationOperationResponse> DeleteAsync(DeleteGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteGlobalOrganizationOperationRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Get(GetGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetGlobalOrganizationOperationRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the specified Operations resource. Gets a list of operations by making a `list()` request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> GetAsync(GetGlobalOrganizationOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetGlobalOrganizationOperationRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override OperationList List(ListGlobalOrganizationOperationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListGlobalOrganizationOperationsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified organization.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<OperationList> ListAsync(ListGlobalOrganizationOperationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListGlobalOrganizationOperationsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }
    }
}
