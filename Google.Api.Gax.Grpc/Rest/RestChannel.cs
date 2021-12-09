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
            var baseAddress = new Uri($"https://{endpoint}");

            // TODO: Avoid creating an HTTP Client for every channel?
            _httpClient = new HttpClient { BaseAddress = baseAddress };
            
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
            if (options.Deadline.HasValue)
            {
                cancellationTokenSource = new CancellationTokenSource(options.Deadline.Value - DateTime.UtcNow);
            }
            var httpResponseTask = SendAsync(restMethod, host, options, request, cancellationTokenSource.Token);

            var responseTask = restMethod.ReadResponseAsync<TResponse>(httpResponseTask);
            var responseHeadersTask = ReadHeadersAsync(httpResponseTask);
            Func<Status> statusFunc = () => GetStatus(httpResponseTask);
            Func<Metadata> trailersFunc = () => GetTrailers(httpResponseTask);
            return new AsyncUnaryCall<TResponse>(responseTask, responseHeadersTask, statusFunc, trailersFunc, cancellationTokenSource.Cancel);
        }

        private async Task<ReadHttpResponseMessage> SendAsync<TRequest>(RestMethod restMethod, string host, CallOptions options, TRequest request, CancellationToken cancellationToken)
        {
            // Ideally, add the header in the client builder instead of in the ServiceSettingsBase...
            var httpRequest = restMethod.CreateRequest((IMessage) request, host);
            foreach (var headerKeyValue in options.Headers
                .Where(mh => !mh.IsBinary)
                .Where(mh=> mh.Key != VersionHeaderBuilder.HeaderName))
            {
                httpRequest.Headers.Add(headerKeyValue.Key, headerKeyValue.Value);
            }
            httpRequest.Headers.Add(VersionHeaderBuilder.HeaderName, RestVersion);

            var addAuthHeadersTask = AddAuthHeadersAsync(httpRequest, restMethod);
            var delayTask = Task.Delay(-1, cancellationToken);
            if (delayTask == await Task.WhenAny(addAuthHeadersTask, delayTask).ConfigureAwait(false))
            {
                throw new InvalidOperationException("Timeout was reached when waiting for auth headers to be added for a method {restMethod.FullName}.");
            }

            HttpResponseMessage httpResponseMessage;
            try
            {
                httpResponseMessage = await _httpClient.SendAsync(httpRequest,
                    HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
            }
            catch(TaskCanceledException ex)
            {
                throw new InvalidOperationException($"The timeout was reached when calling a method {restMethod.FullName}", ex);
            }

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
                // Note: we need this conditionality because it uses a public part of REGAPIC, and all public aspects
                // are currently conditional. It's fine to throw if we're not in a REGAPIC-inclusive version, because
                // this internal code will never be reached. It's only present to avoid having to make *everything*
                // in REGAPIC conditional, which would be relatively annoying.
                var grpcStatus = RestGrpcAdapter.ConvertHttpStatusCode((int) OriginalResponseMessage.StatusCode);
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
