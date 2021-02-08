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
    /// <summary>Settings for <see cref="SslPoliciesClient"/> instances.</summary>
    public sealed partial class SslPoliciesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="SslPoliciesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="SslPoliciesSettings"/>.</returns>
        public static SslPoliciesSettings GetDefault() => new SslPoliciesSettings();

        /// <summary>Constructs a new <see cref="SslPoliciesSettings"/> object with default settings.</summary>
        public SslPoliciesSettings()
        {
        }

        private SslPoliciesSettings(SslPoliciesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            ListAvailableFeaturesSettings = existing.ListAvailableFeaturesSettings;
            PatchSettings = existing.PatchSettings;
            OnCopy(existing);
        }

        partial void OnCopy(SslPoliciesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SslPoliciesClient.Delete</c>
        ///  and <c>SslPoliciesClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SslPoliciesClient.Get</c>
        /// and <c>SslPoliciesClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SslPoliciesClient.Insert</c>
        ///  and <c>SslPoliciesClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SslPoliciesClient.List</c>
        /// and <c>SslPoliciesClient.ListAsync</c>.
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
        /// <c>SslPoliciesClient.ListAvailableFeatures</c> and <c>SslPoliciesClient.ListAvailableFeaturesAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListAvailableFeaturesSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>SslPoliciesClient.Patch</c>
        /// and <c>SslPoliciesClient.PatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="SslPoliciesSettings"/> object.</returns>
        public SslPoliciesSettings Clone() => new SslPoliciesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="SslPoliciesClient"/> to provide simple configuration of credentials, endpoint etc.
    /// </summary>
    public sealed partial class SslPoliciesClientBuilder : gaxgrpc::ClientBuilderBase<SslPoliciesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public SslPoliciesSettings Settings { get; set; }

        partial void InterceptBuild(ref SslPoliciesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<SslPoliciesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override SslPoliciesClient Build()
        {
            SslPoliciesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<SslPoliciesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<SslPoliciesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private SslPoliciesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return SslPoliciesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<SslPoliciesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return SslPoliciesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => SslPoliciesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => SslPoliciesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => SslPoliciesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>SslPolicies client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The SslPolicies API.
    /// </remarks>
    public abstract partial class SslPoliciesClient
    {
        /// <summary>
        /// The default endpoint for the SslPolicies service, which is a host of "compute.googleapis.com" and a port of
        /// 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default SslPolicies scopes.</summary>
        /// <remarks>
        /// The default SslPolicies scopes are:
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
        /// Asynchronously creates a <see cref="SslPoliciesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="SslPoliciesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="SslPoliciesClient"/>.</returns>
        public static stt::Task<SslPoliciesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new SslPoliciesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="SslPoliciesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="SslPoliciesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="SslPoliciesClient"/>.</returns>
        public static SslPoliciesClient Create() => new SslPoliciesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="SslPoliciesClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="SslPoliciesSettings"/>.</param>
        /// <returns>The created <see cref="SslPoliciesClient"/>.</returns>
        internal static SslPoliciesClient Create(grpccore::CallInvoker callInvoker, SslPoliciesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            SslPolicies.SslPoliciesClient grpcClient = new SslPolicies.SslPoliciesClient(callInvoker);
            return new SslPoliciesClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC SslPolicies client</summary>
        public virtual SslPolicies.SslPoliciesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteSslPolicyRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to delete. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string sslPolicy, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(sslPolicy, nameof(sslPolicy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to delete. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string sslPolicy, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(sslPolicy, nameof(sslPolicy)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to delete. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string sslPolicy, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, sslPolicy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SslPolicy Get(GetSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPolicy> GetAsync(GetSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPolicy> GetAsync(GetSslPolicyRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to update. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SslPolicy Get(string project, string sslPolicy, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(sslPolicy, nameof(sslPolicy)),
            }, callSettings);

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to update. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPolicy> GetAsync(string project, string sslPolicy, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(sslPolicy, nameof(sslPolicy)),
            }, callSettings);

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to update. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPolicy> GetAsync(string project, string sslPolicy, st::CancellationToken cancellationToken) =>
            GetAsync(project, sslPolicy, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertSslPolicyRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, SslPolicy sslPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicyResource = gax::GaxPreconditions.CheckNotNull(sslPolicyResource, nameof(sslPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, SslPolicy sslPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicyResource = gax::GaxPreconditions.CheckNotNull(sslPolicyResource, nameof(sslPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, SslPolicy sslPolicyResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, sslPolicyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SslPoliciesList List(ListSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesList> ListAsync(ListSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesList> ListAsync(ListSslPoliciesRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SslPoliciesList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListSslPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListSslPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SslPoliciesListAvailableFeaturesResponse ListAvailableFeatures(ListAvailableFeaturesSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesListAvailableFeaturesResponse> ListAvailableFeaturesAsync(ListAvailableFeaturesSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesListAvailableFeaturesResponse> ListAvailableFeaturesAsync(ListAvailableFeaturesSslPoliciesRequest request, st::CancellationToken cancellationToken) =>
            ListAvailableFeaturesAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual SslPoliciesListAvailableFeaturesResponse ListAvailableFeatures(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAvailableFeatures(new ListAvailableFeaturesSslPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesListAvailableFeaturesResponse> ListAvailableFeaturesAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAvailableFeaturesAsync(new ListAvailableFeaturesSslPoliciesRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<SslPoliciesListAvailableFeaturesResponse> ListAvailableFeaturesAsync(string project, st::CancellationToken cancellationToken) =>
            ListAvailableFeaturesAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchSslPolicyRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to update. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="sslPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string sslPolicy, SslPolicy sslPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(sslPolicy, nameof(sslPolicy)),
                SslPolicyResource = gax::GaxPreconditions.CheckNotNull(sslPolicyResource, nameof(sslPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to update. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="sslPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string sslPolicy, SslPolicy sslPolicyResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchSslPolicyRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SslPolicy = gax::GaxPreconditions.CheckNotNullOrEmpty(sslPolicy, nameof(sslPolicy)),
                SslPolicyResource = gax::GaxPreconditions.CheckNotNull(sslPolicyResource, nameof(sslPolicyResource)),
            }, callSettings);

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="sslPolicy">
        /// Name of the SSL policy to update. The name must be 1-63 characters long, and comply with RFC1035.
        /// </param>
        /// <param name="sslPolicyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string sslPolicy, SslPolicy sslPolicyResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, sslPolicy, sslPolicyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>SslPolicies client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The SslPolicies API.
    /// </remarks>
    public sealed partial class SslPoliciesClientImpl : SslPoliciesClient
    {
        private readonly gaxgrpc::ApiCall<DeleteSslPolicyRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetSslPolicyRequest, SslPolicy> _callGet;

        private readonly gaxgrpc::ApiCall<InsertSslPolicyRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListSslPoliciesRequest, SslPoliciesList> _callList;

        private readonly gaxgrpc::ApiCall<ListAvailableFeaturesSslPoliciesRequest, SslPoliciesListAvailableFeaturesResponse> _callListAvailableFeatures;

        private readonly gaxgrpc::ApiCall<PatchSslPolicyRequest, Operation> _callPatch;

        /// <summary>
        /// Constructs a client wrapper for the SslPolicies service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="SslPoliciesSettings"/> used within this client.</param>
        public SslPoliciesClientImpl(SslPolicies.SslPoliciesClient grpcClient, SslPoliciesSettings settings)
        {
            GrpcClient = grpcClient;
            SslPoliciesSettings effectiveSettings = settings ?? SslPoliciesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteSslPolicyRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("ssl_policy", request => request.SslPolicy);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetSslPolicyRequest, SslPolicy>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("ssl_policy", request => request.SslPolicy);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertSslPolicyRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListSslPoliciesRequest, SslPoliciesList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callListAvailableFeatures = clientHelper.BuildApiCall<ListAvailableFeaturesSslPoliciesRequest, SslPoliciesListAvailableFeaturesResponse>(grpcClient.ListAvailableFeaturesAsync, grpcClient.ListAvailableFeatures, effectiveSettings.ListAvailableFeaturesSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callListAvailableFeatures);
            Modify_ListAvailableFeaturesApiCall(ref _callListAvailableFeatures);
            _callPatch = clientHelper.BuildApiCall<PatchSslPolicyRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("ssl_policy", request => request.SslPolicy);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteSslPolicyRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetSslPolicyRequest, SslPolicy> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertSslPolicyRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListSslPoliciesRequest, SslPoliciesList> call);

        partial void Modify_ListAvailableFeaturesApiCall(ref gaxgrpc::ApiCall<ListAvailableFeaturesSslPoliciesRequest, SslPoliciesListAvailableFeaturesResponse> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchSslPolicyRequest, Operation> call);

        partial void OnConstruction(SslPolicies.SslPoliciesClient grpcClient, SslPoliciesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC SslPolicies client</summary>
        public override SslPolicies.SslPoliciesClient GrpcClient { get; }

        partial void Modify_DeleteSslPolicyRequest(ref DeleteSslPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetSslPolicyRequest(ref GetSslPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertSslPolicyRequest(ref InsertSslPolicyRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListSslPoliciesRequest(ref ListSslPoliciesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListAvailableFeaturesSslPoliciesRequest(ref ListAvailableFeaturesSslPoliciesRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchSslPolicyRequest(ref PatchSslPolicyRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSslPolicyRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified SSL policy. The SSL policy resource can be deleted only if it is not in use by any TargetHttpsProxy or TargetSslProxy resources.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSslPolicyRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SslPolicy Get(GetSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSslPolicyRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all of the ordered rules present in a single specified policy.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SslPolicy> GetAsync(GetSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetSslPolicyRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertSslPolicyRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified SSL policy resource. Gets a list of available SSL policies by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertSslPolicyRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SslPoliciesList List(ListSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListSslPoliciesRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all the SSL policies that have been configured for the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SslPoliciesList> ListAsync(ListSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListSslPoliciesRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override SslPoliciesListAvailableFeaturesResponse ListAvailableFeatures(ListAvailableFeaturesSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListAvailableFeaturesSslPoliciesRequest(ref request, ref callSettings);
            return _callListAvailableFeatures.Sync(request, callSettings);
        }

        /// <summary>
        /// Lists all features that can be specified in the SSL policy when using custom profile.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<SslPoliciesListAvailableFeaturesResponse> ListAvailableFeaturesAsync(ListAvailableFeaturesSslPoliciesRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListAvailableFeaturesSslPoliciesRequest(ref request, ref callSettings);
            return _callListAvailableFeatures.Async(request, callSettings);
        }

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchSslPolicyRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Patches the specified SSL policy with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchSslPolicyRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchSslPolicyRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }
    }
}
