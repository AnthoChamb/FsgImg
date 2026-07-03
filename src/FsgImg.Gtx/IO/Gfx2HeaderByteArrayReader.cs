using FsgImg.Gtx.Abstractions.Interfaces;
using FsgImg.Gtx.Abstractions.Interfaces.IO;
using FsgImg.Gtx.Exceptions;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Gtx.IO
{
    public class Gfx2HeaderByteArrayReader : IGfx2HeaderReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public Gfx2HeaderByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public Gfx2HeaderByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IGfx2Header Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var gfx2Header = new Gfx2Header();
            var magic = BinaryPrimitives.ReadUInt32BigEndian(span);
            InvalidGfx2HeaderMagicException.ThrowIfInvalid(magic);
            gfx2Header.Magic = magic;
            span = span.Slice(sizeof(uint));

            var size = BinaryPrimitives.ReadUInt32BigEndian(span);
            InvalidGfx2HeaderSizeException.ThrowIfInvalid(size);
            gfx2Header.Size = size;
            span = span.Slice(sizeof(uint));

            gfx2Header.MajorVersion = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gfx2Header.MinorVersion = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gfx2Header.GpuVersion = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gfx2Header.AlignMode = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gfx2Header.Reserved = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            gfx2Header.Reserved2 = BinaryPrimitives.ReadUInt32BigEndian(span);

            return gfx2Header;
        }

        public Task<IGfx2Header> ReadAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Read());
        }
    }
}
