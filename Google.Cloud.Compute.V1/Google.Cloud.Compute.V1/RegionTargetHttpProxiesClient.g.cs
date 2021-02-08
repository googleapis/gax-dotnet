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
    /// <summary>Settings for <see cref="RegionTargetHttpProxiesClient"/> instances.</summary>
    public sealed partial class RegionTargetHttpProxiesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="RegionTargetHttpProxiesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="RegionTargetHttpProxiesSettings"/>.</returns>
        public static RegionTargetHttpProxiesSettings GetDefault() => new RegionTargetHttpProxiesSettings();

        /// <summary>
        /// Constructs a new <see cref="RegionTargetHttpProxiesSettings"/> object with default settings.
        /// </summary>
        public RegionTargetHttpProxiesSettings()
        {
        }

        private RegionTargetHttpProxiesSettings(RegionTargetHttpProxiesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            SetUrlMapSettings = existing.SetUrlMapSettings;
            OnCopy(existing);
        }

        partial void OnCopy(RegionTargetHttpProxiesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>RegionTargetHttpProxiesClient.Delete</c> and <c>RegionTargetHttpProxiesClient.DeleteAsync</c>.
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
        /// <c>RegionTargetHttpProxiesClient.Get</c> and <c>RegionTargetHttpProxiesClient.GetAsync</c>.
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
        /// <c>RegionTargetHttpProxiesClient.Insert</c> and <c>RegionTargetHttpProxiesClient.InsertAsync</c>.
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
        /// <c>RegionTargetHttpProxiesClient.List</c> and <c>RegionTargetHttpProxiesClient.ListAsync</c>.
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
        /// <c>RegionTargetHttpProxiesClient.SetUrlMap</c> and <c>RegionTargetHttpProxiesClient.SetUrlMapAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetUrlMapSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="RegionTargetHttpProxiesSettings"/> object.</returns>
        public RegionTargetHttpProxiesSettings Clone() => new RegionTargetHttpProxiesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="RegionTargetHttpProxiesClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class RegionTargetHttpProxiesClientBuilder : gaxgrpc::ClientBuilderBase<RegionTargetHttpProxiesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public RegionTargetHttpProxiesSettings Settings { get; set; }

        partial void InterceptBuild(ref RegionTargetHttpProxiesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<RegionTargetHttpProxiesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override RegionTargetHttpProxiesClient Build()
        {
            RegionTargetHttpProxiesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<RegionTargetHttpProxiesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<RegionTargetHttpProxiesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private RegionTargetHttpProxiesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return RegionTargetHttpProxiesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<RegionTargetHttpProxiesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return RegionTargetHttpProxiesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => RegionTargetHttpProxiesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => RegionTargetHttpProxiesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => RegionTargetHttpProxiesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>RegionTargetHttpProxies client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The RegionTargetHttpProxies API.
    /// </remarks>
    public abstract partial class RegionTargetHttpProxiesClient
    {
        /// <summary>
        /// The default endpoint for the RegionTargetHttpProxies service, which is a host of "compute.googleapis.com"
        /// and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default RegionTargetHttpProxies scopes.</summary>
        /// <remarks>
        /// The default RegionTargetHttpProxies scopes are:
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
        /// Asynchronously creates a <see cref="RegionTargetHttpProxiesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="RegionTargetHttpProxiesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="RegionTargetHttpProxiesClient"/>.</returns>
        public static stt::Task<RegionTargetHttpProxiesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new RegionTargetHttpProxiesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="RegionTargetHttpProxiesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="RegionTargetHttpProxiesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="RegionTargetHttpProxiesClient"/>.</returns>
        public static RegionTargetHttpProxiesClient Create() => new RegionTargetHttpProxiesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="RegionTargetHttpProxiesClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="RegionTargetHttpProxiesSettings"/>.</param>
        /// <returns>The created <see cref="RegionTargetHttpProxiesClient"/>.</returns>
        internal static RegionTargetHttpProxiesClient Create(grpccore::CallInvoker callInvoker, RegionTargetHttpProxiesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            RegionTargetHttpProxies.RegionTargetHttpProxiesClient grpcClient = new RegionTargetHttpProxies.RegionTargetHttpProxiesClient(callInvoker);
            return new RegionTargetHttpProxiesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC RegionTargetHttpProxies client</summary>
        public virtual RegionTargetHttpProxies.RegionTargetHttpProxiesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionTargetHttpProxyRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string targetHttpProxy, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetHttpProxy, nameof(targetHttpProxy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string targetHttpProxy, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetHttpProxy, nameof(targetHttpProxy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string targetHttpProxy, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, targetHttpProxy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetHttpProxy Get(GetRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxy> GetAsync(GetRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxy> GetAsync(GetRegionTargetHttpProxyRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetHttpProxy Get(string project, string region, string targetHttpProxy, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetHttpProxy, nameof(targetHttpProxy)),
            }, callSettings);

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxy> GetAsync(string project, string region, string targetHttpProxy, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetHttpProxy, nameof(targetHttpProxy)),
            }, callSettings);

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxy> GetAsync(string project, string region, string targetHttpProxy, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, targetHttpProxy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionTargetHttpProxyRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, TargetHttpProxy targetHttpProxyResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxyResource = gax::GaxPreconditions.CheckNotNull(targetHttpProxyResource, nameof(targetHttpProxyResource)),
            }, callSettings);

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, TargetHttpProxy targetHttpProxyResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxyResource = gax::GaxPreconditions.CheckNotNull(targetHttpProxyResource, nameof(targetHttpProxyResource)),
            }, callSettings);

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, TargetHttpProxy targetHttpProxyResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, targetHttpProxyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetHttpProxyList List(ListRegionTargetHttpProxiesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxyList> ListAsync(ListRegionTargetHttpProxiesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxyList> ListAsync(ListRegionTargetHttpProxiesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetHttpProxyList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListRegionTargetHttpProxiesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxyList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListRegionTargetHttpProxiesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetHttpProxyList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetUrlMap(SetUrlMapRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetUrlMapAsync(SetUrlMapRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetUrlMapAsync(SetUrlMapRegionTargetHttpProxyRequest request, st::CancellationToken cancellationToken) =>
            SetUrlMapAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy to set a URL map for.
        /// </param>
        /// <param name="urlMapReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetUrlMap(string project, string region, string targetHttpProxy, UrlMapReference urlMapReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            SetUrlMap(new SetUrlMapRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetHttpProxy, nameof(targetHttpProxy)),
                UrlMapReferenceResource = gax::GaxPreconditions.CheckNotNull(urlMapReferenceResource, nameof(urlMapReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy to set a URL map for.
        /// </param>
        /// <param name="urlMapReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetUrlMapAsync(string project, string region, string targetHttpProxy, UrlMapReference urlMapReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            SetUrlMapAsync(new SetUrlMapRegionTargetHttpProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetHttpProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetHttpProxy, nameof(targetHttpProxy)),
                UrlMapReferenceResource = gax::GaxPreconditions.CheckNotNull(urlMapReferenceResource, nameof(urlMapReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetHttpProxy">
        /// Name of the TargetHttpProxy to set a URL map for.
        /// </param>
        /// <param name="urlMapReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetUrlMapAsync(string project, string region, string targetHttpProxy, UrlMapReference urlMapReferenceResource, st::CancellationToken cancellationToken) =>
            SetUrlMapAsync(project, region, targetHttpProxy, urlMapReferenceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>RegionTargetHttpProxies client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The RegionTargetHttpProxies API.
    /// </remarks>
    public sealed partial class RegionTargetHttpProxiesClientImpl : RegionTargetHttpProxiesClient
    {
        private readonly gaxgrpc::ApiCall<DeleteRegionTargetHttpProxyRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetRegionTargetHttpProxyRequest, TargetHttpProxy> _callGet;

        private readonly gaxgrpc::ApiCall<InsertRegionTargetHttpProxyRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListRegionTargetHttpProxiesRequest, TargetHttpProxyList> _callList;

        private readonly gaxgrpc::ApiCall<SetUrlMapRegionTargetHttpProxyRequest, Operation> _callSetUrlMap;

        /// <summary>
        /// Constructs a client wrapper for the RegionTargetHttpProxies service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">
        /// The base <see cref="RegionTargetHttpProxiesSettings"/> used within this client.
        /// </param>
        public RegionTargetHttpProxiesClientImpl(RegionTargetHttpProxies.RegionTargetHttpProxiesClient grpcClient, RegionTargetHttpProxiesSettings settings)
        {
            GrpcClient = grpcClient;
            RegionTargetHttpProxiesSettings effectiveSettings = settings ?? RegionTargetHttpProxiesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteRegionTargetHttpProxyRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_http_proxy", request => request.TargetHttpProxy);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetRegionTargetHttpProxyRequest, TargetHttpProxy>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_http_proxy", request => request.TargetHttpProxy);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertRegionTargetHttpProxyRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListRegionTargetHttpProxiesRequest, TargetHttpProxyList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callSetUrlMap = clientHelper.BuildApiCall<SetUrlMapRegionTargetHttpProxyRequest, Operation>(grpcClient.SetUrlMapAsync, grpcClient.SetUrlMap, effectiveSettings.SetUrlMapSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_http_proxy", request => request.TargetHttpProxy);
            Modify_ApiCall(ref _callSetUrlMap);
            Modify_SetUrlMapApiCall(ref _callSetUrlMap);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteRegionTargetHttpProxyRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetRegionTargetHttpProxyRequest, TargetHttpProxy> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertRegionTargetHttpProxyRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListRegionTargetHttpProxiesRequest, TargetHttpProxyList> call);

        partial void Modify_SetUrlMapApiCall(ref gaxgrpc::ApiCall<SetUrlMapRegionTargetHttpProxyRequest, Operation> call);

        partial void OnConstruction(RegionTargetHttpProxies.RegionTargetHttpProxiesClient grpcClient, RegionTargetHttpProxiesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC RegionTargetHttpProxies client</summary>
        public override RegionTargetHttpProxies.RegionTargetHttpProxiesClient GrpcClient { get; }

        partial void Modify_DeleteRegionTargetHttpProxyRequest(ref DeleteRegionTargetHttpProxyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRegionTargetHttpProxyRequest(ref GetRegionTargetHttpProxyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertRegionTargetHttpProxyRequest(ref InsertRegionTargetHttpProxyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRegionTargetHttpProxiesRequest(ref ListRegionTargetHttpProxiesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetUrlMapRegionTargetHttpProxyRequest(ref SetUrlMapRegionTargetHttpProxyRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified TargetHttpProxy resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetHttpProxy Get(GetRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified TargetHttpProxy resource in the specified region. Gets a list of available target HTTP proxies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetHttpProxy> GetAsync(GetRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a TargetHttpProxy resource in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetHttpProxyList List(ListRegionTargetHttpProxiesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionTargetHttpProxiesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of TargetHttpProxy resources available to the specified project in the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetHttpProxyList> ListAsync(ListRegionTargetHttpProxiesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionTargetHttpProxiesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetUrlMap(SetUrlMapRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetUrlMapRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callSetUrlMap.Sync(request, callSettings);
        }

        /// <summary>
        /// Changes the URL map for TargetHttpProxy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetUrlMapAsync(SetUrlMapRegionTargetHttpProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetUrlMapRegionTargetHttpProxyRequest(ref request, ref callSettings);
            return _callSetUrlMap.Async(request, callSettings);
        }
    }
}
