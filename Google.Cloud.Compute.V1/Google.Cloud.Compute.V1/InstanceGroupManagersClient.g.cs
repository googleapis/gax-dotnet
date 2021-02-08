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
    /// <summary>Settings for <see cref="InstanceGroupManagersClient"/> instances.</summary>
    public sealed partial class InstanceGroupManagersSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="InstanceGroupManagersSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="InstanceGroupManagersSettings"/>.</returns>
        public static InstanceGroupManagersSettings GetDefault() => new InstanceGroupManagersSettings();

        /// <summary>
        /// Constructs a new <see cref="InstanceGroupManagersSettings"/> object with default settings.
        /// </summary>
        public InstanceGroupManagersSettings()
        {
        }

        private InstanceGroupManagersSettings(InstanceGroupManagersSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AbandonInstancesSettings = existing.AbandonInstancesSettings;
            AggregatedListSettings = existing.AggregatedListSettings;
            ApplyUpdatesToInstancesSettings = existing.ApplyUpdatesToInstancesSettings;
            CreateInstancesSettings = existing.CreateInstancesSettings;
            DeleteSettings = existing.DeleteSettings;
            DeleteInstancesSettings = existing.DeleteInstancesSettings;
            DeletePerInstanceConfigsSettings = existing.DeletePerInstanceConfigsSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListErrorsSettings = existing.ListErrorsSettings;
            ListManagedInstancesSettings = existing.ListManagedInstancesSettings;
            ListPerInstanceConfigsSettings = existing.ListPerInstanceConfigsSettings;
            PatchSettings = existing.PatchSettings;
            PatchPerInstanceConfigsSettings = existing.PatchPerInstanceConfigsSettings;
            RecreateInstancesSettings = existing.RecreateInstancesSettings;
            ResizeSettings = existing.ResizeSettings;
            SetInstanceTemplateSettings = existing.SetInstanceTemplateSettings;
            SetTargetPoolsSettings = existing.SetTargetPoolsSettings;
            UpdatePerInstanceConfigsSettings = existing.UpdatePerInstanceConfigsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(InstanceGroupManagersSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.AbandonInstances</c> and <c>InstanceGroupManagersClient.AbandonInstancesAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AbandonInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.AggregatedList</c> and <c>InstanceGroupManagersClient.AggregatedListAsync</c>
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
        /// <c>InstanceGroupManagersClient.ApplyUpdatesToInstances</c> and
        /// <c>InstanceGroupManagersClient.ApplyUpdatesToInstancesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ApplyUpdatesToInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.CreateInstances</c> and <c>InstanceGroupManagersClient.CreateInstancesAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings CreateInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.Delete</c> and <c>InstanceGroupManagersClient.DeleteAsync</c>.
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
        /// <c>InstanceGroupManagersClient.DeleteInstances</c> and <c>InstanceGroupManagersClient.DeleteInstancesAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.DeletePerInstanceConfigs</c> and
        /// <c>InstanceGroupManagersClient.DeletePerInstanceConfigsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeletePerInstanceConfigsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.Get</c> and <c>InstanceGroupManagersClient.GetAsync</c>.
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
        /// <c>InstanceGroupManagersClient.Insert</c> and <c>InstanceGroupManagersClient.InsertAsync</c>.
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
        /// <c>InstanceGroupManagersClient.List</c> and <c>InstanceGroupManagersClient.ListAsync</c>.
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
        /// <c>InstanceGroupManagersClient.ListErrors</c> and <c>InstanceGroupManagersClient.ListErrorsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListErrorsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.ListManagedInstances</c> and
        /// <c>InstanceGroupManagersClient.ListManagedInstancesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListManagedInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.ListPerInstanceConfigs</c> and
        /// <c>InstanceGroupManagersClient.ListPerInstanceConfigsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListPerInstanceConfigsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.Patch</c> and <c>InstanceGroupManagersClient.PatchAsync</c>.
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
        /// <c>InstanceGroupManagersClient.PatchPerInstanceConfigs</c> and
        /// <c>InstanceGroupManagersClient.PatchPerInstanceConfigsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchPerInstanceConfigsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.RecreateInstances</c> and
        /// <c>InstanceGroupManagersClient.RecreateInstancesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RecreateInstancesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.Resize</c> and <c>InstanceGroupManagersClient.ResizeAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ResizeSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.SetInstanceTemplate</c> and
        /// <c>InstanceGroupManagersClient.SetInstanceTemplateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetInstanceTemplateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.SetTargetPools</c> and <c>InstanceGroupManagersClient.SetTargetPoolsAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetTargetPoolsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InstanceGroupManagersClient.UpdatePerInstanceConfigs</c> and
        /// <c>InstanceGroupManagersClient.UpdatePerInstanceConfigsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdatePerInstanceConfigsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="InstanceGroupManagersSettings"/> object.</returns>
        public InstanceGroupManagersSettings Clone() => new InstanceGroupManagersSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="InstanceGroupManagersClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class InstanceGroupManagersClientBuilder : gaxgrpc::ClientBuilderBase<InstanceGroupManagersClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public InstanceGroupManagersSettings Settings { get; set; }

        partial void InterceptBuild(ref InstanceGroupManagersClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<InstanceGroupManagersClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override InstanceGroupManagersClient Build()
        {
            InstanceGroupManagersClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<InstanceGroupManagersClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<InstanceGroupManagersClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private InstanceGroupManagersClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return InstanceGroupManagersClient.Create(callInvoker, Settings);
        }

        private async stt::Task<InstanceGroupManagersClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return InstanceGroupManagersClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => InstanceGroupManagersClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => InstanceGroupManagersClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => InstanceGroupManagersClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>InstanceGroupManagers client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The InstanceGroupManagers API.
    /// </remarks>
    public abstract partial class InstanceGroupManagersClient
    {
        /// <summary>
        /// The default endpoint for the InstanceGroupManagers service, which is a host of "compute.googleapis.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default InstanceGroupManagers scopes.</summary>
        /// <remarks>
        /// The default InstanceGroupManagers scopes are:
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
        /// Asynchronously creates a <see cref="InstanceGroupManagersClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="InstanceGroupManagersClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="InstanceGroupManagersClient"/>.</returns>
        public static stt::Task<InstanceGroupManagersClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new InstanceGroupManagersClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="InstanceGroupManagersClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="InstanceGroupManagersClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="InstanceGroupManagersClient"/>.</returns>
        public static InstanceGroupManagersClient Create() => new InstanceGroupManagersClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="InstanceGroupManagersClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="InstanceGroupManagersSettings"/>.</param>
        /// <returns>The created <see cref="InstanceGroupManagersClient"/>.</returns>
        internal static InstanceGroupManagersClient Create(grpccore::CallInvoker callInvoker, InstanceGroupManagersSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            InstanceGroupManagers.InstanceGroupManagersClient grpcClient = new InstanceGroupManagers.InstanceGroupManagersClient(callInvoker);
            return new InstanceGroupManagersClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC InstanceGroupManagers client</summary>
        public virtual InstanceGroupManagers.InstanceGroupManagersClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AbandonInstances(AbandonInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(AbandonInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(AbandonInstancesInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            AbandonInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersAbandonInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AbandonInstances(string project, string zone, string instanceGroupManager, InstanceGroupManagersAbandonInstancesRequest instanceGroupManagersAbandonInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AbandonInstances(new AbandonInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersAbandonInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersAbandonInstancesRequestResource, nameof(instanceGroupManagersAbandonInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersAbandonInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersAbandonInstancesRequest instanceGroupManagersAbandonInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AbandonInstancesAsync(new AbandonInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersAbandonInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersAbandonInstancesRequestResource, nameof(instanceGroupManagersAbandonInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersAbandonInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersAbandonInstancesRequest instanceGroupManagersAbandonInstancesRequestResource, st::CancellationToken cancellationToken) =>
            AbandonInstancesAsync(project, zone, instanceGroupManager, instanceGroupManagersAbandonInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagerAggregatedList AggregatedList(AggregatedListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerAggregatedList> AggregatedListAsync(AggregatedListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerAggregatedList> AggregatedListAsync(AggregatedListInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagerAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListInstanceGroupManagersRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListInstanceGroupManagersRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation ApplyUpdatesToInstances(ApplyUpdatesToInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(ApplyUpdatesToInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(ApplyUpdatesToInstancesInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            ApplyUpdatesToInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. Should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersApplyUpdatesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation ApplyUpdatesToInstances(string project, string zone, string instanceGroupManager, InstanceGroupManagersApplyUpdatesRequest instanceGroupManagersApplyUpdatesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ApplyUpdatesToInstances(new ApplyUpdatesToInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersApplyUpdatesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersApplyUpdatesRequestResource, nameof(instanceGroupManagersApplyUpdatesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. Should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersApplyUpdatesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersApplyUpdatesRequest instanceGroupManagersApplyUpdatesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ApplyUpdatesToInstancesAsync(new ApplyUpdatesToInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersApplyUpdatesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersApplyUpdatesRequestResource, nameof(instanceGroupManagersApplyUpdatesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. Should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersApplyUpdatesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersApplyUpdatesRequest instanceGroupManagersApplyUpdatesRequestResource, st::CancellationToken cancellationToken) =>
            ApplyUpdatesToInstancesAsync(project, zone, instanceGroupManager, instanceGroupManagersApplyUpdatesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation CreateInstances(CreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(CreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(CreateInstancesInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            CreateInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersCreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation CreateInstances(string project, string zone, string instanceGroupManager, InstanceGroupManagersCreateInstancesRequest instanceGroupManagersCreateInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            CreateInstances(new CreateInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersCreateInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersCreateInstancesRequestResource, nameof(instanceGroupManagersCreateInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersCreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersCreateInstancesRequest instanceGroupManagersCreateInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            CreateInstancesAsync(new CreateInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersCreateInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersCreateInstancesRequestResource, nameof(instanceGroupManagersCreateInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersCreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersCreateInstancesRequest instanceGroupManagersCreateInstancesRequestResource, st::CancellationToken cancellationToken) =>
            CreateInstancesAsync(project, zone, instanceGroupManager, instanceGroupManagersCreateInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string zone, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, zone, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteInstances(DeleteInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(DeleteInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(DeleteInstancesInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            DeleteInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersDeleteInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteInstances(string project, string zone, string instanceGroupManager, InstanceGroupManagersDeleteInstancesRequest instanceGroupManagersDeleteInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DeleteInstances(new DeleteInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersDeleteInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersDeleteInstancesRequestResource, nameof(instanceGroupManagersDeleteInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersDeleteInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersDeleteInstancesRequest instanceGroupManagersDeleteInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DeleteInstancesAsync(new DeleteInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersDeleteInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersDeleteInstancesRequestResource, nameof(instanceGroupManagersDeleteInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersDeleteInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersDeleteInstancesRequest instanceGroupManagersDeleteInstancesRequestResource, st::CancellationToken cancellationToken) =>
            DeleteInstancesAsync(project, zone, instanceGroupManager, instanceGroupManagersDeleteInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeletePerInstanceConfigs(DeletePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(DeletePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(DeletePerInstanceConfigsInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            DeletePerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersDeletePerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeletePerInstanceConfigs(string project, string zone, string instanceGroupManager, InstanceGroupManagersDeletePerInstanceConfigsReq instanceGroupManagersDeletePerInstanceConfigsReqResource, gaxgrpc::CallSettings callSettings = null) =>
            DeletePerInstanceConfigs(new DeletePerInstanceConfigsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersDeletePerInstanceConfigsReqResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersDeletePerInstanceConfigsReqResource, nameof(instanceGroupManagersDeletePerInstanceConfigsReqResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersDeletePerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersDeletePerInstanceConfigsReq instanceGroupManagersDeletePerInstanceConfigsReqResource, gaxgrpc::CallSettings callSettings = null) =>
            DeletePerInstanceConfigsAsync(new DeletePerInstanceConfigsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersDeletePerInstanceConfigsReqResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersDeletePerInstanceConfigsReqResource, nameof(instanceGroupManagersDeletePerInstanceConfigsReqResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersDeletePerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersDeletePerInstanceConfigsReq instanceGroupManagersDeletePerInstanceConfigsReqResource, st::CancellationToken cancellationToken) =>
            DeletePerInstanceConfigsAsync(project, zone, instanceGroupManager, instanceGroupManagersDeletePerInstanceConfigsReqResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManager Get(GetInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(GetInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(GetInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManager Get(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(string project, string zone, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            GetAsync(project, zone, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string zone, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertInstanceGroupManagerRequest
            {
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertInstanceGroupManagerRequest
            {
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string zone, InstanceGroupManager instanceGroupManagerResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, zone, instanceGroupManagerResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagerList List(ListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerList> ListAsync(ListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerList> ListAsync(ListInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagerList List(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListInstanceGroupManagersRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerList> ListAsync(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListInstanceGroupManagersRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagerList> ListAsync(string project, string zone, st::CancellationToken cancellationToken) =>
            ListAsync(project, zone, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagersListErrorsResponse ListErrors(ListErrorsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListErrorsResponse> ListErrorsAsync(ListErrorsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListErrorsResponse> ListErrorsAsync(ListErrorsInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListErrorsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It must be a string that meets the requirements in RFC1035, or an unsigned long integer: must match regexp pattern: (?:[a-z](?:[-a-z0-9]{0,61}[a-z0-9])?)|[1-9][0-9]{0,19}.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagersListErrorsResponse ListErrors(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListErrors(new ListErrorsInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It must be a string that meets the requirements in RFC1035, or an unsigned long integer: must match regexp pattern: (?:[a-z](?:[-a-z0-9]{0,61}[a-z0-9])?)|[1-9][0-9]{0,19}.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListErrorsResponse> ListErrorsAsync(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListErrorsAsync(new ListErrorsInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It must be a string that meets the requirements in RFC1035, or an unsigned long integer: must match regexp pattern: (?:[a-z](?:[-a-z0-9]{0,61}[a-z0-9])?)|[1-9][0-9]{0,19}.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListErrorsResponse> ListErrorsAsync(string project, string zone, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            ListErrorsAsync(project, zone, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagersListManagedInstancesResponse ListManagedInstances(ListManagedInstancesInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListManagedInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListManagedInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListManagedInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagersListManagedInstancesResponse ListManagedInstances(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListManagedInstances(new ListManagedInstancesInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListManagedInstancesResponse> ListManagedInstancesAsync(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListManagedInstancesAsync(new ListManagedInstancesInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListManagedInstancesResponse> ListManagedInstancesAsync(string project, string zone, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            ListManagedInstancesAsync(project, zone, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagersListPerInstanceConfigsResp ListPerInstanceConfigs(ListPerInstanceConfigsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListPerInstanceConfigsResp> ListPerInstanceConfigsAsync(ListPerInstanceConfigsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListPerInstanceConfigsResp> ListPerInstanceConfigsAsync(ListPerInstanceConfigsInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListPerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManagersListPerInstanceConfigsResp ListPerInstanceConfigs(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListPerInstanceConfigs(new ListPerInstanceConfigsInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListPerInstanceConfigsResp> ListPerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListPerInstanceConfigsAsync(new ListPerInstanceConfigsInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManagersListPerInstanceConfigsResp> ListPerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            ListPerInstanceConfigsAsync(project, zone, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the managed instance group.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the instance group manager.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string zone, string instanceGroupManager, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the managed instance group.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the instance group manager.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string zone, string instanceGroupManager, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where you want to create the managed instance group.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the instance group manager.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string zone, string instanceGroupManager, InstanceGroupManager instanceGroupManagerResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, zone, instanceGroupManager, instanceGroupManagerResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation PatchPerInstanceConfigs(PatchPerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(PatchPerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(PatchPerInstanceConfigsInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            PatchPerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersPatchPerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation PatchPerInstanceConfigs(string project, string zone, string instanceGroupManager, InstanceGroupManagersPatchPerInstanceConfigsReq instanceGroupManagersPatchPerInstanceConfigsReqResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchPerInstanceConfigs(new PatchPerInstanceConfigsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersPatchPerInstanceConfigsReqResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersPatchPerInstanceConfigsReqResource, nameof(instanceGroupManagersPatchPerInstanceConfigsReqResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersPatchPerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersPatchPerInstanceConfigsReq instanceGroupManagersPatchPerInstanceConfigsReqResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchPerInstanceConfigsAsync(new PatchPerInstanceConfigsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersPatchPerInstanceConfigsReqResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersPatchPerInstanceConfigsReqResource, nameof(instanceGroupManagersPatchPerInstanceConfigsReqResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersPatchPerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersPatchPerInstanceConfigsReq instanceGroupManagersPatchPerInstanceConfigsReqResource, st::CancellationToken cancellationToken) =>
            PatchPerInstanceConfigsAsync(project, zone, instanceGroupManager, instanceGroupManagersPatchPerInstanceConfigsReqResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RecreateInstances(RecreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RecreateInstancesAsync(RecreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RecreateInstancesAsync(RecreateInstancesInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            RecreateInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersRecreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RecreateInstances(string project, string zone, string instanceGroupManager, InstanceGroupManagersRecreateInstancesRequest instanceGroupManagersRecreateInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RecreateInstances(new RecreateInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersRecreateInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersRecreateInstancesRequestResource, nameof(instanceGroupManagersRecreateInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersRecreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RecreateInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersRecreateInstancesRequest instanceGroupManagersRecreateInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RecreateInstancesAsync(new RecreateInstancesInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersRecreateInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersRecreateInstancesRequestResource, nameof(instanceGroupManagersRecreateInstancesRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersRecreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RecreateInstancesAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersRecreateInstancesRequest instanceGroupManagersRecreateInstancesRequestResource, st::CancellationToken cancellationToken) =>
            RecreateInstancesAsync(project, zone, instanceGroupManager, instanceGroupManagersRecreateInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Resize(ResizeInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(ResizeInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(ResizeInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            ResizeAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="size">
        /// The number of running instances that the managed instance group should maintain at any given time. The group automatically adds or removes instances to maintain the number of instances specified by this parameter.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Resize(string project, string zone, string instanceGroupManager, int size, gaxgrpc::CallSettings callSettings = null) =>
            Resize(new ResizeInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Size = size,
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="size">
        /// The number of running instances that the managed instance group should maintain at any given time. The group automatically adds or removes instances to maintain the number of instances specified by this parameter.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(string project, string zone, string instanceGroupManager, int size, gaxgrpc::CallSettings callSettings = null) =>
            ResizeAsync(new ResizeInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Size = size,
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="size">
        /// The number of running instances that the managed instance group should maintain at any given time. The group automatically adds or removes instances to maintain the number of instances specified by this parameter.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(string project, string zone, string instanceGroupManager, int size, st::CancellationToken cancellationToken) =>
            ResizeAsync(project, zone, instanceGroupManager, size, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetInstanceTemplate(SetInstanceTemplateInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(SetInstanceTemplateInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(SetInstanceTemplateInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            SetInstanceTemplateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersSetInstanceTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetInstanceTemplate(string project, string zone, string instanceGroupManager, InstanceGroupManagersSetInstanceTemplateRequest instanceGroupManagersSetInstanceTemplateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetInstanceTemplate(new SetInstanceTemplateInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersSetInstanceTemplateRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersSetInstanceTemplateRequestResource, nameof(instanceGroupManagersSetInstanceTemplateRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersSetInstanceTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersSetInstanceTemplateRequest instanceGroupManagersSetInstanceTemplateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetInstanceTemplateAsync(new SetInstanceTemplateInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersSetInstanceTemplateRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersSetInstanceTemplateRequestResource, nameof(instanceGroupManagersSetInstanceTemplateRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersSetInstanceTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersSetInstanceTemplateRequest instanceGroupManagersSetInstanceTemplateRequestResource, st::CancellationToken cancellationToken) =>
            SetInstanceTemplateAsync(project, zone, instanceGroupManager, instanceGroupManagersSetInstanceTemplateRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetTargetPools(SetTargetPoolsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(SetTargetPoolsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(SetTargetPoolsInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            SetTargetPoolsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersSetTargetPoolsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetTargetPools(string project, string zone, string instanceGroupManager, InstanceGroupManagersSetTargetPoolsRequest instanceGroupManagersSetTargetPoolsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetTargetPools(new SetTargetPoolsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersSetTargetPoolsRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersSetTargetPoolsRequestResource, nameof(instanceGroupManagersSetTargetPoolsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersSetTargetPoolsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersSetTargetPoolsRequest instanceGroupManagersSetTargetPoolsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetTargetPoolsAsync(new SetTargetPoolsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersSetTargetPoolsRequestResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersSetTargetPoolsRequestResource, nameof(instanceGroupManagersSetTargetPoolsRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="instanceGroupManagersSetTargetPoolsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersSetTargetPoolsRequest instanceGroupManagersSetTargetPoolsRequestResource, st::CancellationToken cancellationToken) =>
            SetTargetPoolsAsync(project, zone, instanceGroupManager, instanceGroupManagersSetTargetPoolsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation UpdatePerInstanceConfigs(UpdatePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(UpdatePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(UpdatePerInstanceConfigsInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            UpdatePerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersUpdatePerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation UpdatePerInstanceConfigs(string project, string zone, string instanceGroupManager, InstanceGroupManagersUpdatePerInstanceConfigsReq instanceGroupManagersUpdatePerInstanceConfigsReqResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdatePerInstanceConfigs(new UpdatePerInstanceConfigsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersUpdatePerInstanceConfigsReqResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersUpdatePerInstanceConfigsReqResource, nameof(instanceGroupManagersUpdatePerInstanceConfigsReqResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersUpdatePerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersUpdatePerInstanceConfigsReq instanceGroupManagersUpdatePerInstanceConfigsReqResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdatePerInstanceConfigsAsync(new UpdatePerInstanceConfigsInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagersUpdatePerInstanceConfigsReqResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagersUpdatePerInstanceConfigsReqResource, nameof(instanceGroupManagersUpdatePerInstanceConfigsReqResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// The name of the zone where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManagersUpdatePerInstanceConfigsReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(string project, string zone, string instanceGroupManager, InstanceGroupManagersUpdatePerInstanceConfigsReq instanceGroupManagersUpdatePerInstanceConfigsReqResource, st::CancellationToken cancellationToken) =>
            UpdatePerInstanceConfigsAsync(project, zone, instanceGroupManager, instanceGroupManagersUpdatePerInstanceConfigsReqResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>InstanceGroupManagers client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The InstanceGroupManagers API.
    /// </remarks>
    public sealed partial class InstanceGroupManagersClientImpl : InstanceGroupManagersClient
    {
        private readonly gaxgrpc::ApiCall<AbandonInstancesInstanceGroupManagerRequest, Operation> _callAbandonInstances;

        private readonly gaxgrpc::ApiCall<AggregatedListInstanceGroupManagersRequest, InstanceGroupManagerAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<ApplyUpdatesToInstancesInstanceGroupManagerRequest, Operation> _callApplyUpdatesToInstances;

        private readonly gaxgrpc::ApiCall<CreateInstancesInstanceGroupManagerRequest, Operation> _callCreateInstances;

        private readonly gaxgrpc::ApiCall<DeleteInstanceGroupManagerRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<DeleteInstancesInstanceGroupManagerRequest, Operation> _callDeleteInstances;

        private readonly gaxgrpc::ApiCall<DeletePerInstanceConfigsInstanceGroupManagerRequest, Operation> _callDeletePerInstanceConfigs;

        private readonly gaxgrpc::ApiCall<GetInstanceGroupManagerRequest, InstanceGroupManager> _callGet;

        private readonly gaxgrpc::ApiCall<InsertInstanceGroupManagerRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListInstanceGroupManagersRequest, InstanceGroupManagerList> _callList;

        private readonly gaxgrpc::ApiCall<ListErrorsInstanceGroupManagersRequest, InstanceGroupManagersListErrorsResponse> _callListErrors;

        private readonly gaxgrpc::ApiCall<ListManagedInstancesInstanceGroupManagersRequest, InstanceGroupManagersListManagedInstancesResponse> _callListManagedInstances;

        private readonly gaxgrpc::ApiCall<ListPerInstanceConfigsInstanceGroupManagersRequest, InstanceGroupManagersListPerInstanceConfigsResp> _callListPerInstanceConfigs;

        private readonly gaxgrpc::ApiCall<PatchInstanceGroupManagerRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<PatchPerInstanceConfigsInstanceGroupManagerRequest, Operation> _callPatchPerInstanceConfigs;

        private readonly gaxgrpc::ApiCall<RecreateInstancesInstanceGroupManagerRequest, Operation> _callRecreateInstances;

        private readonly gaxgrpc::ApiCall<ResizeInstanceGroupManagerRequest, Operation> _callResize;

        private readonly gaxgrpc::ApiCall<SetInstanceTemplateInstanceGroupManagerRequest, Operation> _callSetInstanceTemplate;

        private readonly gaxgrpc::ApiCall<SetTargetPoolsInstanceGroupManagerRequest, Operation> _callSetTargetPools;

        private readonly gaxgrpc::ApiCall<UpdatePerInstanceConfigsInstanceGroupManagerRequest, Operation> _callUpdatePerInstanceConfigs;

        /// <summary>
        /// Constructs a client wrapper for the InstanceGroupManagers service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="InstanceGroupManagersSettings"/> used within this client.</param>
        public InstanceGroupManagersClientImpl(InstanceGroupManagers.InstanceGroupManagersClient grpcClient, InstanceGroupManagersSettings settings)
        {
            GrpcClient = grpcClient;
            InstanceGroupManagersSettings effectiveSettings = settings ?? InstanceGroupManagersSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAbandonInstances = clientHelper.BuildApiCall<AbandonInstancesInstanceGroupManagerRequest, Operation>(grpcClient.AbandonInstancesAsync, grpcClient.AbandonInstances, effectiveSettings.AbandonInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callAbandonInstances);
            Modify_AbandonInstancesApiCall(ref _callAbandonInstances);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListInstanceGroupManagersRequest, InstanceGroupManagerAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callApplyUpdatesToInstances = clientHelper.BuildApiCall<ApplyUpdatesToInstancesInstanceGroupManagerRequest, Operation>(grpcClient.ApplyUpdatesToInstancesAsync, grpcClient.ApplyUpdatesToInstances, effectiveSettings.ApplyUpdatesToInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callApplyUpdatesToInstances);
            Modify_ApplyUpdatesToInstancesApiCall(ref _callApplyUpdatesToInstances);
            _callCreateInstances = clientHelper.BuildApiCall<CreateInstancesInstanceGroupManagerRequest, Operation>(grpcClient.CreateInstancesAsync, grpcClient.CreateInstances, effectiveSettings.CreateInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callCreateInstances);
            Modify_CreateInstancesApiCall(ref _callCreateInstances);
            _callDelete = clientHelper.BuildApiCall<DeleteInstanceGroupManagerRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callDeleteInstances = clientHelper.BuildApiCall<DeleteInstancesInstanceGroupManagerRequest, Operation>(grpcClient.DeleteInstancesAsync, grpcClient.DeleteInstances, effectiveSettings.DeleteInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callDeleteInstances);
            Modify_DeleteInstancesApiCall(ref _callDeleteInstances);
            _callDeletePerInstanceConfigs = clientHelper.BuildApiCall<DeletePerInstanceConfigsInstanceGroupManagerRequest, Operation>(grpcClient.DeletePerInstanceConfigsAsync, grpcClient.DeletePerInstanceConfigs, effectiveSettings.DeletePerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callDeletePerInstanceConfigs);
            Modify_DeletePerInstanceConfigsApiCall(ref _callDeletePerInstanceConfigs);
            _callGet = clientHelper.BuildApiCall<GetInstanceGroupManagerRequest, InstanceGroupManager>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertInstanceGroupManagerRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListInstanceGroupManagersRequest, InstanceGroupManagerList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListErrors = clientHelper.BuildApiCall<ListErrorsInstanceGroupManagersRequest, InstanceGroupManagersListErrorsResponse>(grpcClient.ListErrorsAsync, grpcClient.ListErrors, effectiveSettings.ListErrorsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callListErrors);
            Modify_ListErrorsApiCall(ref _callListErrors);
            _callListManagedInstances = clientHelper.BuildApiCall<ListManagedInstancesInstanceGroupManagersRequest, InstanceGroupManagersListManagedInstancesResponse>(grpcClient.ListManagedInstancesAsync, grpcClient.ListManagedInstances, effectiveSettings.ListManagedInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callListManagedInstances);
            Modify_ListManagedInstancesApiCall(ref _callListManagedInstances);
            _callListPerInstanceConfigs = clientHelper.BuildApiCall<ListPerInstanceConfigsInstanceGroupManagersRequest, InstanceGroupManagersListPerInstanceConfigsResp>(grpcClient.ListPerInstanceConfigsAsync, grpcClient.ListPerInstanceConfigs, effectiveSettings.ListPerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callListPerInstanceConfigs);
            Modify_ListPerInstanceConfigsApiCall(ref _callListPerInstanceConfigs);
            _callPatch = clientHelper.BuildApiCall<PatchInstanceGroupManagerRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callPatchPerInstanceConfigs = clientHelper.BuildApiCall<PatchPerInstanceConfigsInstanceGroupManagerRequest, Operation>(grpcClient.PatchPerInstanceConfigsAsync, grpcClient.PatchPerInstanceConfigs, effectiveSettings.PatchPerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callPatchPerInstanceConfigs);
            Modify_PatchPerInstanceConfigsApiCall(ref _callPatchPerInstanceConfigs);
            _callRecreateInstances = clientHelper.BuildApiCall<RecreateInstancesInstanceGroupManagerRequest, Operation>(grpcClient.RecreateInstancesAsync, grpcClient.RecreateInstances, effectiveSettings.RecreateInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callRecreateInstances);
            Modify_RecreateInstancesApiCall(ref _callRecreateInstances);
            _callResize = clientHelper.BuildApiCall<ResizeInstanceGroupManagerRequest, Operation>(grpcClient.ResizeAsync, grpcClient.Resize, effectiveSettings.ResizeSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callResize);
            Modify_ResizeApiCall(ref _callResize);
            _callSetInstanceTemplate = clientHelper.BuildApiCall<SetInstanceTemplateInstanceGroupManagerRequest, Operation>(grpcClient.SetInstanceTemplateAsync, grpcClient.SetInstanceTemplate, effectiveSettings.SetInstanceTemplateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callSetInstanceTemplate);
            Modify_SetInstanceTemplateApiCall(ref _callSetInstanceTemplate);
            _callSetTargetPools = clientHelper.BuildApiCall<SetTargetPoolsInstanceGroupManagerRequest, Operation>(grpcClient.SetTargetPoolsAsync, grpcClient.SetTargetPools, effectiveSettings.SetTargetPoolsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callSetTargetPools);
            Modify_SetTargetPoolsApiCall(ref _callSetTargetPools);
            _callUpdatePerInstanceConfigs = clientHelper.BuildApiCall<UpdatePerInstanceConfigsInstanceGroupManagerRequest, Operation>(grpcClient.UpdatePerInstanceConfigsAsync, grpcClient.UpdatePerInstanceConfigs, effectiveSettings.UpdatePerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callUpdatePerInstanceConfigs);
            Modify_UpdatePerInstanceConfigsApiCall(ref _callUpdatePerInstanceConfigs);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AbandonInstancesApiCall(ref gaxgrpc::ApiCall<AbandonInstancesInstanceGroupManagerRequest, Operation> call);

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListInstanceGroupManagersRequest, InstanceGroupManagerAggregatedList> call);

        partial void Modify_ApplyUpdatesToInstancesApiCall(ref gaxgrpc::ApiCall<ApplyUpdatesToInstancesInstanceGroupManagerRequest, Operation> call);

        partial void Modify_CreateInstancesApiCall(ref gaxgrpc::ApiCall<CreateInstancesInstanceGroupManagerRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteInstanceGroupManagerRequest, Operation> call);

        partial void Modify_DeleteInstancesApiCall(ref gaxgrpc::ApiCall<DeleteInstancesInstanceGroupManagerRequest, Operation> call);

        partial void Modify_DeletePerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<DeletePerInstanceConfigsInstanceGroupManagerRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetInstanceGroupManagerRequest, InstanceGroupManager> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertInstanceGroupManagerRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListInstanceGroupManagersRequest, InstanceGroupManagerList> call);

        partial void Modify_ListErrorsApiCall(ref gaxgrpc::ApiCall<ListErrorsInstanceGroupManagersRequest, InstanceGroupManagersListErrorsResponse> call);

        partial void Modify_ListManagedInstancesApiCall(ref gaxgrpc::ApiCall<ListManagedInstancesInstanceGroupManagersRequest, InstanceGroupManagersListManagedInstancesResponse> call);

        partial void Modify_ListPerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<ListPerInstanceConfigsInstanceGroupManagersRequest, InstanceGroupManagersListPerInstanceConfigsResp> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchInstanceGroupManagerRequest, Operation> call);

        partial void Modify_PatchPerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<PatchPerInstanceConfigsInstanceGroupManagerRequest, Operation> call);

        partial void Modify_RecreateInstancesApiCall(ref gaxgrpc::ApiCall<RecreateInstancesInstanceGroupManagerRequest, Operation> call);

        partial void Modify_ResizeApiCall(ref gaxgrpc::ApiCall<ResizeInstanceGroupManagerRequest, Operation> call);

        partial void Modify_SetInstanceTemplateApiCall(ref gaxgrpc::ApiCall<SetInstanceTemplateInstanceGroupManagerRequest, Operation> call);

        partial void Modify_SetTargetPoolsApiCall(ref gaxgrpc::ApiCall<SetTargetPoolsInstanceGroupManagerRequest, Operation> call);

        partial void Modify_UpdatePerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<UpdatePerInstanceConfigsInstanceGroupManagerRequest, Operation> call);

        partial void OnConstruction(InstanceGroupManagers.InstanceGroupManagersClient grpcClient, InstanceGroupManagersSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC InstanceGroupManagers client</summary>
        public override InstanceGroupManagers.InstanceGroupManagersClient GrpcClient { get; }

        partial void Modify_AbandonInstancesInstanceGroupManagerRequest(ref AbandonInstancesInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AggregatedListInstanceGroupManagersRequest(ref AggregatedListInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ApplyUpdatesToInstancesInstanceGroupManagerRequest(ref ApplyUpdatesToInstancesInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_CreateInstancesInstanceGroupManagerRequest(ref CreateInstancesInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteInstanceGroupManagerRequest(ref DeleteInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteInstancesInstanceGroupManagerRequest(ref DeleteInstancesInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeletePerInstanceConfigsInstanceGroupManagerRequest(ref DeletePerInstanceConfigsInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetInstanceGroupManagerRequest(ref GetInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertInstanceGroupManagerRequest(ref InsertInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListInstanceGroupManagersRequest(ref ListInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListErrorsInstanceGroupManagersRequest(ref ListErrorsInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListManagedInstancesInstanceGroupManagersRequest(ref ListManagedInstancesInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListPerInstanceConfigsInstanceGroupManagersRequest(ref ListPerInstanceConfigsInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchInstanceGroupManagerRequest(ref PatchInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchPerInstanceConfigsInstanceGroupManagerRequest(ref PatchPerInstanceConfigsInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RecreateInstancesInstanceGroupManagerRequest(ref RecreateInstancesInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ResizeInstanceGroupManagerRequest(ref ResizeInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetInstanceTemplateInstanceGroupManagerRequest(ref SetInstanceTemplateInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetTargetPoolsInstanceGroupManagerRequest(ref SetTargetPoolsInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdatePerInstanceConfigsInstanceGroupManagerRequest(ref UpdatePerInstanceConfigsInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AbandonInstances(AbandonInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AbandonInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callAbandonInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances to be removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AbandonInstancesAsync(AbandonInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AbandonInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callAbandonInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManagerAggregatedList AggregatedList(AggregatedListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of managed instance groups and groups them by zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManagerAggregatedList> AggregatedListAsync(AggregatedListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation ApplyUpdatesToInstances(ApplyUpdatesToInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ApplyUpdatesToInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callApplyUpdatesToInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Applies changes to selected instances on the managed instance group. This method can be used to apply new overrides and/or new versions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> ApplyUpdatesToInstancesAsync(ApplyUpdatesToInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ApplyUpdatesToInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callApplyUpdatesToInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation CreateInstances(CreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callCreateInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates instances with per-instance configs in this managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> CreateInstancesAsync(CreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callCreateInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group. Note that the instance group must not belong to a backend service. Read  Deleting an instance group for more information.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DeleteInstances(DeleteInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeleteInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances in the managed instance group for immediate deletion. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. This operation is marked as DONE when the action is scheduled even if the instances are still being deleted. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteInstancesAsync(DeleteInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeleteInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DeletePerInstanceConfigs(DeletePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeletePerInstanceConfigsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeletePerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeletePerInstanceConfigsAsync(DeletePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeletePerInstanceConfigsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeletePerInstanceConfigs.Async(request, callSettings);
        }

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManager Get(GetInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns all of the details about the specified managed instance group. Gets a list of available managed instance groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManager> GetAsync(GetInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A managed instance group can have up to 1000 VM instances per group. Please contact Cloud Support if you need an increase in this limit.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManagerList List(ListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of managed instance groups that are contained within the specified project and zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManagerList> ListAsync(ListInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManagersListErrorsResponse ListErrors(ListErrorsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListErrorsInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListErrors.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManagersListErrorsResponse> ListErrorsAsync(ListErrorsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListErrorsInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListErrors.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManagersListManagedInstancesResponse ListManagedInstances(ListManagedInstancesInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListManagedInstancesInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListManagedInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all of the instances in the managed instance group. Each instance in the list has a currentAction, which indicates the action that the managed instance group is performing on the instance. For example, if the group is still creating an instance, the currentAction is CREATING. If a previous action failed, the list displays the errors for that failed action. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManagersListManagedInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListManagedInstancesInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListManagedInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManagersListPerInstanceConfigsResp ListPerInstanceConfigs(ListPerInstanceConfigsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPerInstanceConfigsInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListPerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManagersListPerInstanceConfigsResp> ListPerInstanceConfigsAsync(ListPerInstanceConfigsInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPerInstanceConfigsInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListPerInstanceConfigs.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listManagedInstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation PatchPerInstanceConfigs(PatchPerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchPerInstanceConfigsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatchPerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchPerInstanceConfigsAsync(PatchPerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchPerInstanceConfigsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatchPerInstanceConfigs.Async(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation RecreateInstances(RecreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RecreateInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callRecreateInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately recreated. The instances are deleted and recreated using the current instance template for the managed instance group. This operation is marked as DONE when the flag is set even if the instances have not yet been recreated. You must separately verify the status of the recreating action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> RecreateInstancesAsync(RecreateInstancesInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RecreateInstancesInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callRecreateInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Resize(ResizeInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResizeInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callResize.Sync(request, callSettings);
        }

        /// <summary>
        /// Resizes the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes instances. The resize operation is marked DONE when the resize actions are scheduled even if the group has not yet added or deleted any instances. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// When resizing down, the instance group arbitrarily chooses the order in which VMs are deleted. The group takes into account some VM attributes when making the selection including:
        /// 
        /// + The status of the VM instance. + The health of the VM instance. + The instance template version the VM is based on. + For regional managed instance groups, the location of the VM instance.
        /// 
        /// This list is subject to change.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> ResizeAsync(ResizeInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResizeInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callResize.Async(request, callSettings);
        }

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetInstanceTemplate(SetInstanceTemplateInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetInstanceTemplateInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetInstanceTemplate.Sync(request, callSettings);
        }

        /// <summary>
        /// Specifies the instance template to use when creating new instances in this group. The templates for existing instances in the group do not change unless you run recreateInstances, run applyUpdatesToInstances, or set the group's updatePolicy.type to PROACTIVE.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetInstanceTemplateAsync(SetInstanceTemplateInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetInstanceTemplateInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetInstanceTemplate.Async(request, callSettings);
        }

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetTargetPools(SetTargetPoolsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetTargetPoolsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetTargetPools.Sync(request, callSettings);
        }

        /// <summary>
        /// Modifies the target pools to which all instances in this managed instance group are assigned. The target pools automatically apply to all of the instances in the managed instance group. This operation is marked DONE when you make the request even if the instances have not yet been added to their target pools. The change might take some time to apply to all of the instances in the group depending on the size of the group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetTargetPoolsAsync(SetTargetPoolsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetTargetPoolsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetTargetPools.Async(request, callSettings);
        }

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation UpdatePerInstanceConfigs(UpdatePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdatePerInstanceConfigsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callUpdatePerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdatePerInstanceConfigsAsync(UpdatePerInstanceConfigsInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdatePerInstanceConfigsInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callUpdatePerInstanceConfigs.Async(request, callSettings);
        }
    }
}
