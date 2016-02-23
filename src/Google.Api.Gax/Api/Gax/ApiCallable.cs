/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Delegate representing a single asynchronous API call with a request and a cancellation token.
    /// Other call options are expected to be consistent over multiple calls to the same callable.
    /// </summary>
    /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
    /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
    /// <param name="request">Request to make to the service.</param>
    /// <param name="cancellationToken">The cancellation token for this call.</param>
    /// <returns>A task representing the API call; the result of the completed task will be the API response.</returns>
    public delegate Task<TResponse> ApiCallable<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        where TRequest : class, IMessage<TRequest>
        where TResponse : class, IMessage<TResponse>;
}
