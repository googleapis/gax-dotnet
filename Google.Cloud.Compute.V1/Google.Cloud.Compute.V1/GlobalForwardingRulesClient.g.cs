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
    /// <summary>Settings for <see cref="GlobalForwardingRulesClient"/> instances.</summary>
    public sealed partial class GlobalForwardingRulesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="GlobalForwardingRulesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="GlobalForwardingRulesSettings"/>.</returns>
        public static GlobalForwardingRulesSettings GetDefault() => new GlobalForwardingRulesSettings();

        /// <summary>
        /// Constructs a new <see cref="GlobalForwardingRulesSettings"/> object with default settings.
        /// </summary>
        public GlobalForwardingRulesSettings()
        {
        }

        private GlobalForwardingRulesSettings(GlobalForwardingRulesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            SetTargetSettings = existing.SetTargetSettings;
            OnCopy(existing);
        }

        partial void OnCopy(GlobalForwardingRulesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>GlobalForwardingRulesClient.Delete</c> and <c>GlobalForwardingRulesClient.DeleteAsync</c>.
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
        /// <c>GlobalForwardingRulesClient.Get</c> and <c>GlobalForwardingRulesClient.GetAsync</c>.
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
        /// <c>GlobalForwardingRulesClient.Insert</c> and <c>GlobalForwardingRulesClient.InsertAsync</c>.
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
        /// <c>GlobalForwardingRulesClient.List</c> and <c>GlobalForwardingRulesClient.ListAsync</c>.
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
        /// <c>GlobalForwardingRulesClient.Patch</c> and <c>GlobalForwardingRulesClient.PatchAsync</c>.
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
        /// <c>GlobalForwardingRulesClient.SetTarget</c> and <c>GlobalForwardingRulesClient.SetTargetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SetTargetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="GlobalForwardingRulesSettings"/> object.</returns>
        public GlobalForwardingRulesSettings Clone() => new GlobalForwardingRulesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="GlobalForwardingRulesClient"/> to provide simple configuration of credentials,
    /// endpoint etc.
    /// </summary>
    public sealed partial class GlobalForwardingRulesClientBuilder : gaxgrpc::ClientBuilderBase<GlobalForwardingRulesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public GlobalForwardingRulesSettings Settings { get; set; }

        partial void InterceptBuild(ref GlobalForwardingRulesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<GlobalForwardingRulesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override GlobalForwardingRulesClient Build()
        {
            GlobalForwardingRulesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<GlobalForwardingRulesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<GlobalForwardingRulesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private GlobalForwardingRulesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return GlobalForwardingRulesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<GlobalForwardingRulesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return GlobalForwardingRulesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => GlobalForwardingRulesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => GlobalForwardingRulesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => GlobalForwardingRulesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>GlobalForwardingRules client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The GlobalForwardingRules API.
    /// </remarks>
    public abstract partial class GlobalForwardingRulesClient
    {
        /// <summary>
        /// The default endpoint for the GlobalForwardingRules service, which is a host of "compute.googleapis.com" and
        /// a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default GlobalForwardingRules scopes.</summary>
        /// <remarks>
        /// The default GlobalForwardingRules scopes are:
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
        /// Asynchronously creates a <see cref="GlobalForwardingRulesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="GlobalForwardingRulesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="GlobalForwardingRulesClient"/>.</returns>
        public static stt::Task<GlobalForwardingRulesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new GlobalForwardingRulesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="GlobalForwardingRulesClient"/> using the default credentials, endpoint
        /// and settings. To specify custom credentials or other settings, use
        /// <see cref="GlobalForwardingRulesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="GlobalForwardingRulesClient"/>.</returns>
        public static GlobalForwardingRulesClient Create() => new GlobalForwardingRulesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="GlobalForwardingRulesClient"/> which uses the specified call invoker for remote
        /// operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="GlobalForwardingRulesSettings"/>.</param>
        /// <returns>The created <see cref="GlobalForwardingRulesClient"/>.</returns>
        internal static GlobalForwardingRulesClient Create(grpccore::CallInvoker callInvoker, GlobalForwardingRulesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            GlobalForwardingRules.GlobalForwardingRulesClient grpcClient = new GlobalForwardingRules.GlobalForwardingRulesClient(callInvoker);
            return new GlobalForwardingRulesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC GlobalForwardingRules client</summary>
        public virtual GlobalForwardingRules.GlobalForwardingRulesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteGlobalForwardingRuleRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string forwardingRule, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string forwardingRule, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string forwardingRule, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, forwardingRule, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ForwardingRule Get(GetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRule> GetAsync(GetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRule> GetAsync(GetGlobalForwardingRuleRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ForwardingRule Get(string project, string forwardingRule, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRule> GetAsync(string project, string forwardingRule, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRule> GetAsync(string project, string forwardingRule, st::CancellationToken cancellationToken) =>
            GetAsync(project, forwardingRule, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertGlobalForwardingRuleRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, ForwardingRule forwardingRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertGlobalForwardingRuleRequest
            {
                ForwardingRuleResource = gax::GaxPreconditions.CheckNotNull(forwardingRuleResource, nameof(forwardingRuleResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, ForwardingRule forwardingRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertGlobalForwardingRuleRequest
            {
                ForwardingRuleResource = gax::GaxPreconditions.CheckNotNull(forwardingRuleResource, nameof(forwardingRuleResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, ForwardingRule forwardingRuleResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, forwardingRuleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ForwardingRuleList List(ListGlobalForwardingRulesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRuleList> ListAsync(ListGlobalForwardingRulesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRuleList> ListAsync(ListGlobalForwardingRulesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual ForwardingRuleList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListGlobalForwardingRulesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRuleList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListGlobalForwardingRulesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<ForwardingRuleList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchGlobalForwardingRuleRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to patch.
        /// </param>
        /// <param name="forwardingRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string forwardingRule, ForwardingRule forwardingRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                ForwardingRuleResource = gax::GaxPreconditions.CheckNotNull(forwardingRuleResource, nameof(forwardingRuleResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to patch.
        /// </param>
        /// <param name="forwardingRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string forwardingRule, ForwardingRule forwardingRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                ForwardingRuleResource = gax::GaxPreconditions.CheckNotNull(forwardingRuleResource, nameof(forwardingRuleResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource to patch.
        /// </param>
        /// <param name="forwardingRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string forwardingRule, ForwardingRule forwardingRuleResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, forwardingRule, forwardingRuleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetTarget(SetTargetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetAsync(SetTargetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetAsync(SetTargetGlobalForwardingRuleRequest request, st::CancellationToken cancellationToken) =>
            SetTargetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource in which target is to be set.
        /// </param>
        /// <param name="targetReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation SetTarget(string project, string forwardingRule, TargetReference targetReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            SetTarget(new SetTargetGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetReferenceResource = gax::GaxPreconditions.CheckNotNull(targetReferenceResource, nameof(targetReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource in which target is to be set.
        /// </param>
        /// <param name="targetReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetAsync(string project, string forwardingRule, TargetReference targetReferenceResource, gaxgrpc::CallSettings callSettings = null) =>
            SetTargetAsync(new SetTargetGlobalForwardingRuleRequest
            {
                ForwardingRule = gax::GaxPreconditions.CheckNotNullOrEmpty(forwardingRule, nameof(forwardingRule)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                TargetReferenceResource = gax::GaxPreconditions.CheckNotNull(targetReferenceResource, nameof(targetReferenceResource)),
            }, callSettings);

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="forwardingRule">
        /// Name of the ForwardingRule resource in which target is to be set.
        /// </param>
        /// <param name="targetReferenceResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> SetTargetAsync(string project, string forwardingRule, TargetReference targetReferenceResource, st::CancellationToken cancellationToken) =>
            SetTargetAsync(project, forwardingRule, targetReferenceResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>GlobalForwardingRules client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The GlobalForwardingRules API.
    /// </remarks>
    public sealed partial class GlobalForwardingRulesClientImpl : GlobalForwardingRulesClient
    {
        private readonly gaxgrpc::ApiCall<DeleteGlobalForwardingRuleRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetGlobalForwardingRuleRequest, ForwardingRule> _callGet;

        private readonly gaxgrpc::ApiCall<InsertGlobalForwardingRuleRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListGlobalForwardingRulesRequest, ForwardingRuleList> _callList;

        private readonly gaxgrpc::ApiCall<PatchGlobalForwardingRuleRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<SetTargetGlobalForwardingRuleRequest, Operation> _callSetTarget;

        /// <summary>
        /// Constructs a client wrapper for the GlobalForwardingRules service, with the specified gRPC client and
        /// settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="GlobalForwardingRulesSettings"/> used within this client.</param>
        public GlobalForwardingRulesClientImpl(GlobalForwardingRules.GlobalForwardingRulesClient grpcClient, GlobalForwardingRulesSettings settings)
        {
            GrpcClient = grpcClient;
            GlobalForwardingRulesSettings effectiveSettings = settings ?? GlobalForwardingRulesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteGlobalForwardingRuleRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("forwarding_rule", request => request.ForwardingRule);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetGlobalForwardingRuleRequest, ForwardingRule>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("forwarding_rule", request => request.ForwardingRule);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertGlobalForwardingRuleRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListGlobalForwardingRulesRequest, ForwardingRuleList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchGlobalForwardingRuleRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("forwarding_rule", request => request.ForwardingRule);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callSetTarget = clientHelper.BuildApiCall<SetTargetGlobalForwardingRuleRequest, Operation>(grpcClient.SetTargetAsync, grpcClient.SetTarget, effectiveSettings.SetTargetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("forwarding_rule", request => request.ForwardingRule);
            Modify_ApiCall(ref _callSetTarget);
            Modify_SetTargetApiCall(ref _callSetTarget);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteGlobalForwardingRuleRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetGlobalForwardingRuleRequest, ForwardingRule> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertGlobalForwardingRuleRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListGlobalForwardingRulesRequest, ForwardingRuleList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchGlobalForwardingRuleRequest, Operation> call);

        partial void Modify_SetTargetApiCall(ref gaxgrpc::ApiCall<SetTargetGlobalForwardingRuleRequest, Operation> call);

        partial void OnConstruction(GlobalForwardingRules.GlobalForwardingRulesClient grpcClient, GlobalForwardingRulesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC GlobalForwardingRules client</summary>
        public override GlobalForwardingRules.GlobalForwardingRulesClient GrpcClient { get; }

        partial void Modify_DeleteGlobalForwardingRuleRequest(ref DeleteGlobalForwardingRuleRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetGlobalForwardingRuleRequest(ref GetGlobalForwardingRuleRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertGlobalForwardingRuleRequest(ref InsertGlobalForwardingRuleRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListGlobalForwardingRulesRequest(ref ListGlobalForwardingRulesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchGlobalForwardingRuleRequest(ref PatchGlobalForwardingRuleRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_SetTargetGlobalForwardingRuleRequest(ref SetTargetGlobalForwardingRuleRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified GlobalForwardingRule resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override ForwardingRule Get(GetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified GlobalForwardingRule resource. Gets a list of available forwarding rules by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<ForwardingRule> GetAsync(GetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a GlobalForwardingRule resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override ForwardingRuleList List(ListGlobalForwardingRulesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListGlobalForwardingRulesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves a list of GlobalForwardingRule resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<ForwardingRuleList> ListAsync(ListGlobalForwardingRulesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListGlobalForwardingRulesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified forwarding rule with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules. Currently, you can only patch the network_tier field.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation SetTarget(SetTargetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetTargetGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callSetTarget.Sync(request, callSettings);
        }

        /// <summary>
        /// Changes target URL for the GlobalForwardingRule resource. The new target should be of the same type as the old target.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> SetTargetAsync(SetTargetGlobalForwardingRuleRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SetTargetGlobalForwardingRuleRequest(ref request, ref callSettings);
            return _callSetTarget.Async(request, callSettings);
        }
    }
}
