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
    /// <summary>Settings for <see cref="GlobalNetworkEndpointGroupsClient"/> instances.</summary>
    public sealed partial class GlobalNetworkEndpointGroupsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="GlobalNetworkEndpointGroupsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="GlobalNetworkEndpointGroupsSettings"/>.</returns>
        public static GlobalNetworkEndpointGroupsSettings GetDefault() => new GlobalNetworkEndpointGroupsSettings();

        /// <summary>
        /// Constructs a new <see cref="GlobalNetworkEndpointGroupsSettings"/> object with default settings.
        /// </summary>
        public GlobalNetworkEndpointGroupsSettings()
        {
        }

        private GlobalNetworkEndpointGroupsSettings(GlobalNetworkEndpointGroupsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AttachNetworkEndpointsSettings = existing.AttachNetworkEndpointsSettings;
            DeleteSettings = existing.DeleteSettings;
            DetachNetworkEndpointsSettings = existing.DetachNetworkEndpointsSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListNetworkEndpointsSettings = existing.ListNetworkEndpointsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(GlobalNetworkEndpointGroupsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>GlobalNetworkEndpointGroupsClient.AttachNetworkEndpoints</c> and
        /// <c>GlobalNetworkEndpointGroupsClient.AttachNetworkEndpointsAsync</c>.
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
        /// <c>GlobalNetworkEndpointGroupsClient.Delete</c> and <c>GlobalNetworkEndpointGroupsClient.DeleteAsync</c>.
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
        /// <c>GlobalNetworkEndpointGroupsClient.DetachNetworkEndpoints</c> and
        /// <c>GlobalNetworkEndpointGroupsClient.DetachNetworkEndpointsAsync</c>.
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
        /// <c>GlobalNetworkEndpointGroupsClient.Get</c> and <c>GlobalNetworkEndpointGroupsClient.GetAsync</c>.
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
        /// <c>GlobalNetworkEndpointGroupsClient.Insert</c> and <c>GlobalNetworkEndpointGroupsClient.InsertAsync</c>.
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
        /// <c>GlobalNetworkEndpointGroupsClient.List</c> and <c>GlobalNetworkEndpointGroupsClient.ListAsync</c>.
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
        /// <c>GlobalNetworkEndpointGroupsClient.ListNetworkEndpoints</c> and
        /// <c>GlobalNetworkEndpointGroupsClient.ListNetworkEndpointsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListNetworkEndpointsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="GlobalNetworkEndpointGroupsSettings"/> object.</returns>
        public GlobalNetworkEndpointGroupsSettings Clone() => new GlobalNetworkEndpointGroupsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="GlobalNetworkEndpointGroupsClient"/> to provide simple configuration of
    /// credentials, endpoint etc.
    /// </summary>
    public sealed partial class GlobalNetworkEndpointGroupsClientBuilder : gaxgrpc::ClientBuilderBase<GlobalNetworkEndpointGroupsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public GlobalNetworkEndpointGroupsSettings Settings { get; set; }

        partial void InterceptBuild(ref GlobalNetworkEndpointGroupsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<GlobalNetworkEndpointGroupsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override GlobalNetworkEndpointGroupsClient Build()
        {
            GlobalNetworkEndpointGroupsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<GlobalNetworkEndpointGroupsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<GlobalNetworkEndpointGroupsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private GlobalNetworkEndpointGroupsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return GlobalNetworkEndpointGroupsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<GlobalNetworkEndpointGroupsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return GlobalNetworkEndpointGroupsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => GlobalNetworkEndpointGroupsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => GlobalNetworkEndpointGroupsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => GlobalNetworkEndpointGroupsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>GlobalNetworkEndpointGroups client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The GlobalNetworkEndpointGroups API.
    /// </remarks>
    public abstract partial class GlobalNetworkEndpointGroupsClient
    {
        /// <summary>
        /// The default endpoint for the GlobalNetworkEndpointGroups service, which is a host of
        /// "compute.googleapis.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default GlobalNetworkEndpointGroups scopes.</summary>
        /// <remarks>
        /// The default GlobalNetworkEndpointGroups scopes are:
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
        /// Asynchronously creates a <see cref="GlobalNetworkEndpointGroupsClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="GlobalNetworkEndpointGroupsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="GlobalNetworkEndpointGroupsClient"/>.</returns>
        public static stt::Task<GlobalNetworkEndpointGroupsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new GlobalNetworkEndpointGroupsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="GlobalNetworkEndpointGroupsClient"/> using the default credentials,
        /// endpoint and settings. To specify custom credentials or other settings, use
        /// <see cref="GlobalNetworkEndpointGroupsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="GlobalNetworkEndpointGroupsClient"/>.</returns>
        public static GlobalNetworkEndpointGroupsClient Create() => new GlobalNetworkEndpointGroupsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="GlobalNetworkEndpointGroupsClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="GlobalNetworkEndpointGroupsSettings"/>.</param>
        /// <returns>The created <see cref="GlobalNetworkEndpointGroupsClient"/>.</returns>
        internal static GlobalNetworkEndpointGroupsClient Create(grpccore::CallInvoker callInvoker, GlobalNetworkEndpointGroupsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            GlobalNetworkEndpointGroups.GlobalNetworkEndpointGroupsClient grpcClient = new GlobalNetworkEndpointGroups.GlobalNetworkEndpointGroupsClient(callInvoker);
            return new GlobalNetworkEndpointGroupsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC GlobalNetworkEndpointGroups client</summary>
        public virtual GlobalNetworkEndpointGroups.GlobalNetworkEndpointGroupsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AttachNetworkEndpoints(AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            AttachNetworkEndpointsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are attaching network endpoints to. It should comply with RFC1035.
        /// </param>
        /// <param name="globalNetworkEndpointGroupsAttachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AttachNetworkEndpoints(string project, string networkEndpointGroup, GlobalNetworkEndpointGroupsAttachEndpointsRequest globalNetworkEndpointGroupsAttachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AttachNetworkEndpoints(new AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest
            {
                GlobalNetworkEndpointGroupsAttachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(globalNetworkEndpointGroupsAttachEndpointsRequestResource, nameof(globalNetworkEndpointGroupsAttachEndpointsRequestResource)),
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are attaching network endpoints to. It should comply with RFC1035.
        /// </param>
        /// <param name="globalNetworkEndpointGroupsAttachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(string project, string networkEndpointGroup, GlobalNetworkEndpointGroupsAttachEndpointsRequest globalNetworkEndpointGroupsAttachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AttachNetworkEndpointsAsync(new AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest
            {
                GlobalNetworkEndpointGroupsAttachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(globalNetworkEndpointGroupsAttachEndpointsRequestResource, nameof(globalNetworkEndpointGroupsAttachEndpointsRequestResource)),
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are attaching network endpoints to. It should comply with RFC1035.
        /// </param>
        /// <param name="globalNetworkEndpointGroupsAttachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AttachNetworkEndpointsAsync(string project, string networkEndpointGroup, GlobalNetworkEndpointGroupsAttachEndpointsRequest globalNetworkEndpointGroupsAttachEndpointsRequestResource, st::CancellationToken cancellationToken) =>
            AttachNetworkEndpointsAsync(project, networkEndpointGroup, globalNetworkEndpointGroupsAttachEndpointsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteGlobalNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group to delete. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteGlobalNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group to delete. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteGlobalNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group to delete. It should comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string networkEndpointGroup, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, networkEndpointGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DetachNetworkEndpoints(DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            DetachNetworkEndpointsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are removing network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="globalNetworkEndpointGroupsDetachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DetachNetworkEndpoints(string project, string networkEndpointGroup, GlobalNetworkEndpointGroupsDetachEndpointsRequest globalNetworkEndpointGroupsDetachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DetachNetworkEndpoints(new DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest
            {
                GlobalNetworkEndpointGroupsDetachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(globalNetworkEndpointGroupsDetachEndpointsRequestResource, nameof(globalNetworkEndpointGroupsDetachEndpointsRequestResource)),
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are removing network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="globalNetworkEndpointGroupsDetachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(string project, string networkEndpointGroup, GlobalNetworkEndpointGroupsDetachEndpointsRequest globalNetworkEndpointGroupsDetachEndpointsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            DetachNetworkEndpointsAsync(new DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest
            {
                GlobalNetworkEndpointGroupsDetachEndpointsRequestResource = gax::GaxPreconditions.CheckNotNull(globalNetworkEndpointGroupsDetachEndpointsRequestResource, nameof(globalNetworkEndpointGroupsDetachEndpointsRequestResource)),
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group where you are removing network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="globalNetworkEndpointGroupsDetachEndpointsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DetachNetworkEndpointsAsync(string project, string networkEndpointGroup, GlobalNetworkEndpointGroupsDetachEndpointsRequest globalNetworkEndpointGroupsDetachEndpointsRequestResource, st::CancellationToken cancellationToken) =>
            DetachNetworkEndpointsAsync(project, networkEndpointGroup, globalNetworkEndpointGroupsDetachEndpointsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroup Get(GetGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(GetGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(GetGlobalNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroup Get(string project, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetGlobalNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(string project, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetGlobalNetworkEndpointGroupRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group. It should comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroup> GetAsync(string project, string networkEndpointGroup, st::CancellationToken cancellationToken) =>
            GetAsync(project, networkEndpointGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertGlobalNetworkEndpointGroupRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, NetworkEndpointGroup networkEndpointGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertGlobalNetworkEndpointGroupRequest
            {
                NetworkEndpointGroupResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupResource, nameof(networkEndpointGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, NetworkEndpointGroup networkEndpointGroupResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertGlobalNetworkEndpointGroupRequest
            {
                NetworkEndpointGroupResource = gax::GaxPreconditions.CheckNotNull(networkEndpointGroupResource, nameof(networkEndpointGroupResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroupResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, NetworkEndpointGroup networkEndpointGroupResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, networkEndpointGroupResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupList List(ListGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(ListGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(ListGlobalNetworkEndpointGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListGlobalNetworkEndpointGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListGlobalNetworkEndpointGroupsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupsListNetworkEndpoints ListNetworkEndpoints(ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest request, st::CancellationToken cancellationToken) =>
            ListNetworkEndpointsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group from which you want to generate a list of included network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkEndpointGroupsListNetworkEndpoints ListNetworkEndpoints(string project, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            ListNetworkEndpoints(new ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group from which you want to generate a list of included network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(string project, string networkEndpointGroup, gaxgrpc::CallSettings callSettings = null) =>
            ListNetworkEndpointsAsync(new ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest
            {
                NetworkEndpointGroup = gax::GaxPreconditions.CheckNotNullOrEmpty(networkEndpointGroup, nameof(networkEndpointGroup)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkEndpointGroup">
        /// The name of the network endpoint group from which you want to generate a list of included network endpoints. It should comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(string project, string networkEndpointGroup, st::CancellationToken cancellationToken) =>
            ListNetworkEndpointsAsync(project, networkEndpointGroup, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>GlobalNetworkEndpointGroups client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The GlobalNetworkEndpointGroups API.
    /// </remarks>
    public sealed partial class GlobalNetworkEndpointGroupsClientImpl : GlobalNetworkEndpointGroupsClient
    {
        private readonly gaxgrpc::ApiCall<AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest, Operation> _callAttachNetworkEndpoints;

        private readonly gaxgrpc::ApiCall<DeleteGlobalNetworkEndpointGroupRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest, Operation> _callDetachNetworkEndpoints;

        private readonly gaxgrpc::ApiCall<GetGlobalNetworkEndpointGroupRequest, NetworkEndpointGroup> _callGet;

        private readonly gaxgrpc::ApiCall<InsertGlobalNetworkEndpointGroupRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListGlobalNetworkEndpointGroupsRequest, NetworkEndpointGroupList> _callList;

        private readonly gaxgrpc::ApiCall<ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest, NetworkEndpointGroupsListNetworkEndpoints> _callListNetworkEndpoints;

        /// <summary>
        /// Constructs a client wrapper for the GlobalNetworkEndpointGroups service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="GlobalNetworkEndpointGroupsSettings"/> used within this client.
        /// </param>
        public GlobalNetworkEndpointGroupsClientImpl(GlobalNetworkEndpointGroups.GlobalNetworkEndpointGroupsClient grpcClient, GlobalNetworkEndpointGroupsSettings settings)
        {
            GrpcClient = grpcClient;
            GlobalNetworkEndpointGroupsSettings effectiveSettings = settings ?? GlobalNetworkEndpointGroupsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAttachNetworkEndpoints = clientHelper.BuildApiCall<AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest, Operation>(grpcClient.AttachNetworkEndpointsAsync, grpcClient.AttachNetworkEndpoints, effectiveSettings.AttachNetworkEndpointsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callAttachNetworkEndpoints);
            Modify_AttachNetworkEndpointsApiCall(ref _callAttachNetworkEndpoints);
            _callDelete = clientHelper.BuildApiCall<DeleteGlobalNetworkEndpointGroupRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callDetachNetworkEndpoints = clientHelper.BuildApiCall<DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest, Operation>(grpcClient.DetachNetworkEndpointsAsync, grpcClient.DetachNetworkEndpoints, effectiveSettings.DetachNetworkEndpointsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callDetachNetworkEndpoints);
            Modify_DetachNetworkEndpointsApiCall(ref _callDetachNetworkEndpoints);
            _callGet = clientHelper.BuildApiCall<GetGlobalNetworkEndpointGroupRequest, NetworkEndpointGroup>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertGlobalNetworkEndpointGroupRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListGlobalNetworkEndpointGroupsRequest, NetworkEndpointGroupList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListNetworkEndpoints = clientHelper.BuildApiCall<ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest, NetworkEndpointGroupsListNetworkEndpoints>(grpcClient.ListNetworkEndpointsAsync, grpcClient.ListNetworkEndpoints, effectiveSettings.ListNetworkEndpointsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network_endpoint_group", request => request.NetworkEndpointGroup);
            Modify_ApiCall(ref _callListNetworkEndpoints);
            Modify_ListNetworkEndpointsApiCall(ref _callListNetworkEndpoints);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AttachNetworkEndpointsApiCall(ref gaxgrpc::ApiCall<AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteGlobalNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_DetachNetworkEndpointsApiCall(ref gaxgrpc::ApiCall<DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetGlobalNetworkEndpointGroupRequest, NetworkEndpointGroup> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertGlobalNetworkEndpointGroupRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListGlobalNetworkEndpointGroupsRequest, NetworkEndpointGroupList> call);

        partial void Modify_ListNetworkEndpointsApiCall(ref gaxgrpc::ApiCall<ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest, NetworkEndpointGroupsListNetworkEndpoints> call);

        partial void OnConstruction(GlobalNetworkEndpointGroups.GlobalNetworkEndpointGroupsClient grpcClient, GlobalNetworkEndpointGroupsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC GlobalNetworkEndpointGroups client</summary>
        public override GlobalNetworkEndpointGroups.GlobalNetworkEndpointGroupsClient GrpcClient { get; }

        partial void Modify_AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest(ref AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteGlobalNetworkEndpointGroupRequest(ref DeleteGlobalNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest(ref DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetGlobalNetworkEndpointGroupRequest(ref GetGlobalNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertGlobalNetworkEndpointGroupRequest(ref InsertGlobalNetworkEndpointGroupRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListGlobalNetworkEndpointGroupsRequest(ref ListGlobalNetworkEndpointGroupsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest(ref ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AttachNetworkEndpoints(AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callAttachNetworkEndpoints.Sync(request, callSettings);
        }

        /// <summary>
        /// Attach a network endpoint to the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AttachNetworkEndpointsAsync(AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AttachNetworkEndpointsGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callAttachNetworkEndpoints.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified network endpoint group.Note that the NEG cannot be deleted if there are backend services referencing it.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DetachNetworkEndpoints(DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDetachNetworkEndpoints.Sync(request, callSettings);
        }

        /// <summary>
        /// Detach the network endpoint from the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DetachNetworkEndpointsAsync(DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DetachNetworkEndpointsGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callDetachNetworkEndpoints.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroup Get(GetGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified network endpoint group. Gets a list of available network endpoint groups by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroup> GetAsync(GetGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a network endpoint group in the specified project using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertGlobalNetworkEndpointGroupRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertGlobalNetworkEndpointGroupRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroupList List(ListGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListGlobalNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of network endpoint groups that are located in the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroupList> ListAsync(ListGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListGlobalNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkEndpointGroupsListNetworkEndpoints ListNetworkEndpoints(ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callListNetworkEndpoints.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists the network endpoints in the specified network endpoint group.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkEndpointGroupsListNetworkEndpoints> ListNetworkEndpointsAsync(ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworkEndpointsGlobalNetworkEndpointGroupsRequest(ref request, ref callSettings);
            return _callListNetworkEndpoints.Async(request, callSettings);
        }
    }
}
