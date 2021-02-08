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
    /// <summary>Settings for <see cref="BackendBucketsClient"/> instances.</summary>
    public sealed partial class BackendBucketsSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="BackendBucketsSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="BackendBucketsSettings"/>.</returns>
        public static BackendBucketsSettings GetDefault() => new BackendBucketsSettings();

        /// <summary>Constructs a new <see cref="BackendBucketsSettings"/> object with default settings.</summary>
        public BackendBucketsSettings()
        {
        }

        private BackendBucketsSettings(BackendBucketsSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            AddSignedUrlKeySettings = existing.AddSignedUrlKeySettings;
            DeleteSettings = existing.DeleteSettings;
            DeleteSignedUrlKeySettings = existing.DeleteSignedUrlKeySettings;
            GetSettings = existing.GetSettings;
            InsertSettings = existing.InsertSettings;
            ListSettings = existing.ListSettings;
            PatchSettings = existing.PatchSettings;
            UpdateSettings = existing.UpdateSettings;
            OnCopy(existing);
        }

        partial void OnCopy(BackendBucketsSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>BackendBucketsClient.AddSignedUrlKey</c> and <c>BackendBucketsClient.AddSignedUrlKeyAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings AddSignedUrlKeySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BackendBucketsClient.Delete</c>
        ///  and <c>BackendBucketsClient.DeleteAsync</c>.
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
        /// <c>BackendBucketsClient.DeleteSignedUrlKey</c> and <c>BackendBucketsClient.DeleteSignedUrlKeyAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeleteSignedUrlKeySettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BackendBucketsClient.Get</c>
        ///  and <c>BackendBucketsClient.GetAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings GetSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BackendBucketsClient.Insert</c>
        ///  and <c>BackendBucketsClient.InsertAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings InsertSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BackendBucketsClient.List</c>
        ///  and <c>BackendBucketsClient.ListAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings ListSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BackendBucketsClient.Patch</c>
        ///  and <c>BackendBucketsClient.PatchAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings PatchSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to <c>BackendBucketsClient.Update</c>
        ///  and <c>BackendBucketsClient.UpdateAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings UpdateSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="BackendBucketsSettings"/> object.</returns>
        public BackendBucketsSettings Clone() => new BackendBucketsSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="BackendBucketsClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class BackendBucketsClientBuilder : gaxgrpc::ClientBuilderBase<BackendBucketsClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public BackendBucketsSettings Settings { get; set; }

        partial void InterceptBuild(ref BackendBucketsClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<BackendBucketsClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override BackendBucketsClient Build()
        {
            BackendBucketsClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<BackendBucketsClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<BackendBucketsClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private BackendBucketsClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return BackendBucketsClient.Create(callInvoker, Settings);
        }

        private async stt::Task<BackendBucketsClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return BackendBucketsClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => BackendBucketsClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => BackendBucketsClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => BackendBucketsClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => ComputeRestAdapter.ComputeAdapter;
    }

    /// <summary>BackendBuckets client wrapper, for convenient use.</summary>
    /// <remarks>
    /// The BackendBuckets API.
    /// </remarks>
    public abstract partial class BackendBucketsClient
    {
        /// <summary>
        /// The default endpoint for the BackendBuckets service, which is a host of "compute.googleapis.com" and a port
        /// of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = "compute.googleapis.com:443";

        /// <summary>The default BackendBuckets scopes.</summary>
        /// <remarks>
        /// The default BackendBuckets scopes are:
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
        /// Asynchronously creates a <see cref="BackendBucketsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="BackendBucketsClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="BackendBucketsClient"/>.</returns>
        public static stt::Task<BackendBucketsClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new BackendBucketsClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="BackendBucketsClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="BackendBucketsClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="BackendBucketsClient"/>.</returns>
        public static BackendBucketsClient Create() => new BackendBucketsClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="BackendBucketsClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="BackendBucketsSettings"/>.</param>
        /// <returns>The created <see cref="BackendBucketsClient"/>.</returns>
        internal static BackendBucketsClient Create(grpccore::CallInvoker callInvoker, BackendBucketsSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            BackendBuckets.BackendBucketsClient grpcClient = new BackendBuckets.BackendBucketsClient(callInvoker);
            return new BackendBucketsClientImpl(grpcClient, settings);
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

        /// <summary>The underlying gRPC BackendBuckets client</summary>
        public virtual BackendBuckets.BackendBucketsClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddSignedUrlKey(AddSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddSignedUrlKeyAsync(AddSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddSignedUrlKeyAsync(AddSignedUrlKeyBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            AddSignedUrlKeyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to which the Signed URL Key should be added. The name should conform to RFC1035.
        /// </param>
        /// <param name="signedUrlKeyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation AddSignedUrlKey(string project, string backendBucket, SignedUrlKey signedUrlKeyResource, gaxgrpc::CallSettings callSettings = null) =>
            AddSignedUrlKey(new AddSignedUrlKeyBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SignedUrlKeyResource = gax::GaxPreconditions.CheckNotNull(signedUrlKeyResource, nameof(signedUrlKeyResource)),
            }, callSettings);

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to which the Signed URL Key should be added. The name should conform to RFC1035.
        /// </param>
        /// <param name="signedUrlKeyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddSignedUrlKeyAsync(string project, string backendBucket, SignedUrlKey signedUrlKeyResource, gaxgrpc::CallSettings callSettings = null) =>
            AddSignedUrlKeyAsync(new AddSignedUrlKeyBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
                SignedUrlKeyResource = gax::GaxPreconditions.CheckNotNull(signedUrlKeyResource, nameof(signedUrlKeyResource)),
            }, callSettings);

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to which the Signed URL Key should be added. The name should conform to RFC1035.
        /// </param>
        /// <param name="signedUrlKeyResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> AddSignedUrlKeyAsync(string project, string backendBucket, SignedUrlKey signedUrlKeyResource, st::CancellationToken cancellationToken) =>
            AddSignedUrlKeyAsync(project, backendBucket, signedUrlKeyResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(DeleteBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(DeleteBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            DeleteAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Delete(string project, string backendBucket, gaxgrpc::CallSettings callSettings = null) =>
            Delete(new DeleteBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string backendBucket, gaxgrpc::CallSettings callSettings = null) =>
            DeleteAsync(new DeleteBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteAsync(string project, string backendBucket, st::CancellationToken cancellationToken) =>
            DeleteAsync(project, backendBucket, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteSignedUrlKey(DeleteSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteSignedUrlKeyAsync(DeleteSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteSignedUrlKeyAsync(DeleteSignedUrlKeyBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            DeleteSignedUrlKeyAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to which the Signed URL Key should be added. The name should conform to RFC1035.
        /// </param>
        /// <param name="keyName">
        /// The name of the Signed URL Key to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation DeleteSignedUrlKey(string project, string backendBucket, string keyName, gaxgrpc::CallSettings callSettings = null) =>
            DeleteSignedUrlKey(new DeleteSignedUrlKeyBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                KeyName = gax::GaxPreconditions.CheckNotNullOrEmpty(keyName, nameof(keyName)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to which the Signed URL Key should be added. The name should conform to RFC1035.
        /// </param>
        /// <param name="keyName">
        /// The name of the Signed URL Key to delete.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteSignedUrlKeyAsync(string project, string backendBucket, string keyName, gaxgrpc::CallSettings callSettings = null) =>
            DeleteSignedUrlKeyAsync(new DeleteSignedUrlKeyBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                KeyName = gax::GaxPreconditions.CheckNotNullOrEmpty(keyName, nameof(keyName)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to which the Signed URL Key should be added. The name should conform to RFC1035.
        /// </param>
        /// <param name="keyName">
        /// The name of the Signed URL Key to delete.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> DeleteSignedUrlKeyAsync(string project, string backendBucket, string keyName, st::CancellationToken cancellationToken) =>
            DeleteSignedUrlKeyAsync(project, backendBucket, keyName, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendBucket Get(GetBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucket> GetAsync(GetBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucket> GetAsync(GetBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            GetAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendBucket Get(string project, string backendBucket, gaxgrpc::CallSettings callSettings = null) =>
            Get(new GetBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to return.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucket> GetAsync(string project, string backendBucket, gaxgrpc::CallSettings callSettings = null) =>
            GetAsync(new GetBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to return.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucket> GetAsync(string project, string backendBucket, st::CancellationToken cancellationToken) =>
            GetAsync(project, backendBucket, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(InsertBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(InsertBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            InsertAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Insert(string project, BackendBucket backendBucketResource, gaxgrpc::CallSettings callSettings = null) =>
            Insert(new InsertBackendBucketRequest
            {
                BackendBucketResource = gax::GaxPreconditions.CheckNotNull(backendBucketResource, nameof(backendBucketResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, BackendBucket backendBucketResource, gaxgrpc::CallSettings callSettings = null) =>
            InsertAsync(new InsertBackendBucketRequest
            {
                BackendBucketResource = gax::GaxPreconditions.CheckNotNull(backendBucketResource, nameof(backendBucketResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> InsertAsync(string project, BackendBucket backendBucketResource, st::CancellationToken cancellationToken) =>
            InsertAsync(project, backendBucketResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendBucketList List(ListBackendBucketsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucketList> ListAsync(ListBackendBucketsRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucketList> ListAsync(ListBackendBucketsRequest request, st::CancellationToken cancellationToken) =>
            ListAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual BackendBucketList List(string project, gaxgrpc::CallSettings callSettings = null) =>
            List(new ListBackendBucketsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucketList> ListAsync(string project, gaxgrpc::CallSettings callSettings = null) =>
            ListAsync(new ListBackendBucketsRequest
            {
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<BackendBucketList> ListAsync(string project, st::CancellationToken cancellationToken) =>
            ListAsync(project, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(PatchBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(PatchBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            PatchAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to patch.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Patch(string project, string backendBucket, BackendBucket backendBucketResource, gaxgrpc::CallSettings callSettings = null) =>
            Patch(new PatchBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                BackendBucketResource = gax::GaxPreconditions.CheckNotNull(backendBucketResource, nameof(backendBucketResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to patch.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string backendBucket, BackendBucket backendBucketResource, gaxgrpc::CallSettings callSettings = null) =>
            PatchAsync(new PatchBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                BackendBucketResource = gax::GaxPreconditions.CheckNotNull(backendBucketResource, nameof(backendBucketResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to patch.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> PatchAsync(string project, string backendBucket, BackendBucket backendBucketResource, st::CancellationToken cancellationToken) =>
            PatchAsync(project, backendBucket, backendBucketResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(UpdateBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(UpdateBackendBucketRequest request, st::CancellationToken cancellationToken) =>
            UpdateAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to update.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Operation Update(string project, string backendBucket, BackendBucket backendBucketResource, gaxgrpc::CallSettings callSettings = null) =>
            Update(new UpdateBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                BackendBucketResource = gax::GaxPreconditions.CheckNotNull(backendBucketResource, nameof(backendBucketResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to update.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string backendBucket, BackendBucket backendBucketResource, gaxgrpc::CallSettings callSettings = null) =>
            UpdateAsync(new UpdateBackendBucketRequest
            {
                BackendBucket = gax::GaxPreconditions.CheckNotNullOrEmpty(backendBucket, nameof(backendBucket)),
                BackendBucketResource = gax::GaxPreconditions.CheckNotNull(backendBucketResource, nameof(backendBucketResource)),
                Project = gax::GaxPreconditions.CheckNotNullOrEmpty(project, nameof(project)),
            }, callSettings);

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="project">
        /// Project ID for this request.
        /// </param>
        /// <param name="backendBucket">
        /// Name of the BackendBucket resource to update.
        /// </param>
        /// <param name="backendBucketResource">
        /// The body resource for this request
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Operation> UpdateAsync(string project, string backendBucket, BackendBucket backendBucketResource, st::CancellationToken cancellationToken) =>
            UpdateAsync(project, backendBucket, backendBucketResource, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>BackendBuckets client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// The BackendBuckets API.
    /// </remarks>
    public sealed partial class BackendBucketsClientImpl : BackendBucketsClient
    {
        private readonly gaxgrpc::ApiCall<AddSignedUrlKeyBackendBucketRequest, Operation> _callAddSignedUrlKey;

        private readonly gaxgrpc::ApiCall<DeleteBackendBucketRequest, Operation> _callDelete;

        private readonly gaxgrpc::ApiCall<DeleteSignedUrlKeyBackendBucketRequest, Operation> _callDeleteSignedUrlKey;

        private readonly gaxgrpc::ApiCall<GetBackendBucketRequest, BackendBucket> _callGet;

        private readonly gaxgrpc::ApiCall<InsertBackendBucketRequest, Operation> _callInsert;

        private readonly gaxgrpc::ApiCall<ListBackendBucketsRequest, BackendBucketList> _callList;

        private readonly gaxgrpc::ApiCall<PatchBackendBucketRequest, Operation> _callPatch;

        private readonly gaxgrpc::ApiCall<UpdateBackendBucketRequest, Operation> _callUpdate;

        /// <summary>
        /// Constructs a client wrapper for the BackendBuckets service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="BackendBucketsSettings"/> used within this client.</param>
        public BackendBucketsClientImpl(BackendBuckets.BackendBucketsClient grpcClient, BackendBucketsSettings settings)
        {
            GrpcClient = grpcClient;
            BackendBucketsSettings effectiveSettings = settings ?? BackendBucketsSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callAddSignedUrlKey = clientHelper.BuildApiCall<AddSignedUrlKeyBackendBucketRequest, Operation>(grpcClient.AddSignedUrlKeyAsync, grpcClient.AddSignedUrlKey, effectiveSettings.AddSignedUrlKeySettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("backend_bucket", request => request.BackendBucket);
            Modify_ApiCall(ref _callAddSignedUrlKey);
            Modify_AddSignedUrlKeyApiCall(ref _callAddSignedUrlKey);
            _callDelete = clientHelper.BuildApiCall<DeleteBackendBucketRequest, Operation>(grpcClient.DeleteAsync, grpcClient.Delete, effectiveSettings.DeleteSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("backend_bucket", request => request.BackendBucket);
            Modify_ApiCall(ref _callDelete);
            Modify_DeleteApiCall(ref _callDelete);
            _callDeleteSignedUrlKey = clientHelper.BuildApiCall<DeleteSignedUrlKeyBackendBucketRequest, Operation>(grpcClient.DeleteSignedUrlKeyAsync, grpcClient.DeleteSignedUrlKey, effectiveSettings.DeleteSignedUrlKeySettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("backend_bucket", request => request.BackendBucket);
            Modify_ApiCall(ref _callDeleteSignedUrlKey);
            Modify_DeleteSignedUrlKeyApiCall(ref _callDeleteSignedUrlKey);
            _callGet = clientHelper.BuildApiCall<GetBackendBucketRequest, BackendBucket>(grpcClient.GetAsync, grpcClient.Get, effectiveSettings.GetSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("backend_bucket", request => request.BackendBucket);
            Modify_ApiCall(ref _callGet);
            Modify_GetApiCall(ref _callGet);
            _callInsert = clientHelper.BuildApiCall<InsertBackendBucketRequest, Operation>(grpcClient.InsertAsync, grpcClient.Insert, effectiveSettings.InsertSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callInsert);
            Modify_InsertApiCall(ref _callInsert);
            _callList = clientHelper.BuildApiCall<ListBackendBucketsRequest, BackendBucketList>(grpcClient.ListAsync, grpcClient.List, effectiveSettings.ListSettings).WithGoogleRequestParam("project", request => request.Project);
            Modify_ApiCall(ref _callList);
            Modify_ListApiCall(ref _callList);
            _callPatch = clientHelper.BuildApiCall<PatchBackendBucketRequest, Operation>(grpcClient.PatchAsync, grpcClient.Patch, effectiveSettings.PatchSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("backend_bucket", request => request.BackendBucket);
            Modify_ApiCall(ref _callPatch);
            Modify_PatchApiCall(ref _callPatch);
            _callUpdate = clientHelper.BuildApiCall<UpdateBackendBucketRequest, Operation>(grpcClient.UpdateAsync, grpcClient.Update, effectiveSettings.UpdateSettings).WithGoogleRequestParam("project", request => request.Project).WithGoogleRequestParam("backend_bucket", request => request.BackendBucket);
            Modify_ApiCall(ref _callUpdate);
            Modify_UpdateApiCall(ref _callUpdate);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_AddSignedUrlKeyApiCall(ref gaxgrpc::ApiCall<AddSignedUrlKeyBackendBucketRequest, Operation> call);

        partial void Modify_DeleteApiCall(ref gaxgrpc::ApiCall<DeleteBackendBucketRequest, Operation> call);

        partial void Modify_DeleteSignedUrlKeyApiCall(ref gaxgrpc::ApiCall<DeleteSignedUrlKeyBackendBucketRequest, Operation> call);

        partial void Modify_GetApiCall(ref gaxgrpc::ApiCall<GetBackendBucketRequest, BackendBucket> call);

        partial void Modify_InsertApiCall(ref gaxgrpc::ApiCall<InsertBackendBucketRequest, Operation> call);

        partial void Modify_ListApiCall(ref gaxgrpc::ApiCall<ListBackendBucketsRequest, BackendBucketList> call);

        partial void Modify_PatchApiCall(ref gaxgrpc::ApiCall<PatchBackendBucketRequest, Operation> call);

        partial void Modify_UpdateApiCall(ref gaxgrpc::ApiCall<UpdateBackendBucketRequest, Operation> call);

        partial void OnConstruction(BackendBuckets.BackendBucketsClient grpcClient, BackendBucketsSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC BackendBuckets client</summary>
        public override BackendBuckets.BackendBucketsClient GrpcClient { get; }

        partial void Modify_AddSignedUrlKeyBackendBucketRequest(ref AddSignedUrlKeyBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteBackendBucketRequest(ref DeleteBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeleteSignedUrlKeyBackendBucketRequest(ref DeleteSignedUrlKeyBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_GetBackendBucketRequest(ref GetBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_InsertBackendBucketRequest(ref InsertBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_ListBackendBucketsRequest(ref ListBackendBucketsRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_PatchBackendBucketRequest(ref PatchBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        partial void Modify_UpdateBackendBucketRequest(ref UpdateBackendBucketRequest request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation AddSignedUrlKey(AddSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddSignedUrlKeyBackendBucketRequest(ref request, ref callSettings);
            return _callAddSignedUrlKey.Sync(request, callSettings);
        }

        /// <summary>
        /// Adds a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> AddSignedUrlKeyAsync(AddSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_AddSignedUrlKeyBackendBucketRequest(ref request, ref callSettings);
            return _callAddSignedUrlKey.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Delete(DeleteBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteBackendBucketRequest(ref request, ref callSettings);
            return _callDelete.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes the specified BackendBucket resource.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteAsync(DeleteBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteBackendBucketRequest(ref request, ref callSettings);
            return _callDelete.Async(request, callSettings);
        }

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation DeleteSignedUrlKey(DeleteSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSignedUrlKeyBackendBucketRequest(ref request, ref callSettings);
            return _callDeleteSignedUrlKey.Sync(request, callSettings);
        }

        /// <summary>
        /// Deletes a key for validating requests with signed URLs for this backend bucket.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> DeleteSignedUrlKeyAsync(DeleteSignedUrlKeyBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeleteSignedUrlKeyBackendBucketRequest(ref request, ref callSettings);
            return _callDeleteSignedUrlKey.Async(request, callSettings);
        }

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override BackendBucket Get(GetBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetBackendBucketRequest(ref request, ref callSettings);
            return _callGet.Sync(request, callSettings);
        }

        /// <summary>
        /// Returns the specified BackendBucket resource. Gets a list of available backend buckets by making a list() request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<BackendBucket> GetAsync(GetBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_GetBackendBucketRequest(ref request, ref callSettings);
            return _callGet.Async(request, callSettings);
        }

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Insert(InsertBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertBackendBucketRequest(ref request, ref callSettings);
            return _callInsert.Sync(request, callSettings);
        }

        /// <summary>
        /// Creates a BackendBucket resource in the specified project using the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> InsertAsync(InsertBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_InsertBackendBucketRequest(ref request, ref callSettings);
            return _callInsert.Async(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override BackendBucketList List(ListBackendBucketsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListBackendBucketsRequest(ref request, ref callSettings);
            return _callList.Sync(request, callSettings);
        }

        /// <summary>
        /// Retrieves the list of BackendBucket resources available to the specified project.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<BackendBucketList> ListAsync(ListBackendBucketsRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_ListBackendBucketsRequest(ref request, ref callSettings);
            return _callList.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Patch(PatchBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchBackendBucketRequest(ref request, ref callSettings);
            return _callPatch.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request. This method supports PATCH semantics and uses the JSON merge patch format and processing rules.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> PatchAsync(PatchBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_PatchBackendBucketRequest(ref request, ref callSettings);
            return _callPatch.Async(request, callSettings);
        }

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Operation Update(UpdateBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateBackendBucketRequest(ref request, ref callSettings);
            return _callUpdate.Sync(request, callSettings);
        }

        /// <summary>
        /// Updates the specified BackendBucket resource with the data included in the request.
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Operation> UpdateAsync(UpdateBackendBucketRequest request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_UpdateBackendBucketRequest(ref request, ref callSettings);
            return _callUpdate.Async(request, callSettings);
        }
    }
}
