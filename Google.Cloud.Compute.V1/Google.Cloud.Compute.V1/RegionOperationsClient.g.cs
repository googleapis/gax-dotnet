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
    /// <summary>Settings for <see cref="RegionOperationsClient"/> instances.</summary>
    public sealed partial class RegionOperationsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="RegionOperationsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="RegionOperationsSettings"/>.</returns>
        public static RegionOperationsSettings GetDefault() => new RegionOperationsSettings();

        /// <summary>Constructs a new <see cref="RegionOperationsSettings"/> object with default settings.</summary>
        public RegionOperationsSettings()
        {
        }

        private RegionOperationsSettings(RegionOperationsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            ListSettings = existing.ListSettings;
            WaitSettings = existing.WaitSettings;
            OnCopy(existing);
        }

        partial void OnCopy(RegionOperationsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>RegionOperationsClient.Delete</c> and <c>RegionOperationsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>RegionOperationsClient.Get</c>
        ///  and <c>RegionOperationsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>RegionOperationsClient.List</c>
        ///  and <c>RegionOperationsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>RegionOperationsClient.Wait</c>
        ///  and <c>RegionOperationsClient.WaitAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WaitSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="RegionOperationsSettings"/> object.</returns>
        public RegionOperationsSettings Clone() => new RegionOperationsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="RegionOperationsClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class RegionOperationsClientBuilder : gaxgrpc::ClientBuilderBase<RegionOperationsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public RegionOperationsSettings Settings { get; set; }

        partial void InterceptBuild(ref RegionOperationsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<RegionOperationsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override RegionOperationsClient Build()
        {
            RegionOperationsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<RegionOperationsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<RegionOperationsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private RegionOperationsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return RegionOperationsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<RegionOperationsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return RegionOperationsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => RegionOperationsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => RegionOperationsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => RegionOperationsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>RegionOperations client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The RegionOperations API.
    /// </remarks>
    public abstract partial class RegionOperationsClient
    {
        /// <summary>
        /// The default endpoint for the RegionOperations service, which is a host of "compute.googleapis.com" and a
        /// port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default RegionOperations scopes.</summary>
        /// <remarks>
        /// The default RegionOperations scopes are:
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
        /// Asynchronously creates a <see cref="RegionOperationsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="RegionOperationsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="RegionOperationsClient"/>.</returns>
        public static stt::Task<RegionOperationsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new RegionOperationsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="RegionOperationsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="RegionOperationsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="RegionOperationsClient"/>.</returns>
        public static RegionOperationsClient Create() => new RegionOperationsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="RegionOperationsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="RegionOperationsSettings"/>.</param>
        /// <returns>The created <see cref="RegionOperationsClient"/>.</returns>
        internal static RegionOperationsClient Create(grpccore::CallInvoker callInvoker, RegionOperationsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            RegionOperations.RegionOperationsClient grpcClient = new RegionOperations.RegionOperationsClient(callInvoker);
            return new RegionOperationsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC RegionOperations client</summary>
        public virtual RegionOperations.RegionOperationsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual DeleteRegionOperationResponse Delete(DeleteRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteRegionOperationResponse> DeleteAsync(DeleteRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteRegionOperationResponse> DeleteAsync(DeleteRegionOperationRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual DeleteRegionOperationResponse Delete(string project, string region, string operation, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteRegionOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteRegionOperationResponse> DeleteAsync(string project, string region, string operation, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteRegionOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteRegionOperationResponse> DeleteAsync(string project, string region, string operation, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, region, operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Get(GetRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(GetRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(GetRegionOperationRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Get(string project, string region, string operation, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetRegionOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(string project, string region, string operation, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetRegionOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(string project, string region, string operation, st::CancellationToken cancellationToken) =>
            GetAsync(project, region, operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual OperationList List(ListRegionOperationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(ListRegionOperationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(ListRegionOperationsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual OperationList List(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListRegionOperationsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(string project, string region, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListRegionOperationsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(string project, string region, st::CancellationToken cancellationToken) =>
            ListAsync(project, region, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Wait(WaitRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> WaitAsync(WaitRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> WaitAsync(WaitRegionOperationRequest request, st::CancellationToken cancellationToken) =>
            WaitAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Wait(string project, string region, string operation, gaxgrpc::CallSettings callSettings = null) =>
            Wait(new WaitRegionOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> WaitAsync(string project, string region, string operation, gaxgrpc::CallSettings callSettings = null) =>
            WaitAsync(new WaitRegionOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Region = gax::GaxPreconditions.CheckNotNullOrEmpty(region, nameof(region)),
            }, callSettings);

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="region">
        /// Name of the region for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> WaitAsync(string project, string region, string operation, st::CancellationToken cancellationToken) =>
            WaitAsync(project, region, operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>RegionOperations client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The RegionOperations API.
    /// </remarks>
    public sealed partial class RegionOperationsClientImpl : RegionOperationsClient
    {
        private readonly gaxgrpc::ApiCall<DeleteRegionOperationRequest, DeleteRegionOperationResponse> _callDelete;

        private readonly gaxgrpc::ApiCall<GetRegionOperationRequest, Operation> _callGet;

        private readonly gaxgrpc::ApiCall<ListRegionOperationsRequest, OperationList> _callList;

        private readonly gaxgrpc::ApiCall<WaitRegionOperationRequest, Operation> _callWait;

        /// <summary>
        /// Constructs a client wrapper for the RegionOperations service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="RegionOperationsSettings"/> used within this client.</param>
        public RegionOperationsClientImpl(RegionOperations.RegionOperationsClient grpcClient, RegionOperationsSettings settings)
        {
            GrpcClient = grpcClient;
            RegionOperationsSettings effectiveSettings = settings ?? RegionOperationsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteRegionOperationRequest, DeleteRegionOperationResponse>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetRegionOperationRequest, Operation>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callList = clientHelper.BuildApiCall<ListRegionOperationsRequest, OperationList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callWait = clientHelper.BuildApiCall<WaitRegionOperationRequest, Operation>(grpcClient.WaitAsync, grpcClient.Wait, effectiveSettings.WaitSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("region", request => request.Region).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callWait);
            Modify_WaitApiCall(ref _callWait);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteRegionOperationRequest, DeleteRegionOperationResponse> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetRegionOperationRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListRegionOperationsRequest, OperationList> call);

        partial void Modify_WaitApiCall(ref gaxgrpc::ApiCall<WaitRegionOperationRequest, Operation> call);

        partial void OnConstruction(RegionOperations.RegionOperationsClient grpcClient, RegionOperationsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC RegionOperations client</summary>
        public override RegionOperations.RegionOperationsClient GrpcClient { get; }

        partial void Modify_DeleteRegionOperationRequest(ref DeleteRegionOperationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRegionOperationRequest(ref GetRegionOperationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListRegionOperationsRequest(ref ListRegionOperationsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WaitRegionOperationRequest(ref WaitRegionOperationRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override DeleteRegionOperationResponse Delete(DeleteRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionOperationRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<DeleteRegionOperationResponse> DeleteAsync(DeleteRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteRegionOperationRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Get(GetRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionOperationRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the specified region-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> GetAsync(GetRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRegionOperationRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override OperationList List(ListRegionOperationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionOperationsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified region.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<OperationList> ListAsync(ListRegionOperationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListRegionOperationsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Wait(WaitRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WaitRegionOperationRequest(ref request, ref callSettings);
            return _callWait.Sync(request, callSettings);
        }

        /// <summary>
        /// Waits for the specified Operation resource to return as `DONE` or for the request to approach the 2 minute deadline, and retrieves the specified Operation resource. This method differs from the `GET` method in that it waits for no more than the default deadline (2 minutes) and then returns the current state of the operation, which might be `DONE` or still in progress.
        /// 
        /// This method is called on a best-effort basis. Specifically:
        /// - In uncommon cases, when the server is overloaded, the request might return before the default deadline is reached, or might return after zero seconds.
        /// - If the default deadline is reached, there is no guarantee that the operation is actually done when the method returns. Be prepared to retry if the operation is not `DONE`.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> WaitAsync(WaitRegionOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WaitRegionOperationRequest(ref request, ref callSettings);
            return _callWait.Async(request, callSettings);
        }
    }
}
