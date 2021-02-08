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
    /// <summary>Settings for <see cref="InstanceGroupsClient"/> instances.</summary>
    public sealed partial class InstanceGroupsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="InstanceGroupsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="InstanceGroupsSettings"/>.</returns>
        public static InstanceGroupsSettings GetDefault() => new InstanceGroupsSettings();

        /// <summary>Constructs a new <see cref="InstanceGroupsSettings"/> object with default settings.</summary>
        public InstanceGroupsSettings()
        {
        }

        private InstanceGroupsSettings(InstanceGroupsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AddInstancesSettings = existing.AddInstancesSettings;
            AggregatedListSettings = existing.AggregatedListSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListInstancesSettings = existing.ListInstancesSettings;
            RemoveInstancesSettings = existing.RemoveInstancesSettings;
            SetNamedPortsSettings = existing.SetNamedPortsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(InstanceGroupsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupsClient.AddInstances</c> and <c>InstanceGroupsClient.AddInstancesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupsClient.AggregatedList</c> and <c>InstanceGroupsClient.AggregatedListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InstanceGroupsClient.Delete</c>
        ///  and <c>InstanceGroupsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InstanceGroupsClient.Get</c>
        ///  and <c>InstanceGroupsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InstanceGroupsClient.Insert</c>
        ///  and <c>InstanceGroupsClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InstanceGroupsClient.List</c>
        ///  and <c>InstanceGroupsClient.ListAsync</c>.
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
        /// <c>InstanceGroupsClient.ListInstances</c> and <c>InstanceGroupsClient.ListInstancesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupsClient.RemoveInstances</c> and <c>InstanceGroupsClient.RemoveInstancesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RemoveInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupsClient.SetNamedPorts</c> and <c>InstanceGroupsClient.SetNamedPortsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetNamedPortsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="InstanceGroupsSettings"/> object.</returns>
        public InstanceGroupsSettings Clone() => new InstanceGroupsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="InstanceGroupsClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class InstanceGroupsClientBuilder : gaxgrpc::ClientBuilderBase<InstanceGroupsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public InstanceGroupsSettings Settings { get; set; }

        partial void InterceptBuild(ref InstanceGroupsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<InstanceGroupsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override InstanceGroupsClient Build()
        {
            InstanceGroupsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<InstanceGroupsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<InstanceGroupsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private InstanceGroupsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return InstanceGroupsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<InstanceGroupsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return InstanceGroupsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => InstanceGroupsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => InstanceGroupsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => InstanceGroupsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>InstanceGroups client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The InstanceGroups API.
    /// </remarks>
    public abstract partial class InstanceGroupsClient
    {
        /// <summary>
        /// The default endpoint for the InstanceGroups service, which is a host of "compute.googleapis.com" and a port
        /// of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default InstanceGroups scopes.</summary>
        /// <remarks>
        /// The default InstanceGroups scopes are:
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
        /// Asynchronously creates a <see cref="InstanceGroupsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="InstanceGroupsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="InstanceGroupsClient"/>.</returns>
        public static stt::Task<InstanceGroupsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new InstanceGroupsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="InstanceGroupsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="InstanceGroupsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="InstanceGroupsClient"/>.</returns>
        public static InstanceGroupsClient Create() => new InstanceGroupsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="InstanceGroupsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="InstanceGroupsSettings"/>.</param>
        /// <returns>The created <see cref="InstanceGroupsClient"/>.</returns>
        internal static InstanceGroupsClient Create(grpccore::CallInvoker callInvoker, InstanceGroupsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            InstanceGroups.InstanceGroupsClient grpcClient = new InstanceGroups.InstanceGroupsClient(callInvoker);
            return new InstanceGroupsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC InstanceGroups client</summary>
        public virtual InstanceGroups.InstanceGroupsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddInstances(AddInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstancesAsync(AddInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstancesAsync(AddInstancesInstanceGroupRequest request, st::CancellationToken cancellationToken) =>
            AddInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where you are adding instances.
        /// </param>
        /// <param name="instanceGroupsAddInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddInstances(string project, string zone, string instanceGroup, InstanceGroupsAddInstancesRequest instanceGroupsAddInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddInstances(new AddInstancesInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsAddInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsAddInstancesRequestResource, nameof(instanceGroupsAddInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where you are adding instances.
        /// </param>
        /// <param name="instanceGroupsAddInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstancesAsync(string project, string zone, string instanceGroup, InstanceGroupsAddInstancesRequest instanceGroupsAddInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddInstancesAsync(new AddInstancesInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsAddInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsAddInstancesRequestResource, nameof(instanceGroupsAddInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where you are adding instances.
        /// </param>
        /// <param name="instanceGroupsAddInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstancesAsync(string project, string zone, string instanceGroup, InstanceGroupsAddInstancesRequest instanceGroupsAddInstancesRequestResource, st::CancellationToken cancellationToken) =>
            AddInstancesAsync(project, zone, instanceGroup, instanceGroupsAddInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupAggregatedList AggregatedList(AggregatedListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupAggregatedList> AggregatedListAsync(AggregatedListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupAggregatedList> AggregatedListAsync(AggregatedListInstanceGroupsRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListInstanceGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListInstanceGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteInstanceGroupRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string zone, string instanceGroup, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string instanceGroup, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string instanceGroup, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, zone, instanceGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroup Get(GetInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroup> GetAsync(GetInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroup> GetAsync(GetInstanceGroupRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroup Get(string project, string zone, string instanceGroup, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroup> GetAsync(string project, string zone, string instanceGroup, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroup> GetAsync(string project, string zone, string instanceGroup, st::CancellationToken cancellationToken) =>
            GetAsync(project, zone, instanceGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertInstanceGroupRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the instance group.
        /// </param>
        /// <param name="instanceGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string zone, InstanceGroup instanceGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertInstanceGroupRequest
            {
                InstanceGroupResource = gax::GaxPreconditions.CheckNotNull(instanceGroupResource, nameof(instanceGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the instance group.
        /// </param>
        /// <param name="instanceGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, InstanceGroup instanceGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertInstanceGroupRequest
            {
                InstanceGroupResource = gax::GaxPreconditions.CheckNotNull(instanceGroupResource, nameof(instanceGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the instance group.
        /// </param>
        /// <param name="instanceGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, InstanceGroup instanceGroupResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, zone, instanceGroupResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupList List(ListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupList> ListAsync(ListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupList> ListAsync(ListInstanceGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupList List(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListInstanceGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupList> ListAsync(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListInstanceGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupList> ListAsync(string project, string zone, st::CancellationToken cancellationToken) =>
            ListAsync(project, zone, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupsListInstances ListInstances(ListInstancesInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupsListInstances> ListInstancesAsync(ListInstancesInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupsListInstances> ListInstancesAsync(ListInstancesInstanceGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group from which you want to generate a list of included instances.
        /// </param>
        /// <param name="instanceGroupsListInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupsListInstances ListInstances(string project, string zone, string instanceGroup, InstanceGroupsListInstancesRequest instanceGroupsListInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ListInstances(new ListInstancesInstanceGroupsRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsListInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsListInstancesRequestResource, nameof(instanceGroupsListInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group from which you want to generate a list of included instances.
        /// </param>
        /// <param name="instanceGroupsListInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupsListInstances> ListInstancesAsync(string project, string zone, string instanceGroup, InstanceGroupsListInstancesRequest instanceGroupsListInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ListInstancesAsync(new ListInstancesInstanceGroupsRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsListInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsListInstancesRequestResource, nameof(instanceGroupsListInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group from which you want to generate a list of included instances.
        /// </param>
        /// <param name="instanceGroupsListInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupsListInstances> ListInstancesAsync(string project, string zone, string instanceGroup, InstanceGroupsListInstancesRequest instanceGroupsListInstancesRequestResource, st::CancellationToken cancellationToken) =>
            ListInstancesAsync(project, zone, instanceGroup, instanceGroupsListInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveInstances(RemoveInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstancesAsync(RemoveInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstancesAsync(RemoveInstancesInstanceGroupRequest request, st::CancellationToken cancellationToken) =>
            RemoveInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where the specified instances will be removed.
        /// </param>
        /// <param name="instanceGroupsRemoveInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveInstances(string project, string zone, string instanceGroup, InstanceGroupsRemoveInstancesRequest instanceGroupsRemoveInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemoveInstances(new RemoveInstancesInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsRemoveInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsRemoveInstancesRequestResource, nameof(instanceGroupsRemoveInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where the specified instances will be removed.
        /// </param>
        /// <param name="instanceGroupsRemoveInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstancesAsync(string project, string zone, string instanceGroup, InstanceGroupsRemoveInstancesRequest instanceGroupsRemoveInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemoveInstancesAsync(new RemoveInstancesInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsRemoveInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsRemoveInstancesRequestResource, nameof(instanceGroupsRemoveInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where the specified instances will be removed.
        /// </param>
        /// <param name="instanceGroupsRemoveInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstancesAsync(string project, string zone, string instanceGroup, InstanceGroupsRemoveInstancesRequest instanceGroupsRemoveInstancesRequestResource, st::CancellationToken cancellationToken) =>
            RemoveInstancesAsync(project, zone, instanceGroup, instanceGroupsRemoveInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetNamedPorts(SetNamedPortsInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNamedPortsAsync(SetNamedPortsInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNamedPortsAsync(SetNamedPortsInstanceGroupRequest request, st::CancellationToken cancellationToken) =>
            SetNamedPortsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where the named ports are updated.
        /// </param>
        /// <param name="instanceGroupsSetNamedPortsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetNamedPorts(string project, string zone, string instanceGroup, InstanceGroupsSetNamedPortsRequest instanceGroupsSetNamedPortsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetNamedPorts(new SetNamedPortsInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsSetNamedPortsRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsSetNamedPortsRequestResource, nameof(instanceGroupsSetNamedPortsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where the named ports are updated.
        /// </param>
        /// <param name="instanceGroupsSetNamedPortsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNamedPortsAsync(string project, string zone, string instanceGroup, InstanceGroupsSetNamedPortsRequest instanceGroupsSetNamedPortsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetNamedPortsAsync(new SetNamedPortsInstanceGroupRequest
            {
                InstanceGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroup, nameof(instanceGroup)),
                InstanceGroupsSetNamedPortsRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupsSetNamedPortsRequestResource, nameof(instanceGroupsSetNamedPortsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the instance group is located.
        /// </param>
        /// <param name="instanceGroup">
        /// The name of the instance group where the named ports are updated.
        /// </param>
        /// <param name="instanceGroupsSetNamedPortsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetNamedPortsAsync(string project, string zone, string instanceGroup, InstanceGroupsSetNamedPortsRequest instanceGroupsSetNamedPortsRequestResource, st::CancellationToken cancellationToken) =>
            SetNamedPortsAsync(project, zone, instanceGroup, instanceGroupsSetNamedPortsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>InstanceGroups client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The InstanceGroups API.
    /// </remarks>
    public sealed partial class InstanceGroupsClientImpl : InstanceGroupsClient
    {
        private readonly gaxgrpc::ApiCall<AddInstancesInstanceGroupRequest, Operation> _callAddInstances;

        private readonly gaxgrpc::ApiCall<AggregatedListInstanceGroupsRequest, InstanceGroupAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<DeleteInstanceGroupRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetInstanceGroupRequest, InstanceGroup> _callGet;

        private readonly gaxgrpc::ApiCall<InsertInstanceGroupRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListInstanceGroupsRequest, InstanceGroupList> _callList;

        private readonly gaxgrpc::ApiCall<ListInstancesInstanceGroupsRequest, InstanceGroupsListInstances> _callListInstances;

        private readonly gaxgrpc::ApiCall<RemoveInstancesInstanceGroupRequest, Operation> _callRemoveInstances;

        private readonly gaxgrpc::ApiCall<SetNamedPortsInstanceGroupRequest, Operation> _callSetNamedPorts;

        /// <summary>
        /// Constructs a client wrapper for the InstanceGroups service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="InstanceGroupsSettings"/> used within this client.</param>
        public InstanceGroupsClientImpl(InstanceGroups.InstanceGroupsClient grpcClient, InstanceGroupsSettings settings)
        {
            GrpcClient = grpcClient;
            InstanceGroupsSettings effectiveSettings = settings ?? InstanceGroupsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAddInstances = clientHelper.BuildApiCall<AddInstancesInstanceGroupRequest, Operation>(grpcClient.AddInstancesAsync, grpcClient.AddInstances, effectiveSettings.AddInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group", request => request.InstanceGroup);
            Modify_ApiCall(ref _callAddInstances);
            Modify_AddInstancesApiCall(ref _callAddInstances);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListInstanceGroupsRequest, InstanceGroupAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callDelete = clientHelper.BuildApiCall<DeleteInstanceGroupRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group", request => request.InstanceGroup);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetInstanceGroupRequest, InstanceGroup>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group", request => request.InstanceGroup);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertInstanceGroupRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListInstanceGroupsRequest, InstanceGroupList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListInstances = clientHelper.BuildApiCall<ListInstancesInstanceGroupsRequest, InstanceGroupsListInstances>(grpcClient.ListInstancesAsync, grpcClient.ListInstances, effectiveSettings.ListInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group", request => request.InstanceGroup);
            Modify_ApiCall(ref _callListInstances);
            Modify_ListInstancesApiCall(ref _callListInstances);
            _callRemoveInstances = clientHelper.BuildApiCall<RemoveInstancesInstanceGroupRequest, Operation>(grpcClient.RemoveInstancesAsync, grpcClient.RemoveInstances, effectiveSettings.RemoveInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group", request => request.InstanceGroup);
            Modify_ApiCall(ref _callRemoveInstances);
            Modify_RemoveInstancesApiCall(ref _callRemoveInstances);
            _callSetNamedPorts = clientHelper.BuildApiCall<SetNamedPortsInstanceGroupRequest, Operation>(grpcClient.SetNamedPortsAsync, grpcClient.SetNamedPorts, effectiveSettings.SetNamedPortsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group", request => request.InstanceGroup);
            Modify_ApiCall(ref _callSetNamedPorts);
            Modify_SetNamedPortsApiCall(ref _callSetNamedPorts);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AddInstancesApiCall(ref gaxgrpc::ApiCall<AddInstancesInstanceGroupRequest, Operation> call);

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListInstanceGroupsRequest, InstanceGroupAggregatedList> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteInstanceGroupRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetInstanceGroupRequest, InstanceGroup> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertInstanceGroupRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListInstanceGroupsRequest, InstanceGroupList> call);

        partial void Modify_ListInstancesApiCall(ref gaxgrpc::ApiCall<ListInstancesInstanceGroupsRequest, InstanceGroupsListInstances> call);

        partial void Modify_RemoveInstancesApiCall(ref gaxgrpc::ApiCall<RemoveInstancesInstanceGroupRequest, Operation> call);

        partial void Modify_SetNamedPortsApiCall(ref gaxgrpc::ApiCall<SetNamedPortsInstanceGroupRequest, Operation> call);

        partial void OnConstruction(InstanceGroups.InstanceGroupsClient grpcClient, InstanceGroupsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC InstanceGroups client</summary>
        public override InstanceGroups.InstanceGroupsClient GrpcClient { get; }

        partial void Modify_AddInstancesInstanceGroupRequest(ref AddInstancesInstanceGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AggregatedListInstanceGroupsRequest(ref AggregatedListInstanceGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteInstanceGroupRequest(ref DeleteInstanceGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetInstanceGroupRequest(ref GetInstanceGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertInstanceGroupRequest(ref InsertInstanceGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListInstanceGroupsRequest(ref ListInstanceGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListInstancesInstanceGroupsRequest(ref ListInstancesInstanceGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RemoveInstancesInstanceGroupRequest(ref RemoveInstancesInstanceGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetNamedPortsInstanceGroupRequest(ref SetNamedPortsInstanceGroupRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddInstances(AddInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddInstancesInstanceGroupRequest(ref request, ref callSettings);
            return _callAddInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Adds a list of instances to the specified instance group. All of the instances in the instance group must be in the same network/subnetwork. Read  Adding instances for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddInstancesAsync(AddInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddInstancesInstanceGroupRequest(ref request, ref callSettings);
            return _callAddInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupAggregatedList AggregatedList(AggregatedListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListInstanceGroupsRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of instance groups and sorts them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupAggregatedList> AggregatedListAsync(AggregatedListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListInstanceGroupsRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstanceGroupRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified instance group. The instances in the group are not deleted. Note that instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstanceGroupRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroup Get(GetInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInstanceGroupRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified zonal instance group. Get a list of available zonal instance groups by making a list() request.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroup> GetAsync(GetInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInstanceGroupRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertInstanceGroupRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates an instance group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertInstanceGroupRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupList List(ListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInstanceGroupsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of zonal instance group resources contained within the specified zone.
        /// 
        /// For managed instance groups, use the instanceGroupManagers or regionInstanceGroupManagers methods instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupList> ListAsync(ListInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInstanceGroupsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupsListInstances ListInstances(ListInstancesInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInstancesInstanceGroupsRequest(ref request, ref callSettings);
            return _callListInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists the instances in the specified instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupsListInstances> ListInstancesAsync(ListInstancesInstanceGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInstancesInstanceGroupsRequest(ref request, ref callSettings);
            return _callListInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation RemoveInstances(RemoveInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveInstancesInstanceGroupRequest(ref request, ref callSettings);
            return _callRemoveInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Removes one or more instances from the specified instance group, but does not delete those instances.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> RemoveInstancesAsync(RemoveInstancesInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveInstancesInstanceGroupRequest(ref request, ref callSettings);
            return _callRemoveInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetNamedPorts(SetNamedPortsInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetNamedPortsInstanceGroupRequest(ref request, ref callSettings);
            return _callSetNamedPorts.Sync(request, callSettings);
        }

        /// <summary>
        /// Sets the named ports for the specified instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetNamedPortsAsync(SetNamedPortsInstanceGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetNamedPortsInstanceGroupRequest(ref request, ref callSettings);
            return _callSetNamedPorts.Async(request, callSettings);
        }
    }
}
