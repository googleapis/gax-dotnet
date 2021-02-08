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
    /// <summary>Settings for <see cref="NetworkEndpointGroupsClient"/> instances.</summary>
    public sealed partial class NetworkEndpointGroupsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="NetworkEndpointGroupsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="NetworkEndpointGroupsSettings"/>.</returns>
        public static NetworkEndpointGroupsSettings GetDefault() => new NetworkEndpointGroupsSettings();

        /// <summary>
        /// Constructs a new <see cref="NetworkEndpointGroupsSettings"/> object with default settings.
        /// </summary>
        public NetworkEndpointGroupsSettings()
        {
        }

        private NetworkEndpointGroupsSettings(NetworkEndpointGroupsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AggregatedListSettings = existing.AggregatedListSettings;
            AttachNetworkEndpointsSettings = existing.AttachNetworkEndpointsSettings;
            DeleteSettings = existing.DeleteSettings;
            DetachNetworkEndpointsSettings = existing.DetachNetworkEndpointsSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListNetworkEndpointsSettings = existing.ListNetworkEndpointsSettings;
            TestIamPermissionsSettings = existing.TestIamPermissionsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(NetworkEndpointGroupsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.AggregatedList</c> and <c>NetworkEndpointGroupsClient.AggregatedListAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.AttachNetworkEndpoints</c> and
        /// <c>NetworkEndpointGroupsClient.AttachNetworkEndpointsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AttachNetworkEndpointsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.Delete</c> and <c>NetworkEndpointGroupsClient.DeleteAsync</c>.
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
        /// <c>NetworkEndpointGroupsClient.DetachNetworkEndpoints</c> and
        /// <c>NetworkEndpointGroupsClient.DetachNetworkEndpointsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DetachNetworkEndpointsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.Get</c> and <c>NetworkEndpointGroupsClient.GetAsync</c>.
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
        /// <c>NetworkEndpointGroupsClient.Insert</c> and <c>NetworkEndpointGroupsClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.List</c> and <c>NetworkEndpointGroupsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.ListNetworkEndpoints</c> and
        /// <c>NetworkEndpointGroupsClient.ListNetworkEndpointsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListNetworkEndpointsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworkEndpointGroupsClient.TestIamPermissions</c> and
        /// <c>NetworkEndpointGroupsClient.TestIamPermissionsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings TestIamPermissionsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="NetworkEndpointGroupsSettings"/> object.</returns>
        public NetworkEndpointGroupsSettings Clone() => new NetworkEndpointGroupsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="NetworkEndpointGroupsClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class NetworkEndpointGroupsClientBuilder : gaxgrpc::ClientBuilderBase<NetworkEndpointGroupsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public NetworkEndpointGroupsSettings Settings { get; set; }

        partial void InterceptBuild(ref NetworkEndpointGroupsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<NetworkEndpointGroupsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override NetworkEndpointGroupsClient Build()
        {
            NetworkEndpointGroupsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<NetworkEndpointGroupsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<NetworkEndpointGroupsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private NetworkEndpointGroupsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return NetworkEndpointGroupsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<NetworkEndpointGroupsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return NetworkEndpointGroupsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => NetworkEndpointGroupsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => NetworkEndpointGroupsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => NetworkEndpointGroupsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>NetworkEndpointGroups client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The NetworkEndpointGroups API.
    /// </remarks>
    public abstract partial class NetworkEndpointGroupsClient
    {
        /// <summary>
        /// The default endpoint for the NetworkEndpointGroups service, which is a host of "compute.googleapis.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default NetworkEndpointGroups scopes.</summary>
        /// <remarks>
        /// The default NetworkEndpointGroups scopes are:
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
        /// Asynchronously creates a <see cref="NetworkEndpointGroupsClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="NetworkEndpointGroupsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="NetworkEndpointGroupsClient"/>.</returns>
        public static stt::Task<NetworkEndpointGroupsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new NetworkEndpointGroupsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="NetworkEndpointGroupsClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="NetworkEndpointGroupsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="NetworkEndpointGroupsClient"/>.</returns>
        public static NetworkEndpointGroupsClient Create() => new NetworkEndpointGroupsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="NetworkEndpointGroupsClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="NetworkEndpointGroupsSettings"/>.</param>
        /// <returns>The created <see cref="NetworkEndpointGroupsClient"/>.</returns>
        internal static NetworkEndpointGroupsClient Create(grpccore::CallInvoker callInvoker, NetworkEndpointGroupsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            NetworkEndpointGroups.NetworkEndpointGroupsClient grpcClient = new NetworkEndpointGroups.NetworkEndpointGroupsClient(callInvoker);
            return new NetworkEndpointGroupsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC NetworkEndpointGroups client</summary>
        public virtual NetworkEndpointGroups.NetworkEndpointGroupsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupAggregatedList AggregatedList(AggregatedListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupAggregatedList> AggregatedListAsync(AggregatedListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupAggregatedList> AggregatedListAsync(AggregatedListNetworkEndpointGroupsRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListNetworkEndpointGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListNetworkEndpointGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AttachNetworkEndpoints(AttachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(AttachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(AttachNetworkEndpointsNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            AttachNetworkEndpointsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are attaching network endpoints to. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsAttachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AttachNetworkEndpoints(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsAttachEndpointsRequest networkEndpointGroupsAttachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AttachNetworkEndpoints(new AttachNetworkEndpointsNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                NetworkEndpointGroupsAttachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupsAttachEndpointsRequestResource, nameof(networkEndpointGroupsAttachEndpointsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are attaching network endpoints to. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsAttachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsAttachEndpointsRequest networkEndpointGroupsAttachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AttachNetworkEndpointsAsync(new AttachNetworkEndpointsNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                NetworkEndpointGroupsAttachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupsAttachEndpointsRequestResource, nameof(networkEndpointGroupsAttachEndpointsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are attaching network endpoints to. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsAttachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsAttachEndpointsRequest networkEndpointGroupsAttachEndpointsRequestResource, st::CancellationToken cancellationToken) =>
            AttachNetworkEndpointsAsync(project, zone, networkEndpointGroup, networkEndpointGroupsAttachEndpointsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group to delete. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string zone, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group to delete. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group to delete. It should comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string networkEndpointGroup, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, zone, networkEndpointGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DetachNetworkEndpoints(DetachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(DetachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(DetachNetworkEndpointsNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            DetachNetworkEndpointsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are removing network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsDetachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DetachNetworkEndpoints(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsDetachEndpointsRequest networkEndpointGroupsDetachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DetachNetworkEndpoints(new DetachNetworkEndpointsNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                NetworkEndpointGroupsDetachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupsDetachEndpointsRequestResource, nameof(networkEndpointGroupsDetachEndpointsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are removing network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsDetachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsDetachEndpointsRequest networkEndpointGroupsDetachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DetachNetworkEndpointsAsync(new DetachNetworkEndpointsNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                NetworkEndpointGroupsDetachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupsDetachEndpointsRequestResource, nameof(networkEndpointGroupsDetachEndpointsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are removing network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsDetachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsDetachEndpointsRequest networkEndpointGroupsDetachEndpointsRequestResource, st::CancellationToken cancellationToken) =>
            DetachNetworkEndpointsAsync(project, zone, networkEndpointGroup, networkEndpointGroupsDetachEndpointsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroup Get(GetNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(GetNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(GetNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroup Get(string project, string zone, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(string project, string zone, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(string project, string zone, string networkEndpointGroup, st::CancellationToken cancellationToken) =>
            GetAsync(project, zone, networkEndpointGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string zone, NetworkEndpointGroup networkEndpointGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertNetworkEndpointGroupRequest
            {
                NetworkEndpointGroupResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupResource, nameof(networkEndpointGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, NetworkEndpointGroup networkEndpointGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertNetworkEndpointGroupRequest
            {
                NetworkEndpointGroupResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupResource, nameof(networkEndpointGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, NetworkEndpointGroup networkEndpointGroupResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, zone, networkEndpointGroupResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupList List(ListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(ListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(ListNetworkEndpointGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupList List(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListNetworkEndpointGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListNetworkEndpointGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(string project, string zone, st::CancellationToken cancellationToken) =>
            ListAsync(project, zone, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupsListNetworkEndpoints ListNetworkEndpoints(ListNetworkEndpointsNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(ListNetworkEndpointsNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(ListNetworkEndpointsNetworkEndpointGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListNetworkEndpointsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group from which you want to generate a list of included network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsListEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupsListNetworkEndpoints ListNetworkEndpoints(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsListEndpointsRequest networkEndpointGroupsListEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ListNetworkEndpoints(new ListNetworkEndpointsNetworkEndpointGroupsRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                NetworkEndpointGroupsListEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupsListEndpointsRequestResource, nameof(networkEndpointGroupsListEndpointsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group from which you want to generate a list of included network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsListEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsListEndpointsRequest networkEndpointGroupsListEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ListNetworkEndpointsAsync(new ListNetworkEndpointsNetworkEndpointGroupsRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                NetworkEndpointGroupsListEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupsListEndpointsRequestResource, nameof(networkEndpointGroupsListEndpointsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the network endpoint group is located. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group from which you want to generate a list of included network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="networkEndpointGroupsListEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(string project, string zone, string networkEndpointGroup, NetworkEndpointGroupsListEndpointsRequest networkEndpointGroupsListEndpointsRequestResource, st::CancellationToken cancellationToken) =>
            ListNetworkEndpointsAsync(project, zone, networkEndpointGroup, networkEndpointGroupsListEndpointsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TestPermissionsResponse TestIamPermissions(TestIamPermissionsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
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
            TestIamPermissions(new TestIamPermissionsNetworkEndpointGroupRequest
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
            TestIamPermissionsAsync(new TestIamPermissionsNetworkEndpointGroupRequest
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

    /// <summary>NetworkEndpointGroups client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The NetworkEndpointGroups API.
    /// </remarks>
    public sealed partial class NetworkEndpointGroupsClientImpl : NetworkEndpointGroupsClient
    {
        private readonly gaxgrpc::ApiCall<AggregatedListNetworkEndpointGroupsRequest, NetworkEndpointGroupAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<AttachNetworkEndpointsNetworkEndpointGroupRequest, Operation> _callAttachNetworkEndpoints;

        private readonly gaxgrpc::ApiCall<DeleteNetworkEndpointGroupRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<DetachNetworkEndpointsNetworkEndpointGroupRequest, Operation> _callDetachNetworkEndpoints;

        private readonly gaxgrpc::ApiCall<GetNetworkEndpointGroupRequest, NetworkEndpointGroup> _callGet;

        private readonly gaxgrpc::ApiCall<InsertNetworkEndpointGroupRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListNetworkEndpointGroupsRequest, NetworkEndpointGroupList> _callList;

        private readonly gaxgrpc::ApiCall<ListNetworkEndpointsNetworkEndpointGroupsRequest, NetworkEndpointGroupsListNetworkEndpoints> _callListNetworkEndpoints;

        private readonly gaxgrpc::ApiCall<TestIamPermissionsNetworkEndpointGroupRequest, TestPermissionsResponse> _callTestIamPermissions;

        /// <summary>
        /// Constructs a client wrapper for the NetworkEndpointGroups service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="NetworkEndpointGroupsSettings"/> used within this client.</param>
        public NetworkEndpointGroupsClientImpl(NetworkEndpointGroups.NetworkEndpointGroupsClient grpcClient, NetworkEndpointGroupsSettings settings)
        {
            GrpcClient = grpcClient;
            NetworkEndpointGroupsSettings effectiveSettings = settings ?? NetworkEndpointGroupsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListNetworkEndpointGroupsRequest, NetworkEndpointGroupAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callAttachNetworkEndpoints = clientHelper.BuildApiCall<AttachNetworkEndpointsNetworkEndpointGroupRequest, Operation>(grpcClient.AttachNetworkEndpointsAsync, grpcClient.AttachNetworkEndpoints, effectiveSettings.AttachNetworkEndpointsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callAttachNetworkEndpoints);
            Modify_AttachNetworkEndpointsApiCall(ref _callAttachNetworkEndpoints);
            _callDelete = clientHelper.BuildApiCall<DeleteNetworkEndpointGroupRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callDetachNetworkEndpoints = clientHelper.BuildApiCall<DetachNetworkEndpointsNetworkEndpointGroupRequest, Operation>(grpcClient.DetachNetworkEndpointsAsync, grpcClient.DetachNetworkEndpoints, effectiveSettings.DetachNetworkEndpointsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callDetachNetworkEndpoints);
            Modify_DetachNetworkEndpointsApiCall(ref _callDetachNetworkEndpoints);
            _callGet = clientHelper.BuildApiCall<GetNetworkEndpointGroupRequest, NetworkEndpointGroup>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertNetworkEndpointGroupRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListNetworkEndpointGroupsRequest, NetworkEndpointGroupList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListNetworkEndpoints = clientHelper.BuildApiCall<ListNetworkEndpointsNetworkEndpointGroupsRequest, NetworkEndpointGroupsListNetworkEndpoints>(grpcClient.ListNetworkEndpointsAsync, grpcClient.ListNetworkEndpoints, effectiveSettings.ListNetworkEndpointsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callListNetworkEndpoints);
            Modify_ListNetworkEndpointsApiCall(ref _callListNetworkEndpoints);
            _callTestIamPermissions = clientHelper.BuildApiCall<TestIamPermissionsNetworkEndpointGroupRequest, TestPermissionsResponse>(grpcClient.TestIamPermissionsAsync, grpcClient.TestIamPermissions, effectiveSettings.TestIamPermissionsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("resource", request => request.Resource);
            Modify_ApiCall(ref _callTestIamPermissions);
            Modify_TestIamPermissionsApiCall(ref _callTestIamPermissions);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListNetworkEndpointGroupsRequest, NetworkEndpointGroupAggregatedList> call);

        partial void Modify_AttachNetworkEndpointsApiCall(ref gaxgrpc::ApiCall<AttachNetworkEndpointsNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_DetachNetworkEndpointsApiCall(ref gaxgrpc::ApiCall<DetachNetworkEndpointsNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetNetworkEndpointGroupRequest, NetworkEndpointGroup> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListNetworkEndpointGroupsRequest, NetworkEndpointGroupList> call);

        partial void Modify_ListNetworkEndpointsApiCall(ref gaxgrpc::ApiCall<ListNetworkEndpointsNetworkEndpointGroupsRequest, NetworkEndpointGroupsListNetworkEndpoints> call);

        partial void Modify_TestIamPermissionsApiCall(ref gaxgrpc::ApiCall<TestIamPermissionsNetworkEndpointGroupRequest, TestPermissionsResponse> call);

        partial void OnConstruction(NetworkEndpointGroups.NetworkEndpointGroupsClient grpcClient, NetworkEndpointGroupsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC NetworkEndpointGroups client</summary>
        public override NetworkEndpointGroups.NetworkEndpointGroupsClient GrpcClient { get; }

        partial void Modify_AggregatedListNetworkEndpointGroupsRequest(ref AggregatedListNetworkEndpointGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AttachNetworkEndpointsNetworkEndpointGroupRequest(ref AttachNetworkEndpointsNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteNetworkEndpointGroupRequest(ref DeleteNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DetachNetworkEndpointsNetworkEndpointGroupRequest(ref DetachNetworkEndpointsNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetNetworkEndpointGroupRequest(ref GetNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertNetworkEndpointGroupRequest(ref InsertNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNetworkEndpointGroupsRequest(ref ListNetworkEndpointGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNetworkEndpointsNetworkEndpointGroupsRequest(ref ListNetworkEndpointsNetworkEndpointGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_TestIamPermissionsNetworkEndpointGroupRequest(ref TestIamPermissionsNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroupAggregatedList AggregatedList(AggregatedListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of network endpoint groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroupAggregatedList> AggregatedListAsync(AggregatedListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AttachNetworkEndpoints(AttachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AttachNetworkEndpointsNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callAttachNetworkEndpoints.Sync(request, callSettings);
        }

        /// <summary>
        /// Attach a list of network endpoints to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AttachNetworkEndpointsAsync(AttachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AttachNetworkEndpointsNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callAttachNetworkEndpoints.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified network endpoint group. The network endpoints in the NEG and the VM instances they belong to are not terminated when the NEG is deleted. Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DetachNetworkEndpoints(DetachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DetachNetworkEndpointsNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDetachNetworkEndpoints.Sync(request, callSettings);
        }

        /// <summary>
        /// Detach a list of network endpoints from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DetachNetworkEndpointsAsync(DetachNetworkEndpointsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DetachNetworkEndpointsNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDetachNetworkEndpoints.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroup Get(GetNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroup> GetAsync(GetNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroupList List(ListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroupList> ListAsync(ListNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroupsListNetworkEndpoints ListNetworkEndpoints(ListNetworkEndpointsNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworkEndpointsNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callListNetworkEndpoints.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(ListNetworkEndpointsNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworkEndpointsNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callListNetworkEndpoints.Async(request, callSettings);
        }

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TestPermissionsResponse TestIamPermissions(TestIamPermissionsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_TestIamPermissionsNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callTestIamPermissions.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_TestIamPermissionsNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callTestIamPermissions.Async(request, callSettings);
        }
    }
}
