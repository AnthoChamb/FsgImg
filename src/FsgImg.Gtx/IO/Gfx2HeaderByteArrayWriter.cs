using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class Gfx2HeaderByteArrayWriter : IGfx2HeaderWriter
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public Gfx2HeaderByteArrayWriter(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public Gfx2HeaderByteArrayWriter(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public void Write(IGfx2Header gfx2Header)
        {
            var span = new Span<byte>(_buffer, _offset, _count);

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.Magic);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.Size);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.MajorVersion);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.MinorVersion);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.GpuVersion);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.AlignMode);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.Reserved);
            span = span.Slice(sizeof(uint));

            BinaryPrimitives.WriteUInt32BigEndian(span, gfx2Header.Reserved2);
        }

        public Task WriteAsync(IGfx2Header gfx2Header, CancellationToken cancellationToken = default)
        {
            Write(gfx2Header);
            return Task.CompletedTask;
        }
    }
}
