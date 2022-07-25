/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Api.Gax.Grpc.Tests;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static Google.Api.Gax.Grpc.Rest.Tests.Test;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class HttpRuleTranscoderTest
{
    private static readonly List<string> SkippedTranscodingTests = new()
    {
    };

    private static TestFile s_testFile = LoadTestFile();
    public static IEnumerable<object[]> Tests => s_testFile.Tests
        .Select(t => new object[] { new SerializableTest(t) });

    private static TestFile LoadTestFile()
    {
        // TODO: Adjust when we move the tests to the google-cloud-conformance repo
        var rootDirectory = ConformanceTestData.FindRepositoryRootDirectory();
        var path = Path.Combine(rootDirectory, "Google.Api.Gax.Grpc.Tests", "Rest", "transcoder_tests.json");
        string json = File.ReadAllText(path);
        return TestFile.Parser.ParseJson(json);
    }

    [SkippableTheory]
    [MemberData(nameof(Tests))]
    public void Transcode(SerializableTest testWrapper)
    {
        var test = testWrapper.Test;
        Skip.If(SkippedTranscodingTests.Contains(test.Name));

        var rule = test.RuleCase switch
        {
            RuleOneofCase.InlineRule => test.InlineRule,
            RuleOneofCase.RuleName => s_testFile.NamedRules[test.RuleName],
            _ => throw new ArgumentException("No rule specified")
        };

        var requestMessageDescriptor = TranscoderTestReflection.Descriptor.FindTypeByName<MessageDescriptor>(test.RequestMessageName);
        var request = test.Request is null ? null : JsonParser.Default.Parse(test.Request.ToString(), requestMessageDescriptor);

        switch (test.ExpectedResultCase)
        {
            case ExpectedResultOneofCase.InvalidRule:
                Assert.Throws<ArgumentException>(CreateTranscoder);
                break;
            case ExpectedResultOneofCase.NonmatchingRequest:
                Assert.NotNull(request);
                Assert.Null(CreateTranscoder().Transcode(request));
                break;
            case ExpectedResultOneofCase.Success:
                Assert.NotNull(request);
                var actualResult = CreateTranscoder().Transcode(request);
                var expectedResult = test.Success;
                Assert.Equal(expectedResult.Method, actualResult.Method.Method);
                Assert.Equal(expectedResult.Uri, actualResult.GetRelativeUri());
                var actualBody = actualResult.Body is null ? null : Struct.Parser.ParseJson(actualResult.Body);
                Assert.Equal(expectedResult.Body, actualBody);
                break;
            default:
                throw new ArgumentException($"Unknown expected result case: {test.ExpectedResultCase}");
        }

        HttpRuleTranscoder CreateTranscoder() => new HttpRuleTranscoder(test.Name, requestMessageDescriptor, rule);
    }
}

public class SerializableTest : IXunitSerializable
{
    public Test Test { get; private set; }

    // Used in deserialization
    public SerializableTest() { }

    public SerializableTest(Test test) => Test = test;

    public void Deserialize(IXunitSerializationInfo info) =>
        Test = Test.Parser.ParseFrom(info.GetValue<byte[]>(nameof(Test)));

    public void Serialize(IXunitSerializationInfo info) =>
        info.AddValue(nameof(Test), Test.ToByteArray());

    public override string ToString() => Test?.Name ?? "(Unknown)";
}

