/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Gax.Grpc.Rest.Tests;

public class ResumableUploadStreamTest
{
    private class NonSeekableStream : Stream
    {
        private readonly Stream _underlying;

        public NonSeekableStream(Stream underlying)
        {
            _underlying = underlying;
        }

        public bool IsDisposed { get; private set; }

        public override bool CanRead => _underlying.CanRead;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush() => _underlying.Flush();

        public override int Read(byte[] buffer, int offset, int count) =>
            _underlying.Read(buffer, offset, count);

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            _underlying.ReadAsync(buffer, offset, count, cancellationToken);

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                IsDisposed = true;
                _underlying.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    [Fact]
    public void Factory_CreatesCorrectImplementationType()
    {
        byte[] data = Encoding.UTF8.GetBytes("Test data");
        using var seekableMs = new MemoryStream(data);
        using var seekableStream = ResumableUploadStream.Create(seekableMs);
        Assert.IsType<SeekableResumableUploadStream>(seekableStream);

        using var nonSeekableMs = new MemoryStream(data);
        using var nonSeekableStreamWrapper = new NonSeekableStream(nonSeekableMs);
        using var bufferedStream = ResumableUploadStream.Create(nonSeekableStreamWrapper);
        Assert.IsType<BufferedResumableUploadStream>(bufferedStream);
    }

    [Fact]
    public async Task SeekableStream_BasicPropertiesAndSeeking()
    {
        byte[] data = Encoding.UTF8.GetBytes("Hello World Resumable Upload");
        using var memoryStream = new MemoryStream(data);
        using var resumableStream = ResumableUploadStream.Create(memoryStream);

        Assert.Equal(data.Length, resumableStream.Length);
        Assert.True(resumableStream.TryRewind(10));
        Assert.False(resumableStream.TryRewind(-1));
        Assert.False(resumableStream.TryRewind(100));

        byte[] readBuffer = new byte[5];
        int read = await resumableStream.ReadAsync(readBuffer, 0, 5, CancellationToken.None);
        Assert.Equal(5, read);

        Assert.True(resumableStream.TryRewind(0));

        read = await resumableStream.ReadAsync(readBuffer, 0, 5, CancellationToken.None);
        Assert.Equal(5, read);
        Assert.Equal("Hello", Encoding.UTF8.GetString(readBuffer));
    }

    [Fact]
    public async Task UnseekableStream_BufferingAndRewinding()
    {
        byte[] data = Encoding.UTF8.GetBytes("0123456789ABCDEFGHIJKLMNOPQRST");
        using var memoryStream = new MemoryStream(data);
        var nonSeekable = new NonSeekableStream(memoryStream);

        using var resumableStream = ResumableUploadStream.Create(nonSeekable, bufferCapacity: 10);

        Assert.Null(resumableStream.Length);

        // Read 8 bytes: "01234567"
        byte[] buf = new byte[8];
        int read = await resumableStream.ReadAsync(buf, 0, 8, CancellationToken.None);
        Assert.Equal(8, read);
        Assert.Equal("01234567", Encoding.UTF8.GetString(buf));

        // Rewind to 0
        Assert.True(resumableStream.TryRewind(0));

        // Re-read 8 bytes from ring buffer
        byte[] buf2 = new byte[8];
        read = await resumableStream.ReadAsync(buf2, 0, 8, CancellationToken.None);
        Assert.Equal(8, read);
        Assert.Equal("01234567", Encoding.UTF8.GetString(buf2));

        // Read 8 more bytes from underlying stream: "89ABCDEF"
        read = await resumableStream.ReadAsync(buf, 0, 8, CancellationToken.None);
        Assert.Equal(8, read);
        Assert.Equal("89ABCDEF", Encoding.UTF8.GetString(buf));

        // Buffer capacity is 10, so buffered range is [6, 16]
        Assert.True(resumableStream.TryRewind(6));
        Assert.False(resumableStream.TryRewind(5));

        // Read 10 bytes starting at position 6 (returns "6789ABCDEF")
        byte[] buf10 = new byte[10];
        read = await resumableStream.ReadAsync(buf10, 0, 10, CancellationToken.None);
        Assert.Equal(10, read);
        Assert.Equal("6789ABCDEF", Encoding.UTF8.GetString(buf10));
    }

    [Fact]
    public async Task UnseekableStream_LengthReturnsValueAfterEof()
    {
        byte[] data = Encoding.UTF8.GetBytes("Data");
        using var memoryStream = new MemoryStream(data);
        var nonSeekable = new NonSeekableStream(memoryStream);
        using var resumableStream = ResumableUploadStream.Create(nonSeekable, bufferCapacity: 10);

        Assert.Null(resumableStream.Length);

        // Read until EOF
        byte[] buf = new byte[10];
        int read = await resumableStream.ReadAsync(buf, 0, 10, CancellationToken.None);
        Assert.Equal(4, read);
        int eofRead = await resumableStream.ReadAsync(buf, 0, 10, CancellationToken.None);
        Assert.Equal(0, eofRead);

        // Now Length returns 4
        Assert.Equal(4, resumableStream.Length);
    }

    [Fact]
    public void Dispose_HonorsLeaveOpenDefaultTrue()
    {
        byte[] data = Encoding.UTF8.GetBytes("Data");
        var memoryStream1 = new MemoryStream(data);
        var nonSeekable1 = new NonSeekableStream(memoryStream1);
        var stream1 = ResumableUploadStream.Create(nonSeekable1); // leaveOpen default true
        stream1.Dispose();
        Assert.False(nonSeekable1.IsDisposed);
        nonSeekable1.Dispose();

        var memoryStream2 = new MemoryStream(data);
        var nonSeekable2 = new NonSeekableStream(memoryStream2);
        var stream2 = ResumableUploadStream.Create(nonSeekable2, leaveOpen: false);
        stream2.Dispose();
        Assert.True(nonSeekable2.IsDisposed);
    }
}
