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
    /// <summary>Settings for <see cref="TargetGrpcProxiesClient"/> instances.</summary>
    public sealed partial class TargetGrpcProxiesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="TargetGrpcProxiesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="TargetGrpcProxiesSettings"/>.</returns>
        public static TargetGrpcProxiesSettings GetDefault() => new TargetGrpcProxiesSettings();

        /// <summary>Constructs a new <see cref="TargetGrpcProxiesSettings"/> object with default settings.</summary>
        public TargetGrpcProxiesSettings()
        {
        }

        private TargetGrpcProxiesSettings(TargetGrpcProxiesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            OnCopy(existing);
        }

        partial void OnCopy(TargetGrpcProxiesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>TargetGrpcProxiesClient.Delete</c> and <c>TargetGrpcProxiesClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>TargetGrpcProxiesClient.Get</c>
        ///  and <c>TargetGrpcProxiesClient.GetAsync</c>.
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
        /// <c>TargetGrpcProxiesClient.Insert</c> and <c>TargetGrpcProxiesClient.InsertAsync</c>.
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
        /// <c>TargetGrpcProxiesClient.List</c> and <c>TargetGrpcProxiesClient.ListAsync</c>.
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
        /// <c>TargetGrpcProxiesClient.Patch</c> and <c>TargetGrpcProxiesClient.PatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="TargetGrpcProxiesSettings"/> object.</returns>
        public TargetGrpcProxiesSettings Clone() => new TargetGrpcProxiesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="TargetGrpcProxiesClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class TargetGrpcProxiesClientBuilder : gaxgrpc::ClientBuilderBase<TargetGrpcProxiesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public TargetGrpcProxiesSettings Settings { get; set; }

        partial void InterceptBuild(ref TargetGrpcProxiesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<TargetGrpcProxiesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override TargetGrpcProxiesClient Build()
        {
            TargetGrpcProxiesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<TargetGrpcProxiesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<TargetGrpcProxiesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private TargetGrpcProxiesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return TargetGrpcProxiesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<TargetGrpcProxiesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return TargetGrpcProxiesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => TargetGrpcProxiesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => TargetGrpcProxiesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => TargetGrpcProxiesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>TargetGrpcProxies client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The TargetGrpcProxies API.
    /// </remarks>
    public abstract partial class TargetGrpcProxiesClient
    {
        /// <summary>
        /// The default endpoint for the TargetGrpcProxies service, which is a host of "compute.googleapis.com" and a
        /// port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default TargetGrpcProxies scopes.</summary>
        /// <remarks>
        /// The default TargetGrpcProxies scopes are:
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
        /// Asynchronously creates a <see cref="TargetGrpcProxiesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TargetGrpcProxiesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="TargetGrpcProxiesClient"/>.</returns>
        public static stt::Task<TargetGrpcProxiesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new TargetGrpcProxiesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="TargetGrpcProxiesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="TargetGrpcProxiesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="TargetGrpcProxiesClient"/>.</returns>
        public static TargetGrpcProxiesClient Create() => new TargetGrpcProxiesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="TargetGrpcProxiesClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="TargetGrpcProxiesSettings"/>.</param>
        /// <returns>The created <see cref="TargetGrpcProxiesClient"/>.</returns>
        internal static TargetGrpcProxiesClient Create(grpccore::CallInvoker callInvoker, TargetGrpcProxiesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            TargetGrpcProxies.TargetGrpcProxiesClient grpcClient = new TargetGrpcProxies.TargetGrpcProxiesClient(callInvoker);
            return new TargetGrpcProxiesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC TargetGrpcProxies client</summary>
        public virtual TargetGrpcProxies.TargetGrpcProxiesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteTargetGrpcProxyRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string targetGrpcProxy, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetGrpcProxy, nameof(targetGrpcProxy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string targetGrpcProxy, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetGrpcProxy, nameof(targetGrpcProxy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string targetGrpcProxy, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, targetGrpcProxy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetGrpcProxy Get(GetTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxy> GetAsync(GetTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxy> GetAsync(GetTargetGrpcProxyRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetGrpcProxy Get(string project, string targetGrpcProxy, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetGrpcProxy, nameof(targetGrpcProxy)),
            }, callSettings);

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxy> GetAsync(string project, string targetGrpcProxy, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetGrpcProxy, nameof(targetGrpcProxy)),
            }, callSettings);

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxy> GetAsync(string project, string targetGrpcProxy, st::CancellationToken cancellationToken) =>
            GetAsync(project, targetGrpcProxy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertTargetGrpcProxyRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, TargetGrpcProxy targetGrpcProxyResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxyResource = gax::GaxPreconditions.CheckNotNull(targetGrpcProxyResource, nameof(targetGrpcProxyResource)),
            }, callSettings);

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, TargetGrpcProxy targetGrpcProxyResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxyResource = gax::GaxPreconditions.CheckNotNull(targetGrpcProxyResource, nameof(targetGrpcProxyResource)),
            }, callSettings);

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, TargetGrpcProxy targetGrpcProxyResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, targetGrpcProxyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetGrpcProxyList List(ListTargetGrpcProxiesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxyList> ListAsync(ListTargetGrpcProxiesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxyList> ListAsync(ListTargetGrpcProxiesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual TargetGrpcProxyList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListTargetGrpcProxiesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxyList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListTargetGrpcProxiesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<TargetGrpcProxyList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchTargetGrpcProxyRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to patch.
        /// </param>
        /// <param name="targetGrpcProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string targetGrpcProxy, TargetGrpcProxy targetGrpcProxyResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetGrpcProxy, nameof(targetGrpcProxy)),
                TargetGrpcProxyResource = gax::GaxPreconditions.CheckNotNull(targetGrpcProxyResource, nameof(targetGrpcProxyResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to patch.
        /// </param>
        /// <param name="targetGrpcProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string targetGrpcProxy, TargetGrpcProxy targetGrpcProxyResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchTargetGrpcProxyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetGrpcProxy = gax::GaxPreconditions.CheckNotNullOrEmpty(targetGrpcProxy, nameof(targetGrpcProxy)),
                TargetGrpcProxyResource = gax::GaxPreconditions.CheckNotNull(targetGrpcProxyResource, nameof(targetGrpcProxyResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="targetGrpcProxy">
        /// Name of the TargetGrpcProxy resource to patch.
        /// </param>
        /// <param name="targetGrpcProxyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string targetGrpcProxy, TargetGrpcProxy targetGrpcProxyResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, targetGrpcProxy, targetGrpcProxyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>TargetGrpcProxies client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The TargetGrpcProxies API.
    /// </remarks>
    public sealed partial class TargetGrpcProxiesClientImpl : TargetGrpcProxiesClient
    {
        private readonly gaxgrpc::ApiCall<DeleteTargetGrpcProxyRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetTargetGrpcProxyRequest, TargetGrpcProxy> _callGet;

        private readonly gaxgrpc::ApiCall<InsertTargetGrpcProxyRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListTargetGrpcProxiesRequest, TargetGrpcProxyList> _callList;

        private readonly gaxgrpc::ApiCall<PatchTargetGrpcProxyRequest, Operation> _callPatch;

        /// <summary>
        /// Constructs a client wrapper for the TargetGrpcProxies service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="TargetGrpcProxiesSettings"/> used within this client.</param>
        public TargetGrpcProxiesClientImpl(TargetGrpcProxies.TargetGrpcProxiesClient grpcClient, TargetGrpcProxiesSettings settings)
        {
            GrpcClient = grpcClient;
            TargetGrpcProxiesSettings effectiveSettings = settings ?? TargetGrpcProxiesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteTargetGrpcProxyRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("target_grpc_proxy", request => request.TargetGrpcProxy);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetTargetGrpcProxyRequest, TargetGrpcProxy>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("target_grpc_proxy", request => request.TargetGrpcProxy);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertTargetGrpcProxyRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListTargetGrpcProxiesRequest, TargetGrpcProxyList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchTargetGrpcProxyRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("target_grpc_proxy", request => request.TargetGrpcProxy);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteTargetGrpcProxyRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetTargetGrpcProxyRequest, TargetGrpcProxy> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertTargetGrpcProxyRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListTargetGrpcProxiesRequest, TargetGrpcProxyList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchTargetGrpcProxyRequest, Operation> call);

        partial void OnConstruction(TargetGrpcProxies.TargetGrpcProxiesClient grpcClient, TargetGrpcProxiesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC TargetGrpcProxies client</summary>
        public override TargetGrpcProxies.TargetGrpcProxiesClient GrpcClient { get; }

        partial void Modify_DeleteTargetGrpcProxyRequest(ref DeleteTargetGrpcProxyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetTargetGrpcProxyRequest(ref GetTargetGrpcProxyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertTargetGrpcProxyRequest(ref InsertTargetGrpcProxyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListTargetGrpcProxiesRequest(ref ListTargetGrpcProxiesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchTargetGrpcProxyRequest(ref PatchTargetGrpcProxyRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified TargetGrpcProxy in the given scope
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetGrpcProxy Get(GetTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified TargetGrpcProxy resource in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetGrpcProxy> GetAsync(GetTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a TargetGrpcProxy in the specified project in the given scope using the parameters that are included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override TargetGrpcProxyList List(ListTargetGrpcProxiesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTargetGrpcProxiesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists the TargetGrpcProxies for a project in the given scope.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<TargetGrpcProxyList> ListAsync(ListTargetGrpcProxiesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListTargetGrpcProxiesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Patches the specified TargetGrpcProxy resource with the data included in the request. This method supports PATCH semantics and uses JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchTargetGrpcProxyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchTargetGrpcProxyRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }
    }
}
