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
    /// <summary>Settings for <see cref="NetworksClient"/> instances.</summary>
    public sealed partial class NetworksSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="NetworksSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="NetworksSettings"/>.</returns>
        public static NetworksSettings GetDefault() => new NetworksSettings();

        /// <summary>Constructs a new <see cref="NetworksSettings"/> object with default settings.</summary>
        public NetworksSettings()
        {
        }

        private NetworksSettings(NetworksSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AddPeeringSettings = existing.AddPeeringSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListPeeringRoutesSettings = existing.ListPeeringRoutesSettings;
            PatchSettings = existing.PatchSettings;
            RemovePeeringSettings = existing.RemovePeeringSettings;
            SwitchToCustomModeSettings = existing.SwitchToCustomModeSettings;
            UpdatePeeringSettings = existing.UpdatePeeringSettings;
            OnCopy(existing);
        }

        partial void OnCopy(NetworksSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NetworksClient.AddPeering</c>
        ///  and <c>NetworksClient.AddPeeringAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddPeeringSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NetworksClient.Delete</c>
        /// and <c>NetworksClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NetworksClient.Get</c> and
        /// <c>NetworksClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NetworksClient.Insert</c>
        /// and <c>NetworksClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NetworksClient.List</c> and
        /// <c>NetworksClient.ListAsync</c>.
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
        /// <c>NetworksClient.ListPeeringRoutes</c> and <c>NetworksClient.ListPeeringRoutesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListPeeringRoutesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>NetworksClient.Patch</c>
        /// and <c>NetworksClient.PatchAsync</c>.
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
        /// <c>NetworksClient.RemovePeering</c> and <c>NetworksClient.RemovePeeringAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RemovePeeringSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworksClient.SwitchToCustomMode</c> and <c>NetworksClient.SwitchToCustomModeAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SwitchToCustomModeSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>NetworksClient.UpdatePeering</c> and <c>NetworksClient.UpdatePeeringAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdatePeeringSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="NetworksSettings"/> object.</returns>
        public NetworksSettings Clone() => new NetworksSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="NetworksClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class NetworksClientBuilder : gaxgrpc::ClientBuilderBase<NetworksClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public NetworksSettings Settings { get; set; }

        partial void InterceptBuild(ref NetworksClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<NetworksClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override NetworksClient Build()
        {
            NetworksClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<NetworksClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<NetworksClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private NetworksClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return NetworksClient.Create(callInvoker, Settings);
        }

        private async stt::Task<NetworksClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return NetworksClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => NetworksClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => NetworksClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => NetworksClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>Networks client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The Networks API.
    /// </remarks>
    public abstract partial class NetworksClient
    {
        /// <summary>
        /// The default endpoint for the Networks service, which is a host of "compute.googleapis.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default Networks scopes.</summary>
        /// <remarks>
        /// The default Networks scopes are:
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
        /// Asynchronously creates a <see cref="NetworksClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="NetworksClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="NetworksClient"/>.</returns>
        public static stt::Task<NetworksClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new NetworksClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="NetworksClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="NetworksClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="NetworksClient"/>.</returns>
        public static NetworksClient Create() => new NetworksClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="NetworksClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="NetworksSettings"/>.</param>
        /// <returns>The created <see cref="NetworksClient"/>.</returns>
        internal static NetworksClient Create(grpccore::CallInvoker callInvoker, NetworksSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Networks.NetworksClient grpcClient = new Networks.NetworksClient(callInvoker);
            return new NetworksClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC Networks client</summary>
        public virtual Networks.NetworksClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddPeering(AddPeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddPeeringAsync(AddPeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddPeeringAsync(AddPeeringNetworkRequest request, st::CancellationToken cancellationToken) =>
            AddPeeringAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource to add peering to.
        /// </param>
        /// <param name="networksAddPeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddPeering(string project, string network, NetworksAddPeeringRequest networksAddPeeringRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddPeering(new AddPeeringNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworksAddPeeringRequestResource = gax::GaxPreconditions.CheckNotNull(networksAddPeeringRequestResource, nameof(networksAddPeeringRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource to add peering to.
        /// </param>
        /// <param name="networksAddPeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddPeeringAsync(string project, string network, NetworksAddPeeringRequest networksAddPeeringRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddPeeringAsync(new AddPeeringNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworksAddPeeringRequestResource = gax::GaxPreconditions.CheckNotNull(networksAddPeeringRequestResource, nameof(networksAddPeeringRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource to add peering to.
        /// </param>
        /// <param name="networksAddPeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddPeeringAsync(string project, string network, NetworksAddPeeringRequest networksAddPeeringRequestResource, st::CancellationToken cancellationToken) =>
            AddPeeringAsync(project, network, networksAddPeeringRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteNetworkRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string network, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, network, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Network Get(GetNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Network> GetAsync(GetNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Network> GetAsync(GetNetworkRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Network Get(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Network> GetAsync(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Network> GetAsync(string project, string network, st::CancellationToken cancellationToken) =>
            GetAsync(project, network, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertNetworkRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, Network networkResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertNetworkRequest
            {
                NetworkResource = gax::GaxPreconditions.CheckNotNull(networkResource, nameof(networkResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, Network networkResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertNetworkRequest
            {
                NetworkResource = gax::GaxPreconditions.CheckNotNull(networkResource, nameof(networkResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="networkResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, Network networkResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, networkResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkList List(ListNetworksRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkList> ListAsync(ListNetworksRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkList> ListAsync(ListNetworksRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual NetworkList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListNetworksRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListNetworksRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<NetworkList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ExchangedPeeringRoutesList ListPeeringRoutes(ListPeeringRoutesNetworksRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ExchangedPeeringRoutesList> ListPeeringRoutesAsync(ListPeeringRoutesNetworksRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ExchangedPeeringRoutesList> ListPeeringRoutesAsync(ListPeeringRoutesNetworksRequest request, st::CancellationToken cancellationToken) =>
            ListPeeringRoutesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ExchangedPeeringRoutesList ListPeeringRoutes(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            ListPeeringRoutes(new ListPeeringRoutesNetworksRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ExchangedPeeringRoutesList> ListPeeringRoutesAsync(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            ListPeeringRoutesAsync(new ListPeeringRoutesNetworksRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ExchangedPeeringRoutesList> ListPeeringRoutesAsync(string project, string network, st::CancellationToken cancellationToken) =>
            ListPeeringRoutesAsync(project, network, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchNetworkRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to update.
        /// </param>
        /// <param name="networkResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string network, Network networkResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworkResource = gax::GaxPreconditions.CheckNotNull(networkResource, nameof(networkResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to update.
        /// </param>
        /// <param name="networkResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string network, Network networkResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworkResource = gax::GaxPreconditions.CheckNotNull(networkResource, nameof(networkResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to update.
        /// </param>
        /// <param name="networkResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string network, Network networkResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, network, networkResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemovePeering(RemovePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemovePeeringAsync(RemovePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemovePeeringAsync(RemovePeeringNetworkRequest request, st::CancellationToken cancellationToken) =>
            RemovePeeringAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource to remove peering from.
        /// </param>
        /// <param name="networksRemovePeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemovePeering(string project, string network, NetworksRemovePeeringRequest networksRemovePeeringRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemovePeering(new RemovePeeringNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworksRemovePeeringRequestResource = gax::GaxPreconditions.CheckNotNull(networksRemovePeeringRequestResource, nameof(networksRemovePeeringRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource to remove peering from.
        /// </param>
        /// <param name="networksRemovePeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemovePeeringAsync(string project, string network, NetworksRemovePeeringRequest networksRemovePeeringRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemovePeeringAsync(new RemovePeeringNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworksRemovePeeringRequestResource = gax::GaxPreconditions.CheckNotNull(networksRemovePeeringRequestResource, nameof(networksRemovePeeringRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource to remove peering from.
        /// </param>
        /// <param name="networksRemovePeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemovePeeringAsync(string project, string network, NetworksRemovePeeringRequest networksRemovePeeringRequestResource, st::CancellationToken cancellationToken) =>
            RemovePeeringAsync(project, network, networksRemovePeeringRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SwitchToCustomMode(SwitchToCustomModeNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SwitchToCustomModeAsync(SwitchToCustomModeNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SwitchToCustomModeAsync(SwitchToCustomModeNetworkRequest request, st::CancellationToken cancellationToken) =>
            SwitchToCustomModeAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to be updated.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SwitchToCustomMode(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            SwitchToCustomMode(new SwitchToCustomModeNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to be updated.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SwitchToCustomModeAsync(string project, string network, gaxgrpc::CallSettings callSettings = null) =>
            SwitchToCustomModeAsync(new SwitchToCustomModeNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network to be updated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SwitchToCustomModeAsync(string project, string network, st::CancellationToken cancellationToken) =>
            SwitchToCustomModeAsync(project, network, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation UpdatePeering(UpdatePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePeeringAsync(UpdatePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePeeringAsync(UpdatePeeringNetworkRequest request, st::CancellationToken cancellationToken) =>
            UpdatePeeringAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource which the updated peering is belonging to.
        /// </param>
        /// <param name="networksUpdatePeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation UpdatePeering(string project, string network, NetworksUpdatePeeringRequest networksUpdatePeeringRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdatePeering(new UpdatePeeringNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworksUpdatePeeringRequestResource = gax::GaxPreconditions.CheckNotNull(networksUpdatePeeringRequestResource, nameof(networksUpdatePeeringRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource which the updated peering is belonging to.
        /// </param>
        /// <param name="networksUpdatePeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePeeringAsync(string project, string network, NetworksUpdatePeeringRequest networksUpdatePeeringRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdatePeeringAsync(new UpdatePeeringNetworkRequest
            {
                Network = gax::GaxPreconditions.CheckNotNullOrEmpty(network, nameof(network)),
                NetworksUpdatePeeringRequestResource = gax::GaxPreconditions.CheckNotNull(networksUpdatePeeringRequestResource, nameof(networksUpdatePeeringRequestResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="network">
        /// Name of the network resource which the updated peering is belonging to.
        /// </param>
        /// <param name="networksUpdatePeeringRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdatePeeringAsync(string project, string network, NetworksUpdatePeeringRequest networksUpdatePeeringRequestResource, st::CancellationToken cancellationToken) =>
            UpdatePeeringAsync(project, network, networksUpdatePeeringRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Networks client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The Networks API.
    /// </remarks>
    public sealed partial class NetworksClientImpl : NetworksClient
    {
        private readonly gaxgrpc::ApiCall<AddPeeringNetworkRequest, Operation> _callAddPeering;

        private readonly gaxgrpc::ApiCall<DeleteNetworkRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetNetworkRequest, Network> _callGet;

        private readonly gaxgrpc::ApiCall<InsertNetworkRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListNetworksRequest, NetworkList> _callList;

        private readonly gaxgrpc::ApiCall<ListPeeringRoutesNetworksRequest, ExchangedPeeringRoutesList> _callListPeeringRoutes;

        private readonly gaxgrpc::ApiCall<PatchNetworkRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<RemovePeeringNetworkRequest, Operation> _callRemovePeering;

        private readonly gaxgrpc::ApiCall<SwitchToCustomModeNetworkRequest, Operation> _callSwitchToCustomMode;

        private readonly gaxgrpc::ApiCall<UpdatePeeringNetworkRequest, Operation> _callUpdatePeering;

        /// <summary>
        /// Constructs a client wrapper for the Networks service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="NetworksSettings"/> used within this client.</param>
        public NetworksClientImpl(Networks.NetworksClient grpcClient, NetworksSettings settings)
        {
            GrpcClient = grpcClient;
            NetworksSettings effectiveSettings = settings ?? NetworksSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAddPeering = clientHelper.BuildApiCall<AddPeeringNetworkRequest, Operation>(grpcClient.AddPeeringAsync, grpcClient.AddPeering, effectiveSettings.AddPeeringSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callAddPeering);
            Modify_AddPeeringApiCall(ref _callAddPeering);
            _callDelete = clientHelper.BuildApiCall<DeleteNetworkRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetNetworkRequest, Network>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertNetworkRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListNetworksRequest, NetworkList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListPeeringRoutes = clientHelper.BuildApiCall<ListPeeringRoutesNetworksRequest, ExchangedPeeringRoutesList>(grpcClient.ListPeeringRoutesAsync, grpcClient.ListPeeringRoutes, effectiveSettings.ListPeeringRoutesSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callListPeeringRoutes);
            Modify_ListPeeringRoutesApiCall(ref _callListPeeringRoutes);
            _callPatch = clientHelper.BuildApiCall<PatchNetworkRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callRemovePeering = clientHelper.BuildApiCall<RemovePeeringNetworkRequest, Operation>(grpcClient.RemovePeeringAsync, grpcClient.RemovePeering, effectiveSettings.RemovePeeringSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callRemovePeering);
            Modify_RemovePeeringApiCall(ref _callRemovePeering);
            _callSwitchToCustomMode = clientHelper.BuildApiCall<SwitchToCustomModeNetworkRequest, Operation>(grpcClient.SwitchToCustomModeAsync, grpcClient.SwitchToCustomMode, effectiveSettings.SwitchToCustomModeSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callSwitchToCustomMode);
            Modify_SwitchToCustomModeApiCall(ref _callSwitchToCustomMode);
            _callUpdatePeering = clientHelper.BuildApiCall<UpdatePeeringNetworkRequest, Operation>(grpcClient.UpdatePeeringAsync, grpcClient.UpdatePeering, effectiveSettings.UpdatePeeringSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("network", request => request.Network);
            Modify_ApiCall(ref _callUpdatePeering);
            Modify_UpdatePeeringApiCall(ref _callUpdatePeering);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AddPeeringApiCall(ref gaxgrpc::ApiCall<AddPeeringNetworkRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteNetworkRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetNetworkRequest, Network> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertNetworkRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListNetworksRequest, NetworkList> call);

        partial void Modify_ListPeeringRoutesApiCall(ref gaxgrpc::ApiCall<ListPeeringRoutesNetworksRequest, ExchangedPeeringRoutesList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchNetworkRequest, Operation> call);

        partial void Modify_RemovePeeringApiCall(ref gaxgrpc::ApiCall<RemovePeeringNetworkRequest, Operation> call);

        partial void Modify_SwitchToCustomModeApiCall(ref gaxgrpc::ApiCall<SwitchToCustomModeNetworkRequest, Operation> call);

        partial void Modify_UpdatePeeringApiCall(ref gaxgrpc::ApiCall<UpdatePeeringNetworkRequest, Operation> call);

        partial void OnConstruction(Networks.NetworksClient grpcClient, NetworksSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Networks client</summary>
        public override Networks.NetworksClient GrpcClient { get; }

        partial void Modify_AddPeeringNetworkRequest(ref AddPeeringNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteNetworkRequest(ref DeleteNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetNetworkRequest(ref GetNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertNetworkRequest(ref InsertNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListNetworksRequest(ref ListNetworksRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListPeeringRoutesNetworksRequest(ref ListPeeringRoutesNetworksRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchNetworkRequest(ref PatchNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RemovePeeringNetworkRequest(ref RemovePeeringNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SwitchToCustomModeNetworkRequest(ref SwitchToCustomModeNetworkRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdatePeeringNetworkRequest(ref UpdatePeeringNetworkRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddPeering(AddPeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddPeeringNetworkRequest(ref request, ref callSettings);
            return _callAddPeering.Sync(request, callSettings);
        }

        /// <summary>
        /// Adds a peering to the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddPeeringAsync(AddPeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddPeeringNetworkRequest(ref request, ref callSettings);
            return _callAddPeering.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNetworkRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteNetworkRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Network Get(GetNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNetworkRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified network. Gets a list of available networks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Network> GetAsync(GetNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetNetworkRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertNetworkRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a network in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertNetworkRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override NetworkList List(ListNetworksRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworksRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of networks available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<NetworkList> ListAsync(ListNetworksRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListNetworksRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override ExchangedPeeringRoutesList ListPeeringRoutes(ListPeeringRoutesNetworksRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPeeringRoutesNetworksRequest(ref request, ref callSettings);
            return _callListPeeringRoutes.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists the peering routes exchanged over peering connection.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<ExchangedPeeringRoutesList> ListPeeringRoutesAsync(ListPeeringRoutesNetworksRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPeeringRoutesNetworksRequest(ref request, ref callSettings);
            return _callListPeeringRoutes.Async(request, callSettings);
        }

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchNetworkRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Patches the specified network with the data included in the request. Only the following fields can be modified: routingConfig.routingMode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchNetworkRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation RemovePeering(RemovePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemovePeeringNetworkRequest(ref request, ref callSettings);
            return _callRemovePeering.Sync(request, callSettings);
        }

        /// <summary>
        /// Removes a peering from the specified network.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> RemovePeeringAsync(RemovePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemovePeeringNetworkRequest(ref request, ref callSettings);
            return _callRemovePeering.Async(request, callSettings);
        }

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SwitchToCustomMode(SwitchToCustomModeNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SwitchToCustomModeNetworkRequest(ref request, ref callSettings);
            return _callSwitchToCustomMode.Sync(request, callSettings);
        }

        /// <summary>
        /// Switches the network mode from auto subnet mode to custom subnet mode.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SwitchToCustomModeAsync(SwitchToCustomModeNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SwitchToCustomModeNetworkRequest(ref request, ref callSettings);
            return _callSwitchToCustomMode.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation UpdatePeering(UpdatePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdatePeeringNetworkRequest(ref request, ref callSettings);
            return _callUpdatePeering.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified network peering with the data included in the request Only the following fields can be modified: NetworkPeering.export_custom_routes, and NetworkPeering.import_custom_routes
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdatePeeringAsync(UpdatePeeringNetworkRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdatePeeringNetworkRequest(ref request, ref callSettings);
            return _callUpdatePeering.Async(request, callSettings);
        }
    }
}
