/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class GetOrCreateHelperTest
    {
        [Fact]
        public void GetOrCreate_FetchSucceeds()
        {
            string resource = "resource";
            var result = GetOrCreateHelper.GetOrCreate(
                () => resource,
                ThrowRpcException(StatusCode.Internal));
            Assert.Equal(resource, result);
        }

        [Fact]
        public void GetOrCreate_FetchFailsWithInternalError()
        {
            var exception = Assert.Throws<RpcException>(() => GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.Internal),
                ThrowRpcException(StatusCode.DataLoss)));
            Assert.Equal(StatusCode.Internal, exception.Status.StatusCode);
        }

        [Fact]
        public void GetOrCreate_FetchFailsWithNotFound_CreateSucceeds()
        {
            string resource = "resource";
            var result = GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.NotFound),
                () => resource);
            Assert.Equal(resource, result);
        }

        [Fact]
        public void GetOrCreate_FetchFailsWithNotFound_CreateFailsWithInternalError()
        {
            var exception = Assert.Throws<RpcException>(() => GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.NotFound),
                ThrowRpcException(StatusCode.Internal)));
            Assert.Equal(StatusCode.Internal, exception.Status.StatusCode);
        }

        [Fact]
        public void GetOrCreate_FetchFailsWithNotFound_CreateFailsWithAlreadyExists_NextFetchSucceeds()
        {
            string resource = "resource";
            var result = GetOrCreateHelper.GetOrCreate(
                ThrowRpcExceptionThenSucceed(1, StatusCode.NotFound, resource),
                ThrowRpcException(StatusCode.AlreadyExists));
            Assert.Equal(resource, result);
        }

        [Fact]
        public void GetOrCreate_FetchSucceeds_ValidationPasses()
        {
            string resource = "resource";
            var result = GetOrCreateHelper.GetOrCreate(
                () => resource,
                ThrowRpcException(StatusCode.Internal),
                x => x == resource ? null : "bad");
            Assert.Equal(resource, result);
        }

        [Fact]
        public void GetOrCreate_FetchSucceeds_ValidationFails()
        {
            string resource = "resource";
            var exception = Assert.Throws<ResourceMismatchException>(() => GetOrCreateHelper.GetOrCreate(
                () => resource,
                ThrowRpcException(StatusCode.Internal),
                fetched => $"Got {fetched}"));
            Assert.Equal($"Got {resource}", exception.Message);
        }

        [Fact]
        public void GetOrCreate_DefaultMaxAttemptsIs3()
        {
            // With 2 failures we're fine
            string resource = "resource";
            var result = GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.NotFound),
                ThrowRpcExceptionThenSucceed(2, StatusCode.AlreadyExists, resource));
            Assert.Equal(resource, result);

            // With 3 we're not
            Assert.Throws<RpcException>(() => GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.NotFound),
                ThrowRpcExceptionThenSucceed(3, StatusCode.AlreadyExists, resource)));
        }

        [Fact]
        public void GetOrCreate_SpecifyMaxAttempts()
        {
            string resource = "resource";
            var result = GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.NotFound),
                ThrowRpcExceptionThenSucceed(9, StatusCode.AlreadyExists, resource),
                maxAttempts: 10);
            Assert.Equal(resource, result);

            Assert.Throws<RpcException>(() => GetOrCreateHelper.GetOrCreate(
                ThrowRpcException(StatusCode.NotFound),
                ThrowRpcExceptionThenSucceed(10, StatusCode.AlreadyExists, resource),
                maxAttempts: 10));
        }

        // Note: just a couple of tests for the async version, as the code really is just the same as the synchronous version.
        [Fact]
        public async Task GetOrCreateAsync_FetchSucceeds()
        {
            string resource = "resource";
            var result = await GetOrCreateHelper.GetOrCreateAsync(
                () => Task.FromResult(resource),
                ThrowRpcExceptionAsync(StatusCode.Internal));
            Assert.Equal(resource, result);
        }

        [Fact]
        public async Task GetOrCreateAsync_FetchFailsWithInternalError()
        {
            var exception = await Assert.ThrowsAsync<RpcException>(async () => await GetOrCreateHelper.GetOrCreateAsync(
                ThrowRpcExceptionAsync(StatusCode.Internal),
                ThrowRpcExceptionAsync(StatusCode.DataLoss)));
            Assert.Equal(StatusCode.Internal, exception.Status.StatusCode);
        }

        [Fact]
        public async Task GetOrCreateAsync_FetchFailsWithNotFound_CreateSucceeds()
        {
            string resource = "resource";
            var result = await GetOrCreateHelper.GetOrCreateAsync(
                ThrowRpcExceptionAsync(StatusCode.NotFound),
                () => Task.FromResult(resource));
            Assert.Equal(resource, result);
        }

        private static Func<Task<string>> ThrowRpcExceptionAsync(StatusCode code) =>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            async () => { throw new RpcException(new Status(code, "Bang!")); };
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

            /// <summary>
            /// Creates a resource fetcher (for strings) which just throws an exception with the given status code.
            /// </summary>
        private
static Func<string> ThrowRpcException(StatusCode code) =>
            ThrowRpcExceptionThenSucceed(int.MaxValue, code, "irrelevant");

        /// <summary>
        /// Creates a resource fetcher (for strings) which throws an exception with the given status code 
        /// <paramref name="failureCount"/> times, then returns the given result on the next invocation.
        /// </summary>
        private static Func<string> ThrowRpcExceptionThenSucceed(int failureCount, StatusCode code, string result) =>
            () => {
                if (failureCount == 0)
                {
                    return result;
                }
                failureCount--;
                throw new RpcException(new Status(code, "Bang!"));
            };
    }
}
