/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Testing;
using Google.Protobuf;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Testing
{
    /// <summary>
    /// Helper class to use when faking services; enables <see cref="ApiCall{TRequest, TResponse}"/> objects
    /// to be created without gRPC 
    /// </summary>
    public static class FakeApiCall
    {
        /// <summary>
        /// Creates an API call from the given async/sync functions.
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="asyncCall">Function to call for async requests</param>
        /// <param name="syncCall">Function to call for sync requests</param>
        /// <param name="baseCallSettings">The default call settings. May be null.</param>
        /// <param name="clock">The clock to use; defaults to a new <see cref="FakeClock"/>.</param>
        /// <returns>The new API call.</returns>
        public static ApiCall<TRequest, TResponse> Create<TRequest, TResponse>(
            Func<TRequest, CallOptions, Task<TResponse>> asyncCall,
            Func<TRequest, CallOptions, TResponse> syncCall,
            CallSettings baseCallSettings = null,
            IClock clock = null)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
        {
            clock = clock ?? new FakeClock();
            return new ApiCall<TRequest, TResponse>(
                asyncCall.MapArg((CallSettings cs) => cs.ToCallOptions(clock)),
                syncCall.MapArg((CallSettings cs) => cs.ToCallOptions(clock)),
                baseCallSettings);
        }

        /// <summary>
        /// Creates an API call from a synchronous function, which is just called synchronously for
        /// asynchronous requests.
        /// </summary>
        /// <remarks>
        /// For asynchronous requests, the synchronous function is called but within an async
        /// context; exceptions will still be reported back via the returned task, but the call will
        /// complete synchronously.
        /// </remarks>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="syncCall">Function to call for sync requests</param>
        /// <param name="baseCallSettings">The default call settings. May be null.</param>
        /// <param name="clock">The clock to use; defaults to a new <see cref="FakeClock"/>.</param>
        /// <returns>The new API call.</returns>
        public static ApiCall<TRequest, TResponse> Create<TRequest, TResponse>(
            Func<TRequest, CallOptions, TResponse> syncCall,
            CallSettings baseCallSettings = null,
            IClock clock = null)
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse> =>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            // Not using Task.OfResult as we want the faulted-task behaviour for exceptions.
            Create(async (request, response) => syncCall(request, response),
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
                syncCall,
                baseCallSettings,
                clock);
    }
}
