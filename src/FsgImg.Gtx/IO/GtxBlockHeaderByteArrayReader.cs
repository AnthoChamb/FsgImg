using FsgImg.Gtx.Abstractions.Enums;
using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.Exceptions;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class GtxBlockHeaderByteArrayReader : IGtxBlockHeaderReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public GtxBlockHeaderByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public GtxBlockHeaderByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IGtxBlockHeader Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var gtxBlockHeader = new GtxBlockHeader();
            var magic = BinaryPrimitives.ReadUInt32BigEndian(span);
            InvalidGtxBlockHeaderMagicException.ThrowIfInvalid(magic);
            gtxBlockHeader.Magic = magic;
            span = span.Slice(sizeof(uint));

            var size = BinaryPrimitives.ReadUInt32BigEndian(span);
            InvalidGtxBlockHeaderSizeException.ThrowIfInvalid(size);
            gtxBlockHeader.Size = size;
            span = span.Slice(sizeof(uint));

            gtxBlockHeader.MajorVersion = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gtxBlockHeader.MinorVersion = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gtxBlockHeader.BlockType = (GtxBlockType)BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gtxBlockHeader.BlockSize = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gtxBlockHeader.BlockId = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gtxBlockHeader.BlockIndex = BinaryPrimitives.ReadUInt32BigEndian(span);

            return gtxBlockHeader;
        }

        public Task<IGtxBlockHeader> ReadAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Read());
        }
    }
}
