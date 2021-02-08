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
    /// <summary>Settings for <see cref="RegionInstanceGroupManagersClient"/> instances.</summary>
    public sealed partial class RegionInstanceGroupManagersSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="RegionInstanceGroupManagersSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="RegionInstanceGroupManagersSettings"/>.</returns>
        public static RegionInstanceGroupManagersSettings GetDefault() => new RegionInstanceGroupManagersSettings();

        /// <summary>
        /// Constructs a new <see cref="RegionInstanceGroupManagersSettings"/> object with default settings.
        /// </summary>
        public RegionInstanceGroupManagersSettings()
        {
        }

        private RegionInstanceGroupManagersSettings(RegionInstanceGroupManagersSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AbandonInstancesSettings = existing.AbandonInstancesSettings;
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

        partial void OnCopy(RegionInstanceGroupManagersSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>RegionInstanceGroupManagersClient.AbandonInstances</c> and
        /// <c>RegionInstanceGroupManagersClient.AbandonInstancesAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.ApplyUpdatesToInstances</c> and
        /// <c>RegionInstanceGroupManagersClient.ApplyUpdatesToInstancesAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.CreateInstances</c> and
        /// <c>RegionInstanceGroupManagersClient.CreateInstancesAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.Delete</c> and <c>RegionInstanceGroupManagersClient.DeleteAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.DeleteInstances</c> and
        /// <c>RegionInstanceGroupManagersClient.DeleteInstancesAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.DeletePerInstanceConfigs</c> and
        /// <c>RegionInstanceGroupManagersClient.DeletePerInstanceConfigsAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.Get</c> and <c>RegionInstanceGroupManagersClient.GetAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.Insert</c> and <c>RegionInstanceGroupManagersClient.InsertAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.List</c> and <c>RegionInstanceGroupManagersClient.ListAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.ListErrors</c> and <c>RegionInstanceGroupManagersClient.ListErrorsAsync</c>
        /// .
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
        /// <c>RegionInstanceGroupManagersClient.ListManagedInstances</c> and
        /// <c>RegionInstanceGroupManagersClient.ListManagedInstancesAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.ListPerInstanceConfigs</c> and
        /// <c>RegionInstanceGroupManagersClient.ListPerInstanceConfigsAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.Patch</c> and <c>RegionInstanceGroupManagersClient.PatchAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.PatchPerInstanceConfigs</c> and
        /// <c>RegionInstanceGroupManagersClient.PatchPerInstanceConfigsAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.RecreateInstances</c> and
        /// <c>RegionInstanceGroupManagersClient.RecreateInstancesAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.Resize</c> and <c>RegionInstanceGroupManagersClient.ResizeAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.SetInstanceTemplate</c> and
        /// <c>RegionInstanceGroupManagersClient.SetInstanceTemplateAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.SetTargetPools</c> and
        /// <c>RegionInstanceGroupManagersClient.SetTargetPoolsAsync</c>.
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
        /// <c>RegionInstanceGroupManagersClient.UpdatePerInstanceConfigs</c> and
        /// <c>RegionInstanceGroupManagersClient.UpdatePerInstanceConfigsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdatePerInstanceConfigsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="RegionInstanceGroupManagersSettings"/> object.</returns>
        public RegionInstanceGroupManagersSettings Clone() => new RegionInstanceGroupManagersSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="RegionInstanceGroupManagersClient"/> to provide simple configuration of
    /// credentials, endpoint etc.
    /// </summary>
    public sealed partial class RegionInstanceGroupManagersClientBuilder : gaxgrpc::ClientBuilderBase<RegionInstanceGroupManagersClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public RegionInstanceGroupManagersSettings Settings { get; set; }

        partial void InterceptBuild(ref RegionInstanceGroupManagersClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<RegionInstanceGroupManagersClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override RegionInstanceGroupManagersClient Build()
        {
            RegionInstanceGroupManagersClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<RegionInstanceGroupManagersClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<RegionInstanceGroupManagersClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private RegionInstanceGroupManagersClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return RegionInstanceGroupManagersClient.Create(callInvoker, Settings);
        }

        private async stt::Task<RegionInstanceGroupManagersClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return RegionInstanceGroupManagersClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => RegionInstanceGroupManagersClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => RegionInstanceGroupManagersClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => RegionInstanceGroupManagersClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>RegionInstanceGroupManagers client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The RegionInstanceGroupManagers API.
    /// </remarks>
    public abstract partial class RegionInstanceGroupManagersClient
    {
        /// <summary>
        /// The default endpoint for the RegionInstanceGroupManagers service, which is a host of
        /// "compute.googleapis.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default RegionInstanceGroupManagers scopes.</summary>
        /// <remarks>
        /// The default RegionInstanceGroupManagers scopes are:
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
        /// Asynchronously creates a <see cref="RegionInstanceGroupManagersClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="RegionInstanceGroupManagersClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="RegionInstanceGroupManagersClient"/>.</returns>
        public static stt::Task<RegionInstanceGroupManagersClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new RegionInstanceGroupManagersClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="RegionInstanceGroupManagersClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="RegionInstanceGroupManagersClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="RegionInstanceGroupManagersClient"/>.</returns>
        public static RegionInstanceGroupManagersClient Create() => new RegionInstanceGroupManagersClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="RegionInstanceGroupManagersClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="RegionInstanceGroupManagersSettings"/>.</param>
        /// <returns>The created <see cref="RegionInstanceGroupManagersClient"/>.</returns>
        internal static RegionInstanceGroupManagersClient Create(grpccore::CallInvoker callInvoker, RegionInstanceGroupManagersSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            RegionInstanceGroupManagers.RegionInstanceGroupManagersClient grpcClient = new RegionInstanceGroupManagers.RegionInstanceGroupManagersClient(callInvoker);
            return new RegionInstanceGroupManagersClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC RegionInstanceGroupManagers client</summary>
        public virtual RegionInstanceGroupManagers.RegionInstanceGroupManagersClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AbandonInstances(AbandonInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(AbandonInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(AbandonInstancesRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            AbandonInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersAbandonInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AbandonInstances(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersAbandonInstancesRequest regionInstanceGroupManagersAbandonInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AbandonInstances(new AbandonInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersAbandonInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersAbandonInstancesRequestResource, nameof(regionInstanceGroupManagersAbandonInstancesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersAbandonInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersAbandonInstancesRequest regionInstanceGroupManagersAbandonInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AbandonInstancesAsync(new AbandonInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersAbandonInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersAbandonInstancesRequestResource, nameof(regionInstanceGroupManagersAbandonInstancesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersAbandonInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AbandonInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersAbandonInstancesRequest regionInstanceGroupManagersAbandonInstancesRequestResource, st::CancellationToken cancellationToken) =>
            AbandonInstancesAsync(project, region, instanceGroupManager, regionInstanceGroupManagersAbandonInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation ApplyUpdatesToInstances(ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            ApplyUpdatesToInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group, should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagersApplyUpdatesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation ApplyUpdatesToInstances(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersApplyUpdatesRequest regionInstanceGroupManagersApplyUpdatesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ApplyUpdatesToInstances(new ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersApplyUpdatesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersApplyUpdatesRequestResource, nameof(regionInstanceGroupManagersApplyUpdatesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group, should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagersApplyUpdatesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersApplyUpdatesRequest regionInstanceGroupManagersApplyUpdatesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ApplyUpdatesToInstancesAsync(new ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersApplyUpdatesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersApplyUpdatesRequestResource, nameof(regionInstanceGroupManagersApplyUpdatesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group, should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagersApplyUpdatesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ApplyUpdatesToInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersApplyUpdatesRequest regionInstanceGroupManagersApplyUpdatesRequestResource, st::CancellationToken cancellationToken) =>
            ApplyUpdatesToInstancesAsync(project, region, instanceGroupManager, regionInstanceGroupManagersApplyUpdatesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation CreateInstances(CreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(CreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(CreateInstancesRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            CreateInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The name of the region where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagersCreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation CreateInstances(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersCreateInstancesRequest regionInstanceGroupManagersCreateInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            CreateInstances(new CreateInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersCreateInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersCreateInstancesRequestResource, nameof(regionInstanceGroupManagersCreateInstancesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The name of the region where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagersCreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersCreateInstancesRequest regionInstanceGroupManagersCreateInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            CreateInstancesAsync(new CreateInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersCreateInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersCreateInstancesRequestResource, nameof(regionInstanceGroupManagersCreateInstancesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The name of the region where the managed instance group is located. It should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagersCreateInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> CreateInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersCreateInstancesRequest regionInstanceGroupManagersCreateInstancesRequestResource, st::CancellationToken cancellationToken) =>
            CreateInstancesAsync(project, region, instanceGroupManager, regionInstanceGroupManagersCreateInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteInstances(DeleteInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(DeleteInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(DeleteInstancesRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            DeleteInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersDeleteInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteInstances(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersDeleteInstancesRequest regionInstanceGroupManagersDeleteInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DeleteInstances(new DeleteInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersDeleteInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersDeleteInstancesRequestResource, nameof(regionInstanceGroupManagersDeleteInstancesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersDeleteInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersDeleteInstancesRequest regionInstanceGroupManagersDeleteInstancesRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DeleteInstancesAsync(new DeleteInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersDeleteInstancesRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersDeleteInstancesRequestResource, nameof(regionInstanceGroupManagersDeleteInstancesRequestResource)),
            }, callSettings);

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersDeleteInstancesRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersDeleteInstancesRequest regionInstanceGroupManagersDeleteInstancesRequestResource, st::CancellationToken cancellationToken) =>
            DeleteInstancesAsync(project, region, instanceGroupManager, regionInstanceGroupManagersDeleteInstancesRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeletePerInstanceConfigs(DeletePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(DeletePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(DeletePerInstanceConfigsRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            DeletePerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerDeleteInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeletePerInstanceConfigs(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerDeleteInstanceConfigReq regionInstanceGroupManagerDeleteInstanceConfigReqResource, gaxgrpc::CallSettings callSettings = null) =>
            DeletePerInstanceConfigs(new DeletePerInstanceConfigsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagerDeleteInstanceConfigReqResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagerDeleteInstanceConfigReqResource, nameof(regionInstanceGroupManagerDeleteInstanceConfigReqResource)),
            }, callSettings);

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerDeleteInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerDeleteInstanceConfigReq regionInstanceGroupManagerDeleteInstanceConfigReqResource, gaxgrpc::CallSettings callSettings = null) =>
            DeletePerInstanceConfigsAsync(new DeletePerInstanceConfigsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagerDeleteInstanceConfigReqResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagerDeleteInstanceConfigReqResource, nameof(regionInstanceGroupManagerDeleteInstanceConfigReqResource)),
            }, callSettings);

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerDeleteInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeletePerInstanceConfigsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerDeleteInstanceConfigReq regionInstanceGroupManagerDeleteInstanceConfigReqResource, st::CancellationToken cancellationToken) =>
            DeletePerInstanceConfigsAsync(project, region, instanceGroupManager, regionInstanceGroupManagerDeleteInstanceConfigReqResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManager Get(GetRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(GetRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(GetRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InstanceGroupManager Get(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InstanceGroupManager> GetAsync(string project, string region, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertRegionInstanceGroupManagerRequest
            {
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertRegionInstanceGroupManagerRequest
            {
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, InstanceGroupManager instanceGroupManagerResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, instanceGroupManagerResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagerList List(ListRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagerList> ListAsync(ListRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagerList> ListAsync(ListRegionInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagerList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListRegionInstanceGroupManagersRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagerList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListRegionInstanceGroupManagersRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagerList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagersListErrorsResponse ListErrors(ListErrorsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListErrorsResponse> ListErrorsAsync(ListErrorsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListErrorsResponse> ListErrorsAsync(ListErrorsRegionInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListErrorsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request. This should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It must be a string that meets the requirements in RFC1035, or an unsigned long integer: must match regexp pattern: (?:[a-z](?:[-a-z0-9]{0,61}[a-z0-9])?)|[1-9][0-9]{0,19}.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagersListErrorsResponse ListErrors(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListErrors(new ListErrorsRegionInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request. This should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It must be a string that meets the requirements in RFC1035, or an unsigned long integer: must match regexp pattern: (?:[a-z](?:[-a-z0-9]{0,61}[a-z0-9])?)|[1-9][0-9]{0,19}.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListErrorsResponse> ListErrorsAsync(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListErrorsAsync(new ListErrorsRegionInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request. This should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It must be a string that meets the requirements in RFC1035, or an unsigned long integer: must match regexp pattern: (?:[a-z](?:[-a-z0-9]{0,61}[a-z0-9])?)|[1-9][0-9]{0,19}.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListErrorsResponse> ListErrorsAsync(string project, string region, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            ListErrorsAsync(project, region, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagersListInstancesResponse ListManagedInstances(ListManagedInstancesRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesRegionInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListManagedInstancesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagersListInstancesResponse ListManagedInstances(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListManagedInstances(new ListManagedInstancesRegionInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstancesResponse> ListManagedInstancesAsync(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListManagedInstancesAsync(new ListManagedInstancesRegionInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstancesResponse> ListManagedInstancesAsync(string project, string region, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            ListManagedInstancesAsync(project, region, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagersListInstanceConfigsResp ListPerInstanceConfigs(ListPerInstanceConfigsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstanceConfigsResp> ListPerInstanceConfigsAsync(ListPerInstanceConfigsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstanceConfigsResp> ListPerInstanceConfigsAsync(ListPerInstanceConfigsRegionInstanceGroupManagersRequest request, st::CancellationToken cancellationToken) =>
            ListPerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionInstanceGroupManagersListInstanceConfigsResp ListPerInstanceConfigs(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListPerInstanceConfigs(new ListPerInstanceConfigsRegionInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstanceConfigsResp> ListPerInstanceConfigsAsync(string project, string region, string instanceGroupManager, gaxgrpc::CallSettings callSettings = null) =>
            ListPerInstanceConfigsAsync(new ListPerInstanceConfigsRegionInstanceGroupManagersRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionInstanceGroupManagersListInstanceConfigsResp> ListPerInstanceConfigsAsync(string project, string region, string instanceGroupManager, st::CancellationToken cancellationToken) =>
            ListPerInstanceConfigsAsync(project, region, instanceGroupManager, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the instance group manager.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string region, string instanceGroupManager, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the instance group manager.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string region, string instanceGroupManager, InstanceGroupManager instanceGroupManagerResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                InstanceGroupManagerResource = gax::GaxPreconditions.CheckNotNull(instanceGroupManagerResource, nameof(instanceGroupManagerResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the instance group manager.
        /// </param>
        /// <param name="instanceGroupManagerResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string region, string instanceGroupManager, InstanceGroupManager instanceGroupManagerResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, region, instanceGroupManager, instanceGroupManagerResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation PatchPerInstanceConfigs(PatchPerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(PatchPerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(PatchPerInstanceConfigsRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            PatchPerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerPatchInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation PatchPerInstanceConfigs(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerPatchInstanceConfigReq regionInstanceGroupManagerPatchInstanceConfigReqResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchPerInstanceConfigs(new PatchPerInstanceConfigsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagerPatchInstanceConfigReqResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagerPatchInstanceConfigReqResource, nameof(regionInstanceGroupManagerPatchInstanceConfigReqResource)),
            }, callSettings);

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerPatchInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerPatchInstanceConfigReq regionInstanceGroupManagerPatchInstanceConfigReqResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchPerInstanceConfigsAsync(new PatchPerInstanceConfigsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagerPatchInstanceConfigReqResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagerPatchInstanceConfigReqResource, nameof(regionInstanceGroupManagerPatchInstanceConfigReqResource)),
            }, callSettings);

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerPatchInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchPerInstanceConfigsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerPatchInstanceConfigReq regionInstanceGroupManagerPatchInstanceConfigReqResource, st::CancellationToken cancellationToken) =>
            PatchPerInstanceConfigsAsync(project, region, instanceGroupManager, regionInstanceGroupManagerPatchInstanceConfigReqResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

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
        public virtual Operation RecreateInstances(RecreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
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
        public virtual stt::Task<Operation> RecreateInstancesAsync(RecreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
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
        public virtual stt::Task<Operation> RecreateInstancesAsync(RecreateInstancesRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
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
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersRecreateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RecreateInstances(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersRecreateRequest regionInstanceGroupManagersRecreateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RecreateInstances(new RecreateInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersRecreateRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersRecreateRequestResource, nameof(regionInstanceGroupManagersRecreateRequestResource)),
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
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersRecreateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RecreateInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersRecreateRequest regionInstanceGroupManagersRecreateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RecreateInstancesAsync(new RecreateInstancesRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersRecreateRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersRecreateRequestResource, nameof(regionInstanceGroupManagersRecreateRequestResource)),
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
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersRecreateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RecreateInstancesAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersRecreateRequest regionInstanceGroupManagersRecreateRequestResource, st::CancellationToken cancellationToken) =>
            RecreateInstancesAsync(project, region, instanceGroupManager, regionInstanceGroupManagersRecreateRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Resize(ResizeRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(ResizeRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(ResizeRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            ResizeAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="size">
        /// Number of instances that should exist in this instance group manager.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Resize(string project, string region, string instanceGroupManager, int size, gaxgrpc::CallSettings callSettings = null) =>
            Resize(new ResizeRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                Size = size,
            }, callSettings);

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="size">
        /// Number of instances that should exist in this instance group manager.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(string project, string region, string instanceGroupManager, int size, gaxgrpc::CallSettings callSettings = null) =>
            ResizeAsync(new ResizeRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                Size = size,
            }, callSettings);

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="size">
        /// Number of instances that should exist in this instance group manager.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> ResizeAsync(string project, string region, string instanceGroupManager, int size, st::CancellationToken cancellationToken) =>
            ResizeAsync(project, region, instanceGroupManager, size, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetInstanceTemplate(SetInstanceTemplateRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(SetInstanceTemplateRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(SetInstanceTemplateRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            SetInstanceTemplateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersSetTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetInstanceTemplate(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersSetTemplateRequest regionInstanceGroupManagersSetTemplateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetInstanceTemplate(new SetInstanceTemplateRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersSetTemplateRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersSetTemplateRequestResource, nameof(regionInstanceGroupManagersSetTemplateRequestResource)),
            }, callSettings);

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersSetTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersSetTemplateRequest regionInstanceGroupManagersSetTemplateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetInstanceTemplateAsync(new SetInstanceTemplateRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersSetTemplateRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersSetTemplateRequestResource, nameof(regionInstanceGroupManagersSetTemplateRequestResource)),
            }, callSettings);

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersSetTemplateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetInstanceTemplateAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersSetTemplateRequest regionInstanceGroupManagersSetTemplateRequestResource, st::CancellationToken cancellationToken) =>
            SetInstanceTemplateAsync(project, region, instanceGroupManager, regionInstanceGroupManagersSetTemplateRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetTargetPools(SetTargetPoolsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(SetTargetPoolsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(SetTargetPoolsRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            SetTargetPoolsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersSetTargetPoolsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetTargetPools(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersSetTargetPoolsRequest regionInstanceGroupManagersSetTargetPoolsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetTargetPools(new SetTargetPoolsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersSetTargetPoolsRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersSetTargetPoolsRequestResource, nameof(regionInstanceGroupManagersSetTargetPoolsRequestResource)),
            }, callSettings);

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersSetTargetPoolsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersSetTargetPoolsRequest regionInstanceGroupManagersSetTargetPoolsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetTargetPoolsAsync(new SetTargetPoolsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagersSetTargetPoolsRequestResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagersSetTargetPoolsRequestResource, nameof(regionInstanceGroupManagersSetTargetPoolsRequestResource)),
            }, callSettings);

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="instanceGroupManager">
        /// Name of the managed instance group.
        /// </param>
        /// <param name="regionInstanceGroupManagersSetTargetPoolsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetPoolsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagersSetTargetPoolsRequest regionInstanceGroupManagersSetTargetPoolsRequestResource, st::CancellationToken cancellationToken) =>
            SetTargetPoolsAsync(project, region, instanceGroupManager, regionInstanceGroupManagersSetTargetPoolsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation UpdatePerInstanceConfigs(UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest request, st::CancellationToken cancellationToken) =>
            UpdatePerInstanceConfigsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerUpdateInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation UpdatePerInstanceConfigs(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerUpdateInstanceConfigReq regionInstanceGroupManagerUpdateInstanceConfigReqResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdatePerInstanceConfigs(new UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagerUpdateInstanceConfigReqResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagerUpdateInstanceConfigReqResource, nameof(regionInstanceGroupManagerUpdateInstanceConfigReqResource)),
            }, callSettings);

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerUpdateInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerUpdateInstanceConfigReq regionInstanceGroupManagerUpdateInstanceConfigReqResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdatePerInstanceConfigsAsync(new UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest
            {
                InstanceGroupManager = gax::GaxPreconditions.CheckNotNullOrEmpty(instanceGroupManager, nameof(instanceGroupManager)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionInstanceGroupManagerUpdateInstanceConfigReqResource = gax::GaxPreconditions.CheckNotNull(regionInstanceGroupManagerUpdateInstanceConfigReqResource, nameof(regionInstanceGroupManagerUpdateInstanceConfigReqResource)),
            }, callSettings);

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request, should conform to RFC1035.
        /// </param>
        /// <param name="instanceGroupManager">
        /// The name of the managed instance group. It should conform to RFC1035.
        /// </param>
        /// <param name="regionInstanceGroupManagerUpdateInstanceConfigReqResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePerInstanceConfigsAsync(string project, string region, string instanceGroupManager, RegionInstanceGroupManagerUpdateInstanceConfigReq regionInstanceGroupManagerUpdateInstanceConfigReqResource, st::CancellationToken cancellationToken) =>
            UpdatePerInstanceConfigsAsync(project, region, instanceGroupManager, regionInstanceGroupManagerUpdateInstanceConfigReqResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>RegionInstanceGroupManagers client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The RegionInstanceGroupManagers API.
    /// </remarks>
    public sealed partial class RegionInstanceGroupManagersClientImpl : RegionInstanceGroupManagersClient
    {
        private readonly gaxgrpc::ApiCall<AbandonInstancesRegionInstanceGroupManagerRequest, Operation> _callAbandonInstances;

        private readonly gaxgrpc::ApiCall<ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest, Operation> _callApplyUpdatesToInstances;

        private readonly gaxgrpc::ApiCall<CreateInstancesRegionInstanceGroupManagerRequest, Operation> _callCreateInstances;

        private readonly gaxgrpc::ApiCall<DeleteRegionInstanceGroupManagerRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<DeleteInstancesRegionInstanceGroupManagerRequest, Operation> _callDeleteInstances;

        private readonly gaxgrpc::ApiCall<DeletePerInstanceConfigsRegionInstanceGroupManagerRequest, Operation> _callDeletePerInstanceConfigs;

        private readonly gaxgrpc::ApiCall<GetRegionInstanceGroupManagerRequest, InstanceGroupManager> _callGet;

        private readonly gaxgrpc::ApiCall<InsertRegionInstanceGroupManagerRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListRegionInstanceGroupManagersRequest, RegionInstanceGroupManagerList> _callList;

        private readonly gaxgrpc::ApiCall<ListErrorsRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListErrorsResponse> _callListErrors;

        private readonly gaxgrpc::ApiCall<ListManagedInstancesRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListInstancesResponse> _callListManagedInstances;

        private readonly gaxgrpc::ApiCall<ListPerInstanceConfigsRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListInstanceConfigsResp> _callListPerInstanceConfigs;

        private readonly gaxgrpc::ApiCall<PatchRegionInstanceGroupManagerRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<PatchPerInstanceConfigsRegionInstanceGroupManagerRequest, Operation> _callPatchPerInstanceConfigs;

        private readonly gaxgrpc::ApiCall<RecreateInstancesRegionInstanceGroupManagerRequest, Operation> _callRecreateInstances;

        private readonly gaxgrpc::ApiCall<ResizeRegionInstanceGroupManagerRequest, Operation> _callResize;

        private readonly gaxgrpc::ApiCall<SetInstanceTemplateRegionInstanceGroupManagerRequest, Operation> _callSetInstanceTemplate;

        private readonly gaxgrpc::ApiCall<SetTargetPoolsRegionInstanceGroupManagerRequest, Operation> _callSetTargetPools;

        private readonly gaxgrpc::ApiCall<UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest, Operation> _callUpdatePerInstanceConfigs;

        /// <summary>
        /// Constructs a client wrapper for the RegionInstanceGroupManagers service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="RegionInstanceGroupManagersSettings"/> used within this client.
        /// </param>
        public RegionInstanceGroupManagersClientImpl(RegionInstanceGroupManagers.RegionInstanceGroupManagersClient grpcClient, RegionInstanceGroupManagersSettings settings)
        {
            GrpcClient = grpcClient;
            RegionInstanceGroupManagersSettings effectiveSettings = settings ?? RegionInstanceGroupManagersSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAbandonInstances = clientHelper.BuildApiCall<AbandonInstancesRegionInstanceGroupManagerRequest, Operation>(grpcClient.AbandonInstancesAsync, grpcClient.AbandonInstances, effectiveSettings.AbandonInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callAbandonInstances);
            Modify_AbandonInstancesApiCall(ref _callAbandonInstances);
            _callApplyUpdatesToInstances = clientHelper.BuildApiCall<ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest, Operation>(grpcClient.ApplyUpdatesToInstancesAsync, grpcClient.ApplyUpdatesToInstances, effectiveSettings.ApplyUpdatesToInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callApplyUpdatesToInstances);
            Modify_ApplyUpdatesToInstancesApiCall(ref _callApplyUpdatesToInstances);
            _callCreateInstances = clientHelper.BuildApiCall<CreateInstancesRegionInstanceGroupManagerRequest, Operation>(grpcClient.CreateInstancesAsync, grpcClient.CreateInstances, effectiveSettings.CreateInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callCreateInstances);
            Modify_CreateInstancesApiCall(ref _callCreateInstances);
            _callDelete = clientHelper.BuildApiCall<DeleteRegionInstanceGroupManagerRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callDeleteInstances = clientHelper.BuildApiCall<DeleteInstancesRegionInstanceGroupManagerRequest, Operation>(grpcClient.DeleteInstancesAsync, grpcClient.DeleteInstances, effectiveSettings.DeleteInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callDeleteInstances);
            Modify_DeleteInstancesApiCall(ref _callDeleteInstances);
            _callDeletePerInstanceConfigs = clientHelper.BuildApiCall<DeletePerInstanceConfigsRegionInstanceGroupManagerRequest, Operation>(grpcClient.DeletePerInstanceConfigsAsync, grpcClient.DeletePerInstanceConfigs, effectiveSettings.DeletePerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callDeletePerInstanceConfigs);
            Modify_DeletePerInstanceConfigsApiCall(ref _callDeletePerInstanceConfigs);
            _callGet = clientHelper.BuildApiCall<GetRegionInstanceGroupManagerRequest, InstanceGroupManager>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertRegionInstanceGroupManagerRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListRegionInstanceGroupManagersRequest, RegionInstanceGroupManagerList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListErrors = clientHelper.BuildApiCall<ListErrorsRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListErrorsResponse>(grpcClient.ListErrorsAsync, grpcClient.ListErrors, effectiveSettings.ListErrorsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callListErrors);
            Modify_ListErrorsApiCall(ref _callListErrors);
            _callListManagedInstances = clientHelper.BuildApiCall<ListManagedInstancesRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListInstancesResponse>(grpcClient.ListManagedInstancesAsync, grpcClient.ListManagedInstances, effectiveSettings.ListManagedInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callListManagedInstances);
            Modify_ListManagedInstancesApiCall(ref _callListManagedInstances);
            _callListPerInstanceConfigs = clientHelper.BuildApiCall<ListPerInstanceConfigsRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListInstanceConfigsResp>(grpcClient.ListPerInstanceConfigsAsync, grpcClient.ListPerInstanceConfigs, effectiveSettings.ListPerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callListPerInstanceConfigs);
            Modify_ListPerInstanceConfigsApiCall(ref _callListPerInstanceConfigs);
            _callPatch = clientHelper.BuildApiCall<PatchRegionInstanceGroupManagerRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callPatchPerInstanceConfigs = clientHelper.BuildApiCall<PatchPerInstanceConfigsRegionInstanceGroupManagerRequest, Operation>(grpcClient.PatchPerInstanceConfigsAsync, grpcClient.PatchPerInstanceConfigs, effectiveSettings.PatchPerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callPatchPerInstanceConfigs);
            Modify_PatchPerInstanceConfigsApiCall(ref _callPatchPerInstanceConfigs);
            _callRecreateInstances = clientHelper.BuildApiCall<RecreateInstancesRegionInstanceGroupManagerRequest, Operation>(grpcClient.RecreateInstancesAsync, grpcClient.RecreateInstances, effectiveSettings.RecreateInstancesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callRecreateInstances);
            Modify_RecreateInstancesApiCall(ref _callRecreateInstances);
            _callResize = clientHelper.BuildApiCall<ResizeRegionInstanceGroupManagerRequest, Operation>(grpcClient.ResizeAsync, grpcClient.Resize, effectiveSettings.ResizeSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callResize);
            Modify_ResizeApiCall(ref _callResize);
            _callSetInstanceTemplate = clientHelper.BuildApiCall<SetInstanceTemplateRegionInstanceGroupManagerRequest, Operation>(grpcClient.SetInstanceTemplateAsync, grpcClient.SetInstanceTemplate, effectiveSettings.SetInstanceTemplateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callSetInstanceTemplate);
            Modify_SetInstanceTemplateApiCall(ref _callSetInstanceTemplate);
            _callSetTargetPools = clientHelper.BuildApiCall<SetTargetPoolsRegionInstanceGroupManagerRequest, Operation>(grpcClient.SetTargetPoolsAsync, grpcClient.SetTargetPools, effectiveSettings.SetTargetPoolsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callSetTargetPools);
            Modify_SetTargetPoolsApiCall(ref _callSetTargetPools);
            _callUpdatePerInstanceConfigs = clientHelper.BuildApiCall<UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest, Operation>(grpcClient.UpdatePerInstanceConfigsAsync, grpcClient.UpdatePerInstanceConfigs, effectiveSettings.UpdatePerInstanceConfigsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("instance_group_manager", request => request.InstanceGroupManager);
            Modify_ApiCall(ref _callUpdatePerInstanceConfigs);
            Modify_UpdatePerInstanceConfigsApiCall(ref _callUpdatePerInstanceConfigs);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AbandonInstancesApiCall(ref gaxgrpc::ApiCall<AbandonInstancesRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_ApplyUpdatesToInstancesApiCall(ref gaxgrpc::ApiCall<ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_CreateInstancesApiCall(ref gaxgrpc::ApiCall<CreateInstancesRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_DeleteInstancesApiCall(ref gaxgrpc::ApiCall<DeleteInstancesRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_DeletePerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<DeletePerInstanceConfigsRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetRegionInstanceGroupManagerRequest, InstanceGroupManager> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListRegionInstanceGroupManagersRequest, RegionInstanceGroupManagerList> call);

        partial void Modify_ListErrorsApiCall(ref gaxgrpc::ApiCall<ListErrorsRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListErrorsResponse> call);

        partial void Modify_ListManagedInstancesApiCall(ref gaxgrpc::ApiCall<ListManagedInstancesRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListInstancesResponse> call);

        partial void Modify_ListPerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<ListPerInstanceConfigsRegionInstanceGroupManagersRequest, RegionInstanceGroupManagersListInstanceConfigsResp> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_PatchPerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<PatchPerInstanceConfigsRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_RecreateInstancesApiCall(ref gaxgrpc::ApiCall<RecreateInstancesRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_ResizeApiCall(ref gaxgrpc::ApiCall<ResizeRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_SetInstanceTemplateApiCall(ref gaxgrpc::ApiCall<SetInstanceTemplateRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_SetTargetPoolsApiCall(ref gaxgrpc::ApiCall<SetTargetPoolsRegionInstanceGroupManagerRequest, Operation> call);

        partial void Modify_UpdatePerInstanceConfigsApiCall(ref gaxgrpc::ApiCall<UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest, Operation> call);

        partial void OnConstruction(RegionInstanceGroupManagers.RegionInstanceGroupManagersClient grpcClient, RegionInstanceGroupManagersSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC RegionInstanceGroupManagers client</summary>
        public override RegionInstanceGroupManagers.RegionInstanceGroupManagersClient GrpcClient { get; }

        partial void Modify_AbandonInstancesRegionInstanceGroupManagerRequest(ref AbandonInstancesRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest(ref ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_CreateInstancesRegionInstanceGroupManagerRequest(ref CreateInstancesRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteRegionInstanceGroupManagerRequest(ref DeleteRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteInstancesRegionInstanceGroupManagerRequest(ref DeleteInstancesRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeletePerInstanceConfigsRegionInstanceGroupManagerRequest(ref DeletePerInstanceConfigsRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRegionInstanceGroupManagerRequest(ref GetRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertRegionInstanceGroupManagerRequest(ref InsertRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRegionInstanceGroupManagersRequest(ref ListRegionInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListErrorsRegionInstanceGroupManagersRequest(ref ListErrorsRegionInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListManagedInstancesRegionInstanceGroupManagersRequest(ref ListManagedInstancesRegionInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListPerInstanceConfigsRegionInstanceGroupManagersRequest(ref ListPerInstanceConfigsRegionInstanceGroupManagersRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchRegionInstanceGroupManagerRequest(ref PatchRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchPerInstanceConfigsRegionInstanceGroupManagerRequest(ref PatchPerInstanceConfigsRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RecreateInstancesRegionInstanceGroupManagerRequest(ref RecreateInstancesRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ResizeRegionInstanceGroupManagerRequest(ref ResizeRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetInstanceTemplateRegionInstanceGroupManagerRequest(ref SetInstanceTemplateRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetTargetPoolsRegionInstanceGroupManagerRequest(ref SetTargetPoolsRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest(ref UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AbandonInstances(AbandonInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AbandonInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callAbandonInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances to be immediately removed from the managed instance group. Abandoning an instance does not delete the instance, but it does remove the instance from any target pools that are applied by the managed instance group. This method reduces the targetSize of the managed instance group by the number of instances that you abandon. This operation is marked as DONE when the action is scheduled even if the instances have not yet been removed from the group. You must separately verify the status of the abandoning action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AbandonInstancesAsync(AbandonInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AbandonInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callAbandonInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation ApplyUpdatesToInstances(ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callApplyUpdatesToInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Apply updates to selected instances the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> ApplyUpdatesToInstancesAsync(ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ApplyUpdatesToInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callApplyUpdatesToInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation CreateInstances(CreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callCreateInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates instances with per-instance configs in this regional managed instance group. Instances are created using the current instance template. The create instances operation is marked DONE if the createInstances request is successful. The underlying actions take additional time. You must separately verify the status of the creating or actions with the listmanagedinstances method.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> CreateInstancesAsync(CreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_CreateInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callCreateInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified managed instance group and all of the instances in that group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DeleteInstances(DeleteInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeleteInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Flags the specified instances in the managed instance group to be immediately deleted. The instances are also removed from any target pools of which they were a member. This method reduces the targetSize of the managed instance group by the number of instances that you delete. The deleteInstances operation is marked DONE if the deleteInstances request is successful. The underlying actions take additional time. You must separately verify the status of the deleting action with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// 
        /// You can specify a maximum of 1000 instances with this method per request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteInstancesAsync(DeleteInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeleteInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DeletePerInstanceConfigs(DeletePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeletePerInstanceConfigsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeletePerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes selected per-instance configs for the managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeletePerInstanceConfigsAsync(DeletePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeletePerInstanceConfigsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callDeletePerInstanceConfigs.Async(request, callSettings);
        }

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InstanceGroupManager Get(GetRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns all of the details about the specified managed instance group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InstanceGroupManager> GetAsync(GetRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a managed instance group using the information that you specify in the request. After the group is created, instances in the group are created using the specified instance template. This operation is marked as DONE when the group is created even if the instances in the group have not yet been created. You must separately verify the status of the individual instances with the listmanagedinstances method.
        /// 
        /// A regional managed instance group can contain up to 2000 instances.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RegionInstanceGroupManagerList List(ListRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of managed instance groups that are contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RegionInstanceGroupManagerList> ListAsync(ListRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RegionInstanceGroupManagersListErrorsResponse ListErrors(ListErrorsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListErrorsRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListErrors.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all errors thrown by actions on instances for a given regional managed instance group. The filter and orderBy query parameters are not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RegionInstanceGroupManagersListErrorsResponse> ListErrorsAsync(ListErrorsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListErrorsRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListErrors.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RegionInstanceGroupManagersListInstancesResponse ListManagedInstances(ListManagedInstancesRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListManagedInstancesRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListManagedInstances.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists the instances in the managed instance group and instances that are scheduled to be created. The list includes any current actions that the group has scheduled for its instances. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RegionInstanceGroupManagersListInstancesResponse> ListManagedInstancesAsync(ListManagedInstancesRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListManagedInstancesRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListManagedInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RegionInstanceGroupManagersListInstanceConfigsResp ListPerInstanceConfigs(ListPerInstanceConfigsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPerInstanceConfigsRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListPerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all of the per-instance configs defined for the managed instance group. The orderBy query parameter is not supported.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RegionInstanceGroupManagersListInstanceConfigsResp> ListPerInstanceConfigsAsync(ListPerInstanceConfigsRegionInstanceGroupManagersRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPerInstanceConfigsRegionInstanceGroupManagersRequest(ref request, ref callSettings);
            return _callListPerInstanceConfigs.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a managed instance group using the information that you specify in the request. This operation is marked as DONE when the group is patched even if the instances in the group are still in the process of being patched. You must separately verify the status of the individual instances with the listmanagedinstances method. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation PatchPerInstanceConfigs(PatchPerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchPerInstanceConfigsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callPatchPerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Inserts or patches per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchPerInstanceConfigsAsync(PatchPerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchPerInstanceConfigsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
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
        public override Operation RecreateInstances(RecreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RecreateInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
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
        public override stt::Task<Operation> RecreateInstancesAsync(RecreateInstancesRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RecreateInstancesRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callRecreateInstances.Async(request, callSettings);
        }

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Resize(ResizeRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResizeRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callResize.Sync(request, callSettings);
        }

        /// <summary>
        /// Changes the intended size of the managed instance group. If you increase the size, the group creates new instances using the current instance template. If you decrease the size, the group deletes one or more instances.
        /// 
        /// The resize operation is marked DONE if the resize request is successful. The underlying actions take additional time. You must separately verify the status of the creating or deleting actions with the listmanagedinstances method.
        /// 
        /// If the group is part of a backend service that has enabled connection draining, it can take up to 60 seconds after the connection draining duration has elapsed before the VM instance is removed or deleted.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> ResizeAsync(ResizeRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ResizeRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callResize.Async(request, callSettings);
        }

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetInstanceTemplate(SetInstanceTemplateRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetInstanceTemplateRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetInstanceTemplate.Sync(request, callSettings);
        }

        /// <summary>
        /// Sets the instance template to use when creating new instances or recreating instances in this group. Existing instances are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetInstanceTemplateAsync(SetInstanceTemplateRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetInstanceTemplateRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetInstanceTemplate.Async(request, callSettings);
        }

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetTargetPools(SetTargetPoolsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetTargetPoolsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetTargetPools.Sync(request, callSettings);
        }

        /// <summary>
        /// Modifies the target pools to which all new instances in this group are assigned. Existing instances in the group are not affected.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetTargetPoolsAsync(SetTargetPoolsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetTargetPoolsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callSetTargetPools.Async(request, callSettings);
        }

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation UpdatePerInstanceConfigs(UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callUpdatePerInstanceConfigs.Sync(request, callSettings);
        }

        /// <summary>
        /// Inserts or updates per-instance configs for the managed instance group. perInstanceConfig.name serves as a key used to distinguish whether to perform insert or patch.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdatePerInstanceConfigsAsync(UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdatePerInstanceConfigsRegionInstanceGroupManagerRequest(ref request, ref callSettings);
            return _callUpdatePerInstanceConfigs.Async(request, callSettings);
        }
    }
}
