/*
 * Copyright 2026 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Rest;

/// <summary>
/// Defines the contract for streams used in resumable upload operations,
/// supporting reading, position rewinding, and optional length metadata.
/// </summary>
internal interface IResumableUploadStream : IDisposable
{
    /// <summary>
    /// Gets the total length of the stream in bytes, if known; otherwise <c>null</c>.
    /// </summary>
    long? Length { get; }

    /// <summary>
    /// Attempts to position the stream to the specified absolute <paramref name="targetOffset"/>.
    /// </summary>
    /// <param name="targetOffset">The target absolute stream position to rewind or seek to.</param>
    /// <returns><c>true</c> if the stream was successfully positioned; otherwise <c>false</c>.</returns>
    bool TryRewind(long targetOffset);

    /// <summary>
    /// Reads a sequence of bytes asynchronously from the stream.
    /// </summary>
    /// <param name="buffer">An array of bytes to store the read data.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing data.</param>
    /// <param name="count">The maximum number of bytes to read.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The total number of bytes read into the buffer.</returns>
    Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
}

/// <summary>
/// Factory for creating <see cref="IResumableUploadStream"/> instances.
/// </summary>
internal static class ResumableUploadStream
{
    /// <summary>
    /// Creates an <see cref="IResumableUploadStream"/> wrapping the specified <paramref name="underlyingStream"/>.
    /// Returns a <see cref="SeekableResumableUploadStream"/> if the stream is natively seekable,
    /// or a <see cref="BufferedResumableUploadStream"/> if it is unseekable.
    /// </summary>
    /// <param name="underlyingStream">The underlying stream to read from.</param>
    /// <param name="bufferCapacity">
    /// The ring buffer capacity for unseekable streams (defaults to <see cref="ResumableUploadSettings.DefaultChunkSize"/>).
    /// </param>
    /// <param name="leaveOpen"><c>true</c> to leave the underlying stream open upon disposal; otherwise <c>false</c>.</param>
    /// <returns>An <see cref="IResumableUploadStream"/> instance.</returns>
    internal static IResumableUploadStream Create(
        Stream underlyingStream,
        long bufferCapacity = ResumableUploadSettings.DefaultChunkSize,
        bool leaveOpen = true)
    {
        GaxPreconditions.CheckNotNull(underlyingStream, nameof(underlyingStream));

        return underlyingStream.CanSeek
            ? new SeekableResumableUploadStream(underlyingStream, leaveOpen)
            : new BufferedResumableUploadStream(underlyingStream, bufferCapacity, leaveOpen);
    }
}

/// <summary>
/// Pure pass-through stream wrapper for natively seekable streams.
/// </summary>
internal sealed class SeekableResumableUploadStream : IResumableUploadStream
{
    private readonly Stream _underlyingStream;
    private readonly bool _leaveOpen;

    internal SeekableResumableUploadStream(Stream underlyingStream, bool leaveOpen = true)
    {
        _underlyingStream = GaxPreconditions.CheckNotNull(underlyingStream, nameof(underlyingStream));
        GaxPreconditions.CheckArgument(underlyingStream.CanRead, nameof(underlyingStream), "Stream must be readable.");
        GaxPreconditions.CheckArgument(underlyingStream.CanSeek, nameof(underlyingStream), "Stream must be seekable.");
        _leaveOpen = leaveOpen;
    }

    public long? Length => _underlyingStream.Length;

    public bool TryRewind(long targetOffset)
    {
        if (targetOffset < 0 || targetOffset > _underlyingStream.Length)
        {
            return false;
        }

        _underlyingStream.Seek(targetOffset, SeekOrigin.Begin);
        return true;
    }

    public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
        _underlyingStream.ReadAsync(buffer, offset, count, cancellationToken);

    public void Dispose()
    {
        if (!_leaveOpen)
        {
            _underlyingStream.Dispose();
        }
    }
}

/// <summary>
/// Stream wrapper for unseekable streams that maintains a sliding ring buffer
/// allowing rewinding up to a specified buffer capacity.
/// </summary>
internal sealed class BufferedResumableUploadStream : IResumableUploadStream
{
    /// <summary>
    /// The unseekable underlying content stream.
    /// </summary>
    private readonly Stream _underlyingStream;

    /// <summary>
    /// The maximum capacity in bytes of the sliding ring buffer.
    /// </summary>
    private readonly int _bufferCapacity;

    /// <summary>
    /// Indicates whether to leave <see cref="_underlyingStream"/> open upon disposal.
    /// </summary>
    private readonly bool _leaveOpen;

    /// <summary>
    /// Circular byte array storing recently read bytes up to <see cref="_bufferCapacity"/>.
    /// Set to <c>null</c> upon disposal to release memory.
    /// </summary>
    private byte[] _ringBuffer;

    /// <summary>
    /// Array index in <see cref="_ringBuffer"/> corresponding to <see cref="_bufferedStartPosition"/>.
    /// </summary>
    private int _ringBufferStart;

    /// <summary>
    /// Total number of valid bytes currently stored inside <see cref="_ringBuffer"/>.
    /// </summary>
    private int _ringBufferCount;

    /// <summary>
    /// Absolute stream position of the oldest byte currently residing in <see cref="_ringBuffer"/>.
    /// </summary>
    private long _bufferedStartPosition;

    /// <summary>
    /// Total cumulative bytes read from <see cref="_underlyingStream"/> so far.
    /// </summary>
    private long _underlyingPosition;

    /// <summary>
    /// Current virtual reading position of this stream wrapper.
    /// When <see cref="_currentPosition"/> is less than <see cref="_underlyingPosition"/>,
    /// read requests are satisfied directly from <see cref="_ringBuffer"/>.
    /// </summary>
    private long _currentPosition;

    /// <summary>
    /// Flag indicating whether end-of-stream (EOF) has been reached on <see cref="_underlyingStream"/>.
    /// </summary>
    private bool _isEofReached;

    /// <summary>
    /// Single byte peeked ahead from <see cref="_underlyingStream"/> to test for EOF
    /// without pushing into <see cref="_ringBuffer"/> or advancing <see cref="_underlyingPosition"/>.
    /// </summary>
    private byte? _extraByte;

    internal BufferedResumableUploadStream(
        Stream underlyingStream,
        long bufferCapacity = ResumableUploadSettings.DefaultChunkSize,
        bool leaveOpen = true)
    {
        _underlyingStream = GaxPreconditions.CheckNotNull(underlyingStream, nameof(underlyingStream));
        GaxPreconditions.CheckArgument(underlyingStream.CanRead, nameof(underlyingStream), "Stream must be readable.");
        GaxPreconditions.CheckArgument(bufferCapacity >= 0, nameof(bufferCapacity), "Buffer capacity must be non-negative.");

        _bufferCapacity = (int) Math.Min(bufferCapacity, int.MaxValue);
        _leaveOpen = leaveOpen;

        _ringBuffer = new byte[_bufferCapacity];
    }

    public long? Length => _isEofReached ? _underlyingPosition : null;

    public bool TryRewind(long targetOffset)
    {
        if (targetOffset < _bufferedStartPosition || targetOffset > _underlyingPosition)
        {
            return false;
        }

        _currentPosition = targetOffset;
        return true;
    }

    public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        GaxPreconditions.CheckNotNull(buffer, nameof(buffer));
        GaxPreconditions.CheckArgument(offset >= 0, nameof(offset), "Offset must be non-negative.");
        GaxPreconditions.CheckArgument(count >= 0, nameof(count), "Count must be non-negative.");
        GaxPreconditions.CheckArgument(buffer.Length - offset >= count, nameof(offset), "Invalid offset or count for buffer length.");

        if (count == 0)
        {
            return 0;
        }

        int totalRead = 0;

        // Step 1: Satisfy read request from ring buffer if current position is behind underlying stream position
        if (count > 0 && _currentPosition < _underlyingPosition)
        {
            long availableInBuffer = _underlyingPosition - _currentPosition;
            int bytesToTake = (int) Math.Min(count, availableInBuffer);

            long offsetFromBufferStart = _currentPosition - _bufferedStartPosition;
            int bufferIndex = (int) ((_ringBufferStart + offsetFromBufferStart) % _bufferCapacity);

            int firstChunk = Math.Min(bytesToTake, _bufferCapacity - bufferIndex);
            Array.Copy(_ringBuffer, bufferIndex, buffer, offset, firstChunk);
            if (firstChunk < bytesToTake)
            {
                Array.Copy(_ringBuffer, 0, buffer, offset + firstChunk, bytesToTake - firstChunk);
            }

            _currentPosition += bytesToTake;
            offset += bytesToTake;
            count -= bytesToTake;
            totalRead += bytesToTake;
        }

        // Step 2: Consume peeked byte if present and current position has reached underlying stream position
        if (count > 0 && _currentPosition == _underlyingPosition && _extraByte.HasValue)
        {
            byte peekByte = _extraByte.Value;
            _extraByte = null;

            buffer[offset] = peekByte;
            AppendToRingBuffer(buffer, offset, 1);

            _underlyingPosition += 1;
            _currentPosition += 1;
            offset += 1;
            count -= 1;
            totalRead += 1;
        }

        // Step 3: Read from underlying stream if more bytes are requested and we are at the underlying stream position
        while (count > 0 && !_isEofReached)
        {
            int readFromStream = await _underlyingStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            if (readFromStream == 0)
            {
                _isEofReached = true;
                break;
            }

            AppendToRingBuffer(buffer, offset, readFromStream);

            _underlyingPosition += readFromStream;
            _currentPosition += readFromStream;
            offset += readFromStream;
            count -= readFromStream;
            totalRead += readFromStream;
        }

        // Step 4: For unseekable streams where a full buffer was read and EOF is not yet marked,
        // peek 1 byte ahead into _extraByte to determine if EOF has been reached.
        if (!_isEofReached && totalRead > 0 && count == 0 && !_extraByte.HasValue)
        {
            byte[] peekBuffer = new byte[1];
            int peekRead = await _underlyingStream.ReadAsync(peekBuffer, 0, 1, cancellationToken).ConfigureAwait(false);
            if (peekRead == 0)
            {
                _isEofReached = true;
            }
            else
            {
                _extraByte = peekBuffer[0];
            }
        }

        return totalRead;
    }

    private void AppendToRingBuffer(byte[] src, int srcOffset, int length)
    {
        if (_bufferCapacity == 0 || length == 0)
        {
            return;
        }

        if (length >= _bufferCapacity)
        {
            srcOffset += length - _bufferCapacity;
            length = _bufferCapacity;

            Array.Copy(src, srcOffset, _ringBuffer, 0, length);
            _ringBufferStart = 0;
            _ringBufferCount = length;
            _bufferedStartPosition = _underlyingPosition + (length - _bufferCapacity);
            return;
        }

        if (_ringBufferCount + length > _bufferCapacity)
        {
            int evictCount = (_ringBufferCount + length) - _bufferCapacity;
            _ringBufferStart = (_ringBufferStart + evictCount) % _bufferCapacity;
            _ringBufferCount -= evictCount;
            _bufferedStartPosition += evictCount;
        }

        int insertIndex = (_ringBufferStart + _ringBufferCount) % _bufferCapacity;
        int firstChunk = Math.Min(length, _bufferCapacity - insertIndex);
        Array.Copy(src, srcOffset, _ringBuffer, insertIndex, firstChunk);
        if (firstChunk < length)
        {
            Array.Copy(src, srcOffset + firstChunk, _ringBuffer, 0, length - firstChunk);
        }
        _ringBufferCount += length;
    }

    public void Dispose()
    {
        if (!_leaveOpen)
        {
            _underlyingStream.Dispose();
        }
        _ringBuffer = null;
        _extraByte = null;
    }
}
