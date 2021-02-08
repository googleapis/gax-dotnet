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
    /// <summary>Settings for <see cref="VpnGatewaysClient"/> instances.</summary>
    public sealed partial class VpnGatewaysSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="VpnGatewaysSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="VpnGatewaysSettings"/>.</returns>
        public static VpnGatewaysSettings GetDefault() => new VpnGatewaysSettings();

        /// <summary>Constructs a new <see cref="VpnGatewaysSettings"/> object with default settings.</summary>
        public VpnGatewaysSettings()
        {
        }

        private VpnGatewaysSettings(VpnGatewaysSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AggregatedListSettings = existing.AggregatedListSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            GetStatusSettings = existing.GetStatusSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            SetLabelsSettings = existing.SetLabelsSettings;
            TestIamPermissionsSettings = existing.TestIamPermissionsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(VpnGatewaysSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>VpnGatewaysClient.AggregatedList</c> and <c>VpnGatewaysClient.AggregatedListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>VpnGatewaysClient.Delete</c>
        ///  and <c>VpnGatewaysClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>VpnGatewaysClient.Get</c>
        /// and <c>VpnGatewaysClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>VpnGatewaysClient.GetStatus</c>
        ///  and <c>VpnGatewaysClient.GetStatusAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetStatusSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>VpnGatewaysClient.Insert</c>
        ///  and <c>VpnGatewaysClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>VpnGatewaysClient.List</c>
        /// and <c>VpnGatewaysClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>VpnGatewaysClient.SetLabels</c>
        ///  and <c>VpnGatewaysClient.SetLabelsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetLabelsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>VpnGatewaysClient.TestIamPermissions</c> and <c>VpnGatewaysClient.TestIamPermissionsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings TestIamPermissionsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="VpnGatewaysSettings"/> object.</returns>
        public VpnGatewaysSettings Clone() => new VpnGatewaysSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="VpnGatewaysClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class VpnGatewaysClientBuilder : gaxgrpc::ClientBuilderBase<VpnGatewaysClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public VpnGatewaysSettings Settings { get; set; }

        partial void InterceptBuild(ref VpnGatewaysClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<VpnGatewaysClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override VpnGatewaysClient Build()
        {
            VpnGatewaysClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<VpnGatewaysClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<VpnGatewaysClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private VpnGatewaysClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return VpnGatewaysClient.Create(callInvoker, Settings);
        }

        private async stt::Task<VpnGatewaysClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return VpnGatewaysClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => VpnGatewaysClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => VpnGatewaysClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => VpnGatewaysClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>VpnGateways client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The VpnGateways API.
    /// </remarks>
    public abstract partial class VpnGatewaysClient
    {
        /// <summary>
        /// The default endpoint for the VpnGateways service, which is a host of "compute.googleapis.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default VpnGateways scopes.</summary>
        /// <remarks>
        /// The default VpnGateways scopes are:
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
        /// Asynchronously creates a <see cref="VpnGatewaysClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="VpnGatewaysClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="VpnGatewaysClient"/>.</returns>
        public static stt::Task<VpnGatewaysClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new VpnGatewaysClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="VpnGatewaysClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="VpnGatewaysClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="VpnGatewaysClient"/>.</returns>
        public static VpnGatewaysClient Create() => new VpnGatewaysClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="VpnGatewaysClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="VpnGatewaysSettings"/>.</param>
        /// <returns>The created <see cref="VpnGatewaysClient"/>.</returns>
        internal static VpnGatewaysClient Create(grpccore::CallInvoker callInvoker, VpnGatewaysSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            VpnGateways.VpnGatewaysClient grpcClient = new VpnGateways.VpnGatewaysClient(callInvoker);
            return new VpnGatewaysClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC VpnGateways client</summary>
        public virtual VpnGateways.VpnGatewaysClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGatewayAggregatedList AggregatedList(AggregatedListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayAggregatedList> AggregatedListAsync(AggregatedListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayAggregatedList> AggregatedListAsync(AggregatedListVpnGatewaysRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGatewayAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string vpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(vpnGateway, nameof(vpnGateway)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string vpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(vpnGateway, nameof(vpnGateway)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string vpnGateway, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, vpnGateway, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGateway Get(GetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGateway> GetAsync(GetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGateway> GetAsync(GetVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGateway Get(string project, string region, string vpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(vpnGateway, nameof(vpnGateway)),
            }, callSettings);

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGateway> GetAsync(string project, string region, string vpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(vpnGateway, nameof(vpnGateway)),
            }, callSettings);

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGateway> GetAsync(string project, string region, string vpnGateway, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, vpnGateway, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGatewaysGetStatusResponse GetStatus(GetStatusVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewaysGetStatusResponse> GetStatusAsync(GetStatusVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewaysGetStatusResponse> GetStatusAsync(GetStatusVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            GetStatusAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGatewaysGetStatusResponse GetStatus(string project, string region, string vpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            GetStatus(new GetStatusVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(vpnGateway, nameof(vpnGateway)),
            }, callSettings);

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewaysGetStatusResponse> GetStatusAsync(string project, string region, string vpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            GetStatusAsync(new GetStatusVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(vpnGateway, nameof(vpnGateway)),
            }, callSettings);

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGateway">
        /// Name of the VPN gateway to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewaysGetStatusResponse> GetStatusAsync(string project, string region, string vpnGateway, st::CancellationToken cancellationToken) =>
            GetStatusAsync(project, region, vpnGateway, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGatewayResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, VpnGateway vpnGatewayResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGatewayResource = gax::GaxPreconditions.CheckNotNull(vpnGatewayResource, nameof(vpnGatewayResource)),
            }, callSettings);

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGatewayResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, VpnGateway vpnGatewayResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                VpnGatewayResource = gax::GaxPreconditions.CheckNotNull(vpnGatewayResource, nameof(vpnGatewayResource)),
            }, callSettings);

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="vpnGatewayResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, VpnGateway vpnGatewayResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, vpnGatewayResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGatewayList List(ListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayList> ListAsync(ListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayList> ListAsync(ListVpnGatewaysRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual VpnGatewayList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<VpnGatewayList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetLabels(SetLabelsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetLabelsAsync(SetLabelsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetLabelsAsync(SetLabelsVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            SetLabelsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The region for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="regionSetLabelsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetLabels(string project, string region, string resource, RegionSetLabelsRequest regionSetLabelsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetLabels(new SetLabelsVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionSetLabelsRequestResource = gax::GaxPreconditions.CheckNotNull(regionSetLabelsRequestResource, nameof(regionSetLabelsRequestResource)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
            }, callSettings);

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The region for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="regionSetLabelsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetLabelsAsync(string project, string region, string resource, RegionSetLabelsRequest regionSetLabelsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            SetLabelsAsync(new SetLabelsVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                RegionSetLabelsRequestResource = gax::GaxPreconditions.CheckNotNull(regionSetLabelsRequestResource, nameof(regionSetLabelsRequestResource)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
            }, callSettings);

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The region for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="regionSetLabelsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetLabelsAsync(string project, string region, string resource, RegionSetLabelsRequest regionSetLabelsRequestResource, st::CancellationToken cancellationToken) =>
            SetLabelsAsync(project, region, resource, regionSetLabelsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TestPermissionsResponse TestIamPermissions(TestIamPermissionsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            TestIamPermissionsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The name of the region for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="testPermissionsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TestPermissionsResponse TestIamPermissions(string project, string region, string resource, TestPermissionsRequest testPermissionsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            TestIamPermissions(new TestIamPermissionsVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                TestPermissionsRequestResource = gax::GaxPreconditions.CheckNotNull(testPermissionsRequestResource, nameof(testPermissionsRequestResource)),
            }, callSettings);

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The name of the region for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="testPermissionsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(string project, string region, string resource, TestPermissionsRequest testPermissionsRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            TestIamPermissionsAsync(new TestIamPermissionsVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                Resource = gax::GaxPreconditions.CheckNotNullOrEmpty(resource, nameof(resource)),
                TestPermissionsRequestResource = gax::GaxPreconditions.CheckNotNull(testPermissionsRequestResource, nameof(testPermissionsRequestResource)),
            }, callSettings);

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// The name of the region for this request.
        /// </param>
        /// <param name="resource">
        /// Name or id of the resource for this request.
        /// </param>
        /// <param name="testPermissionsRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(string project, string region, string resource, TestPermissionsRequest testPermissionsRequestResource, st::CancellationToken cancellationToken) =>
            TestIamPermissionsAsync(project, region, resource, testPermissionsRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>VpnGateways client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The VpnGateways API.
    /// </remarks>
    public sealed partial class VpnGatewaysClientImpl : VpnGatewaysClient
    {
        private readonly gaxgrpc::ApiCall<AggregatedListVpnGatewaysRequest, VpnGatewayAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<DeleteVpnGatewayRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetVpnGatewayRequest, VpnGateway> _callGet;

        private readonly gaxgrpc::ApiCall<GetStatusVpnGatewayRequest, VpnGatewaysGetStatusResponse> _callGetStatus;

        private readonly gaxgrpc::ApiCall<InsertVpnGatewayRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListVpnGatewaysRequest, VpnGatewayList> _callList;

        private readonly gaxgrpc::ApiCall<SetLabelsVpnGatewayRequest, Operation> _callSetLabels;

        private readonly gaxgrpc::ApiCall<TestIamPermissionsVpnGatewayRequest, TestPermissionsResponse> _callTestIamPermissions;

        /// <summary>
        /// Constructs a client wrapper for the VpnGateways service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="VpnGatewaysSettings"/> used within this client.</param>
        public VpnGatewaysClientImpl(VpnGateways.VpnGatewaysClient grpcClient, VpnGatewaysSettings settings)
        {
            GrpcClient = grpcClient;
            VpnGatewaysSettings effectiveSettings = settings ?? VpnGatewaysSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListVpnGatewaysRequest, VpnGatewayAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callDelete = clientHelper.BuildApiCall<DeleteVpnGatewayRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("vpn_gateway", request => request.VpnGateway);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetVpnGatewayRequest, VpnGateway>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("vpn_gateway", request => request.VpnGateway);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callGetStatus = clientHelper.BuildApiCall<GetStatusVpnGatewayRequest, VpnGatewaysGetStatusResponse>(grpcClient.GetStatusAsync, grpcClient.GetStatus, effectiveSettings.GetStatusSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("vpn_gateway", request => request.VpnGateway);
            Modify_ApiCall(ref _callGetStatus);
            Modify_GetStatusApiCall(ref _callGetStatus);
            _callInsert = clientHelper.BuildApiCall<InsertVpnGatewayRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListVpnGatewaysRequest, VpnGatewayList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callSetLabels = clientHelper.BuildApiCall<SetLabelsVpnGatewayRequest, Operation>(grpcClient.SetLabelsAsync, grpcClient.SetLabels, effectiveSettings.SetLabelsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("resource", request => request.Resource);
            Modify_ApiCall(ref _callSetLabels);
            Modify_SetLabelsApiCall(ref _callSetLabels);
            _callTestIamPermissions = clientHelper.BuildApiCall<TestIamPermissionsVpnGatewayRequest, TestPermissionsResponse>(grpcClient.TestIamPermissionsAsync, grpcClient.TestIamPermissions, effectiveSettings.TestIamPermissionsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("resource", request => request.Resource);
            Modify_ApiCall(ref _callTestIamPermissions);
            Modify_TestIamPermissionsApiCall(ref _callTestIamPermissions);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListVpnGatewaysRequest, VpnGatewayAggregatedList> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteVpnGatewayRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetVpnGatewayRequest, VpnGateway> call);

        partial void Modify_GetStatusApiCall(ref gaxgrpc::ApiCall<GetStatusVpnGatewayRequest, VpnGatewaysGetStatusResponse> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertVpnGatewayRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListVpnGatewaysRequest, VpnGatewayList> call);

        partial void Modify_SetLabelsApiCall(ref gaxgrpc::ApiCall<SetLabelsVpnGatewayRequest, Operation> call);

        partial void Modify_TestIamPermissionsApiCall(ref gaxgrpc::ApiCall<TestIamPermissionsVpnGatewayRequest, TestPermissionsResponse> call);

        partial void OnConstruction(VpnGateways.VpnGatewaysClient grpcClient, VpnGatewaysSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC VpnGateways client</summary>
        public override VpnGateways.VpnGatewaysClient GrpcClient { get; }

        partial void Modify_AggregatedListVpnGatewaysRequest(ref AggregatedListVpnGatewaysRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteVpnGatewayRequest(ref DeleteVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetVpnGatewayRequest(ref GetVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetStatusVpnGatewayRequest(ref GetStatusVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertVpnGatewayRequest(ref InsertVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListVpnGatewaysRequest(ref ListVpnGatewaysRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetLabelsVpnGatewayRequest(ref SetLabelsVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_TestIamPermissionsVpnGatewayRequest(ref TestIamPermissionsVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override VpnGatewayAggregatedList AggregatedList(AggregatedListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListVpnGatewaysRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<VpnGatewayAggregatedList> AggregatedListAsync(AggregatedListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListVpnGatewaysRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteVpnGatewayRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteVpnGatewayRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override VpnGateway Get(GetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetVpnGatewayRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified VPN gateway. Gets a list of available VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<VpnGateway> GetAsync(GetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetVpnGatewayRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override VpnGatewaysGetStatusResponse GetStatus(GetStatusVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetStatusVpnGatewayRequest(ref request, ref callSettings);
            return _callGetStatus.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the status for the specified VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<VpnGatewaysGetStatusResponse> GetStatusAsync(GetStatusVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetStatusVpnGatewayRequest(ref request, ref callSettings);
            return _callGetStatus.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertVpnGatewayRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertVpnGatewayRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override VpnGatewayList List(ListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListVpnGatewaysRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<VpnGatewayList> ListAsync(ListVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListVpnGatewaysRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetLabels(SetLabelsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetLabelsVpnGatewayRequest(ref request, ref callSettings);
            return _callSetLabels.Sync(request, callSettings);
        }

        /// <summary>
        /// Sets the labels on a VpnGateway. To learn more about labels, read the Labeling Resources documentation.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetLabelsAsync(SetLabelsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetLabelsVpnGatewayRequest(ref request, ref callSettings);
            return _callSetLabels.Async(request, callSettings);
        }

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TestPermissionsResponse TestIamPermissions(TestIamPermissionsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_TestIamPermissionsVpnGatewayRequest(ref request, ref callSettings);
            return _callTestIamPermissions.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TestPermissionsResponse> TestIamPermissionsAsync(TestIamPermissionsVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_TestIamPermissionsVpnGatewayRequest(ref request, ref callSettings);
            return _callTestIamPermissions.Async(request, callSettings);
        }
    }
}
