﻿/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
using Grpc.Core;
using System;
using System.IO;
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
            .AppendAssemblyVersion("pb", typeof(Duration))
            .ToString();

        private readonly AsyncAuthInterceptor _channelAuthInterceptor;
        private readonly HttpClient _httpClient;
        private readonly RestServiceCollection _serviceCollection;
        private readonly CallInvoker _callInvoker;

        internal RestChannel(
            RestServiceCollection serviceCollection, string endpoint, ChannelCredentials credentials,
            GrpcChannelOptions options, HttpClient httpClient = null) : base(endpoint)
        {
            _serviceCollection = serviceCollection;

            // Reuse a single CallInvoker however many times CreateCallInvoker is called.
            _callInvoker = new RestCallInvoker(this);
            // TODO: Handle endpoints better...
            var endpointWithScheme =
                endpoint.StartsWith("https://", StringComparison.Ordinal) || endpoint.StartsWith("http://", StringComparison.Ordinal)
                ? endpoint
                : $"https://{endpoint}";
            var baseAddress = new Uri(endpointWithScheme);

            // TODO: Avoid creating an HTTP Client for every channel?
            _httpClient = httpClient ?? new HttpClient { BaseAddress = baseAddress };
            
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

            var cancellationContext = RpcCancellationContext.FromOptions(method.FullName, options);

            var httpResponseTask = cancellationContext.RunAsync(
                cancellationToken => SendAsync(restMethod, host, options, request, HttpCompletionOption.ResponseContentRead, cancellationToken));
            var readResponseTask = ReadResponseAsync(httpResponseTask, cancellationContext);

            var responseTask = restMethod.ReadResponseAsync<TResponse>(readResponseTask);
            var responseHeadersTask = ReadHeadersAsync(readResponseTask);
            Func<Status> statusFunc = () => GetStatus(readResponseTask);
            Func<Metadata> trailersFunc = () => GetTrailers(readResponseTask);
            return new AsyncUnaryCall<TResponse>(responseTask, responseHeadersTask, statusFunc, trailersFunc, cancellationContext.Cancel);
        }

        /// <summary>
        /// Equivalent to <see cref="CallInvoker.AsyncServerStreamingCall{TRequest, TResponse}(Method{TRequest, TResponse}, string, CallOptions, TRequest)"/>.
        /// </summary>
        public AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TResponse, TRequest>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            var restMethod = _serviceCollection.GetRestMethod(method);

            var cancellationContext = RpcCancellationContext.FromOptions(method.FullName, options);

            Task<HttpResponseMessage> httpResponseTask = cancellationContext.RunAsync(
                cancellationToken => SendAsync(restMethod, host, options, request, HttpCompletionOption.ResponseHeadersRead, cancellationToken));

            Task<Metadata> responseHeadersTask = ReadHeadersAsync(httpResponseTask);
            // The response will either contain the response (which is streaming, so we don't
            // want to wait for it to finish) or error details (in which case we *do* want it
            // to finish). The simplest way of providing status/trailer functionality is
            // to create a separate ReadHttpResponseMessage with either empty content or
            // the full original content. That's only used for status/trailers, and both
            // GetStatus and GetTrailers only succeed when the response task has completed.
            var statusResponseSource = new TaskCompletionSource<ReadHttpResponseMessage>();
            var readerTask = CreateReaderTask();
            Func<Status> statusFunc = () => GetStatus(statusResponseSource.Task);
            Func<Metadata> trailersFunc = () => GetTrailers(statusResponseSource.Task);

            // The response stream will dispose of the cancellation context if:
            // - The user disposes of the PartialDecodingStreamReader directly
            // - The user disposes of the AsyncServerStreamingCall
            // - Any exception is thrown while reading an element
            // - We reach the last element
            PartialDecodingStreamReader<TResponse> responseStream = new PartialDecodingStreamReader<TResponse>(readerTask, restMethod.ParseJson<TResponse>, cancellationContext);
            Action disposalAction = () =>
            {
                cancellationContext.Cancel();
                responseStream.Dispose();
            };
            return new AsyncServerStreamingCall<TResponse>(responseStream, responseHeadersTask, statusFunc, trailersFunc, disposalAction);

            async Task<TextReader> CreateReaderTask()
            {
                var httpResponse = await httpResponseTask.ConfigureAwait(false);
                if (httpResponse.IsSuccessStatusCode)
                {
                    // The status for a successful response is empty, in terms of an error response.
                    // We set the result of the task to allow the status and trailers to be read.
                    statusResponseSource.SetResult(new ReadHttpResponseMessage(httpResponse, ""));
                    var stream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return new StreamReader(stream);
                }

                // Read the content from the HttpResponseMessage, and populate a new ReadHttpResponseMessage.
                // We use this for status/trailer reporting. The parent PartialDecodingStreamReader is still responsible
                // for disposing of the cancellation context: while we could dispose it now, that would make
                // a call to MoveNext fail because we couldn't obtain a cancellation token.
                // This should be fine, so long as the returned PartialDecodingStreamReader is used or disposed.
                var errorResponse = await ReadResponseAsync(httpResponseTask, cancellationContext: null).ConfigureAwait(false);
                statusResponseSource.SetResult(errorResponse);
                throw new RpcException(errorResponse.GetStatus(), errorResponse.GetTrailers());
            }
        }

        /// <summary>
        /// Creates an HTTP request, adds headers from CallOptions, and sends the request.
        /// </summary>
        /// <typeparam name="TRequest">The type of request</typeparam>
        /// <param name="restMethod">The RPC being called; used to convert the request</param>
        /// <param name="host">Override for the endpoint, if any</param>
        /// <param name="options">The gRPC call options, used for headers and cancellation</param>
        /// <param name="request">The RPC request</param>
        /// <param name="httpCompletionOption">The option indicating at what point the method should complete,
        /// <param name="cancellationToken">The cancellation token for the RPC.</param>
        /// within HTTP response processing</param>
        private async Task<HttpResponseMessage> SendAsync<TRequest>(
            RestMethod restMethod, string host, CallOptions options, TRequest request,
            HttpCompletionOption httpCompletionOption, CancellationToken cancellationToken)
        {
            // Ideally, add the header in the client builder instead of in the ServiceSettingsBase...
            var httpRequest = restMethod.CreateRequest((IMessage)request, host);
            foreach (var headerKeyValue in (options.Headers ?? Enumerable.Empty<Metadata.Entry>())
                .Where(mh => !mh.IsBinary)
                .Where(mh => mh.Key != VersionHeaderBuilder.HeaderName))
            {
                httpRequest.Headers.Add(headerKeyValue.Key, headerKeyValue.Value);
            }

            httpRequest.Headers.Add(VersionHeaderBuilder.HeaderName, RestVersion);

            await AddAuthHeadersAsync(httpRequest, restMethod, cancellationToken).ConfigureAwait(false);
            return await _httpClient.SendAsync(httpRequest, httpCompletionOption, cancellationToken).ConfigureAwait(false);
        }

        private async Task<ReadHttpResponseMessage> ReadResponseAsync(Task<HttpResponseMessage> msgTask, RpcCancellationContext cancellationContext)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await msgTask.ConfigureAwait(false);

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
            finally
            {
                // Once we've read the response, whether successfully or not, there's nothing to cancel, so we can
                // clean up any resources associated with it.
                cancellationContext?.Dispose();
            }
        }

        private async Task AddAuthHeadersAsync(HttpRequestMessage request, RestMethod restMethod, CancellationToken combinedCancellationToken)
        {
            if (_channelAuthInterceptor is null)
            {
                return;
            }

            Uri hostUri = request.RequestUri.IsAbsoluteUri ? request.RequestUri : _httpClient.BaseAddress;
            string schemeAndAuthority = hostUri.GetLeftPart(UriPartial.Authority);

            var metadata = new Metadata();
            var context = new AuthInterceptorContext(schemeAndAuthority, restMethod.FullName);

            var combinedCancellationTask = Task.Delay(-1, combinedCancellationToken);
            var channelTask = _channelAuthInterceptor(context, metadata);
            var resultTask = await Task.WhenAny(channelTask, combinedCancellationTask).ConfigureAwait(false);

            // If the combinedCancellationTask "wins" `Task.WhenAny` by being cancelled, the following await will throw TaskCancelledException.
            // If the channelTask "wins" by being faulted, the await will rethrow its exception.
            // Finally, if the channelTask completes, the await does nothing.
            await resultTask.ConfigureAwait(false);
            // If we're here, the channelTask has completed successfully.
           
            foreach (var entry in metadata)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }
        }

        private async Task<Metadata> ReadHeadersAsync(Task<ReadHttpResponseMessage> httpResponseTask) =>
            (await httpResponseTask.ConfigureAwait(false)).GetHeaders();

        private async Task<Metadata> ReadHeadersAsync(Task<HttpResponseMessage> httpResponseTask) =>
            ReadHttpResponseMessage.ReadHeaders((await httpResponseTask.ConfigureAwait(false)).Headers);

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
    }
}
