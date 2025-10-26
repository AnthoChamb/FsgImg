using FsgImg.Pvr.Abstractions.Enums;
using FsgImg.Pvr.Abstractions.Interfaces;
using FsgImg.Pvr.Abstractions.Interfaces.IO;
using FsgImg.Pvr.Exceptions;
using System;
using System.Buffers.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.Pvr.IO
{
    public class PvrHeaderByteArrayReader : IPvrHeaderReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public PvrHeaderByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public PvrHeaderByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IPvrHeader Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var version = BinaryPrimitives.ReadUInt32LittleEndian(span);
            InvalidPvrVersionException.ThrowIfInvalid(version);

            var pvrHeader = new PvrHeader();
            pvrHeader.Version = version;
            span = span.Slice(sizeof(uint));

            pvrHeader.Flags = (PvrHeaderFlags)BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.PixelFormat = (PvrPixelFormat)BinaryPrimitives.ReadUInt64LittleEndian(span);
            span = span.Slice(sizeof(ulong));

            pvrHeader.ColourSpace = (PvrColourSpace)BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.ChannelType = (PvrChannelType)BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.Height = BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.Width = BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.Depth = BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.NumSurfaces = BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.NumFaces = BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.MipmapCount = BinaryPrimitives.ReadUInt32LittleEndian(span);
            span = span.Slice(sizeof(uint));

            pvrHeader.MetadataSize = BinaryPrimitives.ReadUInt32LittleEndian(span);

            return pvrHeader;
        }

        public Task<IPvrHeader> ReadAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Read());
        }
    }
}
