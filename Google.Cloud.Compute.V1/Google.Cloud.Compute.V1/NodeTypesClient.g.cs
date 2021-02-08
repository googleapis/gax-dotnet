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
    /// <summary>Settings for <see cref="NodeTypesClient"/> instances.</summary>
    public sealed partial class NodeTypesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="NodeTypesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="NodeTypesSettings"/>.</returns>
        public static NodeTypesSettings GetDefault() => new NodeTypesSettings();

        /// <summary>Constructs a new <see cref="NodeTypesSettings"/> object with default settings.</summary>
        public NodeTypesSettings()
        {
        }

        private NodeTypesSettings(NodeTypesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AggregatedListSettings = existing.AggregatedListSettings;
            GetSettings = existing.GetSettings;
            ListSettings = existing.ListSettings;
            OnCopy(existing);
        }

        partial void OnCopy(NodeTypesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NodeTypesClient.AggregatedList</c> and <c>NodeTypesClient.AggregatedListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeTypesClient.Get</c> and
        /// <c>NodeTypesClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeTypesClient.List</c>
        /// and <c>NodeTypesClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="NodeTypesSettings"/> object.</returns>
        public NodeTypesSettings Clone() => new NodeTypesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="NodeTypesClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class NodeTypesClientBuilder : gaxgrpc::ClientBuilderBase<NodeTypesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public NodeTypesSettings Settings { get; set; }

        partial void InterceptBuild(ref NodeTypesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<NodeTypesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override NodeTypesClient Build()
        {
            NodeTypesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<NodeTypesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<NodeTypesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private NodeTypesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return NodeTypesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<NodeTypesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return NodeTypesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => NodeTypesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => NodeTypesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => NodeTypesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>NodeTypes client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The NodeTypes API.
    /// </remarks>
    public abstract partial class NodeTypesClient
    {
        /// <summary>
        /// The default endpoint for the NodeTypes service, which is a host of "compute.googleapis.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default NodeTypes scopes.</summary>
        /// <remarks>
        /// The default NodeTypes scopes are:
        /// <list type="bullet">
        /// <item><description>https://www.googleapis.com/auth/compute.readonly</description></item>
        /// <item><description>https://www.googleapis.com/auth/compute</description></item>
        /// <item><description>https://www.googleapis.com/auth/cloud-platform</description></item>
        /// </list>
        /// </remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[]
        {
            "https://www.googleapis.com/auth/compute.readonly",
            "https://www.googleapis.com/auth/compute",
            "https://www.googleapis.com/auth/cloud-platform",
        });

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(DefaultScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="NodeTypesClient"/> using the default credentials, endpoint and settings.
        /// To specify custom credentials or other settings, use <see cref="NodeTypesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="NodeTypesClient"/>.</returns>
        public static stt::Task<NodeTypesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new NodeTypesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="NodeTypesClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="NodeTypesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="NodeTypesClient"/>.</returns>
        public static NodeTypesClient Create() => new NodeTypesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="NodeTypesClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="NodeTypesSettings"/>.</param>
        /// <returns>The created <see cref="NodeTypesClient"/>.</returns>
        internal static NodeTypesClient Create(grpccore::CallInvoker callInvoker, NodeTypesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            NodeTypes.NodeTypesClient grpcClient = new NodeTypes.NodeTypesClient(callInvoker);
            return new NodeTypesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC NodeTypes client</summary>
        public virtual NodeTypes.NodeTypesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeTypeAggregatedList AggregatedList(AggregatedListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeAggregatedList> AggregatedListAsync(AggregatedListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeAggregatedList> AggregatedListAsync(AggregatedListNodeTypesRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeTypeAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListNodeTypesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListNodeTypesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeType Get(GetNodeTypeRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeType> GetAsync(GetNodeTypeRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeType> GetAsync(GetNodeTypeRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeType">
        /// Name of the node type to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeType Get(string project, string zone, string nodeType, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetNodeTypeRequest
            {
                NodeType = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeType, nameof(nodeType)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeType">
        /// Name of the node type to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeType> GetAsync(string project, string zone, string nodeType, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetNodeTypeRequest
            {
                NodeType = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeType, nameof(nodeType)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeType">
        /// Name of the node type to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeType> GetAsync(string project, string zone, string nodeType, st::CancellationToken cancellationToken) =>
            GetAsync(project, zone, nodeType, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeTypeList List(ListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeList> ListAsync(ListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeList> ListAsync(ListNodeTypesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeTypeList List(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListNodeTypesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeList> ListAsync(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListNodeTypesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeTypeList> ListAsync(string project, string zone, st::CancellationToken cancellationToken) =>
            ListAsync(project, zone, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>NodeTypes client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The NodeTypes API.
    /// </remarks>
    public sealed partial class NodeTypesClientImpl : NodeTypesClient
    {
        private readonly gaxgrpc::ApiCall<AggregatedListNodeTypesRequest, NodeTypeAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<GetNodeTypeRequest, NodeType> _callGet;

        private readonly gaxgrpc::ApiCall<ListNodeTypesRequest, NodeTypeList> _callList;

        /// <summary>
        /// Constructs a client wrapper for the NodeTypes service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="NodeTypesSettings"/> used within this client.</param>
        public NodeTypesClientImpl(NodeTypes.NodeTypesClient grpcClient, NodeTypesSettings settings)
        {
            GrpcClient = grpcClient;
            NodeTypesSettings effectiveSettings = settings ?? NodeTypesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListNodeTypesRequest, NodeTypeAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callGet = clientHelper.BuildApiCall<GetNodeTypeRequest, NodeType>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_type", request => request.NodeType);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callList = clientHelper.BuildApiCall<ListNodeTypesRequest, NodeTypeList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListNodeTypesRequest, NodeTypeAggregatedList> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetNodeTypeRequest, NodeType> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListNodeTypesRequest, NodeTypeList> call);

        partial void OnConstruction(NodeTypes.NodeTypesClient grpcClient, NodeTypesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC NodeTypes client</summary>
        public override NodeTypes.NodeTypesClient GrpcClient { get; }

        partial void Modify_AggregatedListNodeTypesRequest(ref AggregatedListNodeTypesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetNodeTypeRequest(ref GetNodeTypeRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNodeTypesRequest(ref ListNodeTypesRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeTypeAggregatedList AggregatedList(AggregatedListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListNodeTypesRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of node types.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeTypeAggregatedList> AggregatedListAsync(AggregatedListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListNodeTypesRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeType Get(GetNodeTypeRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNodeTypeRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified node type. Gets a list of available node types by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeType> GetAsync(GetNodeTypeRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNodeTypeRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeTypeList List(ListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNodeTypesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of node types available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeTypeList> ListAsync(ListNodeTypesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNodeTypesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }
    }
}
