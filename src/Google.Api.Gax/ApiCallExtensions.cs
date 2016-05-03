using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    static class ApiCallExtensions
    {
        public static Func<A, CallSettings, R> MapArg<A, B, R>(
            this Func<A, B, R> f, Func<CallSettings, B> fMap) =>
            (a, callSettings) => f(a, fMap(callSettings));

        public static Func<TRequest, CallOptions, Task<TResponse>>
            WithTaskTransform<TRequest, TResponse>(
            this Func<TRequest, CallOptions, AsyncUnaryCall<TResponse>> fn) =>
            (request, callOptions) => fn(request, callOptions).ResponseAsync;
    }
}
