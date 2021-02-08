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
    /// <summary>Settings for <see cref="NodeGroupsClient"/> instances.</summary>
    public sealed partial class NodeGroupsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="NodeGroupsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="NodeGroupsSettings"/>.</returns>
        public static NodeGroupsSettings GetDefault() => new NodeGroupsSettings();

        /// <summary>Constructs a new <see cref="NodeGroupsSettings"/> object with default settings.</summary>
        public NodeGroupsSettings()
        {
        }

        private NodeGroupsSettings(NodeGroupsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AddNodesSettings = existing.AddNodesSettings;
            AggregatedListSettings = existing.AggregatedListSettings;
            DeleteSettings = existing.DeleteSettings;
            DeleteNodesSettings = existing.DeleteNodesSettings;
            GetSettings = existing.GetSettings;
            GetIamPolicySettings = existing.GetIamPolicySettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListNodesSettings = existing.ListNodesSettings;
            PatchSettings = existing.PatchSettings;
            SetIamPolicySettings = existing.SetIamPolicySettings;
            SetNodeTemplateSettings = existing.SetNodeTemplateSettings;
            TestIamPermissionsSettings = existing.TestIamPermissionsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(NodeGroupsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.AddNodes</c>
        ///  and <c>NodeGroupsClient.AddNodesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddNodesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NodeGroupsClient.AggregatedList</c> and <c>NodeGroupsClient.AggregatedListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.Delete</c>
        /// and <c>NodeGroupsClient.DeleteAsync</c>.
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
        /// <c>NodeGroupsClient.DeleteNodes</c> and <c>NodeGroupsClient.DeleteNodesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteNodesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.Get</c>
        /// and <c>NodeGroupsClient.GetAsync</c>.
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
        /// <c>NodeGroupsClient.GetIamPolicy</c> and <c>NodeGroupsClient.GetIamPolicyAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetIamPolicySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.Insert</c>
        /// and <c>NodeGroupsClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.List</c>
        /// and <c>NodeGroupsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.ListNodes</c>
        ///  and <c>NodeGroupsClient.ListNodesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListNodesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NodeGroupsClient.Patch</c>
        /// and <c>NodeGroupsClient.PatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NodeGroupsClient.SetIamPolicy</c> and <c>NodeGroupsClient.SetIamPolicyAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetIamPolicySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NodeGroupsClient.SetNodeTemplate</c> and <c>NodeGroupsClient.SetNodeTemplateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetNodeTemplateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NodeGroupsClient.TestIamPermissions</c> and <c>NodeGroupsClient.TestIamPermissionsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings TestIamPermissionsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="NodeGroupsSettings"/> object.</returns>
        public NodeGroupsSettings Clone() => new NodeGroupsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="NodeGroupsClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class NodeGroupsClientBuilder : gaxgrpc::ClientBuilderBase<NodeGroupsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public NodeGroupsSettings Settings { get; set; }

        partial void InterceptBuild(ref NodeGroupsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<NodeGroupsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override NodeGroupsClient Build()
        {
            NodeGroupsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<NodeGroupsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<NodeGroupsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private NodeGroupsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return NodeGroupsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<NodeGroupsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return NodeGroupsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => NodeGroupsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => NodeGroupsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => NodeGroupsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>NodeGroups client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The NodeGroups API.
    /// </remarks>
    public abstract partial class NodeGroupsClient
    {
        /// <summary>
        /// The default endpoint for the NodeGroups service, which is a host of "compute.googleapis.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default NodeGroups scopes.</summary>
        /// <remarks>
        /// The default NodeGroups scopes are:
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
        /// Asynchronously creates a <see cref="NodeGroupsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="NodeGroupsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="NodeGroupsClient"/>.</returns>
        public static stt::Task<NodeGroupsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new NodeGroupsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="NodeGroupsClient"/> using the default credentials, endpoint and settings.
        /// To specify custom credentials or other settings, use <see cref="NodeGroupsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="NodeGroupsClient"/>.</returns>
        public static NodeGroupsClient Create() => new NodeGroupsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="NodeGroupsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="NodeGroupsSettings"/>.</param>
        /// <returns>The created <see cref="NodeGroupsClient"/>.</returns>
        internal static NodeGroupsClient Create(grpccore::CallInvoker callInvoker, NodeGroupsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            NodeGroups.NodeGroupsClient grpcClient = new NodeGroups.NodeGroupsClient(callInvoker);
            return new NodeGroupsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC NodeGroups client</summary>
        public virtual NodeGroups.NodeGroupsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddNodes(AddNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddNodesAsync(AddNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddNodesAsync(AddNodesNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            AddNodesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource.
        /// </param>
        /// <param name="nodeGroupsAddNodesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddNodes(string project, string zone, string nodeGroup, NodeGroupsAddNodesRequest nodeGroupsAddNodesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddNodes(new AddNodesNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupsAddNodesRequestResource = gax::GaxPreconditions.CheckNotNull(nodeGroupsAddNodesRequestResource, nameof(nodeGroupsAddNodesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource.
        /// </param>
        /// <param name="nodeGroupsAddNodesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddNodesAsync(string project, string zone, string nodeGroup, NodeGroupsAddNodesRequest nodeGroupsAddNodesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddNodesAsync(new AddNodesNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupsAddNodesRequestResource = gax::GaxPreconditions.CheckNotNull(nodeGroupsAddNodesRequestResource, nameof(nodeGroupsAddNodesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource.
        /// </param>
        /// <param name="nodeGroupsAddNodesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddNodesAsync(string project, string zone, string nodeGroup, NodeGroupsAddNodesRequest nodeGroupsAddNodesRequestResource, st::CancellationToken cancellationToken) =>
            AddNodesAsync(project, zone, nodeGroup, nodeGroupsAddNodesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroupAggregatedList AggregatedList(AggregatedListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupAggregatedList> AggregatedListAsync(AggregatedListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupAggregatedList> AggregatedListAsync(AggregatedListNodeGroupsRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroupAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListNodeGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListNodeGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string zone, string nodeGroup, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string nodeGroup, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string nodeGroup, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, zone, nodeGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteNodes(DeleteNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteNodesAsync(DeleteNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteNodesAsync(DeleteNodesNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            DeleteNodesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource whose nodes will be deleted.
        /// </param>
        /// <param name="nodeGroupsDeleteNodesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteNodes(string project, string zone, string nodeGroup, NodeGroupsDeleteNodesRequest nodeGroupsDeleteNodesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DeleteNodes(new DeleteNodesNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupsDeleteNodesRequestResource = gax::GaxPreconditions.CheckNotNull(nodeGroupsDeleteNodesRequestResource, nameof(nodeGroupsDeleteNodesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource whose nodes will be deleted.
        /// </param>
        /// <param name="nodeGroupsDeleteNodesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteNodesAsync(string project, string zone, string nodeGroup, NodeGroupsDeleteNodesRequest nodeGroupsDeleteNodesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DeleteNodesAsync(new DeleteNodesNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupsDeleteNodesRequestResource = gax::GaxPreconditions.CheckNotNull(nodeGroupsDeleteNodesRequestResource, nameof(nodeGroupsDeleteNodesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource whose nodes will be deleted.
        /// </param>
        /// <param name="nodeGroupsDeleteNodesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteNodesAsync(string project, string zone, string nodeGroup, NodeGroupsDeleteNodesRequest nodeGroupsDeleteNodesRequestResource, st::CancellationToken cancellationToken) =>
            DeleteNodesAsync(project, zone, nodeGroup, nodeGroupsDeleteNodesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroup Get(GetNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroup> GetAsync(GetNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroup> GetAsync(GetNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the node group to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroup Get(string project, string zone, string nodeGroup, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the node group to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroup> GetAsync(string project, string zone, string nodeGroup, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the node group to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroup> GetAsync(string project, string zone, string nodeGroup, st::CancellationToken cancellationToken) =>
            GetAsync(project, zone, nodeGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Policy GetIamPolicy(GetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> GetIamPolicyAsync(GetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> GetIamPolicyAsync(GetIamPolicyNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            GetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Policy GetIamPolicy(string project, string zone, string resource, gaxgrpc::CallSettings callSettings = null) =>
            GetIamPolicy(new GetIamPolicyNodeGroupRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> GetIamPolicyAsync(string project, string zone, string resource, gaxgrpc::CallSettings callSettings = null) =>
            GetIamPolicyAsync(new GetIamPolicyNodeGroupRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> GetIamPolicyAsync(string project, string zone, string resource, st::CancellationToken cancellationToken) =>
            GetIamPolicyAsync(project, zone, resource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="initialNodeCount">
        /// Initial count of nodes in the node group.
        /// </param>
        /// <param name="nodeGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string zone, int initialNodeCount, NodeGroup nodeGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertNodeGroupRequest
            {
                InitialNodeCount = initialNodeCount,
                NodeGroupResource = gax::GaxPreconditions.CheckNotNull(nodeGroupResource, nameof(nodeGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="initialNodeCount">
        /// Initial count of nodes in the node group.
        /// </param>
        /// <param name="nodeGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, int initialNodeCount, NodeGroup nodeGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertNodeGroupRequest
            {
                InitialNodeCount = initialNodeCount,
                NodeGroupResource = gax::GaxPreconditions.CheckNotNull(nodeGroupResource, nameof(nodeGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="initialNodeCount">
        /// Initial count of nodes in the node group.
        /// </param>
        /// <param name="nodeGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, int initialNodeCount, NodeGroup nodeGroupResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, zone, initialNodeCount, nodeGroupResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroupList List(ListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupList> ListAsync(ListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupList> ListAsync(ListNodeGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroupList List(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListNodeGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupList> ListAsync(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListNodeGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupList> ListAsync(string project, string zone, st::CancellationToken cancellationToken) =>
            ListAsync(project, zone, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroupsListNodes ListNodes(ListNodesNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupsListNodes> ListNodesAsync(ListNodesNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupsListNodes> ListNodesAsync(ListNodesNodeGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListNodesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource whose nodes you want to list.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NodeGroupsListNodes ListNodes(string project, string zone, string nodeGroup, gaxgrpc::CallSettings callSettings = null) =>
            ListNodes(new ListNodesNodeGroupsRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource whose nodes you want to list.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupsListNodes> ListNodesAsync(string project, string zone, string nodeGroup, gaxgrpc::CallSettings callSettings = null) =>
            ListNodesAsync(new ListNodesNodeGroupsRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource whose nodes you want to list.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NodeGroupsListNodes> ListNodesAsync(string project, string zone, string nodeGroup, st::CancellationToken cancellationToken) =>
            ListNodesAsync(project, zone, nodeGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to update.
        /// </param>
        /// <param name="nodeGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string zone, string nodeGroup, NodeGroup nodeGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupResource = gax::GaxPreconditions.CheckNotNull(nodeGroupResource, nameof(nodeGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to update.
        /// </param>
        /// <param name="nodeGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string zone, string nodeGroup, NodeGroup nodeGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupResource = gax::GaxPreconditions.CheckNotNull(nodeGroupResource, nameof(nodeGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to update.
        /// </param>
        /// <param name="nodeGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string zone, string nodeGroup, NodeGroup nodeGroupResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, zone, nodeGroup, nodeGroupResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Policy SetIamPolicy(SetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> SetIamPolicyAsync(SetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> SetIamPolicyAsync(SetIamPolicyNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            SetIamPolicyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="zoneSetPolicyRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Policy SetIamPolicy(string project, string zone, string resource, ZoneSetPolicyRequest zoneSetPolicyRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetIamPolicy(new SetIamPolicyNodeGroupRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
                ZoneSetPolicyRequestResource = gax::GaxPreconditions.CheckNotNull(zoneSetPolicyRequestResource, nameof(zoneSetPolicyRequestResource)),
            }, callSettings);

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="zoneSetPolicyRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> SetIamPolicyAsync(string project, string zone, string resource, ZoneSetPolicyRequest zoneSetPolicyRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetIamPolicyAsync(new SetIamPolicyNodeGroupRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
                ZoneSetPolicyRequestResource = gax::GaxPreconditions.CheckNotNull(zoneSetPolicyRequestResource, nameof(zoneSetPolicyRequestResource)),
            }, callSettings);

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="zoneSetPolicyRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Policy> SetIamPolicyAsync(string project, string zone, string resource, ZoneSetPolicyRequest zoneSetPolicyRequestResource, st::CancellationToken cancellationToken) =>
            SetIamPolicyAsync(project, zone, resource, zoneSetPolicyRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetNodeTemplate(SetNodeTemplateNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNodeTemplateAsync(SetNodeTemplateNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNodeTemplateAsync(SetNodeTemplateNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            SetNodeTemplateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to update.
        /// </param>
        /// <param name="nodeGroupsSetNodeTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetNodeTemplate(string project, string zone, string nodeGroup, NodeGroupsSetNodeTemplateRequest nodeGroupsSetNodeTemplateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetNodeTemplate(new SetNodeTemplateNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupsSetNodeTemplateRequestResource = gax::GaxPreconditions.CheckNotNull(nodeGroupsSetNodeTemplateRequestResource, nameof(nodeGroupsSetNodeTemplateRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to update.
        /// </param>
        /// <param name="nodeGroupsSetNodeTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNodeTemplateAsync(string project, string zone, string nodeGroup, NodeGroupsSetNodeTemplateRequest nodeGroupsSetNodeTemplateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetNodeTemplateAsync(new SetNodeTemplateNodeGroupRequest
            {
                NodeGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(nodeGroup, nameof(nodeGroup)),
                NodeGroupsSetNodeTemplateRequestResource = gax::GaxPreconditions.CheckNotNull(nodeGroupsSetNodeTemplateRequestResource, nameof(nodeGroupsSetNodeTemplateRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="nodeGroup">
        /// Name of the NodeGroup resource to update.
        /// </param>
        /// <param name="nodeGroupsSetNodeTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNodeTemplateAsync(string project, string zone, string nodeGroup, NodeGroupsSetNodeTemplateRequest nodeGroupsSetNodeTemplateRequestResource, st::CancellationToken cancellationToken) =>
            SetNodeTemplateAsync(project, zone, nodeGroup, nodeGroupsSetNodeTemplateRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TestPermissionsResponse TestIamPermissions(TestIamPermissionsNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsNodeGroupRequest request, st::CancellationToken cancellationToken) =>
            TestIamPermissionsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="testPermissionsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TestPermissionsResponse TestIamPermissions(string project, string zone, string resource, TestPermissionsRequest testPermissionsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            TestIamPermissions(new TestIamPermissionsNodeGroupRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                TestPermissionsRequestResource = gax::GaxPreconditions.CheckNotNull(testPermissionsRequestResource, nameof(testPermissionsRequestResource)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="testPermissionsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(string project, string zone, string resource, TestPermissionsRequest testPermissionsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            TestIamPermissionsAsync(new TestIamPermissionsNodeGroupRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                TestPermissionsRequestResource = gax::GaxPreconditions.CheckNotNull(testPermissionsRequestResource, nameof(testPermissionsRequestResource)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="testPermissionsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(string project, string zone, string resource, TestPermissionsRequest testPermissionsRequestResource, st::CancellationToken cancellationToken) =>
            TestIamPermissionsAsync(project, zone, resource, testPermissionsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>NodeGroups client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The NodeGroups API.
    /// </remarks>
    public sealed partial class NodeGroupsClientImpl : NodeGroupsClient
    {
        private readonly gaxgrpc::ApiCall<AddNodesNodeGroupRequest, Operation> _callAddNodes;

        private readonly gaxgrpc::ApiCall<AggregatedListNodeGroupsRequest, NodeGroupAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<DeleteNodeGroupRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<DeleteNodesNodeGroupRequest, Operation> _callDeleteNodes;

        private readonly gaxgrpc::ApiCall<GetNodeGroupRequest, NodeGroup> _callGet;

        private readonly gaxgrpc::ApiCall<GetIamPolicyNodeGroupRequest, Policy> _callGetIamPolicy;

        private readonly gaxgrpc::ApiCall<InsertNodeGroupRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListNodeGroupsRequest, NodeGroupList> _callList;

        private readonly gaxgrpc::ApiCall<ListNodesNodeGroupsRequest, NodeGroupsListNodes> _callListNodes;

        private readonly gaxgrpc::ApiCall<PatchNodeGroupRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<SetIamPolicyNodeGroupRequest, Policy> _callSetIamPolicy;

        private readonly gaxgrpc::ApiCall<SetNodeTemplateNodeGroupRequest, Operation> _callSetNodeTemplate;

        private readonly gaxgrpc::ApiCall<TestIamPermissionsNodeGroupRequest, TestPermissionsResponse> _callTestIamPermissions;

        /// <summary>
        /// Constructs a client wrapper for the NodeGroups service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="NodeGroupsSettings"/> used within this client.</param>
        public NodeGroupsClientImpl(NodeGroups.NodeGroupsClient grpcClient, NodeGroupsSettings settings)
        {
            GrpcClient = grpcClient;
            NodeGroupsSettings effectiveSettings = settings ?? NodeGroupsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAddNodes = clientHelper.BuildApiCall<AddNodesNodeGroupRequest, Operation>(grpcClient.AddNodesAsync, grpcClient.AddNodes, effectiveSettings.AddNodesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callAddNodes);
            Modify_AddNodesApiCall(ref _callAddNodes);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListNodeGroupsRequest, NodeGroupAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callDelete = clientHelper.BuildApiCall<DeleteNodeGroupRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callDeleteNodes = clientHelper.BuildApiCall<DeleteNodesNodeGroupRequest, Operation>(grpcClient.DeleteNodesAsync, grpcClient.DeleteNodes, effectiveSettings.DeleteNodesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callDeleteNodes);
            Modify_DeleteNodesApiCall(ref _callDeleteNodes);
            _callGet = clientHelper.BuildApiCall<GetNodeGroupRequest, NodeGroup>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callGetIamPolicy = clientHelper.BuildApiCall<GetIamPolicyNodeGroupRequest, Policy>(grpcClient.GetIamPolicyAsync, grpcClient.GetIamPolicy, effectiveSettings.GetIamPolicySettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("resource", request => request.Resource);
            Modify_ApiCall(ref _callGetIamPolicy);
            Modify_GetIamPolicyApiCall(ref _callGetIamPolicy);
            _callInsert = clientHelper.BuildApiCall<InsertNodeGroupRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListNodeGroupsRequest, NodeGroupList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListNodes = clientHelper.BuildApiCall<ListNodesNodeGroupsRequest, NodeGroupsListNodes>(grpcClient.ListNodesAsync, grpcClient.ListNodes, effectiveSettings.ListNodesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callListNodes);
            Modify_ListNodesApiCall(ref _callListNodes);
            _callPatch = clientHelper.BuildApiCall<PatchNodeGroupRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callSetIamPolicy = clientHelper.BuildApiCall<SetIamPolicyNodeGroupRequest, Policy>(grpcClient.SetIamPolicyAsync, grpcClient.SetIamPolicy, effectiveSettings.SetIamPolicySettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("resource", request => request.Resource);
            Modify_ApiCall(ref _callSetIamPolicy);
            Modify_SetIamPolicyApiCall(ref _callSetIamPolicy);
            _callSetNodeTemplate = clientHelper.BuildApiCall<SetNodeTemplateNodeGroupRequest, Operation>(grpcClient.SetNodeTemplateAsync, grpcClient.SetNodeTemplate, effectiveSettings.SetNodeTemplateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("node_group", request => request.NodeGroup);
            Modify_ApiCall(ref _callSetNodeTemplate);
            Modify_SetNodeTemplateApiCall(ref _callSetNodeTemplate);
            _callTestIamPermissions = clientHelper.BuildApiCall<TestIamPermissionsNodeGroupRequest, TestPermissionsResponse>(grpcClient.TestIamPermissionsAsync, grpcClient.TestIamPermissions, effectiveSettings.TestIamPermissionsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("resource", request => request.Resource);
            Modify_ApiCall(ref _callTestIamPermissions);
            Modify_TestIamPermissionsApiCall(ref _callTestIamPermissions);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AddNodesApiCall(ref gaxgrpc::ApiCall<AddNodesNodeGroupRequest, Operation> call);

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListNodeGroupsRequest, NodeGroupAggregatedList> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteNodeGroupRequest, Operation> call);

        partial void Modify_DeleteNodesApiCall(ref gaxgrpc::ApiCall<DeleteNodesNodeGroupRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetNodeGroupRequest, NodeGroup> call);

        partial void Modify_GetIamPolicyApiCall(ref gaxgrpc::ApiCall<GetIamPolicyNodeGroupRequest, Policy> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertNodeGroupRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListNodeGroupsRequest, NodeGroupList> call);

        partial void Modify_ListNodesApiCall(ref gaxgrpc::ApiCall<ListNodesNodeGroupsRequest, NodeGroupsListNodes> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchNodeGroupRequest, Operation> call);

        partial void Modify_SetIamPolicyApiCall(ref gaxgrpc::ApiCall<SetIamPolicyNodeGroupRequest, Policy> call);

        partial void Modify_SetNodeTemplateApiCall(ref gaxgrpc::ApiCall<SetNodeTemplateNodeGroupRequest, Operation> call);

        partial void Modify_TestIamPermissionsApiCall(ref gaxgrpc::ApiCall<TestIamPermissionsNodeGroupRequest, TestPermissionsResponse> call);

        partial void OnConstruction(NodeGroups.NodeGroupsClient grpcClient, NodeGroupsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC NodeGroups client</summary>
        public override NodeGroups.NodeGroupsClient GrpcClient { get; }

        partial void Modify_AddNodesNodeGroupRequest(ref AddNodesNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AggregatedListNodeGroupsRequest(ref AggregatedListNodeGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteNodeGroupRequest(ref DeleteNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteNodesNodeGroupRequest(ref DeleteNodesNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetNodeGroupRequest(ref GetNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetIamPolicyNodeGroupRequest(ref GetIamPolicyNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertNodeGroupRequest(ref InsertNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNodeGroupsRequest(ref ListNodeGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNodesNodeGroupsRequest(ref ListNodesNodeGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchNodeGroupRequest(ref PatchNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetIamPolicyNodeGroupRequest(ref SetIamPolicyNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetNodeTemplateNodeGroupRequest(ref SetNodeTemplateNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_TestIamPermissionsNodeGroupRequest(ref TestIamPermissionsNodeGroupRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddNodes(AddNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddNodesNodeGroupRequest(ref request, ref callSettings);
            return _callAddNodes.Sync(request, callSettings);
        }

        /// <summary>
        /// Adds specified number of nodes to the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddNodesAsync(AddNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddNodesNodeGroupRequest(ref request, ref callSettings);
            return _callAddNodes.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeGroupAggregatedList AggregatedList(AggregatedListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListNodeGroupsRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of node groups. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeGroupAggregatedList> AggregatedListAsync(AggregatedListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListNodeGroupsRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNodeGroupRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified NodeGroup resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNodeGroupRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DeleteNodes(DeleteNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNodesNodeGroupRequest(ref request, ref callSettings);
            return _callDeleteNodes.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes specified nodes from the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteNodesAsync(DeleteNodesNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNodesNodeGroupRequest(ref request, ref callSettings);
            return _callDeleteNodes.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeGroup Get(GetNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNodeGroupRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified NodeGroup. Get a list of available NodeGroups by making a list() request. Note: the "nodes" field should not be used. Use nodeGroups.listNodes instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeGroup> GetAsync(GetNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNodeGroupRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Policy GetIamPolicy(GetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetIamPolicyNodeGroupRequest(ref request, ref callSettings);
            return _callGetIamPolicy.Sync(request, callSettings);
        }

        /// <summary>
        /// Gets the access control policy for a resource. May be empty if no such policy or resource exists.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Policy> GetIamPolicyAsync(GetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetIamPolicyNodeGroupRequest(ref request, ref callSettings);
            return _callGetIamPolicy.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertNodeGroupRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a NodeGroup resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertNodeGroupRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeGroupList List(ListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNodeGroupsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of node groups available to the specified project. Note: use nodeGroups.listNodes for more details about each group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeGroupList> ListAsync(ListNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNodeGroupsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NodeGroupsListNodes ListNodes(ListNodesNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNodesNodeGroupsRequest(ref request, ref callSettings);
            return _callListNodes.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists nodes in the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NodeGroupsListNodes> ListNodesAsync(ListNodesNodeGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNodesNodeGroupsRequest(ref request, ref callSettings);
            return _callListNodes.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchNodeGroupRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchNodeGroupRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Policy SetIamPolicy(SetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetIamPolicyNodeGroupRequest(ref request, ref callSettings);
            return _callSetIamPolicy.Sync(request, callSettings);
        }

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any existing policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Policy> SetIamPolicyAsync(SetIamPolicyNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetIamPolicyNodeGroupRequest(ref request, ref callSettings);
            return _callSetIamPolicy.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetNodeTemplate(SetNodeTemplateNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetNodeTemplateNodeGroupRequest(ref request, ref callSettings);
            return _callSetNodeTemplate.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the node template of the node group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetNodeTemplateAsync(SetNodeTemplateNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetNodeTemplateNodeGroupRequest(ref request, ref callSettings);
            return _callSetNodeTemplate.Async(request, callSettings);
        }

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TestPermissionsResponse TestIamPermissions(TestIamPermissionsNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_TestIamPermissionsNodeGroupRequest(ref request, ref callSettings);
            return _callTestIamPermissions.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsNodeGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_TestIamPermissionsNodeGroupRequest(ref request, ref callSettings);
            return _callTestIamPermissions.Async(request, callSettings);
        }
    }
}
