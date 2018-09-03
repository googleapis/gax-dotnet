/*
 * Copyright 2017 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */
using Google.Api.Gax.Grpc.Testing;
using Google.Api.Gax.Testing;
using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiCallTest
    {
        [Fact]
        public void WithCallSettingsOverlay()
        {
            var ctBase = new CancellationTokenSource().Token;
            var ctPerCall = new CancellationTokenSource().Token;
            var ctOverlay = new CancellationTokenSource().Token;

            CallSettings syncCallSettings = null;
            CallSettings asyncCallSettings = null;
            var call0 = new ApiCall<SimpleRequest, SimpleResponse>(
                (req, cs) => { asyncCallSettings = cs; return null; },
                (req, cs) => { syncCallSettings = cs; return null; },
                CallSettings.FromCancellationToken(ctBase));

            // Verify a null overlay has no effect.
            // Async call runs synchonously due to 'call0' definition above.
            var call1 = call0.WithCallSettingsOverlay(req => null);
            call1.Sync(null, CallSettings.FromCancellationToken(ctPerCall));
            call1.Async(null, CallSettings.FromCancellationToken(ctPerCall));
            Assert.Equal(ctPerCall, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, syncCallSettings.CancellationToken.Value);
            Assert.Equal(ctPerCall, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, asyncCallSettings.CancellationToken.Value);

            // Verify an overlay overwrites all else.
            var call2 = call0.WithCallSettingsOverlay(req => CallSettings.FromCancellationToken(ctOverlay));
            call2.Sync(null, CallSettings.FromCancellationToken(ctPerCall));
            call2.Async(null, CallSettings.FromCancellationToken(ctPerCall));
            Assert.Equal(ctOverlay, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, syncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctPerCall, syncCallSettings.CancellationToken.Value);
            Assert.Equal(ctOverlay, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctBase, asyncCallSettings.CancellationToken.Value);
            Assert.NotEqual(ctPerCall, asyncCallSettings.CancellationToken.Value);
        }

        [Theory, CombinatorialData]
        public async Task MetadataHandlers(bool responseHandler, bool trailingHandler, bool sync)
        {
            var call = CreateMetadataTestingApiCall();
            Metadata actualResponseMetadata = null;
            Metadata actualTrailingMetadata = null;
            Metadata expectedResponseMetadata = responseHandler ? CreateMetadata("kind", "response") : null;
            Metadata expectedTrailingMetadata = trailingHandler ? CreateMetadata("kind", "trailing") : null;

            CallSettings settings = null;
            if (responseHandler)
            {
                settings = settings.WithResponseMetadataHandler(metadata => actualResponseMetadata = metadata);
            }
            if (trailingHandler)
            {
                settings = settings.WithTrailingMetadataHandler(metadata => actualTrailingMetadata = metadata);
            }
            var request = new SimpleRequest();
            var response = sync ? call.Sync(request, settings) : await call.Async(request, settings);
            Assert.Equal("response", response.Name);

            AssertMetadata(expectedResponseMetadata, actualResponseMetadata);
            AssertMetadata(expectedTrailingMetadata, actualTrailingMetadata);
        }

        private ApiCall<SimpleRequest, SimpleResponse> CreateMetadataTestingApiCall()
        {
            var responseMetadata = CreateMetadata("kind", "response");
            var trailingMetadata = CreateMetadata("kind", "trailing");
            var response = new SimpleResponse { Name = "response" };
            var call = new AsyncUnaryCall<SimpleResponse>(
                Task.FromResult(response),
                Task.FromResult(responseMetadata),
                () => Status.DefaultSuccess,
                () => trailingMetadata,
                disposeAction: () => { });

            return ApiCall.Create<SimpleRequest, SimpleResponse>(
                (request, options) => call,
                (request, options) => response,
                baseCallSettings: null,
                clock: new FakeClock());
        }

        private void AssertMetadata(Metadata expected, Metadata actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, actual[i].Key);
                Assert.Equal(expected[i].Value, actual[i].Value);
            }
        }

        /// <summary>
        /// Creates a Metadata instance for a single key/value pair.
        /// </summary>
        private static Metadata CreateMetadata(string key, string value) =>
            new Metadata { new Metadata.Entry("kind", "response") };

        [Theory, CombinatorialData]
        public async Task WithExceptionCustomizer_NoException(bool sync)
        {
            var response = new SimpleResponse();
            var call = FakeApiCall.Create<SimpleRequest, SimpleResponse>((req, options) => response);
            bool called = false;
            call = call.WithExceptionCustomizer(original => { called = true; return null; });
            var request = new SimpleRequest();
            var actualResponse = sync ? call.Sync(request, null) : await call.Async(request, null);
            Assert.Same(response, actualResponse);
            Assert.False(called);
        }

        [Theory, CombinatorialData]
        public async Task WithCustomExceptions_UncustomizedException(bool sync)
        {
            var response = new SimpleResponse();
            var original = new RpcException(Status.DefaultCancelled);
            var call = FakeApiCall.Create<SimpleRequest, SimpleResponse>((req, options) => throw original);
            RpcException callbackException = null;
            call = call.WithExceptionCustomizer(x => { callbackException = x; return null; });
            var request = new SimpleRequest();
            // It's slightly awkward to call ThrowsAsync on its own and specify the lambda there.
            Func<Task<SimpleResponse>> func = async () => sync ? call.Sync(request, null) : await call.Async(request, null);
            var thrown = await Assert.ThrowsAsync<RpcException>(func);
            Assert.Same(original, thrown);
            Assert.Same(original, callbackException);
        }

        [Theory, CombinatorialData]
        public async Task WithCustomExceptions_CustomizedException(bool sync)
        {
            var response = new SimpleResponse();
            var original = new RpcException(Status.DefaultCancelled);
            var replacement = new RpcException(Status.DefaultCancelled, "This is the replacement");
            var call = FakeApiCall.Create<SimpleRequest, SimpleResponse>((req, options) => throw original);
            RpcException callbackException = null;
            call = call.WithExceptionCustomizer(x => { callbackException = x; return replacement; });
            var request = new SimpleRequest();
            // It's slightly awkward to call ThrowsAsync on its own and specify the lambda there.
            Func<Task<SimpleResponse>> func = async () => sync ? call.Sync(request, null) : await call.Async(request, null);
            var thrown = await Assert.ThrowsAsync<RpcException>(func);
            Assert.Same(replacement, thrown);
            Assert.Same(original, callbackException);
        }
    }
}
