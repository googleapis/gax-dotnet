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
    /// <summary>Settings for <see cref="UrlMapsClient"/> instances.</summary>
    public sealed partial class UrlMapsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="UrlMapsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="UrlMapsSettings"/>.</returns>
        public static UrlMapsSettings GetDefault() => new UrlMapsSettings();

        /// <summary>Constructs a new <see cref="UrlMapsSettings"/> object with default settings.</summary>
        public UrlMapsSettings()
        {
        }

        private UrlMapsSettings(UrlMapsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AggregatedListSettings = existing.AggregatedListSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            InvalidateCacheSettings = existing.InvalidateCacheSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            UpdateSettings = existing.UpdateSettings;
            ValidateSettings = existing.ValidateSettings;
            OnCopy(existing);
        }

        partial void OnCopy(UrlMapsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>UrlMapsClient.AggregatedList</c> and <c>UrlMapsClient.AggregatedListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AggregatedListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.Delete</c>
        /// and <c>UrlMapsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.Get</c> and
        /// <c>UrlMapsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.Insert</c>
        /// and <c>UrlMapsClient.InsertAsync</c>.
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
        /// <c>UrlMapsClient.InvalidateCache</c> and <c>UrlMapsClient.InvalidateCacheAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InvalidateCacheSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.List</c> and
        /// <c>UrlMapsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.Patch</c> and
        /// <c>UrlMapsClient.PatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.Update</c>
        /// and <c>UrlMapsClient.UpdateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>UrlMapsClient.Validate</c>
        /// and <c>UrlMapsClient.ValidateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ValidateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="UrlMapsSettings"/> object.</returns>
        public UrlMapsSettings Clone() => new UrlMapsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="UrlMapsClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class UrlMapsClientBuilder : gaxgrpc::ClientBuilderBase<UrlMapsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public UrlMapsSettings Settings { get; set; }

        partial void InterceptBuild(ref UrlMapsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<UrlMapsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override UrlMapsClient Build()
        {
            UrlMapsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<UrlMapsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<UrlMapsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private UrlMapsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return UrlMapsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<UrlMapsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return UrlMapsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => UrlMapsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => UrlMapsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => UrlMapsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>UrlMaps client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The UrlMaps API.
    /// </remarks>
    public abstract partial class UrlMapsClient
    {
        /// <summary>
        /// The default endpoint for the UrlMaps service, which is a host of "compute.googleapis.com" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default UrlMaps scopes.</summary>
        /// <remarks>
        /// The default UrlMaps scopes are:
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
        /// Asynchronously creates a <see cref="UrlMapsClient"/> using the default credentials, endpoint and settings. 
        /// To specify custom credentials or other settings, use <see cref="UrlMapsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="UrlMapsClient"/>.</returns>
        public static stt::Task<UrlMapsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new UrlMapsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="UrlMapsClient"/> using the default credentials, endpoint and settings. To
        /// specify custom credentials or other settings, use <see cref="UrlMapsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="UrlMapsClient"/>.</returns>
        public static UrlMapsClient Create() => new UrlMapsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="UrlMapsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="UrlMapsSettings"/>.</param>
        /// <returns>The created <see cref="UrlMapsClient"/>.</returns>
        internal static UrlMapsClient Create(grpccore::CallInvoker callInvoker, UrlMapsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            UrlMaps.UrlMapsClient grpcClient = new UrlMaps.UrlMapsClient(callInvoker);
            return new UrlMapsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC UrlMaps client</summary>
        public virtual UrlMaps.UrlMapsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMapsAggregatedList AggregatedList(AggregatedListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsAggregatedList> AggregatedListAsync(AggregatedListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsAggregatedList> AggregatedListAsync(AggregatedListUrlMapsRequest request, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Name of the project scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMapsAggregatedList AggregatedList(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedList(new AggregatedListUrlMapsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Name of the project scoping this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsAggregatedList> AggregatedListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            AggregatedListAsync(new AggregatedListUrlMapsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Name of the project scoping this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsAggregatedList> AggregatedListAsync(string project, st::CancellationToken cancellationToken) =>
            AggregatedListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteUrlMapRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string urlMap, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string urlMap, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string urlMap, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, urlMap, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMap Get(GetUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMap> GetAsync(GetUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMap> GetAsync(GetUrlMapRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMap Get(string project, string urlMap, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
            }, callSettings);

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMap> GetAsync(string project, string urlMap, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
            }, callSettings);

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMap> GetAsync(string project, string urlMap, st::CancellationToken cancellationToken) =>
            GetAsync(project, urlMap, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertUrlMapRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, UrlMap urlMapResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMapResource = gax::GaxPreconditions.CheckNotNull(urlMapResource, nameof(urlMapResource)),
            }, callSettings);

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, UrlMap urlMapResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMapResource = gax::GaxPreconditions.CheckNotNull(urlMapResource, nameof(urlMapResource)),
            }, callSettings);

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, UrlMap urlMapResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, urlMapResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation InvalidateCache(InvalidateCacheUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InvalidateCacheAsync(InvalidateCacheUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InvalidateCacheAsync(InvalidateCacheUrlMapRequest request, st::CancellationToken cancellationToken) =>
            InvalidateCacheAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap scoping this request.
        /// </param>
        /// <param name="cacheInvalidationRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation InvalidateCache(string project, string urlMap, CacheInvalidationRule cacheInvalidationRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            InvalidateCache(new InvalidateCacheUrlMapRequest
            {
                CacheInvalidationRuleResource = gax::GaxPreconditions.CheckNotNull(cacheInvalidationRuleResource, nameof(cacheInvalidationRuleResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
            }, callSettings);

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap scoping this request.
        /// </param>
        /// <param name="cacheInvalidationRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InvalidateCacheAsync(string project, string urlMap, CacheInvalidationRule cacheInvalidationRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            InvalidateCacheAsync(new InvalidateCacheUrlMapRequest
            {
                CacheInvalidationRuleResource = gax::GaxPreconditions.CheckNotNull(cacheInvalidationRuleResource, nameof(cacheInvalidationRuleResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
            }, callSettings);

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap scoping this request.
        /// </param>
        /// <param name="cacheInvalidationRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InvalidateCacheAsync(string project, string urlMap, CacheInvalidationRule cacheInvalidationRuleResource, st::CancellationToken cancellationToken) =>
            InvalidateCacheAsync(project, urlMap, cacheInvalidationRuleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMapList List(ListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapList> ListAsync(ListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapList> ListAsync(ListUrlMapsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMapList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListUrlMapsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListUrlMapsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchUrlMapRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to patch.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string urlMap, UrlMap urlMapResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
                UrlMapResource = gax::GaxPreconditions.CheckNotNull(urlMapResource, nameof(urlMapResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to patch.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string urlMap, UrlMap urlMapResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
                UrlMapResource = gax::GaxPreconditions.CheckNotNull(urlMapResource, nameof(urlMapResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to patch.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string urlMap, UrlMap urlMapResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, urlMap, urlMapResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(UpdateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateUrlMapRequest request, st::CancellationToken cancellationToken) =>
            UpdateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to update.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(string project, string urlMap, UrlMap urlMapResource, gaxgrpc::CallSettings callSettings = null) =>
            Update(new UpdateUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
                UrlMapResource = gax::GaxPreconditions.CheckNotNull(urlMapResource, nameof(urlMapResource)),
            }, callSettings);

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to update.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string urlMap, UrlMap urlMapResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdateAsync(new UpdateUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
                UrlMapResource = gax::GaxPreconditions.CheckNotNull(urlMapResource, nameof(urlMapResource)),
            }, callSettings);

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to update.
        /// </param>
        /// <param name="urlMapResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string urlMap, UrlMap urlMapResource, st::CancellationToken cancellationToken) =>
            UpdateAsync(project, urlMap, urlMapResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMapsValidateResponse Validate(ValidateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsValidateResponse> ValidateAsync(ValidateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsValidateResponse> ValidateAsync(ValidateUrlMapRequest request, st::CancellationToken cancellationToken) =>
            ValidateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to be validated as.
        /// </param>
        /// <param name="urlMapsValidateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual UrlMapsValidateResponse Validate(string project, string urlMap, UrlMapsValidateRequest urlMapsValidateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            Validate(new ValidateUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
                UrlMapsValidateRequestResource = gax::GaxPreconditions.CheckNotNull(urlMapsValidateRequestResource, nameof(urlMapsValidateRequestResource)),
            }, callSettings);

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to be validated as.
        /// </param>
        /// <param name="urlMapsValidateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsValidateResponse> ValidateAsync(string project, string urlMap, UrlMapsValidateRequest urlMapsValidateRequestResource, gaxgrpc::CallSettings callSettings = null) =>
            ValidateAsync(new ValidateUrlMapRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                UrlMap = gax::GaxPreconditions.CheckNotNullOrEmpty(urlMap, nameof(urlMap)),
                UrlMapsValidateRequestResource = gax::GaxPreconditions.CheckNotNull(urlMapsValidateRequestResource, nameof(urlMapsValidateRequestResource)),
            }, callSettings);

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="urlMap">
        /// Name of the UrlMap resource to be validated as.
        /// </param>
        /// <param name="urlMapsValidateRequestResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<UrlMapsValidateResponse> ValidateAsync(string project, string urlMap, UrlMapsValidateRequest urlMapsValidateRequestResource, st::CancellationToken cancellationToken) =>
            ValidateAsync(project, urlMap, urlMapsValidateRequestResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>UrlMaps client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The UrlMaps API.
    /// </remarks>
    public sealed partial class UrlMapsClientImpl : UrlMapsClient
    {
        private readonly gaxgrpc::ApiCall<AggregatedListUrlMapsRequest, UrlMapsAggregatedList> _callAggregatedList;

        private readonly gaxgrpc::ApiCall<DeleteUrlMapRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetUrlMapRequest, UrlMap> _callGet;

        private readonly gaxgrpc::ApiCall<InsertUrlMapRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<InvalidateCacheUrlMapRequest, Operation> _callInvalidateCache;

        private readonly gaxgrpc::ApiCall<ListUrlMapsRequest, UrlMapList> _callList;

        private readonly gaxgrpc::ApiCall<PatchUrlMapRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<UpdateUrlMapRequest, Operation> _callUpdate;

        private readonly gaxgrpc::ApiCall<ValidateUrlMapRequest, UrlMapsValidateResponse> _callValidate;

        /// <summary>
        /// Constructs a client wrapper for the UrlMaps service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="UrlMapsSettings"/> used within this client.</param>
        public UrlMapsClientImpl(UrlMaps.UrlMapsClient grpcClient, UrlMapsSettings settings)
        {
            GrpcClient = grpcClient;
            UrlMapsSettings effectiveSettings = settings ?? UrlMapsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAggregatedList = clientHelper.BuildApiCall<AggregatedListUrlMapsRequest, UrlMapsAggregatedList>(grpcClient.AggregatedListAsync, grpcClient.AggregatedList, effectiveSettings.AggregatedListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callAggregatedList);
            Modify_AggregatedListApiCall(ref _callAggregatedList);
            _callDelete = clientHelper.BuildApiCall<DeleteUrlMapRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("url_map", request => request.UrlMap);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetUrlMapRequest, UrlMap>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("url_map", request => request.UrlMap);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertUrlMapRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callInvalidateCache = clientHelper.BuildApiCall<InvalidateCacheUrlMapRequest, Operation>(grpcClient.InvalidateCacheAsync, grpcClient.InvalidateCache, effectiveSettings.InvalidateCacheSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("url_map", request => request.UrlMap);
            Modify_ApiCall(ref _callInvalidateCache);
            Modify_InvalidateCacheApiCall(ref _callInvalidateCache);
            _callList = clientHelper.BuildApiCall<ListUrlMapsRequest, UrlMapList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchUrlMapRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("url_map", request => request.UrlMap);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callUpdate = clientHelper.BuildApiCall<UpdateUrlMapRequest, Operation>(grpcClient.UpdateAsync, grpcClient.Update, effectiveSettings.UpdateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("url_map", request => request.UrlMap);
            Modify_ApiCall(ref _callUpdate);
            Modify_UpdateApiCall(ref _callUpdate);
            _callValidate = clientHelper.BuildApiCall<ValidateUrlMapRequest, UrlMapsValidateResponse>(grpcClient.ValidateAsync, grpcClient.Validate, effectiveSettings.ValidateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("url_map", request => request.UrlMap);
            Modify_ApiCall(ref _callValidate);
            Modify_ValidateApiCall(ref _callValidate);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AggregatedListApiCall(ref gaxgrpc::ApiCall<AggregatedListUrlMapsRequest, UrlMapsAggregatedList> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteUrlMapRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetUrlMapRequest, UrlMap> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertUrlMapRequest, Operation> call);

        partial void Modify_InvalidateCacheApiCall(ref gaxgrpc::ApiCall<InvalidateCacheUrlMapRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListUrlMapsRequest, UrlMapList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchUrlMapRequest, Operation> call);

        partial void Modify_UpdateApiCall(ref gaxgrpc::ApiCall<UpdateUrlMapRequest, Operation> call);

        partial void Modify_ValidateApiCall(ref gaxgrpc::ApiCall<ValidateUrlMapRequest, UrlMapsValidateResponse> call);

        partial void OnConstruction(UrlMaps.UrlMapsClient grpcClient, UrlMapsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC UrlMaps client</summary>
        public override UrlMaps.UrlMapsClient GrpcClient { get; }

        partial void Modify_AggregatedListUrlMapsRequest(ref AggregatedListUrlMapsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteUrlMapRequest(ref DeleteUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetUrlMapRequest(ref GetUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertUrlMapRequest(ref InsertUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InvalidateCacheUrlMapRequest(ref InvalidateCacheUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListUrlMapsRequest(ref ListUrlMapsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchUrlMapRequest(ref PatchUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateUrlMapRequest(ref UpdateUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ValidateUrlMapRequest(ref ValidateUrlMapRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override UrlMapsAggregatedList AggregatedList(AggregatedListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListUrlMapsRequest(ref request, ref callSettings);
            return _callAggregatedList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of all UrlMap resources, regional and global, available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<UrlMapsAggregatedList> AggregatedListAsync(AggregatedListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AggregatedListUrlMapsRequest(ref request, ref callSettings);
            return _callAggregatedList.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteUrlMapRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified UrlMap resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteUrlMapRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override UrlMap Get(GetUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetUrlMapRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified UrlMap resource. Gets a list of available URL maps by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<UrlMap> GetAsync(GetUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetUrlMapRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertUrlMapRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a UrlMap resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertUrlMapRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation InvalidateCache(InvalidateCacheUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InvalidateCacheUrlMapRequest(ref request, ref callSettings);
            return _callInvalidateCache.Sync(request, callSettings);
        }

        /// <summary>
        /// Initiates a cache invalidation operation, invalidating the specified path, scoped to the specified UrlMap.
        /// 
        /// For more information, see [Invalidating cached content](/cdn/docs/invalidating-cached-content).
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InvalidateCacheAsync(InvalidateCacheUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InvalidateCacheUrlMapRequest(ref request, ref callSettings);
            return _callInvalidateCache.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override UrlMapList List(ListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListUrlMapsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of UrlMap resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<UrlMapList> ListAsync(ListUrlMapsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListUrlMapsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchUrlMapRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Patches the specified UrlMap resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchUrlMapRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Update(UpdateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateUrlMapRequest(ref request, ref callSettings);
            return _callUpdate.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified UrlMap resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdateAsync(UpdateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateUrlMapRequest(ref request, ref callSettings);
            return _callUpdate.Async(request, callSettings);
        }

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override UrlMapsValidateResponse Validate(ValidateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ValidateUrlMapRequest(ref request, ref callSettings);
            return _callValidate.Sync(request, callSettings);
        }

        /// <summary>
        /// Runs static validation for the UrlMap. In particular, the tests of the provided UrlMap will be run. Calling this method does NOT create the UrlMap.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<UrlMapsValidateResponse> ValidateAsync(ValidateUrlMapRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ValidateUrlMapRequest(ref request, ref callSettings);
            return _callValidate.Async(request, callSettings);
        }
    }
}
