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
    /// <summary>Settings for <see cref="InterconnectLocationsClient"/> instances.</summary>
    public sealed partial class InterconnectLocationsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="InterconnectLocationsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="InterconnectLocationsSettings"/>.</returns>
        public static InterconnectLocationsSettings GetDefault() => new InterconnectLocationsSettings();

        /// <summary>
        /// Constructs a new <see cref="InterconnectLocationsSettings"/> object with default settings.
        /// </summary>
        public InterconnectLocationsSettings()
        {
        }

        private InterconnectLocationsSettings(InterconnectLocationsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            GetSettings = existing.GetSettings;
            ListSettings = existing.ListSettings;
            OnCopy(existing);
        }

        partial void OnCopy(InterconnectLocationsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>InterconnectLocationsClient.Get</c> and <c>InterconnectLocationsClient.GetAsync</c>.
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
        /// <c>InterconnectLocationsClient.List</c> and <c>InterconnectLocationsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="InterconnectLocationsSettings"/> object.</returns>
        public InterconnectLocationsSettings Clone() => new InterconnectLocationsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="InterconnectLocationsClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class InterconnectLocationsClientBuilder : gaxgrpc::ClientBuilderBase<InterconnectLocationsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public InterconnectLocationsSettings Settings { get; set; }

        partial void InterceptBuild(ref InterconnectLocationsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<InterconnectLocationsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override InterconnectLocationsClient Build()
        {
            InterconnectLocationsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<InterconnectLocationsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<InterconnectLocationsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private InterconnectLocationsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return InterconnectLocationsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<InterconnectLocationsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return InterconnectLocationsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => InterconnectLocationsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => InterconnectLocationsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => InterconnectLocationsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>InterconnectLocations client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The InterconnectLocations API.
    /// </remarks>
    public abstract partial class InterconnectLocationsClient
    {
        /// <summary>
        /// The default endpoint for the InterconnectLocations service, which is a host of "compute.googleapis.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default InterconnectLocations scopes.</summary>
        /// <remarks>
        /// The default InterconnectLocations scopes are:
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
        /// Asynchronously creates a <see cref="InterconnectLocationsClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="InterconnectLocationsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="InterconnectLocationsClient"/>.</returns>
        public static stt::Task<InterconnectLocationsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new InterconnectLocationsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="InterconnectLocationsClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="InterconnectLocationsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="InterconnectLocationsClient"/>.</returns>
        public static InterconnectLocationsClient Create() => new InterconnectLocationsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="InterconnectLocationsClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="InterconnectLocationsSettings"/>.</param>
        /// <returns>The created <see cref="InterconnectLocationsClient"/>.</returns>
        internal static InterconnectLocationsClient Create(grpccore::CallInvoker callInvoker, InterconnectLocationsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            InterconnectLocations.InterconnectLocationsClient grpcClient = new InterconnectLocations.InterconnectLocationsClient(callInvoker);
            return new InterconnectLocationsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC InterconnectLocations client</summary>
        public virtual InterconnectLocations.InterconnectLocationsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectLocation Get(GetInterconnectLocationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocation> GetAsync(GetInterconnectLocationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocation> GetAsync(GetInterconnectLocationRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnectLocation">
        /// Name of the interconnect location to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectLocation Get(string project, string interconnectLocation, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetInterconnectLocationRequest
            {
                InterconnectLocation = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnectLocation, nameof(interconnectLocation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnectLocation">
        /// Name of the interconnect location to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocation> GetAsync(string project, string interconnectLocation, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetInterconnectLocationRequest
            {
                InterconnectLocation = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnectLocation, nameof(interconnectLocation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnectLocation">
        /// Name of the interconnect location to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocation> GetAsync(string project, string interconnectLocation, st::CancellationToken cancellationToken) =>
            GetAsync(project, interconnectLocation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectLocationList List(ListInterconnectLocationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocationList> ListAsync(ListInterconnectLocationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocationList> ListAsync(ListInterconnectLocationsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectLocationList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListInterconnectLocationsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocationList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListInterconnectLocationsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectLocationList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>InterconnectLocations client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The InterconnectLocations API.
    /// </remarks>
    public sealed partial class InterconnectLocationsClientImpl : InterconnectLocationsClient
    {
        private readonly gaxgrpc::ApiCall<GetInterconnectLocationRequest, InterconnectLocation> _callGet;

        private readonly gaxgrpc::ApiCall<ListInterconnectLocationsRequest, InterconnectLocationList> _callList;

        /// <summary>
        /// Constructs a client wrapper for the InterconnectLocations service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="InterconnectLocationsSettings"/> used within this client.</param>
        public InterconnectLocationsClientImpl(InterconnectLocations.InterconnectLocationsClient grpcClient, InterconnectLocationsSettings settings)
        {
            GrpcClient = grpcClient;
            InterconnectLocationsSettings effectiveSettings = settings ?? InterconnectLocationsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callGet = clientHelper.BuildApiCall<GetInterconnectLocationRequest, InterconnectLocation>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("interconnect_location", request => request.InterconnectLocation);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callList = clientHelper.BuildApiCall<ListInterconnectLocationsRequest, InterconnectLocationList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetInterconnectLocationRequest, InterconnectLocation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListInterconnectLocationsRequest, InterconnectLocationList> call);

        partial void OnConstruction(InterconnectLocations.InterconnectLocationsClient grpcClient, InterconnectLocationsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC InterconnectLocations client</summary>
        public override InterconnectLocations.InterconnectLocationsClient GrpcClient { get; }

        partial void Modify_GetInterconnectLocationRequest(ref GetInterconnectLocationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListInterconnectLocationsRequest(ref ListInterconnectLocationsRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InterconnectLocation Get(GetInterconnectLocationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInterconnectLocationRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the details for the specified interconnect location. Gets a list of available interconnect locations by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InterconnectLocation> GetAsync(GetInterconnectLocationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInterconnectLocationRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InterconnectLocationList List(ListInterconnectLocationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInterconnectLocationsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of interconnect locations available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InterconnectLocationList> ListAsync(ListInterconnectLocationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInterconnectLocationsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }
    }
}
