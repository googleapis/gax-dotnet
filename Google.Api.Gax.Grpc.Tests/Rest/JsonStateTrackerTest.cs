/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static Google.Api.Gax.Grpc.Rest.JsonStateTracker;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class JsonStateTrackerTest
{
    [Theory]
    [InlineData("x")] // Top-level non-array
    [InlineData("{")] // Top-level object
    [InlineData("[x")] // Non-object in top array
    [InlineData("[}")] // Close object in top array
    [InlineData("[{]")] // Unbalanced array (close top array while in object)
    [InlineData("[{}x")] // Non-object in top array after first object
    [InlineData("[{\"\\x")] // String token with invalid escape sequence
    [InlineData("[],")] // Non-whitespace after top array
    [InlineData("[]{")] // Non-whitespace after top array
    [InlineData("[][")] // Non-whitespace after top array
    public void ErrorsDetected(string json)
    {
        // We expect that only the final character causes an error
        var tracker = new JsonStateTracker();

        for (int i = 0; i < json.Length - 1; i++)
        {
            var nextAction = tracker.Push(json[i]);
            Assert.NotEqual(NextAction.SignalError, nextAction);
        }
        Assert.Equal(NextAction.SignalError, tracker.Push(json.Last()));
    }

    // Note: this test uses the fact that we're really not validating that it's real JSON.
    // It makes life a lot simpler.

    [Theory]
    [InlineData("[]")]
    [InlineData("   \r\n\t []   \r\n\t ")]
    [InlineData("[{xyz}]", "{xyz}")]
    [InlineData("[{abc}, {def}]", "{abc}", "{def}")]
    [InlineData("[{{nested1}, {nested2}}, {response2}]", "{{nested1}, {nested2}}", "{response2}")]
    [InlineData("[{[array]}]", "{[array]}")]
    [InlineData(@"[{""\""\\\/\b\f\n\r\t\uabcd""}]", @"{""\""\\\/\b\f\n\r\t\uabcd""}")] // All valid escapes
    [InlineData("[{\"}}}}{}{}]]][[[\"}]", "{\"}}}}{}{}]]][[[\"}")] // Braces in strings don't have any meaning
    public void NormalBehavior(string json, params string[] expectedObjects)
    {
        var builder = new StringBuilder();
        var tracker = new JsonStateTracker();
        var actualObjects = new List<string>();
        bool endOfResponses = false;
        foreach (var c in json)
        {
            var nextAction = tracker.Push(c);
            switch (nextAction)
            {
                case NextAction.ParseResponse:
                    Assert.False(endOfResponses);
                    builder.Append(c);
                    actualObjects.Add(builder.ToString());
                    builder.Clear();
                    break;
                case NextAction.BufferAndContinue:
                    Assert.False(endOfResponses);
                    builder.Append(c);
                    break;
                case NextAction.IgnoreAndContinue:
                    break;
                case NextAction.SignalEndOfResponses:
                    Assert.False(endOfResponses);
                    endOfResponses = true;
                    break;
                default:
                    Assert.Fail($"Unexpected next action: {nextAction}");
                    break;
            }
        }
        Assert.True(endOfResponses);
        Assert.Equal(expectedObjects, actualObjects);
    }
}
