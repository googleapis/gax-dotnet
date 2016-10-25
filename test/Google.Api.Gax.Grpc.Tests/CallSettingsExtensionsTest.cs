/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class CallSettingsExtensionsTest
    {
        [Fact]
        public void MergedWith_BothNull()
        {
            CallSettings settings = null;
            Assert.Null(settings.MergedWith(null));
        }

        [Fact]
        public void MergedWith_OneNull()
        {
            CallSettings settings1 = new CallSettings(null, null, null, null, null, null);
            CallSettings settings2 = null;
            Assert.Same(settings1, settings1.MergedWith(settings2));
            Assert.Same(settings1, settings2.MergedWith(settings1));
        }

        [Fact]
        public void MergedWith_BothNonNull()
        {
            CallTiming timing1 = CallTiming.FromExpiration(Expiration.None);
            CallTiming timing2 = CallTiming.FromDeadline(DateTime.UtcNow);

            CancellationToken token = new CancellationTokenSource().Token;

            var settings1 = new CallSettings(token, null, timing1, null, null, null);
            var settings2 = new CallSettings(null, null, timing2, null, null, null);
            var merged = settings1.MergedWith(settings2);
            Assert.Equal(token, merged.CancellationToken);
            Assert.Same(timing2, merged.Timing);
        }

        [Fact]
        public void WithCancellationToken()
        {
            CancellationToken token1 = new CancellationTokenSource().Token;
            CallTiming timing = CallTiming.FromExpiration(Expiration.None);
            var original = new CallSettings(token1, null, timing, null, null, null);

            CancellationToken token2 = new CancellationTokenSource().Token;
            var result = original.WithCancellationToken(token2);
            Assert.Same(timing, result.Timing);
            Assert.Equal(token2, result.CancellationToken);
        }

        [Fact]
        public void WithCallTiming_NonNull()
        {
            CallTiming timing1 = CallTiming.FromExpiration(Expiration.None);
            CallTiming timing2 = CallTiming.FromDeadline(DateTime.UtcNow);

            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, null, timing1, null, null, null);
            var result = original.WithCallTiming(timing2);
            Assert.Same(timing2, result.Timing);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithCallTiming_NullSettings()
        {
            CallSettings noSettings = null;
            Assert.Null(noSettings.WithCallTiming(null));
            CallTiming timing = CallTiming.FromExpiration(Expiration.None);
            var result = noSettings.WithCallTiming(timing);
            Assert.Same(timing, result.Timing);
        }

        [Fact]
        public void WithCallTiming_NullTiming()
        {
            CallTiming timing = CallTiming.FromExpiration(Expiration.None);
            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, null, timing, null, null, null);
            var result = original.WithCallTiming(null);
            Assert.Null(result.Timing);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithCallCredentials_NonNull()
        {
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credentials1 = CallCredentials.FromInterceptor(interceptor);
            var credentials2 = CallCredentials.FromInterceptor(interceptor);
            Assert.NotSame(credentials1, credentials2);

            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, credentials1, null, null, null, null);
            var result = original.WithCallCredentials(credentials2);
            Assert.Same(credentials2, result.Credentials);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithCallCredentials_NullSettings()
        {
            CallSettings noSettings = null;
            Assert.Null(noSettings.WithCallCredentials(null));
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credentials = CallCredentials.FromInterceptor(interceptor);
            var result = noSettings.WithCallCredentials(credentials);
            Assert.Same(credentials, result.Credentials);
        }

        [Fact]
        public void WithCallCredentials_NullCredentials()
        {
            AsyncAuthInterceptor interceptor = (context, metadata) => Task.Delay(0);
            var credentials = CallCredentials.FromInterceptor(interceptor);
            CancellationToken token = new CancellationTokenSource().Token;

            var original = new CallSettings(token, credentials, null, null, null, null);
            var result = original.WithCallCredentials(null);
            Assert.Null(result.Credentials);
            Assert.Equal(token, result.CancellationToken);
        }

        [Fact]
        public void WithHeader_NullSettings()
        {
            CallSettings settings = null;
            var result = settings.WithHeader("name", "value");
            var metadata = new Metadata();
            result.HeaderMutation(metadata);
            Assert.Equal("name", metadata[0].Key);
            Assert.Equal("value", metadata[0].Value);
        }

        [Fact]
        public void WithHeader_NonNullSettings()
        {
            CallSettings settings = CallSettings.FromHeader("name1", "value1");
            var result = settings.WithHeader("name2", "value2");
            var metadata = new Metadata();
            result.HeaderMutation(metadata);
            Assert.Equal("name1", metadata[0].Key);
            Assert.Equal("value1", metadata[0].Value);
            Assert.Equal("name2", metadata[1].Key);
            Assert.Equal("value2", metadata[1].Value);
        }
    }
}
