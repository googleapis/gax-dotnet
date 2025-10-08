/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Auth;
using Grpc.Core;
using System;
using Xunit;
using static Google.Api.Gax.Testing.TestCredentials;

namespace Google.Api.Gax.Grpc.Tests
{
    public class GrpcNetClientAdapterTest
    {
        [Fact]
        public void ConvertOptions_Empty()
        {
            var gaxOptions = GrpcChannelOptions.Empty;
            var result = GrpcNetClientAdapter.ConvertOptions(ChannelCredentials.Insecure, gaxOptions);
            Assert.Same(ChannelCredentials.Insecure, result.Credentials);
        }

        [Fact]
        public void ConvertOptions_CustomOptions_Ignored()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithCustomOption("foo", "bar");
            var result = GrpcNetClientAdapter.ConvertOptions(ChannelCredentials.Insecure, gaxOptions);
            Assert.Same(ChannelCredentials.Insecure, result.Credentials);
        }

        [Fact]
        public void ConvertOptions_EnableServiceConfigResolutionTrue_Throws()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithEnableServiceConfigResolution(true);
            Assert.Throws<ArgumentException>(() => GrpcNetClientAdapter.ConvertOptions(ChannelCredentials.Insecure, gaxOptions));
        }

        [Fact]
        public void ConvertOptions_IgnoredOptions_Valid()
        {
            var gaxOptions = GrpcChannelOptions.Empty
                .WithEnableServiceConfigResolution(false) // Ignored if false; throws when true
                .WithPrimaryUserAgent("primary user agent")
                .WithKeepAliveTime(TimeSpan.FromMinutes(1));
            GrpcNetClientAdapter.ConvertOptions(ChannelCredentials.Insecure, gaxOptions);
        }

        [Fact]
        public void ConvertOptions_MaxSendMessageSize()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithMaxSendMessageSize(100);
            var result = GrpcNetClientAdapter.ConvertOptions(ChannelCredentials.Insecure, gaxOptions);
            Assert.Equal(100, result.MaxSendMessageSize);
        }

        [Fact]
        public void ConvertOptions_MaxReceiveMessageSize()
        {
            var gaxOptions = GrpcChannelOptions.Empty.WithMaxReceiveMessageSize(100);
            var result = GrpcNetClientAdapter.ConvertOptions(ChannelCredentials.Insecure, gaxOptions);
            Assert.Equal(100, result.MaxReceiveMessageSize);
        }

        [Theory]
        [InlineData("10.20.30.40", true, "https://10.20.30.40")]
        [InlineData("10.20.30.40", false, "http://10.20.30.40")]
        [InlineData("10.20.30.40:1234", true, "https://10.20.30.40:1234")]
        [InlineData("10.20.30.40:1234", false, "http://10.20.30.40:1234")]
        [InlineData("http://10.20.30.40", true, "http://10.20.30.40")]
        [InlineData("http://10.20.30.40", false, "http://10.20.30.40")]
        [InlineData("https://10.20.30.40", true, "https://10.20.30.40")]
        [InlineData("https://10.20.30.40:1234", true, "https://10.20.30.40:1234")]
        [InlineData("service.googleapis.com", true, "https://service.googleapis.com")]
        [InlineData("https://service.googleapis.com", true, "https://service.googleapis.com")]
        [InlineData("service.googleapis.com:1234", true, "https://service.googleapis.com:1234")]
        [InlineData("https://service.googleapis.com:1234", true, "https://service.googleapis.com:1234")]
        public void ConvertEndpoint(string input, bool secureCredentials, string expectedOutput)
        {
            Assert.Equal(expectedOutput, GrpcNetClientAdapter.ConvertEndpoint(input, secureCredentials));
        }

        public static TheoryData<ChannelCredentials, bool> SecureCredentialsDetectionData = new TheoryData<ChannelCredentials, bool>
        {
            { ChannelCredentials.SecureSsl, true },
            { ChannelCredentials.Insecure, false },
            { CreateTestServiceAccountCredential().ToChannelCredentials(), true }
        };

        [Theory]
        [MemberData(nameof(SecureCredentialsDetectionData))]
        public void SecureCredentialsDetection_Insecure(ChannelCredentials credentials, bool expectedResult)
        {
            var actualResult = GrpcNetClientAdapter.SecureChannelDetector.AreCredentialsSecure(credentials);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
