/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests
{
    public class PartialDecodingStreamReaderTest
    {
        private static readonly string DataStr;
        static PartialDecodingStreamReaderTest()
        {
            var foo = new JObject
            {
                ["foo"] = 1
            };

            var bar = new JObject
            {
                ["bar"] = 2
            };

            DataStr = JsonConvert.SerializeObject( new [] { foo, bar }, Formatting.Indented);
        }

        /// <summary>
        /// Test coarse split data.
        /// </summary>
        [Fact]
        public async void DecodingStreamReaderTestByLine()
        {
            
            StreamReader reader = new MyStreamReader(DataStr.Split('\n'));
            var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

            var result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.True(result);
            Assert.NotNull(decodingReader.Current);
            Assert.Equal(decodingReader.Current["foo"], 1);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.True(result);
            Assert.NotNull(decodingReader.Current);
            Assert.Equal(decodingReader.Current["bar"], 2);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.False(result);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.False(result);
        }

        /// <summary>
        /// Test data split by characters.
        /// </summary>
        [Fact]
        public async void DecodingStreamReaderTestByChar()
        {
            
            StreamReader reader = new MyStreamReader(DataStr.Select(c =>  c.ToString()));
            var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

            var result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.True(result);
            Assert.NotNull(decodingReader.Current);
            Assert.Equal(decodingReader.Current["foo"], 1);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.True(result);
            Assert.NotNull(decodingReader.Current);
            Assert.Equal(decodingReader.Current["bar"], 2);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.False(result);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.False(result);
        }

        /// <summary>
        /// Test when data breaks off unexpectedly.
        /// </summary>
        [Fact]
        public async void DecodingStreamReaderTestIncomplete()
        {
            var s = DataStr.Split(',')[0]; // right after the first element ends
            StreamReader reader = new MyStreamReader(s.Split('\n'));
            var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

            var result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.True(result);
            Assert.NotNull(decodingReader.Current);
            Assert.Equal(decodingReader.Current["foo"], 1);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false));
            Assert.Contains("Closing `]` bracket not received after iterating through the stream.", ex.Message);
        }

        /// <summary>
        /// Test when data is empty array.
        /// </summary>
        [Fact]
        public async void DecodingStreamReaderTestEmpty()
        {
            StreamReader reader = new MyStreamReader(new[] {"[]"});
            var decodingReader = new PartialDecodingStreamReader<JObject>(Task.FromResult(reader), JObject.Parse);

            var result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.False(result);

            result = await decodingReader.MoveNext(CancellationToken.None).ConfigureAwait(false);
            Assert.False(result);
        }
    }

    /// <summary>
    /// A fake of a StreamReader emitting given strings
    /// </summary>
    internal class MyStreamReader : StreamReader
    {
        private readonly Queue<string> _queue;

        /// <summary>
        /// Cannot override EndOfStream, so have to nudge
        /// the base class to do this.
        /// Initialize it with a non-empty stream and later read
        /// that one to end.
        /// </summary>
        /// <param name="strings"></param>
        public MyStreamReader(IEnumerable<string> strings) : base(new MemoryStream(new byte[1]))
        {
            _queue = new Queue<string>(strings);
        }

        public override Task<int> ReadAsync(char[] buffer, int index, int count)
        {
            if (_queue.Count <= 0)
            {
                base.ReadToEnd(); // EndOfStream starts to return true
                return Task.FromResult(0);
            }

            var nextString = _queue.Dequeue();
            for (int i = 0; i < nextString.Length; i++)
            {
                buffer[i] = nextString[i];
            }

            return Task.FromResult(nextString.Length);
        }
    }
}
