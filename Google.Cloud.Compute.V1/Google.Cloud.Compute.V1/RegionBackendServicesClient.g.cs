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
    /// <summary>Settings for <see cref="RegionBackendServicesClient"/> instances.</summary>
    public sealed partial class RegionBackendServicesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="RegionBackendServicesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="RegionBackendServicesSettings"/>.</returns>
        public static RegionBackendServicesSettings GetDefault() => new RegionBackendServicesSettings();

        /// <summary>
        /// Constructs a new <see cref="RegionBackendServicesSettings"/> object with default settings.
        /// </summary>
        public RegionBackendServicesSettings()
        {
        }

        private RegionBackendServicesSettings(RegionBackendServicesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            GetHealthSettings = existing.GetHealthSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            UpdateSettings = existing.UpdateSettings;
            OnCopy(existing);
        }

        partial void OnCopy(RegionBackendServicesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>RegionBackendServicesClient.Delete</c> and <c>RegionBackendServicesClient.DeleteAsync</c>.
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
        /// <c>RegionBackendServicesClient.Get</c> and <c>RegionBackendServicesClient.GetAsync</c>.
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
        /// <c>RegionBackendServicesClient.GetHealth</c> and <c>RegionBackendServicesClient.GetHealthAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetHealthSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>RegionBackendServicesClient.Insert</c> and <c>RegionBackendServicesClient.InsertAsync</c>.
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
        /// <c>RegionBackendServicesClient.List</c> and <c>RegionBackendServicesClient.ListAsync</c>.
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
        /// <c>RegionBackendServicesClient.Patch</c> and <c>RegionBackendServicesClient.PatchAsync</c>.
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
        /// <c>RegionBackendServicesClient.Update</c> and <c>RegionBackendServicesClient.UpdateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="RegionBackendServicesSettings"/> object.</returns>
        public RegionBackendServicesSettings Clone() => new RegionBackendServicesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="RegionBackendServicesClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class RegionBackendServicesClientBuilder : gaxgrpc::ClientBuilderBase<RegionBackendServicesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public RegionBackendServicesSettings Settings { get; set; }

        partial void InterceptBuild(ref RegionBackendServicesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<RegionBackendServicesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override RegionBackendServicesClient Build()
        {
            RegionBackendServicesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<RegionBackendServicesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<RegionBackendServicesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private RegionBackendServicesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return RegionBackendServicesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<RegionBackendServicesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return RegionBackendServicesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => RegionBackendServicesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => RegionBackendServicesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => RegionBackendServicesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>RegionBackendServices client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The RegionBackendServices API.
    /// </remarks>
    public abstract partial class RegionBackendServicesClient
    {
        /// <summary>
        /// The default endpoint for the RegionBackendServices service, which is a host of "compute.googleapis.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default RegionBackendServices scopes.</summary>
        /// <remarks>
        /// The default RegionBackendServices scopes are:
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
        /// Asynchronously creates a <see cref="RegionBackendServicesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="RegionBackendServicesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="RegionBackendServicesClient"/>.</returns>
        public static stt::Task<RegionBackendServicesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new RegionBackendServicesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="RegionBackendServicesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="RegionBackendServicesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="RegionBackendServicesClient"/>.</returns>
        public static RegionBackendServicesClient Create() => new RegionBackendServicesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="RegionBackendServicesClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="RegionBackendServicesSettings"/>.</param>
        /// <returns>The created <see cref="RegionBackendServicesClient"/>.</returns>
        internal static RegionBackendServicesClient Create(grpccore::CallInvoker callInvoker, RegionBackendServicesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            RegionBackendServices.RegionBackendServicesClient grpcClient = new RegionBackendServices.RegionBackendServicesClient(callInvoker);
            return new RegionBackendServicesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC RegionBackendServices client</summary>
        public virtual RegionBackendServices.RegionBackendServicesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionBackendServiceRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string backendService, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string backendService, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string backendService, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, backendService, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendService Get(GetRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendService> GetAsync(GetRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendService> GetAsync(GetRegionBackendServiceRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendService Get(string project, string region, string backendService, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendService> GetAsync(string project, string region, string backendService, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendService> GetAsync(string project, string region, string backendService, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, backendService, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendServiceGroupHealth GetHealth(GetHealthRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceGroupHealth> GetHealthAsync(GetHealthRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceGroupHealth> GetHealthAsync(GetHealthRegionBackendServiceRequest request, st::CancellationToken cancellationToken) =>
            GetHealthAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="project">
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource for which to get health.
        /// </param>
        /// <param name="resourceGroupReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendServiceGroupHealth GetHealth(string project, string region, string backendService, ResourceGroupReference resourceGroupReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            GetHealth(new GetHealthRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                ResourceGroupReferenceResource = gax::GaxPreconditions.CheckNotNull(resourceGroupReferenceResource, nameof(resourceGroupReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="project">
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource for which to get health.
        /// </param>
        /// <param name="resourceGroupReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceGroupHealth> GetHealthAsync(string project, string region, string backendService, ResourceGroupReference resourceGroupReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            GetHealthAsync(new GetHealthRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                ResourceGroupReferenceResource = gax::GaxPreconditions.CheckNotNull(resourceGroupReferenceResource, nameof(resourceGroupReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="project">
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource for which to get health.
        /// </param>
        /// <param name="resourceGroupReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceGroupHealth> GetHealthAsync(string project, string region, string backendService, ResourceGroupReference resourceGroupReferenceResource, st::CancellationToken cancellationToken) =>
            GetHealthAsync(project, region, backendService, resourceGroupReferenceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionBackendServiceRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, BackendService backendServiceResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertRegionBackendServiceRequest
            {
                BackendServiceResource = gax::GaxPreconditions.CheckNotNull(backendServiceResource, nameof(backendServiceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, BackendService backendServiceResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertRegionBackendServiceRequest
            {
                BackendServiceResource = gax::GaxPreconditions.CheckNotNull(backendServiceResource, nameof(backendServiceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, BackendService backendServiceResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, backendServiceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendServiceList List(ListRegionBackendServicesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceList> ListAsync(ListRegionBackendServicesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceList> ListAsync(ListRegionBackendServicesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendServiceList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListRegionBackendServicesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListRegionBackendServicesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendServiceList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchRegionBackendServiceRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to patch.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string region, string backendService, BackendService backendServiceResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                BackendServiceResource = gax::GaxPreconditions.CheckNotNull(backendServiceResource, nameof(backendServiceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to patch.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string region, string backendService, BackendService backendServiceResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                BackendServiceResource = gax::GaxPreconditions.CheckNotNull(backendServiceResource, nameof(backendServiceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to patch.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string region, string backendService, BackendService backendServiceResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, region, backendService, backendServiceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(UpdateRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateRegionBackendServiceRequest request, st::CancellationToken cancellationToken) =>
            UpdateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to update.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(string project, string region, string backendService, BackendService backendServiceResource, gaxgrpc::CallSettings callSettings = null) =>
            Update(new UpdateRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                BackendServiceResource = gax::GaxPreconditions.CheckNotNull(backendServiceResource, nameof(backendServiceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to update.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string region, string backendService, BackendService backendServiceResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdateAsync(new UpdateRegionBackendServiceRequest
            {
                BackendService = gax::GaxPreconditions.CheckNotNullOrEmpty(backendService, nameof(backendService)),
                BackendServiceResource = gax::GaxPreconditions.CheckNotNull(backendServiceResource, nameof(backendServiceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="backendService">
        /// Name of the BackendService resource to update.
        /// </param>
        /// <param name="backendServiceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string region, string backendService, BackendService backendServiceResource, st::CancellationToken cancellationToken) =>
            UpdateAsync(project, region, backendService, backendServiceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>RegionBackendServices client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The RegionBackendServices API.
    /// </remarks>
    public sealed partial class RegionBackendServicesClientImpl : RegionBackendServicesClient
    {
        private readonly gaxgrpc::ApiCall<DeleteRegionBackendServiceRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetRegionBackendServiceRequest, BackendService> _callGet;

        private readonly gaxgrpc::ApiCall<GetHealthRegionBackendServiceRequest, BackendServiceGroupHealth> _callGetHealth;

        private readonly gaxgrpc::ApiCall<InsertRegionBackendServiceRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListRegionBackendServicesRequest, BackendServiceList> _callList;

        private readonly gaxgrpc::ApiCall<PatchRegionBackendServiceRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<UpdateRegionBackendServiceRequest, Operation> _callUpdate;

        /// <summary>
        /// Constructs a client wrapper for the RegionBackendServices service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="RegionBackendServicesSettings"/> used within this client.</param>
        public RegionBackendServicesClientImpl(RegionBackendServices.RegionBackendServicesClient grpcClient, RegionBackendServicesSettings settings)
        {
            GrpcClient = grpcClient;
            RegionBackendServicesSettings effectiveSettings = settings ?? RegionBackendServicesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteRegionBackendServiceRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("backend_service", request => request.BackendService);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetRegionBackendServiceRequest, BackendService>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("backend_service", request => request.BackendService);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callGetHealth = clientHelper.BuildApiCall<GetHealthRegionBackendServiceRequest, BackendServiceGroupHealth>(grpcClient.GetHealthAsync, grpcClient.GetHealth, effectiveSettings.GetHealthSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("backend_service", request => request.BackendService);
            Modify_ApiCall(ref _callGetHealth);
            Modify_GetHealthApiCall(ref _callGetHealth);
            _callInsert = clientHelper.BuildApiCall<InsertRegionBackendServiceRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListRegionBackendServicesRequest, BackendServiceList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchRegionBackendServiceRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("backend_service", request => request.BackendService);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callUpdate = clientHelper.BuildApiCall<UpdateRegionBackendServiceRequest, Operation>(grpcClient.UpdateAsync, grpcClient.Update, effectiveSettings.UpdateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("backend_service", request => request.BackendService);
            Modify_ApiCall(ref _callUpdate);
            Modify_UpdateApiCall(ref _callUpdate);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteRegionBackendServiceRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetRegionBackendServiceRequest, BackendService> call);

        partial void Modify_GetHealthApiCall(ref gaxgrpc::ApiCall<GetHealthRegionBackendServiceRequest, BackendServiceGroupHealth> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertRegionBackendServiceRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListRegionBackendServicesRequest, BackendServiceList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchRegionBackendServiceRequest, Operation> call);

        partial void Modify_UpdateApiCall(ref gaxgrpc::ApiCall<UpdateRegionBackendServiceRequest, Operation> call);

        partial void OnConstruction(RegionBackendServices.RegionBackendServicesClient grpcClient, RegionBackendServicesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC RegionBackendServices client</summary>
        public override RegionBackendServices.RegionBackendServicesClient GrpcClient { get; }

        partial void Modify_DeleteRegionBackendServiceRequest(ref DeleteRegionBackendServiceRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRegionBackendServiceRequest(ref GetRegionBackendServiceRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetHealthRegionBackendServiceRequest(ref GetHealthRegionBackendServiceRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertRegionBackendServiceRequest(ref InsertRegionBackendServiceRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRegionBackendServicesRequest(ref ListRegionBackendServicesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchRegionBackendServiceRequest(ref PatchRegionBackendServiceRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateRegionBackendServiceRequest(ref UpdateRegionBackendServiceRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionBackendServiceRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionBackendServiceRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override BackendService Get(GetRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionBackendServiceRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified regional BackendService resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<BackendService> GetAsync(GetRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionBackendServiceRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override BackendServiceGroupHealth GetHealth(GetHealthRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetHealthRegionBackendServiceRequest(ref request, ref callSettings);
            return _callGetHealth.Sync(request, callSettings);
        }

        /// <summary>
        /// Gets the most recent health check results for this regional BackendService.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<BackendServiceGroupHealth> GetHealthAsync(GetHealthRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetHealthRegionBackendServiceRequest(ref request, ref callSettings);
            return _callGetHealth.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionBackendServiceRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a regional BackendService resource in the specified project using the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionBackendServiceRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override BackendServiceList List(ListRegionBackendServicesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionBackendServicesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of regional BackendService resources available to the specified project in the given region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<BackendServiceList> ListAsync(ListRegionBackendServicesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionBackendServicesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRegionBackendServiceRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Understanding backend services This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRegionBackendServiceRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Update(UpdateRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateRegionBackendServiceRequest(ref request, ref callSettings);
            return _callUpdate.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified regional BackendService resource with the data included in the request. For more information, see  Backend services overview.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdateAsync(UpdateRegionBackendServiceRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateRegionBackendServiceRequest(ref request, ref callSettings);
            return _callUpdate.Async(request, callSettings);
        }
    }
}
