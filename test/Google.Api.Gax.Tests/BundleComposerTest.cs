/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Tests
{
    public class BundleComposerTest
    {
        private static readonly BundleComposer<BundlingRequest, BundlingResponse> s_composer = BundleComposer<BundlingRequest, BundlingResponse>.Create(
            request => request.Name,
            request => request.Entries,
            response => response.Entries);

        [Fact]
        public void SplitResponse_Success()
        {
            var requests = new[]
            {
                new BundlingRequest { Entries = { "e1", "e2" } },
                new BundlingRequest { },
                new BundlingRequest { Entries = { "e3" } },
            };

            var bigResponse = new BundlingResponse { Name = "resp", Entries = { "r1", "r2", "r3" } };
            var expectedResponses = new[]
            {
                new BundlingResponse { Name = "resp", Entries = { "r1", "r2" } },
                new BundlingResponse { Name = "resp" },
                new BundlingResponse { Name = "resp", Entries = { "r3" } }
            };
            var serializedBigResponse = bigResponse.ToByteString();
            Assert.Equal<BundlingResponse>(expectedResponses, s_composer.SplitResponse(requests, bigResponse));
            // Validate that the response hasn't been mutated.
            Assert.Equal(serializedBigResponse, bigResponse.ToByteString());
        }

        [Theory]
        [InlineData(4)]
        [InlineData(2)]
        public void SplitResponse_IncorrectResponseEntryCount(int responseEntryCount)
        {
            var requests = new[]
            {
                new BundlingRequest { Entries = { "e1", "e2" } },
                new BundlingRequest { },
                new BundlingRequest { Entries = { "e3" } },
            };

            var bigResponse = new BundlingResponse { Name = "resp", Entries = { Enumerable.Range(1, responseEntryCount).Select(index => $"r{index}") } };
            Assert.Throws<ArgumentException>(() => s_composer.SplitResponse(requests, bigResponse));
        }

        [Fact]
        public void ClearEntries()
        {
            var input = new BundlingRequest { Name = "name", Entries = { "e1", "e2" } };
            var expected = new BundlingRequest { Name = "name" };
            s_composer.ClearEntries(input);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddEntries()
        {
            var ongoing = new BundlingRequest { Name = "name", Entries = { "e1", "e2" } };
            var extra = new BundlingRequest { Name = "irrelevant", Entries = { "e3" } };
            var expected = new BundlingRequest { Name = "name", Entries = { "e1", "e2", "e3" } };
            s_composer.AddRequestEntries(ongoing, extra);
            Assert.Equal(expected, ongoing);
        }

        [Fact]
        public void GetEntryCount()
        {
            var input = new BundlingRequest { Name = "name", Entries = { "e1", "e2", "e3" } };
            Assert.Equal(3, s_composer.GetEntryCount(input));
            Assert.Equal(0, s_composer.GetEntryCount(new BundlingRequest()));
        }

        [Fact]
        public void RequestComparer()
        {
            var x = new BundlingRequest { Name = "name1", Entries = { "e1" } };
            var y = new BundlingRequest { Name = "name1", Entries = { "e2", "e3" } };
            var z = new BundlingRequest { Name = "name2", Entries = { "e1" } };
            var comparer = s_composer.RequestComparer;
            Assert.True(comparer.Equals(x, y));
            Assert.Equal(comparer.GetHashCode(x), comparer.GetHashCode(y));
            Assert.False(comparer.Equals(x, z));
        }
    }
}
