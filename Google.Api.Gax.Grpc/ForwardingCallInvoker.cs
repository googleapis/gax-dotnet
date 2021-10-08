/*
 * Copyright 2021 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc
{
#if REGAPIC
    /// <summary>
    /// Non-generic static class just for generic type inference, to make it easier to construct instances
    /// of <see cref="ForwardingCallInvoker{TSourceRequest, TSourceResponse, TTargetRequest, TTargetResponse}"/>.
    /// </summary>
    /// <typeparam name="TSourceRequest">The type of the expected source request. Specifying this explicitly
    /// is usually sufficient to allow type inference to work for generic methods within this class.</typeparam>
    public static class ForwardingCallInvoker<TSourceRequest> where TSourceRequest : class
    {
        /// <summary>
        /// Creates a <see cref="ForwardingCallInvoker{TSourceRequest, TSourceResponse, TTargetRequest, TTargetResponse}"/>
        /// to forward a single unary call to a method in an existing <see cref="CallInvoker"/>.
        /// </summary>
        /// <typeparam name="TSourceResponse">The type of the source response, i.e. the response we expect to return
        /// to the caller at the end of the method.</typeparam>
        /// <typeparam name="TTargetRequest">The type of the target request, i.e. the request we'll forward on
        /// to <paramref name="originalInvoker"/>.</typeparam>
        /// <typeparam name="TTargetResponse">The type of the target response, i.e. the response we expect to be
        /// returned by <paramref name="originalInvoker"/>.</typeparam>
        /// <param name="originalInvoker">The original invoker that will handle the request.</param>
        /// <param name="sourceMethodFullName">The full name (as reported by <see cref="Method{TRequest, TResponse}.FullName"/>)
        /// of the method to forward.</param>
        /// <param name="targetMethod">The target method to call on <paramref name="originalInvoker"/>.</param>
        /// <param name="requestConverter">A delegate to convert source requests to target requests.</param>
        /// <param name="responseConverter">A delegate to convert target responses to source responses, with
        /// additional context being provided from the original source request.</param>
        /// <returns>A call invoker forwarding the specified call.</returns>
        public static CallInvoker Create<TSourceResponse, TTargetRequest, TTargetResponse>(
            CallInvoker originalInvoker, string sourceMethodFullName, Method<TTargetRequest, TTargetResponse> targetMethod,
            Func<TSourceRequest, TTargetRequest> requestConverter,
            Func<TSourceRequest, TTargetResponse, TSourceResponse> responseConverter)            
            where TSourceResponse : class
            where TTargetRequest : class
            where TTargetResponse : class =>
            new ForwardingCallInvoker<TSourceRequest, TSourceResponse, TTargetRequest, TTargetResponse>(originalInvoker, sourceMethodFullName, targetMethod, requestConverter, responseConverter);
    }
#endif

    /// <summary>
    /// A <see cref="CallInvoker"/> which forwards specific calls to an existing invoker,
    /// transforming the requests and responses as necessary.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It would be cleaner to write an interceptor for this functionality, but that doesn't allow for the request/response types to be changed.
    /// </para>
    /// <para>
    /// Currently, only unary methods are supported, and only a single method can be forwarded. Any
    /// other method results in an <see cref="RpcException"/> with a status code of <see cref="StatusCode.Unimplemented"/>.
    /// The type parameters of this class would make it hard to support multiple calls, which is why the factory
    /// class method has a return type of <see cref="CallInvoker"/> rather than the concrete class: we may implement
    /// multi-method support via composition of multiple call invokers.
    /// </para>
    /// </remarks>
    internal sealed class ForwardingCallInvoker<TSourceRequest, TSourceResponse, TTargetRequest, TTargetResponse> : CallInvoker
        where TSourceRequest : class
        where TSourceResponse : class
        where TTargetRequest : class
        where TTargetResponse : class
    {
        private static readonly Task<Metadata> s_emptyMetadataTask = Task.FromResult(Metadata.Empty);
        private static readonly Func<Metadata> s_emptyMetadataFunc = () => Metadata.Empty;
        private static readonly Action s_emptyDisposalAction = () => { };

        private CallInvoker _targetInvoker;
        private string _sourceMethodFullName;
        private Method<TTargetRequest, TTargetResponse> _targetMethod;
        private Func<TSourceRequest, TTargetRequest> _requestConverter;
        private Func<TSourceRequest, TTargetResponse, TSourceResponse> _responseConverter;

        internal ForwardingCallInvoker(
            CallInvoker originalInvoker, string sourceMethodFullName, Method<TTargetRequest, TTargetResponse> targetMethod,
            Func<TSourceRequest, TTargetRequest> requestConverter,
            Func<TSourceRequest, TTargetResponse, TSourceResponse> responseConverter)
        {
            _targetInvoker = originalInvoker;
            _sourceMethodFullName = sourceMethodFullName;
            _targetMethod = targetMethod;
            _requestConverter = requestConverter;
            _responseConverter = responseConverter;
        }

        // The streaming methods throw RpcException directly, rather than creating a call that in turn fails.
        // This is because there are multiple ways of consuming a stream, and throwing directly is more
        // likely to expose the problem immediately. Also, *all* streaming calls will fail with this
        // CallInvoker, so making the failure a more catastrophic one is probably appropriate.
        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) =>
            throw new InvalidOperationException("Streaming calls are unsupported in this CallInvoker");

        public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options) =>
            throw new InvalidOperationException("Streaming calls are unsupported in this CallInvoker");

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) =>
            throw new InvalidOperationException("Streaming calls are unsupported in this CallInvoker");

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            if (method.FullName != _sourceMethodFullName)
            {
                // Rather than throw directly, here we *do* create a call that fails as if it had been
                // rejected by a server. This is more likely to be handled appropriately by calling code.
                var status = CreateUnimplementedStatus($"Method {method.FullName} is not implemented in this CallInvoker");
                return new AsyncUnaryCall<TResponse>(
                    Task.FromException<TResponse>(new RpcException(status)),
                    s_emptyMetadataTask,
                    () => status,
                    s_emptyMetadataFunc,
                    s_emptyDisposalAction);
            }

            var sourceRequest = (TSourceRequest)(object)request;
            var targetRequest = _requestConverter(sourceRequest);
            var targetCall = _targetInvoker.AsyncUnaryCall(_targetMethod, host, options, targetRequest);

            return new AsyncUnaryCall<TResponse>(ConvertResponse(sourceRequest, targetCall.ResponseAsync), targetCall.ResponseHeadersAsync, targetCall.GetStatus, targetCall.GetTrailers, targetCall.Dispose);

            async Task<TResponse> ConvertResponse(TSourceRequest sourceRequest, Task<TTargetResponse> targetResponseTask)
            {
                var targetResponse = await targetResponseTask.ConfigureAwait(false);
                var sourceResponse = _responseConverter(sourceRequest, targetResponse);
                return (TResponse)(object)sourceResponse;
            }
        }

        public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            if (method.FullName != _sourceMethodFullName)
            {
                var status = CreateUnimplementedStatus($"Method {method.FullName} is not implemented in this CallInvoker");
                throw new RpcException(status);
            }

            var sourceRequest = (TSourceRequest)(object)request;
            var targetRequest = _requestConverter(sourceRequest);
            var targetResponse = _targetInvoker.BlockingUnaryCall(_targetMethod, host, options, targetRequest);
            var sourceResponse = _responseConverter(sourceRequest, targetResponse);
            return (TResponse)(object) sourceResponse;
        }

        private Status CreateUnimplementedStatus(string detail) => new Status(StatusCode.Unimplemented, detail);
    }
}
