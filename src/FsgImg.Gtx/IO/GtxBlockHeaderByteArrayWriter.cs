using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class GtxBlockHeaderByteArrayWriter : IGtxBlockHeaderWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public GtxBlockHeaderByteArrayWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public GtxBlockHeaderByteArrayWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IGtxBlockHeader gtxBlockHeader)
        {
            var span = new Span<byte>(_buffer, _offset, _count);

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.Magic);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.Size);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.MajorVersion);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.MinorVersion);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, (uint)gtxBlockHeader.BlockType);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.BlockSize);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.BlockId);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gtxBlockHeader.BlockIndex);
        }

        public Task WriteAsync(IGtxBlockHeader gtxBlockHeader, CancellationToken cancellationToken = default)
        {
            Write(gtxBlockHeader);
            return Task.CompletedTask;
        }
    }
}
