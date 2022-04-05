/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Google.Api.Gax.Grpc.Tests
{
    public class ApiMetadataTest
    {
        [Fact]
        public void ConstructorWithDescriptorsProvider_LazyEvaluation()
        {
            var sequence = new CountingSequence();
            var descriptor = new ApiMetadata("Test", sequence);
            // By the time the constructor returns, it's already evaluated the sequence.
            Assert.Equal(1, sequence.EvaluationCount);

            // Fetching the first time doesn't change the evaluation count
            var protobufDescriptors = descriptor.ProtobufDescriptors;
            Assert.Equal(1, sequence.EvaluationCount);

            // Using the returned list doesn't change the evaluation count
            Assert.Equal(0, protobufDescriptors.Count());
            Assert.Equal(1, sequence.EvaluationCount);

            // Fetching a second time doesn't change the evaluation count
            protobufDescriptors = descriptor.ProtobufDescriptors;
            Assert.Equal(1, sequence.EvaluationCount);
        }

        [Fact]
        public void ConstructorWithDescriptors_SingleImmediateEvaluation()
        {
            var sequence = new CountingSequence();
            var descriptor = new ApiMetadata("Test", () => sequence);
            Assert.Equal(0, sequence.EvaluationCount);

            // Fetching the first time immediately evaluates the sequence
            var protobufDescriptors = descriptor.ProtobufDescriptors;
            Assert.Equal(1, sequence.EvaluationCount);

            // Using the returned list doesn't change the evaluation count
            Assert.Equal(0, protobufDescriptors.Count());
            Assert.Equal(1, sequence.EvaluationCount);

            // Fetching a second time doesn't change the evaluation count
            protobufDescriptors = descriptor.ProtobufDescriptors;
            Assert.Equal(1, sequence.EvaluationCount);
        }

        private class CountingSequence : IEnumerable<FileDescriptor>
        {
            public int EvaluationCount { get; private set; } = 0;

            public IEnumerator<FileDescriptor> GetEnumerator()
            {
                EvaluationCount++;
                yield break;
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
