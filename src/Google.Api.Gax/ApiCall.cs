/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Wrapper for matching asynchronous and synchronous API calls to the same underlying method.
    /// </summary>
    /// <typeparam name="TRequest">Request type, which must be a protobuf message.</typeparam>
    /// <typeparam name="TResponse">Response type, which must be a protobuf message.</typeparam>
    public sealed class ApiCall<TRequest, TResponse>
        where TRequest : class, IMessage<TRequest>
        where TResponse : class, IMessage<TResponse>
    {
        /// <summary>
        /// Delegate representing a single asynchronous API call with a request and <see cref="CallSettings"/>.
        /// </summary>
        /// <param name="request">Request to make to the service.</param>
        /// <param name="callSettings">If not null, provides settings that override the client-provided settings.</param>
        /// <returns>A task representing the API call; the result of the completed task will be the API response.</returns>
        public delegate Task<TResponse> AsyncCall(TRequest request, CallSettings callSettings);
        /// <summary>
        /// Delegate representing a single synchronous API call with a request and <see cref="CallSettings"/>.
        /// </summary>
        /// <param name="request">Request to make to the service.</param>
        /// <param name="callSettings">If not null, provides settings that override the client-provided settings.</param>
        /// <returns>The API response.</returns>
        public delegate TResponse SyncCall(TRequest request, CallSettings callSettings);

        /// <summary>
        /// Initializes a new <see cref="ApiCall"/> with the specified asynchronous and synchronous calls.
        /// </summary>
        /// <param name="asyncCall">The asynchronous API call. Must not be null.</param>
        /// <param name="syncCall">The synchronous API call. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Either specified call is null.</exception>
        public ApiCall(AsyncCall asyncCall, SyncCall syncCall)
        {
            Async = GaxPreconditions.CheckNotNull(asyncCall, nameof(asyncCall));
            Sync = GaxPreconditions.CheckNotNull(syncCall, nameof(syncCall));
        }

        /// <summary>
        /// The asynchronous API call. Will not be null.
        /// </summary>
        public AsyncCall Async { get; }

        /// <summary>
        /// The synchronous API call. Will not be null.
        /// </summary>
        public SyncCall Sync { get; }
    }
}
