/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.IntegrationTests
{
    public class EmulatorSupportTests
    {
        [Fact]
        public void AppliesEmulator_Default()
        {
            Environment.SetEnvironmentVariable(DefaultEmulatorSupportClientBuilder.EmulatorEndpointEnvVar, "emulator.localhost");

            var clientBuilder = new DefaultEmulatorSupportClientBuilder();
            clientBuilder.EmulatorDetector.EmulatorDetection = EmulatorDetection.EmulatorOrProduction;
            clientBuilder.Endpoint = "any.other.endpoint.com";
            clientBuilder.CredentialsPath = "/wont/be/used.json";
            clientBuilder.Build();

            Assert.Equal("emulator.localhost", DefaultEmulatorSupportClientBuilder.EndpointUsedToCreateChannel);
            Assert.Equal(ChannelCredentials.Insecure, DefaultEmulatorSupportClientBuilder.CredentialsUsedToCreateChannel);

            Assert.Equal("any.other.endpoint.com", clientBuilder.Endpoint);
            Assert.Equal("/wont/be/used.json", clientBuilder.CredentialsPath);

            Environment.SetEnvironmentVariable(DefaultEmulatorSupportClientBuilder.EmulatorEndpointEnvVar, null);
        }

        public class DefaultEmulatorSupportClientBuilder : ClientBuilderBase<CallInvoker, EmulatorConfiguration, DefaultEmulatorSupportClientBuilder>
        {
            #region Test Code
            public const string EmulatorEndpointEnvVar = "FAKE_EMULATOR_ENDPOINT_ENV_VAR";
            public static string DefaultEndpoint { get; } = "default.nowhere.com";
            public static string[] DefaultScopes { get; } = new[] { "scope1", "scope2" };
            public ChannelPool ChannelPool { get; } = new ChannelPool(DefaultScopes);

            public static string EndpointUsedToCreateChannel { get; private set; }
            public static ChannelCredentials CredentialsUsedToCreateChannel { get; private set; }
            public static ChannelBase ChannelCreated { get; private set; }
            #endregion

            #region Code needed for default Emulator support
            public new EmulatorDetector<EmulatorConfiguration> EmulatorDetector => base.EmulatorDetector;

            public DefaultEmulatorSupportClientBuilder()
                : base(new EmulatorDetector<EmulatorConfiguration>(() => new EmulatorConfiguration(EmulatorEndpointEnvVar)))
            { }
            #endregion

            #region Code that always needs to be overwritten
            protected override CallInvoker BuildImpl() => CreateCallInvoker();

            protected override Task<CallInvoker> BuildImplAsync(CancellationToken cancellationToken) =>
                CreateCallInvokerAsync(cancellationToken);

            protected override ChannelPool GetChannelPool() => ChannelPool;

            protected override string GetDefaultEndpoint() => DefaultEndpoint;

            protected override IReadOnlyList<string> GetDefaultScopes() => DefaultScopes;

            private protected override ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials)
            {
                CredentialsUsedToCreateChannel = credentials;
                EndpointUsedToCreateChannel = endpoint;
                ChannelCreated = base.CreateChannel(endpoint, credentials);
                return ChannelCreated;
            }
            #endregion
        }

        [Fact]
        public void AppliesEmulator_Custom()
        {
            Environment.SetEnvironmentVariable(CustomEmulatorSupportClientBuilder.EmulatorEndpointEnvVar, "custom.emulator.localhost");

            var clientBuilder = new CustomEmulatorSupportClientBuilder();
            clientBuilder.EmulatorDetector.EmulatorDetection = EmulatorDetection.EmulatorOrProduction;
            clientBuilder.Endpoint = "any.other.endpoint.com";
            clientBuilder.CredentialsPath = "/wont/be/used.json";
            clientBuilder.Build();

            Assert.Equal("custom.emulator.localhost", CustomEmulatorSupportClientBuilder.EndpointUsedToCreateChannel);
            // A better test than this one should be written, but this is good enought for demonstration purposes.
            Assert.NotEqual(ChannelCredentials.Insecure, CustomEmulatorSupportClientBuilder.CredentialsUsedToCreateChannel);

            Assert.Equal("any.other.endpoint.com", clientBuilder.Endpoint);
            Assert.Equal("/wont/be/used.json", clientBuilder.CredentialsPath);

            Environment.SetEnvironmentVariable(CustomEmulatorSupportClientBuilder.EmulatorEndpointEnvVar, null);
        }

        #region Inherit from EmulatorConfiguration if the API emulator needs other than Endpoint.
        public class CustomEmulatorConfiguration : EmulatorConfiguration
        {
            private const string DummyServiceAccountCredentialFileContents = @"{
""private_key_id"": ""PRIVATE_KEY_ID"",
""private_key"": ""-----BEGIN PRIVATE KEY-----
MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAJJM6HT4s6btOsfe
2x4zrzrwSUtmtR37XTTi0sPARTDF8uzmXy8UnE5RcVJzEH5T2Ssz/ylX4Sl/CI4L
no1l8j9GiHJb49LSRjWe4Yx936q0Xj9H0R1HTxvjUPqwAsTwy2fKBTog+q1frqc9
o8s2r6LYivUGDVbhuUzCaMJsf+x3AgMBAAECgYEAi0FTXsu/zRswAUGaViQiHjrL
uU65BSHXNVjV/2fLNEKnGWGqpli68z1IXY+S2nwbUak7rnGsq9/0F6jtsW+hZbLk
KXUOuuExpeC5Kd6ngWX/f2jqmhlUabiQijU9cVk7pMq8EHkRtvlosnMTUAEzempu
QUPwn1PZHhmJkBvZ4lECQQDCErrxl+e3BwUDcS0yVEEmCNSG6xdXs2878b8rzbe7
3Mmi6SuuOLi3PU92J+j+f/MOdtYrk13mEDdYmd5dhrt5AkEAwPvDEsDT/W4y4h5n
gv1awGBA5aLFE1JNWM/Gwn4D1cGpEDHKFREaBtxMDCASpHJuw8r7zUywpKhmBZcf
GS37bwJANdSAKfbafLfjuhqwUJ9yGpykZm/a36aTmerp/bpn1iHdg+RtCzwMcDb/
TWSwibbvsflgWmHbz657y4WSWhq+8QJAWrpCNN/ZCk2zuGDo80lfUBAwkoVat8G6
wWU1oZyS+vzIGef+hLb8kHsjeZPej9eIwZ39kcBbT54oELrCkRjwGwJAQ8V2A7lT
ZUp8AsbVqF6rbLiiUfJMo2btGclQu4DEVyS+ymFA65tXDLUuR9EDqJYdqHNZJ5B8
4Z5p2prkjWTLcA==
-----END PRIVATE KEY-----"",
""client_email"": ""CLIENT_EMAIL"",
""client_id"": ""CLIENT_ID"",
""type"": ""service_account""}";

            public string JsonCredential { get; } = DummyServiceAccountCredentialFileContents;

            public override bool IsValid => base.IsValid && !string.IsNullOrEmpty(JsonCredential);

            public CustomEmulatorConfiguration(string emulatorEndpointVariable)
                : base(emulatorEndpointVariable)
            { }
        }
        #endregion

        public class CustomEmulatorSupportClientBuilder : ClientBuilderBase<CallInvoker, CustomEmulatorConfiguration, CustomEmulatorSupportClientBuilder>
        {
            #region Test code
            public const string EmulatorEndpointEnvVar = "FAKE_EMULATOR_ENDPOINT_ENV_VAR";
            public static string DefaultEndpoint { get; } = "custom.nowhere.com";
            public static string[] DefaultScopes { get; } = new[] { "scope1", "scope2" };
            public ChannelPool ChannelPool { get; } = new ChannelPool(DefaultScopes);

            public static string EndpointUsedToCreateChannel { get; private set; }
            public static ChannelCredentials CredentialsUsedToCreateChannel { get; private set; }
            public static ChannelBase ChannelCreated { get; private set; }
            #endregion

            #region Code needed for custom Emulator support
            public new EmulatorDetector<CustomEmulatorConfiguration> EmulatorDetector => base.EmulatorDetector;

            public CustomEmulatorSupportClientBuilder()
                : base(new EmulatorDetector<CustomEmulatorConfiguration>(() => new CustomEmulatorConfiguration(EmulatorEndpointEnvVar)))
            { }

            protected override CustomEmulatorSupportClientBuilder WithEmulatorConfiguration(CustomEmulatorConfiguration emulatorConfiguration)
            {
                CustomEmulatorSupportClientBuilder builder = base.WithEmulatorConfiguration(emulatorConfiguration);

                // Let's clean up all conflicting settings on the clone.
                builder.ChannelCredentials = null; // base set this to Insecure.

                builder.JsonCredentials = emulatorConfiguration.JsonCredential;

                return builder;
            }
            #endregion

            #region Code that always needs to be overwritten
            protected override CallInvoker BuildImpl() => CreateCallInvoker();

            protected override Task<CallInvoker> BuildImplAsync(CancellationToken cancellationToken) =>
                CreateCallInvokerAsync(cancellationToken);

            protected override ChannelPool GetChannelPool() => ChannelPool;

            protected override string GetDefaultEndpoint() => DefaultEndpoint;

            protected override IReadOnlyList<string> GetDefaultScopes() => DefaultScopes;

            private protected override ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials)
            {
                CredentialsUsedToCreateChannel = credentials;
                EndpointUsedToCreateChannel = endpoint;
                ChannelCreated = base.CreateChannel(endpoint, credentials);
                return ChannelCreated;
            }
            #endregion
        }
    }
}
