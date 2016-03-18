/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Helper methods for client library code which provides "get or create" functionality,
    /// i.e. fetching an existing resource if it exists, and creating it otherwise.
    /// </summary>
    public static class GetOrCreateHelper
    {
        private const int DefaultMaxAttempts = 3;

        /// <summary>
        /// Synchronously retrieves an existing resource or creates a new one if the 
        /// resource doesn't already exist.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <paramref name="fetcher"/> fails with an <see cref="RpcException"/> with a status code
        /// of <see cref="StatusCode.NotFound"/>, it is assumed that the resource needs to be created, and
        /// <paramref name="creator"/> is called. If this then fails with an <see cref="RpcException"/> with
        /// a status code of <see cref="StatusCode.AlreadyExists"/>, it is assumed that two clients have been
        /// racing to create the resource, and the whole process is retried. The maximum number of attempts
        /// (whole get/create cycles) is limited by <paramref name="maxAttempts"/>.
        /// </para>
        /// <para>
        /// If <paramref name="validator"/> is not <c>null</c>, it is called when a resource is fetched rather than created,
        /// with the fetched resource being passed in. If the result of the validation is non-null, it is used as the message
        /// of a <see cref="ResourceMismatchException"/> which is thrown as the result of the operation.
        /// </para>
        /// </remarks>
        /// <typeparam name="TResource">The type of the resource being fetched or created.</typeparam>
        /// <param name="fetcher">A delegate to fetch the resource. Must not be null.</param>
        /// <param name="creator">A delegate to create the resource if it doesn't already exist. Must not be null.</param>
        /// <param name="validator">An optional delegate to validate that a fetched resource has the expected form.</param>
        /// <param name="maxAttempts">The maximum number of fetch/create cycles to try before giving up.</param>
        /// <exception cref="ResourceMismatchException">The resource was fetched, but failed the specified validation.</exception>
        /// <returns>The resource fetched or created.</returns>
        public static TResource GetOrCreate<TResource>(
            Func<TResource> fetcher,
            Func<TResource> creator,
            Func<TResource, string> validator = null,
            int maxAttempts = DefaultMaxAttempts)
        {
            GaxPreconditions.CheckNotNull(fetcher, nameof(fetcher));
            GaxPreconditions.CheckNotNull(creator, nameof(creator));
            GaxPreconditions.CheckArgumentRange(maxAttempts, nameof(maxAttempts), 1, int.MaxValue);
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    var resource = fetcher();
                    var validationError = validator?.Invoke(resource);
                    if (validationError != null)
                    {
                        throw new ResourceMismatchException(validationError);
                    }
                    return resource;
                }
                catch (RpcException e) when (e.Status.StatusCode == StatusCode.NotFound)
                {
                    try
                    {
                        return creator();
                    }
                    catch (RpcException creationException) when (i < maxAttempts - 1 && creationException.Status.StatusCode == StatusCode.AlreadyExists)
                    {
                        // Probably a race condition... someone else tried to create it just when we did.
                        // Go back through the loop and check we can get it this time, failing after this happens too often.
                    }
                }
            }
            throw new InvalidOperationException("Bug in Google.Api.Gax: please report at http://github.com/googleapis/gax-dotnet");
        }

        /// <summary>
        /// Asynchronously retrieves an existing resource or creates a new one if the 
        /// resource doesn't already exist.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <paramref name="fetcher"/> fails with an <see cref="RpcException"/> with a status code
        /// of <see cref="StatusCode.NotFound"/>, it is assumed that the resource needs to be created, and
        /// <paramref name="creator"/> is called. If this then fails with an <see cref="RpcException"/> with
        /// a status code of <see cref="StatusCode.AlreadyExists"/>, it is assumed that two clients have been
        /// racing to create the resource, and the whole process is retried. The maximum number of attempts
        /// (whole get/create cycles) is limited by <paramref name="maxAttempts"/>. Both delegates are expected to be
        /// thread-safe: they are likely not to be called from the original synchronization context.
        /// </para>
        /// <para>
        /// It is expected that if cancellation support is required, it will be embedded in the calls to <paramref name="fetcher"/>
        /// and <paramref name="creator"/>.
        /// </para>
        /// <para>
        /// If <paramref name="validator"/> is not <c>null</c>, it is called when a resource is fetched rather than created,
        /// with the fetched resource being passed in. If the result of the validation is non-null, it is used as the message
        /// of a <see cref="ResourceMismatchException"/> which is thrown as the result of the operation.
        /// </para>
        /// </remarks>
        /// <typeparam name="TResource">The type of the resource being fetched or created.</typeparam>
        /// <param name="fetcher">A delegate to asynchronously fetch the resource. Must not be null.</param>
        /// <param name="creator">A delegate to asynchronously create the resource if it doesn't already exist. Must not be null.</param>
        /// <param name="validator">An optional delegate to validate that a fetched resource has the expected form.</param>
        /// <param name="maxAttempts">The maximum number of fetch/create cycles to try before giving up.</param>
        /// <exception cref="ResourceMismatchException">The resource was fetched, but failed the specified validation.</exception>
        /// <returns>A task representing the asynchronous operation. When the task is completed, its result will be
        /// the resource fetched or created.</returns>
        public static async Task<TResource> GetOrCreateAsync<TResource>(
            Func<Task<TResource>> fetcher,
            Func<Task<TResource>> creator,
            Func<TResource, string> validator = null,
            int maxAttempts = DefaultMaxAttempts)
        {
            GaxPreconditions.CheckNotNull(fetcher, nameof(fetcher));
            GaxPreconditions.CheckNotNull(creator, nameof(creator));
            GaxPreconditions.CheckArgumentRange(maxAttempts, nameof(maxAttempts), 1, int.MaxValue);
            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    var resource = await fetcher().ConfigureAwait(false);
                    var validationError = validator?.Invoke(resource);
                    if (validationError != null)
                    {
                        throw new ResourceMismatchException(validationError);
                    }
                    return resource;
                }
                catch (RpcException e) when (e.Status.StatusCode == StatusCode.NotFound)
                {
                    try
                    {
                        return await creator().ConfigureAwait(false);
                    }
                    catch (RpcException creationException) when (i < maxAttempts - 1 && creationException.Status.StatusCode == StatusCode.AlreadyExists)
                    {
                        // Probably a race condition... someone else tried to create it just when we did.
                        // Go back through the loop and check we can get it this time, failing after this happens too often.
                    }
                }
            }
            throw new InvalidOperationException("Bug in Google.Api.Gax: please report at http://github.com/googleapis/gax-dotnet");
        }
    }
}
