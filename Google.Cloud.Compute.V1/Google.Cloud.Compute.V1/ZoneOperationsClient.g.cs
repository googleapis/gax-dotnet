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
    /// <summary>Settings for <see cref="ZoneOperationsClient"/> instances.</summary>
    public sealed partial class ZoneOperationsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ZoneOperationsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ZoneOperationsSettings"/>.</returns>
        public static ZoneOperationsSettings GetDefault() => new ZoneOperationsSettings();

        /// <summary>Constructs a new <see cref="ZoneOperationsSettings"/> object with default settings.</summary>
        public ZoneOperationsSettings()
        {
        }

        private ZoneOperationsSettings(ZoneOperationsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            ListSettings = existing.ListSettings;
            WaitSettings = existing.WaitSettings;
            OnCopy(existing);
        }

        partial void OnCopy(ZoneOperationsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>ZoneOperationsClient.Delete</c>
        ///  and <c>ZoneOperationsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>ZoneOperationsClient.Get</c>
        ///  and <c>ZoneOperationsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>ZoneOperationsClient.List</c>
        ///  and <c>ZoneOperationsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>ZoneOperationsClient.Wait</c>
        ///  and <c>ZoneOperationsClient.WaitAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WaitSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ZoneOperationsSettings"/> object.</returns>
        public ZoneOperationsSettings Clone() => new ZoneOperationsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ZoneOperationsClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class ZoneOperationsClientBuilder : gaxgrpc::ClientBuilderBase<ZoneOperationsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ZoneOperationsSettings Settings { get; set; }

        partial void InterceptBuild(ref ZoneOperationsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ZoneOperationsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ZoneOperationsClient Build()
        {
            ZoneOperationsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ZoneOperationsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ZoneOperationsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ZoneOperationsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return ZoneOperationsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<ZoneOperationsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return ZoneOperationsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => ZoneOperationsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => ZoneOperationsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ZoneOperationsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>ZoneOperations client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The ZoneOperations API.
    /// </remarks>
    public abstract partial class ZoneOperationsClient
    {
        /// <summary>
        /// The default endpoint for the ZoneOperations service, which is a host of "compute.googleapis.com" and a port
        /// of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default ZoneOperations scopes.</summary>
        /// <remarks>
        /// The default ZoneOperations scopes are:
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
        /// Asynchronously creates a <see cref="ZoneOperationsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="ZoneOperationsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ZoneOperationsClient"/>.</returns>
        public static stt::Task<ZoneOperationsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ZoneOperationsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ZoneOperationsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="ZoneOperationsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ZoneOperationsClient"/>.</returns>
        public static ZoneOperationsClient Create() => new ZoneOperationsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ZoneOperationsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ZoneOperationsSettings"/>.</param>
        /// <returns>The created <see cref="ZoneOperationsClient"/>.</returns>
        internal static ZoneOperationsClient Create(grpccore::CallInvoker callInvoker, ZoneOperationsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            ZoneOperations.ZoneOperationsClient grpcClient = new ZoneOperations.ZoneOperationsClient(callInvoker);
            return new ZoneOperationsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC ZoneOperations client</summary>
        public virtual ZoneOperations.ZoneOperationsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual DeleteZoneOperationResponse Delete(DeleteZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteZoneOperationResponse> DeleteAsync(DeleteZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteZoneOperationResponse> DeleteAsync(DeleteZoneOperationRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual DeleteZoneOperationResponse Delete(string project, string zone, string operation, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteZoneOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteZoneOperationResponse> DeleteAsync(string project, string zone, string operation, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteZoneOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<DeleteZoneOperationResponse> DeleteAsync(string project, string zone, string operation, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, zone, operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Get(GetZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(GetZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(GetZoneOperationRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Get(string project, string zone, string operation, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetZoneOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(string project, string zone, string operation, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetZoneOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> GetAsync(string project, string zone, string operation, st::CancellationToken cancellationToken) =>
            GetAsync(project, zone, operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual OperationList List(ListZoneOperationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(ListZoneOperationsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(ListZoneOperationsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual OperationList List(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListZoneOperationsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(string project, string zone, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListZoneOperationsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="zone">
        /// Name of the zone for request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<OperationList> ListAsync(string project, string zone, st::CancellationToken cancellationToken) =>
            ListAsync(project, zone, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

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
        public virtual Operation Wait(WaitZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
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
        public virtual stt::Task<Operation> WaitAsync(WaitZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null) =>
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
        public virtual stt::Task<Operation> WaitAsync(WaitZoneOperationRequest request, st::CancellationToken cancellationToken) =>
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
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Wait(string project, string zone, string operation, gaxgrpc::CallSettings callSettings = null) =>
            Wait(new WaitZoneOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
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
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> WaitAsync(string project, string zone, string operation, gaxgrpc::CallSettings callSettings = null) =>
            WaitAsync(new WaitZoneOperationRequest
            {
                Operation = gax::GaxPreconditions.CheckNotNullOrEmpty(operation, nameof(operation)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                Zone = gax::GaxPreconditions.CheckNotNullOrEmpty(zone, nameof(zone)),
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
        /// <param name="zone">
        /// Name of the zone for this request.
        /// </param>
        /// <param name="operation">
        /// Name of the Operations resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> WaitAsync(string project, string zone, string operation, st::CancellationToken cancellationToken) =>
            WaitAsync(project, zone, operation, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>ZoneOperations client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The ZoneOperations API.
    /// </remarks>
    public sealed partial class ZoneOperationsClientImpl : ZoneOperationsClient
    {
        private readonly gaxgrpc::ApiCall<DeleteZoneOperationRequest, DeleteZoneOperationResponse> _callDelete;

        private readonly gaxgrpc::ApiCall<GetZoneOperationRequest, Operation> _callGet;

        private readonly gaxgrpc::ApiCall<ListZoneOperationsRequest, OperationList> _callList;

        private readonly gaxgrpc::ApiCall<WaitZoneOperationRequest, Operation> _callWait;

        /// <summary>
        /// Constructs a client wrapper for the ZoneOperations service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="ZoneOperationsSettings"/> used within this client.</param>
        public ZoneOperationsClientImpl(ZoneOperations.ZoneOperationsClient grpcClient, ZoneOperationsSettings settings)
        {
            GrpcClient = grpcClient;
            ZoneOperationsSettings effectiveSettings = settings ?? ZoneOperationsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteZoneOperationRequest, DeleteZoneOperationResponse>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetZoneOperationRequest, Operation>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callList = clientHelper.BuildApiCall<ListZoneOperationsRequest, OperationList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callWait = clientHelper.BuildApiCall<WaitZoneOperationRequest, Operation>(grpcClient.WaitAsync, grpcClient.Wait, effectiveSettings.WaitSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("zone", request => request.Zone).WithGoogleRequestParam("operation", request => request.Operation);
            Modify_ApiCall(ref _callWait);
            Modify_WaitApiCall(ref _callWait);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteZoneOperationRequest, DeleteZoneOperationResponse> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetZoneOperationRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListZoneOperationsRequest, OperationList> call);

        partial void Modify_WaitApiCall(ref gaxgrpc::ApiCall<WaitZoneOperationRequest, Operation> call);

        partial void OnConstruction(ZoneOperations.ZoneOperationsClient grpcClient, ZoneOperationsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC ZoneOperations client</summary>
        public override ZoneOperations.ZoneOperationsClient GrpcClient { get; }

        partial void Modify_DeleteZoneOperationRequest(ref DeleteZoneOperationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetZoneOperationRequest(ref GetZoneOperationRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListZoneOperationsRequest(ref ListZoneOperationsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WaitZoneOperationRequest(ref WaitZoneOperationRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override DeleteZoneOperationResponse Delete(DeleteZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteZoneOperationRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<DeleteZoneOperationResponse> DeleteAsync(DeleteZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteZoneOperationRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Get(GetZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetZoneOperationRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the specified zone-specific Operations resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> GetAsync(GetZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetZoneOperationRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override OperationList List(ListZoneOperationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListZoneOperationsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of Operation resources contained within the specified zone.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<OperationList> ListAsync(ListZoneOperationsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListZoneOperationsRequest(ref request, ref callSettings);
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
        public override Operation Wait(WaitZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WaitZoneOperationRequest(ref request, ref callSettings);
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
        public override stt::Task<Operation> WaitAsync(WaitZoneOperationRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WaitZoneOperationRequest(ref request, ref callSettings);
            return _callWait.Async(request, callSettings);
        }
    }
}
