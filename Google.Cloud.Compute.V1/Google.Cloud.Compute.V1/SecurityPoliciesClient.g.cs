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
    /// <summary>Settings for <see cref="SecurityPoliciesClient"/> instances.</summary>
    public sealed partial class SecurityPoliciesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="SecurityPoliciesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="SecurityPoliciesSettings"/>.</returns>
        public static SecurityPoliciesSettings GetDefault() => new SecurityPoliciesSettings();

        /// <summary>Constructs a new <see cref="SecurityPoliciesSettings"/> object with default settings.</summary>
        public SecurityPoliciesSettings()
        {
        }

        private SecurityPoliciesSettings(SecurityPoliciesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AddRuleSettings = existing.AddRuleSettings;
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            GetRuleSettings = existing.GetRuleSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListPreconfiguredExpressionSetsSettings = existing.ListPreconfiguredExpressionSetsSettings;
            PatchSettings = existing.PatchSettings;
            PatchRuleSettings = existing.PatchRuleSettings;
            RemoveRuleSettings = existing.RemoveRuleSettings;
            OnCopy(existing);
        }

        partial void OnCopy(SecurityPoliciesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SecurityPoliciesClient.AddRule</c> and <c>SecurityPoliciesClient.AddRuleAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddRuleSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SecurityPoliciesClient.Delete</c> and <c>SecurityPoliciesClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SecurityPoliciesClient.Get</c>
        ///  and <c>SecurityPoliciesClient.GetAsync</c>.
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
        /// <c>SecurityPoliciesClient.GetRule</c> and <c>SecurityPoliciesClient.GetRuleAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetRuleSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SecurityPoliciesClient.Insert</c> and <c>SecurityPoliciesClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SecurityPoliciesClient.List</c>
        ///  and <c>SecurityPoliciesClient.ListAsync</c>.
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
        /// <c>SecurityPoliciesClient.ListPreconfiguredExpressionSets</c> and
        /// <c>SecurityPoliciesClient.ListPreconfiguredExpressionSetsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListPreconfiguredExpressionSetsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SecurityPoliciesClient.Patch</c> and <c>SecurityPoliciesClient.PatchAsync</c>.
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
        /// <c>SecurityPoliciesClient.PatchRule</c> and <c>SecurityPoliciesClient.PatchRuleAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchRuleSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>SecurityPoliciesClient.RemoveRule</c> and <c>SecurityPoliciesClient.RemoveRuleAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings RemoveRuleSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="SecurityPoliciesSettings"/> object.</returns>
        public SecurityPoliciesSettings Clone() => new SecurityPoliciesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="SecurityPoliciesClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class SecurityPoliciesClientBuilder : gaxgrpc::ClientBuilderBase<SecurityPoliciesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public SecurityPoliciesSettings Settings { get; set; }

        partial void InterceptBuild(ref SecurityPoliciesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<SecurityPoliciesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override SecurityPoliciesClient Build()
        {
            SecurityPoliciesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<SecurityPoliciesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<SecurityPoliciesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private SecurityPoliciesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return SecurityPoliciesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<SecurityPoliciesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return SecurityPoliciesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => SecurityPoliciesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => SecurityPoliciesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => SecurityPoliciesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>SecurityPolicies client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The SecurityPolicies API.
    /// </remarks>
    public abstract partial class SecurityPoliciesClient
    {
        /// <summary>
        /// The default endpoint for the SecurityPolicies service, which is a host of "compute.googleapis.com" and a
        /// port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default SecurityPolicies scopes.</summary>
        /// <remarks>
        /// The default SecurityPolicies scopes are:
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
        /// Asynchronously creates a <see cref="SecurityPoliciesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="SecurityPoliciesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="SecurityPoliciesClient"/>.</returns>
        public static stt::Task<SecurityPoliciesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new SecurityPoliciesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="SecurityPoliciesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="SecurityPoliciesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="SecurityPoliciesClient"/>.</returns>
        public static SecurityPoliciesClient Create() => new SecurityPoliciesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="SecurityPoliciesClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="SecurityPoliciesSettings"/>.</param>
        /// <returns>The created <see cref="SecurityPoliciesClient"/>.</returns>
        internal static SecurityPoliciesClient Create(grpccore::CallInvoker callInvoker, SecurityPoliciesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            SecurityPolicies.SecurityPoliciesClient grpcClient = new SecurityPolicies.SecurityPoliciesClient(callInvoker);
            return new SecurityPoliciesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC SecurityPolicies client</summary>
        public virtual SecurityPolicies.SecurityPoliciesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddRule(AddRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddRuleAsync(AddRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddRuleAsync(AddRuleSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            AddRuleAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddRule(string project, string securityPolicy, SecurityPolicyRule securityPolicyRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            AddRule(new AddRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
                SecurityPolicyRuleResource = gax::GaxPreconditions.CheckNotNull(securityPolicyRuleResource, nameof(securityPolicyRuleResource)),
            }, callSettings);

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddRuleAsync(string project, string securityPolicy, SecurityPolicyRule securityPolicyRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            AddRuleAsync(new AddRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
                SecurityPolicyRuleResource = gax::GaxPreconditions.CheckNotNull(securityPolicyRuleResource, nameof(securityPolicyRuleResource)),
            }, callSettings);

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddRuleAsync(string project, string securityPolicy, SecurityPolicyRule securityPolicyRuleResource, st::CancellationToken cancellationToken) =>
            AddRuleAsync(project, securityPolicy, securityPolicyRuleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string securityPolicy, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, securityPolicy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPolicy Get(GetSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicy> GetAsync(GetSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicy> GetAsync(GetSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to get.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPolicy Get(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to get.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicy> GetAsync(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to get.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicy> GetAsync(string project, string securityPolicy, st::CancellationToken cancellationToken) =>
            GetAsync(project, securityPolicy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPolicyRule GetRule(GetRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyRule> GetRuleAsync(GetRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyRule> GetRuleAsync(GetRuleSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            GetRuleAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to which the queried rule belongs.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPolicyRule GetRule(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            GetRule(new GetRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to which the queried rule belongs.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyRule> GetRuleAsync(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            GetRuleAsync(new GetRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to which the queried rule belongs.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyRule> GetRuleAsync(string project, string securityPolicy, st::CancellationToken cancellationToken) =>
            GetRuleAsync(project, securityPolicy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, SecurityPolicy securityPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicyResource = gax::GaxPreconditions.CheckNotNull(securityPolicyResource, nameof(securityPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, SecurityPolicy securityPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicyResource = gax::GaxPreconditions.CheckNotNull(securityPolicyResource, nameof(securityPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, SecurityPolicy securityPolicyResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, securityPolicyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPolicyList List(ListSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyList> ListAsync(ListSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyList> ListAsync(ListSecurityPoliciesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPolicyList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListSecurityPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListSecurityPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPolicyList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPoliciesListPreconfiguredExpressionSetsResponse ListPreconfiguredExpressionSets(ListPreconfiguredExpressionSetsSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPoliciesListPreconfiguredExpressionSetsResponse> ListPreconfiguredExpressionSetsAsync(ListPreconfiguredExpressionSetsSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPoliciesListPreconfiguredExpressionSetsResponse> ListPreconfiguredExpressionSetsAsync(ListPreconfiguredExpressionSetsSecurityPoliciesRequest request, st::CancellationToken cancellationToken) =>
            ListPreconfiguredExpressionSetsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SecurityPoliciesListPreconfiguredExpressionSetsResponse ListPreconfiguredExpressionSets(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListPreconfiguredExpressionSets(new ListPreconfiguredExpressionSetsSecurityPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPoliciesListPreconfiguredExpressionSetsResponse> ListPreconfiguredExpressionSetsAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListPreconfiguredExpressionSetsAsync(new ListPreconfiguredExpressionSetsSecurityPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SecurityPoliciesListPreconfiguredExpressionSetsResponse> ListPreconfiguredExpressionSetsAsync(string project, st::CancellationToken cancellationToken) =>
            ListPreconfiguredExpressionSetsAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string securityPolicy, SecurityPolicy securityPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
                SecurityPolicyResource = gax::GaxPreconditions.CheckNotNull(securityPolicyResource, nameof(securityPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string securityPolicy, SecurityPolicy securityPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
                SecurityPolicyResource = gax::GaxPreconditions.CheckNotNull(securityPolicyResource, nameof(securityPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string securityPolicy, SecurityPolicy securityPolicyResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, securityPolicy, securityPolicyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation PatchRule(PatchRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchRuleAsync(PatchRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchRuleAsync(PatchRuleSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            PatchRuleAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation PatchRule(string project, string securityPolicy, SecurityPolicyRule securityPolicyRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchRule(new PatchRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
                SecurityPolicyRuleResource = gax::GaxPreconditions.CheckNotNull(securityPolicyRuleResource, nameof(securityPolicyRuleResource)),
            }, callSettings);

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchRuleAsync(string project, string securityPolicy, SecurityPolicyRule securityPolicyRuleResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchRuleAsync(new PatchRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
                SecurityPolicyRuleResource = gax::GaxPreconditions.CheckNotNull(securityPolicyRuleResource, nameof(securityPolicyRuleResource)),
            }, callSettings);

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="securityPolicyRuleResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchRuleAsync(string project, string securityPolicy, SecurityPolicyRule securityPolicyRuleResource, st::CancellationToken cancellationToken) =>
            PatchRuleAsync(project, securityPolicy, securityPolicyRuleResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveRule(RemoveRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveRuleAsync(RemoveRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveRuleAsync(RemoveRuleSecurityPolicyRequest request, st::CancellationToken cancellationToken) =>
            RemoveRuleAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation RemoveRule(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            RemoveRule(new RemoveRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveRuleAsync(string project, string securityPolicy, gaxgrpc::CallSettings callSettings = null) =>
            RemoveRuleAsync(new RemoveRuleSecurityPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SecurityPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(securityPolicy, nameof(securityPolicy)),
            }, callSettings);

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="securityPolicy">
        /// Name of the security policy to update.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> RemoveRuleAsync(string project, string securityPolicy, st::CancellationToken cancellationToken) =>
            RemoveRuleAsync(project, securityPolicy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>SecurityPolicies client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The SecurityPolicies API.
    /// </remarks>
    public sealed partial class SecurityPoliciesClientImpl : SecurityPoliciesClient
    {
        private readonly gaxgrpc::ApiCall<AddRuleSecurityPolicyRequest, Operation> _callAddRule;

        private readonly gaxgrpc::ApiCall<DeleteSecurityPolicyRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetSecurityPolicyRequest, SecurityPolicy> _callGet;

        private readonly gaxgrpc::ApiCall<GetRuleSecurityPolicyRequest, SecurityPolicyRule> _callGetRule;

        private readonly gaxgrpc::ApiCall<InsertSecurityPolicyRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListSecurityPoliciesRequest, SecurityPolicyList> _callList;

        private readonly gaxgrpc::ApiCall<ListPreconfiguredExpressionSetsSecurityPoliciesRequest, SecurityPoliciesListPreconfiguredExpressionSetsResponse> _callListPreconfiguredExpressionSets;

        private readonly gaxgrpc::ApiCall<PatchSecurityPolicyRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<PatchRuleSecurityPolicyRequest, Operation> _callPatchRule;

        private readonly gaxgrpc::ApiCall<RemoveRuleSecurityPolicyRequest, Operation> _callRemoveRule;

        /// <summary>
        /// Constructs a client wrapper for the SecurityPolicies service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="SecurityPoliciesSettings"/> used within this client.</param>
        public SecurityPoliciesClientImpl(SecurityPolicies.SecurityPoliciesClient grpcClient, SecurityPoliciesSettings settings)
        {
            GrpcClient = grpcClient;
            SecurityPoliciesSettings effectiveSettings = settings ?? SecurityPoliciesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAddRule = clientHelper.BuildApiCall<AddRuleSecurityPolicyRequest, Operation>(grpcClient.AddRuleAsync, grpcClient.AddRule, effectiveSettings.AddRuleSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callAddRule);
            Modify_AddRuleApiCall(ref _callAddRule);
            _callDelete = clientHelper.BuildApiCall<DeleteSecurityPolicyRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetSecurityPolicyRequest, SecurityPolicy>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callGetRule = clientHelper.BuildApiCall<GetRuleSecurityPolicyRequest, SecurityPolicyRule>(grpcClient.GetRuleAsync, grpcClient.GetRule, effectiveSettings.GetRuleSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callGetRule);
            Modify_GetRuleApiCall(ref _callGetRule);
            _callInsert = clientHelper.BuildApiCall<InsertSecurityPolicyRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListSecurityPoliciesRequest, SecurityPolicyList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListPreconfiguredExpressionSets = clientHelper.BuildApiCall<ListPreconfiguredExpressionSetsSecurityPoliciesRequest, SecurityPoliciesListPreconfiguredExpressionSetsResponse>(grpcClient.ListPreconfiguredExpressionSetsAsync, grpcClient.ListPreconfiguredExpressionSets, effectiveSettings.ListPreconfiguredExpressionSetsSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callListPreconfiguredExpressionSets);
            Modify_ListPreconfiguredExpressionSetsApiCall(ref _callListPreconfiguredExpressionSets);
            _callPatch = clientHelper.BuildApiCall<PatchSecurityPolicyRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callPatchRule = clientHelper.BuildApiCall<PatchRuleSecurityPolicyRequest, Operation>(grpcClient.PatchRuleAsync, grpcClient.PatchRule, effectiveSettings.PatchRuleSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callPatchRule);
            Modify_PatchRuleApiCall(ref _callPatchRule);
            _callRemoveRule = clientHelper.BuildApiCall<RemoveRuleSecurityPolicyRequest, Operation>(grpcClient.RemoveRuleAsync, grpcClient.RemoveRule, effectiveSettings.RemoveRuleSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("security_policy", request => request.SecurityPolicy);
            Modify_ApiCall(ref _callRemoveRule);
            Modify_RemoveRuleApiCall(ref _callRemoveRule);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AddRuleApiCall(ref gaxgrpc::ApiCall<AddRuleSecurityPolicyRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteSecurityPolicyRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetSecurityPolicyRequest, SecurityPolicy> call);

        partial void Modify_GetRuleApiCall(ref gaxgrpc::ApiCall<GetRuleSecurityPolicyRequest, SecurityPolicyRule> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertSecurityPolicyRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListSecurityPoliciesRequest, SecurityPolicyList> call);

        partial void Modify_ListPreconfiguredExpressionSetsApiCall(ref gaxgrpc::ApiCall<ListPreconfiguredExpressionSetsSecurityPoliciesRequest, SecurityPoliciesListPreconfiguredExpressionSetsResponse> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchSecurityPolicyRequest, Operation> call);

        partial void Modify_PatchRuleApiCall(ref gaxgrpc::ApiCall<PatchRuleSecurityPolicyRequest, Operation> call);

        partial void Modify_RemoveRuleApiCall(ref gaxgrpc::ApiCall<RemoveRuleSecurityPolicyRequest, Operation> call);

        partial void OnConstruction(SecurityPolicies.SecurityPoliciesClient grpcClient, SecurityPoliciesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC SecurityPolicies client</summary>
        public override SecurityPolicies.SecurityPoliciesClient GrpcClient { get; }

        partial void Modify_AddRuleSecurityPolicyRequest(ref AddRuleSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteSecurityPolicyRequest(ref DeleteSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetSecurityPolicyRequest(ref GetSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetRuleSecurityPolicyRequest(ref GetRuleSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertSecurityPolicyRequest(ref InsertSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListSecurityPoliciesRequest(ref ListSecurityPoliciesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListPreconfiguredExpressionSetsSecurityPoliciesRequest(ref ListPreconfiguredExpressionSetsSecurityPoliciesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchSecurityPolicyRequest(ref PatchSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchRuleSecurityPolicyRequest(ref PatchRuleSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_RemoveRuleSecurityPolicyRequest(ref RemoveRuleSecurityPolicyRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddRule(AddRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callAddRule.Sync(request, callSettings);
        }

        /// <summary>
        /// Inserts a rule into a security policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddRuleAsync(AddRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callAddRule.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSecurityPolicyRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSecurityPolicyRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SecurityPolicy Get(GetSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSecurityPolicyRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// List all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SecurityPolicy> GetAsync(GetSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSecurityPolicyRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SecurityPolicyRule GetRule(GetRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callGetRule.Sync(request, callSettings);
        }

        /// <summary>
        /// Gets a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SecurityPolicyRule> GetRuleAsync(GetRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callGetRule.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertSecurityPolicyRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a new policy in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertSecurityPolicyRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SecurityPolicyList List(ListSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListSecurityPoliciesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// List all the policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SecurityPolicyList> ListAsync(ListSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListSecurityPoliciesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SecurityPoliciesListPreconfiguredExpressionSetsResponse ListPreconfiguredExpressionSets(ListPreconfiguredExpressionSetsSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPreconfiguredExpressionSetsSecurityPoliciesRequest(ref request, ref callSettings);
            return _callListPreconfiguredExpressionSets.Sync(request, callSettings);
        }

        /// <summary>
        /// Gets the current list of preconfigured Web Application Firewall (WAF) expressions.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SecurityPoliciesListPreconfiguredExpressionSetsResponse> ListPreconfiguredExpressionSetsAsync(ListPreconfiguredExpressionSetsSecurityPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListPreconfiguredExpressionSetsSecurityPoliciesRequest(ref request, ref callSettings);
            return _callListPreconfiguredExpressionSets.Async(request, callSettings);
        }

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchSecurityPolicyRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Patches the specified policy with the data included in the request. This cannot be used to be update the rules in the policy. Please use the per rule methods like addRule, patchRule, and removeRule instead.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchSecurityPolicyRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation PatchRule(PatchRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callPatchRule.Sync(request, callSettings);
        }

        /// <summary>
        /// Patches a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchRuleAsync(PatchRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callPatchRule.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation RemoveRule(RemoveRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callRemoveRule.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes a rule at the specified priority.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> RemoveRuleAsync(RemoveRuleSecurityPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_RemoveRuleSecurityPolicyRequest(ref request, ref callSettings);
            return _callRemoveRule.Async(request, callSettings);
        }
    }
}
