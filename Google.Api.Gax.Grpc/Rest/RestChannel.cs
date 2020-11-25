/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Grpc.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest
{
    /// <summary>
    /// gRPC "channel" that really uses REST/JSON over HTTP to make RPCs.
    /// The channel is aware of which APIs it supports, so that it's able to perform the
    /// appropriate request translation.
    /// </summary>
    internal sealed class RestChannel : ChannelBase
    {
        private readonly AsyncAuthInterceptor _channelAuthInterceptor;
        private readonly HttpClient _httpClient;
        private readonly RestServiceCollection _serviceCollection;
        private readonly CallInvoker _callInvoker;

        public RestChannel(RestServiceCollection serviceCollection, string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) : base(endpoint)
        {
            _serviceCollection = serviceCollection;

            // Reuse a single CallInvoker however many times CreateCallInvoker is called.
            _callInvoker = new RestCallInvoker(this);
            // TODO: Handle endpoints better...

            // TODO: Avoid creating an HTTP Client for every channel?
            _httpClient = new HttpClient { BaseAddress = new Uri($"https://{endpoint}") };
            _channelAuthInterceptor = credentials.ToAsyncAuthInterceptor();

            // TODO: Use options where appropriate.
        }

        public override CallInvoker CreateCallInvoker() => _callInvoker;

        /// <summary>
        /// Equivalent to <see cref="CallInvoker.AsyncUnaryCall{TRequest, TResponse}(Method{TRequest, TResponse}, string, CallOptions, TRequest)"/>.
        /// </summary>
        internal AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            var restMethod = _serviceCollection.GetRestMethod(method);

            var cancellationTokenSource = new CancellationTokenSource();
            var httpResponseTask = SendAsync(restMethod, host, options, request, cancellationTokenSource.Token);

            // TODO: Cancellation?
            var responseTask = restMethod.ReadResponseAsync<TResponse>(httpResponseTask);
            var responseHeadersTask = ReadHeadersAsync(httpResponseTask);
            Func<Status> statusFunc = () => GetStatus(httpResponseTask);
            Func<Metadata> trailersFunc = () => GetTrailers(httpResponseTask);
            return new AsyncUnaryCall<TResponse>(responseTask, responseHeadersTask, statusFunc, trailersFunc, cancellationTokenSource.Cancel);
        }

        private async Task<HttpResponseMessage> SendAsync<TRequest>(RestMethod restMethod, string host, CallOptions options, TRequest request, CancellationToken cancellationToken)
        {
            // TODO: Add headers from options.Headers, but intercept the x-goog-api-client header.
            // Ideally, add the header in the client builder instead of in the ServiceSettingsBase...
            // TODO: Use options. How do we set the timeout for an individual HTTP request? We probably need to create a linked cancellation token.
            var httpRequest = restMethod.CreateRequest((IMessage) request, host);
            // TODO: How do we cancel this?
            await AddAuthHeadersAsync(httpRequest, restMethod).ConfigureAwait(false);

            var task = _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseContentRead, cancellationToken);
            return await task.ConfigureAwait(false);
        }

        private async Task AddAuthHeadersAsync(HttpRequestMessage request, RestMethod method)
        {
            Uri hostUri = request.RequestUri.IsAbsoluteUri ? request.RequestUri : _httpClient.BaseAddress;
            string schemeAndAuthority = hostUri.GetLeftPart(UriPartial.Authority);

            var metadata = new Metadata();
            var context = new AuthInterceptorContext(schemeAndAuthority, method.FullName);
            await _channelAuthInterceptor(context, metadata).ConfigureAwait(false);
            foreach (var entry in metadata)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }
        }

        private async Task<Metadata> ReadHeadersAsync(Task<HttpResponseMessage> httpResponseTask)
        {
            var httpResponse = await httpResponseTask.ConfigureAwait(false);
            // TODO: This could be very wrong. I don't know what headers we should really return, and I don't know about semi-colon joining.
            var metadata = new Metadata();
            foreach (var header in httpResponse.Headers)
            {
                metadata.Add(header.Key, string.Join(";", header.Value));
            }
            return metadata;
        }

        internal static Status GetStatus(Task<HttpResponseMessage> httpResponseTask) => httpResponseTask.Status switch
        {
            TaskStatus.RanToCompletion => GetStatus(httpResponseTask.Result),
            TaskStatus.Faulted => new Status(StatusCode.Unknown, "HTTP task faulted", httpResponseTask.Exception.InnerException),
            TaskStatus.Canceled => new Status(StatusCode.Cancelled, "Request cancelled"),
            _ => throw new InvalidOperationException("Cannot call GetStatus with an incomplete HTTP call")
        };

        // TODO: What about error details? Are they still available?
        internal static Status GetStatus(HttpResponseMessage response) =>
            new Status(ConvertHttpToGrpcStatusCode(response.StatusCode), "");

        private static StatusCode ConvertHttpToGrpcStatusCode(HttpStatusCode httpStatusCode) => httpStatusCode switch
        {
            HttpStatusCode.OK => StatusCode.OK,
            HttpStatusCode.Unauthorized => StatusCode.Unauthenticated,
            HttpStatusCode.Forbidden => StatusCode.PermissionDenied,
            HttpStatusCode.BadRequest => StatusCode.InvalidArgument,
            HttpStatusCode.InternalServerError => StatusCode.Internal,
            HttpStatusCode.NotFound => StatusCode.NotFound,
            HttpStatusCode.Conflict => StatusCode.FailedPrecondition,
            // TODO: Others!
            _ => StatusCode.Unknown
        };

        private Metadata GetTrailers(Task<HttpResponseMessage> httpResponseTask)
        {
            if (!httpResponseTask.IsCompleted)
            {
                throw new InvalidOperationException("Cannot call GetTrailers with an incomplete HTTP call");
            }
            // We never have any trailers.
            return new Metadata();
        }
    }
}
