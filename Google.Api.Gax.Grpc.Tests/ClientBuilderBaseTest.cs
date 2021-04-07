/*
 * Copyright 2020 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ClientBuilderBaseTest
    {
        /// <summary>
        /// Tests for <see cref="ClientBuilderBase{TClient}.GetEmulatorEnvironment"/>.
        /// Separated into their own class as there are quite a few of them...
        /// </summary>
        public class GetEmulatorEnvironmentTest
        {
            private const string Required1 = "required1";
            private const string Required2 = "required2";
            private const string Optional1 = "optional1";
            private const string Optional2 = "optional2";
            private const string OtherVariable = "other";
            private static readonly string[] RequiredVariables = { Required1, Required2 };
            private static readonly string[] AllVariables = { Required1, Required2, Optional1, Optional2 };

            [Fact]
            public void DetectionIsNone_NoVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.None);
                var environment = CreateEnvironmentDictionary();
                Assert.Null(builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsNone_AllVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.None);
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2);
                Assert.Null(builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsProductionOnly_NoVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.ProductionOnly);
                var environment = CreateEnvironmentDictionary();
                Assert.Null(builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsProductionOnly_RequiredVariable()
            {
                var builder = new FakeBuilder(EmulatorDetection.ProductionOnly);
                var environment = CreateEnvironmentDictionary(Required1);
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsProductionOnly_OptionalVariable()
            {
                var builder = new FakeBuilder(EmulatorDetection.ProductionOnly);
                var environment = CreateEnvironmentDictionary(Optional1);
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsEmulatorOnly_NoVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly);
                var environment = CreateEnvironmentDictionary();
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsEmulatorOnly_IncompleteSomeRequiredVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly);
                var environment = CreateEnvironmentDictionary(Required1);
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void DetectionIsEmulatorOnly_RequiredVariableIsNull(string required2Value)
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly);
                var environment = CreateEnvironmentDictionary(Required1);
                environment[Required2] = required2Value;
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsEmulatorOnly_AllRequiredVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly);
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1);
                var result = builder.GetEmulatorEnvironment(environment);

                var expected = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2);
                // The Optional2 key should be present, but with a null value
                expected[Optional2] = null;
                Assert.Equal(expected, result);
            }

            [Fact]
            public void DetectionIsEmulatorOnly_AllVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly);
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2, OtherVariable);
                var result = builder.GetEmulatorEnvironment(environment);
                var expected = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void DetectionIsEmulatorOnly_AllVariables_WithAdditionalSettings()
            {
                // With EmulatorOnly, it's invalid to specify credentials etc.
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly) { CredentialsPath = "foo" };
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2, OtherVariable);
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void DetectionIsEmulatorOnly_NullAndWhitespaceConvertedToNull(string optional2Value)
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOnly);
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2);
                environment[Optional2] = optional2Value;
                var result = builder.GetEmulatorEnvironment(environment);
                // null, empty and whitespace are all converted to null in the returned environment.
                Assert.Null(result[Optional2]);
            }

            [Fact]
            public void DetectionIsEmulatorOrProduction_NoVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOrProduction);
                var environment = CreateEnvironmentDictionary();
                Assert.Null(builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsEmulatorOrProduction_PartialRequiredVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOrProduction);
                var environment = CreateEnvironmentDictionary(Required1);
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsEmulatorOrProduction_JustOptionalVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOrProduction);
                var environment = CreateEnvironmentDictionary(Optional1, Optional2);
                Assert.Throws<InvalidOperationException>(() => builder.GetEmulatorEnvironment(environment));
            }

            [Fact]
            public void DetectionIsEmulatorOrProduction_AllVariables()
            {
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOrProduction);
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2, OtherVariable);
                var result = builder.GetEmulatorEnvironment(environment);
                var expected = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void DetectionIsEmulatorOrProduction_AllVariables_WithAdditionalSettings()
            {
                // With EmulatorOrProduction, it's valid to specify credentials etc.
                var builder = new FakeBuilder(EmulatorDetection.EmulatorOrProduction) { CredentialsPath = "foo" };
                var environment = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2, OtherVariable);
                var result = builder.GetEmulatorEnvironment(environment);
                var expected = CreateEnvironmentDictionary(Required1, Required2, Optional1, Optional2);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void GetChannelOptions_UsesGrpcChannelOptions()
            {
                var builder = new FakeBuilder(EmulatorDetection.None);
                var defaultOptions = builder.GetChannelOptions();
                // Used to check the override behavior
                var defaultKeepAliveTime = defaultOptions.KeepAliveTime.Value;
                // Used to check the defaulting behavior
                var defaultEnableServiceConfigResolution = defaultOptions.EnableServiceConfigResolution.Value;

                var newKeepAliveTime = defaultKeepAliveTime + TimeSpan.FromMinutes(10);
                builder.GrpcChannelOptions = GrpcChannelOptions.Empty
                    .WithKeepAliveTime(newKeepAliveTime)
                    .WithMaxReceiveMessageSize(1000);

                var resultOptions = builder.GetChannelOptions();
                // Specified in both
                Assert.Equal(newKeepAliveTime, resultOptions.KeepAliveTime);
                // Specified only in default options
                Assert.Equal(defaultEnableServiceConfigResolution, resultOptions.EnableServiceConfigResolution);
                // Specified only in client-provided options
                Assert.Equal(1000, resultOptions.MaxReceiveMessageSize);
                // Not specified in any options
                Assert.Null(resultOptions.MaxSendMessageSize);
            }

            /// <summary>
            /// Creates a dictionary where each of the specified variables maps to its own name with a "-value" suffix, for simplicity.
            /// </summary>
            private static Dictionary<string, string> CreateEnvironmentDictionary(params string[] variables) =>
                variables.ToDictionary(key => key, key => $"{key}-value");

            private class FakeBuilder : ClientBuilderBase<string>
            {
                internal FakeBuilder(EmulatorDetection detection) =>
                    EmulatorDetection = detection;

                /// <summary>
                /// Convenience method for GetEmulatorEnvironment testing, which plu
                /// </summary>
                internal Dictionary<string, string> GetEmulatorEnvironment(Dictionary<string, string> environment) =>
                    GetEmulatorEnvironment(RequiredVariables, AllVariables,
                        key => environment.TryGetValue(key, out var value) ? value : null);

                public new GrpcChannelOptions GetChannelOptions() => base.GetChannelOptions();
                protected override GrpcAdapter DefaultGrpcAdapter => throw new NotImplementedException();
                public override string Build() => throw new NotImplementedException();
                public override Task<string> BuildAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
                protected override ChannelPool GetChannelPool() => throw new NotImplementedException();
                protected override string GetDefaultEndpoint() => throw new NotImplementedException();
                protected override IReadOnlyList<string> GetDefaultScopes() => throw new NotImplementedException();
            }
        }
    }
}
