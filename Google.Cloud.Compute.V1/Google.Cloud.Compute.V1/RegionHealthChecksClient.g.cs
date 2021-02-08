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
    /// <summary>Settings for <see cref="RegionHealthChecksClient"/> instances.</summary>
    public sealed partial class RegionHealthChecksSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="RegionHealthChecksSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="RegionHealthChecksSettings"/>.</returns>
        public static RegionHealthChecksSettings GetDefault() => new RegionHealthChecksSettings();

        /// <summary>Constructs a new <see cref="RegionHealthChecksSettings"/> object with default settings.</summary>
        public RegionHealthChecksSettings()
        {
        }

        private RegionHealthChecksSettings(RegionHealthChecksSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            UpdateSettings = existing.UpdateSettings;
            OnCopy(existing);
        }

        partial void OnCopy(RegionHealthChecksSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>RegionHealthChecksClient.Delete</c> and <c>RegionHealthChecksClient.DeleteAsync</c>.
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
        /// <c>RegionHealthChecksClient.Get</c> and <c>RegionHealthChecksClient.GetAsync</c>.
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
        /// <c>RegionHealthChecksClient.Insert</c> and <c>RegionHealthChecksClient.InsertAsync</c>.
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
        /// <c>RegionHealthChecksClient.List</c> and <c>RegionHealthChecksClient.ListAsync</c>.
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
        /// <c>RegionHealthChecksClient.Patch</c> and <c>RegionHealthChecksClient.PatchAsync</c>.
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
        /// <c>RegionHealthChecksClient.Update</c> and <c>RegionHealthChecksClient.UpdateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="RegionHealthChecksSettings"/> object.</returns>
        public RegionHealthChecksSettings Clone() => new RegionHealthChecksSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="RegionHealthChecksClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class RegionHealthChecksClientBuilder : gaxgrpc::ClientBuilderBase<RegionHealthChecksClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public RegionHealthChecksSettings Settings { get; set; }

        partial void InterceptBuild(ref RegionHealthChecksClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<RegionHealthChecksClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override RegionHealthChecksClient Build()
        {
            RegionHealthChecksClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<RegionHealthChecksClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<RegionHealthChecksClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private RegionHealthChecksClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return RegionHealthChecksClient.Create(callInvoker, Settings);
        }

        private async stt::Task<RegionHealthChecksClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return RegionHealthChecksClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => RegionHealthChecksClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => RegionHealthChecksClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => RegionHealthChecksClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>RegionHealthChecks client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The RegionHealthChecks API.
    /// </remarks>
    public abstract partial class RegionHealthChecksClient
    {
        /// <summary>
        /// The default endpoint for the RegionHealthChecks service, which is a host of "compute.googleapis.com" and a
        /// port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default RegionHealthChecks scopes.</summary>
        /// <remarks>
        /// The default RegionHealthChecks scopes are:
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
        /// Asynchronously creates a <see cref="RegionHealthChecksClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="RegionHealthChecksClientBuilder"/>
        /// .
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="RegionHealthChecksClient"/>.</returns>
        public static stt::Task<RegionHealthChecksClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new RegionHealthChecksClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="RegionHealthChecksClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="RegionHealthChecksClientBuilder"/>
        /// .
        /// </summary>
        /// <returns>The created <see cref="RegionHealthChecksClient"/>.</returns>
        public static RegionHealthChecksClient Create() => new RegionHealthChecksClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="RegionHealthChecksClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="RegionHealthChecksSettings"/>.</param>
        /// <returns>The created <see cref="RegionHealthChecksClient"/>.</returns>
        internal static RegionHealthChecksClient Create(grpccore::CallInvoker callInvoker, RegionHealthChecksSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            RegionHealthChecks.RegionHealthChecksClient grpcClient = new RegionHealthChecks.RegionHealthChecksClient(callInvoker);
            return new RegionHealthChecksClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC RegionHealthChecks client</summary>
        public virtual RegionHealthChecks.RegionHealthChecksClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteRegionHealthCheckRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string healthCheck, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string healthCheck, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string healthCheck, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, healthCheck, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual HealthCheck Get(GetRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheck> GetAsync(GetRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheck> GetAsync(GetRegionHealthCheckRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual HealthCheck Get(string project, string region, string healthCheck, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheck> GetAsync(string project, string region, string healthCheck, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheck> GetAsync(string project, string region, string healthCheck, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, healthCheck, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertRegionHealthCheckRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, HealthCheck healthCheckResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertRegionHealthCheckRequest
            {
                HealthCheckResource = gax::GaxPreconditions.CheckNotNull(healthCheckResource, nameof(healthCheckResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, HealthCheck healthCheckResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertRegionHealthCheckRequest
            {
                HealthCheckResource = gax::GaxPreconditions.CheckNotNull(healthCheckResource, nameof(healthCheckResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, HealthCheck healthCheckResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, healthCheckResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual HealthCheckList List(ListRegionHealthChecksRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheckList> ListAsync(ListRegionHealthChecksRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheckList> ListAsync(ListRegionHealthChecksRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual HealthCheckList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListRegionHealthChecksRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheckList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListRegionHealthChecksRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<HealthCheckList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchRegionHealthCheckRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to patch.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string region, string healthCheck, HealthCheck healthCheckResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                HealthCheckResource = gax::GaxPreconditions.CheckNotNull(healthCheckResource, nameof(healthCheckResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to patch.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string region, string healthCheck, HealthCheck healthCheckResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                HealthCheckResource = gax::GaxPreconditions.CheckNotNull(healthCheckResource, nameof(healthCheckResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to patch.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string region, string healthCheck, HealthCheck healthCheckResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, region, healthCheck, healthCheckResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(UpdateRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateRegionHealthCheckRequest request, st::CancellationToken cancellationToken) =>
            UpdateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to update.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(string project, string region, string healthCheck, HealthCheck healthCheckResource, gaxgrpc::CallSettings callSettings = null) =>
            Update(new UpdateRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                HealthCheckResource = gax::GaxPreconditions.CheckNotNull(healthCheckResource, nameof(healthCheckResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to update.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string region, string healthCheck, HealthCheck healthCheckResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdateAsync(new UpdateRegionHealthCheckRequest
            {
                HealthCheck = gax::GaxPreconditions.CheckNotNullOrEmpty(healthCheck, nameof(healthCheck)),
                HealthCheckResource = gax::GaxPreconditions.CheckNotNull(healthCheckResource, nameof(healthCheckResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="healthCheck">
        /// Name of the HealthCheck resource to update.
        /// </param>
        /// <param name="healthCheckResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string region, string healthCheck, HealthCheck healthCheckResource, st::CancellationToken cancellationToken) =>
            UpdateAsync(project, region, healthCheck, healthCheckResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>RegionHealthChecks client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The RegionHealthChecks API.
    /// </remarks>
    public sealed partial class RegionHealthChecksClientImpl : RegionHealthChecksClient
    {
        private readonly gaxgrpc::ApiCall<DeleteRegionHealthCheckRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetRegionHealthCheckRequest, HealthCheck> _callGet;

        private readonly gaxgrpc::ApiCall<InsertRegionHealthCheckRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListRegionHealthChecksRequest, HealthCheckList> _callList;

        private readonly gaxgrpc::ApiCall<PatchRegionHealthCheckRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<UpdateRegionHealthCheckRequest, Operation> _callUpdate;

        /// <summary>
        /// Constructs a client wrapper for the RegionHealthChecks service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="RegionHealthChecksSettings"/> used within this client.</param>
        public RegionHealthChecksClientImpl(RegionHealthChecks.RegionHealthChecksClient grpcClient, RegionHealthChecksSettings settings)
        {
            GrpcClient = grpcClient;
            RegionHealthChecksSettings effectiveSettings = settings ?? RegionHealthChecksSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteRegionHealthCheckRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("health_check", request => request.HealthCheck);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetRegionHealthCheckRequest, HealthCheck>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("health_check", request => request.HealthCheck);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertRegionHealthCheckRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListRegionHealthChecksRequest, HealthCheckList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchRegionHealthCheckRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("health_check", request => request.HealthCheck);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callUpdate = clientHelper.BuildApiCall<UpdateRegionHealthCheckRequest, Operation>(grpcClient.UpdateAsync, grpcClient.Update, effectiveSettings.UpdateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("health_check", request => request.HealthCheck);
            Modify_ApiCall(ref _callUpdate);
            Modify_UpdateApiCall(ref _callUpdate);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteRegionHealthCheckRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetRegionHealthCheckRequest, HealthCheck> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertRegionHealthCheckRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListRegionHealthChecksRequest, HealthCheckList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchRegionHealthCheckRequest, Operation> call);

        partial void Modify_UpdateApiCall(ref gaxgrpc::ApiCall<UpdateRegionHealthCheckRequest, Operation> call);

        partial void OnConstruction(RegionHealthChecks.RegionHealthChecksClient grpcClient, RegionHealthChecksSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC RegionHealthChecks client</summary>
        public override RegionHealthChecks.RegionHealthChecksClient GrpcClient { get; }

        partial void Modify_DeleteRegionHealthCheckRequest(ref DeleteRegionHealthCheckRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRegionHealthCheckRequest(ref GetRegionHealthCheckRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertRegionHealthCheckRequest(ref InsertRegionHealthCheckRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRegionHealthChecksRequest(ref ListRegionHealthChecksRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchRegionHealthCheckRequest(ref PatchRegionHealthCheckRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateRegionHealthCheckRequest(ref UpdateRegionHealthCheckRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionHealthCheckRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified HealthCheck resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionHealthCheckRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override HealthCheck Get(GetRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionHealthCheckRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified HealthCheck resource. Gets a list of available health checks by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<HealthCheck> GetAsync(GetRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionHealthCheckRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionHealthCheckRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertRegionHealthCheckRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override HealthCheckList List(ListRegionHealthChecksRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionHealthChecksRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of HealthCheck resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<HealthCheckList> ListAsync(ListRegionHealthChecksRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionHealthChecksRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRegionHealthCheckRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRegionHealthCheckRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Update(UpdateRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateRegionHealthCheckRequest(ref request, ref callSettings);
            return _callUpdate.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates a HealthCheck resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdateAsync(UpdateRegionHealthCheckRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateRegionHealthCheckRequest(ref request, ref callSettings);
            return _callUpdate.Async(request, callSettings);
        }
    }
}
