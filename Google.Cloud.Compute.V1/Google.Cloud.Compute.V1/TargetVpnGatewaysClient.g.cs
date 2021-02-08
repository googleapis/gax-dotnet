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
    /// <summary>Settings for <see cref="TargetVpnGatewaysClient"/> instances.</summary>
    public sealed partial class TargetVpnGatewaysSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="TargetVpnGatewaysSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="TargetVpnGatewaysSettings"/>.</returns>
        public static TargetVpnGatewaysSettings GetDefault() => new TargetVpnGatewaysSettings();

        /// <summary>Constructs a new <see cref="TargetVpnGatewaysSettings"/> object with default settings.</summary>
        public TargetVpnGatewaysSettings()
        {
        }

        private TargetVpnGatewaysSettings(TargetVpnGatewaysSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AggregatedListSettings = existing.AggregatedListSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            OnCopy(existing);
        }

        partial void OnCopy(TargetVpnGatewaysSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TargetVpnGatewaysClient.AggregatedList</c> and <c>TargetVpnGatewaysClient.AggregatedListAsync</c>.
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
        /// <c>TargetVpnGatewaysClient.Delete</c> and <c>TargetVpnGatewaysClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetVpnGatewaysClient.Get</c>
        ///  and <c>TargetVpnGatewaysClient.GetAsync</c>.
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
        /// <c>TargetVpnGatewaysClient.Insert</c> and <c>TargetVpnGatewaysClient.InsertAsync</c>.
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
        /// <c>TargetVpnGatewaysClient.List</c> and <c>TargetVpnGatewaysClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="TargetVpnGatewaysSettings"/> object.</returns>
        public TargetVpnGatewaysSettings Clone() => new TargetVpnGatewaysSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="TargetVpnGatewaysClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class TargetVpnGatewaysClientBuilder : gaxgrpc::ClientBuilderBase<TargetVpnGatewaysClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public TargetVpnGatewaysSettings Settings { get; set; }

        partial void InterceptBuild(ref TargetVpnGatewaysClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<TargetVpnGatewaysClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override TargetVpnGatewaysClient Build()
        {
            TargetVpnGatewaysClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<TargetVpnGatewaysClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<TargetVpnGatewaysClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private TargetVpnGatewaysClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return TargetVpnGatewaysClient.Create(callInvoker, Settings);
        }

        private async stt::Task<TargetVpnGatewaysClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return TargetVpnGatewaysClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => TargetVpnGatewaysClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => TargetVpnGatewaysClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => TargetVpnGatewaysClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>TargetVpnGateways client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The TargetVpnGateways API.
    /// </remarks>
    public abstract partial class TargetVpnGatewaysClient
    {
        /// <summary>
        /// The default endpoint for the TargetVpnGateways service, which is a host of "compute.googleapis.com" and a
        /// port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default TargetVpnGateways scopes.</summary>
        /// <remarks>
        /// The default TargetVpnGateways scopes are:
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
        /// Asynchronously creates a <see cref="TargetVpnGatewaysClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TargetVpnGatewaysClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="TargetVpnGatewaysClient"/>.</returns>
        public static stt::Task<TargetVpnGatewaysClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new TargetVpnGatewaysClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="TargetVpnGatewaysClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TargetVpnGatewaysClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="TargetVpnGatewaysClient"/>.</returns>
        public static TargetVpnGatewaysClient Create() => new TargetVpnGatewaysClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="TargetVpnGatewaysClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="TargetVpnGatewaysSettings"/>.</param>
        /// <returns>The created <see cref="TargetVpnGatewaysClient"/>.</returns>
        internal static TargetVpnGatewaysClient Create(grpccore::CallInvoker callInvoker, TargetVpnGatewaysSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            TargetVpnGateways.TargetVpnGatewaysClient grpcClient = new TargetVpnGateways.TargetVpnGatewaysClient(callInvoker);
            return new TargetVpnGatewaysClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC TargetVpnGateways client</summary>
        public virtual TargetVpnGateways.TargetVpnGatewaysClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetVpnGatewayAggregatedList AggregatedList(AggregatedListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayAggregatedList> AggregatedListAsync(AggregatedListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayAggregatedList> AggregatedListAsync(AggregatedListTargetVpnGatewaysRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetVpnGatewayAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListTargetVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListTargetVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteTargetVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGateway">
        /// Name of the target VPN gateway to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string targetVpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteTargetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetVpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(targetVpnGateway, nameof(targetVpnGateway)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGateway">
        /// Name of the target VPN gateway to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string targetVpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteTargetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetVpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(targetVpnGateway, nameof(targetVpnGateway)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGateway">
        /// Name of the target VPN gateway to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string targetVpnGateway, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, targetVpnGateway, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetVpnGateway Get(GetTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGateway> GetAsync(GetTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGateway> GetAsync(GetTargetVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGateway">
        /// Name of the target VPN gateway to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetVpnGateway Get(string project, string region, string targetVpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetTargetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetVpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(targetVpnGateway, nameof(targetVpnGateway)),
            }, callSettings);

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGateway">
        /// Name of the target VPN gateway to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGateway> GetAsync(string project, string region, string targetVpnGateway, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetTargetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetVpnGateway = gax::GaxPreconditions.CheckNotNullOrEmpty(targetVpnGateway, nameof(targetVpnGateway)),
            }, callSettings);

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGateway">
        /// Name of the target VPN gateway to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGateway> GetAsync(string project, string region, string targetVpnGateway, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, targetVpnGateway, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertTargetVpnGatewayRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGatewayResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, TargetVpnGateway targetVpnGatewayResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertTargetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetVpnGatewayResource = gax::GaxPreconditions.CheckNotNull(targetVpnGatewayResource, nameof(targetVpnGatewayResource)),
            }, callSettings);

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGatewayResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, TargetVpnGateway targetVpnGatewayResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertTargetVpnGatewayRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetVpnGatewayResource = gax::GaxPreconditions.CheckNotNull(targetVpnGatewayResource, nameof(targetVpnGatewayResource)),
            }, callSettings);

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetVpnGatewayResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, TargetVpnGateway targetVpnGatewayResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, targetVpnGatewayResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetVpnGatewayList List(ListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayList> ListAsync(ListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayList> ListAsync(ListTargetVpnGatewaysRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetVpnGatewayList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListTargetVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListTargetVpnGatewaysRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetVpnGatewayList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>TargetVpnGateways client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The TargetVpnGateways API.
    /// </remarks>
    public sealed partial class TargetVpnGatewaysClientImpl : TargetVpnGatewaysClient
    {
        private readonly gaxgrpc::ApiCall<AggregatedListTargetVpnGatewaysRequest, TargetVpnGatewayAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<DeleteTargetVpnGatewayRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetTargetVpnGatewayRequest, TargetVpnGateway> _callGet;

        private readonly gaxgrpc::ApiCall<InsertTargetVpnGatewayRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListTargetVpnGatewaysRequest, TargetVpnGatewayList> _callList;

        /// <summary>
        /// Constructs a client wrapper for the TargetVpnGateways service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="TargetVpnGatewaysSettings"/> used within this client.</param>
        public TargetVpnGatewaysClientImpl(TargetVpnGateways.TargetVpnGatewaysClient grpcClient, TargetVpnGatewaysSettings settings)
        {
            GrpcClient = grpcClient;
            TargetVpnGatewaysSettings effectiveSettings = settings ?? TargetVpnGatewaysSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListTargetVpnGatewaysRequest, TargetVpnGatewayAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callDelete = clientHelper.BuildApiCall<DeleteTargetVpnGatewayRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_vpn_gateway", request => request.TargetVpnGateway);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetTargetVpnGatewayRequest, TargetVpnGateway>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_vpn_gateway", request => request.TargetVpnGateway);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertTargetVpnGatewayRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListTargetVpnGatewaysRequest, TargetVpnGatewayList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListTargetVpnGatewaysRequest, TargetVpnGatewayAggregatedList> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteTargetVpnGatewayRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetTargetVpnGatewayRequest, TargetVpnGateway> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertTargetVpnGatewayRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListTargetVpnGatewaysRequest, TargetVpnGatewayList> call);

        partial void OnConstruction(TargetVpnGateways.TargetVpnGatewaysClient grpcClient, TargetVpnGatewaysSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC TargetVpnGateways client</summary>
        public override TargetVpnGateways.TargetVpnGatewaysClient GrpcClient { get; }

        partial void Modify_AggregatedListTargetVpnGatewaysRequest(ref AggregatedListTargetVpnGatewaysRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteTargetVpnGatewayRequest(ref DeleteTargetVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetTargetVpnGatewayRequest(ref GetTargetVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertTargetVpnGatewayRequest(ref InsertTargetVpnGatewayRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListTargetVpnGatewaysRequest(ref ListTargetVpnGatewaysRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetVpnGatewayAggregatedList AggregatedList(AggregatedListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListTargetVpnGatewaysRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of target VPN gateways.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetVpnGatewayAggregatedList> AggregatedListAsync(AggregatedListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListTargetVpnGatewaysRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTargetVpnGatewayRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified target VPN gateway.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTargetVpnGatewayRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetVpnGateway Get(GetTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetTargetVpnGatewayRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified target VPN gateway. Gets a list of available target VPN gateways by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetVpnGateway> GetAsync(GetTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetTargetVpnGatewayRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertTargetVpnGatewayRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a target VPN gateway in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertTargetVpnGatewayRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertTargetVpnGatewayRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetVpnGatewayList List(ListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTargetVpnGatewaysRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of target VPN gateways available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetVpnGatewayList> ListAsync(ListTargetVpnGatewaysRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTargetVpnGatewaysRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }
    }
}
