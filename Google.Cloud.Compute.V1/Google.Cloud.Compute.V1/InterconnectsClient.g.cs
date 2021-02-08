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
    /// <summary>Settings for <see cref="InterconnectsClient"/> instances.</summary>
    public sealed partial class InterconnectsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="InterconnectsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="InterconnectsSettings"/>.</returns>
        public static InterconnectsSettings GetDefault() => new InterconnectsSettings();

        /// <summary>Constructs a new <see cref="InterconnectsSettings"/> object with default settings.</summary>
        public InterconnectsSettings()
        {
        }

        private InterconnectsSettings(InterconnectsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            DeleteSettings = existing.DeleteSettings;
            GetSettings = existing.GetSettings;
            GetDiagnosticsSettings = existing.GetDiagnosticsSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            OnCopy(existing);
        }

        partial void OnCopy(InterconnectsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InterconnectsClient.Delete</c>
        ///  and <c>InterconnectsClient.DeleteAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InterconnectsClient.Get</c>
        /// and <c>InterconnectsClient.GetAsync</c>.
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
        /// <c>InterconnectsClient.GetDiagnostics</c> and <c>InterconnectsClient.GetDiagnosticsAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetDiagnosticsSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InterconnectsClient.Insert</c>
        ///  and <c>InterconnectsClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InterconnectsClient.List</c>
        ///  and <c>InterconnectsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>InterconnectsClient.Patch</c>
        ///  and <c>InterconnectsClient.PatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="InterconnectsSettings"/> object.</returns>
        public InterconnectsSettings Clone() => new InterconnectsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="InterconnectsClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class InterconnectsClientBuilder : gaxgrpc::ClientBuilderBase<InterconnectsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public InterconnectsSettings Settings { get; set; }

        partial void InterceptBuild(ref InterconnectsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<InterconnectsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override InterconnectsClient Build()
        {
            InterconnectsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<InterconnectsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<InterconnectsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private InterconnectsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return InterconnectsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<InterconnectsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return InterconnectsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => InterconnectsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => InterconnectsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => InterconnectsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>Interconnects client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The Interconnects API.
    /// </remarks>
    public abstract partial class InterconnectsClient
    {
        /// <summary>
        /// The default endpoint for the Interconnects service, which is a host of "compute.googleapis.com" and a port
        /// of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default Interconnects scopes.</summary>
        /// <remarks>
        /// The default Interconnects scopes are:
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
        /// Asynchronously creates a <see cref="InterconnectsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="InterconnectsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="InterconnectsClient"/>.</returns>
        public static stt::Task<InterconnectsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new InterconnectsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="InterconnectsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="InterconnectsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="InterconnectsClient"/>.</returns>
        public static InterconnectsClient Create() => new InterconnectsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="InterconnectsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="InterconnectsSettings"/>.</param>
        /// <returns>The created <see cref="InterconnectsClient"/>.</returns>
        internal static InterconnectsClient Create(grpccore::CallInvoker callInvoker, InterconnectsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            Interconnects.InterconnectsClient grpcClient = new Interconnects.InterconnectsClient(callInvoker);
            return new InterconnectsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC Interconnects client</summary>
        public virtual Interconnects.InterconnectsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteInterconnectRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string interconnect, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string interconnect, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string interconnect, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, interconnect, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Interconnect Get(GetInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Interconnect> GetAsync(GetInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Interconnect> GetAsync(GetInterconnectRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Interconnect Get(string project, string interconnect, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Interconnect> GetAsync(string project, string interconnect, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Interconnect> GetAsync(string project, string interconnect, st::CancellationToken cancellationToken) =>
            GetAsync(project, interconnect, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectsGetDiagnosticsResponse GetDiagnostics(GetDiagnosticsInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectsGetDiagnosticsResponse> GetDiagnosticsAsync(GetDiagnosticsInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectsGetDiagnosticsResponse> GetDiagnosticsAsync(GetDiagnosticsInterconnectRequest request, st::CancellationToken cancellationToken) =>
            GetDiagnosticsAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect resource to query.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectsGetDiagnosticsResponse GetDiagnostics(string project, string interconnect, gaxgrpc::CallSettings callSettings = null) =>
            GetDiagnostics(new GetDiagnosticsInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect resource to query.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectsGetDiagnosticsResponse> GetDiagnosticsAsync(string project, string interconnect, gaxgrpc::CallSettings callSettings = null) =>
            GetDiagnosticsAsync(new GetDiagnosticsInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect resource to query.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectsGetDiagnosticsResponse> GetDiagnosticsAsync(string project, string interconnect, st::CancellationToken cancellationToken) =>
            GetDiagnosticsAsync(project, interconnect, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertInterconnectRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnectResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, Interconnect interconnectResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertInterconnectRequest
            {
                InterconnectResource = gax::GaxPreconditions.CheckNotNull(interconnectResource, nameof(interconnectResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnectResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, Interconnect interconnectResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertInterconnectRequest
            {
                InterconnectResource = gax::GaxPreconditions.CheckNotNull(interconnectResource, nameof(interconnectResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnectResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, Interconnect interconnectResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, interconnectResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectList List(ListInterconnectsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectList> ListAsync(ListInterconnectsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectList> ListAsync(ListInterconnectsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual InterconnectList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListInterconnectsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListInterconnectsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<InterconnectList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchInterconnectRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchInterconnectRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to update.
        /// </param>
        /// <param name="interconnectResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string interconnect, Interconnect interconnectResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                InterconnectResource = gax::GaxPreconditions.CheckNotNull(interconnectResource, nameof(interconnectResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to update.
        /// </param>
        /// <param name="interconnectResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string interconnect, Interconnect interconnectResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchInterconnectRequest
            {
                Interconnect = gax::GaxPreconditions.CheckNotNullOrEmpty(interconnect, nameof(interconnect)),
                InterconnectResource = gax::GaxPreconditions.CheckNotNull(interconnectResource, nameof(interconnectResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="interconnect">
        /// Name of the interconnect to update.
        /// </param>
        /// <param name="interconnectResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string interconnect, Interconnect interconnectResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, interconnect, interconnectResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>Interconnects client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The Interconnects API.
    /// </remarks>
    public sealed partial class InterconnectsClientImpl : InterconnectsClient
    {
        private readonly gaxgrpc::ApiCall<DeleteInterconnectRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<GetInterconnectRequest, Interconnect> _callGet;

        private readonly gaxgrpc::ApiCall<GetDiagnosticsInterconnectRequest, InterconnectsGetDiagnosticsResponse> _callGetDiagnostics;

        private readonly gaxgrpc::ApiCall<InsertInterconnectRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListInterconnectsRequest, InterconnectList> _callList;

        private readonly gaxgrpc::ApiCall<PatchInterconnectRequest, Operation> _callPatch;

        /// <summary>
        /// Constructs a client wrapper for the Interconnects service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="InterconnectsSettings"/> used within this client.</param>
        public InterconnectsClientImpl(Interconnects.InterconnectsClient grpcClient, InterconnectsSettings settings)
        {
            GrpcClient = grpcClient;
            InterconnectsSettings effectiveSettings = settings ?? InterconnectsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callDelete = clientHelper.BuildApiCall<DeleteInterconnectRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("interconnect", request => request.Interconnect);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callGet = clientHelper.BuildApiCall<GetInterconnectRequest, Interconnect>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("interconnect", request => request.Interconnect);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callGetDiagnostics = clientHelper.BuildApiCall<GetDiagnosticsInterconnectRequest, InterconnectsGetDiagnosticsResponse>(grpcClient.GetDiagnosticsAsync, grpcClient.GetDiagnostics, effectiveSettings.GetDiagnosticsSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("interconnect", request => request.Interconnect);
            Modify_ApiCall(ref _callGetDiagnostics);
            Modify_GetDiagnosticsApiCall(ref _callGetDiagnostics);
            _callInsert = clientHelper.BuildApiCall<InsertInterconnectRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListInterconnectsRequest, InterconnectList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchInterconnectRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("interconnect", request => request.Interconnect);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteInterconnectRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetInterconnectRequest, Interconnect> call);

        partial void Modify_GetDiagnosticsApiCall(ref gaxgrpc::ApiCall<GetDiagnosticsInterconnectRequest, InterconnectsGetDiagnosticsResponse> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertInterconnectRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListInterconnectsRequest, InterconnectList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchInterconnectRequest, Operation> call);

        partial void OnConstruction(Interconnects.InterconnectsClient grpcClient, InterconnectsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC Interconnects client</summary>
        public override Interconnects.InterconnectsClient GrpcClient { get; }

        partial void Modify_DeleteInterconnectRequest(ref DeleteInterconnectRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetInterconnectRequest(ref GetInterconnectRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetDiagnosticsInterconnectRequest(ref GetDiagnosticsInterconnectRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertInterconnectRequest(ref InsertInterconnectRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListInterconnectsRequest(ref ListInterconnectsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchInterconnectRequest(ref PatchInterconnectRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInterconnectRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteInterconnectRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Interconnect Get(GetInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInterconnectRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified interconnect. Get a list of available interconnects by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Interconnect> GetAsync(GetInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetInterconnectRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InterconnectsGetDiagnosticsResponse GetDiagnostics(GetDiagnosticsInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetDiagnosticsInterconnectRequest(ref request, ref callSettings);
            return _callGetDiagnostics.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the interconnectDiagnostics for the specified interconnect.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InterconnectsGetDiagnosticsResponse> GetDiagnosticsAsync(GetDiagnosticsInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetDiagnosticsInterconnectRequest(ref request, ref callSettings);
            return _callGetDiagnostics.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertInterconnectRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a Interconnect in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertInterconnectRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override InterconnectList List(ListInterconnectsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInterconnectsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of interconnect available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<InterconnectList> ListAsync(ListInterconnectsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListInterconnectsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchInterconnectRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified interconnect with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchInterconnectRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchInterconnectRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }
    }
}
