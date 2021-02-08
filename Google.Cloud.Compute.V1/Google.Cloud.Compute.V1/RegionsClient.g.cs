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
    /// <summary>Settings for <see cref="RegionsClient"/> instances.</summary>
    public sealed partial class RegionsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="RegionsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="RegionsSettings"/>.</returns>
        public static RegionsSettings GetDefault() => new RegionsSettings();

        /// <summary>Constructs a new <see cref="RegionsSettings"/> object with default settings.</summary>
        public RegionsSettings()
        {
        }

        private RegionsSettings(RegionsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            GetSettings = existing.GetSettings;
            ListSettings = existing.ListSettings;
            OnCopy(existing);
        }

        partial void OnCopy(RegionsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>RegionsClient.Get</c> and
        /// <c>RegionsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>RegionsClient.List</c> and
        /// <c>RegionsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="RegionsSettings"/> object.</returns>
        public RegionsSettings Clone() => new RegionsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="RegionsClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class RegionsClientBuilder : gaxgrpc::ClientBuilderBase<RegionsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public RegionsSettings Settings { get; set; }

        partial void InterceptBuild(ref RegionsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<RegionsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override RegionsClient Build()
        {
            RegionsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<RegionsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<RegionsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private RegionsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return RegionsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<RegionsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return RegionsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => RegionsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => RegionsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => RegionsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>Regions client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The Regions API.
    /// </remarks>
    public abstract partial class RegionsClient
    {
        /// <summary>
        /// The default endpoint for the Regions service, which is a host of "compute.googleapis.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default Regions scopes.</summary>
        /// <remarks>
        /// The default Regions scopes are:
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
        /// Asynchronously creates a <see cref="RegionsClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="RegionsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="RegionsClient"/>.</returns>
        public static stt::Task<RegionsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new RegionsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="RegionsClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="RegionsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="RegionsClient"/>.</returns>
        public static RegionsClient Create() => new RegionsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="RegionsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="RegionsSettings"/>.</param>
        /// <returns>The created <see cref="RegionsClient"/>.</returns>
        internal static RegionsClient Create(grpccore::CallInvoker callInvoker, RegionsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Regions.RegionsClient grpcClient = new Regions.RegionsClient(callInvoker);
            return new RegionsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC Regions client</summary>
        public virtual Regions.RegionsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Region Get(GetRegionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Region> GetAsync(GetRegionRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Region> GetAsync(GetRegionRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Region Get(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetRegionRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Region> GetAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetRegionRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Region> GetAsync(string project, string region, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionList List(ListRegionsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionList> ListAsync(ListRegionsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionList> ListAsync(ListRegionsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual RegionList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListRegionsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListRegionsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<RegionList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Regions client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The Regions API.
    /// </remarks>
    public sealed partial class RegionsClientImpl : RegionsClient
    {
        private readonly gaxgrpc::ApiCall<GetRegionRequest, Region> _callGet;

        private readonly gaxgrpc::ApiCall<ListRegionsRequest, RegionList> _callList;

        /// <summary>
        /// Constructs a client wrapper for the Regions service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="RegionsSettings"/> used within this client.</param>
        public RegionsClientImpl(Regions.RegionsClient grpcClient, RegionsSettings settings)
        {
            GrpcClient = grpcClient;
            RegionsSettings effectiveSettings = settings ?? RegionsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callGet = clientHelper.BuildApiCall<GetRegionRequest, Region>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callList = clientHelper.BuildApiCall<ListRegionsRequest, RegionList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetRegionRequest, Region> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListRegionsRequest, RegionList> call);

        partial void OnConstruction(Regions.RegionsClient grpcClient, RegionsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Regions client</summary>
        public override Regions.RegionsClient GrpcClient { get; }

        partial void Modify_GetRegionRequest(ref GetRegionRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRegionsRequest(ref ListRegionsRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Region Get(GetRegionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified Region resource. Gets a list of available regions by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Region> GetAsync(GetRegionRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override RegionList List(ListRegionsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of region resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<RegionList> ListAsync(ListRegionsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }
    }
}
