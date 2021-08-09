/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Grpc.Core;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.ExceptionServices;
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
        private static readonly string RestVersion = new VersionHeaderBuilder()
            .AppendDotNetEnvironment()
            .AppendAssemblyVersion("gapic", typeof(RestChannel))
            .AppendAssemblyVersion("gax", typeof(CallSettings))
            .AppendAssemblyVersion("rest", typeof(HttpClient))
            .ToString();

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

        private async Task<ReadHttpResponseMessage> SendAsync<TRequest>(RestMethod restMethod, string host, CallOptions options, TRequest request, CancellationToken cancellationToken)
        {
            // Ideally, add the header in the client builder instead of in the ServiceSettingsBase...
            // TODO: Use options. How do we set the timeout for an individual HTTP request? We probably need to create a linked cancellation token.
            var httpRequest = restMethod.CreateRequest((IMessage) request, host);
            foreach (var headerKeyValue in options.Headers
                .Where(mh => !mh.IsBinary)
                .Where(mh=> mh.Key != VersionHeaderBuilder.HeaderName))
            {
                httpRequest.Headers.Add(headerKeyValue.Key, headerKeyValue.Value);
            }
            httpRequest.Headers.Add(VersionHeaderBuilder.HeaderName, RestVersion);

            // TODO: How do we cancel this?
            await AddAuthHeadersAsync(httpRequest, restMethod).ConfigureAwait(false);

            var httpResponseMessage = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);

            try
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new ReadHttpResponseMessage(httpResponseMessage, content);
            }
            catch (Exception ex)
            {
                // Let's defer the throwing of this exception to when it's actually needed,
                // so that we can at least read headers and other metadata.
                var exInfo = ExceptionDispatchInfo.Capture(ex);
                return new ReadHttpResponseMessage(httpResponseMessage, exInfo);
            }
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

        private async Task<Metadata> ReadHeadersAsync(Task<ReadHttpResponseMessage> httpResponseTask) =>
            (await httpResponseTask.ConfigureAwait(false)).GetHeaders();

        private static Status GetStatus(Task<ReadHttpResponseMessage> httpResponseTask) => httpResponseTask.Status switch
        {
            TaskStatus.RanToCompletion => httpResponseTask.Result.GetStatus(),
            TaskStatus.Faulted => new Status(StatusCode.Unknown, "HTTP task faulted", httpResponseTask.Exception.InnerException),
            TaskStatus.Canceled => new Status(StatusCode.Cancelled, "Request cancelled"),
            _ => throw new InvalidOperationException("Cannot call GetStatus with an incomplete HTTP call")
        };

        private Metadata GetTrailers(Task<ReadHttpResponseMessage> httpResponseTask)
        {
            if (!httpResponseTask.IsCompleted)
            {
                throw new InvalidOperationException("Cannot call GetTrailers with an incomplete HTTP call");
            }
            return httpResponseTask.Result.GetTrailers();
        }

        /// <summary>
        /// In <see cref="AsyncUnaryCall{TResponse}"/> the functions to obtain the TResponse
        /// and the <see cref="Status"/> of the call are two different functions.
        /// The function to obtain the response is async, but the function to obtain the
        /// <see cref="Status"/> is not.
        /// For being able to surface error details in <see cref="Status"/> we need to be
        /// able to call <see cref="HttpContent.ReadAsStringAsync"/> which is an async method,
        /// and thus cannot be done, without blocking, on the sync function that obtains the 
        /// <see cref="Status"/> in the <see cref="AsyncUnaryCall{TResponse}"/>.
        /// So we need to make async content reading part of sending the call and not part of
        /// building the TResponse.
        /// This class is just a convenient wrapper for passing together the <see cref="HttpResponseMessage"/>
        /// and its read response.
        /// </summary>
        internal class ReadHttpResponseMessage
        {
            private HttpResponseMessage OriginalResponseMessage { get; }

            private readonly string _content;
            private readonly ExceptionDispatchInfo _readException;

            internal string Content
            {
                get
                {
                    _readException?.Throw();
                    return _content;
                }
            }

            internal ReadHttpResponseMessage(HttpResponseMessage response, string content) =>
                (OriginalResponseMessage, _content) = (response, content);

            internal ReadHttpResponseMessage(HttpResponseMessage response, ExceptionDispatchInfo readException) =>
                (OriginalResponseMessage, _readException) = (response, readException);

            internal Metadata GetHeaders()
            {
                // TODO: This could be very wrong. I don't know what headers we should really return, and I don't know about semi-colon joining.
                var metadata = new Metadata();
                foreach (var header in OriginalResponseMessage.Headers)
                {
                    metadata.Add(header.Key, string.Join(";", header.Value));
                }
                return metadata;
            }

            internal Status GetStatus()
            {
                var httpStatus = (int) OriginalResponseMessage.StatusCode;
                var grpcStatus = (httpStatus / 100) switch
                {
                    // All 2xx responses map to OK
                    2 => StatusCode.OK,

                    // 4xx defaults to FailedPrecondition, with specific exceptions
                    4 => httpStatus switch
                    {
                        400 => StatusCode.InvalidArgument,
                        401 => StatusCode.Unauthenticated,
                        403 => StatusCode.PermissionDenied,
                        404 => StatusCode.NotFound,
                        409 => StatusCode.Aborted,
                        416 => StatusCode.OutOfRange,
                        429 => StatusCode.ResourceExhausted,
                        499 => StatusCode.Cancelled,
                        _ => StatusCode.FailedPrecondition,
                    },

                    // 5xx defaults to Internal, with specific exceptions
                    5 => httpStatus switch
                    {
                        501 => StatusCode.Unimplemented,
                        503 => StatusCode.Unavailable,
                        504 => StatusCode.DeadlineExceeded,
                        _ => StatusCode.Internal
                    },

                    // Anything else (including all 1xx and 3xx) maps to Unknown
                    _ => StatusCode.Unknown
                };

                return new Status(grpcStatus,
                    // Notice that here, if there was an exception reading the content
                    // we'll bubble it up. This is similar to what's done if there's an
                    // exception while sending the request, and if there's an exception
                    // reading the content for TResponse.
                    grpcStatus == StatusCode.OK ? "" : Content);
            }

            internal Metadata GetTrailers() => new Metadata(); // We never have any trailers.
        }
    }
}
