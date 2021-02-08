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
    /// <summary>Settings for <see cref="TargetPoolsClient"/> instances.</summary>
    public sealed partial class TargetPoolsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="TargetPoolsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="TargetPoolsSettings"/>.</returns>
        public static TargetPoolsSettings GetDefault() => new TargetPoolsSettings();

        /// <summary>Constructs a new <see cref="TargetPoolsSettings"/> object with default settings.</summary>
        public TargetPoolsSettings()
        {
        }

        private TargetPoolsSettings(TargetPoolsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AddHealthCheckSettings = existing.AddHealthCheckSettings;
            AddInstanceSettings = existing.AddInstanceSettings;
            AggregatedListSettings = existing.AggregatedListSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            GetHealthSettings = existing.GetHealthSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            RemoveHealthCheckSettings = existing.RemoveHealthCheckSettings;
            RemoveInstanceSettings = existing.RemoveInstanceSettings;
            SetBackupSettings = existing.SetBackupSettings;
            OnCopy(existing);
        }

        partial void OnCopy(TargetPoolsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TargetPoolsClient.AddHealthCheck</c> and <c>TargetPoolsClient.AddHealthCheckAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddHealthCheckSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TargetPoolsClient.AddInstance</c> and <c>TargetPoolsClient.AddInstanceAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddInstanceSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TargetPoolsClient.AggregatedList</c> and <c>TargetPoolsClient.AggregatedListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetPoolsClient.Delete</c>
        ///  and <c>TargetPoolsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetPoolsClient.Get</c>
        /// and <c>TargetPoolsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetPoolsClient.GetHealth</c>
        ///  and <c>TargetPoolsClient.GetHealthAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetHealthSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetPoolsClient.Insert</c>
        ///  and <c>TargetPoolsClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetPoolsClient.List</c>
        /// and <c>TargetPoolsClient.ListAsync</c>.
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
        /// <c>TargetPoolsClient.RemoveHealthCheck</c> and <c>TargetPoolsClient.RemoveHealthCheckAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RemoveHealthCheckSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TargetPoolsClient.RemoveInstance</c> and <c>TargetPoolsClient.RemoveInstanceAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RemoveInstanceSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetPoolsClient.SetBackup</c>
        ///  and <c>TargetPoolsClient.SetBackupAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetBackupSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="TargetPoolsSettings"/> object.</returns>
        public TargetPoolsSettings Clone() => new TargetPoolsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="TargetPoolsClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class TargetPoolsClientBuilder : gaxgrpc::ClientBuilderBase<TargetPoolsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public TargetPoolsSettings Settings { get; set; }

        partial void InterceptBuild(ref TargetPoolsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<TargetPoolsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override TargetPoolsClient Build()
        {
            TargetPoolsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<TargetPoolsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<TargetPoolsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private TargetPoolsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return TargetPoolsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<TargetPoolsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return TargetPoolsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => TargetPoolsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => TargetPoolsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => TargetPoolsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>TargetPools client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The TargetPools API.
    /// </remarks>
    public abstract partial class TargetPoolsClient
    {
        /// <summary>
        /// The default endpoint for the TargetPools service, which is a host of "compute.googleapis.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default TargetPools scopes.</summary>
        /// <remarks>
        /// The default TargetPools scopes are:
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
        /// Asynchronously creates a <see cref="TargetPoolsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TargetPoolsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="TargetPoolsClient"/>.</returns>
        public static stt::Task<TargetPoolsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new TargetPoolsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="TargetPoolsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TargetPoolsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="TargetPoolsClient"/>.</returns>
        public static TargetPoolsClient Create() => new TargetPoolsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="TargetPoolsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="TargetPoolsSettings"/>.</param>
        /// <returns>The created <see cref="TargetPoolsClient"/>.</returns>
        internal static TargetPoolsClient Create(grpccore::CallInvoker callInvoker, TargetPoolsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            TargetPools.TargetPoolsClient grpcClient = new TargetPools.TargetPoolsClient(callInvoker);
            return new TargetPoolsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC TargetPools client</summary>
        public virtual TargetPools.TargetPoolsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddHealthCheck(AddHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddHealthCheckAsync(AddHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddHealthCheckAsync(AddHealthCheckTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            AddHealthCheckAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the target pool to add a health check to.
        /// </param>
        /// <param name="targetPoolsAddHealthCheckRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddHealthCheck(string project, string region, string targetPool, TargetPoolsAddHealthCheckRequest targetPoolsAddHealthCheckRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddHealthCheck(new AddHealthCheckTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsAddHealthCheckRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsAddHealthCheckRequestResource, nameof(targetPoolsAddHealthCheckRequestResource)),
            }, callSettings);

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the target pool to add a health check to.
        /// </param>
        /// <param name="targetPoolsAddHealthCheckRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddHealthCheckAsync(string project, string region, string targetPool, TargetPoolsAddHealthCheckRequest targetPoolsAddHealthCheckRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddHealthCheckAsync(new AddHealthCheckTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsAddHealthCheckRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsAddHealthCheckRequestResource, nameof(targetPoolsAddHealthCheckRequestResource)),
            }, callSettings);

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the target pool to add a health check to.
        /// </param>
        /// <param name="targetPoolsAddHealthCheckRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddHealthCheckAsync(string project, string region, string targetPool, TargetPoolsAddHealthCheckRequest targetPoolsAddHealthCheckRequestResource, st::CancellationToken cancellationToken) =>
            AddHealthCheckAsync(project, region, targetPool, targetPoolsAddHealthCheckRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddInstance(AddInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstanceAsync(AddInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstanceAsync(AddInstanceTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            AddInstanceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to add instances to.
        /// </param>
        /// <param name="targetPoolsAddInstanceRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddInstance(string project, string region, string targetPool, TargetPoolsAddInstanceRequest targetPoolsAddInstanceRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddInstance(new AddInstanceTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsAddInstanceRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsAddInstanceRequestResource, nameof(targetPoolsAddInstanceRequestResource)),
            }, callSettings);

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to add instances to.
        /// </param>
        /// <param name="targetPoolsAddInstanceRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstanceAsync(string project, string region, string targetPool, TargetPoolsAddInstanceRequest targetPoolsAddInstanceRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            AddInstanceAsync(new AddInstanceTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsAddInstanceRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsAddInstanceRequestResource, nameof(targetPoolsAddInstanceRequestResource)),
            }, callSettings);

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to add instances to.
        /// </param>
        /// <param name="targetPoolsAddInstanceRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddInstanceAsync(string project, string region, string targetPool, TargetPoolsAddInstanceRequest targetPoolsAddInstanceRequestResource, st::CancellationToken cancellationToken) =>
            AddInstanceAsync(project, region, targetPool, targetPoolsAddInstanceRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPoolAggregatedList AggregatedList(AggregatedListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolAggregatedList> AggregatedListAsync(AggregatedListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolAggregatedList> AggregatedListAsync(AggregatedListTargetPoolsRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPoolAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListTargetPoolsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListTargetPoolsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string region, string targetPool, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string targetPool, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string region, string targetPool, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, targetPool, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPool Get(GetTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPool> GetAsync(GetTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPool> GetAsync(GetTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPool Get(string project, string region, string targetPool, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
            }, callSettings);

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPool> GetAsync(string project, string region, string targetPool, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
            }, callSettings);

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPool> GetAsync(string project, string region, string targetPool, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, targetPool, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPoolInstanceHealth GetHealth(GetHealthTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolInstanceHealth> GetHealthAsync(GetHealthTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolInstanceHealth> GetHealthAsync(GetHealthTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            GetHealthAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to which the queried instance belongs.
        /// </param>
        /// <param name="instanceReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPoolInstanceHealth GetHealth(string project, string region, string targetPool, InstanceReference instanceReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            GetHealth(new GetHealthTargetPoolRequest
            {
                InstanceReferenceResource = gax::GaxPreconditions.CheckNotNull(instanceReferenceResource, nameof(instanceReferenceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
            }, callSettings);

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to which the queried instance belongs.
        /// </param>
        /// <param name="instanceReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolInstanceHealth> GetHealthAsync(string project, string region, string targetPool, InstanceReference instanceReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            GetHealthAsync(new GetHealthTargetPoolRequest
            {
                InstanceReferenceResource = gax::GaxPreconditions.CheckNotNull(instanceReferenceResource, nameof(instanceReferenceResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
            }, callSettings);

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to which the queried instance belongs.
        /// </param>
        /// <param name="instanceReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolInstanceHealth> GetHealthAsync(string project, string region, string targetPool, InstanceReference instanceReferenceResource, st::CancellationToken cancellationToken) =>
            GetHealthAsync(project, region, targetPool, instanceReferenceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPoolResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, string region, TargetPool targetPoolResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPoolResource = gax::GaxPreconditions.CheckNotNull(targetPoolResource, nameof(targetPoolResource)),
            }, callSettings);

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPoolResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, TargetPool targetPoolResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPoolResource = gax::GaxPreconditions.CheckNotNull(targetPoolResource, nameof(targetPoolResource)),
            }, callSettings);

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPoolResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, string region, TargetPool targetPoolResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, region, targetPoolResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPoolList List(ListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolList> ListAsync(ListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolList> ListAsync(ListTargetPoolsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetPoolList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListTargetPoolsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListTargetPoolsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetPoolList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveHealthCheck(RemoveHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveHealthCheckAsync(RemoveHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveHealthCheckAsync(RemoveHealthCheckTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            RemoveHealthCheckAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the target pool to remove health checks from.
        /// </param>
        /// <param name="targetPoolsRemoveHealthCheckRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveHealthCheck(string project, string region, string targetPool, TargetPoolsRemoveHealthCheckRequest targetPoolsRemoveHealthCheckRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemoveHealthCheck(new RemoveHealthCheckTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsRemoveHealthCheckRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsRemoveHealthCheckRequestResource, nameof(targetPoolsRemoveHealthCheckRequestResource)),
            }, callSettings);

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the target pool to remove health checks from.
        /// </param>
        /// <param name="targetPoolsRemoveHealthCheckRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveHealthCheckAsync(string project, string region, string targetPool, TargetPoolsRemoveHealthCheckRequest targetPoolsRemoveHealthCheckRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemoveHealthCheckAsync(new RemoveHealthCheckTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsRemoveHealthCheckRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsRemoveHealthCheckRequestResource, nameof(targetPoolsRemoveHealthCheckRequestResource)),
            }, callSettings);

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the target pool to remove health checks from.
        /// </param>
        /// <param name="targetPoolsRemoveHealthCheckRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveHealthCheckAsync(string project, string region, string targetPool, TargetPoolsRemoveHealthCheckRequest targetPoolsRemoveHealthCheckRequestResource, st::CancellationToken cancellationToken) =>
            RemoveHealthCheckAsync(project, region, targetPool, targetPoolsRemoveHealthCheckRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveInstance(RemoveInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstanceAsync(RemoveInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstanceAsync(RemoveInstanceTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            RemoveInstanceAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to remove instances from.
        /// </param>
        /// <param name="targetPoolsRemoveInstanceRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveInstance(string project, string region, string targetPool, TargetPoolsRemoveInstanceRequest targetPoolsRemoveInstanceRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemoveInstance(new RemoveInstanceTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsRemoveInstanceRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsRemoveInstanceRequestResource, nameof(targetPoolsRemoveInstanceRequestResource)),
            }, callSettings);

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to remove instances from.
        /// </param>
        /// <param name="targetPoolsRemoveInstanceRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstanceAsync(string project, string region, string targetPool, TargetPoolsRemoveInstanceRequest targetPoolsRemoveInstanceRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            RemoveInstanceAsync(new RemoveInstanceTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetPoolsRemoveInstanceRequestResource = gax::GaxPreconditions.CheckNotNull(targetPoolsRemoveInstanceRequestResource, nameof(targetPoolsRemoveInstanceRequestResource)),
            }, callSettings);

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to remove instances from.
        /// </param>
        /// <param name="targetPoolsRemoveInstanceRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveInstanceAsync(string project, string region, string targetPool, TargetPoolsRemoveInstanceRequest targetPoolsRemoveInstanceRequestResource, st::CancellationToken cancellationToken) =>
            RemoveInstanceAsync(project, region, targetPool, targetPoolsRemoveInstanceRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetBackup(SetBackupTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetBackupAsync(SetBackupTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetBackupAsync(SetBackupTargetPoolRequest request, st::CancellationToken cancellationToken) =>
            SetBackupAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to set a backup pool for.
        /// </param>
        /// <param name="targetReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetBackup(string project, string region, string targetPool, TargetReference targetReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            SetBackup(new SetBackupTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetReferenceResource = gax::GaxPreconditions.CheckNotNull(targetReferenceResource, nameof(targetReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to set a backup pool for.
        /// </param>
        /// <param name="targetReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetBackupAsync(string project, string region, string targetPool, TargetReference targetReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            SetBackupAsync(new SetBackupTargetPoolRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
                TargetPool = gax::GaxPreconditions.CheckNotNullOrEmpty(targetPool, nameof(targetPool)),
                TargetReferenceResource = gax::GaxPreconditions.CheckNotNull(targetReferenceResource, nameof(targetReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region scoping this request.
        /// </param>
        /// <param name="targetPool">
        /// Name of the TargetPool resource to set a backup pool for.
        /// </param>
        /// <param name="targetReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetBackupAsync(string project, string region, string targetPool, TargetReference targetReferenceResource, st::CancellationToken cancellationToken) =>
            SetBackupAsync(project, region, targetPool, targetReferenceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>TargetPools client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The TargetPools API.
    /// </remarks>
    public sealed partial class TargetPoolsClientImpl : TargetPoolsClient
    {
        private readonly gaxgrpc::ApiCall<AddHealthCheckTargetPoolRequest, Operation> _callAddHealthCheck;

        private readonly gaxgrpc::ApiCall<AddInstanceTargetPoolRequest, Operation> _callAddInstance;

        private readonly gaxgrpc::ApiCall<AggregatedListTargetPoolsRequest, TargetPoolAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<DeleteTargetPoolRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetTargetPoolRequest, TargetPool> _callGet;

        private readonly gaxgrpc::ApiCall<GetHealthTargetPoolRequest, TargetPoolInstanceHealth> _callGetHealth;

        private readonly gaxgrpc::ApiCall<InsertTargetPoolRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListTargetPoolsRequest, TargetPoolList> _callList;

        private readonly gaxgrpc::ApiCall<RemoveHealthCheckTargetPoolRequest, Operation> _callRemoveHealthCheck;

        private readonly gaxgrpc::ApiCall<RemoveInstanceTargetPoolRequest, Operation> _callRemoveInstance;

        private readonly gaxgrpc::ApiCall<SetBackupTargetPoolRequest, Operation> _callSetBackup;

        /// <summary>
        /// Constructs a client wrapper for the TargetPools service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="TargetPoolsSettings"/> used within this client.</param>
        public TargetPoolsClientImpl(TargetPools.TargetPoolsClient grpcClient, TargetPoolsSettings settings)
        {
            GrpcClient = grpcClient;
            TargetPoolsSettings effectiveSettings = settings ?? TargetPoolsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAddHealthCheck = clientHelper.BuildApiCall<AddHealthCheckTargetPoolRequest, Operation>(grpcClient.AddHealthCheckAsync, grpcClient.AddHealthCheck, effectiveSettings.AddHealthCheckSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callAddHealthCheck);
            Modify_AddHealthCheckApiCall(ref _callAddHealthCheck);
            _callAddInstance = clientHelper.BuildApiCall<AddInstanceTargetPoolRequest, Operation>(grpcClient.AddInstanceAsync, grpcClient.AddInstance, effectiveSettings.AddInstanceSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callAddInstance);
            Modify_AddInstanceApiCall(ref _callAddInstance);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListTargetPoolsRequest, TargetPoolAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callDelete = clientHelper.BuildApiCall<DeleteTargetPoolRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetTargetPoolRequest, TargetPool>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callGetHealth = clientHelper.BuildApiCall<GetHealthTargetPoolRequest, TargetPoolInstanceHealth>(grpcClient.GetHealthAsync, grpcClient.GetHealth, effectiveSettings.GetHealthSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callGetHealth);
            Modify_GetHealthApiCall(ref _callGetHealth);
            _callInsert = clientHelper.BuildApiCall<InsertTargetPoolRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListTargetPoolsRequest, TargetPoolList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callRemoveHealthCheck = clientHelper.BuildApiCall<RemoveHealthCheckTargetPoolRequest, Operation>(grpcClient.RemoveHealthCheckAsync, grpcClient.RemoveHealthCheck, effectiveSettings.RemoveHealthCheckSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callRemoveHealthCheck);
            Modify_RemoveHealthCheckApiCall(ref _callRemoveHealthCheck);
            _callRemoveInstance = clientHelper.BuildApiCall<RemoveInstanceTargetPoolRequest, Operation>(grpcClient.RemoveInstanceAsync, grpcClient.RemoveInstance, effectiveSettings.RemoveInstanceSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callRemoveInstance);
            Modify_RemoveInstanceApiCall(ref _callRemoveInstance);
            _callSetBackup = clientHelper.BuildApiCall<SetBackupTargetPoolRequest, Operation>(grpcClient.SetBackupAsync, grpcClient.SetBackup, effectiveSettings.SetBackupSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("target_pool", request => request.TargetPool);
            Modify_ApiCall(ref _callSetBackup);
            Modify_SetBackupApiCall(ref _callSetBackup);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AddHealthCheckApiCall(ref gaxgrpc::ApiCall<AddHealthCheckTargetPoolRequest, Operation> call);

        partial void Modify_AddInstanceApiCall(ref gaxgrpc::ApiCall<AddInstanceTargetPoolRequest, Operation> call);

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListTargetPoolsRequest, TargetPoolAggregatedList> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteTargetPoolRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetTargetPoolRequest, TargetPool> call);

        partial void Modify_GetHealthApiCall(ref gaxgrpc::ApiCall<GetHealthTargetPoolRequest, TargetPoolInstanceHealth> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertTargetPoolRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListTargetPoolsRequest, TargetPoolList> call);

        partial void Modify_RemoveHealthCheckApiCall(ref gaxgrpc::ApiCall<RemoveHealthCheckTargetPoolRequest, Operation> call);

        partial void Modify_RemoveInstanceApiCall(ref gaxgrpc::ApiCall<RemoveInstanceTargetPoolRequest, Operation> call);

        partial void Modify_SetBackupApiCall(ref gaxgrpc::ApiCall<SetBackupTargetPoolRequest, Operation> call);

        partial void OnConstruction(TargetPools.TargetPoolsClient grpcClient, TargetPoolsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC TargetPools client</summary>
        public override TargetPools.TargetPoolsClient GrpcClient { get; }

        partial void Modify_AddHealthCheckTargetPoolRequest(ref AddHealthCheckTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AddInstanceTargetPoolRequest(ref AddInstanceTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_AggregatedListTargetPoolsRequest(ref AggregatedListTargetPoolsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteTargetPoolRequest(ref DeleteTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetTargetPoolRequest(ref GetTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetHealthTargetPoolRequest(ref GetHealthTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertTargetPoolRequest(ref InsertTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListTargetPoolsRequest(ref ListTargetPoolsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RemoveHealthCheckTargetPoolRequest(ref RemoveHealthCheckTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RemoveInstanceTargetPoolRequest(ref RemoveInstanceTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetBackupTargetPoolRequest(ref SetBackupTargetPoolRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddHealthCheck(AddHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddHealthCheckTargetPoolRequest(ref request, ref callSettings);
            return _callAddHealthCheck.Sync(request, callSettings);
        }

        /// <summary>
        /// Adds health check URLs to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddHealthCheckAsync(AddHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddHealthCheckTargetPoolRequest(ref request, ref callSettings);
            return _callAddHealthCheck.Async(request, callSettings);
        }

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddInstance(AddInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddInstanceTargetPoolRequest(ref request, ref callSettings);
            return _callAddInstance.Sync(request, callSettings);
        }

        /// <summary>
        /// Adds an instance to a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddInstanceAsync(AddInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddInstanceTargetPoolRequest(ref request, ref callSettings);
            return _callAddInstance.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetPoolAggregatedList AggregatedList(AggregatedListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListTargetPoolsRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves an aggregated list of target pools.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetPoolAggregatedList> AggregatedListAsync(AggregatedListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListTargetPoolsRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTargetPoolRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTargetPoolRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetPool Get(GetTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetTargetPoolRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified target pool. Gets a list of available target pools by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetPool> GetAsync(GetTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetTargetPoolRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetPoolInstanceHealth GetHealth(GetHealthTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetHealthTargetPoolRequest(ref request, ref callSettings);
            return _callGetHealth.Sync(request, callSettings);
        }

        /// <summary>
        /// Gets the most recent health check results for each IP for the instance that is referenced by the given target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetPoolInstanceHealth> GetHealthAsync(GetHealthTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetHealthTargetPoolRequest(ref request, ref callSettings);
            return _callGetHealth.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertTargetPoolRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a target pool in the specified project and region using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertTargetPoolRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetPoolList List(ListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTargetPoolsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of target pools available to the specified project and region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetPoolList> ListAsync(ListTargetPoolsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTargetPoolsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation RemoveHealthCheck(RemoveHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveHealthCheckTargetPoolRequest(ref request, ref callSettings);
            return _callRemoveHealthCheck.Sync(request, callSettings);
        }

        /// <summary>
        /// Removes health check URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> RemoveHealthCheckAsync(RemoveHealthCheckTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveHealthCheckTargetPoolRequest(ref request, ref callSettings);
            return _callRemoveHealthCheck.Async(request, callSettings);
        }

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation RemoveInstance(RemoveInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveInstanceTargetPoolRequest(ref request, ref callSettings);
            return _callRemoveInstance.Sync(request, callSettings);
        }

        /// <summary>
        /// Removes instance URL from a target pool.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> RemoveInstanceAsync(RemoveInstanceTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveInstanceTargetPoolRequest(ref request, ref callSettings);
            return _callRemoveInstance.Async(request, callSettings);
        }

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetBackup(SetBackupTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetBackupTargetPoolRequest(ref request, ref callSettings);
            return _callSetBackup.Sync(request, callSettings);
        }

        /// <summary>
        /// Changes a backup target pool's configurations.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetBackupAsync(SetBackupTargetPoolRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetBackupTargetPoolRequest(ref request, ref callSettings);
            return _callSetBackup.Async(request, callSettings);
        }
    }
}
