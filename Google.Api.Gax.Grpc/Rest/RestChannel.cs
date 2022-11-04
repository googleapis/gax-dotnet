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
            var endpointWithScheme = endpoint.StartsWith("https://") || endpoint.StartsWith("http://")
                ? endpoint
                : $"https://{endpoint}";
            var baseAddress = new Uri(endpointWithScheme);

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
                // TODO: [virost, 2021-12] Use IClock.
                var delayInterval = options.Deadline.Value - DateTime.UtcNow;
                if (delayInterval.TotalMilliseconds <= 0)
                {
                    throw new RpcException(new Status(StatusCode.DeadlineExceeded, $"The timeout was reached when calling a method `{restMethod.FullName}`"));
                }
                cancellationTokenSource = new CancellationTokenSource(delayInterval);
            }

            var httpResponseTask = SendAsync(restMethod, host, options, request, cancellationTokenSource.Token, HttpCompletionOption.ResponseContentRead);
            var readResponseTask = ReadResponseAsync(httpResponseTask);

            var responseTask = restMethod.ReadResponseAsync<TResponse>(readResponseTask);
            var responseHeadersTask = ReadHeadersAsync(readResponseTask);
            Func<Status> statusFunc = () => GetStatus(readResponseTask);
            Func<Metadata> trailersFunc = () => GetTrailers(readResponseTask);
            return new AsyncUnaryCall<TResponse>(responseTask, responseHeadersTask, statusFunc, trailersFunc, cancellationTokenSource.Cancel);
        }

        private async Task<HttpResponseMessage> SendAsync<TRequest>(RestMethod restMethod, string host, CallOptions options, TRequest request,
            CancellationToken deadlineToken, HttpCompletionOption httpCompletionOption)
        {
            // Ideally, add the header in the client builder instead of in the ServiceSettingsBase...
            var httpRequest = restMethod.CreateRequest((IMessage)request, host);
            foreach (var headerKeyValue in options.Headers
                .Where(mh => !mh.IsBinary)
                .Where(mh => mh.Key != VersionHeaderBuilder.HeaderName))
            {
                httpRequest.Headers.Add(headerKeyValue.Key, headerKeyValue.Value);
            }

            httpRequest.Headers.Add(VersionHeaderBuilder.HeaderName, RestVersion);

            HttpResponseMessage httpResponseMessage;
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(options.CancellationToken, deadlineToken))
            {
                try
                {
                    await AddAuthHeadersAsync(httpRequest, restMethod, linkedCts.Token).ConfigureAwait(false);
                    httpResponseMessage = await _httpClient.SendAsync(httpRequest, httpCompletionOption, linkedCts.Token).ConfigureAwait(false);
                }
                catch (TaskCanceledException ex) when (deadlineToken.IsCancellationRequested)
                {
                    throw new RpcException(new Status(StatusCode.DeadlineExceeded, $"The timeout was reached when calling a method `{restMethod.FullName}`", ex));
                }
            }

            return httpResponseMessage;
        }

        /// <summary>
        /// Equivalent to <see cref="CallInvoker.AsyncServerStreamingCall{TRequest, TResponse}(Method{TRequest, TResponse}, string, CallOptions, TRequest)"/>.
        /// </summary>
        public AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TResponse, TRequest>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            // TODO[virost, 11/2022] Refactor this and the Unary call to remove duplication
            var restMethod = _serviceCollection.GetRestMethod(method);

            var cancellationTokenSource = new CancellationTokenSource();
            if (options.Deadline.HasValue)
            {
                // TODO: [virost, 2021-12] Use IClock.
                var delayInterval = options.Deadline.Value - DateTime.UtcNow;
                if (delayInterval.TotalMilliseconds <= 0)
                {
                    throw new RpcException(new Status(StatusCode.DeadlineExceeded, $"The timeout was reached when calling a method `{restMethod.FullName}`"));
                }
                cancellationTokenSource = new CancellationTokenSource(delayInterval);
            }

            Task<HttpResponseMessage> httpResponseTask = SendAsync(restMethod, host, options, request, cancellationTokenSource.Token, HttpCompletionOption.ResponseHeadersRead);

            Task<Metadata> responseHeadersTask = ReadHeadersAsync(httpResponseTask);
            Func<Status> statusFunc = () => GetStatus(ReadResponseAsync(httpResponseTask));
            Func<Metadata> trailersFunc = () => GetTrailers(ReadResponseAsync(httpResponseTask));

            IAsyncStreamReader<TResponse> responseStream = restMethod.ResponseStreamAsync<TResponse>(httpResponseTask);
            return new AsyncServerStreamingCall<TResponse>(responseStream, responseHeadersTask, statusFunc, trailersFunc, cancellationTokenSource.Cancel);
        }

        private async Task<ReadHttpResponseMessage> ReadResponseAsync(Task<HttpResponseMessage> msgTask)
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
